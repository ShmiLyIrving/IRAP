using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class RepairMode
    {
        public string RepairName { get; set; }
        public string RepairCode { get; set; }
        public int RepairLeaf { get; set; }
        public int RepairID { get; set; }
        public int Ordinal { get; set; }

        public RepairMode Clone()
        {
            RepairMode rlt = MemberwiseClone() as RepairMode;

            return rlt;
        }
    }
}