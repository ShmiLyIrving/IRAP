using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.FVS
{
    public class PeriodAndonEvent
    {
        public int Ordinal { get; set; }
        public string EventType { get; set; }
        public long EventFactID { get; set; }
        public string Description { get; set; }
        public string CallTime { get; set; }
        public string RespondingTime { get; set; }
        public string ClosedTime { get; set; }

        public PeriodAndonEvent Clone()
        {
            return MemberwiseClone() as PeriodAndonEvent;
        }
    }
}
