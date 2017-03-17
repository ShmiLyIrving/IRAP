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
    public class IRAPMESTSClient
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static IRAPMESTSClient _instance = null;

        private IRAPMESTSClient()
        {
        }

        public static IRAPMESTSClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPMESTSClient();
                return _instance;
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        public void ufn_GetKanban_FaileureSrcOperation(
            int communityID,
            long sysLogID,
            int productLeaf,
            int workUnitLeaf,
            ref List<FailureSrcOperation> datas,
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
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetKanban_FaileureSrcOperation，输入参数：" +
                        "CommunityID={0}|ProductLeaf={1}|WorkUnitLeaf={2}|SysLogID={3}",
                        communityID,
                        productLeaf,
                        workUnitLeaf,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "ufn_GetKanban_FaileureSrcOperation",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<FailureSrcOperation>;
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

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        public void ufn_GetKanban_FailureNature(
            int communityID,
            long sysLogID,
            int productLeaf,
            int workUnitLeaf,
            ref List<FailureNature> datas,
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
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetKanban_FailureNature，输入参数：" +
                        "CommunityID={0}|ProductLeaf={1}|WorkUnitLeaf={2}|SysLogID={3}",
                        communityID,
                        productLeaf,
                        workUnitLeaf,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "ufn_GetKanban_FailureNature",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<FailureNature>;
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

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        public void ufn_GetKanban_FailureDuties(
            int communityID,
            long sysLogID,
            int productLeaf,
            int workUnitLeaf,
            ref List<FailureDuty> datas,
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
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetKanban_FailureDuties，输入参数：" +
                        "CommunityID={0}|ProductLeaf={1}|WorkUnitLeaf={2}|SysLogID={3}",
                        communityID,
                        productLeaf,
                        workUnitLeaf,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "ufn_GetKanban_FailureDuties",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<FailureDuty>;
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

        /// <param name="communityID">社区标识</param>
        /// <param name="menuItemID">功能菜单标识号</param>
        /// <param name="progLanguageID">编程语言标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_TSFormCtrl(
            int communityID,
            int menuItemID,
            int progLanguageID,
            long sysLogID,
            ref List<TSFormCtrl> datas,
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
                hashParams.Add("menuItemID", menuItemID);
                hashParams.Add("progLanguageID", progLanguageID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_TSFormCtrl，输入参数：" +
                        "CommunityID={0}|MenuItemID={1}|ProgLanguageID={2}|SysLogID={3}",
                        communityID,
                        menuItemID,
                        progLanguageID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "ufn_GetList_TSFormCtrl",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<TSFormCtrl>;
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
        /// 故障维修路由防错
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="wipIDCode">在制品标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="wipPattern">在制品主标识代码样式</param>
        /// <param name="srcT107LeafID">来源工位叶标识</param>
        /// <param name="srcT216LeafID">来源工序叶标识</param>
        /// <param name="rsFactPK">检查失效或测试失败行集事实表分区键</param>
        /// <param name="linkedFactID">检查失效或测试失败事实编号</param>
        /// <param name="numTestChannels">测试通道数</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void usp_PokaYoke_TroubleShooting(
            int communityID,
            ref int productLeaf,
            int workUnitLeaf,
            string wipIDCode,
            long sysLogID,
            out string wipPattern,
            out int srcT107LeafID,
            out int srcT216LeafID,
            out long rsFactPK,
            out long linkedFactID,
            out int numTestChannels,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            wipPattern = "";
            srcT107LeafID = 0;
            srcT216LeafID = 0;
            rsFactPK = 0;
            linkedFactID = 0;
            numTestChannels = 0;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("productLeaf", productLeaf);
                    hashParams.Add("workUnitLeaf", workUnitLeaf);
                    hashParams.Add("wipIDCode", wipIDCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_PokaYoke_TroubleShooting，输入参数：" +
                            "CommunityID={0}|ProductLeaf={1}|WorkUnitLeaf={2}|" +
                            "WIPIDCode={3}|SysLogID={4}",
                            communityID, productLeaf, workUnitLeaf, wipIDCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "usp_PokaYoke_TroubleShooting",
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

                            #region 取返回值
                            try
                            {
                                HashtableTools.Instance.GetValue(rltHash, "ProductLeaf", out productLeaf);
                                HashtableTools.Instance.GetValue(rltHash, "WIPPattern", out wipPattern);
                                HashtableTools.Instance.GetValue(rltHash, "SrcT107LeafID", out srcT107LeafID);
                                HashtableTools.Instance.GetValue(rltHash, "SrcT216LeafID", out srcT216LeafID);
                                HashtableTools.Instance.GetValue(rltHash, "RSFactPK", out rsFactPK);
                                HashtableTools.Instance.GetValue(rltHash, "LinkedFactID", out linkedFactID);
                                HashtableTools.Instance.GetValue(rltHash, "NumTestChannels", out numTestChannels);
                                WriteLog.Instance.Write(
                                    string.Format(
                                        "输出参数：ProductLeaf={0}|WIPPattern={1}|SrcT107LeafID={2}|" +
                                        "SrcT216LeafID={3}|RSFactPK={4}|LinkedFactID={5}|"+
                                        "NumTestChannels={6}",
                                        productLeaf, wipPattern, srcT107LeafID, srcT216LeafID,
                                        rsFactPK, linkedFactID, numTestChannels),
                                    strProcedureName);
                            }
                            catch (Exception error)
                            {
                                errCode = -1003;
                                errText = error.Message;
                                WriteLog.Instance.Write(errText, strProcedureName);
                                return;
                            }
                            #endregion
                        }
                        else
                        {
                            errCode = -1002;
                            errText = "应用服务 usp_PokaYoke_TroubleShooting 返回的不是 Hashtable！";
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
        /// 获取子在制品标识清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="wipPattern"></param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_SubWIPIDCodes_TS(
            int communityID,
            string wipPattern,
            int productLeaf,
            int workUnitLeaf,
            long sysLogID,
            ref List<SubWIPIDCodes_TS> datas,
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
                hashParams.Add("wipPattern", wipPattern);
                hashParams.Add("productLeaf", productLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_SubWIPIDCodes_TS，输入参数：" +
                        "CommunityID={0}|WIPPattern={1}|ProductLeaf={2}|"+
                        "WorkUnitLeaf={3}|SysLogID={4}",
                        communityID,
                        wipPattern,
                        productLeaf,
                        workUnitLeaf,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "ufn_GetList_SubWIPIDCodes_TS",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<SubWIPIDCodes_TS>;
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
        /// 获取不良在制品失效情况
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID_Src">来源工位叶标识</param>
        /// <param name="wipIDCode">在制品主标识代码（个体）</param>
        /// <param name="qcFactID">检查或测试事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_FailuresOfNGProduct(
            int communityID,
            int t102LeafID,
            int t107LeafID_Src,
            string wipIDCode,
            long qcFactID,
            long sysLogID,
            ref List<FailuresOfNGProduct> datas,
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
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("t107LeafID_Src", t107LeafID_Src);
                hashParams.Add("wipIDCode", wipIDCode);
                hashParams.Add("qcFactID", qcFactID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 ufn_GetList_FailuresOfNGProduct，" +
                        "参数：CommunityID={0}|T102LeafID={1}|T107LeafID_Src={2}|" +
                        "WIPIDCode={3}|QCFactID={4}|SysLogID={5}",
                        communityID, t102LeafID, t107LeafID_Src, wipIDCode,
                        qcFactID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "ufn_GetList_FailuresOfNGProduct",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<FailuresOfNGProduct>;
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
        /// 获取送修在制品修复转出工序清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="srcT107LeafID">来源工位</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_QCOperationsForNG(
            int communityID,
            int t102LeafID,
            int srcT107LeafID,
            long sysLogID,
            ref List<QCOperationsForNG> datas,
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
                hashParams.Add("t102LeafID", t102LeafID);
                hashParams.Add("srcT107LeafID", srcT107LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_QCOperationsForNG，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|SrcT107LeafID={2}|SysLogID={3}",
                        communityID,
                        t102LeafID,
                        srcT107LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "ufn_GetList_QCOperationsForNG",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<QCOperationsForNG>;
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
        /// 保存在制品故障维修事实
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">维修人员工号</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <param name="destT216LeafID">修复转出目前工序</param>
        /// <param name="subWIPIDCodes">在制品维修内容清单</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SaveFact_TroubleShooting(
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
            try
            {
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("productLeaf", productLeaf);
                    hashParams.Add("workUnitLeaf", workUnitLeaf);
                    hashParams.Add("destT216LeafID", destT216LeafID);
                    hashParams.Add("subWIPIDCodes", subWIPIDCodes);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_TroubleShooting，输入参数：" +
                            "CommunityID={0}|UserCode={1}|ProductLeaf={2}|"+
                            "WorkUnitLeaf={3}|DestT216LeafID={4}|"+
                            "SubWIPIDCodes.Count={5}|SysLogID={6}",
                            communityID, userCode, productLeaf, workUnitLeaf, 
                            destT216LeafID, subWIPIDCodes.Count, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "usp_SaveFact_TroubleShooting",
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