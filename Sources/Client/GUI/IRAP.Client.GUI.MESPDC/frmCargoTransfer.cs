using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystems;
using IRAP.Entity.MDM;
using IRAP.Entity.SSO;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;
using IRAP.Client.Global.GUI.Dialogs;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmCargoTransfer : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private MenuInfo menuInfo = null;
        private UDFForm1Ex_30 busUDFForm = new UDFForm1Ex_30();

        public frmCargoTransfer()
        {
            InitializeComponent();
        }

        private void edtPartNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (cboCustomers.Properties.Items.Count > 0)
            {
                cboCustomers.Properties.Items.Clear();
                cboCustomers.SelectedIndex = -1;
            }
            if (cboAddresses.Properties.Items.Count > 0)
            {
                cboAddresses.Properties.Items.Clear();
                cboAddresses.SelectedIndex = -1;
            }
            edtTransferQuantity.Text = "";
            edtProductDate.DateTime = DateTime.Now;
        }

        private void edtPartNumber_Validating(object sender, CancelEventArgs e)
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
                List<CustomerOfAProduction> customers = new List<CustomerOfAProduction>();

                cboCustomers.Properties.Items.Clear();
                IRAPMDMClient.Instance.ufn_GetList_CustomerProduct(
                    IRAPUser.Instance.CommunityID,
                    edtPartNumber.Text,
                    IRAPUser.Instance.SysLogID,
                    ref customers,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                {
                    foreach (CustomerOfAProduction customer in customers)
                        cboCustomers.Properties.Items.Add(customer);
                    if (cboCustomers.Properties.Items.Count > 0)
                        cboCustomers.SelectedIndex = 0;
                }
                else
                {
                    cboCustomers.SelectedIndex = -1;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void cboCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboAddresses.Properties.Items.Clear();
            cboAddresses.SelectedIndex = -1;

            if (cboCustomers.SelectedItem != null)
            {
                CustomerOfAProduction customer = 
                    cboCustomers.SelectedItem as CustomerOfAProduction;

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
                    List<AvailableSite> sites = new List<AvailableSite>();

                    cboAddresses.Properties.Items.Clear();
                    IRAPMDMClient.Instance.ufn_GetList_AvaiableSite(
                        IRAPUser.Instance.CommunityID,
                        customer.T102LeafID,
                        customer.T105LeafID,
                        IRAPUser.Instance.SysLogID,
                        ref sites,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        foreach (AvailableSite site in sites)
                            cboAddresses.Properties.Items.Add(site);
                        if (cboAddresses.Properties.Items.Count > 0)
                            cboAddresses.SelectedIndex = 0;
                    }
                    else
                    {
                        cboCustomers.SelectedIndex = -1;
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (edtPartNumber.Text.Trim() == "")
                edtPartNumber.Focus();
            if (cboCustomers.SelectedItem == null)
                cboCustomers.Focus();
            if (cboAddresses.SelectedItem == null)
                cboAddresses.Focus();
            if (edtTransferQuantity.Text == "")
                edtTransferQuantity.Focus();
            if (edtProductDate.EditValue == null)
                edtProductDate.Focus();

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 数据校验
                int errCode = 0;
                string errText = "";
                IRAPSCESClient.Instance.usp_PokaYoke_PallPrint(
                    IRAPUser.Instance.CommunityID,
                    edtPartNumber.Text.Trim(),
                    ((CustomerOfAProduction)cboCustomers.SelectedItem).T105Code,
                    ((AvailableSite)cboAddresses.SelectedItem).T172Code,
                    edtTransferQuantity.Text.Trim(),
                    edtProductDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                    if (
                        ShowMessageBox.Show(
                            errText, 
                            "数据校验时发现问题", 
                            MessageBoxButtons.OKCancel, 
                            MessageBoxIcon.Question, 
                            MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                    {
                        edtTransferQuantity.Focus();
                        return;
                    }

                #endregion

                #region 保存
                busUDFForm.SetStrParameterValue(edtPartNumber.Text, 1);
                busUDFForm.SetStrParameterValue(((CustomerOfAProduction)cboCustomers.SelectedItem).T105Code, 2);
                busUDFForm.SetStrParameterValue(((AvailableSite)cboAddresses.SelectedItem).T172Code, 3);
                busUDFForm.SetStrParameterValue(edtTransferQuantity.Text, 4);
                busUDFForm.SetStrParameterValue(edtProductDate.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), 5);
                busUDFForm.SetStrParameterValue(edtCopies.Value.ToString(), 6);

                busUDFForm.SaveOLTPUDFFormData(0, 0);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", busUDFForm.ErrorCode, busUDFForm.ErrorMessage),
                    strProcedureName);
                xucIRAPListView.WriteLog(
                    busUDFForm.ErrorCode,
                    busUDFForm.ErrorMessage,
                    DateTime.Now);

                if (busUDFForm.ErrorCode == 0)
                {
                    edtPartNumber.Text = "";
                    cboCustomers.Properties.Items.Clear();
                    cboCustomers.SelectedItem = null;
                    cboAddresses.Properties.Items.Clear();
                    cboAddresses.SelectedItem = null;
                    edtTransferQuantity.Text = "";
                    edtProductDate.EditValue = null;

                    WriteLog.Instance.Write(
                        string.Format("Output={0}", busUDFForm.OutputStr),
                        strProcedureName);
                    if (busUDFForm.OutputStr != "")
                    {
                        try
                        {
                            Actions.UDFActions.DoActions(
                                busUDFForm.OutputStr,
                                null);
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(
                                string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                                    error.Message,
                                    error.StackTrace),
                                strProcedureName);
                            xucIRAPListView.WriteLog(
                                -1,
                                string.Format(
                                    "执行输出指令时发生错误：[{0}]",
                                    error.Message),
                                DateTime.Now);
                        }
                    }

                    edtPartNumber.Focus();
                }
                else
                {
                    edtTransferQuantity.Text = "";
                    edtProductDate.EditValue = null;

                    edtTransferQuantity.Focus();
                }
                #endregion
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                xucIRAPListView.WriteLog(-1, error.Message, DateTime.Now);

                edtTransferQuantity.Text = "";
                edtProductDate.EditValue = null;

                edtTransferQuantity.Focus();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmCargoTransfer_Shown(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (this.Tag is MenuInfo)
                {
                    menuInfo = this.Tag as MenuInfo;
                }
                else
                {
                    WriteLog.Instance.Write("没有正确的传入菜单参数", strProcedureName);
                    xucIRAPListView.WriteLog(-1, "没有正确的传入菜单参数！", DateTime.Now);
                    return;
                }

                try
                {
                    if (menuInfo.Parameters == "")
                    {
                        xucIRAPListView.WriteLog(-1, "菜单参数中没有正确配置万能表单的参数", DateTime.Now);
                    }
                    else
                    {
                        busUDFForm.SetCtrlParameter(menuInfo.Parameters);
                        busUDFForm.OpNode = menuInfo.OpNode;

                        frmCargoTransfer_Activated(this, null);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    xucIRAPListView.WriteLog(-1, error.Message, DateTime.Now);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmCargoTransfer_Activated(object sender, EventArgs e)
        {
        }
    }
}
