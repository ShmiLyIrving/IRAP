using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPORM;
using IRAPShared;
using IRAPShared.Json;
using IRAP.Entity.MES;

namespace IRAP.BL.MES
{
    public class WIP : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public WIP()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取用于人工检查的在制品以及子在制品信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="wipIDCode">在制品标识</param>
        /// <param name="productLeaf">当前选中产品叶标识</param>
        /// <param name="workUnitLeaf">当前选中工位叶标识</param>
        /// <param name="isEnhanced">是否增强</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>Inspecting</returns>
        public IRAPJsonResult mfn_GetInfo_WIPIDCode(
            int communityID,
            string wipIDCode,
            int productLeaf,
            int workUnitLeaf,
            bool isEnhanced,
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
                Inspecting inspectingObject = new Inspecting();
                IRAPJsonResult jsonResult = ufn_GetInfo_WIPIDCode(
                    communityID,
                    wipIDCode,
                    productLeaf,
                    workUnitLeaf,
                    isEnhanced,
                    sysLogID,
                    out errCode,
                    out errText);
                if (errCode == 0)
                {
                    WIPIDCode wip = IRAPJsonSerializer.Deserializer(
                        jsonResult.Json,
                        typeof(WIPIDCode)) as WIPIDCode;
                    inspectingObject.MainWIPIDCode = wip;

                    if (wip.BarcodeStatus == 0 && wip.RoutingStatus == 0)
                    {
                        jsonResult = ufn_GetList_SubWIPIDCodes(
                            communityID,
                            wip.WIPCode,
                            productLeaf,
                            workUnitLeaf,
                            sysLogID,
                            out errCode,
                            out errText);
                        if (errCode == 0)
                        {
                            List<SubWIPIDCodeInfo> subWIPs = IRAPJsonSerializer.Deserializer(
                                jsonResult.Json,
                                typeof(List<SubWIPIDCodeInfo>)) as List<SubWIPIDCodeInfo>;
                            foreach (SubWIPIDCodeInfo subWIP in subWIPs)
                            {
                                inspectingObject.SubWIPIDCodes.Add(
                                    new SubWIPIDCodeInfo_Inspecting()
                                    {
                                        Ordinal = subWIP.Ordinal,
                                        T102LeafID = subWIP.T102LeafID,
                                        ProductNo = subWIP.ProductNo,
                                        SubWIPGroupID = subWIP.SubWIPGroupID,
                                        SubWIPIDCode = subWIP.SubWIPIDCode,
                                        Scrapped = subWIP.Scrapped,
                                        PWOCategoryLeaf = subWIP.PWOCategoryLeaf,
                                    });
                            }
                        }
                    }
                }

                return Json(inspectingObject);
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                return Json(new Inspecting());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 解析WIPIDCode在当前工位上生产是否OK：
        /// ⒈ 路由是否停滞在本工位；
        /// ⒉ 产品是否当前选中产品；
        /// ⒊ 是否合法的在制品标识或在制品容器标识。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="wipIDCode">在制品标识</param>
        /// <param name="productLeaf">当前选中产品叶标识</param>
        /// <param name="workUnitLeaf">当前选中工位叶标识</param>
        /// <param name="isEnhanced">是否增强</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List[WIPIDCode]</returns>
        public IRAPJsonResult ufn_GetInfo_WIPIDCode(
            int communityID, 
            string wipIDCode, 
            int productLeaf, 
            int workUnitLeaf, 
            bool isEnhanced, 
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
                WIPIDCode data = new WIPIDCode();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@WIPIDCode", DbType.String, wipIDCode));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@IsEnhanced", DbType.Boolean, isEnhanced));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetInfo_WIPIDCode，参数：CommunityID={0}|" +
                        "WIPIDCode={1}|ProductLeaf={2}|WorkUnitLeaf={3}|IsEnhanced={4}|" +
                        "SysLogID={5}",
                        communityID, wipIDCode, productLeaf, workUnitLeaf, isEnhanced,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetInfo_WIPIDCode(" +
                            "@CommunityID, @WIPIDCode, @ProductLeaf, " +
                            "@WorkUnitLeaf, @IsEnhanced, @SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<WIPIDCode> lstDatas = 
                            conn.CallTableFunc<WIPIDCode>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = "调用成功！";
                        }
                        else
                        {
                            errCode = 99001;
                            errText = string.Format("在制品标识[{0}]在系统中不存在", wipIDCode);
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = 
                        string.Format(
                            "调用 IRAPMES..ufn_GetInfo_WIPIDCode 函数发生异常：{0}", 
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(data);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取子在制品标识清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="wipIDCode">在制品标识</param>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        /// <returns>List[SubWIPIDCodeInfo]</returns>
        public IRAPJsonResult ufn_GetList_SubWIPIDCodes(
            int communityID,
            string wipIDCode,
            int productLeaf,
            int workUnitLeaf,
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
                List<SubWIPIDCodeInfo> datas = new List<SubWIPIDCodeInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@WIPIDCode", DbType.String, wipIDCode));
                paramList.Add(new IRAPProcParameter("@ProductLeaf", DbType.Int32, productLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_SubWIPIDCodes，" +
                        "参数：CommunityID={0}|WIPIDCode={1}|ProductLeaf={2}|" +
                        "WorkUnitLeaf={3}|SysLogID={4}",
                        communityID, wipIDCode, productLeaf, workUnitLeaf,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_SubWIPIDCodes(" +
                            "@CommunityID, @WIPIDCode, @ProductLeaf, " +
                            "@WorkUnitLeaf, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<SubWIPIDCodeInfo> lstDatas =
                            conn.CallTableFunc<SubWIPIDCodeInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<SubWIPIDCodeInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPMES..ufn_GetList_SubWIPIDCodes 函数发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
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
        /// 获取指定在制品经过指定工位的次数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="wipCode">在制品主标识代码</param>
        public IRAPJsonResult ufn_GetWIPPassByTimes(
            int communityID,
            int t102LeafID,
            int t107LeafID,
            string wipCode,
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
                int rlt = 0;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@WIPCode", DbType.String, wipCode));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES.dbo.ufn_GetWIPPassByTimes，参数：" +
                        "CommunityID={0}|T102LeafID={1}|T107LeafID={2}|WIPCode={3}",
                        communityID,
                        t102LeafID,
                        t107LeafID,
                        wipCode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        rlt = 
                            (int) conn.CallScalarFunc(
                                "IRAPMES.dbo.ufn_GetWIPPassByTimes", 
                                paramList);
                        if (rlt > -2147483648)
                        {
                            errCode = 0;
                            errText = string.Format("调用成功！获得 PassByTimes={0}", rlt);
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                        else
                        {
                            errCode = 99999;
                            errText = "未得到 PassByTimes 的值";
                        }
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = 
                        string.Format(
                            "调用 IRAPMES.dbo.ufn_GetWIPPassByTimes 函数发生异常：{0}", 
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }

        /// <summary>
        /// 人工检查的失败送修功能
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="wipCode">在制品个体标识</param>
        /// <param name="lotNumber">在制品批次</param>
        /// <param name="containerNo">在制品容器号</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="qcStatus">在制品质量状态</param>
        /// <param name="t107LeafID">当前滞在工序叶标识</param>
        /// <param name="routingCondition">路由条件控制值</param>
        public IRAPJsonResult usp_MarkNGWIP(
            int communityID,
            int t102LeafID,
            string wipCode,
            string lotNumber,
            string containerNo,
            string pwoNo,
            long qcStatus,
            int t107LeafID,
            long routingCondition,
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
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@WIPCode", DbType.String, wipCode));
                paramList.Add(new IRAPProcParameter("@LotNumber", DbType.String, lotNumber));
                paramList.Add(new IRAPProcParameter("@ContainerNo", DbType.String, containerNo));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, pwoNo));
                paramList.Add(new IRAPProcParameter("@QCStatus", DbType.Int64, qcStatus));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@RoutingCondition", DbType.Int64, routingCondition));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_MarkNGWIP，参数：CommunityID={0}|" +
                        "T102LeafID={1}|WIPCode={2}|LotNumber={3}|ContainerNo={4}|" +
                        "PWONo={5}|QCStatus={6}|T107LeafID={7}|RoutingCondition={8}|" +
                        "SysLogID={9}",
                        communityID, t102LeafID, wipCode, lotNumber, containerNo,
                        pwoNo, qcStatus, t107LeafID, routingCondition, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = 
                        conn.CallProc("IRAPMES..usp_MarkNGWIP", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    return Json(error);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = 
                    string.Format(
                        "调用 IRAPMES..usp_MarkNGWIP 函数发生异常：{0}", 
                        error.Message);
                return Json(
                    new IRAPError()
                    {
                        ErrCode = errCode,
                        ErrText = errText,
                    });
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 在制品路由控制
        /// ⒈ 支持个体可追溯产品个体或群体标识代码的路由控制；
        /// ⒉ 支持批次可追溯产品在制品容器标识的路由控制；
        /// ⒊ 支持在路由终点直接下线到在制品线边库位(如果有线边库位)；
        /// ⒋ 支持在路由终点直接下线到在制品缓冲区的收料库位(如果没有线边库位)。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t102LeafID">产品叶标识</param>
        /// <param name="wipCode">在制品个体标识</param>
        /// <param name="lotNumber">在制品批次</param>
        /// <param name="containerNo">在制品容器号</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="qcStatus">在制品质量状态</param>
        /// <param name="t107LeafID">当前滞在工序叶标识</param>
        /// <param name="routingCondition">路由条件控制值</param>
        public IRAPJsonResult usp_WIPForward(
            int communityID,
            int t102LeafID,
            string wipCode,
            string lotNumber,
            string containerNo,
            string pwoNo,
            long qcStatus,
            int t107LeafID,
            long routingCondition,
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
                paramList.Add(new IRAPProcParameter("@T102LeafID", DbType.Int32, t102LeafID));
                paramList.Add(new IRAPProcParameter("@WIPCode", DbType.String, wipCode));
                paramList.Add(new IRAPProcParameter("@LotNumber", DbType.String, lotNumber));
                paramList.Add(new IRAPProcParameter("@ContainerNo", DbType.String, containerNo));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, pwoNo));
                paramList.Add(new IRAPProcParameter("@QCStatus", DbType.Int64, qcStatus));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@RoutingCondition", DbType.Int64, routingCondition));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_WIPForward，参数：CommunityID={0}|" +
                        "T102LeafID={1}|WIPCode={2}|LotNumber={3}|ContainerNo={4}|" +
                        "PWONo={5}|QCStatus={6}|T107LeafID={7}|RoutingCondition={8}|" +
                        "SysLogID={9}",
                        communityID, t102LeafID, wipCode, lotNumber, containerNo,
                        pwoNo, qcStatus, t107LeafID, routingCondition, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = 
                        conn.CallProc("IRAPMES..usp_WIPForward", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    return Json(error);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = 
                    string.Format(
                        "调用 IRAPMES..usp_WIPForward 函数发生异常：{0}", 
                        error.Message);
                return Json(
                    new IRAPError()
                    {
                        ErrCode = errCode,
                        ErrText = errText,
                    });
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}