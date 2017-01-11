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
using IRAP.Entities.FVS;
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmProductionLineStoppedConfirm : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public frmProductionLineStoppedConfirm()
        {
            InitializeComponent();

            switch (IRAPUser.Instance.CommunityID)
            {
                case 60006:
                    tcMain.SelectedTabPage = tpLineStop;
                    break;
                default:
                    tcMain.SelectedTabPage = tpLineStopWithAndonEvent;
                    break;
            }
        }

        private void GetOpenedAndonEvents()
        {
            if (currentProductionLine == null ||
                currentProductionLine.T134LeafID == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "当前站点还没有绑定生产线！",
                    Text);
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
                List<OpenAndonEvent> datas = new List<OpenAndonEvent>();

                IRAPFVSClient.Instance.ufn_GetList_OpenAndonEventsByLine(
                    IRAPUser.Instance.CommunityID,
                    134,
                    currentProductionLine.T134LeafID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                {
                    grdAndonEvents.DataSource = datas;
                }
                else
                {
                    grdAndonEvents.DataSource = null;
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

        private void GetT144Leaf(int T134LeafID)
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
                    T134LeafID,
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

        private void frmProductionLineStoppedConfirm_Activated(object sender, EventArgs e)
        {
            GetOpenedAndonEvents();
            if (currentProductionLine != null)
                GetT144Leaf(currentProductionLine.T134LeafID);
        }

        private void grdvAndonEvents_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                OpenAndonEvent andonEvent = grdvAndonEvents.GetFocusedRow() as OpenAndonEvent;
                if (andonEvent.ProductionDown)
                    btnStoppedConfirm.Enabled = true;
                else
                    btnStoppedConfirm.Enabled = false;
            }
            else
            {
                btnStoppedConfirm.Enabled = false;
            }
        }

        private void btnStoppedConfirm_Click(object sender, EventArgs e)
        {
            object focusedObject = grdvAndonEvents.GetFocusedRow();

            if (focusedObject == null || 
                !(focusedObject is OpenAndonEvent))
                return;

            OpenAndonEvent focusedEvent = focusedObject as OpenAndonEvent;
            if (!focusedEvent.ProductionDown)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "未停产的安灯呼叫事件不能作为停线的关联安灯事件！",
                    Text);
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
                long transactNo = 0;
                long factID = 0;
                string opNode = "-4820";

                transactNo =
                    IRAPUTSClient.Instance.mfn_GetTransactNo(
                        IRAPUser.Instance.CommunityID,
                        1,
                        IRAPUser.Instance.SysLogID,
                        opNode);
                factID =
                    IRAPUTSClient.Instance.mfn_GetFactID(
                        IRAPUser.Instance.CommunityID,
                        1,
                        IRAPUser.Instance.SysLogID,
                        opNode);

                IRAPFVSClient.Instance.usp_SaveFact_StopEventFromAndon(
                    IRAPUser.Instance.CommunityID,
                    transactNo,
                    factID,
                    focusedEvent.EventID,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                    IRAPMessageBox.Instance.ShowInformation(errText, Text);
                else
                    IRAPMessageBox.Instance.ShowErrorMessage(errText, Text);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                IRAPMessageBox.Instance.ShowErrorMessage(error.Message, Text);
            }
            finally
            {
                GetOpenedAndonEvents();
                RefreshCurrentProductionLine();

                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void tpLineStop_Resize(object sender, EventArgs e)
        {
            btnLineStop.Left = (Width - btnLineStop.Width) / 2;
            //btnLineStop.Top = (Height - btnLineStop.Height) / 5 * 2;
        }

        private void btnLineStop_Click(object sender, EventArgs e)
        {
            int t144LeafID = 0;
            if (rgpT144Leaf.SelectedIndex < 0)
            {
                IRAPMessageBox.Instance.Show(
                    "请选择【现场原因】！",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                int idx = rgpT144Leaf.SelectedIndex;
                if (rgpT144Leaf.Properties.Items[idx].Value is AnomalyCauseType)
                {
                    AnomalyCauseType type = rgpT144Leaf.Properties.Items[idx].Value as AnomalyCauseType;
                    t144LeafID = type.T144LeafID;
                }
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
                long transactNo = 0;
                long factID = 0;
                string opNode = "-4820";

                transactNo =
                    IRAPUTSClient.Instance.mfn_GetTransactNo(
                        IRAPUser.Instance.CommunityID,
                        1,
                        IRAPUser.Instance.SysLogID,
                        opNode);
                factID =
                    IRAPUTSClient.Instance.mfn_GetFactID(
                        IRAPUser.Instance.CommunityID,
                        1,
                        IRAPUser.Instance.SysLogID,
                        opNode);

                IRAPFVSClient.Instance.usp_SaveFact_StopEvent(
                    IRAPUser.Instance.CommunityID,
                    transactNo,
                    factID,
                    134,
                    currentProductionLine.T134LeafID,
                    "",
                    t144LeafID,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                    IRAPMessageBox.Instance.ShowInformation(errText, Text);
                else
                    IRAPMessageBox.Instance.ShowErrorMessage(errText, Text);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                IRAPMessageBox.Instance.ShowErrorMessage(error.Message, Text);
            }
            finally
            {
                RefreshCurrentProductionLine();

                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
