using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using System.Management;
using System.Diagnostics;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Entity.SSO;
using IRAP.Entity.MDM;
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;
using IRAP.Client.Global.Enums;
using IRAP.AutoUpgrade;

using IRAP_FVS_LSSIVO.UserControls;

namespace IRAP_FVS_LSSIVO
{
    public partial class frmKPIDashboard : DevExpress.XtraEditors.XtraForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        /// <summary>
        /// 当前站点的 MAC 地址
        /// </summary>
        private string macAddress = "";
        /// <summary>
        /// 应用服务器的当前时间
        /// </summary>
        private DateTime serverTime = DateTime.Now;
        /// <summary>
        /// 当前站点的登录信息
        /// </summary>
        private StationLogin stationUser = null;
        /// <summary>
        /// 当前看板显示的指标列表
        /// </summary>
        private List<KPIToMonitor> kpis = new List<KPIToMonitor>();
        /// <summary>
        /// 当前看板的仪表盘列表
        /// </summary>
        private List<ucInstrumentPanel> dashboards = new List<ucInstrumentPanel>();
        /// <summary>
        /// 上次更新指标值时间
        /// </summary>
        private DateTime lastRefreshData = DateTime.Now;
        /// <summary>
        /// 上次程序更新检查时间
        /// </summary>
        private DateTime lastUpgrade = DateTime.Now;

        public frmKPIDashboard()
        {
            InitializeComponent();

            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            #region 读取虚拟的 MAC 地址，用于程序调试
            if (config.AppSettings.Settings["Virtual Station Used"] != null)
            {
                if (config.AppSettings.Settings["Virtual Station Used"].Value.ToUpper() == "TRUE")
                {
                    if (config.AppSettings.Settings["Virtual Station"] != null)
                    {
                        macAddress = config.AppSettings.Settings["Virtual Station"].Value;
                    }
                }
            }
            if (macAddress.Trim() == "")
                GetMacAddress();
            #endregion

            lblCompanyName.Parent = picBackground;
            lblServerTime.Parent = picBackground;
        }


