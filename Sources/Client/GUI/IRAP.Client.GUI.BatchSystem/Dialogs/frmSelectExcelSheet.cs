using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.BatchSystem.Dialogs
{
    public partial class frmSelectExcelSheet : IRAP.Client.Global.frmCustomBase
    {
        public frmSelectExcelSheet()
        {
            InitializeComponent();
        }

        public frmSelectExcelSheet(List<string> items) : this()
        {
            cboSelectItems.Properties.Items.Clear();
            foreach (string item in items)
                cboSelectItems.Properties.Items.Add(item);

            if (items.Count > 0)
                cboSelectItems.SelectedIndex = 0;
        }

        public string SelectSheetName
        {
            get
            {
                if (cboSelectItems.SelectedItem != null)
                    return cboSelectItems.SelectedItem as string;
                else
                    return "";
            }
        }

        private void cboSelectItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = cboSelectItems != null;
        }
    }
}
