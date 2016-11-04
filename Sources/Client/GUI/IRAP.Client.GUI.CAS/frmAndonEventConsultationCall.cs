using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventConsultationCall : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private UserInfo staffInfo = new UserInfo();

        public frmAndonEventConsultationCall()
        {
            InitializeComponent();

            switch (IRAPUser.Instance.CommunityID)
            {
                case 60006:
                    lblGetIDNo.Text = "    请刷卡或输入工号，获取呼叫您的安灯事件：";
                    break;
                default:
                    lblGetIDNo.Text = "请刷卡，获取呼叫您的安灯事件：";
                    break;
            }
        }

        private void ReplaceIDCardNoReadPanel()
        {
            pnlIDCardNoRead.Top = (tpIDCardnoRead.Height - pnlIDCardNoRead.Height) / 2;
            pnlIDCardNoRead.Left = (tpIDCardnoRead.Width - pnlIDCardNoRead.Width) / 2;
        }

        private void frmAndonEventConsultation_Shown(object sender, EventArgs e)
        {
            tcMain.SelectedTabPage = tpIDCardnoRead;
            ReplaceIDCardNoReadPanel();
        }

        private void frmAndonEventConsultation_Resize(object sender, EventArgs e)
        {
            ReplaceIDCardNoReadPanel();
        }

        private void edtIDCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (e.KeyCode == Keys.Return)
            {
                if (edtIDCardNo.Text.Trim() != "")
                {
                    WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                    try
                    {
                        int errCode = 0;
                        string errText = "";

                        IRAPUserClient.Instance.sfn_GetInfo_UserFromIDCard(
                            IRAPUser.Instance.CommunityID,
                            edtIDCardNo.Text.Trim(),
                            ref staffInfo,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("({0}){1}", errCode, errText),
                            strProcedureName);

                        if (errCode != 0)
                        {
                            IRAPMessageBox.Instance.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            edtIDCardNo.Text = "";
                            edtIDCardNo.Focus();
                            return;
                        }
                        else
                        {
                            // 获取该用户需要响应的安灯事件列表
                            //andonEventsToRespond.Clear();
                            //try
                            //{
                            //    IRAPFVSClient.Instance.ufn_GetList_AndonEventsToRespond(
                            //        IRAPUser.Instance.CommunityID,
                            //        staffInfo.UserCode,
                            //        IRAPUser.Instance.SysLogID,
                            //        ref andonEventsToRespond,
                            //        out errCode,
                            //        out errText);
                            //    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                            //    if (errCode == 0)
                            //    {
                            //        if (andonEventsToRespond.Count > 0)
                            //        {
                            //            chkCallOtherOneAndonEvents.Checked = false;
                            //            chkCallOtherOneAndonEvents_CheckedChanged(chkCallOtherOneAndonEvents, new EventArgs());

                            //            tcMain.SelectedTabPage = tpAndonEvents;
                            //        }
                            //        else
                            //        {
                            //            ShowMessageBox.Show("当前站点没有呼叫您的安灯事件！", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //            edtIDCardNo.Text = "";
                            //            edtIDCardNo.Focus();
                            //        }
                            //    }
                            //    else
                            //    {
                            //        ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //        edtIDCardNo.Text = "";
                            //        edtIDCardNo.Focus();
                            //        return;
                            //    }
                            //}
                            //catch (Exception error)
                            //{
                            //    WriteLog.Instance.Write(error.Message, strProcedureName);
                            //    ShowMessageBox.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    grdAndonEvents.DataSource = null;

                            //    edtIDCardNo.Text = "";
                            //    edtIDCardNo.Focus();
                            //}
                        }
                    }
                    finally
                    {
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                }
            }
        }
    }
}
