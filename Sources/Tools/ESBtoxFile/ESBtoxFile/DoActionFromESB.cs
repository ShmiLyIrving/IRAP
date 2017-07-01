using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace ESBtoxFile
{
    public delegate void LogOutputHandler(string msg, string modeName, ToolTipIcon icon);
    public delegate void AppendMessageContext(string context);

    internal class DoActionFromESB
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string esbUri = "";
        private string esbQueueName = "";
        private string esbExCode = "";
        private string esbFilter = "";

        private IConnectionFactory factory = null;
        private IConnection connection = null;
        private ISession session = null;
        private IMessageConsumer consumer = null;
        /// <summary>
        /// 当前 ESB 连接状态
        /// 0: 未连接;
        /// 1: 正在连接中;
        /// 2: 连接成功
        /// </summary>
        private int esbConnectStatus = 0;
        /// <summary>
        /// 上次尝试 ESB 连接时间
        /// </summary>
        private DateTime lastESBConnectTime = DateTime.Now;
        /// <summary>
        /// 再次尝试连接 ESB 的间隔时间
        /// </summary>
        private int esbReconnectSpantime = 60;

        private Timer tmrReconnect = new Timer();

        public DoActionFromESB(string uri, string queueName, string exCode,string filter)
        {
            esbUri = uri;
            esbQueueName = queueName;
            esbExCode = exCode;
            esbFilter = filter;
            tmrReconnect.Interval = 100;
            tmrReconnect.Tick += TmrReconnect_Tick;
        }

        ~DoActionFromESB()
        {
            tmrReconnect.Enabled = false;
            tmrReconnect.Tick -= TmrReconnect_Tick;
            tmrReconnect = null;
        }

        private void TmrReconnect_Tick(object sender, EventArgs e)
        {
            tmrReconnect.Enabled = false;
            try
            {
                switch (esbConnectStatus)
                {
                    case 0:
                        TimeSpan span = DateTime.Now - lastESBConnectTime;
                        if (span.TotalSeconds >= esbReconnectSpantime)
                        {
                            CloseConsumer();
                            System.Threading.Thread.Sleep(500);
                            InitConsumer();
                        }
                        break;
                }
            }
            finally
            {
                tmrReconnect.Enabled = true;
            }
        }

        public LogOutputHandler OutputLog = null;
        public AppendMessageContext Write2Queue = null;

        private void WriteLog(string msg, string modeName, ToolTipIcon icon)
        {
            if (OutputLog != null)
                OutputLog(msg, modeName, icon);
        }

        private void InitConsumer()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            try
            {
                WriteLog("连接 ESB ......", strProcedureName, ToolTipIcon.Info);

                esbConnectStatus = 1;
                lastESBConnectTime = DateTime.Now;

                string brokerUri =
                    string.Format(
                        "failover://({0})?&transport.startupMaxReconnectAttempts=1&" +
                        "transport.initialReconnectDelay=10",
                        esbUri);
                factory = new ConnectionFactory(brokerUri);
                connection = factory.CreateConnection();
                connection.ClientId = System.Guid.NewGuid().ToString();
                connection.Start();

                session = connection.CreateSession();
                consumer =
                    session.CreateConsumer(
                        new ActiveMQQueue(esbQueueName),
                        string.Format( "Filter='{0}' AND ExCode='{1}'",  esbFilter,esbExCode));
                consumer.Listener += new MessageListener(consumer_Listener);

                esbConnectStatus = 2;

                WriteLog("ESB 连接成功，开始接收消息......", strProcedureName, ToolTipIcon.Info);
            }
            catch (Exception error)
            {
                esbConnectStatus = 0;
                lastESBConnectTime = DateTime.Now;

                WriteLog(
                    string.Format(
                        "EBS 连接失败：{0}",
                        error.Message),
                    strProcedureName,
                    ToolTipIcon.Error);
            }
        }

        private void CloseConsumer()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (consumer != null)
            {
                consumer.Close();
                consumer = null;
            }
            if (session != null)
            {
                session.Close();
                session = null;
            }
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }

            factory = null;

            esbConnectStatus = 0;
            lastESBConnectTime = DateTime.Now;

            OutputLog("停止服务，关闭 ESB 连接。", strProcedureName, ToolTipIcon.Info);
        }

        private void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;

            if (Write2Queue != null)
                Write2Queue(msg.Text);
        }

        public void Start()
        {
            if (esbConnectStatus == 1 || esbConnectStatus == 2)
                return;
            else
            {
                InitConsumer();
                tmrReconnect.Enabled = true;
            }
        }

        public void Stop()
        {
            tmrReconnect.Enabled = false;
            CloseConsumer();
        }
    }
}
