using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Rows;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global.Enums;
using IRAP.Entities.MDM;
using IRAP.Entities.IRAP;
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.BatchSystem.UserControls
{
    public partial class ucPrdtParams_Clean : DevExpress.XtraEditors.XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string caption = "";

        private WIPStation stationInfo = null;
        private int t3LeafID = 0;
        private STB006 currentOperator = null;
        private DateTime startDatetime = DateTime.Now;
        /// <summary>
        /// 设备的当前生产状态
        /// </summary>
        private ProductionStatus prdtStatus = ProductionStatus.Idle;
        /// <summary>
        /// 生产过程参数数据表
        /// </summary>
        private DataTable dtParams = new DataTable();
        /// <summary>
        /// 生产过程参数集
        /// </summary>
        private List<ProductionProcessParam> ppp = new List<ProductionProcessParam>();
        /// <summary>
        /// 指定批次中的生产工单集
        /// </summary>
        private List<BatchPWOInfo> pwos = new List<BatchPWOInfo>();
        /// <summary>
        /// 当前的生产炉次号
        /// </summary>
        private string currentBatchNo = "";

        public ucPrdtParams_Clean()
        {
            InitializeComponent();
        }

        public ucPrdtParams_Clean(WIPStation station, int t3LeafID) : this()
        {
            stationInfo = station;
            this.t3LeafID = t3LeafID;
        }

        private void RefreshForm()
        {
            switch (prdtStatus)
            {
                case ProductionStatus.Idle:
                    edtOperatorCode.Enabled = true;

                    lblDevices.Visible = true;
                    lblBatchNos.Visible = true;
                    cboDevices.Visible = true;
                    cboBatchNos.Visible = true;

                    btnParamNew.Enabled = false;
                    btnParamRemove.Enabled = false;

                    btnBegin.Enabled = true;
                    btnTerminate.Enabled = false;
                    btnEnd.Enabled = false;

                    break;
                case ProductionStatus.Busy:
                    edtOperatorCode.Enabled = false;

                    lblDevices.Visible = false;
                    lblBatchNos.Visible = false;
                    cboDevices.Visible = false;
                    cboBatchNos.Visible = false;

                    btnParamNew.Enabled = true;
                    btnParamRemove.Enabled = true;

                    btnBegin.Enabled = false;
                    btnTerminate.Enabled = true;
                    btnEnd.Enabled = true;

                    break;
            }
        }

        private void GetDevices()
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
                List<WIPStation> stations = new List<WIPStation>();

                cboDevices.Properties.Items.Clear();
                stations.Clear();
                IRAPMDMClient.Instance.ufn_GetList_WIPStationsOfAHostByFunction(
                    IRAPUser.Instance.CommunityID,
                    -373355,
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
                else
                {
                    foreach (WIPStation station in stations)
                    {
                        cboDevices.Properties.Items.Add(station.Clone());
                    }
                }
                if (cboDevices.Properties.Items.Count > 0)
                {
                    cboDevices.SelectedIndex = 0;
                }
                else
                {
                    cboDevices.SelectedIndex = -1;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetBatchsFromEquipment(int t133LeafID, int t107LeafID)
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
                List<BatchByEquipment> batchNos = new List<BatchByEquipment>();

                cboBatchNos.Properties.Items.Clear();
                IRAPMESClient.Instance.ufn_GetList_BatchByEquipment_N(
                    IRAPUser.Instance.CommunityID,
                    t133LeafID,
                    t107LeafID,
                    "",
                    IRAPUser.Instance.SysLogID,
                    ref batchNos,
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
                else
                {
                    foreach (BatchByEquipment batchNo in batchNos)
                    {
                        cboBatchNos.Properties.Items.Add(batchNo.Clone());
                    }
                }
                if (cboBatchNos.Properties.Items.Count > 0)
                {
                    cboBatchNos.SelectedIndex = 0;
                }
                else
                {
                    cboBatchNos.SelectedIndex = -1;
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

                IRAPMESClient.Instance.ufn_GetList_WorkUnitBatchPWONo(
                    IRAPUser.Instance.CommunityID,
                    stationInfo.T107LeafID,
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
                //else
                //{
                //    for (int i = rlt.Count - 1; i >= 0; i--)
                //    {
                //        if (rlt[i].QCStatus != 0 ||
                //            rlt[i].BatchEndDate.Trim() == "")
                //            rlt.RemoveAt(i);
                //    }
                //}
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
        /// 根据 ID 卡的卡号查找操作工
        /// </summary>
        /// <param name="idCode">ID 卡卡号</param>
        /// <returns></returns>
        private STB006 GetUserInfoWithIDCode(string idCode)
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
                List<STB006> users = new List<STB006>();

                IRAPUserClient.Instance.mfn_GetList_Users(
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
        /// 生成生产开始的输入参数 XML 串
        /// </summary>
        /// <param name="pwos"></param>
        /// <returns></returns>
        private string GenerateBatchProductionStartXML(List<BatchPWOInfo> pwos)
        {
            string rlt = "";
            int idx = 1;
            foreach (BatchPWOInfo pwo in pwos)
            {
                rlt +=
                    string.Format(
                        "<RF25 Ordinal=\"{0}\" T102LeafID=\"{1}\" " +
                        "T216LeafID=\"{2}\" WIPCode=\"\" LotNumber=\"{3}\" " +
                        "Texture=\"{4}\" PWONo=\"{5}\" BatchLot=\"\" " +
                        "Qty=\"{6}\" Scale=\"0\" />\n",
                        idx++,
                        pwo.T102LeafID,
                        stationInfo.T216LeafID,
                        pwo.LotNumber,
                        pwo.Texture,
                        pwo.PWONo,
                        pwo.Qty);
            }
            rlt = string.Format("<RSFact>\n{0}</RSFact>", rlt);

            return rlt;
        }

        /// <summary>
        /// 获取检验项目及检验值
        /// </summary>
        /// <param name="t131LeafID">工序叶标识</param>
        /// <param name="t216LeafID">环别叶标识</param>
        /// <param name="batchNumber">炉次号</param>
        private void GetMethodStandards(
            int t131LeafID,
            int t216LeafID,
            string batchNumber)
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

        /// <summary>
        /// 生成保存生产过程参数时的 XML
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GenerateRSFactXML(DataRow dr)
        {
            string rlt = "";

            for (int i = 0; i < dtParams.Columns.Count; i++)
            {
                rlt +=
                    string.Format(
                        "<RF25_1 Ordinal=\"{0}\" T20LeafID=\"{1}\" " +
                        "ParameterName=\"{2}\" LowLimit=\"\" " +
                        "Criterion=\"\" HighLimit=\"\" Scale=\"\" " +
                        "UnitOfMeasure=\"\" Metric01=\"{3}\" />",
                        ppp[i].Ordinal,
                        ppp[i].T20LeafID,
                        ppp[i].T20Name,
                        dr[i].ToString());
            }

            rlt = string.Format("<RSFact>{0}</RSFact>", rlt);
            return rlt;
        }

        /// <summary>
        /// 生成删除生产过程参数的 XML
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        private string GenerateDeleteRSFactXML(DataRow dr, int idx)
        {
            string rlt = "";

            for (int i = 0; i < dtParams.Columns.Count; i++)
            {
                List<PPParamValue> values = ppp[i].ResolveDataXML();

                rlt +=
                    string.Format(
                        "<RF25_1 Ordinal=\"{0}\" FactID=\"{1}\" " +
                        "T20LeafID=\"{2}\" ParameterName=\"{3}\" " +
                        "LowLimit=\"\" Criterion=\"\" HighLimit=\"\" " +
                        "Scale=\"\" UnitOfMeasure=\"\" Metric01=\"{4}\" />",
                        ppp[i].Ordinal,
                        values[idx].FactID,
                        ppp[i].T20LeafID,
                        ppp[i].T20Name,
                        dr[i].ToString());
            }

            rlt = string.Format("<RSFact>{0}</RSFact>", rlt);
            return rlt;
        }

        /// <summary>
        /// 获取当前站点的生产信息
        /// </summary>
        /// <returns></returns>
        private BatchProductInfo GetWorkUnitProductionInfo()
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
                BatchProductInfo data = new BatchProductInfo();

                IRAPMESClient.Instance.ufn_GetInfo_BatchProduct(
                    IRAPUser.Instance.CommunityID,
                    stationInfo.T107LeafID,
                    stationInfo.T216LeafID,
                    stationInfo.T133LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref data,
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
                    if (data.InProduction == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return data;
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void ucCleanTemperPrdtParams_Load(object sender, EventArgs e)
        {
            BatchProductInfo data = GetWorkUnitProductionInfo();
            if (data != null)
            {
                currentOperator = new STB006()
                {
                    UserCode = data.OperatorCode,
                    UserName = data.OperatorName,
                };
                currentBatchNo = data.BatchNumber;
                startDatetime = data.BatchStartDate;
                if (data.InProduction == 0)
                {
                    prdtStatus = ProductionStatus.Idle;
                    GetMethodStandards(0, 0, "");
                }
                else
                {
                    prdtStatus = ProductionStatus.Busy;

                    pwos = GetPWOWithBatchNo(currentBatchNo);
                    grdPWOs.DataSource = pwos;
                    grdvPWOs.BestFitColumns();

                    GetMethodStandards(0, stationInfo.T216LeafID, currentBatchNo);
                }

                edtOperatorCode.Text =
                    string.Format(
                        "{0}[{1}]",
                        currentOperator.UserName,
                        currentOperator.UserCode);
                lblBatchNo.Text = currentBatchNo;
                lblStartTime.Text = startDatetime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                GetDevices();
            }

            RefreshForm();
        }

        private void ucCleanTemperPrdtParams_Enter(object sender, EventArgs e)
        {
            if (prdtStatus == ProductionStatus.Idle)
            {
                edtOperatorCode.Focus();

                cboDevices_SelectedIndexChanged(cboDevices, null);
            }
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
            }
        }

        private void cboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboBatchNos.Properties.Items.Clear();
            if (cboDevices.SelectedItem != null)
            {
                grdPWOs.DataSource = null;
                grdvPWOs.BestFitColumns();

                GetBatchsFromEquipment(
                    ((WIPStation)cboDevices.SelectedItem).T133LeafID,
                    stationInfo.T107LeafID);
            }
        }

        private void cboBatchNos_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdvPWOs.BeginDataUpdate();
            grdPWOs.DataSource = null;
            grdvPWOs.EndDataUpdate();
            vgrdMethodParams.Rows.Clear();

            if (cboBatchNos.SelectedItem != null)
            {
                pwos = GetPWOWithBatchNo(((BatchByEquipment)cboBatchNos.SelectedItem).BatchNumber);
                grdPWOs.DataSource = pwos;
                grdvPWOs.BestFitColumns();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            lblCurrentTime.Text =
                now.ToString("yyyy-MM-dd HH:mm:ss");

            if (prdtStatus == ProductionStatus.Busy)
            {
                TimeSpan span = now - startDatetime;
                lblProductTimeSpan.Text = "";
                if (span.Days != 0)
                    lblProductTimeSpan.Text = string.Format("{0}天", span.Days);
                if (span.Hours != 0)
                    lblProductTimeSpan.Text += string.Format("{0}小时", span.Hours);
                if (span.Minutes != 0)
                    lblProductTimeSpan.Text += string.Format("{0}分钟", span.Minutes);
                if (span.Seconds != 0)
                    lblProductTimeSpan.Text += string.Format("{0}秒", span.Seconds);

                lblProductTimeSpan.Text = 
                    string.Format(
                        "从 {0} 开始，已过 {1}", 
                        lblStartTime.Text, 
                        lblProductTimeSpan.Text);
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            #region 数据检验
            if (currentOperator == null)
            {
                XtraMessageBox.Show(
                    "请刷卡记录您的身份！",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtOperatorCode.Focus();
                return;
            }
            if (pwos.Count <= 0)
            {
                XtraMessageBox.Show(
                    "无工单信息不能进行当前设备的生产！",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            #endregion

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
                currentBatchNo = ((BatchByEquipment)cboBatchNos.SelectedItem).BatchNumber;

                IRAPMESClient.Instance.usp_SaveFact_BatchProductionStart_N(
                    IRAPUser.Instance.CommunityID,
                    stationInfo.T216LeafID,
                    stationInfo.T107LeafID,
                    currentOperator.UserCode,
                    currentBatchNo,
                    0,
                    GenerateBatchProductionStartXML(pwos),
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        string.Format("在生产开始时发生错误：[{0}]", errText),
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

            startDatetime = DateTime.Now;
            lblBatchNo.Text = currentBatchNo;
            lblStartTime.Text = startDatetime.ToString("yyyy-MM-dd HH:mm:ss");

            GetMethodStandards(0, stationInfo.T216LeafID, currentBatchNo);

            prdtStatus = ProductionStatus.Busy;
            RefreshForm();
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            if (
                IRAPMessageBox.Instance.Show(
                    $"是否要终止当前炉次【{currentBatchNo}】的生产？",
                    "生产终止",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

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

                IRAPMESClient.Instance.usp_SaveFact_BatchBreakProduction(
                    IRAPUser.Instance.CommunityID,
                    stationInfo.T216LeafID,
                    stationInfo.T107LeafID,
                    currentBatchNo,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        string.Format("在生产终止时发生错误：[{0}]", errText),
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    currentOperator = null;
                    currentBatchNo = "";
                    startDatetime = DateTime.Now;
                    pwos.Clear();
                    ppp.Clear();
                    InitMethodParamsGrid(ppp);

                    edtOperatorCode.Text = "";
                    lblBatchNo.Text = "";
                    lblProductTimeSpan.Text = "";
                    lblStartTime.Text = "";

                    GetDevices();
                    grdPWOs.RefreshDataSource();

                    GetMethodStandards(0, 0, "");

                    prdtStatus = ProductionStatus.Idle;
                    RefreshForm();
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
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

                IRAPMESClient.Instance.usp_SaveFact_BatchProductionEnd(
                    IRAPUser.Instance.CommunityID,
                    stationInfo.T216LeafID,
                    stationInfo.T107LeafID,
                    currentBatchNo,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        string.Format("在生产结束时发生错误：[{0}]", errText),
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    currentOperator = null;
                    currentBatchNo = "";
                    startDatetime = DateTime.Now;
                    pwos.Clear();
                    ppp.Clear();
                    InitMethodParamsGrid(ppp);

                    edtOperatorCode.Text = "";
                    lblBatchNo.Text = "";
                    lblProductTimeSpan.Text = "";
                    lblStartTime.Text = "";

                    GetDevices();
                    grdPWOs.RefreshDataSource();

                    GetMethodStandards(0, 0, "");

                    prdtStatus = ProductionStatus.Idle;
                    RefreshForm();
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnParamNew_Click(object sender, EventArgs e)
        {
            using (Dialogs.frmItemsEditor formEditor =
                new Dialogs.frmItemsEditor(
                    EditStatus.New,
                    splitContainerControl1.Panel2.Text,
                    dtParams,
                    -1))
            {
                if (formEditor.ShowDialog() == DialogResult.OK)
                {
                    DataRow dr = dtParams.Rows[dtParams.Rows.Count - 1];

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

                        IRAPMESClient.Instance.usp_SaveFact_BatchMethodConfirming(
                            IRAPUser.Instance.CommunityID,
                            stationInfo.T216LeafID,
                            stationInfo.T107LeafID,
                            currentBatchNo,
                            GenerateRSFactXML(dr),
                            IRAPUser.Instance.SysLogID,
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

                        GetMethodStandards(
                            0,
                            stationInfo.T216LeafID,
                            currentBatchNo);
                        vgrdMethodParams.RefreshDataSource();
                    }
                    finally
                    {
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                }
            }
        }

        private void btnParamRemove_Click(object sender, EventArgs e)
        {
            int idx = vgrdMethodParams.FocusedRecord;
            if (idx >= 0)
            {
                if (XtraMessageBox.Show(
                    string.Format(
                        "是否要删除选择的第[{0}]组参数值？",
                        idx + 1),
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataRow dr = dtParams.Rows[idx];

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
                        List<PPParamValue> values = ppp[0].ResolveDataXML();

                        IRAPMESClient.Instance.usp_SaveFact_BatchMethodCancel(
                            IRAPUser.Instance.CommunityID,
                            stationInfo.T216LeafID,
                            stationInfo.T107LeafID,
                            currentBatchNo,
                            "D",
                            values[idx].FactID,
                            GenerateDeleteRSFactXML(dr, idx),
                            IRAPUser.Instance.SysLogID,
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
                    finally
                    {
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }

                    #region 刷新生产过程参数列表
                    GetMethodStandards(
                        0,
                        stationInfo.T216LeafID,
                        currentBatchNo);
                    vgrdMethodParams.RefreshDataSource();
                    #endregion
                }
            }
        }
    }
}
