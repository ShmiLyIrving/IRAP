using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading.Tasks;

namespace PlanMGMT.Control
{
    /// <summary>
    /// PopUP.xaml 的交互逻辑
    /// </summary>
    public partial class PopUP : Window
    {
        private static PopUP _instance;
        private static readonly object _lock = new Object();

        /// <summary> 消息主题 </summary>
        public string Subject { get; set; }
        /// <summary>  消息内容 </summary>
        public string Msg { get; set; }
        /// <summary> 窗口标题 </summary>
        public string PopTitle { get; set; }
        #region 单一实例
        /// <summary>
        /// 
        /// </summary>

        /// <summary>
        /// 返回唯一实例
        /// </summary>
        public static PopUP Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                             _instance = new PopUP();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            //Dispose(true);
            _instance.Loaded -= Loading;
            this.Dispatcher.Invoke(
                            new Action(
                                delegate
                                {
                                    _instance.Close();
                                }));

            _instance = null;
            GC.SuppressFinalize(this);
        }
        #endregion
        
        public PopUP()
        {
            InitializeComponent();
            this.Left = SystemParameters.WorkArea.Width - this.Width;
            this.Top = SystemParameters.WorkArea.Height - this.Height;
            this.Loaded += Loading;           
        }
        private void Loading(object sender ,RoutedEventArgs e)
        {
                   
        }
          
        private void PopWin_Loaded(object sender, RoutedEventArgs e)
        {
            this.Msg = this.Msg == null ? "" : this.Msg;
            this.Subject = this.Subject == null ? "" : this.Subject;
            this.lblTitle.Content = this.PopTitle == null ? "系统信息" : this.PopTitle;

            if (this.Subject.Length == 0)
            {
                this.txtInfo.Inlines.Remove(this.txtSubject);
            }
            else
            {
                this.txtSubject.Text = this.Subject.Length > 18 ? this.Subject.Substring(0, 18) + "..." : this.Subject;
                this.txtSubject.Text += "\r\n";
            }
            this.txtContent.Text = (this.Msg.Length > 70 ? this.Msg.Substring(0, 70) + "..." : this.Msg);
        }
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            tm.Tick += new EventHandler(tm_Tick);
            tm.Interval = TimeSpan.FromSeconds(1);
            tm.Start();
        }
        DispatcherTimer tm = new DispatcherTimer();
        void tm_Tick(object sender, EventArgs e)
        {
            tm.Stop();
            tm.Tick -= tm_Tick;
            Dispose();
        }

        private void Canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
