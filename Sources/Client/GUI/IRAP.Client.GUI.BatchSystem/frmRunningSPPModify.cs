using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.WCF.Client.Method;
using IRAP.Entities.MDM;
using IRAP.Entities.MDM.Tables;
using IRAP.Entities.MES;

namespace IRAP.Client.GUI.BatchSystem
{
    public partial class frmRunningSPPModify : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<WIPStation> equipments = new List<WIPStation>();
        private SmeltBatchProductionInfo infoSmeltProduct = null;
        private DataTable dtPWOs = null;

        public frmRunningSPPModify()
        {
            InitializeComponent();

            dtPWOs = CreateGridDataSource();

            #region 过滤删除的行
            grdvOrders.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            grdvOrders.ActiveFilterString = "[RecordStatus] <> 3";
            #endregion
            grdvOrders.BestFitColumns();

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

        private DataTable CreateGridDataSource()
        {
            DataTable dtResult = new DataTable();

            dtResult.Columns.Add("Ordinal", typeof(int));
            dtResult.Columns.Add("BatchNumber", typeof(string));
            dtResult.Columns.Add("PWONo", typeof(string));
            dtResult.Columns.Add("MONumber", typeof(string));
            dtResult.Columns.Add("MOLineNo", typeof(int));
            dtResult.Columns.Add("T102Code", typeof(string));
            dtResult.Columns.Add("LinkedFactID", typeof(long));
            dtResult.Columns.Add("T131Code", typeof(string));
            dtResult.Columns.Add("Qty", typeof(long));
            dtResult.Columns.Add("PlateNo", typeof(string));
            dtResult.Columns.Add("LotNumber", typeof(string));
            dtResult.Columns.Add("MachineModelling", typeof(string));
            dtResult.Columns.Add("FoldNumber", typeof(int));
            dtResult.Columns.Add("RecordStatus", typeof(int));      // 当前记录状态：0-正常；1-新增；2-修改；3-删除
            dtResult.Columns.Add("ErrCode", typeof(int));
            dtResult.Columns.Add("ErrText", typeof(string));

            return dtResult;
        }

        private void SetPWONos(List<OrderInfo> orders)
        {
            dtPWOs.Rows.Clear();

            foreach (OrderInfo order in orders)
            {
                DataRow dr = dtPWOs.NewRow();

                dr["Ordinal"] = order.Ordinal;
                dr["BatchNumber"] = order.BatchNumber;
                dr["PWONo"] = order.PWONo;
                dr["MONumber"] = order.MONumber;
                dr["MOLineNo"] = order.MOLineNo;
                dr["T131Code"] = order.Texture;
                dr["T102Code"] = order.T102Code;
                dr["LinkedFactID"] = order.FactID;
                dr["Qty"] = order.Qty;
                dr["PlateNo"] = order.PlateNo;
                dr["LotNumber"] = order.LotNumber;
                dr["MachineModelling"] = order.MachineModelling;
                dr["FoldNumber"] = order.FoldNumber;
                dr["RecordStatus"] = 0;
                dr["ErrCode"] = 0;
                dr["ErrText"] = "";

                dtPWOs.Rows.Add(dr);
            }

            // 保存该炉次所熔炼的材质
            if (dtPWOs.Rows.Count > 0 &&
                infoSmeltProduct != null)
                infoSmeltProduct.T131Code = dtPWOs.Rows[0]["T131Code"].ToString().Substring(0, 3);

            grdvOrders.BeginDataUpdate();
            grdOrders.DataSource = dtPWOs;
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

            TWaitting.Instance.ShowWaitForm("获取当前设备正在生产的工单");
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
                TWaitting.Instance.CloseWaitForm();
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
            DataRow dr = grdvOrders.GetDataRow(e.RowHandle);
            if (dr !=  null)
            {
                try
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Modified:
                        case DataRowState.Detached:
                        case DataRowState.Added:
                            if ((int)dr["RecordStatus"] == 0)
                                dr["RecordStatus"] = 2;

                            #region 校验工单信息
                            if (dr["MONumber"] == null ||
                                ((string)dr["MONumber"]).Trim() == "")
                            {
                                dr["ErrCode"] = 99;
                                dr["ErrText"] = "订单号不能空白";
                            }
                            else
                            {
                                // 检查工单列表中是否有重复的订单号和行号
                                foreach (DataRow dataRow in dtPWOs.Rows)
                                {
                                    if ((string)dr["MONumber"] == (string)dataRow["MONumber"] &&
                                        (int)dr["MOLineNo"] == (int)dataRow["MOLineNo"] &&
                                        (int)dr["Ordinal"] != (int)dataRow["Ordinal"] &&
                                        (int)dataRow["RecordStatus"] != 3)
                                    {
                                        dr["ErrCode"] = 99;
                                        dr["ErrText"] = "在同一炉次中不允许有相同的订单号和行号出现";
                                        return;
                                    }
                                }

                                // 校验工单信息
                                OpenPWOInfo pwo =
                                    FindPWOWithNumberAndNo(
                                        (string)dr["MONumber"],
                                        (int)dr["MOLineNo"]);
                                if (pwo == null)
                                {
                                    dr["ErrCode"] = 99;
                                    dr["ErrText"] =
                                        string.Format(
                                            "未找到 订单号[{1}]和行号[{2}] 的制造订单",
                                            dr["ErrText"].ToString(),
                                            dr["MONumber"].ToString(),
                                            dr["MOLineNo"].ToString());
                                }
                                else
                                {
                                    dr["T102Code"] = pwo.ProductNo;
                                    dr["LotNumber"] = pwo.LotNumber;
                                    dr["LinkedFactID"] = pwo.PWOIssuingFactID;
                                    dr["Qty"] = pwo.OrderQty;

                                    #region 解析 T102Code
                                    int errCode = 0;
                                    string errText = "";
                                    Stb058 data = new Stb058();

                                    IRAPMDMClient.Instance.mfn_GetInfo_Entity058WithCode(
                                        IRAPUser.Instance.CommunityID,
                                        102,
                                        pwo.ProductNo,
                                        ref data,
                                        out errCode,
                                        out errText);
                                    if (errCode == 0)
                                    {
                                        string[] strTemps = data.NodeName.Split('-');
                                        if (strTemps.Length >= 1)
                                            dr["PlateNo"] = strTemps[0];
                                        if (strTemps.Length >= 2)
                                            dr["T131Code"] = strTemps[1];
                                    }
                                    #endregion

                                    dr["ErrCode"] = 0;
                                    dr["ErrText"] = "";
                                }
                            }
                            #endregion

                            #region 校验材质
                            if (dr["T131Code"] == null ||
                                ((string)dr["T131Code"]).Trim() == "")
                            {
                                dr["ErrCode"] = (int)dr["ErrCode"] + 1;
                                dr["ErrText"] = (string)dr["ErrText"] + ";材质不能空白";
                            }
                            else
                            {
                                // 校验材质
                                if (((string)dr["T131Code"]).Substring(0, 3) != infoSmeltProduct.T131Code)
                                {
                                    dr["ErrCode"] = (int)dr["ErrCode"] + 1;
                                    dr["ErrText"] =
                                        (string)dr["ErrText"] +
                                        string.Format(";材质必须是 [{0}] 系列的", infoSmeltProduct.T131Code);
                                }
                            }
                            #endregion

                            break;
                    }
                }
                finally
                {
                    for (int i = 0; i < dtPWOs.Rows.Count; i++)
                        dtPWOs.Rows[i]["Ordinal"] = i + 1;
                }
            }
        }

        /// <summary>
        /// 新增记录时，初始化记录数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdvOrders_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow dr = grdvOrders.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["Ordinal"] = 0;
                dr["BatchNumber"] = infoSmeltProduct.BatchNumber;
                dr["PWONo"] = "";
                dr["MONumber"] = "";
                dr["MOLineNo"] = 0;
                dr["T102Code"] = "";
                dr["LinkedFactID"] = 0;
                dr["T131Code"] = "";
                dr["Qty"] = 0;
                dr["PlateNo"] = "";
                dr["LotNumber"] = "";
                dr["MachineModelling"] = "";
                dr["FoldNumber"] = 0;
                dr["RecordStatus"] = 1;
                dr["ErrCode"] = 0;
                dr["ErrText"] = "";
            }
        }

        private void grdvOrders_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            grdvOrders.BestFitColumns();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtPWOs.Rows.Count <= 0)
                return;

            foreach (DataRow dr in dtPWOs.Rows)
            {
                if ((int)dr["ErrCode"] != 0)
                {
                    XtraMessageBox.Show(
                        "存在有问题的生产计划，请修改后再保存",
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            int errCode = 0;
            string errText = "";

            try
            {
                TWaitting.Instance.ShowWaitForm("正在保存");
                foreach (DataRow dr in dtPWOs.Rows)
                {
                    int recordStatus = (int)dr["RecordStatus"];
                    if (recordStatus == 2 || recordStatus == 3)
                    {
                        IRAPMESBatchClient.Instance.usp_SaveChangeFact_SmeltBatchProduction(
                            IRAPUser.Instance.CommunityID,
                            (string)dr["BatchNumber"],
                            "D",
                            (string)dr["PWONo"],
                            (string)dr["MONumber"],
                            (int)dr["MOLineNo"],
                            (string)dr["T102Code"],
                            (long)dr["LinkedFactID"],
                            (string)dr["T131Code"],
                            (long)dr["Qty"],
                            (string)dr["PlateNo"],
                            (string)dr["LotNumber"],
                            (string)dr["MachineModelling"],
                            (int)dr["FoldNumber"],
                            IRAPUser.Instance.SysLogID,
                            out errCode,
                            out errText);
                    }
                    if (errCode != 0)
                    {
                        errText =
                            string.Format(
                                "在删除[{0}|{1}|{2}]是发生错误：{3}",
                                dr["BatchNumber"].ToString(),
                                dr["MONumber"].ToString(),
                                dr["MOLineNo"].ToString(),
                                errText);
                        break;
                    }

                    if (recordStatus == 1 || recordStatus == 2)
                    {
                        IRAPMESBatchClient.Instance.usp_SaveChangeFact_SmeltBatchProduction(
                            IRAPUser.Instance.CommunityID,
                            (string)dr["BatchNumber"],
                            "A",
                            (string)dr["PWONo"],
                            (string)dr["MONumber"],
                            (int)dr["MOLineNo"],
                            (string)dr["T102Code"],
                            (long)dr["LinkedFactID"],
                            (string)dr["T131Code"],
                            (long)dr["Qty"],
                            (string)dr["PlateNo"],
                            (string)dr["LotNumber"],
                            (string)dr["MachineModelling"],
                            (int)dr["FoldNumber"],
                            IRAPUser.Instance.SysLogID,
                            out errCode,
                            out errText);
                    }
                    if (errCode != 0)
                    {
                        errText =
                            string.Format(
                                "在增加[{0}|{1}|{2}]是发生错误：{3}",
                                dr["BatchNumber"].ToString(),
                                dr["MONumber"].ToString(),
                                dr["MOLineNo"].ToString(),
                                errText);
                        break;
                    }
                }
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
            }

            if (errCode == 0)
            {
                XtraMessageBox.Show(
                    "生产计划修改完成",
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show(
                    errText,
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            lstEquipmentsSelectedIndexChanged(lstEquipments, new EventArgs());
        }

        private void ribeDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DataRow dr = grdvOrders.GetFocusedDataRow();
            if (dr != null)
            {
                switch (e.Button.Caption.ToUpper())
                {
                    case "DELETEROW":
                        if (XtraMessageBox.Show(
                            "请确认是否要删除当前行？",
                            "提示",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            int indexFocused = grdvOrders.FocusedRowHandle;

                            grdvOrders.BeginDataUpdate();
                            try
                            {
                                if (Convert.ToInt32(dr["RecordStatus"]) == 1)
                                    dtPWOs.Rows.Remove(dr);
                                else
                                {
                                    dr["RecordStatus"] = 3;
                                }
                            }
                            finally
                            {
                                grdvOrders.EndDataUpdate();
                                grdvOrders.BestFitColumns();
                            }

                            if (dtPWOs.Rows.Count > 0)
                            {
                                if (indexFocused >= dtPWOs.Rows.Count)
                                    grdvOrders.FocusedRowHandle = dtPWOs.Rows.Count - 1;
                                else
                                    grdvOrders.FocusedRowHandle = indexFocused;
                            }
                        }
                        break;
                }
            }
        }
    }

    internal class PWOItem
    {
        public string BatchNumber { get; set; }
        public string PWONo { get; set; }
        public string MONumber { get; set; }
        public int MOLineNo { get; set; }
        public string T102Code { get; set; }
        public long LinkedFactID { get; set; }
        public string T131Code { get; set; }
        public long Qty { get; set; }
        public string PlateNo { get; set; }
        public string LotNumber { get; set; }
        public string MachineModelling { get; set; }
        public int FoldNumber { get; set; }
        /// <summary>
        /// 当前记录状态：0-正常；1-新增；2-修改；3-删除
        /// </summary>
        public int RecordStatus { get; set; }
        public int ErrCode { get; set; }
        public string ErrText { get; set; }
    }
}
