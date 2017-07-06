using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Entity.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.Global.GUI
{
    public partial class frmCustomKanbanBase : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        /// <summary>
        /// 数据刷新出错日志
        /// </summary>
        private List<AppOperationLog> errorLogs = new List<AppOperationLog>();
        /// <summary>
        /// 菜单信息
        /// </summary>
        protected MenuInfo menuInfo = null;
        /// <summary>
        /// 需要切换的下一个功能号信息
        /// </summary>
        protected JumpToFunction nextFunction;
        /// <summary>
        /// 是否需要重新获取下一个切换的功能号信息
        /// </summary>
        private bool needRegetNextFunctionInfo = true;
        /// <summary>
        /// 自动切换其它功能
        /// </summary>
        protected bool autoSwtich;
        protected string t134ClickStream;
        protected string t132ClickStream;

        /// <summary>
        /// 当需要切换下一功能时触发
        /// </summary>
        public event SwitchToNextFunctionHandler OnSwitch;

        public frmCustomKanbanBase()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 主框架菜单
        /// </summary>
        public RibbonControl SystemMenu { get; set; }

        /// <summary>
        /// 系统登录标识
        /// </summary>
        public long SysLogID { get; set; }

        /// <summary>
        /// 菜单缓冲区标识
        /// </summary>
        public int MenuCacheID { get; set; }

        /// <summary>
        /// 产线名称
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 设置最近一次看板数据获取状态图标
        /// </summary>
        public void SetConnectionStatus(bool connected)
        {
            if (connected)
                picConnectionStatus.Image = Properties.Resources.Connected;
            else
                picConnectionStatus.Image = Properties.Resources.Disconnected;
        }

        /// <summary>
        /// 获取下一次需要切换的功能号
        /// </summary>
        public void GetNextSwitchFunction()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (menuInfo != null)
                {
                    int errCode = 0;
                    string errText = "";
                    List<JumpToFunction> functions = new List<JumpToFunction>();

                    IRAPKBClient.Instance.sfn_GetList_JumpToFunctions(
                        IRAPUser.Instance.CommunityID,
                        Math.Abs(menuInfo.ItemID),
                        IRAPUser.Instance.SysLogID,
                        ref functions,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("{0}.{1}", errCode, errText),
                        strProcedureName);
                    if (errCode == 0 && functions.Count >= 1)
                    {
                        if (functions[0].JumpToT3LeafID != 0)
                        {
                            nextFunction = functions[0].Clone();
                            autoSwtich = true;

                            SystemMenu.Visible = false;
                        }
                        else
                        {
                            SystemMenu.Visible = true;
                            autoSwtich = false;
                        }
                    }
                    else
                    {
                        SystemMenu.Visible = true;
                        autoSwtich = false;
                    }
                    SetConnectionStatus(true);
                }
                else
                    SetConnectionStatus(false);

                needRegetNextFunctionInfo = false;
            }
            catch (Exception error)
            {
                SetConnectionStatus(false);
                needRegetNextFunctionInfo = true;
                autoSwtich = false;

                WriteLog.Instance.Write(error.Message, strProcedureName);
                AddLog(new AppOperationLog(DateTime.Now, -1, error.Message));
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);

            }
        }

        /// <summary>
        /// 添加信息，以便显示
        /// </summary>
        /// <param name="message"></param>
        public void AddLog(AppOperationLog message)
        {
            if (errorLogs.Count >= 50)
                errorLogs.RemoveRange(errorLogs.Count - 1, 1);
            errorLogs.Insert(0, message);
        }

        /// <summary>
        /// 跳转到下一个功能
        /// </summary>
        public void JumpToNextFunction()
        {
            if (nextFunction != null && OnSwitch != null)
                OnSwitch(nextFunction.JumpToT3LeafID);
        }

        private void picConnectionStatus_Click(object sender, EventArgs e)
        {
            using (frmShowErrorLogs showErrorLogs = new frmShowErrorLogs(errorLogs))
            {
                showErrorLogs.ShowDialog();
            }
        }

        private void frmCustomKanbanBase_Activated(object sender, EventArgs e)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (Tag is MenuInfo)
                {
                    menuInfo = (MenuInfo) Tag;
                    if (needRegetNextFunctionInfo)
                        GetNextSwitchFunction();
                }

                int errCode = 0;
                string errText = "";

                #region 获取 T132ClickStream
                IRAPFVSClient.Instance.ufn_GetT132ClickStream(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref t132ClickStream,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                #endregion

                #region 获取 T134ClickStream
                IRAPFVSClient.Instance.ufn_GetT134ClickStream(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref t134ClickStream,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmCustomKanbanBase_Shown(object sender, EventArgs e)
        {
            lblFuncName.Text =
                string.Format(
                    "{0}{1}",
                    string.IsNullOrEmpty(LineName) ?
                        "" :
                        string.Format(
                            "{0}-",
                            LineName),
                    lblFuncName.Text);
        }
    }

    /// <summary>
    /// 切换到下一个指定的功能界面
    /// </summary>
    /// <param name="itemID">需要切换的功能标识号</param>
    public delegate void SwitchToNextFunctionHandler(int itemID);
}
