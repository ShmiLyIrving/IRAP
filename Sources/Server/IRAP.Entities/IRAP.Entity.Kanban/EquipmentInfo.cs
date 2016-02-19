using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class EquipmentInfo
    {
        public string EquipmentName { get; set; }
        public string EquipmentCode { get; set; }
        public int EquipmentLeaf { get; set; }
        public int EquipmentID { get; set; }
        public int Ordinal { get; set; }

        public EquipmentInfo Clone()
        {
            EquipmentInfo rlt = MemberwiseClone() as EquipmentInfo;

            return rlt;
        }
    }
}