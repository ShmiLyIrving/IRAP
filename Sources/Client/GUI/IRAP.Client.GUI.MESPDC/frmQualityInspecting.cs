using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Rows;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.Entities.MES;
using IRAP.Entities.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmQualityInspecting : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private UserDetailInfo currentOperator = null;
        private List<WIPStation> stations = new List<WIPStation>();
        private List<BatchByEquipment> batchs = new List<BatchByEquipment>();
        private List<BatchPWOInfo> pwos = new List<BatchPWOInfo>();
        private List<InspectionItem> inspectionItems = new List<InspectionItem>();

        private DataTable dtInspection = new DataTable();

        public frmQualityInspecting()
        {
            InitializeComponent();
        }

        private void GetStations()
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

                stations.Clear();
                IRAPMDMClient.Instance.ufn_GetList_WIPStationsOfAHost(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref stations,
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

        private void ClearAll()
        {
            batchs.Clear();
            grdvBatchNos.UpdateCurrentRow();

            pwos.Clear();
            grdvPWOs.UpdateCurrentRow();
        }

        private void RefreshCtrlInForm()
        {
            grdBatchNos.RefreshDataSource();
            grdPWOs.RefreshDataSource();

            if (currentOperator == null)
            {
                cboWorkUnit.Enabled = false;
                splitContainerControl2.Enabled = false;
                vgrdInspectParams.Enabled = false;
                btnPWONew.Enabled = false;
                btnPWOModify.Enabled = false;
                btnPWORemove.Enabled = false;
                btnSaveParams.Enabled = false;
            }
            else
            {
                cboWorkUnit.Enabled = true;
                if (cboWorkUnit.SelectedItem != null)
                {
                    splitContainerControl2.Enabled = true;
                }
                if (grdvPWOs.GetFocusedDataSourceRowIndex() >= 0)
                {
                    vgrdInspectParams.Enabled = true;
                    btnPWONew.Enabled = true;
                    btnPWOModify.Enabled = true;
                    btnPWORemove.Enabled = true;
                    btnSaveParams.Enabled = true;
                }
                else
                {
                    vgrdInspectParams.Enabled = false;
                    btnPWONew.Enabled = false;
                    btnPWOModify.Enabled = false;
                    btnPWORemove.Enabled = false;
                    btnSaveParams.Enabled = false;
                }
            }
        }

        private void GetBatchsFromEquipment(WIPStation station)
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

                batchs.Clear();
                IRAPMESClient.Instance.ufn_GetList_BatchByEquipment(
                    IRAPUser.Instance.CommunityID,
                    station.T133LeafID,
                    "IQ",
                    IRAPUser.Instance.SysLogID,
                    ref batchs,
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

        private UserDetailInfo GetUserInfoWithIDCode(string idCode)
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
                List<UserDetailInfo> users = new List<UserDetailInfo>();

                IRAPUserClient.Instance.sfn_GetList_UsersOfACommunity(
                    IRAPUser.Instance.CommunityID,
                    "",
                    idCode,
                    ref users,
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
                    return null;
                }
                else
                {
                    if (users.Count == 0)
                    {
                        XtraMessageBox.Show(
                            string.Format(
                                "未找到[{0}]的用户",
                                idCode),
                            caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return null;
                    }
                    else
                    {
                        return users[0];
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据生产容器批次号获取工单信息列表
        /// </summary>
        /// <param name="batchNumber">生产容器批次号</param>
        /// <returns></returns>
        private List<BatchPWOInfo> GetPWOWithBatchNo(string batchNumber)
        {
            List<BatchPWOInfo> rlt = new List<BatchPWOInfo>();

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

                IRAPMESClient.Instance.ufn_GetList_BatchPWONo(
                    IRAPUser.Instance.CommunityID,
                    batchNumber,
                    IRAPUser.Instance.SysLogID,
                    ref rlt,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                string errMsg =
                    string.Format(
                        "获取工单信息列表时发生错误：[{0}]",
                        error.Message);
                WriteLog.Instance.Write(errMsg, strProcedureName);

                XtraMessageBox.Show(
                    errMsg,
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

            return rlt;
        }

        /// <summary>
        /// 生成质量检验值临时表
        /// </summary>
        /// <param name="items"></param>
        private void InitInspectionItemsGrid(List<InspectionItem> items)
        {
            dtInspection.Clear();
            dtInspection.Columns.Clear();

            vgrdInspectParams.Rows.Clear();

            foreach (InspectionItem item in items)
            {
                string colName = string.Format("Column{0}", item.Ordinal);
                dtInspection.Columns.Add(colName, typeof(long));

                EditorRow row = new EditorRow();
                row.Properties.Caption = item.T20Name;
                row.Properties.FieldName = colName;
                vgrdInspectParams.Rows.Add(row);
            }

            vgrdInspectParams.DataSource = dtInspection;
            vgrdInspectParams.BestFit();
        }

        private void frmQualityInspecting_Load(object sender, EventArgs e)
        {
            GetStations();
            foreach (WIPStation station in stations)
            {
                cboWorkUnit.Properties.Items.Add(station);
            }

            grdBatchNos.DataSource = batchs;
            grdPWOs.DataSource = pwos;
        }

        private void edtOperatorCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (edtOperatorCode.Text.Trim() != "")
                {
                    currentOperator = GetUserInfoWithIDCode(edtOperatorCode.Text.Trim());
                    if (currentOperator != null)
                    {
                        edtOperatorCode.Text =
                            string.Format(
                                "{0}[{1}]",
                                currentOperator.UserName,
                                currentOperator.UserCode);
                    }
                    else
                    {
                        edtOperatorCode.Text = "";
                    }
                }
                else
                {
                    edtOperatorCode.Text = "";
                    currentOperator = null;
                }

                RefreshCtrlInForm();
            }
        }

        private void cboWorkUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAll();

            if (cboWorkUnit.SelectedItem != null)
            {
                WIPStation station = cboWorkUnit.SelectedItem as WIPStation;
                GetBatchsFromEquipment(station);

                grdBatchNos.DataSource = batchs;
                grdvBatchNos.UpdateCurrentRow();
                grdvBatchNos.BestFitColumns();
            }

            RefreshCtrlInForm();
        }

        private void grdvBatchNos_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            grdPWOs.DataSource = null;

            int idx = grdvBatchNos.GetFocusedDataSourceRowIndex();
            if (idx >= 0 && idx < batchs.Count)
            {
                BatchByEquipment batch = batchs[idx];
                pwos = GetPWOWithBatchNo(batch.BatchNumber);
                grdPWOs.DataSource = pwos;
            }
            else
            {
                pwos.Clear();
                grdPWOs.DataSource = null;
            }

            grdPWOs.RefreshDataSource();
            grdvPWOs.BestFitColumns();
        }

        private void grdvPWOs_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            int idx = grdvPWOs.GetFocusedDataSourceRowIndex();
            if (idx >=0 && idx < pwos.Count)
            {
                int errCode = 0;
                string errText = "";

                IRAPMDMClient.Instance.ufn_GetList_InspectionItems(
                    IRAPUser.Instance.CommunityID,
                    pwos[idx].T102LeafID,
                    ((WIPStation)cboWorkUnit.SelectedItem).T216LeafID,
                    pwos[idx].PWONo,
                    pwos[idx].BatchNumber,
                    IRAPUser.Instance.SysLogID,
                    ref inspectionItems,
                    out errCode,
                    out errText);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                inspectionItems.Clear();
            }

            InitInspectionItemsGrid(inspectionItems);
        }
    }
}
