using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ESBtoxFile
{
    public partial class frmSysParams : DevExpress.XtraEditors.XtraForm
    {
        public frmSysParams()
        {
            InitializeComponent();
        }

        private void frmSysParams_Load(object sender, EventArgs e)
        {
            edtUpgradeURL.Text = SysParams.Instance.UpgradeURL;
            chkWriteLog.Checked = SysParams.Instance.IsWriteLog;

            edtBrokeURI.Text = SysParams.Instance.ActiveMQ_URI;
            edtQueueName.Text = SysParams.Instance.ActiveMQ_QueueName;
            edtFilterString.Text = SysParams.Instance.FilterString;
            edtExCode.Text = SysParams.Instance.ExCode;

            edtLocalFileLocation.Text = SysParams.Instance.LocalFileSaveLocation;
            edtLocalFileName.Text = SysParams.Instance.LocalFileName;
            cboFileType.Text = SysParams.Instance.FileType;
            edtXMLRootNodeName.Text = SysParams.Instance.XmlRootNodeName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SysParams.Instance.UpgradeURL = edtUpgradeURL.Text.Trim();
            SysParams.Instance.IsWriteLog = chkWriteLog.Checked;

            SysParams.Instance.ActiveMQ_URI = edtBrokeURI.Text.Trim();
            SysParams.Instance.ActiveMQ_QueueName = edtQueueName.Text.Trim();
            SysParams.Instance.FilterString = edtFilterString.Text.Trim();
            SysParams.Instance.ExCode = edtExCode.Text.Trim();

            SysParams.Instance.LocalFileSaveLocation = edtLocalFileLocation.Text.Trim();
            SysParams.Instance.LocalFileName = edtLocalFileName.Text.Trim();
            SysParams.Instance.FileType = cboFileType.Text;
            SysParams.Instance.XmlRootNodeName = edtXMLRootNodeName.Text.Trim();

            btnCancel.PerformClick();
        }

        private void cboFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboFileType.SelectedIndex)
            {
                case 0:
                    tcFileTypeProperties.SelectedTabPage = tpXmlProperties;
                    break;
            }
        }
    }
}