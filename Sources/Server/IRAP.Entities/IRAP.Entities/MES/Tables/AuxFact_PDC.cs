using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entities.MES.Tables
{

    /// <summary>
    /// 辅助事实表
    /// </summary>
    [IRAPDB(TableName = "IRAPMES..AuxFact_PDC")]
    public class AuxFact_PDC
    {
        [IRAPKey()]
        public long FactID { get; set; }
        [IRAPKey()]
        public long PartitioningKey { get; set; }
        public long FactPartitioningKey { get; set; }
        public string WFInstanceID { get; set; }
        public string WIPCode { get; set; }
        public string AltWIPCode { get; set; }
        public string SerialNumber { get; set; }
        public string LotNumber { get; set; }
        public string ContainerNo { get; set; }
        public string FakePreventingCode { get; set; }
        public string CustomerAssignedID { get; set; }
        public string ElectronicProductCode { get; set; }
        public long QCStatus { get; set; }

        public AuxFact_PDC Clone()
        {
            return MemberwiseClone() as AuxFact_PDC;
        }
    }
}
