using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.SSO;

namespace IRAP.Client.User
{
    public class IRAPUser : StationUser
    {
        private static string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static IRAPUser _instance = null;

        private IRAPUser()
        {
            throw new System.NotImplementedException();
        }

        public static IRAPUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPUser();
                return _instance;
            }
        }

        /// <summary>
        /// 用户社区标识
        /// </summary>
        public int CommunityID
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public AgencyInfo Agency
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public List<AgencyInfo> AvailableAgencies
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public List<RoleInfo> AvailableRoles
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string HostName
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string HPhoneNo
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public bool IsGetLogoutDiary
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public bool IsPWDVerified
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public bool IsSubSystemSelected
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int LanguageID
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string MPhoneNo
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string NickName
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string OPhoneNo
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                string strProcedureName = string.Format("{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

                if (!isLogon)
                {
                    if (value.Trim() != "")
                    {
                        WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                        try
                        {
                            int errCode = 0;
                            string errText = "";

                            IsPWDVerified = 
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 是否需要刷新界面上的选项一和选项二
        /// </summary>
        public bool RefreshGUIOptions
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public RoleInfo Role
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int ScenarioIndex
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public long SysLogID
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string SystemList4Station
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string UserCode
        {
            get { return UserCode; }
            set
            {
                if (!isLogon)
                    userCode = value;
                else
                    throw new Exception("当前用户已经登录，不能更改登录用户号");
            }
        }

        public string UserDiary
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string UserName
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public string VeriCode
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public override bool ChangePassword(string oldPWD, string newPWD, string renewPWD)
        {
            throw new NotImplementedException();
        }

        public override void Login()
        {
            throw new NotImplementedException();
        }

        public override void Logout()
        {
            throw new NotImplementedException();
        }

        private void GetAvailableAgencies()
        {
            throw new System.NotImplementedException();
        }

        private void GetAvailableRoles()
        {
            throw new System.NotImplementedException();
        }

        public void RecordRunAFunction(int menuItemID)
        {
            throw new System.NotImplementedException();
        }

        public void SelectAgency(int index)
        {
            throw new System.NotImplementedException();
        }

        public void SelectRole(int index)
        {
            throw new System.NotImplementedException();
        }

        public void UserLogin()
        {
            throw new System.NotImplementedException();
        }
    }
}