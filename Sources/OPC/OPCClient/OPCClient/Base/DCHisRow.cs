using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCClient
{
    public class DCHisRow
    {
        public long PartitioningKey { get; set; }
        public int TagID { get; set; }
        public string TagName { get; set; }
        public int UnixTime { get; set; }
        public string DateType { get; set; }
        public float Value { get; set; }
        public string ValueStr { get; set; }
        public string Quality { get; set; }
    }
}
