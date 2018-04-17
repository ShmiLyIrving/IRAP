using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using DevExpress.XtraEditors.Controls;

namespace IRAP.Client.Global
{
    public partial class frmSysParams : IRAP.Client.Global.frmCustomBase
    {
        public frmSysParams()
        {
            InitializeComponent();
        }

        private void InitParams()
        {
            foreach (ImageComboBoxItem item in cboControlBoxType.Properties.Items)
            {
                if (item.Value.ToString() == IRAPConst.Instance.WarningLightCtrlBoxType)
                {
                    cboControlBoxType.SelectedItem = item;
                    break;
                }
            }
            edtZLan6042IPAddr.Text = IRAPConst.Instance.Zlan6042IPAddress;
            chkMultInstance.Checked = IRAPConst.Instance.MultiInstance;

            switch (IRAPConst.Instance.CommunityID)
            {
                case 60010:
                case 60030:
                    tpAsimcoParams.PageVisible = true;

                    if (ConfigurationManager.AppSettings["PrintProductInfoTrack"] != null)
                        chkPrintWIPProductInfoTrack.Checked =
                            ConfigurationManager.AppSettings["PrintProductInfoTrack"].ToUpper() == "TRUE";
                    else
                        chkPrintWIPProductInfoTrack.Checked = false;

                    break;
            }
        }

        private void SaveParams()
        {
            if (cboControlBoxType.SelectedIndex >= 0)
            {
                IRAPConst.Instance.WarningLightCtrlBoxType =
                    cboControlBoxType.Properties.Items[
                        cboControlBoxType.SelectedIndex].Value.ToString();
            }
            else
            {
                IRAPConst.Instance.WarningLightCtrlBoxType = "";
            }
            IRAPConst.Instance.Zlan6042IPAddress = edtZLan6042IPAddr.Text.Trim();
            IRAPConst.Instance.MultiInstance = chkMultInstance.Checked;

            switch (IRAPConst.Instance.CommunityID)
            {
                case 60010:
                case 60030:
                    IRAPConst.Instance.SaveParams(
                        "PrintProductInfoTrack",
                        chkPrintWIPProductInfoTrack.Checked.ToString());

                    break;
            }
        }

        private void cboControlBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboControlBoxType.SelectedItem != null)
            {
                ImageComboBoxItem item = cboControlBoxType.SelectedItem as ImageComboBoxItem;
                switch (item.Value.ToString())
                {
                    case "ZLAN6042":
                        tcControlBoxProperties.SelectedTabPage = tpZLan6042;
                        break;
                    default:
                        tcControlBoxProperties.SelectedTabPage = tpNone;
                        break;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveParams();

            DialogResult = DialogResult.OK;
        }

        private void frmSysParams_Shown(object sender, EventArgs e)
        {
            InitParams();
        }
    }
}
