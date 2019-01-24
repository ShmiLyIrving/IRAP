using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;

namespace IRAP_MaterialRequestImport
{
    public partial class frmLogin : XtraForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private bool formMove = false;
        private Point formPoint;

        public frmLogin()
        {
            InitializeComponent();
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
            {
                formMove = false;
            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            formPoint = new Point();
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X;
                yOffset = -e.Y;
                if (FormBorderStyle != FormBorderStyle.None)
                {
                    xOffset -= SystemInformation.FrameBorderSize.Width;
                    yOffset -= SystemInformation.FrameBorderSize.Height;
                }
                if (ControlBox)
                {
                    yOffset -= SystemInformation.CaptionHeight;
                }

                formPoint = new Point(xOffset, yOffset);
                formMove = true;
            }
        }

        private void edtUserCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TIRAPUser.Instance.UserCode = edtUserCode.Text;

                edtUserPWD.Text = "";
                cboAgencies.Properties.Items.Clear();
                cboRoles.Properties.Items.Clear();
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    "出错了",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void edtUserPWD_Validating(object sender, CancelEventArgs e)
        {
            if (edtUserPWD.Text != "")
            {
                string strProcedureName =
                    $"{className}.{MethodBase.GetCurrentMethod().Name}";

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    TIRAPUser.Instance.Password = edtUserPWD.Text;
                    if (TIRAPUser.Instance.IsPWDVerified)
                    {
                        cboAgencies.Properties.Items.Clear();
                        cboRoles.Properties.Items.Clear();

                        #region Fill Agencies
                        foreach (TAgencyInfo agency in TIRAPUser.Instance.AvailableAgencies)
                        {
                            cboAgencies.Properties.Items.Add(agency);
                        }
                        if (cboAgencies.Properties.Items.Count > 0)
                        {
                            cboAgencies.SelectedIndex = 0;
                        }
                        cboAgencies.Enabled = cboAgencies.Properties.Items.Count > 1;
                        #endregion

                        #region Fill Roles
                        foreach (TRoleInfo role in TIRAPUser.Instance.AvailableRoles)
                        {
                            cboRoles.Properties.Items.Add(role);
                        }
                        if (cboRoles.Properties.Items.Count > 0)
                        {
                            cboRoles.SelectedIndex = 0;
                        }
                        cboRoles.Enabled = cboRoles.Properties.Items.Count > 1;
                        #endregion

                        btnLogin.Enabled =
                            ((cboAgencies.SelectedIndex >= 0) &&
                            (cboRoles.SelectedIndex >= 0));
                        if (btnLogin.Enabled)
                        {
                            btnLogin.Focus();
                        }
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);

                    edtUserPWD.Text = "";

                    XtraMessageBox.Show(
                        error.Message,
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    e.Cancel = true;
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
            else
            {
                cboAgencies.Properties.Items.Clear();
                cboRoles.Properties.Items.Clear();

                btnLogin.Enabled = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                TIRAPUser.Instance.SelectAgency(cboAgencies.SelectedIndex);
                TIRAPUser.Instance.SelectRole(cboRoles.SelectedIndex);

                try
                {
                    TIRAPUser.Instance.Login();
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

                if (TIRAPUser.Instance.IsLogon)
                {
                    Hide();
                }

                btnCancel.PerformClick();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}