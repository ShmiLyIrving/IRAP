using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPShared;
using IRAPORM;
using IRAP.Entity.FVS;
using IRAP.Entities.FVS;

namespace IRAP.BL.FVS
{
    public class AndonEventKanban : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public AndonEventKanban()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetAndonEventKanban_BMR(
            int communityID,
            string t134ClickStream,
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
                List<AndonEventKanbanBMR> datas = new List<AndonEventKanbanBMR>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134ClickStream", DbType.String, t134ClickStream));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetAndonEventKanban_BMR，" +
                        "参数：CommunityID={0}|T134ClickStream={1}|SysLogID={2}",
                        communityID, t134ClickStream, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetAndonEventKanban_BMR(" +
                            "@CommunityID, @T134ClickStream, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<AndonEventKanbanBMR> lstDatas =
                            conn.CallTableFunc<AndonEventKanbanBMR>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEventKanbanBMR>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetAndonEventKanban_BMR 函数发生异常：{0}", error.Message);
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

        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetAndonEventKanban_LSR(
            int communityID,
            string t134ClickStream,
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
                List<AndonEventKanbanLSR> datas = new List<AndonEventKanbanLSR>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134ClickStream", DbType.String, t134ClickStream));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetAndonEventKanban_LSR，" +
                        "参数：CommunityID={0}|T134ClickStream={1}|SysLogID={2}",
                        communityID, t134ClickStream, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetAndonEventKanban_LSR(" +
                            "@CommunityID, @T134ClickStream, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<AndonEventKanbanLSR> lstDatas =
                            conn.CallTableFunc<AndonEventKanbanLSR>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEventKanbanLSR>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetAndonEventKanban_LSR 函数发生异常：{0}", error.Message);
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

        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetAndonEventKanban_MDR(
            int communityID,
            string t134ClickStream,
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
                List<AndonEventKanbanMDR> datas = new List<AndonEventKanbanMDR>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134ClickStream", DbType.String, t134ClickStream));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetAndonEventKanban_MDR，" +
                        "参数：CommunityID={0}|T134ClickStream={1}|SysLogID={2}",
                        communityID, t134ClickStream, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetAndonEventKanban_MDR(" +
                            "@CommunityID, @T134ClickStream, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<AndonEventKanbanMDR> lstDatas =
                            conn.CallTableFunc<AndonEventKanbanMDR>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEventKanbanMDR>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetAndonEventKanban_MDR 函数发生异常：{0}", error.Message);
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

        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetAndonEventKanban_QCR(
            int communityID,
            string t134ClickStream,
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
                List<AndonEventKanbanQCR> datas = new List<AndonEventKanbanQCR>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134ClickStream", DbType.String, t134ClickStream));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetAndonEventKanban_QCR，" +
                        "参数：CommunityID={0}|T134ClickStream={1}|SysLogID={2}",
                        communityID, t134ClickStream, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetAndonEventKanban_QCR(" +
                            "@CommunityID, @T134ClickStream, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<AndonEventKanbanQCR> lstDatas =
                            conn.CallTableFunc<AndonEventKanbanQCR>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEventKanbanQCR>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetAndonEventKanban_QCR 函数发生异常：{0}", error.Message);
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

        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetAndonEventKanban_SPR(
            int communityID,
            string t134ClickStream,
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
                List<AndonEventKanbanSPR> datas = new List<AndonEventKanbanSPR>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134ClickStream", DbType.String, t134ClickStream));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetAndonEventKanban_SPR，" +
                        "参数：CommunityID={0}|T134ClickStream={1}|SysLogID={2}",
                        communityID, t134ClickStream, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetAndonEventKanban_SPR(" +
                            "@CommunityID, @T134ClickStream, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<AndonEventKanbanSPR> lstDatas =
                            conn.CallTableFunc<AndonEventKanbanSPR>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEventKanbanSPR>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetAndonEventKanban_SPR 函数发生异常：{0}", error.Message);
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

        /// <param name="communityID">社区标识</param>
        /// <param name="t134ClickStream">产线目录树点击流</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetAndonEventKanban_TRR(
            int communityID,
            string t134ClickStream,
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
                List<AndonEventKanbanTRR> datas = new List<AndonEventKanbanTRR>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T134ClickStream", DbType.String, t134ClickStream));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetAndonEventKanban_TRR，" +
                        "参数：CommunityID={0}|T134ClickStream={1}|SysLogID={2}",
                        communityID, t134ClickStream, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetAndonEventKanban_TRR(" +
                            "@CommunityID, @T134ClickStream, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<AndonEventKanbanTRR> lstDatas =
                            conn.CallTableFunc<AndonEventKanbanTRR>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEventKanbanTRR>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetAndonEventKanban_TRR 函数发生异常：{0}", error.Message);
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
    }
}