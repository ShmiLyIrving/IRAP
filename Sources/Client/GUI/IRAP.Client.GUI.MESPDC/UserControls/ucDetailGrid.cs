using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IRAP.Client.Global.Enums;
using DevExpress.XtraVerticalGrid;

namespace IRAP.Client.GUI.MESPDC.UserControls {
    public partial class ucDetailGrid : UserControl {
        public ucDetailGrid() {
            InitializeComponent();
        }

        [Browsable(true)]
        public string Title {
            get { return this.groupControl1.Text; }
            set { this.groupControl1.Text = value; }
        }

        [Browsable(true)]
        public DataTable DataSource {
            get { return this.vGridControl1.DataSource as DataTable; }
            set { this.vGridControl1.DataSource = value; }
        }

        [Browsable(true)]
        public string SaveBtnText {
            get { return this.btnSave.Text; }
            set { this.btnSave.Text = value; }
        }

        public VGridControl vGridControl {
            get { return this.vGridControl1; }
        }

        public delegate void BtnSaveClick(object sender, EventArgs e);
        public BtnSaveClick SaveClick; 
        private void btnSave_Click_1(object sender, EventArgs e) {
            if (SaveClick!=null) {
                SaveClick(sender, e);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (DataSource.Columns.Count < 0) {
                XtraMessageBox.Show(
                    "当前没有可配置的参数",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            using (Dialogs.frmItemsEditor formEditor =
                new Dialogs.frmItemsEditor(
                    EditStatus.New,
                    this.groupControl1.Text,
                    this.DataSource,
                    -1)) {
                if (formEditor.ShowDialog() == DialogResult.OK) {
                    this.vGridControl1.RefreshDataSource();
                }
            }
        }

        public void Clear() {
            this.vGridControl1.DataSource = null;
            this.vGridControl1.Rows.Clear();
        }

        private void btnModify_Click(object sender, EventArgs e) {
            if (DataSource.Columns.Count < 0) {
                XtraMessageBox.Show(
                    "当前没有可配置的参数",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            int idx = this.vGridControl1.FocusedRecord;
            if (idx < 0) {
                XtraMessageBox.Show(
                    "当前没有需要修改参数",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            using (Dialogs.frmItemsEditor formEditor =
                new Dialogs.frmItemsEditor(
                    EditStatus.Edit,
                   this.groupControl1.Text,
                    DataSource,
                    idx)) {
                if (formEditor.ShowDialog() == DialogResult.OK) {
                    this.vGridControl1.RefreshDataSource();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            int idx = this.vGridControl1.FocusedRecord;
            if (idx >= 0) {
                if (XtraMessageBox.Show(
                    string.Format(
                        "是否要删除选择的第[{0}]组参数值？",
                        idx + 1),
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                    DataSource.Rows.RemoveAt(idx);

                    this.vGridControl1.RefreshDataSource();
                }
            }
        }
          
    }
 
    
}
