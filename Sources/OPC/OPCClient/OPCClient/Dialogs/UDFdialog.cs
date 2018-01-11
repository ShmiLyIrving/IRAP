using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace OPCClient.Dialogs
{
    public partial class UDFdialog :Form
    {
        private FormWindowState windowstate = FormWindowState.Normal;
        /// <summary>
        /// 无边框窗体拖动
        /// </summary>
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;


        /// <summary>
        /// 窗体动画函数
        /// </summary>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果
        public UDFdialog()
        {
            InitializeComponent();
            lbTitle.Text = "";
        }
        public UDFdialog(string title) : this()
        {
            lbTitle.Text = title;
        }

        //非空验证
        protected bool BlankValidate()
        {            
            ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            foreach (System.Windows.Forms.Control c in this.Controls["pnlBody"].Controls)
            {
                if (c.Tag != null)
                {
                    notEmptyValidationRule.ErrorText = $"{this.Controls["pnlBody"].Controls[$"labelControl{c.Tag.ToString()}"].Text}不能为空!";
                    dxValidationProvider1.SetValidationRule(c, notEmptyValidationRule);
                    this.dxValidationProvider1.SetIconAlignment(c, ErrorIconAlignment.MiddleRight);
                }
            }
            return this.dxValidationProvider1.Validate();
        }

        //label拖动
        protected void SetLabelMouseDown()
        {
            foreach(System.Windows.Forms.Control c in this.Controls["pnlBody"].Controls)
            {
                if(c.Name.Contains("label"))
                {
                    c.MouseDown += this.pnlHead_MouseDown;
                }
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void pnlHead_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            if (e.Clicks > 1)
            {
                btnSize_Click(null, null);
            }
        }

        private void UDFdialog_Load_1(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 200,AW_ACTIVE | AW_BLEND);
        }

        private void UDFdialog_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 100, AW_BLEND | AW_HIDE| AW_CENTER);
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            if (windowstate == FormWindowState.Normal)
            {
                windowstate = FormWindowState.Maximized;
                this.WindowState = windowstate;
            }
            else if (windowstate == FormWindowState.Maximized)
            {
                windowstate = FormWindowState.Normal;
                this.WindowState = windowstate;
            }
        }
    }
}
