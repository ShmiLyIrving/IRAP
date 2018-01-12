using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

using DevExpress.Utils;

namespace BatchSystemMNGNT_Asimco
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

            AppearanceObject.DefaultFont = new Font("微软雅黑", 10.5f);
            AppearanceObject.DefaultMenuFont = new Font("微软雅黑", 10.5f);

            Application.Run(new frmMain());
        }
    }
}
