using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.MES;
using IRAP.Entities.MES;
using IRAPORM;
using IRAPShared;

namespace IRAP.BL.MES
{
    public class QC : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public QC()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取质量控制点序号
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <returns>质量控制点序号[int]</returns>
        public IRAPJsonResult ufn_GetQCCheckPointOrdinal(
            int communityID, 
            int t102LeafID, 
            int t107LeafID, 
            string pwoNo, 
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
                int rlt = 0;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.String, t107LeafID));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, pwoNo));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES.dbo.ufn_GetQCCheckPointOrdinal，参数：" +
                        "CommunityID={0}|T102LeafID={1}|T107LeafID={2}|PWONo={3}",
                        communityID,
                        t102LeafID,
                        t107LeafID,
                        pwoNo),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        rlt = (int) conn.CallScalarFunc("IRAPMES.dbo.ufn_GetQCCheckPointOrdinal", paramList);
                        if (rlt > -2147483648)
                        {
                            errCode = 0;
                            errText = string.Format("调用成功！获得 QCCheckPointOrdinal={0}", rlt);
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                        else
                        {
                            errCode = 99999;
                            errText = "未得到 QCCheckPointOrdinal 的值";
                        }
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMES.dbo.ufn_GetQCCheckPointOrdinal 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }

        /// <summary>
        /// 获取SPC控制图信息：⒈ 支持彩虹图；⒉ 支持Xbar-R图
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="t47LeafID">SPC控制图类型代码：373564-彩虹图；373565-Xbar-R图</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t133LeafID">设备叶标识</param>
        /// <param name="t20LeafID">工艺参数叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetInfo_SPCChart(
            int communityID, 
            string pwoNo, 
            int t47LeafID, 
            int t216LeafID, 
            int t133LeafID, 
            int t20LeafID, 
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
                EntitySPCChart rlt = new EntitySPCChart();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("PWONo", DbType.String, pwoNo));
                paramList.Add(new IRAPProcParameter("T47LeafID", DbType.Int32, t47LeafID));
                paramList.Add(new IRAPProcParameter("T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T133LeafID", DbType.Int32, t133LeafID));
                paramList.Add(new IRAPProcParameter("@T20LeafID", DbType.String, t20LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES.dbo.ufn_GetInfo_SPCChart，参数：" +
                        "CommunityID={0}|PWONo={1}|T47LeafID={2}|T216LeafID={3}" +
                        "T133LeafID={4}|T20LeafID={5}|SysLogID={6}",
                        communityID,
                        pwoNo,
                        t47LeafID,
                        t216LeafID,
                        t133LeafID,
                        t20LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string sqlCmd = "SELECT * FROM IRAPMES..ufn_GetInfo_SPCChart(" +
                            "@CommunityID, @PWONo, @T47LeafID, @T216LeafID, @T133LeafID, " +
                            "@T20LeafID, @SysLogID)";
                        IList<EntitySPCChart> objs = 
                            conn.CallTableFunc<EntitySPCChart>(sqlCmd, paramList);
                        if (objs != null && objs.Count > 0)
                        {
                            rlt = objs[0].Clone();

                            errCode = 0;
                            errText = "调用成功！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                        else
                        {
                            errCode = 99999;
                            errText = "未得到 SPC 控制图信息";
                        }
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMES.dbo.ufn_GetInfo_SPCChart 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }

        /// <summary>
        /// 统计过程重置
        /// ⒈ 更新工艺调整时间点为当前时间点，从此时点以后的数据计入SPC图；
        /// ⒉ 写工艺调整日志。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="c1ID">产品工位关联标识</param>
        /// <param name="t47LeafID">SPC控制图标识号：373564-彩虹图；373565-XBarR图</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_WriteLog_SPCReset(
            int communityID,
            int c1ID,
            int t47LeafID,
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
                paramList.Add(new IRAPProcParameter("@C1ID", DbType.Int32, c1ID));
                paramList.Add(new IRAPProcParameter("@T47LeafID", DbType.Int32, t47LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_WriteLog_SPCReset，参数：CommunityID={0}|" +
                        "C1ID={1}|T47LeafID={2}|SysLogID={3}",
                        communityID, c1ID, t47LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_WriteLog_SPCReset", ref paramList);
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
                        "调用 IRAPMES..usp_WriteLog_SPCReset 函数发生异常：{0}",
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

        /// <summary>
        /// 设置统计过程控制中 XBar-R 图的上下控制线
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="c1ID">产品工位关联标识</param>
        /// <param name="t47LeafID">SPC控制图标识号：373564-彩虹图；373565-XBarR图</param>
        /// <param name="lcl">XBar 控制线下限</param>
        /// <param name="ucl">XBar 控制线上限</param>
        /// <param name="rlcl">R 控制线下限</param>
        /// <param name="rucl">R 控制线上限</param>
        /// <param name="rbar">R 的均值</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_WriteLog_SPCCtrlLineSet(
            int communityID,
            int c1ID,
            int t47LeafID,
            long lcl,
            long ucl,
            long rlcl,
            long rucl,
            long rbar,
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
                paramList.Add(new IRAPProcParameter("@C1ID", DbType.Int32, c1ID));
                paramList.Add(new IRAPProcParameter("@T47LeafID", DbType.Int32, t47LeafID));
                paramList.Add(new IRAPProcParameter("@LCL", DbType.Int64, lcl));
                paramList.Add(new IRAPProcParameter("@UCL", DbType.Int64, ucl));
                paramList.Add(new IRAPProcParameter("@RLCL", DbType.Int64, rlcl));
                paramList.Add(new IRAPProcParameter("@RUCL", DbType.Int64, rucl));
                paramList.Add(new IRAPProcParameter("@RBar", DbType.Int64, rbar));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_WriteLog_SPCCtrlLineSet，参数：CommunityID={0}|" +
                        "C1ID={1}|T47LeafID={2}|LCL={3}|UCL={4}|RLCL={5}|RUCL={6}|RBar={7}|SysLogID={8}",
                        communityID, c1ID, t47LeafID, lcl, ucl, rlcl, rucl, rbar, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_WriteLog_SPCCtrlLineSet", ref paramList);
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
                        "调用 IRAPMES..usp_WriteLog_SPCCtrlLineSet 函数发生异常：{0}",
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

        /// <summary>
        /// 获取测试数据采集行集事实(测试数据)
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="rsFactPK">行集事实分区键</param>
        /// <param name="factID">事实编号</param>
        /// <param name="failOnly">是否仅包括失败的测试项</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[RSFactTestData]</returns>
        public IRAPJsonResult ufn_GetRSFact_TestData(
            int communityID,
            long rsFactPK,
            long factID,
            bool failOnly,
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
                List<RSFactTestData> datas = new List<RSFactTestData>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@RSFactPK", DbType.Int64, rsFactPK));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@FailOnly", DbType.Boolean, failOnly));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetRSFact_TestData，" +
                        "参数：CommunityID={0}|RSFactPK={1}|FactID={2}|" +
                        "FailOnly={3}|SysLogID={4}",
                        communityID, rsFactPK, factID, failOnly,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetRSFact_TestData(" +
                            "@CommunityID, @RSFactPK, @FactID, " +
                            "@FailOnly, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<RSFactTestData> lstDatas =
                            conn.CallTableFunc<RSFactTestData>(strSQL, paramList);
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
                            "调用 IRAPMES..ufn_GetRSFact_TestData 函数发生异常：{0}",
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
