using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class ProductMoveBack
    {
        public int Quantity { get; set; }
        public string PackageSN { get; set; }
        public int Ordinal { get; set; }

        public ProductMoveBack Clone()
        {
            ProductMoveBack rlt = MemberwiseClone() as ProductMoveBack;

            return rlt;
        }
    }
}