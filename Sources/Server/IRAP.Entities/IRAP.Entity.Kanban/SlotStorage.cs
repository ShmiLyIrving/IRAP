using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class SlotStorage
    {
        public int EstimatedLoss { get; set; }
        public int UnloadedStorage { get; set; }
        public string UnloadedSupplierCode { get; set; }
        public string UnloadedLotNumber { get; set; }
        public int StandbyStorage { get; set; }
        public string StandbySupplierCode { get; set; }
        public string StandbyLotNumber { get; set; }
        public int OnlineStorage { get; set; }
        public string OnlineSupplierCode { get; set; }
        public string OnlineLotNumber { get; set; }
        public string PartNumber { get; set; }
        public string SlotCode { get; set; }
        public int SlotLeaf { get; set; }
        public int SlotID { get; set; }
        public int Ordinal { get; set; }

        public SlotStorage Clone()
        {
            SlotStorage rlt = MemberwiseClone() as SlotStorage;

            return rlt;
        }
    }
}