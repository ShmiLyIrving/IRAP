using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.Reflection;
using System.Threading;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

using IRAP.Global;

namespace IRAP.TPM.Services
{
    public partial class WinServIRAPTPM : ServiceBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IConnectionFactory factory = null;
        private IConnection connection = null;
        private ISession session = null;
        private IMessageConsumer consumer = null;
        private string brokerUri = "";
        private string dbConnectionString = "";

        public WinServIRAPTPM()
        {
            InitializeComponent();

            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key.Contains("brokerUri"))
                {
                    brokerUri = ConfigurationManager.AppSettings[key].ToString();
                }
            }
            dbConnectionString = ConfigurationManager.ConnectionStrings["IRAPTPM"].ToString();
        }

        protected override void OnStart(string[] args)
        {
            WriteLog.Instance.WriteLogFileName = className;
            WriteLog.Instance.WriteBeginSplitter(className);
            WriteLog.Instance.Write("服务开始运行", className);

            InitConsumer();
        }

        protected override void OnStop()
        {
            consumer.Close();
            session.Close();
            connection.Close();

            consumer = null;
            session = null;
            connection = null;
            factory = null;

            WriteLog.Instance.Write("服务终止运行", className);
            WriteLog.Instance.WriteEndSplitter(className);
            WriteLog.Instance.Write("");
        }

        private void InitConsumer()
        {
            factory = new ConnectionFactory(brokerUri);
            connection = factory.CreateConnection();
            connection.ClientId = "irap.tpm.services.andon.listener";
            connection.Start();
            session = connection.CreateSession();
            consumer = session.CreateConsumer(
                new ActiveMQQueue("IRAPTPM_InQueue"),
                "Filter='Andon'");
            consumer.Listener += new MessageListener(consumer_Listener);
        }

        private void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage) message;
           
            DoAction(msg.Text);
        }

        private SqlParameter CreateParam(
            SqlCommand sqlCommand,
            SqlDbType sqlDbType,
            int size,
            ParameterDirection parameterDirection,
            string parameterName,
            object value)
        {
            SqlParameter newParam = sqlCommand.CreateParameter();
            newParam.SqlDbType = sqlDbType;
            newParam.Size = size;
            newParam.Direction = parameterDirection;
            newParam.ParameterName = parameterName;
            newParam.Value = value;
            return newParam;
        }

        private DataSet ExecuteReturnDataSet(SqlConnection dbConnection, CommandType commandType, string cmdStr)
        {
            DataSet returnDS = new DataSet();

            SqlCommand cmd = new SqlCommand(cmdStr, dbConnection)
            {
                CommandType = commandType
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(returnDS);

            return returnDS;
        }

        private void DoAction(string message)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(message);

            XmlNode node = xml.SelectSingleNode("SY/Head/ExCode");
            if (node != null)
            {
                string excode = node.InnerText.ToUpper();
                switch (excode)
                {
                    case "TPM_0001":
                        Do0001Action(message);
                        break;
                    case "TPM_1001":
                        Do1001Action(message);
                        break;
                }
            }
            else
            {
                WriteLog.Instance.Write(message);
                WriteLog.Instance.Write("没有找到 SY/Head/ExCode 节点");
            }
        }

        private void Do1001Action(string message)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(message);

            WriteLog.Instance.WriteBeginSplitter(className);
            WriteLog.Instance.Write("收到处理报文：", className);
            WriteLog.Instance.Write(message, className);

            XmlNode node = xml.SelectSingleNode("SY/Body/Data");
            if (node != null)
            {
                try
                {
                    int opID = Convert.ToInt32(node.Attributes["OpID"].Value);
                    string deviceCode = node.Attributes["DeviceCode"].Value;
                    long factID = Convert.ToInt64(node.Attributes["FactID"].Value);
                    long transactNo = Convert.ToInt64(node.Attributes["TransactNo"].Value);
                    string callerCode = node.Attributes["CallerCode"].Value;
                    string callerName = node.Attributes["CallerName"].Value;
                    string callTime = node.Attributes["CallTime"].Value;
                    string responserCode = node.Attributes["ResponserCode"].Value;
                    string responserName = node.Attributes["ResponserName"].Value;
                    string responseTime = node.Attributes["ResponseTime"].Value;
                    string closeTime = node.Attributes["CloseTime"].Value;
                    string cancelUserCode = node.Attributes["CancelUserCode"].Value;
                    string cancelUserName = node.Attributes["CancelUserName"].Value;
                    string cancelReason = node.Attributes["CancelReason"].Value;
                    int andonScore = Convert.ToInt32(node.Attributes["AndonScore"].Value);

                    if (responseTime.Trim() == "")
                        responseTime = "1900-01-01 00:00:00.000";

                    if (opID >= 0 || opID <= 3)
                    {
                        string strConnection = dbConnectionString;
                        using (SqlConnection dbConnection = new SqlConnection(strConnection))
                        {
                            try
                            {
                                dbConnection.Open();
                            }
                            catch (Exception error)
                            {
                                WriteLog.Instance.Write(error.Message);
                                WriteLog.Instance.Write(error.StackTrace);
                                return;
                            }

                            using (SqlCommand sqlCmd = new SqlCommand())
                            {
                                sqlCmd.Connection = dbConnection;
                                switch (opID)
                                {
                                    case 0:
                                    case 4:
                                        sqlCmd.CommandText =
                                            "INSERT INTO utb_RWO_Info " +
                                            "SELECT MAX(RWONo) + 1 , 0, " +
                                            "@FactID, @TransactNo, @EventStatus, " +
                                            "@DeviceCode, @IsStoped, @CallerCode, " +
                                            "@CallerName, @CallTime, 0, " +
                                            "'', @ResponseTime, @ResponserCode, " +
                                            "@ResponserName, '1900-01-01 00:00:00.000', '1900-01-01 00:00:00.000', " +
                                            "'', '', '', 0, 0, 0, -1, -1, 0, " +
                                            "'', '' FROM utb_RWO_Info";

                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@FactID", factID));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@TransactNo", transactNo));
                                        if (opID == 0)
                                            sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.Int, 4, ParameterDirection.Input, "@EventStatus", 0));
                                        else
                                            sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.Int, 4, ParameterDirection.Input, "@EventStatus", 1));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 30, ParameterDirection.Input, "@DeviceCode", deviceCode));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.Bit, 1, ParameterDirection.Input, "@IsStoped", 1));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 20, ParameterDirection.Input, "@CallerCode", callerCode));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 20, ParameterDirection.Input, "@CallerName", callerName));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 24, ParameterDirection.Input, "@CallTime", callTime));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 24, ParameterDirection.Input, "@ResponseTime", responseTime));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 20, ParameterDirection.Input, "@ResponserCode", responserCode));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 20, ParameterDirection.Input, "@ResponserName", responserName));

                                        break;
                                    case 1:
                                        sqlCmd.CommandText =
                                            "UPDATE utb_RWO_Info " +
                                            "SET EventStatus=1, ResponseTime=@ResponseTime, " +
                                            "ResponserCode=@ResponserCode, ResponserName=@ResponserName " +
                                            "WHERE FactID=@FactID AND TransactNo=@TransactNo AND ResponserCode='' " +
                                            "AND ResponserName=''";

                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@FactID", factID));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@TransactNo", transactNo));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 24, ParameterDirection.Input, "@ResponseTime", responseTime));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 20, ParameterDirection.Input, "@ResponserCode", responserCode));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 20, ParameterDirection.Input, "@ResponserName", responserName));

                                        break;
                                    case 2:
                                        sqlCmd.CommandText =
                                            "UPDATE utb_RWO_Info " +
                                            "SET EventStatus=2, CloseTime=@CloseTime, AndonScore=@AndonScore " +
                                            "WHERE FactID=@FactID AND TransactNo=@TransactNo";

                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@FactID", factID));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@TransactNo", transactNo));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 24, ParameterDirection.Input, "@CloseTime", closeTime));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.Int, 4, ParameterDirection.Input, "@AndonScore", andonScore));

                                        break;
                                    case 3:
                                        sqlCmd.CommandText =
                                            "UPDATE utb_RWO_Info " +
                                            "SET EventStatus=3, CloseTime=@CloseTime, " +
                                            "CancelUserCode=@CancelUserCode, CancelUserName=@CancelUserName, " +
                                            "CancelReason=@CancelReason " +
                                            "WHERE FactID=@FactID AND TransactNo=@TransactNo";

                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@FactID", factID));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@TransactNo", transactNo));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 24, ParameterDirection.Input, "@CloseTime", closeTime));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 20, ParameterDirection.Input, "@CancelUserCode", cancelUserCode));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 20, ParameterDirection.Input, "@CancelUserName", cancelUserName));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 100, ParameterDirection.Input, "@CancelReason", cancelReason));

                                        break;
                                    default:
                                        return;
                                }

                                int retryTime = 0;
                                do
                                {
                                    WriteLog.Instance.Write(
                                        string.Format("第[{0}]次执行", retryTime++),
                                        className);
                                    try
                                    {
                                        WriteLog.Instance.Write(sqlCmd.CommandText, className);
                                        sqlCmd.CommandTimeout = 120;
                                        sqlCmd.ExecuteNonQuery();
                                        WriteLog.Instance.Write("处理成功！", className);
                                        break;
                                    }
                                    catch (Exception error)
                                    {
                                        WriteLog.Instance.Write(error.Message, className);
                                        WriteLog.Instance.Write(error.StackTrace, className);

                                        Thread.Sleep(200);
                                    }
                                }
                                while (true);
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, className);
                    WriteLog.Instance.Write(error.StackTrace, className);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(className);
                }
            }
        }

        private void Do0001Action(string message)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(message);

            foreach (XmlNode node in xml.SelectNodes("SY/Body/Action"))
            {
                string type = node.Attributes["Type"].Value.ToString();
                switch (type)
                {
                    case "PWOBuild":
                        string deviceCode = node.Attributes["DeviceCode"].Value.ToString().Trim();
                        if (deviceCode != "")
                        {
                            string strConnection = dbConnectionString;
                            using (SqlConnection dbConnection = new SqlConnection(strConnection))
                            {
                                try
                                {
                                    dbConnection.Open();
                                }
                                catch (Exception e)
                                {
                                    return;
                                }

                                int intT133LeafID = 0;
                                DataSet ds = ExecuteReturnDataSet(
                                    dbConnection,
                                    CommandType.Text,
                                    string.Format(
                                        "SELECT * FROM stb_BizTrees WHERE TreeID = 133 AND Code='{0}'",
                                        deviceCode));
                                if (ds == null || ds.Tables.Count == 0 && ds.Tables[0].Rows.Count == 0)
                                {
                                    return;
                                }
                                else
                                {
                                    intT133LeafID = (int) ds.Tables[0].Rows[0]["NodeID"];
                                }

                                using (SqlCommand sqlCmd = new SqlCommand("usp_InsertPMWorkOrderInfo", dbConnection))
                                {
                                    sqlCmd.CommandType = CommandType.StoredProcedure;

                                    sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 23, ParameterDirection.Input, "@CurrentDateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                                    sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.Int, 4, ParameterDirection.Input, "@T133LeafID", intT133LeafID));
                                    sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.Int, 4, ParameterDirection.Input, "@PMPlanCycle", 99));
                                    sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.Int, 4, ParameterDirection.Output, "@ErrCode", 0));
                                    sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.NVarChar, 400, ParameterDirection.Output, "@ErrText", ""));

                                    try
                                    {
                                        sqlCmd.ExecuteNonQuery();
                                    }
                                    catch (Exception e)
                                    {
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
