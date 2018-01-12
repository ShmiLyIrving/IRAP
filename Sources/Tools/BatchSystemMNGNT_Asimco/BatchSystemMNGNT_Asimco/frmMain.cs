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

namespace BatchSystemMNGNT_Asimco
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<Entities.TEntityCustomLog> logs = new List<Entities.TEntityCustomLog>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void ShowErrorMessage(Exception error)
        {
            int errCode = -1;
            string errText = "";

            if (error.Data["ErrCode"] != null)
                errCode = (int)error.Data["ErrCode"];
            if (error.Data["ErrText"] != null)
                errText = error.Data["ErrText"].ToString();

            MessageBox.Show(
                string.Format("({0}){1}", errCode, errText),
                "错误信息",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private List<TTableMaterialStore> GetMaterialStore(string skuID)
        {
            try
            {
                using (IRAPSQLConnection conn =
                    new IRAPSQLConnection(SysParams.Instance.DBConnectionString))
                {
                    IList<IDataParameter> paramList = new List<IDataParameter>();
                    paramList.Add(new IRAPProcParameter("@SKUID", DbType.String, skuID));

                    IList<TTableMaterialStore> lstDatas =
                        conn.CallTableFunc<TTableMaterialStore>(
                            "SELECT * FROM IRAPRIMCS..utb_MaterialStore " +
                            "WHERE SKUID=@SKUID",
                            paramList);

                    if (lstDatas.Count > 0)
                        return lstDatas.ToList();
                    else
                        return null;
                }
            }
            catch (Exception error)
            {
                error.Data["ErrCode"] = 999999;
                error.Data["ErrText"] =
                    string.Format(
                        "获取 SKUID[{0}] 物料的记录时发生异常：{1}",
                        skuID,
                        error.Message);
                throw error;
            }
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
                ShowErrorMessage(error);
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
                    grdMaterialStore.DataSource = GetMaterialStore(log.SKUID);
                }
                catch (Exception error)
                {
                    ShowErrorMessage(error);
                    grdMaterialStore.DataSource = null;
                }
            }
        }
    }
}