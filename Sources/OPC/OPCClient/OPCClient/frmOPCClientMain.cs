using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

using DevExpress.XtraBars;
using DevExpress.XtraTab;

namespace OPCClient
{
    public partial class frmOPCClientMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private bool canClosed = false;

        public frmOPCClientMain()
        {
            InitializeComponent();

            notifyIcon.Text = "IRAP OPC 数据采集";
        }

        private void HideForm()
        {
            Hide();
            ShowInTaskbar = false;
        }

        private void ShowForm()
        {
            Show();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            Activate();
            SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);
        }

        private XtraTabPage NewTabPage(string pageName, UserContols.ucCustomBase userControl)
        {
            XtraTabPage rlt = new XtraTabPage();

            rlt.Name = pageName;
            userControl.Dock = DockStyle.Fill;

            rlt.Controls.Add(userControl);
            tcMain.TabPages.Add(rlt);

            tcMain.SelectedTabPage = rlt;

            return rlt;
        }

        private void frmOPCClientMain_Load(object sender, EventArgs e)
        {

        }

        private void frmOPCClientMain_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void frmOPCClientMain_FormClosing(object sender, FormClosingEventArgs e)
        {
#if DEBUG
            e.Cancel = false;
#else
            if (canClosed)
                e.Cancel = false;
            else
            {
                e.Cancel = true;
                HideForm();
            }
#endif
        }

        private void frmOPCClientMain_Resize(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    HideForm();
                    break;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (WindowState == FormWindowState.Minimized)
                    ShowForm();
                else
                {
                    WindowState = FormWindowState.Minimized;
                    HideForm();
                }
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            canClosed = true;
            Close();
        }

        private void bbiSysParamsConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bbiConfigOPCServers_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (XtraTabPage page in tcMain.TabPages)
            {
                if (page.Name == "tpConfigOPCServers")
                {
                    tcMain.SelectedTabPage = page;
                    return;
                }
            }

            UserContols.ucConfigOPCServers newUC = 
                new UserContols.ucConfigOPCServers(bbiConfigOPCServers.Caption);
            XtraTabPage newPage = NewTabPage("tpConfigOPCServers", newUC);
        }

        private void bbiOPCTagCollection_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (XtraTabPage page in tcMain.TabPages)
            {
                if (page.Name == "tpOPCMonitor")
                {
                    tcMain.SelectedTabPage = page;
                    return;
                }
            }

            UserContols.ucCustomBase newUC = 
                new UserContols.ucOPCMonitor(bbiOPCTagCollection.Caption);
            XtraTabPage newPage = NewTabPage("tpOPCMonitor", newUC);
        }

        private void bbiConfigSysParams_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (XtraTabPage page in tcMain.TabPages)
            {
                if (page.Name == "tpSysParamsConfig")
                {
                    tcMain.SelectedTabPage = page;
                    return;
                }
            }

            UserContols.ucConfigSysParams newUC =
                new UserContols.ucConfigSysParams(bbiConfigSysParams.Caption);
            XtraTabPage newPage = NewTabPage("tpSysParamsConfig", newUC);
        }
    }
}