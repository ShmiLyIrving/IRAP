using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    /// <summary>
    /// 角色信息
    /// </summary>
    public class RoleInfo
    {
        public int RoleID { get; set; }
        public string RoleCode { get; set; }
        public int RoleLeaf { get; set; }
        public string RoleName { get; set; }

        public RoleInfo Clone()
        {
            return MemberwiseClone() as RoleInfo;
        }
    }
}
