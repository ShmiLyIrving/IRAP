using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class FailureDuty
    {
        public int Ordinal { get; set; }
        public int T184EntityID { get; set; }
        public int T184LeafID { get; set; }
        public string T184Code { get; set; }
        public string T184NodeName { get; set; }

        public FailureDuty Clone()
        {
            return MemberwiseClone() as FailureDuty;
        }
    }
}
