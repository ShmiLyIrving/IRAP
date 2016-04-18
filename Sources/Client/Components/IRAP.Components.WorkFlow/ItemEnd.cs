using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAP.Client.Global.Resources.Properties;

namespace IRAP.Components.WorkFlow
{
    public class ItemEnd : CustomItemNode
    {
        public ItemEnd(Graphics graphics, Point location)
            :base(graphics, location)
        {
            SetItemImage(Resources.End, location);
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