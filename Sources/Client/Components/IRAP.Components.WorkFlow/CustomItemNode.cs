using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IRAP.Components.WorkFlow
{
    public class CustomItemNode : WFItem
    {
        protected object tag = null;

        public CustomItemNode(Graphics graphics, Point locate) : base(graphics, locate)
        {
            itemImage = IRAP.Client.Global.Resources.Properties.Resources.空结点;

            CalculateLocation(locate);
        }

        public List<ItemLink> PrevLinks
        {
            get { return prevLinks; }
            set { prevLinks = value; }
        }

        public List<ItemLink> NextLinks
        {
            get { return nextLinks; }
            set { nextLinks = value; }
        }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public override void DrawSelf(Graphics graphics, Pen pen = null)
        {
            graphics.DrawImage(itemImage, itemLocate);

            if ((ItemStatus & ItemStatus.Pointed) == ItemStatus.Pointed)
            {
                graphics.DrawRectangle(
                    itemPen,
                    itemLocate.X - 3,
                    itemLocate.Y - 3,
                    itemImage.Width + 6,
                    itemImage.Height + 6);
            }

            foreach (ItemLink line in nextLinks)
            {
                line.DrawSelf(graphics, pen);
            }
        }

        protected void DrawToPoint(Graphics graphics)
        {
            Pen pointPen = new Pen(Color.Black);
            graphics.DrawRectangle(
                pointPen,
                ToPoint.X - 1,
                ToPoint.Y - 1,
                2,
                2);
            graphics.FillRectangle(
                new SolidBrush(Color.Black),
                new Rectangle(
                    new Point(
                        ToPoint.X - 1,
                        ToPoint.Y - 1),
                    new Size(2, 2)));
        }

        protected void DrawFromPoint(Graphics graphics)
        {
            Pen pointPen = new Pen(Color.Black);
            graphics.DrawRectangle(
                pointPen,
                FromPoint.X - 1,
                FromPoint.Y - 1,
                2,
                2);
            graphics.FillRectangle(
                new SolidBrush(Color.Black),
                new Rectangle(
                    new Point(
                        FromPoint.X - 1,
                        FromPoint.Y - 1),
                    new Size(2, 2)));
        }
    }
}