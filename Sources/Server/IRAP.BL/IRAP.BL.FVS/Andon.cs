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

namespace IRAP.BL.FVS
{
    public class Andon : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public Andon()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取可撤销的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="sysLogID">响应站点系统登录标识</param>
        public IRAPJsonResult ufn_GetList_AndonEventsToCancel(
            int communityID,
            string userCode,
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
                List<AndonEventInfo> datas = new List<AndonEventInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetList_AndonEventsToCancel，" +
                        "参数：CommunityID={0}|UserCode={1}|SysLogID={2}",
                        communityID, userCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetList_AndonEventsToCancel(" +
                            "@CommunityID, @UserCode, @SysLogID)";

                        IList<AndonEventInfo> lstDatas = conn.CallTableFunc<AndonEventInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEventInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetList_AndonEventsToCancel 函数发生异常：{0}", error.Message);
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
        /// 获取待关闭的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_AndonEventsToClose(
            int communityID, 
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
                List<AndonEventToClose> datas = new List<AndonEventToClose>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetList_AndonEventsToClose，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetList_AndonEventsToClose(" +
                            "@CommunityID, @SysLogID)";

                        IList<AndonEventToClose> lstDatas = 
                            conn.CallTableFunc<AndonEventToClose>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEventToClose>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetList_AndonEventsToClose 函数发生异常：{0}", error.Message);
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
        /// 获取本人已响应未关闭的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="sysLogID">响应站点系统登录标识</param>
        public IRAPJsonResult ufn_GetList_AndonEventsToForward(
            int communityID,
            string userCode,
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
                List<AndonEventInfo> datas = new List<AndonEventInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetList_AndonEventsToForward，" +
                        "参数：CommunityID={0}|UserCode={1}|SysLogID={2}",
                        communityID, userCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetList_AndonEventsToForward(" +
                            "@CommunityID, @UserCode, @SysLogID)";

                        IList<AndonEventInfo> lstDatas = conn.CallTableFunc<AndonEventInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonEventInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetList_AndonEventsToForward 函数发生异常：{0}", error.Message);
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
        /// 获取待响应的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="sysLogID">响应站点系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_AndonEventsToRespond(
            int communityID,
            string userCode,
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
                List<AndonRspEventInfo> datas = new List<AndonRspEventInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetList_AndonEventsToRespond，" +
                        "参数：CommunityID={0}|UserCode={1}|SysLogID={2}",
                        communityID, userCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetList_AndonEventsToRespond(" +
                            "@CommunityID, @UserCode, @SysLogID)";

                        IList<AndonRspEventInfo> lstDatas = conn.CallTableFunc<AndonRspEventInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonRspEventInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetList_AndonEventsToRespond 函数发生异常：{0}", error.Message);
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
        /// 获取当前站点绑定产线的安灯告警灯状态
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetList_AndonLightStatus(
            int communityID,
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
                List<AndonLightStatus> datas = new List<AndonLightStatus>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPFVS..ufn_GetList_AndonLightStatus，" +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPFVS..ufn_GetList_AndonLightStatus(" +
                            "@CommunityID, @SysLogID)" +
                            "ORDER BY Ordinal";

                        IList<AndonLightStatus> lstDatas =
                            conn.CallTableFunc<AndonLightStatus>(strSQL, paramList);
                        datas = lstDatas.ToList<AndonLightStatus>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAPFVS..ufn_GetList_AndonLightStatus 函数发生异常：{0}", error.Message);
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
        /// 安灯事件撤销
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="opID">业务操作标识</param>
        /// <param name="userCode">撤销人用户代码</param>
        /// <param name="veriCode">撤销授权码(短信)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_AndonEventCancel(
            int communityID,
            long eventFactID,
            int opID,
            string userCode,
            string veriCode,
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
                paramList.Add(new IRAPProcParameter("@EventFactID", DbType.Int64, eventFactID));
                paramList.Add(new IRAPProcParameter("@OpID", DbType.Int32, opID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@VeriCode", DbType.String, veriCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 " +
                        "IRAPFVS..usp_AndonEventCancel，参数：" +
                        "CommunityID={0}|EventFactID={1}|OpID={2}|UserCode={3}|" +
                        "VeriCode={4}|SysLogID={5}",
                        communityID, eventFactID, opID, userCode, veriCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPFVS..usp_AndonEventCancel", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    return Json("");
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPFVS..usp_AndonEventCancel 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件追加呼叫
        /// </summary>
        public IRAPJsonResult usp_AndonEventForwarding(
            int communityID,
            long eventFactID,
            int opID,
            int ordinal,
            string userCode,
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
                paramList.Add(new IRAPProcParameter("@EventFactID", DbType.Int64, eventFactID));
                paramList.Add(new IRAPProcParameter("@OpID", DbType.Int32, opID));
                paramList.Add(new IRAPProcParameter("@Ordinal", DbType.Int32, ordinal));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 " +
                        "IRAPFVS..usp_AndonEventForwarding，参数：" +
                        "CommunityID={0}|EventFactID={1}|OpID={2}|Ordinal={3}|" +
                        "UserCode={4}|SysLogID={5}",
                        communityID, eventFactID, opID, ordinal, userCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPFVS..usp_AndonEventForwarding", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    return Json("");
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPFVS..usp_AndonEventForwarding 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件撤销授权请求
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="eventID">申请授权事件标识(事实编号/交易号)</param>
        /// <param name="userCode">申请授权人用户代码</param>
        /// <param name="userName">申请授权人姓名</param>
        /// <param name="menuItemID">当前菜单项标识</param>
        /// <param name="t2LeafID">授权人角色叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_AuthorizationRequest(
            int communityID,
            long eventID,
            string userCode,
            string userName,
            int menuItemID,
            int t2LeafID,
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
                paramList.Add(new IRAPProcParameter("@EventID", DbType.Int64, eventID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@UserName", DbType.String, userName));
                paramList.Add(new IRAPProcParameter("@MenuItemID", DbType.Int32, menuItemID));
                paramList.Add(new IRAPProcParameter("@T2LeafID", DbType.Int32, t2LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 " +
                        "IRAPFVS..usp_AuthorizationRequest，参数：" +
                        "CommunityID={0}|EventID={1}|UserCode={2}|UserName={3}|" +
                        "MenuItemID={4}|T2LeafID={5}|SysLogID={6}",
                        communityID, eventID, userCode, userName, menuItemID,
                        t2LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPFVS..usp_AuthorizationRequest", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    return Json("");
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPFVS..usp_AuthorizationRequest 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 从产线触发安灯呼叫：
        /// ⒈ 呼叫产线设备的故障维修；
        /// ⒉ 呼叫产线的原辅材料及半成品配送；
        /// ⒊ 呼叫产线在制品的质量问题解决；
        /// ⒋ 呼叫产线设备的工装更换；
        /// ⒌ 呼叫产线安全问题解决；
        /// ⒍ 呼叫产线其他干系人现场支持
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="t179LeafID">安灯事件类型叶标识</param>
        /// <param name="t134LeafID">呼叫产线叶标识</param>
        /// <param name="t133LeafID">呼叫设备叶标识</param>
        /// <param name="objectTreeID">呼叫对象树标识</param>
        /// <param name="objectLeafID">呼叫对象叶标识</param>
        /// <param name="objectCode">呼叫对象代码</param>
        /// <param name="productionDown">是否已停产(0-未停产；1-已停产)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_SaveFact_AndonEventCallFromProductionLine(
            int communityID,
            long transactNo,
            long factID,
            int t179LeafID,
            int t134LeafID,
            int t133LeafID,
            int objectTreeID,
            int objectLeafID,
            string objectCode,
            bool productionDown,
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
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@T179LeafID", DbType.Int32, t179LeafID));
                paramList.Add(new IRAPProcParameter("@T134LeafID", DbType.Int32, t134LeafID));
                paramList.Add(new IRAPProcParameter("@T133LeafID", DbType.Int32, t133LeafID));
                paramList.Add(new IRAPProcParameter("@ObjectTreeID", DbType.Int32, objectTreeID));
                paramList.Add(new IRAPProcParameter("@ObjectLeafID", DbType.Int32, objectLeafID));
                paramList.Add(new IRAPProcParameter("@ObjectCode", DbType.String, objectCode));
                paramList.Add(new IRAPProcParameter("@ProductionDown", DbType.Boolean, productionDown));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 " +
                        "IRAPFVS..usp_SaveFact_AndonEventCallFromProductionLine，参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|T179LeafID={3}|" +
                        "T134LeafID={4}|T133LeafID={5}|ObjectTreeID={6}|ObjectLeafID={7}|" +
                        "ObjectCode={8}|ProductionDown={9}|SysLogID={10}",
                        communityID, transactNo, factID, t179LeafID, t134LeafID, t133LeafID,
                        objectTreeID, objectLeafID, objectCode, productionDown, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPFVS..usp_SaveFact_AndonEventCallFromProductionLine", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    return Json("");
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPFVS..usp_SaveFact_AndonEventCallFromProductionLine 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件关闭
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="opID">业务操作标识</param>
        /// <param name="userCode">关闭人用户代码</param>
        /// <param name="satisfactoryLevel">
        /// 满意度评价：
        /// 1-非常满意；
        /// 2-满意；
        /// 3-一般；
        /// 4-不满意
        /// </param>
        /// <param name="sysLogID">关闭站点系统登录标识</param>
        public IRAPJsonResult usp_SaveFact_AndonEventClose(
            int communityID, 
            long transactNo, 
            long factID, 
            long eventFactID, 
            int opID, 
            string userCode, 
            int satisfactoryLevel, 
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
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@EventFactID", DbType.Int64, eventFactID));
                paramList.Add(new IRAPProcParameter("@OpID", DbType.Int32, opID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@SatisfactoryLevel", DbType.Int32, satisfactoryLevel));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 " +
                        "IRAPFVS..usp_SaveFact_AndonEventClose，参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|EventFactID={3}|" +
                        "OpID={4}|UserCode={5}|SatisfactoryLevel={6}|SysLogID={7}",
                        communityID, transactNo, factID, eventFactID, opID,
                        userCode, satisfactoryLevel, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPFVS..usp_SaveFact_AndonEventClose", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    return Json("");
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPFVS..usp_SaveFact_AndonEventClose 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件现场响应
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="opID">业务操作标识</param>
        /// <param name="userCode">关闭人用户代码</param>
        /// <param name="sysLogID">关闭站点系统登录标识</param>
        public IRAPJsonResult usp_SaveFact_AndonEventOnSiteRespond(
            int communityID,
            long transactNo,
            long factID,
            long eventFactID,
            int opID,
            string userCode,
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
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@EventFactID", DbType.Int64, eventFactID));
                paramList.Add(new IRAPProcParameter("@OpID", DbType.Int32, opID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 " +
                        "IRAPFVS..usp_SaveFact_AndonEventOnSiteRespond，参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|EventFactID={3}|" +
                        "OpID={4}|UserCode={5}|SysLogID={6}",
                        communityID, transactNo, factID, eventFactID, opID,
                        userCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAPFVS..usp_SaveFact_AndonEventOnSiteRespond", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    return Json("");
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAPFVS..usp_SaveFact_AndonEventOnSiteRespond 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}