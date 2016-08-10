using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.Global.GUI.Dialogs
{
    internal partial class frmAuthrizeCode : IRAP.Client.Global.frmCustomBase
    {
        public frmAuthrizeCode()
        {
            InitializeComponent();
        }

        public string NotifyMessage
        {
            get { return lblNotifyMessage.Text; }
            set { lblNotifyMessage.Text = value; }
        }

        public string InputString
        {
            get { return edtInputString.Text; }
        }

        private void frmAuthrizeCode_Activated(object sender, EventArgs e)
        {
            edtInputString.Focus();
        }

        private void edtInputString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnOK.PerformClick();
        }
    }

    public class InputAuthrizeCode
    {
        private static InputAuthrizeCode _instance = null;

        private InputAuthrizeCode() { }

        public static InputAuthrizeCode Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InputAuthrizeCode();
                return _instance;
            }
        }

        public string Execute(string notifyMessage = "")
        {
            using (frmAuthrizeCode inputForm=new frmAuthrizeCode())
            {
                if (notifyMessage.Trim() != "")
                    inputForm.NotifyMessage = notifyMessage;

                if (inputForm.ShowDialog() == DialogResult.OK)
                    return inputForm.InputString;
                else
                    return "";
            }
        }
    }
}
