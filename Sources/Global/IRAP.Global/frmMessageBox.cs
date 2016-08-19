using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;

namespace IRAP.Global
{
    internal partial class frmMessageBox : DevExpress.XtraEditors.XtraForm
    {
        public frmMessageBox()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }

    public class IRAPMessageBox
    {
        private static IRAPMessageBox _instance = null;

        private frmMessageBox messageBox = null;

        private IRAPMessageBox()
        {
            messageBox = new frmMessageBox();
        }

        public static IRAPMessageBox Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPMessageBox();
                return _instance;
            }
        }

        public void Show(
            string text,
            string caption = "",
            MessageBoxIcon icon = MessageBoxIcon.Asterisk)
        {
            messageBox.Text = caption;
            messageBox.lblMessage.Text = text;

            bool soundAlert = true;
            if (ConfigurationManager.AppSettings["SoundAlert"] != null)
                soundAlert = ConfigurationManager.AppSettings["SoundAlert"].ToString().ToUpper() == "TRUE";

            switch (icon)
            {
                case MessageBoxIcon.Asterisk:
                case MessageBoxIcon.Exclamation:
                    if (soundAlert)
                        Tools.Play(Properties.Resources.ALARM9);
                    messageBox.picIcon.Image = Properties.Resources.故障;
                    break;
                case MessageBoxIcon.Error:
                    if (soundAlert)
                        Tools.Play(Properties.Resources.ALARM9);
                    messageBox.picIcon.Image = Properties.Resources.报错;
                    break;
                case MessageBoxIcon.Question:
                    messageBox.picIcon.Image = Properties.Resources.帮助;
                    break;
            }

            messageBox.btnClose.Visible = true;
            messageBox.btnClose.Left = (messageBox.Width - messageBox.btnClose.Width) / 2;
            messageBox.CancelButton = messageBox.btnClose;

            messageBox.TopMost = true;
            messageBox.Show();
        }

        public void Hide()
        {
            messageBox.Hide();
        }

        public DialogResult Show(
            string text, 
            string caption = "", 
            MessageBoxButtons buttons = MessageBoxButtons.OK, 
            MessageBoxIcon icon = MessageBoxIcon.Asterisk, 
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            using (frmMessageBox messageBox = new frmMessageBox())
            {
                messageBox.Text = caption;
                messageBox.lblMessage.Text = text;

                int splitterWidth = 0;
                switch (buttons)
                {
                    case MessageBoxButtons.AbortRetryIgnore:
                        messageBox.btnAbort.Visible = true;
                        messageBox.btnRetry.Visible = true;
                        messageBox.btnIgnore.Visible = true;

                        splitterWidth = (messageBox.Width - messageBox.btnAbort.Width - messageBox.btnRetry.Width - messageBox.btnIgnore.Width) / 4;
                        messageBox.btnAbort.Left = splitterWidth;
                        messageBox.btnRetry.Left = splitterWidth * 2 + messageBox.btnAbort.Width;
                        messageBox.btnIgnore.Left = splitterWidth * 3 + messageBox.btnAbort.Width + messageBox.btnRetry.Width;

                        messageBox.CancelButton = messageBox.btnIgnore;
                        break;
                    case MessageBoxButtons.OK:
                        messageBox.btnOK.Visible = true;
                        messageBox.btnOK.Left = (messageBox.Width - messageBox.btnOK.Width) / 2;
                        messageBox.CancelButton = messageBox.btnOK;
                        break;
                    case MessageBoxButtons.OKCancel:
                        messageBox.btnOK.Visible = true;
                        messageBox.btnCancel.Visible = true;

                        splitterWidth = (messageBox.Width - messageBox.btnOK.Width - messageBox.btnCancel.Width) / 3;
                        messageBox.btnOK.Left = splitterWidth;
                        messageBox.btnCancel.Left = splitterWidth * 2 + messageBox.btnOK.Width;

                        messageBox.CancelButton = messageBox.btnCancel;
                        break;
                    case MessageBoxButtons.RetryCancel:
                        messageBox.btnRetry.Visible = true;
                        messageBox.btnCancel.Visible = true;

                        splitterWidth = (messageBox.Width - messageBox.btnRetry.Width - messageBox.btnCancel.Width) / 3;
                        messageBox.btnRetry.Left = splitterWidth;
                        messageBox.btnCancel.Left = splitterWidth * 2 + messageBox.btnRetry.Width;

                        messageBox.CancelButton = messageBox.btnCancel;
                        break;
                    case MessageBoxButtons.YesNo:
                        messageBox.btnYes.Visible = true;
                        messageBox.btnNo.Visible = true;

                        splitterWidth = (messageBox.Width - messageBox.btnYes.Width - messageBox.btnNo.Width) / 3;
                        messageBox.btnYes.Left = splitterWidth;
                        messageBox.btnNo.Left = splitterWidth * 2 + messageBox.btnYes.Width;

                        messageBox.CancelButton = messageBox.btnNo;
                        break;
                    case MessageBoxButtons.YesNoCancel:
                        messageBox.btnYes.Visible = true;
                        messageBox.btnNo.Visible = true;
                        messageBox.btnCancel.Visible = true;

                        splitterWidth = (messageBox.Width - messageBox.btnYes.Width - messageBox.btnNo.Width - messageBox.btnCancel.Width) / 4;
                        messageBox.btnYes.Left = splitterWidth;
                        messageBox.btnNo.Left = splitterWidth * 2 + messageBox.btnYes.Width;
                        messageBox.btnCancel.Left = splitterWidth * 3 + messageBox.btnYes.Width + messageBox.btnNo.Width;

                        messageBox.CancelButton = messageBox.btnCancel;
                        break;
                }

                switch (icon)
                {
                    case MessageBoxIcon.Asterisk:
                        messageBox.picIcon.Image = Properties.Resources.故障;
                        break;
                    case MessageBoxIcon.Error:
                        IRAP.Global.Tools.Play(Properties.Resources.ALARM9);
                        messageBox.picIcon.Image = Properties.Resources.报错;
                        break;
                    case MessageBoxIcon.Exclamation:
                        IRAP.Global.Tools.Play(Properties.Resources.ALARM9);
                        messageBox.picIcon.Image = Properties.Resources.故障;
                        break;
                    case MessageBoxIcon.Question:
                        messageBox.picIcon.Image = Properties.Resources.帮助;
                        break;
                }

                switch (defaultButton)
                {
                    case MessageBoxDefaultButton.Button1:
                        break;
                    case MessageBoxDefaultButton.Button2:
                        switch (buttons)
                        {
                            case MessageBoxButtons.OKCancel:
                                messageBox.btnCancel.TabIndex = 1;
                                messageBox.btnOK.TabIndex = 2;
                                break;
                            case MessageBoxButtons.YesNo:
                                messageBox.btnNo.TabIndex = 1;
                                messageBox.btnYes.TabIndex = 2;
                                break;
                            case MessageBoxButtons.RetryCancel:
                                messageBox.btnCancel.TabIndex = 1;
                                messageBox.btnRetry.TabIndex = 2;
                                break;
                            case MessageBoxButtons.AbortRetryIgnore:
                                messageBox.btnRetry.TabIndex = 1;
                                messageBox.btnIgnore.TabIndex = 2;
                                messageBox.btnAbort.TabIndex = 3;
                                break;
                            case MessageBoxButtons.YesNoCancel:
                                messageBox.btnNo.TabIndex = 1;
                                messageBox.btnCancel.TabIndex = 2;
                                messageBox.btnYes.TabIndex = 3;
                                break;
                        }
                        break;
                    case MessageBoxDefaultButton.Button3:
                        switch (buttons)
                        {
                            case MessageBoxButtons.AbortRetryIgnore:
                                messageBox.btnIgnore.TabIndex = 1;
                                messageBox.btnAbort.TabIndex = 2;
                                messageBox.btnRetry.TabIndex = 3;
                                break;
                            case MessageBoxButtons.YesNoCancel:
                                messageBox.btnCancel.TabIndex = 1;
                                messageBox.btnYes.TabIndex = 2;
                                messageBox.btnNo.TabIndex = 3;
                                break;
                        }
                        break;
                }

                return messageBox.ShowDialog();
            }
        }
    }
}