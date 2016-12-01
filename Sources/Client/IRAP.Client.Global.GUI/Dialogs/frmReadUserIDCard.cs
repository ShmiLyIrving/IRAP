using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.Global.GUI.Dialogs
{
    public partial class frmReadUserIDCard : IRAP.Client.Global.frmCustomBase
    {
        public frmReadUserIDCard()
        {
            InitializeComponent();
        }

        public string Caption
        {
            get { return lblCaption.Text; }
            set { lblCaption.Text = value; }
        }

        public string UserIDCardNo
        {
            get { return edtIDCardNo.Text; }
        }

        public bool ShowInputString
        {
            get { return edtIDCardNo.Properties.UseSystemPasswordChar; }
            set { edtIDCardNo.Properties.UseSystemPasswordChar = value; }
        }

        private void edtIDCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Return)
            {
                if (edtIDCardNo.Text != "")
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    btnCancel.PerformClick();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            edtIDCardNo.Text = "";
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
