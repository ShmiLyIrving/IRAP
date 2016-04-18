using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IRAP.Entity.Kanban;
using IRAP.Entity.MDM;

namespace IRAP.Client.GUI.MDM
{
    public partial class frmProcessProperties : IRAP.Client.Global.frmCustomBase
    {
        private ProductProcess processProperties = null;

        public frmProcessProperties()
        {
            InitializeComponent();
        }

        public ProductProcess ProcessProperties
        {
            get
            {
                processProperties.MinPercent = (int)edtLowLimit.Value;
                processProperties.MaxPercent = (int)edtHighLimit.Value;
                processProperties.ProcessPercentage = (int)edtProcessPercentage.Value;
                if (cboT121LeafID.SelectedItem != null)
                {
                    processProperties.T121LeafID = (cboT121LeafID.SelectedItem as LeafSetEx).LeafID;
                    processProperties.T121Name = (cboT121LeafID.SelectedItem as LeafSetEx).LeafName;
                }
                else
                {
                    processProperties.T121LeafID = 0;
                    processProperties.T121Name = "";
                }

                return processProperties;
            }
            set
            {
                processProperties = value;

                edtLowLimit.EditValue = value.MinPercent;
                edtHighLimit.EditValue = value.MaxPercent;
                edtProcessPercentage.EditValue = value.ProcessPercentage;

                for (int i = 0; i < cboT121LeafID.Properties.Items.Count; i++)
                {
                    LeafSetEx t121Item = cboT121LeafID.Properties.Items[i] as LeafSetEx;
                    if (t121Item.LeafID == value.T121LeafID)
                    {
                        cboT121LeafID.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        public List<LeafSetEx> T121Items
        {
            set
            {
                cboT121LeafID.Properties.Items.Clear();
                foreach (LeafSetEx item in value)
                {
                    cboT121LeafID.Properties.Items.Add(item);
                }
            }
        }
    }
}
