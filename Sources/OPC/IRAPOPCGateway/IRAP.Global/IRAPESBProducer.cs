using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace IRAP.Global
{
    /// <summary>
    /// IRAP 企业消息总线生产者类
    /// </summary>
    public class IRAPESBProducer
    {
        private IConnectionFactory activeMQFactory = null;
        private IConnection activeMQConnection = null;
        private ISession activeMQSession = null;
        private IMessageProducer activeMQProducer = null;
        private string activeMQ_Uri;
        private string activeMQ_QueueName;
        private string activeMQ_Filter;
        private string activeMQ_ServerAddress;
        private string activeMQ_ExCode;

        public IRAPESBProducer(
            string esbParam_Uri, 
            string esbParam_QueueName, 
            string esbParam_Filter, 
            string esbParam_ServerAddress, 
            string esbParam_ExCode)
        {
            activeMQ_Uri = esbParam_Uri;
            activeMQ_QueueName = esbParam_QueueName;
            activeMQ_Filter = esbParam_Filter;
            activeMQ_ServerAddress = esbParam_ServerAddress;
            activeMQ_ExCode = esbParam_ExCode;
        }

        ~IRAPESBProducer()
        {
            if (activeMQProducer!=null)
            {
                activeMQProducer.Close();
                activeMQProducer = null;
            }
            if (activeMQSession != null)
            {
                activeMQSession.Close();
                activeMQSession = null;
            }
            if (activeMQConnection != null)
            {
                activeMQConnection.Close();
                activeMQConnection = null;
            }
            if (activeMQFactory != null)
            {
                activeMQFactory = null;
            }
        }

        /// <summary>
        /// 发送 ESB 消息
        /// </summary>
        public void SendToESB(string msgString)
        {
            string brokerUri =
                string.Format(
                    "failover://({0})?&transport.startupMaxReconnectAttempts=2&" +
                    "transport.initialReconnectDelay=10",
                    activeMQ_Uri);

            try
            {
                if (activeMQFactory == null)
                {
                    activeMQFactory = new ConnectionFactory(brokerUri);
                    activeMQConnection = activeMQFactory.CreateConnection();
                    activeMQSession = activeMQConnection.CreateSession();
                    activeMQProducer = activeMQSession.CreateProducer(
                        new ActiveMQQueue(activeMQ_QueueName));

                    activeMQProducer.DeliveryMode = MsgDeliveryMode.Persistent;
                    activeMQProducer.TimeToLive = new TimeSpan(0, 0, 0, 0);
                }

                ITextMessage message = activeMQProducer.CreateTextMessage();
                message.Text = msgString;
                message.Properties.SetString("Filter", activeMQ_Filter);
                message.Properties.SetString("ESBServerAddr", activeMQ_ServerAddress);
                message.Properties.SetString("ExCode", activeMQ_ExCode);
                message.NMSType = "XML";

                activeMQProducer.Send(
                    message, 
                    MsgDeliveryMode.Persistent, 
                    MsgPriority.Normal, 
                    new TimeSpan(0, 0, 0, 0));
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = "999999";
                error.Data["ErrText"] = 
                    string.Format("发送 ESB 消息时发生错误：{0}",
                    error.Message);
                throw error;
            }
        }
    }
}