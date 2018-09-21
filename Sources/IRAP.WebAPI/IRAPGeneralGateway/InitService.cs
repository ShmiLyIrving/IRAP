using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using IRAP.Global;
using IRAPGeneralGateway.Entities;

namespace IRAPGeneralGateway
{
    public class InitService
    {
        public static string ConfigConnString;
        public static string ExCodeDBConnString;
        public static int ExCodeDBType = 1;
        public static int DefaultSecurityLevel = 1;
        public static int IsWriteLog = 1;
        public static int MaxConnectPerSecond = 0;
        public static string ServiceID = string.Empty;
        public static string ServiceName = string.Empty;
        public static string IPAddress = string.Empty;  //  --多个IP用逗号隔开
        public static string APIUrl = string.Empty;     //  ---对外服务的地址 
        public static int VerifyMode = 1;
        public static string DefaultPrefix = string.Empty;
        public static int LoadExCode = 1;
        public static int CommandTimeout = 60;
        public static int ReceiveStream = 1;

        private static bool _regToDB = false;
        private static string fileName = string.Empty; // appPath + configName;
        private static Dictionary<string, TEntityClient> _clientInMemory = 
            new Dictionary<string, TEntityClient>();

        public static Dictionary<string, TEntityClient> ClientList
        {
            get
            {
                return _clientInMemory;
            }
        }

