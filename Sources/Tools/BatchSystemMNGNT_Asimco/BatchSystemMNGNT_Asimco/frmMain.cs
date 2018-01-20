using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using DevExpress.XtraBars;

using IRAP.Global;
using IRAPORM;
using IRAPShared;
using BatchSystemMNGNT_Asimco.Entities;
using BatchSystemMNGNT_Asimco.DAL;

namespace BatchSystemMNGNT_Asimco
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<Entities.TEntityCustomLog> logs = new List<Entities.TEntityCustomLog>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void ShowWaitForm(string description, string caption = "")
        {
            if (!splashScreenManager.IsSplashFormVisible)
                splashScreenManager.ShowWaitForm();

            if (caption == "")
                splashScreenManager.SetWaitFormCaption("请稍等......");
            else
                splashScreenManager.SetWaitFormCaption(caption);
            splashScreenManager.SetWaitFormDescription(description);
        }

        private void CloseWaitForm()
        {
            if (splashScreenManager.IsSplashFormVisible)
                splashScreenManager.CloseWaitForm();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void bbiSysParams_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmSysParams sysParamForm = new frmSysParams())
            {
                sysParamForm.ShowDialog();
            }
        }

        private void btnGetLogs_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitForm("获取数据", "程序正在处理，请稍等......");
                if (chkFailureOnly.Enabled)
                {
                    TWebServShuttlingLogs.Instance.GetLogs(
                        "",
                        edtItemNumber.Text,
                        edtRecvBatchNo.Text,
                        edtMONo.Text,
                        edtMOLineNo.Text,
                        chkFailureOnly.Checked);
                }
                else
                {
                    TWebServShuttlingLogs.Instance.GetLogs();
                }

                grdvLogs.BeginUpdate();
                grdLogs.DataSource = null;
                grdLogs.DataSource = TWebServShuttlingLogs.Instance.Logs;
                grdvLogs.EndUpdate();

                grdvLogs.BestFitColumns();
                grdvLogs.ExpandAllGroups();
            }
            catch (Exception error)
            {
                MSGHelp.Instance.ShowErrorMessage(error);
            }
            finally
            {
                CloseWaitForm();
            }
        }

        private void edtLinkedLogID_EditValueChanged(object sender, EventArgs e)
        {
            chkFailureOnly.Enabled =
                edtItemNumber.Text.Trim() != "" ||
                edtRecvBatchNo.Text.Trim() != "" ||
                edtMONo.Text.Trim() != "" ||
                edtMOLineNo.Text.Trim() != "";

            if (!chkFailureOnly.Enabled)
            {
                chkFailureOnly.Checked = true;
            }
        }

        private void grdvLogs_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int idx = e.FocusedRowHandle;
            if (idx < 0 || idx >= TWebServShuttlingLogs.Instance.Logs.Count)
            {
                edtErrText.Text = "";
                grdExChangeXML.DataSource = null;
                grdMaterialStore.DataSource = null;
            }
            else
            {
                TEntityCustomLog log =
                    TWebServShuttlingLogs.Instance.Logs[grdvLogs.GetFocusedDataSourceRowIndex()];

                edtErrText.Text = log.ErrText;

                grdvExChangeXML.Columns.Clear();
                grdExChangeXML.DataSource = log.ExChange;

                try
                {
                    grdMaterialStore.DataSource = TDBHelper.GetMaterialStore(log.SKUID);
                }
                catch (Exception error)
                {
                    MSGHelp.Instance.ShowErrorMessage(error);
                    grdMaterialStore.DataSource = null;
                }
            }
        }

        private void grdvLogs_DoubleClick(object sender, EventArgs e)
        {
            int idx = grdvLogs.GetFocusedDataSourceRowIndex();
            if (idx >= 0 && idx < TWebServShuttlingLogs.Instance.Logs.Count)
            {
                TEntityCustomLog log = TWebServShuttlingLogs.Instance.Logs[idx];
                log.Do();
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            foreach (TEntityCustomLog log in TWebServShuttlingLogs.Instance.Logs)
            {
                if (log.Checked)
                {
                    tsmiRetry.Enabled = true;
                    tsmiDelete.Enabled = true;
                    return;
                }
            }

            tsmiRetry.Enabled = false;
            tsmiDelete.Enabled = false;
        }

        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            grdvLogs.BeginDataUpdate();
            foreach (TEntityCustomLog log in TWebServShuttlingLogs.Instance.Logs)
            {
                log.Checked = true;
            }
            grdvLogs.EndDataUpdate();
        }

        private void tsmiUnselectAll_Click(object sender, EventArgs e)
        {
            grdvLogs.BeginDataUpdate();
            foreach (TEntityCustomLog log in TWebServShuttlingLogs.Instance.Logs)
            {
                log.Checked = false ;
            }
            grdvLogs.EndDataUpdate();
        }
    }
}