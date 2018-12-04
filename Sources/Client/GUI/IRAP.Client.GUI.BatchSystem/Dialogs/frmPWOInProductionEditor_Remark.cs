using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IRAP.Entities.MES;

namespace IRAP.Client.GUI.BatchSystem.Dialogs
{
    public partial class frmPWOInProductionEditor_Remark : IRAP.Client.Global.frmCustomBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private BatchPWOInfo pwo = null;

        public frmPWOInProductionEditor_Remark()
        {
            InitializeComponent();
        }

        public frmPWOInProductionEditor_Remark(
            ref BatchPWOInfo pwo) : this()
        {
            this.pwo = pwo;

            if (pwo == null)
            {
                throw new Exception("生产工单对象不能空白！");
            }
            else
            {
                edtPWONo.Text = pwo.PWONo;
                edtProductNo.Text = pwo.T102Code;
                edtProductName.Text = pwo.T102Name;
                edtBatchNo.Text = pwo.LotNumber;
                edtTextureCode.Text = pwo.Texture;
                edtQuantity1.Value = Convert.ToDecimal(pwo.Quantity1);
                edtQuantity2.Value = Convert.ToDecimal(pwo.Quantity2);
                edtDisplayRemark.Text = pwo.DisplayRemark;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            pwo.DisplayRemark = edtDisplayRemark.Text.Trim();
            DialogResult = DialogResult.OK;
        }
    }
}
