// 文 件 名：ReportBll.cs
// 功能描述：日志Bll基类
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PlanMGMT.BLL
{
    public class ReportBLL
    {
        private static ReportBLL _instance;
        //private static object _lock = new object();//使用static object作为互斥资源
        public List<DateTime> CurrentCommitDates = new List<DateTime>();
        #region 单例
        /// <summary>
        /// 
        /// </summary>
        public ReportBLL()
        {
        }

        /// <summary>
        /// 返回唯一实例
        /// </summary>
        public static ReportBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    //lock (_obj)
                    //{
                    //if (_instance == null)
                    //{
                    _instance = new ReportBLL();
                    //}
                    //}
                }
                return _instance;
            }
        }
        #endregion
        public List<DateTime> GetCurCommitDates(DateTime dt0)
        {
            DateTime start = dt0.AddDays(1 - dt0.Day);  //本月月初
            DateTime stop = start.AddMonths(1).AddDays(-1);  //本月月末
            try
            {
                CurrentCommitDates.Clear();
                string sql = $"select WriteTime from utb_worklog where WriteTime>='{start.ToString()}' and WriteTime <='{stop.ToString()}' and UserCode ='{Utility.ProU.Instance.PspUser.UserCode}'";
                DataTable dt = Mysql.Instance.Query(sql).Tables["ds"];
                foreach (DataRow dr in dt.Rows)
                {
                    CurrentCommitDates.Add(System.Convert.ToDateTime(dr[0]));
                }
                return CurrentCommitDates;
            }
            catch(Exception e)
            {
                Helper.Instance.AlertError("获取日志记录时发生错误：" + e.Message);
                return null;
            }
        }
        public Entity.WorkLog GetCurLog(DateTime dt)
        {

            string sql = $"select Daily,TomorrowDaily from utb_worklog where WriteTime ='{dt.ToString()}' and UserCode ='{Utility.ProU.Instance.PspUser.UserCode}'";
            DataTable temp = Mysql.Instance.Query(sql).Tables["ds"];
            if (temp != null && temp.Rows.Count > 0)
            {
                Entity.WorkLog log = new Entity.WorkLog(temp.Rows[0][0].ToString(), temp.Rows[0][1].ToString());
                return log;
            }
            return null;
        }
        public Error Commit(string daily,string tomorrowdaily,DateTime selecteddate)
        {
            Error error = new Error();
            try
            {
                string sql = $"insert into utb_worklog(UserCode,Daily,WriteTime,TomorrowDaily,DiscussCount) Values('{Utility.ProU.Instance.PspUser.UserCode}','{daily}','{selecteddate.ToString()}','{tomorrowdaily}',0)";
                Mysql.Instance.ExecuteSql(sql);
                error.ErrCode = 0;
                error.ErrText = "";
            }
            catch(Exception e)
            {
                error.ErrCode = 9999;
                error.ErrText = e.Message;
            }
            return error;
        }
    }
}
