using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using DevExpress.XtraEditors;
using System.Threading;
using System.Globalization;
using System.IO;

using IRAP.AutoUpgrade;
using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;

namespace IRAP
{
    static class Program
    {
        private const int WS_SHOWNORMAL = 1;
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!IRAP.Client.Global.IRAPConst.Instance.MultiInstance)
            {
                #region 判断是否已经运行了本程序的另一个实例
                Process instance = GetRunningInstance();
                if (instance != null)
                {
                    HandleRunningInstance(instance);
                    return;
                }
                #endregion
            }

            #region 设置默认字体、日期格式、汉化DEV
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Utils.AppearanceObject.DefaultFont =
                new System.Drawing.Font("微软雅黑", 10.5f);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CHS");
            // 设置程序区域语言设置中日期格式
            //CultureInfo ci = new CultureInfo("zh-CHS");
            //DateTimeFormatInfo di =
            //    (DateTimeFormatInfo)Thread.CurrentThread.CurrentCulture.DateTimeFormat.Clone();
            //di.DateSeparator = "-";
            //di.ShortDatePattern = "yyyy-MM-dd";
            //di.LongDatePattern = "yyyy'年'M'月'd'日'";
            //di.ShortTimePattern = "H:mm:ss";
            //di.LongTimePattern = "H'时'mm'分'ss'秒'";
            //ci.DateTimeFormat = di;
            //Thread.CurrentThread.CurrentCulture = ci;
            #endregion

            if (Thread.CurrentThread.CurrentCulture.Name.Substring(0, 2) == "en")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WriteLog.Instance.WriteBeginSplitter("IRAP");
            WriteLog.Instance.Write("运行 IRAP 应用平台系统", "IRAP");

            try
            {
                #region 检测当前授权是否允许运行
                #endregion

                #region 系统自动更新
#if !DEBUG
                WriteLog.Instance.Write("系统自动更新", "IRAP");
                Upgrade.Instance.UpgradeCFGFileName =
                    string.Format(
                        @"{0}\IRAP.xml",
                        Directory.GetCurrentDirectory());
                if (Upgrade.Instance.CanUpgrade)
                {
                    WriteLog.Instance.Write("系统开始更新...", "IRAP");
                    if (Upgrade.Instance.Do() == -1)
                    {
                        Process.Start(Application.ExecutablePath);
                        WriteLog.Instance.Write("重新启动系统", "IRAP");
                        return;
                    }
                    WriteLog.Instance.Write("系统更新完成...", "IRAP");
                }
                else
                {
                    WriteLog.Instance.Write("系统无法自动更新", "IRAP");
                }
#endif
                #endregion

                #region 用户登录
                IRAPUser.Instance.UserLogin();
                if (IRAPUser.Instance.IsLogon)
                {
                    while (true)
                    {
                        using (frmSelectSubSystem formSelectSystem = new frmSelectSubSystem())
                        {
                            if (formSelectSystem.ShowDialog() == DialogResult.Cancel)
                                break;

                            frmIRAPMain main = null;
                            try
                            {
                                main = new frmIRAPMain();
                                main.ShowDialog();
                            }
                            catch (Exception error)
                            {
                                WriteLog.Instance.Write(error.Message, "IRAP");
                                XtraMessageBox.Show(
                                    error.Message,
                                    "系统信息",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                            finally
                            {
                                main.Dispose();
                            }

                            if (AvailableSubSystems.Instance.AvailableCount <= 1)
                                break;
                        }
                    }

                    if (IRAPUser.Instance.IsLogon)
                    {
                        try
                        {
                            IRAPUser.Instance.Logout();
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(
                                string.Format(
                                    "登录用户注销时发生错误：{0}",
                                    error.Message),
                                "IRAP");
                        }
                    }
                }
#endregion
            }
            finally
            {
                WriteLog.Instance.Write("退出 IRAP 应用平台系统", "IRAP");
                WriteLog.Instance.WriteEndSplitter("IRAP");
                WriteLog.Instance.Write("");
            }
        }

        /// <summary>
        /// 获取当前系统是否有相同的进程
        /// </summary>
        /// <returns></returns>
        private static Process GetRunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            // 遍历具有相同名字的正在运行的进程
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                        return process;
            }

            return null;
        }

        /// <summary>
        /// 激活原有进程
        /// </summary>
        /// <param name="instance"></param>
        private static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            SetForegroundWindow(instance.MainWindowHandle);
        }
    }
}