using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors.Controls;

using IRAP.Entities.MES;
using IRAP.Client.GUI.BatchSystem.Entities;

namespace IRAP.Client.GUI.BatchSystem.Dialogs
{
    internal partial class frmSelectMaterialPreparation : IRAP.Client.Global.frmCustomBase
    {

        private TMaterialPreparationInfos mps = new TMaterialPreparationInfos();
        private TMaterialPreparationInfo mp = null;

        public frmSelectMaterialPreparation()
        {
            InitializeComponent();
        }

        public frmSelectMaterialPreparation(TMaterialPreparationInfos mps) : this()
        {
            this.mps = mps;
        }

        public TMaterialPreparationInfo MP
        {
            get { return mp; }
        }

        private void frmSelectMaterialPreparation_Shown(object sender, EventArgs e)
        {
            foreach (TMaterialPreparationInfo item in mps.Items)
            {
                ilstMaterialPreparation.Items.Add(item, 0);
            }
        }

        private void ilstMaterialPreparation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageListBoxItem item = ilstMaterialPreparation.SelectedItem as ImageListBoxItem;

            if (item != null)
            {
                TMaterialPreparationInfo mp = item.Value as TMaterialPreparationInfo;

                if (mp != null)
                {
                    grdPWOs.DataSource = mp.PWOs;
                }
                else
                {
                    grdPWOs.DataSource = null;
                }
            }
            else
            {
                grdPWOs.DataSource = null;
            }
            grdvPWOs.BestFitColumns();

            Refresh();
        }

        private void frmSelectMaterialPreparation_Paint(object sender, PaintEventArgs e)
        {
            if (ilstMaterialPreparation.SelectedItem == null)
            {
                btnSelect.Enabled = false;
            }
            else
            {
                if (grdPWOs.DataSource == null)
                {
                    btnSelect.Enabled = false;
                }
                else
                {
                    if ((grdvPWOs.DataSource as List<EntityBatchPWO>).Count >= 0)
                    {
                        btnSelect.Enabled = true;
                    }
                    else
                    {
                        btnSelect.Enabled = false;
                    }
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            mp = (ilstMaterialPreparation.SelectedItem as ImageListBoxItem).Value as TMaterialPreparationInfo;

            DialogResult = DialogResult.OK;
        }
    }
}
