using System.Windows.Forms;
using System.Configuration;

namespace IRAP.Client.Global.GUI.Dialogs
{
    public class ShowMessageBox
    {
        public static DialogResult Show(
            string text, 
            string caption = "", 
            MessageBoxButtons buttons = MessageBoxButtons.OK, 
            MessageBoxIcon icon = MessageBoxIcon.Asterisk, 
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            bool soundAlert = false;

            if (ConfigurationManager.AppSettings["SoundAlert"] != null)
                soundAlert = ConfigurationManager.AppSettings["SoundAlert"].ToString().ToUpper() == "TRUE";

            using (frmMessageBox messageBox = new frmMessageBox())
            {
                messageBox.Text = caption;
                messageBox.lblText.Text = text;

                int splitterWidth = 0;
                switch (buttons)
                {
                    case MessageBoxButtons.AbortRetryIgnore:
                        messageBox.btnAbort.Visible = true;
                        messageBox.btnRetry.Visible = true;
                        messageBox.btnIgnore.Visible = true;

                        splitterWidth = 
                            (messageBox.Width - 
                            messageBox.btnAbort.Width - 
                            messageBox.btnRetry.Width - 
                            messageBox.btnIgnore.Width) / 4;
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
                        messageBox.picIcon.Image = Properties.Resources.Asterisk;
                        break;
                    case MessageBoxIcon.Error:
                        if (soundAlert)
                            IRAP.Global.Tools.Play(Properties.Resources.ALARM9);
                        messageBox.picIcon.Image = Properties.Resources.Error;
                        break;
                    case MessageBoxIcon.Exclamation:
                        if (soundAlert)
                            IRAP.Global.Tools.Play(Properties.Resources.ALARM9);
                        messageBox.picIcon.Image = Properties.Resources.Exclamation;
                        break;
                    case MessageBoxIcon.Question:
                        messageBox.picIcon.Image = Properties.Resources.Question;
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
