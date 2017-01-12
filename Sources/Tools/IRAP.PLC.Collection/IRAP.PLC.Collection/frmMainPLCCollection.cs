using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Threading;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace IRAP.PLC.Collection
{
    public partial class frmMainPLCCollection : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private CustomSendToESBThread dataCollect = null;

        private bool canClosed = false;
        private bool boolRunning = false;

        private OleDbConnection connection = null;

        public frmMainPLCCollection()
        {
            InitializeComponent();
        }

        #region 自定义函数
        private void ShowForm()
        {
            Show();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            Activate();
            SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);
        }

        private void HideForm()
        {
            Hide();
            ShowInTaskbar = false;
        }
        #endregion

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                ShowForm();
            else
            {
                WindowState = FormWindowState.Minimized;
                HideForm();
            }
        }

        private void frmMainPLCCollection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClosed)
                e.Cancel = false;
            else
            {
                e.Cancel = true;
                HideForm();
            }
        }

        private void frmMainPLCCollection_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                HideForm();
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            canClosed = true;
            Close();
        }

        private void frmMainPLCCollection_Load(object sender, EventArgs e)
        {
            notifyIcon.Text = Text;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (SystemParams.Instance.DataFileName == "")
            {
                MessageBox.Show(
                    "工艺参数数据库文件没有配置！", 
                    "系统信息", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            if (dataCollect != null)
                dataCollect = null;

            switch (SystemParams.Instance.DeviceType)
            {
                case 0:
                    dataCollect = new DC_CPPlating_NB(mmoLogs);
                    break;
                case 1:
                    dataCollect = new DC_Baking_NB(mmoLogs);
                    break;
                case 2:
                    dataCollect = new DC_Baking_NMT(mmoLogs);
                    break;
            }

            if (dataCollect == null)
            {
                MessageBox.Show(
                    "不支持当前选择的设备类型",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else
                dataCollect.StartWatch();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            tsmiConfiguration.Enabled = !boolRunning;
        }

        private void tsmiConfiguration_Click(object sender, EventArgs e)
        {
            using (frmSystemParams frmParams = new frmSystemParams())
            {
                frmParams.ShowDialog();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (dataCollect != null)
            {
                if (dataCollect.Enabled)
                    dataCollect.Enabled = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            try
            {
                if (connection == null)
                {
                    connection =
                        new OleDbConnection(
                            string.Format(
                                "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                "Data Source=\"{0}\";Persist Security Info=false",
                                SystemParams.Instance.DataFileName));
                    connection.Open();
                }

                try
                {
                    switch (SystemParams.Instance.DeviceCode)
                    {
                        case "BF-0016":
                        case "BF-0824":
                        case "BF-0017":
                            GetData_NB(connection, SystemParams.Instance.DeviceCode);
                            break;
                        case "BF-0825":
                            GetData_NMT(connection);
                            break;
                    }
                }
                catch (Exception error)
                {

                }
            }
            finally
            {
                timer.Enabled = true;
            }
        }

        private void GetData_NMT(OleDbConnection conn)
        {
            int deltaTimeSpan = SystemParams.Instance.DeltaTimeSpan;
            DateTime beginDT = SystemParams.Instance.BeginDT;
            DateTime endDT = beginDT.AddMinutes(deltaTimeSpan);

            if (endDT < DateTime.Now)
            {
                #region 采集烤箱1的数据
                {
                    string sql =
                        string.Format(
                            "SELECT * FROM 烤箱1存盘数据_MCGS " +
                            "WHERE MCGS_Time >= #{0}# AND MCGS_Time <= #{1}#",
                            beginDT,
                            endDT);

                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string xml = "";

                        if (reader["Oven1_Product1"].ToString().Trim() != "")
                        {
                            xml =
                                string.Format(
                                    "<ROOT>" +
                                    "<Row T133Code=\"{0}\" Time=\"{1}\" MCGS_TimeMS=\"{2}\" " +
                                    "第1台PV=\"{3}\" 第2台PV=\"{4}\" 第3台PV=\"{5}\" " +
                                    "第4台PV=\"{6}\" 第5台PV=\"{7}\" ProductNo1=\"{8}\" " +
                                    "ProductNo2=\"{9}\" ProductNo3=\"{10}\" Productno4=\"{11}\" " +
                                    "ProductNo5=\"{12}\" />" +
                                    "</ROOT>",
                                    "BF-0825-1",
                                    reader["MCGS_Time"].ToString(),
                                    reader["MCGS_TimeMS"].ToString(),
                                    reader["一台PV"].ToString(),
                                    reader["二台PV"].ToString(),
                                    reader["三台PV"].ToString(),
                                    reader["四台PV"].ToString(),
                                    reader["五台PV"].ToString(),
                                    reader["Oven1_Product1"].ToString(),
                                    reader["Oven1_Product2"].ToString(),
                                    reader["Oven1_Product3"].ToString(),
                                    reader["Oven1_Product4"].ToString(),
                                    reader["Oven1_Product5"].ToString());
                            SendToESB(xml);
                        }

                        Thread.Sleep(100);
                    }
                }
                #endregion

                #region 采集烤箱2的数据
                {
                    string sql =
                        string.Format(
                            "SELECT * FROM 烤箱2存盘数据_MCGS " +
                            "WHERE MCGS_Time >= #{0}# AND MCGS_Time <= #{1}#",
                            beginDT,
                            endDT);

                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string xml = "";

                        if (reader["Oven2_Product1"].ToString().Trim() != "")
                        {
                            xml =
                                string.Format(
                                    "<ROOT>" +
                                    "<Row T133Code=\"{0}\" Time=\"{1}\" MCGS_TimeMS=\"{2}\" " +
                                    "第6台PV=\"{3}\" 第7台PV=\"{4}\" 第8台PV=\"{5}\" " +
                                    "第9台PV=\"{6}\" 第10台PV=\"{7}\" ProductNo1=\"{8}\" " +
                                    "ProductNo2=\"{9}\" ProductNo3=\"{10}\" Productno4=\"{11}\" " +
                                    "ProductNo5=\"{12}\" />" +
                                    "</ROOT>",
                                    "BF-0825-2",
                                    reader["MCGS_Time"].ToString(),
                                    reader["MCGS_TimeMS"].ToString(),
                                    reader["六台PV"].ToString(),
                                    reader["七台PV"].ToString(),
                                    reader["八台PV"].ToString(),
                                    reader["九台PV"].ToString(),
                                    reader["十台PV"].ToString(),
                                    reader["Oven2_Product1"].ToString(),
                                    reader["Oven2_Product2"].ToString(),
                                    reader["Oven2_Product3"].ToString(),
                                    reader["Oven2_Product4"].ToString(),
                                    reader["Oven2_Product5"].ToString());
                            SendToESB(xml);

                            Thread.Sleep(100);
                        }
                    }
                }
                #endregion

                #region 采集烤箱3的数据
                {
                    string sql =
                        string.Format(
                            "SELECT * FROM 烤箱3存盘数据_MCGS " +
                            "WHERE MCGS_Time >= #{0}# AND MCGS_Time <= #{1}#",
                            beginDT,
                            endDT);

                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string xml = "";

                        if (reader["Oven3_Product1"].ToString().Trim() != "")
                        {
                            xml =
                                string.Format(
                                    "<ROOT>" +
                                    "<Row T133Code=\"{0}\" Time=\"{1}\" MCGS_TimeMS=\"{2}\" " +
                                    "第11台PV=\"{3}\" 第12台PV=\"{4}\" 第13台PV=\"{5}\" " +
                                    "第14台PV=\"{6}\" 第15台PV=\"{7}\" ProductNo1=\"{8}\" " +
                                    "ProductNo2=\"{9}\" ProductNo3=\"{10}\" Productno4=\"{11}\" " +
                                    "ProductNo5=\"{12}\" />" +
                                    "</ROOT>",
                                    "BF-0825-3",
                                    reader["MCGS_Time"].ToString(),
                                    reader["MCGS_TimeMS"].ToString(),
                                    reader["十一台PV"].ToString(),
                                    reader["十二台PV"].ToString(),
                                    reader["十三台PV"].ToString(),
                                    reader["十四台PV"].ToString(),
                                    reader["十五台PV"].ToString(),
                                    reader["Oven3_Product1"].ToString(),
                                    reader["Oven3_Product2"].ToString(),
                                    reader["Oven3_Product3"].ToString(),
                                    reader["Oven3_Product4"].ToString(),
                                    reader["Oven3_Product5"].ToString());
                            SendToESB(xml);

                            Thread.Sleep(100);
                        }
                    }
                }
                #endregion

                SystemParams.Instance.BeginDT = endDT;
            }
        }

        private void GetData_NB(OleDbConnection conn, string DeviceCode)
        {
            int deltaTimeSpan = SystemParams.Instance.DeltaTimeSpan;
            DateTime beginDT = SystemParams.Instance.BeginDT;
            DateTime endDT = beginDT.AddMinutes(deltaTimeSpan);

            if (endDT < DateTime.Now)
            {
                #region 采集入线表的数据
                {
                    string sql =
                        string.Format(
                            "SELECT * FROM 入线表 " +
                            "WHERE CDATE(出线时间) BETWEEN #{0}# AND #{1}#",
                            beginDT,
                            endDT);

                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string xml =
                                string.Format(
                                    "<ROOT>" +
                                    "<Row T133Code=\"{0}\" 飞巴号=\"{1}\" 零件号码=\"{2}\" " +
                                    "零件批次=\"{3}\" 零件数量=\"{4}\" 入线时间=\"{5}\" " +
                                    "出线时间=\"{6}\" />" +
                                    "</ROOT>",
                                    DeviceCode,
                                    reader["飞巴号"].ToString(),
                                    reader["零件号码"].ToString(),
                                    reader["零件批次"].ToString(),
                                    reader["零件数量"].ToString(),
                                    reader["入线时间"].ToString(),
                                    reader["出线时间"].ToString());
                        SendToESB(xml);

                        Thread.Sleep(100);
                    }
                }
                #endregion

                #region 采集线状态历史的数据
                {
                    string sql =
                        string.Format(
                            "SELECT * FROM 线状态历史 " +
                            "WHERE CDATE(时间) BETWEEN #{0}# AND #{1}#",
                            beginDT,
                            endDT);

                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string xml = "";

                        if (reader["Oven1_Product1"].ToString().Trim() != "")
                        {
                            xml =
                                string.Format(
                                    "<ROOT>" +
                                    "<Row T133Code=\"{0}\" 槽工位号=\"{1}\" 运行工步=\"{2}\" " +
                                    "槽位名称=\"{3}\" 零件号码=\"{4}\" 零件批次=\"{5}\" " +
                                    "设定时间=\"{6}\" 入槽时间=\"{7}\" 设定温度=\"{8}\" " +
                                    "实际温度=\"{9}\" 设定电流=\"{10}\" 实际电流=\"{11}\" " +
                                    "实际电压=\"{12}\" 零件数量=\"{13}\" 安培小时=\"{14}\" " +
                                    "飞巴号=\"{15}\" 时间=\"{16}\" 设定温度波形=\"{17}\" " +
                                    "实际温度波形=\"{18}\" 设定电流波形=\"{19}\" 实际电流波形=\"{20}\" " +
                                    "实际电压波形=\"{21}\" />" +
                                    "</ROOT>",
                                    DeviceCode,
                                    reader["槽工位号"].ToString(),
                                    reader["运行工步"].ToString(),
                                    reader["槽位名称"].ToString(),
                                    reader["零件号码"].ToString(),
                                    reader["零件批次"].ToString(),
                                    reader["设定时间"].ToString(),
                                    reader["入槽时间"].ToString(),
                                    reader["设定温度"].ToString(),
                                    reader["实际温度"].ToString(),
                                    reader["设定电流"].ToString(),
                                    reader["实际电流"].ToString(),
                                    reader["实际电压"].ToString(),
                                    reader["零件数量"].ToString(),
                                    reader["安培小时"].ToString(),
                                    reader["飞巴号"].ToString(),
                                    reader["时间"].ToString(),
                                    reader["设定温度波形"].ToString(),
                                    reader["实际温度波形"].ToString(),
                                    reader["设定电流波形"].ToString(),
                                    reader["实际电流波形"].ToString(),
                                    reader["实际电压波形"].ToString());
                            SendToESB(xml);

                            Thread.Sleep(100);
                        }
                    }
                }
                #endregion

                SystemParams.Instance.BeginDT = endDT;
            }
        }

        private IConnectionFactory factory = null;
        private void SendToESB(string bodyXML)
        {
            string brokerUri =
                string.Format(
                    "failover://({0})?&transport.startupMaxReconnectAttempts=2&" +
                    "transport.initialReconnectDelay=10",
                    SystemParams.Instance.ActiveMQ_URI);

            try
            {
                if (factory == null)
                    factory = new ConnectionFactory(brokerUri);

                using (IConnection esbConn = factory.CreateConnection())
                {
                    using (ISession session = esbConn.CreateSession())
                    {
                        IMessageProducer prod =
                            session.CreateProducer(
                                new ActiveMQQueue(
                                    SystemParams.Instance.ActiveMQ_QueueName));
                        ITextMessage message = prod.CreateTextMessage();
                        message.Text =
                            string.Format(
                                "<?xml version=\"1.0\"?>" +
                                "<Softland><Head><ExCode>MES2DPA</ExCode>" +
                                "<CorrelationID>{0}</CorrelationID>" +
                                "<CommunityID>60002</CommunityID>" +
                                "<SysLogID>1</SysLogID>" +
                                "<UserCode>Admin</UserCode>" +
                                "<AgencyLeaf>1</AgencyLeaf>" +
                                "<RoleLeaf>2</RoleLeaf>" +
                                "<StationID>60002MNGMT001</StationID>" +
                                "</Head><Body>{1}</Body></Softland>",
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                bodyXML);
                        message.Properties.SetString("Filter", "Device");
                        message.Properties.SetString("ESBServerAddr", "http://192.168.57.210:16911/RESTFul/SendMQ/");
                        message.Properties.SetString("ExCode", "MES2DPA");

                        prod.Send(message, MsgDeliveryMode.Persistent, MsgPriority.Normal, TimeSpan.MinValue);
                    }
                }
            }
            catch (Exception error)
            {

            }
        }
    }
}
