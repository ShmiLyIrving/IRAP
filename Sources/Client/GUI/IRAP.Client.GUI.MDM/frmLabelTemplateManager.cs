using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using FastReport;
using FastReport.Data;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MDM
{
    public partial class frmLabelTemplateManager : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public frmLabelTemplateManager()
        {
            InitializeComponent();
        }

        private void ribeActions_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int idx = grdvAddressList.GetFocusedDataSourceRowIndex();
            if (idx >= 0)
            {
                if (grdAddressList.DataSource != null &&
                    (grdAddressList.DataSource as List<AvailableSite>).Count > idx)
                {
                    AvailableSite site = (grdAddressList.DataSource as List<AvailableSite>)[idx];

                    using (frmTemplateManager formTemplateManager = new frmTemplateManager(site))
                    {
                        formTemplateManager.ShowDialog();
                    }

                    cboCustomers_SelectedIndexChanged(null, null);
                }
            }
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
                cboCustomers.Properties.Items.Clear();
                cboCustomers.SelectedItem = null;
                grdAddressList.DataSource = null;

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
                        grdAddressList.DataSource = sites;
                    }
                    else
                    {
                        grdAddressList.DataSource = null;
                    }

                    grdvAddressList.BestFitColumns();
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }
    }
}
