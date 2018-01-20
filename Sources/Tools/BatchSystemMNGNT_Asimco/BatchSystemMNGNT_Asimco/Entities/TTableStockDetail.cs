using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchSystemMNGNT_Asimco.Entities
{
    public class TTableStockDetail
    {
        public string ITEM { get; set; }
        public string ITEM_DESC { get; set; }
        public string STK_ROOM { get; set; }
        public string BIN { get; set; }
        public double QTY_BY_LOC { get; set; }
        public string LOT { get; set; }
        public DateTime MFG_DATE { get; set; }
        public int SafetyStockQuantity { get; set; }
    }
}
