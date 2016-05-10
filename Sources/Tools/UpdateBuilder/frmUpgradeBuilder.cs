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
using System.IO;
using System.Security.Principal;

using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils;

using IRAP.Global;

namespace UpdateBuilder
{
    public partial class frmUpgradeBuilder : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string firstProject = "";

        public frmUpgradeBuilder()
        {
            InitializeComponent();
        }

        public frmUpgradeBuilder(string[] args) : this()
        {
            if (args.Length > 0 && File.Exists(args[0]))
            {
                firstProject = args[0];
            }
        }

        #region 自定义函数
        private void AddPageMdi(string fileName)
        {
            frmUpdateProjectFile childForm = null;
            if (fileName != "" && File.Exists(fileName))
                childForm = new frmUpdateProjectFile(fileName);
            else
                childForm = new frmUpdateProjectFile();

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

            #region 检查当前应用是否以管理员权限运行
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            bool isRunasAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            #endregion

            btnRegisterApp.Enabled = isRunasAdmin;
            if (!btnRegisterApp.Enabled)
            {
                btnRegisterApp.SuperTip = new SuperToolTip();
                btnRegisterApp.SuperTip.Items.Add("当前功能需要程序具有管理员权限才能使用！");
            }                    
        }

        private void frmUpgradeBuilder_Shown(object sender, EventArgs e)
        {
            AddPageMdi(firstProject);
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

        private void btnGenerate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBox.Show(System.IO.Path.GetExtension(@"C:\IRAP.INI"));
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                frmUpdateProjectFile form = ActiveMdiChild as frmUpdateProjectFile;
                form.Save();
            }
        }

        private void btnNewProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddPageMdi("");
        }

        private void btnOpenProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (MdiChildren.Length == 1 && 
                    MdiChildren[0] is frmUpdateProjectFile &&
                    (MdiChildren[0] as frmUpdateProjectFile).EmptyProject)
                {
                    MdiChildren[0].Close();
                }

                AddPageMdi(openFileDialog.FileName);
            }
        }

        private void btnSaveAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i< MdiChildren.Length; i++)
            {
                if (MdiChildren[i] is frmUpdateProjectFile)
                {
                    frmUpdateProjectFile form = MdiChildren[i] as frmUpdateProjectFile;
                    form.Save();
                }
            }
        }

        private void btnSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                frmUpdateProjectFile form = ActiveMdiChild as frmUpdateProjectFile;
                form.SaveAs();
            }
        }

        private void btnRegisterApp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FileTypeRegInfo fileTypeRegInfo = new FileTypeRegInfo(".upb");

            fileTypeRegInfo.Description = "IRAP 自动更新工程文件";
            fileTypeRegInfo.ExePath = Application.ExecutablePath.Replace('/', '\\');
            fileTypeRegInfo.ExtendName = ".upb";
            fileTypeRegInfo.IcoPath = Application.ExecutablePath.Replace('/', '\\');

            FileTypeRegister.RegisterFileType(fileTypeRegInfo);
        }
    }
}
