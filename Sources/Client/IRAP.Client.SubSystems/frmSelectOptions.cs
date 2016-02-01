using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;

namespace IRAP.Client.SubSystems
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
                MessageBox.Show(
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

        private void lstProcesses_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
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
                    MessageBox.Show(
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
            throw new NotImplementedException();
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
    }
}
