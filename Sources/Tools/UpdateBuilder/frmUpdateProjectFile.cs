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
using IRAP.AutoUpgrade;

namespace UpdateBuilder
{
    public partial class frmUpdateProjectFile : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<FileInfo> files = new List<FileInfo>();

        public frmUpdateProjectFile()
        {
            InitializeComponent();

            files.Add(new FileInfo() { FileName = @"D:\Working\IRAP\Bin\Client\Release\IRAP.exe", });
            files.Add(new FileInfo() { FileName = @"D:\Working\IRAP\Bin\Client\Release\IRAP.Global.dll", });

            tvlUpgradeFiles.DataSource = files;
        }

        private void btnFileAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tvlUpgradeFiles.BeginUpdate();

                files.Add(new FileInfo()
                {
                    FileName = openFileDialog.FileName,
                });

                tvlUpgradeFiles.RefreshDataSource();
                tvlUpgradeFiles.EndUpdate();
                tvlUpgradeFiles.BestFitColumns();
            }
        }
    }
}