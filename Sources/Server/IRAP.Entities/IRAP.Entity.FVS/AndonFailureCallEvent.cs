using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class AndonFailureCallEvent
    {
        public int Ordinal { get; set; }
        public string CallTime { get; set; }
        public string ProductionLine { get; set; }
        public string FailuresCode { get; set; }
        public string FailuresName { get; set; }
        public string CalledSupport { get; set; }
        public bool ProductionStopped { get; set; }
        public string TimeElapsed { get; set; }
        public string EventStatus { get; set; }

        public AndonFailureCallEvent Clone()
        {
            AndonFailureCallEvent rlt = MemberwiseClone() as AndonFailureCallEvent;

            return rlt;
        }
    }
}