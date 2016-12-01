using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using IRAP.Global;
using IRAP.Client.Global.GUI.Dialogs;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Entities.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventCloseProperties : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private UserInfo userInfo = new UserInfo();

        public frmAndonEventCloseProperties()
        {
            InitializeComponent();

            switch (IRAPUser.Instance.CommunityID)
            {
                case 60006:
                    edtUserIDCardNo.Properties.UseSystemPasswordChar = false;
                    break;
                default:
                    edtUserIDCardNo.Properties.UseSystemPasswordChar = true;
                    break;
            }
        }

        public UserInfo UserInfo
        {
            get { return userInfo; }
        }

        public int Satisfactory
        {
            get { return (int)rgpSatisfactory.Properties.Items[rgpSatisfactory.SelectedIndex].Value; }
        }

        private void frmAndonEventCloseProperties_Paint(object sender, PaintEventArgs e)
        {
            btnOK.Enabled =
                (userInfo.UserCode != "") &&
                (rgpSatisfactory.SelectedIndex >= 0);
        }

        private void rgpSatisfactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void edtUserIDCardNo_Validating(object sender, CancelEventArgs e)
        {
            userInfo = new UserInfo();

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (edtUserIDCardNo.Text.Trim() == "")
                {
                    WriteLog.Instance.Write("没有得到用户卡号。", strProcedureName);
                    return;
                }

                int errCode = 0;
                string errText = "";

                IRAPUserClient.Instance.sfn_GetInfo_UserFromIDCard(
                    IRAPUser.Instance.CommunityID,
                    edtUserIDCardNo.Text,
                    ref userInfo,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                if (errCode != 0)
                {
                    ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    edtUserIDCardNo.Text = "";
                    return;
                }
                else
                {
                    rgpSatisfactory.Focus();
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                ShowMessageBox.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                edtUserIDCardNo.Text = "";
                return;
            }
            finally
            {
                this.Refresh();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
