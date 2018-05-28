using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace IRAP.Client.GUI.MDM.Dialogs
{
    public partial class frmProcessOperationEdit : IRAP.Client.Global.frmCustomBase
    {
        public frmProcessOperationEdit()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get { return edtFileName.Text; }
            set { edtFileName.Text = value; }
        }

        private void edtFileName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            openFileDialog.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                edtFileName.Text = openFileDialog.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edtFileName.Text.Trim()))
            {
                XtraMessageBox.Show(
                    "路径不能为空！",
                    "提示", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (!System.IO.File.Exists(edtFileName.Text.Trim()))
            {
                XtraMessageBox.Show(
                    "请检查文件路径是否正确，文件不存在！",
                    "提示", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
