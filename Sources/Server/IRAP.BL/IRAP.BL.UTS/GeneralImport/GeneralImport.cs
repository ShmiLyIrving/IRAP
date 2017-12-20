using IRAP.Entity.UTS;
using IRAP.Global;
using IRAPORM;
using IRAPShared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace IRAP.BL.UTS {
    public class GeneralImport : IRAPBLLBase {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public GeneralImport() {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取导入导出关联的树及其叶选择提示信息 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t19LeafID">导入导出叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public IRAPJsonResult sfn_GetInfo_LinkedTreeOfImpExp(int communityID, int t19LeafID, long sysLogID, out int errCode,
            out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<LinkedTreeTip> datas = new List<LinkedTreeTip>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T19LeafID", DbType.Int32, t19LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetInfo_LinkedTreeOfImpExp，" +
                        "参数：CommunityID={0}|T19LeafID={1}|SysLogID={2}",
                        communityID, t19LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_GetInfo_LinkedTreeOfImpExp(" +
                            "@CommunityID, @T19LeafID, @SysLogID)";

                        IList<LinkedTreeTip> lstDatas = conn.CallTableFunc<LinkedTreeTip>(strSQL, paramList);
                        datas = lstDatas.ToList<LinkedTreeTip>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_GetInfo_LinkedTreeOfImpExp 函数发生异常：{0}", error.Message);
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
        /// 获取导入信息XML报文
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t19LeafID">导入导出叶标识</param>
        /// <param name="txLeafID">导出导出关联树叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns></returns>
        public IRAPJsonResult sfn_GetXML_ImportInfo(int communityID, int t19LeafID, int txLeafID,
             long sysLogID, out int errCode, out string errText) {

            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                string xml = null;
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@communityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@t19LeafID", DbType.Int32, t19LeafID));
                paramList.Add(new IRAPProcParameter("@txLeafID", DbType.Int32, txLeafID));
                paramList.Add(new IRAPProcParameter("@sysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetXML_ImportInfo，" +
                        "参数：communityID={0}|t19LeafID={1}|txLeafID={2}|sysLogID={3}",
                        communityID, t19LeafID, txLeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT IRAP.dbo.sfn_GetXML_ImportInfo(@communityID,@t19LeafID,@txLeafID,@sysLogID)";
                        xml = conn.CallScalar(strSQL, paramList).ToString();
                        errCode = 0;
                        errText = string.Format("调用成功！结果长度{0}", xml.Length);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_GetXML_ImportInfo 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion
                return Json(new List<string>() { xml });
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t19LeafID">导入导出叶标识</param>
        /// <param name="treeID">导入关联树标识</param>
        /// <param name="txLeafID">导出导出关联树叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="blName"></param>
        /// <returns></returns>
        public IRAPJsonResult sfn_Get_ProcToCreateTBL(int communityID, int t19LeafID, int treeID, int txLeafID,
            long sysLogID, string blName, out int errCode, out string errText) {

            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            List<IRAPError> data = new List<IRAPError>();
            try {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T19LeafID", DbType.Int32, t19LeafID));
                paramList.Add(new IRAPProcParameter("@TreeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@TxLeafID", DbType.Int32, txLeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 800));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用存储过程 IRAP..sfn_Get_ProcToCreateTBL，" +
                        "参数：communityID={0}|t19LeafID={1}|treeID={2}|txLeafID={3}|sysLogID={4}|blName={5}",
                        communityID, t19LeafID, treeID, txLeafID, sysLogID, blName), strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "IRAPDPA.." + blName;
                        var err = conn.CallProc(strSQL, ref paramList);
                        errCode = err.ErrCode;
                        errText = err.ErrText;
                        WriteLog.Instance.Write(errText, strProcedureName);
                        data.Add(err);

                    }
                } catch (Exception ex) {
                    IRAPError errInfo = new IRAPError(9999, ex.Message);
                    errCode = 9999;
                    errText = string.Format("创建table：{0}发生异常{1}",blName, ex.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(ex.StackTrace, strProcedureName);
                    data.Add(errInfo);
                }
                #endregion
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return Json(data);
        }

        public IRAPJsonResult sfn_AccessibleFilteredLeafSet(int communityID, int treeID, int scenarioIndex,
            string dicingFilter, int nodeDepth, string keyword, long sysLogID, out int errCode, out string errText) {

            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                List<LeafSet> datas = new List<LeafSet>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@communityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@treeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@scenarioIndex", DbType.Int32, scenarioIndex));
                paramList.Add(new IRAPProcParameter("@dicingFilter", DbType.String, dicingFilter));
                paramList.Add(new IRAPProcParameter("@nodeDepth", DbType.Int32, nodeDepth));
                paramList.Add(new IRAPProcParameter("@keyword", DbType.String, keyword));
                paramList.Add(new IRAPProcParameter("@sysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_AccessibleFilteredLeafSet，" +
                        "参数：communityID={0}|treeID={1}|scenarioIndex={2}|dicingFilter={3}|nodeDepth={4}|keyword={5}|sysLogID={6}",
                        communityID, treeID, scenarioIndex, dicingFilter, nodeDepth, keyword, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_AccessibleFilteredLeafSet(" +
                            "@communityID, @treeID, @scenarioIndex, @dicingFilter, @nodeDepth, @keyword, @sysLogID)";

                        IList<LeafSet> lstDatas = conn.CallTableFunc<LeafSet>(strSQL, paramList);
                        datas = lstDatas.ToList<LeafSet>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception error) {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_AccessibleFilteredLeafSet 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public IRAPJsonResult DeleteOldTableData(string tableName, long importLogId, out int errCode, out string errText) {

            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            List<IRAPError> data = new List<IRAPError>();
            try {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@importLogId", DbType.Int64, importLogId));
                WriteLog.Instance.Write(
                    string.Format("执行SQL delete from IRAPDPA..{0} where ImportLogID ={1}", tableName, importLogId),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = string.Format("delete from IRAPDPA..{0} where ImportLogID =@importLogId", tableName);
                        var count = conn.CallScalar(strSQL, paramList);
                        IRAPError errInfo = new IRAPError(0, "成功删除旧数据");
                        errCode = errInfo.ErrCode;
                        errText = errInfo.ErrText;
                        WriteLog.Instance.Write(errInfo.ErrText, strProcedureName);
                        data.Add(errInfo);
                    }
                } catch (Exception ex) {
                    IRAPError errInfo = new IRAPError(9999, ex.Message);
                    errCode = 9999;
                    errText = string.Format("删除表{1}中的数据发生异常：{0}", ex.Message, tableName);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(ex.StackTrace, strProcedureName);
                    data.Add(errInfo);
                }
                #endregion
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return Json(data);
        }

        public IRAPJsonResult InsertTempTableData(string tableName, DataTable data, out int errCode, out string errText) {

            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            List<IRAPError> result = new List<IRAPError>();
            try {
                #region 创建数据库调用参数组，并赋值
                WriteLog.Instance.Write(
                    string.Format("将数据插入临时表{0}中", tableName),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        var errInfo = conn.BulkBatchInsert(data, "IRAPDPA.." + tableName + "");
                        errCode = errInfo.ErrCode;
                        errText = errInfo.ErrText;
                        WriteLog.Instance.Write(errInfo.ErrText, strProcedureName);
                        result.Add(errInfo);
                    }
                } catch (Exception ex) {
                    IRAPError errInfo = new IRAPError(9999, ex.Message);
                    errCode = 9999;
                    errText = string.Format("插入表{1}中的数据发生异常：{0}", ex.Message, tableName);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(ex.StackTrace, strProcedureName);
                    result.Add(errInfo);
                }
                #endregion
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return Json(result);
        }

        /// <summary>
        /// 指定时区地方时转换为Unix时间 
        /// </summary>
        /// <returns>Unix时间 </returns>
        public IRAPJsonResult sfn_LocalToUnixTime(out int errCode, out string errText) {

            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            var localDateTime = DateTime.Now;
            int timeZone = 8;
            int result = 0;
            try {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@LocalDateTime", DbType.DateTime, localDateTime));
                paramList.Add(new IRAPProcParameter("@TimeZone", DbType.Int16, timeZone));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_LocalToUnixTime，参数：LocalDateTime={0}|TimeZone={1}", localDateTime, timeZone),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        result = Convert.ToInt32(conn.CallScalarFunc("IRAP.dbo.sfn_LocalToUnixTime", paramList));
                        errCode = 0;
                        errText = "调用函数 IRAP..sfn_LocalToUnixTime成功";
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                } catch (Exception ex) {
                    IRAPError errInfo = new IRAPError(9999, ex.Message);
                    errCode = 9999;
                    errText = string.Format("调用函数 IRAP..sfn_LocalToUnixTime异常：{0}", ex.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(ex.StackTrace, strProcedureName);
                }
                #endregion
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return Json(result);
        }

        /// <summary>
        /// 调用验证存储过程
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t19LeafID">导入导出叶标识</param>
        /// <param name="treeID">导入关联树标识</param>
        /// <param name="txLeafID">导出导出关联树叶标识</param>
        /// <param name="importLogID"></param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="blName"></param>
        /// <param name="verifyName">验证存储过程名</param>
        /// <returns></returns>
        public IRAPJsonResult ProcOnVerification(int communityID, int t19LeafID, int treeID, int txLeafID,long importLogID,
            long sysLogID, string blName,string verifyName, out int errCode, out string errText) {
                return ProcOnLoad(communityID, t19LeafID, treeID, txLeafID, importLogID, sysLogID, blName, verifyName, 0, 0, false, out errCode, out errText);
            
        }

        /// <summary>
        /// 调用加载存储过程
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t19LeafID">导入导出叶标识</param>
        /// <param name="treeID">导入关联树标识</param>
        /// <param name="txLeafID">导出导出关联树叶标识</param>
        /// <param name="importLogID"></param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="blName"></param>
        /// <param name="loadName">验证存储过程名</param>
        /// <param name="IncludeAll">是否导入全量</param>
        /// <param name="MigrateImportLog">加载后是否迁移导入日志</param>
        /// <param name="isLoad">是否是加载</param>
        /// <returns></returns>
        public IRAPJsonResult ProcOnLoad(int communityID, int t19LeafID, int treeID, int txLeafID, long importLogID, long sysLogID,
            string blName, string loadName, int isLaodAll, int isLoadLog, bool isLoad, out int errCode, out string errText) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);

            DataTable dt = new DataTable("grid");
            try {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@communityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@t19LeafID", DbType.Int32, t19LeafID));
                paramList.Add(new IRAPProcParameter("@treeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@txLeafID", DbType.Int32, txLeafID));
                paramList.Add(new IRAPProcParameter("@importLogID", DbType.Int64, importLogID));
                paramList.Add(new IRAPProcParameter("@blName", DbType.String, blName));
                paramList.Add(new IRAPProcParameter("@sysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 800));
                if (isLoad) {
                    paramList.Add(new IRAPProcParameter("@isLaodAll", DbType.Boolean, isLaodAll));
                    paramList.Add(new IRAPProcParameter("@MigrateImportLog ", DbType.Boolean, isLoadLog));
                    WriteLog.Instance.Write(
                    string.Format(
                        "调用存储过程{0}，参数：communityID={1}|t19LeafID={2}|treeID={3}|txLeafID={4}|importLogID={5}|blName={6}|sysLogID={7}|isLaodAll={8}|isLoadLog={9}",
                        loadName, communityID, t19LeafID, treeID, txLeafID, importLogID, blName, sysLogID, isLaodAll, isLoadLog), strProcedureName);
                } else {
                    WriteLog.Instance.Write(
                        string.Format(
                            "调用存储过程{0}，参数：communityID={1}|t19LeafID={2}|treeID={3}|txLeafID={4}|importLogID={5}|blName={6}|sysLogID={7}",
                            loadName, communityID, t19LeafID, treeID, txLeafID, importLogID, blName, sysLogID), strProcedureName);
                }
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        var err = conn.CallProc("IRAPDPA.." + loadName + "", ref paramList);
                        errCode = 0;
                        errText = string.Format("调用存储过程{0}成功", loadName);
                        WriteLog.Instance.Write(errText, strProcedureName);

                        dt = conn.QuerySQL(string.Format("select * from IRAPDPA..{0} where PartitioningKey={1} and ImportLogID={2}", blName, communityID * 10000, importLogID));
                        return Json(dt);
                    }
                } catch (Exception ex) {
                    IRAPError errInfo = new IRAPError(9999, ex.Message);
                    errCode = 9999;
                    errText = string.Format("调用存储过程{0}异常：{1}", loadName, ex.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(ex.StackTrace, strProcedureName);
                }


                #endregion
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return Json(dt);
        }


    }
}
