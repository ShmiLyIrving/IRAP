using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Data;

using IRAP.Global;

namespace IRAP.WCF.Client.Method
{
    public class IRAPUTSClient
    {
        private static IRAPUTSClient _instance = null;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IRAPUTSClient()
        {
        }

        public static IRAPUTSClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPUTSClient();
                return _instance;
            }
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
        /// <param name="sequenceNo">申请到的第一个序列值</param>
        public void ssp_GetSequenceNo(
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

            sequenceNo = 0;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("sequenceCode", sequenceCode);
                    hashParams.Add("count", count);
                    hashParams.Add("sysLogID", sysLogID);
                    hashParams.Add("opNode", opNode);
                    hashParams.Add("voucherNo", voucherNo);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ssp_GetSequenceNo，输入参数：" +
                            "CommunityID={0}|SequenceCode={1}|Count={2}|SysLogID={3}|" +
                            "OpNode={4}|VoucherNo={5}",
                            communityID, sequenceCode, count, sysLogID, opNode, voucherNo),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.UTS.dll",
                        "IRAP.BL.UTS.IRAPUTS",
                        "ssp_GetSequenceNo",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    if (errCode == 0)
                    {
                        if (rlt is Hashtable)
                        {
                            Hashtable rltHash = (Hashtable)rlt;
                            try
                            {
                                HashtableTools.Instance.GetValue(rltHash, "SequenceNo", out sequenceNo);
                            }
                            catch (Exception error)
                            {
                                errCode = -1003;
                                errText = error.Message;
                                WriteLog.Instance.Write(errText, strProcedureName);
                                return;
                            }
                        }
                        else
                        {
                            errCode = -1002;
                            errText = "应用服务 ssp_GetSequenceNo 返回的不是 Hashtable！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                    }
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

        /// <summary>
        /// 申请交易号
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="numToApply">申请交易号的个数</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="opNode">业务操作节点列表</param>
        /// <returns></returns>
        public long mfn_GetTransactNo(
            int communityID,
            int numToApply,
            long sysLogID,
            string opNode)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (numToApply <= 0)
            {
                return 0;
            }

            try
            {
                int errCode = 0;
                string errText = "";
                long rlt = 0;

                ssp_GetSequenceNo(
                    communityID,
                    "NextTransactNo", 
                    numToApply, 
                    sysLogID, 
                    opNode, 
                    "",
                    ref rlt,
                    out errCode,
                    out errText);
                return rlt;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                throw error;
            }
        }

        /// <summary>
        /// 申请事实编号
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="numToApply">申请交易号的个数</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="opNode">业务操作节点列表</param>
        /// <returns></returns>
        public long mfn_GetFactID(
            int communityID,
            int numToApply,
            long sysLogID,
            string opNode)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (numToApply <= 0)
            {
                return 0;
            }

            try
            {
                int errCode = 0;
                string errText = "";
                long rlt = 0;

                ssp_GetSequenceNo(
                    communityID,
                    "NextFactNo",
                    numToApply,
                    sysLogID,
                    opNode,
                    "",
                    ref rlt,
                    out errCode,
                    out errText);
                return rlt;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                throw error;
            }
        }

