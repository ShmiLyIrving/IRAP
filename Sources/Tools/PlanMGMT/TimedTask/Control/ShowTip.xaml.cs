using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace PlanMGMT.Control
{
    /// <summary>
    /// ScreenTip.xaml 的交互逻辑
    /// </summary>
    public partial class ShowTip : Window
    {
        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipType">信息类别</param>
        /// <param name="msg">提示信息</param>
        public ShowTip(ShowTipType tipType, string msg)
        {
            InitializeComponent();
            OnInit(tipType, null, msg);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipType">窗口类别</param>
        /// <param name="title">窗口标题</param>
        /// <param name="msg">提示信息</param>
        public ShowTip(ShowTipType tipType, string title, string msg)
        {
            InitializeComponent();
            OnInit(tipType, title, msg);
        }
        #endregion
        #region 初始化

        /// <summary>
        /// 初始化窗口
        /// </summary>
        /// <param name="tipType">窗口类别</param>
        /// <param name="title">窗口标题</param>
        /// <param name="msg">提示信息</param>
        private void OnInit(ShowTipType tipType, string title, string msg)
        {
            if (tipType == ShowTipType.Confirm)
            {
                this.spTip.Visibility = Visibility.Collapsed;
                this.spConfim.Visibility = Visibility.Visible;
                this.btnStop.Visibility = Visibility.Collapsed;
                this.txtInfo.Text = msg;
                this.btnAccept.Content = "确定";
                this.spConfim.Width = this.Width = 300;
                this.spConfim.Height = this.Height = 140;
                this.lblTitle.Content = String.IsNullOrEmpty(title) ? "系统提示" : title;
                return;
            }
            else if(tipType == ShowTipType.Choice)
            {
                this.spTip.Visibility = Visibility.Collapsed;
                this.spConfim.Visibility = Visibility.Visible;
                this.spConfim.Width = this.Width = 300;
                this.spConfim.Height = this.Height = 140;
                this.txtInfo.Text = msg;
                this.btnAccept.Content = "暂停";
                this.btnStop.Visibility = Visibility.Visible;
                this.lblTitle.Content = String.IsNullOrEmpty(title) ? "系统提示" : title;
                return;
            }
            this.Width = 50 + MSL.Tool.CString.GetLen(msg) * 8;
            #region 定时关闭提示窗口

            this.Loaded += (sender, e) =>
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(2000);// 2000;//2秒钟关闭
                timer.Tick += (s, t) =>
                {
                    if (timer != null)
                        timer.Stop();
                    this.Close();
                };
                timer.Start();
            };
            #endregion
            #region 成功/失败/警告 提示信息

            string tipImg = "";
            Brush bdBrush = null;
            Brush spBrush = null;
            switch (tipType)
            {
                case ShowTipType.Ok:
                    tipImg = "/Theme/Images/Tip/ok.png";
                    bdBrush = new SolidColorBrush(Color.FromRgb(135, 196, 120));//#87c478
                    spBrush = new SolidColorBrush(Color.FromRgb(231, 250, 225));//#e7fae1
                    break;
                case ShowTipType.Warning:
                    tipImg = "/Theme/Images/Tip/warn.png";
                    bdBrush = new SolidColorBrush(Color.FromRgb(186, 175, 2));//#baaf02
                    spBrush = new SolidColorBrush(Color.FromRgb(254, 251, 195));//#fefbc3
                    break;
                case ShowTipType.Error:
                    tipImg = "/Theme/Images/Tip/error.png";
                    bdBrush = new SolidColorBrush(Color.FromRgb(176, 0, 8));//#b00008
                    spBrush = new SolidColorBrush(Color.FromRgb(206, 136, 136));//#ce8888
                    break;
                case ShowTipType.Information:
                default:
                    tipImg = "/Theme/Images/Tip/ok.png";
                    bdBrush = new SolidColorBrush(Color.FromRgb(135, 196, 120));//#87c478
                    spBrush = new SolidColorBrush(Color.FromRgb(231, 250, 225));//#e7fae1
                    break;
            }
            this.mainBoder.BorderBrush = bdBrush;
            this.mainBoder.Background = spBrush;
            this.imgTip.Source = new BitmapImage(new Uri(tipImg, UriKind.Relative));

            spBrush = null;
            bdBrush = null;
            this.lblMsg.Content = msg;
            #endregion
        }
        #endregion

        /// <summary>窗体关闭</summary>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public enum ShowTipType
    {
        /// <summary>基本信息 无图标</summary>
        Information = 0,
        /// <summary>成功</summary>
        Ok = 1,
        /// <summary>警告</summary>
        Warning = 2,
        /// <summary>错误</summary>
        Error = 3,
        /// <summary>确定</summary>
        Confirm = 4,
        /// <summary>
        /// 选择
        /// </summary>
        Choice = 5
    }
}
