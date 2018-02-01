using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Reflection;
using System.Xml;
using System.IO;

using DevExpress.XtraEditors;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

using IRAP.Global;

namespace IRAP.PLC.Collection
{
    internal abstract class CustomSendToESBThread
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        // 申明委托
        protected delegate void InvokeAddMessage(string msg);
        protected delegate void InvokeClearLogs();
        protected delegate void InvokeSaveCheckPoint(DateTime lastCheckPoint);

        protected MemoEdit mmeLog;

        /// <summary>
        /// 线程是否运行
        /// </summary>
        protected bool isThreadStarted = false;
        protected Thread thread = null;

        protected object locker = new object();

        public CustomSendToESBThread(MemoEdit displayLog)
        {
            mmeLog = displayLog;
        }

        ~CustomSendToESBThread()
        {
            if (prod != null)
            {
                prod.Close();
                prod = null;
            }
            if (session != null)
            {
                session.Close();
                session = null;
            }
            if (esbConn != null)
            {
                esbConn.Close();
                esbConn = null;
            }
            if (factory != null)
            {
                factory = null;
            }
        }

        public bool Enabled
        {
            get { return isThreadStarted; }
            set
            {
                if (value)
                {
                    if (!isThreadStarted)
                        StartWatch();
                }
                else
                    isThreadStarted = value;
            }
        }

        protected void AddLog(string msg)
        {
            if (mmeLog.Lines.Length > 100)
                mmeLog.Text = "";

            if (msg == "")
                mmeLog.Text += "\r\n";
            else
                mmeLog.Text +=
                    string.Format(
                        "{0}: {1}\r\n",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        msg);

            mmeLog.SelectionStart = mmeLog.Text.Length;
            mmeLog.ScrollToCaret();

            Thread.Sleep(100);

            WriteLog.Instance.Write(msg, className);
        }

        protected void ClearLogs()
        {
            mmeLog.Text = "";
        }

        private void SaveCheckPoint(DateTime lastCheckPoint)
        {
            SystemParams.Instance.BeginDT = lastCheckPoint;
        }

        private void SaveParams(string key, string value)
        {
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public void StartWatch()
        {
            if (!isThreadStarted)
            {
                thread = new Thread(new ThreadStart(Do));

                mmeLog.BeginInvoke(
                    new InvokeClearLogs(ClearLogs),
                    new object[] { });
                string message =
                        string.Format(
                            "开始从 {0} 中采集工艺参数数据...",
                            SystemParams.Instance.DataFileName);
                mmeLog.BeginInvoke(
                    new InvokeAddMessage(AddLog),
                    new object[] { message });

                isThreadStarted = true;

                thread.IsBackground = true;
                thread.Start();
            }
        }

        protected void WriteLogInThread(string message)
        {
            mmeLog.BeginInvoke(
                new InvokeAddMessage(AddLog),
                new object[] { message });
        }

        protected void SaveCheckPointInThread(DateTime lastCheckPoint)
        {
            WriteLogInThread(
                string.Format("保存最近的检查点：{0}", lastCheckPoint.ToString()));

            mmeLog.BeginInvoke(
                new InvokeSaveCheckPoint(SaveCheckPoint),
                new object[] { lastCheckPoint });
        }

        private IConnectionFactory factory = null;
        private IConnection esbConn = null;
        private ISession session = null;
        private IMessageProducer prod = null;
        protected void SendToESB(XmlDocument xml)
        {
            string brokerUri =
                string.Format(
                    "failover://({0})?&transport.startupMaxReconnectAttempts=2&" +
                    "transport.initialReconnectDelay=10",
                    SystemParams.Instance.ActiveMQ_URI);

            try
            {
                if (factory == null)
                {
                    factory = new ConnectionFactory(brokerUri);
                    esbConn = factory.CreateConnection();
                    session = esbConn.CreateSession();
                    prod = session.CreateProducer(
                        new ActiveMQQueue(
                            SystemParams.Instance.ActiveMQ_QueueName));
                }

                ITextMessage message = prod.CreateTextMessage();
                message.Text = FormatXML(xml); 
                message.Properties.SetString("ESBServerAddr", "");
                if (!string.IsNullOrEmpty(SystemParams.Instance.ExCode))
                {
                    message.Properties.SetString("ExCode", SystemParams.Instance.ExCode);
                    message.Properties.SetString("Filter", SystemParams.Instance.Filter);
                    message.NMSCorrelationID = TimeParser.LocalTimeToUnix(DateTime.Now).ToString();
                }
                else
                {
                    message.Properties.SetString("Filter", "BWI");
                    message.Properties.SetString("ExCode", "MES2DPA");
                }
                message.NMSType = "XML";

                prod.Send(message, MsgDeliveryMode.Persistent, MsgPriority.Normal, TimeSpan.MinValue);
            }
            catch (Exception error)
            {
                WriteLogInThread(
                    string.Format("发送 ESB 消息时发生错误：{0}",
                    error.Message));
            }
        }

        private string FormatXML(XmlDocument xml)
        {
            StringWriter sw = new StringWriter();
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                writer.Indentation = 2;
                writer.Formatting = Formatting.Indented;
                xml.WriteContentTo(writer);
                writer.Close();
            }
            return sw.ToString();
        }

        protected abstract void Do();
    }
}
