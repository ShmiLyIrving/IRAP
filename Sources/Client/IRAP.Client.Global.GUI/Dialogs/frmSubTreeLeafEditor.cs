using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.Global.GUI.Dialogs
{
    public partial class frmSubTreeLeafEditor : IRAP.Client.Global.frmCustomBase
    {
        public frmSubTreeLeafEditor()
        {
            InitializeComponent();
        }

        public frmSubTreeLeafEditor(int nodeID)
            : this()
        {

            if (tpProperties != null)
            {
                switch (nodeID)
                {
                    case 210:
                        tpProperties.Text = "工装";
                        break;
                    case 5140:
                        tpProperties.Text = "制造工艺参数";
                        break;
                    case 5094:
                        tpProperties.Text = "制造质量参数";
                        break;
                }
            }
        }

        public string Caption
        {
            get
            {
                return tpProperties.Text = "";
            }
            set
            {
                tpProperties.Text = value;
            }
        }

        public string NodeCode
        {
            get { return edtNodeCode.Text; }
            set { edtNodeCode.Text = value; }
        }

        public string NodeName
        {
            get { return edtNodeName.Text; }
            set { edtNodeName.Text = value; }
        }

        public bool CanModifyNodeCode
        {
            get { return edtNodeCode.Enabled; }
            set { edtNodeCode.Enabled = value; }
        }

        private void frmSubTreeLeafEditor_Shown(object sender, EventArgs e)
        {
            edtNodeCode.Focus();
        }
    }
}
