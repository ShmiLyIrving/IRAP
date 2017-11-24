using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AsimcoBatchMNGMT
{
    public partial class Reports : Form
    {
        public Reports()
        {
            string baseDir = Path.Combine(Application.StartupPath, "TestFastReport");
            FastReport.Utils.Res.LocaleFolder = Path.Combine(baseDir, "L18N");
            var file = FastReport.Utils.Res.LocaleFolder + @"Chinese (Simplified).frl";
            FastReport.Utils.Res.LoadLocale(file);
            InitializeComponent();           
        }
    }
   
}
