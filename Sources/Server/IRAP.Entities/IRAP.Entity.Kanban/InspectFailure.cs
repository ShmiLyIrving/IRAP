using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class InspectFailure
    {
        public string SupplierCode1 { get; set; }
        public int T104LeafID1 { get; set; }
        public string LotNumber1 { get; set; }
        public string StoreLocation { get; set; }
        public int T106LeafID { get; set; }
        public string SupplierCode0 { get; set; }
        public int T104LeafID0 { get; set; }
        public string LotNumber0 { get; set; }
        public string PartNumber { get; set; }
        public int T101LeafID { get; set; }
        public string FailureName { get; set; }
        public string FailureCode { get; set; }
        public int FailureLeaf { get; set; }
        public double YCoordinate { get; set; }
        public double XCoordinate { get; set; }
        public int SideFlag { get; set; }
        public string Symbol { get; set; }
        public int T110LeafID { get; set; }
        public int Ordinal { get; set; }

        public InspectFailure Clone()
        {
            InspectFailure rlt = MemberwiseClone() as InspectFailure;

            return rlt;
        }
    }
}