using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;

using IRAP.Global;
using IRAP.Entities.MES;
using IRAP.Entities.MES.Tables;
using IRAPORM;
using IRAPShared;
using IRAPDAL;
using IRAP.Server.Global;

namespace IRAP.BL.MES
{
    public class TroubleShooting : IRAPBLLBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public TroubleShooting()
        {
            WriteLog.Instance.WriteLogFileName = 
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 申请序列号
        /// ⒈ 申请预定义序列的一个或多个序列号；
        /// ⒉ 如果序列是交易号的，自动写交易日志。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sequenceCode">序列代码</param>
        /// <param name="count">申请序列值个数</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="opNode">业务操作节点列表</param>
        /// <param name="voucherNo">业务凭证号</param>
        /// <returns>申请到的第一个序列值[long]</returns>
        private void ssp_GetSequenceNo(
            int communityID,
            string sequenceCode,
            int count,
            long sysLogID,
            string opNode,
            string voucherNo,
            ref long sequenceNo,
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
                sequenceNo = 0;

                Hashtable rlt = new Hashtable();
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SequenceCode", DbType.String, sequenceCode));
                paramList.Add(new IRAPProcParameter("@Count", DbType.Int32, count));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@OpNode", DbType.String, opNode));
                paramList.Add(new IRAPProcParameter("@VoucherNo", DbType.String, voucherNo));
                paramList.Add(new IRAPProcParameter("@SequenceNo", DbType.Int64, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAP..ssp_GetSequenceNo，输入参数：" +
                        "CommunityID={0}|SequenceCode={1}|Count={2}|SysLogID={3}" +
                        "OpNode={4}|VoucherNo={5}",
                        communityID, sequenceCode, count, sysLogID, opNode, voucherNo),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_GetSequenceNo", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                        if (rlt["SequenceNo"] != null)
                            sequenceNo = (long)rlt["SequenceNo"];
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..ssp_GetSequenceNo 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 故障维修交易复核
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">待复核交易号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        private void usp_CheckTransaction_11(
            int communityID,
            long transactNo,
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
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAPMES..usp_CheckTransaction_11，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|SysLogID={2}",
                        communityID, transactNo, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAPMES..usp_CheckTransaction_11", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMES..usp_CheckTransaction_11 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private long[] GetMaterialTrackID(
            int communityID,
            string wipBarcode,
            int t102LeafID,
            int t107LeafID,
            int t101LeafID,
            long sysLogID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            IList<IDataParameter> paramList = new List<IDataParameter>();
            paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
            paramList.Add(new IRAPProcParameter("@WIPBarCode", DbType.String, wipBarcode));
            paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
            paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
            paramList.Add(new IRAPProcParameter("@T101LeafID", DbType.Int32, t101LeafID));
            paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));

