using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

using IRAP.Global;

namespace IRAP.Components.WorkFlow
{
    public class WorkFlowPanel : Panel
    {
        private Image defaultImage = new Bitmap(20, 20);
        private Image bufferMap = null;
        private Graphics bufferGraphics = null;
        private bool gridShowed = true;
        private Color gridLineColor = Color.LightGray;
        private int gridSplitWidth = 50;
        private IPaintItem root = null;
        private List<IPaintItem> items = new List<IPaintItem>();
        /// <summary>
        /// 当前鼠标移动是否是在划线
        /// </summary>
        private bool drawingLine = false;
        /// <summary>
        /// 被鼠标点击的节点
        /// </summary>
        private IPaintItem clickedItem = null;
        private Point clickedItemPoint;
        private IPaintItem lastMouseStayItem = null;
        /// <summary>
        /// 当前正在绘画的连接线
        /// </summary>
        private ItemLink currentDrawingLine = null;
        private Color backgroundColor = Color.White;

        public WorkFlowPanel()
        {
            SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor,
                true);

            bufferMap = new Bitmap(10, 10);
            bufferGraphics = Graphics.FromImage(bufferMap);
        }

        /// <summary>
        /// 是否显示网格线
        /// </summary>
        [DefaultValue(true)]
        public bool GridLineShowed
        {
            get { return gridShowed; }
            set
            {
                gridShowed = value;
                Refresh();
            }
        }

        /// <summary>
        /// 网格线间隔距离
        /// </summary>
        [DefaultValue(50)]
        public int GridLineSplitWidth
        {
            get { return gridSplitWidth; }
            set
            {
                gridSplitWidth = value;
                Refresh();
            }
        }

        /// <summary>
        /// 流程图起始节点
        /// </summary>
        [Browsable(false)]
        public IPaintItem Root
        {
            get { return root; }
            set { root = value; }
        }

        /// <summary>
        /// 流程图中的所有节点（包括连接线）
        /// </summary>
        [Browsable(false)]
        public List<IPaintItem> Items
        {
            get { return items; }
        }

        /// <summary>
        /// 当前鼠标移动是否是在划线
        /// </summary>
        [DefaultValue(false)]
        [Browsable(false)]
        public bool DrawingLink
        {
            get { return drawingLine; }
            set { drawingLine = value; }
        }

        [Browsable(false)]
        public Graphics BufferGraphics
        {
            get { return bufferGraphics; }
        }

        /// <summary>
        /// 画布背景颜色
        /// </summary>
        [Browsable(true)]
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            bufferGraphics.Clear(backgroundColor);
            DrawGird();
            DrawItem();

            e.Graphics.TranslateTransform(
                AutoScrollPosition.X,
                AutoScrollPosition.Y);
            e.Graphics.DrawImage(bufferMap, new Point(0, 0));
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            int bufferWidth =
                AutoScrollMinSize.Width == 0 ?
                Width :
                AutoScrollMinSize.Width;
            int bufferHeight =
                AutoScrollMinSize.Height == 0 ?
                Height :
                AutoScrollMinSize.Height;

            if (bufferWidth != 0 ||
                bufferHeight != 0)
            {
                bufferMap =
                    new Bitmap(
                        bufferWidth,
                        bufferHeight);
                bufferGraphics = Graphics.FromImage(bufferMap);
            }

            base.OnSizeChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Point locate = new Point(
                e.X + HorizontalScroll.Value,
                e.Y + VerticalScroll.Value);

