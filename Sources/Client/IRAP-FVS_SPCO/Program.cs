using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using IRAP.AutoUpgrade;

namespace IRAP_FVS_SPCO
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
    }
}
