using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    public class PCBSymbols
    {
        public int Ordinal { get; set; }
        public int SymbolEntity { get; set; }
        public int SymbolLeaf { get; set; }
        public string Symbol { get; set; }
        /// <summary>
        /// 正反面
        /// </summary>
        public int SideFlag { get; set; }
        public int MaterialLeaf { get; set; }
        public string MaterialCode { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { set; get; }
        public double ZCoordinate { get; set; }
        public int PWOCategoryLeaf { get; set; }
        public string PWOCategoryName { set; get; }
    }
}
