using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    public class AndonPrdtLine
    {
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public int T134LeafID { get; set; }
        public string T134NodeName { get; set; }
        public int UDFOrdinal { get; set; }
        public int EventTypeLeaf { get; set; }
        public string EventTypeCode { get; set; }
        public string EventTypeName { get; set; }
        public int Status { get; set; }

        public AndonPrdtLine Clone()
        {
            AndonPrdtLine rlt = MemberwiseClone() as AndonPrdtLine;

            return rlt;
        }
    }
}