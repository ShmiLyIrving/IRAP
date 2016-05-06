using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

using IRAP.Global;
using IRAPShared;
using IRAPORM;

namespace IRAP.BL.UTS
{
    public class IRAPPDC : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPPDC()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public IRAPJsonResult ufn_OLTP_StringValid(
            string menuParameters,
            int processLeaf,
            int workUnitLeaf,
            string inputStr,
            string opNodes,
            string tvCtrlParameters,
            int tabOrderID,
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
                DataTable rlt = new DataTable("PrintData");
                string sqlCmd =
                    string.Format(
                        "SELECT * FROM ufn_OLTP_{0}(@ProcessLeaf, @WorkUnitLeaf, " +
                        "@InputStr, @OpNodes, @TVCtrlParameters, @TabOrderID, " +
                        "@SysLogID) ORDER BY Ordinal",
                        menuParameters);

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@ProcessLeaf", DbType.Int32, processLeaf));
                paramList.Add(new IRAPProcParameter("@WorkUnitLeaf", DbType.Int32, workUnitLeaf));
                paramList.Add(new IRAPProcParameter("@InputStr", DbType.String, inputStr));
                paramList.Add(new IRAPProcParameter("@OpNodes", DbType.String, opNodes));
                paramList.Add(new IRAPProcParameter("@TVCtrlParameters", DbType.String, tvCtrlParameters));
                paramList.Add(new IRAPProcParameter("@TabOrderID", DbType.Int32, tabOrderID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用SQL命令[{0}]，参数：" + 
                        "ProcessLeaf={1}|WorkUnitLeaf={2}|InputStr={3}|"+
                        "OpNodes={4}|TVCtrlParameters={5}|TabOrderID={6}|"+
                        "SysLogID={7}", 
                        sqlCmd, processLeaf, workUnitLeaf, inputStr, opNodes,
                        tvCtrlParameters, tabOrderID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        rlt = conn.QuerySQL(sqlCmd);
                        if (rlt != null && rlt.Rows.Count > 0)
                        {
                            DataRow dr = rlt.Rows[0];
                            errCode = Convert.ToInt32(dr["ErrCode"].ToString());
                            errText = dr["ErrText"].ToString();
                        }
                        else
                        {
                            errCode = -1;
                            errText = "校验函数没有返回校验结果！";
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                        return Json("");
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用失败：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    return Json("");
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }

        public IRAPJsonResult GetDataTableWithSQL(
            string sqlCmd,
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
                DataTable rlt = new DataTable("PrintData");

                #region 创建数据库调用参数组，并赋值
                WriteLog.Instance.Write(
                    string.Format("调用SQL命令[{0}]", sqlCmd),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        rlt = conn.QuerySQL(sqlCmd);
                        if (rlt != null)
                        {
                            errCode = 0;
                            errText = 
                                string.Format(
                                    "调用成功！获得 {0} 条记录", 
                                    (rlt as DataTable).Rows.Count);
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                        else
                        {
                            errCode = 99999;
                            errText = "未得到返回的结果集";
                            rlt = new DataTable("PrintData");
                        }
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用失败：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    return Json(rlt);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }
    }
}