using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using IRAP.Client.Global.Resources;

namespace IRAP.AutoUpgrade
{
    public partial class frmShowUpgrade : DevExpress.XtraEditors.XtraForm
    {
        private static frmShowUpgrade _instance = null;

        public frmShowUpgrade()
        {
            InitializeComponent();

            BackgroundImage = 
                IRAP.Client.Global.Resources.Properties.Resources.UserLogin;
            BackgroundImageLayout = ImageLayout.Tile;
        }

        public static frmShowUpgrade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmShowUpgrade();
                return _instance;
            }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set
            {
                if (value.Trim() == "")
                {
                    _instance.Hide();
                    Application.DoEvents();
                }
                else
                {
                    _instance.Show();
                    lblMessage.Text = value;
                    Application.DoEvents();
                }
            }
        }
    }
}