using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.Global.GUI.Dialogs
{
    public partial class frmGetString : IRAP.Client.Global.frmCustomBase
    {
        public frmGetString()
        {
            InitializeComponent();
        }

        public string Message
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public string String
        {
            get { return edtInputString.Text; }
        }
    }

    public class GetString
    {
        private static GetString _instance = null;
        private frmGetString formGetString = new frmGetString();

        private GetString() { }

        public static GetString Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GetString();
                return _instance;
            }
        }   

        public string Show(
            string caption,
            string messages)
        {
            string rlt = "";

            formGetString.Text = caption;
            formGetString.Message = messages;

            if (formGetString.ShowDialog() == DialogResult.OK)
                rlt = formGetString.String;

            return rlt;
        }
    }
}
