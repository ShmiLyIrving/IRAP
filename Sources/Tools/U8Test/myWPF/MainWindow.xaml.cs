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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadConfig();
                AddTrayIcon();
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
<editprop>A</editprop>
</row></table> ";


                    sVouchType = "11";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = false;
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
                                UpdateLog("提交成功", mode, ToolTipIcon.Info);
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
</row></table> ";

                    sVouchType = "10";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = false;
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
                                UpdateLog("提交成功", mode, ToolTipIcon.Info);
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
<cdefine24>{txtcdefine242.Text.Trim()}</cdefine24>
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
                    bIsRedVouch = false;
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
                                UpdateLog("提交成功", mode, ToolTipIcon.Info);
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
</row></table> ";

                    sVouchType = "12";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = false;
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
                            UpdateLog("提交成功", mode, ToolTipIcon.Info);
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
 </row></table> ";

                    sVouchType = "32";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = false;
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
                                UpdateLog("提交成功", mode, ToolTipIcon.Info);
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
 </row></table> ";

                    sVouchType = "08";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = false;
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
                                UpdateLog("提交成功", mode, ToolTipIcon.Info);
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
                    mode = "材料出库";
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
 </row></table> ";

                    sVouchType = "09";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//

                    bIsRedVouch = false;
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
                                UpdateLog("提交成功", mode, ToolTipIcon.Info);
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
                case 7:
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
<cinvcode>{txtcinvcode7.Text.Trim()}</cinvcode>
<editprop>{txteditprop7.Text.Trim()}</editprop>
<iavquantity>{txtiavquantity7.Text.Trim()}</iavquantity>
<bavtype>{txtbavtype7.Text.Trim()}</bavtype>
<cinvm_unit>{txtcinvm_unit7.Text.Trim()}</cinvm_unit>
<cavbatch>{txtcavbatch7.Text.Trim()}</cavbatch>
<cwhcode>{txtcwhcode7.Text.Trim()}</cwhcode>
</row></table> ";

                    sVouchType = "15";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//
                    bIsRedVouch = false;
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
                                UpdateLog("提交成功", mode, ToolTipIcon.Info);
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
                #region 审计
                case 8:
                    mode = "审计";                    
                    sVouchType = "11";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "1000009997";//

                    OutputLog("=======================开始上传========================", mode, ToolTipIcon.None);
                    t = new Task(() =>
                    {
                        s = ir.MaterialOutAudit("333",
                                    sVouchType,
                                    out errMsg,
                                    cnnFromO,
                                    VouchId,
                                    out o,
                                    bCheck,
                                    bBeforCheckStock);
                    });
                    t.ContinueWith(c =>
                    {
                        try
                        {
                            if ((bool)s)
                            {
                                UpdateLog("提交成功", mode, ToolTipIcon.Info);
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
#endregion

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
                    h = $@"&lt;table&gt;
&lt;row&gt;
&lt;id&gt;{txtid0.Text.Trim()}&lt;/id&gt;
&lt;cwhcode&gt;{txtcwhname0.Text.Trim()}&lt;/cwhcode&gt;
&lt;cmpocode&gt;{txtcmpocode0.Text.Trim()}&lt;/cmpocode&gt;
&lt;iproorderid&gt;{txtimpoids0.Text.Trim()}&lt;/iproorderid&gt;
&lt;cmaker&gt;{txtcmaker0.Text.Trim()}&lt;/cmaker&gt;
&lt;dnmaketime&gt;{dpdnmaketime0.Text.Trim()}&lt;/dnmaketime&gt;
&lt;cbustype&gt;{txtcbustype0.Text.Trim()}&lt;/cbustype&gt;
&lt;crdcode&gt;{txtcrdname0.Text.Trim()}&lt;/crdcode&gt;
&lt;vt_id&gt;{txtvt_id0.Text.Trim()}&lt;/vt_id&gt;
&lt;cdepcode&gt;0907&lt;/cdepcode&gt;
&lt;cCode&gt;{txtccode0.Text.Trim()}&lt;/cCode&gt;
&lt;dDate&gt;{dpddate0.Text.Trim()}&lt;/dDate&gt;
&lt;/row&gt;&lt;/table&gt;";

                    b = $@"&lt;table&gt;
&lt;row&gt;
&lt;autoid&gt;1&lt;/autoid&gt;
&lt;cinvcode&gt;{txtcinvcode0.Text.Trim()}&lt;/cinvcode&gt;
&lt;cbatch&gt;{txtcbatch0.Text.Trim()}&lt;/cbatch&gt;
&lt;iquantity&gt;{txtiquantity0.Text.Trim()}&lt;/iquantity&gt;
&lt;cmocode&gt;{txtcmpocode0.Text.Trim()}&lt;/cmocode&gt;
&lt;imoseq&gt;{txtimoseq0.Text.Trim()}&lt;/imoseq&gt;
&lt;impoids&gt;{txtimpoids0.Text.Trim()}&lt;/impoids&gt;
&lt;cposition&gt;{txtcposname0.Text.Trim()}&lt;/cposition&gt;
&lt;cdefine22&gt;{txtcdefine220.Text.Trim()}&lt;/cdefine22&gt;
&lt;cdefine23&gt;{txtcdefine230.Text.Trim()}&lt;/cdefine23&gt;
&lt;cdefine24&gt;{txtcdefine240.Text.Trim()}&lt;/cdefine24&gt;
&lt;/row&gt;&lt;/table&gt;";
                    Excode = "<Parameters>"+
$"<Param Mode=\"MaterialOutAdd\" sAccID =\"333\" sVouchType=\"11\" VouchId=\"11\" bCheck=\"{SysParams.Instance.bCheck}\" bBeforCheckStock=\"{SysParams.Instance.bBeforCheckStock}\" bIsRedVouch=\"false\" sAddedState=\"\" bReMote=\"true\" body=\"{b}\" head=\"{h}\"/>" +
                        "</Parameters>";

                    break;
                #endregion                
                #region 产品入库
                case 1:
                    mode = "产品入库";
                    h = $@"&lt;table&gt;
&lt;row&gt;
&lt;id&gt;{txtid0.Text.Trim()}&lt;/id&gt;
&lt;cwhcode&gt;{txtcwhname0.Text.Trim()}&lt;/cwhcode&gt;
&lt;cmpocode&gt;{txtcmpocode0.Text.Trim()}&lt;/cmpocode&gt;
&lt;iproorderid&gt;{txtimpoids0.Text.Trim()}&lt;/iproorderid&gt;
&lt;cmaker&gt;{txtcmaker0.Text.Trim()}&lt;/cmaker&gt;
&lt;dnmaketime&gt;{dpdnmaketime0.Text.Trim()}&lt;/dnmaketime&gt;
&lt;cbustype&gt;{txtcbustype0.Text.Trim()}&lt;/cbustype&gt;
&lt;crdcode&gt;{txtcrdname0.Text.Trim()}&lt;/crdcode&gt;
&lt;vt_id&gt;{txtvt_id0.Text.Trim()}&lt;/vt_id&gt;
&lt;cdepcode&gt;0907&lt;/cdepcode&gt;
&lt;dDate&gt;{dpddate0.Text.Trim()}&lt;/dDate&gt;
&lt;cCode&gt;{txtccode0.Text.Trim()}&lt;/cCode&gt;
&lt;/row&gt;&lt;/table&gt;";

                    b = $@"&lt;table&gt;
&lt;row&gt;
&lt;autoid&gt;1&lt;/autoid&gt;
&lt;cinvcode&gt;{txtcinvcode0.Text.Trim()}&lt;/cinvcode&gt;
&lt;cbatch&gt;{txtcbatch0.Text.Trim()}&lt;/cbatch&gt;
&lt;iquantity&gt;{txtiquantity0.Text.Trim()}&lt;/iquantity&gt;
&lt;cmocode&gt;{txtcmpocode0.Text.Trim()}&lt;/cmocode&gt;
&lt;imoseq&gt;{txtimoseq0.Text.Trim()}&lt;/imoseq&gt;
&lt;impoids&gt;{txtimpoids0.Text.Trim()}&lt;/impoids&gt;
&lt;cposition&gt;{txtcposname0.Text.Trim()}&lt;/cposition&gt;
&lt;cdefine22&gt;{txtcdefine220.Text.Trim()}&lt;/cdefine22&gt;
&lt;cdefine23&gt;{txtcdefine230.Text.Trim()}&lt;/cdefine23&gt;
&lt;cdefine24&gt;{txtcdefine240.Text.Trim()}&lt;/cdefine24&gt;
&lt;/row&gt;&lt;/table&gt;";
                    Excode = "<Parameters>" +
$"<Param Mode=\"MaterialOutAdd\" sAccID =\"333\" sVouchType=\"11\" VouchId=\"11\" bCheck=\"{SysParams.Instance.bCheck}\" bBeforCheckStock=\"{SysParams.Instance.bBeforCheckStock}\" bIsRedVouch=\"false\" sAddedState=\"\" bReMote=\"true\" body=\"{b}\" head=\"{h}\"/>" +
                        "</Parameters>";

                    break;
                #endregion
                #region 调拨
                case 3:
                    mode = "调拨";
                    h = $@"                
                &lt;table&gt;
                &lt;row&gt;
                &lt;id&gt;&lt;/id&gt;
                &lt;ctvcode&gt;1&lt;/ctvcode&gt;
                &lt;dtvdate&gt;2018-04-17&lt;/dtvdate&gt;               
                &lt;codepcode&gt;0907&lt;/codepcode&gt;
                &lt;cidepcode&gt;0907&lt;/cidepcode&gt;
                &lt;cordcode&gt;205&lt;/cordcode&gt;
                &lt;cirdcode&gt;106&lt;/cirdcode&gt;
                &lt;csource&gt;&lt;/csource&gt;
                &lt;cmaker&gt;测试&lt;/cmaker&gt;
                &lt;dnmaketime&gt;2018-04-17&lt;/dnmaketime&gt;
                &lt;vt_id&gt;89&lt;/vt_id&gt;
                &lt;iproorderid&gt;&lt;/iproorderid&gt;
                &lt;ciwhcode&gt;M011&lt;/ciwhcode&gt;
                &lt;cowhcode&gt;M012&lt;/cowhcode&gt;
                &lt;ctranrequestcode&gt;&lt;/ctranrequestcode&gt;
                &lt;itransflag&gt;&lt;/itransflag&gt;
                &lt;/row&gt;
                &lt;/table&gt;";

                    b = $@"
                &lt;table&gt;
                &lt;row&gt;
                &lt;autoid&gt;&lt;/autoid&gt;
                &lt;cinvcode&gt;1111021005&lt;/cinvcode&gt;
                &lt;editprop&gt;A&lt;/editprop&gt;
                &lt;itvquantity&gt;0.1&lt;/itvquantity&gt;
                &lt;cinvm_unit&gt;&lt;/cinvm_unit&gt;
                &lt;cmocode&gt;&lt;/cmocode&gt;
                &lt;imoseq&gt;&lt;/imoseq&gt;
                &lt;impoids&gt;&lt;/impoids&gt;
                &lt;coutposcode&gt;&lt;/coutposcode&gt;
                &lt;cinposcode&gt;&lt;/cinposcode&gt;
                &lt;ctvbatch&gt;20180417004&lt;/ctvbatch&gt;
                &lt;itrids&gt;&lt;/itrids&gt;
                &lt;/row&gt;&lt;/table&gt;";

                    Excode = "<Parameters>" +
$"<Param Mode=\"TransVouchAdd\" sAccID =\"900\" sVouchType=\"12\" VouchId=\"aw\" bCheck=\"true\" bBeforCheckStock=\"false\" bIsRedVouch=\"false\" sAddedState=\" \" bReMote=\"false\" body=\"{b}\" head=\"{h}\"/>" +
                        "</Parameters>";
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Excode);
                    Excode = doc.OuterXml;
                    break;
                #endregion
                #region 材料出库审计
                case 8:
                    mode = "审计";                  
                    Excode = "<Parameters>" +
$"<Param Mode=\"otheroutAudit\" sAccID =\"333\" sVouchType=\"09\" VouchId=\"1000010105\" bCheck=\"{SysParams.Instance.bCheck}\" bBeforCheckStock=\"{SysParams.Instance.bBeforCheckStock}\"/>" +
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
    }
}
