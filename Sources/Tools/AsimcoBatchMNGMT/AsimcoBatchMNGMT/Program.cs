using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsimcoBatchMNGMT
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

            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

#if DEBUG
            Application.Run(new frmMain());
#else
            Application.Run(new MainForm());
#endif
        }
    }
}
