using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace xFiletoESB
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
            edtBackupFileLocation.Text = SysParams.Instance.BackupFileSaveLocation;
            edtUnreadableFileLocation.Text = SysParams.Instance.UnreadableFileSaveLocation;
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
            SysParams.Instance.BackupFileSaveLocation = edtBackupFileLocation.Text.Trim();
            SysParams.Instance.UnreadableFileSaveLocation = edtUnreadableFileLocation.Text.Trim();
            SysParams.Instance.FileType = cboFileType.Text;
            SysParams.Instance.XmlRootNodeName = edtXMLRootNodeName.Text.Trim();

            this.DialogResult = DialogResult.OK;
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

        private void btn_localpathchose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择本地文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                edtLocalFileLocation.Text = folder.SelectedPath;                
            }
        }

        private void btn_backuppathchose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择备份文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                edtBackupFileLocation.Text = folder.SelectedPath;
            }
        }

        private void btn_unreadablepathchose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择错误文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                edtUnreadableFileLocation.Text = folder.SelectedPath;
            }
        }
        private void btn_localpathopen_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(edtLocalFileLocation.Text);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btn_backuppathopen_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(edtBackupFileLocation.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btn_unreadablepathopen_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(edtUnreadableFileLocation.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}