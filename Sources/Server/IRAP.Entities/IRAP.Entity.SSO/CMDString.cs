using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    public class CMDString
    {
        public int Ordinal { get; set; }
        public string CMD { get; set; }

        public CMDString Clone()
        {
            return MemberwiseClone() as CMDString;
        }
    }
}
