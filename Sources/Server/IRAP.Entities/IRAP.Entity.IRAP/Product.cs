using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.IRAP
{
    public class Product
    {
        public int Oridinal { get; set; }
        public int T102LeafID { get; set; }
        public string T102Code { get; set; }
        public string T102NodeName { get; set; }

        public Product Clone()
        {
            return MemberwiseClone() as Product;
        }
    }
}