using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.SCES
{
    public class ReprintPWO
    {
        public string PWONo { get; set; }
        public string T134Name { get; set; }
        public string PlannedStartDate { get; set; }
        public string PlannedCloseDate { get; set; }
        public string MONumber { get; set; }
        public int MOLineNo { get; set; }
        public long PlannedQuantity { get; set; }
        public string ProductNo { get; set; }
        public string ProductDesc { get; set; }

        public string LotNumber { get; set; }

        public string T173Code { get; set; }
        public string T173Name { get; set; }
        public string AtStoreLocCode { get; set; }
        public string DstWorkShopCode { get; set; }
        public string DstWorkShopDesc { get; set; }
        public string SuggestedQuantityToPick { get; set; }
        public string UnitOfMeasure { get; set; }
        public string T131Code { get; set; }
        public string ActualQtyDecompose { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDesc { get; set; }
        public string ActualQuantityToDeliver { get; set; }
        public string DstT106Code { get; set; }
    }
}
