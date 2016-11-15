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
using IRAP.Entity.MDM;
using IRAP.Entities.FVS;
using IRAP.Entity.FVS;
using IRAP.Entities.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventConsultationConfirm : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        bool isShowMessageBeforeActive = false;

        public frmAndonEventConsultationConfirm()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            lstEventType.Items.Clear();
            lstEventType.SelectedItem = null;

            tcEventTypes.SelectedTabPage = tpEmpty;

            ucDeviceFailureModes.T133Code = "";
            rgpT144Leaf.SelectedIndex = -1;

            grdStaffs.DataSource = null;
        }

        /// <summary>
        /// 安灯事件会诊结果确认保存
        /// </summary>
        /// <param name="eventFactID">安灯事件事实号</param>
        /// <param name="newEventType">新安灯类型叶标识</param>
        /// <param name="objectTreeID">对象树标识</param>
        /// <param name="objectCode">设备代码</param>
        /// <param name="attrLeafID">失效模式叶标识</param>
        /// <param name="t144LeafID">发生原因叶标识</param>
        /// <param name="userCode">安灯事件处理责任人代码</param>
        private void ConsultationConfirm(
            long eventFactID,
            int newEventType,
            int objectTreeID,
            string objectCode,
            int attrLeafID,
            int t144LeafID,
            string userCode)
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

                IRAPFVSClient.Instance.usp_SaveFact_AndonEventConsultation(
                    IRAPUser.Instance.CommunityID,
                    eventFactID,
                    newEventType,
                    objectTreeID,
                    objectCode,
                    attrLeafID,
                    t144LeafID,
                    userCode,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        Text);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                IRAPMessageBox.Instance.ShowErrorMessage(
                    error.Message,
                    Text);
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

            int errCode = 0;
            string errText = "";
            List<AndonEventType> types = new List<AndonEventType>();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPMDMClient.Instance.ufn_GetList_AndonEventTypes(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref types,
                    out errCode,
                    out errText);

                if (errCode == 0)
                {
                    switch (IRAPUser.Instance.CommunityID)
                    {
                        case 60006:
                            foreach (AndonEventType type in types)
                            {
                                if (type.EventTypeCode == "T" ||
                                    type.EventTypeCode == "S" ||
                                    type.EventTypeCode == "M")
                                    continue;
                                else
                                {
                                    int idx = lstEventType.Items.Add(type);
                                    lstEventType.Items[idx].ImageIndex = type.Ordinal - 1;
                                }
                            }
                            break;
                        default:
                            foreach (AndonEventType type in types)
                            {
                                int idx = lstEventType.Items.Add(type);
                                lstEventType.Items[idx].ImageIndex = type.Ordinal - 1;
                            }
                            break;
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetT144Leaf()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int errCode = 0;
            string errText = "";
            List<AnomalyCauseType> datas = new List<AnomalyCauseType>();

            rgpT144Leaf.Properties.Items.Clear();
            rgpT144Leaf.SelectedIndex = -1;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPFVSClient.Instance.ufn_GetList_AnomalyCauseTypes(
                    IRAPUser.Instance.CommunityID,
                    currentProductionLine.T134LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (AnomalyCauseType data in datas)
                    {
                        rgpT144Leaf.Properties.Items.Add(
                            new RadioGroupItem()
                            {
                                Description = data.T144Name,
                                Value = data,
                            });
                    }
                }
                else
                {
                    isShowMessageBeforeActive = true;
                    IRAPMessageBox.Instance.Show(
                        errText,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetEvents_WaitforConfirm()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int errCode = 0;
            string errText = "";
            List<EventToConsultation> datas = new List<EventToConsultation>();

            cboAndonEvent.Properties.Items.Clear();
            cboAndonEvent.SelectedItem = null;

            Clear();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPFVSClient.Instance.ufn_GetList_EventsToConsultation(
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
                    foreach (EventToConsultation data in datas)
                    {
                        cboAndonEvent.Properties.Items.Add(data);
                    }
                    if (datas.Count > 0)
                        cboAndonEvent.SelectedIndex = 0;
                }
                else
                {
                    isShowMessageBeforeActive = true;
                    IRAPMessageBox.Instance.Show(
                        errText,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetNewEventInfo(
            ref int eventLeafID, 
            ref int objectTreeID,
            ref string objectCode, 
            ref int failureModeLeafID)
        {
            eventLeafID = 0;
            objectTreeID = 0;
            objectCode = "";
            failureModeLeafID = 0;

            if (lstEventType.SelectedItem == null)
                return;

            AndonEventType eventType = (lstEventType.SelectedItem as ImageListBoxItem).Value as AndonEventType;
            eventLeafID = eventType.EventTypeLeaf;

            switch (eventType.EventTypeCode)
            {
                case "R":
                    objectTreeID = 133;
                    objectCode = ucDeviceFailureModes.T133Code;
                    failureModeLeafID = ucDeviceFailureModes.FailureModeLeafID;
                    break;
                case "M":
                    objectTreeID = 118;
                    failureModeLeafID = ucFailureModesM.FailureModeLeafID;
                    break;
                case "Q":
                    objectTreeID = 118;
                    failureModeLeafID = ucFailureModesQ.FailureModeLeafID;
                    break;
                case "T":
                    objectTreeID = 118;
                    failureModeLeafID = ucFailureModesT.FailureModeLeafID;
                    break;
                case "S":
                    objectTreeID = 118;
                    failureModeLeafID = ucFailureModesS.FailureModeLeafID;
                    break;
                case "O":
                    break;
            }
        }

        private void frmAndonEventConsultationConfirm_Load(object sender, EventArgs e)
        {
            GetEvents_WaitforConfirm();
            GetAndonEventTypes();
        }

        private void cboAndonEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAndonEvent.SelectedItem == null)
            {
                grdStaffs.DataSource = null;

                splitContainerControl1.Enabled = false;
                lstEventType.SelectedItem = null;

                Clear();
            }
            else
            {
                grdStaffs.DataSource = (cboAndonEvent.SelectedItem as EventToConsultation).Stakeholders;

                splitContainerControl1.Enabled = true;

                EventToConsultation etc = cboAndonEvent.SelectedItem as EventToConsultation;

                AndonEventType eventType = null;
                if (lstEventType.SelectedItem != null)
                {
                    eventType = (lstEventType.SelectedItem as ImageListBoxItem).Value as AndonEventType;
                }
                else
                    eventType = new AndonEventType();

                if (etc.EventCode == eventType.EventTypeCode)
                lstEventType_SelectedIndexChanged(lstEventType, null);
                else
                {
                    foreach (ImageListBoxItem item in lstEventType.Items)
                    {
                        if (item == null)
                            continue;

                        if (item.Value is AndonEventType)
                        {
                            if (((AndonEventType)item.Value).EventTypeCode == etc.EventCode)
                            {
                                lstEventType.SelectedItem = item;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void lstEventType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEventType.SelectedItem == null)
                tcEventTypes.SelectedTabPage = tpEmpty;
            else
            {
                EventToConsultation etc = null;
                if (cboAndonEvent.SelectedItem != null)
                {
                    etc = cboAndonEvent.SelectedItem as EventToConsultation;
                }

                AndonEventType eventType = (lstEventType.SelectedItem as ImageListBoxItem).Value as AndonEventType;
                switch (eventType.EventTypeCode)
                {
                    case "R":
                        tcEventTypes.SelectedTabPage = tpR;

                        if (etc != null && etc.EventCode == "R")
                            ucDeviceFailureModes.T133Code = etc.WFInstanceID;
                        else
                            ucDeviceFailureModes.T133Code = "";
                        break;
                    case "M":
                        tcEventTypes.SelectedTabPage = tpM;

                        ucFailureModesM.T179LeafID = eventType.EventTypeLeaf;
                        break;
                    case "Q":
                        tcEventTypes.SelectedTabPage = tpQ;

                        ucFailureModesQ.T179LeafID = eventType.EventTypeLeaf;
                        break;
                    case "T":
                        tcEventTypes.SelectedTabPage = tpT;

                        ucFailureModesT.T179LeafID = eventType.EventTypeLeaf;
                        break;
                    case "S":
                        tcEventTypes.SelectedTabPage = tpS;

                        ucFailureModesS.T179LeafID = eventType.EventTypeLeaf;
                        break;
                    case "O":
                        tcEventTypes.SelectedTabPage = tpO;
                        break;
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cboAndonEvent.SelectedItem == null)
                return;
            if (lstEventType.SelectedItem == null)
                return;
            if (grdvStaffs.GetFocusedDataSourceRowIndex() < 0)
                return;

            string objectCode = "";
            int failureModeLeafID = 0;
            int eventTypeLeaf = 0;
            int t144LeafID = 0;
            int objectTreeID = 0;

            GetNewEventInfo(ref eventTypeLeaf, ref objectTreeID, ref objectCode, ref failureModeLeafID);
            if (eventTypeLeaf == 0)
                return;
            if (objectCode != "" && failureModeLeafID == 0)
                return;
            if (rgpT144Leaf.SelectedIndex < 0)
                return;
            t144LeafID = (rgpT144Leaf.Properties.Items[rgpT144Leaf.SelectedIndex].Value as AnomalyCauseType).T144LeafID;

            string userCode = "";
            int idx = grdvStaffs.GetFocusedDataSourceRowIndex();
            if (idx >= 0)
            {
                userCode = (grdStaffs.DataSource as List<Stakeholder>)[idx].UserCode;
            }
            else
            {
                return;
            }

            ConsultationConfirm(
                (cboAndonEvent.SelectedItem as EventToConsultation).EventFactID,
                eventTypeLeaf,
                objectTreeID,
                objectCode,
                failureModeLeafID,
                t144LeafID,
                userCode);

            GetEvents_WaitforConfirm();
        }

        private void frmAndonEventConsultationConfirm_Activated(object sender, EventArgs e)
        {
            if (!isShowMessageBeforeActive)
            {
                GetEvents_WaitforConfirm();
                isShowMessageBeforeActive = false;
            }

            GetT144Leaf();
        }
    }
}
