using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Telerik.WinControls.UI;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.Entity.SSO;

namespace IRAP.Client.SubSystems
{
    public partial class frmSelectSubSystem : IRAP.Client.Global.frmCustomBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public frmSelectSubSystem()
        {
            InitializeComponent();
        }

        private void RefreshButtonStatus()
        {
            btnSelect.Enabled = lstSubSystems.SelectedIndex >= 0;
        }

        private void frmSelectSubSystem_Load(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                AvailableSubSystems.Instance.GetSubSystems(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    IRAPConst.Instance.IRAP_PROGLANGUAGEID);

                lstSubSystems.Items.Clear();
                foreach (SystemInfo system in AvailableSubSystems.Instance.SubSystems)
                {
                    if (system.Accessible)
                        lstSubSystems.Items.Add(
                            new RadListDataItem(system.ToString(), system.Clone()));
                }

                if (lstSubSystems.Items.Count >= 1)
                {
                    lstSubSystems.SelectedIndex = 0;
                    btnSelect.Enabled = true;
                    if (lstSubSystems.Items.Count == 1)
                        btnSelect.PerformClick();
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                MessageBox.Show(
                    error.Message,
                    "选择子系统",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void lstSubSystems_Click(object sender, EventArgs e)
        {
            RefreshButtonStatus();
        }

        private void lstSubSystems_KeyDown(object sender, KeyEventArgs e)
        {
            RefreshButtonStatus();
        }

        private void lstSubSystems_DoubleClick(object sender, EventArgs e)
        {
            if (btnSelect.Enabled)
                btnSelect.PerformClick();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (lstSubSystems.SelectedIndex >= 0)
                {
                    CurrentSubSystem.Instance.SetSystemInfo(
                        (SystemInfo) lstSubSystems.SelectedValue);

                    try
                    {
                        CurrentStationInfo.Instance.GetStation();
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        MessageBox.Show(
                            error.Message,
                            "获取当前站点信息时出错",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
