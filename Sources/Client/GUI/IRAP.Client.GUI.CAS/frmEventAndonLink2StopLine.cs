using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmEventAndonLink2StopLine : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<SelectPeriodStopEvent> stopEvents = new List<SelectPeriodStopEvent>();
        private List<SelectPeriodAndonEvent> andonEvents = new List<SelectPeriodAndonEvent>();
        private List<SelectPeriodAndonEvent> unUsedAndonEvents = new List<SelectPeriodAndonEvent>();

        private string caption = "";

        public frmEventAndonLink2StopLine()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";
        }

        private void GetStopEvents()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                stopEvents.Clear();

                int errCode = 0;
                string errText = "";
                List<PeriodStopEvent> datas = new List<PeriodStopEvent>();

                IRAPFVSClient.Instance.ufn_GetList_PeriodStopEvents(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (PeriodStopEvent data in datas)
                    {
                        AddToSelectStopEvent(data);

                        // 如果停线事件已经和安灯事件关联，则从 unUsedAndonEvents中删除已关联的事件
                        if (data.AndonFactID != 0)
                        {
                            SelectPeriodAndonEvent andonEvent = 
                                FindAndonEventWithFactID(
                                    unUsedAndonEvents,
                                    data.AndonFactID);
                            if (andonEvent != null)
                            {
                                unUsedAndonEvents.Remove(andonEvent);
                            }
                        }
                    }

                    grdStopEvents.DataSource = stopEvents;
                }
                else
                {
                    grdStopEvents.DataSource = null;

                    IRAPMessageBox.Instance.ShowErrorMessage(errText, caption);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void AddToSelectStopEvent(PeriodStopEvent data)
        {
            SelectPeriodStopEvent stopEvent = null;

            if (data != null)
            {
                for (int i = 0; i < stopEvents.Count; i++)
                {
                    if (stopEvents[i].EventFactID == data.EventFactID)
                    {
                        stopEvent = stopEvents[i];
                        break;
                    }
                }

                if (stopEvent == null)
                {
                    stopEvent = new SelectPeriodStopEvent();
                    stopEvent.Ordinal = stopEvents.Count + 1;
                    stopEvents.Add(stopEvent);
                }
                stopEvent.CopyFrom(data);
            }
        }

        private void GetAndonEvents()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                andonEvents.Clear();
                unUsedAndonEvents.Clear();

                int errCode = 0;
                string errText = "";
                List<PeriodAndonEvent> datas = new List<PeriodAndonEvent>();

                IRAPFVSClient.Instance.ufn_GetList_PeriodAndonEvents(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (PeriodAndonEvent data in datas)
                    {
                        SelectPeriodAndonEvent andonEvent = new SelectPeriodAndonEvent();
                        andonEvent.CopyFrom(data);

                        andonEvents.Add(andonEvent);
                        unUsedAndonEvents.Add(andonEvent.Clone());
                    }
                }
                else
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText, caption);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private List<SelectPeriodAndonEvent> GetAndonEventsWithStopEvent(string clickStream)
        {
            List<SelectPeriodAndonEvent> rlt = new List<SelectPeriodAndonEvent>();

            foreach (SelectPeriodAndonEvent data in unUsedAndonEvents)
                rlt.Add(data);

            return rlt;
        }

        private SelectPeriodAndonEvent FindAndonEventWithFactID(List<SelectPeriodAndonEvent> datas, long factID)
        {
            SelectPeriodAndonEvent rlt = null;
            foreach (SelectPeriodAndonEvent data in datas)
            {
                if (data.EventFactID == factID)
                {
                    rlt = data;
                    break;
                }
            }

            return rlt;
        }

        private void RemoveFromUnUsedAndonEvents(long eventFactID)
        {
            SelectPeriodAndonEvent data =
                FindAndonEventWithFactID(
                    unUsedAndonEvents,
                    eventFactID);
            if (data != null)
            {
                unUsedAndonEvents.Remove(data);
            }
        }

        private void frmEventAndonLink2StopLine_Load(object sender, EventArgs e)
        {

        }

        private void frmEventAndonLink2StopLine_Activated(object sender, EventArgs e)
        {
            GetAndonEvents();
            GetStopEvents();

            grdvStopEvents_FocusedRowChanged(null, null);
        }

        private void grdvAndonEvents_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //if (e.Row is SelectPeriodAndonEvent)
            //    IRAPMessageBox.Instance.ShowInformation((e.Row as SelectPeriodAndonEvent).Description);

        }

        private void grdvStopEvents_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int idx = grdvStopEvents.GetFocusedDataSourceRowIndex();
            if (idx < 0 || idx >= stopEvents.Count)
                return;

            SelectPeriodStopEvent stopEvent = stopEvents[idx];

            List<SelectPeriodAndonEvent> datas = new List<SelectPeriodAndonEvent>();
            for (int i = 0; i < stopEvent.AndonEventFactIDs.Count; i++)
            {
                SelectPeriodAndonEvent data = FindAndonEventWithFactID(andonEvents, stopEvent.AndonEventFactIDs[i]);
                if (data != null)
                {
                    data = data.Clone();
                    data.Selected = true;
                    datas.Add(data);
                }
            }
            foreach (SelectPeriodAndonEvent data in unUsedAndonEvents)
                datas.Add(data.Clone());

            SelectPeriodAndonEvent_CompareByFactID compare = new SelectPeriodAndonEvent_CompareByFactID();
            datas.Sort(compare);

            grdAndonEvents.DataSource = datas;
            grdvAndonEvents.BestFitColumns();
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            int idx = grdvAndonEvents.GetFocusedDataSourceRowIndex();
            if ( grdvAndonEvents.GetFocusedRow() != null)
            {
                SelectPeriodAndonEvent data = 
                    grdvAndonEvents.GetFocusedRow() as SelectPeriodAndonEvent;

                SelectPeriodStopEvent stopEvent = 
                    grdvStopEvents.GetFocusedRow() as SelectPeriodStopEvent;

                data.Selected = !data.Selected;
                grdvStopEvents.BeginDataUpdate();
                if (data.Selected)
                {
                    RemoveFromUnUsedAndonEvents(data.EventFactID);
                    stopEvent.AndonEventFactIDs.Add(data.EventFactID);
                }
                else
                {
                    unUsedAndonEvents.Add(data.Clone());
                    stopEvent.AndonEventFactIDs.Remove(data.EventFactID);
                }
                grdvStopEvents.EndDataUpdate();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                bool saveSuccessed = true;
                string errorMessage = "";

                foreach (SelectPeriodStopEvent data in stopEvents)
                {
                    try
                    {
                        int errCode = 0;
                        string errText = "";
                        long transactNo = 0;
                        string opNode = "-4820";

                        transactNo =
                            IRAPUTSClient.Instance.mfn_GetTransactNo(
                                IRAPUser.Instance.CommunityID,
                                1,
                                IRAPUser.Instance.SysLogID,
                                opNode);

                        IRAPFVSClient.Instance.usp_SaveFact_StopEvent(
                            IRAPUser.Instance.CommunityID,
                            transactNo,
                            data.EventFactID,
                            134,
                            currentProductionLine.T134LeafID,
                            data.ClickStream,
                            0,
                            IRAPUser.Instance.SysLogID,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("({0}){1}", errCode, errText),
                            strProcedureName);

                        if (errCode == 0)
                        {
                            saveSuccessed = saveSuccessed && true;
                            errorMessage +=
                                string.Format(
                                    "第 [{0}] 条停线记录与安灯事件关联成功\n",
                                    data.Ordinal);
                        }
                        else
                        {
                            saveSuccessed = saveSuccessed && false;
                            errorMessage +=
                                string.Format(
                                    "第 [{0}] 条停线记录与安灯事件关联失败：[{1}]\n",
                                    data.Ordinal,
                                    errText);
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                        saveSuccessed = saveSuccessed && false;
                        errorMessage +=
                            string.Format(
                                "第 [{0}] 条停线记录与安灯事件关联失败：[{1}]\n",
                                data.Ordinal,
                                error.Message);
                    }
                }

                if (saveSuccessed)
                    XtraMessageBox.Show(
                        errorMessage,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show(
                        errorMessage,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmEventAndonLink2StopLine_Activated(null, null);
        }
    }

    internal class SelectPeriodStopEvent
    {
        private List<long> andonEventFactIDs = new List<long>();

        public SelectPeriodStopEvent()
        {
            Ordinal = 0;
            EventFactID = 0;
            Remark = "";
            CallTime = "";
            EndTime = "";
        }

        public int Ordinal { get; set; }
        public long EventFactID { get; set; }
        public string Remark { get; set; }
        public string CallTime { get; set; }
        public string EndTime { get; set; }

        public bool IsLinked
        {
            get { return andonEventFactIDs.Count > 0; }
        }

        public string ClickStream
        {
            get
            {
                string rlt = "";
                foreach (long factID in andonEventFactIDs)
                {
                    if (rlt == "")
                        rlt += factID.ToString();
                    else
                        rlt += "," + factID.ToString();
                }

                return rlt;
            }
        }

        public List<long> AndonEventFactIDs
        {
            get { return andonEventFactIDs; }
        }

        public SelectPeriodStopEvent Clone()
        {
            return MemberwiseClone() as SelectPeriodStopEvent;
        }

        public void CopyFrom(PeriodStopEvent parent)
        {
            EventFactID = parent.EventFactID;
            Remark = parent.Remark;
            CallTime = parent.CallTime;
            EndTime = parent.EndTime;

            if (parent.AndonFactID != 0)
                andonEventFactIDs.Add(parent.AndonFactID);
        }
    }

    internal class SelectPeriodAndonEvent : PeriodAndonEvent
    {
        public bool Selected { get; set; }

        public new SelectPeriodAndonEvent Clone()
        {
            return MemberwiseClone() as SelectPeriodAndonEvent;
        }

        public void CopyFrom(PeriodAndonEvent parent)
        {
            var parentType = typeof(PeriodAndonEvent);
            var properties = parentType.GetProperties();
            foreach (var propertie in properties)
            {
                if (propertie.CanRead && propertie.CanWrite)
                    propertie.SetValue(this, propertie.GetValue(parent, null), null);
            }
        }
    }

    internal class SelectPeriodAndonEvent_CompareByFactID : IComparer<SelectPeriodAndonEvent>
    {
        public int Compare(SelectPeriodAndonEvent x, SelectPeriodAndonEvent y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (y == null)
                    return 1;
                else
                    return x.EventFactID.CompareTo(y.EventFactID);
            }
        }
    }
}
