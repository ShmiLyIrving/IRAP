using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPShared;
using IRAPORM;
using IRAP.Entities.APS;

namespace IRAP.BL.APS
{
    public class IRAPAPS : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPAPS()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取制造订单格式字符串
        /// </summary>
        public IRAPJsonResult ufn_GetAccessibleMOPattern(
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
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPAPS.dbo.ufn_GetAccessibleMOPattern，"+
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string rlt =
                            (string)conn.CallScalarFunc(
                                "IRAPAPS.dbo.ufn_GetAccessibleMOPattern",
                                paramList);

                        errCode = 0;
                        errText = "调用成功！";

                        WriteLog.Instance.Write(errText, strProcedureName);
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = 
                        string.Format(
                            "调用 IRAPAPS.dbo.ufn_GetAccessibleMOPattern 函数发生异常：{0}", 
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    return Json("");
                }
                #endregion
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
        /// <param name="t124LeafID">制造区域叶标识</param>
        /// <param name="moPattern">MO号格式</param>
        /// <param name="dtfInDays">需求时间栏天数</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ManufacturingOrder]</returns>
        public IRAPJsonResult ufn_GetList_ManufacturingOrdersToDispatch(
            int communityID,
            int t124LeafID,
            string moPattern,
            int dtfInDays,
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
                List<ManufacturingOrder> datas = new List<ManufacturingOrder>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T124LeafID", DbType.Int32, t124LeafID));
                paramList.Add(new IRAPProcParameter("@MOPattern", DbType.String, moPattern));
                paramList.Add(new IRAPProcParameter("@DTFInDays", DbType.Int32, dtfInDays));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPAPS..ufn_GetList_ManufacturingOrdersToDispatch，" +
                        "参数：CommunityID={0}|T124LeafID={1}|MOPattern={2}|DTFInDays={3}"+
                        "SysLogID={4}",
                        communityID, t124LeafID, moPattern, dtfInDays, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPAPS..ufn_GetList_ManufacturingOrdersToDispatch(" +
                            "@CommunityID, @T124LeafID, @MOPattern, @DTFInDays, @SysLogID) " +
                            "ORDER BY PriorityOrdinal";

                        IList<ManufacturingOrder> lstDatas =
                            conn.CallTableFunc<ManufacturingOrder>(strSQL, paramList);
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
                            "调用 IRAPAPS..ufn_GetList_ManufacturingOrdersToDispatch 函数发生异常：{0}",
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
        /// 手动同步四班的订单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="dstT173LeafID">目标产线代码</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult usp_ManualMODispatch(
            int communityID,
            int dstT173LeafID,
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
                paramList.Add(new IRAPProcParameter("@DstT173LeafID", DbType.Int32, dstT173LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPAPS..usp_ManualMODispatch，参数：" +
                        "CommunityID={0}|DstT173LeafID={1}|SysLogID={2}",
                        communityID, dstT173LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPAPS..usp_ManualMODispatch", ref paramList);
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
                        "调用 IRAPAPS..usp_ManualMODispatch 过程发生异常：{0}",
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