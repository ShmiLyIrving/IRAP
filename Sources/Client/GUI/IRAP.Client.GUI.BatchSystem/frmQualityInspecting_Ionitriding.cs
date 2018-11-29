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
using DevExpress.XtraEditors.Controls;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.BatchSystem
{
    public partial class frmQualityInspecting_Ionitriding : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<WIPStationInfo> stations = new List<WIPStationInfo>();

        public frmQualityInspecting_Ionitriding()
        {
            InitializeComponent();
        }

        private void GetStations(
            int communityID,
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
                List<WIPStation> datas = new List<WIPStation>();

                stations.Clear();
                IRAPMDMClient.Instance.ufn_GetList_WIPStationsOfAHost(
                    communityID,
                    sysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        errText,
                        caption);
                }
                else
                {
                    datas.Sort(
                        new WIPStation_CompareByT133AltCode());

                    foreach (WIPStation data in datas)
                    {
                        stations.Add(WIPStationInfo.Mapper(data));
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmQualityInspecting_Ionitriding_Shown(object sender, EventArgs e)
        {
            ilstDevices.Items.Clear();

            GetStations(
                IRAPUser.Instance.CommunityID,
                IRAPUser.Instance.SysLogID);

            if (stations.Count <= 0)
            {
                XtraTabPage page = new XtraTabPage();
                page.Name = "emptyPage";
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
                    #region 创建设备生产情况页
                    XtraTabPage page = new XtraTabPage();
                    page.Text = station.ToString();
                    page.Name = station.T133Code;

                    UserControls.ucQualityInspecting_Furnace prdt =
                        new UserControls.ucQualityInspecting_Furnace(station);
                    prdt.Dock = DockStyle.Fill;
                    page.Controls.Add(prdt);

                    tcMain.TabPages.Add(page);
                    #endregion

                    #region 创建设备列表项
                    ilstDevices.Items.Add(station, -1);
                    #endregion
                }
            }
        }

        private void ilstDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPageIndex = -1;

            if (ilstDevices.SelectedItem != null &&
                (ilstDevices.SelectedItem as ImageListBoxItem).Value is WIPStationInfo)
            {
                WIPStationInfo station =
                    (ilstDevices.SelectedItem as ImageListBoxItem).Value as WIPStationInfo;

                for (int i = 0; i < tcMain.TabPages.Count; i++)
                {
                    if (tcMain.TabPages[i].Name == station.T133Code)
                    {
                        spccMain.Panel2.Text =
                            $"设备：[{station.WIPStationName}]\t质量检查";

                        selectedPageIndex = i;
                        break;
                    }
                }
            }

            tcMain.SelectedTabPageIndex = selectedPageIndex;
            if (selectedPageIndex < 0)
            {
                spccMain.Panel2.Text = "质量检查";
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

        private void frmQualityInspecting_Ionitriding_Activated(object sender, EventArgs e)
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
