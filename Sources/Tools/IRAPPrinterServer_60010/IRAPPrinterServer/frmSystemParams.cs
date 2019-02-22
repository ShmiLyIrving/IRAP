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
using System.Drawing.Printing;

namespace IRAPPrinterServer
{
    public partial class frmSystemParams : Form
    {
        public frmSystemParams()
        {
            InitializeComponent();
        }

        private void FullGenPDFAndPrintParams()
        {
            cboPrinter.Items.Clear();
            foreach (string prtName in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(prtName);
            }
            string param_PrinterName = SystemParams.Instance.PrinterName;
            if (!string.IsNullOrEmpty(param_PrinterName))
            {
                int index = cboPrinter.Items.IndexOf(param_PrinterName);
                if (index >= 0)
                {
                    cboPrinter.SelectedIndex = index;
                }
            }

            string param_PDFPrinter = SystemParams.Instance.PDFPrinter;
            lblPDFPrinterStatus.Text =
                $"[{param_PDFPrinter}]打印机未安装，某些打印功能无法使用";
            lblPDFPrinterStatus.ForeColor = Color.Red;
            SystemParams.Instance.CanPrintToPDF = false;
            foreach (string prtName in PrinterSettings.InstalledPrinters)
            {
                if (prtName == param_PDFPrinter)
                {
                    lblPDFPrinterStatus.Text =
                        $"[{param_PDFPrinter}]已安装";
                    lblPDFPrinterStatus.ForeColor = Color.Black;
                    SystemParams.Instance.CanPrintToPDF = true;
                    break;
                }
            }
        }

        private void ClearGenPDFAndPrintParams()
        {
            lblPDFPrinterStatus.Text = "";
            cboPrinter.Items.Clear();
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

            chkGenPDFtoPrint.Checked = SystemParams.Instance.GenPDFAndPrintMode;

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

        private void chkGenPDFtoPrint_CheckedChanged(object sender, EventArgs e)
        {
            SystemParams.Instance.GenPDFAndPrintMode = chkGenPDFtoPrint.Checked;
            if (chkGenPDFtoPrint.Checked)
            {
                cboPrinter.Enabled = true;

                FullGenPDFAndPrintParams();
            }
            else
            {
                cboPrinter.Enabled = false;

                ClearGenPDFAndPrintParams();
            }
        }

        private void cboPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboPrinter.SelectedIndex;
            if (index >=0&& index < cboPrinter.Items.Count)
            {
                SystemParams.Instance.PrinterName =
                    cboPrinter.Items[index].ToString();
            }
        }
    }
}
