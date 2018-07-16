using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Input;
using PlanMGMT.Utility;

//----------------------------------------------------------------*/
// 版权所有：
// 文 件 名：ConfigViewModel.cs
// 功能描述：
// 修改描述：
//----------------------------------------------------------------*/
namespace PlanMGMT.ViewModel
{
    public class ConfigViewModel : ViewModelBase
    {
        private ConfigHelper _config = null;
        private SysHelper _sys = new SysHelper();

        public ConfigViewModel()
        {
            if (!IsInDesignMode)// 不是在使用Blend设计的模式下
            {
                Loading();
            }
            this.RadioCommand = new ViewModelCommand((Object m) =>
            {
                int n = Int32.Parse(m.ToString());
                if (n == 1 || n == 2)
                    this.BtnOKText = "保存";
                else if (n == 3)
                    this.BtnOKText = "保存";
            });
            this.SaveCommand = new ViewModelCommand((Object parameter) => Save());
            this.SelectionMinuteChangedCommand = new ViewModelCommand((Object m) =>
            {
                this.LockMinute = (Int32)m;
            });
            this.OpenAppImgCommand = new ViewModelCommand((Object type) => OpenImage(type.ToString()));
        }

        #region 属性

        private string _btnText = "保存";
        private string _bgImg = PlanMGMT.Model.PM.AppBgImg;
        private string _lockImg = PlanMGMT.Model.PM.LockBgImg;
        private bool _isAutoRun = false;
        private bool _minToTray = false;
        private bool _saveLog = false;
        private bool _showNews = true;//启动时是否显示资讯
        private bool _AutoLogin = false;

        private int _lockMinute = PlanMGMT.Model.PM.LockMinute;
        private List<int> _lstMinute;

        /// <summary> 关闭最小化 </summary>
        public bool ShowNews
        {
            get { return _showNews; }
            set
            {
                this._showNews = value;
                base.RaisePropertyChanged("ShowNews");
            }
        }
        public bool AutoLogin
        {
            get { return _AutoLogin; }
            set
            {
                this._AutoLogin = value;
                base.RaisePropertyChanged("AutoLogin");
            }
        }
        /// <summary> 锁屏时间 </summary>
        public List<int> LstMinute
        {
            get { return _lstMinute; }
            set
            {
                this._lstMinute = value;
                base.RaisePropertyChanged("LstMinute");
            }
        }
        /// <summary> 关闭最小化 </summary>
        public bool MinToTray
        {
            get { return _minToTray; }
            set
            {
                this._minToTray = value;
                base.RaisePropertyChanged("MinToTray");
            }
        }
        /// <summary> 锁屏时间 分钟 </summary>
        public int LockMinute
        {
            get { return _lockMinute; }
            set
            {
                this._lockMinute = value;
                base.RaisePropertyChanged("LockMinute");
            }
        }
        /// <summary> 是否保存运行日志 </summary>
        public bool SaveLog
        {
            get { return _saveLog; }
            set
            {
                this._saveLog = value;
                base.RaisePropertyChanged("SaveLog");
            }
        }
        /// <summary> 是否自启 </summary>
        public bool IsAutoRun
        {
            get { return _isAutoRun; }
            set
            {
                this._isAutoRun = value;
                base.RaisePropertyChanged("IsAutoRun");
            }
        }
        /// <summary> 保存文字 </summary>
        public string BtnOKText
        {
            get { return _btnText; }
            set
            {
                this._btnText = value;
                base.RaisePropertyChanged("BtnOKText");
            }
        }
        /// <summary> 窗体背景 </summary>
        public string BgImg
        {
            get { return _bgImg; }
            set
            {
                this._bgImg = value;
                base.RaisePropertyChanged("BgImg");
            }
        }
        /// <summary> 锁屏背景 </summary>
        public string LockImg
        {
            get { return _lockImg; }
            set
            {
                this._lockImg = value;
                base.RaisePropertyChanged("LockImg");
            }
        }

        #endregion

        #region 命令

        public ICommand RadioCommand { set; get; }
        /// <summary> 保存  </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary> 选择图片  </summary>
        public ICommand OpenAppImgCommand { set; get; }
        /// <summary> 锁屏  </summary>
        public ICommand SelectionMinuteChangedCommand { set; get; }
        #endregion

        #region 方法

        private void OpenImage(string type)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "JPG文件|*.jpg|PNG文件|*.png";//全部|*.*||批处理|*.bat";
            if (ofd.ShowDialog() == true)
            {
                if (type == "1")//窗体
                {
                    this.BgImg = ofd.FileName;
                }
                else
                {
                    this.LockImg = ofd.FileName;
                }
            }
        }
        private void Save()
        {
            if (this.BtnOKText == "确定")
            {
                //this.Close();
                return;
            }
            this._sys.AutoStartup(this.IsAutoRun);
            PlanMGMT.Model.PM.MinToTray = this.MinToTray;

            this._config.SetValue("LockMinute", this.LockMinute.ToString());
            this._config.SetValue("SaveLog", this.SaveLog ? "1" : "0");
            this._config.SetValue("ShowNews", this.ShowNews ? "1" : "0");
            this._config.SetValue("isAutoLogin", this.AutoLogin ? "1" : "0");
            try
            {
                this._config.SetValue("AppBgImg", this.BgImg);
                this._config.SetValue("LockBgImg", this.LockImg);
                this._config.SetValue("MinToTray", PlanMGMT.Model.PM.MinToTray ? "1" : "0");
                this._config.Save();

                Helper.Instance.AlertSuccess("保存成功，部分设定在重启后生效！");
            }
            catch (Exception ex)
            {
                MSL.Tool.LogHelper.Instance.WriteLog("Config btnOK_Click\r\n" + ex.ToString());
                Helper.Instance.AlertError("保存失败！");
            }
        }
        private void Loading()
        {
            this._config = new ConfigHelper(PlanMGMT.Model.PM.Config);
            this.BgImg = this._config.GetValue("AppBgImg");
            this.LockImg = this._config.GetValue("LockBgImg");

            //自动启动
            if (this._sys.IsAutoStartup())
                this.IsAutoRun = true;

            this.LstMinute = new List<int>();
            for (int i = 1; i < 20; i++)
            {
                this.LstMinute.Add(i);
            }

            this.MinToTray = PlanMGMT.Model.PM.MinToTray;
            this.SaveLog = PlanMGMT.Model.PM.SaveLog;
            this.ShowNews = PlanMGMT.Model.PM.ShowNews;
            this.AutoLogin = PlanMGMT.Model.PM.isAutoLogin;
        }
        #endregion
    }
}
