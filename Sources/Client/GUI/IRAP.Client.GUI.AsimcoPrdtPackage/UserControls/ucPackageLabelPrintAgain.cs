using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Configuration;
using System.Reflection;

using FastReport;
using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.Asimco;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.AsimcoPrdtPackage.UserControls
{
    public partial class ucPackageLabelPrintAgain : XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ucPackageLabelPrintAgain()
        {
            InitializeComponent();
        }

        private void ucPackageLabelPrintAgain_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                cboPrinters.Properties.Items.Add(PrinterSettings.InstalledPrinters[i]);
            }

            PrintDocument prntDoc = new PrintDocument();
            string printerName = prntDoc.PrinterSettings.PrinterName;
            if (ConfigurationManager.AppSettings["LabelPrinter"] != null)
            {
                printerName = ConfigurationManager.AppSettings["LabelPrinter"];
            }

            if (cboPrinters.Properties.Items.Count > 0)
            {
                cboPrinters.SelectedIndex =
                    cboPrinters.Properties.Items.IndexOf(printerName);
            }
            else
            {
                btnPrintBoxLabel.Enabled = false;
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "当前电脑中没有安装打印机，无法打印标签！");
            }
        }

        private void btnPrintBoxLabel_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            if (edtBoxNumber.Text.Trim() == "")
            {
                IRAPMessageBox.Instance.ShowInformation(
                    "请输入需要补打的内包装筒号");
                edtBoxNumber.Focus();
                return;
            }

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<RePrintBoxNumber> items = new List<RePrintBoxNumber>();

                #region 获取内标签打印内容
                AsimcoPackageClient.Instance.usp_RePrintBoxNumber(
                    IRAPUser.Instance.CommunityID,
                    edtBoxNumber.Text.Trim(),
                    IRAPUser.Instance.SysLogID,
                    ref items,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode!= 0)
                {
                    edtBoxNumber.Text = "";
                    IRAPMessageBox.Instance.ShowErrorMessage(errText);
                    edtBoxNumber.Focus();
                    return;
                }

                if (items.Count == 0)
                {
                    edtBoxNumber.Text = "";
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        $"没有找到筒号 [{edtBoxNumber.Text}] 的标签信息！");
                    edtBoxNumber.Focus();
                    return;
                }
                #endregion

                #region 获取内标签打印模板
                TemplateContent template = new TemplateContent();
                IRAPMDMClient.Instance.ufn_GetInfo_TemplateFMTStr(
                    IRAPUser.Instance.CommunityID,
                    items[0].T117LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref template,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode != 0 || template.TemplateFMTStr.Trim() == "")
                {
                    edtBoxNumber.Text = "";
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        $"无法获取到 [T117LeafID={items[0].T117LeafID}] 的模板");
                    edtBoxNumber.Focus();
                    return;
                }
                #endregion

                #region 打印内标签
                Report rpt = new Report();
                try
                {
                    rpt.LoadFromString(template.TemplateFMTStr.Trim());
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(
                        $"内包装标签打印模板装载失败：{error.Message}，",
                        strProcedureName);
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        $"内包装标签打印模板装载失败：{error.Message}，\n" +
                        "请联系系统开发人员，并发起重打申请！");
                    return;
                }

                PrinterSettings prntSettings = new PrinterSettings();
                prntSettings.Copies = Convert.ToInt16(items[0].PrintQty);
                prntSettings.PrinterName = (string)cboPrinters.SelectedItem;

                rpt.Parameters.FindByName("Model").Value = items[0].Model;
                rpt.Parameters.FindByName("DrawingID").Value = items[0].DrawingID;
                rpt.Parameters.FindByName("MaterialCategory").Value = items[0].MaterialCategory;
                rpt.Parameters.FindByName("BoxQty").Value = items[0].MaterialQty;
                rpt.Parameters.FindByName("MaterialCode").Value = items[0].BoxMaterialNo;
                rpt.Parameters.FindByName("LotNumber").Value = items[0].LotNumber;
                rpt.Parameters.FindByName("CylinderID").Value = items[0].CylinderID;
                rpt.Parameters.FindByName("SupplyCode").Value = items[0].SupplyCode;
                rpt.Parameters.FindByName("T134AlternateCode").Value = items[0].T134AlternateCode;
                rpt.Parameters.FindByName("BarCode").Value = items[0].CylinderID;

                if (rpt.Prepare())
                {
                    rpt.PrintPrepared(prntSettings);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
