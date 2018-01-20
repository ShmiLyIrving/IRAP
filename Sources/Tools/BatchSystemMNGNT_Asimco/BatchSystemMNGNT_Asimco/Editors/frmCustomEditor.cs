using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using IRAP.Global;

namespace BatchSystemMNGNT_Asimco.Editors
{
    public partial class frmCustomEditor : DevExpress.XtraEditors.XtraForm
    {
        protected string itemNumber = "";
        protected string lotNumber = "";
        protected string skuID = "";

        public frmCustomEditor()
        {
            InitializeComponent();
        }

        private void btnFindData_Click(object sender, EventArgs e)
        {
            if (itemNumber != "" || lotNumber != "")
            {
                try
                {
                    TWaitting.Instance.ShowWaitForm("正在查询四班库存情况");

                    List<Entities.TTableStockDetail> datas =
                        TBLStockDetails.Get(itemNumber, lotNumber);

                    if (datas.Count > 0)
                    {
                        edtBIN.Text = datas[0].BIN;
                        edtQTY_BY_LOC.Text = datas[0].QTY_BY_LOC.ToString();
                    }
                    else
                    {
                        edtBIN.Text = "无记录";
                        edtQTY_BY_LOC.Text = "无记录";
                    }

                    TWaitting.Instance.CloseWaitForm();
                }
                catch (Exception error)
                {
                    edtQTY_BY_LOC.Text = "";
                    edtBIN.Text = "";

                    TWaitting.Instance.CloseWaitForm();

                    MSGHelp.Instance.ShowErrorMessage(error);
                }
            }
        }

        private void frmCustomEditor_Load(object sender, EventArgs e)
        {
            btnFindData.PerformClick();

            if (skuID != "")
            {
                try
                {
                    TWaitting.Instance.ShowWaitForm("正在查询批次库存情况");

                    List<Entities.TTableMaterialStore> datas =
                        DAL.TDBHelper.GetMaterialStore(skuID);
                    if (datas.Count > 0)
                    {
                        edtSKUID.Text = datas[0].SKUID;
                        edtRecvBatchNo.Text = datas[0].RecvBatchNo;
                        edtT106Code.Text = datas[0].StorageBin;
                        edtQtyInStore.Text = datas[0].QtyInStore.ToString();
                    }
                    else
                    {
                        edtSKUID.Text = skuID;
                        edtRecvBatchNo.Text = "无记录";
                        edtT106Code.Text = "无记录";
                        edtQtyInStore.Text = "无记录";
                    }

                    TWaitting.Instance.CloseWaitForm();
                }
                catch (Exception error)
                {
                    edtSKUID.Text = skuID;
                    edtRecvBatchNo.Text = "无记录";
                    edtT106Code.Text = "无记录";
                    edtQtyInStore.Text = "无记录";

                    TWaitting.Instance.CloseWaitForm();

                    MSGHelp.Instance.ShowErrorMessage(error);
                }
            }
        }

        private void btnFindDatas_Click(object sender, EventArgs e)
        {
            using (Dialogs.frmMaterialStoreIn4Shift form =
                new Dialogs.frmMaterialStoreIn4Shift(itemNumber, lotNumber))
            {
                form.ShowDialog();
            }
        }
    }
}