            if (e.Button == MouseButtons.Left)
            {
                clickedItem = GetItemAtPoint(locate);
                if (clickedItem != null)
                {
                    if (clickedItem is CustomItemNode)
                    {
                        if (!drawingLine)
                        {
                            clickedItemPoint =
                                new Point(
                                    locate.X - clickedItem.ItemLocate.X,
                                    locate.Y - clickedItem.ItemLocate.Y);
                        }
                        else
                        {
                            if (!(clickedItem is ItemEnd))
                            {
                                currentDrawingLine = CreateWorkFlowLine();
                                currentDrawingLine.ItemStatus = ItemStatus.Drawing;
                                currentDrawingLine.ItemFrom = clickedItem as CustomItemNode;
                            }
                        }
                    }
                }
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point location = new Point(
                e.X + HorizontalScroll.Value,
                e.Y + VerticalScroll.Value);

            if (e.Button == MouseButtons.Left)
            {
                if (!drawingLine)
                {
                    if (clickedItem != null)
                    {
                        clickedItem.ItemLocate =
                            new Point(
                                location.X - clickedItemPoint.X,
                                location.Y - clickedItemPoint.Y);

                        Refresh();
                    }
                }
                else
                {
                    IPaintItem item = GetItemAtPoint(location);

                    if (currentDrawingLine != null)
                    {
                        // 连接线已经存在，则将连接线的终点设置到当前鼠标所在的坐标。
                        // 如果鼠标所在位置是结点，则设置终点为结点的 LinkToPrevPoint
                        if (item != null && item is CustomItemNode)
                        {
                            if (item != currentDrawingLine.ItemFrom)
                            {
                                currentDrawingLine.EndPoint =
                                    ((CustomItemNode) item).ToPoint;
                            }
                            else
                            {
                                currentDrawingLine.EndPoint = location;
                            }
                        }
                        else
                        {
                            currentDrawingLine.EndPoint = location;
                        }

                        Refresh();
                    }
                }
            }
            else
            {
                IPaintItem itemMouseStay = GetItemAtPoint(location);
                if (itemMouseStay == null)
                {
                    IPaintItem line = GetLineAtPoint(location);
                    if (line != null)
                    {
                        if (lastMouseStayItem == null)
                        {
                            lastMouseStayItem = line;
                            line.ItemStatus = ItemStatus.Pointed;
                            Refresh();
                        }
                        else
                        {
                            if (lastMouseStayItem != line)
                            {
                                lastMouseStayItem.ItemStatus = ItemStatus.Watting;

                                line.ItemStatus = ItemStatus.Pointed;
                                lastMouseStayItem = line;


                                Refresh();
                            }
                        }
                    }
                    else
                    {
                        if (lastMouseStayItem != null)
                        {
                            lastMouseStayItem.ItemStatus = ItemStatus.Watting;
                            lastMouseStayItem = null;

                            Refresh();
                        }
                    }
                }
                else
                {
                    if (lastMouseStayItem == null)
                    {
                        lastMouseStayItem = itemMouseStay;
                        lastMouseStayItem.ItemStatus = ItemStatus.Pointed;
                        Refresh();
                    }
                    else
                    {
                        if (lastMouseStayItem != itemMouseStay)
                        {
                            lastMouseStayItem.ItemStatus = ItemStatus.Watting;
                            itemMouseStay.ItemStatus = ItemStatus.Pointed;
                            lastMouseStayItem = itemMouseStay;

                            Refresh();
                        }
                    }
                }
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Point location = new Point(
                e.X + HorizontalScroll.Value,
                e.Y + VerticalScroll.Value);

            if (e.Button == MouseButtons.Left)
            {
                if (drawingLine)
                {
                    if (currentDrawingLine != null)
                    {
                        IPaintItem item = GetItemAtPoint(location);
                        if (item != null && item is CustomItemNode)
                        {
                            if (item == currentDrawingLine.ItemFrom)
                            {
                            }
                            else if (item is ItemBegin)
                            {
                            }
                            else
                            {
                                if (CheckValid(
                                    currentDrawingLine,
                                    item as CustomItemNode))
                                {
                                    currentDrawingLine.ItemStatus = ItemStatus.Watting;
                                    currentDrawingLine.ItemTo = item as CustomItemNode;

                                    if (!LinkLineExists(currentDrawingLine))
                                    {
                                        currentDrawingLine.ItemTo.PrevLinks.Add(currentDrawingLine);
                                        currentDrawingLine.ItemFrom.NextLinks.Add(currentDrawingLine);
                                    }
                                }
                            }
                        }
                        currentDrawingLine = null;
                    }
                }
            }

            base.OnMouseUp(e);
        }

        private bool LinkLineExists(ItemLink link)
        {
            foreach (ItemLink itemLink in link.ItemFrom.NextLinks)
            {
                if (link.ItemFrom == itemLink.ItemFrom && link.ItemTo == itemLink.ItemTo)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 绘制网格线
        /// </summary>
        private void DrawGird()
        {
            if (gridShowed)
            {
                Pen gridPen = new Pen(gridLineColor);
                gridPen.DashStyle = DashStyle.Custom;
                gridPen.DashPattern = new float[] { 1, 2 };

                for (int column = 0;
                    column < (int) Math.Ceiling((double) bufferMap.Width / (double) gridSplitWidth);
                    column++)
                {
                    bufferGraphics.DrawLine(
                        gridPen,
                        new Point(column * gridSplitWidth, 0),
                        new Point(column * gridSplitWidth, bufferMap.Height));
                }

                for (int row = 0;
                    row < (int) Math.Ceiling((double) bufferMap.Height / (double) gridSplitWidth);
                    row++)
                {
                    bufferGraphics.DrawLine(
                        gridPen,
                        new Point(0, row * gridSplitWidth),
                        new Point(bufferMap.Width, row * gridSplitWidth));
                }
            }
        }

        protected virtual void DrawItem()
        {
            foreach (IPaintItem item in items)
            {
                item.DrawSelf(bufferGraphics);

                if (item is CustomItemNode)
                {
                    foreach (ItemLink line in ((CustomItemNode) item).NextLinks)
                    {
                        line.DrawSelf(bufferGraphics);
                    }
                }
            }

            if (currentDrawingLine != null)
            {
                currentDrawingLine.DrawSelf(bufferGraphics);
            }
        }

        public IPaintItem GetItemAtPoint(Point point)
        {
            foreach (IPaintItem item in items)
            {
                if (item is ItemLink)
                {

                }
                else
                {
                    if ((item.ItemLocate.X < point.X &&
                        (item.ItemLocate.X + item.ItemImage.Width) > point.X) &&
                        (item.ItemLocate.Y < point.Y &&
                        (item.ItemLocate.Y + item.ItemImage.Height) > point.Y))
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        public IPaintItem GetLineAtPoint(Point location)
        {
            foreach (IPaintItem item in items)
            {
                if (item is CustomItemNode)
                {
                    foreach (ItemLink line in (item as CustomItemNode).NextLinks)
                    {
                        if (Math.Abs(MyMath.LineWidthWithTwoPoint(line.StartPoint, line.EndPoint) -
                            (MyMath.LineWidthWithTwoPoint(line.StartPoint, location) +
                            MyMath.LineWidthWithTwoPoint(location, line.EndPoint))) <= 1.0)
                        {
                            return line;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 重置流程图的布局
        /// </summary>
        public void ResetLayout()
        {
            int x = 50;
            int y = 100;

            foreach (IPaintItem item in items)
            {
                if (item is CustomItemNode)
                    ((CustomItemNode) item).LayoutResetted = true;
            }
            ResetItemPoint(root as ItemBegin, new Point(x, y));

            Refresh();
        }

        private void ResetItemPoint(CustomItemNode item, Point location)
        {
            int itemHorizontalSplitter = 150;
            int itemVerticalSplitter = 100;

            if (item.LayoutResetted)
            {
                item.ItemLocate = location;
                item.LayoutResetted = false;
            }

            int i = 1;
            foreach (ItemLink line in item.NextLinks)
            {
                Point nextLoation =
                    new Point(
                        location.X + itemHorizontalSplitter,
                        location.Y);
                ResetItemPoint(line.ItemTo, nextLoation);

                location.Y = item.ToPoint.Y * i++ + itemVerticalSplitter;
            }
        }

        /// <summary>
        /// 创建一条连接线
        /// </summary>
        protected virtual ItemLink CreateWorkFlowLine()
        {
            return new ItemLink();
        }

        /// <summary>
        /// 检查指定的结点是否是当前连接线的起始结点
        /// </summary>
        protected virtual bool NodeInPrevRouting(ItemLink link, CustomItemNode node)
        {
            if (link.ItemFrom == node)
                return true;
            else
            {
                foreach (ItemLink prevLink in link.ItemFrom.PrevLinks)
                {
                    if (NodeInPrevRouting(prevLink, node))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 新建连接线后的链路校验。
        /// 缺省的检验是：如果形成闭合循环，则返回 false，否则返回 true
        /// </summary>
        protected virtual bool CheckValid(ItemLink link, CustomItemNode node)
        {
            if (NodeInPrevRouting(link, node))
            {
                MessageBox.Show(
                    "当前流程不支持闭合循环！",
                    "链路错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }
    }
}
