using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraTab;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.BatchSystem
{
    public partial class frmPrdtParamsCollection_CleanTemper : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private MenuInfo menuInfo = null;
        private int t3LeafID = 0;
        private List<WIPStation> stations = new List<WIPStation>();

        public frmPrdtParamsCollection_CleanTemper()
        {
            InitializeComponent();
        }

        private void GetStations(
            int communityID,
            int t3LeafID,
            long sysLogID)
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

                stations.Clear();
                IRAPMDMClient.Instance.ufn_GetList_WIPStationsOfAHostByFunction(
                    communityID,
                    t3LeafID,
                    sysLogID,
                    ref stations,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmPrdtParamsCollection_CleanTemper_Shown(object sender, EventArgs e)
        {
            if (Tag is MenuInfo)
            {
                menuInfo = (MenuInfo)Tag;
                t3LeafID = menuInfo.ItemID;
            }
            else
            {
                t3LeafID = 0;
            }

            GetStations(
                IRAPUser.Instance.CommunityID,
                t3LeafID,
                IRAPUser.Instance.SysLogID);
            if (stations.Count <= 0)
            {
                XtraTabPage page = new XtraTabPage();
                page.TabPageWidth = 0;

                LabelControl label = new LabelControl();
                label.Appearance.Font = new Font("微软雅黑", 18f, FontStyle.Bold);
                label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                label.Appearance.Options.UseFont = true;
                label.Appearance.Options.UseTextOptions = true;
                label.AutoSizeMode = LabelAutoSizeMode.None;
                label.Dock = DockStyle.Fill;
                label.Text = "还没有配置设备！";
                page.Controls.Add(label);

                tcMain.TabPages.Add(page);
            }
            else
            {
                foreach (WIPStation station in stations)
                {
                    XtraTabPage page = new XtraTabPage();
                    page.Text = station.ToString();

                    UserControls.ucCleanTemperPrdtParams prdt = new UserControls.ucCleanTemperPrdtParams(station, t3LeafID);
                    prdt.Dock = DockStyle.Fill;
                    page.Controls.Add(prdt);

                    tcMain.TabPages.Add(page);
                }
            }
        }

        private void tcMain_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            foreach (Control ctrl in e.Page.Controls)
            {
                if (ctrl is UserControls.ucCleanTemperPrdtParams)
                {
                    ctrl.Focus();
                }
            }
        }
    }
}
