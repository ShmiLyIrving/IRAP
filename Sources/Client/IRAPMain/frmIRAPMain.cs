using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.Global.GUI;
using IRAP.Client.User;
using IRAP.Client.SubSystems;
using IRAP.Entity.SSO;
using IRAP.WCF.Client.Method;

using IRAP.Client.Global.Resources.Properties;

namespace IRAP
{
    public partial class frmIRAPMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        /// <summary>
        /// 关闭系统时是否需要询问
        /// </summary>
        private bool isQuitSilent = false;
        private List<MenuInfo> menuInfos = new List<MenuInfo>();

        public frmIRAPMain()
        {
            InitializeComponent();
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

        private void GenerateRibbonMenu(int menuCacheID)
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
                        IRAPConst.Instance.IRAP_PROGLANGUAGEID,
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
                    WriteLog.Instance.Write("没有菜单项可供系统生成！", strProcedureName);
                    throw new Exception(
                        string.Format(
                            "{0}用户在[{1}]中没有可以使用的功能，请联系系统支持维护人员解决！",
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

        private void GenerateRibbonMenuWithRibbonStyle(int menuCacheID)
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
                    IRAPSystemClient.Instance.sfn_AvailableCSMenus(
                        IRAPUser.Instance.CommunityID,
                        CurrentSubSystem.Instance.SysInfo.SystemID,
                        menuCacheID,
                        IRAPConst.Instance.IRAP_PROGLANGUAGEID,
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
                    WriteLog.Instance.Write("没有菜单项可供系统生成！", strProcedureName);
                    throw new Exception(
                        string.Format(
                            "{0}用户在[{1}]中没有可以使用的功能，请联系系统支持维护人员解决！",
                            IRAPUser.Instance.UserName,
                            CurrentSubSystem.Instance.SysInfo.SystemName));
                }
                else
                {
                    try
                    {
                        #region 生成 Ribbon 菜单
                        RibbonPage currentPage = null;
                        RibbonPageGroup currentGroup = null;
                        int j = 0;

                        for (int i = 0; i < menuInfos.Count; i++)
                        {
                            SystemMenuInfoMenuStyle menuInfo = 
                                (SystemMenuInfoMenuStyle)menuInfos[i];
                            if (i == 0)
                            {
                                if (menuInfo.NodeDepth == 1)
                                    j = 0;
                                else
                                    j = menuInfo.NodeDepth - 2;
                            }

                            switch (menuInfo.NodeDepth - j)
                            {
                                case 1:
                                    break;
                                case 2:
                                    RibbonPage ribbonPage = new RibbonPage()
                                    {
                                        Text =
                                            menuInfo.HotKey.Trim() == "" ?
                                                menuInfo.ItemText :
                                                string.Format(
                                                    "{0}(&{1})",
                                                    menuInfo.ItemText,
                                                    menuInfo.HotKey),
                                        Tag = menuInfo,
                                    };
                                    ribbonControl.Pages.Add(ribbonPage);

                                    break;
                                case 3:
                                    if (menuInfo.ItemID >= 0)
                                    {
                                        if ((currentPage == null) ||
                                            (((MenuInfo)currentPage.Tag).ItemID != menuInfo.ItemID))
                                            currentPage = GetRibbonPageWithItemID(menuInfo.Parent);

                                        if (currentPage != null)
                                        {
                                            RibbonPageGroup newGroup = new RibbonPageGroup()
                                            {
                                                Text =
                                                    menuInfo.HotKey.Trim() == "" ?
                                                        menuInfo.ItemText :
                                                        string.Format(
                                                            "{0}(&{1})",
                                                            menuInfo.ItemText,
                                                            menuInfo.HotKey),
                                                Tag = menuInfo,
                                            };
                                            currentPage.Groups.Add(newGroup);
                                        }
                                    }
                                    else
                                    {
                                        // 先查找是否存在 ItemID==Parent的组
                                        if ((currentGroup == null) ||
                                            ((MenuInfo)currentGroup.Tag).ItemID != menuInfo.ItemID)
                                            currentGroup = GetRibbonPageGroupWithItemID(menuInfo.Parent);

                                        if (currentGroup == null)
                                        {
                                            currentPage = GetRibbonPageWithItemID(menuInfo.Parent);
                                            if (currentPage != null)
                                            {
                                                currentGroup = new RibbonPageGroup()
                                                {
                                                    Text = "",
                                                    Tag = currentPage.Tag,
                                                };
                                                currentPage.Groups.Add(currentGroup);
                                            }
                                        }

                                        if (currentGroup != null)
                                        {
                                            currentGroup.ItemLinks.Add(GenerateRibbonMenuButton(menuInfo));
                                        }
                                    }

                                    break;
                                case 4:
                                    if ((currentGroup == null) ||
                                        ((SystemMenuInfoMenuStyle)currentGroup.Tag).ItemID != menuInfo.ItemID)
                                        currentGroup = GetRibbonPageGroupWithItemID(menuInfo.ItemID);

                                    if (currentGroup != null)
                                    {
                                        currentGroup.ItemLinks.Add(GenerateRibbonMenuButton(menuInfo));
                                    }

                                    break;
                                default:
                                    WriteLog.Instance.Write("当前系统不支持 4 层以上的菜单结构！", strProcedureName);
                                    MessageBox.Show(
                                        "当前系统不支持 4 层以上的菜单结构！",
                                        "系统信息",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);

                                    break;
                            }
                        }
                        #endregion
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                        throw error;
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
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
                        MessageBox.Show(
                            error.Message,
                            "记录运行功能",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
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
                            MessageBox.Show(
                                string.Format(
                                    "类库文件[{0}]不存在！",
                                    classFileName),
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        Assembly asm = Assembly.LoadFile(classFileName);
                        if (asm == null)
                        {
                            MessageBox.Show(
                                string.Format(
                                    "无法加载类库文件[{0}]",
                                    classFileName),
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        object obj = Activator.CreateInstance(
                            asm.GetType(
                                string.Format(
                                    "IRAP.Client.GUI.{0}.{1}",
                                    fileBuiltin,
                                    ((MenuInfo)menuItem.Tag).FormName)));
                        childForm = (frmCustomFuncBase)obj;
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                        MessageBox.Show(
                            string.Format(
                                "[{0}(IRAP.Client.GUI.{1}.{2})]目前正在建设中......",
                                ((MenuInfo)menuItem.Tag).ItemText,
                                fileBuiltin,
                                ((MenuInfo)menuItem.Tag).FormName),
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    #endregion

                    #region 显示新创建的功能窗体
                    if (childForm != null)
                    {
                        childForm.Text = ((MenuInfo)menuItem.Tag).ItemText;
                        childForm.MdiParent = this;
                        childForm.Tag = menuItem.Tag;
                        childForm.Options = ucOptions;
                        childForm.RefreshGUIOptions = IRAPUser.Instance.RefreshGUIOptions;

                        if (childForm is frmCustomKanbanBase)
                        {
                            ((frmCustomKanbanBase)childForm).OnSwitch +=
                                new SwitchToNextFunctionHandler(PerformClickMenuWithItemID);
                            ((frmCustomKanbanBase)childForm).SystemMenu = ribbonControl;
                            ((frmCustomKanbanBase)childForm).SysLogID = IRAPUser.Instance.SysLogID;
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
                            XtraMessageBox.Show(
                                error.Message,
                                Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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

        private void frmIRAPMain_Load(object sender, EventArgs e)
        {
            if (!CurrentSubSystem.Instance.IsSystemSelected)
            {
                throw new Exception("还没有选择需要使用的子系统!");
            }

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            int menuCacheID = 0;

            WindowState = FormWindowState.Maximized;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                Text = string.Format(
                    "{0}-[登录用户：{1}{2}]-[{3}]-[{4}]",
                    CurrentSubSystem.Instance.SysInfo.SystemName,
                    IRAPUser.Instance.UserName,
                    IRAPUser.Instance.UserCode,
                    IRAPUser.Instance.Agency.AgencyName,
                    IRAPUser.Instance.HostName);

                cmdQuitSubSystem.Caption =
                    string.Format(
                        "退出[{0}]",
                        CurrentSubSystem.Instance.SysInfo.SystemName);

                int errCode = 0;
                string errText = "";

                #region 调用 ssp_OnSelectionASystem
                try
                {
                    IRAPSystemClient.Instance.ssp_OnSelectionASystem(
                        IRAPUser.Instance.CommunityID,
                        CurrentSubSystem.Instance.SysInfo.SystemID,
                        IRAPConst.Instance.IRAP_PROGLANGUAGEID,
                        false,
                        IRAPUser.Instance.SysLogID,
                        ref menuCacheID,
                        out errCode,
                        out errText);
                    if (errCode == 0)
                        WriteLog.Instance.Write(
                            string.Format(
                                "获得 ManuCacheID = {0}",
                                menuCacheID),
                            strProcedureName);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    MessageBox.Show(
                        error.Message,
                        "子系统使用登记失败",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                #endregion

                if (menuCacheID == 0)
                    menuCacheID = 0 - Convert.ToInt32(IRAPUser.Instance.SysLogID);
                else
                    menuCacheID = 0 - menuCacheID;

                #region 生产动态菜单
                switch (CurrentSubSystem.Instance.SysInfo.MenuStyle)
                {
                    case 1:
                        WriteLog.Instance.Write(
                            string.Format(
                                "根据 MenuCacheID={0} 的结果生成菜单",
                                menuCacheID),
                            strProcedureName);
                        try
                        {
                            GenerateRibbonMenuWithRibbonStyle(menuCacheID);
                            WriteLog.Instance.Write("动态菜单生成完毕", strProcedureName);
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(error.Message, strProcedureName);
                            MessageBox.Show(
                                string.Format(
                                    "{0}\n\n点击“确定”退出。",
                                    error.Message),
                                "动态菜单生成",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            isQuitSilent = true;
                            Close();
                        }
                        break;
                    case 5:
                        WriteLog.Instance.Write(
                            string.Format(
                                "根据 MenuCacheID={0} 的结果生成菜单",
                                menuCacheID),
                            strProcedureName);
                        try
                        {
                            GenerateRibbonMenu(menuCacheID);
                            WriteLog.Instance.Write("动态菜单生成完毕", strProcedureName);
                        }
                        catch (Exception error)
                        {
                            WriteLog.Instance.Write(error.Message, strProcedureName);
                            MessageBox.Show(
                                string.Format(
                                    "{0}\n\n点击“确定”退出。",
                                    error.Message),
                                "动态菜单生成",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            isQuitSilent = true;
                            Close();
                        }
                        break;
                    default:
                        errText = string.Format(
                            "系统不支持[{0}]形式的菜单！",
                            CurrentSubSystem.Instance.SysInfo.MenuStyle);
                        WriteLog.Instance.Write(errText, strProcedureName);
                        MessageBox.Show(
                            string.Format(
                                "{0}\n\n点击“确定”按钮后退出就。",
                                errText),
                            "菜单样式错误",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        isQuitSilent = true;
                        Close();
                        break;
                }
                #endregion

                AvailableProcesses.Instance.Options = ucOptions;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmIRAPMain_Shown(object sender, EventArgs e)
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
                    IRAPUser.Instance.SysLogID,
                    ref defaultFunctionID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                #endregion

                if (defaultFunctionID == 0)
                    return;
                else
                    // 自动运行配置的功能
                    PerformClickMenuWithItemID(defaultFunctionID);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmIRAPMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isQuitSilent)
            {
                if (XtraMessageBox.Show(
                    string.Format(
                        "请确定是否要退出[{0}]？",
                        CurrentSubSystem.Instance.SysInfo.SystemName),
                    "退出子系统",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void cmdQuitSubSystem_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            Close();
        }

        private void skinBarItem_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            defaultLookAndFeel.LookAndFeel.SkinName = e.Item.Caption;
            IniFile.WriteString(
                "AppSetting",
                "Skin",
                defaultLookAndFeel.LookAndFeel.SkinName,
                string.Format(
                    @"{0}\IRAP.ini",
                    AppDomain.CurrentDomain.SetupInformation.ApplicationBase));
        }
    }
}