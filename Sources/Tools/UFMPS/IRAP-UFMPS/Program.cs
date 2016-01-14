using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRAP_UFMPS
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
            DevExpress.UserSkins.TouchSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("微软雅黑", 9f);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
