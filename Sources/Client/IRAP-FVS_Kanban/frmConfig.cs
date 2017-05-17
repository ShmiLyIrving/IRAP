using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace IRAP_FVS_Kanban
{
    public partial class frmConfig : DevExpress.XtraEditors.XtraForm
    {
        public frmConfig()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitCheckBoxList()
        {
            grdScreens.DataSource = KanbanScreens.Instance.Screens;
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            InitCheckBoxList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            KanbanScreens.Instance.SaveScreenParams();

            btnCancel.PerformClick();
        }
    }
}