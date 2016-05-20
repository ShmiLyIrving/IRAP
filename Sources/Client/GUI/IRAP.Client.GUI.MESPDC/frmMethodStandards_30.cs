using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmMethodStandards_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        public frmMethodStandards_30()
        {
            InitializeComponent();
        }

        private void frmMethodStandards_30_Activated(object sender, EventArgs e)
        {
            Options.Visible = true;
        }
    }
}
