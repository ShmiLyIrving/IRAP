﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace IRAP.TPM.Services.Host
{
    public partial class Form1 : Form
    {
        public delegate void DelegateRevMessage(ITextMessage message);

        public Form1()
        {
            InitializeComponent();
        }

        private void InitConsumer()
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://192.168.57.208:61616");
            IConnection connection = factory.CreateConnection();
            connection.ClientId = "irap.tpm.services.mes.listener";
            connection.Start();
            ISession session = connection.CreateSession();
            IMessageConsumer consumer = session.CreateConsumer(
                new ActiveMQQueue("IRAPTPM_InQueue"),
                "filter='MES'");
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

            foreach (XmlNode node in xml.SelectNodes("SY/Body/Action"))
            {
                string type = node.Attributes["Type"].Value.ToString();
                switch (type)
                {
                    case "PWOBuild":
                        string deviceCode = node.Attributes["DeviceCode"].Value.ToString().Trim();
                        if (deviceCode != "")
                        {
                            string strConnection =
                                "Data Source=192.168.57.210;Initial Catalog=IRAPTPM;Persist Security Info=True;User ID=sa;Password=irap!209420";
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