            IRAPSQLConnection conn = new IRAPSQLConnection();
            try
            {
                DataTable dt =
                    conn.QuerySQL(
                        "SELECT * FROM IRAPMES..ufn_GetInfo_MaterialTrackOfTS(" +
                        "@CommunityID, @WIPBarCode, @T102LeafID, @T107LeafID, " +
                        "@T101LeafID,@SysLogID)",
                     paramList);
                long[] returns = { (long)dt.Rows[0][0], (long)dt.Rows[0][1] };
                return returns;
            }
            catch (Exception err)
            {
                WriteLog.Instance.Write(err.Message, strProcedureName);

                long[] turns = { 0, 0 };
                return turns;
            }
            finally
            {
                conn.Close();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取送修在制品修复转出工序清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID_TS">维修站位叶标识</param>
        /// <param name="t107LeafID_Src">来源工位叶标识</param>
        /// <param name="t119LeafList">维修模式叶标识列表</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_QCOperationsForNG(
            int communityID, 
            int t102LeafID, 
            int t107LeafID_TS,
            int t107LeafID_Src,
            string t119LeafList, 
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
                List<QCOperationsForNG> datas = new List<QCOperationsForNG>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID_TS", DbType.Int32, t107LeafID_TS));
                paramList.Add(new IRAPProcParameter("@T102LeafID_Src", DbType.Int32, t107LeafID_Src));
                paramList.Add(new IRAPProcParameter("@T119LeafList", DbType.String, t119LeafList));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_QCOperationsForNG，" +
                        "参数：CommunityID={0}|T102LeafID={1}|T107LeafID_TS={2}|"+
                        "T107LeafID_Src={3}|T119LeafList={4}|SysLogID={5}",
                        communityID, t102LeafID, t107LeafID_TS, t107LeafID_Src, 
                        t119LeafList, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_QCOperationsForNG(" +
                            "@CommunityID, @T102LeafID, @T107LeafID_TS, @T107LeafID_Src, " +
                            "@T119LeafList, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<QCOperationsForNG> lstDatas =
                            conn.CallTableFunc<QCOperationsForNG>(strSQL, paramList);
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
                            "调用 IRAPMES..ufn_GetList_QCOperationsForNG 函数发生异常：{0}",
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

        /// <param name="communityID">社区标识</param>
        /// <param name="menuItemID">功能菜单标识号</param>
        /// <param name="progLanguageID">编程语言标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_TSFormCtrl(
            int communityID,
            int menuItemID,
            int progLanguageID,
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
                List<TSFormCtrl> datas = new List<TSFormCtrl>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@MenuItemID", DbType.Int32, menuItemID));
                paramList.Add(new IRAPProcParameter("@ProgLanguageID", DbType.Int32, progLanguageID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_TSFormCtrl，" +
                        "参数：CommunityID={0}|MenuItemID={1}|ProgLanguageID={2}|" +
                        "SysLogID={3}",
                        communityID, menuItemID, progLanguageID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_TSFormCtrl(" +
                            "@CommunityID, @MenuItemID, @ProgLanguageID, " +
                            "@SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<TSFormCtrl> lstDatas =
                            conn.CallTableFunc<TSFormCtrl>(strSQL, paramList);
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
                            "调用 IRAPMES..ufn_GetList_TSFormCtrl 函数发生异常：{0}",
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

        public IRAPJsonResult usp_PokaYoke_TroubleShooting(
            int communityID,
            int productLeaf,
            int workUnitLeaf,
            string wipIDCode,
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
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, ParameterDirection.InputOutput, 4)
                {
                    Value = productLeaf,
                });
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@WIPIDCode", DbType.String, wipIDCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, ParameterDirection.Output, 18));
                paramList.Add(new IRAPProcParameter("@WIPPattern", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@SrcT107LeafID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@SrcT216LeafID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@RSFactPK", DbType.Int64, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@LinkedFactID", DbType.Int64, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@NumTestChannels", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAPMES..usp_PokaYoke_TroubleShooting，参数：" +
                        "CommunityID={0}|ProductLeaf={1}|WorkUnitLeaf={2}|"+
                        "WIPIDCode={3}|SysLogID={4}",
                        communityID, productLeaf, workUnitLeaf,
                        wipIDCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = 
                        conn.CallProc(
                            "IRAPMES..usp_PokaYoke_TroubleShooting", 
                            ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    Hashtable rtnParams = new Hashtable();
                    if (errCode == 0)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                            {
                                if (param.Value == DBNull.Value)
                                {
                                    switch (param.DbType)
                                    {
                                        case DbType.Double:
                                        case DbType.Byte:
                                        case DbType.SByte:
                                        case DbType.Int16:
                                        case DbType.Int32:
                                        case DbType.Int64:
                                            rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                            break;
                                        case DbType.String:
                                            rtnParams.Add(param.ParameterName.Replace("@", ""), "");
                                            break;
                                        case DbType.Date:
                                        case DbType.DateTime:
                                        case DbType.DateTime2:
                                        case DbType.DateTimeOffset:
                                            rtnParams.Add(
                                                param.ParameterName.Replace("@", ""),
                                                Convert.ToDateTime("1900-1-1 0:0:0"));
                                            break;
                                    }
                                }
                                else
                                {
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                                }
                            }
                        }
                    }

                    return Json(rtnParams);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = 
                    string.Format(
                        "调用 IRAPMES..usp_PokaYoke_TroubleShooting 时发生异常：{0}", 
                        error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取子在制品标识清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="wipPattern"></param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[SubWIPIDCodes_TS]</returns>
        public IRAPJsonResult ufn_GetList_SubWIPIDCodes_TS(
            int communityID,
            string wipPattern,
            int productLeaf,
            int workUnitLeaf,
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
                List<SubWIPIDCodes_TS> datas = new List<SubWIPIDCodes_TS>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@WIPPattern", DbType.String, wipPattern));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_SubWIPIDCodes_TS，" +
                        "参数：CommunityID={0}|WIPPattern={1}|ProductLeaf={2}|"+
                        "WorkUnitLeaf={3}|SysLogID={4}",
                        communityID, wipPattern, productLeaf, workUnitLeaf, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_SubWIPIDCodes_TS(" +
                            "@CommunityID, @WIPPattern, @ProductLeaf, " +
                            "@WorkUnitLeaf, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<SubWIPIDCodes_TS> lstDatas =
                            conn.CallTableFunc<SubWIPIDCodes_TS>(strSQL, paramList);
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
                            "调用 IRAPMES..ufn_GetList_SubWIPIDCodes_TS 函数发生异常：{0}",
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
        /// 获取不良在制品失效情况
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID_Src">来源工位叶标识</param>
        /// <param name="wipIDCode">在制品主标识代码（个体）</param>
        /// <param name="rsFactPK">行集事实分区键</param>
        /// <param name="qcFactID">检查或测试事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_FailuresOfNGProduct(
            int communityID,
            int t102LeafID,
            int t107LeafID_Src,
            string wipIDCode,
            long rsFactPK,
            long qcFactID,
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
                List<FailuresOfNGProduct> datas = new List<FailuresOfNGProduct>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID_Src", DbType.Int32, t107LeafID_Src));
                paramList.Add(new IRAPProcParameter("@WIPIDCode", DbType.String, wipIDCode));
                paramList.Add(new IRAPProcParameter("@RSFactPK", DbType.Int64, rsFactPK));
                paramList.Add(new IRAPProcParameter("@QCFactID", DbType.Int64, qcFactID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_FailuresOfNGProduct，" +
                        "参数：CommunityID={0}|T102LeafID={1}|T107LeafID_Src={2}|" +
                        "WIPIDCode={3}|RSFactPK={4}|QCFactID={5}|SysLogID={6}",
                        communityID, t102LeafID, t107LeafID_Src, wipIDCode,
                        rsFactPK, qcFactID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_FailuresOfNGProduct(" +
                            "@CommunityID, @T102LeafID, @T107LeafID_Src, " +
                            "@WIPIDCode, @RSFactPK, @QCFactID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<FailuresOfNGProduct> lstDatas =
                            conn.CallTableFunc<FailuresOfNGProduct>(strSQL, paramList);
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
                            "调用 IRAPMES..ufn_GetList_FailuresOfNGProduct 函数发生异常：{0}",
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
        /// 获取维修物料超市先进先出物料的SKUID
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID_TS">维修工位叶标识</param>
        /// <param name="t101LeafID">物料叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>string</returns>
        public IRAPJsonResult ufn_GetFIFOSKUIDinTSSite(
            int communityID,
            int t107LeafID_TS,
            int t101LeafID,
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
                paramList.Add(new IRAPProcParameter("@T107LeafID_TS", DbType.Int32, t107LeafID_TS));
                paramList.Add(new IRAPProcParameter("@T101LeafID", DbType.Int32, t101LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES.dbo.ufn_GetFIFOSKUIDinTSSite，参数："+
                        "CommunityID={0}|T107LeafID_TS={1}|T101LeafID={2}|"+
                        "SysLogID={3}",
                        communityID,
                        t107LeafID_TS,
                        t101LeafID,
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
                                "IRAPMES.dbo.ufn_GetFIFOSKUIDinTSSite", 
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
                            "调用 IRAPMES.dbo.ufn_GetFIFOSKUIDinTSSite 函数发生异常：{0}", 
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    return Json(0);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据器件位号或物料代码获取追溯标签序列号
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="wipCode">在制品主标识代码</param>
        /// <param name="t110LeafID">器件位置叶标识</param>
        /// <param name="t101LeafID">原辅材料叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>string</returns>
        public IRAPJsonResult ufn_GetMaterialSKUIDBySymbol(
            int communityID,
            string wipCode,
            int t110LeafID,
            int t101LeafID,
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
                paramList.Add(new IRAPProcParameter("@WIPCode", DbType.String, wipCode));
                paramList.Add(new IRAPProcParameter("@T110LeafID", DbType.Int32, t110LeafID));
                paramList.Add(new IRAPProcParameter("@T101LeafID", DbType.Int32, t101LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES.dbo.ufn_GetMaterialSKUIDBySymbol，参数：" +
                        "CommunityID={0}|WIPCode={1}|T110LeafID={2}|" +
                        "T101LeafID={3}|SysLogID={4}",
                        communityID,
                        wipCode,
                        t110LeafID,
                        t101LeafID,
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
                                "IRAPMES.dbo.ufn_GetMaterialSKUIDBySymbol",
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
                            "调用 IRAPMES.dbo.ufn_GetMaterialSKUIDBySymbol 函数发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    return Json(0);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 保存在制品故障维修事实
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">维修人员工号</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t216Code">工序代码</param>
        /// <param name="destT216LeafID">修复转出目前工序</param>
        /// <param name="subWIPIDCodes">在制品维修内容清单</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_SaveFact_TroubleShooting(
            int communityID,
            string userCode,
            int productLeaf,
            int workUnitLeaf,
            int t216LeafID,
            string t216Code,
            int destT216LeafID,
            List<SubWIPIDCode_TroubleShooting> subWIPIDCodes,
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
            WriteLog.Instance.Write("开始接受数据..", strProcedureName);
            IRAPSQLConnection conn = new IRAPSQLConnection();
            try
            {
                WriteLog.Instance.Write(
                    string.Format(
                        "SubWIPIDCodes 的数据量：{0}",
                        subWIPIDCodes.Count), 
                    strProcedureName);

                #region 获取事实表维度数据
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@ProcessLeaf", DbType.Int32, 0));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));

                WIPContext dimesion = 
                    (WIPContext)conn.Get<WIPContext>(
                        "SELECT * FROM IRAPMES..ufn_GetInfo_WIPContext(" +
                        "@CommunityID, @ProductLeaf, @ProcessLeaf, @WorkUnitLeaf, @SysLogID)",
                        paramList);
                conn.Close();
                #endregion

                #region 申请交易号
                WriteLog.Instance.Write("开始申请交易号", strProcedureName);
                long transactNo = 0;
                try
                {
                    ssp_GetSequenceNo(
                        communityID,
                        "NextTransactNo",
                        1,
                        sysLogID,
                        "-11",
                        "",
                        ref transactNo,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode == 0)
                    {
                        WriteLog.Instance.Write(string.Format("申请到的交易号：{0}", transactNo),
                            strProcedureName);
                    }
                    else
                    {
                        errCode = 99001;
                        errText = string.Format("申请交易号出错：{0}", errText);
                        WriteLog.Instance.Write(errText, strProcedureName);
                        return Json(errCode);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99001;
                    errText = string.Format("申请交易号出错：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    return Json(errCode);
                }
                #endregion


                // 开始新事务保存
                WriteLog.Instance.Write("开始新事务保存", strProcedureName);
                conn.BeginTran();
                WriteLog.Instance.Write("新事务保存开始了", strProcedureName);

                try
                {
                    #region 保存事实
                    foreach (SubWIPIDCode_TroubleShooting wipIDCode in subWIPIDCodes)
                    {
                        long factID = IRAPDAL.UTS.Instance.msp_GetSequenceNo("NextFactNo", 1);
                        long factPartitionPolicy =
                            PartitioningKey.Instance.GetFactPartitionPolicy(
                                communityID,
                                DateTime.Now.Year,
                                11);
                        long auxPartitioning =
                            PartitioningKey.Instance.GetAuxPartitionPolicy(
                                communityID,
                                DateTime.Now.Year,
                                wipIDCode.PWOCategoryLeaf);

                        #region 保存主事实
                        FixedFact_MES tempFact = new FixedFact_MES();
                        tempFact.FactID = factID;
                        tempFact.TransactNo = transactNo;
                        tempFact.PartitioningKey = factPartitionPolicy;
                        tempFact.OpID = 11;
                        tempFact.OpType = wipIDCode.RepairStatus;
                        tempFact.BusinessDate = DateTime.Now;
                        tempFact.Leaf01 = productLeaf;          // 产品
                        tempFact.Leaf02 = dimesion.T120Leaf;    // 流程（返工流程）
                        tempFact.Leaf03 = workUnitLeaf;         // 工位
                        tempFact.Leaf04 = dimesion.T126Leaf;    // 班次
                        tempFact.Leaf05 = dimesion.T1Leaf;      // 班组
                        tempFact.Leaf06 = dimesion.T134Leaf;    // 产线
                        tempFact.Leaf07 = dimesion.T181Leaf;    // 工厂
                        tempFact.Leaf08 = dimesion.T1002Leaf;   // 所属公司
                        tempFact.Leaf09 = t216LeafID;           // 工序
                        tempFact.Code01 = wipIDCode.PartNumber;
                        tempFact.Code02 = dimesion.T120Code;
                        tempFact.Code03 = dimesion.T107Code;
                        tempFact.Code04 = dimesion.T126Code;
                        tempFact.Code05 = dimesion.T1Code;
                        tempFact.Code06 = dimesion.T134Code;
                        tempFact.Code07 = dimesion.T181Code;
                        tempFact.Code08 = dimesion.T1002Code;
                        tempFact.Code09 = t216Code;
                        tempFact.IsFixed = 1;
                        tempFact.Metric01 = 1;
                        tempFact.WFInstanceID = wipIDCode.SubWIPIDCode;
                        tempFact.LinkedFactID = wipIDCode.LinkedFactID;
                        tempFact.Remark = "故障维修";
                        WriteLog.Instance.Write("开始保存主事实", strProcedureName);
                        conn.Insert(tempFact);
                        WriteLog.Instance.Write("保存主事实完成", strProcedureName);
                        #endregion

                        #region  保存辅助事实
                        AuxFact_PDC auxFact = new AuxFact_PDC();
                        auxFact.FactID = factID;
                        auxFact.PartitioningKey = auxPartitioning;
                        auxFact.FactPartitioningKey = factPartitionPolicy;
                        auxFact.WFInstanceID = wipIDCode.PWONo;
                        auxFact.WIPCode = wipIDCode.SubWIPIDCode;
                        auxFact.AltWIPCode = "";
                        auxFact.SerialNumber = "";
                        auxFact.LotNumber = "";
                        auxFact.ContainerNo = "";
                        WriteLog.Instance.Write("开始保存辅助事实", strProcedureName);
                        conn.Insert(auxFact);
                        WriteLog.Instance.Write("保存辅助事实完成", strProcedureName);
                        #endregion

                        #region 更新路由
                        if (destT216LeafID > 0)
                        {
                            long wipPartition =
                                PartitioningKey.Instance.GetWIPPartitioningKey(
                                    communityID,
                                    wipIDCode.PWOCategoryLeaf);

                            IList<IDataParameter> paramSet = new List<IDataParameter>();
                            paramSet.Add(new IRAPProcParameter("@DstT216LeafID", DbType.Int32, destT216LeafID));
                            paramSet.Add(new IRAPProcParameter("@PartitioningKey", DbType.Int64, communityID * 10000));
                            paramSet.Add(new IRAPProcParameter("@EntityID", DbType.Int32, workUnitLeaf));
                            paramSet.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, productLeaf));
                            paramSet.Add(new IRAPProcParameter("@WIPCode", DbType.String, wipIDCode.SubWIPIDCode));

                            WriteLog.Instance.Write("开始更新路由", strProcedureName);
                            conn.Update(
                                "UPDATE IRAPMES..utb_WIPs_TroubleShooting " +
                                "SET DstT216LeafID=@DstT216LeafID " +
                                "WHERE PartitioningKey=@PartitioningKey AND " +
                                "EntityID=@EntityID AND " +
                                "T102LeafID=@T102LeafID AND " +
                                "WIPCode=@WIPCode ",
                                paramSet);
                            WriteLog.Instance.Write("更新路由完成", strProcedureName);
                        }
                        #endregion

                        #region 写行集事实
                        int ordinal = 0;
                        WriteLog.Instance.Write(
                            string.Format(
                                "WIPIDCode.TSItems 条数：{0}",
                                wipIDCode.TSItems.Count),
                            strProcedureName);
                        //wipIDCode.GetListFromDataTable();
                        foreach (SubWIPIDCode_TSItem item in wipIDCode.TSItems)
                        {
                            WriteLog.Instance.Write(
                                string.Format(
                                    "T101: [{0}]|T110: [{1}]",
                                    item.T101LeafID, item.T110LeafID),
                                strProcedureName);

                            ordinal++;
                            TBL_RSFact_TSDataCollecting rsfact = new TBL_RSFact_TSDataCollecting();
                            rsfact.PartitioningKey = factPartitionPolicy;
                            rsfact.FactID = factID;
                            rsfact.WFInstanceID = wipIDCode.SubWIPIDCode;
                            rsfact.Ordinal = ordinal;
                            rsfact.T110LeafID = item.T110LeafID;
                            rsfact.T118LeafID = item.T118LeafID;
                            rsfact.T119LeafID = item.T119LeafID;
                            rsfact.T183LeafID = item.T183LeafID;
                            rsfact.T184LeafID = item.T184LeafID;
                            rsfact.T101LeafID = item.T101LeafID;
                            rsfact.T216LeafID = item.T216LeafID;
                            rsfact.CntDefect = item.FailurePointCount;
                            rsfact.MaterialLabelSN0 = item.SKUID1;
                            rsfact.MaterialLabelSN1 = item.SKUID2;
                            rsfact.TrackRef = item.TrackReferenceValue;
                            try
                            {
                                conn.Insert(rsfact);
                            }
                            catch (Exception error)
                            {
                                WriteLog.Instance.Write(error.Message, strProcedureName);

                                conn.RollBack();

                                errCode = 999001;
                                errText = string.Format("行集事实保存失败：{0}", error.Message);

                                return Json(errCode);
                            }
                            WriteLog.Instance.Write("行集事实保存成功", strProcedureName);
                        }
                        #endregion

                        #region 产品报废时需要写报废事实
                        if (wipIDCode.RepairStatus == 4 || wipIDCode.RepairStatus == 5)
                        {
                            #region 申请报废事实编号
                            factID = IRAPDAL.UTS.Instance.msp_GetSequenceNo("NextFactNo", 1);
                            #endregion

                            #region 保存报废主事实
                            FixedFact_MES scrappingOLTP = new FixedFact_MES();
                            scrappingOLTP.FactID = factID;
                            scrappingOLTP.TransactNo = transactNo;
                            scrappingOLTP.PartitioningKey = factPartitionPolicy;
                            scrappingOLTP.OpID = 17;
                            scrappingOLTP.OpType = 1;
                            scrappingOLTP.BusinessDate = DateTime.Now;
                            scrappingOLTP.Leaf01 = productLeaf;        //产品
                            scrappingOLTP.Leaf02 = dimesion.T120Leaf;  //流程（返工流程）
                            scrappingOLTP.Leaf03 = workUnitLeaf;       //工位
                            scrappingOLTP.Leaf04 = dimesion.T126Leaf;  //班次
                            scrappingOLTP.Leaf05 = dimesion.T1Leaf;    //班组
                            scrappingOLTP.Leaf06 = dimesion.T134Leaf;  //产线
                            scrappingOLTP.Leaf07 = dimesion.T181Leaf;  //工厂
                            scrappingOLTP.Leaf08 = dimesion.T1002Leaf; //所属公司
                            scrappingOLTP.Leaf09 = t216LeafID;
                            scrappingOLTP.Code01 = wipIDCode.PartNumber;
                            scrappingOLTP.Code02 = dimesion.T120Code;
                            scrappingOLTP.Code03 = dimesion.T107Code;
                            scrappingOLTP.Code04 = dimesion.T126Code;
                            scrappingOLTP.Code05 = dimesion.T1Code;
                            scrappingOLTP.Code06 = dimesion.T134Code;
                            scrappingOLTP.Code07 = dimesion.T181Code;
                            scrappingOLTP.Code08 = dimesion.T1002Code;
                            scrappingOLTP.Code09 = t216Code;
                            scrappingOLTP.IsFixed = 1;
                            scrappingOLTP.Metric01 = 1;
                            scrappingOLTP.WFInstanceID = wipIDCode.SubWIPIDCode;
                            scrappingOLTP.LinkedFactID = wipIDCode.LinkedFactID;
                            scrappingOLTP.Remark = "故障维修";
                            conn.Insert(scrappingOLTP);
                            #endregion

                            #region 保存报废辅助事实
                            AuxFact_PDC scrappingAuxFact = new AuxFact_PDC();
                            scrappingAuxFact.FactID = factID;
                            scrappingAuxFact.PartitioningKey = auxPartitioning;
                            scrappingAuxFact.FactPartitioningKey = factPartitionPolicy;
                            scrappingAuxFact.WFInstanceID = wipIDCode.PWONo;
                            scrappingAuxFact.WIPCode = wipIDCode.SubWIPIDCode;
                            scrappingAuxFact.AltWIPCode = "";
                            scrappingAuxFact.SerialNumber = "";
                            scrappingAuxFact.LotNumber = "";
                            scrappingAuxFact.ContainerNo = "";
                            conn.Insert(scrappingAuxFact);
                            #endregion

                            #region 保存报废行集事实
                            ordinal = 0;
                            foreach (SubWIPIDCode_TSItem item in wipIDCode.TSItems)
                            {
                                long[] materialArray =
                                    GetMaterialTrackID(
                                        communityID,
                                        wipIDCode.SubWIPIDCode,
                                        productLeaf,
                                        workUnitLeaf,
                                        item.T101LeafID,
                                        sysLogID);

                                ordinal++;
                                TBL_RSFact_WIPScrapping rsfact = new TBL_RSFact_WIPScrapping();
                                rsfact.PartitioningKey = factPartitionPolicy;
                                rsfact.FactID = factID;
                                rsfact.WFInstanceID = wipIDCode.SubWIPIDCode;
                                rsfact.Ordinal = ordinal;
                                rsfact.T101LeafID = item.T110LeafID;
                                rsfact.T102LeafID = dimesion.T102Leaf;
                                rsfact.T104LeafID = 0;
                                rsfact.T181LeafID = dimesion.T181Leaf;

                                rsfact.QtyScrapped = 1;
                                rsfact.QtyScale = 0;
                                rsfact.AmtScrapped = 0;
                                rsfact.AmtScale = 0;
                                rsfact.BondedGoods = false;
                                rsfact.LotNumber = "";
                                rsfact.MaterialTrackID = materialArray[0];
                                conn.Insert(rsfact);
                            }
                            #endregion
                        }
                        #endregion
                    }

                    conn.Commit();
                    #endregion
                }
                catch (Exception err)
                {
                    errCode = 9999;
                    errText = "保存事实失败：" + err.Message;
                    conn.RollBack();
                    return Json(errCode);
                }

                #region 复核交易
                usp_CheckTransaction_11(
                    communityID,
                    transactNo,
                    sysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("复核交易结果：({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    errCode = 0;
                    errText = "故障维修事实保存成功";
                }
                else
                {
                    errCode = 9999;
                    errText = string.Format("故障维修事实保存成功，复核交易失败：{0}", errText);
                }
                #endregion

                return Json(errCode);
            }
            finally
            {
                conn.Close();
                conn = null;

                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}