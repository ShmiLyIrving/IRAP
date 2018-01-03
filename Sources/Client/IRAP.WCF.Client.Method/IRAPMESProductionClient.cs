using IRAP.Entities.MES;
using IRAP.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IRAP.WCF.Client.Method {
    public class IRAPMESProductionClient {
        private static IRAPMESProductionClient _instance = null;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IRAPMESProductionClient() {

        }

        public static IRAPMESProductionClient Instance {
            get {
                if (_instance == null)
                    _instance = new IRAPMESProductionClient();
                return _instance;
            }
        }

        /// <summary>
        /// 获取信息站点上下文(工位或工作流结点功能信息)
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public List<ProductionParam> GetInfoContent(int communityID, long sysLogID, out int errCode,out string errText) {
            string strProcedureName =string.Format("{0}.{1}",className,MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_WIPStationsOfAHost 函数， " +
                        "参数：communityID={0}|sysLogID={1}",
                        communityID,sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "ufn_GetList_WIPStationsOfAHost",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        var datas = rlt as List<ProductionParam>;
                        if (datas == null || datas.Count == 0) {
                            errCode = 99;
                            errText = "没有找到信息站点上下文，请检查配置！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return null;
                        }
                        return datas;
                    }
                }
                #endregion
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

    }
}
