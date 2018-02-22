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
    public partial class frmEditorINVA01 : BatchSystemMNGNT_Asimco.Editors.frmCustomEditor
    {
        public frmEditorINVA01()
        {
            InitializeComponent();
        }

        public frmEditorINVA01(TEntityINVA01 entity) : this()
        {
            SetEntity(entity);

            if (entity != null && entity.ExChange.Count > 0)
            {
                TEntityXMLINVA01 exchange = entity.ExChange[0] as TEntityXMLINVA01;

                edtUserID.Text = exchange.UserID;
                edtPassword.Text = exchange.PassWord;
                edtItemNumber.Text = exchange.ItemNumber;
                edtLotNumber.Text = exchange.LotNumber;
                edtStockroom.Text = exchange.Stockroom;
                edtBin.Text = exchange.Bin;
                edtActionCode.Text = exchange.ActionCode;
                edtAdjustQuantity.Text = exchange.AdjustQuantity;

                itemNumber = exchange.ItemNumber;
                lotNumber = exchange.LotNumber;
                skuID = entity.SKUID;

                edtErrText.Text = entity.ErrText;
            }
        }

        protected override bool SetValue()
        {
            if (entity != null && entity.ExChange.Count > 0)
            {
                TEntityXMLINVA01 exchange =
                    entity.ExChange[0] as TEntityXMLINVA01;

                exchange.PassWord = edtPassword.Text;
                exchange.LotNumber = edtLotNumber.Text;
                exchange.Bin = edtBin.Text;
                exchange.ActionCode = edtActionCode.Text;
                exchange.AdjustQuantity = edtAdjustQuantity.Text;

                return true;
            }
            else
                return false;
        }
    }
}
