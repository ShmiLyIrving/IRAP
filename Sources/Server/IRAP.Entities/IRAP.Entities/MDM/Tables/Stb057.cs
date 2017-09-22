using IRAPShared;

namespace IRAP.Entities.MDM.Tables
{
    [IRAPDB(TableName = "IRAPMDM..stb057")]
    public class Stb057
    {
        [IRAPKey()]
        public long PartitioningKey { get; set; }
        public int TreeID { get; set; }
        [IRAPKey()]
        public int NodeID { get; set; }
        public string Code { get; set; }
        public int NameID { get; set; }
        public string NodeName { get; set; }
        public int Father { get; set; }
        public double UDFOrdinal { get; set; }
        public int NodeDepth { get; set; }
        public int NodeStatus { get; set; }
        public int CSTRoot { get; set; }
        public int IconID { get; set; }
    }
}
