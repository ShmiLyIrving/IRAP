using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Diagnostics;

using IRAP.Global;
using IRAP.AutoUpgrade;

namespace IRAP_FVS_Kanban
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Utils.AppearanceObject.DefaultFont =
                new System.Drawing.Font("微软雅黑", 10.5f);

            if (Thread.CurrentThread.CurrentCulture.Name.Substring(0, 2) == "en")
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            WriteLog.Instance.WriteBeginSplitter("IRAP-FVS Kanban");
            WriteLog.Instance.Write("运行 IRAP-FVS Kanban 系统", "IRAP-FVS");

            #region 自动更新 
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

            Application.Run(new frmMainScreen());

            WriteLog.Instance.Write("退出 IRAP-FVS KANBAN系统", "IRAP-FVS KANBAN");
            WriteLog.Instance.WriteEndSplitter("IRAP-FVS KANBAN");
            WriteLog.Instance.Write("");
        }
    }
}
