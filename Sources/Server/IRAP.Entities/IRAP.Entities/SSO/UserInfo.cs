using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.SSO
{
    /// <summary>
    /// 根据员工身份识别卡获取用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 机构名称
        /// </summary>
        public string AgencyName { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 先生/女士
        /// </summary>
        public string UserGender { get; set; }

        public UserInfo Clone()
        {
            return this.MemberwiseClone() as UserInfo;
        }
    }
}
