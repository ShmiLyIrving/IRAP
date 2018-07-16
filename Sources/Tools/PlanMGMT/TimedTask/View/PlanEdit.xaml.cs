
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using PlanMGMT.Model;
using PlanMGMT.Utility;

namespace PlanMGMT.View
{
    /// <summary>
    /// TaskEdit.xaml 的交互逻辑
    /// </summary>
    public partial class PlanEdit : Window
    {
        private BLL.PlanBaseBLL _bllPlan = new BLL.PlanBaseBLL();
        //ObservableCollection实现了INotifyPropertyChanged和INotifyCollectionChanged接口 表示一个动态数据集合，在添加项、移除项或刷新整个列表时，此集合将提供通知
        public int ID { get; set; }
        //窗体加载
        public PlanEdit()
        {
            InitializeComponent();
            this.cboProject.ItemsSource = BLL.ProjectBLL.Instance.projects;
            this.cboStatus.ItemsSource = LoginBLL.Instance.PlanStatus;
            this.cboInCharge.ItemsSource = LoginBLL.Instance.Allusers;
            this.cboCoCharge.ItemsSource = LoginBLL.Instance.Allusers;
            this.cboPriority.ItemsSource = LoginBLL.Instance.Priorities;
           
        }
        //窗体初始化
        private void OnInit()
        {
            if (ID == 0)
            {
                this.btnOK.Content = "添加任务";
                this.cboInCharge.SelectedItem = LoginBLL.Instance.Allusers.Find((a)=>a.UserCode==ProU.Instance.PspUser.UserCode);
                if(ProU.Instance.PspUser.RoleID>1)
                {
                    cboInCharge.IsEnabled = true;
                }
                else
                {
                    cboInCharge.IsEnabled = false;
                }
                this.txtChangeCount.Text = "0";
                this.cboChecked.SelectedIndex = 0;
                dp_StartDate.SelectedDate = dp_StopDate.SelectedDate = DateTime.Now.Date;
                return;
            }
            else
            {
                this.btnOK.Content = "保 存";
            }

            PlanMGMT.Model.Plan model = _bllPlan.GetEntity<Plan>(" PlanID=" + ID);
            // 开始与停止时间

            if (model != null)
            {
                this.txtJobName.Text = model.JobName;
                this.cboProject.SelectedItem = BLL.ProjectBLL.Instance.projects.Find((a)=> a.ProjectID ==model.ProjectID);
                this.cboInCharge.SelectedItem = LoginBLL.Instance.Allusers.Find((a)=>a.UserCode== model.InCharge);
                this.cboCoCharge.SelectedItem = LoginBLL.Instance.Allusers.Find((a)=>a.UserCode ==model.CoCharge);
                this.dp_StartDate.SelectedDate = model.PlanStart;
                this.dp_StopDate.SelectedDate = model.PlanEnd;
                this.dp_AStartDate.SelectedDate = model.ActualStart;
                this.dp_AStopDate.SelectedDate = model.ActualEnd;
                this.cboStatus.SelectedItem = LoginBLL.Instance.PlanStatus.Find((a)=>a.StatusIndex==model.Status) ;
                this.txtChangeCount.Text = model.ChangeCount.ToString();
                this.cboChecked.SelectedIndex = model.Checked;
                this.txtHardRate.Text = model.HardRate.ToString();
                this.txtDependOn.Text = model.DependOn.ToString();
                this.txtCost.Text = model.CostMinutes.ToString();   
                this.cboPriority.SelectedItem = LoginBLL.Instance.Priorities.Find((a)=>a.PriorityIndex==model.Priority);
                this.txtRemark.Text = model.Remark;
            }            
        }
        //窗体加载
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OnInit();
        }
        //窗体移动
        private void bg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        //窗体关闭
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //保存
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {      
            if(string.IsNullOrEmpty(txtJobName.Text))
            {
                Helper.Instance.AlertError("任务名称不能为空");
                return;
            }  
            if(string.IsNullOrEmpty(cboInCharge.Text))
            {
                Helper.Instance.AlertError("负责人不能为空");
                return;
            }
            if(string.IsNullOrEmpty(cboProject.Text))
            {
                Helper.Instance.AlertError("所属项目不能为空");
                return;
            }
            if(dp_StartDate.SelectedDate==null)
            {
                Helper.Instance.AlertError("计划开始时间不能为空");
                return;
            }
            if(dp_StopDate.SelectedDate ==null)
            {
                Helper.Instance.AlertError("计划结束时间不能为空");
                return;
            }
            if(dp_StopDate.SelectedDate!=null&dp_StopDate.SelectedDate!=null&& Helper.Instance.GetDayEnd(dp_StopDate.SelectedDate)< Helper.Instance.GetDayBegin(dp_StartDate.SelectedDate))
            {
                Helper.Instance.AlertError("计划结束时间不能早于计划开始时间");
                return;
            }
            if(dp_AStopDate.SelectedDate!=null&&dp_AStartDate.SelectedDate!=null&&Helper.Instance.GetDayEnd(dp_AStopDate.SelectedDate)<Helper.Instance.GetDayBegin(dp_AStartDate.SelectedDate))
            {
                Helper.Instance.AlertError("实际结束时间不能早于实际开始时间");
                return;
            }
            if(string.IsNullOrEmpty(cboPriority.Text))
            {
                Helper.Instance.AlertError("任务优先级不能为空");
                return;
            }
            if(string.IsNullOrEmpty(cboStatus.Text))
            {
                Helper.Instance.AlertError("任务状态不能为空");
                return;
            }
            Plan model = new Plan();
            try
            {
                bool flag = ID == 0 ? true : false;//是否是新增
                model.JobName = txtJobName.Text.Trim();
                model.ProjectID = (cboProject.SelectedItem as Model.Project).ProjectID;
                model.InCharge = cboInCharge.SelectedIndex == -1 ? "" : (cboInCharge.SelectedItem as Entity.User).UserCode;
                model.CoCharge = cboCoCharge.SelectedIndex == -1 ? "":(cboCoCharge.SelectedItem as Entity.User).UserCode;
                model.PlanStart = Helper.Instance.GetDayBegin(dp_StartDate.SelectedDate);
                model.PlanEnd = Helper.Instance.GetDayEnd(dp_StopDate.SelectedDate);
                model.ActualStart = dp_AStartDate.SelectedDate == null ? null:Helper.Instance.GetDayBegin(dp_AStartDate.SelectedDate);
                model.ActualEnd =dp_AStopDate.SelectedDate == null ? null:Helper.Instance.GetDayEnd(dp_AStopDate.SelectedDate);
                model.Priority = (cboPriority.SelectedItem as Entity.Priority).PriorityIndex;
                model.Status = (cboStatus.SelectedItem as Entity.PlanStatus).StatusIndex;
                model.ChangeCount = short.Parse(txtChangeCount.Text);
                model.Checked = cboChecked.SelectedIndex;
                float h; int d, c;
                float.TryParse(txtHardRate.Text ,out h);
                model.HardRate = h;
                int.TryParse(txtDependOn.Text,out d);
                model.DependOn = d;
                int.TryParse(txtCost.Text,out c);
                model.CostMinutes = c;
                model.Remark = txtRemark.Text.Trim();
                if (!flag)//修改
                {
                    model.PlanID = ID;
                    model.ChangeCount++;
                    this._bllPlan.Update(model, " PlanID=" + ID);
                    Helper.Instance.AlertSuccess("保存设置成功！" + (DateTime.Now > model.PlanEnd ? " 警告：任务已过期！" : ""));
                }
                else//新增
                {
                    model.BizTime = DateTime.Now;
                    model.Operator = ProU.Instance.PspUser.UserCode;
                    _bllPlan.Add(model);

                    Helper.Instance.AlertError("新增成功！" + (DateTime.Now.Date > model.PlanEnd ? " 警告：任务已过期！" : ""));
                    btnReset_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Helper.Instance.AlertError("保存设置失败！"+ex.Message);
                MSL.Tool.LogHelper.Instance.WriteLog("TaskEdit btnOK_Click\r\n" + ex.ToString());
            }
        }
        //重置
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.txtJobName.Text = "";
            this.cboProject.SelectedIndex = -1;
            this.cboCoCharge.SelectedIndex = -1;
            this.cboPriority.SelectedIndex = -1;
            this.cboStatus.SelectedIndex = -1;
            this.txtHardRate.Text = "1";
            this.txtDependOn.Text = "0";
            this.txtCost.Text = "0";
            this.txtRemark.Text = "";
            OnInit();
        }
        //窗口关闭
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Helper.Instance.StopAudio();
        }
    }
}
