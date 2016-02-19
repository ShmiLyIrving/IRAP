using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class SysParam
    {
        public DateTime TimeUpdated { get; set; }
        public string UpdatedBy { get; set; }
        public string ParamValueStr { get; set; }
        public int ParamValue { get; set; }
        public int ParamNameID { get; set; }
        public int ParamID { get; set; }

        public SysParam Clone()
        {
            SysParam rlt = MemberwiseClone() as SysParam;

            return rlt;
        }
    }
}