using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            Application.Run(new frmSPCOMain());
        }
    }
}
