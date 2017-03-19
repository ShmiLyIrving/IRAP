using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRAPShared;

namespace IRAP.Entities.MES
{
    [IRAPDB(TableName = "IRAPMES..RSFact_WIPScrapping")]
    public class TBL_RSFact_WIPScrapping
    {
        [IRAPKey()]
        public long FactID { get; set; }
        [IRAPKey()]
        public long PartitioningKey { get; set; }
        public string WFInstanceID { get; set; }
        [IRAPKey()]
        public int Ordinal { get; set; }
        public int T102LeafID { get; set; }
        public int T101LeafID { get; set; }
        public int T104LeafID { get; set; }
        public int T181LeafID { get; set; }
        public long MaterialTrackID { get; set; }
        public string LotNumber { get; set; }
        public bool BondedGoods { get; set; }
        public long QtyScrapped { get; set; }
        public int QtyScale { get; set; }
        public long AmtScrapped { get; set; }
        public int AmtScale { get; set; }
    }
}
