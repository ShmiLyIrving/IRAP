using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.OPC.Entity
{
    public class TIRAPOPCTagValueItem
    {
        public string KepServerAddress { get; set; }
        public string KepServerName { get; set; }
        public string TagName { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        public string Quality { get; set; }
        public string TimeStamp { get; set; }
    }
}
