using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.Entities.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.UserControls
{
    public partial class ucBatchSysProduction : DevExpress.XtraEditors.XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private WIPStation stationInfo = null;
        private List<Shift> shifts = new List<Shift>();

        private UserDetailInfo currentOperator = null;
        private DateTime startDatetime = DateTime.Now;

        private string caption = "";

        public ucBatchSysProduction()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";
        }

        public ucBatchSysProduction(WIPStation station) : this()
        {
            stationInfo = station;

            if (station != null)
            {
                GetShifts();
                foreach (Shift shift in shifts)
                {
                    cboShift.Properties.Items.Add(shift);
                }
            }
        }

        private void GetShifts()
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

                IRAPMDMClient.Instance.ufn_GetList_ShiftsOfAMFGRSC(
                    IRAPUser.Instance.CommunityID,
                    134,
                    stationInfo.T134LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref shifts,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private UserDetailInfo GetUserInfoWithIDCode(string idCode)
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
                List<UserDetailInfo> users = new List<UserDetailInfo>();

                IRAPUserClient.Instance.sfn_GetList_UsersOfACommunity(
                    IRAPUser.Instance.CommunityID,
                    "",
                    idCode,
                    ref users,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    if (users.Count == 0)
                    {
                        XtraMessageBox.Show(
                            string.Format(
                                "未找到[{0}]的用户",
                                idCode),
                            caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return null;
                    }
                    else
                    {
                        return users[0];
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName)
;            }
        }

        private void edtOperatorCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (edtOperatorCode.Text.Trim() != "")
                {
                    currentOperator = GetUserInfoWithIDCode(edtOperatorCode.Text.Trim());
                    if (currentOperator != null)
                    {
                        edtOperatorCode.Text =
                            string.Format(
                                "{0}[{1}]",
                                currentOperator.UserName,
                                currentOperator.UserCode);
                    }
                    else
                    {
                        edtOperatorCode.Text = "";
                    }
                }
                else
                {
                    edtOperatorCode.Text = "";
                    currentOperator = null;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            lblCurrentTime.Text =
                now.ToString("yyyy-MM-dd HH:mm:ss");

            TimeSpan span = now - startDatetime;
            lblProductTimeSpan.Text = "";
            if (span.Days != 0)
                lblProductTimeSpan.Text = string.Format("{0}天", span.Days);
            if (span.Hours != 0)
                lblProductTimeSpan.Text += string.Format("{0}小时", span.Hours);
            if (span.Minutes != 0)
                lblProductTimeSpan.Text += string.Format("{0}分钟", span.Minutes);
            if (span.Seconds != 0)
                lblProductTimeSpan.Text += string.Format("{0}秒", span.Seconds);
        }
    }
}
