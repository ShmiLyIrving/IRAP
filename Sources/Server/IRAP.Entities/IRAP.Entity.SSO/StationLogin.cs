using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    /// <summary>
    /// 站点的系统登录信息
    /// </summary>
    public class StationLogin
    {
        /// <summary>
        /// 系统登录标识，0-该站点尚无登录信息
        /// </summary>
        public long SysLogID
        {
            get; set;
        }

        /// <summary>
        /// 机构叶标识
        /// </summary>
        public int AgencyLeaf
        {
            get; set;
        }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string AgencyName
        {
            get; set;
        }

        /// <summary>
        /// 社区标识，请保存为 Session 变量以备用
        /// </summary>
        public int CommunityID
        {
            get; set;
        }

        /// <summary>
        /// 错误信息文本
        /// </summary>
        public string ErrText
        {
            get; set;
        }

        /// <summary>
        /// 站点主机名
        /// </summary>
        public string HostName
        {
            get; set;
        }

        /// <summary>
        /// 站点 IP 地址
        /// </summary>
        public string IPAddress
        {
            get; set;
        }

        /// <summary>
        /// 语言标识
        /// </summary>
        public int LanguageID
        {
            get; set;
        }

        /// <summary>
        /// 角色叶标识
        /// </summary>
        public int RoleLeaf
        {
            get; set;
        }


        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get; set;
        }


        /// <summary>
        /// 站点组标识
        /// </summary>
        public int StationGroupID
        {
            get; set;
        }


        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode
        {
            get; set;
        }


        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get; set;
        }


        public StationLogin Clone()
        {
            return MemberwiseClone() as StationLogin;
        }
    }
}