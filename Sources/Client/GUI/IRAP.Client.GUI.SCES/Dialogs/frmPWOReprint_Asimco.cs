using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Configuration;

using DevExpress.XtraEditors;
using FastReport;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.SCES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.SCES.Dialogs
{
    public partial class frmPWOReprint_Asimco : IRAP.Client.Global.frmCustomBase
    {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int t173LeafID = 0;

        public frmPWOReprint_Asimco()
        {
            InitializeComponent();
        }

        public frmPWOReprint_Asimco(int t173LeafID) : this()
        {
            this.t173LeafID = t173LeafID;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (edtMONumber.Text.Trim() == "")
            {
                XtraMessageBox.Show("请输入制造订单号！");
                edtMONumber.Focus();
                return;
            }
            if (edtMOLineNo.Text.Trim() == "")
            {
                XtraMessageBox.Show("请输入制造订单行号！");
                edtMOLineNo.Focus();
                return;
            }

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                ReprintPWO pwoInfo = new ReprintPWO();
                int errCode = 0;
                string errText = "";

                IRAPSCESClient.Instance.mfn_GetInfo_PWOToReprint(
                    IRAPUser.Instance.CommunityID,
                    t173LeafID,
                    edtMONumber.Text.Trim(),
                    Tools.ConvertToInt32(edtMOLineNo.Text.Trim()),
                    IRAPUser.Instance.SysLogID,
                    ref pwoInfo,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    #region 打印
                    Report report = new Report();
                    Report report1 = new Report();
                    bool printWIPProductInfoTrack = false;

                    MemoryStream ms;
                    switch (IRAPUser.Instance.CommunityID)
                    {
                        case 60023:
                            ms = new MemoryStream(Properties.Resources.WIPTransferTrackSheet_60023);
                            break;
                        default:
                            ms = new MemoryStream(Properties.Resources.WIPTransferTrackSheet);
                            if (ConfigurationManager.AppSettings["PrintProductInfoTrack"] != null)
                                printWIPProductInfoTrack =
                                    ConfigurationManager.AppSettings["PrintProductInfoTrack"].ToUpper() == "TRUE";
                            break;
                    }
                    report.Load(ms);

                    if (printWIPProductInfoTrack && IRAPUser.Instance.CommunityID == 60010)
                    {
                        ms = new MemoryStream(Properties.Resources.WIPProductInfoTrack);
                        report1.Load(ms);
                    }

                    try
                    {
                        switch (IRAPUser.Instance.CommunityID)
                        {
                            case 60010:    // 仪征打印的生产流转卡
                                report.Parameters.FindByName("BarCode").Value = pwoInfo.PWONo;
                                report.Parameters.FindByName("DeliveryWorkshop").Value = "";
                                report.Parameters.FindByName("StorehouseCode").Value =
                                    string.Format(
                                        "{0}({1})",
                                        pwoInfo.T173Name,
                                        pwoInfo.T173Code);
                                report.Parameters.FindByName("T106Code").Value = pwoInfo.AtStoreLocCode;
                                report.Parameters.FindByName("WorkshopName").Value =
                                    string.Format(
                                        "{0}({1})",
                                        pwoInfo.DstWorkShopDesc,
                                        pwoInfo.DstWorkShopCode);
                                report.Parameters.FindByName("ProductLine").Value = pwoInfo.T134Name;
                                report.Parameters.FindByName("AdvicedPickedQty").Value = pwoInfo.SuggestedQuantityToPick;
                                report.Parameters.FindByName("StartingDate").Value = pwoInfo.PlannedStartDate;
                                report.Parameters.FindByName("CompletingDate").Value = pwoInfo.PlannedCloseDate;
                                report.Parameters.FindByName("PrintingDate").Value = DateTime.Now.ToString("yyyy-MM-dd");
                                report.Parameters.FindByName("Unit").Value = pwoInfo.UnitOfMeasure;
                                report.Parameters.FindByName("MONo").Value = pwoInfo.MONumber;
                                report.Parameters.FindByName("LineNo").Value = pwoInfo.MOLineNo;
                                report.Parameters.FindByName("LotNumber").Value = pwoInfo.LotNumber;
                                report.Parameters.FindByName("MaterialTexture").Value = pwoInfo.T131Code;
                                report.Parameters.FindByName("ActualPickedBars").Value = pwoInfo.ActualQtyDecompose;
                                report.Parameters.FindByName("OrderQty").Value = pwoInfo.PlannedQuantity;
                                report.Parameters.FindByName("MaterialCode").Value = pwoInfo.MaterialCode;
                                report.Parameters.FindByName("MaterialDescription").Value = pwoInfo.MaterialDesc;
                                report.Parameters.FindByName("TransferringInDate").Value = DateTime.Now.ToString("yyyy-MM-dd");
                                report.Parameters.FindByName("InQuantity").Value = pwoInfo.ActualQuantityToDeliver;
                                report.Parameters.FindByName("FatherMaterialCode").Value = pwoInfo.ProductNo;
                                report.Parameters.FindByName("FatherMaterialName").Value = pwoInfo.ProductDesc;
                                report.Parameters.FindByName("DstT106Code").Value = pwoInfo.DstT106Code;
                                break;
                        }

                        if (printWIPProductInfoTrack && IRAPUser.Instance.CommunityID == 60010)
                        {
                            report1.Parameters.FindByName("BarCode").Value = pwoInfo.PWONo;
                            report1.Parameters.FindByName("DeliveryWorkshop").Value = "";
                            report1.Parameters.FindByName("StorehouseCode").Value =
                                string.Format(
                                    "{0}({1})",
                                    pwoInfo.T173Name,
                                    pwoInfo.T173Code);
                            report1.Parameters.FindByName("T106Code").Value = pwoInfo.AtStoreLocCode;
                            report1.Parameters.FindByName("WorkshopName").Value = pwoInfo.DstWorkShopCode;
                            report1.Parameters.FindByName("ProductLine").Value = pwoInfo.T134Name;
                            report1.Parameters.FindByName("AdvicedPickedQty").Value = pwoInfo.SuggestedQuantityToPick;
                            report1.Parameters.FindByName("StartingDate").Value = pwoInfo.PlannedStartDate.Substring(5, 5);
                            report1.Parameters.FindByName("CompletingDate").Value = pwoInfo.PlannedCloseDate.Substring(5, 5);
                            report1.Parameters.FindByName("PrintingDate").Value = DateTime.Now.ToString("MM-dd HH:mm:ss");
                            report1.Parameters.FindByName("Unit").Value = pwoInfo.UnitOfMeasure;
                            report1.Parameters.FindByName("MONo").Value = pwoInfo.MONumber;
                            report1.Parameters.FindByName("LineNo").Value = pwoInfo.MOLineNo;
                            report1.Parameters.FindByName("LotNumber").Value = pwoInfo.LotNumber;
                            report1.Parameters.FindByName("MaterialTexture").Value = pwoInfo.T131Code;
                            report1.Parameters.FindByName("ActualPickedBars").Value = pwoInfo.ActualQtyDecompose;
                            report1.Parameters.FindByName("OrderQty").Value = pwoInfo.PlannedQuantity;
                            report1.Parameters.FindByName("MaterialCode").Value = pwoInfo.MaterialCode;
                            report1.Parameters.FindByName("MaterialDescription").Value = pwoInfo.MaterialDesc;
                            report1.Parameters.FindByName("TransferringInDate").Value = DateTime.Now.ToString("yyyy-MM-dd");
                            report1.Parameters.FindByName("InQuantity").Value = pwoInfo.ActualQuantityToDeliver.ToString();
                            report1.Parameters.FindByName("FatherMaterialCode").Value = pwoInfo.ProductNo;
                            report1.Parameters.FindByName("FatherMaterialName").Value = pwoInfo.ProductDesc;
                            report1.Parameters.FindByName("DstT106Code").Value = pwoInfo.DstT106Code;
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        XtraMessageBox.Show(
                            error.Message,
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    System.Drawing.Printing.PrinterSettings prnSetting =
                        new System.Drawing.Printing.PrinterSettings();
                    if (report.Prepare())
                    {
                        bool rePrinter = false;
                        do
                        {
                            if (report.ShowPrintDialog(out prnSetting))
                            {
                                report.PrintPrepared(prnSetting);
                                rePrinter = (
                                    XtraMessageBox.Show(
                                        "物料配送流转卡已经打印完成，是否需要重新打印？",
                                        "系统信息",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2) == DialogResult.Yes);
                            }
                        } while (rePrinter);
                    }

                    if (IRAPUser.Instance.CommunityID == 60010 && printWIPProductInfoTrack)
                    {
                        IRAPMessageBox.Instance.ShowInformation(
                            "请将打印机中的打印纸更换为【产品信息跟踪卡】，更换完毕后点击确认开始打印");

                        if (report1.Prepare())
                        {
                            bool rePrint = false;
                            do
                            {
                                if (report1.ShowPrintDialog(out prnSetting))
                                {
                                    report1.PrintPrepared(prnSetting);
                                    rePrint =
                                        (
                                            XtraMessageBox.Show(
                                                "【产品信息跟踪卡】已经打印完成，是否需要重新打印？",
                                                "系统信息",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question,
                                                MessageBoxDefaultButton.Button2) == DialogResult.Yes
                                        );
                                }
                            } while (rePrint);
                        }
                    }
                    btnClose.PerformClick();
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(
                    error.Message,
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
