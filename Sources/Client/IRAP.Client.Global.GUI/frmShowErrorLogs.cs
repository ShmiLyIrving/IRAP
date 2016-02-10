using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.Global.GUI
{
    public partial class frmShowErrorLogs : IRAP.Client.Global.frmCustomBase
    {
        private List<AppOperationLog> logs = new List<AppOperationLog>();

        public frmShowErrorLogs()
        {
            InitializeComponent();
        }

        public frmShowErrorLogs(List<AppOperationLog> errorLogs) : this()
        {
            logs = errorLogs;

            grdLogs.DataSource = logs;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
