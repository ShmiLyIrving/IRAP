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
            try
            {
                TWaitting.Instance.ShowWaitForm("正在查询四班库存");

                grdvStockDetail.BeginDataUpdate();
                grdStockDetail.DataSource = TBLStockDetails.Get(itemNumber, lotNumber);
                grdvStockDetail.BestFitColumns();
                grdvStockDetail.EndDataUpdate();

                TWaitting.Instance.CloseWaitForm();
            }
            catch (Exception error)
            {
                TWaitting.Instance.CloseWaitForm();

                XtraMessageBox.Show(
                    string.Format("查询时发生错误：[{0}]", error.Message),
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}