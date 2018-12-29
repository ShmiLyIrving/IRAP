using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Printing;
using System.Configuration;

using FastReport;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors.ButtonsPanelControl;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.Entities.Asimco;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.AsimcoPrdtPackage.UserControls
{
    public partial class ucPackabeLabelReprint : XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ucPackabeLabelReprint()
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
                btnPrint.Enabled = false;
                XtraMessageBox.Show(
                    "当前电脑中没有安装打印机，无法打印标签！",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 获取当前待确认的包装标签清单
        /// </summary>
        /// <returns></returns>
        private List<WaitRePrintCarton> GetConfirmLabels()
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("获取待重打的外包装标签清单");
            try
            {
                int errCode = 0;
                string errText = "";
                List<WaitRePrintCarton> datas = new List<WaitRePrintCarton>();

                AsimcoPackageClient.Instance.ufn_GetList_WaitRePrintCarton(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode == 0)
                {
                    return datas;
                }
                else
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return new List<WaitRePrintCarton>();
                }
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void RefreshPackageLabels()
        {
            grdPackageLabels.DataSource = GetConfirmLabels();
            grdvPackageLabels.BestFitColumns();
        }

        /// <summary>
        /// 打印标签
        /// </summary>
        /// <param name="cartonInfo"></param>
        private void PrintLabel(WaitRePrintCarton cartonInfo)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            int errCode = 0;
            string errText = "";

            #region 根据 T117LeafID 获取标签打印模板
            TemplateContent template = new TemplateContent();
            IRAPMDMClient.Instance.ufn_GetInfo_TemplateFMTStr(
                IRAPUser.Instance.CommunityID,
                cartonInfo.T117LeafID,
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
                    $"无法获取到 [T117LeafID={cartonInfo.T117LeafID}] 的模板",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else
            {
                PrintCartonLabel(cartonInfo, template.TemplateFMTStr);
            }
            #endregion
        }

        private void PrintCartonLabel(WaitRePrintCarton cartonInfo, string labelTemplate)
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
                XtraMessageBox.Show(
                    $"外包装标签打印模板装载失败：{error.Message}，\n" +
                    "请联系系统开发人员，并发起重打申请！",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            #region 打印外包装标签
            PrinterSettings prntSettings = new PrinterSettings();
            //prntSettings.Copies = Convert.ToInt16(cartonInfo.PrintQty);
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
                $"{cartonInfo.CartonNumber}+" +
                $"{cartonInfo.CartonQty.ToString()}";

            if (rpt.Prepare())
            {
                for (int i = 0; i < cartonInfo.PrintQty; i++)
                {
                    rpt.PrintPrepared(prntSettings);
                }
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
                XtraMessageBox.Show(
                    $"获取标签打印信息时发生错误，请发起重打申请！",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                XtraMessageBox.Show(
                    $"错误信息：{errText}",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (boxes.Count == 0)
            {
                XtraMessageBox.Show(
                    $"未获取到外包装号 [{cartonInfo.CartonNumber}] 的内包装标签数据，" +
                    "请联系系统开发人员，并发起重打申请！",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 打印内标签
            foreach (BoxOfCarton box in boxes)
            {
                int t117LeafID = 0;
                string boxLabelTemplate = "";

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
                        XtraMessageBox.Show(
                            $"无法获取到 [T117LeafID={box.T117LeafID}] 的模板",
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
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
                XtraMessageBox.Show(
                    $"内包装标签打印模板装载失败：{error.Message}，\n" +
                    "请联系系统开发人员，并发起重打申请！",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            #region 打印内包装标签
            PrinterSettings prntSettings = new PrinterSettings();
            //prntSettings.Copies = Convert.ToInt16(box.PrintQty);
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
                for (int i = 0; i < box.PrintQty; i++)
                {
                    rpt.PrintPrepared(prntSettings);
                }
            }
            #endregion
        }

        private void ucPackabeLabelReprint_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                RefreshPackageLabels();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int idx = grdvPackageLabels.GetFocusedDataSourceRowIndex();
            List<WaitRePrintCarton> items =
                grdPackageLabels.DataSource as List<WaitRePrintCarton>;

            if (items == null)
            {
                XtraMessageBox.Show(
                    "没有需要重打的包装标签！",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (idx < 0)
            {
                XtraMessageBox.Show(
                    "请选择需要重打的包装标签！",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                AsimcoPackageClient.Instance.usp_SaveFact_PrintStatus(
                    IRAPUser.Instance.CommunityID,
                    items[idx].FactID,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode == 0)
                {
                    PrintLabel(items[idx]);

                    XtraMessageBox.Show(
                        "标签打印完成。",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                RefreshPackageLabels();
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

        private void gpcPackageSOs_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            GroupBoxButton button = e.Button as GroupBoxButton;
            switch (button.Caption)
            {
                case "刷新":
                    RefreshPackageLabels();

                    break;
                default:
                    break;
            }
        }
    }
}
