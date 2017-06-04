using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using System.Reflection;
using System.Configuration;
using System.Runtime.InteropServices;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Entity.SSO;
using IRAP.Entity.MDM;
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_LSSIVO
{
    public partial class frmFVSCell_Visteon : DevExpress.XtraEditors.XtraForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static object lockObject = new object();

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
        /// 最近一次更新
        /// </summary>
        private DateTime LastUpdatedTime = DateTime.Now;
        /// <summary>
        /// 是否可以退出程序
        /// </summary>
        private bool canClose = false;
        /// <summary>
        /// 上次键盘或者鼠标消息产生的时间
        /// </summary>
        private DateTime lastKBMouseActionTime = DateTime.Now;
        /// <summary>
        /// 主窗体是否显示
        /// </summary>
        private bool isFormShow = true;

        #region 系统钩子
        public struct KeyMSG
        {
            /// <summary>
            /// 键值
            /// </summary>
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int X;
            public int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hWnd;
            public int wHitTestCode;
            public int dwExtendInfo;
        }

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        public static int hKeyobardHook = 0;
        public static int hMouseHook = 0;
        public HookProc KeyboardHookProcedure;

        /// <summary>
        /// 安装钩子
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        /// <summary>
        /// 卸载钩子
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);
        /// <summary>
        /// 继续下一个钩子
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);
        /// <summary>
        /// 取得当前线程编号（线程钩子需要用到）
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        /// <summary>
        /// 安装钩子
        /// </summary>
        private void HookStart()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (hKeyobardHook == 0)
            {
                // 创建 HookProc 实例
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);

                // 设置线程钩子
                hKeyobardHook =
                    SetWindowsHookEx(
                        13,
                        KeyboardHookProcedure,
                        Marshal.GetHINSTANCE(
                            Assembly.GetExecutingAssembly().GetModules()[0]),
                        0);

                // 键盘线程钩子
                //SetWindowsHookEx(2, KeyboardHookProcedure, IntPtr.Zero, GetCurrentThreadId());

                // 键盘全局钩子，需要引用空间 (using System.Reflection;)
                //SetWindowsHookEx(
                //    13,
                //    KeyboardHookProcedure,
                //    Marshal.GetHINSTANCE(
                //        Assembly.GetExecutingAssembly().GetModules()[0]),
                //    0);

                /*
                关于 SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId) 函数
                将钩子加入到钩子链表中，说明一下四个参数：
                idHook 钩子类型，即确定钩子监听何种消息，上面的代码中设定为 2，即监听键盘消息并且是线程钩子，如果是全
                局钩子监听键盘消息应设为 13，线程钩子监听鼠标消息设为 7，全局钩子监听鼠标消息设为 14.
                lpfn 钩子子程的地址指针。如果 dwThreadId 参数为 0 或是一个由别的进程创建的线程的标识， lpfn 必须
                指向 DLL 中的钩子子程。除此之外， lpfn 可以指向当前进程的一段钩子子程代码。钩子函数的入口地址，当钩子
                钩到任何消息后便调用这个函数。
                hInstance 应用程序实例的句柄。标识包含 lpfn 所指的子程的 DLL。如果 threadId 标识当前进程创建的
                一个线程，而且子程代码位于当前进程，hInstance 必须为 NULL。可以很简单的设定其为本应用程序的实例句柄。
                threadId 与安装的钩子子程相关联的线程的标识符。如果为 0，钩子子程与所有的线程关联，即为全局钩子。
                */

                // 如果设置钩子失败
                if (hKeyobardHook == 0)
                {
                    HookStop();
                    WriteLog.Instance.Write("UnhookWindowsHookEx failed.", strProcedureName);
                }
            }

            // 不在设置鼠标系统钩子
            //if (hMouseHook == 0)
            //{
            //    hMouseHook =
            //        SetWindowsHookEx(
            //            14,
            //            new HookProc(MouseHookProc),
            //            Marshal.GetHINSTANCE(
            //                Assembly.GetExecutingAssembly().GetModules()[0]),
            //            0);

            //    if (hMouseHook == 0)
            //    {
            //        HookStop();
            //        WriteLog.Instance.Write("UnhookWindowsHookEx failed.", strProcedureName);
            //    }
            //}
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        private void HookStop()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            bool retKeyboard = true;
            if (hKeyobardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyobardHook);
                hKeyobardHook = 0;
            }
            if (!retKeyboard)
            {
                WriteLog.Instance.Write("UnhookWindowsHookEx failed.", strProcedureName);
            }

            bool retMouse = true;
            if (hMouseHook != 0)
            {
                retMouse = UnhookWindowsHookEx(hMouseHook);
                hMouseHook = 0;
            }
            if (!retMouse)
                WriteLog.Instance.Write("UnhookWindowsHookEx failed.", strProcedureName);
        }


        private int KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                // 线程键盘钩子判断是否按下键
                Keys keyData = (Keys)wParam;
                if (lParam.ToInt32() > 0)
                {
                    // 键盘按下
                }
                if (lParam.ToInt32() < 0)
                {
                    // 键盘抬起
                }

                /*
                wParam==0x100       // 键盘按下
                wParam==0x101       // 键盘抬起
                */

                KeyMSG m = (KeyMSG)Marshal.PtrToStructure(lParam, typeof(KeyMSG));

                #region 在这里添加想要做的事情
                lock (lockObject)
                {
                    lastKBMouseActionTime = DateTime.Now;
                }
                #endregion

                // 如果返回 1，则结束消息，这个消息到此为止，不再传递。如果返回 0 或调用
                // CallNextHookEx 函数，则消息出了这个钩子继续往下传递，也就是传给消息
                // 真正的接受者
                return 0;
            }

            return CallNextHookEx(hKeyobardHook, nCode, wParam, lParam);
        }

        private int MouseHookProc(int nCode, int wParam, IntPtr lParam)
        {
            MouseHookStruct MyMouseHookStruct = 
                (MouseHookStruct)Marshal.PtrToStructure(
                    lParam, 
                    typeof(MouseHookStruct));
            if (nCode < 0)
            {
                return 0;
            }
            else
            {
                #region 在这里添加想要做的事情
                lock(lockObject)
                {
                    lastKBMouseActionTime = DateTime.Now;
                }
                #endregion

                return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
            }
        }
        #endregion

        public frmFVSCell_Visteon()
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

            notifyIcon.Icon = Icon;

            lblLineName.Parent = picLineName;
        }

        private void ShowForm()
        {
            notifyIcon.Visible = false;
            Show();
            isFormShow = true;
        }

        private void HideForm()
        {
            lock (lockObject)
            {
                lastKBMouseActionTime = DateTime.Now;
            }

            notifyIcon.Visible = true;
            Hide();
            isFormShow = false;
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

        /// <summary>
        /// 刷新产线及产品
        /// </summary>
        private void RefreshProductionLineInfo()
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

                if (stationUser == null || stationUser.SysLogID <= 0)
                {
                    #region 获取当前站点的登录信息
                    stationUser = PadLogin(ref errCode, ref errText);
                    if (errCode != 0)
                    {
                        return;
                    }
                    #endregion
                }

                if (stationUser != null && stationUser.SysLogID != 0)
                {
                    ProductionLineInfo line = new ProductionLineInfo();

                    IRAPMDMClient.Instance.ufn_GetInfo_ProductionLine(
                        stationUser.CommunityID,
                        stationUser.SysLogID,
                        ref line,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        lblLineName.Text =
                            string.Format(
                                "[{0}] {1}",
                                line.T134Code,
                                line.T134NodeName);
                    }
                    else
                    {
                        lblLineName.Text = "当前站点未配置产线信息";
                        return;
                    }

                    FVS_LogoImages images = new FVS_LogoImages();
                    IRAPMDMClient.Instance.ufn_GetInfo_LogoImages(
                        stationUser.CommunityID,
                        line.T134LeafID,
                        line.T102LeafID_InProduction,
                        ref images,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0 && images != null)
                    {
                        string pwoNo = "";

                        picCompanyLogo.Image = images.CompanyLogo;
                        picCustomLogo.Image = images.CustomerLogo;
                        picProduction.Image = images.CustomerProduct;

                        switch (stationUser.CommunityID)
                        {
                            case 60026:
                                ucPallet.Visible = true;
                                ucOnePointLessons.Visible = false;
                                break;
                            default:
                                ucPallet.Visible = false;
                                ucOnePointLessons.Visible = true;
                                break;
                        }

                        if (!canClose)
                            // 当前工单执行的瞬时达成率
                            RefreshExecutePWOInfo(line);

                        if (!canClose)
                            // 安灯状态
                            ucAndonStatus.SetSearchCondition(
                                stationUser.CommunityID,
                                line.T134LeafID,
                                stationUser.SysLogID);

                        if (!canClose)
                            // 未关闭工单
                            ucOpenPWOs.SetSearchCondition(
                                stationUser.CommunityID,
                                134,
                                line.T134LeafID,
                                stationUser.SysLogID,
                                ucKPIBTS,
                                ref pwoNo);

                        if (!canClose)
                            // FTT
                            ucFTT.SetSearchCondition(
                                stationUser.CommunityID,
                                pwoNo,
                                stationUser.SysLogID);

                        if (!canClose)
                            // 技能矩阵
                            ucOperatorSkillsMatrix.SetSearchCondition(
                                stationUser.CommunityID,
                                line.T102LeafID_InProduction,
                                line.T134LeafID,
                                "",
                                stationUser.SysLogID);

                        if (!canClose && ucOnePointLessons.Visible)
                            // 一点课
                            ucOnePointLessons.SetSearchCondition(
                                stationUser.CommunityID,
                                line.T102LeafID_InProduction,
                                "",
                                stationUser.SysLogID);

                        if (!canClose && ucPallet.Visible)
                            // 质量问题柏拉图
                            ucPallet.SetSearchCondition(
                                stationUser.CommunityID,
                                line.T102LeafID_InProduction,
                                0,
                                pwoNo,
                                stationUser.SysLogID);

                        if (!canClose)
                            // 未关闭的变更事项
                            ucECNtoLine.SetSearchCondition(
                                stationUser.CommunityID,
                                line.T102LeafID_InProduction,
                                stationUser.SysLogID);
                    }
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void RefreshExecutePWOInfo(ProductionLineInfo line)
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
                LineKPI_BTS pwoBTS = new LineKPI_BTS();

                IRAPFVSClient.Instance.ufn_GetInfo_LineKPI_BTS(
                    stationUser.CommunityID,
                    134,
                    line.T134LeafID,
                    "",
                    stationUser.SysLogID,
                    ref pwoBTS,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                {
                    pwoBTS.BTSStatus = (int)UserControls.TrackBarStyle.tbsNone;
                }

                ucKPIBTS.Minimum = 0;
                ucKPIBTS.Maximum = pwoBTS.PlanQuantity.DoubleValue;
                ucKPIBTS.KPIName = pwoBTS.KPIName;
                ucKPIBTS.KPIValue = Convert.ToDouble(pwoBTS.KPIValue);
                ucKPIBTS.KPIProgress = Convert.ToDouble(pwoBTS.BTSProgress);
                ucKPIBTS.TrackBarStyle = (UserControls.TrackBarStyle)pwoBTS.BTSStatus;
                ucKPIBTS.ActualOutputQuantity = pwoBTS.ActualQuantity.DoubleValue;

                ucKPIBTS.Tag = pwoBTS;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmFVSCell_Visteon_Shown(object sender, EventArgs e)
        {
        }

        private void frmFVSCell_Visteon_Load(object sender, EventArgs e)
        {
            notifyIcon.Text = "IRAP-FVS 线边客户端";

            WindowState = FormWindowState.Maximized;

            //pnlTop.Height = Height / 2;
            //pnlFirstQuadrant.Width = pnlTop.Width / 100 * 48;
            //pnlThirdQuadrant.Width = pnlBotton.Width / 100 * 45;

            splitContainerBody.SplitterPosition = splitContainerBody.Width / 100 * 45;

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

            HookStart();

            RefreshProductionLineInfo();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
            try
            {
                #region 刷新界面上的产线信息
                {
                    TimeSpan span = DateTime.Now - LastUpdatedTime;
                    if (span.TotalMinutes > 2)
                    {
                        LastUpdatedTime = DateTime.Now;

                        RefreshProductionLineInfo();
                    }
                }
                #endregion

                #region 
                if (!isFormShow)
                {
                    TimeSpan span = DateTime.Now - lastKBMouseActionTime;
                    if (span.TotalSeconds >= 60)
                    {
                        ShowForm();
                    }
                }
                #endregion
            }
            finally
            {
                timerRefresh.Enabled = true;
            }
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            HideForm();
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            if (
                IRAPMessageBox.Instance.Show(
                    string.Format(
                        "是否要退出[{0}]？",
                        notifyIcon.Text),
                    "系统信息",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                canClose = true;
                Close();
            }
        }

        private void frmFVSCell_Visteon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClose)
            {
                isFormShow = true;

                HookStop();

                e.Cancel = false;
            }
            else
            {
                HideForm();

                e.Cancel = true;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}