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
using IRAP.Client.User;
using IRAP.Entities.SSO;
using IRAP.Entities.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventConsultationCall : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private UserInfo staffInfo = new UserInfo();
        private List<AndonRspedEventInfo> andonEventsRepsonded = 
            new List<AndonRspedEventInfo>();
        List<EventStakeholder> staffs = new List<EventStakeholder>();

        bool isShowMessageBeforeActive = false;

        public frmAndonEventConsultationCall()
        {
            InitializeComponent();

            switch (IRAPUser.Instance.CommunityID)
            {
                case 60006:
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        lblGetIDNo.Text = "Please swipe your card or enter a number "+
                            "to obtain a call to your andon event";
                    else
                        lblGetIDNo.Text = "    请刷卡或输入工号，获取呼叫您的安灯事件：";
                    edtIDCardNo.Properties.UseSystemPasswordChar = false;
                    break;
                default:
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        lblGetIDNo.Text = "Please swipe your card to obtain a "+
                            "call to your andon event";
                    else
                        lblGetIDNo.Text = "请刷卡，获取呼叫您的安灯事件：";
                    edtIDCardNo.Properties.UseSystemPasswordChar = true;
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

                        switch (IRAPUser.Instance.CommunityID)
                        {
                            case 60006:
                                staffInfo = new UserInfo()
                                {
                                    UserCode = edtIDCardNo.Text.Trim(),
                                };
                                break;
                            default:
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
                                    isShowMessageBeforeActive = true;
                                    IRAPMessageBox.Instance.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    edtIDCardNo.Text = "";
                                    edtIDCardNo.Focus();
                                    return;
                                }
                                break;
                        }

                        cboAndonEvent.SelectedItem = null;
                        cboAndonEvent.Properties.Items.Clear();

                        // 获取该用户需要响应的安灯事件列表
                        andonEventsRepsonded.Clear();
                        try
                        {
                            IRAPFVSClient.Instance.ufn_GetList_AndonEventsResponded(
                                IRAPUser.Instance.CommunityID,
                                staffInfo.UserCode,
                                IRAPUser.Instance.SysLogID,
                                ref andonEventsRepsonded,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                            if (errCode == 0)
                            {
                                if (andonEventsRepsonded.Count <= 0)
                                {
                                    isShowMessageBeforeActive = true;
                                    IRAPMessageBox.Instance.Show(
                                        "当前站点没有呼叫您的安灯事件！",
                                        Text,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                                    edtIDCardNo.Text = "";
                                    edtIDCardNo.Focus();
                                }
                                else
                                {
                                    tcMain.SelectedTabPage = tpAndonEvents;
                                    Application.DoEvents();

                                    foreach (AndonRspedEventInfo data in andonEventsRepsonded)
                                    {
                                        cboAndonEvent.Properties.Items.Add(data);
                                    }
                                    if (cboAndonEvent.Properties.Items.Count > 0)
                                        cboAndonEvent.SelectedIndex = 0;

                                }
                            }
                            else
                            {
                                isShowMessageBeforeActive = true;
                                IRAPMessageBox.Instance.Show(
                                    errText,
                                    Text,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                edtIDCardNo.Text = "";
                                edtIDCardNo.Focus();
                                return;
                            }
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(error.Message, strProcedureName);
                            WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                            isShowMessageBeforeActive = true;
                            IRAPMessageBox.Instance.Show(
                                error.Message,
                                Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            edtIDCardNo.Text = "";
                            edtIDCardNo.Focus();
                        }
                    }
                    finally
                    {
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                }
            }
        }

        private void cboAndonEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (cboAndonEvent.SelectedItem == null)
            {
                grdStaffs.DataSource = null;
                grdvStaffs.BestFitColumns();

                return;
            }

            AndonRspedEventInfo eventAndon = (AndonRspedEventInfo)cboAndonEvent.SelectedItem;
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPFVSClient.Instance.ufn_GetList_EventStakeholders(
                    IRAPUser.Instance.CommunityID,
                    eventAndon.EventFactID,
                    IRAPUser.Instance.SysLogID,
                    ref staffs,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                {
                    grdStaffs.DataSource = staffs;
                }
                else
                {
                    grdStaffs.DataSource = null;

                    isShowMessageBeforeActive = true;
                    IRAPMessageBox.Instance.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                grdStaffs.DataSource = null;

                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                isShowMessageBeforeActive = true;
                IRAPMessageBox.Instance.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnConsultationCall_Click(object sender, EventArgs e)
        {
            if (cboAndonEvent.SelectedItem == null)
            {
                return;
            }

            int intSelectedCount = 0;
            foreach (EventStakeholder staff in staffs)
            {
                if (staff.Choice)
                    intSelectedCount++;
            }
            if (intSelectedCount <= 0)
            {
                isShowMessageBeforeActive = true;
                IRAPMessageBox.Instance.Show("至少要选择一个人员！", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdStaffs.Focus();
                return;
            }

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                AndonRspedEventInfo andonEvent = cboAndonEvent.SelectedItem as AndonRspedEventInfo;

                string strSuccess = "";
                string strFailures = "";
                foreach (EventStakeholder staff in staffs)
                {
                    if (staff.Choice)
                    {
                        try
                        {
                            IRAPFVSClient.Instance.usp_AndonEventForwardingEx(
                                IRAPUser.Instance.CommunityID,
                                andonEvent.EventFactID,
                                andonEvent.OpID,
                                0,
                                staff.UserCode,
                                IRAPUser.Instance.SysLogID,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                            if (errCode != 0)
                            {
                                strFailures += string.Format("[{0}]", staff.UserName);
                                isShowMessageBeforeActive = true;
                                IRAPMessageBox.Instance.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                strSuccess += string.Format("[{0}]", staff.UserName);
                            }
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(error.Message, strProcedureName);
                            WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                            isShowMessageBeforeActive = true;
                            IRAPMessageBox.Instance.Show(
                                error.Message,
                                Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }

                string msg = "";
                if (strSuccess != "")
                    msg += string.Format("已经成功呼叫{0}前来参与会诊\n", strSuccess);
                if (strFailures != "")
                    msg += string.Format("{0}呼叫失败，你可以再次重新呼叫！", strFailures);

                if (msg != "")
                {
                    isShowMessageBeforeActive = true;
                    IRAPMessageBox.Instance.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                btnReturn.PerformClick();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            tcMain.SelectedTabPage = tpIDCardnoRead;

            edtIDCardNo.Text = "";
            edtIDCardNo.Focus();
        }

        private void tcMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page== tpIDCardnoRead)
            {
                edtIDCardNo.Focus();
            }
        }

        private void frmAndonEventConsultationCall_Activated(object sender, EventArgs e)
        {
            if (!isShowMessageBeforeActive)
            {
                btnReturn.PerformClick();
                isShowMessageBeforeActive = false;
            }
        }
    }
}
