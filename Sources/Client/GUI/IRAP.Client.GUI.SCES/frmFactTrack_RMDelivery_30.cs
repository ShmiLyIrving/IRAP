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
using IRAP.Entity.Kanban;
using IRAP.Entities.Kanban;
using IRAP.Entities.SCES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.SCES
{
    public partial class frmFactTrack_RMDelivery_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private static string className = 
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<LeafSetEx> storeSites = new List<LeafSetEx>();

        public frmFactTrack_RMDelivery_30()
        {
            InitializeComponent();
        }

        public void GetStoreSites()
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                storeSites.Clear();
                cboStoreSite.Properties.Items.Clear();

                try
                {
                    int errCode = 0;
                    string errText = "";

                    IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                        IRAPUser.Instance.CommunityID,
                        173,
                        IRAPUser.Instance.ScenarioIndex,
                        IRAPUser.Instance.SysLogID,
                        ref storeSites,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText), 
                        strProcedureName);
                    if (errCode == 0)
                    {
                        foreach (LeafSetEx storeSite in storeSites)
                        {
                            cboStoreSite.Properties.Items.Add(storeSite);
                        }
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetPeriodTypes()
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                cboPeriodType.Properties.Items.Clear();

                try
                {
                    int errCode = 0;
                    string errText = "";
                    List<PeriodType> periodTypes = new List<PeriodType>();

                    IRAPKBClient.Instance.sfn_GetList_ValidPeriodTypes(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.LanguageID,
                        ref periodTypes,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText), 
                        strProcedureName);
                    if (errCode == 0)
                    {
                        foreach (PeriodType periodType in periodTypes)
                        {
                            cboPeriodType.Properties.Items.Add(periodType);
                        }

                        if (periodTypes.Count > 0)
                            cboPeriodType.SelectedIndex = 0;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message, 
                        strProcedureName, 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetPeriod(PeriodType periodType, DateTime dateTimeSpec, int offset)
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
                Period period = new Period();

                try
                {
                    IRAPKBClient.Instance.sfn_Period(
                        IRAPUser.Instance.CommunityID,
                        periodType.PeriodTypeCode,
                        dateTimeSpec,
                        offset,
                        ref period,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText), 
                        strProcedureName);
                    if (errCode == 0)
                    {
                        edtBeginDT.Value = period.BeginDT;
                        edtEndDT.Value = period.EndDT;
                    }
                    else
                    {
                        edtBeginDT.Value = DateTime.Now;
                        edtEndDT.Value = DateTime.Now;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message, 
                        strProcedureName, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);

                    edtBeginDT.Value = DateTime.Now;
                    edtEndDT.Value = DateTime.Now;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmFactTrack_RMDelivery_30_Shown(object sender, EventArgs e)
        {
            GetStoreSites();
            GetPeriodTypes();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            #region 查询条件合法性校验
            if (cboStoreSite.SelectedItem == null)
            {
                MessageBox.Show(
                    "请选择仓储地点！", 
                    "系统信息", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                cboStoreSite.Focus();
                return;
            }
            if (cboPeriodType.SelectedItem == null)
            {
                XtraMessageBox.Show(
                    "请选择查询的时间粒度！", 
                    "系统信息", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                cboPeriodType.Focus();
                return;
            }
            #endregion

            #region 时间粒度为“任意时间”时，校验开始时间和结束时间的合法性
            if (((PeriodType)cboPeriodType.SelectedItem).PeriodTypeCode.ToLower() == "any")
            {
                if (edtBeginDT.Value > edtEndDT.Value)
                {
                    XtraMessageBox.Show(
                        "时间段定义必须从小到大！", 
                        "系统信息", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    edtBeginDT.Focus();
                    return;
                }
                if (edtBeginDT.Value.Year != edtEndDT.Value.Year)
                {
                    XtraMessageBox.Show(
                        "时间段不能跨年！", 
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    edtBeginDT.Focus();
                    return;
                }
            }
            #endregion

            grdResults.DataSource = null;
            grdvResults.BestFitColumns();

            #region 获取查询结果
            List<RMTransferForPWO> datas = new List<RMTransferForPWO>();
            int errCode = 0;
            string errText = "";

            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPSCESClient.Instance.ufn_GetFactList_RMTransferForPWO(
                    IRAPUser.Instance.CommunityID,
                    ((LeafSetEx)cboStoreSite.SelectedItem).LeafID,
                    edtBeginDT.Value,
                    edtEndDT.Value,
                    //edtWorkCenter.Text,
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
                    MessageBox.Show(
                        errText, 
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                MessageBox.Show(
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

        private void btnExportTo_Click(object sender, EventArgs e)
        {
            if ((grdResults.DataSource as List<RMTransferForPWO>).Count <= 0)
            {
                XtraMessageBox.Show(
                    "没有可以导出的数据",
                    "系统提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                grdvResults.ExportToXlsx(saveFileDialog.FileName);
            }
        }

        private void cboPeriodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriodType.SelectedItem != null)
            {
                PeriodType periodType = cboPeriodType.SelectedItem as PeriodType;
                if (periodType.PeriodTypeCode.ToLower() == "any")
                {
                    edtBeginDT.Enabled = true;
                    edtEndDT.Enabled = true;

                    btnPrevPeriod.Visible = false;
                    btnNextPeriod.Visible = false;
                }
                else
                {
                    edtBeginDT.Enabled = false;
                    edtEndDT.Enabled = false;

                    btnPrevPeriod.Visible = true;
                    btnNextPeriod.Visible = true;

                    GetPeriod((cboPeriodType.SelectedItem as PeriodType), DateTime.Now, 0);
                }
            }
        }

        private void btnPrevPeriod_Click(object sender, EventArgs e)
        {
            GetPeriod((cboPeriodType.SelectedItem as PeriodType), edtBeginDT.Value, -1);
        }

        private void btnNextPeriod_Click(object sender, EventArgs e)
        {
            GetPeriod((cboPeriodType.SelectedItem as PeriodType), edtBeginDT.Value, 1);
        }
    }
}
