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
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventRespond_30 : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private UserInfo staffInfo = new UserInfo();
        private List<AndonRspEventInfo> andonEventsToRespond = new List<AndonRspEventInfo>();
        private List<AndonRspEventInfo> andonEventsInList = new List<AndonRspEventInfo>();

        public frmAndonEventRespond_30()
        {
            InitializeComponent();
        }

        private void ReplaceIDCardNoReadPanel()
        {
            pnlIDCardNoRead.Top = (tpIDCardnoRead.Height - pnlIDCardNoRead.Height) / 2;
            pnlIDCardNoRead.Left = (tpIDCardnoRead.Width - pnlIDCardNoRead.Width) / 2;
        }

        private void frmAndonEventRespond_30_Resize(object sender, EventArgs e)
        {
            ReplaceIDCardNoReadPanel();
        }

        private void frmAndonEventRespond_30_Shown(object sender, EventArgs e)
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

            if (e.KeyCode== Keys.Return)
            {
                if (edtIDCardNo.Text.Trim() != "")
                {
                    WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                    try
                    {
                        int errCode = 0;
                        string errText = "";

                        IRAPUserClient.Instance.sfn_GetInfo_UserFromIDCode(
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
                            ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            edtIDCardNo.Text = "";
                            edtIDCardNo.Focus();
                            return;
                        }
                        else
                        {
                            // 获取该用户需要响应的安灯事件列表
                            andonEventsToRespond.Clear();
                            try
                            {
                                IRAPFVSClient.Instance.ufn_GetList_AndonEventsToRespond(
                                    IRAPUser.Instance.CommunityID,
                                    staffInfo.UserCode,
                                    IRAPUser.Instance.SysLogID,
                                    ref andonEventsToRespond,
                                    out errCode,
                                    out errText);
                                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                                if (errCode == 0)
                                {
                                    if (andonEventsToRespond.Count > 0)
                                    {
                                        chkCallOtherOneAndonEvents.Checked = false;
                                        chkCallOtherOneAndonEvents_CheckedChanged(chkCallOtherOneAndonEvents, new EventArgs());

                                        tcMain.SelectedTabPage = tpAndonEvents;
                                    }
                                    else
                                    {
                                        ShowMessageBox.Show("当前站点没有呼叫您的安灯事件！", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        edtIDCardNo.Text = "";
                                        edtIDCardNo.Focus();
                                    }
                                }
                                else
                                {
                                    ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    edtIDCardNo.Text = "";
                                    edtIDCardNo.Focus();
                                    return;
                                }
                            }
                            catch (Exception error)
                            {
                                WriteLog.Instance.Write(error.Message, strProcedureName);
                                ShowMessageBox.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                grdAndonEvents.DataSource = null;

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

        private void btnResponse_Click(object sender, EventArgs e)
        {
            int intSelectedCount = 0;
            foreach (AndonRspEventInfo andonEvent in andonEventsInList)
            {
                if (andonEvent.Choice)
                    intSelectedCount++;
            }
            if (intSelectedCount <= 0)
            {
                ShowMessageBox.Show("至少要选择一个安灯事件！", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdAndonEvents.Focus();
                return;
            }

            #region 保存响应的安灯事件事实
            foreach (AndonRspEventInfo andonEvent in andonEventsInList)
            {
                if (andonEvent.Choice)
                {
                    SaveAndonEventRespond(andonEvent);
                }
            }
            #endregion

            edtIDCardNo.Text = "";
            tcMain.SelectedTabPage = tpIDCardnoRead;
        }

        private void SaveAndonEventRespond(AndonEventInfo andonEvent)
        {
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
                long transactNo = 0;
                long factID = 0;

                #region 获取交易号和事实编号
                try
                {
                    factID = IRAPUTSClient.Instance.mfn_GetFactID(
                        IRAPUser.Instance.CommunityID,
                        1,
                        IRAPUser.Instance.SysLogID,
                        ((MenuInfo)this.Tag).OpNode);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    ShowMessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    transactNo = IRAPUTSClient.Instance.mfn_GetTransactNo(
                        IRAPUser.Instance.CommunityID,
                        1,
                        IRAPUser.Instance.SysLogID,
                        ((MenuInfo)this.Tag).OpNode);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    MessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                #region 保存
                try
                {
                    IRAPFVSClient.Instance.usp_SaveFact_AndonEventOnSiteRespond(
                        IRAPUser.Instance.CommunityID,
                        transactNo,
                        factID,
                        andonEvent.EventFactID,
                        andonEvent.OpID,
                        this.staffInfo.UserCode,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    if (errCode != 0)
                        ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    ShowMessageBox.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            edtIDCardNo.Text = "";
            tcMain.SelectedTabPage = tpIDCardnoRead;
        }

        private void tcMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tcMain.SelectedTabPage == tpIDCardnoRead)
                edtIDCardNo.Focus();
        }

        private void chkCallOtherOneAndonEvents_CheckedChanged(object sender, EventArgs e)
        {
            andonEventsInList.Clear();

            foreach (AndonRspEventInfo andonEvent in andonEventsToRespond)
            {
                if (chkCallOtherOneAndonEvents.Checked)
                {
                    gpcAndonEvents.Text = string.Format(string.Format("{0}可以响应的安灯事件", staffInfo.UserName));
                    if (andonEvent.AndonEventOwnership == 0)
                    {
                        andonEventsInList.Add(andonEvent);
                    }
                }
                else
                {
                    gpcAndonEvents.Text = string.Format(string.Format("呼叫{0}的安灯事件", staffInfo.UserName));
                    if (andonEvent.AndonEventOwnership != 0)
                    {
                        andonEventsInList.Add(andonEvent);
                    }
                }
            }

            grdAndonEvents.DataSource = andonEventsInList;
            for (int i = 0; i < grdvAndonEvents.Columns.Count; i++)
            {
                grdvAndonEvents.Columns[i].BestFit();
            }
            grdvAndonEvents.OptionsView.RowAutoHeight = true;
            grdvAndonEvents.LayoutChanged();
        }
    }
}
