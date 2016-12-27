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
    }
}
