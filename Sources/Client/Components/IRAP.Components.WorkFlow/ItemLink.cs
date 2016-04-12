using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace IRAP.Components.WorkFlow
{
    public class ItemLink : IPaintItem
    {
        protected Color itemColor = Color.Green;
        protected Font itemFont = new Font("微软雅黑", 9f);
        protected Image itemImage = null;
        protected Point itemLocate;
        protected string itemName;
        protected ItemStatus itemStatus;
        protected CustomItemNode itemFrom = null;
        protected CustomItemNode itemTo = null;
        protected Point startPoint = new Point(0, 0);
        protected Point endPoint = new Point(0, 0);

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
            set { itemLocate = value; }
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

        public CustomItemNode ItemFrom
        {
            get { return itemFrom; }
            set
            {
                itemFrom = value;
                if (value != null)
                {
                    startPoint = itemFrom.FromPoint;
                    AfterSetItemFrom(value);
                }
            }
        }

        public CustomItemNode ItemTo
        {
            get { return itemTo; }
            set
            {
                itemTo = value;
                if (value != null)
                {
                    endPoint = itemTo.ToPoint;
                    AfterSetItemTo(value);
                }
            }
        }

        public Point StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        public Point EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public void DrawSelf(Graphics graphics, Pen pen = null)
        {
            CheckValid();

            switch (itemStatus)
            {
                case ItemStatus.Drawing:
                    pen = new Pen(Color.Gray);
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { 1, 2 };
                    pen.Width = 2.0f;
                    break;
                case ItemStatus.Pointed:
                    pen = new Pen(Color.Blue)
                    {
                        Width = 2.5f,
                    };
                    break;
                case ItemStatus.Error:
                    pen = new Pen(Color.Red)
                    {
                        Width = 2.0f,
                    };
                    break;
                default:
                    pen = new Pen(itemColor);
                    pen.Width = 2.0f;
                    break;
            }
            pen.StartCap = LineCap.Round;

            graphics.DrawLine(pen, startPoint, endPoint);
            DrawArrowHead(graphics, pen, startPoint, endPoint);
        }

        /// <summary>
        /// 绘制箭头
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="startPoint">起始点</param>
        /// <param name="endPoint">终止点</param>
        private void DrawArrowHead(Graphics graphics, Pen pen, PointF startPoint, PointF endPoint)
        {
            double ArrowLength = 10.0;
            double RelativeValue = 2;

            double distance = Math.Abs(Math.Sqrt(
               (startPoint.X - endPoint.X) * (startPoint.X - endPoint.X) +
               (startPoint.Y - endPoint.Y) * (startPoint.Y - endPoint.Y)));
            if (distance == 0)
            {
                return;
            }

            double xa = endPoint.X + ArrowLength * ((startPoint.X - endPoint.X)
                + (startPoint.Y - endPoint.Y) / RelativeValue) / distance;
            double ya = endPoint.Y + ArrowLength * ((startPoint.Y - endPoint.Y)
                - (startPoint.X - endPoint.X) / RelativeValue) / distance;
            double xb = endPoint.X + ArrowLength * ((startPoint.X - endPoint.X)
                - (startPoint.Y - endPoint.Y) / RelativeValue) / distance;
            double yb = endPoint.Y + ArrowLength * ((startPoint.Y - endPoint.Y)
                + (startPoint.X - endPoint.X) / RelativeValue) / distance;

            PointF[] polygonPoints =
            {
                new PointF(endPoint.X, endPoint.Y),
                new PointF((float)xa, (float)ya),
                new PointF((float)xb, (float)yb),
            };

            DrawArrowHead(graphics, pen, polygonPoints);
        }

        private void DrawArrowHead(Graphics graphics, Pen pen, PointF[] points)
        {
            if (pen == null)
            {
                pen = new Pen(itemColor);
            }
            graphics.DrawPolygon(pen, points);
            graphics.FillPolygon(new SolidBrush(pen.Color), points);
        }

        protected virtual void AfterSetItemFrom(CustomItemNode item) { }

        protected virtual void AfterSetItemTo(CustomItemNode item)
        {
            if (item is ItemNode)
            {
                if (ItemFrom is ItemBegin)
                {
                    (item as ItemNode).Level = 1;
                    ResetNextLevel();
                }
                else
                {
                    int level = (ItemFrom as ItemNode).Level + 1;
                    if (level > (item as ItemNode).Level)
                    {
                        (item as ItemNode).Level = level;
                        ResetNextLevel();
                    }
                }
            }
        }

        private void ResetNextLevel()
        {
            foreach (ItemLink link in itemTo.NextLinks)
            {
                link.ItemTo = link.ItemTo;
            }
        }

        protected virtual void CheckValid()
        {
        }
    }
}