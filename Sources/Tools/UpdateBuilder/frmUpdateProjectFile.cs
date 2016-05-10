using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using DevExpress.XtraBars;
using DevExpress.XtraEditors;

using IRAP.Global;

namespace UpdateBuilder
{
    public partial class frmUpdateProjectFile : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private UpgradeProject project = new UpgradeProject();

        public frmUpdateProjectFile()
        {
            InitializeComponent();

            SetTextName();
        }

        public frmUpdateProjectFile(string projectFileName)
        {
            InitializeComponent();

            project = LoadProject(projectFileName);

            SetTextName();
        }

        public bool EmptyProject
        {
            get
            {
                return (project.ProjectFileName == "新建项目" &&
                    project.Files.Count == 0);
            }
        }

        #region 自定义函数
        private UpgradeProject LoadProject(string fileName)
        {
            UpgradeProject rlt = new UpgradeProject();

            rlt.Load(fileName);

            return rlt;
        }

        private void SetTextName()
        {
            Text = (project.IsModified ? "* " : "") +
                project.ProjectFileName;
        }

        public void Save()
        {
            project.Save();

            tvlUpgradeFiles.BeginUpdate();
            tvlUpgradeFiles.RefreshDataSource();
            tvlUpgradeFiles.BestFitColumns();
            tvlUpgradeFiles.EndUpdate();

            SetTextName();
        }

        public void SaveAs()
        {
            project.SaveAs();

            tvlUpgradeFiles.BeginUpdate();
            tvlUpgradeFiles.RefreshDataSource();
            tvlUpgradeFiles.BestFitColumns();
            tvlUpgradeFiles.EndUpdate();

            SetTextName();
        }
        #endregion

        private void frmUpdateProjectFile_Load(object sender, EventArgs e)
        {
            tvlUpgradeFiles.BeginUpdate();
            tvlUpgradeFiles.DataSource = project.Files;
            tvlUpgradeFiles.RefreshDataSource();
            tvlUpgradeFiles.BestFitColumns();
            tvlUpgradeFiles.EndUpdate();
        }

        private void btnFileAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tvlUpgradeFiles.BeginUpdate();

                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                    project.AddFile(openFileDialog.FileNames[i]);

                tvlUpgradeFiles.RefreshDataSource();
                tvlUpgradeFiles.BestFitColumns();
                tvlUpgradeFiles.EndUpdate();
            }

            SetTextName();
        }

        private void frmUpdateProjectFile_Shown(object sender, EventArgs e)
        {
            if (project.FileCount() > 0)
                tvlUpgradeFiles.BestFitColumns();
        }

        private void btnRemoveFiles_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tvlUpgradeFiles.Selection.Count > 0)
            {
                for (int i = 0; i < tvlUpgradeFiles.Selection.Count; i++)
                {
                    project.DeleteFile(project.Files[tvlUpgradeFiles.Selection[i].Id]);

                    tvlUpgradeFiles.BeginUpdate();
                    tvlUpgradeFiles.RefreshDataSource();
                    tvlUpgradeFiles.BestFitColumns();
                    tvlUpgradeFiles.EndUpdate();

                    SetTextName();
                }
            }
        }

        private void btnAddFilesInDirectory_ItemClick(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnGenerate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!project.CanGenerateupgradeFile())
            {
                XtraMessageBox.Show(
                    "升级文件列表中没有内容，或者没有选择文件！",
                    "生成升级配置文件",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    project.GenerateUpgradeFile(saveFileDialog.FileName);
                }
            }
        }
    }
}