using IRAP.Entities.MDM;
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
        public List<WIPStation> GetFurnaceLists(int communityID, long sysLogID, out int errCode, out string errText) {
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
                            "IRAP.BL.MDM.dll",
                            "IRAP.BL.MDM.IRAPMDM",
                            "ufn_GetList_WIPStationsOfAHost",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        var datas = rlt as List<WIPStation>; 
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
                        var datas = rlt as List<long>; 
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
        /// 获取配料信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t131LeafID">环别叶标识</param>
        /// <param name="t216LeafID">工序代码</param>
        /// <param name="batchNumber">熔炼容次号</param>
        /// <param name="sysLogID">语言标识</param>
        public List<SmeltMaterialItem> GetSmeltMaterialItems(int communityID, int t131LeafID, int t216LeafID, string batchNumber, long sysLogID,
            out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t131LeafID", t131LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_SmeltMaterialItems 函数， " +
                        "参数：CommunityID={0}|t131LeafID={1}|t216LeafID={2}|BatchNumber={3}||SysLogID={4}",
                        communityID, t131LeafID,t216LeafID,batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "ufn_GetList_SmeltMaterialItems",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
//#if DEBUG
//                        #region Debug
//                        var datas = new List<SmeltMaterialItem>();
//                        datas.Add(new SmeltMaterialItem() { Ordinal = 1, T101LeafID = 0001, T101Code = "0001", T101Name = "材料1号" });
//                        datas.Add(new SmeltMaterialItem() { Ordinal = 2, T101LeafID = 0002, T101Code = "0002", T101Name = "材料2号" });
//                        datas.Add(new SmeltMaterialItem() { Ordinal = 3, T101LeafID = 0003, T101Code = "0003", T101Name = "材料3号" });
//                        #endregion
//#else 
                        var datas = rlt as List<SmeltMaterialItem>; 
//#endif

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
        /// 获取生产开炉参数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t131LeafID">环别叶标识</param>
        /// <param name="t216LeafID">工序代码</param>
        /// <param name="batchNumber">熔炼容次号</param>
        /// <param name="sysLogID">语言标识</param>
        public List<SmeltMethodItem> GetSmeltMethodItems(int communityID, int t131LeafID, int t216LeafID, string batchNumber, long sysLogID,
            out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t131LeafID", t131LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_SmeltMethodItems 函数， " +
                        "参数：CommunityID={0}|t131LeafID={1}|t216LeafID={2}|BatchNumber={3}||SysLogID={4}",
                        communityID, t131LeafID, t216LeafID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "ufn_GetList_SmeltMethodItems",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
//#if DEBUG
//                        var datas = new List<SmeltMethodItem>();
//                        datas.Add(new SmeltMethodItem() { Ordinal = 1, T20Code="0001", T20LeafID = 0001, T20Name = "开炉时间" });
//                        datas.Add(new SmeltMethodItem() { Ordinal = 1, T20Code="0002", T20LeafID = 0002, T20Name = "电表开始度数" });
//#else
                         var datas = rlt as List<SmeltMethodItem>; 
                        
//#endif
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
        /// 生产开始
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="t131LeafID">材质</param>
        /// <param name="operatorCode">操作工代码</param>
        /// <param name="batchNumber">熔次号</param>
        /// <param name="rSFactXML">工艺参数XML</param>
        /// --<RSFact>
        ///<RF25 Ordinal=""  T102LeafID="" T216LeafID=""  WIPCode="" 
        ///LotNumber="" Texture="" PWONo="" BatchLot="" Qty="" Scale=""/> 
        ///</RSFact>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public void StartProduct(int communityID, int t216LeafID, int t107LeafID, int t131LeafID,
            string operatorCode, string batchNumber, string rSFactXML, long sysLogID, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("t131LeafID", t131LeafID);
                hashParams.Add("operatorCode", operatorCode);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("rSFactXML", rSFactXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_SmeltBatchProductionStart 函数， " +
                        "参数：CommunityID={0}|t216LeafID={1}|t107LeafID={2}|t131LeafID={3}|operatorCode={4}|batchNumber={5}|rSFactXML={6}|sysLogID={7}",
                        communityID, t216LeafID, t107LeafID, t131LeafID, operatorCode, batchNumber, rSFactXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {
//#if DEBUG
//                    errCode = 0;
//                    errText = "生产开始完成，请继续生产";
//#else
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "usp_SaveFact_SmeltBatchProductionStart",
                        hashParams,
                        out errCode,
                        out errText);

//#endif
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                }
                #endregion
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 重新加载
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID">工序叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t133LeafID">设备叶标识</param>
        /// <param name="sysLogID">语言标识</param>
        /// <returns></returns>
        public List<SmeltBatchProductionInfo> ReloadSmeltBatchProduct(int communityID, int t107LeafID, int t216LeafID, int t133LeafID,
             long sysLogID, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t133LeafID", t133LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_SmeltBatchProduct 函数， " +
                        "参数：CommunityID={0}|T107LeafID={1}||T216LeafID={2}|T133LeafID={3}|SysLogID={4}",
                        communityID, t107LeafID, t216LeafID, t133LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "ufn_GetInfo_SmeltBatchProduct",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
//#if DEBUG
//                        var datas = new List<SmeltBatchProductionInfo>();
//                        datas.Add(new SmeltBatchProductionInfo() { BatchNumber = "SD20180103003",BatchStartDate = new DateTime(2018,01,10,12,00,00),InProduction=1,
//                                                                   OperatorCode = "0000001", OperatorName = "Softland 开发人员"
//                        });
//#else


                        var datas = rlt as List<SmeltBatchProductionInfo>;
                         
//#endif
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
        /// 获取炉前光谱、浇三角试样、炉水出炉的参数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="opType">检验类型 --LQGP 炉前光谱，SSJSY 烧三角试验，LLCL 炉水出炉</param>
        /// <param name="t131LeafID">环别叶标识</param>
        /// <param name="t216LeafID">工序代码</param>
        /// <param name="batchNumber">熔炼容次号</param>
        /// <param name="sysLogID">语言标识</param>
        /// <returns></returns>
        public List<SmeltMethodItemByOpType> GetSmeltMethodItemByOpType(int communityID, string opType, int t131LeafID, int t216LeafID,
            string batchNumber, long sysLogID, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("opType", opType);
                hashParams.Add("t131LeafID", t131LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数ufn_GetList_SmeltMethodItemsByOpType," +
                        "参数：CommunityID={0}|OpType={1}|T131LeafID={2}|T216LeafID={3}|BatchNumber={4}||SysLogID={5}",
                        communityID, opType, t131LeafID, t216LeafID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "ufn_GetList_SmeltMethodItemsByOpType",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        var datas = rlt as List<SmeltMethodItemByOpType>; 
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
        /// 保存参数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="opType">检验类型 --LQGP 炉前光谱，SSJSY 烧三角试验，LLCL 炉水出炉</param>
        /// <param name="t216LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">熔次号</param>
        /// <param name="rSFactXML">工艺参数XML</param>
        /// --<RSFact>
        ///<RF25 Ordinal=""  T102LeafID="" T216LeafID=""  WIPCode="" 
        ///LotNumber="" Texture="" PWONo="" BatchLot="" Qty="" Scale=""/> 
        ///</RSFact>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public void SaveSmeltBatch(int communityID, string opType, int t216LeafID, int t107LeafID,string batchNumber, 
            string rSFactXML, long sysLogID, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("opType", opType);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("rSFactXML", rSFactXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数usp_SaveFact_SmeltBatchMethodConfirming,参数：" +
                        "CommunityID={0}|OpType={1}|T216LeafID={2}|T107LeafID={3}|BatchNumber={4}|RSFactXML={5}|SysLogID={6}",
                        communityID, opType, t216LeafID, t107LeafID, batchNumber, rSFactXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {
//#if DEBUG
//                    errCode = 0;
//                    errText = "保存成功！";
//#else
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "usp_SaveFact_SmeltBatchMethodConfirming",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);
//#endif 

                    if (errCode == 0) {
                        WriteLog.Instance.Write(errText, strProcedureName);
                        return;
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
        }

        /// <summary>
        /// 保存原材料调整
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">熔次号</param>
        /// <param name="rSFactXML">工艺参数XML</param>
        ///<RSFact> 
        ///  <RF13_1 Ordinal="" T101LeafID="" LotNumber=""  Qty=""/>
        ///  </RF13_1>
        ///</RSFact>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public void SaveSmeltBatchMaterial(int communityID, int t216LeafID, int t107LeafID,
            string batchNumber, string rSFactXML, long sysLogID, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("rSFactXML", rSFactXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数usp_SaveFact_SmeltBatchLoadingMaterial,参数：" +
                       "CommunityID={0} |T216LeafID={1}|T107LeafID={2}|BatchNumber={3}|RSFactXML={4}|SysLogID={5}",
                        communityID, t216LeafID, t107LeafID, batchNumber, rSFactXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {
//#if DEBUG
//                    errCode = 0;
//                    errText = "保存成功！";
//#else


                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "usp_SaveFact_SmeltBatchLoadingMaterial",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);
//#endif
                    if (errCode == 0) {
                        WriteLog.Instance.Write(errText, strProcedureName);
                        return;
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
        }

        /// <summary>
        /// 生产结束
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">熔次号</param> 
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public void SmeltBatchProductionEnd(int communityID, int t216LeafID, int t107LeafID,
            string batchNumber, long sysLogID, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t107LeafID", t107LeafID);
                hashParams.Add("batchNumber", batchNumber);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数usp_SaveFact_SmeltBatchProductionEnd,参数：" +
                       "CommunityID={0} |T216LeafID={1}|T107LeafID={2}|BatchNumber={3} |SysLogID={4}",
                        communityID, t216LeafID, t107LeafID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "usp_SaveFact_SmeltBatchProductionEnd",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        WriteLog.Instance.Write(errText, strProcedureName);
                        return;
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
        }

        /// <summary>
        /// 获取批次号
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t101LeafID">工序叶标识</param> 
        /// <param name="sysLogID">语言标识</param>
        /// <returns></returns>
        public List<SmeltBatchMaterial> GetSmeltBatchMaterial(int communityID, int t101LeafID, long sysLogID, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("t101LeafID", t101LeafID); 
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数ufn_GetList_SmeltBatchMaterial," +
                        "参数：CommunityID={0}|T101LeafID={1}|SysLogID={2}",
                        communityID, t101LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient()) {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.MES.dll",
                            "IRAP.BL.MES.SmeltingProduction",
                            "ufn_GetList_SmeltBatchMaterial",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0) {
                        var datas = rlt as List<SmeltBatchMaterial>;
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
