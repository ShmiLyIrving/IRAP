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
        protected Entities.TEntityCustomLog entity = null;

        public frmCustomEditor()
        {
            InitializeComponent();
        }

        protected void SetEntity(Entities.TEntityCustomLog entity)
        {
            this.entity = entity;

            // 如果当前程序具有管理员权限，则对所有的日志记录具有执行的功能，
            // 否则只有对等待重试的记录具有执行功能
            if (SysParams.Instance.IsAdmin)
                btnExecute.Enabled = true;
            else
            {
                if (entity != null &&
                    (!entity.Retried && entity.ErrCode != 0))
                    btnExecute.Enabled = true;
                else
                    btnExecute.Enabled = false;
            }
        }

        protected virtual bool SetValue()
        {
            throw new NotImplementedException();
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

                    if (datas.Count == 1)
                    {
                        edt4ShiftBIN.Text = datas[0].BIN;
                        edt4ShiftQTY_BY_LOC.Text = datas[0].QTY_BY_LOC.ToString();
                    }
                    else
                    {
                        edt4ShiftBIN.Text = "无记录";
                        edt4ShiftQTY_BY_LOC.Text = "无记录";
                    }

                    TWaitting.Instance.CloseWaitForm();
                }
                catch (Exception error)
                {
                    edt4ShiftQTY_BY_LOC.Text = "";
                    edt4ShiftBIN.Text = "";

                    TWaitting.Instance.CloseWaitForm();

                    MSGHelp.Instance.ShowErrorMessage(error);
                }
            }
        }

        protected virtual void GetMaterialInfo()
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

        private void frmCustomEditor_Load(object sender, EventArgs e)
        {
            GetMaterialInfo();
        }

        private void btnFindDatas_Click(object sender, EventArgs e)
        {
            using (Dialogs.frmMaterialStoreIn4Shift form =
                new Dialogs.frmMaterialStoreIn4Shift(itemNumber, lotNumber))
            {
                form.ShowDialog();
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (SetValue())
                DialogResult = DialogResult.OK;
        }
    }
}