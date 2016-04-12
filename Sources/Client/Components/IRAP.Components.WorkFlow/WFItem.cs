using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using IRAP.Client.Global.Resources;

namespace IRAP.Components.WorkFlow
{
    public class WFItem : IPaintItem
    {
        protected Color itemColor = Color.Gray;
        protected Font itemFont = new Font("微软雅黑", 9f);
        protected Image itemImage;
        protected Point itemLocate = new Point(10, 10);
        protected string itemName = "未命名";
        protected ItemStatus itemStatus;
        protected Pen itemPen = new Pen(Color.LightGray);
        protected List<ItemLink> nextLinks = new List<ItemLink>();
        protected List<ItemLink> prevLinks = new List<ItemLink>();
        protected static int defaultImageWidth = 64;
        protected static int defaultImageHeight = 32;
        protected Graphics graphics = null;

        public WFItem(Graphics graphics, Point location)
        {
            this.graphics = graphics;

            CalculateLocation(location);
        }

        public Color ItemColor
        {
            get { return itemColor; }
            set { itemColor = value; }
        }

        public Font ItemFont
        {
            get { return itemFont; }
            set { itemFont = value; }
        }

        public Image ItemImage
        {
            get { return itemImage; }
        }

        public Point ItemLocate
        {
            get { return itemLocate; }
            set
            {
                itemLocate = value;

                foreach (ItemLink line in nextLinks)
                {
                    line.StartPoint = FromPoint;
                }
                foreach (ItemLink line in prevLinks)
                {
                    line.EndPoint = ToPoint;
                }
            }
        }

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public ItemStatus ItemStatus
        {
            get { return itemStatus; }
            set { itemStatus = value; }
        }

        public Point ToPoint
        {
            get
            {
                Point location =
                    new Point(
                        itemLocate.X - 3,
                        itemLocate.Y + itemImage.Height / 2);
                return location;
            }
        }

        public Point FromPoint
        {
            get
            {
                Point location =
                    new Point(
                        itemLocate.X + itemImage.Width + 3,
                        itemLocate.Y + itemImage.Height / 2);
                return location;
            }
        }

        /// <summary>
        /// 是否需要重新设置坐标
        /// </summary>
        public bool LayoutResetted { get; set; }

        protected void CalculateLocation(Point location)
        {
            if (location != null)
            {
                itemLocate.X = location.X - itemImage.Width / 2;
                itemLocate.Y = location.Y - itemImage.Height / 2;

                if (itemLocate.X < 5)
                    itemLocate.X = 5;
                if (itemLocate.Y < 5)
                    itemLocate.Y = 5;
            }
        }

        public virtual void DrawSelf(Graphics graphics, Pen pen = null)
        {
        }
    }
}