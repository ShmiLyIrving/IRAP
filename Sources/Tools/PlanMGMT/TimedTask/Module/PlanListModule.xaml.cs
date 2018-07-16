using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using PlanMGMT.BLL;

namespace PlanMGMT.Module
{
    /// <summary>
    /// TaskListModule.xaml 的交互逻辑
    /// </summary>
    public partial class PlanListModule : UserControl
    {
        private Entity.PlanFilter filter = new Entity.PlanFilter();
        public PlanListModule()
        {
            InitializeComponent();
            this.IsShowTitleList = true;
            this.IsExpandAll = false;
            this.cboDept.ItemsSource = LoginBLL.Instance.GetDepts();
            this.cboStatus.ItemsSource = LoginBLL.Instance.PlanStatus;
            this.cboProject.ItemsSource = BLL.ProjectBLL.Instance.projects;
            this.cboInCharge.ItemsSource = LoginBLL.Instance.Allusers;
            this.dp_StartDate.SelectedDate = Helper.Instance.GetLastMondayDate();
            this.dp_EndDate.SelectedDate = Helper.Instance.GetNextSundayDate();
            this.btnImgDispMode.PreviewMouseLeftButtonDown += (s, e) =>
            {
                this.IsShowTitleList = !this.IsShowTitleList;
                this.btnImgDispMode.Source = new BitmapImage(
                    new Uri(this.IsShowTitleList ? "/Theme/Images/Button/frm_left_hide.png" : "/Theme/Images/Button/frm_left_show.png", UriKind.Relative)
                    );
                string key = this.IsShowTitleList ? "InChargeTitleTemplate" : "InChargeSummaryTemplate";
                this.lstMain.ItemTemplate = (DataTemplate)this.FindResource(key);
            };
        }
        protected void ShowMenuItem_Click(object sender, EventArgs e)
        {
            PlanMGMT.Model.Plan plan = (sender as Button).DataContext as PlanMGMT.Model.Plan;
            PlanBLL.Instance.ItemClick("1", plan);
            ((ViewModel.PlanListViewModel)base.DataContext).LoadCommand.Execute(null);
        }
        protected void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            PlanMGMT.Model.Plan plan = (sender as Button).DataContext as PlanMGMT.Model.Plan;
            PlanBLL.Instance.ItemClick("2", plan);
            ((ViewModel.PlanListViewModel)base.DataContext).LoadCommand.Execute(null);
        }
        protected void LockMenuItem_Click(object sender, EventArgs e)
        {
            PlanMGMT.Model.Plan plan = (sender as Button).DataContext as PlanMGMT.Model.Plan;
            Error error = PlanBLL.Instance.GetEnableTimer(plan);
            if (error.ErrCode != 0)
            {
                Helper.Instance.AlertError(error.ErrText);
                return;
            }
            ((ViewModel.PlanListViewModel)base.DataContext).TimerCommand.Execute(plan);
        }
        /// <summary>
        /// 是否以标题列表显示任务列表
        /// </summary>
        public bool IsShowTitleList { get; set; }
        public bool IsExpandAll { get; set; }

        private void ListBox_Answers_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((System.Windows.Controls.Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }
        private void btnSerch_Click(object sender, RoutedEventArgs e)
        {
            if(dp_EndDate.SelectedDate<dp_StartDate.SelectedDate)
            {
                Helper.Instance.AlertWarning("结束时间不能早于开始时间");
                return;
            }
            else
            {
                filter.StartDate = dp_StartDate.SelectedDate;
                filter.StopDate = dp_EndDate.SelectedDate;
            }
            filter.ProjectID =cboProject.SelectedItem==null?-1: (cboProject.SelectedItem as Model.Project).ProjectID;
            filter.InCharge =cboInCharge.SelectedItem==null?"":(cboInCharge.SelectedItem as Entity.User).UserCode;
            filter.Status =cboStatus.SelectedItem==null?(short)-1:(cboStatus.SelectedItem as Entity.PlanStatus).StatusIndex;
            filter.DeptID =cboDept.SelectedItem==null?-1:(cboDept.SelectedItem as Entity.Department).deptid;
            ((ViewModel.PlanListViewModel)base.DataContext).LoadCommand.Execute(filter);
        }
    }
}
