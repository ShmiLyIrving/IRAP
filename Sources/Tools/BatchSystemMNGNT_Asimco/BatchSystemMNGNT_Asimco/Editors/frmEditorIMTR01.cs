using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

        private void edtLotNumberFrom_EditValueChanged(object sender, EventArgs e)
        {
            edtLotNumberTo.Text = edtLotNumberFrom.Text;
        }
    }
}
