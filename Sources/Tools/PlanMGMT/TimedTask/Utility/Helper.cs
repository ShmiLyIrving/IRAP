// 版权所有：
// 文 件  名：
// 功能描述：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using PlanMGMT.Utility;
using Visifire.Charts;

namespace PlanMGMT
{
    public class Helper
    {
        private static Helper _instance;
        private static readonly object _lock = new Object();
        private System.Windows.Media.MediaPlayer _player = new System.Windows.Media.MediaPlayer();

        #region 单一实例
        /// <summary>
        /// 
        /// </summary>
        private Helper()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        ~Helper()
        {
            Dispose();
        }
        /// <summary>
        /// 返回唯一实例
        /// </summary>
        public static Helper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                        _instance = new Helper();
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
            GC.SuppressFinalize(this);
        }
        #endregion

        #region 进程

        /// <summary>
        /// 杀死进程
        /// </summary>
        /// <param name="proccessName">进程名</param>
        public void EndApp(string proccessName)
        {
            if ((proccessName + "").Length == 0)
            {
                return;
            }
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                if (p.ProcessName == proccessName)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception e)
                    {
                        MSL.Tool.LogHelper.Instance.WriteLog("Common KillProccess\r\n" + e.ToString());
                    }
                }
            }
        }
        #endregion

        #region CMD

        /// <summary>
        /// 运行cmd命令
        /// </summary>
        /// <param name="command">cmd命令文本</param>
        public void Run(string command)
        {
            if (String.IsNullOrEmpty(command))
                return;
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                //p.StandardInput.WriteLine("shutdown -s -t 30 -c \"如果此时不想关机，就点击“取消关机”按钮！\"");
                p.StandardInput.WriteLine(command);
                p.StandardInput.WriteLine("exit");
                string strRst = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                MSL.Tool.LogHelper.Instance.WriteLog("Common Run\r\n" + ex.ToString());
            }
        }
        #endregion

        #region 饼状图
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">标题名称</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="valuex"></param>
        /// <param name="valuey"></param>
        public Chart CreatePie(string title, int width, int height, List<string> valuex, List<string> valuey)
        {
            Chart chart = new Chart();
            chart.Width = width;
            chart.Height = height;
            chart.BorderThickness = new Thickness(1);//禁用边框
            //chart.Margin = new Thickness(100, 5, 10, 5);
            //title.Padding = new Thickness(0, 5, 5, 0);

            chart.ToolBarEnabled = true;//是否启用打印
            chart.ScrollingEnabled = true;//是否启用滚动
            chart.View3D = true;//3D效果显示

            chart.Titles.Add(new Title()//设置标题的名称
            {
                Text = title
            });
            DataSeries series = new DataSeries();//数据线
            series.RenderAs = RenderAs.Pie;//柱状Stacked 设置数据线的格式
            DataPoint point;// 设置数据点   
            for (int i = 0; i < valuex.Count; i++)
            {
                point = new DataPoint();
                point.AxisXLabel = valuex[i];// 设置X轴点   
                point.LegendText = "##" + valuex[i];

                point.YValue = double.Parse(valuey[i]);//设置Y轴点
                //point.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown);
                series.DataPoints.Add(point); //添加数据点 
            }

            chart.Series.Add(series); // 添加数据线到数据序列。
            return chart;
        }

        #endregion

        #region 声音

        /// <summary>
        /// 文字转语音
        /// </summary>
        /// <param name="message">文字信息</param>
        /// <param name="speekType">声音类别 0：单词男声Sam,1:单词男声Mike,2:单词女声Mary,3:中文发音，如果是英文，就依单词字母一个一个发音</param>
        public void Speek(string message)
        {
            try
            {
                //引入COM组件:Microsoft speech object Library
                //SpeechLib.SpVoice voice = new SpeechLib.SpVoice();
                //voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(0);
                //voice.Speak(message, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync);
            }
            catch (Exception ex)
            {
                Helper.Instance.AlertError(ex.Message);
            }
        }

        /// <summary>
        /// 停止播放声音
        /// </summary>
        public void StopAudio()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (this._player != null)
                {
                    this._player.Stop();
                    this._player.Close();
                }
            }));
        }
        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="soundName">声音名</param>
        public void PalyAudio(string soundName, double volume)
        {
            if (String.IsNullOrEmpty(soundName) || soundName.Contains("无"))
                return;

            string path = PlanMGMT.Model.PM.AudioHt[soundName].ToString();
            if (!System.IO.File.Exists(path))
                return;
            /*
              SoundPlayer类特点
              1）仅支持.wav音频文件；
            2）不支持同时播放多个音频（任何新播放的操作将终止当前正在播放的）；
            3）无法控制声音的音量；
              if (path.EndsWith(".wav"))
              {
                  using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(path))
                  {
                      player.Play();//播放波形文件
                  }
              }
            */
            if (this._player != null)
            {
                StopAudio();
            }
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (path.EndsWith(".mp3") || path.EndsWith(".wma") || path.EndsWith(".wav"))
                {
                    try
                    {
                        this._player = new System.Windows.Media.MediaPlayer();
                        this._player.Open(new Uri(path));
                        this._player.Volume = volume / 100;//大小为0~1.0
                        this._player.Play();
                    }
                    catch (Exception ex)
                    {
                        MSL.Tool.LogHelper.Instance.WriteLog("Core Common_PalyAudio\r\n" + ex.ToString());
                    }
                }
            }));
        }

        #endregion

        #region 获得程序版本

        /// <summary>
        /// 获得程序版本
        /// </summary>
        /// <returns></returns>
        public string GetVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        #endregion

        #region 显示器

        private const uint WM_SYSCOMMAND = 0x0112;
        private const uint SC_MONITORPOWER = 0xF170;
        private readonly IntPtr HWND_HANDLE = new IntPtr(0xffff);
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, uint wParam, int lParam);

        /// <summary>
        /// 打开显示器
        /// </summary>
        public void OpenMonitor()
        {
            // 2 为关闭显示器， －1则打开显示器
            SendMessage(HWND_HANDLE, WM_SYSCOMMAND, SC_MONITORPOWER, -1);
        }
        /// <summary>
        /// 关闭显示器
        /// </summary>
        public void CloseMonitor()
        {
            // 2 为关闭显示器， －1则打开显示器
            SendMessage(HWND_HANDLE, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
        }
        #endregion

        #region 启动外部程序

        /// <summary>
        /// 启动外部Windows应用程序
        /// </summary>
        /// <param name="appName">应用程序路径名称</param>
        /// <returns></returns>
        public bool StartApp(string appName)
        {
            return StartApp(appName, null, System.Diagnostics.ProcessWindowStyle.Normal);
        }

        /// <summary>
        /// 启动外部应用程序
        /// </summary>
        /// <param name="appName">应用程序路径名称</param>
        /// <param name="arguments">启动参数</param>
        /// <param name="style">进程窗口模式</param>
        /// <returns></returns>
        public bool StartApp(string appName, string arguments, System.Diagnostics.ProcessWindowStyle style)
        {
            bool result = false;
            using (System.Diagnostics.Process p = new System.Diagnostics.Process())
            {
                p.StartInfo.FileName = appName;//exe,bat and so on
                p.StartInfo.WindowStyle = style;
                p.StartInfo.Arguments = arguments;
                try
                {
                    p.Start();
                    p.WaitForExit();
                    p.Close();
                    result = true;
                }
                catch
                {
                }
            }
            return result;
        }
        #endregion

        #region 传回阳历y年m月的总天数

        /// <summary>
        /// 传回阳历y年m月的总天数
        /// </summary>
        public int GetDaysByMonth(int y, int m)
        {
            int[] days = new int[] { 31, DateTime.IsLeapYear(y) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return days[m - 1];
        }
        #endregion
        #region 获取周一周日日期
        /// <summary> 
        /// 计算某日起始日期（礼拜一的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns> 
        public DateTime GetMondayDate()
        {
            DateTime dt = DateTime.Now;
            return dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).Date;  //本周周一           
        }
        /// <summary> 
        /// 计算某日结束日期（礼拜日的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜日日期，后面的具体时、分、秒和传入值相等</returns> 
        public DateTime GetSundayDate()
        {           
            return GetMondayDate().AddDays(6).Date;  //本周周日
        }
        public DateTime GetNextSundayDate()
        {
            return GetSundayDate().AddDays(7).Date;//下周周日
        }
        public DateTime GetLastMondayDate()
        {
            return GetMondayDate().AddDays(-7).Date;//上周周一
        }
        public DateTime? GetDayBegin(DateTime? d)
        {
            return d.Value.Date;
        }
        public DateTime? GetDayEnd(DateTime? d)
        {
            return d.Value.Date.AddDays(1).AddTicks(-1);
        }
        #endregion

        #region 多个匹配内容

        /// <summary>
        /// 多个匹配内容
        /// </summary>
        /// <param name="input">输入内容</param>
        /// <param name="pattern">表达式字符串</param>
        /// <param name="groupName">分组名, ""代表不分组</param>
        public List<string> GetList(string input, string pattern, string groupName)
        {
            List<string> list = new List<string>();
            Regex re = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);//| RegexOptions.IgnorePatternWhitespace
            MatchCollection mcs = re.Matches(input);
            foreach (Match mc in mcs)
            {
                if (groupName != "")
                {
                    list.Add(mc.Groups[groupName].Value);
                }
                else
                {
                    list.Add(mc.Value);
                }
            }
            return list;
        }

        /// <summary>
        /// 多个匹配内容
        /// </summary>
        /// <param name="input">输入内容</param>
        /// <param name="pattern">表达式字符串</param>
        /// <param name="groupIndex">第几个分组, 从1开始, 0代表不分组</param>
        public List<string> GetList(string input, string pattern, int groupIndex)
        {
            List<string> list = new List<string>();
            Regex re = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            MatchCollection mcs = re.Matches(input);
            foreach (Match mc in mcs)
            {
                if (groupIndex > 0)
                {
                    list.Add(mc.Groups[groupIndex].Value);
                }
                else
                {
                    list.Add(mc.Value);
                }
            }
            return list;
        }
        #endregion

        #region 信息提醒
        /// <summary>
        /// 默认错误提示
        /// </summary>
        /// <param name="message">显示消息</param>
        public void AlertError(string message)
        {
            ShowTip(PlanMGMT.Control.ShowTipType.Warning, message);
        }
        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="message">显示消息</param>
        public void Alert(string message)
        {
            ShowTip(PlanMGMT.Control.ShowTipType.Information, message);
        }
        /// <summary>
        /// 提示警告信息
        /// </summary>
        /// <param name="message">显示消息</param>
        public void AlertWarning(string message)
        {
            ShowTip(PlanMGMT.Control.ShowTipType.Warning, message);
        }
        /// <summary>
        /// 提示选择信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="action1"></param>
        /// <param name="action2"></param>
        public void AlertChoice(string title,string message,Action action1,Action action2)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                var window = new Control.ShowTip(Control.ShowTipType.Choice, title, message);
                window.btnAccept.Click += (sender, e) =>
                {
                    window.Close();
                    Loading(action1, "正在处理...");
                };
                window.btnStop.Click += (sender, e) =>
                 {
                     window.Close();
                     Loading(action2, "正在处理...");
                 };
                window.MouseLeftButtonDown += (sender, e) =>
                {
                    if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                        window.DragMove();
                };
                window.ShowDialog();
            }));
        }
        /// <summary>
        /// 提示成功信息
        /// </summary>
        /// <param name="message">显示消息</param>
        public void AlertSuccess(string message)
        {
            ShowTip(PlanMGMT.Control.ShowTipType.Ok, message);
        }
        /// <summary>
        /// 提示确认信息
        /// </summary>
        /// <param name="title">窗口标题</param>
        /// <param name="message">显示消息</param>
        public void AlertConfirm(string title, string message, Action callback)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                var window = new Control.ShowTip(Control.ShowTipType.Confirm, title, message);
                window.btnAccept.Click += (sender, e) =>
                {
                    window.Close();
                    Loading(callback, "正在处理...");
                    //callback.Invoke();
                };
                window.MouseLeftButtonDown += (sender, e) =>
                {
                    if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                        window.DragMove();
                };
                window.ShowDialog();
            }));
        }
        /// <summary>
        /// 信息提醒
        /// </summary>
        /// <param name="tipType">提醒类型</param>
        /// <param name="msg">信息</param>
        private void ShowTip(PlanMGMT.Control.ShowTipType tipType, string msg)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
               {
                   Control.ShowTip tip = new Control.ShowTip(tipType, msg);
                   switch (tipType)
                   {
                       case PlanMGMT.Control.ShowTipType.Ok:
                           msg = (String.IsNullOrEmpty(msg) ? msg = "操作成功！" : msg);
                           break;
                       case PlanMGMT.Control.ShowTipType.Warning:
                           msg = (String.IsNullOrEmpty(msg) ? msg = msg = "操作失败！" : msg);
                           break;
                       case PlanMGMT.Control.ShowTipType.Error: msg = (String.IsNullOrEmpty(msg) ? msg = msg = "操作失败！" : msg);
                           break;
                       case PlanMGMT.Control.ShowTipType.Information:
                       default: break;
                   }
                   tip.Show();
               }));
        }
        #endregion

        #region 加载进度条
        /// <summary>
        /// 加载进度条
        /// </summary>
        /// <param name="doWork">执行方法</param>
        /// <param name="msg">提示</param>
        public void Loading(Action doWork, string msg)
        {
            if (doWork == null)
                return;
            Control.Loading load = new Control.Loading(doWork);
            if (String.IsNullOrEmpty(msg))
                msg = "正在加载。。。";
            load.Msg = msg;
            load.Start();
            load.ShowDialog();
        }
        #endregion

        #region 弹出Pup窗口提醒
        /// <summary>
        /// 弹出Pup窗口提醒
        /// </summary>
        /// <param name="title">窗口标题</param>
        /// <param name="subject">提醒主题</param>
        /// <param name="msg">信息</param>
        public void ShowPupUp(string title, string subject, string msg)
        {
            if (String.IsNullOrEmpty(title))
                title = "提醒";            
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                Control.PopUP.Instance.Dispose();
                Control.PopUP.Instance.Subject = subject;
                Control.PopUP.Instance.Msg = msg;
                Control.PopUP.Instance.PopTitle = title;
                Control.PopUP.Instance.Show();
            }));
            //System.Threading.Tasks.Task.Factory.StartNew(() =>
            //{
            //    Control.PopUP pop = new Control.PopUP();
            //    pop.Subject = subject;
            //    pop.Msg = msg;
            //    pop.PopTitle = title;
            //    pop.Show();
            //});
        }
         #endregion
        }
}
