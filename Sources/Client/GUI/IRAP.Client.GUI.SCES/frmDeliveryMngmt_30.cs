using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

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
                    break;
                default:
                    btnReprint.Visible = false;
                    break;
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
                ProductionWorkOrderEx order = orders[index];
                for (int i = 0; i < index; i++)
                {
                    if (orders[i].ProductNo == order.ProductNo)
                    {
                        mitmDeliver.Enabled = false;
                        btnDeliver.Enabled = false;
                        return;
                    }
                }
                mitmDeliver.Enabled = true;
                btnDeliver.Enabled = true;
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
            if (cboDstStoreSites.SelectedItem == null)
            {
                XtraMessageBox.Show(
                    "请先选择\"目标仓储地点\"",
                    "系统提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                cboDstStoreSites.Focus();
                return;
            }

            using (Dialogs.frmPWOReprint_Asimco Form =
                new Dialogs.frmPWOReprint_Asimco(
                    (cboDstStoreSites.SelectedItem as DstDeliveryStoreSite).T173LeafID))
            {
                Form.ShowDialog();
            }
        }
    }
}
