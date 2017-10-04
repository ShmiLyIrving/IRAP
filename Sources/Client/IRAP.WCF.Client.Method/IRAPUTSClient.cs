using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Data;

using IRAP.Global;
using IRAP.Entities.UTS;

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
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
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
                using (WCFClient client = new WCFClient())
                {
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
        /// 申请序列号
        /// ⒈ 申请预定义序列的一个或多个序列号；
        /// ⒉ 如果序列是交易号的，自动写交易日志。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sequenceCode">序列代码</param>
        /// <param name="count">申请序列值个数</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="sequenceNo">申请到的第一个序列值</param>
        public void msp_GetSequenceNo(
            int communityID,
            string sequenceCode,
            int count,
            long sysLogID,
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
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("sequenceCode", sequenceCode);
                hashParams.Add("count", count);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 msp_GetSequenceNo，输入参数：" +
                        "CommunityID={0}|SequenceCode={1}|Count={2}|SysLogID={3}",
                        communityID, sequenceCode, count, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.UTS.dll",
                        "IRAP.BL.UTS.IRAPUTS",
                        "msp_GetSequenceNo",
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
                        sequenceNo = (long)rlt;
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
            ref string errText)
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
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
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
                hashParams.Add("errMessage", errText);
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 ssp_OLTP_UDFForm，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|CtrlParameter1={3}|" +
                        "CtrlParameter2={4}|CtrlParameter3={5}|SysLogID={6}|" +
                        "StrParameter1={7}|StrParameter2={8}|StrParameter3={9}|" +
                        "StrParameter4={10}|StrParameter5={11}|StrParameter6={12}|" +
                        "StrParameter7={13}|StrParameter8={14}|ErrText={15}",
                        communityID, transactNo, factID, ctrlParameter1, ctrlParameter2,
                        ctrlParameter3, sysLogID, strParameter1, strParameter2,
                        strParameter3, strParameter4, strParameter5, strParameter6,
                        strParameter7, strParameter8, errText),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
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
        /// 万能表单统一防错入口
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="ctrlParameter1">个性功能号</param>
        /// <param name="ctrlParameter2">选项一标识</param>
        /// <param name="ctrlParameter3">选项二标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="strParameter1">字串参数1</param>
        /// <param name="strParameter2">字串参数2</param>
        /// <param name="strParameter3">字串参数3</param>
        /// <param name="strParameter4">字串参数4</param>
        /// <param name="strParameter5">字串参数5</param>
        /// <param name="strParameter6">字串参数6</param>
        /// <param name="strParameter7">字串参数7</param>
        /// <param name="strParameter8">字串参数8</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void ssp_PokaYoke_UDFForm(
            int communityID,
            int ctrlParameter1,
            ref int ctrlParameter2,
            ref int ctrlParameter3,
            long sysLogID,
            ref string strParameter1,
            ref string strParameter2,
            ref string strParameter3,
            ref string strParameter4,
            ref string strParameter5,
            ref string strParameter6,
            ref string strParameter7,
            ref string strParameter8,
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
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
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
                        "执行存储过程 ssp_PokaYoke_UDFForm，输入参数：" +
                        "CommunityID={0}|CtrlParameter1={1}|" +
                        "CtrlParameter2={2}|CtrlParameter3={3}|SysLogID={4}|" +
                        "StrParameter1={5}|StrParameter2={6}|StrParameter3={7}|" +
                        "StrParameter4={8}|StrParameter5={9}|StrParameter6={10}|" +
                        "StrParameter7={11}|StrParameter8={12}",
                        communityID, ctrlParameter1, ctrlParameter2,
                        ctrlParameter3, sysLogID, strParameter1, strParameter2,
                        strParameter3, strParameter4, strParameter5, strParameter6,
                        strParameter7, strParameter8),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.UTS.dll",
                        "IRAP.BL.UTS.IRAPUTS",
                        "ssp_PokaYoke_UDFForm",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (rlt is Hashtable)
                    {
                        Hashtable rltHash = (Hashtable)rlt;
                        try
                        {
                            HashtableTools.Instance.GetValue(rltHash, "CtrlParameter2", out ctrlParameter2);
                            HashtableTools.Instance.GetValue(rltHash, "CtrlParameter3", out ctrlParameter3);
                            HashtableTools.Instance.GetValue(rltHash, "StrParameter1", out strParameter1);
                            HashtableTools.Instance.GetValue(rltHash, "StrParameter2", out strParameter2);
                            HashtableTools.Instance.GetValue(rltHash, "StrParameter3", out strParameter3);
                            HashtableTools.Instance.GetValue(rltHash, "StrParameter4", out strParameter4);
                            HashtableTools.Instance.GetValue(rltHash, "StrParameter5", out strParameter5);
                            HashtableTools.Instance.GetValue(rltHash, "StrParameter6", out strParameter6);
                            HashtableTools.Instance.GetValue(rltHash, "StrParameter7", out strParameter7);
                            HashtableTools.Instance.GetValue(rltHash, "StrParameter8", out strParameter8);
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
                        errText = "应用服务 ssp_PokaYoke_UDFForm 返回的不是 Hashtable！";
                        WriteLog.Instance.Write(errText, strProcedureName);
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
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("sqlCmd", sqlCmd);
                WriteLog.Instance.Write(
                    string.Format("执行 SQL 语句：[{0}]", sqlCmd),
                    strProcedureName);
                #endregion

                #region 执行存储过程或函数
                using (WCFClient client = new WCFClient())
                {
                    object d1 = client.WCFRESTFul(
                        "IRAP.BL.UTS.dll",
                        "IRAP.BL.UTS.IRAPPDC",
                        "GetDataTableWithSQL",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText), 
                        strProcedureName);

                    if (errCode == 0)
                        dataTable = d1 as DataTable;
                    else
                        dataTable.Clear();
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
        /// 获取业务操作类型清单
        /// </summary>
        public void sfn_OperTypes(
            int opID,
            int languageID,
            ref List<OperTypeInfo> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("opID", opID);
                hashParams.Add("languageID", languageID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_OperTypes，输入参数：" +
                        "OpID={0}|LanguageID={1}",
                        opID,
                        languageID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.UTS.dll",
                        "IRAP.BL.UTS.IRAPUTS",
                        "sfn_OperTypes",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<OperTypeInfo>;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 复核交易
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">待复核的交易号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ssp_CheckTransaction(
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
                #region 将函数参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("transactNo", transactNo);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 ssp_CheckTransaction，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|SysLogID={3}",
                        communityID, transactNo, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.UTS.dll",
                        "IRAP.BL.UTS.IRAPUTS",
                        "ssp_CheckTransaction",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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
    }
}