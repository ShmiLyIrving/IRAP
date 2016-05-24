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

using DevExpress.XtraEditors;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace IRAP_FVS_SPCO
{
    public partial class frmSPCOMain : XtraForm
    {
        private const int WS_SHOWMAXIMIZE = 3;

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private string brokerUri = "";
        private string queueName = "";

        public frmSPCOMain()
        {
            InitializeComponent();

            #region 从程序配置文件中读取 ActiveMQ 配置信息
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings["ActiveMQ_URI"] != null)
                brokerUri = config.AppSettings.Settings["ActiveMQ_URI"].Value.ToString();
            if (brokerUri.Trim() == "")
                brokerUri = "tcp://192.168.57.208:61616";

            if (config.AppSettings.Settings["ActiveMQ_QueueName"] != null)
                queueName = config.AppSettings.Settings["ActiveMQ_QueueName"].Value.ToString();
            if (queueName.Trim() == "")
                queueName = "firstQueue";
            #endregion

            InitConsumer();
        }

        #region 自定义函数
        private void HandleRunningInstance()
        {
            Process current = Process.GetCurrentProcess();

            ShowWindowAsync(current.MainWindowHandle, WS_SHOWMAXIMIZE);
            SetForegroundWindow(current.MainWindowHandle);
        }

        private void InitConsumer()
        {
            IConnectionFactory factory = new ConnectionFactory(brokerUri);
            IConnection connection = factory.CreateConnection();
            connection.ClientId = Guid.NewGuid().ToString();
            connection.Start();

            ISession session = connection.CreateSession();
            IMessageConsumer consumer =
                session.CreateConsumer(
                    new ActiveMQQueue(queueName),
                    "filter='121.225.92.136'");
            consumer.Listener += new MessageListener(consumer_Listener);
        }

        private void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;

            // 收到消息后，将当前应用激活，并置于最前面
            HandleRunningInstance();
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
    }
}