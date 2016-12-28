using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors.Controls;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.SSO;
using IRAP.Entities.FVS;
using IRAP.WCF.Client.Method;
using IRAP.Entity.MDM;
using IRAP.Entity.FVS;
using IRAP.Entities.Kanban;
using IRAP.Entity.Kanban;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmGetHisAndonEvents : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public frmGetHisAndonEvents()
        {
            InitializeComponent();
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
                int errCode = 0;
                string errText = "";
                List<PeriodType> periods = new List<PeriodType>();

                cboPeriodTypes.Properties.Items.Clear();

                IRAPKBClient.Instance.sfn_GetList_ValidPeriodTypes(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.LanguageID,
                    ref periods,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                       string.Format("({0}){1}", errCode, errText),
                       strProcedureName);

                if (errCode == 0)
                {
                    foreach (PeriodType data in periods)
                        cboPeriodTypes.Properties.Items.Add(data);
                    if (periods.Count > 0)
                        cboPeriodTypes.SelectedIndex = 0;
                }
                else
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        Text);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetAndonEventTypes()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                cboAndonEventTypes.Properties.Items.Clear();
                cboAndonEventTypes.Properties.Items.Add(
                    new AndonEventType()
                    {
                        EventTypeLeaf = 0,
                        EventTypeName = "全部",
                    });

                int errCode = 0;
                string errText = "";
                List<AndonEventType> types = new List<AndonEventType>();

                IRAPMDMClient.Instance.ufn_GetList_AndonEventTypes(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref types,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                       string.Format("({0}){1}", errCode, errText),
                       strProcedureName);

                if (errCode == 0)
                {
                    foreach (AndonEventType data in types)
                        if (data.Available)
                            cboAndonEventTypes.Properties.Items.Add(data);
                    if (types.Count > 0)
                        cboAndonEventTypes.SelectedIndex = 0;
                }
                else
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        Text);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void SetDateTimePeriod(
            string periodTypeCode,
            DateTime datetimeSpec,
            int periodOffset)
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

                IRAPKBClient.Instance.sfn_Period(
                    IRAPUser.Instance.CommunityID,
                    periodTypeCode,
                    datetimeSpec,
                    periodOffset,
                    ref period,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode!=0)
                {
                    edtBeginDT.Value =
                        DateTime.Parse(
                            string.Format(
                                "{0} 00:00:00.000",
                                DateTime.Now.ToString("yyyy-MM-dd")));
                    edtEndDT.Value =
                        DateTime.Parse(
                            string.Format(
                                "{0} 23:59:59.999",
                                DateTime.Now.ToString("yyyy-MM-dd")));

                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        Text);
                }
                else
                {
                    edtBeginDT.Value = period.BeginDT;
                    edtEndDT.Value = period.EndDT;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                IRAPMessageBox.Instance.ShowErrorMessage(error.Message, Text);

                edtBeginDT.Value =
                    DateTime.Parse(
                        string.Format(
                            "{0} 00:00:00.000",
                            DateTime.Now.ToString("yyyy-MM-dd")));
                edtEndDT.Value =
                    DateTime.Parse(
                        string.Format(
                            "{0} 23:59:59.999",
                            DateTime.Now.ToString("yyyy-MM-dd")));
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetAndonEvents(
            int t134LeafID, 
            int t179LeafID,
            string beginDate,
            string endDate)
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
                List<AndonEventFact> datas = new List<AndonEventFact>();

                IRAPFVSClient.Instance.ufn_GetFactList_AndonEvents(
                    IRAPUser.Instance.CommunityID,
                    t134LeafID,
                    t179LeafID,
                    beginDate,
                    endDate,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                {
                    grdAndonEvents.DataSource = null;

                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        Text);
                }
                else
                {
                    grdAndonEvents.DataSource = datas;
                }
            }
            catch (Exception error)
            {
                grdAndonEvents.DataSource = null;

                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                IRAPMessageBox.Instance.ShowErrorMessage(error.Message, Text);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmGetHisAndonEvents_Shown(object sender, EventArgs e)
        {
            GetPeriodTypes();
            GetAndonEventTypes();
        }

        private void frmGetHisAndonEvents_Activated(object sender, EventArgs e)
        {
            if (cboPeriodTypes.Properties.Items.Count <= 0)
                GetPeriodTypes();
            if (cboAndonEventTypes.Properties.Items.Count <= 0)
                GetAndonEventTypes();
        }

        private void cboPeriodTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriodTypes.SelectedIndex < 0)
            {
                edtBeginDT.Value =
                    DateTime.Parse(
                        string.Format(
                            "{0} 00:00:00.000",
                            DateTime.Now.ToString("yyyy-MM-dd")));
                edtEndDT.Value =
                    DateTime.Parse(
                        string.Format(
                            "{0} 23:59:59.999",
                            DateTime.Now.ToString("yyyy-MM-dd")));

                edtBeginDT.Enabled = false;
                edtEndDT.Enabled = false;

                lnklblPrev.Enabled = false;
                lnklblNext.Enabled = false;
            }
            else
            {
                PeriodType periodType = cboPeriodTypes.SelectedItem as PeriodType;
                switch (periodType.PeriodTypeID)
                {
                    case 99:
                        edtBeginDT.Enabled = true;
                        edtEndDT.Enabled = true;

                        lnklblPrev.Enabled = false;
                        lnklblNext.Enabled = false;

                        break;
                    default:
                        edtBeginDT.Enabled = false;
                        edtEndDT.Enabled = false;

                        lnklblPrev.Enabled = true;
                        lnklblNext.Enabled = true;

                        SetDateTimePeriod(
                            periodType.PeriodTypeCode,
                            DateTime.Now,
                            0);

                        break;
                }
            }
        }

        private void lnklblPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboPeriodTypes.SelectedItem == null)
                return;

            PeriodType type = cboPeriodTypes.SelectedItem as PeriodType;
            if (type.PeriodTypeID == 99)
                return;

            SetDateTimePeriod(type.PeriodTypeCode, edtBeginDT.Value, -1);
        }

        private void lnklblNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboPeriodTypes.SelectedItem == null)
                return;

            PeriodType type = cboPeriodTypes.SelectedItem as PeriodType;
            if (type.PeriodTypeID == 99)
                return;

            SetDateTimePeriod(type.PeriodTypeCode, edtBeginDT.Value, 1);
        }

        private void btnGetAndonEvents_Click(object sender, EventArgs e)
        {
            if (edtBeginDT.Value > edtEndDT.Value)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "查询时间段的开始日期不能晚于结束日期！",
                    Text);
                return;
            }
            if (cboAndonEventTypes.SelectedItem == null)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "请选择一种安灯事件类型进行查询！",
                    Text);
                return;
            }
            if (currentProductionLine == null || 
                currentProductionLine.T134LeafID == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "当前站点没有绑定产线，无法查询！",
                    Text);
                return;
            }

            GetAndonEvents(
                currentProductionLine.T134LeafID,
                (cboAndonEventTypes.SelectedItem as AndonEventType).EventTypeLeaf,
                edtBeginDT.Value.ToString("G"),
                edtEndDT.Value.ToString("G"));
        }
    }
}
