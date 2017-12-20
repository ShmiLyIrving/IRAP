using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Xml;

using IRAP.Global;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace xFiletoESB
{
    public delegate void LogOutputHandler(string msg, string modeName, ToolTipIcon icon);

    internal class DoActionToESB
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
        private IMessageProducer producer;

        protected static ITextMessage message = null;
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
        private Timer tmReadFromxFile = new Timer();

        public DoActionToESB(string uri, string queueName, string exCode, string filter)
        {
            esbUri = uri;
            esbQueueName = queueName;
            esbExCode = exCode;
            esbFilter = filter;
            tmrReconnect.Interval = 100;
            tmrReconnect.Tick += TmrReconnect_Tick;
            tmReadFromxFile.Interval = 100;
            tmReadFromxFile.Tick += tmReadFromxFile_Tick;
        }

        ~DoActionToESB()
        {
            tmrReconnect.Enabled = false;
            tmrReconnect.Tick -= TmrReconnect_Tick;
            tmReadFromxFile.Tick -= tmReadFromxFile_Tick;
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
                            CloseProducer();
                            System.Threading.Thread.Sleep(500);
                            InitProducer();
                        }
                        break;
                }
            }
            finally
            {
                tmrReconnect.Enabled = true;
            }
        }

        private void tmReadFromxFile_Tick(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            tmReadFromxFile.Enabled = false;
            try
            {
                if (!Directory.Exists(SysParams.Instance.LocalFileSaveLocation))
                    Directory.CreateDirectory(SysParams.Instance.LocalFileSaveLocation);
                if (!Directory.Exists(SysParams.Instance.BackupFileSaveLocation))
                    Directory.CreateDirectory(SysParams.Instance.BackupFileSaveLocation);
                if (!Directory.Exists(SysParams.Instance.UnreadableFileSaveLocation))
                    Directory.CreateDirectory(SysParams.Instance.UnreadableFileSaveLocation);
                string _dataDir = SysParams.Instance.LocalFileSaveLocation;
                string[] fileList = Directory.GetFiles(_dataDir, "*.xml");
                if (fileList.Length > 0)
                {
                    switch (SysParams.Instance.FileType)
                    {
                        case "XML 文件":
                            for (int i = 0; i < fileList.Length; i++)
                            {
                                message = producer.CreateTextMessage();
                                message.Properties.SetString("Filter", esbFilter);
                                message.Properties.SetString("ExCode", esbExCode);
                                message.NMSType = "xml";
                                message.NMSCorrelationID = Path.GetFileNameWithoutExtension(fileList[i]);
                                message.Text = ReadFromXMLFile(Path.GetFileNameWithoutExtension(fileList[i]));
                                string fileFullPathName = fileList[i];
                                string fileBackFullPathName =
                                    string.Format(
                                        @"{0}\{1}.xml.bak",
                                        SysParams.Instance.BackupFileSaveLocation,
                                        Path.GetFileNameWithoutExtension(fileList[i]));
                                if (message.Text != null)
                                {
                                    try
                                    {
                                        producer.Send(message);
                                        OutputLog("发送成功!", strProcedureName, ToolTipIcon.None);
                                        int j = 1;
                                        string temp = fileList[i];
                                        while (true)
                                        {
                                            try
                                            {
                                                File.Move(fileFullPathName, fileBackFullPathName);
                                                break;
                                            }
                                            catch (System.IO.IOException)
                                            {
                                                fileBackFullPathName =
                                                    string.Format(
                                                        @"{0}\{1}[{2}].xml.bak",
                                                        SysParams.Instance.BackupFileSaveLocation,
                                                        Path.GetFileNameWithoutExtension(temp), j++);
                                            }
                                        }
                                    }
                                    catch (Exception error)
                                    {
                                        OutputLog("发送失败" + fileFullPathName + error.Message, strProcedureName, ToolTipIcon.Error);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception error)
            {
                OutputLog(error.Message, strProcedureName, ToolTipIcon.Error);
            }
            finally
            {
                tmReadFromxFile.Enabled = true;
            }
        }
        private string ReadFromXMLFile(string fileNameTemp)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            string fileFullPathName =
                       string.Format(
                           @"{0}\{1}.xml",
                           SysParams.Instance.LocalFileSaveLocation,
                           fileNameTemp);
            string fileUnreadableFullPathName =
                       string.Format(
                           @"{0}\{1}.xml",
                           SysParams.Instance.UnreadableFileSaveLocation,
                           fileNameTemp);
            string message = null;
            try
            {

                XmlDocument x = new XmlDocument();
                x.Load(fileFullPathName);

            }
            catch (System.IO.IOException)
            {
                return null;
            }
            catch (XmlException e)
            {
                if (!Directory.Exists(SysParams.Instance.UnreadableFileSaveLocation))
                    Directory.CreateDirectory(SysParams.Instance.UnreadableFileSaveLocation);
                int i = 1;
                while (true)
                {
                    try
                    {
                        File.Move(fileFullPathName, fileUnreadableFullPathName);
                        OutputLog("xml格式不正确：" + fileFullPathName + e.Message, strProcedureName, ToolTipIcon.Error);
                        break;
                    }
                    catch (System.IO.IOException)
                    {
                        fileUnreadableFullPathName = string.Format(@"{0}\{1}[{2}].xml", 
                            SysParams.Instance.UnreadableFileSaveLocation,
                            fileNameTemp, i++);
                    }
                }
                return null;
            }
            
            try
            {
                XmlDocument readXml = new XmlDocument();
                readXml.Load(fileFullPathName);
                if (readXml.InnerXml != "")
                {
                    XmlDocument writexml = new XmlDocument();
                    //XmlNode writeRootNode = null;
                    //if (SysParams.Instance.XmlRootNodeName != "")
                    //    writeRootNode = writexml.CreateElement("Softland");
                    //else
                    //    writeRootNode = writexml.CreateElement("Root");
                    //writexml.AppendChild(writeRootNode);
                    //writeRootNode = writexml.CreateElement("Head");
                    //writexml.FirstChild.AppendChild(writeRootNode);
                    //writeRootNode = writexml.CreateElement("UnixTime");
                    //writeRootNode.InnerText = TimeParser.LocalTimeToUnix(System.DateTime.Now).ToString();
                    //writexml.FirstChild.FirstChild.AppendChild(writeRootNode);
                    //writeRootNode = writexml.CreateElement("CorrelationID");
                    //writeRootNode.InnerText = "IRAP";
                    //writexml.FirstChild.FirstChild.AppendChild(writeRootNode);
                    //writeRootNode = writexml.CreateElement("Body");
                    //writeRootNode.InnerXml = readXml.InnerXml;
                    //writexml.FirstChild.AppendChild(writeRootNode);
                    writexml.InnerXml = readXml.InnerXml;
                    message = writexml.InnerXml;
                    OutputLog("读取文件：" + fileFullPathName+"成功!", strProcedureName,ToolTipIcon.None); 
                }
            }
            catch(Exception e)
            {
                OutputLog("读取文件错误：" + e.Message, strProcedureName, ToolTipIcon.Error);
            }
            return message;
        }
        public LogOutputHandler OutputLog = null;
    

        private void WriteLog(string msg, string modeName, ToolTipIcon icon)
        {
            if (OutputLog != null)
                OutputLog(msg, modeName, icon);
        }
        private void InitProducer()
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
                producer =
                    session.CreateProducer(
                        new ActiveMQQueue(esbQueueName));
                producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

                esbConnectStatus = 2;

                WriteLog("ESB 连接成功,开始发送消息", strProcedureName, ToolTipIcon.Info);
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

        private void CloseProducer()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (producer != null)
            {
                producer.Close();
                producer = null;
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
        public void Start()
        {
            if (esbConnectStatus == 1 || esbConnectStatus == 2)
                return;
            else
            {
                InitProducer();
                tmrReconnect.Enabled = true;
                tmReadFromxFile.Enabled = true;
            }
        }

        public void Stop()
        {
            tmrReconnect.Enabled = false;
            tmReadFromxFile.Enabled = false;
            CloseProducer();
        }
    }
}
