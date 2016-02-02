using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

using IRAP.Entity.SSO;
using IRAP.Global;
using IRAP.WCF.Client;

namespace IRAP.WCF.Client.Method
{
    public class IRAPUserClient
    {
        private static IRAPUserClient _instance = null;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IRAPUserClient()
        {
        }

        public static IRAPUserClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPUserClient();
                return _instance;
            }
        }

        /// <summary>
        /// 返回指定信息站点的系统登录信息（适合无登录的展现系统）
        /// </summary>
        /// <param name="stationID">站点标识</param>
        public void sfn_GetInfo_StationLogin(string stationID, ref StationLogin stationInfo, out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 Hashtable 中
                #endregion

                errCode = 0;
                errText = "";
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void sfn_PostLoginCMDs(
            long sysLogID, 
            ref List<CMDString> datas, 
            out int errCode, 
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_PostLoginCMDs，输入参数：" +
                        "SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPUser",
                        "sfn_PostLoginCMDs",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<CMDString>;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void sfn_PostLogoutCMDs(
            long sysLogID,
            ref List<CMDString> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_PostLoginCMDs，输入参数：" +
                        "SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPUser",
                        "sfn_PostLogoutCMDs",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        datas = rlt as List<CMDString>;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void sfn_UserAgencies(
            int communityID,
            string userCode,
            ref List<AgencyInfo> agencies,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                agencies.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("userCode", userCode);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_UserAgencies，输入参数：" +
                        "CommunityID={0}|UserCode={1}",
                        communityID,
                        userCode),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPUser",
                        "sfn_UserAgencies",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        agencies = rlt as List<AgencyInfo>;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 验证用户的登录口令是否正确
        /// </summary>
        public bool sfn_UserPWDVerify(
            string userCode,
            string password,
            string stationID,
            string veriCode,
            ref int communityID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("userCode", userCode);
                hashParams.Add("plainPWD", password);
                hashParams.Add("veriCode", veriCode);
                hashParams.Add("stationID", stationID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_UserPWDVerify，输入参数：" +
                        "UserCode={0}|Password={1}|StationID={2}|VeriCode={3}",
                        userCode,
                        "***",
                        stationID,
                        veriCode),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPUser",
                        "sfn_UserPWDVerify",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}，CommunityID={2}",
                            errCode,
                            errText,
                            (int)rlt),
                        strProcedureName);

                    if (errCode == 0)
                        communityID = (int)rlt;
                    else
                        communityID = 0;
                    return communityID != 0;
                }
                #endregion
            }
            catch (Exception error)
            {
                communityID = 0;
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                return false;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void sfn_UserRoles(
            int communityID,
            string userCode,
            ref List<RoleInfo> roles,
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
                roles.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("userCode", userCode);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 sfn_UserAgencies，输入参数：" +
                        "CommunityID={0}|UserCode={1}",
                        communityID,
                        userCode),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPUser",
                        "sfn_UserRoles",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        roles = rlt as List<RoleInfo>;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 申请系统登录标识，必要时也获取短信验证码
        /// </summary>
        /// <param name="userCode">用户代码</param>
        /// <param name="stationID">站点标识/社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="smsVeriCode">短信验证码</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void ssp_GetSysLogID(
            string userCode,
            string stationID,
            out long sysLogID,
            out string smsVeriCode,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            sysLogID = 0;
            smsVeriCode = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("stationID", stationID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ssp_GetSysLogID，输入参数：" +
                            "UserCode={0}|StationID={1}",
                            userCode, stationID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPUser",
                        "ssp_GetSysLogID",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    if (errCode == 0)
                    {
                        if (rlt is Hashtable)
                        {
                            Hashtable rltHash = (Hashtable)rlt;
                            try
                            {
                                HashtableTools.Instance.GetValue(rltHash, "SysLogID", out sysLogID);
                                HashtableTools.Instance.GetValue(rltHash, "SMSVeriCode", out smsVeriCode);
                            }
                            catch (Exception error)
                            {
                                errCode = -1003;
                                errText = error.Message;
                                WriteLog.Instance.Write(errText, strProcedureName);
                                return;
                            }
                        }
                        else
                        {
                            errCode = -1002;
                            errText = "应用服务 ssp_GetSysLogID 返回的不是 Hashtable！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
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
        /// <param name="userName">用户姓名</param>
        /// <param name="nickName">用户昵称</param>
        /// <param name="sysLogID">系统登录标识（可预先获取）</param>
        /// <param name="languageID">语言标识</param>
        /// <param name="oPhoneNo">办公电话</param>
        /// <param name="hPhoneNo">住宅电话</param>
        /// <param name="mPhoneNo">移动电话</param>
        /// <param name="agencyID">机构标识</param>
        /// <param name="agencyName">机构名称</param>
        /// <param name="hostName">主机名</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void ssp_Login(
            string dbName,
            string userCode,
            string plainPWD,
            string veriCode,
            string stationID,
            string ipAddress,
            int agencyLeaf,
            int roleLeaf,
            out string userName,
            out string nickName,
            ref long sysLogID,
            out int languageID,
            out string oPhoneNo,
            out string hPhoneNo,
            out string mPhoneNo,
            out int agencyID,
            out string agencyName,
            out string hostName,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            userName = "";
            nickName = "";
            languageID = 0;
            oPhoneNo = "";
            hPhoneNo = "";
            mPhoneNo = "";
            agencyID = 0;
            agencyName = "";
            hostName = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("dbName", dbName);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("plainPWD", plainPWD);
                    hashParams.Add("veriCode", veriCode);
                    hashParams.Add("stationID", stationID);
                    hashParams.Add("ipAddress", ipAddress);
                    hashParams.Add("agencyLeaf", agencyLeaf);
                    hashParams.Add("roleLeaf", roleLeaf);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ssp_Login，输入参数：" +
                            "DBName={0}|UserCode={1}|PlainPWD={2}|"+
                            "VeriCode={3}|StationID={4}|IPAddress={5}|"+
                            "AgencyLeaf={6}|RoleLeaf={7}|SysLogID={8}",
                            dbName, userCode, plainPWD, veriCode, stationID,
                            ipAddress, agencyLeaf, roleLeaf, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPUser",
                        "ssp_Login",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    if (errCode == 0)
                    {
                        if (rlt is Hashtable)
                        {
                            Hashtable rltHash = (Hashtable)rlt;

                            #region 取返回值
                            try
                            {
                                HashtableTools.Instance.GetValue(rltHash, "UserName", out userName);
                                HashtableTools.Instance.GetValue(rltHash, "NickName", out nickName);
                                HashtableTools.Instance.GetValue(rltHash, "SysLogID", out sysLogID);
                                HashtableTools.Instance.GetValue(rltHash, "LanguageID", out languageID);
                                HashtableTools.Instance.GetValue(rltHash, "OPhoneNo", out oPhoneNo);
                                HashtableTools.Instance.GetValue(rltHash, "HPhoneNo", out hPhoneNo);
                                HashtableTools.Instance.GetValue(rltHash, "MPhoneNo", out mPhoneNo);
                                HashtableTools.Instance.GetValue(rltHash, "AgencyID", out agencyID);
                                HashtableTools.Instance.GetValue(rltHash, "AgencyName", out agencyName);
                                HashtableTools.Instance.GetValue(rltHash, "HostName", out hostName);
                                WriteLog.Instance.Write(
                                    string.Format(
                                        "输出参数：UserName={0}|NickName={1}|SysLogID={2}|" +
                                        "LanguageID={3}|OPhoneNo={4}|HPhoneNo={5}|MPhoneNo={6}|" +
                                        "AgencyID={7}|AgencyName={8}|HostName={9}",
                                        userName, nickName, sysLogID, languageID, oPhoneNo,
                                        hPhoneNo, mPhoneNo, agencyID, agencyName, hostName),
                                    strProcedureName);
                            }
                            catch (Exception error)
                            {
                                errCode = -1003;
                                errText = error.Message;
                                WriteLog.Instance.Write(errText, strProcedureName);
                                return;
                            }
                            #endregion
                        }
                        else
                        {
                            errCode = -1002;
                            errText = "应用服务 ssp_GetSysLogID 返回的不是 Hashtable！";
                            WriteLog.Instance.Write(errText, strProcedureName);
                        }
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 登录用户修改登录密码
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="oldPWD">原登录密码</param>
        /// <param name="newPWD">新登录密码</param>
        public void ssp_ModiPWD(int communityID, string userCode, string oldPWD, string newPWD, out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("oldPassword", oldPWD);
                    hashParams.Add("newPassword", newPWD);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ssp_ModiPWD，输入参数：" +
                            "CommunityID={0}|UserCode={1}|OldPWD={2}|"+
                            "NewPWD={3}",
                            communityID, userCode, oldPWD, newPWD),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPUser",
                        "ssp_ModiPWD",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
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
        public void ssp_Logout(int communityID, long sysLogID, string userDiary, out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("sysLogID", sysLogID);
                    hashParams.Add("userDiary", userDiary);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ssp_Logout，输入参数：" +
                            "CommunityID={0}|SysLogID={1}|UserDiary={2}",
                            communityID, sysLogID, userDiary),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.SSO.dll",
                        "IRAP.BL.SSO.IRAPUser",
                        "ssp_Logout",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
