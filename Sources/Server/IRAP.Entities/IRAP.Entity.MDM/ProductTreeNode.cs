using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    public class ProductTreeNode : TreeViewNode
    {
        public int T132LeafID { get; set; }
        public string T132NodeName { get; set; }
        public int T213LeafID { get; set; }
        public string T213NodeName { get; set; }
        public long MarketDemandAccountedFor { get; set; }

        public new ProductTreeNode Clone()
        {
            ProductTreeNode rlt = MemberwiseClone() as ProductTreeNode;

            rlt.IconImage = IconImage;

            return rlt;
        }
    }
}