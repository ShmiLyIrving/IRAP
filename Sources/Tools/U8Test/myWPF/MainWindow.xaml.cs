using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml;

namespace myWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 字段属性
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private bool canClosed = false;
        private static NotifyIcon trayIcon;
        private FormWindowState formStatus = FormWindowState.Minimized;
        private object lockArea = new object();
        private List<string> wait4ReadToxFile = new List<string>();


        /// <summary>
        /// 上次尝试 ESB 连接时间
        /// </summary>
        private DateTime lastESBConnectTime = DateTime.Now;
        /// <summary>
        /// 再次尝试连接 ESB 的间隔时间
        /// </summary>
        //private int esbReconnectSpantime = 60;

        private System.Windows.Forms.Timer tmReadFromxFile = new System.Windows.Forms.Timer();
        #endregion
        #region 方法
        public MainWindow()
        {
            InitializeComponent();         
        }
        ~MainWindow()
        {
            
        }
        private void AddTrayIcon()
        {
            if (trayIcon != null)
            {
                return;
            }
            trayIcon = new NotifyIcon
            {
                Icon = new System.Drawing.Icon("Photos/gftp.ico"),
                Text = "U8Test"
            };
            trayIcon.Visible = true;
            trayIcon.DoubleClick += new EventHandler(delegate { this.trayIcon_DoubleClick(null, null); });
            System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();

            System.Windows.Forms.MenuItem closeItem = new System.Windows.Forms.MenuItem();
            closeItem.Text = "退出";
            closeItem.Click += new EventHandler(delegate { this.ApplicationExit(null,null); });

            System.Windows.Forms.MenuItem configItem = new System.Windows.Forms.MenuItem();
            configItem.Text = "配置";
            configItem.Click += new EventHandler(delegate { this.ApplicationConfig(null, null); });
            menu.MenuItems.Add(configItem);
            menu.MenuItems.Add(closeItem);

            trayIcon.ContextMenu = menu;    //设置NotifyIcon的右键弹出菜单
        }

        private void RemoveTrayIcon()
        {
            if (trayIcon != null)
            {
                trayIcon.Visible = false;
                trayIcon.Dispose();
                trayIcon = null;
            }
        }
        private void LoadConfig()
        {
            txtUpgrade.Text = SysParams.Instance.UpgradeURL;
            this.chkLog.IsChecked = SysParams.Instance.IsWriteLog;

            txtServerIP.Text = SysParams.Instance.U8ServerIP;
            txtuid.Text = SysParams.Instance.U8uid;
            txtpwd.Password = SysParams.Instance.U8pwd;
            chkbCheck.IsChecked = SysParams.Instance.bCheck;
            chkbBeforeCheckStocks.IsChecked = SysParams.Instance.bBeforCheckStock;
            chkbIsRedVouch.IsChecked = SysParams.Instance.bIsRedVouch;
        }
        private void UpdateBtn(bool enable)
        {
            try
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate ()
                    {
                        SetBtn(enable);
                    });
            }
            catch (Exception error)
            {
                System.Windows.MessageBox.Show(string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               error.Message,
                               error.StackTrace),
                           "");
                WriteLog.Instance.Write(
                           string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               error.Message,
                               error.StackTrace),
                           "");
            }
        }
        private void SetBtn(bool enable)
        {
            btn_Confirm.IsEnabled = enable;
        }
        private void UpdateLog(string msg, string modeName, ToolTipIcon icon)
        {
            try
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                      (ThreadStart)delegate ()
                      {
                          OutputLog(msg, modeName, icon);
                      }
                    );
            }
            catch (Exception error)
            {
                System.Windows.MessageBox.Show(string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               error.Message,
                               error.StackTrace),
                           "");
                WriteLog.Instance.Write(
                           string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               error.Message,
                               error.StackTrace),
                           "");
            }
        }
        private void OutputLog(string msg, string modeName, ToolTipIcon icon)
        {
            try
            {
                if (msg != null)
                {
                    WriteLog.Instance.Write(msg, modeName);
                    Paragraph p = new Paragraph();
                    Run run = new Run() { Text = msg };
                    p.Inlines.Add(run);
                    edtLogs.Document.Blocks.Add(p);
                    ShowMessageInBalloon(msg, icon, 5000);
                }
            }
            catch (Exception error)
            {
                System.Windows.MessageBox.Show(string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               error.Message,
                               error.StackTrace),
                           "");
                WriteLog.Instance.Write(
                           string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               error.Message,
                               error.StackTrace),
                           "");
            }
        }
        private void ShowMessageInBalloon(
            string msg,
            ToolTipIcon icon = ToolTipIcon.None,
            int timeout = 1000)
        {
            string caption = "";
            switch (icon)
            {
                case ToolTipIcon.Error:
                    caption = "错误消息";
                    break;
                case ToolTipIcon.Info:
                    caption = "提示信息";
                    break;
                case ToolTipIcon.None:
                    return;
                case ToolTipIcon.Warning:
                    caption = "警告信息";
                    break;
            }
            trayIcon.ShowBalloonTip(timeout, caption, msg, icon);
        }
        private void ShowForm()
        {
            formStatus = FormWindowState.Normal;
            Show();
            ShowInTaskbar = true;
            Activate();
            SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);
        }
        private void HideForm()
        {
            //方便操作工不隐藏窗口
            //return;
            formStatus = FormWindowState.Minimized;

            //if (WindowState == FormWindowState.Maximized)
            //    WindowState = FormWindowState.Normal;

            Hide();
            ShowInTaskbar = false;
        }
        #endregion
        #region 事件
        private void tabMain_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // MoveFocus takes a TraveralReqest as its argument.
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);

                // Gets the element with keyboard focus.
                UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;

                // Change keyboard focus.
                if (elementWithFocus != null)
                {
                    elementWithFocus.MoveFocus(request);
                }
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }
        private void ApplicationExit(object sender, ExitEventArgs e)
        {          
            canClosed = true;
            System.Windows.Application.Current.Shutdown();
        }
        private void ApplicationConfig(object sender, ExitEventArgs e)
        {
            tabMain.SelectedIndex = 1;
            ShowForm();
        }
        private void LoadMode()
        {
            List<AuditMode> modes = new List<AuditMode>();
            modes.Add(new AuditMode(11, "MaterialOutAudit", "材料出库单审计"));
            modes.Add(new AuditMode(10, "ProductInAudit", "产成品入库单审计"));
            modes.Add(new AuditMode(01, "PuStoreInAudit", "采购入库单审计"));
            modes.Add(new AuditMode(12, "TransVouchAudit", "调拨单审计"));
            modes.Add(new AuditMode(32, "saleoutAudit", "销售出库单审计"));
            modes.Add(new AuditMode(08, "otherinAudit", "其他入库单审计"));
            modes.Add(new AuditMode(09, "otheroutAudit", "其他出库单审计"));
            foreach (AuditMode m in modes)
            {
                cboMode.Items.Add(m);
            }
            cboMode.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadConfig();
                AddTrayIcon();
                LoadMode();
            }
            catch(Exception error)
            {
                System.Windows.MessageBox.Show(string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               error.Message,
                               error.StackTrace),
                           "");
                WriteLog.Instance.Write(
                           string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                               error.Message,
                               error.StackTrace),
                           "");
            }          
        }
        
      
        private void edtLogs_TextChanged(object sender, TextChangedEventArgs e)
        {
            edtLogs.ScrollToEnd();
        }
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            SysParams.Instance.UpgradeURL = txtUpgrade.Text;
            SysParams.Instance.IsWriteLog = (bool)(this.chkLog.IsChecked);
            SysParams.Instance.U8uid = txtuid.Text;
            SysParams.Instance.U8pwd = txtpwd.Password;
            SysParams.Instance.U8ServerIP = txtServerIP.Text;
            SysParams.Instance.bCheck = (bool)(chkbCheck.IsChecked);
            SysParams.Instance.bBeforCheckStock = (bool)(chkbBeforeCheckStocks.IsChecked);
            SysParams.Instance.bIsRedVouch = (bool)(chkbIsRedVouch.IsChecked);
            System.Windows.MessageBox.Show("保存成功！");
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (canClosed)
            {
                e.Cancel = false;
                RemoveTrayIcon();
            }
            else
            {
                e.Cancel = true;
                HideForm();
            }
        }
        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }
        #endregion

        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            btn_Confirm.IsEnabled = false;
            IRAP_WS ir = new IRAP_WS();
            ir.Outputlog = OutputLog;
            string h, b, mode;
            bool? s = false;
            Task t;
            MSXML2.DOMDocumentClass domMsg = new MSXML2.DOMDocumentClass();
            domMsg.loadXML("");

            MSXML2.IXMLDOMDocument2 domMsgO = domMsg;
            object o = (object)domMsgO;

            System.String sVouchType;
            System.Object domPosition;
            System.String errMsg="";
            ADODB.Connection cnnFromO = null;
            System.String VouchId;//

            System.Boolean bCheck = SysParams.Instance.bCheck;
            System.Boolean bBeforCheckStock = SysParams.Instance.bBeforCheckStock;
            System.Boolean bIsRedVouch;
            System.String sAddedState = "";
            System.Boolean bReMote;

          switch (tabBo.SelectedIndex)
            {

                #region 材料出库单
                //<ccode>1AQOT1APCM70321033</ccode>
                //<cwhname>M051</cwhname>      
                //<cinvcode>5122000000</cinvcode>
                //<editprop>A</editprop>
                //<cdepcode>0907</cdepcode>
                //< cpersoncode > 000381 </ cpersoncode >
                //< crdcode > 206 </ crdcode >
                //< cwhcode >M051</ cwhcode >
                //<cbatch>17m049b</<cbatch>>
                case 0:
                    mode = "材料出库";
                    h = $@"<table>
<row>
<id>{txtid0.Text.Trim()}</id>
<ccode>{txtccode0.Text.Trim()}</ccode>
<ddate>{dpddate0.Text.Trim()}</ddate>
<cwhcode>{txtcwhname0.Text.Trim()}</cwhcode>
<cmpocode>{txtcmpocode0.Text.Trim()}</cmpocode>
<iproorderid>{txtimpoids0.Text.Trim()}</iproorderid>
<cmaker>{txtcmaker0.Text.Trim()}</cmaker>
<dnmaketime>{dpdnmaketime0.Text.Trim()}</dnmaketime>
<cbustype>{txtcbustype0.Text.Trim()}</cbustype>
<crdcode>{txtcrdname0.Text.Trim()}</crdcode>
<vt_id>{txtvt_id0.Text.Trim()}</vt_id>
<cdepcode>{txtcdepcode0.Text.Trim()}</cdepcode>
<cprobatch></cprobatch>
<cpersoncode>000094</cpersoncode>
<cproinvaddcode>1</cproinvaddcode>
<csource>生产订单</csource>
</row></table>";

                    b = $@"<table>
<row>
<autoid>1</autoid>
<cinvcode>{txtcinvcode0.Text.Trim()}</cinvcode>
<cbatch>{txtcbatch0.Text.Trim()}</cbatch>
<iquantity>{txtiquantity0.Text.Trim()}</iquantity>
<cmocode>{txtcmpocode0.Text.Trim()}</cmocode>
<imoseq>{txtimoseq0.Text.Trim()}</imoseq>
<impoids>{txtimpoids0.Text.Trim()}</impoids>
<cposition>{txtcposname0.Text.Trim()}</cposition>
<cdefine22>{txtcdefine220.Text.Trim()}</cdefine22>
<cdefine23>{txtcdefine230.Text.Trim()}</cdefine23>
<cdefine24>{txtcdefine240.Text.Trim()}</cdefine24>
<cdefine26>{txtcdefine260.Text.Trim()}</cdefine26>
<editprop>A</editprop>
</row></table> ";


                    sVouchType = "11";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = SysParams.Instance.bIsRedVouch;
                    sAddedState = "";
                    bReMote = false;
                    
                    OutputLog("=======================开始上传========================", mode, ToolTipIcon.None);
                    OutputLog("DomHead =" + h, mode, ToolTipIcon.None);
                    OutputLog("DomBody =" + b, mode, ToolTipIcon.None);

                    t = new Task(() => 
                    {
                        s = ir.MaterialOutAdd(sVouchType,
                            h, b,
                              domPosition,
                              out errMsg,
                              cnnFromO,
                              ref VouchId,
                              out o,
                              bCheck,
                              bBeforCheckStock,
                              bIsRedVouch,
                              sAddedState,
                              bReMote);
                    });
                    t.ContinueWith(c=>
                    {
                        try
                         {
                            if ((bool)s)
                            {
                                UpdateLog("提交成功"+"VouchId ="+ VouchId, mode, ToolTipIcon.Info);
                            }
                            else
                            {
                                UpdateLog("提交失败："+errMsg, mode, ToolTipIcon.Info);
                            }
                            if (domMsg != null)
                                UpdateLog((o as MSXML2.IXMLDOMDocument2).xml.ToString(), mode, ToolTipIcon.None);
                        }
                        catch (Exception ex)
                        {
                            if (s == null)
                            {
                                UpdateLog("发生异常: s is null," + ex.Message, mode, ToolTipIcon.None);
                            }
                            if (errMsg == null)
                            {
                                UpdateLog("发生异常:errMsg is null," + ex.Message, mode, ToolTipIcon.None);
                            }
                            if (domMsg == null)
                                UpdateLog("发生异常:0 is null," + ex.Message, mode, ToolTipIcon.None);
                        }
                        UpdateBtn(true);
                        UpdateLog("=======================结束==========================", mode, ToolTipIcon.None);
                    });
                    t.Start();                  
                    break;
                #endregion 材料出库单
                #region 产成品入库单
//<ccode>1AQOT1APCM70321033</ccode>
//<cwhname>M051</cwhname>      
//<cinvcode>5122000000</cinvcode>
//<editprop>A</editprop>
//<cdepcode>0907</cdepcode>
//<cpersoncode>000381</cpersoncode>
//<crdcode>102</crdcode>
//<csource>生产订单</csource>
//<cbustype>成品入库</cbustype>
                case 1:
                    mode = "产品入库";
                    h = $@"<table>
<row>
<id>{txtid1.Text.Trim()}</id>
<cCode>{txtccode1.Text.Trim()}</cCode>
<dDate>{dpddate1.Text.Trim()}</dDate>
<cwhcode>{txtcwhname1.Text.Trim()}</cwhcode>
<cmpocode>{txtcmpocode1.Text.Trim()}</cmpocode>
<crdcode>{txtcrdname1.Text.Trim()}</crdcode>
<crdname>{txtcrdname1.Text.Trim()}</crdname>
<cmaker>{txtcmaker1.Text.Trim()}</cmaker>
<dnmaketime>{dpdnmaketime1.Text.Trim()}</dnmaketime>
<cdepcode>{txtcdepname1.Text.Trim()}</cdepcode>
<cbustype>{txtcbustype1.Text.Trim()}</cbustype>
<iproorderid>{txtimpoids1.Text.Trim()}</iproorderid>
<vt_id>{txtvt_id1.Text.Trim()}</vt_id>
<cprobatch></cprobatch>
<csource>生产订单</csource>
</row></table>
";

                    b = $@"<table>
<row>
<autoid>{txtautoid1.Text.Trim()}</autoid>
<cinvcode>{txtcinvcode1.Text.Trim()}</cinvcode>
<cbatch>{txtcbatch1.Text.Trim()}</cbatch>
<iquantity>{txtiquantity1.Text.Trim()}</iquantity>
<cmocode>{txtcmpocode1.Text.Trim()}</cmocode>
<imoseq>{txtimoseq1.Text.Trim()}</imoseq>
<impoids>{txtimpoids1.Text.Trim()}</impoids>
<cposition>{txtcposname1.Text.Trim()}</cposition>
<cdefine22>{txtcdefine221.Text.Trim()}</cdefine22>
<cdefine23>{txtcdefine231.Text.Trim()}</cdefine23>
<cdefine24>{txtcdefine241.Text.Trim()}</cdefine24>
<cdefine26>{txtcdefine261.Text.Trim()}</cdefine26>
</row></table> ";

                    sVouchType = "10";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = SysParams.Instance.bIsRedVouch;
                    sAddedState = "";
                    bReMote = false; ;
                    OutputLog("=======================开始上传========================", mode, ToolTipIcon.None);
                    OutputLog("DomHead =" + h, mode, ToolTipIcon.None);
                    OutputLog("DomBody =" + b, mode, ToolTipIcon.None);
                    t = new Task(() =>
                    {
                        s = ir.ProductInAdd(sVouchType,
                                  h, b,
                                    domPosition,
                                    out errMsg,
                                    cnnFromO,
                                    ref VouchId,
                                    out o,
                                    bCheck,
                                    bBeforCheckStock,
                                    bIsRedVouch,
                                    sAddedState,
                                    bReMote);
                    });
                    t.ContinueWith(c =>
                    {
                        try
                        {
                            if ((bool)s)
                            {
                                UpdateLog("提交成功" + "VouchId =" + VouchId, mode, ToolTipIcon.Info);
                            }
                            else
                            {
                                UpdateLog("提交失败：" + errMsg, mode, ToolTipIcon.Info);
                            }
                            if (domMsg != null)
                                UpdateLog((o as MSXML2.IXMLDOMDocument2).xml.ToString(), mode, ToolTipIcon.None);
                        }
                        catch
                        {
                            if (s == null)
                            {
                                UpdateLog("发生异常: s is null", mode, ToolTipIcon.None);
                            }
                            if (errMsg == null)
                            {
                                UpdateLog("发生异常:errMsg is null", mode, ToolTipIcon.None);
                            }
                            if (domMsg == null)
                                UpdateLog("发生异常:0 is null", mode, ToolTipIcon.None);
                        }
                        UpdateBtn(true);
                        UpdateLog("=======================结束===========================", "", ToolTipIcon.None);
                    });
                    t.Start();
                    break;
                #endregion 产成品入库单
                #region 采购入库单
                case 2:
                    mode = "采购入库";
                    h = $@"<table>
<row>
<id>{txtid2.Text.Trim()}</id>
<bomfirst>{txtbomfirst2.Text.Trim()}</bomfirst>
<ccode>{txtccode2.Text.Trim()}</ccode>
<ddate>{dpddate2.Text.Trim()}</ddate>
<iverifystate>{txtiverifystate2.Text.Trim()}</iverifystate>
<iswfcontrolled>{txtiswfcontrolled2.Text.Trim()}</iswfcontrolled>
<cvenabbname>{txtcvenabbname2.Text.Trim()}</cvenabbname>
<cbustype>{txtcbustype2.Text.Trim()}</cbustype>
<cmaker>{txtcmaker2.Text.Trim()}</cmaker>
<dnmaketime>{dpdnmaketime2.Text.Trim()}</dnmaketime>
<iexchrate>{txtiexchrate2.Text.Trim()}</iexchrate>
<cexch_name>{txtcexch_name2.Text.Trim()}</cexch_name>
<ufts>{txtufts2.Text.Trim()}</ufts>
<bpufirst>{txtbpufirst2.Text.Trim()}</bpufirst>
<cvencode>{txtcvencode2.Text.Trim()}</cvencode>
<cvouchtype>{txtcvouchtype2.Text.Trim()}</cvouchtype>
<cwhcode>{txtcwhcode2.Text.Trim()}</cwhcode>
<brdflag>{txtbrdflag2.Text.Trim()}</brdflag>
<cdepcode>{txtcdepcode2.Text.Trim()}</cdepcode>
<cpersoncode>{txtcpersoncode2.Text.Trim()}</cpersoncode>
<crdcode>{txtcrdcode2.Text.Trim()}</crdcode>
<vt_id>{txtvt_id2.Text.Trim()}</vt_id>
<cvenpuomprotocol>{txtcvenpuomprotocol2.Text.Trim()}</cvenpuomprotocol>
<cordercode>{txtcordercode2.Text.Trim()}</cordercode>
<cptcode>{txtcptcode2.Text.Trim()}</cptcode>
<csource>{txtcsource2.Text.Trim()}</csource>
<ipurorderid>{txtipurorderid2.Text.Trim()}</ipurorderid>
<bcredit>{txtbcredit2.Text.Trim()}</bcredit>
</row></table>
";

                    b = $@"<table>
<row>
<autoid>{txtautoid2.Text.Trim()}</autoid>
<id>{txtfid2.Text.Trim()}</id>
<cinvcode>{txtcinvcode2.Text.Trim()}</cinvcode>
<cinvm_unit>{txtcinvm_unit2.Text.Trim()}</cinvm_unit>
<iquantity>{txtiquantity2.Text.Trim()}</iquantity>
<editprop>{txteditprop2.Text.Trim()}</editprop>
<iMatSettleState>{txtiMatSettleState.Text.Trim()}</iMatSettleState>
<iposid>{txtiposid2.Text.Trim()}</iposid>
<cpoid>{txtcpoid2.Text.Trim()}</cpoid>
<cbatch>{txtcbatch2.Text.Trim()}</cbatch>
<cposition>{txtcposname2.Text.Trim()}</cposition>
<cdefine22>{txtcdefine222.Text.Trim()}</cdefine22>
<cdefine23>{txtcdefine232.Text.Trim()}</cdefine23>
<cdefine26>{txtcdefine262.Text.Trim()}</cdefine26>
<isotype>{txtisotype2.Text.Trim()}</isotype>
<btaxcost>{txtbtaxcost2.Text.Trim()}</btaxcost>
<iunitcost>{txtiunitcost2.Text.Trim()}</iunitcost>
<corufts>{txtcorufts2.Text.Trim()}</corufts>
<ioritaxcost>{txtioritaxcost2.Text.Trim()}</ioritaxcost>
<ioricost>{txtioricost2.Text.Trim()}</ioricost>
<iorimoney>{txtiorimoney2.Text.Trim()}</iorimoney>
<ioritaxprice>{txtioritaxprice2.Text.Trim()}</ioritaxprice>
<iorisum>{txtiorisum2.Text.Trim()}</iorisum>
<itaxrate>{txtitaxrate2.Text.Trim()}</itaxrate>
<itaxprice>{txtitaxprice2.Text.Trim()}</itaxprice>
<isum>{txtisum2.Text.Trim()}</isum>
<facost>{txtfacost2.Text.Trim()}</facost>
<iaprice>{txtiaprice2.Text.Trim()}</iaprice>

</row></table> ";

                    sVouchType = "01";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = SysParams.Instance.bIsRedVouch;
                    sAddedState = "";
                    bReMote = false; ;

                    OutputLog("=======================开始上传========================", mode, ToolTipIcon.None);
                    OutputLog("DomHead =" + h, mode, ToolTipIcon.None);
                    OutputLog("DomBody =" + b, mode, ToolTipIcon.None);
                    t = new Task(() =>
                    {
                        s = ir.PuStoreInAdd(sVouchType,
                                  h, b,
                                    domPosition,
                                    out errMsg,
                                    cnnFromO,
                                    ref VouchId,
                                    out o,
                                    bCheck,
                                    bBeforCheckStock,
                                    bIsRedVouch,
                                    sAddedState,
                                    bReMote);
                    });
                    t.ContinueWith(c =>
                    {
                        try
                        {
                            if ((bool)s)
                            {
                                UpdateLog("提交成功" + "VouchId =" + VouchId, mode, ToolTipIcon.Info);
                            }
                            else
                            {
                                UpdateLog("提交失败：" + errMsg, mode, ToolTipIcon.Info);
                            }
                            if (domMsg != null)
                                UpdateLog((o as MSXML2.IXMLDOMDocument2).xml.ToString(), mode, ToolTipIcon.None);
                        }
                        catch
                        {
                            if (s == null)
                            {
                                UpdateLog("发生异常: s is null", mode, ToolTipIcon.None);
                            }
                            if (errMsg == null)
                            {
                                UpdateLog("发生异常:errMsg is null", mode, ToolTipIcon.None);
                            }
                            if (domMsg == null)
                                UpdateLog("发生异常:0 is null", mode, ToolTipIcon.None);
                        }
                        UpdateBtn(true);
                        UpdateLog("========================结束==========================", "", ToolTipIcon.None);
                    });
                    t.Start();
                    break;


                #endregion 采购入库单
                #region 调拨单
                //<ccode>1AQOT1APCM70321033</ccode>
                //<cwhname>M051</cwhname>      
                //<cinvcode>5122000000</cinvcode>
                //<editprop>A</editprop>
                case 3:
                    mode = "调拨";
                    h = $@"<table>
<row>
<id>{txtid3.Text.Trim()}</id>
<ctvcode>{txtctvcode3.Text.Trim()}</ctvcode>
<dtvdate>{dpdtvdate3.Text.Trim()}</dtvdate>
<codepcode>{txtcodepcode3.Text.Trim()}</codepcode>
<cidepcode>{txtcidepcode3.Text.Trim()}</cidepcode>
<cirdcode>{txtcirdcode3.Text.Trim()}</cirdcode>
<cordcode>{txtcordcode3.Text.Trim()}</cordcode>
<csource>{txtcsource3.Text.Trim()}</csource>
<cmaker>{txtcmaker3.Text.Trim()}</cmaker>
<dnmaketime>{dpdnmaketime3.Text.Trim()}</dnmaketime>
<vt_id>{txtvt_id3.Text.Trim()}</vt_id>
<iproorderid>{txtiproorderid3.Text.Trim()}</iproorderid>
<cowhcode>{txtcowhcode3.Text.Trim()}</cowhcode>
<ciwhcode>{txtciwhcode3.Text.Trim()}</ciwhcode>
<ctranrequestcode>{txtctranrequestcode3.Text.Trim()}</ctranrequestcode>
<itransflag>{txtitransflag3.Text.Trim()}</itransflag>
</row></table>
";

                    b = $@"<table>
<row>
<autoid>{txtautoid3.Text.Trim()}</autoid>
<cinvcode>{txtcinvcode3.Text.Trim()}</cinvcode>
<editprop>{txteditprop3.Text.Trim()}</editprop>
<itvquantity>{txtitvquantity3.Text.Trim()}</itvquantity>
<cinvm_unit>{txtcinvm_unit3.Text.Trim()}</cinvm_unit>
<cmocode>{txtcmocode3.Text.Trim()}</cmocode>
<imoseq>{txtimoseq3.Text.Trim()}</imoseq>
<impoids>{txtimpoids3.Text.Trim()}</impoids>
<coutposcode>{txtcoutposcode3.Text.Trim()}</coutposcode>
<cinposcode>{txtcinposcode3.Text.Trim()}</cinposcode>
<ctvbatch>{txtctvbatch3.Text.Trim()}</ctvbatch>
<itrids>{txtitrids3.Text.Trim()}</itrids>
<cdefine26>{txtcdefine263.Text.Trim()}</cdefine26>
</row></table> ";

                    sVouchType = "12";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = SysParams.Instance.bIsRedVouch;
                    sAddedState = "";
                    bReMote = false; ;
                    OutputLog("=======================开始上传========================", mode, ToolTipIcon.None);
                    OutputLog("DomHead =" + h, mode, ToolTipIcon.None);
                    OutputLog("DomBody =" + b, mode, ToolTipIcon.None);

                        s = ir.TransVouchAdd(sVouchType,
                                  h, b,
                                    domPosition,
                                    out errMsg,
                                    cnnFromO,
                                    ref VouchId,
                                    out o,
                                    bCheck,
                                    bBeforCheckStock,
                                    bIsRedVouch,
                                    sAddedState,
                                    bReMote);

                    try
                    {
                        if ((bool)s)
                        {
                            UpdateLog("提交成功" + "VouchId =" + VouchId, mode, ToolTipIcon.Info);
                        }
                        else
                        {
                            UpdateLog("提交失败：" + errMsg, mode, ToolTipIcon.Info);
                        }
                        if (domMsg != null)
                            UpdateLog((o as MSXML2.IXMLDOMDocument2).xml.ToString(), mode, ToolTipIcon.None);
                    }
                    catch
                    {
                        if (s == null)
                        {
                            UpdateLog("发生异常: s is null", mode, ToolTipIcon.None);
                        }
                        if (errMsg == null)
                        {
                            UpdateLog("发生异常:errMsg is null", mode, ToolTipIcon.None);
                        }
                        if (domMsg == null)
                            UpdateLog("发生异常:0 is null", mode, ToolTipIcon.None);
                    }
                        UpdateBtn(true);
                        UpdateLog("=======================结束===========================", "", ToolTipIcon.None);
                    
                 
                    break;
                #endregion 调拨单
                #region 销售出库单
                //<ccode>1AQOT1APCM70321033</ccode>
                //<cwhname>M051</cwhname>      
                //<cinvcode>5122000000</cinvcode>
                //<editprop>A</editprop>
                case 4:
                    mode = "销售出库";
                    h = $@"<table>
<row>
<id>{txtid4.Text.Trim()}</id>
<ccode>{txtccode4.Text.Trim()}</ccode>
<ddate>{dpddate4.Text.Trim()}</ddate>
<cbustype>{txtcbustype4.Text.Trim()}</cbustype>
<iverifystate>{txtiverifystate4.Text.Trim()}</iverifystate>
<iswfcontrolled>{txtiswfcontrolled4.Text.Trim()}</iswfcontrolled>
<ccusabbname>{txtccusabbname4.Text.Trim()}</ccusabbname>
<cmaker>{txtcmaker4.Text.Trim()}</cmaker>
<dnmaketime>{dpdnmaketime4.Text.Trim()}</dnmaketime>
<ufts>{txtufts4.Text.Trim()}</ufts>
<cvouchtype>{txtcvouchtype4.Text.Trim()}</cvouchtype>
<cwhcode>{txtcwhcode4.Text.Trim()}</cwhcode>
<csource>{txtcsource4.Text.Trim()}</csource>
<brdflag>{txtbrdflag4.Text.Trim()}</brdflag>
<ccuscode>{txtccuscode4.Text.Trim()}</ccuscode>
<bisstqc>{txtbisstqc4.Text.Trim()}</bisstqc>
<cbuscode>{txtcbuscode4.Text.Trim()}</cbuscode>
<cstcode>{txtcstcode4.Text.Trim()}</cstcode>
<vt_id>{txtvt_id4.Text.Trim()}</vt_id>
<cdepcode>{txtcdepcode4.Text.Trim()}</cdepcode>
<crdcode>{txtcrdcode4.Text.Trim()}</crdcode>
<cdlcode>{txtcdlcode4.Text.Trim()}</cdlcode>
<iarriveid>{txtiarriveid4.Text.Trim()}</iarriveid>
</row>
</table>
";

                    b = $@"<table>
<row>
<autoid>{txtautoid4.Text.Trim()}</autoid>
<cinvm_unit>{txtcinvm_unit4.Text.Trim()}</cinvm_unit>
<iquantity>{txtiquantity4.Text.Trim()}</iquantity>
<cinvcode>{txtcinvcode4.Text.Trim()}</cinvcode>
<id>{txtfid4.Text.Trim()}</id>
<editprop>{txteditprop4.Text.Trim()}</editprop>
<cposition>{txtcposname4.Text.Trim()}</cposition>
<cdefine22>{txtcdefine224.Text.Trim()}</cdefine22>
<cdefine23>{txtcdefine234.Text.Trim()}</cdefine23>
<cdefine24>{txtcdefine244.Text.Trim()}</cdefine24>
<cdefine26>{txtcdefine264.Text.Trim()}</cdefine26>
<cinvaddcode>{txtcinvaddcode4.Text.Trim()}</cinvaddcode>
<cinvname>{txtcinvcode4.Text.Trim()}</cinvname>
<cbatch>{txtcbatch4.Text.Trim()}</cbatch>
<idlsid>{txtidlsid4.Text.Trim()}</idlsid>
<cbdlcode>{txtcbdlcode4.Text.Trim()}</cbdlcode>
<iprice>{txtiprice4.Text.Trim()}</iprice>
<iunitcost>{txtiunitcost4.Text.Trim()}</iunitcost>
<iordercode>{txtiordercode4.Text.Trim()}</iordercode>
<isodid>{txtisodid4.Text.Trim()}</isodid>
<iordertype>{txtiordertype4.Text.Trim()}</iordertype>
<iorderdid>{txtiorderdid4.Text.Trim()}</iorderdid>
<cdefine26>{txtcdefine264.Text.Trim()}</cdefine26>
 </row></table> ";

                    sVouchType = "32";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = SysParams.Instance.bIsRedVouch;
                    sAddedState = "";
                    bReMote = false; ;
                    OutputLog("=======================开始上传========================", mode, ToolTipIcon.None);
                    OutputLog("DomHead =" + h, mode, ToolTipIcon.None);
                    OutputLog("DomBody =" + b, mode, ToolTipIcon.None);
                    t = new Task(() =>
                    {
                        s = ir.saleoutAdd(sVouchType,
                                  h, b,
                                    domPosition,
                                    out errMsg,
                                    cnnFromO,
                                    ref VouchId,
                                    out o,
                                    bCheck,
                                    bBeforCheckStock,
                                    bIsRedVouch,
                                    sAddedState,
                                    bReMote);
                    });
                    t.ContinueWith(c =>
                    {
                        try
                        {
                            if ((bool)s)
                            {
                                UpdateLog("提交成功" + "VouchId =" + VouchId, mode, ToolTipIcon.Info);
                            }
                            else
                            {
                                UpdateLog("提交失败：" + errMsg, mode, ToolTipIcon.Info);
                            }
                            if (domMsg != null)
                                UpdateLog((o as MSXML2.IXMLDOMDocument2).xml.ToString(), mode, ToolTipIcon.None);
                        }
                        catch
                        {
                            if (s == null)
                            {
                                UpdateLog("发生异常: s is null", mode, ToolTipIcon.None);
                            }
                            if (errMsg == null)
                            {
                                UpdateLog("发生异常:errMsg is null", mode, ToolTipIcon.None);
                            }
                            if (domMsg == null)
                                UpdateLog("发生异常:0 is null", mode, ToolTipIcon.None);
                        }
                        UpdateBtn(true);
                        UpdateLog("=======================结束===========================", "", ToolTipIcon.None);
                    });
                    t.Start();
                    break;
                #endregion 销售出库单
                #region 其他入库单
                //<ccode>1AQOT1APCM70321033</ccode>
                //<cwhname>M051</cwhname>      
                //<cinvcode>5122000000</cinvcode>
                //<editprop>A</editprop>
                case 5:
                    mode = "其他入库";
                    h = $@"<table>
     <row>
<id>{txtid5.Text.Trim()}</id>
<ccode>{txtccode5.Text.Trim()}</ccode>
<ddate>{dpddate5.Text.Trim()}</ddate>
<cwhname>{txtcwhname5.Text.Trim()}</cwhname>
<cwhcode>{txtcwhname5.Text.Trim()}</cwhcode>
<cbustype>{txtcbustype5.Text.Trim()}</cbustype>
<cdepcode>0907</cdepcode>
<cpersoncode>000381</cpersoncode>
<crdcode>{txtcrdcode5.Text.Trim()}</crdcode>
<csource>{txtcsource5.Text.Trim()}</csource>
<cbuscode>{txtcbuscode5.Text.Trim()}</cbuscode>
<cmaker>{txtcmaker5.Text.Trim()}</cmaker>
<dnmaketime>{dpdnmaketime5.Text.Trim()}</dnmaketime>
<vt_id>{txtvt_id5.Text.Trim()}</vt_id>
<brdflag>{txtbrdflag5.Text.Trim()}</brdflag>
</row>
</table>
";

                    b = $@"<table>
     <row>
   <autoid>{txtautoid5.Text.Trim()}</autoid>
<cinvcode>{txtcinvcode5.Text.Trim()}</cinvcode>
<editprop>{txteditprop5.Text.Trim()}</editprop>
<iquantity>{txtiquantity5.Text.Trim()}</iquantity>
<cbatch>{txtcbatch5.Text.Trim()}</cbatch>
<cbaccounter>{txtcbaccounter5.Text.Trim()}</cbaccounter>
<cposition>{txtcposname5.Text.Trim()}</cposition>
<cdefine22>{txtcdefine225.Text.Trim()}</cdefine22>
<cdefine23>{txtcdefine235.Text.Trim()}</cdefine23>
<cdefine24>{txtcdefine245.Text.Trim()}</cdefine24>
<cdefine26>{txtcdefine265.Text.Trim()}</cdefine26>
 </row></table> ";

                    sVouchType = "08";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = SysParams.Instance.bIsRedVouch;
                    sAddedState = "";
                    bReMote = false; ;
                    OutputLog("=======================开始上传========================", mode, ToolTipIcon.None);
                    OutputLog("DomHead =" + h, mode, ToolTipIcon.None);
                    OutputLog("DomBody =" + b, mode, ToolTipIcon.None);
                    t = new Task(() =>
                    {
                        s = ir.otherinAdd(sVouchType,
                                  h, b,
                                    domPosition,
                                    out errMsg,
                                    cnnFromO,
                                    ref VouchId,
                                    out o,
                                    bCheck,
                                    bBeforCheckStock,
                                    bIsRedVouch,
                                    sAddedState,
                                    bReMote);
                    });
                    t.ContinueWith(c =>
                    {
                        try
                        {
                            if ((bool)s)
                            {
                                UpdateLog("提交成功" + "VouchId =" + VouchId, mode, ToolTipIcon.Info);
                            }
                            else
                            {
                                UpdateLog("提交失败：" + errMsg, mode, ToolTipIcon.Info);
                            }
                            if (domMsg != null)
                                UpdateLog((o as MSXML2.IXMLDOMDocument2).xml.ToString(), mode, ToolTipIcon.None);
                        }
                        catch
                        {
                            if (s == null)
                            {
                                UpdateLog("发生异常: s is null", mode, ToolTipIcon.None);
                            }
                            if (errMsg == null)
                            {
                                UpdateLog("发生异常:errMsg is null", mode, ToolTipIcon.None);
                            }
                            if (domMsg == null)
                                UpdateLog("发生异常:0 is null", mode, ToolTipIcon.None);
                        }
                        UpdateBtn(true);
                        UpdateLog("=======================结束===========================", "", ToolTipIcon.None);
                    });
                    t.Start();
                    break;
                #endregion 其他入库单
                #region 其他出库单
                //<ccode>1AQOT1APCM70321033</ccode>
                //<cwhname>M051</cwhname>      
                //<cinvcode>5122000000</cinvcode>
                //<editprop>A</editprop>
                case 6:
                    mode = "其他出库单";
                    h = $@"<table>
     <row>
<id>{txtid6.Text.Trim()}</id>
<ccode>{txtccode6.Text.Trim()}</ccode>
<ddate>{dpddate6.Text.Trim()}</ddate>
<cwhname>{txtcwhname6.Text.Trim()}</cwhname>
<cwhcode>{txtcwhname6.Text.Trim()}</cwhcode>
<cbustype>{txtcbustype6.Text.Trim()}</cbustype>
<cdepcode>0907</cdepcode>
<cpersoncode>000381</cpersoncode>
<crdcode>{txtcrdcode6.Text.Trim()}</crdcode>
<csource>{txtcsource6.Text.Trim()}</csource>
<cbuscode>{txtcbuscode6.Text.Trim()}</cbuscode>
<cmaker>{txtcmaker6.Text.Trim()}</cmaker>
<dnmaketime>{dpdnmaketime6.Text.Trim()}</dnmaketime>
<vt_id>{txtvt_id6.Text.Trim()}</vt_id>
<brdflag>{txtbrdflag6.Text.Trim()}</brdflag>
</row></table>
";

                    b = $@"<table>
<row>
<autoid>{txtautoid6.Text.Trim()}</autoid>
<cinvcode>{txtcinvcode6.Text.Trim()}</cinvcode>
<editprop>{txteditprop6.Text.Trim()}</editprop>
<iquantity>{txtiquantity6.Text.Trim()}</iquantity>
<cbatch>{txtcbatch6.Text.Trim()}</cbatch>
<cbaccounter>{txtcbaccounter5.Text.Trim()}</cbaccounter>
<cposition>{txtcposname6.Text.Trim()}</cposition>
<cdefine22>{txtcdefine226.Text.Trim()}</cdefine22>
<cdefine23>{txtcdefine236.Text.Trim()}</cdefine23>
<cdefine24>{txtcdefine246.Text.Trim()}</cdefine24>
<cdefine26>{txtcdefine266.Text.Trim()}</cdefine26>
 </row></table> ";

                    sVouchType = "09";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//

                    bIsRedVouch = SysParams.Instance.bIsRedVouch;
                    sAddedState = "";
                    bReMote = false;
                    OutputLog("=======================开始上传========================", "", ToolTipIcon.None);
                    OutputLog("DomHead =" + h, mode, ToolTipIcon.None);
                    OutputLog("DomBody =" + b, mode, ToolTipIcon.None);
                    t = new Task(() =>
                    {
                        s = ir.otheroutAdd(sVouchType,
                            h, b,
                              domPosition,
                              out errMsg,
                              cnnFromO,
                              ref VouchId,
                              out o,
                              bCheck,
                              bBeforCheckStock,
                              bIsRedVouch,
                              sAddedState,
                              bReMote);
                    });
                    t.ContinueWith(c =>
                    {
                        try
                        {
                            if ((bool)s)
                            {
                                UpdateLog("提交成功" + "VouchId =" + VouchId, mode, ToolTipIcon.Info);
                            }
                            else
                            {
                                UpdateLog("提交失败：" + errMsg, mode, ToolTipIcon.Info);
                            }
                            if (domMsg != null)
                                UpdateLog((o as MSXML2.IXMLDOMDocument2).xml.ToString(), mode, ToolTipIcon.None);
                        }
                        catch (Exception ex)
                        {
                            if (s == null)
                            {
                                UpdateLog("发生异常: s is null," + ex.Message, mode, ToolTipIcon.None);
                            }
                            if (errMsg == null)
                            {
                                UpdateLog("发生异常:errMsg is null," + ex.Message, mode, ToolTipIcon.None);
                            }
                            if (domMsg == null)
                                UpdateLog("发生异常:0 is null," + ex.Message, mode, ToolTipIcon.None);
                        }
                        UpdateBtn(true);
                        UpdateLog("=======================结束==========================", mode, ToolTipIcon.None);
                    });
                    t.Start();
                    break;
                #endregion 其他出库单
                #region 形态转换单
                //<ccode>1AQOT1APCM70321033</ccode>
                //<cwhname>M051</cwhname>      
                //<cinvcode>5122000000</cinvcode>
                //<editprop>A</editprop>
                case 12:
                    mode = "形态转换单";
                    h = $@"<table>
<row>
<id>{txtid7.Text.Trim()}</id>
<cavcode>{txtcavcode7.Text.Trim()}</cavcode>
<davdate>{dpdavdate7.Text.Trim()}</davdate>
<cdepcode>{txtcdepcode7.Text.Trim()}</cdepcode>
<cvouchtype>{txtcvouchtype7.Text.Trim()}</cvouchtype>
<cpersonname>{txtcpersonname7.Text.Trim()}</cpersonname>
<cirdcode>{txtcirdcode7.Text.Trim()}</cirdcode>
<cordcode>{txtcordcode7.Text.Trim()}</cordcode>
<cmaker>{txtcmaker7.Text.Trim()}</cmaker>
<dnmaketime>{dpdnmaketime7.Text.Trim()}</dnmaketime>
<vt_id>{txtvt_id7.Text.Trim()}</vt_id>
</row></table>
";

                    b = $@"<table>
<row>
<autoid>{txtautoid7.Text.Trim()}</autoid>
<cinvcode>{txtbcinvcode7.Text.Trim()}</cinvcode>
<editprop>{txteditprop7.Text.Trim()}</editprop>
<iavquantity>{txtiavquantity7.Text.Trim()}</iavquantity>
<bavtype>转换前</bavtype>
<cinvm_unit>{txtcinvm_unit7.Text.Trim()}</cinvm_unit>
<cavbatch>{txtbcavbatch7.Text.Trim()}</cavbatch>
<cwhcode>{txtbcwhcode7.Text.Trim()}</cwhcode>
<cdefine26>{txtcdefine267.Text.Trim()}</cdefine26>
<cposition>{txtbcposition7.Text.Trim()}</cposition>
</row>
<row>
<autoid>{txtautoid7.Text.Trim()}</autoid>
<cinvcode>{txtbcinvcode7.Text.Trim()}</cinvcode>
<editprop>{txteditprop7.Text.Trim()}</editprop>
<iavquantity>{txtiavquantity7.Text.Trim()}</iavquantity>
<bavtype>转换后</bavtype>
<cinvm_unit>{txtcinvm_unit7.Text.Trim()}</cinvm_unit>
<cavbatch>{txtacavbatch7.Text.Trim()}</cavbatch>
<cwhcode>{txtacwhcode7.Text.Trim()}</cwhcode>
<cdefine26>{txtcdefine267.Text.Trim()}</cdefine26>
<cposition>{txtacposition7.Text.Trim()}</cposition>
</row>
</table> ";

                    sVouchType = "15";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = SysParams.Instance.bIsRedVouch;
                    sAddedState = "";
                    bReMote = false; ;
                    OutputLog("=======================开始上传========================", mode, ToolTipIcon.None);
                    OutputLog("DomHead =" + h, mode, ToolTipIcon.None);
                    OutputLog("DomBody =" + b, mode, ToolTipIcon.None);
                    t = new Task(() =>
                    {
                        s = ir.ShapeChangVouchAdd(sVouchType,
                                  h, b,
                                    domPosition,
                                    out errMsg,
                                    cnnFromO,
                                    ref VouchId,
                                    out o,
                                    bCheck,
                                    bBeforCheckStock,
                                    bIsRedVouch,
                                    sAddedState,
                                    bReMote);
                    });
                    t.ContinueWith(c =>
                    {
                        try
                        {
                            if ((bool)s)
                            {
                                UpdateLog("提交成功" + "VouchId =" + VouchId, mode, ToolTipIcon.Info);
                            }
                            else
                            {
                                UpdateLog("提交失败：" + errMsg, mode, ToolTipIcon.Info);
                            }
                            if (domMsg != null)
                                UpdateLog((o as MSXML2.IXMLDOMDocument2).xml.ToString(), mode, ToolTipIcon.None);
                        }
                        catch
                        {
                            if (s == null)
                            {
                                UpdateLog("发生异常: s is null", mode, ToolTipIcon.None);
                            }
                            if (errMsg == null)
                            {
                                UpdateLog("发生异常:errMsg is null", mode, ToolTipIcon.None);
                            }
                            if (domMsg == null)
                                UpdateLog("发生异常:0 is null", mode, ToolTipIcon.None);
                        }
                        UpdateBtn(true);
                        UpdateLog("=======================结束===========================", "", ToolTipIcon.None);
                    });
                    t.Start();
                    break;
                #endregion 形态转换单              
            }
        }

        private void btn_WebConfirm_Click(object sender, RoutedEventArgs e)
        {
            btn_WebConfirm.IsEnabled = false;
            Web.IRAP_WebService client = new Web.IRAP_WebService();
            //IRAP_WebService s = new IRAP_WebService();
            string Excode = "";
            string h, b,mode="";
            switch (tabBo.SelectedIndex)
            {
                #region 材料出库
                case 0:
                    mode = "材料出库";
                    h = $@"<head><table>
<row>
<id>{txtid0.Text.Trim()}</id>
<cwhcode>{txtcwhname0.Text.Trim()}</cwhcode>
<cmpocode>{txtcmpocode0.Text.Trim()}</cmpocode>
<cmaker>{txtcmaker0.Text.Trim()}</cmaker>
<dnmaketime>{dpdnmaketime0.Text.Trim()}</dnmaketime>
<cbustype>{txtcbustype0.Text.Trim()}</cbustype>
<crdcode>{txtcrdname0.Text.Trim()}</crdcode>
<vt_id>{txtvt_id0.Text.Trim()}</vt_id>
<cdepcode>{txtcdepcode0.Text.Trim()}</cdepcode>
<ccode>{txtccode0.Text.Trim()}</ccode>
<ddate>{dpddate0.Text.Trim()}</ddate>
<cvencode>{txtcvencode0.Text.Trim()}</cvencode>
</row></table></head>";

                    b = $@"<body><table>
<row>
<autoid>1</autoid>
<cinvcode>{txtcinvcode0.Text.Trim()}</cinvcode>
<cbatch>{txtcbatch0.Text.Trim()}</cbatch>
<iquantity>{txtiquantity0.Text.Trim()}</iquantity>
<cmocode>{txtcmocode0.Text.Trim()}</cmocode>
<imoseq>{txtimoseq0.Text.Trim()}</imoseq>
<impoids>{txtimpoids0.Text.Trim()}</impoids>
<cposition>{txtcposname0.Text.Trim()}</cposition>
<cdefine22>{txtcdefine220.Text.Trim()}</cdefine22>
<cdefine23>{txtcdefine230.Text.Trim()}</cdefine23>
<cdefine24>{txtcdefine240.Text.Trim()}</cdefine24>
<cdefine26>{txtcdefine260.Text.Trim()}</cdefine26>
<comcode>{txtcomcode0.Text.Trim()}</comcode>
<iomodid>{txtiomodid0.Text.Trim()}</iomodid>
<iomomid>{txtiomomid0.Text.Trim()}</iomomid>
<editprop>{txteditprop0.Text.Trim()}</editprop>
</row></table></body>";
                    Excode = "<Parameters>"+
$"<Param Mode=\"MaterialOutAdd\" sAccID =\"{SysParams.Instance.U8VouchCode}\" sVouchType=\"11\" VouchId=\"11\" bCheck=\"{SysParams.Instance.bCheck}\" bBeforCheckStock=\"{SysParams.Instance.bBeforCheckStock}\" bIsRedVouch=\"{SysParams.Instance.bIsRedVouch}\" sAddedState=\"\" bReMote=\"false\">";
                    Excode += @"<body>      <table>        <row>          <autoid>1</autoid>          <cinvcode>XXXXXX</cinvcode>          <cbatch>20180510</cbatch>          <iquantity>1000</iquantity>          <cmocode />          <imoseq />          <impoids />          <cposition>N061</cposition>          <cdefine22 />          <cdefine23 />          <cdefine24 />          <cdefine26 />          <comcode />          <iomodid />          <iomomid />          <editprop>A</editprop>        </row>      </table>    </body>    <head>      <table>        <row>          <id>1</id>          <cwhcode />          <cmpocode>18010547</cmpocode>          <cmaker>000094</cmaker>          <dnmaketime>2018-05-10</dnmaketime>          <cbustype>领料</cbustype>          <crdcode />          <vt_id>65</vt_id>          <cdepcode>N060</cdepcode>          <ccode>65</ccode>          <ddate>2018-05-10</ddate>          <cvencode />        </row>      </table>    </head>  </Param></Parameters>";

                    break;
                #endregion                
                #region 产品入库
                case 1:
                    mode = "产品入库";
                    h = $@"&lt;table>
&lt;row&gt;
&lt;id&gt;{txtid1.Text.Trim()}&lt;/id&gt;
&lt;ccode&gt;{txtccode1.Text.Trim()}&lt;/ccode&gt;
&lt;ddate&gt;{dpddate1.Text.Trim()}&lt;/ddate&gt;
&lt;cwhcode&gt;{txtcwhname1.Text.Trim()}&lt;/cwhcode&gt;
&lt;cmpocode&gt;{txtcmpocode1.Text.Trim()}&lt;/cmpocode&gt;
&lt;crdcode&gt;{txtcrdname1.Text.Trim()}&lt;/crdcode&gt;
&lt;crdname&gt;{txtcrdname1.Text.Trim()}&lt;/crdname&gt;
&lt;cmaker&gt;{txtcmaker1.Text.Trim()}&lt;/cmaker&gt;
&lt;dnmaketime&gt;{dpdnmaketime1.Text.Trim()}&lt;/dnmaketime&gt;
&lt;cdepcode&gt;{txtcdepname1.Text.Trim()}&lt;/cdepcode&gt;
&lt;cbustype&gt;{txtcbustype1.Text.Trim()}&lt;/cbustype&gt;
&lt;iproorderid&gt;{txtimpoids1.Text.Trim()}&lt;/iproorderid&gt;
&lt;vt_id&gt;{txtvt_id1.Text.Trim()}&lt;/vt_id&gt;
&lt;cprobatch&gt;&lt;/cprobatch&gt;
&lt;csource&gt;生产订单&lt;/csource&gt;
&lt;/row&gt;&lt;/table&gt;
";

                    b = $@"&lt;table&gt;
&lt;row&gt;
&lt;autoid&gt;{txtautoid1.Text.Trim()}&lt;/autoid&gt;
&lt;cinvcode&gt;{txtcinvcode1.Text.Trim()}&lt;/cinvcode&gt;
&lt;cbatch&gt;{txtcbatch1.Text.Trim()}&lt;/cbatch&gt;
&lt;iquantity&gt;{txtiquantity1.Text.Trim()}&lt;/iquantity&gt;
&lt;cmocode&gt;{txtcmpocode1.Text.Trim()}&lt;/cmocode&gt;
&lt;imoseq&gt;{txtimoseq1.Text.Trim()}&lt;/imoseq&gt;
&lt;impoids&gt;{txtimpoids1.Text.Trim()}&lt;/impoids&gt;
&lt;cposition&gt;{txtcposname1.Text.Trim()}&lt;/cposition&gt;
&lt;cdefine22&gt;{txtcdefine221.Text.Trim()}&lt;/cdefine22&gt;
&lt;cdefine23&gt;{txtcdefine231.Text.Trim()}&lt;/cdefine23&gt;
&lt;cdefine24&gt;{txtcdefine241.Text.Trim()}&lt;/cdefine24&gt;
&lt;cdefine26&gt;{txtcdefine261.Text.Trim()}&lt;/cdefine26&gt;
&lt;editprop&gt;{txteditprop1.Text.Trim()}&lt;/editprop&gt;
&lt;/row&gt;&lt;/table&gt; ";
                    Excode = "<Parameters>" +
$"<Param Mode=\"ProductInAdd\" sAccID =\"{SysParams.Instance.U8VouchCode}\" sVouchType=\"10\" VouchId=\"10\" bCheck=\"{SysParams.Instance.bCheck}\" bBeforCheckStock=\"{SysParams.Instance.bBeforCheckStock}\" bIsRedVouch=\"{SysParams.Instance.bIsRedVouch}\" sAddedState=\"\" bReMote=\"false\" body=\"{b}\" head=\"{h}\"/>" +
                        "</Parameters>";

                break;
                #endregion
                #region 采购入库
                case 2:
                    mode = "采购入库";
                    h = $@"&lt;table&gt;
&lt;row&gt;
&lt;id&gt;{txtid2.Text.Trim()}&lt;/id&gt;
&lt;bomfirst&gt;{txtbomfirst2.Text.Trim()}&lt;/bomfirst&gt;
&lt;ccode&gt;{txtccode2.Text.Trim()}&lt;/ccode&gt;
&lt;ddate&gt;{dpddate2.Text.Trim()}&lt;/ddate&gt;
&lt;iverifystate&gt;{txtiverifystate2.Text.Trim()}&lt;/iverifystate&gt;
&lt;iswfcontrolled&gt;{txtiswfcontrolled2.Text.Trim()}&lt;/iswfcontrolled&gt;
&lt;cvenabbname&gt;{txtcvenabbname2.Text.Trim()}&lt;/cvenabbname&gt;
&lt;cbustype&gt;{txtcbustype2.Text.Trim()}&lt;/cbustype&gt;
&lt;cmaker&gt;{txtcmaker2.Text.Trim()}&lt;/cmaker&gt;
&lt;dnmaketime&gt;{dpdnmaketime2.Text.Trim()}&lt;/dnmaketime&gt;
&lt;iexchrate&gt;{txtiexchrate2.Text.Trim()}&lt;/iexchrate&gt;
&lt;cexch_name&gt;{txtcexch_name2.Text.Trim()}&lt;/cexch_name&gt;
&lt;ufts&gt;{txtufts2.Text.Trim()}&lt;/ufts&gt;
&lt;bpufirst&gt;{txtbpufirst2.Text.Trim()}&lt;/bpufirst&gt;
&lt;cvencode&gt;{txtcvencode2.Text.Trim()}&lt;/cvencode&gt;
&lt;cvouchtype&gt;{txtcvouchtype2.Text.Trim()}&lt;/cvouchtype&gt;
&lt;cwhcode&gt;{txtcwhcode2.Text.Trim()}&lt;/cwhcode&gt;
&lt;brdflag&gt;{txtbrdflag2.Text.Trim()}&lt;/brdflag&gt;
&lt;cdepcode&gt;{txtcdepcode2.Text.Trim()}&lt;/cdepcode&gt;
&lt;cpersoncode&gt;{txtcpersoncode2.Text.Trim()}&lt;/cpersoncode&gt;
&lt;crdcode&gt;{txtcrdcode2.Text.Trim()}&lt;/crdcode&gt;
&lt;vt_id&gt;{txtvt_id2.Text.Trim()}&lt;/vt_id&gt;
&lt;cvenpuomprotocol&gt;{txtcvenpuomprotocol2.Text.Trim()}&lt;/cvenpuomprotocol&gt;
&lt;cordercode&gt;{txtcordercode2.Text.Trim()}&lt;/cordercode&gt;
&lt;cptcode&gt;{txtcptcode2.Text.Trim()}&lt;/cptcode&gt;
&lt;csource&gt;{txtcsource2.Text.Trim()}&lt;/csource&gt;
&lt;ipurorderid&gt;{txtipurorderid2.Text.Trim()}&lt;/ipurorderid&gt;
&lt;bcredit&gt;{txtbcredit2.Text.Trim()}&lt;/bcredit&gt;
&lt;carvcode&gt;{txtcarvcode2.Text.Trim()}&lt;/carvcode&gt;
&lt;iarriveid&gt;{txtiarriveid2.Text.Trim()}&lt;/iarriveid&gt;
&lt;ipurarriveid&gt;{txtipurarriveid2.Text.Trim()}&lt;/ipurarriveid&gt;
&lt;/row&gt;&lt;/table&gt;";

                    b = $@"&lt;table&gt;
&lt;row&gt;
&lt;autoid&gt;{txtautoid2.Text.Trim()}&lt;/autoid&gt;
&lt;id&gt;{txtfid2.Text.Trim()}&lt;/id&gt;
&lt;cinvcode&gt;{txtcinvcode2.Text.Trim()}&lt;/cinvcode&gt;
&lt;cinvm_unit&gt;{txtcinvm_unit2.Text.Trim()}&lt;/cinvm_unit&gt;
&lt;iquantity&gt;{txtiquantity2.Text.Trim()}&lt;/iquantity&gt;
&lt;editprop&gt;{txteditprop2.Text.Trim()}&lt;/editprop&gt;
&lt;iMatSettleState&gt;{txtiMatSettleState.Text.Trim()}&lt;/iMatSettleState&gt;
&lt;iposid&gt;{txtiposid2.Text.Trim()}&lt;/iposid&gt;
&lt;cpoid&gt;{txtcpoid2.Text.Trim()}&lt;/cpoid&gt;
&lt;cbatch&gt;{txtcbatch2.Text.Trim()}&lt;/cbatch&gt;
&lt;cposition&gt;{txtcposname2.Text.Trim()}&lt;/cposition&gt;
&lt;cdefine22&gt;{txtcdefine222.Text.Trim()}&lt;/cdefine22&gt;
&lt;cdefine23&gt;{txtcdefine232.Text.Trim()}&lt;/cdefine23&gt;
&lt;cdefine26&gt;{txtcdefine262.Text.Trim()}&lt;/cdefine26&gt;
&lt;isotype&gt;{txtisotype2.Text.Trim()}&lt;/isotype&gt;
&lt;btaxcost&gt;{txtbtaxcost2.Text.Trim()}&lt;/btaxcost&gt;
&lt;iunitcost&gt;{txtiunitcost2.Text.Trim()}&lt;/iunitcost&gt;
&lt;corufts&gt;{txtcorufts2.Text.Trim()}&lt;/corufts&gt;
&lt;ioritaxcost&gt;{txtioritaxcost2.Text.Trim()}&lt;/ioritaxcost&gt;
&lt;ioricost&gt;{txtioricost2.Text.Trim()}&lt;/ioricost&gt;
&lt;iorimoney&gt;{txtiorimoney2.Text.Trim()}&lt;/iorimoney&gt;
&lt;ioritaxprice&gt;{txtioritaxprice2.Text.Trim()}&lt;/ioritaxprice&gt;
&lt;iorisum&gt;{txtiorisum2.Text.Trim()}&lt;/iorisum&gt;
&lt;itaxrate&gt;{txtitaxrate2.Text.Trim()}&lt;/itaxrate&gt;
&lt;itaxprice&gt;{txtitaxprice2.Text.Trim()}&lt;/itaxprice&gt;
&lt;isum&gt;{txtisum2.Text.Trim()}&lt;/isum&gt;
&lt;facost&gt;{txtfacost2.Text.Trim()}&lt;/facost&gt;
&lt;iaprice&gt;{txtiaprice2.Text.Trim()}&lt;/iaprice&gt;
&lt;cbarvcode&gt;{txtcarvcode2.Text.Trim()}&lt;/cbarvcode&gt;
&lt;iarrsid&gt;{txtiarrsid2.Text.Trim()}&lt;/iarrsid&gt;
&lt;/row&gt;&lt;/table&gt;";

                    Excode = "<Parameters>" +
$"<Param Mode=\"PuStoreInAdd\" sAccID =\"{SysParams.Instance.U8VouchCode}\" sVouchType=\"01\" VouchId=\"01\" bCheck=\"{SysParams.Instance.bCheck}\" bBeforCheckStock=\"{SysParams.Instance.bBeforCheckStock}\" bIsRedVouch=\"{SysParams.Instance.bIsRedVouch}\" sAddedState=\"\" bReMote=\"false\" body=\"{b}\" head=\"{h}\"/>" +
                        "</Parameters>";
                    break;
                #endregion
                #region 调拨
                case 3:
                    mode = "调拨";
                    h = $@"&lt;table&gt;
&lt;row&gt;
&lt;id&gt;{txtid3.Text.Trim()}&lt;/id&gt;
&lt;ctvcode&gt;{txtctvcode3.Text.Trim()}&lt;/ctvcode&gt;
&lt;dtvdate&gt;{dpdtvdate3.Text.Trim()}&lt;/dtvdate&gt;
&lt;codepcode&gt;{txtcodepcode3.Text.Trim()}&lt;/codepcode&gt;
&lt;cidepcode&gt;{txtcidepcode3.Text.Trim()}&lt;/cidepcode&gt;
&lt;cirdcode&gt;{txtcirdcode3.Text.Trim()}&lt;/cirdcode&gt;
&lt;cordcode&gt;{txtcordcode3.Text.Trim()}&lt;/cordcode&gt;
&lt;csource&gt;{txtcsource3.Text.Trim()}&lt;/csource&gt;
&lt;cmaker&gt;{txtcmaker3.Text.Trim()}&lt;/cmaker&gt;
&lt;dnmaketime&gt;{dpdnmaketime3.Text.Trim()}&lt;/dnmaketime&gt;
&lt;vt_id&gt;{txtvt_id3.Text.Trim()}&lt;/vt_id&gt;
&lt;iproorderid&gt;{txtiproorderid3.Text.Trim()}&lt;/iproorderid&gt;
&lt;cowhcode&gt;{txtcowhcode3.Text.Trim()}&lt;/cowhcode&gt;
&lt;ciwhcode&gt;{txtciwhcode3.Text.Trim()}&lt;/ciwhcode&gt;
&lt;ctranrequestcode&gt;{txtctranrequestcode3.Text.Trim()}&lt;/ctranrequestcode&gt;
&lt;itransflag&gt;{txtitransflag3.Text.Trim()}&lt;/itransflag&gt;
&lt;/row&gt;&lt;/table&gt;
";

                    b = $@"&lt;table&gt;
&lt;row&gt;
&lt;autoid&gt;{txtautoid3.Text.Trim()}&lt;/autoid&gt;
&lt;cinvcode&gt;{txtcinvcode3.Text.Trim()}&lt;/cinvcode&gt;
&lt;editprop&gt;{txteditprop3.Text.Trim()}&lt;/editprop&gt;
&lt;itvquantity&gt;{txtitvquantity3.Text.Trim()}&lt;/itvquantity&gt;
&lt;cinvm_unit&gt;{txtcinvm_unit3.Text.Trim()}&lt;/cinvm_unit&gt;
&lt;cmocode&gt;{txtcmocode3.Text.Trim()}&lt;/cmocode&gt;
&lt;imoseq&gt;{txtimoseq3.Text.Trim()}&lt;/imoseq&gt;
&lt;impoids&gt;{txtimpoids3.Text.Trim()}&lt;/impoids&gt;
&lt;coutposcode&gt;{txtcoutposcode3.Text.Trim()}&lt;/coutposcode&gt;
&lt;cinposcode&gt;{txtcinposcode3.Text.Trim()}&lt;/cinposcode&gt;
&lt;ctvbatch&gt;{txtctvbatch3.Text.Trim()}&lt;/ctvbatch&gt;
&lt;itrids&gt;{txtitrids3.Text.Trim()}&lt;/itrids&gt;
&lt;cdefine26&gt;{txtcdefine263.Text.Trim()}&lt;/cdefine26&gt;
&lt;/row&gt;&lt;/table&gt; ";

                    Excode = "<Parameters>" +
$"<Param Mode=\"TransVouchAdd\" sAccID =\"{SysParams.Instance.U8VouchCode}\" sVouchType=\"12\" VouchId=\"12\" bCheck=\"true\" bBeforCheckStock=\"false\" bIsRedVouch=\"{SysParams.Instance.bIsRedVouch}\" sAddedState=\" \" bReMote=\"false\" body=\"{b}\" head=\"{h}\"/>" +
                        "</Parameters>";
                    break;
                #endregion
                #region 销售出库
                case 4:
                    mode = "销售出库";
                    h = $@"&lt;table&gt;
&lt;row&gt;
&lt;id&gt;{txtid4.Text.Trim()}&lt;/id&gt;
&lt;ccode&gt;{txtccode4.Text.Trim()}&lt;/ccode&gt;
&lt;ddate&gt;{dpddate4.Text.Trim()}&lt;/ddate&gt;
&lt;cbustype&gt;{txtcbustype4.Text.Trim()}&lt;/cbustype&gt;
&lt;iverifystate&gt;{txtiverifystate4.Text.Trim()}&lt;/iverifystate&gt;
&lt;iswfcontrolled&gt;{txtiswfcontrolled4.Text.Trim()}&lt;/iswfcontrolled&gt;
&lt;ccusabbname&gt;{txtccusabbname4.Text.Trim()}&lt;/ccusabbname&gt;
&lt;cmaker&gt;{txtcmaker4.Text.Trim()}&lt;/cmaker&gt;
&lt;dnmaketime&gt;{dpdnmaketime4.Text.Trim()}&lt;/dnmaketime&gt;
&lt;ufts&gt;{txtufts4.Text.Trim()}&lt;/ufts&gt;
&lt;cvouchtype&gt;{txtcvouchtype4.Text.Trim()}&lt;/cvouchtype&gt;
&lt;cwhcode&gt;{txtcwhcode4.Text.Trim()}&lt;/cwhcode&gt;
&lt;csource&gt;{txtcsource4.Text.Trim()}&lt;/csource&gt;
&lt;brdflag&gt;{txtbrdflag4.Text.Trim()}&lt;/brdflag&gt;
&lt;ccuscode&gt;{txtccuscode4.Text.Trim()}&lt;/ccuscode&gt;
&lt;bisstqc&gt;{txtbisstqc4.Text.Trim()}&lt;/bisstqc&gt;
&lt;cbuscode&gt;{txtcbuscode4.Text.Trim()}&lt;/cbuscode&gt;
&lt;cstcode&gt;{txtcstcode4.Text.Trim()}&lt;/cstcode&gt;
&lt;vt_id&gt;{txtvt_id4.Text.Trim()}&lt;/vt_id&gt;
&lt;cdepcode&gt;{txtcdepcode4.Text.Trim()}&lt;/cdepcode&gt;
&lt;crdcode&gt;{txtcrdcode4.Text.Trim()}&lt;/crdcode&gt;
&lt;cdlcode&gt;{txtcdlcode4.Text.Trim()}&lt;/cdlcode&gt;
&lt;iarriveid&gt;{txtiarriveid4.Text.Trim()}&lt;/iarriveid&gt;
&lt;/row&gt;
&lt;/table&gt;
";

                    b = $@"&lt;table&gt;
&lt;row&gt;
&lt;autoid&gt;{txtautoid4.Text.Trim()}&lt;/autoid&gt;
&lt;cinvm_unit&gt;{txtcinvm_unit4.Text.Trim()}&lt;/cinvm_unit&gt;
&lt;iquantity&gt;{txtiquantity4.Text.Trim()}&lt;/iquantity&gt;
&lt;cinvcode&gt;{txtcinvcode4.Text.Trim()}&lt;/cinvcode&gt;
&lt;id&gt;{txtfid4.Text.Trim()}&lt;/id&gt;
&lt;editprop&gt;{txteditprop4.Text.Trim()}&lt;/editprop&gt;
&lt;cposition&gt;{txtcposname4.Text.Trim()}&lt;/cposition&gt;
&lt;cdefine22&gt;{txtcdefine224.Text.Trim()}&lt;/cdefine22&gt;
&lt;cdefine23&gt;{txtcdefine234.Text.Trim()}&lt;/cdefine23&gt;
&lt;cdefine24&gt;{txtcdefine244.Text.Trim()}&lt;/cdefine24&gt;
&lt;cdefine26&gt;{txtcdefine264.Text.Trim()}&lt;/cdefine26&gt;
&lt;cinvaddcode&gt;{txtcinvaddcode4.Text.Trim()}&lt;/cinvaddcode&gt;
&lt;cinvname&gt;{txtcinvcode4.Text.Trim()}&lt;/cinvname&gt;
&lt;cbatch&gt;{txtcbatch4.Text.Trim()}&lt;/cbatch&gt;
&lt;idlsid&gt;{txtidlsid4.Text.Trim()}&lt;/idlsid&gt;
&lt;cbdlcode&gt;{txtcbdlcode4.Text.Trim()}&lt;/cbdlcode&gt;
&lt;iprice&gt;{txtiprice4.Text.Trim()}&lt;/iprice&gt;
&lt;iunitcost&gt;{txtiunitcost4.Text.Trim()}&lt;/iunitcost&gt;
&lt;iordercode&gt;{txtiordercode4.Text.Trim()}&lt;/iordercode&gt;
&lt;isodid&gt;{txtisodid4.Text.Trim()}&lt;/isodid&gt;
&lt;iordertype&gt;{txtiordertype4.Text.Trim()}&lt;/iordertype&gt;
&lt;iorderdid&gt;{txtiorderdid4.Text.Trim()}&lt;/iorderdid&gt;
 &lt;/row&gt;&lt;/table&gt; ";

                    Excode = "<Parameters>" +
$"<Param Mode=\"saleoutAdd\" sAccID =\"{SysParams.Instance.U8VouchCode}\" sVouchType=\"32\" VouchId=\"32\" bCheck=\"true\" bBeforCheckStock=\"false\" bIsRedVouch=\"{SysParams.Instance.bIsRedVouch}\" sAddedState=\" \" bReMote=\"false\" body=\"{b}\" head=\"{h}\"/>" +
                        "</Parameters>";
                    break;
                #endregion
                #region 其他入库单
                case 5:
                    mode = "其他入库单";
                    h = $@"&lt;table&gt;
     &lt;row&gt;
&lt;id&gt;{txtid5.Text.Trim()}&lt;/id&gt;
&lt;ccode&gt;{txtccode5.Text.Trim()}&lt;/ccode&gt;
&lt;ddate&gt;{dpddate5.Text.Trim()}&lt;/ddate&gt;
&lt;cwhname&gt;{txtcwhname5.Text.Trim()}&lt;/cwhname&gt;
&lt;cwhcode&gt;{txtcwhname5.Text.Trim()}&lt;/cwhcode&gt;
&lt;cbustype&gt;{txtcbustype5.Text.Trim()}&lt;/cbustype&gt;
&lt;cdepcode&gt;{txtcdepcode5.Text.Trim()}&lt;/cdepcode&gt;
&lt;cpersoncode&gt;000381&lt;/cpersoncode&gt;
&lt;crdcode&gt;{txtcrdcode5.Text.Trim()}&lt;/crdcode&gt;
&lt;csource&gt;{txtcsource5.Text.Trim()}&lt;/csource&gt;
&lt;cbuscode&gt;{txtcbuscode5.Text.Trim()}&lt;/cbuscode&gt;
&lt;cmaker&gt;{txtcmaker5.Text.Trim()}&lt;/cmaker&gt;
&lt;dnmaketime&gt;{dpdnmaketime5.Text.Trim()}&lt;/dnmaketime&gt;
&lt;vt_id&gt;{txtvt_id5.Text.Trim()}&lt;/vt_id&gt;
&lt;brdflag&gt;{txtbrdflag5.Text.Trim()}&lt;/brdflag&gt;
&lt;/row&gt;
&lt;/table&gt;
";

                    b = $@"&lt;table&gt;
     &lt;row&gt;
   &lt;autoid&gt;{txtautoid5.Text.Trim()}&lt;/autoid&gt;
&lt;cinvcode&gt;{txtcinvcode5.Text.Trim()}&lt;/cinvcode&gt;
&lt;editprop&gt;{txteditprop5.Text.Trim()}&lt;/editprop&gt;
&lt;iquantity&gt;{txtiquantity5.Text.Trim()}&lt;/iquantity&gt;
&lt;cbatch&gt;{txtcbatch5.Text.Trim()}&lt;/cbatch&gt;
&lt;cbaccounter&gt;{txtcbaccounter5.Text.Trim()}&lt;/cbaccounter&gt;
&lt;cposition&gt;{txtcposname5.Text.Trim()}&lt;/cposition&gt;
&lt;cdefine22&gt;{txtcdefine225.Text.Trim()}&lt;/cdefine22&gt;
&lt;cdefine23&gt;{txtcdefine235.Text.Trim()}&lt;/cdefine23&gt;
&lt;cdefine24&gt;{txtcdefine245.Text.Trim()}&lt;/cdefine24&gt;
&lt;cdefine26&gt;{txtcdefine265.Text.Trim()}&lt;/cdefine26&gt;
 &lt;/row&gt;&lt;/table&gt; ";

                    Excode = "<Parameters>" +
$"<Param Mode=\"otherinAdd\" sAccID =\"{SysParams.Instance.U8VouchCode}\" sVouchType=\"08\" VouchId=\"08\" bCheck=\"true\" bBeforCheckStock=\"false\" bIsRedVouch=\"{SysParams.Instance.bIsRedVouch}\" sAddedState=\" \" bReMote=\"false\" body=\"{b}\" head=\"{h}\"/>" +
                        "</Parameters>";
                    break;
                #endregion
                #region 其他出库单
                case 6:
                    mode = "其他出库单";
                    h = $@"&lt;table&gt;
     &lt;row&gt;
&lt;id&gt;{txtid6.Text.Trim()}&lt;/id&gt;
&lt;ccode&gt;{txtccode6.Text.Trim()}&lt;/ccode&gt;
&lt;ddate&gt;{dpddate6.Text.Trim()}&lt;/ddate&gt;
&lt;cwhname&gt;{txtcwhname6.Text.Trim()}&lt;/cwhname&gt;
&lt;cwhcode&gt;{txtcwhname6.Text.Trim()}&lt;/cwhcode&gt;
&lt;cbustype&gt;{txtcbustype6.Text.Trim()}&lt;/cbustype&gt;
&lt;cdepcode&gt;{txtcdepcode6.Text.Trim()}&lt;/cdepcode&gt;
&lt;cpersoncode&gt;000381&lt;/cpersoncode&gt;
&lt;crdcode&gt;{txtcrdcode6.Text.Trim()}&lt;/crdcode&gt;
&lt;csource&gt;{txtcsource6.Text.Trim()}&lt;/csource&gt;
&lt;cbuscode&gt;{txtcbuscode6.Text.Trim()}&lt;/cbuscode&gt;
&lt;cmaker&gt;{txtcmaker6.Text.Trim()}&lt;/cmaker&gt;
&lt;dnmaketime&gt;{dpdnmaketime6.Text.Trim()}&lt;/dnmaketime&gt;
&lt;vt_id&gt;{txtvt_id6.Text.Trim()}&lt;/vt_id&gt;
&lt;brdflag&gt;{txtbrdflag6.Text.Trim()}&lt;/brdflag&gt;
&lt;/row&gt;
&lt;/table&gt;
";

                    b = $@"&lt;table&gt;
     &lt;row&gt;
   &lt;autoid&gt;{txtautoid6.Text.Trim()}&lt;/autoid&gt;
&lt;cinvcode&gt;{txtcinvcode6.Text.Trim()}&lt;/cinvcode&gt;
&lt;editprop&gt;{txteditprop6.Text.Trim()}&lt;/editprop&gt;
&lt;iquantity&gt;{txtiquantity6.Text.Trim()}&lt;/iquantity&gt;
&lt;cbatch&gt;{txtcbatch6.Text.Trim()}&lt;/cbatch&gt;
&lt;cbaccounter&gt;{txtcbaccounter6.Text.Trim()}&lt;/cbaccounter&gt;
&lt;cposition&gt;{txtcposname6.Text.Trim()}&lt;/cposition&gt;
&lt;cdefine22&gt;{txtcdefine226.Text.Trim()}&lt;/cdefine22&gt;
&lt;cdefine23&gt;{txtcdefine236.Text.Trim()}&lt;/cdefine23&gt;
&lt;cdefine24&gt;{txtcdefine246.Text.Trim()}&lt;/cdefine24&gt;
&lt;cdefine26&gt;{txtcdefine266.Text.Trim()}&lt;/cdefine26&gt;
 &lt;/row&gt;&lt;/table&gt; ";

                    Excode = "<Parameters>" +
$"<Param Mode=\"otheroutAdd\" sAccID =\"{SysParams.Instance.U8VouchCode}\" sVouchType=\"09\" VouchId=\"09\" bCheck=\"true\" bBeforCheckStock=\"false\" bIsRedVouch=\"{SysParams.Instance.bIsRedVouch}\" sAddedState=\" \" bReMote=\"false\" body=\"{b}\" head=\"{h}\"/>" +
                        "</Parameters>";
                    break;
                #endregion
                #region 形态转换
                case 7:
                    mode = "形态转换";
                    h = $@"<head><table>
<row>
<id>{txtid7.Text.Trim()}</id>
<cavcode>{txtcavcode7.Text.Trim()}</cavcode>
<davdate>{dpdavdate7.Text.Trim()}</davdate>
<cdepcode>{txtcdepcode7.Text.Trim()}</cdepcode>
<cvouchtype>{txtcvouchtype7.Text.Trim()}</cvouchtype>
<cpersonname>{txtcpersonname7.Text.Trim()}</cpersonname>
<cirdcode>{txtcirdcode7.Text.Trim()}</cirdcode>
<cordcode>{txtcordcode7.Text.Trim()}</cordcode>
<btransflag>0</btransflag>
<cmaker>{txtcmaker7.Text.Trim()}</cmaker>
<dnmaketime>{dpdnmaketime7.Text.Trim()}</dnmaketime>
<vt_id>{txtvt_id7.Text.Trim()}</vt_id>
</row></table></head>
";

                    b = $@"<body><table>
                    <row>
                    <autoid>{txtautoid7.Text.Trim()}</autoid>
                    <cinvcode>{txtbcinvcode7.Text.Trim()}</cinvcode>
                    <editprop>{txteditprop7.Text.Trim()}</editprop>
                    <iavquantity>{txtiavquantity7.Text.Trim()}</iavquantity>
                    <bavtype>转换前</bavtype>
                    <cinvm_unit>{txtcinvm_unit7.Text.Trim()}</cinvm_unit>
                    <cavbatch>{txtbcavbatch7.Text.Trim()}</cavbatch>
                    <cwhcode>{txtbcwhcode7.Text.Trim()}</cwhcode>
                    <cdefine26>{txtcdefine267.Text.Trim()}</cdefine26>
<cavcode>0</cavcode>
                    </row>
                    
<row>
<autoid>{txtautoid7.Text.Trim()}</autoid>
<cinvcode>{txtacinvcode7.Text.Trim()}</cinvcode>
<editprop>{txteditprop7.Text.Trim()}</editprop>
<iavquantity>{txtiavquantity7.Text.Trim()}</iavquantity>
<bavtype>转换后</bavtype>
<cinvm_unit>{txtcinvm_unit7.Text.Trim()}</cinvm_unit>
<cavbatch>{txtacavbatch7.Text.Trim()}</cavbatch>
<cwhcode>{txtacwhcode7.Text.Trim()}</cwhcode>
<cdefine26>{txtcdefine267.Text.Trim()}</cdefine26>
<cavcode>0</cavcode>
</row>
</table></body>";

                    Excode = "<Parameters>" +
$"<Param Mode=\"ShapeChangVouchAdd\" sAccID =\"{SysParams.Instance.U8VouchCode}\" sVouchType=\"15\" VouchId=\"15\" bCheck=\"true\" bBeforCheckStock=\"false\" bIsRedVouch=\"{SysParams.Instance.bIsRedVouch}\" sAddedState=\" \" bReMote=\"false\">"+
    b+h +
                        "</Param></Parameters>";
                    break;
                #endregion
                #region 审计
                case 8:
                    AuditMode m = cboMode.SelectedItem as AuditMode;
                    mode = m.Name;                  
                    Excode = "<Parameters>" +
$"<Param Mode=\"{m.Mode}\" sAccID =\"{SysParams.Instance.U8VouchCode}\" sVouchType=\"{m.VouchType.ToString()}\" VouchId=\"{txtVouchId.Text.Trim()}\" bCheck=\"{SysParams.Instance.bCheck}\" bBeforCheckStock=\"{SysParams.Instance.bBeforCheckStock}\"/>" +
                        "</Parameters>";

                    break;
                    #endregion

            }
            OutputLog(Excode,mode,ToolTipIcon.None);
            try
            {
                OutputLog(ZipUtil.UnZip(client.IRAPUES(ZipUtil.Zip(Excode))), mode, ToolTipIcon.Info);
            }
            catch(Exception ex)
            {
                OutputLog(ex.Message, mode, ToolTipIcon.Error);
            }
            finally
            {
                btn_WebConfirm.IsEnabled = true;
            }
        }

        private void cboMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtVouchType.Text = (cboMode.SelectedItem as AuditMode).VouchType.ToString();
        }
    }
}
