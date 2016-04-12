using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;

using IRAP.Global;

namespace IRAP.Client.Global
{
    public partial class frmCustomBase : XtraForm
    {
        protected static DefaultLookAndFeel defaultLookAndFeel =
            new DefaultLookAndFeel();

        public frmCustomBase()
        {
            InitializeComponent();

            string skinName = "";
            skinName = IniFile.ReadString(
                "AppSetting",
                "Skin",
                "Blue",
                string.Format(
                    @"{0}\IRAP.ini",
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase));

            defaultLookAndFeel.LookAndFeel.SkinName = skinName;
        }

        private void frmCustomBase_Activated(object sender, EventArgs e)
        {
            if (MdiParent != null)
                WindowState = FormWindowState.Maximized;
        }
    }
}