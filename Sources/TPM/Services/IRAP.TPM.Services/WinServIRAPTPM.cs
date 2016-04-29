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

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace IRAP.TPM.Services
{
    public partial class WinServIRAPTPM : ServiceBase
    {
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
        }

        private void InitConsumer()
        {
            factory = new ConnectionFactory(brokerUri);
            connection = factory.CreateConnection();
            connection.ClientId = "irap.tpm.services.mes.listener";
            connection.Start();
            session = connection.CreateSession();
            consumer = session.CreateConsumer(
                new ActiveMQQueue("IRAPTPM_InQueue"),
                "filter='MES'");
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
