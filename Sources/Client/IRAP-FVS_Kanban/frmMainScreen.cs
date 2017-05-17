using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IRAP_FVS_Kanban
{
    public partial class frmMainScreen : DevExpress.XtraEditors.XtraForm
    {
        private Point offset;
        private string screenStatusText = "";

        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void ShowSceenInfo()
        {
            Screen[] sc = Screen.AllScreens;
            btnInfo.Text = string.Format("系统共检测到当前有{0}个扩展屏幕", sc.Count() - 1);
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            foreach (KanbanScreen screen in KanbanScreens.Instance.Screens)
            {
                if (screen.Detected && screen.Show)
                {
                    //frmMain frmDisplay = new frmMain(screen);
                    //frmDisplay.Show();
                }
            }

            ShowSceenInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            ShowSceenInfo();
        }

        private void frmMainScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button)
                return;

            Point cur = MousePosition;
            Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        private void frmMainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmConfig frmconfig = new frmConfig();
            frmconfig.Show();
        }
    }
}