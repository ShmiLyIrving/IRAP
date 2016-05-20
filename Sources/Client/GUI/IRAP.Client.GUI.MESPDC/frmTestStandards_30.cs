using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmTestStandards_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        public frmTestStandards_30()
        {
            InitializeComponent();
        }

        private void frmTestStandards_30_Activated(object sender, EventArgs e)
        {
            Options.Visible = true;
        }
    }
}
