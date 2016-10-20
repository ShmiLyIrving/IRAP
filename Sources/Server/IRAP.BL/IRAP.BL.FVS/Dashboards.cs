using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPORM;
using IRAPShared;
using IRAP.Entity.FVS;

namespace IRAP.BL.FVS
{
    public class Dashboards : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public Dashboards()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取制造订单跟踪看板
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t132ClickStream">产品族点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_Dashboard_MOTrack(
            int communityID, 
            string t132ClickStream, 
            long sysLogID, 
            out int errCode, 
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<Dashboard_MOTrack> datas = new List<Dashboard_MOTrack>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T132ClickStream", DbType.String, t132ClickStream));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_Dashboard_MOTrack，" +
                        "参数：CommunityID={0}|T132ClickStream={1}|SysLogID={2}",
                        communityID, t132ClickStream, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_Dashboard_MOTrack(" +
                            "@CommunityID, @T132ClickStream, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<Dashboard_MOTrack> lstDatas = 
                            conn.CallTableFunc<Dashboard_MOTrack>(strSQL, paramList);
                        datas = lstDatas.ToList<Dashboard_MOTrack>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_Dashboard_MOTrack 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">产线点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_Dashboard_WorkUnitProductionProgress(
            int communityID, 
            string t134ClickStream, 
            long sysLogID, 
            out int errCode, 
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<Dashboard_WorkUnitProductionProgress> datas = 
                    new List<Dashboard_WorkUnitProductionProgress>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134ClickStream", DbType.String, t134ClickStream));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_Dashboard_WorkUnitProductionProgress，" +
                        "参数：CommunityID={0}|T134ClickStream={1}|SysLogID={2}",
                        communityID, t134ClickStream, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_Dashboard_WorkUnitProductionProgress(" +
                            "@CommunityID, @T134ClickStream, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<Dashboard_WorkUnitProductionProgress> lstDatas =
                            conn.CallTableFunc<Dashboard_WorkUnitProductionProgress>(strSQL, paramList);
                        datas = lstDatas.ToList<Dashboard_WorkUnitProductionProgress>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_Dashboard_WorkUnitProductionProgress 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public IRAPJsonResult ufn_Dashboard_MoDelivery()
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult ufn_Dashboard_WIPWaiting()
        {
            throw new System.NotImplementedException();
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetDashboard_FTT(
            int communityID, 
            long sysLogID, 
            out int errCode, 
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<Dashboard_FTT> datas = new List<Dashboard_FTT>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetDashboard_FTT，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetDashboard_FTT(" +
                            "@CommunityID, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<Dashboard_FTT> lstDatas =
                            conn.CallTableFunc<Dashboard_FTT>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetDashboard_FTT 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}