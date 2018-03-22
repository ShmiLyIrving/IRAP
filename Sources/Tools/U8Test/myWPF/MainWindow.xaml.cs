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
                Text = "NotifyIconStd"
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
        }
        private void UpdateBtn(bool enable)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart)delegate ()
                {
                    SetBtn(enable);
                });
        }
        private void SetBtn(bool enable)
        {
            btn_Confirm.IsEnabled = enable;
        }
        private void UpdateLog(string msg, string modeName, ToolTipIcon icon)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                  (ThreadStart)delegate ()
                  {
                      OutputLog(msg, modeName, icon);
                  }
                );
        }
        private void OutputLog(string msg, string modeName, ToolTipIcon icon)
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
            LoadConfig();
            AddTrayIcon();           
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

            System.Boolean bCheck;
            System.Boolean bBeforCheckStock;
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
<cwhname>{txtcwhname0.Text.Trim()}</cwhname>
<cwhcode>{txtcwhname0.Text.Trim()}</cwhcode>
<cmpocode>{txtcmpocode0.Text.Trim()}</cmpocode>
<iproorderid>{txtimpoids0.Text.Trim()}</iproorderid>
<cmaker>{txtcmaker0.Text.Trim()}</cmaker>
<cbustype>{txtcbustype0.Text.Trim()}</cbustype>
<crdcode>{txtcrdname0.Text.Trim()}</crdcode>
<crdname>{txtcrdname0.Text.Trim()}</crdname>
<vt_id>{txtvt_id0.Text.Trim()}</vt_id>
<cdepcode>0907</cdepcode>
<cpersoncode>000094</cpersoncode>
<cproinvaddcode>1</cproinvaddcode>
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
<editprop>A</editprop>
</row></table> ";


                    sVouchType = "11";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//

                    bCheck = true;
                    bBeforCheckStock = false;
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
<ccode>{txtccode1.Text.Trim()}</ccode>
<ddate>{dpddate1.Text.Trim()}</ddate>
<cwhname>{txtcwhname1.Text.Trim()}</cwhname>
<cwhcode>{txtcwhname1.Text.Trim()}</cwhcode>
<cmpocode>{txtcmpocode1.Text.Trim()}</cmpocode>
<crdcode>{txtcrdname1.Text.Trim()}</crdcode>
<crdname>{txtcrdname1.Text.Trim()}</crdname>
<cmaker>{txtcmaker1.Text.Trim()}</cmaker>
<cdepcode>{txtcdepname1.Text.Trim()}</cdepcode>
<cbustype>{txtcbustype1.Text.Trim()}</cbustype>
<iproorderid>{txtimpoids1.Text.Trim()}</iproorderid>
<vt_id>{txtvt_id1.Text.Trim()}</vt_id>
<cprobatch>1703002</cprobatch>
<csource>生产订单</csource>
</row>
</table>
";

                    b = $@"<table>
<row>
<autoid>{txtautoid1.Text.Trim()}</autoid>
<cinvcode>{txtcinvcode1.Text.Trim()}</cinvcode>
<cbatch>{txtcbatch1.Text.Trim()}</cbatch>
<inquantity>{txtiquantity1.Text.Trim()}</inquantity>
<cmocode>{txtcmpocode1.Text.Trim()}</cmocode>
<imoseq>{txtimoseq1.Text.Trim()}</imoseq>
<impoids>{txtimpoids1.Text.Trim()}</impoids>
<cposname>{txtcposname1.Text.Trim()}</cposname>
<cposition>{txtcposname1.Text.Trim()}</cposition>
<cdefine22>{txtcdefine221.Text.Trim()}</cdefine22>
<cdefine23>{txtcdefine231.Text.Trim()}</cdefine23>
<cdefine24>{txtcdefine241.Text.Trim()}</cdefine24>
<cdefine26>0</cdefine26>
<cmolotcode>1703002</cmolotcode>
<isotype>0</isotype>
<iordertype>0</iordertype>
<iorderdid>0</iorderdid>


</row></table> ";

                    sVouchType = "10";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//

                    bCheck = true;
                    bBeforCheckStock = true;
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
                                UpdateLog(errMsg, mode, ToolTipIcon.Info);
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
<csource>{txtcsource2.Text.Trim()}</csource>
</row>
</table>
";

                    b = $@"<table>
