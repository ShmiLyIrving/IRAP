using IRAP.Entity.UTS;
using IRAP.Global;
using IRAPORM;
using IRAPShared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

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
                    errText = string.Format("调用 IRAP..sfn_GetXML_ImportInfo 函数发生异常：{0}", ex.Message);
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

        public IRAPJsonResult InsertTempTableData(string tableName,DataTable data, out int errCode, out string errText) {

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
    }

}
