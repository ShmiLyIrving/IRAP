using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    public class ProductSeriesTreeNode : TreeViewNode
    {
        public int T213LeafID { get; set; }
        public string T213NodeName { get; set; }

        public new ProductSeriesTreeNode Clone()
        {
            ProductSeriesTreeNode rlt = MemberwiseClone() as ProductSeriesTreeNode;

            rlt.IconImage = IconImage;

            return rlt;
        }
    }
}