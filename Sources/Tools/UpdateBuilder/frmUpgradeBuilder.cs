using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;

using IRAP.Global;

namespace UpdateBuilder
{
    public partial class frmUpgradeBuilder : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmUpgradeBuilder()
        {
            InitializeComponent();
        }

        public frmUpgradeBuilder(string[] args) : this()
        {
            foreach (string arg in args)
            {
                XtraMessageBox.Show(arg);
            }
        }

        #region 自定义函数
        private void AddPageMdi()
        {
            frmUpdateProjectFile childForm = new frmUpdateProjectFile();
            childForm.MdiParent = this;
            childForm.Show();
        }
        #endregion

        private void frmUpgradeBuilder_Load(object sender, EventArgs e)
        {
            #region 自动注册文件类型
            if (!FileTypeRegister.FileTypeRegistered(".upb"))
            {
                FileTypeRegInfo fileTypeRegInfo = new FileTypeRegInfo(".upb");

                fileTypeRegInfo.Description = "IRAP 自动更新工程文件";
                fileTypeRegInfo.ExePath = Application.ExecutablePath.Replace('/', '\\');
                fileTypeRegInfo.ExtendName = ".upb";
                fileTypeRegInfo.IcoPath = Application.ExecutablePath.Replace('/', '\\');

                FileTypeRegister.RegisterFileType(fileTypeRegInfo);
            }
            #endregion

            WindowState = FormWindowState.Maximized;
        }

        private void btnNew_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            AddPageMdi();
        }

        private void ribbonControl_Merge(object sender, RibbonMergeEventArgs e)
        {
            RibbonControl parentRibbon = sender as RibbonControl;
            RibbonControl childRibbon = e.MergedChild;
            parentRibbon.StatusBar.MergeStatusBar(childRibbon.StatusBar);
        }

        private void ribbonControl_UnMerge(object sender, RibbonMergeEventArgs e)
        {
            RibbonControl parentRibbon = sender as RibbonControl;
            parentRibbon.StatusBar.UnMergeStatusBar();
        }

        private void btnQuit_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            Close();
        }
    }
}
