using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAP.Client.Global.Resources.Properties;

namespace IRAP.Components.WorkFlow
{
    public class ItemBegin : CustomItemNode
    {
        public ItemBegin(Graphics graphics, Point location) 
            : base(graphics, location)
        {
            SetItemImage(Resources.Begin, location);
        }

        private new List<ItemLink> PrevLinks
        {
            get { return prevLinks; }
        }

        public override void DrawSelf(Graphics graphics, Pen pen = null)
        {
            base.DrawSelf(graphics, pen);

            if (ItemStatus == ItemStatus.Pointed)
            {
                DrawFromPoint(graphics);
            }
        }
    }
}