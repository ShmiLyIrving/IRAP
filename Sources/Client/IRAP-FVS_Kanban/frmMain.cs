using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using DevExpress.XtraBars;

using IRAP.Entity.SSO;
using IRAP.Entity.Kanban;

namespace IRAP_FVS_Kanban
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int monitorIndex = 0;
        private int sysLogIDIndex = 0;
        private Screen[] sc = Screen.AllScreens;
        private int MenuCacheID = 9001;
        private string LineName = "";
        private static string className = "IRAP.frmMain";
        private List<SystemMenuInfoButtonStyle> buttonInfos = new List<SystemMenuInfoButtonStyle>();
        private List<SystemMenuInfoMenuStyle> menuInfos = new List<SystemMenuInfoMenuStyle>();
        /// <summary>
        /// 关闭系统时是否需要询问
        /// </summary>
        private bool isQuitSilent = false;
        /// <summary>
        /// 需要自动切换的功能列表
        /// </summary>
        private List<JumpToFunction> autoCycleFuntions = new List<JumpToFunction>();
        private KanbanScreen _screen = null;

        public frmMain()
        {
            InitializeComponent();

            ShowInTaskbar = false;
        }

        public frmMain(int screenIndex, int productIndex) : this()
        {
            monitorIndex = screenIndex;
            sysLogIDIndex = productIndex;
        }

        public frmMain(KanbanScreen screen) : this()
        {
            _screen = screen;
        }

        private void ShowOnMonitor(int showOnMonitor)
        {
            DesktopBounds = _screen.Bounds;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Maximized;
        }

        protected 
    }
}