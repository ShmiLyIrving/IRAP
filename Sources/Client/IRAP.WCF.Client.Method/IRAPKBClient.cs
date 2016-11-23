using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.Kanban;
using IRAP.Entities.Kanban;

namespace IRAP.WCF.Client.Method
{
    public class IRAPKBClient
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static IRAPKBClient _instance = null;

        private IRAPKBClient()
        {
        }

        public static IRAPKBClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPKBClient();
                return _instance;
            }
        }

        public void sfn_GetList_JumpToFunctions(
            int communityID,
            int t3LeafID,
            long sysLogID,
            ref List<JumpToFunction> functions,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                functions.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("t3LeafID", t3LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_GetList_JumpToFunctions，输入参数：" +
                        "CommunityID={0}|T3LeafID={1}|SysLogID={2}",
                        communityID,
                        t3LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.Kanban.dll",
                        "IRAP.BL.Kanban.IRAPKanban",
                        "sfn_GetList_JumpToFunctions",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        functions = rlt as List<JumpToFunction>;
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
        /// 获取可访问叶集(带名称)
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="scenarioIndex">应用情境序号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void sfn_AccessibleLeafSetEx(
            int communityID,
            int treeID,
            int scenarioIndex,
            long sysLogID,
            ref List<LeafSetEx> datas,
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
                hashParams.Add("communityID", communityID);
                hashParams.Add("treeID", treeID);
                hashParams.Add("scenarioIndex", scenarioIndex);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_AccessibleLeafSetEx，输入参数：" +
                        "CommunityID={0}|TreeID={1}|ScenarioIndex={2}|SysLogID={3}",
                        communityID,
                        treeID,
                        scenarioIndex,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.Kanban.dll",
                        "IRAP.BL.Kanban.IRAPKanban",
                        "sfn_AccessibleLeafSetEx",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<LeafSetEx>;
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
        /// 获取过滤后的子树叶集
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="nodeID">结点标识</param>
        /// <param name="filterString">过滤字符串</param>
        public void mfn_SubtreeLeaves(
            int communityID,
            int treeID,
            int nodeID,
            string filterString,
            ref List<SubTreeLeaf> datas,
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
                hashParams.Add("communityID", communityID);
                hashParams.Add("treeID", treeID);
                hashParams.Add("nodeID", nodeID);
                hashParams.Add("filterString", filterString);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 mfn_SubtreeLeaves，输入参数：" +
                        "CommunityID={0}|TreeID={1}|NodeID={2}|FilterString={3}",
                        communityID,
                        treeID,
                        nodeID,
                        filterString),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.Kanban.dll",
                        "IRAP.BL.Kanban.IRAPKanban",
                        "mfn_SubtreeLeaves",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<SubTreeLeaf>;
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
        /// 拉出比较类型列表
        /// </summary>
        public void sfn_GetList_ScopeCriterionType(
            long sysLogID,
            ref List<ScopeCriterionType> datas,
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
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_GetList_ScopeCriterionType，输入参数：" +
                        "SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.Kanban.dll",
                        "IRAP.BL.Kanban.IRAPKanban",
                        "sfn_GetList_ScopeCriterionType",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<ScopeCriterionType>;
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
        /// 获取可访问子树叶集
        /// </summary>
        public void sfn_AccessibleSubtreeLeaves(
            int communityID,
            int treeID,
            int nodeID,
            int scenarioIndex,
            long sysLogID,
            ref List<SubTreeLeaf> datas,
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
                hashParams.Add("treeID", treeID);
                hashParams.Add("nodeID", nodeID);
                hashParams.Add("scenarioIndex", scenarioIndex);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_AccessibleSubtreeLeaves，输入参数：" +
                        "CommunityID={0}|TreeID={1}|NodeID={2}|ScenarioIndex={3}|"+
                        "SysLogID={4}",
                        communityID,
                        treeID,
                        nodeID,
                        scenarioIndex,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.Kanban.dll",
                        "IRAP.BL.Kanban.IRAPKanban",
                        "sfn_AccessibleSubtreeLeaves",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<SubTreeLeaf>;
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
        /// 获取点击流选中叶集
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="clickStream">点击流</param>
        public void sfn_SelectedLeafSet(
            int communityID,
            int treeID,
            string clickStream,
            ref List<SelectedLeaf> datas,
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
                hashParams.Add("treeID", treeID);
                hashParams.Add("clickStream", clickStream);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_SelectedLeafSet，输入参数：" +
                        "CommunityID={0}|TreeID={1}|ClickStream={2}",
                        communityID,
                        treeID,
                        clickStream),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.Kanban.dll",
                        "IRAP.BL.Kanban.IRAPKanban",
                        "sfn_SelectedLeafSet",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<SelectedLeaf>;
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
        /// 获取点击流选中叶集增强版
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="treeID">树标识</param>
        /// <param name="clickStream">点击流</param>
        /// <param name="languageID">语言标识</param>
        public void sfn_SelectedLeafSetEx(
            int communityID,
            int treeID,
            string clickStream,
            int languageID,
            ref List<SelectedLeafEx> datas,
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
                hashParams.Add("treeID", treeID);
                hashParams.Add("clickStream", clickStream);
                hashParams.Add("languageID", languageID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_SelectedLeafSetEx，输入参数：" +
                        "CommunityID={0}|TreeID={1}|ClickStream={2}|"+
                        "LanguageID={3}",
                        communityID,
                        treeID,
                        clickStream,
                        languageID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.Kanban.dll",
                        "IRAP.BL.Kanban.IRAPKanban",
                        "sfn_SelectedLeafSetEx",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<SelectedLeafEx>;
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
        /// 获取指定社区的所有用户清单
        /// </summary>
        public void sfn_GetList_UsersOfACommunity(
            int communityID,
            ref List<CommunityUserInfo> datas,
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
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_GetList_UsersOfACommunity，输入参数：" +
                        "CommunityID={0}",
                        communityID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.Kanban.dll",
                        "IRAP.BL.Kanban.IRAPKanban",
                        "sfn_GetList_UsersOfACommunity",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<CommunityUserInfo>;
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
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="processLeafID">产品生产流程标识</param>
        public void ufn_GetKanban_Station_Ports(
            int communityID,
            long sysLogID,
            int processLeafID,
            ref List<StationPortInfo> datas,
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
                hashParams.Add("sysLogID", sysLogID);
                hashParams.Add("processLeafID", processLeafID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetKanban_Station_Ports 函数， " +
                        "参数：CommunityID={0}|SysLogID={1}|ProcessLeafID={2}",
                        communityID,
                        sysLogID,
                        processLeafID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.Kanban.dll",
                            "IRAP.BL.Kanban.IRAPKanban",
                            "ufn_GetKanban_Station_Ports",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<StationPortInfo>;
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
        /// 检查指定主机和指定刷新类型是否需要刷新数据
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="refreshingType">数据刷新类型</param>
        /// <param name="hostName">主机名</param>
        public void mfn_GetInfo_StationNeedRefreshed(
            int communityID, 
            string refreshingType, 
            string hostName, 
            ref bool needRefreshed, 
            out int errCode, 
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                needRefreshed = false;
 
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("refreshingType", refreshingType);
                hashParams.Add("hostName", hostName);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 mfn_GetInfo_StationNeedRefreshed，输入参数：" +
                        "CommunityID={0}|RefreshingType={1}|HostName={2}",
                        communityID,
                        refreshingType,
                        hostName),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = 
                        client.WCFRESTFul(
                            "IRAP.BL.Kanban.dll",
                            "IRAP.BL.Kanban.IRAPKanban",
                            "mfn_GetInfo_StationNeedRefreshed",
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}，NeedRefreshed={2}",
                            errCode,
                            errText,
                            (bool)rlt),
                        strProcedureName);

                    if (errCode == 0)
                        needRefreshed = (bool)rlt;
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

        public void ufn_GetList_GoToProduct(
            int communityID,
            string input,
            ref List<ProductProcessInfo> datas,
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
                hashParams.Add("input", input);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_GoToProduct，输入参数：" +
                        "CommunityID={0}|Input={1}",
                        communityID, input),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.Kanban.dll",
                        "IRAP.BL.Kanban.IRAPKanban",
                        "ufn_GetList_GoToProduct",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<ProductProcessInfo>;
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
        /// 获取有效期间类型清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="languageID">语言标识</param>
        public void sfn_GetList_ValidPeriodTypes(
            int communityID,
            int languageID,
            ref List<PeriodType> datas,
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
                hashParams.Add("languageID", languageID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_GetList_ValidPeriodTypes，输入参数：" +
                        "CommunityID={0}|LanguageID={1}",
                        communityID, languageID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.Kanban.dll",
                        "IRAP.BL.Kanban.IRAPKanban",
                        "sfn_GetList_ValidPeriodTypes",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<PeriodType>;
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
        /// 获取期间起止时间
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="periodTypeCode">期间类型代码</param>
        /// <param name="datetimeSpec">指定的日期时间点</param>
        /// <param name="periodOffset">期间偏移量</param>
        public void sfn_Period(
            int communityID,
            string periodTypeCode,
            DateTime datetimeSpec,
            int periodOffset,
            ref Period data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new Period()
                {
                    BeginDT = DateTime.Now,
                    EndDT = DateTime.Now,
                };

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("periodTypeCode", periodTypeCode);
                hashParams.Add("datetimeSpec", datetimeSpec);
                hashParams.Add("periodOffset", periodOffset);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_Period，输入参数：" +
                        "CommunityID={0}|PeriodTypeCode={1}|DatetimeSpec={2}|"+
                        "PeriodOffset={3}",
                        communityID,
                        periodTypeCode,
                        datetimeSpec,
                        periodOffset),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.Kanban.dll",
                            "IRAP.BL.Kanban.IRAPKanban",
                            "sfn_Period",
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = (Period)rlt;
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
    }
}