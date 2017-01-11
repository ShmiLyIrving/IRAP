using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.FVS
{
    public class PeriodStopEvent
    {
        public int Ordinal { get; set; }
        public long EventFactID { get; set; }
        public long AndonFactID { get; set; }
        public string Remark { get; set; }
        public string CallTime { get; set; }
        public string EndTime { get; set; }

        public PeriodStopEvent Clone()
        {
            return MemberwiseClone() as PeriodStopEvent;
        }
    }
}
