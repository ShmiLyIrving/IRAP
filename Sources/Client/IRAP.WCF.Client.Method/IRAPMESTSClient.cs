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
        /// <param name="pwoNo">生产工单号</param>
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
            out string pwoNo,
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

            pwoNo = "";
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
                                HashtableTools.Instance.GetValue(rltHash, "PWONo", out pwoNo);
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
                                        "NumTestChannels={6}|PWONo={7}",
                                        productLeaf, wipPattern, srcT107LeafID, srcT216LeafID,
                                        rsFactPK, linkedFactID, numTestChannels, pwoNo),
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
        /// <param name="rsFactPK">行集事实分区键</param>
        /// <param name="qcFactID">检查或测试事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_FailuresOfNGProduct(
            int communityID,
            int t102LeafID,
            int t107LeafID_Src,
            string wipIDCode,
            long rsFactPK,
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
                hashParams.Add("rsFactPK", rsFactPK);
                hashParams.Add("qcFactID", qcFactID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 ufn_GetList_FailuresOfNGProduct，" +
                        "参数：CommunityID={0}|T102LeafID={1}|T107LeafID_Src={2}|" +
                        "WIPIDCode={3}|RSFactPK={4}|QCFactID={5}|SysLogID={6}",
                        communityID, t102LeafID, t107LeafID_Src, wipIDCode,
                        rsFactPK, qcFactID, sysLogID),
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
        /// <param name="t107LeafID_TS">维修站位叶标识</param>
        /// <param name="t107LeafID_Src">来源工位</param>
        /// <param name="t119LeafList">维修模式叶标识列表</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_QCOperationsForNG(
            int communityID,
            int t102LeafID,
            int t107LeafID_TS,
            int t107LeafID_Src,
            string t119LeafList,
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
                hashParams.Add("t107LeafID_TS", t107LeafID_TS);
                hashParams.Add("t107LeafID_Src", t107LeafID_Src);
                hashParams.Add("t119LeafList", t119LeafList);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_QCOperationsForNG，输入参数：" +
                        "CommunityID={0}|T102LeafID={1}|T107LeafID_TS={2}|"+
                        "T107LeafID_Src={3}|T119LeafList={4}|SysLogID={5}",
                        communityID,
                        t102LeafID,
                        t107LeafID_TS,
                        t107LeafID_Src,
                        t119LeafList,
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
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t216Code">工序代码</param>
        /// <param name="destT216LeafID">修复转出目前工序</param>
        /// <param name="subWIPIDCodes">在制品维修内容清单</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SaveFact_TroubleShooting(
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
                    hashParams.Add("t216LeafID", t216LeafID);
                    hashParams.Add("t216Code", t216Code);
                    hashParams.Add("destT216LeafID", destT216LeafID);
                    hashParams.Add("subWIPIDCodes", subWIPIDCodes);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_TroubleShooting，输入参数：" +
                            "CommunityID={0}|UserCode={1}|ProductLeaf={2}|"+
                            "WorkUnitLeaf={3}T216LeafID={4}|T216Code={5}"+
                            "|DestT216LeafID={6}|SubWIPIDCodes.Count={7}|"+
                            "SysLogID={8}",
                            communityID, userCode, productLeaf, workUnitLeaf, 
                            t216LeafID, t216Code, destT216LeafID, subWIPIDCodes.Count, 
                            sysLogID),
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

        /// <summary>
        /// 获取维修物料超市先进先出物料的SKUID
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID_TS">维修工位叶标识</param>
        /// <param name="t101LeafID">物料叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetFIFOSKUIDinTSSite(
            int communityID,
            int t107LeafID_TS,
            int t101LeafID,
            long sysLogID,
            ref string skuID,
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
                hashParams.Add("communityID", communityID);
                hashParams.Add("t107LeafID_TS", t107LeafID_TS);
                hashParams.Add("t101LeafID", t101LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetFIFOSKUIDinTSSite，输入参数：" +
                        "CommunityID={0}|T107LeafID_TS={1}|"+
                        "T101LeafID={2}|SysLogID={3}",
                        communityID,
                        t107LeafID_TS,
                        t101LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "ufn_GetFIFOSKUIDinTSSite",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}，SKUID={2}",
                            errCode,
                            errText,
                            (string)rlt),
                        strProcedureName);

                    if (errCode == 0)
                        skuID = (string)rlt;
                    else
                        skuID = "";
                }
                #endregion
            }
            catch (Exception error)
            {
                skuID = "";
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
        /// 根据器件位号或物料代码获取追溯标签序列号
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="wipCode">在制品主标识代码</param>
        /// <param name="t110LeafID">器件位置叶标识</param>
        /// <param name="t101LeafID">原辅材料叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetMaterialSKUIDBySymbol(
            int communityID,
            string wipCode,
            int t110LeafID,
            int t101LeafID,
            long sysLogID,
            ref string skuID,
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
                hashParams.Add("communityID", communityID);
                hashParams.Add("wipCode", wipCode);
                hashParams.Add("t110LeafID", t110LeafID);
                hashParams.Add("t101LeafID", t101LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetMaterialSKUIDBySymbol，输入参数：" +
                        "CommunityID={0}|WIPCode={1}|T110LeafID={2}|" +
                        "T101LeafID={3}|SysLogID={4}",
                        communityID,
                        wipCode,
                        t110LeafID,
                        t101LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.TroubleShooting",
                        "ufn_GetMaterialSKUIDBySymbol",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}，SKUID={2}",
                            errCode,
                            errText,
                            (string)rlt),
                        strProcedureName);

                    if (errCode == 0)
                        skuID = (string)rlt;
                    else
                        skuID = "";
                }
                #endregion
            }
            catch (Exception error)
            {
                skuID = "";
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
    }
}