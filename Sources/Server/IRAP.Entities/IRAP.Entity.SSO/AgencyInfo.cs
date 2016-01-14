using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    public class AgencyInfo
    {
        public int AgencyID { get; set; }
        public string AgencyCode { get; set; }
        public int AgencyLeaf { get; set; }
        public string AgencyName { get; set; }

        public override string ToString()
        {
            return AgencyName;
        }

        public AgencyInfo Clone()
        {
            AgencyInfo rlt = MemberwiseClone() as AgencyInfo;

            return rlt;
        }
    }
}
