using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PlanMGMT.Utility;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media;

namespace PlanMGMT
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Module.TaskListModule _tlModule = new Module.TaskListModule();      //任务列表模块
        //private Module.NoteListModule _nlModule = new Module.NoteListModule();      //记事本列表模块
        private Module.MainModule _mmModule = new Module.MainModule();              //主页模块
        //private Module.MessageListModule _mlModule = new Module.MessageListModule();//消息模板
        private Module.PlanListModule _plModule = new Module.PlanListModule();//计划模板
        private Module.ReportModule _rpModule = new Module.ReportModule(); //日志模板
        public MainWindow()
        {
            InitializeComponent();
            this.SourceInitialized += delegate (object sender, EventArgs e)
            {
                this._HwndSource = PresentationSource.FromVisual((Visual)sender) as HwndSource;
            };
            this.MouseMove += new MouseEventHandler(Window_MouseMove);
            XamlHelper.Instance.SetBackground(this.mainborder, PlanMGMT.Model.PM.AppBgImg);
            #region 窗体事件

            this.MouseLeftButtonDown += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
            };
            //窗体最小化
            this.btnMin.Click += (s, e) =>
            {
                this.WindowState = System.Windows.WindowState.Minimized;
                this.Visibility = Visibility.Hidden;//最小化到托盘
            };
            //窗体关闭
            this.btnClose.Click += (s, e) =>
            {
                if (PlanMGMT.Model.PM.MinToTray)
                {
                    Minimized();
                    return;
                }
                BackgroundWindow.ExitApp();
            };
            #endregion
            #region 主菜单

            //首页
            this.btnMain.Click += (s, e) =>
            {
                if (this.brMain.Child != this._mmModule) this.brMain.Child = this._mmModule;
            };
            //设置
            this.btnSet.Click += (s, e) =>
            {
                View.Config config = new View.Config();
                config.Owner = this;
                config.ShowDialog();
            };
            //记事
            //this.btnNote.Click += (s, e) =>
            //{
            //    if (this.brMain.Child != this._nlModule) this.brMain.Child = this._nlModule;
            //};
            //任务
            this.btnTask.Click += (s, e) =>
            {
                if (this.brMain.Child != this._rpModule) this.brMain.Child = this._rpModule;
            };
            //计划
            this.btnPlan.Click += (s, e) =>
            {
                if (this.brMain.Child != this._plModule) this.brMain.Child = this._plModule;
            };

            #endregion
            #region 弹出资讯
            
            if (Model.PM.ShowNews)
            {
                this.WindowState = System.Windows.WindowState.Minimized;
            }
            #endregion
            if (this.brMain.Child != this._plModule) this.brMain.Child = this._plModule;
            NotifyIconHelper.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(TaskBarLeftDown_Click);
            #region 接收消息
            //EsbHelper.Instance.BeginReceiveMessage();
            #endregion
        }
        #region  窗体缩放
        private const int WM_SYSCOMMAND = 0x112;
        private HwndSource _HwndSource;
        private Dictionary<ResizeDirection, Cursor> cursors = new Dictionary<ResizeDirection, Cursor>
        {
            {ResizeDirection.BottomRight, Cursors.SizeNWSE}
        };
        private enum ResizeDirection
        {
            BottomRight = 8,
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public void SetBackground(string imgpath)
        {
            XamlHelper.Instance.SetBackground(this.mainborder, imgpath);
        }
        void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton != MouseButtonState.Pressed)
            {
                FrameworkElement element = e.OriginalSource as FrameworkElement;
                if (element != null && !element.Name.Contains("Resize"))
                    this.Cursor = Cursors.Arrow;
            }
        }
        private void ResizePressed(object sender, MouseEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            ResizeDirection direction = (ResizeDirection)Enum.Parse(typeof(ResizeDirection), element.Name.Replace("Resize", ""));
            this.Cursor = cursors[direction];
            if (e.LeftButton == MouseButtonState.Pressed)
                ResizeWindow(direction);         
        }
        private void ResizeWindow(ResizeDirection direction)
        {
            SendMessage(_HwndSource.Handle, WM_SYSCOMMAND, (IntPtr)(61440 + direction), IntPtr.Zero);
        }
        #endregion
        #region 托盘相关

        /// <summary>
        /// 任务栏单击击图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskBarLeftDown_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Show();
                if (this.WindowState == System.Windows.WindowState.Minimized)
                {
                    this.WindowState = System.Windows.WindowState.Normal;
                }
                this.Activate();
            }
        }
        #endregion

        #region 窗体

        /// <summary>
        /// 窗口最小化
        /// </summary>
        private void Minimized()
        {
            this.WindowState = System.Windows.WindowState.Minimized;
            this.Visibility = Visibility.Hidden;//最小化到托盘
        }

        #endregion

        #region 菜单事件
        //下拉菜单
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string arg = ((sender as MenuItem).CommandParameter).ToString();
            if (arg.Length == 0)
                return;

            switch (arg)
            {
                case "1"://登录
                    //View.Login login = new View.Login();
                    //login.ShowDialog();
                    break;
                case "2"://检查更新
                    Helper.Instance.Alert("开发中...");
                    break;
                case "3"://新闻资讯
               
                    break;
                case "4"://关于
                    View.About about = new View.About();
                    about.Owner = this;
                    about.Show();
                    break;
                case "5"://退出
                    NotifyIconHelper.Instance().Hide();
                    Application.Current.Shutdown();
                    break;
                case "0-1"://网页图片下载
                    View.PageImageDown pageImage = new View.PageImageDown();
                    pageImage.Show();
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void ResizeBottomRight_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount>1)
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
            }
        }    
    }
}
