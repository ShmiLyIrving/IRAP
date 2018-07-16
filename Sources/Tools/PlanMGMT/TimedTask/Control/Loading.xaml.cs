using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PlanMGMT.Control
{
    /// <summary>
    /// 加载框
    /// </summary>
    public partial class Loading : Window
    {
        /* 使用方法
          Control.Loading load = new Control.Loading(Test);
          load.Msg = "稍等。。。";
          load.Start();
          load.ShowDialog();
         
          private void Test()
          {
              System.Threading.Thread.Sleep(15000);
          }
         */
        public Action WorkMethod;

        private string _msg = "正在加载...";
        private string _message = string.Empty;
        private Storyboard _storyboard;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            this._storyboard.Begin(this.image, true);
        }
        public void Stop()
        {
            base.Dispatcher.BeginInvoke(new Action(() =>
            {
                this._storyboard.Pause(this.image);
                base.Visibility = System.Windows.Visibility.Collapsed;
            }));
        }
        public Loading(Action workMethod)
        {
            InitializeComponent();
            this._storyboard = (base.Resources["waiting"] as Storyboard);

            this.lblMsg.Content = this.Msg;
            this.WorkMethod = workMethod;
        }
        public void Start()
        {
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.DoWork += (obj, e) =>
                {
                    this.WorkMethod();
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    this.Close();
                };
                bw.RunWorkerAsync();
            }
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
