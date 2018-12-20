using IRAPShared;

namespace IRAP.Entities.DPA
{
    [IRAPDB(TableName = "IRAPDPA..dpa_DBF_MO")]
    public class dpa_DBF_MO
    {
        public long PartitioningKey { get; set; }
        public long ImportID { get; set; }
        public string MOSource { get; set; }
        public string MOType { get; set; }
        public string MONumber { get; set; }
        public int MOLineNo { get; set; }
        public string MaterialCode { get; set; }
        public string Treasury { get; set; }
        public string Location { get; set; }
        public string LotNumber { get; set; }
        public decimal OrderQty { get; set; }
        public int ErrCode { get; set; }
        public string ErrText { get; set; }
    }
}
