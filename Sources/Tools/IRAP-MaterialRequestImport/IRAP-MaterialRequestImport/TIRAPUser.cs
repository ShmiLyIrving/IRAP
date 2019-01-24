using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;

using IRAP.Global;

namespace IRAP_MaterialRequestImport
{
    public class TIRAPUser : TStationUser
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static TIRAPUser _instance = null;

        public static TIRAPUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TIRAPUser();
                return _instance;
            }
        }

        private TAgencyInfo currentAgencyInfo = new TAgencyInfo();
        private TRoleInfo currentRoleInfo = new TRoleInfo();
        private List<TAgencyInfo> agencies = new List<TAgencyInfo>();
        private List<TRoleInfo> roles = new List<TRoleInfo>();

        private int communityID = 60006;
        private string hostName = "";
        private string hPhoneNo = "";
        private bool isGetLogoutDiary = false;
        private bool isPWDVerified = false;
        private bool isSubSystemSelected = false;
        private int languageID = 0;
        private string mPhoneNo = "";
        private string nickName = "";
        private string oPhoneNo = "";
        private bool refreshGUIOptions = false;
        private int scenarioIndex = 0;
        private long sysLogID = 0;
        private string systemList4Station = "";
        private string userDiary = "";
        private string userName = "";
        private string veriCode = "";

        private TIRAPUser() { }

        #region 属性

        /// <summary>
        /// 用户社区标识
        /// </summary>
        public int CommunityID
        {
            get { return communityID; }
            set { communityID = value; }
        }

        /// <summary>
        /// 当前用户的登录机构
        /// </summary>
        public TAgencyInfo Agency
        {
            get { return currentAgencyInfo; }
        }

        /// <summary>
        /// 当前用户在登录时可选的机构列表
        /// </summary>
        public List<TAgencyInfo> AvailableAgencies
        {
            get { return agencies; }
        }
        /// <summary>
        /// 当前用户在登录时可选的角色列表
        /// </summary>
        public List<TRoleInfo> AvailableRoles
        {
            get { return roles; }
        }
        /// <summary>
        /// 主机名称
        /// </summary>
        public string HostName
        {
            get { return hostName; }
        }
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string HPhoneNo
        {
            get { return hPhoneNo; }
        }
        /// <summary>
        /// 是否需要用户在注销时输入日志
        /// </summary>
        public bool IsGetLogoutDiary
        {
            get { return isGetLogoutDiary; }
        }
        /// <summary>
        /// 是否已经通过用户登录密码验证
        /// </summary>
        public bool IsPWDVerified
        {
            get { return isPWDVerified; }
        }
        /// <summary>
        /// 是否已经选择子系统
        /// </summary>
        public bool IsSubSystemSelected
        {
            get { return isSubSystemSelected; }
        }
        /// <summary>
        /// 语言标识
        /// </summary>
        public int LanguageID
        {
            get { return languageID; }
        }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string MPhoneNo
        {
            get { return mPhoneNo; }
        }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName
        {
            get { return nickName; }
        }
        /// <summary>
        /// 办公室电话
        /// </summary>
        public string OPhoneNo
        {
            get { return oPhoneNo; }
        }
        /// <summary>
        /// 用户登录密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set
            {
                string strProcedureName = string.Format(
                    format: "{0}.{1}",
                    arg0: className,
                    arg1: MethodBase.GetCurrentMethod().Name);

                if (!isLogon)
                {
                    if (value.Trim() != "")
                    {
                        WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                        try
                        {
                            int errCode = 0;
                            string errText = "";

                            isPWDVerified =
                                TDBHelper.Instance.sfn_UserPWDVerify(
                                    userCode,
                                    value,
                                    veriCode,
                                    out errCode,
                                    out errText);
                            WriteLog.Instance.Write(
                                string.Format(
                                    "({0}){1}",
                                    errCode,
                                    errText),
                                strProcedureName);

                            if (isPWDVerified)
                            {
                                password = value;

                                string strCFGFileName =
                                    $"{AppDomain.CurrentDomain.BaseDirectory}\\IRAP.ini";
                                try
                                {
                                    communityID =
                                            Convert.ToInt32(
                                                IniFile.ReadString(
                                                    "IRAP",
                                                    "CummintyID",
                                                    "60006",
                                                    strCFGFileName));
                                }
                                catch { communityID = 60006; }

                                GetAvailableAgencies();
                                GetAvailableRoles();
                            }
                            else
                            {
                                password = "";

                                if (errCode == 0)
                                {
                                    throw new Exception("您输入的登录密码不正确！");
                                }
                                else
                                    throw new Exception(errText);
                            }
                        }
                        catch (Exception error)
                        {
                            isPWDVerified = false;
                            password = "";
                            WriteLog.Instance.Write(error.Message, strProcedureName);
                            WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                            if (error.Message.IndexOf("没有终结点在侦听", 0) >= 0)
                            {
                                throw new Exception("找不到应用服务器。可能：1、网络不通；2、应用服务已经停止。");
                            }
                            else
                                throw error;
                        }
                        finally
                        {
                            WriteLog.Instance.WriteEndSplitter(strProcedureName);
                        }
                    }
                }
                else
                {
                    string errText = "用户已经登录，不能设置登录密码";
                    WriteLog.Instance.Write(errText);
                    throw new Exception(errText);
                }
            }
        }
        /// <summary>
        /// 是否需要刷新界面上的选项一和选项二
        /// </summary>
        public bool RefreshGUIOptions
        {
            get { return refreshGUIOptions; }
            set { refreshGUIOptions = value; }
        }
        /// <summary>
        /// 当前用户的登录角色
        /// </summary>
        public TRoleInfo Role
        {
            get { return currentRoleInfo; }
        }
        /// <summary>
        /// 场景索引号
        /// </summary>
        public int ScenarioIndex
        {
            get { return scenarioIndex; }
        }
        /// <summary>
        /// 登录标识
        /// </summary>
        public long SysLogID
        {
            get { return sysLogID; }
            set { sysLogID = value; }
        }
        /// <summary>
        /// 当前站点可用子系统标识号流
        /// </summary>
        public string SystemList4Station
        {
            get { return systemList4Station; }
        }
        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode
        {
            get { return userCode; }
            set
            {
                if (!isLogon)
                {
                    userCode = value;
                    isPWDVerified = false;
                    currentAgencyInfo = new TAgencyInfo();
                    currentRoleInfo = new TRoleInfo();
                    agencies.Clear();
                    roles.Clear();
                }
                else
                {
                    throw new Exception("当前用户已经登录，不能更改登录用户号");
                }
            }
        }
        /// <summary>
        /// 日志
        /// </summary>
        public string UserDiary
        {
            get { return userDiary; }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName
        {
            get { return userName; }
        }
        /// <summary>
        /// 登录验证码
        /// </summary>
        public string VeriCode
        {
            get { return veriCode; }
            set { veriCode = value; }
        }
        #endregion

        #region 方法

        /// <summary>
        /// 用户修改登录密码
        /// </summary>
        public override bool ChangePassword(string oldPwd, string newPwd, string renewPwd)
        {
            //    string strProcedureName =
            //        string.Format(
            //            "{0}.{1}",
            //            className,
            //            MethodBase.GetCurrentMethod().Name);

            //    if (!isLogon)
            //    {
            //        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            //            throw new Exception("Can't change password while user has not been logged in.");
            //        else
            //            throw new Exception("用户还没有登录成功，不能修改密码！");
            //    }
            //    if (newPwd != renewPwd)
            //    {
            //        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            //            throw new Exception("The password must be kept consistent with the two input.");
            //        else
            //            throw new Exception("输入的新密码不一致，请重新输入新的密码，并且确保两次输入的密码一致！");
            //    }

            //    WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            //    try
            //    {
            //        int errCode = 0;
            //        string errText = "";

            //        IRAPUserClient.Instance.ssp_ModiPWD(
            //            communityID, userCode, oldPwd, newPwd, out errCode, out errText);
            //        WriteLog.Instance.Write(
            //            string.Format("({0}){1}", errCode, errText),
            //            strProcedureName);
            //        if (errCode == 0)
            return true;
            //        else
            //            throw new Exception(errText);
            //    }
            //    catch (Exception error)
            //    {
            //        WriteLog.Instance.Write(error.Message, strProcedureName);
            //        WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            //        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            //            throw new Exception(string.Format("Login password modification failed, {0}", error.Message));
            //        else
            //            throw new Exception(string.Format("登录密码修改失败，原因：{0}", error.Message));
            //    }
            //    finally
            //    {
            //        WriteLog.Instance.WriteEndSplitter(strProcedureName);
            //    }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        public override void Login()
        {
            string strProcedureName =
               $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                try
                {
                    #region 预先获取本次用户登录的标识号
                    int errCode = 0;
                    string errText = "";
                    sysLogID = 0;
                    veriCode = "";

                    WriteLog.Instance.Write("获取本次用户登录的标识号", strProcedureName);
                    sysLogID = 
                        TDBHelper.Instance.ssp_GetSysLogID(
                            userCode, 
                            macAddress, 
                            out veriCode,
                            out errCode, 
                            out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode != 0)
                    {
                        throw new Exception(
                            string.Format(
                                "({0}){1}",
                                errCode,
                                errText));
                    }
                    #endregion

                    #region 用户登录
                    WriteLog.Instance.Write("用户登录", strProcedureName);
                    int agencyLeaf = 0;
                    string agencyName = "";
                    TDBHelper.Instance.ssp_Login(
                        "IRAP", userCode, password, veriCode, macAddress, ipAddress,
                        currentAgencyInfo.AgencyLeaf, currentRoleInfo.RoleLeaf,
                        ref userName, ref nickName, ref sysLogID, ref languageID,
                        ref oPhoneNo, ref hPhoneNo, ref mPhoneNo, ref agencyLeaf,
                        ref agencyName, ref hostName, out errCode, out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                        isLogon = true;
                    else
                    {
                        isLogon = false;
                        throw new Exception(errText);
                    }
                    #endregion
                }
                catch (Exception error)
                {
                    isLogon = false;
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    throw error;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 用户注销
        /// </summary>
        public override void Logout()
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                WriteLog.Instance.Write("用户开始注销", strProcedureName);
                TDBHelper.Instance.ssp_Logout(
                    sysLogID,
                    userDiary,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                    isLogon = false;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取当前用户的可用机构列表
        /// </summary>
        private void GetAvailableAgencies()
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            agencies.Clear();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                WriteLog.Instance.Write("获取当前用户的可用机构列表", strProcedureName);
                agencies =
                    TDBHelper.Instance.sfn_UserAgencies(
                        userCode,
                        out errCode,
                        out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                throw error;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取当前用户的可用角色列表
        /// </summary>
        private void GetAvailableRoles()
        {
            string strProcedureName = 
               $"{className}.{MethodBase.GetCurrentMethod().Name}";

            roles.Clear();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                roles = 
                    TDBHelper.Instance.sfn_UserRoles(
                        userCode,
                        out errCode,
                        out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                throw error;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void RecordRunAFunction(int menuItemID)
        {
            string strProcedureName = string.Format(
                "{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                TDBHelper.Instance.ssp_RunAFunction(
                    sysLogID,
                    menuItemID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                    throw new Exception(errText);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                throw new Exception(
                    string.Format(
                        "记录当前运行功能时发生错误：{0}",
                        error.Message));
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 在可用机构列表中选择一个机构作为当前登录机构
        /// </summary>
        public void SelectAgency(int index)
        {
            if ((index < 0) || (index >= agencies.Count()))
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                    throw new Exception("Index out of range");
                else
                    throw new Exception("索引超出数组范围！");
            }
            else
            {
                currentAgencyInfo = agencies[index].Clone();

                //GetAvailableRoles(currentAgencyInfo.AgencyID);
            }
        }

        /// <summary>
        /// 在可用角色列表中选择一个角色作为当前登录角色
        /// </summary>
        public void SelectRole(int index)
        {
            if ((index < 0) || (index >= roles.Count()))
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                    throw new Exception("Index out of range");
                else
                    throw new Exception("索引超出数组范围！");
            }
            else
                currentRoleInfo = roles[index].Clone();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        public void UserLogin()
        {
            if (isLogon)
            {
                throw new Exception("当前用户已经登录，不需要再次登录！");
            }
            else
            {
                try
                {
                    frmLogin formLogin = new frmLogin();
                    formLogin.ShowDialog();
                }
                catch (Exception error)
                {
                    throw error;
                }
            }
        }

        #endregion
    }
}
