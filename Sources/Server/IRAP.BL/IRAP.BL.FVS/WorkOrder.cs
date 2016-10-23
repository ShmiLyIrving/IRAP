using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

using IRAP.Global;
using IRAPShared;
using IRAP.Entity.FVS;
using IRAPORM;

namespace IRAP.BL.FVS
{
    public class WorkOrder : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public WorkOrder()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取当前工单执行的瞬时达成率
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="resourceTreeID">产线或工作中心（134/211）</param>
        /// <param name="resourceLeafID">产线或工作中心叶标识</param>
        /// <param name="nowTime">当前时间(传入空串表示当前时间)</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>LineKPI_BTS</returns>
        public IRAPJsonResult ufn_GetInfo_LineKPI_BTS(
            int communityID,
            int resourceTreeID,
            int resourceLeafID,
            string nowTime,
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
                LineKPI_BTS data = new LineKPI_BTS();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ResourceTreeID", DbType.Int32, resourceTreeID));
                paramList.Add(new IRAPProcParameter("@ResourceLeafID", DbType.Int32, resourceLeafID));
                paramList.Add(new IRAPProcParameter("@NowTime", DbType.String, nowTime));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetInfo_LineKPI_BTS，" +
                        "参数：CommunityID={0}|ResourceTreeID={1}|ResourceLeafID={2}|"+
                        "NowTime={3}|SysLogID={4}",
                        communityID, resourceTreeID, resourceTreeID, nowTime, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetInfo_LineKPI_BTS(" +
                            "@CommunityID, @ResourceTreeID, @ResourceLeafID, " +
                            "@NowTime, @SysLogID)";

                        IList<LineKPI_BTS> lstDatas = 
                            conn.CallTableFunc<LineKPI_BTS>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = "调用成功！";
                        }
                        else
                        {
                            errCode = -99001;
                            errText = "没有当前工单执行的瞬时达成率信息";
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetInfo_LineKPI_BTS 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(data);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="pwoNo">工单编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[TrendFTTofAPWO</returns>
        public IRAPJsonResult ufn_GetTrend_FTTofAPWO(
            int communityID,
            string pwoNo,
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
                List<TrendFTTofAPWO> datas =
                    new List<TrendFTTofAPWO>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, pwoNo));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetTrend_FTTofAPWO，" +
                        "参数：CommunityID={0}|PWONo={1}|SysLogID={2}",
                        communityID, pwoNo, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetTrend_FTTofAPWO(" +
                            "@CommunityID, @PWONo, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<TrendFTTofAPWO> lstDatas =
                            conn.CallTableFunc<TrendFTTofAPWO>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPFVS..ufn_GetTrend_FTTofAPWO 函数发生异常：{0}",
                            error.Message);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[Structure_FFTofAPWO</returns>
        public IRAPJsonResult ufn_GetStructure_FFTofAPWO(
            int communityID, 
            string pwoNo, 
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
                List<Structure_FFTofAPWO> datas =
                    new List<Structure_FFTofAPWO>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, pwoNo));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetStructure_FFTofAPWO，" +
                        "参数：CommunityID={0}|PWONo={1}|SysLogID={2}",
                        communityID, pwoNo, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetStructure_FFTofAPWO(" +
                            "@CommunityID, @PWONo, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<Structure_FFTofAPWO> lstDatas =
                            conn.CallTableFunc<Structure_FFTofAPWO>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPFVS..ufn_GetStructure_FFTofAPWO 函数发生异常：{0}",
                            error.Message);
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