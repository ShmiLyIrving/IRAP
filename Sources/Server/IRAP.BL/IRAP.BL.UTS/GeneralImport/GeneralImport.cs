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
        public IRAPJsonResult sfn_GetInfo_LinkedTreeOfImpExp(int communityID,int t19LeafID,long sysLogID,out int errCode,
            out string errText) {
            string strProcedureName =string.Format("{0}.{1}",className, MethodBase.GetCurrentMethod().Name);

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
             long sysLogID, out int errCode,out string errText) {

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
                return Json(new List<string>(){xml});
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
        public IRAPError sfn_Get_ProcToCreateTBL(int communityID, int t19LeafID, int treeID, int txLeafID,
            long sysLogID, string blName, out int errCode, out string errText) {

            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@communityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@t19LeafID", DbType.Int32, t19LeafID));
                paramList.Add(new IRAPProcParameter("@treeID", DbType.Int32, treeID));
                paramList.Add(new IRAPProcParameter("@txLeafID", DbType.Int32, txLeafID));
                paramList.Add(new IRAPProcParameter("@sysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@errCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@errText", DbType.String, ParameterDirection.Output, 800));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用存储过程 IRAP..sfn_Get_ProcToCreateTBL，" +
                        "参数：communityID={0}|t19LeafID={1}|treeID={2}|txLeafID={3}|sysLogID={4}|blName={5}",
                        communityID, t19LeafID, treeID, txLeafID, sysLogID),strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection()) {
                        string strSQL = "IRAPDPA.." + blName;
                        var err = conn.CallProc(strSQL,ref paramList);
                        errCode = err.ErrCode;
                        errText = err.ErrText;
                        WriteLog.Instance.Write(errText, strProcedureName);
                        return err;
                    }
                } catch (Exception ex) {
                    IRAPError errInfo = new IRAPError(9999, ex.Message);
                    errCode = 9999;
                    errText = string.Format("调用 IRAP..sfn_GetXML_ImportInfo 函数发生异常：{0}", ex.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(ex.StackTrace, strProcedureName);
                    return errInfo;
                }
                #endregion
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
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

    }
}
