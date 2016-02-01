using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;

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
                    paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                    paramList.Add(new IRAPProcParameter("@SystemID", DbType.Int32, systemID));
                    paramList.Add(new IRAPProcParameter("@MenuCacheID", DbType.Int32, menuCacheID));
                    paramList.Add(new IRAPProcParameter("@ProgLanguageID", DbType.Int32, progLanguageID));
                    paramList.Add(new IRAPProcParameter("@AvailableOnly", DbType.Boolean, availableOnly));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAP..sfn_AvailableCSFunctions，参数：" +
                            "CommunityID={0}|SystemID={1}|MenuCacheID={2}|ProgLanguageID={3}|AvailableOnly={4}",
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
                    paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                    paramList.Add(new IRAPProcParameter("@SystemID", DbType.Int32, systemID));
                    paramList.Add(new IRAPProcParameter("@MenuCacheID", DbType.Int32, menuCacheID));
                    paramList.Add(new IRAPProcParameter("@ProgLanguageID", DbType.Int32, progLanguageID));
                    paramList.Add(new IRAPProcParameter("@AvailableOnly", DbType.Boolean, availableOnly));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAP..sfn_AvailableCSMenus，参数：" +
                            "CommunityID={0}|SystemID={1}|MenuCacheID={2}|ProgLanguageID={3}|AvailableOnly={4}",
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
                    paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
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
                    paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portalCode"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>int PortalID</returns>
        public IRAPJsonResult sfn_GetID_Portal(string portalCode, out int errCode, out string errText)
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
                    paramList.Add(new IRAPProcParameter("@PortalCode", DbType.String, portalCode));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAP.dbo.sfn_GetID_Portal，参数：" +
                            "PortalCode={0}", portalCode),
                        strProcedureName);
                    #endregion

                    #region 执行数据库函数或存储过程
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        rlt = (int)conn.CallScalarFunc("IRAP.dbo.sfn_GetID_Portal", paramList);

                        errCode = 0;
                        errText = string.Format("调用成功，获得值： [{0}]", rlt);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP.dbo.sfn_GetID_Portal 时发生异常：{0}", error.Message);
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

        public IRAPJsonResult sfn_GetList_PortalLinks(int portalID, bool logonForMe, string myPlainPWD, long sysLogID, out int errCode, out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<PortalLink> datas = new List<PortalLink>();

                try
                {
                    #region 创建数据库调用参数组，并赋值
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@PortalID", DbType.Int32, portalID));
                    paramList.Add(new IRAPProcParameter("@LogonForMe", DbType.Boolean, logonForMe));
                    paramList.Add(new IRAPProcParameter("@MyPlainPassword", DbType.String, myPlainPWD));
                    paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAP..sfn_GetList_PortalLinks，参数：" +
                            "PortalID={0}|LogonForMe={1}|MyPlainPassword={2}|SysLogID={4}",
                            portalID, logonForMe, myPlainPWD, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行数据库函数或存储过程
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_GetList_PortalLinks(@ProtalID, " +
                            "@LogonForMe, @MyPlainPassword, @SysLogID)";

                        IList<PortalLink> lstDatas = conn.CallTableFunc<PortalLink>(strSQL, paramList);
                        datas = lstDatas.ToList<PortalLink>();

                        errCode = 0;
                        errText = string.Format("调用成功，共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_GetList_PortalLinks 时发生异常：{0}", error.Message);
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
        /// 获取社区级全局字串型参数清单
        /// 1、当传入社区标识为 0 时，返回平台全局共享字串型参数清单
        /// 2、当传入社区标识非 0 时，返回社区个性以及社区分享的平台字串型参数清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="languageID">语言标识：0-英文；30-简体中文；28=繁体中文</param>
        /// <param name="filterParamIDs">参数标识号</param>
        /// <returns></returns>
        public IRAPJsonResult sfn_IRAPStrParameters(int communityID, int languageID, string filterParamIDs, out int errCode, out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<StrParamInfo> datas = new List<StrParamInfo>();

                try
                {
                    #region 创建数据库调用参数组，并赋值
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                    paramList.Add(new IRAPProcParameter("@LanguageID", DbType.Int32, languageID));
                    WriteLog.Instance.Write(string.Format("执行函数 IRAP..sfn_IRAPStrParameters，参数：" +
                            "CommunityID={0}|LanguageID={1}|ParameterID={2}",
                            communityID, languageID, filterParamIDs),
                        strProcedureName);
                    #endregion

                    #region 执行数据库函数或存储过程
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_IRAPStrParameters(@CommunityID, "+
                            "@LanguageID)";
                        if (filterParamIDs != "")
                        {
                            strSQL += string.Format(" WHERE ParameterID IN ({0})", filterParamIDs);
                        }

                        IList<StrParamInfo> lstDatas = conn.CallTableFunc<StrParamInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<StrParamInfo>();

                        errCode = 0;
                        errText = string.Format("调用成功，共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_IRAPStrParameters 时发生异常：{0}", error.Message);
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
        /// 向数据库注册当前用户准备使用的子系统
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="systemID">系统标识</param>
        /// <param name="progLanguageID">编程语言标识</param>
        /// <param name="isBSMode">是否 B/S 方式</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>
        /// [ 
        ///     MenuCacheID int: 菜单缓冲区标识 
        /// ]
        /// </returns>
        public IRAPJsonResult ssp_OnSelectionASystem(int communityID, int systemID, int progLanguageID, bool isBSMode, long sysLogID, out int errCode, out string errText)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SystemID", DbType.Int32, systemID));
                paramList.Add(new IRAPProcParameter("@ProgLanguageID", DbType.Int32, progLanguageID));
                paramList.Add(new IRAPProcParameter("@IsBSMode", DbType.Boolean, isBSMode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@MenuCacheID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAP..ssp_OnSelectionASystem，输入参数：" +
                        "CommunityID={0}|SystemID={1}|ProgLanguageID={2}|" +
                        "IsBSMode={3}|SysLogID={4}",
                        communityID, systemID, progLanguageID, isBSMode,
                        sysLogID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_OnSelectionASystem", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                            {
                                rlt.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..ssp_OnSelectionASystem 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据输入参数描述的属性，记录运行的功能
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="menuItemID">点中的菜单项</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>
        /// [
        ///     ScenarioIndex int: 返回的应用情景
        ///     RefreshGUIOptions bool: 是否刷新界面选择
        /// ]
        /// </returns>
        public IRAPJsonResult ssp_RunAFunction(int communityID, long sysLogID, int menuItemID, out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@MenuItemID", DbType.Int32, menuItemID));
                paramList.Add(new IRAPProcParameter("@ScenarioInex", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@RefreshGUIOptions", DbType.Boolean, ParameterDirection.Output, 1));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAP..ssp_RunAFunction，输入参数：" +
                        "CommunityID={0}|SysLogID={1}|MenuItemID={2}",
                        communityID, sysLogID, menuItemID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_RunAFunction", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                            {
                                rlt.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..ssp_RunAFunction 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult sfn_GetInfo_Station(int communityID, long sysLogID, out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                StationInfo data = new StationInfo();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetInfo_Station，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAP..sfn_GetInfo_Station(" +
                            "@CommunityID, @SysLogID)";

                        IList<StationInfo> lstDatas = conn.CallTableFunc<StationInfo>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        }
                        else
                        {
                            errCode = 99001;
                            errText = string.Format("没有登录标识[{0}]的站点信息", sysLogID);
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_GetInfo_Station 函数发生异常：{0}", error.Message);
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
    }
}