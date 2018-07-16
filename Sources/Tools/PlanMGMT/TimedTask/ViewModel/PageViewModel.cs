//using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

//----------------------------------------------------------------*/
// 版权所有：
// 文 件 名：PageViewModel.cs
// 功能描述：
// 修改描述：
//----------------------------------------------------------------*/
namespace TimedTask.ViewModel
{
    /// 申明委托
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate void EventPagingHandler(EventPagingArg e);

    /// <summary>
    /// 自定义事件参数
    /// </summary>
    public class EventPagingArg : EventArgs
    {
        public int PageIndex { get; set; }

        public EventPagingArg(int pageIndex)
        {
            PageIndex = pageIndex;
        }
    }

    public class PagerViewModel : ViewModelBase
    {
        #region 构造器

        public PagerViewModel()
        {
            NextPageCommand = new RelayCommand(new Action(NextPageCommandExecute));
            PreviousPageCommand = new RelayCommand(new Action(PreviousPageCommandExecute));
            HomePageCommand = new RelayCommand(new Action(HomePageCommandExecute));
            TailPageCommand = new RelayCommand(new Action(TailPageCommandExecute));
        }


        #endregion

        #region Property
        private int pageIndex;

        public int PageIndex
        {
            get { return pageIndex; }
            set
            {
                pageIndex = value;
                this.RaisePropertyChanged("PageIndex");
                if (PagingHandler != null)
                    PagingHandler.Invoke(new EventPagingArg(PageIndex));
            }
        }

        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; this.RaisePropertyChanged("PageSize"); }
        }

        private int pageCount;

        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; this.RaisePropertyChanged("PageCount"); }
        }

        private int recordCount;

        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; this.RaisePropertyChanged("RecordCount"); }
        }

        private List<int> indexList;

        public List<int> IndexList
        {
            get { return indexList; }
            set { indexList = value; this.RaisePropertyChanged("IndexList"); }
        }

        #endregion

        #region 命令

        public RelayCommand NextPageCommand { get; set; }

        public RelayCommand PreviousPageCommand { get; set; }

        public RelayCommand HomePageCommand { get; set; }

        public RelayCommand TailPageCommand { get; set; }

        private void NextPageCommandExecute()
        {
            if (PageIndex < PageCount)
                PageIndex = PageIndex + 1;
        }
        private void PreviousPageCommandExecute()
        {
            if (PageIndex > 1)
                PageIndex = PageIndex - 1;
        }
        private void HomePageCommandExecute()
        {
            PageIndex = 1;
        }
        private void TailPageCommandExecute()
        {
            PageIndex = PageCount;
        }

        #endregion

        #region 事件

        public EventPagingHandler PagingHandler { get; set; }

        #endregion
    }
}
