using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

using IRAP.Global;
using IRAP.Entity.SSO;

namespace IRAP.WCF.Client.Method
{
    public class IRAPSystemClient
    {
        private static IRAPSystemClient _instance = null;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public static IRAPSystemClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPSystemClient();
                return _instance;
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="systemID">系统标识</param>
        /// <param name="sysLogID">系统登录标识或者菜单缓冲区标识的相反数</param>
        /// <param name="progLanguageID">编程语言标识</param>
        /// <param name="availableOnly">是否仅呈现可用菜单</param>
        public void sfn_AvailableCSFunctions(int communityID, int systemID, long sysLogID, int progLanguageID, bool availableOnly, ref List<SystemMenuInfoButtonStyle> buttons, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        public void sfn_AvailableSystems(int communityID, long sysLogID, int progLanguageID, ref List<SystemInfo> subSystems, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取子系统自动运行的功能标识号
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="systemID">子系统标识号</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="defaultFunctionID">自动运行的功能标识号</param>
        public void sfn_DefaultFunctionTuRun(int communityID, int systemID, long sysLogID, ref int defaultFunctionID, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取社区级全局字串型参数清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="languageID">语言标识（0-英文；30-简体中文；28-繁体中文）</param>
        /// <param name="filterParamIDs">需要获取的参数 ID 列表</param>
        public void sfn_IRAPStrParameters(int communityID, int languageID, string filterParamIDs, ref List<StrParamInfo> strParams, out int errCode, out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                strParams.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("languageID", languageID);
                hashParams.Add("filterParamIDs", filterParamIDs);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_IRAPStrParameters，输入参数：" +
                        "CommunityID={0}|LanguageID={1}|FilterParamIDs={2}",
                        communityID, languageID, filterParamIDs),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPSystem",
                        "sfn_IRAPStrParameters",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        strParams = rlt as List<StrParamInfo>;
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
        /// 获取工艺流程或工作流程清单
        /// </summary>
        public void ufn_GetKanban_Processes(int communityID, long sysLogID, ref List<ProcessInfo> datas, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据输入参数描述的属性，记录运行的功能
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="menuItemID">点中的菜单项</param>
        /// <param name="scenarioIndex">应用情境</param>
        /// <param name="refreshGUIOptions">是否刷新界面选项</param>
        public void ssp_RunAFunction(int communityID, long sysLogID, int menuItemID, out int scenarioIndex, out bool refreshGUIOptions, out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            scenarioIndex = 0;
            refreshGUIOptions = false;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("sysLogID", sysLogID);
                    hashParams.Add("menuItemID", menuItemID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ssp_RunAFunction，输入参数：" +
                            "CommunityID={0}|SysLogID={1}|MenuItemID={2}",
                            communityID, sysLogID, menuItemID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPSystem",
                        "ssp_RunAFunction",
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
                                HashtableTools.Instance.GetValue(rltHash, "ScenarioIndex", out scenarioIndex);
                                HashtableTools.Instance.GetValue(rltHash, "RefreshGUIOptions", out refreshGUIOptions);
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
                            errText = "应用服务 ssp_RunAFunction 返回的不是 Hashtable！";
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
    }
}