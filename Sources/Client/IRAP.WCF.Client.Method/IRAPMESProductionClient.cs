using IRAP.Entities.MES;
using IRAP.Entity.UTS;
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
        public List<ProductionParam> GetFurnaceLists(int communityID, long sysLogID, out int errCode,out string errText) {
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

        /// <summary>
        /// 操作工编号校验
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="operatorCode">操作工编号</param>
        /// <returns>是否校验通过</returns>
        public bool OperatorCodeValidate(int communityID, string operatorCode, out int errCode,out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("operatorCode", operatorCode);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 LookForOperatorCode 函数， " +
                        "参数：communityID={0}|operatorCode={1}",
                        communityID, operatorCode),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "LookForOperatorCode",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        var datas = rlt as List<int>;
                        if (datas == null || datas.Count == 0) {
                            errCode = 99;
                            errText = "操作工不存在，请重新输入！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                            return false;
                        }
                        return true;
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
            return false;
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
        public List<WaitingSmelt> GetWaitingSmeilts(int communityID, int t107LeafID, int t216LeafID, int t133LeafID,
            string planStartDate, long sysLogID, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
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
                        "调用 ufn_GetList_WaitSmeltBatchProduction 函数， " +
                        "参数：CommunityID={0}|T107LeafID={1}||T216LeafID={2}|T133LeafID={3}|PlanStartDate={4}|SysLogID={5}",
                        communityID, t107LeafID,t216LeafID,t133LeafID,planStartDate,sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

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

                    if (errCode == 0) {
                        var datas = rlt as List<WaitingSmelt>;
                        if (datas == null || datas.Count == 0) {
                            errCode = 99;
                            errText = "没有找到炉次号，请检查配置！";
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

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="batchNumber">熔炼容次号</param>
        /// <param name="sysLogID">语言标识</param>
        public List<OrderInfo> GetOrderInfo(int communityID, string batchNumber, long sysLogID, out int errCode,
            out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("batchNumber", batchNumber); 
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_SmeltBatchPWONo 函数， " +
                        "参数：CommunityID={0}|BatchNumber={1}||SysLogID={2}",
                        communityID,batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

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

                    if (errCode == 0) {
                        var datas = rlt as List<OrderInfo>;
                        if (datas == null || datas.Count == 0) {
                            errCode = 99;
                            errText = "没有找到订单信息，请检查配置！";
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
