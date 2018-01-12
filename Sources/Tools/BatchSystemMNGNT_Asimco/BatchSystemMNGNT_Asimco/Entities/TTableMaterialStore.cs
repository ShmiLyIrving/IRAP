using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace BatchSystemMNGNT_Asimco.Entities
{
    [IRAPDB(TableName = "IRAPRIMCS..utb_MaterialStore")]
    public class TTableMaterialStore
    {
        private int leaf03 = 0;

        [IRAPKey(IsKey = true)]
        public string SKUID { get; set; }
        [IRAPKey(IsKey = true)]
        public long PartitioningKey { get; set; }
        public int Leaf01 { get; set; }
        [IRAPKey(IsKey = true)]
        public int Leaf02 { get; set; }
        public int Leaf03
        {
            get { return leaf03; }
            set
            {
                leaf03 = value;
                TTableMDM058 bin =
                    TStorageLocations.Instance.GetStorageLocationWithLeafID(leaf03);
                StorageBin = bin.NodeName;
            }
        }
        public int Leaf04 { get; set; }
        public int Leaf05 { get; set; }
        public int Leaf06 { get; set; }
        public int Leaf07 { get; set; }
        public int Leaf08 { get; set; }
        public DateTime MFGDate { get; set; }
        public string LotNumber { get; set; }
        public string RecvBatchNo { get; set; }
        public string SerialNumber { get; set; }
        public DateTime MoveInTime { get; set; }
        public string ReceiveDate { get; set; }
        public DateTime ShelfLifeEndDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
        public DateTime VMEndDate { get; set; }
        public int SKUStatus { get; set; }
        public long MaterialTrackID { get; set; }
        public long LockedByFactID { get; set; }
        public long QtyInStore { get; set; }
        public long QtyReserved { get; set; }
        public int QtyScale { get; set; }
        public long AmtInStore { get; set; }
        public int AmtScale { get; set; }
        public int SKULength { get; set; }
        public int SKUWidth { get; set; }
        public int SKUHeight { get; set; }
        public long ASNTransactNo { get; set; }
        public long IQCTransactNo { get; set; }
        public long LastTransactNo { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public string StorageBin { get; set; }
    }
}
