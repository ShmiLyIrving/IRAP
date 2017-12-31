using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace BatchSystemMNGNT_Asimco
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void bbiSysParams_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmSysParams sysParamForm = new frmSysParams())
            {
                sysParamForm.ShowDialog();
            }
        }
    }
}