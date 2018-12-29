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
using IRAP.Client.Global;
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
                XtraMessageBox.Show(
                    "当前电脑中没有安装打印机，无法打印标签！",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPrintBoxLabel_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            if (edtBoxNumber.Text.Trim() == "")
            {
                XtraMessageBox.Show(
                    "请输入需要补打的内包装筒号",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    edtBoxNumber.Focus();
                    return;
                }

                if (items.Count == 0)
                {
                    edtBoxNumber.Text = "";
                    XtraMessageBox.Show(
                        $"没有找到筒号 [{edtBoxNumber.Text}] 的标签信息！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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
                    XtraMessageBox.Show(
                        $"无法获取到 [T117LeafID={items[0].T117LeafID}] 的模板",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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
                    XtraMessageBox.Show(
                        $"内包装标签打印模板装载失败：{error.Message}，\n" +
                        "请联系系统开发人员，并发起重打申请！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                PrinterSettings prntSettings = new PrinterSettings();
                prntSettings.PrinterName = (string)cboPrinters.SelectedItem;
                //prntSettings.Copies = Convert.ToInt16(items[0].PrintQty);

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

        private void rbByCartonNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rbByCartonNumber.Checked)
            {
                edtCartonNumber.Enabled = true;
                edtMONumber.Enabled = false;
                edtMOLineNo.Enabled = false;
                edtCartonNumber.Focus();
            }
            else
            {
                edtCartonNumber.Enabled = false;
                edtMONumber.Enabled = true;
                edtMOLineNo.Enabled = true;
                edtMONumber.Focus();
            }
        }

        private void btnPrintCartonLabel_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            string cartonNumber = "";
            string moNumber = "";
            int moLineNo = 0;

            if (rbByCartonNumber.Checked)
            {
                if (edtCartonNumber.Text.Trim() == "")
                {
                    XtraMessageBox.Show(
                        "请输入外包装标签号！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    edtCartonNumber.Focus();
                    return;
                }
                else
                {
                    cartonNumber = edtCartonNumber.Text.Trim();
                }
            }
            if (rbByMONumber.Checked)
            {
                if (edtMONumber.Text.Trim() == "")
                {
                    XtraMessageBox.Show(
                        "请输入订单号！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    edtMONumber.Focus();
                    return;
                }
                else
                {
                    moNumber = edtMONumber.Text.Trim();
                }

                int.TryParse(edtMOLineNo.Text.Trim(), out moLineNo);
                if (moLineNo <= 0)
                {
                    XtraMessageBox.Show(
                        "请输入正确的订单行号！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    edtMOLineNo.Focus();
                    return;
                }
            }

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<RePrintCartonNumber> items = new List<RePrintCartonNumber>();

                #region 获取外标签打印内容
                AsimcoPackageClient.Instance.usp_RePrintCartonNumber(
                    IRAPUser.Instance.CommunityID,
                    moNumber,
                    moLineNo,
                    cartonNumber,
                    IRAPUser.Instance.SysLogID,
                    ref items,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode != 0)
                {
                    edtCartonNumber.Text = "";
                    edtMONumber.Text = "";
                    edtMOLineNo.Text = "";
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    if (rbByCartonNumber.Checked)
                    {
                        edtCartonNumber.Focus();
                    }
                    else
                    {
                        edtMONumber.Focus();
                    }
                    return;
                }

                if (items.Count == 0)
                {
                    edtCartonNumber.Text = "";
                    edtMONumber.Text = "";
                    edtMOLineNo.Text = "";
                    XtraMessageBox.Show(
                        $"没有找到需要打印的外标签信息！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    if (rbByCartonNumber.Checked)
                    {
                        edtCartonNumber.Focus();
                    }
                    else
                    {
                        edtMONumber.Focus();
                    }
                    return;
                }
                #endregion

                #region 打印外标签
                int t117LeafID = 0;
                string labelTemplate = "";

                foreach (RePrintCartonNumber item in items)
                {
                    if (t117LeafID != item.T117LeafID)
                    {
                        #region 根据 T117LeafID 获取标签打印模板
                        TemplateContent template = new TemplateContent();
                        IRAPMDMClient.Instance.ufn_GetInfo_TemplateFMTStr(
                            IRAPUser.Instance.CommunityID,
                            item.T117LeafID,
                            IRAPUser.Instance.SysLogID,
                            ref template,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            $"({errCode}){errText}",
                            strProcedureName);
                        if (errCode != 0 || template.TemplateFMTStr.Trim() == "")
                        {
                            XtraMessageBox.Show(
                                $"无法获取到 [T117LeafID={item.T117LeafID}] 的模板",
                                "",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            labelTemplate = "";
                            return;
                        }
                        else
                        {
                            t117LeafID = item.T117LeafID;
                            labelTemplate = template.TemplateFMTStr;
                        }
                        #endregion
                    }

                    if (labelTemplate != "")
                    {
                        Report rpt = new Report();
                        try
                        {
                            rpt.LoadFromString(labelTemplate);
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(
                                $"外包装标签打印模板装载失败：{error.Message}，",
                                strProcedureName);
                            XtraMessageBox.Show(
                                $"外包装标签打印模板装载失败：{error.Message}，\n" +
                                "请联系系统开发人员！",
                                "",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        #region 打印外包装标签
                        PrinterSettings prntSettings = new PrinterSettings();
                        //prntSettings.Copies = Convert.ToInt16(item.PrintQty);
                        prntSettings.PrinterName = (string)cboPrinters.SelectedItem;

                        rpt.Parameters.FindByName("Model").Value = item.Model;
                        rpt.Parameters.FindByName("DrawingID").Value = item.DrawingID;
                        rpt.Parameters.FindByName("MaterialCategory").Value = item.MaterialCategory;
                        rpt.Parameters.FindByName("CartonQty").Value = item.CartonQty;
                        rpt.Parameters.FindByName("CartonProductNo").Value = item.CartonProductNo;
                        rpt.Parameters.FindByName("LotNumber").Value = item.LotNumber;
                        rpt.Parameters.FindByName("SupplyCode").Value = item.SupplyCode;
                        rpt.Parameters.FindByName("T134AlternateCode").Value = item.T134AlternateCode;
                        rpt.Parameters.FindByName("BarCode").Value =
                            $"{item.CartonProductNo}+" +
                            $"{item.CartonNumber}+" +
                            $"{item.CartonQty.ToString()}";

                        if (rpt.Prepare())
                        {
                            rpt.PrintPrepared(prntSettings);
                        }
                        #endregion
                    }
                }
                #endregion

                XtraMessageBox.Show(
                    "外标签打印完成。",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void cboPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            IRAPConst.Instance.SaveParams(
                "LabelPrinter",
                (string)cboPrinters.SelectedItem);
        }
    }
}
