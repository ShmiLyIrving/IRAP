using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IRAP.Global;
using BatchSystemMNGNT_Asimco.Entities;

namespace BatchSystemMNGNT_Asimco.Editors
{
    public partial class frmEditorIMTR01 : BatchSystemMNGNT_Asimco.Editors.frmCustomEditor
    {
        public frmEditorIMTR01()
        {
            InitializeComponent();
        }

        public frmEditorIMTR01(TEntityIMTR01 entity) : this()
        {
            SetEntity(entity);

            if (entity != null && entity.ExChange.Count > 0)
            {
                TEntityXMLIMTR01 exchange = entity.ExChange[0] as TEntityXMLIMTR01;

                edtUserID.Text = exchange.UserID;
                edtPassword.Text = exchange.PassWord;
                edtItemNumber.Text = exchange.ItemNumber;
                edtStockroomFrom.Text = exchange.StockroomFrom;
                edtBinFrom.Text = exchange.BinFrom;
                edtLotNumberFrom.Text = exchange.LotNumberFrom;
                edtStockroomTo.Text = exchange.StockroomTo;
                edtBinTo.Text = exchange.BinTo;
                edtLotNumberTo.Text = exchange.LotNumberTo;
                edtInventoryQuantity.Text = exchange.InventoryQuantity;

                itemNumber = exchange.ItemNumber;
                lotNumber = exchange.LotNumberFrom;
                skuID = entity.SKUID;

                edtErrText.Text = entity.ErrText;
            }
        }

        protected override bool SetValue()
        {
            if (entity != null && entity.ExChange.Count > 0)
            {
                TEntityXMLIMTR01 exchange =
                    entity.ExChange[0] as TEntityXMLIMTR01;

                //try
                //{
                //    Quantity issuedQty = new Quantity()
                //    {
                //        Scale = materialTrack.Scale,
                //        DoubleValue = Convert.ToDouble(edtIssuedQuantity.Text),
                //    };

                //    if (issuedQty.IntValue != materialTrack.QtyLoaded)
                //    {
                //        ((TEntityPICK08)entity).QtyLoaded = issuedQty;
                //    }
                //}
                //catch (Exception error)
                //{
                //    error.Data["ErrCode"] = 999999;
                //    error.Data["ErrText"] =
                //        string.Format(
                //            "无法将 [{0}] 转换成数值！",
                //            edtIssuedQuantity.Text);
                //    MSGHelp.Instance.ShowErrorMessage(error);

                //    edtIssuedQuantity.Text = exchange.IssuedQuantity;
                //    edtIssuedQuantity.Focus();

                //    return false;
                //}

                exchange.UserID = edtUserID.Text;
                exchange.PassWord = edtPassword.Text;
                exchange.ItemNumber = edtItemNumber.Text;
                exchange.StockroomFrom = edtStockroomFrom.Text;
                exchange.BinFrom = edtBinFrom.Text;
                exchange.LotNumberFrom = edtLotNumberFrom.Text;
                exchange.StockroomTo = edtStockroomTo.Text;
                exchange.BinTo = edtBinTo.Text;
                exchange.LotNumberTo = edtLotNumberTo.Text;
                exchange.InventoryQuantity = edtInventoryQuantity.Text;

                return true;
            }
            else
                return false;
        }

        private void edtLotNumberFrom_EditValueChanged(object sender, EventArgs e)
        {
            edtLotNumberTo.Text = edtLotNumberFrom.Text;
        }
    }
}
