using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IRAP.Global;
using BatchSystemMNGNT_Asimco.Entities;
using BatchSystemMNGNT_Asimco.DAL;

namespace BatchSystemMNGNT_Asimco.Editors
{
    public partial class frmEditorPICK08 : BatchSystemMNGNT_Asimco.Editors.frmCustomEditor
    {
        private TTableRSFactPWOMaterialTrack materialTrack = null;

        public frmEditorPICK08()
        {
            InitializeComponent();
        }

        public frmEditorPICK08(TEntityPICK08 entity) : this()
        {
            SetEntity(entity);

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

                ShowPWOMaterialTrackInfo(
                    entity.SKUID,
                    exchange.OrderNumber,
                    Tools.ConvertToInt32(exchange.LineNumber));
            }
        }

        private void ShowPWOMaterialTrackInfo(
            string skuID,
            string moNumber,
            int moLineNo)
        {
            TWaitting.Instance.ShowWaitForm("获取批次提料信息");
            try
            {
                List<TTableRSFactPWOMaterialTrack> datas =
                    TDBHelper.GetMaterialTrack(skuID, moNumber, moLineNo);

                if (datas.Count > 0)
                {
                    materialTrack = datas[0].Clone();

                    Quantity qty = new Quantity()
                    {
                        IntValue = materialTrack.QtyLoaded,
                        Scale = materialTrack.Scale,
                    };

                    edtQtyLoaded.Text = qty.ToString();
                }
                else
                {
                    materialTrack = null;
                    edtQtyLoaded.Text = "";
                }

                TWaitting.Instance.CloseWaitForm();
            }
            catch (Exception error)
            {
                TWaitting.Instance.CloseWaitForm();

                MSGHelp.Instance.ShowErrorMessage(error);
            }
        }

        protected override bool SetValue()
        {
            if (entity != null && entity.ExChange.Count > 0)
            {
                TEntityXMLPICK08 exchange =
                    entity.ExChange[0] as TEntityXMLPICK08;

                try
                {
                    Quantity issuedQty = new Quantity()
                    {
                        Scale = materialTrack.Scale,
                        DoubleValue = Convert.ToDouble(edtIssuedQuantity.Text),
                    };

                    if (issuedQty.IntValue != materialTrack.QtyLoaded)
                    {
                        ((TEntityPICK08)entity).QtyLoaded = issuedQty;
                    }
                }
                catch (Exception error)
                {
                    error.Data["ErrCode"] = 999999;
                    error.Data["ErrText"] =
                        string.Format(
                            "无法将 [{0}] 转换成数值！",
                            edtIssuedQuantity.Text);
                    MSGHelp.Instance.ShowErrorMessage(error);

                    edtIssuedQuantity.Text = exchange.IssuedQuantity;
                    edtIssuedQuantity.Focus();

                    return false;
                }

                exchange.UserID = edtUserID.Text;
                exchange.PassWord = edtPassword.Text;
                exchange.OrderNumber = edtOrderNumber.Text;
                exchange.LineNumber = edtLineNumber.Text;
                exchange.ItemNumber = edtItemNumber.Text;
                exchange.LotNumber = edtLotNumber.Text;
                exchange.Stockroom = edtStockroom.Text;
                exchange.Bin = edtBin.Text;
                exchange.IssuedQuantity = edtIssuedQuantity.Text;

                return true;
            }
            else
                return false;
        }
    }
}
