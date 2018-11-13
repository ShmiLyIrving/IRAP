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
using DevExpress.XtraVerticalGrid.Rows;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.Global.GUI;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.BatchSystem
{
    public partial class frmPrdtBatchNumberTrack : frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        /// <summary>
        /// 生产过程参数数据表
        /// </summary>
        private DataTable dtParams = new DataTable();
        /// <summary>
        /// 生产过程参数集
        /// </summary>
        private List<ProductionProcessParam> ppp = new List<ProductionProcessParam>();

        public frmPrdtBatchNumberTrack()
        {
            InitializeComponent();
        }

        private List<WIPStation> GetStations(
            int communityID,
            int t3LeafID,
            long sysLogID)
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";

            int errCode = 0;
            string errText = "";
            List<WIPStation> stations = new List<WIPStation>();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("刷新设备信息......");
            try
            {
                IRAPMDMClient.Instance.ufn_GetList_WIPStationsOfAHostByFunction(
                    communityID,
                    t3LeafID,
                    sysLogID,
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
                TWaitting.Instance.CloseWaitForm();
            }

            return stations;
        }

        private List<BatchByWorkday> GetBatchNumbers(
            int t133LeafID,
            string workDate)
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";

            int errCode = 0;
            string errText = "";
            List<BatchByWorkday> batchNumbers = new List<BatchByWorkday>();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("刷新炉次号列表.....");
            try
            {
                IRAPMESClient.Instance.ufn_GetList_BatchByWorkDay(
                    IRAPUser.Instance.CommunityID,
                    t133LeafID,
                    workDate,
                    IRAPUser.Instance.SysLogID,
                    ref batchNumbers,
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
                TWaitting.Instance.CloseWaitForm();
            }

            return batchNumbers;
        }

        /// <summary>
        /// 根据工位叶标识和生产容器批次号获取工单信息列表
        /// </summary>
        /// <param name="batchNumber">生产容器批次号</param>
        /// <returns></returns>
        private List<BatchPWOInfo> GetPWOWithBatchNo(
            int t107LeafID,
            string batchNumber)
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

                IRAPMESClient.Instance.ufn_GetList_WorkUnitBatchPWONo(
                    IRAPUser.Instance.CommunityID,
                    t107LeafID,
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
                    IRAPMessageBox.Instance.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                string errMsg = $"获取工单信息列表时发生错误：[{error.Message}]";
                WriteLog.Instance.Write(errMsg, strProcedureName);

                IRAPMessageBox.Instance.Show(
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
        /// 获取生产过程参数项目及参数值
        /// </summary>
        /// <param name="t131LeafID">工序叶标识</param>
        /// <param name="t216LeafID">环别叶标识</param>
        /// <param name="batchNumber">炉次号</param>
        private void GetMethodStandards(
            int t131LeafID,
            int t216LeafID,
            string batchNumber)
        {
            if (t131LeafID == 0 && t216LeafID == 0 && string.IsNullOrEmpty(batchNumber))
            {
                ppp = new List<ProductionProcessParam>();
                InitMethodParamsGrid(ppp);
                return;
            }

            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("获取生产过程参数......");
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPMDMClient.Instance.ufn_GetList_MethodItems(
                    IRAPUser.Instance.CommunityID,
                    t131LeafID,
                    t216LeafID,
                    batchNumber,
                    IRAPUser.Instance.SysLogID,
                    ref ppp,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        string.Format("在获取生产过程参数时发生错误：[{0}]", errText),
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    InitMethodParamsGrid(ppp);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                TWaitting.Instance.CloseWaitForm();
            }
        }

        /// <summary>
        /// 初始化生产过程参数列表
        /// </summary>
        /// <param name="ppParams"></param>
        private void InitMethodParamsGrid(List<ProductionProcessParam> ppParams)
        {
            dtParams.Clear();
            dtParams.Columns.Clear();

            vgrdMethodParams.Rows.Clear();

            foreach (ProductionProcessParam param in ppParams)
            {
                string colName = string.Format("Column{0}", param.Ordinal);
                DataColumn dc = dtParams.Columns.Add(colName, typeof(string));
                dc.Caption = param.T20Name;

                EditorRow row = new EditorRow();
                row.Properties.Caption = param.T20Name;
                row.Properties.FieldName = colName;
                vgrdMethodParams.Rows.Add(row);
            }

            for (int i = 0; i < dtParams.Columns.Count; i++)
            {
                List<PPParamValue> values = ppParams[i].ResolveDataXML();
                for (int j = 0; j < values.Count; j++)
                {
                    DataRow dr = null;
                    if (dtParams.Rows.Count < j + 1)
                    {
                        dr = dtParams.NewRow();
                        dtParams.Rows.Add(dr);
                    }
                    else
                    {
                        dr = dtParams.Rows[j];
                    }

                    dr[i] = values[j].Metric01;
                }
            }

            vgrdMethodParams.DataSource = dtParams;
            vgrdMethodParams.BestFit();
        }

        private void frmPrdtBatchNumberTrack_Shown(object sender, EventArgs e)
        {
            ilstBatchNo.Items.Clear();

            icboEquipmentStyle_SelectedIndexChanged(
                icboEquipmentStyle,
                null);
        }

        private void icboEquipmentStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            icboEquipment.Properties.Items.Clear();

            if (icboEquipmentStyle.SelectedItem != null)
            {
                ImageComboBoxItem item = icboEquipmentStyle.SelectedItem as ImageComboBoxItem;
                if (item.Value != null)
                {
                    int t3LeafID = (int)item.Value;

                    List<WIPStation> stations =
                        GetStations(
                            IRAPUser.Instance.CommunityID,
                            t3LeafID,
                            IRAPUser.Instance.SysLogID);

                    foreach (WIPStation station in stations)
                    {
                        icboEquipment.Properties.Items.Add(
                            new ImageComboBoxItem()
                            {
                                Description = $"[{station.T133Code}]{station.T216Name}",
                                Value = station,
                                ImageIndex = -1,
                            });
                    }

                    if (icboEquipment.Properties.Items.Count > 0)
                    {
                        icboEquipment.SelectedIndex = 0;
                    }
                }
            }
        }

        private void ilstBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ilstBatchNo.SelectedItem == null)
            {
                grdPWOs.DataSource = null;
                GetMethodStandards(0, 0, "");
                return;
            }

            ImageListBoxItem item = ilstBatchNo.SelectedItem as ImageListBoxItem;
            if (item.Value is BatchByWorkday)
            {
                ImageComboBoxItem cboItem = icboEquipment.SelectedItem as ImageComboBoxItem;
                int t107LeafID = (cboItem.Value as WIPStation).T107LeafID;

                string batchNo = ((BatchByWorkday)item.Value).BatchNumber;
                List<BatchPWOInfo> pwos = GetPWOWithBatchNo(t107LeafID, batchNo);
                grdPWOs.DataSource = pwos;
                grdvPWOs.BestFitColumns();

                GetMethodStandards(0, (cboItem.Value as WIPStation).T216LeafID, batchNo);
            }
            else
            {
                IRAPMessageBox.Instance.Show("选择项值对象的类型不是 BatchByWorkday", "", MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ilstBatchNo.Items.Clear();

            if (icboEquipment.SelectedItem == null)
            {
                return;
            }

            ImageComboBoxItem item = (ImageComboBoxItem)icboEquipment.SelectedItem;
            if (!(item.Value is WIPStation))
            {
                return;
            }

            WIPStation station = (WIPStation)item.Value;

            List<BatchByWorkday> batchNumbers =
                GetBatchNumbers(
                    station.T133LeafID,
                    edtPrdtDate.DateTime.ToString("yyyy-MM-dd"));

            foreach (BatchByWorkday batchNumber in batchNumbers)
            {
                ilstBatchNo.Items.Add(
                    new ImageListBoxItem()
                    {
                        Description = batchNumber.BatchNumber,
                        Value = batchNumber.Clone(),
                        ImageIndex = -1,
                    });
            }
        }
    }
}
