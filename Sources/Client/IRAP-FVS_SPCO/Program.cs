using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

using IRAP.AutoUpgrade;

namespace IRAP_FVS_SPCO
{
    static class Program
    {
        private const int WS_SHOWNORMAL = 1;
        private const int WS_SHOWMINIMIZED = 2;
        private const int WS_SHOWMAXIMIZED = 3;
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
            #region 判断是否已经运行了本程序的另一个实例

            Process instance = GetRunningInstance();
            if (instance != null)
            {
                HandleRunningInstance(instance);
                return;
            }
            #endregion

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Utils.AppearanceObject.DefaultFont =
                new System.Drawing.Font("微软雅黑", 9.75f);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if !DEBUG
            #region 系统自动更新
            Upgrade.Instance.UpgradeCFGFileName =
                string.Format(
                    @"{0}\IRAP-FVS_SPCO.xml",
                    Directory.GetCurrentDirectory());
            if (Upgrade.Instance.CanUpgrade)
            {
                int upgradeRlt = Upgrade.Instance.Do();
                switch (upgradeRlt)
                {
                    case 0:
                        break;
                    case -1:
                        Process.Start(Application.ExecutablePath);
                        return;
                    case -2:
                        return;
                }
            }
            #endregion
#endif

            Application.Run(new frmSPCOMain());
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
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWMAXIMIZED);
            SetForegroundWindow(instance.MainWindowHandle);
        }
    }
}
