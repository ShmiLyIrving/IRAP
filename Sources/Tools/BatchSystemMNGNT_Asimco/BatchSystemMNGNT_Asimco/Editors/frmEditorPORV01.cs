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
    public partial class frmEditorPORV01 : BatchSystemMNGNT_Asimco.Editors.frmCustomEditor
    {
        public frmEditorPORV01()
        {
            InitializeComponent();
        }

        public frmEditorPORV01(TEntityPORV01 entity) : this()
        {
            SetEntity(entity);

            if (entity != null && entity.ExChange.Count > 0)
            {
                TEntityXMLPORV01 exchange = entity.ExChange[0] as TEntityXMLPORV01;

                edtUserID.Text = exchange.UserID;
                edtPassword.Text = exchange.PassWord;
                edtItemNumber.Text = exchange.ItemNumber;
                edtLotNumberDefault.Text = exchange.LotNumberDefault;
                edtPONumber.Text = exchange.PONumber;
                edtPOLineNumber.Text = exchange.POLineNumber;
                edtStockroom1.Text = exchange.Stockroom1;
                edtBin1.Text = exchange.Bin1;
                edtReceiptQuantityMove1.Text = exchange.ReceiptQuantityMove1;
                edtPromisedDate.Text = exchange.PromisedDate;

                itemNumber = exchange.ItemNumber;
                lotNumber = exchange.LotNumberDefault;
                skuID = entity.SKUID;

                edtErrText.Text = entity.ErrText;
            }
        }

        protected override bool SetValue()
        {
            if (entity != null && entity.ExChange.Count > 0)
            {
                TEntityXMLPORV01 exchange = entity.ExChange[0] as TEntityXMLPORV01;

                exchange.PassWord = edtPassword.Text;
                exchange.PromisedDate = edtPromisedDate.Text;

                return true;
            }
            else
                return false;
        }
    }
}
