using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class ResponsibleResponderInfo
    {
        public int Ordinal { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string AgencyName { get; set; }
        public string RoleName { get; set; }

        public ResponsibleResponderInfo Clone()
        {
            ResponsibleResponderInfo rlt = MemberwiseClone() as ResponsibleResponderInfo;

            return rlt;
        }
    }
}