using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using IRAP.Client.Global;

namespace IRAP.Client.User
{
    public partial class frmChangePassword : frmCustomBase
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                IRAPUser.Instance.ChangePassword(
                    IRAPUser.Instance.Password,
                    edtPassword.Text,
                    edtConfPassword.Text);
                XtraMessageBox.Show(
                    "登录密码修改完成，新的登录密码将在下次登录时生效。",
                    "登录密码修改",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btnCancel.PerformClick();
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    string.Format(
                        "修改登录密码失败：{0}",
                        error.Message),
                    "登录密码修改",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                edtPassword.Text = "";
                edtConfPassword.Text = "";

                edtPassword.Focus();
            }
        }
    }
}
