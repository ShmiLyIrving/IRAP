using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IRAP.Entity.MDM;

namespace IRAP.Client.GUI.MDM
{
    public partial class frmSelectOperation : IRAP.Client.Global.frmCustomBase
    {
        public frmSelectOperation()
        {
            InitializeComponent();
        }

        public ProcessOperation OperationSelected
        {
            get
            {
                if (cboOperations.SelectedItem == null)
                    return null;
                else
                    return cboOperations.SelectedItem as ProcessOperation;
            }
        }
    }
}
