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

namespace IRAPPrinterServer
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
            edtBrokeURI.Text = SystemParams.Instance.ActiveMQ_URI;
            edtQueueName.Text = SystemParams.Instance.ActiveMQ_QueueName;
            edtUpgradeURL.Text = SystemParams.Instance.UpgradeURL;
            chkWriteLog.Checked = SystemParams.Instance.WriteLog;
            edtFilterString.Text = SystemParams.Instance.FilterString;
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
            SystemParams.Instance.WriteLog = chkWriteLog.Checked;
        }

        private void edtT133Code_Validated(object sender, EventArgs e)
        {
            SystemParams.Instance.FilterString = edtFilterString.Text;
        }
    }
}
