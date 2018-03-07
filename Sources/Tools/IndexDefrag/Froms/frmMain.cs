using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using DevExpress.XtraEditors.Controls;
using System.Threading;

namespace IndexDefrag
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
            LoadConfig();
            ScanningTask.Instance.SetMsgState += SetMsgState;
            ScanningTask.Instance.SetAccumTask += SetAccumTask;
            ScanningTask.Instance.SetlbHead += SetlbHead;
            ScanningTask.Instance.AfterScan += AfterScan;
            ScanningTask.Instance.SetPicAnimate += SetPicAnimate;
            ScanningTask.Instance.AfterDefrag += AfterDefrag;
            ScanningTask.Instance.SetBtnEnable += SetBtnEnable;
            timer.Interval = 999;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimeCheck);
        }
        ~frmMain()
        {
            timer.Elapsed -= new System.Timers.ElapsedEventHandler(TimeCheck);
        }

        /// <summary>
        /// 无边框窗体拖动
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private string className =
           MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private FormWindowState formStatus = FormWindowState.Normal;
        private bool canClosed = false;
        private bool isFirstScan = true;
        private static object lockArea = new object();
        CancellationTokenSource ctsScan = null;
        System.Timers.Timer timer = new System.Timers.Timer();


        //委托
        delegate void SetMsgCallBack(string msg, string modeName, ToolTipIcon icon);
        delegate void SetTextCallBack(string text);
        delegate void ActionCallBack();
        delegate void SetEnableCallBack(bool enable);
        delegate void SerBtnEnableCallBack(int page, bool enable);
        

        #region 方法
        private void SetBtnEnable(int page,bool enable)
        {
            if (btnScan.InvokeRequired)
            {
                SerBtnEnableCallBack sb = new SerBtnEnableCallBack(SetBtnEnable);
                this.Invoke(sb, new object[] { page, enable });
            }
            else
            {
                switch (page)
                {
                    case 1:
                        btnScan.Enabled = enable;
                        break;
                    case 2:
                        btnCancel.Enabled = enable;
                        break;
                    case 3:
                        btnDefrag.Enabled = enable;
                        break;
                    default:
                        break;
                }
            }
        }
        private void BeginDefrag()
        {
            if (this.InvokeRequired)
            {
                ActionCallBack ac = new ActionCallBack(BeginDefrag);
                this.Invoke(ac, new object[] { });
            }
            else
            {
                tabDetail.SelectedTabPageIndex = 1;
                lbhead.Text = "正在清理：";
                lbAccumTask.Text = "0";
                lbMsgState.Text = "正在清理索引碎片";
                picloading.StartAnimation();
                ctsScan = new CancellationTokenSource();
                ScanningTask.Instance.Defrag(ctsScan.Token);
                btnCancel.Enabled = true;
            }
        }
        private void AfterDefrag()
        {          
            if(tabDetail.InvokeRequired)
            {
                ActionCallBack ac = new ActionCallBack(AfterDefrag);
                this.Invoke(ac);
            }
            else
            {
                btnCancel.Enabled = false;
                btnScan.Enabled = true;
                SetlbHead("");
                btnDefrag.Text = "重新清理";
                picloading.StopAnimation();
            }
        }
        private void LoadConfig()
        {
            edtUpgradeURL.Text = SysParams.Instance.UpgradeURL;
            chkWriteLog.Checked = SysParams.Instance.IsWriteLog;

            edtDBAdress.Text = SysParams.Instance.DBServer;
            edtDBUid.Text = SysParams.Instance.DBUid;
            edtDBPwd.Text = SysParams.Instance.DBPwd;

            edtMaxAFP.Text = SysParams.Instance.MaxAFP;
            edtMaxFragmentCount.Text = SysParams.Instance.MaxFragmentCount;
            MaxIgnoreSacningTimes.Text = SysParams.Instance.MaxIgnoreSacningTimes;
            edtMaxScanningThreadCount.Text = SysParams.Instance.MaxScanningThreadCount;
            edtMaxDefragThreadCount.Text = SysParams.Instance.MaxDefragThreadCount;

            chkAutoDefag.Checked = SysParams.Instance.AutoDefrag;
            chkLogScan.Checked = SysParams.Instance.ScanningLog;
        }
        private void TimeCheck(object sender, System.Timers.ElapsedEventArgs e)
        {
            // 得到 hour minute second  如果等于某个值就开始执行某个程序。  
            int intHour = e.SignalTime.Hour;
            int intMinute = e.SignalTime.Minute;
            int intSecond = e.SignalTime.Second;
            // 定制时间； 比如 在10：30 ：00 的时候执行某个函数  
            int iHour = int.Parse(cmbHour.Text);
            int iMinute = int.Parse(cmbMin.Text);
            int iSecond = 00;
            // 设置　 每秒钟的开始执行一次  
            //if (intSecond == iSecond)
            //{
            //    Console.WriteLine("每秒钟的开始执行一次！");
            //}
            //// 设置　每个小时的３０分钟开始执行  
            //if (intMinute == iMinute && intSecond == iSecond)
            //{
            //    Console.WriteLine("每个小时的３０分钟开始执行一次！");
            //}
            // 设置　每天的１０：３０：００开始执行程序  
            if (intHour == iHour && intMinute == iMinute && intSecond == iSecond)
            {
                if(btnDefrag.Enabled ==true)
                {
                    BeginDefrag();
                }
            }
        }
        private void SetPicAnimate(bool enable)
        {
            if(picloading.InvokeRequired)
            {
                SetEnableCallBack sb = new SetEnableCallBack(SetPicAnimate);
                this.Invoke(sb,new object[] { enable });
            }
            else
            {
                if(enable)
                {
                    picloading.StartAnimation();
                }
                else
                {
                    picloading.StopAnimation();
                }          
            }
        }
        private void ReFreshgcIndex()
        {
            gcIndex.DataSource = (cmbTable.SelectedItem as DBTable).indexstates;
        }

        private void ShowResult()
        {
            cmbDB.Properties.Items.Clear();
            cmbDB.Text = "";
            cmbTable.Properties.Items.Clear();
            cmbTable.Text = "";
            gcIndex.DataSource = null;
            tabDetail.SelectedTabPageIndex = 2;
            foreach (DB db in Server.Instance.databases)
            {
                cmbDB.Properties.Items.Add(db);
            }
            cmbDB.SelectedIndex = 0;
            cmbTable.SelectedIndex = 0;
            if (cmbTable.SelectedItem != null)
            {
                ReFreshgcIndex();
            }
            foreach (DB db in Server.Instance.databases)
                foreach (DBTable table in db.tables)
                {
                    if (table.indexstates.Count > 0)
                    {
                        btnDefrag.Enabled = true;
                        break;
                    }                  
                }
            if(btnDefrag.Enabled ==false)
            {
                lbMsgState.Text = "无可清理项目";
            }
            btnCancel.Enabled = false;
            btnScan.Enabled = true;
            SetlbHead("");
            btnScan.Text = "重新扫描";
        }
        private void AfterScan()
        {
            if (tabDetail.InvokeRequired)
            {
                ActionCallBack ac = new ActionCallBack(AfterScan);
                this.Invoke(ac);
            }
            else
            {
                ShowResult();
                if(chkAutoDefag.Checked)
                {
                    BeginDefrag();
                }
            }
        }
        private void SetlbHead(string head)
        {
            if (lbhead.InvokeRequired)
            {
                SetTextCallBack sb = new SetTextCallBack(SetlbHead);
                this.Invoke(sb, new object[] { head });
            }
            else
            {
                lbhead.Text = head;
            }
        }
        private void SetAccumTask(string count)
        {
            if (lbAccumTask.InvokeRequired)
            {
                SetTextCallBack sb = new SetTextCallBack(SetAccumTask);
                this.Invoke(sb, new object[] { count });
            }
            else
            {
                lbAccumTask.Text = count;
            }
        }
        private void SetMsgState(string msg, string modeName, ToolTipIcon icon)
        {
            if(lbMsgState.InvokeRequired)
            {
                SetMsgCallBack sb = new SetMsgCallBack(SetMsgState);
                this.Invoke(sb, new object[] { msg, modeName, icon });
            }
            else
            {
                lbMsgState.Text = string.Format("{0}\r\n", msg);
                WriteLog.Instance.Write(msg, modeName);
                ShowMessageInBalloon(msg, icon, 500);
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
            notifyIcon.ShowBalloonTip(timeout, caption, msg, icon);
        }
        private void frmxFiletoESBMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClosed)
            {
                e.Cancel = false;
                notifyIcon.Visible = false;
            }
            else
            {
                e.Cancel = true;
                HideForm();
            }
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
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Color FColor = Color.SteelBlue;
            //Color TColor = Color.Azure;
            //Brush b = new LinearGradientBrush(this.ClientRectangle, FColor, TColor, LinearGradientMode.Vertical);
            //g.FillRectangle(b, this.ClientRectangle);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //tabDetail.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            try
            {
                Server.Instance.InitServer();
                foreach (DB db in Server.Instance.databases)
                {
                    chkDB.Items.Add(db);                
                }
                btnScan.Enabled = true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        
        }

        private void tsmiConfiguration_Click(object sender, EventArgs e)
        {
            tabDetail.SelectedTabPageIndex = 3;
            if(formStatus ==FormWindowState.Minimized)
            {
                {
                    ShowForm();
                }
            }
            else
            {
                SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);
            }
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            canClosed = true;
            Close();
        }
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (formStatus == FormWindowState.Minimized)
            {
                ShowForm();
            }
            else
            {
                HideForm();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            HideForm();
        }

        private void btnConfSave_Click(object sender, EventArgs e)
        {
            bool serverchanged = false;
            if (edtDBAdress.Text.Trim() != Server.Instance.DBServer ||
                edtDBUid.Text.Trim()!=SysParams.Instance.DBUid||
                edtDBPwd.Text.Trim()!=SysParams.Instance.DBPwd)
            {
                serverchanged = true;
            }
            SysParams.Instance.UpgradeURL = edtUpgradeURL.Text.Trim();
            SysParams.Instance.IsWriteLog = chkWriteLog.Checked;
            SysParams.Instance.ScanningLog = chkLogScan.Checked;

            SysParams.Instance.DBServer = edtDBAdress.Text.Trim();
            SysParams.Instance.DBUid = edtDBUid.Text.Trim();
            SysParams.Instance.DBPwd = edtDBPwd.Text.Trim();

            SysParams.Instance.MaxIgnoreSacningTimes = MaxIgnoreSacningTimes.Text.Trim();
            SysParams.Instance.MaxAFP = edtMaxAFP.Text.Trim();
            SysParams.Instance.MaxFragmentCount = edtMaxFragmentCount.Text.Trim(); 
            SysParams.Instance.MaxScanningThreadCount = edtMaxScanningThreadCount.Text.Trim();
            SysParams.Instance.MaxDefragThreadCount = edtMaxDefragThreadCount.Text.Trim();

            SysParams.Instance.TimerDefrag = chkTimerDefrag.Checked;

            if (serverchanged)
            {
                try
                {
                    btnScan.Enabled = false;
                    btnDefrag.Enabled = false;
                    cmbDB.Properties.Items.Clear();
                    cmbDB.Text = "";
                    cmbTable.Properties.Items.Clear();
                    cmbTable.Text = "";
                    gcIndex.DataSource = null;
                    Server.Instance.InitServer();
                    XmlFile.Instance.Initialization();
                    chkDB.Items.Clear();
                    foreach (DB db in Server.Instance.databases)
                    {
                        chkDB.Items.Add(db);
                    }
                    btnScan.Enabled = true;
                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            if (SysParams.Instance.TimerDefrag)
            {
                if(string.IsNullOrEmpty(cmbHour.Text)||string.IsNullOrEmpty(cmbMin.Text))
                {
                    lbMsgState.Text = "保存失败，请选择定时时间！";
                    return;
                }
                timer.Enabled = true;
                timer.Start();           
            }
            else
            {
                timer.Stop();
                timer.Enabled = false;
            }
            lbMsgState.Text = "保存成功";
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            if (chkDB.CheckedItems.Count <= 0)
            {
                lbMsgState.Text = "您尚未选择数据库!";
            }
            else
            {
                if(!isFirstScan)
                {
                    Server.Instance.InitServer();
                }
                foreach (CheckedListBoxItem item in chkDB.Items)
                {
                    if (item.CheckState == CheckState.Unchecked)
                    {
                        Server.Instance.databases.Remove((DB)(item.Value));
                    }
                }
            }
            isFirstScan = false;
            tabDetail.SelectedTabPageIndex = 1;
            btnScan.Enabled = false;
            btnCancel.Enabled = true;
            btnDefrag.Enabled = false;
            cmbDB.Properties.Items.Clear();
            cmbDB.Text = "";
            cmbTable.Properties.Items.Clear();
            cmbTable.Text = "";
            gcIndex.DataSource = null;
            picloading.StartAnimation();
            ctsScan = new CancellationTokenSource();
            ScanningTask.Instance.GetTableStruct(ctsScan.Token);
        }
        private void labelControl4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        private void cmbDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTable.Properties.Items.Clear();
            cmbTable.Text = "";
            if ((cmbDB.SelectedItem as DB).tables != null)
            {
                foreach (DBTable table in (cmbDB.SelectedItem as DB).tables)
                {
                    if (table.indexstates != null && table.indexstates.Count > 0)
                    {
                        cmbTable.Properties.Items.Add(table);
                    }
                }
                if (cmbTable.Properties.Items.Count < 1)
                {
                    gcIndex.DataSource = null;
                }
                else
                {
                    cmbTable.SelectedIndex = 0;
                }
            }
            else
            {
                gcIndex.DataSource = null;
            }
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReFreshgcIndex();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ctsScan.Cancel();           
            this.lbAccumTask.Text = "正在取消";
            btnCancel.Enabled = false;
        }
        private void tabDetail_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Text == "状态")
            {
                if (!btnCancel.Enabled)
                {
                    picloading.StopAnimation();
                }
            }
        }

        private void btnDefrag_Click(object sender, EventArgs e)
        {
            BeginDefrag();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckEdit).Checked)
            {
                chkDB.CheckAll();
            }
            else
            {
                chkDB.UnCheckAll();
            }
        }

        private void chkAutoDefag_CheckedChanged(object sender, EventArgs e)
        {
            SysParams.Instance.AutoDefrag = (sender as CheckEdit).Checked;
        }

        #endregion

        private void lbMsgState_DoubleClick(object sender, EventArgs e)
        {
            string logPath = string.Format("{0}{1}_{2}.log",
                                    string.Format(@"{0}Log\",
                                    AppDomain.CurrentDomain.BaseDirectory),
                                    "IRAP",
                                    DateTime.Now.ToString("yyyy-MM-dd"));
            if (System.IO.File.Exists(logPath))
            {
                try
                {
                    System.Diagnostics.Process.Start(logPath); //打开此文件。
                }
                catch
                {
                }
            }
        }
    }
}