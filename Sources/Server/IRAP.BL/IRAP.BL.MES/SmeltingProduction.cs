using IRAP.Entities.IRAP;
using IRAP.Entities.MES;
using IRAP.Global;
using IRAPORM;
using IRAPShared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IRAP.BL.MES {
    public class SmeltingProduction :IRAPBLLBase {

        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public SmeltingProduction() {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        #region Debug
        /// <summary>
        /// 获取测试用的登录标识
        /// </summary>
        /// <returns></returns>
        private int GetSysLogID() {
            try {
                using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                    string strSQL = "SELECT  TOP 1 SysLogID,*FROM IRAP..stb009 WHERE PartitioningKey=600300000  AND UserCode='0000001'"
                    + "  ORDER BY LoginTime DESC";

                    return (int)conn.CallScalar(strSQL);
                }
            } catch (Exception) {
                return 0;
            }
        }
    
        #endregion

        /// <summary>
        /// 操作工编号检验
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="operatorCode">操作工编号</param>
        /// <returns></returns>
        public IRAPJsonResult LookForOperatorCode(int communityID,string operatorCode, out int errCode,
            out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<long> datas = new List<long>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int64, communityID*10000));
                paramList.Add(new IRAPProcParameter("@OperatorCode", DbType.String, operatorCode));
                WriteLog.Instance.Write(
                    string.Format(
                        "在表IRAP..stb006中查找匹配项，" +
                        "参数：CommunityID={0}|OperatorCode={1}",
                        communityID, operatorCode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "select * from IRAP..stb006 where PartitioningKey = @CommunityID and UserCode = @OperatorCode";

                        var id = (long)conn.CallScalar(strSQL, paramList);
                        datas.Add(id);
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("在表IRAP..stb006中查找匹配项发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
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
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_WaitSmeltBatchProduction(int communityID, int t107LeafID,int t216LeafID,int t133LeafID,
            string planStartDate,long sysLogID,out int errCode,out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<WaitingSmelt> datas = new List<WaitingSmelt>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.String, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T133LeafID", DbType.String, t133LeafID));
                paramList.Add(new IRAPProcParameter("@PlanStartDate", DbType.String, planStartDate));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数ufn_GetList_WaitSmeltBatchProduction," +
                        "参数：CommunityID={0}|T107LeafID={1}||T216LeafID={2}|T133LeafID={3}|PlanStartDate={4}|SysLogID={5}",
                        communityID, t107LeafID, t216LeafID, t133LeafID, planStartDate, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_WaitSmeltBatchProduction(" +
                            "@CommunityID,@T107LeafID,@T216LeafID,@T133LeafID,@PlanStartDate, @SysLogID)";
                        IList<WaitingSmelt> lstDatas = conn.CallTableFunc<WaitingSmelt>(strSQL, paramList);
                        datas = lstDatas.ToList<WaitingSmelt>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用函数ufn_GetList_WaitSmeltBatchProduction发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="batchNumber">熔炼容次号</param>
        /// <param name="sysLogID">语言标识</param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_SmeltBatchPWONo(int communityID, string batchNumber,long sysLogID, out int errCode,
            out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<OrderInfo> datas = new List<OrderInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber)); 
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数ufn_GetList_SmeltBatchPWONo," +
                        "参数：CommunityID={0}|BatchNumber={1}||SysLogID={2}",
                        communityID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_SmeltBatchPWONo(" +
                            "@CommunityID, @BatchNumber, @SysLogID)";
                        IList<OrderInfo> lstDatas = conn.CallTableFunc<OrderInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<OrderInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用函数ufn_GetList_SmeltBatchPWONo发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取配料信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t131LeafID">环别叶标识</param>
        /// <param name="t216LeafID">工序代码</param>
        /// <param name="batchNumber">熔炼容次号</param>
        /// <param name="sysLogID">语言标识</param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_SmeltMaterialItems(int communityID,int t131LeafID,int t216LeafID,string batchNumber, long sysLogID,
            out int errCode,out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<SmeltMaterialItem> datas = new List<SmeltMaterialItem>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T131LeafID", DbType.Int32, t131LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数ufn_GetList_SmeltMaterialItems," +
                        "参数：CommunityID={0}|T131LeafID={1}|T216LeafID={2}|BatchNumber={3}||SysLogID={4}",
                        communityID, t131LeafID, t216LeafID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_SmeltMaterialItems(" +
                            "@CommunityID,@T131LeafID,@T216LeafID, @BatchNumber, @SysLogID)";
                        IList<SmeltMaterialItem> lstDatas = conn.CallTableFunc<SmeltMaterialItem>(strSQL, paramList);
                        datas = lstDatas.ToList<SmeltMaterialItem>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用函数ufn_GetList_SmeltMaterialItems发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取生产开炉参数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t131LeafID">环别叶标识</param>
        /// <param name="t216LeafID">工序代码</param>
        /// <param name="batchNumber">熔炼容次号</param>
        /// <param name="sysLogID">语言标识</param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_SmeltMethodItems(int communityID, int t131LeafID, int t216LeafID, string batchNumber, long sysLogID,
            out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<SmeltMethodItem> datas = new List<SmeltMethodItem>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T131LeafID", DbType.Int32, t131LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数ufn_GetList_SmeltMethodItems," +
                        "参数：CommunityID={0}|T131LeafID={1}|T216LeafID={2}|BatchNumber={3}||SysLogID={4}",
                        communityID, t131LeafID, t216LeafID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_SmeltMethodItems(" +
                            "@CommunityID,@T131LeafID,@T216LeafID, @BatchNumber, @SysLogID)";
                        IList<SmeltMethodItem> lstDatas = conn.CallTableFunc<SmeltMethodItem>(strSQL, paramList);
                        datas = lstDatas.ToList<SmeltMethodItem>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用函数ufn_GetList_SmeltMethodItems发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
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
        public IRAPJsonResult usp_SaveFact_SmeltBatchProductionStart(int communityID, int t216LeafID, int t107LeafID, int t131LeafID,
            string operatorCode,string batchNumber, string rSFactXML,long sysLogID,out int errCode, out string errText) {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int64, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@T131LeafID", DbType.Int32, t131LeafID));
                paramList.Add(new IRAPProcParameter("@OperatorCode", DbType.String, operatorCode));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@RSFactXML", DbType.String, rSFactXML));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode",DbType.Int32,ParameterDirection.Output,4));
                paramList.Add(new IRAPProcParameter("@ErrText",DbType.String,ParameterDirection.Output,400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 " +
                        "IRAPMES..usp_SaveFact_SmeltBatchProductionStart，参数：" +
                        "CommunityID={0}|T216LeafID={1}|T107LeafID={2}|T131LeafID={3}|OperatorCode={4}|BatchNumber={5}|RSFactXML={6}"+
                        "|SysLogID={7}",
                        communityID, t216LeafID, t107LeafID, t131LeafID, operatorCode,batchNumber,rSFactXML,sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                    IRAPError error = conn.CallProc("IRAPMES..usp_SaveFact_SmeltBatchProductionStart", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText),strProcedureName);

                    return Json("");
                }
                #endregion
            } catch (Exception error) {
                errCode = 99000;
                errText = string.Format("调用 IRAPMES..usp_SaveFact_SmeltBatchProductionStart 时发生异常：{0}", error.Message);
                return Json("");
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
        public IRAPJsonResult ufn_GetInfo_SmeltBatchProduct(
            int communityID,
            int t107LeafID,
            int t216LeafID,
            int t133LeafID,
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
                List<SmeltBatchProductionInfo> data = new List<SmeltBatchProductionInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.String, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T133LeafID", DbType.String, t133LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数ufn_GetInfo_SmeltBatchProduct," +
                        "参数：CommunityID={0}|T107LeafID={1}||T216LeafID={2}|T133LeafID={3}|SysLogID={4}",
                        communityID, t107LeafID, t216LeafID, t133LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetInfo_SmeltBatchProduct(" +
                            "@CommunityID,@T107LeafID,@T216LeafID,@T133LeafID, @SysLogID)";

                        IList<SmeltBatchProductionInfo> lstDatas = 
                            conn.CallTableFunc<SmeltBatchProductionInfo>(strSQL, paramList);
                        data = lstDatas.ToList<SmeltBatchProductionInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = 
                        string.Format(
                            "调用函数 IRAPMES..ufn_GetInfo_SmeltBatchProduct 发生异常：{0}", 
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
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
        /// 获取炉前光谱、浇三角试样、炉水出炉的参数
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="opType">检验类型 --LQGP 炉前光谱，SSJSY 烧三角试验，LLCL 炉水出炉</param>
        /// <param name="t131LeafID">环别叶标识</param>
        /// <param name="t216LeafID">工序代码</param>
        /// <param name="batchNumber">熔炼容次号</param>
        /// <param name="sysLogID">语言标识</param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_SmeltMethodItemsByOpType(int communityID,string opType, int t131LeafID, int t216LeafID, 
            string batchNumber, long sysLogID, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<SmeltMethodItemByOpType> datas = new List<SmeltMethodItemByOpType>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@OpType", DbType.String, opType));
                paramList.Add(new IRAPProcParameter("@T131LeafID", DbType.Int32, t131LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数ufn_GetList_SmeltMethodItemsByOpType," +
                        "参数：CommunityID={0}|OpType={1}|T131LeafID={2}|T216LeafID={3}|BatchNumber={4}||SysLogID={5}",
                        communityID, opType, t131LeafID, t216LeafID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_SmeltMethodItemsByOpType(" +
                            "@CommunityID,@OpType,@T131LeafID,@T216LeafID, @BatchNumber, @SysLogID)";
                        IList<SmeltMethodItemByOpType> lstDatas = conn.CallTableFunc<SmeltMethodItemByOpType>(strSQL, paramList);
                        datas = lstDatas.ToList<SmeltMethodItemByOpType>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用函数ufn_GetList_SmeltMethodItemsByOpType发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
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
        public IRAPJsonResult usp_SaveFact_SmeltBatchMethodConfirming(int communityID, string opType,int t216LeafID, int t107LeafID, 
             string batchNumber, string rSFactXML, long sysLogID, out int errCode, out string errText) {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@Optype", DbType.String, opType));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int64, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@RSFactXML", DbType.String, rSFactXML));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 " +
                        "IRAPMES..usp_SaveFact_SmeltBatchMethodConfirming，参数：" +
                        "CommunityID={0}|Optype={1}|T216LeafID={2}|T107LeafID={3}|BatchNumber={4}|RSFactXML={5}|SysLogID={6}",
                        communityID, opType,t216LeafID, t107LeafID, batchNumber, rSFactXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                    IRAPError error = conn.CallProc("IRAPMES..usp_SaveFact_SmeltBatchMethodConfirming", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    return Json("");
                }
                #endregion
            } catch (Exception error) {
                errCode = 99000;
                errText = string.Format("调用 IRAPMES..usp_SaveFact_SmeltBatchMethodConfirming 时发生异常：{0}", error.Message);
                return Json("");
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
        public IRAPJsonResult usp_SaveFact_SmeltBatchLoadingMaterial(int communityID, int t216LeafID, int t107LeafID, 
            string batchNumber, string rSFactXML, long sysLogID, out int errCode, out string errText) {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int64, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@RSFactXML", DbType.String, rSFactXML));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 " +
                        "IRAPMES..usp_SaveFact_SmeltBatchLoadingMaterial，参数：" +
                        "CommunityID={0} |T216LeafID={1}|T107LeafID={2}|BatchNumber={3}|RSFactXML={4}|SysLogID={5}",
                        communityID, t216LeafID, t107LeafID, batchNumber, rSFactXML, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                    IRAPError error = conn.CallProc("IRAPMES..usp_SaveFact_SmeltBatchLoadingMaterial", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    return Json("");
                }
                #endregion
            } catch (Exception error) {
                errCode = 99000;
                errText = string.Format("调用 IRAPMES..usp_SaveFact_SmeltBatchLoadingMaterial 时发生异常：{0}", error.Message);
                return Json("");
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
        public IRAPJsonResult usp_SaveFact_SmeltBatchProductionEnd(int communityID, int t216LeafID, int t107LeafID,
            string batchNumber, long sysLogID, out int errCode, out string errText) {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int64, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 " +
                        "IRAPMES..usp_SaveFact_SmeltBatchProductionEnd，参数：" +
                        "CommunityID={0} |T216LeafID={1}|T107LeafID={2}|BatchNumber={3} |SysLogID={4}",
                        communityID, t216LeafID, t107LeafID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                    IRAPError error = conn.CallProc("IRAPMES..usp_SaveFact_SmeltBatchProductionEnd", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    return Json("");
                }
                #endregion
            } catch (Exception error) {
                errCode = 99000;
                errText = string.Format("调用 IRAPMES..usp_SaveFact_SmeltBatchProductionEnd 时发生异常：{0}", error.Message);
                return Json("");
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
        public IRAPJsonResult ufn_GetList_SmeltBatchMaterial(int communityID, int t101LeafID, long sysLogID, out int errCode,out string errText) {
            string strProcedureName =string.Format("{0}.{1}",className,MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<SmeltBatchMaterial> data = new List<SmeltBatchMaterial>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T101LeafID", DbType.Int32, t101LeafID)); 
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数ufn_GetList_SmeltBatchMaterial," +
                        "参数：CommunityID={0}|T101LeafID={1}||SysLogID={2}",
                        communityID, t101LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_SmeltBatchMaterial(" +
                            "@CommunityID,@T101LeafID, @SysLogID)";

                        IList<SmeltBatchMaterial> lstDatas =
                            conn.CallTableFunc<SmeltBatchMaterial>(strSQL, paramList);
                        data = lstDatas.ToList<SmeltBatchMaterial>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用函数 IRAPMES..ufn_GetList_SmeltBatchMaterial 发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                } finally {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
                #endregion

                return Json(data);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }

}
