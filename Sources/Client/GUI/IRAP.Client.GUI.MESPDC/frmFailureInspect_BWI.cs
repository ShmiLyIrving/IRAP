using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmFailureInspect_BWI : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<FailureModeByWorkUnit> datas = new List<FailureModeByWorkUnit>();

        private string caption;

        public frmFailureInspect_BWI()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";
        }

        #region 自定义函数
        private List<FailureModeByWorkUnit> GetFailureModes(int t107LeafID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            List<FailureModeByWorkUnit> datas = new List<FailureModeByWorkUnit>();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPMDMClient.Instance.ufn_GetList_WorkUnitFailureModes(
                    IRAPUser.Instance.CommunityID,
                    t107LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                    throw new Exception(errText);
                else
                {
                    return datas;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void AfterOptionChanged(object sender, EventArgs e)
        {
            edtProductCardNo.Text = "";
            grdFailureModes.DataSource = null;
        }

        private long GetTotalFailureQuantity(List<FailureModeByWorkUnit> datas)
        {
            long rlt = 0;

            foreach (FailureModeByWorkUnit data in datas)
            {
                if (data.Qty != 0)
                    rlt += data.Qty;
            }

            return rlt;
        }

        private string GenerateRSFactXML(List<FailureModeByWorkUnit> datas)
        {
            string rlt = "";

            foreach (FailureModeByWorkUnit data in datas)
            {
                if (data.Qty != 0)
                {
                    rlt +=
                        string.Format(
                            "<RF17 Ordinal=\"{0}\" T118LeafID=\"{1}\" Metric01=\"{2}\" />\n",
                            data.Ordinal,
                            data.T118LeafID,
                            data.Qty);
                }
            }

            return string.Format(
                "<RSFact>\n{0}</RSFact>",
                rlt);
        }
        #endregion

        private void frmFailureInspect_BWI_Load(object sender, EventArgs e)
        {
            Options.OptionChanged += AfterOptionChanged;
        }

        private void frmFailureInspect_BWI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Options.OptionChanged -= AfterOptionChanged;
        }

        private void edtProductCardNo_Validating(object sender, CancelEventArgs e)
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

                IRAPMESClient.Instance.usp_PokaYoke_PalletRouting(
                    IRAPUser.Instance.CommunityID,
                    Options.SelectProduct.T102LeafID,
                    Options.SelectStation.T107LeafID,
                    edtProductCardNo.Text.Trim(),
                    IRAPUser.Instance.SysLogID,
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
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void edtProductCardNo_Validated(object sender, EventArgs e)
        {
            try
            {
                datas = GetFailureModes(Options.SelectStation.T107LeafID);

                grdFailureModes.DataSource = datas;
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                grdFailureModes.DataSource = null;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            grdFailureModes.DataSource = null;
            edtProductCardNo.Text = "";

            edtProductCardNo.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
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

                long intTransactNo = 0;
                long intFactID = 0;

                #region 申请交易号和事实编号
                try
                {
                    intTransactNo =
                        IRAPUTSClient.Instance.mfn_GetTransactNo(
                            IRAPUser.Instance.CommunityID,
                            1,
                            IRAPUser.Instance.SysLogID,
                            "17");
                    intFactID =
                        IRAPUTSClient.Instance.mfn_GetFactID(
                            IRAPUser.Instance.CommunityID,
                            1,
                            IRAPUser.Instance.SysLogID,
                            "17");
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(
                        string.Format(
                            "申请交易号和事实编号的时候发生错误：{0}",
                            error.Message),
                        strProcedureName);

                    XtraMessageBox.Show(
                        error.Message,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                #endregion

                IRAPMESClient.Instance.usp_SaveFact_FailureInspecting(
                    IRAPUser.Instance.CommunityID,
                    intTransactNo,
                    intFactID,
                    Options.SelectProduct.T102LeafID,
                    Options.SelectStation.T107LeafID,
                    edtProductCardNo.Text.Trim(),
                    "",
                    GetTotalFailureQuantity(datas),
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                    btnClear.PerformClick();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmFailureInspect_BWI_Activated(object sender, EventArgs e)
        {
            Options.Visible = true;            
        }
    }
}
