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
using IRAP.Entities.FVS;
using IRAP.Entity.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.FVS
{
    public partial class frmKanbanPWOExec_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        List<PWOSurveillance> pwos = new List<PWOSurveillance>();

        public frmKanbanPWOExec_30()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据 T103LeafID 获取工单列表
        /// </summary>
        private void GetProductWorkOrders()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (lstT103LeafSet.SelectedIndex >= 0)
            {
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    LeafSetEx workType = lstT103LeafSet.SelectedItem as LeafSetEx;

                    int errCode = 0;
                    string errText = "";

                    try
                    {
                        IRAPFVSClient.Instance.ufn_GetKanban_PWOSurveillance(
                            IRAPUser.Instance.CommunityID,
                            workType.LeafID,
                            IRAPUser.Instance.SysLogID,
                            ref pwos,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                        if (errCode != 0)
                        {
                            XtraMessageBox.Show(
                                errText, 
                                "系统信息", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        XtraMessageBox.Show(
                            error.Message, 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return;
                    }

                    grdPWOs.DataSource = pwos;
                    for (int i = 0; i < cardView.Columns.Count; i++)
                    {
                        cardView.Columns[i].BestFit();
                    }
                    cardView.LayoutChanged();
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void frmKanbanPWOExec_30_Shown(object sender, EventArgs e)
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
                List<LeafSetEx> workTypes = new List<LeafSetEx>();

                try
                {
                    IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                        IRAPUser.Instance.CommunityID,
                        103,
                        IRAPUser.Instance.ScenarioIndex,
                        IRAPUser.Instance.SysLogID,
                        ref workTypes,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    if (errCode != 0)
                    {
                        XtraMessageBox.Show(
                            errText, 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }

                lstT103LeafSet.Items.Clear();
                foreach (LeafSetEx workType in workTypes)
                {
                    lstT103LeafSet.Items.Add(workType);
                }
                if (lstT103LeafSet.Items.Count > 0)
                {
                    lstT103LeafSet.SelectedIndex = 0;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void lstT103LeafSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductWorkOrders();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetProductWorkOrders();
        }

        private void cardView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenu.Show(grdPWOs, e.Location);
            }
        }

        private void mitmMethodAndQualityStandard_Click(object sender, EventArgs e)
        {
            int index = cardView.GetFocusedDataSourceRowIndex();
            if (index >= 0)
            {
                using (frmMethodAndQualityStandardsWithProduct showMethodAndQualityStandard = new 
                    frmMethodAndQualityStandardsWithProduct())
                {
                    showMethodAndQualityStandard.PWO = pwos[index];
                    showMethodAndQualityStandard.ShowDialog();
                }
            }
        }
    }
}
