using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class FailureNature
    {
        public int Ordinal { get; set; }
        public int T183EntityID { get; set; }
        public int T183LeafID { get; set; }
        public string T183Code { get; set; }
        public string T183NodeName { get; set; }

        public FailureNature Clone()
        {
            return MemberwiseClone() as FailureNature;
        }
    }
}
