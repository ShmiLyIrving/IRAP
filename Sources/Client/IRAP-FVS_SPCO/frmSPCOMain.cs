using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Configuration;
using System.Management;
using System.Reflection;
using System.Xml;

using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

using IRAP.Global;
using IRAP.Entity.SSO;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_SPCO
{
    public partial class frmSPCOMain : XtraForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public delegate void RedrawingSPCChartMethod(
            XtraTabControl tabControl, 
            string t107Code, 
            string pwoNo, 
            int t20LeafID);

        private const int WS_SHOWMAXIMIZE = 3;

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        private string brokerUri = "";
        private string queueName = "";
        private string macAddress = "";
        private StationLogin stationUser = null;
        private List<WIPStationProductionStatus> workUnits = new List<WIPStationProductionStatus>();

        public frmSPCOMain()
        {
            InitializeComponent();

            #region 从程序配置文件中读取 ActiveMQ 配置信息
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings["ActiveMQ_URI"] != null)
                brokerUri = config.AppSettings.Settings["ActiveMQ_URI"].Value;
            if (brokerUri.Trim() == "")
                brokerUri = "tcp://192.168.57.208:61616";

            if (config.AppSettings.Settings["ActiveMQ_QueueName"] != null)
                queueName = config.AppSettings.Settings["ActiveMQ_QueueName"].Value;
            if (queueName.Trim() == "")
                queueName = "firstQueue";
            #endregion

            #region
            if (config.AppSettings.Settings["Virtual Station Used"] != null)
            {
                if (config.AppSettings.Settings["Virtual Station Used"].Value.ToUpper() == "TRUE")
                {
                    if (config.AppSettings.Settings["Virtual Station"] != null)
                    {
                        macAddress = config.AppSettings.Settings["Virtual Station"].Value;
                    }
                }
            }
            #endregion

            if (macAddress.Trim() == "")
                GetMacAddress();
        }

        #region 自定义函数
        private void HandleRunningInstance()
        {
            Process current = Process.GetCurrentProcess();

            IntPtr hWnd = GetForegroundWindow();
            if (hWnd != current.MainWindowHandle)
            {
                ShowWindowAsync(current.MainWindowHandle, WS_SHOWMAXIMIZE);
                SetForegroundWindow(current.MainWindowHandle);
            }
        }

        private void InitConsumer(string filterString)
        {
            IConnectionFactory factory = new ConnectionFactory(brokerUri);
            IConnection connection = factory.CreateConnection();
            connection.ClientId = Guid.NewGuid().ToString();
            connection.Start();

            ISession session = connection.CreateSession();
            IMessageConsumer consumer =
                session.CreateConsumer(
                    new ActiveMQQueue(queueName),
                    string.Format("filter='{0}'", filterString));
            consumer.Listener += new MessageListener(consumer_Listener);
        }

        private void consumer_Listener(IMessage message)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            ITextMessage msg = (ITextMessage)message;

            // 收到消息后，将当前应用激活，并置于最前面
            HandleRunningInstance();

            if (msg.Text.Trim() != "")
            {
                string text = msg.Text.Trim();
                XmlDocument xmlDoc = new XmlDocument();

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    xmlDoc.LoadXml(text);

                    XmlNode node = xmlDoc.SelectSingleNode("Content/Message");
                    if (node != null)
                    {
                        string pwoNo = "";
                        string t107Code = "";
                        int t20LeafID = 0;
                        DateTime sendTime = DateTime.Now;

                        if (node.Attributes["T107Code"] != null)
                            t107Code = node.Attributes["T107Code"].Value;
                        else
                            return;
                        if (node.Attributes["PWONo"] != null)
                            pwoNo = node.Attributes["PWONo"].Value;
                        else
                            return;
                        if (node.Attributes["T20LeafID"] != null)
                            t20LeafID = int.Parse(node.Attributes["T20LeafID"].Value);
                        else
                            return;
                        if (node.Attributes["SendDateTime"] != null)
                            sendTime = DateTime.Parse(node.Attributes["SendDateTime"].Value);
                        else
                            return;

                        if ((DateTime.Now - sendTime).TotalSeconds <= 180)
                        {
                            // 切换到消息中指定工位的显示面板
                            object[] parameters = new object[4];
                            parameters[0] = tcMain;
                            parameters[1] = t107Code;
                            parameters[2] = pwoNo;
                            parameters[3] = t20LeafID;

                            BeginInvoke(new RedrawingSPCChartMethod(RedrawingSPCChart), parameters);
                        }
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void RedrawingSPCChart(
            XtraTabControl tabControl,
            string t107Code,
            string pwoNo,
            int t20LeafID)
        {
            foreach (XtraTabPage page in tabControl.TabPages)
            {
                if (page.Tag == null)
                    return;

                WIPStationProductionStatus workUnit = page.Tag as WIPStationProductionStatus;
                if (workUnit.T107Code == t107Code)
                {

                    tabControl.SelectedTabPage = page;
                    foreach (Control control in page.Controls)
                    {
                        if (control is ucRainBowChart)
                        {
                            ucRainBowChart chart = control as ucRainBowChart;
                            chart.DrawChart(stationUser, workUnit, pwoNo, t20LeafID);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取当前真实的 MAC 地址
        /// </summary>
        protected virtual void GetMacAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                try
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        macAddress = mo["MacAddress"].ToString();
                        macAddress = macAddress.Replace(":", "");
                        break;
                    }
                }
                catch 
                {
                    mo.Dispose();
                }
            }
        }

        /// <summary>
        /// Pad 登录
        /// </summary>
        private StationLogin PadLogin(
            ref int errCode,
            ref string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                StationLogin stationUser = new StationLogin();

                IRAPUserClient.Instance.sfn_GetInfo_StationLogin(
                    macAddress != "" ? macAddress : "60010MDV1101001",
                    ref stationUser,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                    return stationUser;
                else
                    return null;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取当前站点的所有工位
        /// </summary>
        private List<WIPStationProductionStatus> GetWorkUnits(
            ref int errCode,
            ref string errText)
        {
            string strProcedureName =
                 string.Format(
                     "{0}.{1}",
                     className,
                     MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<WIPStationProductionStatus> rlt =
                    new List<WIPStationProductionStatus>();

                IRAPMDMClient.Instance.ufn_GetList_WIPStationProductionStatus(
                    stationUser.CommunityID,
                    stationUser.SysLogID,
                    0,
                    ref rlt,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("{0}.{1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                    return rlt;
                else
                    return null;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void HideErrorMessage()
        {
            if (lblErrorMessage.Visible)
                lblErrorMessage.Visible = false;
            if (!xtraScrollableControl.Visible)
                xtraScrollableControl.Visible = true;

            lblErrorMessage.Text = "";
        }

        private void ShowErrorMessage(string msg)
        {
            lblErrorMessage.Text = msg;

            if (!lblErrorMessage.Visible)
                lblErrorMessage.Visible = true;
            if (xtraScrollableControl.Visible)
                xtraScrollableControl.Visible = false;
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frmSPCOMain_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Application.DoEvents();

            int errCode = 0;
            string errText = "";

            if (stationUser == null || stationUser.SysLogID <= 0)
            {
                #region 获取当前站点的登录信息
                stationUser = PadLogin(ref errCode, ref errText);
                if (errCode != 0)
                {
                    ShowErrorMessage(errText);
                    return;
                }
                else
                {
                    HideErrorMessage();
                }
                #endregion
            }

            if (stationUser != null)
            {
                if (stationUser.SysLogID > 0)
                {
                    if (!xtraScrollableControl.Visible)
                        xtraScrollableControl.Visible = true;

                    if (workUnits.Count == 0)
                    {
                        btnClose.Visible = false;
                        try
                        {
                            tcMain.TabPages.Clear();
                            workUnits = GetWorkUnits(ref errCode, ref errText);

                            if (errCode == 0)
                            {
                                HideErrorMessage();

                                foreach (WIPStationProductionStatus workUnit in workUnits)
                                {
                                    XtraTabPage page = tcMain.TabPages.Add();
                                    page.Text = workUnit.T107Name;
                                    page.Tag = workUnit;

                                    ucRainBowChart chart = new ucRainBowChart();
                                    chart.Dock = DockStyle.Fill;
                                    chart.Parent = page;

                                    //chart.DrawChart(stationUser, workUnit, "1C3PK1A7BA50422003", 352942);
                                    InitConsumer(workUnit.T107Code);
                                }
                            }
                            else
                            {
                                ShowErrorMessage(errText);
                            }
                        }
                        finally
                        {
                            btnClose.Visible = true;
                        }
                    }
                }
            }
        }
    }
}