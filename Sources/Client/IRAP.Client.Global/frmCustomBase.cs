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

            defaultLookAndFeel.LookAndFeel.SetSkinStyle(skinName);
        }

        private void frmCustomBase_Activated(object sender, EventArgs e)
        {
            if (MdiParent != null)
                WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// 显示运行等待窗体
        /// </summary>
        /// <param name="description"></param>
        /// <param name="caption"></param>
        protected void ShowWaitForm(string description, string caption = "")
        {
            if (!splashScreenManager.IsSplashFormVisible)
                splashScreenManager.ShowWaitForm();
            if (caption != "")
                splashScreenManager.SetWaitFormCaption(caption);
            else
                splashScreenManager.SetWaitFormCaption("请耐心等待......");
            splashScreenManager.SetWaitFormDescription(description);
        }

        /// <summary>
        /// 关闭运行等待窗体
        /// </summary>
        protected void CloseWaitForm()
        {
            if (splashScreenManager.IsSplashFormVisible)
                splashScreenManager.CloseWaitForm();
        }
    }
}