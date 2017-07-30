using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Server.Global;
using IRAP.Entities.MES;
using IRAP.Entities.MES.Tables;
using IRAPORM;
using IRAPShared;
using IRAPShared.Json;
using IRAP.BL.MDM;

namespace IRAP.BL.MES
{
    public class ManualInspecting : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ManualInspecting()
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
        /// 计算 QCStatus 的值
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="pwoNo">工单号</param>
        /// <param name="qcStatus">质量控制状态</param>
        private long CalculateQCStatus(
            int communityID,
            int t102LeafID,
            int t107LeafID,
            string pwoNo,
            long qcStatus)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}",
                    className, 
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                QC qc = new QC();
                try
                {
                    IRAPJsonResult rlt = 
                        qc.ufn_GetQCCheckPointOrdinal(
                            communityID, 
                            t102LeafID, 
                            t107LeafID, 
                            pwoNo, 
                            out errCode, 
                            out errText);
                    int qcCheckPointOrdinal = 
                        (int)IRAPJsonSerializer.Deserializer(
                            rlt.Json, 
                            typeof(int));
                    if (errCode == 0)
                    {
                        qcStatus = qcStatus | Int64.Parse(Math.Pow(2, (23 + qcCheckPointOrdinal)).ToString());
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                }
                return qcStatus;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取指定在制品经过指定工位的次数
        /// </summary>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="wipCode">在制品主标识代码</param>
        private int ufn_GetWIPPassByTimes(
            int communityID,
            int t102LeafID,
            int t107LeafID,
            string wipCode)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}",
                    className, 
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                WIP wip = new WIP();
                try
                {
                    IRAPJsonResult rlt = 
                        wip.ufn_GetWIPPassByTimes(
                            communityID, 
                            t102LeafID, 
                            t107LeafID, 
                            wipCode, 
                            out errCode, 
                            out errText);
                    return (int)IRAPJsonSerializer.Deserializer(rlt.Json, typeof(int));
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    return 0;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取工序标准周期时间
        /// </summary>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        private long ufn_GetStdCycleTimeOfOperation(
            int communityID,
            int t102LeafID,
            int t107LeafID)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}",
                    className, 
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                IRAPMDM mdm = new IRAPMDM();
                try
                {
                    IRAPJsonResult rlt = 
                        mdm.ufn_GetStdCycleTimeOfOperation(
                            communityID, 
                            t102LeafID, 
                            t107LeafID, 
                            out errCode, 
                            out errText);
                    return (long)IRAPJsonSerializer.Deserializer(rlt.Json, typeof(long));
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    return 0;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 人工检查实体对象中是否有子板需要送修
        /// </summary>
        /// <param name="wipInspecting"></param>
        /// <returns></returns>
        private bool NeedRepair(Inspecting wipInspecting)
        {
            foreach (SubWIPIDCodeInfo_Inspecting subWIP in wipInspecting.SubWIPIDCodes)
            {
                if (subWIP.InspectingStatus == 3)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 根据工位呼叫安灯记录计算工位停产时间(秒)
        /// </summary>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="periodBegin">期间开始时间</param>
        /// <param name="periodEnd">期间结束时间</param>
        /// <returns>long</returns>
        private long ufn_GetUnscheduledPDTofAWorkUnit(
            int communityID,
            int t107LeafID,
            DateTime periodBegin,
            DateTime periodEnd,
            long sysLogID)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}",
                    className, 
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                WorkUnit workUnit = new WorkUnit();
                try
                {
                    IRAPJsonResult rlt = 
                        workUnit.ufn_GetUnscheduledPDTofAWorkUnit(
                            communityID, 
                            t107LeafID, 
                            periodBegin, 
                            periodEnd, 
                            sysLogID, 
                            out errCode, 
                            out errText);
                    return (long)IRAPJsonSerializer.Deserializer(rlt.Json, typeof(long));
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    return 0;
                }
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
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="rsFactXML">检查结果 XML 
        /// [RSFact]
        ///     [RF17 Ordinal="" T118LeafID="" Metric01="" /]
        /// [/RSFact]
        /// </param>
        /// <param name="inspectedQty">检查总不良品数量</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_SaveFact_FailureInspecting(
            int communityID,
            long transactNo,
            long factID,
            int t102LeafID,
            int t107LeafID,
            string pwoNo,
            string rsFactXML,
            long inspectedQty,
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
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, pwoNo));
                paramList.Add(new IRAPProcParameter("@RSFactXML", DbType.String, rsFactXML));
                paramList.Add(new IRAPProcParameter("@InspectedQty", DbType.Int64, inspectedQty));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_SaveFact_FailureInspecting，参数："+
                        "CommunityID={0}|TransactNo={1}|FactID={2}|"+
                        "T102LeafID={3}|T107LeafID={4}|PWONo={5}|"+
                        "RSFactXML={6}|InspectedQty={7}|SysLogID={8}",
                        communityID, transactNo, factID, t102LeafID,
                        t107LeafID, pwoNo, rsFactXML, inspectedQty, 
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_SaveFact_FailureInspecting", ref paramList);
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
                        "调用 IRAPMES..usp_SaveFact_FailureInspecting 函数发生异常：{0}",
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
        /// 人工检查记录保存
        /// </summary>
        /// <param name="userCode">系统登录用户号</param>
        /// <param name="agencyLeaf">登录用户的机构叶标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="t107EntityID">工位实体标识</param>
        /// <param name="t132LeafID">产品族叶标识</param>
        /// <param name="containerNo">容器号</param>
        /// <param name="functionName">功能名称</param>
        /// <param name="wipInspecting">人工检查实体对象</param>
        /// <param name="confirmTime">检查确认时间</param>
        /// <returns></returns>
        public IRAPJsonResult msp_SaveFact_ManualInspecting(
            int communityID,
            string userCode,
            int agencyLeaf,
            int productLeaf,
            int workUnitLeaf,
            int t107EntityID,
            int t132LeafID,
            string containerNo,
            string functionName,
            Inspecting wipInspecting,
            DateTime confirmTime,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                WriteLog.Instance.Write(string.Format("CommunityID={0}|UserCode={1}|AgencyLeaf={2}|" +
                        "ProductLeaf={3}|WorkUnitLeaf={4}|T107EntityID={5}|T132LeafID={6}|" +
                        "ContainerNo={7}|FunctionName={8}|ConfirmTime={9}|SysLogID={10}",
                        communityID,
                        userCode,
                        agencyLeaf,
                        productLeaf,
                        workUnitLeaf,
                        t107EntityID,
                        t132LeafID,
                        containerNo,
                        functionName,
                        confirmTime,
                        sysLogID),
                    strProcedureName);

                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    long transactNo = 0;

                    #region 申请交易号
                    WriteLog.Instance.Write("开始申请交易号", strProcedureName);
                    try
                    {
                        ssp_GetSequenceNo(
                            communityID,
                            "NextTransactNo",
                            1,
                            sysLogID,
                            "-6",
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

                    int passByTimes = ufn_GetWIPPassByTimes(
                        communityID, productLeaf, workUnitLeaf, wipInspecting.MainWIPIDCode.WIPCode);
                    long stdcycleTimeOfOperation = ufn_GetStdCycleTimeOfOperation(
                        communityID, productLeaf, workUnitLeaf);
                    long unscheduledPDTofAWorkUnit = ufn_GetUnscheduledPDTofAWorkUnit(
                        communityID,
                        workUnitLeaf,
                        wipInspecting.MainWIPIDCode.MoveInTime,
                        confirmTime,
                        sysLogID);

                    // 开始事务处理
                    conn.BeginTran();

                    foreach (SubWIPIDCodeInfo_Inspecting wip in wipInspecting.SubWIPIDCodes)
                    {
                        long factID = 0;
                        long partitionPolicy = 0;
                        long factPartitioningKey = 0;

                        #region 申请事实编号
                        try
                        {
                            factID = IRAPDAL.UTS.Instance.msp_GetSequenceNo("NextFactNo", 1);
                        }
                        catch (Exception error)
                        {
                            errCode = 99001;
                            errText = string.Format("申请事实编号出错：{0}", error.Message);
                            WriteLog.Instance.Write(errText, strProcedureName);
                            WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                            conn.RollBack();

                            return Json(errCode);
                        }
                        if (factID <= 0)
                        {
                            errCode = 99001;
                            errText = "未申请到事实编号！";
                            WriteLog.Instance.Write(errText, strProcedureName);

                            conn.RollBack();

                            return Json(errCode);
                        }
                        else
                        {
                            WriteLog.Instance.Write(string.Format("申请到的事实编号：{0}", factID),
                                strProcedureName);
                        }
                        #endregion

                        #region 在行集事实表(RSFact_Inspecting)中添加纪录
                        WriteLog.Instance.Write("保存行集事实", strProcedureName);
                        partitionPolicy = Int64.Parse(DateTime.Now.Year.ToString() +
                            (100000000L + communityID).ToString().Substring(1, 8) + "0006");

                        wip.GetListFromDataTable();
                        for (int i = 0; i < wip.FailureItems.Count; i++)
                        {
                            RSFact_Inspecting rsFactInspecting = new RSFact_Inspecting()
                            {
                                FactID = factID,
                                PartitionPolicy = partitionPolicy,
                                WFInstanceID = wipInspecting.MainWIPIDCode.PWONo,
                                Ordinal = i + 1,
                                T101LeafID = wip.FailureItems[i].T101LeafID,
                                T110LeafID = wip.FailureItems[i].T110LeafID,
                                T118LeafID = wip.FailureItems[i].T118LeafID,
                                T216LeafID = wip.FailureItems[i].T216LeafID,
                                T183LeafID = wip.FailureItems[i].T183LeafID,
                                T184LeafID = wip.FailureItems[i].T184LeafID,
                                CntDefect = wip.FailureItems[i].CntDefect,
                            };
                            try
                            {
                                conn.Insert(rsFactInspecting);
                            }
                            catch (Exception error)
                            {
                                errCode = 99002;
                                errText = string.Format("保存行集事实失败：{0}", error.Message);
                                WriteLog.Instance.Write(errText, strProcedureName);
                                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                                conn.RollBack();

                                return Json(errCode);
                            }
                        }
                        WriteLog.Instance.Write("行集事实保存完成", strProcedureName);
                        #endregion

                        #region 在辅助事实表(AuxFact_PDC)中添加纪录
                        WriteLog.Instance.Write("保存辅助事实", strProcedureName);
                        partitionPolicy = Int64.Parse(communityID.ToString() +
                            (100000000L + t132LeafID).ToString().Substring(1, 8) +
                            DateTime.Now.Year.ToString());
                        factPartitioningKey = Int64.Parse(DateTime.Now.Year.ToString() +
                            (100000000L + communityID).ToString().Substring(1, 8) + "0006");

                        AuxFact_PDC auxFactPDC = new AuxFact_PDC()
                        {
                            FactID = factID,
                            PartitioningKey = partitionPolicy,
                            FactPartitioningKey = factPartitioningKey,
                            WFInstanceID = wipInspecting.MainWIPIDCode.PWONo,
                            WIPCode = wip.SubWIPIDCode,
                            AltWIPCode = wipInspecting.MainWIPIDCode.AltWIPCode,
                            SerialNumber = wipInspecting.MainWIPIDCode.SerialNumber,
                            LotNumber = wipInspecting.MainWIPIDCode.LotNumber,
                            ContainerNo = containerNo,
                            FakePreventingCode = "",
                            CustomerAssignedID = "",
                            ElectronicProductCode = "",
                        };

                        #region 计算 QCStatus 值
                        if (wip.InspectingStatus == 3)
                            wip.QCStatus = CalculateQCStatus(communityID,
                                productLeaf,
                                workUnitLeaf,
                                wipInspecting.MainWIPIDCode.PWONo,
                                wip.QCStatus);
                        auxFactPDC.QCStatus = wip.QCStatus;
                        #endregion

                        try
                        {
                            conn.Insert(auxFactPDC);
                        }
                        catch (Exception error)
                        {
                            errCode = 99002;
                            errText = string.Format("保存辅助事实表失败：{0}", error.Message);
                            WriteLog.Instance.Write(errText, strProcedureName);
                            WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                            conn.RollBack();

                            return Json(errCode);
                        }
                        WriteLog.Instance.Write("辅助事实保存完成", strProcedureName);
                        #endregion

                        #region 在主事实表(FixedFact_MES)中添加记录
                        WriteLog.Instance.Write("保存主事实", strProcedureName);
                        partitionPolicy = Int64.Parse(DateTime.Now.Year.ToString() +
                            (100000000L + communityID).ToString().Substring(1, 8) + "0006");

                        #region 准备需要保存的数据
                        FixedFact_MES fixedFactMES = new FixedFact_MES()
                        {
                            FactID = factID,
                            PartitioningKey = partitionPolicy,
                            TransactNo = transactNo,
                            IsFixed = 1,
                            OpID = 6,
                            OpType = wip.InspectingStatus,
                            BusinessDate = confirmTime,
                            Code01 = wipInspecting.MainWIPIDCode.T102Code,
                            Code02 = wipInspecting.MainWIPIDCode.T120Code,
                            Code03 = wipInspecting.MainWIPIDCode.T107Code,
                            Code04 = wipInspecting.MainWIPIDCode.T126Code,
                            Code05 = wipInspecting.MainWIPIDCode.T1Code,
                            Code06 = wipInspecting.MainWIPIDCode.T134Code,
                            Code07 = wipInspecting.MainWIPIDCode.T181Code,
                            Code08 = wipInspecting.MainWIPIDCode.T1002Code,
                            Leaf01 = wipInspecting.MainWIPIDCode.T102Leaf,
                            Leaf02 = wipInspecting.MainWIPIDCode.T120Leaf,
                            Leaf03 = wipInspecting.MainWIPIDCode.T107Leaf,
                            Leaf04 = wipInspecting.MainWIPIDCode.T126Leaf,
                            Leaf05 = wipInspecting.MainWIPIDCode.T1Leaf,
                            Leaf06 = wipInspecting.MainWIPIDCode.T134Leaf,
                            Leaf07 = wipInspecting.MainWIPIDCode.T181Leaf,
                            Leaf08 = wipInspecting.MainWIPIDCode.T1002Leaf,
                        };

                        fixedFactMES.AChecksum = 0;
                        fixedFactMES.CorrelationID = 0;
                        fixedFactMES.Metric01 = 1;     // 此处应该由前台传入
                        fixedFactMES.Metric02 = passByTimes;
                        fixedFactMES.Metric03 = 1;

                        fixedFactMES.Metric04 = Int64.Parse((confirmTime -
                            wipInspecting.MainWIPIDCode.MoveInTime).TotalMilliseconds.ToString()) /
                            wipInspecting.MainWIPIDCode.NumOfSubWIPs;
                        fixedFactMES.Metric05 = fixedFactMES.Metric04 + fixedFactMES.Metric02;
                        fixedFactMES.Metric06 = fixedFactMES.Metric04 + fixedFactMES.Metric03;
                        fixedFactMES.Metric07 = stdcycleTimeOfOperation;
                        fixedFactMES.Metric08 = TimeParser.LocalTimeToUnix(confirmTime);
                        fixedFactMES.Metric09 = (long)(wipInspecting.ScanTime -
                            wipInspecting.MainWIPIDCode.MoveInTime).TotalMilliseconds;
                        fixedFactMES.Metric10 = unscheduledPDTofAWorkUnit;
                        fixedFactMES.BChecksum = 0;
                        fixedFactMES.MeasurementID = 0;
                        fixedFactMES.WFInstanceID = wipInspecting.MainWIPIDCode.PWONo;
                        fixedFactMES.Remark = functionName;
                        fixedFactMES.LinkedFactID = 0;
                        #endregion

                        #region 添加记录
                        try
                        {
                            conn.Insert(fixedFactMES);
                        }
                        catch (Exception error)
                        {
                            errCode = 99002;
                            errText = string.Format("保存主事实表失败：{0}", error.Message);
                            WriteLog.Instance.Write(errText, strProcedureName);
                            WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                            conn.RollBack();

                            return Json(errCode);
                        }
                        #endregion
                        WriteLog.Instance.Write("主事实保存完成", strProcedureName);
                        #endregion
                    }

                    if (NeedRepair(wipInspecting))
                    {
                        #region 调整路由送修(IRAPMES..usp_MarkNGWIP)
                        {
                            WriteLog.Instance.Write("调整路由送修", strProcedureName);
                            WIP wip = new WIP();
                            try
                            {
                                IRAPJsonResult rlt = wip.usp_MarkNGWIP(
                                    communityID,
                                    productLeaf,
                                    wipInspecting.MainWIPIDCode.WIPCode,
                                    wipInspecting.MainWIPIDCode.LotNumber,
                                    containerNo,
                                    wipInspecting.MainWIPIDCode.PWONo,
                                    wipInspecting.MainWIPIDCode.QCStatus,
                                    workUnitLeaf,
                                    0,
                                    sysLogID,
                                    out errCode,
                                    out errText);
                                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText),
                                    strProcedureName);
                                if (errCode != 0)
                                {
                                    conn.RollBack();
                                    return Json(errCode);
                                }
                            }
                            catch (Exception error)
                            {
                                errCode = 99003;
                                errText = string.Format("调用 usp_MarkNGWIP 失败：{0}", error.Message);
                                WriteLog.Instance.Write(errText, strProcedureName);
                                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                                conn.RollBack();

                                return Json(errCode);
                            }
                            WriteLog.Instance.Write("路由送修调整完毕", strProcedureName);
                        }
                        #endregion
                    }
                    else
                    {
                        #region 调整路由(IRAPMES..usp_WIPForward)
                        {
                            WriteLog.Instance.Write("调整路由", strProcedureName);
                            WIP wip = new WIP();
                            try
                            {
                                IRAPJsonResult rlt = wip.usp_WIPForward(
                                    communityID,
                                    productLeaf,
                                    wipInspecting.MainWIPIDCode.WIPPattern,
                                    wipInspecting.MainWIPIDCode.LotNumber,
                                    containerNo,
                                    wipInspecting.MainWIPIDCode.PWONo,
                                    wipInspecting.MainWIPIDCode.QCStatus,
                                    workUnitLeaf,
                                    0,
                                    sysLogID,
                                    out errCode,
                                    out errText);
                                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText),
                                    strProcedureName);
                                if (errCode != 0)
                                {
                                    conn.RollBack();

                                    return Json(errCode);
                                }
                            }
                            catch (Exception error)
                            {
                                errCode = 99003;
                                errText = string.Format("调用 usp_WIPForward 失败：{0}", error.Message);
                                WriteLog.Instance.Write(errText, strProcedureName);
                                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                                conn.RollBack();

                                return Json(errCode);
                            }
                            WriteLog.Instance.Write("路由调整完成", strProcedureName);
                        }
                        #endregion
                    }

                    #region 更新工位的第二个瞬态属性(IRAPMDM..stb060)
                    {
                        WriteLog.Instance.Write("更新工位第二个瞬态属性", strProcedureName);
                        int partitioningKey = Int32.Parse(communityID.ToString() + "0107");
                        List<IDataParameter> paramList = new List<IDataParameter>();
                        paramList.Add(new IRAPProcParameter("@Statistic02", DbType.Int64, TimeParser.LocalTimeToUnix(confirmTime)));
                        paramList.Add(new IRAPProcParameter("@PartitioningKey", DbType.Int64, partitioningKey));
                        paramList.Add(new IRAPProcParameter("@T107EntityID", DbType.Int32, t107EntityID));
                        try
                        {
                            conn.Update("UPDATE IRAPMDM..stb060 SET Statistic02 = @Statistic02 " +
                                "WHERE PartitioningKey = @PartitioningKey AND EntityID = @T107EntityID",
                                paramList);
                        }
                        catch (Exception error)
                        {
                            errCode = 99004;
                            errText = string.Format("更新工位(IRAPMDM..stb060)的第二个瞬态属性失败：{0}", error.Message);
                            WriteLog.Instance.Write(errText, strProcedureName);
                            WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                            conn.RollBack();

                            return Json(errCode);
                        }
                        WriteLog.Instance.Write("工位第二个瞬态属性更新完成", strProcedureName);
                    }
                    #endregion

                    #region 交易复核(IRAPMES..stb010)
                    {
                        WriteLog.Instance.Write("交易复核", strProcedureName);
                        long partitionPolicy = Int64.Parse(confirmTime.Year.ToString() +
                            (100000000L + communityID).ToString().Substring(1, 8));
                        List<IDataParameter> paramList = new List<IDataParameter>();
                        paramList.Add(new IRAPProcParameter("@OkayTime", DbType.DateTime2, confirmTime));
                        paramList.Add(new IRAPProcParameter("@AgencyLeaf2", DbType.Int32, agencyLeaf));
                        paramList.Add(new IRAPProcParameter("@Checked", DbType.String, userCode));
                        paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                        paramList.Add(new IRAPProcParameter("@PartitionPolicy", DbType.Int64, partitionPolicy));
                        try
                        {
                            conn.Update("UPDATE IRAPMES..stb010 SET OkayTime = @OkayTime, " +
                                "AgencyLeaf2 = @AgencyLeaf2, Checked = @Checked, " +
                                "Status = 5 WHERE TransactNo = @TransactNo AND " +
                                "PartitionPolicy = @PartitionPolicy",
                                paramList);
                        }
                        catch (Exception error)
                        {
                            errCode = 99004;
                            errText = string.Format("交易复核(IRAPMES..stb010)失败：{0}", error.Message);
                            WriteLog.Instance.Write(errText, strProcedureName);
                            WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                            conn.RollBack();

                            return Json(errCode);
                        }
                        WriteLog.Instance.Write("交易复核完成", strProcedureName);
                    }
                    #endregion

                    conn.Commit();

                    errCode = 0;
                    errText = "保存成功";

                    return Json(errCode);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="factID"></param>
        /// <param name="t102LeafID"></param>
        /// <param name="t107LeafID"></param>
        /// <param name="batchNumber"></param>
        /// <param name="lotNumber"></param>
        /// <param name="pwoNo"></param>
        /// <param name="qcStatus"></param>
        /// <param name="rsFactXML"></param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult usp_SaveFact_BatchManualInspecting(
            int communityID,
            long factID,
            int t102LeafID,
            int t107LeafID,
            string batchNumber,
            string lotNumber,
            string pwoNo,
            int qcStatus,
            string rsFactXML,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            throw new NotImplementedException();
        }
    }
}