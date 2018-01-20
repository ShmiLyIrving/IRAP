using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;

namespace BatchSystemMNGNT_Asimco.Entities
{
    public class TEntityXMLIMTR01 : IXMLNodeObject
    {
        public string AgencyLeaf { get; set; }
        public string SysLogID { get; set; }
        public string StationID { get; set; }
        public string RoleLeaf { get; set; }
        public string CommunityID { get; set; }
        public string UserCode { get; set; }
        public string ExCode { get; set; }
        public string UserID { get; set; }
        public string PassWord { get; set; }
        public string ItemNumber { get; set; }
        public string StockroomFrom { get; set; }
        public string BinFrom { get; set; }
        public string InventoryCategoryFrom { get; set; }
        public string LotNumberFrom { get; set; }
        public string InventoryQuantity { get; set; }
        public string StockroomTo { get; set; }
        public string BinTo { get; set; }
        public string InventoryCategoryTo { get; set; }
        public string LotNumberTo { get; set; }
        public string DocumentNumber { get; set; }
        public string ItemLotReceiptWindow { get; set; }
        public string LotIdentifier { get; set; }

        public string GetXMLString()
        {
            return IRAPXMLUtils.ObjectToXMLString(this, "Parameters", "Param");
        }
    }
}
