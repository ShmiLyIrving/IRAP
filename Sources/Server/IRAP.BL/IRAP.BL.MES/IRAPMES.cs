using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPORM;
using IRAPShared;
using IRAP.Entity.MES;
using IRAP.Entities.MES;

namespace IRAP.BL.MES
{
    public class IRAPMES : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPMES()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public IRAPJsonResult ufn_GetInfo_WIPBarcode(
            int communityID,
            string barcode, 
            int processLeaf, 
            int workUnitLeaf, 
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
                WIPBarCodeInfo data = new WIPBarCodeInfo();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@Barcode", DbType.String, barcode));
                paramList.Add(new IRAPProcParameter("@ProcessLeaf", DbType.Int32, processLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetInfo_WIPBarcode，" +
                        "参数：CommunityID={0}|Barcode={1}|ProcessLeaf={2}|WorkUnitLeaf={3}",
                        communityID, barcode, processLeaf, workUnitLeaf),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAPMES..ufn_GetInfo_WIPBarcode(" +
                            "@CommunityID, @Barcode, @ProcessLeaf, @WorkUnitLeaf)";

                        IList<WIPBarCodeInfo> lstDatas = conn.CallTableFunc<WIPBarCodeInfo>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        }
                        else
                        {
                            errCode = 99001;
                            errText = string.Format("没有[{0}]的在制品信息", barcode);
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMES..ufn_GetInfo_WIPBarcode 函数发生异常：{0}", error.Message);
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

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="productLeaf">产品叶标识(T102LeafID)</param>
        /// <param name="workUnitLeaf">工位叶标识(T107LeafID)</param>
        public IRAPJsonResult ufn_GetKanban_RepairModes(
            int communityID, 
            long sysLogID, 
            int productLeaf, 
            int workUnitLeaf, 
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
                List<RepairMode> datas = new List<RepairMode>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetKanban_RepairModes，" +
                        "参数：CommunityID={0}|SysLogID={1}|ProductLeaf={2}|WorkUnitLeaf={3}",
                        communityID, sysLogID, productLeaf, workUnitLeaf),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetKanban_RepairModes(" +
                            "@CommunityID, @SysLogID, @ProductLeaf, @WorkUnitLeaf)" +
                            "ORDER BY Ordinal";

                        IList<RepairMode> lstDatas = 
                            conn.CallTableFunc<RepairMode>(strSQL, paramList);
                        datas = lstDatas.ToList<RepairMode>();
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
                            "调用 IRAPMES..ufn_GetKanban_RepairModes 函数发生异常：{0}", 
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
        /// 获取指定产品未关闭的变更事项
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[OpenChangeInfo]</returns>
        public IRAPJsonResult ufn_GetFactList_OpenChanges(
            int communityID,
            int t102LeafID,
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
                List<OpenChangeInfo> datas = new List<OpenChangeInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetFactList_OpenChanges，" +
                        "参数：CommunityID={0}|T102LeafID={1}|SysLogID={2}",
                        communityID, t102LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetFactList_OpenChanges(" +
                            "@CommunityID, @T102LeafID, @SysLogID)";

                        IList<OpenChangeInfo> lstDatas =
                            conn.CallTableFunc<OpenChangeInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<OpenChangeInfo>();
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
                            "调用 IRAPMES..ufn_GetFactList_OpenChanges 函数发生异常：{0}",
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
        /// 获取产品相关未关闭变更事项的类别汇总信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[OpenChangeSummary]</returns>
        public IRAPJsonResult ufn_GetSummary_OpenChanges(
            int communityID,
            int t102LeafID,
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
                List<OpenChangeSummary> datas = new List<OpenChangeSummary>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetSummary_OpenChanges，" +
                        "参数：CommunityID={0}|T102LeafID={1}|SysLogID={2}",
                        communityID, t102LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetSummary_OpenChanges(" +
                            "@CommunityID, @T102LeafID, @SysLogID)";

                        IList<OpenChangeSummary> lstDatas =
                            conn.CallTableFunc<OpenChangeSummary>(strSQL, paramList);
                        datas = lstDatas.ToList<OpenChangeSummary>();
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
                            "调用 IRAPMES..ufn_GetSummary_OpenChanges 函数发生异常：{0}",
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

        public IRAPJsonResult usp_ManufactureRecord(
            int communityID,
            long transactNo,
            long factID,
            int processLeaf,
            int workUnitLeaf,
            string wipBarcode,
            string productSN,
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
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@ProcessLeaf", DbType.Int32, processLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@WIPBarcode", DbType.String, wipBarcode));
                paramList.Add(new IRAPProcParameter("@ProductSN", DbType.String, productSN));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_ManufactureRecord，参数：CommunityID={0}|" +
                        "TransactNo={1}|FactID={2}|ProcessLeaf={3}|WorkUnitLeaf={4}|"+
                        "WIPBarcode={5}|ProductSN={6}|SysLogID={7}",
                        communityID, transactNo, factID, productSN, workUnitLeaf,
                        wipBarcode, productSN, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_ManufactureRecord", ref paramList);
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
                        "调用 IRAPMES..usp_ManufactureRecord 函数发生异常：{0}",
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
        /// 保存人工外观检查事实记录，记录失效模式清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="productLeaf">产品叶标识（T102LeafID）</param>
        /// <param name="workUnitLeaf">工位叶标识（T107LeafID）</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="barCode">产品条码</param>
        /// <param name="scrapCode">失效模式代码清单</param>
        public IRAPJsonResult usp_SaveFact_Inspecting(
            int communityID,
            long transactNo,
            long factID,
            int productLeaf,
            int workUnitLeaf,
            long sysLogID,
            string barCode,
            string scrapCode,
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
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@BarCode", DbType.String, barCode));
                paramList.Add(new IRAPProcParameter("@ScrapCode", DbType.String, scrapCode));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_SaveFact_Inspecting，参数：CommunityID={0}|" +
                        "TransactNo={1}|FactID={2}|ProductLeaf={3}|WorkUnitLeaf={4}|" +
                        "SysLogID={5}|Barcode={6}|ScrapCode={7}|",
                        communityID, transactNo, factID, productLeaf, workUnitLeaf,
                        sysLogID, barCode, scrapCode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_SaveFact_Inspecting", ref paramList);
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
                        "调用 IRAPMES..usp_SaveFact_Inspecting 函数发生异常：{0}",
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
        /// 获取失效模式的质量问题柏拉图数据清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <returns>List[FailureModeOfPallet]</returns>
        public IRAPJsonResult ufn_GetPallet_FailureMode(
           int communityID,
           int productLeaf,
           int workUnitLeaf,
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
                List<FailureModeOfPallet> datas = new List<FailureModeOfPallet>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, pwoNo));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetPallet_FailureMode，" +
                        "参数：CommunityID={0}|ProductLeaf={1}|WorkUnitLeaf={2}|"+
                        "PWONo={3}|SysLogID={4}",
                        communityID, productLeaf, workUnitLeaf, pwoNo, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetPallet_FailureMode(" +
                            "@CommunityID, @ProductLeaf, @WorkUnitLeaf, @PWONo) "+
                            "ORDER BY Ordinal";

                        IList<FailureModeOfPallet> lstDatas =
                            conn.CallTableFunc<FailureModeOfPallet>(strSQL, paramList);
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
                            "调用 IRAPMES..ufn_GetPallet_FailureMode 函数发生异常：{0}",
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
        /// 保存批次管理系统中的生产过程参数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">容次号</param>
        /// <param name="rsFactXML">
        /// 生产过程参数 XML
        /// [RSFact]
        ///     [RF25_1
        ///         Ordinal=""
        ///         T20LeafID=""
        ///         ParameterName=""
        ///         LowLimit=""
        ///         Criterion=""
        ///         HighLimit=""
        ///         Scale=""
        ///         UnitOfMeasure=""
        ///         Metric01="" /]
        /// [/RSFact]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult usp_SaveFact_BatchMethodConfirming(
            int communityID,
            int t216LeafID,
            int t107LeafID,
            string batchNumber,
            string rsFactXML,
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
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@RSFactXML", DbType.String, rsFactXML));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_SaveFact_BatchMethodConfirming，参数："+
                        "CommunityID={0}|T216LeafID={1}|T107LeafID={2}|BatchNumber={3}|"+
                        "RSFactXML={4}|SysLogID={5}",
                        communityID, t216LeafID, t107LeafID, batchNumber, rsFactXML,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_SaveFact_BatchMethodConfirming", ref paramList);
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
                        "调用 IRAPMES..usp_SaveFact_BatchMethodConfirming 函数发生异常：{0}",
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
        /// 编辑批次管理系统中的生产过程参数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">容次号</param>
        /// <param name="opType">
        /// 操作标识：
        /// D-删除；U-修改（目前仅支持删除）
        /// </param>
        /// <param name="factID">保存的生产过程参数事实号</param>
        /// <param name="rsFactXML">
        /// 生产过程参数 XML
        /// [RSFact]
        ///     [RF25_1
        ///         Ordinal=""
        ///         T20LeafID=""
        ///         ParameterName=""
        ///         LowLimit=""
        ///         Criterion=""
        ///         HighLimit=""
        ///         Scale=""
        ///         UnitOfMeasure=""
        ///         Metric01="" /]
        /// [/RSFact]
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult usp_SaveFact_BatchMethodCancel(
            int communityID,
            int t216LeafID,
            int t107LeafID,
            string batchNumber,
            string opType,
            long factID,
            string rsFactXML,
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
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@OpType", DbType.String, opType));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@RSFactXML", DbType.String, rsFactXML));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_SaveFact_BatchMethodCancel，参数：" +
                        "CommunityID={0}|T216LeafID={1}|T107LeafID={2}|BatchNumber={3}|" +
                        "OpType={4}|FactID={5}|RSFactXML={6}|SysLogID={7}",
                        communityID, t216LeafID, t107LeafID, batchNumber, opType, factID,
                        rsFactXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_SaveFact_BatchMethodCancel", ref paramList);
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
                        "调用 IRAPMES..usp_SaveFact_BatchMethodCancel 函数发生异常：{0}",
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