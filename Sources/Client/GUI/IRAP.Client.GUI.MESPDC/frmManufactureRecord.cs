using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;
using IRAP.Entity.Kanban;
using IRAP.Entity.MES;
using IRAP.Entity.SSO;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmManufactureRecord : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private static string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private List<StationPortInfo> ports = new List<StationPortInfo>();
        private List<ScannerForSerialPort> scanners = new List<ScannerForSerialPort>();
        private List<ManufactureRecordLog> logs = new List<ManufactureRecordLog>();
        private List<ScannerView> scannerViews = new List<ScannerView>();

        public frmManufactureRecord()
        {
            InitializeComponent();

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            #region 从数据库中获取当前站点配置的串口扫描枪的信息列表
            {

                int errCode = 0;
                string errText = "";

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    IRAPKBClient.Instance.ufn_GetKanban_Station_Ports(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.SysLogID,
                        0,
                        ref ports,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
            #endregion

            #region 根据上面获取到的串口扫描枪信息列表，创建串口扫描枪读取对象列表，并开始侦听
            {
                try
                {
                    foreach (StationPortInfo port in ports)
                    {
                        if (port.IsComm)
                        {
                            ScannerForSerialPort scanner = new ScannerForSerialPort(lstBarCodes, port);
                            scanners.Add(scanner);

                            scannerViews.Add(
                                new ScannerView()
                                {
                                    PortName = port.CommPort,
                                    WorkUnitCode = port.WorkUnitCode,
                                    WorkUnitName = port.WorkUnitName,
                                });
                        }
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
            }
            #endregion

            grdSerialPortScanners.DataSource = scannerViews;
            grdBarCodeLogs.DataSource = logs;

            grdvSerialPortScanners.BestFitColumns();
            grdvBarCodeLogs.BestFitColumns();

            timer.Enabled = true;
        }

        private void frmManufactureRecord_Activated(object sender, EventArgs e)
        {
            Options.Visible = true;

            if (Options.SelectStation != null)
            {
                edtContainerNo1.Text = Options.SelectStation.T107G02;
                edtContainerNo2.Text = Options.SelectStation.T107G03;
            }
        }

        private void frmManufactureRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = scanners.Count - 1; i >= 0; i--)
            {
                scanners[i].Close();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            timer.Enabled = false;
            try
            {
                string barCode = "";

                // 从条码池中获取一条待处理的在产品条码
                lstBarCodes.Invoke(
                    new EventHandler(
                        delegate
                            {
                                if (lstBarCodes.Items.Count > 0)
                                {
                                    object item = lstBarCodes.Items[0];
                                    barCode = lstBarCodes.Items[0].ToString();
                                    lstBarCodes.Items.Remove(item);
                                }
                            }));

                string[] splitString = barCode.Split('|');
                if (splitString.Length <= 1)
                {
                    return;
                }

                foreach (ScannerView view in scannerViews)
                {
                    if (view.PortName == splitString[0])
                    {
                        view.BarCode = splitString[1];
                        grdvSerialPortScanners.BestFitColumns();

                        if (Options.SelectStation == null ||
                            Options.SelectProduct == null)
                        {
                            WriteToScreenLog(
                                view.BarCode,
                                "",
                                "",
                                -1,
                                "当前站点没有配置产品流程和或工位");
                            return;
                        }

                        WriteLog.Instance.WriteBeginSplitter(strProcedureName);

                        try
                        {
                            int errCode = 0;
                            string errText = "";
                            WIPBarCodeInfo barcodeInfo = new WIPBarCodeInfo();

                            #region 获取条码信息
                            IRAPMESClient.Instance.ufn_GetInfo_WIPBarcode(
                                IRAPUser.Instance.CommunityID,
                                view.BarCode,
                                Options.SelectProduct.T120LeafID,
                                Options.SelectStation.T107LeafID,
                                ref barcodeInfo,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(
                                string.Format("({0}){1}", errCode, errText),
                                strProcedureName);
                            if (errCode != 0)
                            {
                                WriteToScreenLog(
                                    view.BarCode,
                                    "",
                                    "",
                                    errCode,
                                    errText);
                                return;
                            }
                            #endregion

                            #region 根据条码信息中的条码状态和路由状态，进行生产记载
                            switch (barcodeInfo.BarcodeStatus)
                            {
                                case 0:
                                    switch (barcodeInfo.RoutingStatus)
                                    {
                                        case 1:
                                            break;
                                        default:
                                            WriteToScreenLog(
                                                view.BarCode,
                                                "",
                                                "",
                                                barcodeInfo.RoutingStatus,
                                                barcodeInfo.RoutingStatusStr);
                                            return;
                                    }
                                    break;
                                case 1:
                                    switch (barcodeInfo.RoutingStatus)
                                    {
                                        case 1:
                                            // 自动切换工艺流程
                                            ProductViaStation product =
                                                AvailableProducts.Instance.GetProductWithLeafID(barcodeInfo.ProcessLeaf);
                                            if (product == null)
                                            {
                                                WriteToScreenLog(
                                                    view.BarCode,
                                                    "",
                                                    barcodeInfo.SerialNumber,
                                                    -1,
                                                    "该条码的在产品生产流程不在当前工位上");
                                                return;
                                            }
                                            else
                                            {
                                                CurrentOptions.Instance.OptionTwo = product;
                                                Options.RefreshOptionTwo(product.T102LeafID);
                                            }
                                            break;
                                        default:
                                            WriteToScreenLog(
                                                view.BarCode,
                                                "",
                                                "",
                                                barcodeInfo.BarcodeStatus,
                                                barcodeInfo.BarcodeStatusStr);
                                            return;
                                    }
                                    break;
                                case 7:
                                    return;
                                default:
                                    WriteToScreenLog(
                                        view.BarCode,
                                        "",
                                        "",
                                        barcodeInfo.BarcodeStatus,
                                        barcodeInfo.BarcodeStatusStr);
                                    return;
                            }

                            long transactNo = 0;
                            long factID = 0;

                            // 申请交易号
                            transactNo =
                                IRAPUTSClient.Instance.mfn_GetTransactNo(
                                    IRAPUser.Instance.CommunityID,
                                    1,
                                    IRAPUser.Instance.SysLogID,
                                    "14");
                            // 申请事实编号
                            factID =
                                IRAPUTSClient.Instance.mfn_GetFactID(
                                    IRAPUser.Instance.CommunityID,
                                    barcodeInfo.NumOfSubPCBs,
                                    IRAPUser.Instance.SysLogID,
                                    "0");

                            IRAPMESClient.Instance.usp_ManufactureRecord(
                                IRAPUser.Instance.CommunityID,
                                transactNo,
                                factID,
                                Options.SelectProduct.T120LeafID,
                                Options.SelectStation.T107LeafID,
                                view.BarCode,
                                barcodeInfo.SerialNumber,
                                IRAPUser.Instance.SysLogID,
                                out errCode,
                                out errText);
                            WriteToScreenLog(
                                view.BarCode,
                                "",
                                barcodeInfo.SerialNumber,
                                errCode,
                                errText);
                            #endregion
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(error.Message, strProcedureName);
                            WriteToScreenLog(
                                view.BarCode,
                                "",
                                "",
                                -1,
                                error.Message);
                        }
                        finally
                        {
                            WriteLog.Instance.WriteEndSplitter(strProcedureName);
                        }
                    }
                }
            }
            finally
            {
                timer.Enabled = true;
            }
        }

        private void WriteToScreenLog(
            string mainBarCode,
            string subBarCode,
            string serialNumber,
            int errCode,
            string errText)
        {
            if (logs.Count >= 100)
            {
                logs.RemoveRange(99, logs.Count - 99);
            }

            logs.Insert(
                0,
                new ManufactureRecordLog()
                {
                    ProcessTime = DateTime.Now.ToString(),
                    MainBarCode = mainBarCode,
                    SubBarCode = subBarCode,
                    SerialNumber = serialNumber,
                    ResultCode = errCode,
                    ResultMessage = errText,
                });
            grdvBarCodeLogs.BestFitColumns();
        }
    }

    internal class ManufactureRecordLog
    {
        public string ProcessTime { get; set; }
        public string MainBarCode { get; set; }
        public string SubBarCode { get; set; }
        public string SerialNumber { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }

    internal class ScannerView
    {
        public string PortName { get; set; }
        public string WorkUnitCode { get; set; }
        public string WorkUnitName { get; set; }
        public int WorkUnitLeafID { get; set; }
        public string BarCode { get; set; }
    }
}
