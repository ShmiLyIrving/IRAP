using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAP_MaterialRequestImport
{
    public class TRoleInfo
    {
        public int RoleID { get; set; }
        public string RoleCode { get; set; }
        public int RoleLeaf { get; set; }
        public string RoleName { get; set; }

        public override string ToString()
        {
            return RoleName;
        }

        public TRoleInfo Clone()
        {
            return MemberwiseClone() as TRoleInfo;
        }
    }
}
