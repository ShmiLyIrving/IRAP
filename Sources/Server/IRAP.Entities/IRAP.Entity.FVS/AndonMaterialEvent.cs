using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class AndonMaterialEvent
    {
        public int Ordinal { get; set; }
        public string CallTime { get; set; }
        public string ProductionLine { get; set; }
        public string MaterialType { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public int LineSideStock { get; set; }
        public int QtyCalled { get; set; }
        public bool ProductionStopped { get; set; }
        public string TimeElapsed { get; set; }
        public string DueTime { get; set; }

        public AndonMaterialEvent Clone()
        {
            AndonMaterialEvent rlt = MemberwiseClone() as AndonMaterialEvent;

            return rlt;
        }
    }
}