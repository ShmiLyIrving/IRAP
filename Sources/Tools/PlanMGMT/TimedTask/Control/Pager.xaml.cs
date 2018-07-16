using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Collections;

namespace PlanMGMT.Control
{
    /// 申明委托
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    //public delegate void EventPagingHandler(EventPagingArg e);

    /// <summary>
    /// UCPaging.xaml 的交互逻辑
    /// </summary>
    public partial class Pager : UserControl
    {
        #region Pirvate Member

        // 页码变化触发事件
        public event EventHandler EventPaging;
        //public DataTable dt;
        public IList list;
        //public event EventPagingHandler EventPaging;
        private int pageIndex = 1;
        private int pageSize = 100;
        private int recordCount = 0;
        private int pageCount = 0;
        private string jumpText;
        /// <summary>
        /// 当前页面
        /// </summary>
        public virtual int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public virtual int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public virtual int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (pageSize != 0)
                {
                    pageCount = GetPageCount();
                }
                return pageCount;
            }
        }

        /// <summary>
        /// 跳转按钮文本
        /// </summary>
        public string JumpText
        {
            get
            {
                if (string.IsNullOrEmpty(jumpText))
                {
                    jumpText = "GO";
                }
                return jumpText;
            }
            set { jumpText = value; }
        }


        #endregion

        /// <summary>
        /// 计算总页数
        /// </summary>
        /// <returns></returns>
        private int GetPageCount()
        {
            if (pageSize == 0)
            {
                return 0;
            }
            pageCount = RecordCount / PageSize;
            if (RecordCount % PageSize == 0)
            {
                pageCount = RecordCount / PageSize;
            }
            else
            {
                pageCount = RecordCount / PageSize + 1;
            }
            return pageCount;
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public Pager()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 触发翻页事件
        /// </summary>
        private void TrrigerEventPaging()
        {
            if (this.EventPaging != null)
                this.EventPaging(this, null);//当前分页数字改变时，触发委托事件
        }
        /// <summary>
        /// 得到数据
        /// </summary>
        /// <returns></returns>
        public void Bind()
        {
            if (list == null || list.Count == 0)
            {
                this.Visibility = Visibility.Collapsed;
                return;
            }
            else
            {
                this.Visibility = Visibility.Visible;
            }
            this.txbGO.Text = " " + this.JumpText;

            //--控制 7
            this.txbInfo.Text = "第 " + (this.PageIndex == 1 ? 1 : (this.PageIndex - 1) * this.PageSize) + "-" + this.PageIndex * this.PageSize + " 条  共 " + this.RecordCount + " 条  |  第 " + this.PageIndex + " / " + this.PageCount + " 页";
            this.txtPageNum.Text = this.PageIndex.ToString();
            this.txbTotalPageCount.Text = " / " + PageCount;

            this.wPanel.Width = 90 + this.PageCount.ToString().Length * 7;
            if (PageCount > 1 && PageCount > PageIndex)
            {
                //this.iNext.Source = new BitmapImage(new Uri("../Resources/Images/Pager/next2.gif", UriKind.Relative));
                this.iNext.IsEnabled = true;
                this.iLast.IsEnabled = true;
            }
            else
            {
                this.iNext.IsEnabled = false;
                this.iLast.IsEnabled = false;
            }

            if (this.PageIndex > 1 && this.PageIndex <= this.PageCount)
            {
                this.iFirst.IsEnabled = true;
                this.iPrev.IsEnabled = true;
            }
            else
            {
                this.iFirst.IsEnabled = false;
                this.iPrev.IsEnabled = false;
            }
        }

        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void iFirst_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.PageIndex = 1;
            this.TrrigerEventPaging();
            this.Bind();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void iPrev_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.PageIndex--;
            this.TrrigerEventPaging();
            this.Bind();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void iNext_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.PageIndex++;
            this.TrrigerEventPaging();
            this.Bind();
        }

        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void iLast_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.PageIndex = PageCount;
            this.TrrigerEventPaging();
            this.Bind();
        }

        /// <summary>
        /// 确定导航到指定页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudPageIndex_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Return)
            {
                this.PageIndex = int.Parse(this.txtPageNum.Text.ToString());
                this.TrrigerEventPaging();
                this.Bind();
            }
        }

        /// <summary>
        /// 确定导航
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbGO_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.PageIndex = int.Parse(this.txtPageNum.Text.ToString());
            this.TrrigerEventPaging();
            this.Bind();
        }
        /// <summary>
        /// 跳转限制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            int num = 0;
            if (int.TryParse(txtPageNum.Text.Trim(), out num) && num > 0)
            {
                if (num > PageCount)
                {
                    txtPageNum.Text = PageCount.ToString();
                }
            }
        }
        /// <summary>
        /// 键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPageNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.txtPageNum.Focus();
                this.PageIndex = int.Parse(this.txtPageNum.Text.ToString());
                this.TrrigerEventPaging();
                this.Bind();
            }
        }
        /// <summary>
        /// 鼠标移入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbGO_MouseMove(object sender, MouseEventArgs e)
        {
            this.txbGO.TextDecorations = TextDecorations.Underline;//加下划线
        }
        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbGO_MouseLeave(object sender, MouseEventArgs e)
        {
            this.txbGO.TextDecorations = null;
        }
    }

    /// <summary>
    /// 自定义事件数据基类
    /// </summary>
    //public class EventPagingArg : EventArgs
    //{
    //    public EventPagingArg() { }
    //}
}
