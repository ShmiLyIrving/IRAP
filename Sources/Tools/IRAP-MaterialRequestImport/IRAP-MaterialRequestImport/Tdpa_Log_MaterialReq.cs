using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IRAPShared;

namespace IRAP_MaterialRequestImport
{
    [IRAPDB(TableName = "IRAPDPA..dpa_Log_MaterialReq")]
    public class Tdpa_Log_MaterialReq
    {
        [IRAPKey(IsKey = true)]
        public long PartitioningKey { get; set; }
        [IRAPKey(IsKey = true)]
        public long ImportID { get; set; }
        public DateTime ImportDate { get; set; }
        [IRAPKey(IsKey = true)]
        public int Ordinal { get; set; }
        public string MaterialCode { get; set; }
        public long ReqQty { get; set; }
        public string SrcLoc { get; set; }
        [IRAPKey(IsKey = true)]
        public string DstLoc { get; set; }
        public string RoutingCode { get; set; }
        public int T101LeafID { get; set; }
        public int T134LeafID { get; set; }
        public int T106SrcLeaf { get; set; }
        public int T106DstLeaf { get; set; }
        public int T192LeafID { get; set; }
        public string Remark { get; set; }
        public int ErrCode { get; set; }
        public string ErrText { get; set; }

        public Tdpa_Log_MaterialReq()
        {
            PartitioningKey = 0;
            ImportID = 0;
            ImportDate = DateTime.Now;
            Ordinal = 0;
            MaterialCode = "";
            ReqQty = 0;
            SrcLoc = "";
            DstLoc = "";
            RoutingCode = "";
            T101LeafID = 0;
            T134LeafID = 0;
            T106SrcLeaf = 0;
            T106DstLeaf = 0;
            T192LeafID = 0;
            Remark = "";
            ErrCode = -1;
            ErrText = "未校验";
        }
    }
}