<row>
<autoid>{txtautoid2.Text.Trim()}</autoid>
<id>{txtfid2.Text.Trim()}</id>
<cinvcode>{txtcinvcode0.Text.Trim()}</cinvcode>
<cinvm_unit>{txtcinvm_unit2.Text.Trim()}</cinvm_unit>
<iquantity>{txtiquantity2.Text.Trim()}</iquantity>
<editprop>{txteditprop2.Text.Trim()}</editprop>
<iMatSettleState>{txtiMatSettleState.Text.Trim()}</iMatSettleState>
<impoids>{txtimpoids2.Text.Trim()}</impoids>
<cposname>{txtcposname2.Text.Trim()}</cposname>
<cposition>{txtcposname2.Text.Trim()}</cposition>
<cdefine22>{txtcdefine222.Text.Trim()}</cdefine22>
<cdefine23>{txtcdefine232.Text.Trim()}</cdefine23>
<cdefine24>{txtcdefine242.Text.Trim()}</cdefine24>
</row></table> ";

                    sVouchType = "01";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//

                    bCheck = true;
                    bBeforCheckStock = false;
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
                                UpdateLog(errMsg, mode, ToolTipIcon.Info);
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
<cwhname>{txtcwhname3.Text.Trim()}</cwhname>
<cwhname_1>{txtcwhname3_1.Text.Trim()}</cwhname_1>
<crdname_1>{txtcrdname_13.Text.Trim()}</crdname_1>
<crdname>{txtcrdname3.Text.Trim()}</crdname>
<csource>{txtcsource3.Text.Trim()}</csource>
<cmaker>{txtcmaker3.Text.Trim()}</cmaker>
<vt_id>{txtvt_id3.Text.Trim()}</vt_id>
<iproorderid>{txtiproorderid3.Text.Trim()}</iproorderid>
<cpersoncode>000381</cpersoncode>
</row>
</table>
";

                    b = $@"<table>
<row>
<autoid>{txtautoid3.Text.Trim()}</autoid>
<cinvcode>{txtcinvcode3.Text.Trim()}</cinvcode>
<editprop>{txteditprop3.Text.Trim()}</editprop>
<iquantity>{txtiquantity3.Text.Trim()}</iquantity>
<cinvm_unit>{txtcinvm_unit3.Text.Trim()}</cinvm_unit>
<cmocode>{txtcmocode3.Text.Trim()}</cmocode>
<imoseq>{txtimoseq3.Text.Trim()}</imoseq>
<impoids>{txtimpoids3.Text.Trim()}</impoids>
<iquantity>1</inquantity>
<id>1</id>
<ifnum>1</ifnum>
<innum>1</innum>
<cbatchproperty1>1</cbatchproperty1>
 </row></table> ";

                    sVouchType = "12";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//

                    bCheck = true;
                    bBeforCheckStock = false;
                    bIsRedVouch = false;
                    sAddedState = "";
                    bReMote = false; ;
                    OutputLog("=======================开始上传========================", mode, ToolTipIcon.None);
                    OutputLog("DomHead =" + h, mode, ToolTipIcon.None);
                    OutputLog("DomBody =" + b, mode, ToolTipIcon.None);
                    t = new Task(() =>
                    {
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
                                UpdateLog(errMsg, mode, ToolTipIcon.Info);
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
<cwhname>{txtcwhname4.Text.Trim()}</cwhname>
<cbustype>{txtcbustype4.Text.Trim()}</cbustype>
<iverifystate>{txtiverifystate4.Text.Trim()}</iverifystate>
<iswfcontrolled>{txtiswfcontrolled4.Text.Trim()}</iswfcontrolled>
<ccusabbname>{txtccusabbname4.Text.Trim()}</ccusabbname>
<cmaker>{txtcmaker4.Text.Trim()}</cmaker>
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
<cpersoncode>{txtcdepcode4.Text.Trim()}</cpersoncode>
<crdcode>{txtcrdcode4.Text.Trim()}</crdcode>
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
<cposname>{txtcposname4.Text.Trim()}</cposname>
<cposition>{txtcposname4.Text.Trim()}</cposition>
<cdefine22>{txtcdefine224.Text.Trim()}</cdefine22>
<cdefine23>{txtcdefine234.Text.Trim()}</cdefine23>
<cdefine24>{txtcdefine244.Text.Trim()}</cdefine24>
<cdefine26>{txtcdefine264.Text.Trim()}</cdefine26>
<cinvaddcode>1</cinvaddcode>
<cinvname>{txtcinvcode4.Text.Trim()}</cinvname>
<cbatch>{txtcbatch4.Text.Trim()}</cbatch>
 </row></table> ";

                    sVouchType = "32";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//

                    bCheck = true;
                    bBeforCheckStock = false;
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
                                UpdateLog(errMsg, mode, ToolTipIcon.Info);
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
<id>1</id>
<ifnum>1</ifnum>
<inquantity>1</inquantity>
<innum>1</innum>
<cbatchproperty1>1</cbatchproperty1>
 </row></table> ";

                    sVouchType = "08";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//

                    bCheck = true;
                    bBeforCheckStock = false;
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
                                UpdateLog(errMsg, mode, ToolTipIcon.Info);
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
<vt_id>{txtvt_id6.Text.Trim()}</vt_id>
<brdflag>{txtbrdflag6.Text.Trim()}</brdflag>
</row>
</table>
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
<id>1</id>
<cinvaddcode>1</cinvaddcode>
<ifnum>1</ifnum>
<inquantity>1</inquantity>
<innum>1</innum>
 </row></table> ";

                    sVouchType = "09";
                    domPosition = "";
                    errMsg = "";
                    cnnFromO = null;
                    VouchId = "aw";//

                    bCheck = true;
                    bBeforCheckStock = false;
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
                                UpdateLog(errMsg, mode, ToolTipIcon.Info);
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
            }
        }

        
    }
}
