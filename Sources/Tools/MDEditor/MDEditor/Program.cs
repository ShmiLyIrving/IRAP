using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MDEditor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region 设置默认字体、日期格式、汉化DEV
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Utils.AppearanceObject.DefaultFont =
                new System.Drawing.Font("微软雅黑", 10.5f);
            #endregion

            Application.Run(new Form1());
        }
    }
}
