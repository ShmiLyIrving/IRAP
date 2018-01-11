using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OPCClient.Dialogs
{
    public partial class dlgAddorModifyServer :UDFdialog
    {
        private int type;
        public dlgAddorModifyServer()
        {
            InitializeComponent();
            this.Text = "添加";
            this.btnOK.Text = "添加";
            type = 1;
        }
        public dlgAddorModifyServer(string title): base(title)
        {
            InitializeComponent();
            SetLabelMouseDown();
            this.Text = "添加";
            this.btnOK.Text = "添加";
            type = 1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (BlankValidate())
            {
                if (IRAPOPCServers.Instance.UpdateKepServ(this.edtServerAddress.Text, this.edtServerName.Text, type))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
