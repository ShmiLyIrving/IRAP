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
<csource>{txtcsource2.Text.Trim()}</csource>
<cdepcode>0907</cdepcode>
<cpersoncode>000094</cpersoncode>
<crdcode>101</crdcode>
</row>
</table>
";

                    b = $@"<table>
     <row>

<cinvcode>{txtcinvcode0.Text.Trim()}</cinvcode>

<id>1</id>
<cinvaddcode>1</cinvaddcode>
<cinvname>1</cinvname>
<cinvstd>1</cinvstd>
<cinvm_unit>1</cinvm_unit>
<cinva_unit>1</cinva_unit>
<creplaceitem>1</creplaceitem>
<cbatch>1</cbatch>
<iinvexchrate>1</iinvexchrate>
<inum>1</inum>
<iquantity>1</iquantity>
<isoutquantity>1</isoutquantity>
<isoutnum>1</isoutnum>
<ifquantity>1</ifquantity>
<ifnum>1</ifnum>
<cvouchcode>1</cvouchcode>
<inquantity>1</inquantity>
<innum>1</innum>
<dmadedate>2016-11-1010:10:10</dmadedate>
<impoids>1</impoids>
<isodid>1</isodid>
<cbvencode>1</cbvencode>
<cinvouchcode>1</cinvouchcode>
<cvenname>1</cvenname>
<imassdate>2016-11-1010:10:10</imassdate>
<cassunit>1</cassunit>
<corufts>1</corufts>
<cposname>1</cposname>
<cmassunit>1</cmassunit>
<csocode>1</csocode>
<cvmivencode>1</cvmivencode>
<cvmivenname>1</cvmivenname>
<bvmiused>1</bvmiused>
<ivmisettlequantity>1</ivmisettlequantity>
<ivmisettlenum>1</ivmisettlenum>
<cdemandmemo>1</cdemandmemo>
<iordertype>1</iordertype>
<iorderdid>1</iorderdid>
<iordercode>1</iordercode>
<iorderseq>1</iorderseq>
<cciqbookcode>1</cciqbookcode>
<ibondedsumqty>1</ibondedsumqty>

<cname>1</cname>
<citem_class>1</citem_class>
<citemcname>1</citemcname>
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

<cwhcode>M051</cwhcode>
<cdepcode>0907</cdepcode>
<cpersoncode>000381</cpersoncode>
<crdcode>106</crdcode>
<csource>1</csource>

     </row>
    </table>
";

                    b = $@"<table>
     <row>
   <autoid>{txtautoid3.Text.Trim()}</autoid>
<cinvcode>{txtcinvcode3.Text.Trim()}</cinvcode>
<editprop>{txteditprop3.Text.Trim()}</editprop>
<id>1</id>
<ifnum>1</ifnum>
<inquantity>1</inquantity>
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

<cdepcode>0907</cdepcode>
<cpersoncode>000381</cpersoncode>
<crdcode>201</crdcode>
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

<cinvaddcode>1</cinvaddcode>
<cinvname>1</cinvname>
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
                    mode = "产品入库";
                    h = $@"<table>
     <row>
<id>{txtid5.Text.Trim()}</id>
<ccode>{txtccode5.Text.Trim()}</ccode>
<ddate>{dpddate5.Text.Trim()}</ddate>
<cwhname>{txtcwhname5.Text.Trim()}</cwhname>
<cwhcode>M051</cwhcode>
<cdepcode>0907</cdepcode>
<cpersoncode>000381</cpersoncode>
<crdcode>102</crdcode>
<csource>1</csource>

     </row>
    </table>
";

                    b = $@"<table>
     <row>
   <autoid>{txtautoid5.Text.Trim()}</autoid>
<cinvcode>{txtcinvcode5.Text.Trim()}</cinvcode>
<editprop>{txteditprop5.Text.Trim()}</editprop>
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


<cwhcode>M051</cwhcode>
<cdepcode>0907</cdepcode>
<cpersoncode>000381</cpersoncode>
<crdcode>206</crdcode>

     </row>
    </table>
";

                    b = $@"<table>
     <row>
   <autoid>{txtautoid6.Text.Trim()}</autoid>
<cinvcode>{txtcinvcode6.Text.Trim()}</cinvcode>
<editprop>{txteditprop6.Text.Trim()}</editprop>
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
