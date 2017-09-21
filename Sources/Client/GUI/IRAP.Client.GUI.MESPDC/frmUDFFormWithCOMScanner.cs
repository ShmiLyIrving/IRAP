using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;
using IRAP.Entity.SSO;
using IRAP.Entity.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmUDFFormWithCOMScanner : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private MenuInfo menuInfo = null;
        private UDFForm1Ex busUDFForm = new UDFForm1Ex();

        private List<StationPortInfo> ports = new List<StationPortInfo>();
        private List<ScannerForSerialPort> scanners = new List<ScannerForSerialPort>();
        private List<SerialPortScannerUDFLog> logs = new List<SerialPortScannerUDFLog>();
        private List<ScannerView> scannerViews = new List<ScannerView>();

        public frmUDFFormWithCOMScanner()
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
                                    WorkUnitLeafID = port.WorkUnitLeaf,
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
        }

        private void WriteToScreenLog(
            string mainBarCode,
            string SerialPort,
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
                new SerialPortScannerUDFLog()
                {
                    ProcessTime = DateTime.Now.ToString(),
                    MainBarCode = mainBarCode,
                    SerialPort = SerialPort,
                    SerialNumber = serialNumber,
                    ResultCode = errCode,
                    ResultMessage = errText,
                });
            grdvBarCodeLogs.BestFitColumns();
        }

        private void frmUDFFormWithCOMScanner_Shown(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (this.Tag is MenuInfo)
                {
                    menuInfo = this.Tag as MenuInfo;
                }
                else
                {
                    WriteLog.Instance.Write("没有正确的传入菜单参数", strProcedureName);
                    WriteToScreenLog("", "", "", -1, "没有正确的传入菜单参数！");
                    return;
                }

                try
                {
                    if (menuInfo.Parameters == "")
                    {
                        WriteToScreenLog("", "", "", -1, "菜单参数中没有正确配置万能表单的参数");
                    }
                    else
                    {
                        busUDFForm.SetCtrlParameter(menuInfo.Parameters);
                        busUDFForm.OpNode = menuInfo.OpNode;

                        frmUDFFormWithCOMScanner_Activated(this, null);

                        timer.Enabled = true;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteToScreenLog("", "", "", -1, error.Message);
                }

#if DEBUG
                textEdit1.Visible = true;
#else
                textEdit1.Visible = false;
#endif
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmUDFFormWithCOMScanner_Activated(object sender, EventArgs e)
        {
            Options.Visible = true;
        }

        private void frmUDFFormWithCOMScanner_FormClosed(object sender, FormClosedEventArgs e)
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
                        view.BarCode = splitString[1].TrimEnd('\0');
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
                            object tag = scannerViews;

#if DEBUG
                            XtraMessageBox.Show(
                                string.Format(
                                    "PortName={0}|WorkUnitLeafID={1}|" +
                                    "WorkUnitCode={2}|WorkUnitName={3}",
                                    view.PortName,
                                    view.WorkUnitLeafID,
                                    view.WorkUnitCode,
                                    view.WorkUnitName));
#endif

                            busUDFForm.SetStrParameterValue(view.BarCode, 1);
                            busUDFForm.SaveOLTPUDFFormData(
                                CurrentOptions.Instance.OptionTwo.T102LeafID,
                                view.WorkUnitLeafID,
                                null,
                                ref tag);
                            grdvSerialPortScanners.RefreshData();
                            grdvSerialPortScanners.BestFitColumns();

                            WriteLog.Instance.Write(
                                string.Format(
                                    "{0}.{1}",
                                    busUDFForm.ErrorCode,
                                    busUDFForm.ErrorMessage),
                                strProcedureName);
                            WriteToScreenLog(
                                view.BarCode,
                                splitString[0],
                                "",
                                busUDFForm.ErrorCode,
                                busUDFForm.ErrorMessage);

                            if (busUDFForm.ErrorCode == 0)
                            {
                                WriteLog.Instance.Write(
                                    string.Format("Output={0}", busUDFForm.OutputStr),
                                    strProcedureName);
                                if (busUDFForm.OutputStr != "")
                                {
                                    try
                                    {
                                        Actions.UDFActions.DoActions(
                                            busUDFForm.OutputStr,
                                            null,
                                            ref tag);

                                        grdvSerialPortScanners.RefreshData();
                                        grdvSerialPortScanners.BestFitColumns();
                                    }
                                    catch (Exception error)
                                    {
                                        WriteLog.Instance.Write(
                                            string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                                                error.Message,
                                                error.StackTrace),
                                            strProcedureName);
                                        WriteToScreenLog(
                                            view.BarCode,
                                            splitString[0],
                                            "",
                                            -1,
                                            string.Format(
                                                "执行输出指令时发生错误：[{0}]",
                                                error.Message));
                                    }
                                }
                            }
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

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                lstBarCodes.Items.Add(textEdit1.Text);
                textEdit1.Text = "";
            }
        }
    }

    internal class SerialPortScannerUDFLog
    {
        public string ProcessTime { get; set; }
        public string MainBarCode { get; set; }
        public string SerialPort { get; set; }
        public string SerialNumber { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
