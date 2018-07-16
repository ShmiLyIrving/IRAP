using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using PlanMGMT.Model;
using PlanMGMT.Module;
using System.Windows.Input;

using PlanMGMT.Utility;

namespace PlanMGMT.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportViewModel : ViewModelBase
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ReportViewModel()
        {
            this.UserCode = ProU.Instance.PspUser.UserCode;
            if (!IsInDesignMode)
            {
                DateTime dt = DateTime.Now;
                Load(dt);
                this.LoadCommand = new ViewModelCommand((Object parameter) =>
                {
                    Load(parameter);
                });
                this.CommitCommand =  new ViewModelCommand((Object parameter) =>
                {
                    Commit();
                });
            }
        }
        public string UserCode
        {
            get;set;
        }
        public List<DateTime> CommitDates
        {
            get
            {
                return BLL.ReportBLL.Instance.CurrentCommitDates;
            }
            set
            {
                base.RaisePropertyChanged("CommitDates");
            }
        }
        private string _daily="";
        private string _tomorrowdaily="";
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                base.RaisePropertyChanged("SelectedDate");
            }
        }
        public string Daily
        {
            get
            {
                return _daily;
            }
            set
            {
                _daily = value;
                base.RaisePropertyChanged("Daily");
            }
        }
        public string TomorrowDaily
        {
            get
            {
                return _tomorrowdaily;
            }
            set
            {
                _tomorrowdaily = value;
                base.RaisePropertyChanged("TomorrowDaily");
            }
        }
        public ICommand LoadCommand { get; set; }
        public void Load(object param)
        {
            DateTime dt = Convert.ToDateTime(param);
            SelectedDate = dt;
            CommitDates = BLL.ReportBLL.Instance.GetCurCommitDates(dt);
            Entity.WorkLog log = BLL.ReportBLL.Instance.GetCurLog(dt);
            if (log != null)
            {
                Daily = log.Daily;
                TomorrowDaily = log.TomorrowDaily;
            }
            else
            {
                Daily = "";
                TomorrowDaily = "";
            }
        }
        public ICommand CommitCommand { get; set; }
        public void Commit()
        {
            if (string.IsNullOrEmpty(Daily))
            {
                Helper.Instance.AlertError("您的今日总结不能为空");
                return;
            }

            Error error = BLL.ReportBLL.Instance.Commit(Daily, TomorrowDaily, SelectedDate);
            if (error.ErrCode == 0)
            {
                Helper.Instance.AlertSuccess("提交成功");
                Load(SelectedDate);
            }
            else
            {
                Helper.Instance.AlertError("提交日志失败" + error.ErrText);
            }
        }
    }
}
