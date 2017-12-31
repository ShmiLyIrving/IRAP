using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;



namespace BatchSystemMNGNT_Asimco
{
    public partial class frmSysParams : DevExpress.XtraEditors.XtraForm
    {
        public frmSysParams()
        {
            InitializeComponent();
        }

        private void frmSysParams_Load(object sender, EventArgs e)
        {
            edtDBAddress.Text = SysParams.Instance.DBAddress;
            edtDBName.Text = SysParams.Instance.DBName;
            edtDBUserID.Text = SysParams.Instance.DBUserID;
            edtDBUserPWD.Text = SysParams.Instance.DBUserPWD;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SysParams.Instance.DBAddress = edtDBAddress.Text.Trim();
            SysParams.Instance.DBName = edtDBName.Text.Trim();
            SysParams.Instance.DBUserID = edtDBUserID.Text.Trim();
            SysParams.Instance.DBUserPWD = edtDBUserPWD.Text.Trim();

            DialogResult = DialogResult.OK;
        }
    }
}