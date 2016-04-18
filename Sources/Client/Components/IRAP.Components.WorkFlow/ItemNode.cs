using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IRAP.Components.WorkFlow
{
    public class ItemNode : CustomItemNode
    {
        protected int level = 0;

        public ItemNode(Graphics graphics, Point location, int level = 0) : base(graphics, location)
        {
            this.level = level;

            SetItemImage(GenerateImage(), location);
        }

        public new string ItemName
        {
            get { return itemName; }
            set
            {
                itemName = value;
                GenerateImage();
                DrawSelf(graphics);
            }
        }

        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                DrawOrdinal(graphics);
            }
        }

        protected virtual Image GenerateImage()
        {
            int imageWidth = defaultImageWidth;
            int imageHeight = defaultImageHeight;
            Graphics gp = null;

            Image itemImage = new Bitmap(imageWidth, imageHeight);
            gp = Graphics.FromImage(itemImage);

            // 画阴影部分
            gp.FillRectangle(
                new SolidBrush(Color.LightGray),
                new Rectangle(
                    new Point(5, 5),
                    new Size(imageWidth - 5, imageHeight - 5)));

            // 画主体部分
            Pen mainPen = null;
            if (CheckValid())
            {
                mainPen = new Pen(Color.LightBlue);
            }
            else
                mainPen = new Pen(Color.Red);
            gp.DrawRectangle(
                mainPen,
                new Rectangle(
                    new Point(0, 0),
                    new Size(imageWidth - 5, imageHeight - 5)));
            gp.FillRectangle(
                new SolidBrush(Color.White),
                new Rectangle(
                    new Point(1, 1),
                    new Size(imageWidth - 6, imageHeight - 6)));

            DrawOrdinal(gp);

            return itemImage;
        }

        public override void DrawSelf(Graphics graphics, Pen pen = null)
        {
            GenerateImage();
            base.DrawSelf(graphics, pen);

            DrawOrdinal(graphics);

            // 写标题
            SizeF size = graphics.MeasureString(itemName, itemFont);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            graphics.DrawString(
                itemName,
                itemFont,
                new SolidBrush(Color.Blue),
                new Rectangle(
                    new Point(
                        itemLocate.X + (ItemImage.Width - (int) size.Width) / 2,
                        itemLocate.Y + ItemImage.Height + 10),
                    new Size(
                        (int) size.Width + 5,
                        (int) size.Height + 5)),
                sf);

            if (itemStatus == ItemStatus.Pointed)
            {
                DrawFromPoint(graphics);
                DrawToPoint(graphics);
            }
        }

        protected virtual void DrawOrdinal(Graphics graphics)
        {
            SizeF size = graphics.MeasureString(level.ToString(), itemFont);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            graphics.DrawString(
                level.ToString(),
                itemFont,
                new SolidBrush(Color.Blue),
                new Rectangle(
                    new Point(itemLocate.X, itemLocate.Y - (int) size.Height - 5),
                    new Size(ItemImage.Width - 2, (int) size.Height)),
                sf);
        }

        public virtual bool CheckValid()
        {
            if (prevLinks.Count == 0)
                return false;
            else if (nextLinks.Count == 0)
                return false;
            else
                return true;
        }
    }
}