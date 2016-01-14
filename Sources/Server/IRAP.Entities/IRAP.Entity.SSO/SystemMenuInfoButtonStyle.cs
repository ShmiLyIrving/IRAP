using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    public class SystemMenuInfoButtonStyle : MenuInfo
    {
        /// <summary>
        /// 用户界面XML
        /// </summary>
        public string GUIXAML { get; set; }

        public new SystemMenuInfoButtonStyle Clone()
        {
            return MemberwiseClone() as SystemMenuInfoButtonStyle;
        }
    }
}