        public static void ReadConfig()
        {
            if (!_regToDB)
            {
                DefaultSecurityLevel = int.Parse(ConfigurationManager.AppSettings["DefaultSecurityLevel"]);
                ConfigConnString = ConfigurationManager.AppSettings["ConnectionString"];
                ExCodeDBConnString = ConfigurationManager.AppSettings["ExCodeDBConn"];
                ExCodeDBType = int.Parse(ConfigurationManager.AppSettings["ExCodeDBType"]);
                ServiceName = ConfigurationManager.AppSettings["ServiceName"];
                ServiceID = ConfigurationManager.AppSettings["ServiceID"];
                int.TryParse(ConfigurationManager.AppSettings["IsWriteLog"], out IsWriteLog);
                int.TryParse(ConfigurationManager.AppSettings["MaxConnectPerSecond"], out MaxConnectPerSecond);
                int.TryParse(ConfigurationManager.AppSettings["VerifyMode"], out VerifyMode);
                int.TryParse(ConfigurationManager.AppSettings["loadExCode"], out LoadExCode);
                DefaultPrefix = ConfigurationManager.AppSettings["prefix"].ToString();
                int.TryParse(ConfigurationManager.AppSettings["CommandTimeout"], out CommandTimeout);
                int.TryParse(ConfigurationManager.AppSettings["ReceiveStream"], out ReceiveStream);

                Computer com = new Computer();
                IPAddress = com.IpAddress;
                if (ServiceID == string.Empty)
                {
                    ServiceID = com.CPUID;
                }
                _regToDB = true;
                Thread t = new Thread(HeartBeat);
                t.IsBackground = true;
                t.Start();
            }

            try
            {
                //读取可用渠道设置
                using (SqlConnection conn = new SqlConnection(ConfigConnString))
                {
                    conn.Open();
                    SqlCommand command = 
                        new SqlCommand(
                            "SELECT ClientID,ChannelName,UserID,Password,IsValid,ExpireDate," +
                            "SecurityLevel,SecurityPassword FROM dbo.stb_Channels ORDER BY ClientID", 
                            conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TEntityClient f = new TEntityClient();
                        f.ClientID = reader["ClientID"].ToString();
                        f.ChannelName = reader["ChannelName"].ToString();
                        f.UserID = reader["UserID"].ToString();
                        f.Password = reader["Password"].ToString();
                        f.IsValid = int.Parse(reader["Isvalid"].ToString());
                        f.ExpireDate = (DateTime)reader["ExpireDate"];
                        f.SecurityLevel = int.Parse(reader["SecurityLevel"].ToString());
                        f.SecurityPassword = reader["SecurityPassword"].ToString();
                        if (!_clientInMemory.ContainsKey(f.ClientID))
                        {
                            _clientInMemory.Add(f.ClientID, f);
                        }
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception err)
            {
                WriteLog.Instance.WriteLocalMsg(9999, "读取渠道信息失败：" + err.Message);
            }
        }

        public static void RefreshServiceToDB(int status, string baseURL, string msg)
        {
            string[] ipList = IPAddress.Split(';');
            if (APIUrl == string.Empty)
            {
                if (ipList.Length > 0)
                    APIUrl = baseURL.Replace("localhost", ipList[0]);
            }
            try
            {
                //判断是否存在服务记录
                using (SqlConnection conn = new SqlConnection(ConfigConnString))
                {
                    conn.Open();
                    SqlCommand command = 
                        new SqlCommand(
                            "SELECT COUNT(*) AS cnt FROM stb_Services WHERE ServiceID=@ServiceID", 
                            conn);
                    command.Parameters.AddWithValue("@ServiceID", ServiceID);
                    object reader = command.ExecuteScalar();
                    bool exists = (int)reader == 0 ? false : true;
                    if (!exists)
                    {
                        string insertSql = 
                            "INSERT INTO stb_Services "+
                            "VALUES(@ServiceID, @ServiceName, @IPAddress, @APIURL, GetDate(), " +
                            "GetDate(), 1, 1, @MaxConnect, @WriteLogLevel, @ExCodeDB, @Remark, @DiagMsg)";
                        SqlCommand insertCommand = new SqlCommand(insertSql, conn);
                        insertCommand.Parameters.AddWithValue("@ServiceID", ServiceID);
                        insertCommand.Parameters.AddWithValue("@ServiceName", ServiceName);
                        insertCommand.Parameters.AddWithValue("@IPAddress", IPAddress);
                        insertCommand.Parameters.AddWithValue("@APIURL", APIUrl);
                        insertCommand.Parameters.AddWithValue("@MaxConnect", MaxConnectPerSecond);
                        insertCommand.Parameters.AddWithValue("@WriteLogLevel", IsWriteLog);
                        insertCommand.Parameters.AddWithValue(
                            "@ExCodeDB", 
                            Regex.Replace(ExCodeDBConnString, @"pwd=(\S+)", "pwd=*****"));
                        insertCommand.Parameters.AddWithValue("@Remark", "服务初始化成功");
                        insertCommand.Parameters.AddWithValue("@DiagMsg", "等待连接");
                        insertCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        string updateSql = 
                            "UPDATE stb_Services SET MaxConnectPerSecond=@MaxConnect, WriteLogLevel=@WriteLogLevel," +
                            "ExCodeDB=@ExCodeDB, Remark=@Remark, DiagMsg=@DiagMsg, LastCallTime=GetDate(),"+
                            "Running=@Status WHERE ServiceID=@ServiceID";
                        SqlCommand updateCommand = new SqlCommand(updateSql, conn);
                        updateCommand.Parameters.AddWithValue("@ServiceID", ServiceID);
                        updateCommand.Parameters.AddWithValue("@MaxConnect", MaxConnectPerSecond);
                        updateCommand.Parameters.AddWithValue("@WriteLogLevel", IsWriteLog);
                        updateCommand.Parameters.AddWithValue(
                            "@ExCodeDB", 
                            Regex.Replace(ExCodeDBConnString, @"pwd=(\S+)", "pwd=*****"));
                        updateCommand.Parameters.AddWithValue("@Remark", "服务正在运行");
                        updateCommand.Parameters.AddWithValue("@DiagMsg", msg);
                        updateCommand.Parameters.AddWithValue("@Status", status);
                    }
                }
            }
            catch (Exception err)
            {
                WriteLog.Instance.WriteLocalMsg(9999, "刷新服务状态失败：" + err.Message);
            }
        }

        public static void HeartBeat()
        {
            while (true)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConfigConnString))
                    {
                        conn.Open();
                        SqlCommand command = 
                            new SqlCommand(
                                "UPDATE stb_Services SET HeartTime=GetDate() WHERE ServiceID=@ServiceID",
                                conn);
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception err)
                {
                    WriteLog.Instance.WriteLocalMsg(9999, "心跳失败：" + err.Message);
                }

                //30秒钟检测一次心跳
                Thread.Sleep(30000);

                //检测过期的令牌删除
                try
                {
                    lock (TIRAPGeneralWebAPIService.AccessList)
                    {
                        foreach (string key in TIRAPGeneralWebAPIService.AccessList.Keys.ToArray())
                        {
                            if (DateTime.Now.Subtract(TIRAPGeneralWebAPIService.AccessList[key]).TotalMinutes > 60)
                            {
                                TIRAPGeneralWebAPIService.AccessList.Remove(key);
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    WriteLog.Instance.WriteLocalMsg(9999, "移除令牌并发控制列表失败：" + err.Message);
                }
            }
        }

        public static void WriteLogToDB(string clientID, string exCode, string msg, int level = 2)
        {
            //level值 ---0 INFO  1--warning 2--error 3--Excption
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigConnString))
                {
                    conn.Open();
                    string insertSql = 
                        "INSERT INTO stb_ServicesLog VALUES(@ServiceID, @ClientID, GetDate(), @Level, @ExCode, @Msg)";

                    SqlCommand command = new SqlCommand(insertSql, conn);
                    command.Parameters.AddWithValue("@ServiceID", ServiceID);
                    command.Parameters.AddWithValue("@ClientID", clientID);
                    command.Parameters.AddWithValue("@Level", level);
                    command.Parameters.AddWithValue("@ExCode", exCode);
                    command.Parameters.AddWithValue("@Msg", msg);

                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception err)
            {
                WriteLog.Instance.WriteLocalMsg(9999, "日志记录失败：" + err.Message);
            }
        }
    }
}
