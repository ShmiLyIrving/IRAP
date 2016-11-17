using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace IRAP.TPM.Services.Host
{
    public partial class Form1 : Form
    {
        public delegate void DelegateRevMessage(ITextMessage message);
        private string dbConnectionString = "";

        public Form1()
        {
            InitializeComponent();

            dbConnectionString = ConfigurationManager.ConnectionStrings["IRAPTPM"].ToString();
        }

        private void InitConsumer()
        {
            IConnectionFactory factory = new ConnectionFactory("failover:(tcp://192.168.97.242:61616/)");
            IConnection connection = factory.CreateConnection();
            connection.ClientId = "irap.tpm.services.andon.listener";
            connection.Start();
            ISession session = connection.CreateSession();
            IMessageConsumer consumer = session.CreateConsumer(
                new ActiveMQQueue("IRAPTPM_InQueue"),
                "filter='Andon'");
            consumer.Listener += new MessageListener(consumer_Listener);
        }

        private void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage) message;
            textBox1.Invoke(new DelegateRevMessage(RecvMessage), msg);
        }

        private void RecvMessage(ITextMessage message)
        {
            DoAction(message.Text);
            textBox1.Text = message.Text;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            InitConsumer();
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

            //WriteLog.Instance.Write(message);

            XmlNode node = xml.SelectSingleNode("SY/Head/ExCode");
            if (node != null)
            {
                string excode = node.InnerText.ToUpper();
                //WriteLog.Instance.Write(excode);
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
                //WriteLog.Instance.Write("没有找到 SY/Head/ExCode 节点");
            }
        }

        private void Do1001Action(string message)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(message);

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
                                MessageBox.Show(error.Message);
                                return;
                            }

                            using (SqlCommand sqlCmd = new SqlCommand())
                            {
                                sqlCmd.Connection = dbConnection;
                                switch (opID)
                                {
                                    case 0:
                                        sqlCmd.CommandText =
                                            "INSERT INTO utb_RWO_Info " +
                                            "SELECT MAX(RWONo) + 1 , 0, " +
                                            "@FactID, @TransactNo, 0, " +
                                            "@DeviceCode, @IsStoped, @CallerCode, " +
                                            "@CallerName, @CallTime, 0, " +
                                            "'', @ResponseTime, @ResponserCode, " +
                                            "@ResponserName, '1900-01-01 00:00:00.000', '1900-01-01 00:00:00.000', " +
                                            "'', '', '', 0, 0, 0, 0, 0, 0, " +
                                            "'', '' FROM utb_RWO_Info";

                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@FactID", factID));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@TransactNo", transactNo));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.Int, 4, ParameterDirection.Input, "@EventStatus", 0));
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

                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@FactID", factID));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@TransactNo", transactNo));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 24, ParameterDirection.Input, "@ResponseTime", responseTime));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 20, ParameterDirection.Input, "@ResponserCode", responserCode));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 20, ParameterDirection.Input, "@ResponserName", responserName));

                                        break;
                                    case 2:
                                        sqlCmd.CommandText =
                                            "UPDATE utb_RWO_Info " +
                                            "SET EventStatus=2, CloseTime=@CloseTime " +
                                            "WHERE FactID=@FactID AND TransactNo=@TransactNo";

                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@FactID", factID));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.BigInt, 8, ParameterDirection.Input, "@TransactNo", transactNo));
                                        sqlCmd.Parameters.Add(CreateParam(sqlCmd, SqlDbType.VarChar, 24, ParameterDirection.Input, "@CloseTime", closeTime));

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


                                try
                                {
                                    sqlCmd.ExecuteNonQuery();
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show(error.Message);
                                    //WriteLog.Instance.Write(error.Message);
                                    //WriteLog.Instance.Write(error.StackTrace);
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    //WriteLog.Instance.Write(error.Message);
                    //WriteLog.Instance.Write(error.StackTrace);
                    return;
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
                                    intT133LeafID = (int)ds.Tables[0].Rows[0]["NodeID"];
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
