using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MES;
using IRAPShared;
using IRAPORM;

namespace IRAP.BL.MES
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
        /// 获取社区全部未结生产工单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <returns>List[OpenProductionWorkOrder]</returns>
        public IRAPJsonResult ufn_GetList_OpenProductionWorkOrders(
            int communityID, 
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
                List<OpenProductionWorkOrder> datas = 
                    new List<OpenProductionWorkOrder>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_OpenProductionWorkOrders，" +
                        "参数：CommunityID={0}",
                        communityID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_OpenProductionWorkOrders(" +
                            "@CommunityID) ORDER BY Ordinal";

                        IList<OpenProductionWorkOrder> lstDatas =
                            conn.CallTableFunc<OpenProductionWorkOrder>(strSQL, paramList);
                        datas = lstDatas.ToList<OpenProductionWorkOrder>();
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
                            "调用 IRAPMES..ufn_GetList_OpenProductionWorkOrders 函数发生异常：{0}",
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
        /// 获取可访问的返工工单清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <returns>List[OpenReworkPWO]</returns>
        public IRAPJsonResult ufn_GetList_OpenReworkPWOs(
            int communityID,
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
                List<OpenReworkPWO> datas =
                    new List<OpenReworkPWO>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_OpenReworkPWOs，" +
                        "参数：CommunityID={0}",
                        communityID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_OpenReworkPWOs(" +
                            "@CommunityID) ORDER BY Ordinal";

                        IList<OpenReworkPWO> lstDatas =
                            conn.CallTableFunc<OpenReworkPWO>(strSQL, paramList);
                        datas = lstDatas.ToList<OpenReworkPWO>();
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
                            "调用 IRAPMES..ufn_GetList_OpenReworkPWOs 函数发生异常：{0}",
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
        /// 获取指定产线未结工单清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="resourceTreeID">菜单参数(134)</param>
        /// <param name="leafID">产线的叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[OpenPWO]</returns>
        public IRAPJsonResult ufn_GetList_OpenPWOsOfALine(
            int communityID,
            int resourceTreeID,
            int leafID,
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
                List<OpenPWO> datas =
                    new List<OpenPWO>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ResourceTreeID", DbType.Int32, resourceTreeID));
                paramList.Add(new IRAPProcParameter("@LeafID", DbType.Int32, leafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_OpenPWOsOfALine，" +
                        "参数：CommunityID={0}|ResourceTreeID={1}|" +
                        "LeafID={2}|SysLogID={3}",
                        communityID,
                        resourceTreeID,
                        leafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_OpenPWOsOfALine(" +
                            "@CommunityID, @ResourceTreeID, @LeafID, @SysLogID) " +
                            "ORDER BY PWOStatus DESC, ScheduledStartTime ASC";

                        IList<OpenPWO> lstDatas =
                            conn.CallTableFunc<OpenPWO>(strSQL, paramList);
                        datas = lstDatas.ToList<OpenPWO>();
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
                            "调用 IRAPMES..ufn_GetList_OpenPWOsOfALine 函数发生异常：{0}",
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
        /// 获取返工工单卸料表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="tf482PK">事实分区键</param>
        /// <param name="pwoIssuingFactID">返工工单签发事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ReworkPWOUnloadingSheetItem]</returns>
        public IRAPJsonResult ufn_GetReworkPWOUnloadingSheet(
            int communityID, 
            long tf482PK, 
            long pwoIssuingFactID, 
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
                List<ReworkPWOUnloadingSheetItem> datas =
                    new List<ReworkPWOUnloadingSheetItem>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TF482PK", DbType.Int64, tf482PK));
                paramList.Add(new IRAPProcParameter("@PWOIssuingFactID", DbType.Int64, pwoIssuingFactID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetReworkPWOUnloadingSheet，" +
                        "参数：CommunityID={0}|TF482PK={1}|PWOIssuingFactID={2}|" +
                        "SysLogID={3}",
                        communityID, tf482PK, pwoIssuingFactID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetReworkPWOUnloadingSheet(" +
                            "@CommunityID, @TF482PK, @PWOIssuingFactID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<ReworkPWOUnloadingSheetItem> lstDatas =
                            conn.CallTableFunc<ReworkPWOUnloadingSheetItem>(strSQL, paramList);
                        datas = lstDatas.ToList<ReworkPWOUnloadingSheetItem>();
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
                            "调用 IRAPMES..ufn_GetReworkPWOUnloadingSheet 函数发生异常：{0}",
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
        /// 获取指定返工工单的返工路由表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="tf482PK">事实分区键</param>
        /// <param name="pwoIssuingFactID">返工工单签发事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <remarks>List[ReworkRouter]</remarks>
        public IRAPJsonResult ufn_GetReworkRoutingTBL(
            int communityID,
            long tf482PK,
            long pwoIssuingFactID,
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
                List<ReworkRouter> datas =
                    new List<ReworkRouter>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TF482PK", DbType.Int64, tf482PK));
                paramList.Add(new IRAPProcParameter("@PWOIssuingFactID", DbType.Int64, pwoIssuingFactID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetReworkRoutingTBL，" +
                        "参数：CommunityID={0}|TF482PK={1}|PWOIssuingFactID={2}|" +
                        "SysLogID={3}",
                        communityID, tf482PK, pwoIssuingFactID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetReworkRoutingTBL(" +
                            "@CommunityID, @TF482PK, @PWOIssuingFactID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<ReworkRouter> lstDatas =
                            conn.CallTableFunc<ReworkRouter>(strSQL, paramList);
                        datas = lstDatas.ToList<ReworkRouter>();
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
                            "调用 IRAPMES..ufn_GetReworkRoutingTBL 函数发生异常：{0}",
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
        /// 保存返工工单路由设置与卸料设置
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="tf482PK">事实分区键</param>
        /// <param name="pwoIssuingFactID">返工工单签发事实编号</param>
        /// <param name="reworkRoutingTBL">
        /// 返工路由表 XML
        /// [RSFact]
        /// 	[RF3 Ordinal="..." 
        /// 	     T107LeafID1="..." 
        /// 	     T107LeafID2="..." 
        /// 	     T116LeafID="..." /]
        /// 	...
        /// [/RSFact]
        /// </param>
        /// <param name="reworkUnloadingSheet">
        /// 返工卸料表 XML
        /// [RSFact]
        /// 	[RF4 Ordinal="..."
        /// 	     T107LeafID="..."
        /// 	     T108LeafID="..."
        /// 	     T110LeafID="..."
        /// 	     T101LeafID="..."
        /// 	     T102LeafID="..."
        /// 	     UnloadQty="..."
        /// 	     ScrapOnUnloading="..." /]
        /// 	...
        /// [/RSFact]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_SaveRSFact_ReworkPWO(
            int communityID, 
            long tf482PK, 
            long pwoIssuingFactID, 
            string reworkRoutingTBL, 
            string reworkUnloadingSheet, 
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
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TF482PK", DbType.Int64, tf482PK));
                paramList.Add(new IRAPProcParameter("@PWOIssuingFactID", DbType.Int64, pwoIssuingFactID));
                paramList.Add(new IRAPProcParameter("@ReworkRoutingTBL", DbType.String, reworkRoutingTBL));
                paramList.Add(new IRAPProcParameter("@ReworkUnloadingSheet", DbType.String, reworkUnloadingSheet));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_SaveRSFacts_ReworkPWO，" +
                        "参数：CommunityID={0}|TF482PK={1}|PWOIssuingFactID={2}|"+
                        "ReworkRoutingTBL={3}|ReworkUnloadingSheet={4}|SysLogID={5}",
                        communityID, tf482PK, pwoIssuingFactID, reworkRoutingTBL, 
                        reworkUnloadingSheet, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = 
                        conn.CallProc("IRAPMES..usp_SaveRSFacts_ReworkPWO", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    return Json(error);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = 
                    string.Format(
                        "调用 IRAPMES..usp_SaveRSFacts_ReworkPWO 函数发生异常：{0}", 
                        error.Message);
                return Json(
                    new IRAPError()
                    {
                        ErrCode = errCode,
                        ErrText = errText,
                    });
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}