using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.IO;

using IRAP.Global;

namespace IRAP.PLC.Collection
{
    public partial class frmSystemParams : Form
    {
        public frmSystemParams()
        {
            InitializeComponent();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            Controls.Clear();

            if (btnSwitch.Text == "英")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            if (btnSwitch.Text == "中")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            }

            InitializeComponent();
            frmSystemParams_Load(null, null);
        }

        private void frmSystemParams_Load(object sender, EventArgs e)
        {

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            {
                cboDeviceType.Properties.Items.Clear();

                cboDeviceType.Properties.Items.Add(new DeviceType() { ID = 0, Name = "BF-0016/BF-0824", });
                cboDeviceType.Properties.Items.Add(new DeviceType() { ID = 1, Name = "BF-0017", });
                cboDeviceType.Properties.Items.Add(new DeviceType() { ID = 2, Name = "BF-0825", });
            }
            else
            {
                cboDeviceType.Properties.Items.Clear();

                cboDeviceType.Properties.Items.Add(new DeviceType() { ID = 0, Name = "电镀设备-纽堡", });
                cboDeviceType.Properties.Items.Add(new DeviceType() { ID = 1, Name = "脱氢炉设备-纽堡", });
                cboDeviceType.Properties.Items.Add(new DeviceType() { ID = 2, Name = "脱氢炉设备-耐美特", });
            }

            edtBrokeURI.Text = SystemParams.Instance.ActiveMQ_URI;
            edtQueueName.Text = SystemParams.Instance.ActiveMQ_QueueName;
            edtUpgradeURL.Text = SystemParams.Instance.UpgradeURL;
            chkWriteLog.Checked = SystemParams.Instance.WriteLog;
            edtT133Code.Text = SystemParams.Instance.DeviceCode;
            edtDBFileName.Text = SystemParams.Instance.DataFileName;
            edtDeltaTimeSpan.Text = SystemParams.Instance.DeltaTimeSpan.ToString();
            cboDeviceType.SelectedIndex = SystemParams.Instance.DeviceType;
            edtLastCheckPoint.Value = SystemParams.Instance.BeginDT;
            edtT216Code.Text = SystemParams.Instance.T216Code;
        }

        private void edtBrokeURI_Validated(object sender, EventArgs e)
        {
            SystemParams.Instance.ActiveMQ_URI = edtBrokeURI.Text;
        }

        private void edtQueueName_Validated(object sender, EventArgs e)
        {
            SystemParams.Instance.ActiveMQ_QueueName = edtQueueName.Text;
        }

        private void edtUpgradeURL_Validated(object sender, EventArgs e)
        {
            SystemParams.Instance.UpgradeURL = edtUpgradeURL.Text;
        }

        private void chkWriteLog_CheckedChanged(object sender, EventArgs e)
        {
            WriteLog.Instance.IsWriteLog = chkWriteLog.Checked;
            SystemParams.Instance.WriteLog = chkWriteLog.Checked;
        }

        private void edtT133Code_Validated(object sender, EventArgs e)
        {
            SystemParams.Instance.DeviceCode = edtT133Code.Text;
        }

        private void edtDBFileName_Validated(object sender, EventArgs e)
        {
            SystemParams.Instance.DataFileName = edtDBFileName.Text;
        }

        private void edtDBFileName_Validating(object sender, CancelEventArgs e)
        {
            if (edtDBFileName.Text != "")
            {
                if (File.Exists(edtDBFileName.Text))
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (edtDBFileName.Text != "")
                openFileDialog.InitialDirectory = Path.GetFullPath(edtDBFileName.Text);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                edtDBFileName.Text = openFileDialog.FileName;
                SystemParams.Instance.DataFileName = openFileDialog.FileName;
            }
        }

        private void edtDeltaTimeSpan_Validated(object sender, EventArgs e)
        {
            SystemParams.Instance.DeltaTimeSpan = int.Parse(edtDeltaTimeSpan.Text);
        }

        private void cboDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SystemParams.Instance.DeviceType = ((DeviceType)cboDeviceType.SelectedItem).ID;
        }

        private void edtLastCheckPoint_ValueChanged(object sender, EventArgs e)
        {
            SystemParams.Instance.BeginDT = edtLastCheckPoint.Value;
        }
    }

    public class DeviceType
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
