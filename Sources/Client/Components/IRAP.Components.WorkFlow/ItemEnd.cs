using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IRAP.Components.WorkFlow
{
    public class ItemEnd : CustomItemNode
    {
        public ItemEnd(Graphics graphics, Point location)
            :base(graphics, location)
        {
            itemImage = IRAP.Client.Global.Resources.Properties.Resources.End;

            CalculateLocation(location);
        }

        private new List<ItemLink> NextLinks
        {
            get { return nextLinks; }
        }

        public override void DrawSelf(Graphics graphics, Pen pen = null)
        {
            base.DrawSelf(graphics, pen);

            if (ItemStatus== ItemStatus.Pointed)
            {
                DrawToPoint(graphics);
            }
        }
    }
}