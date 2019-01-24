using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAP_MaterialRequestImport
{
    public class TAgencyInfo
    {
        public int AgencyID { get; set; }
        public string AgencyCode { get; set; }
        public int AgencyLeaf { get; set; }
        public string AgencyName { get; set; }

        public override string ToString()
        {
            return AgencyName;
        }

        public TAgencyInfo Clone()
        {
            TAgencyInfo rlt = MemberwiseClone() as TAgencyInfo;

            return rlt;
        }
    }
}
