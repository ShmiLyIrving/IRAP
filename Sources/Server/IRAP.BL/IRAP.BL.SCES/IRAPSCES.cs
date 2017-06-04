using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;

using IRAP.Global;
using IRAPShared;
using IRAPORM;
using IRAP.Entities.SCES;

namespace IRAP.BL.SCES
{
    public class IRAPSCES : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPSCES()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="dstT173LeafID">目标仓储地点叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[ProductionWorkOrder]</returns>
        public IRAPJsonResult ufn_GetList_ProductionWorkOrdersToDeliverMaterial(
            int communityID,
            int dstT173LeafID,
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
                List<ProductionWorkOrder> datas = new List<ProductionWorkOrder>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@DstT173LeafID", DbType.Int32, dstT173LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPSCES..ufn_GetList_ProductionWorkOrdersToDeliverMaterial，" +
                        "参数：CommunityID={0}|DstT173LeafID={1}|SysLogID={2}",
                        communityID,
                        dstT173LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                                "SELECT * " +
                                "FROM IRAPSCES..ufn_GetList_ProductionWorkOrdersToDeliverMaterial(" +
                                "@CommunityID, @DstT173LeafID, @SysLogID) " +
                                "ORDER BY ScheduledStartTime";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<ProductionWorkOrder> lstDatas =
                            conn.CallTableFunc<ProductionWorkOrder>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPSCES..ufn_GetList_ProductionWorkOrdersToDeliverMaterial 函数发生异常：{0}",
                        error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(datas);
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
        public IRAPJsonResult ufn_GetList_MaterialToDeliverForPWO(
            int communityID, 
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
                List<MaterialToDeliver> datas = new List<MaterialToDeliver>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@PWOIssuingFactID", DbType.Int64, pwoIssuingFactID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPSCES..ufn_GetList_MaterialToDeliverForPWO，" +
                        "参数：CommunityID={0}|PWOIssuingFactID={1}|SysLogID={2}",
                        communityID,
                        pwoIssuingFactID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                                "SELECT * " +
                                "FROM IRAPSCES..ufn_GetList_MaterialToDeliverForPWO(" +
                                "@CommunityID, @PWOIssuingFactID, @SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<MaterialToDeliver> lstDatas =
                            conn.CallTableFunc<MaterialToDeliver>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPSCES..ufn_GetList_MaterialToDeliverForPWO 函数发生异常：{0}",
                        error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(datas);
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
        public IRAPJsonResult usp_PrintVoucher_PWOMaterialDelivery(
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
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@PWOIssuingFactID", DbType.Int64, pwoIssuingFactID));
                paramList.Add(new IRAPProcParameter("@SrcT173LeafID", DbType.Int32, srcT173LeafID));
                paramList.Add(new IRAPProcParameter("@DstT173LeafID", DbType.Int32, dstT173LeafID));
                paramList.Add(new IRAPProcParameter("@DstT106LeafID_Recv", DbType.Int32, dstT106LeafID_Recv));
                paramList.Add(new IRAPProcParameter("@DstT1LeafID_Recv", DbType.Int32, dstT1LeafID_Recv));
                paramList.Add(new IRAPProcParameter("@PickUpSheetXML", DbType.String, pickUpSheetXML));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAPSCES..usp_PrintVoucher_PWOMaterialDelivery，参数：" +
                        "CommunityID={0}|TransactNo={1}|PWOIssuingFactID={2}|SrcT173LeafID={3}|" +
                        "DstT173LeafID={4}|DstT106LeafID_Recv={5}|DstT1LeafID_Recv={6}|" +
                        "PickUpSheetXML={7}|SysLogID={8}",
                        communityID, transactNo, pwoIssuingFactID, srcT173LeafID, dstT173LeafID,
                        dstT106LeafID_Recv, dstT1LeafID_Recv, pickUpSheetXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = 
                        conn.CallProc(
                            "IRAPSCES..usp_PrintVoucher_PWOMaterialDelivery", 
                            ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    Hashtable rtnParams = new Hashtable();
                    if (errCode == 0)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput || 
                                param.Direction == ParameterDirection.Output)
                            {
                                if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                else
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }
                    }

                    return Json(rtnParams);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPSCES..usp_PrintVoucher_PWOMaterialDelivery 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="pwoIssuingFactID">工单签发事实编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_ProductionFlowCard(
            int communityID, 
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
                List<ProductionFlowCard> datas = new List<ProductionFlowCard>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@PWOIssuingFactID", DbType.Int64, pwoIssuingFactID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPSCES..ufn_GetList_ProductionFlowCard，" +
                        "参数：CommunityID={0}|PWOIssuingFactID={1}|SysLogID={2}",
                        communityID,
                        pwoIssuingFactID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                                "SELECT * " +
                                "FROM IRAPSCES..ufn_GetList_ProductionFlowCard(" +
                                "@CommunityID, @PWOIssuingFactID, @SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<ProductionFlowCard> lstDatas =
                            conn.CallTableFunc<ProductionFlowCard>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format(
                        "调用 IRAPSCES..ufn_GetList_ProductionFlowCard 函数发生异常：{0}",
                        error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(datas);
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
        public IRAPJsonResult usp_PokaYoke_PallPrint(
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
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@MaterialCode", DbType.String, materialCode));
                paramList.Add(new IRAPProcParameter("@CustomerCode", DbType.String, customerCode));
                paramList.Add(new IRAPProcParameter("@ShipToParty", DbType.String, shipToParty));
                paramList.Add(new IRAPProcParameter("@QtyInStore", DbType.String, qtyInStore));
                paramList.Add(new IRAPProcParameter("@DateCode", DbType.String, dateCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAPSCES..usp_PokaYoke_PallPrint，参数：" +
                        "CommunityID={0}|MaterialCode={1}|CustomerCode={2}"+
                        "ShipToParty={3}|QtyInStore={4}|DateCode={5}|SysLogID={6}",
                        communityID, materialCode, customerCode, shipToParty,
                        qtyInStore, dateCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc(
                            "IRAPSCES..usp_PokaYoke_PallPrint",
                            ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    Hashtable rtnParams = new Hashtable();
                    if (errCode == 0)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput ||
                                param.Direction == ParameterDirection.Output)
                            {
                                if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                else
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }
                    }

                    return Json(rtnParams);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPSCES..usp_PokaYoke_PallPrint 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
