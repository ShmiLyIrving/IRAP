using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class SelectedLeaf
    {
        public double Ordinal { get; set; }
        public int LeafStatus { get; set; }
        public string Code { get; set; }
        public int EntityID { get; set; }
        public int LeafID { get; set; }
        public int TreeID { get; set; }

        public SelectedLeaf Clone()
        {
            SelectedLeaf rlt = MemberwiseClone() as SelectedLeaf;

            return rlt;
        }
    }
}