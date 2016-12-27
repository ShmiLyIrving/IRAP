using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MES
{
    [IRAPDB(TableName = "IRAPMES..FixedFact_MES")]
    public class TBL_FixedFact_MES
    {
        public TBL_FixedFact_MES()
        {
            FactID = 0;
            PartitionPolicy = 0;
            TransactNo = 0;
            IsFixed = 0;
            OpID = 0;
            OpType = 0;
            BusinessDate = DateTime.Now;
            Code01 = "";
            Code02 = "";
            Code03 = "";
            Code04 = "";
            Code05 = "";
            Code06 = "";
            Code07 = "";
            Code08 = "";
            Leaf01 = 0;
            Leaf02 = 0;
            Leaf03 = 0;
            Leaf04 = 0;
            Leaf05 = 0;
            Leaf06 = 0;
            Leaf07 = 0;
            Leaf08 = 0;
            AChecksum = 0;
            CorrelationID = 0;
            Metric01 = 0;
            Metric02 = 0;
            Metric03 = 0;
            Metric04 = 0;
            Metric05 = 0;
            Metric06 = 0;
            Metric07 = 0;
            Metric08 = 0;
            Metric09 = 0;
            Metric10 = 0;
            BChecksum = 0;
            MeasurementID = 0;
            WFInstanceID = "";
            Remark = "";
            LinkedFactID = 0;
        }

        [IRAPKey]
        public long FactID { get; set; }
        [IRAPKey]
        public long PartitionPolicy { get; set; }
        public long TransactNo { get; set; }
        public int IsFixed { get; set; }
        public int OpID { get; set; }
        public int OpType { get; set; }
        public DateTime BusinessDate { get; set; }
        public string Code01 { get; set; }
        public string Code02 { get; set; }
        public string Code03 { get; set; }
        public string Code04 { get; set; }
        public string Code05 { get; set; }
        public string Code06 { get; set; }
        public string Code07 { get; set; }
        public string Code08 { get; set; }
        public int Leaf01 { get; set; }
        public int Leaf02 { get; set; }
        public int Leaf03 { get; set; }
        public int Leaf04 { get; set; }
        public int Leaf05 { get; set; }
        public int Leaf06 { get; set; }
        public int Leaf07 { get; set; }
        public int Leaf08 { get; set; }
        public int AChecksum { get; set; }
        public int CorrelationID { get; set; }
        public long Metric01 { get; set; }
        public long Metric02 { get; set; }
        public long Metric03 { get; set; }
        public long Metric04 { get; set; }
        public long Metric05 { get; set; }
        public long Metric06 { get; set; }
        public long Metric07 { get; set; }
        public long Metric08 { get; set; }
        public long Metric09 { get; set; }
        public long Metric10 { get; set; }
        public int BChecksum { get; set; }
        public int MeasurementID { get; set; }
        public string WFInstanceID { get; set; }
        public string Remark { get; set; }
        public long LinkedFactID { get; set; }

        public TBL_FixedFact_MES Clone()
        {
            return MemberwiseClone() as TBL_FixedFact_MES;
        }
    }
}
