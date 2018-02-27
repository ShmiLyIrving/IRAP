using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Entities.MDM;
using IRAP.Entities.MES;
using System.Reflection;
using IRAP.WCF.Client.Method;
using IRAP.Client.User;
using System.IO;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmPhysicochemicalInspectionBatchSystem : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private List<OrderInfo> pwos = new List<OrderInfo>();
        public static string currentBatchNo = null;
        public static string currentOpType;
        public static bool saveState = true;//是否已保存

        private UserControls.ucPhysicochemicalFurnace ucMPLH = new UserControls.ucPhysicochemicalFurnace(true);
        private UserControls.ucPhysicochemicalFurnace ucLQLH = new UserControls.ucPhysicochemicalFurnace(false);
        private UserControls.ucPhysicochemicalFurnace ucLHLH = new UserControls.ucPhysicochemicalFurnace(false);
      
        public frmPhysicochemicalInspectionBatchSystem()
        {
            InitializeComponent();
            currentOpType = tcMain.SelectedTabPage.Name.Substring(3);
            tcMain.TabPages[0].Controls.Add(ucLQLH);
            ucLQLH.Dock = DockStyle.Fill;
            ucLQLH.Optype = "LQLH";
            tcMain.TabPages[1].Controls.Add(ucLHLH);
            ucLHLH.Dock = DockStyle.Fill;
            ucLHLH.Optype = "LHLH";
            tcMain.TabPages[2].Controls["plMPLH"].Controls["scMPLH"].Controls[1].Controls.Add(ucMPLH);
            ucMPLH.Dock = DockStyle.Fill;
            ucMPLH.Optype = "MPLH";
        }


        private void edtFileName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }
  
       
        private void edtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (edtBatchNo.Text.Trim() != "")
                {
                    if (AlertConfirm())
                    {
                        currentBatchNo = edtBatchNo.Text;
                        ChangeUC();
                    }
                }
            }
        }
        private bool AlertConfirm()
        {
            if (saveState == false)
            {
                DialogResult rlt = XtraMessageBox.Show("离开后未保存的数据将被清空", "数据未保存", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (rlt == DialogResult.Cancel)
                {
                    return false;
                }
            }            
            return true;           
        }
        private void tcMain_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if(!AlertConfirm())
            {
                e.Cancel = true;
            }
        }
        private void tcMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            currentOpType = e.Page.Name.Substring(3);
            ChangeUC();
        }
        /// <summary>
        /// 刷新自定义控件
        /// </summary>
        private void ChangeUC()
        {
            if (!string.IsNullOrEmpty(currentBatchNo))
            {
                if (currentOpType == "LQLH" || currentOpType == "LHLH")
                {
                    {
                        if (currentOpType == "LQLH")
                        {
                            ucLQLH.RefreshUC();
                        }
                        else
                        {
                            ucLHLH.RefreshUC();
                        }
                    }
                }
                else if (currentOpType == "MPLH")
                {
                    grdPWOs.DataSource = null;
                    pwos.Clear();
                    pwos = GetPWOWithBatchNo(currentBatchNo);
                    if (pwos == null || pwos.Count == 0)
                    {
                        ucMPLH.RefreshUC(null);
                        XtraMessageBox.Show(
                            string.Format(
                                "根据炉次号[{0}]无法找到生产信息，可能该炉次号不存在或还未开始生产",
                                frmPhysicochemicalInspectionBatchSystem.currentBatchNo),
                            "提示信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    grdPWOs.DataSource = pwos;
                    grdPWOs.RefreshDataSource();
                    grdvPWOs.BestFitColumns();
                }
            }
            saveState = true;
        }
       
        /// <summary>
        /// 根据生产容器批次号获取工单信息列表
        /// </summary>
        /// <param name="batchNumber">生产容器批次号</param>
        /// <returns></returns>
        private List<OrderInfo> GetPWOWithBatchNo(string batchNumber)
        {
            List<OrderInfo> rlt = new List<OrderInfo>();

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

                IRAPMESSmeltClient.Instance.ufn_GetList_SmeltBatchPWONo(
                    IRAPUser.Instance.CommunityID,
                    batchNumber,
                    IRAPUser.Instance.SysLogID,
                    ref rlt,
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
            catch (Exception error)
            {
                string errMsg =
                    string.Format(
                        "获取工单信息列表时发生错误：[{0}]",
                        error.Message);
                WriteLog.Instance.Write(errMsg, strProcedureName);

                XtraMessageBox.Show(
                    errMsg,
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return rlt;
        }

        private void grdvPWOs_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

            int idx = grdvPWOs.GetFocusedDataSourceRowIndex();
            if (idx >= 0 && idx < pwos.Count)
            {
                ucMPLH.RefreshUC(pwos[idx]);
                saveState = true;                      
            }            
        }

        private void grdvPWOs_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            int idx = grdvPWOs.GetFocusedDataSourceRowIndex();
            if (idx >= 0 && idx < pwos.Count)
            {
                if (!AlertConfirm())
                {
                    e.Allow = false;
                }
            }
        }
        private void edtFileName_Validating(object sender, CancelEventArgs e)
        {
        }
    }
}