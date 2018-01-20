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
    public partial class frmEditorPICK08 : BatchSystemMNGNT_Asimco.Editors.frmCustomEditor
    {
        private TEntityPICK08 entity = null;

        public frmEditorPICK08()
        {
            InitializeComponent();
        }

        public frmEditorPICK08(TEntityPICK08 entity) : this()
        {
            this.entity = entity;

            if (entity != null && entity.ExChange.Count > 0)
            {
                TEntityXMLPICK08 exchange = entity.ExChange[0] as TEntityXMLPICK08;

                edtUserID.Text = exchange.UserID;
                edtPassword.Text = exchange.PassWord;
                edtOrderNumber.Text = exchange.OrderNumber;
                edtLineNumber.Text = exchange.LineNumber;
                edtItemNumber.Text = exchange.ItemNumber;
                edtLotNumber.Text = exchange.LotNumber;
                edtStockroom.Text = exchange.Stockroom;
                edtBin.Text = exchange.Bin;
                edtIssuedQuantity.Text = exchange.IssuedQuantity;

                itemNumber = exchange.ItemNumber;
                lotNumber = exchange.LotNumber;
                skuID = entity.SKUID;

                edtErrText.Text = entity.ErrText;
            }
        }
    }
}
