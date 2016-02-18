using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class AndonEquipRepairEvent
    {
        public int Ordinal { get; set; }
        public string CallingTime { get; set; }
        public string ProductionLine { get; set; }
        public string EquipmentCode { get; set; }
        public string EquipmentName { get; set; }
        public string CalledSupport { get; set; }
        public bool ProductionStopped { get; set; }
        public string TimeElapsed { get; set; }
        public string EventStatus { get; set; }

        public AndonEquipRepairEvent Clone()
        {
            AndonEquipRepairEvent rlt = MemberwiseClone() as AndonEquipRepairEvent;

            return rlt;
        }
    }
}