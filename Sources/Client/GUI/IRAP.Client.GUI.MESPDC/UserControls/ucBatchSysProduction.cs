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
using IRAP.Client.User;
using IRAP.Client.Global.Enums;
using IRAP.Client.GUI.MESPDC.Entities;
using IRAP.Entities.MDM;
using IRAP.Entities.SSO;
using IRAP.Entities.MES;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.UserControls
{
    public partial class ucBatchSysProduction : DevExpress.XtraEditors.XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private WIPStation stationInfo = null;

        private UserDetailInfo currentOperator = null;
        private DateTime startDatetime = DateTime.Now;
        /// <summary>
        /// 当前的生产炉次号
        /// </summary>
        private string currentBatchNo = "";
        /// <summary>
        /// 产品类别
        /// </summary>
        private List<BatchRingCategory> prdtTypes = new List<BatchRingCategory>();

        private List<EntityPWO> pwos = new List<EntityPWO>();
        private List<MethodStandard> standards = new List<MethodStandard>();
        private List<ProductionProcessParam> ppp = new List<ProductionProcessParam>();

        private DataTable dtParams = new DataTable();

        private string caption = "";

        public ucBatchSysProduction()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";
        }

        public ucBatchSysProduction(WIPStation station) : this()
        {
            stationInfo = station;

            if (station != null)
            {
                GetPrdtTypes();
            }

            if (station.T216LeafID == 5258694) { }
            else
            {
                lblPrdtType.Visible = false;
                cboPrdtType.Visible = false;
            }

            GetMethodStandards(0, station.T216LeafID, "");
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
                dtParams.Columns.Add(colName, typeof(long));

                EditorRow row = new EditorRow();
                row.Properties.Caption = param.T20Name;
                row.Properties.FieldName = colName;
                vgrdMethodParams.Rows.Add(row);
            }

            //for (int i = 0; i < 3; i++)
            //{
            //    DataRow dr = dtParams.NewRow();
            //    for (int j = 0; j < dtParams.Columns.Count; j++)
            //        dr[j] = (i + 1) * 1000 + (j + 1);
            //    dtParams.Rows.Add(dr);
            //}

            vgrdMethodParams.DataSource = dtParams;
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

        private string GenerateBatchProductionStartXML(List<EntityPWO> pwos)
        {
            string rlt = "";
            int idx = 1;
            foreach (EntityPWO pwo in pwos)
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
                        pwo.BatchNo,
                        pwo.TextureCode,
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

        private void ucBatchSysProduction_Load(object sender, EventArgs e)
        {
            grdPWOs.DataSource = pwos;

            BatchProductInfo data = GetWorkUnitProductionInfo();
            if (data != null)
            {
                currentOperator = new UserDetailInfo()
                {
                    UserCode = data.OperatorCode,
                    UserName = data.OperatorName,
                };
                currentBatchNo = data.BatchNumber;
                startDatetime = data.BatchStartDate;

                edtOperatorCode.Text =
                    string.Format(
                        "{0}[{1}]",
                        currentOperator.UserName,
                        currentOperator.UserCode);

                GetMethodStandards(data.T131LeafID, stationInfo.T216LeafID, data.BatchNumber);
            }
        }

        private void FormCtrlsWithWorkStatus(bool isWorking)
        {
            if (isWorking)
            {
                edtOperatorCode.Enabled = false;
                cboPrdtType.Enabled = false;

                btnPWONew.Enabled = false;
                btnPWOModify.Enabled = false;
                btnPWORemove.Enabled = false;

                btnParamNew.Enabled = true;
                btnParamRemove.Enabled = true;

                btnBegin.Enabled = false;
                btnEnd.Enabled = true;
            }
            else
            {
                edtOperatorCode.Enabled = true;
                cboPrdtType.Enabled = true;

                btnPWONew.Enabled = true;
                btnPWOModify.Enabled = true;
                btnPWORemove.Enabled = true;

                btnParamNew.Enabled = false;
                btnParamRemove.Enabled = false;

                btnBegin.Enabled = true;
                btnEnd.Enabled = false;
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

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!btnBegin.Enabled)
            {
                DateTime now = DateTime.Now;

                lblCurrentTime.Text =
                    now.ToString("yyyy-MM-dd HH:mm:ss");

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
                    "请选择当前的班次！",
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

                IRAPMESClient.Instance.usp_SaveFact_BatchProductionStart(
                    IRAPUser.Instance.CommunityID,
                    stationInfo.T216LeafID,
                    stationInfo.T107LeafID,
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

            btnBegin.Enabled = false;
            btnEnd.Enabled = true;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            btnBegin.Enabled = true;
            btnEnd.Enabled = false;
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

            EntityPWO newPWO = new EntityPWO();

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
                EntityPWO pwo = pwos[idx];

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
}
