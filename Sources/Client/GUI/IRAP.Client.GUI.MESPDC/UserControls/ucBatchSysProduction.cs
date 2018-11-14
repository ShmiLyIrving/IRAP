using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Rows;

using IRAP.Global;
using IRAP.Client.Global.Enums;
using IRAP.Client.User;
using IRAP.Client.GUI.MESPDC.Entities;
using IRAP.Entities.MDM;
using IRAP.Entities.SSO;
using IRAP.Entities.MES;
using IRAP.Entities.IRAP;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.UserControls
{
    public partial class ucBatchSysProduction : DevExpress.XtraEditors.XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private Entities.EntityEquipmentInfo stationInfo = null;

        private STB006 currentOperator = null;
        private DateTime startDatetime = DateTime.Now;
        /// <summary>
        /// 当前的生产炉次号
        /// </summary>
        private string currentBatchNo = "";
        /// <summary>
        /// 产品类别
        /// </summary>
        private List<BatchRingCategory> prdtTypes = new List<BatchRingCategory>();

        private List<EntityBatchPWO> pwos = new List<EntityBatchPWO>();
        private List<MethodStandard> standards = new List<MethodStandard>();
        private List<ProductionProcessParam> ppp = new List<ProductionProcessParam>();

        private DataTable dtParams = new DataTable();
        /// <summary>
        /// 设备的当前生产状态
        /// </summary>
        private ProductionStatus prdtStatus = ProductionStatus.Idle;

        private string caption = "";

        public ucBatchSysProduction()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";
        }

        public ucBatchSysProduction(EntityEquipmentInfo station) : this()
        {
            stationInfo = station;

            if (station != null)
            {
                GetPrdtTypes();
            }
        }

        private void RefreshForm()
        {
            switch (prdtStatus)
            {
                case ProductionStatus.Idle:
                    edtOperatorCode.Enabled = true;
                    cboPrdtType.Enabled = true;

                    btnPWONew.Enabled = true;
                    btnPWOModify.Enabled = true;
                    btnPWORemove.Enabled = true;

                    btnParamNew.Enabled = false;
                    btnParamRemove.Enabled = false;

                    btnBegin.Enabled = true;
                    btnEnd.Enabled = false;

                    break;
                case ProductionStatus.Busy:
                    edtOperatorCode.Enabled = false;
                    cboPrdtType.Enabled = false;

                    btnPWONew.Enabled = false;
                    btnPWOModify.Enabled = false;
                    btnPWORemove.Enabled = false;

                    btnParamNew.Enabled = true;
                    btnParamRemove.Enabled = true;

                    btnBegin.Enabled = false;
                    btnEnd.Enabled = true;

                    break;
            }
        }

        private void GetPrdtTypes()
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

                IRAPMDMClient.Instance.ufn_GetList_BatchRingCategory(
                    IRAPUser.Instance.CommunityID,
                    stationInfo.T216LeafID,
                    0,
                    IRAPUser.Instance.SysLogID,
                    ref prdtTypes,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (BatchRingCategory data in prdtTypes)
                        cboPrdtType.Properties.Items.Add(data);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

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

        private string GenerateBatchProductionStartXML(List<EntityBatchPWO> pwos)
        {
            string rlt = "";
            int idx = 1;
            foreach (EntityBatchPWO pwo in pwos)
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
                        pwo.Quantity);
            }
            rlt = string.Format("<RSFact>\n{0}</RSFact>", rlt);

            return rlt;
        }

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

        /// <summary>
        /// 获取材质
        /// </summary>
        /// <param name="materialCode">物料号（原材料/半成品/产成品）</param>
        /// <returns>string</returns>
        private string GetTextureCodeFromMaterialCode(
            string materialCode,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                string rlt = "";

                IRAPMDMClient.Instance.ufn_GetMaterialTextureCodeFromERP_FourthShift(
                    IRAPUser.Instance.CommunityID,
                    materialCode,
                    ref rlt,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                return rlt;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
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

        private void ucBatchSysProduction_Load(object sender, EventArgs e)
        {
            grdPWOs.DataSource = pwos;

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
                    prdtStatus = ProductionStatus.Idle;
                else
                    prdtStatus = ProductionStatus.Busy;

                pwos = data.GetPWOsFromXML();
                #region 遍历所有生产工单，获取生产工单的在制品的材质
                //foreach (EntityBatchPWO pwo in pwos)
                //{
                //    int errCode = 0;
                //    string errText = "";

                //    string texture =
                //        GetTextureCodeFromMaterialCode(
                //            pwo.T102Code,
                //            out errCode,
                //            out errText);
                //    if (errCode == 0)
                //        pwo.Texture = texture;
                //    else
                //        pwo.Texture = "";
                //}
                #endregion
                grdPWOs.DataSource = pwos;
                grdvPWOs.BestFitColumns();

                edtOperatorCode.Text =
                    string.Format(
                        "{0}[{1}]",
                        currentOperator.UserName,
                        currentOperator.UserCode);
                lblBatchNo.Text = currentBatchNo;
                lblStartTime.Text = startDatetime.ToString("yyyy-MM-dd HH:mm:ss");

                cboPrdtType.SelectedIndex = -1;
                for (int i = 0; i < cboPrdtType.Properties.Items.Count; i++)
                {
                    BatchRingCategory prdtType =
                        (BatchRingCategory)cboPrdtType.Properties.Items[i];
                    if (prdtType.T131LeafID == data.T131LeafID)
                    {
                        cboPrdtType.SelectedIndex = i;
                        break;
                    }
                }

                //GetMethodStandards(data.T131LeafID, stationInfo.T216LeafID, data.BatchNumber);
            }

            RefreshForm();
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
            if (cboPrdtType.SelectedIndex < 0)
            {
                XtraMessageBox.Show(
                    "请选择！",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cboPrdtType.Focus();
                return;
            }
            if (pwos.Count <= 0)
            {
                XtraMessageBox.Show(
                    "还没有添加工单信息，请至少增加一个生产工单！",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnPWONew.Focus();
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

                IRAPMESBatchClient.Instance.usp_SaveFact_BatchProductionStart(
                    IRAPUser.Instance.CommunityID,
                    stationInfo.T216LeafID,
                    stationInfo.T107LeafID,
                    currentOperator.UserCode,
                    ((BatchRingCategory)cboPrdtType.SelectedItem).T131LeafID,
                    GenerateBatchProductionStartXML(pwos),
                    IRAPUser.Instance.SysLogID,
                    out currentBatchNo,
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

            prdtStatus = ProductionStatus.Busy;
            RefreshForm();
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
                    cboPrdtType.SelectedIndex = -1;
                    lblBatchNo.Text = "";
                    lblProductTimeSpan.Text = "";
                    lblStartTime.Text = "";

                    grdParams.RefreshDataSource();
                    grdPWOs.RefreshDataSource();

                    prdtStatus = ProductionStatus.Idle;
                    RefreshForm();
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnPWONew_Click(object sender, EventArgs e)
        {
            if (cboPrdtType.SelectedItem == null)
            {
                XtraMessageBox.Show(
                    "请先选择产品类别！",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                cboPrdtType.Focus();
                return;
            }

            BatchRingCategory prdtType = cboPrdtType.SelectedItem as BatchRingCategory;

            EntityBatchPWO newPWO = new EntityBatchPWO();

            using (Dialogs.frmPWOInProductionEditor formEditor =
                new Dialogs.frmPWOInProductionEditor(
                    EditStatus.New,
                    stationInfo.T134LeafID,
                    stationInfo.T216LeafID,
                    prdtType.T131LeafID,
                    pwos,
                    ref newPWO))
            {
                if (formEditor.ShowDialog() == DialogResult.OK)
                {
                    pwos.Add(newPWO);
                    grdvPWOs.BestFitColumns();
                }
            }
        }

        private void btnPWOModify_Click(object sender, EventArgs e)
        {
            if (cboPrdtType.SelectedItem == null)
            {
                XtraMessageBox.Show(
                    "请先选择产品类别！",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                cboPrdtType.Focus();
                return;
            }

            BatchRingCategory prdtType = cboPrdtType.SelectedItem as BatchRingCategory;
            int idx = grdvPWOs.GetFocusedDataSourceRowIndex();
            if (idx >=0 && idx < pwos.Count)
            {
                EntityBatchPWO pwo = pwos[idx];

                using (Dialogs.frmPWOInProductionEditor formEditor =
                    new Dialogs.frmPWOInProductionEditor(
                        EditStatus.Edit,
                        stationInfo.T134LeafID,
                        stationInfo.T216LeafID,
                        prdtType.T131LeafID,
                        pwos,
                        ref pwo))
                {
                    if (formEditor.ShowDialog() == DialogResult.OK)
                    {
                        grdvPWOs.UpdateCurrentRow();

                        grdvPWOs.BestFitColumns();
                    }
                }
            }
        }

        private void btnPWORemove_Click(object sender, EventArgs e)
        {
            int idx = grdvPWOs.GetFocusedDataSourceRowIndex();
            if (idx >= 0 && idx < pwos.Count)
            {
                if (
                    XtraMessageBox.Show(
                        string.Format(
                            "是否要删除工单[{0}]的信息？",
                            pwos[idx].PWONo),
                        "系统信息",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    pwos.Remove(pwos[idx]);
                    grdvPWOs.UpdateCurrentRow();
                    grdvPWOs.BestFitColumns();
                }
            }
        }

        private void cboPrdtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPrdtType.SelectedItem != null)
            {
                BatchRingCategory prdtType =
                    (BatchRingCategory)cboPrdtType.SelectedItem;
                GetMethodStandards(
                    prdtType.T131LeafID,
                    stationInfo.T216LeafID,
                    currentBatchNo);
            }
            else
            {
                GetMethodStandards(
                    0,
                    0,
                    "");
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

                        BatchRingCategory prdtType =
                            (BatchRingCategory)cboPrdtType.SelectedItem;
                        GetMethodStandards(
                            prdtType.T131LeafID,
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
                    BatchRingCategory prdtType =
                        (BatchRingCategory)cboPrdtType.SelectedItem;
                    GetMethodStandards(
                        prdtType.T131LeafID,
                        stationInfo.T216LeafID,
                        currentBatchNo);
                    vgrdMethodParams.RefreshDataSource();
                    #endregion
                }
            }
        }
    }
}
