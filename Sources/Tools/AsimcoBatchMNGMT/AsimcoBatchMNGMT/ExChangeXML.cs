using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsimcoBatchMNGMT
{
    public class ExChangeXML
    {
        public long LinkedLogID
        { get; set; }
        public int ErrCode
        { get; set; }
        public string ErrText
        { get; set; }
        public bool Retried
        { get; set; }
        public Int64 LogID
        { get; set; }
        public int SysLogID
        { get; set; }
        public int PartitioningKey
        { get; set; }
        public string ExCode
        { get;set;  }
        public string UserCode
        { get; set; }
        public int AgencyLeaf
        { get; set; }
        public string StationID
        { get; set; }
        public int RoleLeaf
        { get; set; }
        public int CommunityID
        { get; set; }
        public string UserID
        { get; set; }
        public string PassWord
        { get; set; }
        public string LotNumberAssignmentPolicy
        { get; set; }
        public string LotNumberDefault
        { get; set; }
        public string PONumber
        { get; set; }
        public string ItemNumber
        { get; set; }
        public string POLineNumber
        { get; set; }
        public string POReceiptActionNumber
        { get; set; }
        public string POReceiptActionType
        { get; set; }
        public string POLineUM
        { get; set; }
        public string ReceiptQuantityMove1
        { get; set; }
        public int Stockroom1
        { get; set; }
        public string Bin1
        { get; set; }
        public string InventoryCategory1
        { get; set; }
        public string POLineType
        { get; set; }
        public string NewLot
        { get; set; }
        public string PromisedDate
        { get; set; }
        public string POReceiptDate
        { get; set; }
        public int StockroomFrom
        { get; set; }
        public string BinFrom
        { get; set; }
        public string InventoryCategoryFrom
        { get; set; }
        public string LotNumberFrom
        { get; set; }
        public string LotNumberTo
        { get; set; }
        public string VendorLotNumber
        { get; set; }
        public string FirstReceiptDate
        { get; set; }
        public string InventoryQuantity
        { get; set; }
        public int StockroomTo
        { get; set; }
        public string BinTo
        { get; set; }
        public string InventoryCategoryTo
        { get; set; }
        public string DocumentNumber
        { get; set; }
        public string ItemLotReceiptWindow
        { get; set; }
        public string ReceivingType
        { get; set; }
        public string LotIdentifier
        { get; set; }
        public string ProperTies
        { get; set; }
        public string MONumber
        { get; set; }
        public string MOLineNumber
        { get; set; }
        public string ReceiptQuantity
        { get; set; }
        public string MoveQuantity1
        { get; set; }
        public string InspectionCode1
        { get; set; }
        public string MOLineType
        { get; set; }
        public string IsNewLot
        { get; set; }
        public string LotNumber
        { get; set; }
        public string OrderType
        { get; set; }
        public string IssueType
        { get; set; }
        public string OrderNumber
        { get; set; }
        public string LineNumber
        { get; set; }
        public string ComponentLineType
        { get; set; }
        public string PointOfUseID
        { get; set; }
        public string OperationSequenceNumber
        { get; set; }
        public string Stockroom
        { get; set; }
        public string Bin
        { get; set; }
        public string IssueQuantity
        { get; set; }
        public string ResourceComponentPolicy
        { get; set; }
        public string QuantityType
        { get; set; }
        public string IssuedQuantity
        { get; set; }
        
        public string InventoryCategory
        { get; set; }
        public string ActionCode
        { get; set; }
        public string AdjustQuantity
        { get; set; }
        public string ItemUM
        { get; set; }
        public string InventoryOffsetMasterAccountNumber
        { get; set; }
        public string Reason
        { get; set; }
        public string InspectonCode1
        { get; set; }
        //ItemLotReceiptWindow="Y" LotIdentifier="E" ItemUM="KG" InventoryOffsetMasterAccountNumber="0800-000-143110" Reason="P" AdjustQuantity="5.700" ActionCode="+" DocumentNumber="0002314" 
        public override string ToString()
        {
            return LogID.ToString();
        }
        public ExChangeXML Clone()
        {
            ExChangeXML rlt = MemberwiseClone() as ExChangeXML;

            return rlt;
        }
    }

}

