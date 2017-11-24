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
    public partial class frmserchstock : DevExpress.XtraEditors.XtraForm
    {
        public frmserchstock()
        {
            InitializeComponent();
        }
        public frmserchstock(DataTable dt)
        {
            InitializeComponent();
            if (dt.Rows.Count > 0)
            {
                this.gridControl1.DataSource = dt;
            }
        }
    }
}