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
using IRAP.Entity.MES;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmAppearanceInspection : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string caption = "";
        private EventHandler afterOptionChanged = null;

        private WIPIDCode wip = new WIPIDCode();
        private List<SelectFailureMode> selectedFModes = new List<SelectFailureMode>();

        public frmAppearanceInspection()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";

            afterOptionChanged = new EventHandler(frmApperanceInspetion_AfterOptionChanged);
        }

        private void GetFailureModes(int productLeaf, int workUnitLeaf)
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

                List<FailureMode> failureModes = new List<FailureMode>();
                try
                {
                    IRAPMDMClient.Instance.ufn_GetList_FailureModes(
                        IRAPUser.Instance.CommunityID,
                        productLeaf,
                        workUnitLeaf,
                        IRAPUser.Instance.SysLogID,
                        ref failureModes,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = error.Message;
                }
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
                }

                selectedFModes.Clear();
                foreach (FailureMode mode in failureModes)
                {
                    selectedFModes.Add(
                        new SelectFailureMode()
                        {
                            FailureMode = mode.Clone(),
                            Selected = false,
                        });
                }

                grdFailureModes.DataSource = selectedFModes;
                grdvFailureModes.BestFitColumns();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void CleanFailureModes()
        {
            selectedFModes.Clear();
            grdFailureModes.DataSource = null;
        }

        private int FailureModeSelectCount()
        {
            int rlt = 0;
            foreach (SelectFailureMode mode in selectedFModes)
            {
                if (mode.Selected)
                    rlt++;
            }
            return rlt;
        }

        private List<FailureMode> GetSelectedFailureModes()
        {
            List<FailureMode> rlt = new List<FailureMode>();
            foreach (SelectFailureMode mode in selectedFModes)
            {
                if (mode.Selected)
                    rlt.Add(mode.FailureMode.Clone());
            }
            return rlt;
        }

        private void frmApperanceInspetion_AfterOptionChanged(object sender, EventArgs e)
        {
            edtWIPBarCode.Text = "";
            CleanFailureModes();
        }

        private void frmAppearanceInspection_Activated(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                Options.Visible = true;

                frmApperanceInspetion_AfterOptionChanged(null, null);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void edtWIPBarCode_Validating(object sender, CancelEventArgs e)
        {
            CleanFailureModes();

            if (Options.SelectStation == null)
            {
                XtraMessageBox.Show(
                    "未选择选项一！",
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (Options.SelectProduct == null)
            {
                XtraMessageBox.Show(
                    "未选择选项二！",
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (edtWIPBarCode.Text.Trim() != "")
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

                    try
                    {
                        IRAPMESClient.Instance.ufn_GetInfo_WIPIDCode(
                            IRAPUser.Instance.CommunityID,
                            edtWIPBarCode.Text.Trim(),
                            Options.SelectProduct.T102LeafID,
                            Options.SelectStation.T107LeafID,
                            false,
                            IRAPUser.Instance.SysLogID,
                            ref wip,
                            out errCode,
                            out errText);
                    }
                    catch (Exception error)
                    {
                        errCode = -1;
                        errText = error.Message;
                    }
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

                        edtWIPBarCode.SelectAll();
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        if (wip.BarcodeStatus != 0)
                        {
                            WriteLog.Instance.Write(wip.BarcodeStatusStr, strProcedureName);
                            XtraMessageBox.Show(
                                wip.BarcodeStatusStr,
                                caption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            edtWIPBarCode.SelectAll();
                            e.Cancel = true;
                            return;
                        }
                        else if (wip.RoutingStatus != 0)
                        {
                            WriteLog.Instance.Write(wip.RoutingStatusStr, strProcedureName);
                            XtraMessageBox.Show(
                                wip.RoutingStatusStr,
                                caption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            edtWIPBarCode.SelectAll();
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            WriteLog.Instance.Write(
                                string.Format(
                                    "得到产品标签：[{0}]",
                                    wip.WIPPattern),
                                strProcedureName);

                            GetFailureModes(wip.ProductLeaf, wip.WorkUnitLeaf);

                            e.Cancel = false;
                            return;
                        }
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
            else
            {
                wip = new WIPIDCode();
                e.Cancel = false;
            }
        }

        private void frmAppearanceInspection_Load(object sender, EventArgs e)
        {
            grdFailureModes.DataSource = selectedFModes;

            Options.OptionChanged += afterOptionChanged;
        }

        private void frmAppearanceInspection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Options.OptionChanged -= afterOptionChanged;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 检查是否扫描产品条码
            if (edtWIPBarCode.Text.Trim() == "")
            {
                XtraMessageBox.Show(
                    "请先扫描产品条码！",
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtWIPBarCode.Focus();
                return;
            }
            #endregion

            #region 检查是否选择了失效模式
            if (FailureModeSelectCount() == 0)
            {
                XtraMessageBox.Show(
                    "请先选择失效模式（至少一个）！",
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                grdFailureModes.Focus();
                return;
            }
            #endregion

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
                string scrapCode = "";

                #region 申请交易号
                try
                {
                    transactNo = IRAPUTSClient.Instance.mfn_GetTransactNo(
                        IRAPUser.Instance.CommunityID,
                        1,
                        IRAPUser.Instance.SysLogID,
                        "6");
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                WriteLog.Instance.Write(
                    string.Format("申请到的交易号：[{0}]", transactNo),
                    strProcedureName);
                if (transactNo == 0)
                {
                    XtraMessageBox.Show(
                        string.Format("申请到的交易号[{0}]无效！", transactNo),
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                #endregion

                #region 申请事实编号
                try
                {
                    factID = IRAPUTSClient.Instance.mfn_GetFactID(
                        IRAPUser.Instance.CommunityID,
                        FailureModeSelectCount(),
                        IRAPUser.Instance.SysLogID,
                        "6");
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                WriteLog.Instance.Write(
                    string.Format("申请到的事实编号：[{0}]", factID),
                    strProcedureName);
                if (factID == 0)
                {
                    XtraMessageBox.Show(
                        string.Format("申请到的事实编号[{0}]无效！", factID),
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                #endregion

                List<FailureMode> selectModes = new List<FailureMode>();
                selectModes = GetSelectedFailureModes();
                foreach (FailureMode mode in selectModes)
                {
                    if (scrapCode != "")
                        scrapCode += ",";
                    scrapCode += string.Format("{0}", mode.FailureLeaf);
                }

                #region 保存外观检查事实
                try
                {
                    IRAPMESClient.Instance.usp_SaveFact_Inspecting(
                        IRAPUser.Instance.CommunityID,
                        transactNo,
                        factID,
                        Options.SelectProduct.T102LeafID,
                        Options.SelectStation.T107LeafID,
                        IRAPUser.Instance.SysLogID,
                        edtWIPBarCode.Text.Trim(),
                        scrapCode,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = error.Message;
                }

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
                }
                else
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    edtWIPBarCode.Text = "";
                    CleanFailureModes();

                    edtWIPBarCode.Focus();
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }

    internal class SelectFailureMode
    {
        private FailureMode failureMode = new FailureMode();
        private bool selected = false;

        public FailureMode FailureMode
        {
            get { return failureMode; }
            set { failureMode = value; }
        }

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
    }
}
