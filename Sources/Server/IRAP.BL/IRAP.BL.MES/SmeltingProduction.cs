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
        /// 获取信息站点上下文(工位或工作流结点功能信息)
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_WIPStationsOfAHost(int communityID,long sysLogID, out int errCode,
            out string errText) {
            //todo:删除此句
                sysLogID = GetSysLogID();
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<ProductionParam> datas = new List<ProductionParam>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMDM..ufn_GetList_WIPStationsOfAHost，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMDM..ufn_GetList_WIPStationsOfAHost(" +
                            "@CommunityID, @SysLogID)";

                        IList<ProductionParam> lstDatas = conn.CallTableFunc<ProductionParam>(strSQL, paramList);
                        datas = lstDatas.ToList<ProductionParam>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPMDM..ufn_GetList_WIPStationsOfAHost 函数发生异常：{0}", error.Message);
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
                List<int> datas = new List<int>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
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

                        var id = (int)conn.CallScalar(strSQL, paramList);
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

    }

}
