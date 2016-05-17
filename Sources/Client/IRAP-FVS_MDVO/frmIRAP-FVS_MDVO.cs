using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Management;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Entity.SSO;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_MDVO
{
    public partial class frmIRAP_FVS_MDVO : DevExpress.XtraEditors.XtraForm
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private string macAddress = "";
        private bool needRefreshed = false;
        private StationLogin stationUser = null;
        private List<WIPStationProductionStatus> workUnits = 
            new List<WIPStationProductionStatus>();
        private List<ucWorkUnit> buttons = new List<ucWorkUnit>();
        private frmShowMDVO formMDVO = null;

        private const int widthButtonSplitter = 10;

        public frmIRAP_FVS_MDVO()
        {
            InitializeComponent();

            string cfgFileName =
                string.Format(
                    @"{0}\IRAP.ini",
                    AppDomain.CurrentDomain.BaseDirectory);
            bool usingVirtualAddr =
                IniFile.ReadBool(
                    "Virtual Station",
                    "Virtual Station Used",
                    false,
                    cfgFileName);
            if (usingVirtualAddr)
            {
                macAddress =
                    IniFile.ReadString(
                        "Virtual Station",
                        "Virtual Station",
                        "",
                        cfgFileName);
            }

            if (macAddress.Trim() == "")
                GetMacAddress();

            BackgroundImage = Properties.Resources.Background;
            BackgroundImageLayout = ImageLayout.Stretch;

            needRefreshed = true;
        }

        #region 自定义函数
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
                    if ((bool)mo["IPEnabled"] == true)
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
        /// Pad 登录
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

        /// <summary>
        /// 获取当前站点的所有工位
        /// </summary>
        /// <returns></returns>
        private List<WIPStationProductionStatus> GetWorkUnits()
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
                List<WIPStationProductionStatus> rlt =
                    new List<WIPStationProductionStatus>();

                IRAPMDMClient.Instance.ufn_GetList_WIPStationProductionStatus(
                    stationUser.CommunityID,
                    stationUser.SysLogID,
                    0,
                    ref rlt,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("{0}.{1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                    return rlt;
                else
                    return null;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GenerateTileButtons(List<WIPStationProductionStatus> workUnits)
        {
            if (buttons.Count == 0)
            {
                int intButtonWidth = 0;
                int intButtonTop = 0;
                int intButtonLeft = 0;

                for (int i = 0; i < workUnits.Count; i++)
                {
                    WIPStationProductionStatus station = workUnits[i].Clone();
                    ucWorkUnit button = new ucWorkUnit();

                    if (intButtonWidth == 0)
                    {
                        intButtonWidth =
                            button.Width *
                            workUnits.Count +
                            widthButtonSplitter *
                            (workUnits.Count - 1);
                        intButtonTop =
                            (xtraScrollableControl.Height - button.Height) / 2;
                        intButtonLeft =
                            (xtraScrollableControl.Width - intButtonWidth) / 2;
                        if (intButtonLeft < 0)
                            intButtonLeft = 0;
                    }

                    button.Top = intButtonTop;
                    button.Left = intButtonLeft + (button.Width + widthButtonSplitter) * i;

                    button.Station = station;
                    button.Parent = xtraScrollableControl;
                    button.MouseLeftClick += new EventHandler(ItemClick);

                    buttons.Add(button);
                }
            }
            else
            {
                for (int i = 0; i < workUnits.Count; i++)
                {
                    if (i >= buttons.Count)
                        break;
                    buttons[i].Station = workUnits[i].Clone();
                }
            }
        }

        private void ItemClick(object sender, EventArgs e)
        {
            if (sender is ucWorkUnit)
            {
                ucWorkUnit workUnit = sender as ucWorkUnit;

                if (workUnit.Station.T102LeafID_InProduction != 0)
                {
                    using (formMDVO=new frmShowMDVO(stationUser))
                    {
                        try
                        {
                            timer.Enabled = false;
                            formMDVO.WindowState = FormWindowState.Maximized;
                            Application.DoEvents();
                            formMDVO.WorkUnit = workUnit.Station.Clone();

                            formMDVO.ShowDialog();
                        }
                        finally
                        {
                            timer_Tick(this, null);
                        }
                    }
                }
            }
        }
        #endregion

        private void frmIRAP_FVS_MDVO_Activated(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            timer.Enabled = false;

            try
            {
                int errCode = 0;
                string errText = "";

                if (stationUser == null || stationUser.SysLogID <= 0)
                {
                    #region 获取当前站点登录信息
                    stationUser = PadLogin(ref errCode, ref errText);
                    if (errCode != 0)
                    {
                        if (!lblErrorMessage.Visible)
                            lblErrorMessage.Visible = true;
                        if (xtraScrollableControl.Visible)
                            xtraScrollableControl.Visible = false;
                        lblErrorMessage.Text = errText;
                        return;
                    }
                    else
                    {
                        if (lblErrorMessage.Visible)
                        {
                            lblErrorMessage.Visible = false;
                            xtraScrollableControl.Visible = true;
                        }
                        lblErrorMessage.Text = "";
                    }
                    #endregion
                }

                if (stationUser != null)
                {
                    if (stationUser.SysLogID > 0)
                    {
                        if (!xtraScrollableControl.Visible)
                            xtraScrollableControl.Visible = true;

                        if (needRefreshed)
                        {
                            btnClose.Visible = false;
                            try
                            {
                                workUnits = GetWorkUnits();
                                if (workUnits != null)
                                {
                                    GenerateTileButtons(workUnits);
                                }
                            }
                            finally
                            {
                                btnClose.Visible = true;
                            }
                        }

                        IRAPKBClient.Instance.mfn_GetInfo_StationNeedRefreshed(
                            stationUser.CommunityID,
                            "MDV",
                            stationUser.HostName,
                            ref needRefreshed,
                            out errCode,
                            out errText);
                    }
                    else
                    {
                        if (!lblErrorMessage.Visible)
                            lblErrorMessage.Visible = true;
                        if (xtraScrollableControl.Visible)
                            xtraScrollableControl.Visible = false;
                        lblErrorMessage.Text = stationUser.ErrText;
                    }
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(
                    error.Message,
                    strProcedureName);

                if (!lblErrorMessage.Visible)
                    lblErrorMessage.Visible = true;
                if (xtraScrollableControl.Visible)
                    xtraScrollableControl.Visible = false;
                lblErrorMessage.Text = error.Message;
            }
            finally
            {
                timer.Interval = 5000;
                timer.Enabled = true;
            }
        }
    }
}