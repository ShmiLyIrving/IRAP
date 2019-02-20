using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Configuration;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.Entities.SCES;
using IRAP.Entity.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.SCES
{
    public partial class frmDeliveryMngmt_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        List<ProductionWorkOrderEx> orders = new List<ProductionWorkOrderEx>();
    
        public frmDeliveryMngmt_30()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取目标仓储地点列表
        /// </summary>
        public void GetDstStoreSites()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("正在获取目标仓储地点列表");
            try
            {
                int errCode = 0;
                string errText = "";
                List<DstDeliveryStoreSite> dstStoreSites = new List<DstDeliveryStoreSite>();

                try
                {
                    IRAPMDMClient.Instance.ufn_GetList_DstDeliveryStoreSites(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.SysLogID,
                        ref dstStoreSites,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    if (errCode == 0)
                    {
                        cboDstStoreSites.Properties.Items.Clear();
                        foreach (DstDeliveryStoreSite storeSite in dstStoreSites)
                        {
                            cboDstStoreSites.Properties.Items.Add(storeSite);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(
                            errText, 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmDeliveryMngmt_30_Shown(object sender, EventArgs e)
        {
            this.GetDstStoreSites();

            switch (IRAPUser.Instance.CommunityID)
            {
                case 60010:
                case 60030:
                    btnReprint.Visible = true;
                    btnReprint1.Visible = true;
                    break;
                default:
                    btnReprint.Visible = false;
                    btnReprint1.Visible = false;
                    break;
            }

            string versionDeliveryMngmt = "";
            if (ConfigurationManager.AppSettings["DeliveryMngmtVersion"] != null)
            {
                versionDeliveryMngmt = ConfigurationManager.AppSettings["DeliveryMngmtVersion"];
            }

            if (versionDeliveryMngmt != "1.0")
            {
                using (Dialogs.frmNewVersionMessage formNewTips = new Dialogs.frmNewVersionMessage())
                {
                    formNewTips.WindowState = FormWindowState.Maximized;
                    formNewTips.ShowDialog();
                    IRAPConst.Instance.SaveParams("DeliveryMngmtVersion", "1.0"); 
                }
            }
        }

        private void GetProductionWorkOrders(DstDeliveryStoreSite dstSite)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("正在获取待配送的制造订单列表");
            try
            {
                int errCode = 0;
                string errText = "";

                try
                {
                    IRAPSCESClient.Instance.ufn_GetList_ProductionWorkOrdersToDeliverMaterial_N(
                        IRAPUser.Instance.CommunityID,
                        dstSite.T173LeafID,
                        IRAPUser.Instance.SysLogID,
                        0,
                        ref orders,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    if (errCode == 0)
                    {
                        grdOrders.DataSource = orders;
                        for (int i = 0; i < grdvOrders.Columns.Count; i++)
                        {
                            if (grdvOrders.Columns[i].Visible)
                                grdvOrders.Columns[i].BestFit();
                        }
                        grdOrders.MainView.LayoutChanged();
                    }
                    else
                    {
                        XtraMessageBox.Show(
                            errText, "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void cboDstStoreSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDstStoreSites.SelectedIndex >= 0)
            {
                DstDeliveryStoreSite dstSite = cboDstStoreSites.SelectedItem as DstDeliveryStoreSite;

                GetProductionWorkOrders(dstSite);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cboDstStoreSites.SelectedItem != null)
                GetProductionWorkOrders(cboDstStoreSites.SelectedItem as DstDeliveryStoreSite);
        }

        private void mitmRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void grdvOrders_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = grdvOrders.GetFocusedDataSourceRowIndex();
            if (index >= 0)
            {
                if (cboDstStoreSites.SelectedItem == null)
                {
                    mitmDeliver.Enabled = false;
                    btnDeliver.Enabled = false;
                    return;
                }

                int dstStoreSiteLeafID = (cboDstStoreSites.SelectedItem as DstDeliveryStoreSite).T173LeafID;
                if ((IRAPUser.Instance.CommunityID == 60010 &&
                     (dstStoreSiteLeafID != 5259040 &&
                      dstStoreSiteLeafID != 2155631)) ||
                    IRAPUser.Instance.CommunityID == 60030)
                {
                    mitmDeliver.Enabled = true;
                    btnDeliver.Enabled = true;
                }
                else
                {
                    ProductionWorkOrderEx order = orders[index];
                    for (int i = 0; i < index; i++)
                    {
                        if (orders[i].ProductNo == order.ProductNo)
                        {
                            if (orders[i].ScheduledStartTime == order.ScheduledStartTime)
                            {
                                mitmDeliver.Enabled = true;
                                btnDeliver.Enabled = true;
                            }
                            else
                            {
                                mitmDeliver.Enabled = false;
                                btnDeliver.Enabled = false;
                            }
                            return;
                        }
                    }
                    mitmDeliver.Enabled = true;
                    btnDeliver.Enabled = true;
                }
            }
            else
            {
                mitmDeliver.Enabled = false;
                btnDeliver.Enabled = false;
            }
        }

        private void grdvOrders_DoubleClick(object sender, EventArgs e)
        {
            int index = grdvOrders.GetFocusedDataSourceRowIndex();
            if (index >= 0)
            {
                if (btnDeliver.Enabled)
                    btnDeliver.PerformClick();
            }
        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {
            int index = grdvOrders.GetFocusedDataSourceRowIndex();
            if (index >= 0)
            {
                DstDeliveryStoreSite dstStoreSite = cboDstStoreSites.SelectedItem as DstDeliveryStoreSite;
                string opNode = ((MenuInfo)Tag).OpNode;
                using (frmMaterialsToDeliver showMaterisl = 
                    new frmMaterialsToDeliver(
                        orders[index].FactID, 
                        orders[index].AF482PK,
                        dstStoreSite, 
                        opNode))
                {
                    showMaterisl.ShowDialog();
                }

                btnRefresh.PerformClick();
            }
        }

        private void mitmDeliver_Click(object sender, EventArgs e)
        {
            btnDeliver.PerformClick();
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            using (Dialogs.frmPWOReprint_Asimco Form = new Dialogs.frmPWOReprint_Asimco())
            {
                Form.ShowDialog();
            }
        }

        private void btnSyncMO_Click(object sender, EventArgs e)
        {
            if (cboDstStoreSites.SelectedItem != null)
            {
                string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                TWaitting.Instance.ShowWaitForm("正在同步四班的订单");
                try
                {
                    int errCode = 0;
                    string errText = "";
                    DstDeliveryStoreSite dstSite = cboDstStoreSites.SelectedItem as DstDeliveryStoreSite;

                    try
                    {
                        IRAPAPSClient.Instance.usp_ManualMODispatch(
                            IRAPUser.Instance.CommunityID,
                            dstSite.T173LeafID,
                            IRAPUser.Instance.SysLogID,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                        if (errCode == 0)
                        {
                            GetProductionWorkOrders(dstSite);
                        }
                        else
                        {
                            TWaitting.Instance.CloseWaitForm();
                            XtraMessageBox.Show(
                                errText, "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception error)
                    {
                        TWaitting.Instance.CloseWaitForm();
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                        XtraMessageBox.Show(
                            error.Message,
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                finally
                {
                    TWaitting.Instance.CloseWaitForm();
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void btnSearchByMaterialCode_Click(object sender, EventArgs e)
        {
            if (edtSubMaterialCode.Text.Trim() == "")
            {
                XtraMessageBox.Show(
                    "请输入子项物料号",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtSubMaterialCode.Focus();
                return;
            }
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("正在获取待配送的制造订单列表");
            try
            {
                int errCode = 0;
                string errText = "";
                List<PWOToDeliverByMaterialCode> pwos =
                    new List<PWOToDeliverByMaterialCode>();

                try
                {
                    IRAPSCESClient.Instance.ufn_GetList_PWOToDeliverByMaterialCode(
                        IRAPUser.Instance.CommunityID,
                        edtSubMaterialCode.Text.Trim(),
                        IRAPUser.Instance.SysLogID,
                        ref pwos,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        $"({errCode}){errText}", strProcedureName);
                    if (errCode == 0)
                    {
                        grdPWOs.DataSource = pwos;
                        grdvPWOs.BestFitColumns();
                        grdPWOs.MainView.LayoutChanged();

                        if (pwos.Count <= 0)
                        {
                            XtraMessageBox.Show(
                                $"未找到子项物料[{edtSubMaterialCode.Text.Trim()}]" +
                                "的待配送订单",
                                "",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(
                            errText, 
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message,
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnDeliver1_Click(object sender, EventArgs e)
        {
            int index = grdvPWOs.GetFocusedDataSourceRowIndex();
            if (index >= 0)
            {
                List<PWOToDeliverByMaterialCode> pwos =
                    grdPWOs.DataSource as List<PWOToDeliverByMaterialCode>;
                if (pwos != null)
                {
                    DstDeliveryStoreSite storeSite = null;
                    for (int i = 0; i < cboDstStoreSites.Properties.Items.Count; i++)
                    {
                        storeSite =
                            cboDstStoreSites.Properties.Items[i] as DstDeliveryStoreSite;
                        if (storeSite.T173LeafID == pwos[index].T173LeafID)
                        {
                            break;
                        }
                        else
                        {
                            storeSite = null;
                        }
                    }

                    if (storeSite== null)
                    {
                        XtraMessageBox.Show(
                            $"您无权向{pwos[index].T173Name}配送该订单",
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    string opNode = ((MenuInfo)Tag).OpNode;
                    using (frmMaterialsToDeliver showMaterisl =
                        new frmMaterialsToDeliver(
                            pwos[index].FactID,
                            pwos[index].AF482PK,
                            storeSite,
                            opNode))
                    {
                        showMaterisl.ShowDialog();
                    }

                    btnSearchByMaterialCode.PerformClick();
                }
            }
        }

        private void edtSubMaterialCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (edtSubMaterialCode.Text.Trim() != "")
                    btnSearchByMaterialCode.PerformClick();
            }
        }

        private void btnDeletePWO_Click(object sender, EventArgs e)
        {
            int index = grdvOrders.GetFocusedDataSourceRowIndex();
            if (index >= 0)
            {
                if (XtraMessageBox.Show(
                    "请确认是否要删除：\n"+
                    $"      订单号：{orders[index].MONumber}\n"+
                    $"      行  号：{orders[index].MOLineNo}\n"+
                    "的订单？",
                    "请确认",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strProcedureName =
                        $"{className}.{MethodBase.GetCurrentMethod().Name}";

                    WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                    try
                    {
                        int errCode = 0;
                        string errText = "";

                        IRAPMESBatchClient.Instance.usp_CancelDeliverMaterual(
                            IRAPUser.Instance.CommunityID,
                            orders[index].FactID,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            $"({errCode}){errText}",
                            strProcedureName);
                        if (errCode == 0)
                        {
                            XtraMessageBox.Show(
                                errText,
                                "删除订单",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(
                                errText,
                                "删除订单",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        XtraMessageBox.Show(
                            $"在删除订单时发生错误：{error.Message}",
                            "出错啦",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    finally
                    {
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }

                    btnRefresh.PerformClick();
                }
            }
            else
            {
                XtraMessageBox.Show(
                    "请选择一个订单！",
                    "删除订单",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnDeletePWO1_Click(object sender, EventArgs e)
        {
            int index = grdvPWOs.GetFocusedDataSourceRowIndex();
            
            if (index >= 0)
            {
                List<PWOToDeliverByMaterialCode> pwos =
                    grdPWOs.DataSource as List<PWOToDeliverByMaterialCode>;
                if (pwos != null)
                {
                    if (XtraMessageBox.Show(
                        "请确认是否要删除：\n" +
                        $"      订单号：{pwos[index].MONumber}\n" +
                        $"      行  号：{pwos[index].MOLineNo}\n" +
                        "的订单？",
                        "请确认",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strProcedureName =
                            $"{className}.{MethodBase.GetCurrentMethod().Name}";

                        WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                        try
                        {
                            int errCode = 0;
                            string errText = "";

                            IRAPMESBatchClient.Instance.usp_CancelDeliverMaterual(
                                IRAPUser.Instance.CommunityID,
                                pwos[index].FactID,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(
                                $"({errCode}){errText}",
                                strProcedureName);
                            if (errCode == 0)
                            {
                                XtraMessageBox.Show(
                                    errText,
                                    "删除订单",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            else
                            {
                                XtraMessageBox.Show(
                                    errText,
                                    "删除订单",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(error.Message, strProcedureName);
                            XtraMessageBox.Show(
                                $"在删除订单时发生错误：{error.Message}",
                                "出错啦",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        finally
                        {
                            WriteLog.Instance.WriteEndSplitter(strProcedureName);
                        }

                        btnSearchByMaterialCode.PerformClick();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(
                    "请选择一个订单！",
                    "删除订单",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
