using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using PlanMGMT.BLL;
using PlanMGMT.Enums;
using PlanMGMT.Utility;

//----------------------------------------------------------------*/
// 文 件 名：TaskListViewModel.cs
// 功能描述：
// 修改描述：
//----------------------------------------------------------------*/
namespace PlanMGMT.ViewModel
{
    public class PlanListViewModel : ViewModelBase
    {
        private List<Model.PlanByName> _inchargelist = new List<Model.PlanByName>();
        private BLL.PlanBaseBLL _bllPlan = new BLL.PlanBaseBLL();
        private Entity.PlanFilter filter = new Entity.PlanFilter();       
        public PlanListViewModel()
        {
            if (!IsInDesignMode)
            {
                Load(filter);
                this._plan = new PlanMGMT.Model.Plan();
                this.LoadCommand = new ViewModelCommand((Object parameter) =>
                {
                    if (parameter == null)
                    {
                        Load(filter);
                    }
                    else
                    {
                        filter = (Entity.PlanFilter)parameter;
                        Load(filter);
                    }
                });

                #region 温馨提示
                string msg ="您有：" +PlanBLL.Instance.RunningTaskCnt()+ "条正在进行中任务，正在为您自动计时\r\n";               
                msg += " 您有：" + PlanBLL.Instance.UnStartTaskCnt() + "条未开始任务\r\n";
                msg += " 您有：" + PlanBLL.Instance.StopTaskCnt() + "条暂停中任务\r\n";
                msg += " 您有：" + PlanBLL.Instance.PastTaskCnt() + "条任务已延期\r\n";                
                Helper.Instance.ShowPupUp("任务提示！", null, msg);
                #endregion

                this.SaveCommand = new ViewModelCommand((Object parameter) => Save());
                this.AddCommand = new ViewModelCommand((Object parameter) =>
                {
                    View.PlanEdit edit = new View.PlanEdit();
                    edit.ID = 0;
                    edit.Closed += new EventHandler(Edit_Closed);//注册关闭事件 
                    edit.Show();
                });
                this.ContextMenuCommand = new ViewModelCommand((Object n) => { TaskListContextClick(n.ToString()); });
                this.TimerCommand = new ViewModelCommand((Object parameter) =>
                {
                PlanModel = parameter == null ? null : parameter as Model.Plan;
                if (this.PlanModel == null || PlanModel.PlanID == 0)
                {
                    Helper.Instance.AlertWarning("没有任何选中项！");
                    return;
                }
                    if (PlanModel.Status == 0)
                    {
                        Helper.Instance.AlertConfirm("不可撤销操作！", "是否开始任务？", () =>
                          {
                              try
                              {
                                  PlanBLL.Instance.StartPlan(PlanModel.PlanID);
                              }
                              catch (Exception e)
                              {
                                  Helper.Instance.AlertError("操作失败：" + e.Message);
                              }
                          });
                    }
                    else if (PlanModel.Status == 1)
                    {
                        Helper.Instance.AlertChoice("不可撤销操作！", "请选择要执行的操作？", 
                            () =>
                                 {
                                     try
                                     {
                                         PlanBLL.Instance.StopPlan(PlanModel.PlanID);
                                     }
                                     catch (Exception e)
                                     {
                                         Helper.Instance.AlertError("操作失败：" + e.Message);
                                     }
                                 }, 
                            () =>
                                  {
                                      try
                                      {
                                          PlanBLL.Instance.CompeletePlan(PlanModel.PlanID);
                                      }
                                      catch (Exception e)
                                      {
                                          Helper.Instance.AlertError("操作失败：" + e.Message);
                                      }
                                  });
                    }   
                    else if(PlanModel.Status == 2)
                    {
                        Helper.Instance.AlertWarning("您无法操作已经完成的任务");
                    }     
                    else if(PlanModel.Status == 3)
                    {
                        Helper.Instance.AlertConfirm(null, "继续开始您的任务？", () =>
                          {
                              try
                              {
                                  PlanBLL.Instance.ContinuePlan(PlanModel.PlanID);
                              }
                              catch (Exception e)
                              {
                                  Helper.Instance.AlertError("操作失败：" + e.Message);
                              }
                          });
                    }          
                    Load(filter);
                });
            }
            this.TaskListItemCommand = new ViewModelCommand((Object m) => TaskListItemClick(m.ToString()));
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 60000;//1分钟执行一次
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Task);
            timer.Start();
        }


        private void Edit_Closed(object sender, EventArgs e)
        {
            Load(filter);
        }
        private void Timer_Task(object sender, System.Timers.ElapsedEventArgs e)
        {
                _bllPlan.AddMinute();
                Load(filter);          
        }

        #region 属性
        private PlanMGMT.Model.Plan _plan;
        private List<PlanMGMT.Model.Plan> _planList;
        private List<Model.Project> _projectList;
        private string _planMsg = "您可在左侧面版设置查询条件...";

