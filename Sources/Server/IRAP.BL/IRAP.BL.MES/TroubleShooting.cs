using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;

using IRAP.Global;
using IRAP.Entities.MES;
using IRAPORM;
using IRAPShared;
using IRAPDAL;

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
        /// <param name="srcT107LeafID">来源工位叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_QCOperationsForNG(
            int communityID, 
            int t102LeafID, 
            int srcT107LeafID, 
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
                paramList.Add(new IRAPProcParameter("@SrcT107LeafID", DbType.Int32, srcT107LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_QCOperationsForNG，" +
                        "参数：CommunityID={0}|T102LeafID={1}|SrcT107LeafID={2}|" +
                        "SysLogID={3}",
                        communityID, t102LeafID, srcT107LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_QCOperationsForNG(" +
                            "@CommunityID, @T102LeafID, @SrcT107LeafID, " +
                            "@SysLogID) " +
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
        /// <param name="qcFactID">检查或测试事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_FailuresOfNGProduct(
            int communityID,
            int t102LeafID,
            int t107LeafID_Src,
            string wipIDCode,
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
                paramList.Add(new IRAPProcParameter("@QCFactID", DbType.Int64, qcFactID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_FailuresOfNGProduct，" +
                        "参数：CommunityID={0}|T102LeafID={1}|T107LeafID_Src={2}|" +
                        "WIPIDCode={3}|QCFactID={4}|SysLogID={5}",
                        communityID, t102LeafID, t107LeafID_Src, wipIDCode,
                        qcFactID, sysLogID),
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
                            "@WIPIDCode, @QCFactID, @SysLogID) " +
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
        /// 保存在制品故障维修事实
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">维修人员工号</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="destT216LeafID">修复转出目前工序</param>
        /// <param name="subWIPIDCodes">在制品维修内容清单</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_SaveFact_TroubleShooting(
            int communityID,
            string userCode,
            int productLeaf,
            int workUnitLeaf,
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
                long transactNo = 0;
                try
                {
                    transactNo = IRAPDAL.UTS.Instance.msp_GetTransactNo(
                        communityID,
                        1,
                        "IRAPMES..stb010",
                        userCode,
                        sysLogID,
                        "",
                        "",
                        out errCode,
                        out errText,
                        true);
                }
                catch (Exception error)
                {
                    errCode = 99001;
                    errText = string.Format("申请交易号出错：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    return Json(errCode);
                }
                if (errCode != 0)
                {
                    errCode = 99001;
                    errText = string.Format("申请交易号出错：{0}", errText);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    return Json(errCode);
                }
                else
                {
                    WriteLog.Instance.Write(string.Format("申请到的交易号：{0}", transactNo),
                        strProcedureName);
                }
                #endregion


                // 开始新事务保存
                conn.BeginTran();
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
                        TBL_FixedFact_MES tempFact = new TBL_FixedFact_MES();
                        tempFact.FactID = factID;
                        tempFact.TransactNo = transactNo;
                        tempFact.PartitionPolicy = factPartitionPolicy;
                        tempFact.OpID = 11;
                        tempFact.OpType = wipIDCode.RepairStatus;
                        tempFact.BusinessDate = DateTime.Now;
                        tempFact.Leaf01 = productLeaf;        //产品
                        tempFact.Leaf02 = dimesion.T120Leaf;  //流程（返工流程）
                        tempFact.Leaf03 = workUnitLeaf;       //工位
                        tempFact.Leaf04 = dimesion.T126Leaf;  //班次
                        tempFact.Leaf05 = dimesion.T1Leaf;    //班组
                        tempFact.Leaf06 = dimesion.T134Leaf;  //产线
                        tempFact.Leaf07 = dimesion.T181Leaf;  //工厂
                        tempFact.Leaf08 = dimesion.T1002Leaf; //所属公司
                        tempFact.Code01 = wipIDCode.PartNumber;
                        tempFact.Code02 = dimesion.T120Code;
                        tempFact.Code03 = dimesion.T107Code;
                        tempFact.Code04 = dimesion.T126Code;
                        tempFact.Code05 = dimesion.T1Code;
                        tempFact.Code06 = dimesion.T134Code;
                        tempFact.Code07 = dimesion.T181Code;
                        tempFact.Code08 = dimesion.T1002Code;
                        tempFact.IsFixed = 1;
                        tempFact.Metric01 = 1;
                        tempFact.WFInstanceID = wipIDCode.SubWIPIDCode;
                        tempFact.LinkedFactID = wipIDCode.LinkedFactID;
                        tempFact.Remark = "故障维修";
                        conn.Insert(tempFact);
                        #endregion

                        #region  保存辅助事实
                        TBL_AuxFact_PDC auxFact = new TBL_AuxFact_PDC();
                        auxFact.FactID = factID;
                        auxFact.PartitionPolicy = auxPartitioning;
                        auxFact.FactPartitioningKey = factPartitionPolicy;
                        auxFact.WFInstanceID = dimesion.PWONo;
                        auxFact.WIPCode = wipIDCode.SubWIPIDCode;
                        auxFact.AltWIPCode = "";
                        auxFact.SerialNumber = "";
                        auxFact.LotNumber = "";
                        auxFact.ContainerNo = "";
                        conn.Insert(auxFact);
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
                            paramSet.Add(new IRAPProcParameter("@PartitioningKey", DbType.Int64, wipPartition));
                            paramSet.Add(new IRAPProcParameter("@EntityID", DbType.Int32, workUnitLeaf));
                            paramSet.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, productLeaf));
                            paramSet.Add(new IRAPProcParameter("@WIPCode", DbType.String, wipIDCode.SubWIPIDCode));

                            conn.Update(
                                "UPDATE IRAPMES..utb_WIPs_TroubleShooting " +
                                "SET DstT216LeafID=@DstT216LeafID " +
                                "WHERE PartitioningKey=@PartitioningKey AND " +
                                "EntityID=@EntityID AND " +
                                "T102LeafID=@T102LeafID AND " +
                                "WIPCode=@WIPCode ",
                                paramSet);
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
                            rsfact.PartitionPolicy = factPartitionPolicy;
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
                            long[] materialArray =
                                GetMaterialTrackID(
                                    communityID,
                                    wipIDCode.SubWIPIDCode,
                                    productLeaf,
                                    workUnitLeaf,
                                    item.T101LeafID,
                                    sysLogID);
                            rsfact.MaterialTrackID0 = materialArray[0];
                            rsfact.MaterialTrackID1 = materialArray[1];
                            rsfact.TrackRef = item.TrackReferenceValue;
                            conn.Insert(rsfact);

                            IList<IDataParameter> paramProcList = new List<IDataParameter>();
                            paramProcList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                            paramProcList.Add(new IRAPProcParameter("@MaterialTrackID0", DbType.Int64, materialArray[0]));
                            paramProcList.Add(new IRAPProcParameter("@MaterialTrackID1", DbType.Int64, materialArray[1]));
                            paramProcList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, productLeaf));
                            paramProcList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, workUnitLeaf));
                            paramProcList.Add(new IRAPProcParameter("@T101LeafID", DbType.Int32, item.T101LeafID));
                            paramProcList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                            paramProcList.Add(new IRAPProcParameter("@ErrCode", DbType.Int64, ParameterDirection.Output, 4));
                            paramProcList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));

                            IRAPError saveError =
                                conn.CallProc(
                                    "IRAPMES..usp_SaveFact_TroubleShootingTrace",
                                    ref paramProcList);
                            if (saveError.ErrCode != 0)
                            {
                                conn.RollBack();
                                errCode = saveError.ErrCode;
                                errText = saveError.ErrText;
                                return Json(errCode);
                            }
                            //Console.WriteLine(item.T110LeafID + " " + item.T118LeafID);
                        }
                        #endregion

                        #region 产品报废时需要写报废事实
                        if (wipIDCode.RepairStatus == 4 || wipIDCode.RepairStatus == 5)
                        {
                            #region 申请报废事实编号
                            factID = IRAPDAL.UTS.Instance.msp_GetSequenceNo("NextFactNo", 1);
                            #endregion

                            #region 保存报废主事实
                            TBL_FixedFact_MES scrappingOLTP = new TBL_FixedFact_MES();
                            scrappingOLTP.FactID = factID;
                            scrappingOLTP.TransactNo = transactNo;
                            scrappingOLTP.PartitionPolicy = factPartitionPolicy;
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
                            scrappingOLTP.Code01 = wipIDCode.PartNumber;
                            scrappingOLTP.Code02 = dimesion.T120Code;
                            scrappingOLTP.Code03 = dimesion.T107Code;
                            scrappingOLTP.Code04 = dimesion.T126Code;
                            scrappingOLTP.Code05 = dimesion.T1Code;
                            scrappingOLTP.Code06 = dimesion.T134Code;
                            scrappingOLTP.Code07 = dimesion.T181Code;
                            scrappingOLTP.Code08 = dimesion.T1002Code;
                            scrappingOLTP.IsFixed = 1;
                            scrappingOLTP.Metric01 = 1;
                            scrappingOLTP.WFInstanceID = wipIDCode.SubWIPIDCode;
                            scrappingOLTP.LinkedFactID = wipIDCode.LinkedFactID;
                            scrappingOLTP.Remark = "故障维修";
                            conn.Insert(scrappingOLTP);
                            #endregion

                            #region 保存报废辅助事实
                            TBL_AuxFact_PDC scrappingAuxFact = new TBL_AuxFact_PDC();
                            scrappingAuxFact.FactID = factID;
                            scrappingAuxFact.PartitionPolicy = auxPartitioning;
                            scrappingAuxFact.FactPartitioningKey = factPartitionPolicy;
                            scrappingAuxFact.WFInstanceID = dimesion.PWONo;
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
                                rsfact.PartitionPolicy = factPartitionPolicy;
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
                    #endregion

                    #region 复核交易
                    UTS.IRAPUTS uts = new UTS.IRAPUTS();
                    uts.ssp_CheckTransaction(
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
                        conn.Commit();

                        errCode = 0;
                        errText = "故障维修事实保存成功";
                    }
                    else
                    {
                        conn.RollBack();

                        errCode = 9999;
                        errText = string.Format("故障维修事实保存失败：{0}", errText);
                    }
                   #endregion
                }

                return Json(errCode);
            }
            catch (Exception err)
            {
                errCode = 9999;
                errText = "保存事实失败：" + err.Message;
                conn.RollBack();
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