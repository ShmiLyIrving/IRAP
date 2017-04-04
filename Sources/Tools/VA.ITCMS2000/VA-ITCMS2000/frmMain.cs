using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VA_ITCMS2000
{
    public partial class frmMain : Form
    {
        private bool canClosed = false;

        public frmMain()
        {
            InitializeComponent();

            notifyIcon.Icon = Icon;
            notifyIcon.Text = Text;
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
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState== FormWindowState.Minimized)
            {
                ShowForm();
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                HideForm();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClosed)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                HideForm();
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    HideForm();
                    break;
            }
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            canClosed = true;
            Close();
        }

        private void tsmiConfiguration_Click(object sender, EventArgs e)
        {
            using (frmSysParams formParams=new frmSysParams())
            {
                formParams.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VAThread.Instance.Logs = edtLogs;
            VAThread.Instance.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VAThread.Instance.Enabled = false;
        }
    }
}
