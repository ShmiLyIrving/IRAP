using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace IRAP.MDC.Service
{
    public class RecordData
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string source = "";
        private string data = "";
        private string activeMQ_BrokerUri = "";
        private string activeMQ_QueueName = "";

        private IConnectionFactory factory = null;

        private RecordData()
        {
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);

            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings["ActiveMQ_BrokerUri"] != null)
                activeMQ_BrokerUri =
                    config.AppSettings.Settings["ActiveMQ_BrokerUri"].Value.ToString();
            if (config.AppSettings.Settings["ActiveMQ_QueueName"] != null)
                activeMQ_QueueName =
                    config.AppSettings.Settings["ActiveMQ_QueueName"].Value.ToString();

            if (activeMQ_BrokerUri.Trim() != "" &&
                activeMQ_QueueName.Trim() != "")
            {
                try
                {
                    factory = new ConnectionFactory(activeMQ_BrokerUri);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(
                        string.Format(
                            "初始化 ActiveMQ 失败：{0}",
                            error.Message),
                        strProcedureName);
                }
            }
            else
            {
                WriteLog.Instance.Write("无法初始化 ActiveMQ", strProcedureName);
            }
        }

        public RecordData(string source, string data) : this()
        {
            this.source = 
                source.Substring(
                    0,
                    source.IndexOf(':'));
            this.data = data;
        }

        public void Record()
        {
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);

            switch (data.Length)
            {
                case 10:
                    SendMessageToESB();
                    break;
                case 11:
                    SendMessageToESB();
                    break;
                default:
                    WriteLog.Instance.Write("报文格式不符合规范！", strProcedureName);
                    break;
            }

        }

        private void SendMessageToESB()
        {
            if (factory != null && 
                activeMQ_QueueName.Trim() != "")
            {
                using (IConnection connection = factory.CreateConnection())
                {
                    using (ISession session = connection.CreateSession())
                    {
                        IMessageProducer prod =
                            session.CreateProducer(
                                new ActiveMQQueue(activeMQ_QueueName));
                        ITextMessage message = prod.CreateTextMessage();
                        message.Text = source;
                        message.Properties.SetString("filter", source);
                        prod.Send(
                            message,
                            MsgDeliveryMode.Persistent,
                            MsgPriority.Normal,
                            TimeSpan.MinValue);
                    }
                }
            }
        }
    }
}