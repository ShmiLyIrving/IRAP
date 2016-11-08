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
using IRAP.Entities.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventCancel_30 : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private UserInfo staffInfo = new UserInfo();
        private List<AndonEventInfo> andonEvents = new List<AndonEventInfo>();
        AnimateImage image = null;

        public frmAndonEventCancel_30()
        {
            InitializeComponent();

            image = new AnimateImage(Properties.Resources.ReadIDCard);
            image.OnFrameChanged += new EventHandler<EventArgs>(image_OnFrameChanged);
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.UserPaint, 
                true);

            switch (IRAPUser.Instance.CommunityID)
            {
                case 60006:
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        lblGetIDNo.Text = "Please swipe your card or enter a number " +
                            "to obtain a call to your andon event";
                    else
                        lblGetIDNo.Text = "    请刷卡或输入工号，获取呼叫您的安灯事件：";
                    edtIDCardNo.Properties.UseSystemPasswordChar = false;
                    break;
                default:
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        lblGetIDNo.Text = "Please swipe your card to obtain a " +
                            "call to your andon event";
                    else
                        lblGetIDNo.Text = "请刷卡，获取呼叫您的安灯事件：";
                    edtIDCardNo.Properties.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void image_OnFrameChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void ReplaceIDCardNoReadPanel()
        {
            pnlIDCardNoRead.Top = (tpIDCardnoRead.Height - pnlIDCardNoRead.Height) / 2;
            pnlIDCardNoRead.Left = (tpIDCardnoRead.Width - pnlIDCardNoRead.Width) / 2;
        }

        private void frmAndonEventCancel_30_Resize(object sender, EventArgs e)
        {
            ReplaceIDCardNoReadPanel();
        }

        private void frmAndonEventCancel_30_Shown(object sender, EventArgs e)
        {
            tcMain.SelectedTabPage = tpIDCardnoRead;

            ReplaceIDCardNoReadPanel();
            image.Play();
        }

        private void frmAndonEventCancel_30_Paint(object sender, PaintEventArgs e)
        {
            lock (image.Image)
            {
                e.Graphics.DrawImage(image.Image, new Point(0, 0));
            }
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
                            IRAPMessageBox.Instance.Show(
                                errText, 
                                Text, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
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
                                IRAPFVSClient.Instance.ufn_GetList_AndonEventsToCancel(
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
                                        grdAndonEvents.DataSource = andonEvents;
                                        for (int i = 0; i < grdvAndonEvents.Columns.Count; i++)
                                        {
                                            grdvAndonEvents.Columns[i].BestFit();
                                        }
                                        grdvAndonEvents.OptionsView.RowAutoHeight = true;
                                        grdvAndonEvents.LayoutChanged();

                                        gpcAndonEvents.Text = string.Format("{0}触发的安灯事件", staffInfo.UserName);
                                        tcMain.SelectedTabPage = tpAndonEvents;
                                    }
                                    else
                                    {
                                        IRAPMessageBox.Instance.Show("没有您触发的安灯事件！", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        edtIDCardNo.Text = "";
                                        edtIDCardNo.Focus();
                                    }
                                }
                                else
                                {
                                    IRAPMessageBox.Instance.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    edtIDCardNo.Text = "";
                                    edtIDCardNo.Focus();
                                    return;
                                }
                            }
                            catch (Exception error)
                            {
                                WriteLog.Instance.Write(
                                    error.Message, 
                                    strProcedureName);
                                WriteLog.Instance.Write(
                                    error.StackTrace, 
                                    strProcedureName);
                                IRAPMessageBox.Instance.Show(
                                    error.Message, 
                                    Text, 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int index = grdvAndonEvents.GetFocusedDataSourceRowIndex();

            int itemID = 0;
            string parameters = "";

            if (Tag == null)
                return;
            itemID = ((MenuInfo)Tag).ItemID;
            parameters = ((MenuInfo)Tag).Parameters;

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int errCode = 0;
            string errText = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                try
                {
                    IRAPFVSClient.Instance.usp_AuthorizationRequest(
                        IRAPUser.Instance.CommunityID,
                        andonEvents[index].EventFactID,
                        staffInfo.UserCode,
                        staffInfo.UserName,
                        itemID,
                        Tools.ConvertToInt32(parameters),
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode != 0)
                    {
                        IRAPMessageBox.Instance.Show(
                            errText, 
                            Text, 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        IRAPMessageBox.Instance.Show(
                            errText, 
                            Text, 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(
                        error.Message,
                        strProcedureName);
                    WriteLog.Instance.Write(
                        error.StackTrace,
                        strProcedureName);

                    IRAPMessageBox.Instance.Show(
                        error.Message, 
                        Text, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }

                #region 要求用户输入安灯事件撤销授权码
                string veriCode = InputAuthrizeCode.Instance.Execute(errText);
                #endregion

                #region 撤销安灯事件
                CancelAndonEvent(andonEvents[index], veriCode);
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

            edtIDCardNo.Text = "";
            edtIDCardNo.Focus();

            tcMain.SelectedTabPage = tpIDCardnoRead;
        }

        private void CancelAndonEvent(AndonEventInfo andonEvent, string veriCode)
        {
            string strProcedureName = className + ".CancelAndonEvent";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                #region 保存
                try
                {
                    IRAPFVSClient.Instance.usp_AndonEventCancel(
                        IRAPUser.Instance.CommunityID,
                        andonEvent.EventFactID,
                        andonEvent.OpID,
                        this.staffInfo.UserCode,
                        veriCode,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    if (errCode != 0)
                        IRAPMessageBox.Instance.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        IRAPMessageBox.Instance.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    IRAPMessageBox.Instance.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            edtIDCardNo.Focus();

            tcMain.SelectedTabPage = tpIDCardnoRead;
        }

        private void tcMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tpIDCardnoRead)
            {
                edtIDCardNo.Focus();
            }
        }
    }
}