        /// <summary>
        /// 保存万能表单采集的数据
        /// </summary>
        public void ssp_OLTP_UDFForm(
            int communityID,
            long transactNo,
            long factID,
            int ctrlParameter1,
            int ctrlParameter2,
            int ctrlParameter3,
            long sysLogID,
            string strParameter1,
            string strParameter2,
            string strParameter3,
            string strParameter4,
            string strParameter5,
            string strParameter6,
            string strParameter7,
            string strParameter8,
            ref string outputStr,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            outputStr = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("transactNo", transactNo);
                    hashParams.Add("factID", factID);
                    hashParams.Add("ctrlParameter1", ctrlParameter1);
                    hashParams.Add("ctrlParameter2", ctrlParameter2);
                    hashParams.Add("ctrlParameter3", ctrlParameter3);
                    hashParams.Add("sysLogID", sysLogID);
                    hashParams.Add("strParameter1", strParameter1);
                    hashParams.Add("strParameter2", strParameter2);
                    hashParams.Add("strParameter3", strParameter3);
                    hashParams.Add("strParameter4", strParameter4);
                    hashParams.Add("strParameter5", strParameter5);
                    hashParams.Add("strParameter6", strParameter6);
                    hashParams.Add("strParameter7", strParameter7);
                    hashParams.Add("strParameter8", strParameter8);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ssp_GetSequenceNo，输入参数：" +
                            "CommunityID={0}|TransactNo={1}|FactID={2}|CtrlParameter1={3}|" +
                            "CtrlParameter2={4}|CtrlParameter3={5}|SysLogID={6}|"+
                            "StrParameter1={7}|StrParameter2={8}|StrParameter3={9}|" +
                            "StrParameter4={10}|StrParameter5={11}|StrParameter6={12}|" +
                            "StrParameter7={13}|StrParameter8={14}",
                            communityID, transactNo, factID, ctrlParameter1, ctrlParameter2,
                            ctrlParameter3, sysLogID, strParameter1, strParameter2, 
                            strParameter3, strParameter4, strParameter5, strParameter6, 
                            strParameter7, strParameter8),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.UTS.dll",
                        "IRAP.BL.UTS.IRAPUTS",
                        "ssp_OLTP_UDFForm",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    if (errCode == 0)
                    {
                        if (rlt is Hashtable)
                        {
                            Hashtable rltHash = (Hashtable)rlt;
                            try
                            {
                                HashtableTools.Instance.GetValue(rltHash, "OutputStr", out outputStr);
                            }
                            catch (Exception error)
                            {
                                errCode = -1003;
                                errText = error.Message;
                                WriteLog.Instance.Write(errText, strProcedureName);
                                return;
                            }
                        }
                        else
                        {
                            errCode = -1002;
                            errText = "应用服务 ssp_OLTP_UDFForm 返回的不是 Hashtable！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                    }
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

        /// <summary>
        /// 校验输入的内容是否正确
        /// </summary>
        public bool ufn_OLTP_StringValid(
            string menuParameters, 
            int processLeaf, 
            int workUnitLeaf, 
            string inputValue, 
            string opNode, 
            string tvCtrlParameters, 
            int tabOrderID, 
            long sysLogID, 
            out int errCode, 
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
               className,
               MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("menuParameters", menuParameters);
                hashParams.Add("processLeaf", processLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("inputValue", inputValue);
                hashParams.Add("opNode", opNode);
                hashParams.Add("tvCtrlParameters", tvCtrlParameters);
                hashParams.Add("tabOrderID", tabOrderID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_OLTP_{0}，输入参数：" +
                        "ProcessLeaf={1}|WorkUnitLeaf={2}|InputStr={3}|" +
                        "OpNodes={4}|TVCtrlParameters={5}|TabOrderID={6}|" +
                        "SysLogID={7}",
                        menuParameters, processLeaf, workUnitLeaf, inputValue,
                        opNode, tvCtrlParameters, tabOrderID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.UTS.dll",
                        "IRAP.BL.UTS.IRAPPDC",
                        "ufn_OLTP_StringValid",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    return errCode == 0;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                return false;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据 SQL 语句获取结果集(DataTable)
        /// </summary>
        /// <param name="sqlCmd">SQL 语句</param>
        public void GetDataTableWithSQL(
            string sqlCmd,
            ref DataTable dataTable,
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
                    WriteLog.Instance.Write(
                        string.Format("执行 SQL 语句：[{0}]", sqlCmd),
                        strProcedureName);
                    #region 将函数调用参数加入 HashTable 中
                    Hashtable hashParams = new Hashtable();
                    hashParams.Add("sqlCmd", sqlCmd);
                    #endregion

                    object d1 = client.WCFRESTFul("IRAP.BL.UTS.dll",
                        "IRAP.BL.UTS.IRAPPDC",
                        "GetDataTableWithSQL",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    if (errCode == 0)
                        dataTable = d1 as DataTable;
                    else
                        dataTable.Clear();
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