using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    public class PortalLink
    {
        public int Ordinal { get; set; }

        public int PortalID { get; set; }

        public string PortalName { get; set; }

        public bool IsBSMode { get; set; }

        public int LanguageID { get; set; }

        public int ProgLanguageID { get; set; }

        public string Link { get; set; }

        public string KeyStrokeStream { get; set; }

        public PortalLink Clone()
        {
            return MemberwiseClone() as PortalLink;
        }
    }
}
