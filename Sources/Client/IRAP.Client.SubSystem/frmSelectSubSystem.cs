using System;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;

namespace IRAP.Client.SubSystem
{
    public partial class frmSelectSubSystem : IRAP.Client.Global.frmCustomBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string message = "";
        private string caption = "";

        public frmSelectSubSystem()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System tip";
            else
                caption = "系统信息";
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
                        lstSubSystems.Items.Add(system.Clone());
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
                IRAPMessageBox.Instance.ShowErrorMessage(
                    error.Message,
                    caption);
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
                        (SystemInfo)lstSubSystems.SelectedValue);

                    try
                    {
                        CurrentStationInfo.Instance.GetStation();
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        IRAPMessageBox.Instance.ShowErrorMessage(
                            error.Message,
                            caption);
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
