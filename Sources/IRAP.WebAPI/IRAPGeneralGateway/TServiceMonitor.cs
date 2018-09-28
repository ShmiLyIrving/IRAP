using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace IRAPGeneralGateway
{
    /// <summary>
    ///  服务监控类
    /// </summary>
    public class TServiceMonitor
    {
        /// <summary>
        /// 服务 ID
        /// </summary>
        public static string ServiceID;

        /// <summary>
        /// 查询时间
        /// </summary>
        private static int REAL_TIME = Convert.ToInt32(ConfigurationManager.AppSettings["QueryTimer"]);
        /// <summary>
        /// 历史时间
        /// </summary>
        private static int HISTORY_TIME = Convert.ToInt32(ConfigurationManager.AppSettings["HistoryTimer"]);
        private static string CONNECTSTR = ConfigurationManager.AppSettings["ConnectionString"];
        /// <summary>
        /// 实时统计访问量
        /// clientID->ExCode->实体
        /// </summary>
        private static Dictionary<string, Dictionary<string, TEntityService>> _realServiceCollection =
            new Dictionary<string, Dictionary<string, TEntityService>>();
        /// <summary>
        /// 每小时统计访问量
        /// clientID->ExCode->实体
        /// </summary>
        private static Dictionary<string, Dictionary<string, TEntityService>> _historyServiceCollection =
            new Dictionary<string, Dictionary<string, TEntityService>>();
        private static Thread readTimeThread = null;
        private static Thread historyThread = null;

        private static void RealTimeMonitor()
        {
            while (true)
            {
                int interval = 1000;
                int time = 0;
                while (time <= REAL_TIME)
                {
                    time += interval;
                    Thread.Sleep(interval);
                }

                InsertRealTimeData();
            }
        }

        private static void HistoryMonitor()
        {
            while (true)
            {
                int interval = 60000;
                int time = interval;
                while (time <= HISTORY_TIME)
                {
                    Thread.Sleep(interval);
                    time += interval;
                }

                Thread.Sleep(1000);
                InitService.WriteLogToDB("Monitor", "WT", "开始保存：time=" + time.ToString());

                InsertHistoryData();
            }
        }

        private static void InsertRealTimeData()
        {
            string clientId = "";
            string exCode = "";

            lock (_realServiceCollection)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(CONNECTSTR))
                    {
                        conn.Open();

                        string sqlCmd = "DELETE stb_Services_Real WHERE ServiceID=@ServiceID;";
                        SqlCommand command = new SqlCommand(sqlCmd, conn);
                        command.Parameters.AddWithValue("@ServiceID", ServiceID);
                        command.ExecuteNonQuery();

                        sqlCmd =
                            "INSERT INTO stb_Services_Real " +
                            "SELECT @ServiceID, @ClientID, @TrueExCode, @Success, "+
                            "@Failure, @Reject, @Exception, @LastCallTime";
                        command = new SqlCommand(sqlCmd, conn);
                        command.Parameters.Add("@ServiceID", SqlDbType.VarChar, 32);
                        command.Parameters.Add("@ClientID", SqlDbType.VarChar, 50);
                        command.Parameters.Add("@TrueExCode", SqlDbType.VarChar, 20);
                        command.Parameters.Add("@Success", SqlDbType.Int);
                        command.Parameters.Add("@Failure", SqlDbType.Int);
                        command.Parameters.Add("@Reject", SqlDbType.Int);
                        command.Parameters.Add("@Exception", SqlDbType.Int);
                        command.Parameters.Add("@LastCallTime", SqlDbType.DateTime2);

                        command.Parameters["@ServiceID"].Value = ServiceID;
                        foreach (KeyValuePair<string, Dictionary<string, TEntityService>> clients in _realServiceCollection)
                        {
                            clientId = clients.Key;

                            command.Parameters["@ClientID"].Value = clientId;
                            foreach (KeyValuePair<string, TEntityService> items in clients.Value)
                            {
                                exCode = items.Key;

                                command.Parameters["@TrueExCode"].Value = exCode;
                                command.Parameters["@Success"].Value = items.Value.Success;
                                command.Parameters["@Failure"].Value = items.Value.Failed;
                                command.Parameters["@Reject"].Value = items.Value.Reject;
                                command.Parameters["@Exception"].Value = items.Value.Except;
                                command.Parameters["@LastCallTime"].Value = items.Value.LastCallDate;

                                command.ExecuteNonQuery();
                            }
                        }

                        conn.Close();
                        _realServiceCollection.Clear();
                    }
                }
                catch (Exception error)
                {
                    InitService.WriteLogToDB(clientId, exCode, "保存实时日志失败：" + error.Message);
                }
            }
        }

        private static void InsertHistoryData()
        {
            string clientId = "";
            string exCode = "";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            DateTime now = DateTime.Now;
            lock (_historyServiceCollection)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(CONNECTSTR))
                    {
                        conn.Open();

                        string insertSql = 
                            "INSERT INTO stb_Services_His VALUES(@ServiceID, "+
                            "@ClientID, @TrueExCode, @YearID, @MonthOfYear, "+
                            "@WhichDay, @WhichHour, @Success, @Failure, @Exception, @Reject)";
                        SqlCommand command = new SqlCommand(insertSql, conn);

                        command.Parameters.Add("@ServiceID", SqlDbType.VarChar, 32);
                        command.Parameters.Add("@ClientID", SqlDbType.VarChar, 50);
                        command.Parameters.Add("@TrueExCode", SqlDbType.VarChar, 20);
                        command.Parameters.Add("@YearID", SqlDbType.Int);
                        command.Parameters.Add("@MonthOfYear", SqlDbType.Int);
                        command.Parameters.Add("@WhichDay", SqlDbType.Int);
                        command.Parameters.Add("@WhichHour", SqlDbType.Int);
                        command.Parameters.Add("@Success", SqlDbType.Int);
                        command.Parameters.Add("@Failure", SqlDbType.Int);
                        command.Parameters.Add("@Reject", SqlDbType.Int);
                        command.Parameters.Add("@Exception", SqlDbType.Int);

                        command.Parameters["@ServiceID"].Value = ServiceID;
                        foreach (KeyValuePair<string, Dictionary<string, TEntityService>> clients in _historyServiceCollection)
                        {
                            clientId = clients.Key;
                            command.Parameters["@ClientID"].Value = clientId;

                            foreach (var items in clients.Value)
                            {
                                exCode = items.Key;

                                command.Parameters["@TrueExCode"].Value = exCode;
                                command.Parameters["@YearID"].Value = now.Year;
                                command.Parameters["@MonthOfYear"].Value = now.Month;
                                command.Parameters["@WhichDay"].Value = now.Day;
                                command.Parameters["@WhichHour"].Value = now.Hour;
                                command.Parameters["@Success"].Value = items.Value.Success;
                                command.Parameters["@Failure"].Value = items.Value.Failed;
                                command.Parameters["@Reject"].Value = items.Value.Reject;
                                command.Parameters["@Exception"].Value = items.Value.Except;

                                command.ExecuteNonQuery();
                            }
                        }
                        conn.Close();
                        stopwatch.Stop();
                        TimeSpan timespan = stopwatch.Elapsed;
                        InitService.WriteLogToDB(clientId, exCode, "间隔" + (HISTORY_TIME / 1000 / 60).ToString() + "分钟保存成功，耗时：" + timespan.TotalMilliseconds.ToString());
                        _historyServiceCollection.Clear();
                    }
                }
                catch (Exception ex)
                {
                    stopwatch.Stop();
                    InitService.WriteLogToDB(clientId, exCode, "间隔" + (HISTORY_TIME / 1000 / 60).ToString() + "分钟保存日志失败：" + ex.Message);
                }
            }
        }

        public static void Running()
        {
            if (readTimeThread == null)
            {
                readTimeThread = new Thread(new ThreadStart(RealTimeMonitor));
                readTimeThread.IsBackground = true;
                readTimeThread.Start();
            }

            if (historyThread== null)
            {
                historyThread = new Thread(new ThreadStart(HistoryMonitor));
                historyThread.IsBackground = true;
                historyThread.Start();
            }
        }

        /// <summary>
        /// 缓存数据
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="exCode"></param>
        /// <param name="result"></param>
        public static void Add(string clientID, string exCode, TServiceCallResult result)
        {
            if (string.IsNullOrEmpty(clientID) || string.IsNullOrEmpty(exCode))
            {
                return;
            }

            // 实时数据
            lock (_realServiceCollection)
            {
                if (!_realServiceCollection.Keys.Contains(clientID))
                {
                    _realServiceCollection.Add(clientID, new Dictionary<string, TEntityService>());
                }
                
                if (!_realServiceCollection[clientID].Keys.Contains(exCode))
                {
                    TEntityService entity = new TEntityService();
                    _realServiceCollection[clientID].Add(exCode, entity);
                }

                _realServiceCollection[clientID][exCode].SetServiceCallStatus(result);
            }

            // 历史数据
            lock (_historyServiceCollection)
            {
                if (!_historyServiceCollection.Keys.Contains(clientID))
                {
                    _historyServiceCollection.Add(clientID, new Dictionary<string, TEntityService>());
                }

                if (!_historyServiceCollection[clientID].Keys.Contains(exCode))
                {
                    _historyServiceCollection[clientID].Add(exCode, new TEntityService());
                }

                _historyServiceCollection[clientID][exCode].SetServiceCallStatus(result);
            }
        }
    }
}
