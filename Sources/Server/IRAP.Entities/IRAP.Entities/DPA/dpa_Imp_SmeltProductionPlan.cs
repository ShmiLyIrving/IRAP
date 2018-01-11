using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.DPA
{
    [IRAPDB(TableName = "IRAPDPA..dpa_Imp_SmeltProductionPlan")]
    public class dpa_Imp_SmeltProductionPlan
    {
        [IRAPKey(IsKey = true)]
        public long PartitioningKey { get; set; }
        [IRAPKey(IsKey = true)]
        public long ImportLogID { get; set; }
        public int UnixTime { get; set; }
        [IRAPKey(IsKey = true)]
        public int Ordinal { get; set; }
        public string ColName01 { get; set; }
        public string ColName02 { get; set; }
        public string ColName03 { get; set; }
        public string ColName04 { get; set; }
        public string ColName05 { get; set; }
        public string ColName06 { get; set; }
        public string ColName07 { get; set; }
        public string ColName08 { get; set; }
        public string ColName09 { get; set; }
        public string ColName10 { get; set; }
        public string ColName11 { get; set; }
        public int ErrCode { get; set; }
        public string ErrText { get; set; }
    }
}
