using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace BatchSystemMNGNT_Asimco.Dialogs
{
    public partial class frmMaterialStoreIn4Shift : DevExpress.XtraEditors.XtraForm
    {
        public frmMaterialStoreIn4Shift()
        {
            InitializeComponent();
        }

        public frmMaterialStoreIn4Shift(
            string itemNumber,
            string lotNumber) : this()
        {
            grdvStockDetail.BeginDataUpdate();
            grdStockDetail.DataSource = TBLStockDetails.Get(itemNumber, lotNumber);
            grdvStockDetail.BestFitColumns();
            grdvStockDetail.EndDataUpdate();
        }
    }
}