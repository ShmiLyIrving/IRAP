using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

using IRAP.AutoUpgrade;

namespace IRAP_FVS_MDVO
{
    static class Program
    {
        private const int WS_SHOWMAXIMIZE = 3;

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Utils.AppearanceObject.DefaultFont = 
                new System.Drawing.Font("微软雅黑", 9.75f);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region 判断是否已经运行本程序的另一个实例
            Process instance = GetRunningInstance();
            if (instance != null)
            {
                HandleRunningInstance(instance);
                return;
            }
            #endregion

            #region 系统自动更新
            Upgrade.Instance.UpgradeCFGFileName =
                string.Format(
                    @"{0}\IRAP-FVS_MDVO.xml",
                    Directory.GetCurrentDirectory());
            if (Upgrade.Instance.CanUpgrade)
                if (Upgrade.Instance.Do() == -1)
                {
                    Process.Start(Application.ExecutablePath);
                    return;
                }
            #endregion

            Application.Run(new frmIRAP_FVS_MDVO());
        }

        /// <summary>
        /// 获取当前系统是否有相同的进程
        /// </summary>
        /// <returns></returns>
        public static Process GetRunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            // 遍历具有相同名字的正在运行的进程
            foreach (Process process in processes)
            {
                // 忽略现有的进程
                if (process.Id != current.Id)
                {
                    // 确保例程是从EXE文件运行
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") ==
                        current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 激活原有进程
        /// </summary>
        public static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWMAXIMIZE);
            SetForegroundWindow(instance.MainWindowHandle);
        }
    }
}
