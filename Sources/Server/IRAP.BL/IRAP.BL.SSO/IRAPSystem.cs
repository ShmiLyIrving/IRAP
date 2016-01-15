using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAPShared;
using IRAPORM;
using IRAP.Entity.SSO;

namespace IRAP.BL.SSO
{
    public class IRAPSystem : IRAPBLLBase
    {
        private static string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPSystem()
        {
            WriteLog.Instance.WriteLogFileName = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="systemID">系统标识</param>
        /// <param name="menuCacheID">系统登录标识或菜单缓冲区标识的相反数</param>
        /// <param name="progLanguageID">编程语言标识</param>
        /// <param name="availableOnly">是否仅呈现可用菜单</param>
        public IRAPJsonResult sfn_AvailableCSFunctions(
            int communityID,
            int systemID,
            int menuCacheID,
            int progLanguageID,
            bool availableOnly,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<SystemMenuInfoButtonStyle> datas = new List<SystemMenuInfoButtonStyle>();

                try
                {
                    #region 创建数据库调用参数组，并赋值
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@CummunityID", DbType.Int32, communityID));
                    paramList.Add(new IRAPProcParameter("@SystemID", DbType.Int32, systemID));
                    paramList.Add(new IRAPProcParameter("@MenuCacheID", DbType.Int32, menuCacheID));
                    paramList.Add(new IRAPProcParameter("@ProgLanguageID", DbType.Int32, progLanguageID));
                    paramList.Add(new IRAPProcParameter("@AvailableOnly", DbType.Boolean, availableOnly));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAP..sfn_AvailableCSFunctions，参数：" +
                            "CommunityID={0}|SystemID={1}|MenuCacheID={2}|ProgLanguageID={4}|AvailableOnly={5}",
                            communityID, systemID, menuCacheID, progLanguageID, availableOnly),
                        strProcedureName);
                    #endregion

                    #region 执行数据库函数或存储过程
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_AvailableCSFunctions(@CommunityID, " +
                            "@SystemID, @MenuCacheID, @ProgLanguageID, @AvailableOnly) " +
                            "ORDER BY Ordinal";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<SystemMenuInfoButtonStyle> lstDatas = conn.CallTableFunc<SystemMenuInfoButtonStyle>(strSQL, paramList);
                        datas = lstDatas.ToList<SystemMenuInfoButtonStyle>();

                        errCode = 0;
                        errText = string.Format("调用成功，共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_AvailableCSFunctions 时发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取 CS 方式的系统菜单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="systemID">系统标识</param>
        /// <param name="menuCacheID">系统登录标识或菜单缓冲区标识的相反数</param>
        /// <param name="progLanguageID">编程语言标识</param>
        /// <param name="availableOnly">是否仅呈现可用菜单</param>
        public IRAPJsonResult sfn_AvailableCSMenus(
            int communityID,
            int systemID,
            int menuCacheID,
            int progLanguageID,
            bool availableOnly,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<SystemMenuInfoMenuStyle> datas = new List<SystemMenuInfoMenuStyle>();

                try
                {
                    #region 创建数据库调用参数组，并赋值
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@CummunityID", DbType.Int32, communityID));
                    paramList.Add(new IRAPProcParameter("@SystemID", DbType.Int32, systemID));
                    paramList.Add(new IRAPProcParameter("@MenuCacheID", DbType.Int32, menuCacheID));
                    paramList.Add(new IRAPProcParameter("@ProgLanguageID", DbType.Int32, progLanguageID));
                    paramList.Add(new IRAPProcParameter("@AvailableOnly", DbType.Boolean, availableOnly));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAP..sfn_AvailableCSMenus，参数：" +
                            "CommunityID={0}|SystemID={1}|MenuCacheID={2}|ProgLanguageID={4}|AvailableOnly={5}",
                            communityID, systemID, menuCacheID, progLanguageID, availableOnly),
                        strProcedureName);
                    #endregion

                    #region 执行数据库函数或存储过程
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_AvailableCSMenus(@CommunityID, " +
                            "@SystemID, @MenuCacheID, @ProgLanguageID, @AvailableOnly) " +
                            "ORDER BY NodeDepth, Parent, Ordinal";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<SystemMenuInfoMenuStyle> lstDatas = conn.CallTableFunc<SystemMenuInfoMenuStyle>(strSQL, paramList);
                        datas = lstDatas.ToList<SystemMenuInfoMenuStyle>();

                        errCode = 0;
                        errText = string.Format("调用成功，共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_AvailableCSMenus 时发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取可用应用系统清单
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="sysLogID"></param>
        /// <param name="progLanguageID">编程语言标识</param>
        public IRAPJsonResult sfn_AvailableSystems(
            int communityID,
            int sysLogID,
            int progLanguageID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<SystemInfo> datas = new List<SystemInfo>();

                try
                {
                    #region 创建数据库调用参数组，并赋值
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@CummunityID", DbType.Int32, communityID));
                    paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                    paramList.Add(new IRAPProcParameter("@ProgLanguageID", DbType.Int32, progLanguageID));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAP..sfn_AvailableSystems，参数：" +
                            "CommunityID={0}|SysLogID={1}|ProgLanguageID={2}",
                            communityID, sysLogID, progLanguageID),
                        strProcedureName);
                    #endregion

                    #region 执行数据库函数或存储过程
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_AvailableSystems(@CommunityID, " +
                            "@SysLogID, @ProgLanguageID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<SystemInfo> lstDatas = conn.CallTableFunc<SystemInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<SystemInfo>();

                        errCode = 0;
                        errText = string.Format("调用成功，共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_AvailableSystems 时发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public IRAPJsonResult sfn_DefaultFunctionToRun(
            int communityID,
            int systemID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int rlt = 0;

                try
                {
                    #region 创建数据库调用参数组，并赋值
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@CummunityID", DbType.Int32, communityID));
                    paramList.Add(new IRAPProcParameter("@SystemID", DbType.Int32, systemID));
                    paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAP..sfn_DefaultFunctionToRun，参数：" +
                            "CommunityID={0}|SystemID={1}|SysLogID={2}",
                            communityID, systemID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行数据库函数或存储过程
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP.dbo.sfn_DefaultFunctionToRun(@CommunityID, " +
                            "@SystemID, @SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        rlt = (int)conn.CallScalarFunc("IRAP.dbo.sfn_DefaultFunctionToRun", paramList);

                        errCode = 0;
                        errText = string.Format("调用成功，获得值： [{0}]", rlt);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP.dbo.sfn_DefaultFunctionToRun 时发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}