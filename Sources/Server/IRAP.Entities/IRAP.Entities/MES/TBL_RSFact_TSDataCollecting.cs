using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MES
{
    [IRAPDB(TableName = "IRAPMES..RSFact_TSDataCollecting")]
    public class TBL_RSFact_TSDataCollecting
    {
        [IRAPKey()]
        public long FactID { get; set; }
        [IRAPKey()]
        public long PartitionPolicy { get; set; }
        public string WFInstanceID { get; set; }
        [IRAPKey()]
        public int Ordinal { get; set; }
        public int T110LeafID { get; set; }
        public int T101LeafID { get; set; }
        public int T118LeafID { get; set; }
        public int T119LeafID { get; set; }
        public int T216LeafID { get; set; }
        public int T183LeafID { get; set; }
        public int T184LeafID { get; set; }
        public int CntDefect { get; set; }
        public long MaterialTrackID0 { get; set; }
        public long MaterialTrackID1 { get; set; }
        public string TrackRef { get; set; }
    }
}
