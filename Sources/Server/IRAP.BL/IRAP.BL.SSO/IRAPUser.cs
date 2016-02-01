using System;
using System.Collections;
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
    public class IRAPUser : IRAPBLLBase
    {
        private static string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPUser()
        {
            WriteLog.Instance.WriteLogFileName = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public IRAPJsonResult sfn_PostLoginCMDs(
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<CMDString> datas = new List<CMDString>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(string.Format("调用函数 IRAP..sfn_PostLoginCMDs，参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAP..sfn_PostLoginCMDs(@SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<CMDString> lstDatas = conn.CallTableFunc<CMDString>(strSQL, paramList);
                        datas = lstDatas.ToList<CMDString>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_PostLoginCMDs 函数发生异常：{0}", error.Message);
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

        public IRAPJsonResult sfn_PostLogoutCMDs(
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<CMDString> datas = new List<CMDString>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(string.Format("调用函数 IRAP..sfn_PostLogoutCMDs，参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAP..sfn_PostLogoutCMDs(@SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<CMDString> lstDatas = conn.CallTableFunc<CMDString>(strSQL, paramList);
                        datas = lstDatas.ToList<CMDString>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_PostLogoutCMDs 函数发生异常：{0}", error.Message);
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
        /// 获取用户名及密码验证的结果（0-验证不通过；1-验证通过，则返回社区标识号0;>1-验证通过，返回社区标识号）
        /// </summary>
        /// <param name="userCode">用户代码</param>
        /// <param name="plainPWD">用户密码明码</param>
        /// <param name="veriCode">验证码，不需时传空串</param>
        /// <param name="stationID">验证站点或社区标识</param>
        public IRAPJsonResult sfn_UserPWDVerify(
            string userCode,
            string plainPWD,
            string veriCode,
            string stationID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@PlainPWD", DbType.String, plainPWD));
                paramList.Add(new IRAPProcParameter("@VeriCode", DbType.String, veriCode));
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_UserPWDVerify，参数：UserCode={0}|"+
                        "PlainPWD={1}|VeriCode={2}|StationID={3}",
                        userCode,
                        plainPWD,
                        veriCode,
                        stationID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        int rlt = (int)conn.CallScalarFunc("IRAP.dbo.sfn_UserPWDVerify", paramList);
                        errCode = 0;
                        errText = "调用成功！";
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP.dbo.sfn_UserPWDVerify 函数发生异常：{0}", error.Message);
                    return Json(0);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 申请系统登录标识 , 必要时也获取短信验证码
        /// </summary>
        /// <remarks>
        /// UserCode        string          用户代码
        /// StationID       string          站点标识/社区标识
        /// 输出
        /// SysLogID        long            系统登录标识
        /// SMSVeriCode     string          短信验证码
        /// </remarks>
        /// <param name="userCode">用户代码</param>
        /// <param name="stationID">站点标识/社区标识</param>
        public IRAPJsonResult ssp_GetSysLogID(
            string userCode,
            string stationID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@SMSVeriCode", DbType.String, ParameterDirection.Output, 10));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_GetSysLogID", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        Hashtable rlt = new Hashtable();
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                            {
                                rlt.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 ssp_GetSysLogID 函数发生异常：{0}", error.Message);
                    return Json(new Hashtable());
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 退出 IRAP 平台
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="userDiary">工作日志</param>
        public IRAPJsonResult ssp_Logout(
            int communityID,
            long sysLogID,
            string userDiary,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserDiary", DbType.String, userDiary));
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
                WriteLog.Instance.Write(string.Format("执行存储过程 IRAP..ssp_Logout，参数：" +
                        "CommunityID={0}|UserDiary={1}|SysLogID={2}",
                        communityID, userDiary, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_Logout", ref paramList);
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
                errText = string.Format("调用 IRAP..ssp_Logout 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public IRAPJsonResult ssp_ModiPWD(
            int communityID,
            string userCode,
            string oldPassword,
            string newPassword,
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
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@OldPWD", DbType.String, oldPassword));
                paramList.Add(new IRAPProcParameter("@NewPWD", DbType.String, newPassword));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAP..ssp_ModiPWD，参数：" +
                        "CommunityID={0}|UserCode={1}|OldPWD={2}|NewPWD={3}",
                        communityID, userCode, oldPassword, newPassword),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_ModiPWD", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;

                    return Json("");
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAP..ssp_ModiPWD 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 登录 IRAP 平台
        /// 1、校验用户名、用户密码、验证码集信息站点的合法性
        /// 2、校验通过时写系统登录日志，取得用户及站点的有关信息
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="plainPWD">登录密码</param>
        /// <param name="veriCode">验证码</param>
        /// <param name="stationID">站点标识</param>
        /// <param name="ipAddress">IP 地址</param>
        /// <param name="agencyLeaf">登录机构叶标识</param>
        /// <param name="roleLeaf">登录角色叶标识</param>
        /// <param name="sysLogID">系统登录标识（可预先获取）</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>
        /// [
        ///     UserName string: 用户姓名
        ///     NickName string: 用户昵称
        ///     SysLogID long: 系统登录标识
        ///     LanguageID int: 语言标识
        ///     OPHoneNo string: 办公电话
        ///     HPhoneNo string: 住宅电话
        ///     MPhoneNo string: 移动电话
        ///     AgencyID int: 机构标识
        ///     AgencyName string: 机构名称
        ///     HostName string: 主机名
        /// ]
        /// </returns>
        public IRAPJsonResult ssp_Login(
            string dbName,
            string userCode,
            string plainPWD,
            string veriCode,
            string stationID,
            string ipAddress,
            int agencyLeaf,
            int roleLeaf,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            string userName = "";
            string nickName = "";
            int languageID = 30;
            string oPhoneNo = "";
            string hPhoneNo = "";
            string mPhoneNo = "";
            int agencyID = 0;
            string hostName = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@DBName", DbType.String, dbName));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@PlainPWD", DbType.String, plainPWD));
                paramList.Add(new IRAPProcParameter("@VeriCode", DbType.String, veriCode));
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                paramList.Add(new IRAPProcParameter("@IPAddress", DbType.String, ipAddress));
                paramList.Add(new IRAPProcParameter("@AgencyLeaf", DbType.Int32, agencyLeaf));
                paramList.Add(new IRAPProcParameter("@RoleLeaf", DbType.Int32, roleLeaf));
                paramList.Add(new IRAPProcParameter("@UserName", DbType.String, ParameterDirection.Output, 40));
                paramList.Add(new IRAPProcParameter("@NickName", DbType.String, ParameterDirection.Output, 40));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, ParameterDirection.InputOutput, 8)
                {
                    Value = sysLogID,
                });
                paramList.Add(new IRAPProcParameter("@LanguageID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@OPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@HPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@MPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@AgencyID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@AgencyName", DbType.String, ParameterDirection.Output, 100));
                paramList.Add(new IRAPProcParameter("@HostName", DbType.String, ParameterDirection.Output, 30));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAP..ssp_Login，参数：" +
                        "DBName={0}|UserCode={1}|PlainPWD={2}|VeriCode={3}"+
                        "StationID={4}|IPAddress={5}|AgencyLeaf={6}|"+
                        "RoleLeaf={7}|SysLogID={8}",
                        dbName, userCode, plainPWD, veriCode, stationID, 
                        ipAddress, agencyLeaf, roleLeaf, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_Login", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", 
                            errCode, 
                            errText), 
                        strProcedureName);

                    Hashtable rtnParams = new Hashtable();
                    if (errCode == 0)
                    {
                        foreach (IRAPProcParameter param in paramList)
                        {
                            if (param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Output)
                            {
                                if (param.DbType == DbType.Int32 && param.Value == DBNull.Value)
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), 0);
                                else
                                    rtnParams.Add(param.ParameterName.Replace("@", ""), param.Value);
                            }
                        }
                    }

                    return Json(rtnParams);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAP..ssp_Login 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据员工身份识别卡获取用户信息
        /// </summary>
        /// <param name="communityID">社区标识号</param>
        /// <param name="cardNo">用户 ID 卡号</param>
        /// <returns>UserInfo</returns>
        public IRAPJsonResult sfn_GetInfo_UserFromIDCode(int communityID, string cardNo, out int errCode, out string errText)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                UserInfo data = new UserInfo();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@CardNo", DbType.String, cardNo));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetInfo_UserFromIDCode，"+
                        "参数：CommunityID={0}|CardNo={1}",
                        communityID, cardNo),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAP..sfn_GetInfo_UserFromIDCode(" +
                            "@CommunityID, @CardNo)";

                        IList<UserInfo> lstDatas = conn.CallTableFunc<UserInfo>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        }
                        else
                        {
                            errCode = 99001;
                            errText = string.Format("没有[{0}]的用户信息", cardNo);
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_PostLoginCMDs 函数发生异常：{0}", error.Message);
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

        /// <summary>
        /// 根据用户 ID 卡号，获取用户名
        /// </summary>
        public IRAPJsonResult sfn_GetUserCodeFromIDCard(int communityID, string cardNo, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult sfn_UserAgencies(int communityID, string userCode, out int errCode, out string errText)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<AgencyInfo> datas = new List<AgencyInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_UserAgencies，" +
                        "参数：CommunityID={0}|UserCode={1}",
                        communityID, userCode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_UserAgencies(" +
                            "@CommunityID, @UserCode)";

                        IList<AgencyInfo> lstDatas = conn.CallTableFunc<AgencyInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<AgencyInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_UserAgencies 函数发生异常：{0}", error.Message);
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

        public IRAPJsonResult sfn_UserRoles(int communityID, string userCode, out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<RoleInfo> datas = new List<RoleInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_UserRoles，" +
                        "参数：CommunityID={0}|UserCode={1}",
                        communityID, userCode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_UserRoles(" +
                            "@CommunityID, @UserCode)";

                        IList<RoleInfo> lstDatas = conn.CallTableFunc<RoleInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<RoleInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_UserRoles 函数发生异常：{0}", error.Message);
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

        public void ssp_SetPWD(string userCode, string userPWD, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }
    }
}