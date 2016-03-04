using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    public class ProductionLineOfProduct
    {
        public int Ordinal { get; set; }
        public int T134LeafID { get; set; }
        public string T134Code { get; set; }
        public string T134Name { get; set; }

        public ProductionLineOfProduct Clone()
        {
            return MemberwiseClone() as ProductionLineOfProduct;
        }
    }
}