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
    }
}