using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.WCF.Client.Method;
using IRAP.Entities.MDM;
using IRAP.Entities.MES;

namespace IRAP.Client.GUI.BatchSystem
{
    public partial class frmRunningSPPModify : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<WIPStation> equipments = new List<WIPStation>();
        private SmeltBatchProductionInfo infoSmeltProduct = null;

        public frmRunningSPPModify()
        {
            InitializeComponent();

            GetStation();
            lstEquipments.Items.Clear();
            foreach (WIPStation station in equipments)
            {
                lstEquipments.Items.Add(station);
            }
            lstEquipments.SelectedIndexChanged +=
                lstEquipmentsSelectedIndexChanged;
            if (lstEquipments.Items.Count > 0)
            {
                lstEquipments.SelectedIndex = 0;
                lstEquipmentsSelectedIndexChanged(lstEquipments, new EventArgs());
            }
        }

        private void GetStation()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                equipments.Clear();
                IRAPMDMClient.Instance.ufn_GetList_WIPStationsOfAHost(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref equipments,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取指定设备的当前生产状态
        /// </summary>
        private void GetProductingInfo(
            int t107LeafID,
            int t216LeafID,
            int t133LeafID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                infoSmeltProduct = null;
                IRAPMESBatchClient.Instance.ufn_GetInfo_SmeltBatchProduct(
                    IRAPUser.Instance.CommunityID,
                    t107LeafID,
                    t216LeafID,
                    t133LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref infoSmeltProduct,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据制造订单号和制造订单行号查询未结生产工单
        /// </summary>
        /// <param name="moNumber"></param>
        /// <param name="moLineNo"></param>
        /// <returns></returns>
        private OpenPWOInfo FindPWOWithNumberAndNo(string moNumber, int moLineNo)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            OpenPWOInfo rlt = null;

            TWaitting.Instance.ShowWaitForm("查询未结生产工单");
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<OpenPWOInfo> pwos = new List<OpenPWOInfo>();

                IRAPMESClient.Instance.mfn_GetInfo_OpenPWOs(
                    IRAPUser.Instance.CommunityID,
                    moNumber,
                    moLineNo,
                    ref pwos,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                    XtraMessageBox.Show(
                        errText,
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                {
                    if (pwos.Count > 0)
                        rlt = pwos[0].Clone();
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                TWaitting.Instance.CloseWaitForm();
            }

            return rlt;
        }

        private void EmptyPWONos()
        {
            grdvOrders.BeginDataUpdate();
            grdOrders.DataSource = null;
            grdvOrders.EndDataUpdate();

            grdvOrders.BestFitColumns();
            grdvOrders.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        private void SetPWONos(List<OrderInfo> orders)
        {
            List<PWOItem> items = new List<PWOItem>();
            foreach (OrderInfo order in orders)
                items.Add(
                    new PWOItem()
                    {
                        MONumber = order.MONumber,
                        MOLineNo = order.MOLineNo,
                        Texture = order.Texture,
                        T102Code = order.T102Code,
                        PlateNo = order.PlateNo,
                        LotNumber = order.LotNumber,
                        MachineModelling = order.MachineModelling,
                        FoldNumber = order.FoldNumber,
                        ErrCode = 0,
                        ErrText = "",
                    });

            // 保存该炉次所熔炼的材质
            if (items.Count > 0 &&
                infoSmeltProduct != null)
                infoSmeltProduct.T131Code = items[0].Texture.Substring(0, 3);

            grdvOrders.BeginDataUpdate();
            BindingSource bsSource = new BindingSource();
            bsSource.DataSource = items;
            grdOrders.DataSource = bsSource;
            grdvOrders.EndDataUpdate();

            grdvOrders.BestFitColumns();

            if (orders.Count > 0)
                grdvOrders.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            else
                grdvOrders.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        private void GetOrders(string batchNo)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                List<OrderInfo> orders = new List<OrderInfo>();
                IRAPMESBatchClient.Instance.ufn_GetList_SmeltBatchPWONo(
                    IRAPUser.Instance.CommunityID,
                    batchNo,
                    IRAPUser.Instance.SysLogID,
                    ref orders,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    EmptyPWONos();

                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    SetPWONos(orders);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void lstEquipmentsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEquipments.SelectedItem != null &&
                lstEquipments.SelectedItem is WIPStation)
            {
                WIPStation station = lstEquipments.SelectedItem as WIPStation;
                GetProductingInfo(
                    station.T107LeafID,
                    station.T216LeafID,
                    station.T133LeafID);
                if (infoSmeltProduct != null &&
                    infoSmeltProduct.InProduction == 1)
                {
                    GetOrders(infoSmeltProduct.BatchNumber);
                }
                else
                    EmptyPWONos();
            }
            else
                EmptyPWONos();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstEquipmentsSelectedIndexChanged(lstEquipments, new EventArgs());
        }

        private void grdvOrders_ValidateRow(
            object sender,
            ValidateRowEventArgs e)
        {
            if (e.Row != null &&
                e.Row is PWOItem)
            {
                PWOItem order = e.Row as PWOItem;

                // 校验材质
                if (order.Texture.Substring(0, 3) != infoSmeltProduct.T131Code)
                {
                    order.ErrCode = 99;
                    order.ErrText = string.Format("材质必须是 [{0}] 系列的", infoSmeltProduct.T131Code);
                }
                else
                {
                    order.ErrCode = 0;
                    order.ErrText = "";
                }

                // 校验工单信息
                OpenPWOInfo pwo =
                    FindPWOWithNumberAndNo(order.MONumber, order.MOLineNo);
                if (pwo == null)
                {
                    order.ErrCode += 1;
                    order.ErrText +=
                        string.Format(
                            "{0};未找到 订单号[{1}]和行号[{2}] 的制造订单",
                            order.ErrText,
                            order.MONumber,
                            order.MOLineNo);
                }
                else
                {
                    if (pwo.ProductNo != order.T102Code)
                    {
                        order.ErrCode += 1;
                        order.ErrText +=
                            string.Format(
                                "{0};订单号[{1}]和行号[{2}] 的制造订单的产品为[{3}]",
                                order.ErrText,
                                order.MONumber,
                                order.MOLineNo,
                                pwo.ProductNo);
                    }
                }
            }
        }

        private void grdvOrders_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            if (grdOrders.DataSource != null &&
                grdOrders.DataSource is BindingList<PWOItem>)
            {
                BindingList<PWOItem> orders = grdOrders.DataSource as BindingList<PWOItem>;
                orders[e.RowHandle].FoldNumber = 10;
            }
        }

        private void grdvOrders_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            grdvOrders.BestFitColumns();
        }
    }

    internal class PWOItem
    {
        public string MONumber { get; set; }
        public int MOLineNo { get; set; }
        public string Texture { get; set; }
        public string T102Code { get; set; }
        public string PlateNo { get; set; }
        public string LotNumber { get; set; }
        public string MachineModelling { get; set; }
        public int FoldNumber { get; set; }
        public int ErrCode { get; set; }
        public string ErrText { get; set; }
    }
}
