using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

using IRAP.Global;
using IRAP.Entities.MES;

namespace IRAP.WCF.Client.Method
{
    public class IRAPMESSmeltClient
    {
        private static IRAPMESSmeltClient _instance = null;

        public static IRAPMESSmeltClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPMESSmeltClient();
                return _instance;
            }
        }

        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IRAPMESSmeltClient() { }

        /// <summary>
        /// 重新加载
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID">工序叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t133LeafID">设备叶标识</param>
        /// <param name="sysLogID">语言标识</param>
        /// <returns></returns>
        public void ufn_GetInfo_SmeltBatchProduct(
            int communityID,
            int t107LeafID,
            int t216LeafID,
            int t133LeafID,
            long sysLogID,
            ref SmeltBatchProductionInfo data,
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
                data = null;

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t133LeafID", t133LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_SmeltBatchProduct 函数，参数：" +
                        "CommunityID={0}|T107LeafID={1}|T216LeafID={2}|" +
                        "T133LeafID={3}|SysLogID={4}",
                        communityID, t107LeafID, t216LeafID, t133LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "ufn_GetInfo_SmeltBatchProduct",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        var datas = rlt as List<SmeltBatchProductionInfo>;
                        if (datas == null || datas.Count == 0)
                        {
                            errCode = 99;
                            errText = "没有找到重新加载信息，请检查配置！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                        else
                            data = datas[0];
                    }
                }
                #endregion
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="batchNumber">熔炼容次号</param>
        /// <param name="sysLogID">语言标识</param>
        public void ufn_GetList_SmeltBatchPWONo(
            int communityID, 
            string batchNumber, 
            long sysLogID, 
            ref List<OrderInfo> datas,
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
                datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_SmeltBatchPWONo 函数，参数：" +
                        "CommunityID={0}|BatchNumber={1}||SysLogID={2}",
                        communityID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "ufn_GetList_SmeltBatchPWONo",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<OrderInfo>;
                }
                #endregion
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取当前工位正在生产的容次号
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID">工序叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t133LeafID">设备叶标识</param>
        /// <param name="planStartDate">开始生产时间</param>
        /// <param name="sysLogID">语言标识</param>
        public void ufn_GetList_WaitSmeltBatchProduction(
            int communityID, 
            int t107LeafID, 
            int t216LeafID, 
            int t133LeafID,
            string planStartDate, 
            long sysLogID, 
            ref List<WaitingSmelt> datas,
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
                datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t133LeafID", t133LeafID);
                hashParams.Add("planStartDate", planStartDate);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_WaitSmeltBatchProduction 函数，参数：" +
                        "CommunityID={0}|T107LeafID={1}|T216LeafID={2}|T133LeafID={3}|" +
                        "PlanStartDate={4}|SysLogID={5}",
                        communityID, t107LeafID, t216LeafID, t133LeafID, planStartDate, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "ufn_GetList_WaitSmeltBatchProduction",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<WaitingSmelt>;
                }
                #endregion
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 保存理化检验内容
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="factID">关联事实号（需要申请）</param>
        /// <param name="opType">保存类型代码</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">炉次号</param>
        /// <param name="lotNumber">生产批次号</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="rsFactXML">
        /// 检查结果：
        /// &lt;RSFact&gt;
        /// 	&lt;RF6_2 RowNum="" Ordinal="" T20LeafID="" LowLimit="" Criterion="" HighLimit="" UnitOfMeasure="" Metric01="" IQCReport=""/&gt;
        /// &lt;/RSFact&gt;
        /// </param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SaveFact_SmeltBatchInspecting(
            int communityID,
            long factID,
            string opType,
            int t102LeafID,
            int t107LeafID,
            string batchNumber,
            string lotNumber,
            string pwoNo,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("factID", factID);
                    hashParams.Add("opType", opType);
                    hashParams.Add("t102LeafID", t102LeafID);
                    hashParams.Add("t107LeafID", t107LeafID);
                    hashParams.Add("batchNumber", batchNumber);
                    hashParams.Add("lotNumber", lotNumber);
                    hashParams.Add("pwoNo", pwoNo);
                    hashParams.Add("rsFactXML", rsFactXML);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format("执行存储过程 usp_SaveFact_SmeltBatchInspecting，参数：" +
                            "CommunityID={0}|FactID={1}|OpType={2}|T102LeafID={3}|" +
                            "T107LeafID={4}|BatchNumber={5}|LotNumber={6}|PWONo={7}|" +
                            "RSFactXML={8}|SysLogID={9}",
                            communityID, factID, opType, t102LeafID, t107LeafID,
                            batchNumber, lotNumber, pwoNo, rsFactXML, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.SmeltingProduction",
                        "usp_SaveFact_SmeltBatchInspecting",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
