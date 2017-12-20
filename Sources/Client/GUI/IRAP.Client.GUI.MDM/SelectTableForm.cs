using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MDM {
    public partial class SelectTableForm : IRAP.Client.Global.GUI.frmCustomFuncBase {
        public SelectTableForm(List<string> sheetLists) {
            InitializeComponent();
            FillData(sheetLists);
        }

        /// <summary>
        /// 选择的Sheet
        /// </summary>
        public string SelectSheet { 
            get { return this.comboxSheets.SelectedItem.ToString();} 
        }
        
        /// <summary>
        /// 是否确定
        /// </summary>
        public bool IsSelected {
            get { return _isSelected; }
        }
        private bool _isSelected;

        private void FillData(List<string> sheetLists) {
            if (sheetLists == null || sheetLists.Count == 0) {
                return;
            }
            this.comboxSheets.Properties.Items.AddRange(sheetLists);
        }

        private void btnOK_CheckedChanged(object sender, EventArgs e) {
            _isSelected = true;
            this.Close();
        }

        private void btnCancel_CheckedChanged(object sender, EventArgs e) {
            _isSelected = false;
            this.Close();
        }
       
    }
}
