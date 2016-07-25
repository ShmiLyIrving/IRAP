using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace IRAP_UFMPS
{
    static class Program
    {
        private const int WS_SHOWNORMAL = 1;
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
                MessageBox.Show(
                    "本程序已经运行！\n不能同时运行两个以上的程序实例。",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                HandleRunningInstance(instance);
                return;
            }

            #endregion

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.TouchSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("微软雅黑", 9f);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
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
