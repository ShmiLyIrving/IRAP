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
using IRAP.Entity.SSO;
using IRAP.Entity.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.SubSystem
{
    public partial class frmSelectOptions : IRAP.Client.Global.frmCustomBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public frmSelectOptions()
        {
            InitializeComponent();
        }

        private void frmSelectOptions_Load(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (AvailableProcesses.Instance.Processes.Count <= 0)
                    AvailableProcesses.Instance.GetProcesses(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.SysLogID);

                lstProcesses.DataSource = AvailableProcesses.Instance.Processes;
                lstProcesses.DisplayMember = "T120NodeName";
                lstProcesses.SelectedIndex =
                    AvailableProcesses.Instance.IndexOf(
                        CurrentOptions.Instance.Process);
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void lstProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstWorkUnits.Items.Clear();
            if (lstProcesses.SelectedItem != null)
            {
                ProcessInfo process =
                    AvailableProcesses.Instance.Processes[lstProcesses.SelectedIndex];
                try
                {
                    AvailableWorkUnits.Instance.GetWorkUnits(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.SysLogID,
                        process.T120LeafID);

                    lstWorkUnits.DataSource = AvailableWorkUnits.Instance.WorkUnits;
                    lstWorkUnits.DisplayMember = "WorkUnitName";
                    lstWorkUnits.SelectedIndex =
                        AvailableWorkUnits.Instance.IndexOf(
                            CurrentOptions.Instance.WorkUnit);
                }
                catch (Exception error)
                {
                    XtraMessageBox.Show(
                        error.Message,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    Refresh();
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
#if 歌乐
            #region 根据当前选择的产品和工序，确定当前登录操作员能否操作（根据技能矩阵进行判断）
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPMESClient.Instance.usp_PokaYoke_OperatorSkill(
                    IRAPUser.Instance.CommunityID,
                    ((ProcessInfo)lstProcesses.SelectedItem).T102LeafID,
                    ((WorkUnitInfo)lstWorkUnits.SelectedItem).WorkUnitLeaf,
                    1,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format(
                        "({0}){1}", 
                        errCode, 
                        errText), 
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText, 
                        Text, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                XtraMessageBox.Show(
                    string.Format(
                        "在校验操作工技能时，发生异常：{0}", 
                        error.Message),
                    Text, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            #endregion
#endif

            CurrentOptions.Instance.Process = (ProcessInfo)lstProcesses.SelectedItem;
            try
            {
                CurrentOptions.Instance.WorkUnit = (WorkUnitInfo)lstWorkUnits.SelectedItem;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(
                    error.Message,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmSelectOptions_Paint(object sender, PaintEventArgs e)
        {
            btnSelect.Enabled =
                (lstProcesses.SelectedItem != null) &&
                (lstWorkUnits.SelectedItem != null);
        }

        private void lstWorkUnits_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void lstWorkUnits_DoubleClick(object sender, EventArgs e)
        {
            Refresh();
            if (btnSelect.Enabled)
                btnSelect.PerformClick();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            lstProcesses.DataSource = AvailableProcesses.Instance.Processes;
            lstProcesses.DisplayMember = "T120NodeName";
            lstProcesses.SelectedIndex =
                AvailableProcesses.Instance.IndexOf(
                    CurrentOptions.Instance.Process);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                lstProcesses.Items.Clear();

                lstWorkUnits.DataSource = null;
                lstWorkUnits.Items.Clear();

                int errCode = 0;
                string errText = "";
                List<ProcessInfo> processes = new List<ProcessInfo>();
                List<ProductProcessInfo> datas = new List<ProductProcessInfo>();

                IRAPKBClient.Instance.ufn_GetList_GoToProduct(
                    IRAPUser.Instance.CommunityID,
                    edtSearchCondition.Text.Trim(),
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    foreach (ProductProcessInfo data in datas)
                    {
                        foreach (ProcessInfo process in AvailableProcesses.Instance.Processes)
                        {
                            if (process.T102LeafID == data.T102LeafID &&
                                process.T120LeafID == data.T120LeafID)
                            {
                                processes.Add(process);
                                break;
                            }
                        }
                    }

                    lstProcesses.DataSource = processes;
                    lstProcesses.DisplayMember = "T120NodeName";
                    if (processes.Count > 0)
                        lstProcesses.SelectedIndex = 0;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                XtraMessageBox.Show(
                    error.Message,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void edtSearchCondition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnSearch.PerformClick();
        }
    }
}
