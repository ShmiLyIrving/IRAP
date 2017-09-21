using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRAPShared;

namespace IRAP.Entities.MES.Tables
{
    [IRAPDB(TableName = "IRAPMES..AuxFact_PWOIssuing")]
    public class AuxFact_PWOIssuing
    {
        [IRAPKey()]
        public long FactID { get; set; }
        [IRAPKey()]
        public long PartitioningKey { get; set; }
        public long FactPartitioningKey { get; set; }
        public string WFInstanceID { get; set; }
        public string AltPWONo { get; set; }
        public string LotNumber { get; set; }
        public int T134NodeID { get; set; }
        public int T124LeafID { get; set; }
        public string MONumber { get; set; }
        public int MOLineNo { get; set; }
        public string SONumber { get; set; }
        public int SOLineNo { get; set; }
        public int CreatedUnixTime { get; set; }
        public string ScheduledStartTime { get; set; }
        public string ScheduledCloseTime { get; set; }
        public string MaterialDeliverTime { get; set; }
        public string ActualStartTime { get; set; }
        public string ActualCloseTime { get; set; }
        public string ContainerNo { get; set; }
        public int PWOStatus { get; set; }
        public int PWOPriority { get; set; }
        public bool EmergencyOrder { get; set; }
        public int T102S1 { get; set; }
        public int PWOCtrlAttr { get; set; }
    }
}
