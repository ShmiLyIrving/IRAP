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
using IRAP.Client.Global.GUI.Dialogs;
using IRAP.Entity.SSO;
using IRAP.Entities.SSO;
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventForward_30 : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private List<AndonEventInfo> andonEvents = new List<AndonEventInfo>();
        private List<ResponsibleResponderInfo> responders = new List<ResponsibleResponderInfo>();
        private UserInfo staffInfo = new UserInfo();

        public frmAndonEventForward_30()
        {
            InitializeComponent();
        }

        private void ReplaceIDCardNoReadPanel()
        {
            pnlIDCardNoRead.Top = (tpIDCardnoRead.Height - pnlIDCardNoRead.Height) / 3;
            pnlIDCardNoRead.Left = (tpIDCardnoRead.Width - pnlIDCardNoRead.Width) / 2;
        }

        private void frmAndonEventForward_30_Resize(object sender, EventArgs e)
        {
            ReplaceIDCardNoReadPanel();
        }

        private void frmAndonEventForward_30_Shown(object sender, EventArgs e)
        {
            tcMain.SelectedTabPage = tpIDCardnoRead;
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
                        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                        if (errCode != 0)
                        {
                            ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            edtIDCardNo.Text = "";
                            edtIDCardNo.Focus();
                            return;
                        }
                        else
                        {
                            // 获取呼叫该用户的安灯事件列表
                            andonEvents.Clear();
                            try
                            {
                                IRAPFVSClient.Instance.ufn_GetList_AndonEventsToForward(
                                    IRAPUser.Instance.CommunityID,
                                    staffInfo.UserCode,
                                    IRAPUser.Instance.SysLogID,
                                    ref andonEvents,
                                    out errCode,
                                    out errText);
                                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                                if (errCode == 0)
                                {
                                    if (andonEvents.Count > 0)
                                    {
                                        cboAndonEvents.Properties.Items.Clear();
                                        foreach (AndonEventInfo andonEvent in andonEvents)
                                        {
                                            cboAndonEvents.Properties.Items.Add(andonEvent);
                                            Application.DoEvents();
                                        }
                                        cboAndonEvents.SelectedIndex = -1;
                                        grdStaffs.DataSource = null;

                                        gpcAndonEvents.Text = string.Format("呼叫{0}的安灯事件", staffInfo.UserName);
                                        tcMain.SelectedTabPage = tpAndonEvents;
                                    }
                                    else
                                    {
                                        MessageBox.Show("您没有已经响应的安灯事件！", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        edtIDCardNo.Text = "";
                                        edtIDCardNo.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    edtIDCardNo.Text = "";
                                    edtIDCardNo.Focus();
                                    return;
                                }
                            }
                            catch (Exception error)
                            {
                                WriteLog.Instance.Write(error.Message, strProcedureName);
                                MessageBox.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                grdStaffs.DataSource = null;

                                edtIDCardNo.Text = "";
                                edtIDCardNo.Focus();
                            }
                        }
                    }
                    finally
                    {
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            tcMain.SelectedTabPage = tpIDCardnoRead;
            edtIDCardNo.Text = "";
            edtIDCardNo.Focus();
        }

        private void cboAndonEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAndonEvents.SelectedIndex < 0)
            {
                responders.Clear();
                grdStaffs.DataSource = null;
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
                AndonEventInfo andonEvent = cboAndonEvents.SelectedItem as AndonEventInfo;

                int errCode = 0;
                string errText = "";

                try
                {
                    responders.Clear();
                    IRAPFVSClient.Instance.ufn_GetList_ResponsibleRespondersToInform(
                        IRAPUser.Instance.CommunityID,
                        andonEvent.EventFactID,
                        andonEvent.OpID,
                        IRAPUser.Instance.SysLogID,
                        ref responders,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    if (errCode == 0)
                    {
                        for (int i = 0; i < responders.Count; i++)
                        {
                            if (responders[i].UserCode == staffInfo.UserCode)
                            {
                                responders.RemoveAt(i);
                                break;
                            }
                        }
                        grdStaffs.DataSource = responders;
                    }
                    else
                    {
                        grdStaffs.DataSource = null;
                        MessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception error)
                {
                    grdStaffs.DataSource = null;

                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    MessageBox.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            int intSelectedCount = 0;
            foreach (ResponsibleResponderInfo staff in responders)
            {
                if (staff.Choice)
                    intSelectedCount++;
            }
            if (intSelectedCount <= 0)
            {
                MessageBox.Show("至少要选择一个人员！", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdStaffs.Focus();
                return;
            }

            string strProcedureName = className + ".btnForward_Click";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                AndonEventInfo andonEvent = cboAndonEvents.SelectedItem as AndonEventInfo;

                foreach (ResponsibleResponderInfo staff in responders)
                {
                    if (staff.Choice)
                    {
                        try
                        {
                            IRAPFVSClient.Instance.usp_AndonEventForwarding(
                                IRAPUser.Instance.CommunityID,
                                andonEvent.EventFactID,
                                andonEvent.OpID,
                                staff.Ordinal,
                                staff.UserCode,
                                IRAPUser.Instance.SysLogID,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                            MessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                btnReturn.PerformClick();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}

