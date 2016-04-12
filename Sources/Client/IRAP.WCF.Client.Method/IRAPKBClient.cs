using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.Kanban;

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
    }
}