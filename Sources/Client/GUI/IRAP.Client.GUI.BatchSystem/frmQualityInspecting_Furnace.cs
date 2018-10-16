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
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.BatchSystem
{
    public partial class frmQualityInspecting_Furnace : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<WIPStation> stations = new List<WIPStation>();

        public frmQualityInspecting_Furnace()
        {
            InitializeComponent();
        }

        private void GetStations()
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
                    IRAPUser.Instance.CommunityID,
                    -373355,
                    IRAPUser.Instance.SysLogID,
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

        private void frmQualityInspecting_Furnace_Shown(object sender, EventArgs e)
        {
            GetStations();

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
                stations.Sort(new WIPStation_CompareByT133AltCode());
                foreach (WIPStation station in stations)
                {
                    XtraTabPage page = new XtraTabPage();
                    page.Text = station.ToString();

                    UserControls.ucQualityInspecting_Furnace inspect =
                        new UserControls.ucQualityInspecting_Furnace(station);
                    inspect.Dock = DockStyle.Fill;

                    page.Controls.Add(inspect);

                    tcMain.TabPages.Add(page);

                    inspect.ClearAll();
                }
            }
        }

        private void tcMain_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            foreach (Control ctrl in e.Page.Controls)
            {
                if (ctrl is UserControls.ucQualityInspecting_Furnace)
                {
                    ctrl.Focus();
                }
            }
        }

        private void frmQualityInspecting_Furnace_Activated(object sender, EventArgs e)
        {
            if (tcMain.SelectedTabPage != null)
            {
                tcMain_SelectedPageChanged(
                    tcMain, 
                    new TabPageChangedEventArgs(
                        tcMain.SelectedTabPage,
                        tcMain.SelectedTabPage));

            }
        }
    }
}