        private bool _isExpandAll =false;
        public bool IsExpandAll
        {
            get
            {
                return _isExpandAll;
            }
            set
            {
                if (value == _isExpandAll)
                    return;
                _isExpandAll = value;
                foreach(var i in InChargeList)
                {
                    i.IsExpanded = value;
                }
                Load(filter);
                base.RaisePropertyChanged("IsExpandAll");
            }
        }
        public List<Model.PlanByName> InChargeList
        {
            get { return _inchargelist; }
            set
            {
                _inchargelist = value;
                base.RaisePropertyChanged("InChargeList");
            }
        }
        /// <summary> 任务信息 </summary>
        public string PlanMsg
        {
            get { return _planMsg; }
            set
            {
                if (this._planMsg == value) return;
                this._planMsg = value;
                base.RaisePropertyChanged("PlanMsg");
            }
        }
        /// <summary> 当前选择的任务 </summary>
        public PlanMGMT.Model.Plan PlanModel
        {
            get { return _plan; }
            set
            {
                if (this._plan == value) return;
                this._plan = value;
                base.RaisePropertyChanged("Plan");
            }
        }
        public List<Model.Project> ProjectList
        {
            get { return _projectList; }
            set
            {
                _projectList = value;
                base.RaisePropertyChanged("ProjectList");
            }
        }
        /// <summary>
        /// 任务列表
        /// </summary>
        public List<PlanMGMT.Model.Plan> PlanList
        {
            get { return _planList; }
            set
            {
                _planList = value;
                base.RaisePropertyChanged("PlanList");
            }
        }


        #endregion

        #region 命令

        public ICommand _planSelectedChangedCommand;
        public ICommand _expandedCommand;
        public ICommand _collapsedCommand;
        public ICommand TaskListItemCommand { get; set; }
        /// <summary> 收缩展开 </summary>
        public ICommand ShowDispModeCommand { get; set; }
        /// <summary> 声音列表选择 </summary>
       
        /// <summary> 列表选择 </summary>
        public ICommand PlanSelectedChangedCommand
        {
            get
            {
                if (_planSelectedChangedCommand == null)
                {
                    _planSelectedChangedCommand = new ViewModelCommand((Object mod) =>
                    {
                        this.PlanModel = (PlanMGMT.Model.Plan)mod;
                    });
                }
                return _planSelectedChangedCommand;
            }
        }
  
     
        /// <summary> 保存  </summary>
        public ICommand SaveCommand { get; set; }
        /// <summary> 添加  </summary>
        public ICommand AddCommand { get; set; }
        /// <summary> 加载  </summary>
        public ICommand LoadCommand { get; set; }
        /// <summary> 上下文菜单  </summary>
        public ICommand ContextMenuCommand { get; set; }
        public ICommand TimerCommand { get; set; }
        #endregion

        #region 方法

        private void TaskListItemClick(string p)
        {
            PlanBLL.Instance.ItemClick(p, this.PlanModel);
            Load(filter);
        }
        private void TaskListContextClick(string type)
        {
           
        }
        //运行选中项
        
        private void Save()
        {
            if (this.PlanModel == null)
            {
                Helper.Instance.AlertWarning("没有任何选中项！");
                return;
            }
            try
            {
                _bllPlan.Update(this.PlanModel, "PlanID=" + this.PlanModel.PlanID);
                Helper.Instance.AlertSuccess("操作成功！");
            }
            catch (Exception ex)
            {
                MSL.Tool.LogHelper.Instance.WriteLog("NoteListModule btnOK_Click\r\n" + ex.ToString());
                Helper.Instance.AlertError("系统异常，操作失败！");
            }
        }
        private string GenerateWhereSql()
        {
            string s="";
            return s;
        }
        private void Load(Entity.PlanFilter filter)
        {
            //this.IsShowTitleList = true;
            this.PlanList = PlanMGMT.BLL.PlanBLL.Instance.GetPlanList(filter.GenerateFilter(), "InCharge,Status,PlanStart") ;
            if (this.PlanList == null)
                return;

            if (this.PlanList.Count >=0)
            {
                this.PlanMsg = "共有 " + this.PlanList.Count + " 条记录，您可点的左侧按钮改变显示模式...";
                if (PlanList.Count > 0)
                {                
                    List<string> uers = PlanList.Select(x => x.InCharge).Distinct().ToList<string>();
                    List<Model.PlanByName> incharges = new List<Model.PlanByName>();
                    foreach (var u in uers)
                    {
                        incharges.Add(new Model.PlanByName(u, LoginBLL.Instance.GetUserNameByCode(u)));
                    }
                    InChargeList = incharges;
                }
                else
                {
                    InChargeList=null;
                }
            }
        }
        #endregion
    }
}
