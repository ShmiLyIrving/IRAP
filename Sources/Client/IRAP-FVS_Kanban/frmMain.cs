using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using System.Threading;
using System.IO;

using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;
using IRAP.Client.Global.Resources.Properties;
using IRAP.Client.Global.GUI;
using IRAP.Entity.SSO;
using IRAP.Entity.Kanban;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_Kanban
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int monitorIndex = 0;
        private int sysLogIDIndex = 0;
        private Screen[] sc = Screen.AllScreens;
        private int menuCacheID = 9001;
        private string LineName = "";
        private List<MenuInfo> menuInfos = new List<MenuInfo>();
        /// <summary>
        /// 关闭系统时是否需要询问
        /// </summary>
        private bool isQuitSilent = false;
        /// <summary>
        /// 需要自动切换的功能列表
        /// </summary>
        private List<JumpToFunction> autoCycleFuntions = new List<JumpToFunction>();
        private KanbanScreen _screen = null;

        private string message = "";
        private string caption = "";

        public frmMain()
        {
            InitializeComponent();

            ShowInTaskbar = false;
        }

        public frmMain(int screenIndex, int productIndex) : this()
        {
            monitorIndex = screenIndex;
            sysLogIDIndex = productIndex;
        }

        public frmMain(KanbanScreen screen) : this()
        {
            _screen = screen;
        }

        private void ShowOnMonitor(int showOnMonitor)
        {
            DesktopBounds = _screen.Bounds;
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Maximized;
        }

        private string GetInfo_ProductionLine()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            string lineName = "";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                ProductionLineInfo lineInfo = new ProductionLineInfo();
                IRAPMDMClient.Instance.ufn_GetInfo_ProductionLine(
                    IRAPUser.Instance.CommunityID,
                    _screen.SysLogID,
                    ref lineInfo,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText), 
                    strProcedureName);
                if (errCode == 0)
                {
                    lineName = lineInfo.T134NodeName;
                }
                else
                {
                    lineName = "";
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
            return lineName;
        }

        private RibbonPage GetRibbonPageWithItemID(int itemID)
        {
            foreach (RibbonPage page in ribbonControl.Pages)
            {
                if (((SystemMenuInfoMenuStyle)page.Tag).ItemID == itemID)
                {
                    return page;
                }
            }
            return null;
        }

        private RibbonPageGroup GetRibbonPageGroupWithItemID(int itemID)
        {
            foreach (RibbonPage page in ribbonControl.Pages)
            {
                foreach (RibbonPageGroup group in page.Groups)
                {
                    if (((SystemMenuInfoMenuStyle)group.Tag).ItemID == itemID)
                    {
                        return group;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 通过功能标识号，模拟对象菜单按钮的点击动作
        /// </summary>
        /// <param name="itemID">菜单功能标识号</param>
        private void PerformClickMenuWithItemID(int itemID)
        {
            for (int i = 0; i < ribbonControl.Items.Count; i++)
            {
                if (ribbonControl.Items[i] is BarButtonItem)
                {
                    BarButtonItem menuItem = (BarButtonItem)ribbonControl.Items[i];
                    if (menuItem.Tag is MenuInfo)
                    {
                        MenuInfo menuInfo = menuItem.Tag as MenuInfo;
                        if (Math.Abs(menuInfo.ItemID) == Math.Abs(itemID))
                        {
                            ItemClickEventArgs eAction = new ItemClickEventArgs(menuItem, null);
                            MenuButtonItemClick(ribbonControl, eAction);
                            return;
                        }
                    }
                }
            }
        }

        private void MenuButtonItemClick(object sender, ItemClickEventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            BarButtonItem menuItem = null;
            frmCustomFuncBase childForm = null;
            bool activeMDIChildForm = false;

            if (e.Item is BarButtonItem)
            {
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    menuItem = e.Item as BarButtonItem;

                    #region 记录用户运行功能的动作
                    try
                    {
                        IRAPUser.Instance.RecordRunAFunction(
                            ((MenuInfo)menuItem.Tag).ItemID);
                        activeMDIChildForm = true;
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        IRAPMessageBox.Instance.ShowErrorMessage(
                            error.Message,
                            caption);
                        activeMDIChildForm = false;
                    }
                    #endregion

                    for (int i = 0; i < MdiChildren.Length; i++)
                    {
                        if (MdiChildren[i].Tag == menuItem.Tag)
                        {
                            ((frmCustomFuncBase)MdiChildren[i]).RefreshGUIOptions =
                                IRAPUser.Instance.RefreshGUIOptions;
                            MdiChildren[i].Activate();
                            MdiChildren[i].Focus();
                            return;
                        }
                    }

                    #region 加载类库，并创建 Form 对象
                    string fileBuiltin =
                        ((MenuInfo)menuItem.Tag).FileBuiltin.Replace("IRAP", "");
                    try
                    {
                        string classFileName =
                            string.Format(
                                @"{0}\IRAP.Client.GUI.{1}.dll",
                                Application.StartupPath,
                                fileBuiltin);

                        if (!File.Exists(classFileName))
                        {
                            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                                message = "The class library file [{0}] does not exist!";
                            else
                                message = "类库文件[{0}]不存在！";

                            IRAPMessageBox.Instance.ShowErrorMessage(
                                string.Format(
                                    message,
                                    classFileName),
                                caption);
                            return;
                        }

                        Assembly asm = Assembly.LoadFile(classFileName);
                        if (asm == null)
                        {
                            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                                message = "Unable to load class library file [{0}]";
                            else
                                message = "无法加载类库文件[{0}]";

                            IRAPMessageBox.Instance.ShowErrorMessage(
                                string.Format(
                                    message,
                                    classFileName),
                                caption);
                            return;
                        }

                        string formName = ((MenuInfo)menuItem.Tag).FormName.Replace("_30", "");
                        object obj = Activator.CreateInstance(
                            asm.GetType(
                                string.Format(
                                    "IRAP.Client.GUI.{0}.{1}",
                                    fileBuiltin,
                                    formName)));
                        childForm = (frmCustomFuncBase)obj;
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                            message = "[{0}(IRAP.Client.GUI.{1}.{2})] is under construction...";
                        else
                            message = "[{0}(IRAP.Client.GUI.{1}.{2})]目前正在建设中......";
                        message =
                            string.Format(
                                message,
                                ((MenuInfo)menuItem.Tag).ItemText,
                                fileBuiltin,
                                ((MenuInfo)menuItem.Tag).FormName);

                        WriteLog.Instance.Write(message, strProcedureName);
                        IRAPMessageBox.Instance.ShowErrorMessage(message, caption);
                    }
                    #endregion

                    #region 显示新创建的功能窗体
                    if (childForm != null)
                    {
                        childForm.Text = ((MenuInfo)menuItem.Tag).ItemText;
                        childForm.MdiParent = this;
                        childForm.Tag = menuItem.Tag;
                        childForm.RefreshGUIOptions = IRAPUser.Instance.RefreshGUIOptions;

                        if (childForm is frmCustomKanbanBase)
                        {
                            ((frmCustomKanbanBase)childForm).OnSwitch +=
                                new SwitchToNextFunctionHandler(PerformClickMenuWithItemID);
                            ((frmCustomKanbanBase)childForm).SystemMenu = ribbonControl;
                            ((frmCustomKanbanBase)childForm).SysLogID = _screen.SysLogID;
                            ((frmCustomKanbanBase)childForm).LineName = LineName;
                            ((frmCustomKanbanBase)childForm).MenuCacheID = menuCacheID;
                        }

                        try
                        {
                            childForm.Show();
                            childForm.Activate();
                            childForm.Enabled = activeMDIChildForm;
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(error.Message, strProcedureName);
                            WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                            IRAPMessageBox.Instance.ShowErrorMessage(
                                error.Message,
                                caption);
                        }
                    }
                    #endregion
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private BarButtonItem GenerateRibbonMenuButton(MenuInfo menuInfo)
        {
            BarButtonItem menuItem = new BarButtonItem()
            {
                Caption =
                    menuInfo.HotKey.Trim() == "" ?
                        menuInfo.ItemText :
                        string.Format(
                            "{0}(&{1})",
                            menuInfo.ItemText,
                            menuInfo.HotKey),
                Tag = menuInfo,
                PaintStyle = BarItemPaintStyle.CaptionGlyph,
                Hint = menuInfo.MicroHelp,
            };

            object pic = Resources.ResourceManager.GetObject(menuInfo.ToolBarIconFile);
            if (pic == null)
            {
                pic = Resources.ResourceManager.GetObject("DefaultMenuImage");
            }
            menuItem.Glyph = pic as Bitmap;
            menuItem.LargeGlyph = pic as Bitmap;

            menuItem.ItemClick += MenuButtonItemClick;

            return menuItem;
        }

        private void GenearateRibbonMenu(long menuCacheID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 从数据库中获取菜单项
                menuInfos.Clear();

                int errCode = 0;
                string errText = "";

                try
                {
                    IRAPSystemClient.Instance.sfn_AvailableCSFunctions(
                        IRAPUser.Instance.CommunityID,
                        CurrentSubSystem.Instance.SysInfo.SystemID,
                        menuCacheID,
                        9,
                        true,
                        ref menuInfos,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode != 0)
                    {
                        throw new Exception(errText);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    throw error;
                }
                #endregion

                if (menuInfos.Count <= 0)
                {
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        message = "User [{0}] do not have the function to use in [{1}], " +
                            "please contact the system to support the maintenance personnel " +
                            "to solve!";
                    else
                        message = "{0}用户在[{1}]中没有可以使用的功能，请联系系统支持维护人员解决！";

                    WriteLog.Instance.Write(message, strProcedureName);
                    throw new Exception(
                        string.Format(
                            message,
                            IRAPUser.Instance.UserName,
                            CurrentSubSystem.Instance.SysInfo.SystemName));
                }
                else
                {
                    #region 生成 Ribbon 菜单
                    RibbonPage ribbonPage = new RibbonPage()
                    {
                        Text = CurrentSubSystem.Instance.SysInfo.SystemName,
                    };
                    ribbonControl.Pages.Add(ribbonPage);

                    RibbonPageGroup group = null;
                    for (int i = 0; i < menuInfos.Count; i++)
                    {
                        SystemMenuInfoButtonStyle buttonInfo =
                            (SystemMenuInfoButtonStyle)menuInfos[i];
                        if (buttonInfo.ItemID < 0)
                        {
                            if ((buttonInfo.ToolBarNewSpace) ||
                                (group == null))
                            {
                                group = new RibbonPageGroup();
                                ribbonPage.Groups.Add(group);
                            }
                            group.ItemLinks.Add(GenerateRibbonMenuButton(buttonInfo));
                        }
                    }
                    #endregion
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            ShowOnMonitor(_screen.ScreenIndex);

            int communityID = 60010;
            if (ConfigurationManager.AppSettings["CommunityID"] != null)
                int.TryParse(
                    ConfigurationManager.AppSettings["CommunityID"].ToString(),
                    out communityID);
            IRAPUser.Instance.CommunityID = communityID;

            int systemID = 5169;
            if (ConfigurationManager.AppSettings["SystemID"] != null)
                int.TryParse(
                    ConfigurationManager.AppSettings["SystemID"].ToString(),
                    out systemID);
            CurrentSubSystem.Instance.SysInfo.SystemID = systemID;

            menuCacheID = Convert.ToInt32(_screen.SysLogID);
            IRAPUser.Instance.SysLogID = _screen.SysLogID;

            CurrentSubSystem.Instance.SysInfo.SystemName = "IRAP-FVS KANBAN";
            Text = CurrentSubSystem.Instance.SysInfo.SystemName;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                LineName = GetInfo_ProductionLine();
                #region 生成动态菜单
                // 动态创建 Ribbon 式的菜单
                WriteLog.Instance.Write(
                    string.Format(
                        "根据 MenuCacheID = {0} 的结果生成菜单",
                        menuCacheID),
                    strProcedureName);
                try
                {
                    GenearateRibbonMenu(menuCacheID);
                    WriteLog.Instance.Write("动态菜单生成完毕", strProcedureName);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    MessageBox.Show(
                        string.Format("{0}\n\n点击“确定”按钮后退出。", error.Message),
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isQuitSilent = true;
                    Application.Exit();
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
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
                int defaultFunctionID = 0;

                #region 获取当前子系统自动运行的功能标识号
                IRAPSystemClient.Instance.sfn_DefaultFunctionToRun(
                    IRAPUser.Instance.CommunityID,
                    CurrentSubSystem.Instance.SysInfo.SystemID,
                    _screen.SysLogID,
                    ref defaultFunctionID,
                    out errCode,
                    out errText);
                #endregion

                if (defaultFunctionID == 0)
                {
                    return;
                }
                else
                {
                    // 自动运行配置的功能
                    PerformClickMenuWithItemID(defaultFunctionID);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                MessageBox.Show(
                    error.Message, 
                    "系统信息", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}