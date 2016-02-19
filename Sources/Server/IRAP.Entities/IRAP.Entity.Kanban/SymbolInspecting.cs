using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class SymbolInspecting
    {
        public string PWOCategoryName { get; set; }
        public int PWOCategoryLeaf { get; set; }
        public double ZCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public double XCoordinate { get; set; }
        public int SideFlag { get; set; }
        public string Symbol { get; set; }
        public int SymbolLeaf { get; set; }
        public int Ordinal { get; set; }

        public SymbolInspecting Clone()
        {
            SymbolInspecting rlt = MemberwiseClone() as SymbolInspecting;

            return rlt;
        }
    }
}