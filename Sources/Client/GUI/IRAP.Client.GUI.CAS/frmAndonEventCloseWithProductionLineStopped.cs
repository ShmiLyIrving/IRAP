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
using IRAP.Entities.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventCloseWithProductionLineStopped : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private UserInfo userInfo = new UserInfo();
        private List<OpenAndonEventChoice> choices = new List<OpenAndonEventChoice>();

        public frmAndonEventCloseWithProductionLineStopped()
        {
            InitializeComponent();
        }

        public frmAndonEventCloseWithProductionLineStopped(
            int t134LeafID,
            long eventFactID):
            this()
        {
            GetOpenedAndonEvents(t134LeafID, eventFactID);
        }

        /// <summary>
        /// 操作员信息
        /// </summary>
        public UserInfo UserInfo
        {
            get { return userInfo; }
        }

        /// <summary>
        /// 满意度评价
        /// </summary>
        public int Satisfactory
        {
            get { return (int)rgpSatisfactory.Properties.Items[rgpSatisfactory.SelectedIndex].Value; }
        }

        /// <summary>
        /// 需要关联停线的新安灯事件事实号
        /// </summary>
        public long NewEventFactID
        {
            get
            {
                long rlt = 0;

                if (choices.Count <= 0)
                    rlt = 0;
                else
                    foreach (OpenAndonEventChoice data in choices)
                    {
                        if (data.Choice)
                        {
                            rlt = data.EventID;
                            break;
                        }
                    }

                return rlt;
            }
        }

        /// <summary>
        /// 获取指定产线的未关闭安灯事件列表
        /// </summary>
        /// <param name="t134LeafID"></param>
        /// <param name="excludeEventFactID"></param>
        private void GetOpenedAndonEvents(
            int t134LeafID,
            long excludeEventFactID)
        {
            if (t134LeafID == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "当前站点还没有绑定生产线！",
                    Text);
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
                List<OpenAndonEvent> datas = new List<OpenAndonEvent>();

                choices.Clear();

                IRAPFVSClient.Instance.ufn_GetList_OpenAndonEventsByLine(
                    IRAPUser.Instance.CommunityID,
                    134,
                    t134LeafID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                {
                    foreach (OpenAndonEvent data in datas)
                    {
                        if (data.EventID != excludeEventFactID && data.ProductionDown)
                            choices.Add(new OpenAndonEventChoice(data));
                    }

                    grdAndonEvents.DataSource = choices;
                }
                else
                {
                    grdAndonEvents.DataSource = choices;
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        Text);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private int LinkToStoppedEventCount()
        {
            int rlt = 0;
            foreach (OpenAndonEventChoice data in choices)
                if (data.Choice)
                    rlt++;
            return rlt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (userInfo.UserCode == "" || UserInfo.UserCode == null)
            {
                IRAPMessageBox.Instance.ShowErrorMessage("请输入您的工号！", Text);
                return;
            }
            if (rgpSatisfactory.SelectedIndex < 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage("请您对本次安灯事件的处理作出满意度评价！", Text);
                return;
            }

            int count = LinkToStoppedEventCount();
            switch (count)
            {
                case 0:
                    if (choices.Count == 0)
                        DialogResult = DialogResult.OK;
                    else
                    {
                        if (IRAPMessageBox.Instance.Show(
                            "当前产线是否已经恢复生产了？\n"+
                            "如果已经恢复，则点击[是]；\n"+
                            "如果还没有恢复生产，请点击[否]，选择一个已停产的安灯事件！",
                            Text,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            DialogResult = DialogResult.OK;
                    }
                    break;
                case 1:
                    DialogResult = DialogResult.OK;
                    break;
                default:
                    IRAPMessageBox.Instance.ShowErrorMessage("同一时刻只能有一个停产的安灯事件关联停线！", Text);
                    return;
            }
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
                    IRAPMessageBox.Instance.ShowErrorMessage(errText, Text);
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
                IRAPMessageBox.Instance.ShowErrorMessage(error.Message, Text);
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

    internal class OpenAndonEventChoice : OpenAndonEvent
    {
        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool Choice { get; set; }

        public OpenAndonEventChoice(OpenAndonEvent parent)
        {
            var parentType = typeof(OpenAndonEvent);
            var properties = parentType.GetProperties();

            foreach (var property in properties)
            {
                if (property.CanRead && property.CanWrite)
                {
                    property.SetValue(this, property.GetValue(parent, null), null);
                }
            }
        }
    }
}
