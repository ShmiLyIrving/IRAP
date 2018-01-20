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
        private TEntityIMTR01 entity = null;

        public frmEditorIMTR01()
        {
            InitializeComponent();
        }

        public frmEditorIMTR01(TEntityIMTR01 entity) : this()
        {
            this.entity = entity;

            if (entity != null && entity.ExChange.Count > 0)
            {
                TEntityXMLIMTR01 exchange = entity.ExChange[0] as TEntityXMLIMTR01;

                itemNumber = exchange.ItemNumber;
                lotNumber = exchange.LotNumberFrom;
                skuID = entity.SKUID;

                edtErrText.Text = entity.ErrText;
            }
        }
    }
}