        /// <summary>
        /// 获取当前真实的 MAC 地址
        /// </summary>
        protected virtual void GetMacAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                try
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        macAddress = mo["MacAddress"].ToString();
                        macAddress = macAddress.Replace(":", "");
                        break;
                    }
                }
                catch
                {
                    mo.Dispose();
                }
            }
        }

        /// <summary>
        /// 当前站点登录
        /// </summary>
        private StationLogin PadLogin(
            ref int errCode,
            ref string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                StationLogin stationUser = new StationLogin();

                IRAPUserClient.Instance.sfn_GetInfo_StationLogin(
                    macAddress != "" ? macAddress : "60010MDV1101001",
                    ref stationUser,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                    return stationUser;
                else
                    return null;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void SetTitle()
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

                #region 获取标题中的公司 Logo
                string logoBase64 = "";
                IRAPMDMClient.Instance.sfn_GetImage_CompanyLogo(
                    stationUser.CommunityID,
                    stationUser.SysLogID,
                    ref logoBase64,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                try
                {
                    byte[] imageBytes;
                    imageBytes = Convert.FromBase64String(logoBase64);
                    picLogo.Image = Tools.BytesToImage(imageBytes);
                }
                catch
                {
                    picLogo.Image = null;
                }
                #endregion

                #region 获取标题中的公司名称和当前显示的指标名
                string companyName = "";
                IRAPMDMClient.Instance.sfn_GetCompanyName(
                    stationUser.CommunityID,
                    stationUser.SysLogID,
                    ref companyName,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                IRAPMDMClient.Instance.ufn_GetList_KPIsToMonitor(
                    stationUser.CommunityID,
                    stationUser.SysLogID,
                    ref kpis,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                lblCompanyName.Text = string.Format("{0}关键绩效指标仪表板", companyName);
                if (kpis.Count > 0)
                    lblCompanyName.Text += string.Format("—— {0} Dashboard", kpis[0].KPIName);
                #endregion
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void FillDashboards(ref List<ucInstrumentPanel> panels)
        {
            int pnlEmptyCount = panels.Count % 5;
            if (pnlEmptyCount > 0)
                for (int i = 1; i <= 5 - pnlEmptyCount; i++)
                {
                    panels.Add(
                        new ucInstrumentPanel()
                        {
                            Status = KPIStatus.ksNotProduced,
                            Value = 0,
                        });
                }
        }

        private void ShowOEEDashboard()
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
                List<Dashboard_KPI> datas = new List<Dashboard_KPI>();

                IRAPFVSClient.Instance.ufn_GetDashboard_OEE(
                    stationUser.CommunityID,
                    stationUser.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                Dashboard_KPI_OrderByResourceName compare = new Dashboard_KPI_OrderByResourceName();
                datas.Sort(compare);

                for (int i = 0; i < datas.Count; i++)
                {
                    if (dashboards.Count < i + 1)
                    {
                        dashboards.Add(
                            new ucInstrumentPanel()
                            {
                                Title = datas[i].ResourceName,
                                Status = (KPIStatus)datas[i].KPIStatus,
                                Value = datas[i].CurrentKPIValue,
                            });
                    }
                    else
                    {
                        dashboards[i].Title = datas[i].ResourceName;
                        dashboards[i].Status = (KPIStatus)datas[i].KPIStatus;
                        dashboards[i].Value = datas[i].CurrentKPIValue;
                    }
                }
                for (int i = datas.Count; i < dashboards.Count; i++)
                {
                    dashboards[i].Title = "";
                    dashboards[i].Status = KPIStatus.ksNotProduced;
                    dashboards[i].Value = 0;
                }

                FillDashboards(ref dashboards);

                ResetDashboardPosition(dashboards);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }       
        }

        private void ShowBTSDashboard()
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
                List<Dashboard_KPI> datas = new List<Dashboard_KPI>();

                IRAPFVSClient.Instance.ufn_GetDashboard_BTS(
                    stationUser.CommunityID,
                    stationUser.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                Dashboard_KPI_OrderByResourceName compare = new Dashboard_KPI_OrderByResourceName();
                datas.Sort(compare);

                for (int i = 0; i < datas.Count; i++)
                {
                    if (dashboards.Count < i + 1)
                    {
                        dashboards.Add(
                            new ucInstrumentPanel()
                            {
                                Title = datas[i].ResourceName,
                                Status = (KPIStatus)datas[i].KPIStatus,
                                Value = datas[i].CurrentKPIValue,
                                Formatter = "0.0",
                            });
                    }
                    else
                    {
                        dashboards[i].Title = datas[i].ResourceName;
                        dashboards[i].Status = (KPIStatus)datas[i].KPIStatus;
                        dashboards[i].Value = datas[i].CurrentKPIValue;
                    }
                }
                for (int i = datas.Count; i < dashboards.Count; i++)
                {
                    dashboards[i].Title = "";
                    dashboards[i].Status = KPIStatus.ksNotProduced;
                    dashboards[i].Value = 0;
                }
                //dashboards.Clear();
                //foreach (Dashboard_KPI data in datas)
                //{
                //    ucInstrumentPanel panel = new ucInstrumentPanel();
                //    panel.Title = data.ResourceName;
                //    panel.Status = (KPIStatus)data.KPIStatus;
                //    panel.Value = data.CurrentKPIValue;
                //    panel.Formatter = "0.0";

                //    dashboards.Add(panel);
                //}

                FillDashboards(ref dashboards);

                ResetDashboardPosition(dashboards);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void ShowFTTDashboard()
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
                List<Dashboard_KPI> datas = new List<Dashboard_KPI>();

                IRAPFVSClient.Instance.ufn_GetDashboard_FTT(
                    stationUser.CommunityID,
                    stationUser.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                Dashboard_KPI_OrderByResourceName compare = new Dashboard_KPI_OrderByResourceName();
                datas.Sort(compare);

                for (int i = 0; i < datas.Count; i++)
                {
                    if (dashboards.Count < i + 1)
                    {
                        dashboards.Add(
                            new ucInstrumentPanel()
                            {
                                Title = datas[i].ResourceName,
                                Status = (KPIStatus)datas[i].KPIStatus,
                                Value = datas[i].CurrentKPIValue,
                            });
                    }
                    else
                    {
                        dashboards[i].Title = datas[i].ResourceName;
                        dashboards[i].Status = (KPIStatus)datas[i].KPIStatus;
                        dashboards[i].Value = datas[i].CurrentKPIValue;
                    }
                }
                for (int i = datas.Count; i < dashboards.Count; i++)
                {
                    dashboards[i].Title = "";
                    dashboards[i].Status = KPIStatus.ksNotProduced;
                    dashboards[i].Value = 0;
                }
                //dashboards.Clear();
                //foreach (Dashboard_KPI data in datas)
                //{
                //    ucInstrumentPanel panel = new ucInstrumentPanel();
                //    panel.Title = data.ResourceName;
                //    panel.Status = (KPIStatus)data.KPIStatus;
                //    panel.Value = data.CurrentKPIValue;

                //    dashboards.Add(panel);
                //}

                FillDashboards(ref dashboards);

                ResetDashboardPosition(dashboards);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void ResetDashboardPosition(List<ucInstrumentPanel> panels)
        {
            if (panels.Count > 0)
            {
                int panelLines = panels.Count / 5;
                if (panels.Count % 5 > 0)
                    panelLines++;

                int panelWidth = pnlBody.Width / 5 - 1;
                int panelHeight = pnlBody.Height / panelLines;

                int pnlPosX = 0;
                int pnlPosY = 0;
                for (int i = 0; i < panels.Count; i++)
                {
                    panels[i].Width = panelWidth;
                    panels[i].Height = panelHeight;

                    if (pnlPosX + panels[i].Width >= pnlBody.Width)
                    {
                        pnlPosX = 0;
                        pnlPosY += panels[i].Height;
                    }

                    panels[i].Parent = pnlBody;

                    panels[i].Left = pnlPosX;
                    panels[i].Top = pnlPosY;

                    pnlPosX += panels[i].Width;
                }


            }
        }

        private void smiClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmOEEDashboard_Shown(object sender, EventArgs e)
        {
            if (kpis.Count > 0)
            {
                switch (kpis[0].KPIName.ToUpper())
                {
                    case "OEE":
                        ShowOEEDashboard();
                        break;
                    case "BTS":
                        ShowBTSDashboard();
                        break;
                    case "FTT":
                        ShowFTTDashboard();
                        break;
                }

                lastRefreshData = DateTime.Now;
            }
        }

        private void timerServerTime_Tick(object sender, EventArgs e)
        {
            lblServerTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            TimeSpan span = DateTime.Now - lastRefreshData;
            if (span.TotalMinutes >= 2)
            {
                lastRefreshData = DateTime.Now;

                SetTitle();
                if (kpis.Count > 0)
                {
                    switch (kpis[0].KPIName.ToUpper())
                    {
                        case "OEE":
                            ShowOEEDashboard();
                            break;
                        case "BTS":
                            ShowBTSDashboard();
                            break;
                        case "FTT":
                            ShowFTTDashboard();
                            break;
                    }
                }
            }

            span = DateTime.Now - lastUpgrade;
            if (span.TotalMinutes >= 60)
            {
                string upgradeURL = "";
                if (ConfigurationManager.AppSettings["UpgradeURL"] != null)
                {
                    upgradeURL = ConfigurationManager.AppSettings["UpgradeURL"].Trim();
                }

                if (upgradeURL != "")
                {
                    Upgrade.Instance.URLCFGFileName = upgradeURL;
                    Upgrade.Instance.Silent = true;
                    if (Upgrade.Instance.CanUpgrade)
                    {
                        if (Upgrade.Instance.Do() == -1)
                        {
                            Process.Start(Application.ExecutablePath);
                            return;
                        }
                    }
                    else
                    {
                    }
                }

                lastUpgrade = DateTime.Now;
            }
        }

        private void frmOEEDashboard_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            int errCode = 0;
            string errText = "";

            #region 获取服务器的当前时间，并设置当前的系统时间
            IRAPSystemClient.Instance.sfn_GetServerDateTime(
                ref serverTime,
                out errCode,
                out errText);
            if (errCode == 0)
            {
                SetSystemDateTime.SetSystemTime(serverTime);
            }
            #endregion


            if (stationUser == null || stationUser.SysLogID <= 0)
            {
                #region 获取当前站点的登录信息
                stationUser = PadLogin(ref errCode, ref errText);
                if (errCode != 0)
                {

                    //ShowErrorMessage(errText);
                    return;
                }
                else
                {
                    //HideErrorMessage();
                }
                #endregion
            }

            if (stationUser != null && stationUser.SysLogID != 0)
            {
                SetTitle();
            }
        }

        private void pnlBody_Resize(object sender, EventArgs e)
        {
            ResetDashboardPosition(dashboards);
        }
    }
}