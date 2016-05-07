using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;

namespace IRAP.Client.SubSystems
{
    public partial class ucOptions : DevExpress.XtraEditors.XtraUserControl
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        /// <summary>
        /// 选项一、二更改后的事件
        /// </summary>
        public event EventHandler OptionChanged;

        public ucOptions()
        {
            InitializeComponent();
        }

        public ProcessInfo SelectProduct
        {
            get
            {
                if (cboProcesses.SelectedItem != null)
                    return (ProcessInfo)cboProcesses.SelectedItem;
                else
                    return null;
            }
        }

        public WorkUnitInfo SelectWorkUnit
        {
            get
            {
                if (cboWorkUnits.SelectedItem != null)
                    return (WorkUnitInfo)cboWorkUnits.SelectedItem;
                else
                    return null;
            }
        }

        public void RefreshOptions()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 获取当前站点的可用产品/流程列表
                try
                {
                    AvailableProcesses.Instance.GetProcesses(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.SysLogID);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message,
                        "产品/流程选项",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                #endregion

                #region 将获取的产品/流程列表加入下拉列表中
                cboProcesses.Properties.Items.Clear();
                foreach (ProcessInfo process in AvailableProcesses.Instance.Processes)
                    cboProcesses.Properties.Items.Add(process);

                if (cboProcesses.Properties.Items.Count > 0)
                {
                    cboProcesses.SelectedIndex = 0;

                    try
                    {
                        CurrentOptions.Instance.Process =
                            (ProcessInfo)cboProcesses.SelectedItem;

                        cboWorkUnits.Properties.Items.Clear();
                        foreach (WorkUnitInfo workUnit in CurrentOptions.Instance.WorkUnits)
                            cboWorkUnits.Properties.Items.Add(workUnit);
                        cboWorkUnits.SelectedIndex = CurrentOptions.Instance.IndexOfWorkUnit;
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                    }
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void RefreshOptions(int t102LeafID)
        {
            foreach (ProcessInfo process in AvailableProcesses.Instance.Processes)
            {
                if (process.T102LeafID == t102LeafID)
                {
                    CurrentOptions.Instance.Process = process;
                    ResetCurrentOptions();
                }
            }
        }

        private void ResetCurrentOptions()
        {
            cboProcesses.Properties.Items.Clear();
            cboProcesses.Properties.Items.Add(CurrentOptions.Instance.Process);
            cboProcesses.SelectedIndex = 0;

            cboWorkUnits.Properties.Items.Clear();
            foreach (WorkUnitInfo workUnit in CurrentOptions.Instance.WorkUnits)
                cboWorkUnits.Properties.Items.Add(workUnit);
            if (CurrentOptions.Instance.WorkUnit.WorkUnitLeaf != 0)
                cboWorkUnits.SelectedIndex = CurrentOptions.Instance.IndexOfWorkUnit;

            if (OptionChanged != null)
                OptionChanged(this, new EventArgs());
        }

        private void ucOptions_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    if (Visible)
                    {
                        if (AvailableProcesses.Instance.Processes.Count == 0)
                            RefreshOptions();
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            using (frmSelectOptions selectOptions = new frmSelectOptions())
            {
                if (selectOptions.ShowDialog() == DialogResult.OK)
                    ResetCurrentOptions();
            }
        }

        public void ShowSwitchButton(bool boolShowSwtichButton = true)
        {
            btnSwitch.Visible = boolShowSwtichButton;
        }

        private void cboProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProcesses.SelectedIndex >= 0)
                CurrentOptions.Instance.Process = cboProcesses.SelectedItem as ProcessInfo;
            else
                CurrentOptions.Instance.Process = null;
        }

        private void cboWorkUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWorkUnits.SelectedItem == null)
                CurrentOptions.Instance.WorkUnit = null;
            else
                CurrentOptions.Instance.WorkUnit = cboWorkUnits.SelectedItem as WorkUnitInfo;
        }
    }
}
