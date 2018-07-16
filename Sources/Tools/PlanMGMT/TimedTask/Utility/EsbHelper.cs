using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;

namespace PlanMGMT
{
    public class EsbHelper
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static EsbHelper _instance;
        private object lockArea = new object();
        private static readonly object _lock = new Object();
        public List<CommonMessage> WaitingMessages = new List<CommonMessage>();

        private IConnectionFactory factory = null;
        private IConnection connection = null;
        private ISession session = null;
        private IMessageProducer producer = null;
        private IMessageConsumer consumer = null;
        protected static ITextMessage message = null;
        private string xml = "<Parameters><Params><Message></Message></Params></Parameters>";
        #region 单一实例
        /// <summary>
        /// 
        /// </summary>
        private EsbHelper()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        ~EsbHelper()
        {
            Dispose();
        }
        /// <summary>
        /// 返回唯一实例
        /// </summary>
        public static EsbHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        //if (_instance == null)
                        //{
                        _instance = new EsbHelper();
                        //}
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        public bool SendMessage(MessageType type, string ReceiverID,string content)
        {
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);
            bool success = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                Message msg = null;
                if (type == MessageType.Commom)
                {
                    msg = new CommonMessage("loacl", ReceiverID, content);
                }
                if (msg.GenerateSendXml(doc).OuterXml != null)
                {
                   string brokerUri =
                   string.Format(
                       "failover://({0})?&transport.startupMaxReconnectAttempts=1&" +
                       "transport.initialReconnectDelay=10",
                       Model.PM.ActiveMQ_URI);
                    factory = new ConnectionFactory(brokerUri);
                    connection = factory.CreateConnection();
                    connection.ClientId = System.Guid.NewGuid().ToString();
                    connection.Start();

                    session = connection.CreateSession();
                    producer =
                        session.CreateProducer(
                            new ActiveMQQueue(Model.PM.ActiveMQ_QueueName));
                    producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

                    message = producer.CreateTextMessage();
                    message.Properties.SetString("ReceiverID", ReceiverID);
                    message.NMSType = "xml";
                    message.Text = msg.GenerateSendXml(doc).OuterXml;
                    producer.Send(message);
                    success = true;
                }
            }
            catch(Exception ex)
            {
                success = false;
                Helper.Instance.Alert("发送失败!"+ex.Message);
                throw ex;               
            }
            return success;
        }
        public bool BeginReceiveMessage()
        {
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);
            bool success = false;
            try
            {
                string brokerUri =
                        string.Format(
                            "failover://({0})?&transport.startupMaxReconnectAttempts=1&" +
                            "transport.initialReconnectDelay=10",
                            Model.PM.ActiveMQ_URI);
                factory = new ConnectionFactory(brokerUri);
                connection = factory.CreateConnection();
                connection.ClientId = System.Guid.NewGuid().ToString();
                connection.Start();

                session = connection.CreateSession();
                consumer =
                    session.CreateConsumer(
                        new ActiveMQQueue(Model.PM.ActiveMQ_QueueName),
                        string.Format("ReceiverID='{0}'", "local"));
                consumer.Listener += new MessageListener(consumer_Listener);
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }
        private void consumer_Listener(IMessage message)
        {
            String strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);
            try
            {
                ITextMessage msg = (ITextMessage)message;

                lock (lockArea)
                {
                    
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(msg.Text);
                    if (IRAPXMLUtils.GetXMLNodeAttributeValue(doc.FirstChild.FirstChild.FirstChild,"Type") == MessageType.Commom.ToString())
                    {
                        CommonMessage Commonmsg = new CommonMessage();
                        IRAPXMLUtils.LoadValueFromXMLNode(doc.FirstChild.FirstChild.FirstChild, Commonmsg);
                        Helper.Instance.ShowPupUp("消息", Commonmsg.FromID, Commonmsg.Content);
                        Thread.Sleep(1000);
                        WaitingMessages.Add(Commonmsg);
                    }                   
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
