using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

using IRAP.Global;
using IRAP.AutoUpgrade;

namespace xFiletoESB
{
  
    static class Program
    {
        //API 常数定义
        private const int SW_HIDE = 0;
        private const int SW_NORMAL = 1;
        private const int SW_MAXIMIZE = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_SHOW = 5;
        private const int SW_MINIMIZE = 6;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            #region 判断是否已经运行本程序的另一个实例
            if (!SysParams.Instance.MultiInstance)
            {
                Process instance = GetRunningInstance();
                if (instance != null)
                {
                    HandleRunningInstance(instance);
                    return;
                }
            }
            #endregion

            if (WriteLog.Instance.IsWriteLog != SysParams.Instance.IsWriteLog)
                WriteLog.Instance.IsWriteLog = SysParams.Instance.IsWriteLog;

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    MethodBase.GetCurrentMethod().DeclaringType.FullName,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            WriteLog.Instance.Write(
                string.Format("运行 IRAP xFiles to ESB (V {0})", "6.1"),
                strProcedureName);


            try
            {
#if !DEBUG
                #region 系统自动更新
                if (SysParams.Instance.UpgradeURL != "")
                {
                    WriteLog.Instance.Write("系统自动更新", strProcedureName);
                    Upgrade.Instance.URLCFGFileName = SysParams.Instance.UpgradeURL;
                    if (Upgrade.Instance.CanUpgrade)
                    {
                        WriteLog.Instance.Write("系统开始更新...", strProcedureName);
                        if (Upgrade.Instance.Do() == -1)
                        {
                            Process.Start(Application.ExecutablePath);
                            WriteLog.Instance.Write("重新启动系统", strProcedureName);
                            return;
                        }
                        WriteLog.Instance.Write("系统更新完成...", strProcedureName);
                    }
                    else
                    {
                        WriteLog.Instance.Write("系统无法自动更新", strProcedureName);
                    }
                }
                #endregion
#endif

                Application.Run(new frmxFiletoESBMain());
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.Write("退出 IRAP ESB to xFiles", strProcedureName);
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
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
            ShowWindowAsync(instance.MainWindowHandle, SW_SHOW);
            SetForegroundWindow(instance.MainWindowHandle);
        }
    }
}
