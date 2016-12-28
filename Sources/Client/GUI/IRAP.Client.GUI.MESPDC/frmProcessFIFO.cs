using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmProcessFIFO : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<ProducingPWOFromWorkUnit> pwoOnWorking = 
            new List<ProducingPWOFromWorkUnit>();
        private List<ToDoPWOFromWorkUnit> pwoWaiting =
            new List<ToDoPWOFromWorkUnit>();

        private string caption = "";

        public frmProcessFIFO()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";
        }

        private void GetPWOOnProducing()
        {
            cboDevices.Properties.Items.Clear();
            cboDevices.SelectedItem = null;

#if !DEBUG
            if (Options.SelectProduct == null ||
                Options.SelectWorkUnit == null)
                return;
#endif

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

                IRAPMESClient.Instance.ufn_GetList_ProducingPWOFromWorkUnit(
                    IRAPUser.Instance.CommunityID,
#if DEBUG
                    0,
                    0,
#else
                    Options.SelectProduct.T102LeafID,
                    Options.SelectWorkUnit.WorkUnitLeaf,
#endif
                    IRAPUser.Instance.SysLogID,
                    ref pwoOnWorking,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (ProducingPWOFromWorkUnit data in pwoOnWorking)
                    {
                        cboDevices.Properties.Items.Add(data.T133Name);
                    }
                    if (pwoOnWorking.Count > 0)
                        cboDevices.SelectedIndex = 0;
                }
                else
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText, caption);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                IRAPMessageBox.Instance.ShowErrorMessage(error.Message, caption);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetPWOOnWaiting()
        {
#if !DEBUG
            if (Options.SelectProduct == null ||
                Options.SelectWorkUnit == null)
                return;
#endif

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

                IRAPMESClient.Instance.ufn_GetList_ToDoPWOFromWorkUnit(
                    IRAPUser.Instance.CommunityID,
#if DEBUG
                    0,
                    0,
#else
                    Options.SelectProduct.T102LeafID,
                    Options.SelectWorkUnit.WorkUnitLeaf,
#endif
                    IRAPUser.Instance.SysLogID,
                    ref pwoWaiting,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    grdPWOofWait.DataSource = pwoWaiting;
                    grdvPWOofWait.BestFitColumns();
                }
                else
                {
                    grdPWOofWait.DataSource = null;

                    IRAPMessageBox.Instance.ShowErrorMessage(errText, caption);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                IRAPMessageBox.Instance.ShowErrorMessage(error.Message, caption);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void AfterOptionsChanged(object sender, EventArgs e)
        {
            GetPWOOnProducing();
            GetPWOOnWaiting();
        }

        private void cboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDevices.SelectedIndex >= 0 &&
                cboDevices.SelectedIndex < pwoOnWorking.Count)
            {
                int idx = cboDevices.SelectedIndex;

                rowPWONo.Properties.Value = pwoOnWorking[idx].PWONo;
                rowPWOQuantity.Properties.Value = pwoOnWorking[idx].PWOQuantity.ToString();
                rowPWOStartTime.Properties.Value = pwoOnWorking[idx].PWOStartTime;
                rowPlannedCloseTime.Properties.Value = pwoOnWorking[idx].PlannedCloseTime;
                rowT133Name.Properties.Value = pwoOnWorking[idx].T133Name;
                rowNotGoodQuantity.Properties.Value = pwoOnWorking[idx].NotGoodQuantity.ToString();
                rowGoodRate.Properties.Value = pwoOnWorking[idx].GoodRate.ToString("#0.00 %");
            }
            else
            {
                rowPWONo.Properties.Value = "";
                rowPWOQuantity.Properties.Value = "";
                rowPWOStartTime.Properties.Value = "";
                rowPlannedCloseTime.Properties.Value = "";
                rowPlannedCloseTime.Properties.Value = "";
                rowT133Name.Properties.Value = "";
                rowNotGoodQuantity.Properties.Value = "";
                rowGoodRate.Properties.Value = "";
            }

            vgrdCurrentPWO.BestFit();
        }

        private void frmProcessFIFO_Load(object sender, EventArgs e)
        {
            Options.OptionChanged += AfterOptionsChanged;

            AfterOptionsChanged(null, null);
        }

        private void frmProcessFIFO_FormClosed(object sender, FormClosedEventArgs e)
        {
            Options.OptionChanged -= AfterOptionsChanged;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AfterOptionsChanged(null, null);
        }

        private void frmProcessFIFO_Activated(object sender, EventArgs e)
        {
            Options.Visible = true;
        }
    }
}
