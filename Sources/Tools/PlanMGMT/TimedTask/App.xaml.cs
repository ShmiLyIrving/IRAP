using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Xml;
using PlanMGMT.Model;
using PlanMGMT.Utility;

namespace PlanMGMT
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        //单实例运行代码
        Mutex mutex;
        //应用程序启动前调用
        protected override void OnStartup(StartupEventArgs e)
        {
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            base.OnStartup(e);
            bool startupFlag;
            mutex = new Mutex(true, PM.ApplicationName, out startupFlag);
            if (!startupFlag)
            {
                if (!PM.IsMainWinShow)
                {
                    PM.IsMainWinShow = true;
                    //激活已运行实例
                }

                MessageBox.Show("程序已经启动！");
                Environment.Exit(0);

            }
            else
            {
                if (e.Args.Length > 0)//启动参数
                {

                }
                OnInit();

                View.Login login = new View.Login();
                
                if (login.ShowDialog() == true)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else
                {
                    BackgroundWindow.ExitApp();
                }
            }
        }

        //系统初始化
        private void OnInit()
        {
            PM.StartPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            PM.Config = PM.StartPath + "\\Config.xml";
            //this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(Application_Error);//注册全局Application_Error

            ConfigHelper config = new ConfigHelper(PM.Config);
            MSL.Tool.LogHelper.LogPath = PM.StartPath + "\\Log\\";
            if (!System.IO.File.Exists(PM.Config))
            {
                Helper.Instance.AlertWarning("配置文件丢失！");
                Application.Current.Shutdown();
            }
            try
            {
                string minutes = config.GetValue("LockMinute");
                PM.AppBgImg = config.GetValue("AppBgImg");
                PM.LockBgImg = config.GetValue("LockBgImg");
                PM.MinToTray = config.GetValue("MinToTray") == "1" ? true : false;
                PM.ShowNews = config.GetValue("ShowNews") == "1" ? true : false;
                PM.LockMinute = minutes.Length == 0 ? 3 : Convert.ToInt32(minutes);
                PM.SaveLog = config.GetValue("SaveLog") == "1" ? true : false;
                PM.NewsUrl = config.GetValue("NewsUrl");
                PM.ExCode = config.GetValue("ExCode");
                PM.isSavePass= config.GetValue("isSavePass") == "1" ? true : false;
                PM.isAutoLogin =config.GetValue("isAutoLogin") == "1" ? true : false;
                PM.UserCode = config.GetValue("UserCode");
                if(!string.IsNullOrEmpty(config.GetValue("UserPass"))&&PM.isSavePass ==true)
                    PM.UserPass = Utility.Encrypt.Instance.DecryptString(config.GetValue("UserPass"));

                XmlNode node = config.GetXmlNode("Configuration/NewsTag");
                PM.NewsTag = new SortedList();
                string key = String.Empty;
                if (node != null && node.HasChildNodes)
                {
                    foreach (XmlElement v in node.ChildNodes)
                    {
                        key = v.Attributes["title"].InnerText;
                        if (PM.NewsTag.ContainsKey(key))
                            continue;

                        PM.NewsTag.Add(key, v.InnerText.Replace("<![CDATA[", "").Replace("]]>", ""));
                    }
                }
                if (PM.AppBgImg.Length == 0)
                    PM.AppBgImg = PM.StartPath + "\\Bg\\bg.jpg";
                if (PM.LockBgImg.Length == 0)
                    PM.LockBgImg = PM.StartPath + "\\Bg\\lock.jpg";
            }
            catch (Exception ex)
            {
                MSL.Tool.LogHelper.Instance.WriteLog("MainWindow.xaml.cs Window_Loaded\r\n" + ex.ToString());
            }

            #region 数据库配置

            //MSL.Tool.Data.DbHelper.ConnectionString = string.Format(config.GetValue("Conn"), PM.StartPath + @"\");
            //MSL.Tool.Data.DbHelper.DatabaseType = MSL.Tool.Data.DataBaseType.SQLite;

            //MSL.Tool.Data.DbHelper.ConnectionString = string.Format(xml.GetAddValue( "Conn"), PM.StartPath + @"\");
            //MSL.Tool.Data.DbHelper.DatabaseType = MSL.Tool.Data.DataBaseType.Access;
            #endregion
        }
        //系统关机前调用
        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);
        }
        //应用程序关闭前调用
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
        //全局异常处理逻辑
        //private void Application_Error(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        //{
        //    MSL.Tool.LogHelper.Instance.WriteLog("异常信息：" + e.Exception.Source + "\r\n" + e.Exception.Message);
        //    Helper.Instance.AlertError(e.Exception.Message);
        //    e.Handled = true;//处理完后，我们需要将Handler=true表示已此异常已处理过
        //}
    }
}
