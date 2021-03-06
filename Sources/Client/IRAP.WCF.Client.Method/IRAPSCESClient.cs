﻿using System;
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

        /// <summary>
        /// 获取待配送到指定目标仓储地址的制造订单列表
        /// </summary>
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
        /// 获取待配送到指定目标仓储地址的制造订单列表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="dstT173LeafID">目标仓储地点叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="orderFactID">工单 FactID（0:-全部工单）</param>
        public void ufn_GetList_ProductionWorkOrdersToDeliverMaterial_N(
            int communityID,
            int dstT173LeafID,
            long sysLogID,
            long orderFactID,
            ref List<ProductionWorkOrderEx> datas,
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
                        "调用 ufn_GetList_ProductionWorkOrdersToDeliverMaterial_N 函数， " +
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
                            "ufn_GetList_ProductionWorkOrdersToDeliverMaterial_N",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ProductionWorkOrderEx>;

                        if (orderFactID != 0)
                        {
                            List<ProductionWorkOrderEx> filterDatas = new List<ProductionWorkOrderEx>();
                            foreach (ProductionWorkOrderEx order in datas)
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
        /// 获取待配送到指定目标仓储地址的制造订单列表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="subMaterialCode">子项物料号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_PWOToDeliverByMaterialCode(
            int communityID,
            string subMaterialCode,
            long sysLogID,
            ref List<PWOToDeliverByMaterialCode> datas,
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
                hashParams.Add("subMaterialCode", subMaterialCode);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_PWOToDeliverByMaterialCode 函数， " +
                        "参数：CommunityID={0}|SubMaterialCode={1}|SysLogID={2}",
                        communityID,
                        subMaterialCode,
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
                            "ufn_GetList_PWOToDeliverByMaterialCode",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<PWOToDeliverByMaterialCode>;
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

        /// <summary>
        /// 根据制造订单号和制造订单行号，获取工单信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="dstT173LeafID">目标仓储地点</param>
        /// <param name="moNumber">制造订单号</param>
        /// <param name="moLineNo">制造订单行号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void mfn_GetInfo_PWOToReprint(
            int communityID,
            int dstT173LeafID,
            string moNumber,
            int moLineNo,
            long sysLogID,
            ref ReprintPWO data,
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
                data = new ReprintPWO();

                #region 将函数调用参数加入 Hashtable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("dstT173LeafID", dstT173LeafID);
                hashParams.Add("moNumber", moNumber);
                hashParams.Add("moLineNo", moLineNo);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 mfn_GetInfo_PWOToReprint，输入参数：" +
                        "CommunityID={0}|DstT173LeafID={1}|MONumber={2}|"+
                        "MOLineNo={3}|SysLogID={4}",
                        communityID, dstT173LeafID, moNumber, moLineNo, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.SCES.dll",
                            "IRAP.BL.SCES.IRAPSCES",
                            "mfn_GetInfo_PWOToReprint",
                            hashParams,
                            out errCode,
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as ReprintPWO;
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
        /// 获取指定期间指定库房工单物料配送历史记录
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t173LeafID">仓储地点叶标识</param>
        /// <param name="beginDT">开始日期时间</param>
        /// <param name="endDT">结束日期时间</param>
        public void ufn_GetFactList_RMTransferForPWO(
            int communityID,
            int t173LeafID,
            DateTime beginDT,
            DateTime endDT,
            long sysLogID,
            ref List<RMTransferForPWO> datas,
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
                hashParams.Add("t173LeafID", t173LeafID);
                hashParams.Add("beginDT", beginDT);
                hashParams.Add("endDT", endDT);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetFactList_RMTransferForPWO 函数，参数：" +
                        "CommunityID={0}|T173LeafID={1}|BeginDT={2}|"+
                        "EndDT={3}|SysLogID={4}",
                        communityID,
                        t173LeafID,
                        beginDT.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        endDT.ToString("yyyy-MM-dd HH:mm:ss.fff"),
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
                            "ufn_GetFactList_RMTransferForPWO",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<RMTransferForPWO>;
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
        /// 修改指定生产工单的配送数量
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="factID">生产工单事实编号</param>
        /// <param name="actualQtyToDeliver">配送数量</param>
        /// <param name="subTreeID">子项树标识</param>
        /// <param name="subLeafID">子项叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public void usp_SaveFact_PWODeliveryQty(
            int communityID,
            long factID,
            long actualQtyToDeliver,
            int subTreeID,
            int subLeafID,
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
                hashParams.Add("factID", factID);
                hashParams.Add("actualQtyToDeliver", actualQtyToDeliver);
                hashParams.Add("subTreeID", subTreeID);
                hashParams.Add("subLeafID", subLeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_SaveFact_PWODeliveryQty，输入参数：" +
                        "CommunityID={0}|FactID={1}|ActualQtyToDeliver={2}|"+
                        "SubTreeID={3}|SubLeafID={4}|SysLogID={5}",
                        communityID, factID, actualQtyToDeliver, subTreeID,
                        subLeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SCES.dll",
                        "IRAP.BL.SCES.IRAPSCES",
                        "usp_SaveFact_PWODeliveryQty",
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