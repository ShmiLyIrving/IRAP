using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

using IRAP.Global;
using IRAP.Entities.SCES;

namespace IRAP.WCF.Client.Method
{
    public class IRAPSCESClient
    {
        private static IRAPSCESClient _instance = null;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IRAPSCESClient()
        {

        }

        public static IRAPSCESClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPSCESClient();
                return _instance;
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="dstT173LeafID">目标仓储地点叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="orderFactID">工单 FactID（0:-全部工单）</param>
        public void ufn_GetList_ProductionWorkOrdersToDeliverMaterial(
            int communityID,
            int dstT173LeafID,
            long sysLogID,
            long orderFactID,
            ref List<ProductionWorkOrder> datas,
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
                hashParams.Add("dstT173LeafID", dstT173LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_ProductionWorkOrdersToDeliverMaterial 函数， " +
                        "参数：CommunityID={0}|DstT173LeafID={1}|SysLogID={2}",
                        communityID,
                        dstT173LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.SCES.dll",
                            "IRAP.BL.SCES.IRAPSCES",
                            "ufn_GetList_ProductionWorkOrdersToDeliverMaterial",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ProductionWorkOrder>;

                        if (orderFactID != 0)
                        {
                            List<ProductionWorkOrder> filterDatas = new List<ProductionWorkOrder>();
                            foreach (ProductionWorkOrder order in datas)
                            {
                                if (order.FactID == orderFactID)
                                {
                                    filterDatas.Add(order.Clone());
                                    break;
                                }
                            }
                            datas = filterDatas;
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
        /// 获取工单物料配送指令单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="pwoIssuingFactID">工单签发事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_MaterialToDeliverForPWO(
            int communityID,
            long pwoIssuingFactID,
            long sysLogID,
            ref List<MaterialToDeliver> datas,
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
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_MaterialToDeliverForPWO 函数， " +
                        "参数：CommunityID={0}|PWOIssuingFactID={1}|SysLogID={2}",
                        communityID,
                        pwoIssuingFactID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.SCES.dll",
                            "IRAP.BL.SCES.IRAPSCES",
                            "ufn_GetList_MaterialToDeliverForPWO",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<MaterialToDeliver>;
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
        /// 打印生产工单流转卡，并生成工单原辅材料配送临时记录
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="pwoIssuingFactID">工单签发事实编号</param>
        /// <param name="srcT173LeafID">发料库房叶标识</param>
        /// <param name="dstT173LeafID">目标超市叶标识</param>
        /// <param name="dstT106LeafID_Recv">目标超市收料库位叶标识</param>
        /// <param name="dstT1LeafID_Recv">目标超市物料员部门叶标识</param>
        /// <param name="pickUpSheetXML">备料清单XML</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_PrintVoucher_PWOMaterialDelivery(
            int communityID,
            long transactNo,
            long pwoIssuingFactID,
            int srcT173LeafID,
            int dstT173LeafID,
            int dstT106LeafID_Recv,
            int dstT1LeafID_Recv,
            string pickUpSheetXML,
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
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("transactNo", transactNo);
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("srcT173LeafID", srcT173LeafID);
                hashParams.Add("dstT173LeafID", dstT173LeafID);
                hashParams.Add("dstT106LeafID_Recv", dstT106LeafID_Recv);
                hashParams.Add("dstT1LeafID_Recv", dstT1LeafID_Recv);
                hashParams.Add("pickUpSheetXML", pickUpSheetXML);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_PrintVoucher_PWOMaterialDelivery，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|PWOIssuingFactID={2}|SrcT173LeafID={3}|" +
                        "DstT173LeafID={4}|DstT106LeafID_Recv={5}|DstT1LeafID_Recv={6}|" +
                        "PickUpSheetXML={7}|SysLogID={8}",
                        communityID,
                        transactNo,
                        pwoIssuingFactID,
                        srcT173LeafID,
                        dstT173LeafID,
                        dstT106LeafID_Recv,
                        dstT1LeafID_Recv,
                        pickUpSheetXML,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SCES.dll",
                        "IRAP.BL.SCES.IRAPSCES",
                        "usp_PrintVoucher_PWOMaterialDelivery",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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

        public void ufn_GetList_ProductionFlowCard(
            int communityID,
            long pwoIssuingFactID,
            long sysLogID,
            ref List<ProductionFlowCard> datas,
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
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_ProductionFlowCard 函数， " +
                        "参数：CommunityID={0}|PWOIssuingFactID={1}|SysLogID={2}",
                        communityID,
                        pwoIssuingFactID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.SCES.dll",
                            "IRAP.BL.SCES.IRAPSCES",
                            "ufn_GetList_ProductionFlowCard",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ProductionFlowCard>;
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
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="materialCode">物料代码</param>
        /// <param name="customerCode">物料标签代码</param>
        /// <param name="shipToParty">发运地点</param>
        /// <param name="qtyInStore">物料计划量</param>
        /// <param name="dateCode">物料生产日期</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_PokaYoke_PallPrint(
            int communityID,
            string materialCode,
            string customerCode,
            string shipToParty,
            string qtyInStore,
            string dateCode,
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
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("materialCode", materialCode);
                hashParams.Add("customerCode", customerCode);
                hashParams.Add("shipToParty", shipToParty);
                hashParams.Add("qtyInStore", qtyInStore);
                hashParams.Add("dateCode", dateCode);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_PokaYoke_PallPrint，输入参数：" +
                        "CommunityID={0}|MaterialCode={1}|CustomerCode={2}|" +
                        "ShipToParty={3}|QtyInStore={4}|DateCode={5}|SysLogID={6}",
                        communityID, materialCode, customerCode, shipToParty,
                        qtyInStore, dateCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SCES.dll",
                        "IRAP.BL.SCES.IRAPSCES",
                        "usp_PokaYoke_PallPrint",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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
        /// 获取生产工单发料的未结配送指令清单，包括：
        /// ⒈ 已排产但尚未配送的
        /// ⒉ 已配送但尚未接收的 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="dstT173LeafID">目标仓储地点叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_UnclosedDeliveryOrdersForPWO(
            int communityID,
            int dstT173LeafID,
            long sysLogID,
            ref List<UnclosedDeliveryOrdersForPWO> datas,
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
                hashParams.Add("dstT173LeafID", dstT173LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_UnclosedDeliveryOrdersForPWO 函数， " +
                        "参数：CommunityID={0}|DstT173LeafID={1}|SysLogID={2}",
                        communityID,
                        dstT173LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.SCES.dll",
                            "IRAP.BL.SCES.IRAPSCES",
                            "ufn_GetList_UnclosedDeliveryOrdersForPWO",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<UnclosedDeliveryOrdersForPWO>;
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
        /// 生产工单配送流转卡打印后实际配送操作前撤销
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="af482PK">辅助事实分区键</param>
        /// <param name="pwoIssuingFactID">工单签发事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_UndoPrintVoucher_PWOMaterialDelivery(
            int communityID,
            long af482PK,
            long pwoIssuingFactID,
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
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("af482PK", af482PK);
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_UndoPrintVoucher_PWOMaterialDelivery，输入参数：" +
                        "CommunityID={0}|AF482PK={1}|PWOIssuingFactID={2}|" +
                        "SysLogID={3}",
                        communityID, af482PK, pwoIssuingFactID, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SCES.dll",
                        "IRAP.BL.SCES.IRAPSCES",
                        "usp_UndoPrintVoucher_PWOMaterialDelivery",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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