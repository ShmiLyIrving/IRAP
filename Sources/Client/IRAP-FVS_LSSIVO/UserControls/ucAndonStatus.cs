using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucAndonStatus : ucCustomFVSKanban
    {
        public ucAndonStatus()
        {
            InitializeComponent();
        }

        private void ucAndonStatus_SizeChanged(object sender, EventArgs e)
        {
            int totalWidth =
                (Width - lblSystem.Left - lblTitle.Left -
                (lblSystem.Width + lblWarehouse.Width +
                lblTest.Width + lblTechnology.Width +
                lblEquipment.Width + lblProcedure.Width +
                lblPCBA.Width + lblOthers.Width +
                lblMaterialTrack.Width + lblQuality.Width +
                lblExpandPosition.Width)) / 10;

            lblWarehouse.Left = lblSystem.Left + lblSystem.Width + totalWidth;
            lblTest.Left = lblWarehouse.Left + lblWarehouse.Width + totalWidth;
            lblTechnology.Left = lblTest.Left + lblTest.Width + totalWidth;
            lblEquipment.Left = lblTechnology.Left + lblTechnology.Width + totalWidth;
            lblProcedure.Left = lblEquipment.Left + lblEquipment.Width + totalWidth;
            lblPCBA.Left = lblProcedure.Left + lblProcedure.Width + totalWidth;
            lblOthers.Left = lblPCBA.Left + lblPCBA.Width + totalWidth;
            lblMaterialTrack.Left = lblOthers.Left + lblOthers.Width + totalWidth;
            lblQuality.Left = lblMaterialTrack.Left + lblMaterialTrack.Width + totalWidth;
            lblExpandPosition.Left = lblQuality.Left + lblQuality.Width + totalWidth;
        }
    }
}
