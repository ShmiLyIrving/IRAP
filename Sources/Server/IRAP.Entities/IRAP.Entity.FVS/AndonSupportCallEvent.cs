using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class AndonSupportCallEvent
    {
        public int Ordinal { get; set; }
        public string CallTime { get; set; }
        public string ProductionLine { get; set; }
        public string CalledSupport { get; set; }
        public bool ProductionStopped { get; set; }
        public string TimeElapsed { get; set; }
        public string EventStatus { get; set; }

        public AndonSupportCallEvent Clone()
        {
            AndonSupportCallEvent rlt = MemberwiseClone() as AndonSupportCallEvent;

            return rlt;
        }
    }
}