using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AsimcoBatchMNGMT
{
    public partial class frmMaterialIn4Shift : DevExpress.XtraEditors.XtraForm
    {
        public frmMaterialIn4Shift()
        {
            InitializeComponent();
        }
        public frmMaterialIn4Shift(DataTable dt)
        {
            InitializeComponent();

            if (dt.Rows.Count > 0)
            {
                grdStockDetailIn4Shift.DataSource = dt;
                grdvStockDetailIn4Shift.BestFitColumns();
            }
        }
    }
}