using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using PlanMGMT.BLL;
using PlanMGMT.Utility;

namespace PlanMGMT
{
    /// <summary>
    /// 后台任务 定时任务执行
    /// </summary>
    public partial class BackgroundWindow : Window
    {
        private static System.Timers.Timer timerTask = null;//
        // 程序退出
        public static void ExitApp()
        {
            App.Current.Dispatcher.Invoke(new Action(
                delegate
                {
                    if (timerTask != null)
                        timerTask.Dispose();

                    NotifyIconHelper.Instance().Hide();
                    App.Current.Shutdown();
                }
                ), null);
        }

        public BackgroundWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
            NotifyIconHelper.Instance();

            BLL.SysLogBLL taskLog = new BLL.SysLogBLL();
            MSL.Tool.IOHelper.Instance.DeleteFiles(MSL.Tool.LogHelper.LogPath, new string[] { ".txt", ".log" }, 4);//删除4天前日志文件
            taskLog.DeleteHistory();
            MSL.Tool.IOHelper.Instance.CreateFolder(MSL.Tool.LogHelper.LogPath);
        }

    }
}
