using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.SCES;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.SCES
{
    public partial class frmLST_UnclosedRMDelivery_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<UnclosedDeliveryOrdersForPWO> datas = new List<UnclosedDeliveryOrdersForPWO>();

        public frmLST_UnclosedRMDelivery_30()
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
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText), 
                        strProcedureName);
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
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetData()
        {
            if (cboDstStoreSites.SelectedItem == null)
            {
                XtraMessageBox.Show(
                    "请先选择目标仓储地点！", 
                    "系统信息", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                cboDstStoreSites.Focus();
                return;
            }

            #region 获取查询结果
            int errCode = 0;
            string errText = "";

            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPSCESClient.Instance.ufn_GetList_UnclosedDeliveryOrdersForPWO(
                    IRAPUser.Instance.CommunityID,
                    ((DstDeliveryStoreSite)cboDstStoreSites.SelectedItem).T173LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText), 
                    strProcedureName);
                grdResults.DataSource = datas;
                for (int i = 0; i < grdvResults.Columns.Count; i++)
                {
                    if (grdvResults.Columns[i].Visible)
                        grdvResults.Columns[i].BestFit();
                }
                grdResults.MainView.LayoutChanged();

                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(
                    error.Message, 
                    "系统信息", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            #endregion
        }

        private void frmLST_UnclosedRMDelivery_30_Activated(object sender, EventArgs e)
        {
            GetDstStoreSites();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnExportTo_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                grdvResults.ExportToXlsx(saveFileDialog.FileName);
                XtraMessageBox.Show(
                    string.Format(
                        "当前的查询结果已经保存到 【{0}】。", 
                        saveFileDialog.FileName),
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void cmsAction_Opening(object sender, CancelEventArgs e)
        {
            if (datas == null)
            {
                tsmiUndoDelivery.Enabled = false;
                return;
            }

            int index = grdvResults.GetFocusedDataSourceRowIndex();
            if (index < 0 || index >= datas.Count)
            {
                tsmiUndoDelivery.Enabled = false;
                return;
            }

            tsmiUndoDelivery.Enabled = 
                (datas[index].PWOStatus == 2 || datas[index].PWOStatus == 3)
                && datas[index].ContainerNo == ""
                && IRAPUser.Instance.Role.RoleLeaf == 281;
        }

        private void tsmiUndoDelivery_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(
                    "请确认是否要撤销当前选择的物料配送？",
                    "系统信息",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                int index = grdvResults.GetFocusedDataSourceRowIndex();
                UnclosedDeliveryOrdersForPWO order = datas[index];

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

                    IRAPSCESClient.Instance.usp_UndoPrintVoucher_PWOMaterialDelivery(
                        IRAPUser.Instance.CommunityID,
                        order.AF482PK,
                        order.FactID,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText), 
                        strProcedureName);
                    if (errCode == 0)
                        XtraMessageBox.Show(
                            errText, 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show(
                            errText, 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    XtraMessageBox.Show(
                        string.Format(
                            "在撤销物料配送时发生错误：{0}", 
                            error.Message),
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }

                GetData();
            }
        }

        private void cboDstStoreSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGetData.PerformClick();
        }
    }
}
