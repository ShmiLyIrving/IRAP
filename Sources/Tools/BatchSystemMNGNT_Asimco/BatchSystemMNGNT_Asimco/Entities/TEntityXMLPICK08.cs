using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;

namespace BatchSystemMNGNT_Asimco.Entities
{
    public class TEntityXMLPICK08 : IXMLNodeObject
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
        public string OrderType { get; set; }
        public string IssueType { get; set; }
        public string OrderNumber { get; set; }
        public string LineNumber { get; set; }
        public string ComponentLineType { get; set; }
        public string PointOfUseID { get; set; }
        public string OperationSequenceNumber { get; set; }
        public string ItemNumber { get; set; }
        public string Stockroom { get; set; }
        public string Bin { get; set; }
        public string LotNumber { get; set; }
        public string IssuedQuantity { get; set; }
        public string ResourceComponentPolicy { get; set; }
        public string QuantityType { get; set; }

        public string GetXMLString()
        {
            return IRAPXMLUtils.ObjectToXMLString(this, "Parameters", "Param");
        }
    }
}
