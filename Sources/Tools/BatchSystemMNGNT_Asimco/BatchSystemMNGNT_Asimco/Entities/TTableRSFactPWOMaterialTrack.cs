using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace BatchSystemMNGNT_Asimco.Entities
{
    [IRAPDB(TableName = "IRAPMES..RSFact_PWOMaterialTrack")]
    public class TTableRSFactPWOMaterialTrack
    {
        [IRAPKey(IsKey = true)]
        public long FactID { get; set; }
        [IRAPKey(IsKey = true)]
        public long PartitioningKey { get; set; }
        public string WFInstanceID { get; set; }
        [IRAPKey(IsKey = true)]
        public int Ordinal { get; set; }
        public DateTime LoadTime { get; set; }
        public string SKUID { get; set; }
        public int T127LeafID { get; set; }
        public int T101LeafID { get; set; }
        public int T102LeafID { get; set; }
        public string MaterialCode { get; set; }
        public long QtyLoaded { get; set; }
        public int Scale { get; set; }
        public string UnitOfMeasure { get; set; }
        public long MaterialTrackID { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public string LotNumber { get; set; }
        public string MFGDate { get; set; }

        public TTableRSFactPWOMaterialTrack Clone()
        {
            return MemberwiseClone() as TTableRSFactPWOMaterialTrack;
        }
    }
}
