using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MES.Tables
{
    /// <summary>
    /// 人工检查行集事实表
    /// </summary>
    [Serializable()]
    [IRAPDB(TableName = "IRAPMES..RSFact_Inspecting")]
    public class RSFact_Inspecting
    {
        public long FactID { get; set; }
        public long PartitionPolicy { get; set; }
        public string WFInstanceID { get; set; }
        public int Ordinal { get; set; }
        public int T101LeafID { get; set; }
        public int T110LeafID { get; set; }
        public int T118LeafID { get; set; }
        public int T216LeafID { get; set; }
        public int T183LeafID { get; set; }
        public int T184LeafID { get; set; }
        public int CntDefect { get; set; }
        public byte[] DefectImage { get; set; }

        public RSFact_Inspecting Clone()
        {
            return MemberwiseClone() as RSFact_Inspecting;
        }
    }
}
