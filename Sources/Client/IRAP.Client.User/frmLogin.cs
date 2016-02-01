using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Reflection;

using IRAP.Global;

namespace IRAP.Client.User
{
    public partial class frmLogin : IRAP.Client.Global.frmCustomBase
    {
        private bool formMove = false;
        private Point formPoint;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void edtUserCode_Leave(object sender, EventArgs e)
        {
            IRAPUser.Instance.UserCode = edtUserCode.Text;

            edtUserPWD.Text = "";
            cboAgencies.Items.Clear();
            cboRoles.Items.Clear();
        }

        private void edtUserPWD_Leave(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPUser.Instance.SelectAgency(cboAgencies.SelectedIndex);
                IRAPUser.Instance.SelectRole(cboRoles.SelectedIndex);

                try
                {
                    IRAPUser.Instance.Login();
                }
                catch (Exception error)
                {
                    MessageBox.Show(
                        error.Message,
                        "请联系系统维护人员",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (IRAPUser.Instance.IsLogon)
                {
                    Hide();

                    #region 登录成功后，如果用户选择了“修改登录密码”后，进入密码修改界面
                    if (chkChangePWD.Checked)
                    {
                        using (frmChangePassword changePassword=new frmChangePassword())
                        {
                            changePassword.ShowDialog();
                        }
                    }
                    #endregion
                }

                btnCancel.PerformClick();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }   

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            formPoint = new Point();
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y
                    - SystemInformation.CaptionHeight
                    - SystemInformation.FrameBorderSize.Height;

                formPoint = new Point(xOffset, yOffset);
                formMove = true;
            }
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (formMove)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(formPoint.X, formPoint.Y);
                Location = mousePos;
            }
        }

        private void frmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                formMove = false;
        }

        private void edtUserPWD_Validating(object sender, CancelEventArgs e)
        {
            if (edtUserPWD.Text != "")
            {
                string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    IRAPUser.Instance.Password = edtUserPWD.Text;
                    if (IRAPUser.Instance.IsPWDVerified)
                    {
                        cboAgencies.Items.Clear();
                        cboAgencies.DataSource = IRAPUser.Instance.AvailableAgencies;
                        cboAgencies.DisplayMember = "AgencyName";
                        cboAgencies.ValueMember = "AgencyLeaf";
                        if (cboAgencies.Items.Count > 0)
                            cboAgencies.SelectedIndex = 0;
                        cboAgencies.Enabled = cboAgencies.Items.Count > 1;

                        cboRoles.DataSource = IRAPUser.Instance.AvailableRoles;
                        cboRoles.DisplayMember = "RoleName";
                        cboRoles.ValueMember = "RoleLeaf";
                        if (cboRoles.Items.Count > 0)
                            cboRoles.SelectedIndex = 0;
                        cboRoles.Enabled = cboRoles.Items.Count > 1;

                        btnLogin.Enabled =
                            ((cboAgencies.SelectedIndex >= 0) &&
                            (cboRoles.SelectedIndex >= 0));
                        if (btnLogin.Enabled)
                            btnLogin.Focus();

                        e.Cancel = false;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    MessageBox.Show(
                        error.Message,
                        "登录密码错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    edtUserPWD.Text = "";
                    edtUserPWD.Focus();

                    e.Cancel = true;
                }
                finally
                {
                    chkChangePWD.Enabled = IRAPUser.Instance.IsPWDVerified;
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
            else
            {
                cboAgencies.Items.Clear();
                cboRoles.Items.Clear();
                chkChangePWD.Enabled = false;
                btnLogin.Enabled = false;

                e.Cancel = false;
            }
        }

        private void edtUserPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return || e.KeyCode != Keys.Tab)
            {
                cboAgencies.Items.Clear();
                cboRoles.Items.Clear();
                chkChangePWD.Enabled = false;
                btnLogin.Enabled = false;
            }
        }
    }
}
