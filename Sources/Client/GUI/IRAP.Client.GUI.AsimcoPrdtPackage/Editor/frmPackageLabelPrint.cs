using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Printing;
using System.Configuration;

using FastReport;
using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entities.Asimco;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.AsimcoPrdtPackage.Editor
{
    public partial class frmPackageLabelPrint : frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private WaitPackageSO mo = null;

        private bool isProgramChanged = false;

        public frmPackageLabelPrint()
        {
            InitializeComponent();

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
                btnLabelPrint.Enabled = false;
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "当前电脑没有安装打印机，无法打印标签");
            }
        }

        public frmPackageLabelPrint(
            WaitPackageSO mo,
            List<PackageLine> lines) : this()
        {
            this.mo = mo;

            foreach (PackageLine line in lines)
            {
                cboPackageLines.Properties.Items.Add(line);
            }
        }

        /// <summary>
        /// 根据订单号和行号获取客户
        /// </summary>
        /// <param name="moNumber"></param>
        /// <param name="moLineNo"></param>
        /// <returns></returns>
        private List<PackageClient> GetCustomersFromPrdt(
            string moNumber, int moLineNo)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<PackageClient> datas = new List<PackageClient>();

                AsimcoPackageClient.Instance.ufn_GetList_PackageClient(
                    IRAPUser.Instance.CommunityID,
                    moNumber,
                    moLineNo,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode != 0)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText);
                }

                return datas;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据打印交易号，打印标签
        /// </summary>
        /// <param name="transactNo"></param>
        private void PrintLabel(long transactNo)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            int errCode = 0;
            string errText = "";
            List<Carton> cartons = new List<Carton>();

            AsimcoPackageClient.Instance.ufn_GetList_Carton(
                IRAPUser.Instance.CommunityID,
                transactNo,
                IRAPUser.Instance.SysLogID,
                ref cartons,
                out errCode,
                out errText);
            WriteLog.Instance.Write(
                $"({errCode}]{errText}",
                strProcedureName);
            if (errCode != 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"获取标签打印信息时发生错误，请发起重打申请！");
                XtraMessageBox.Show(
                    $"错误信息：{errText}",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (cartons.Count == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"未获取到打印交易号 [{transactNo}] 的外包装标签数据，" +
                    "请联系系统开发人员，并发起重打申请！");
                return;
            }

            int t117LeafID = 0;
            string labelTemplate = "";

            foreach (Carton carton in cartons)
            {
                if (t117LeafID != carton.T117LeafID)
                {
                    #region 根据 T117LeafID 获取标签打印模板
                    TemplateContent template = new TemplateContent();
                    IRAPMDMClient.Instance.ufn_GetInfo_TemplateFMTStr(
                        IRAPUser.Instance.CommunityID,
                        carton.T117LeafID,
                        IRAPUser.Instance.SysLogID,
                        ref template,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        $"({errCode}){errText}",
                        strProcedureName);
                    if (errCode != 0 || template.TemplateFMTStr.Trim() == "")
                    {
                        IRAPMessageBox.Instance.ShowErrorMessage(
                            $"无法获取到 [T117LeafID={carton.T117LeafID}] 的模板");
                        labelTemplate = "";
                        return;
                    }
                    else
                    {
                        t117LeafID = carton.T117LeafID;
                        labelTemplate = template.TemplateFMTStr;
                    }
                    #endregion
                }

                if (labelTemplate != "")
                {
                    PrintCartonLabel(carton, labelTemplate);
                }
            }

            IRAPMessageBox.Instance.ShowInformation("标签打印完成。");
        }

        private void PrintCartonLabel(Carton cartonInfo, string labelTemplate)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

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
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"外包装标签打印模板装载失败：{error.Message}，\n" +
                    "请联系系统开发人员，并发起重打申请！");
                return;
            }

            #region 打印外包装标签
            PrinterSettings prntSettings = new PrinterSettings();
            prntSettings.Copies = Convert.ToInt16(mo.PrintedQty);
            prntSettings.PrinterName = (string)cboPrinters.SelectedItem;

            rpt.Parameters.FindByName("Model").Value = cartonInfo.Model;
            rpt.Parameters.FindByName("DrawingID").Value = cartonInfo.DrawingID;
            rpt.Parameters.FindByName("MaterialCategory").Value = cartonInfo.MaterialCategory;
            rpt.Parameters.FindByName("CartonQty").Value = cartonInfo.CartonQty;
            rpt.Parameters.FindByName("CartonProductNo").Value = cartonInfo.CartonProductNo;
            rpt.Parameters.FindByName("LotNumber").Value = cartonInfo.LotNumber;
            rpt.Parameters.FindByName("SupplyCode").Value = cartonInfo.SupplyCode;
            rpt.Parameters.FindByName("T134AlternateCode").Value = cartonInfo.T134AlternateCode;
            rpt.Parameters.FindByName("BarCode").Value =
                $"{cartonInfo.CartonProductNo}+" +
                $"{cartonInfo.LotNumber}+" +
                $"{cartonInfo.CartonQty.ToString()}";

            if (rpt.Prepare())
            {
                rpt.PrintPrepared(prntSettings);
            }
            #endregion

            #region 获取内包装标签列表
            int errCode = 0;
            string errText = "";
            List<BoxOfCarton> boxes = new List<BoxOfCarton>();
            AsimcoPackageClient.Instance.ufn_GetList_BoxOfCarton(
                IRAPUser.Instance.CommunityID,
                cartonInfo.CartonNumber,
                IRAPUser.Instance.SysLogID,
                ref boxes,
                out errCode,
                out errText);
            WriteLog.Instance.Write(
                $"({errCode}){errText}",
                strProcedureName);
            if (errCode != 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"获取标签打印信息时发生错误，请发起重打申请！");
                XtraMessageBox.Show(
                    $"错误信息：{errText}",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (boxes.Count == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"未获取到外包装号 [{cartonInfo.CartonNumber}] 的内包装标签数据，" +
                    "请联系系统开发人员，并发起重打申请！");
                return;
            }
            #endregion

            #region 打印内标签
            int t117LeafID = 0;
            string boxLabelTemplate = "";

            foreach (BoxOfCarton box in boxes)
            {
                if (t117LeafID != box.T117LeafID)
                {
                    #region 根据 T117LeafID 获取标签打印模板
                    TemplateContent template = new TemplateContent();
                    IRAPMDMClient.Instance.ufn_GetInfo_TemplateFMTStr(
                        IRAPUser.Instance.CommunityID,
                        box.T117LeafID,
                        IRAPUser.Instance.SysLogID,
                        ref template,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        $"({errCode}){errText}",
                        strProcedureName);
                    if (errCode != 0 || template.TemplateFMTStr.Trim() == "")
                    {
                        IRAPMessageBox.Instance.ShowErrorMessage(
                            $"无法获取到 [T117LeafID={box.T117LeafID}] 的模板");
                        boxLabelTemplate = "";
                    }
                    else
                    {
                        t117LeafID = box.T117LeafID;
                        boxLabelTemplate = template.TemplateFMTStr;
                    }
                    #endregion
                }

                if (boxLabelTemplate != "")
                {
                    PrintBoxLabel(box, boxLabelTemplate);
                }
            }
            #endregion
        }

        private void PrintBoxLabel(BoxOfCarton box, string labelTemplate)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            Report rpt = new Report();
            try
            {
                rpt.LoadFromString(labelTemplate);
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

            #region 打印内包装标签
            PrinterSettings prntSettings = new PrinterSettings();
            prntSettings.Copies = Convert.ToInt16(box.PrintQty);
            prntSettings.PrinterName = (string)cboPrinters.SelectedItem;

            rpt.Parameters.FindByName("Model").Value = box.Model;
            rpt.Parameters.FindByName("DrawingID").Value = box.DrawingID;
            rpt.Parameters.FindByName("MaterialCategory").Value = box.MaterialCategory;
            rpt.Parameters.FindByName("BoxQty").Value = box.MaterialQty;
            rpt.Parameters.FindByName("MaterialCode").Value = box.BoxMaterialNo;
            rpt.Parameters.FindByName("LotNumber").Value = box.LotNumber;
            rpt.Parameters.FindByName("CylinderID").Value = box.CylinderID;
            rpt.Parameters.FindByName("SupplyCode").Value = box.SupplyCode;
            rpt.Parameters.FindByName("T134AlternateCode").Value = box.T134AlternateCode;
            rpt.Parameters.FindByName("BarCode").Value = box.CylinderID;

            if (rpt.Prepare())
            {
                rpt.PrintPrepared(prntSettings);
            }
            #endregion
        }

        private void frmPackageLabelPrint_Shown(object sender, EventArgs e)
        {
            if (mo != null)
            {
                #region 获取当前订单可配送的客户清单
                List<PackageClient> customers =
                    GetCustomersFromPrdt(
                        mo.MONumber,
                        mo.MOLineNo);

                int idx = -1;
                isProgramChanged = true;
                try
                {
                    for (int i = 0; i < customers.Count; i++)
                    {
                        if (customers[i].T105Code == mo.CustomerCode)
                        {
                            idx = i;
                        }
                        cboCustomers.Properties.Items.Add(customers[i]);
                    }
                }
                finally
                {
                    isProgramChanged = false;
                }

                cboCustomers.SelectedIndex = idx;
                cboCustomers.Enabled = idx < 0;
                #endregion
            }
        }

        private void cboCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            PackageClient customer = cboCustomers.SelectedItem as PackageClient;
            if (customer != null)
            {
                edtCartonNumber.Value = customer.NumberOfCarton;
                edtBoxNumber.Value = customer.NumberOfBox;
            }
        }

        private void edtCartonNumber_Validating(object sender, CancelEventArgs e)
        {
            if (!isProgramChanged)
            {
                int t105LeafID = 0;
                long maxNumberOfCarton = 0;
                if (cboCustomers.SelectedItem == null)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        "未选择客户");
                    return;
                }
                else
                {
                    t105LeafID =
                        (cboCustomers.SelectedItem as PackageClient).T105LeafID;
                    maxNumberOfCarton =
                        (cboCustomers.SelectedItem as PackageClient).NumberOfCarton;
                }

                if (edtCartonNumber.Value > maxNumberOfCarton)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        $"外箱数量不能大于 [{maxNumberOfCarton}] ！");
                    edtCartonNumber.Value = 0;
                    e.Cancel = true;
                    return;
                }

                string strProcedureName =
                    $"{className}.{MethodBase.GetCurrentMethod().Name}";

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";
                    int cartonNumber = Convert.ToInt32(edtCartonNumber.Value);
                    int boxNumber = 0;

                    AsimcoPackageClient.Instance.usp_PokaYoke_Package(
                        IRAPUser.Instance.CommunityID,
                        mo.MONumber,
                        mo.MOLineNo,
                        t105LeafID,
                        cartonNumber,
                        IRAPUser.Instance.SysLogID,
                        out boxNumber,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        $"({errCode}){errText}",
                        strProcedureName);
                    if (errCode == 0)
                    {
                        edtBoxNumber.Value = boxNumber;
                    }
                    else
                    {
                        IRAPMessageBox.Instance.ShowErrorMessage(errText);
                        cboCustomers_SelectedIndexChanged(cboCustomers, null);
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void btnLabelPrint_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            long numberOfCarton = 0;
            if (cboCustomers.SelectedItem == null)
            {
                IRAPMessageBox.Instance.ShowErrorMessage("请选择客户！");
                cboCustomers.Focus();
                return;
            }
            else
            {
                PackageClient customer = cboCustomers.SelectedItem as PackageClient;
                numberOfCarton = customer.NumberOfCarton;
            }
            if (cboPackageLines.SelectedItem == null)
            {
                IRAPMessageBox.Instance.ShowErrorMessage("请选择包装线！");
                cboPackageLines.Focus();
                return;
            }
            if (edtCartonNumber.Value <= 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage("外箱数量不能小于等于零！");
                edtCartonNumber.Focus();
                return;
            }
            if (Convert.ToInt64(edtCartonNumber.Value) > numberOfCarton)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"外箱数量不能大于 [{numberOfCarton}]");
                edtCartonNumber.Value = numberOfCarton;
                edtCartonNumber.Focus();
                return;
            }
            if (cboPrinters.SelectedItem == null)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "请选择一台打印机！");
                cboPrinters.Focus();
                return;
            }

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                long transactNo = 0;

                long numberOfBox = Convert.ToInt64(edtBoxNumber.Value);
                long cartonNumber = Convert.ToInt64(edtCartonNumber.Value);
                PackageClient customer = cboCustomers.SelectedItem as PackageClient;
                PackageLine line = cboPackageLines.SelectedItem as PackageLine;

                AsimcoPackageClient.Instance.usp_SaveFact_PackagePrint(
                    IRAPUser.Instance.CommunityID,
                    mo.MONumber,
                    mo.MOLineNo,
                    0,
                    cartonNumber,
                    customer.T105LeafID,
                    line.T134LeafID,
                    numberOfBox,
                    IRAPUser.Instance.SysLogID,
                    ref transactNo,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    $"({errCode}){errText}",
                    strProcedureName);
                if (errCode == 0)
                {
                    WriteLog.Instance.Write($"得到打印交易号 [{transactNo}]。", strProcedureName);
                    PrintLabel(transactNo);

                    btnCancel.PerformClick();
                }
                else
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText);
                }
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
