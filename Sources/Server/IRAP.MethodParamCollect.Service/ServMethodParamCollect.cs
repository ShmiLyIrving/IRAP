using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.Xml;
using System.Data.SqlClient;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

using IRAP.Global;
using IRAP.Entities.DPA;

namespace IRAP.MethodParamCollect.Service
{
    public partial class ServMethodParamCollect : ServiceBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        #region ActiveMQ 消费者
        private IConnectionFactory esbFactory = null;
        private IConnection esbConnection = null;
        private ISession esbSession = null;
        private IMessageConsumer esbConsumer = null;
        #endregion

        #region 数据库连接
        SqlConnection dbConnection = null;
        #endregion

        /// <summary>
        /// ESB 队列所在地址
        /// </summary>
        private string activeMQ_URI = "";
        /// <summary>
        /// ESB 队列名称
        /// </summary>
        private string activeMQ_QueueName = "";

        public ServMethodParamCollect()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            try
            {
                WriteLog.Instance.IsWriteLog = true;
            }
            catch { }

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            WriteLog.Instance.Write("启动服务", strProcedureName);
            try
            {
                Init();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write("终止服务", strProcedureName);
                WriteLog.Instance.WriteEndSplitter(strProcedureName);

                throw error;
            }
        }

        protected override void OnStop()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            CloseConsumer();
            WriteLog.Instance.Write("终止服务", strProcedureName);
            WriteLog.Instance.WriteEndSplitter(strProcedureName);
        }

        #region 自定义函数
        private string GetString(string key)
        {
            string rlt = "";
            if (ConfigurationManager.AppSettings[key] != null)
            {
                rlt = ConfigurationManager.AppSettings[key];
            }
            return rlt;
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
                WriteLog.Instance.Write(
                    string.Format(
                        "连接 ESB ({0}) ......",
                        activeMQ_URI), 
                    strProcedureName);

                string brokerUri =
                    string.Format(
                        "failover://({0})?&transport.startupMaxReconnectAttempts=1&" +
                        "transport.initialReconnectDelay=10",
                        activeMQ_URI);
                esbFactory = new ConnectionFactory(brokerUri);
                esbConnection = esbFactory.CreateConnection();
                esbConnection.ClientId = System.Guid.NewGuid().ToString();
                esbConnection.Start();

                esbSession = esbConnection.CreateSession();
                esbConsumer =
                    esbSession.CreateConsumer(
                        new ActiveMQQueue(activeMQ_QueueName),
                        "Filter='BWI'");
                esbConsumer.Listener += new MessageListener(consumer_Listener);

                WriteLog.Instance.Write("ESB 连接成功，开始接收工艺参数采集的消息......", strProcedureName);
            }
            catch (Exception error)
            {
                string errText =
                    string.Format(
                        "EBS 连接失败：{0}",
                        error.Message);
                WriteLog.Instance.Write(errText, strProcedureName);
                throw new Exception(errText);
            }
        }

        private void CloseConsumer()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (dbConnection != null)
                dbConnection = null;

            if (esbConsumer != null)
            {
                esbConsumer.Close();
                esbConsumer = null;
            }
            if (esbSession != null)
            {
                esbSession.Close();
                esbSession = null;
            }
            if (esbConnection != null)
            {
                esbConnection.Close();
                esbConnection = null;
            }

            esbFactory = null;

            WriteLog.Instance.Write("停止服务，关闭 ESB 连接。", strProcedureName);
        }

        private void Init()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            activeMQ_URI = GetString("ActiveMQ_URI");
            activeMQ_QueueName = GetString("ActiveMQ_QueueName");

            if (activeMQ_URI == "" || activeMQ_QueueName == "")
            {
                string errText = "ESB 总线连接参数配置不全，无法启动服务";
                WriteLog.Instance.Write(errText, strProcedureName);
                throw new Exception(errText);
            }

            string connectionString = GetString("ConnectionString");
            if (connectionString=="")
            {
                string errText = "目标数据库连接字串未配置，无法启动服务";
                WriteLog.Instance.Write(errText, strProcedureName);
                throw new Exception(errText);
            }
            dbConnection = new SqlConnection(connectionString);
            try { dbConnection.Open(); }
            catch (Exception error)
            {
                string errText = string.Format("无法打开目标数据库[{0}]", error.Message);
                WriteLog.Instance.Write(errText, strProcedureName);
                throw new Exception(errText);
            }

            InitConsumer();
        }

        private void Log(string queueMsgID, string msg, string modeName = "COMM")
        {
            WriteLog.Instance.Write(
                string.Format(
                    "[{0}]{1}",
                    queueMsgID,
                    msg),
                modeName);
        }

        private void consumer_Listener(IMessage message)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            ITextMessage msg = (ITextMessage)message;

            // 若收到的消息是空白的消息，在忽略
            if (msg.Text.Trim() == "")
                return;

            string msgID = System.Guid.NewGuid().ToString("N");
            Log(
                msgID,
                string.Format("收到的报文内容：[{0}]", msg.Text),
                strProcedureName);

            XmlDocument xml = new XmlDocument();
            try { xml.LoadXml(msg.Text); }
            catch (Exception error)
            {
                Log(
                    msgID,
                    string.Format("解析报文时发生错误：[{0}]", error.Message),
                    strProcedureName);
                return;
            }

            try
            {
                foreach (XmlNode node in xml.SelectNodes("ROOT/Row"))
                {
                    xdr_MethodParams data = new xdr_MethodParams();

                    data.PartitioningKey = 600020000;
                    data.ID = 0;
                    data.CollectingTime = Tools.ConvertToInt64(node.Attributes["CollectingTime"].Value);
                    data.EquipmentCode = node.Attributes["EquipmentCode"].Value;
                    data.OperationCode = node.Attributes["OperationCode"].Value;
                    data.StepNo = Tools.ConvertToInt32(node.Attributes["StepNo"].Value);
                    data.ProductNo = node.Attributes["ProductNo"].Value;
                    data.LotNumber = node.Attributes["LotNumber"].Value;
                    data.SerialNumber = node.Attributes["SerialNumber"].Value;
                    data.Ordinal = Tools.ConvertToInt32(node.Attributes["Ordinal"].Value);
                    data.ParamCode = node.Attributes["ParamCode"].Value;
                    data.ParamName = node.Attributes["ParamName"].Value;
                    data.Remark = "";

                    if (node.NodeType == XmlNodeType.CDATA ||
                        node.NodeType == XmlNodeType.Text)
                        data.Remark = node.Value;

                    if (node.Attributes["Remark"] != null)
                        data.Remark = node.Attributes["Remark"].Value;

                    data.CollectMode = 0;
                    data.LowLimit = Tools.ConvertToInt64(node.Attributes["LowLimit"].Value);
                    data.Criterion = node.Attributes["Criterion"].Value;
                    data.HighLimit = Tools.ConvertToInt64(node.Attributes["HighLimit"].Value);
                    data.Scale = Tools.ConvertToInt32(node.Attributes["Scale"].Value);
                    data.UnitOfMeasure = node.Attributes["UnitOfMeasure"].Value;
                    data.Conclusion = node.Attributes["Conclusion"].Value;
                    data.Metric01 = Tools.ConvertToInt64(node.Attributes["Metric01"].Value);
                    data.Metric02 = Tools.ConvertToInt64(node.Attributes["Metric02"].Value);
                    data.Metric03 = Tools.ConvertToInt64(node.Attributes["Metric03"].Value);
                    data.Metric04 = Tools.ConvertToInt64(node.Attributes["Metric04"].Value);
                    data.Metric05 = Tools.ConvertToInt64(node.Attributes["Metric05"].Value);

                    try
                    {
                        string sqlCmd =
                                "INSERT INTO IRAPDPA..xdr_MethodParams" +
                                "(PartitioningKey, CollectingTime, EquipmentCode, " +
                                "OperationCode, StepNo, ProductNo, LotNumber, " +
                                "SerialNumber, Ordinal, ParamCode, ParamName, " +
                                "Remark, CollectMode, LowLimit, Criterion, HighLimit, " +
                                "Scale, UnitOfMeasure, Conclusion, Metric01, " +
                                "Metric02, Metric03, Metric04, Metric05) " +
                                "VALUES(@PartitioningKey, @CollectingTime, @EquipmentCode, " +
                                "@OperationCode, @StepNo, @ProductNo, @LotNumber, " +
                                "@SerialNumber, @Ordinal, @ParamCode, @ParamName, " +
                                "@Remark, @CollectMode, @LowLimit, @Criterion, @HighLimit, " +
                                "@Scale, @UnitOfMeasure, @Conclusion, @Metric01, " +
                                "@Metric02, @Metric03, @Metric04, @Metric05)";

                        SqlCommand cmd = new SqlCommand(sqlCmd, dbConnection);

                        cmd.Parameters.Add(new SqlParameter("@PartitioningKey", SqlDbType.BigInt) { Value = data.PartitioningKey });
                        cmd.Parameters.Add(new SqlParameter("@CollectingTime", SqlDbType.BigInt) { Value = data.CollectingTime });
                        cmd.Parameters.Add(new SqlParameter("@EquipmentCode", SqlDbType.VarChar, 40) { Value = data.EquipmentCode });
                        cmd.Parameters.Add(new SqlParameter("@OperationCode", SqlDbType.VarChar, 40) { Value = data.OperationCode });
                        cmd.Parameters.Add(new SqlParameter("@StepNo", SqlDbType.Int) { Value = data.StepNo });
                        cmd.Parameters.Add(new SqlParameter("@ProductNo", SqlDbType.VarChar, 40) { Value = data.ProductNo });
                        cmd.Parameters.Add(new SqlParameter("@LotNumber", SqlDbType.VarChar, 50) { Value = data.LotNumber });
                        cmd.Parameters.Add(new SqlParameter("@SerialNumber", SqlDbType.VarChar, 80) { Value = data.SerialNumber });
                        cmd.Parameters.Add(new SqlParameter("@Ordinal", SqlDbType.Int) { Value = data.Ordinal });
                        cmd.Parameters.Add(new SqlParameter("@ParamCode", SqlDbType.VarChar, 40) { Value = data.ParamCode });
                        cmd.Parameters.Add(new SqlParameter("@ParamName", SqlDbType.NVarChar, 100) { Value = data.ParamName });
                        cmd.Parameters.Add(new SqlParameter("@Remark", SqlDbType.VarChar, 2147483647) { Value = data.Remark });
                        cmd.Parameters.Add(new SqlParameter("@CollectMode", SqlDbType.TinyInt) { Value = data.CollectMode });
                        cmd.Parameters.Add(new SqlParameter("@LowLimit", SqlDbType.BigInt) { Value = data.LowLimit });
                        cmd.Parameters.Add(new SqlParameter("@Criterion", SqlDbType.VarChar, 4) { Value = data.Criterion });
                        cmd.Parameters.Add(new SqlParameter("@HighLimit", SqlDbType.BigInt) { Value = data.HighLimit });
                        cmd.Parameters.Add(new SqlParameter("@Scale", SqlDbType.SmallInt) { Value = data.Scale });
                        cmd.Parameters.Add(new SqlParameter("@UnitOfMeasure", SqlDbType.NVarChar, 20) { Value = data.UnitOfMeasure });
                        cmd.Parameters.Add(new SqlParameter("@Conclusion", SqlDbType.VarChar, 1) { Value = data.Conclusion });
                        cmd.Parameters.Add(new SqlParameter("@Metric01", SqlDbType.BigInt) { Value = data.Metric01 });
                        cmd.Parameters.Add(new SqlParameter("@Metric02", SqlDbType.BigInt) { Value = data.Metric02 });
                        cmd.Parameters.Add(new SqlParameter("@Metric03", SqlDbType.BigInt) { Value = data.Metric03 });
                        cmd.Parameters.Add(new SqlParameter("@Metric04", SqlDbType.BigInt) { Value = data.Metric04 });
                        cmd.Parameters.Add(new SqlParameter("@Metric05", SqlDbType.BigInt) { Value = data.Metric05 });

                        cmd.ExecuteNonQuery();

                        Log(msgID, "插表成功", strProcedureName);
                    }
                    catch (Exception error)
                    {
                        Log(
                            msgID,
                            string.Format(
                                "插表时发生错误：{0}",
                                error.Message),
                            strProcedureName);
                    }
                }
            }
            finally
            {
            }
        }
        #endregion
    }
}
