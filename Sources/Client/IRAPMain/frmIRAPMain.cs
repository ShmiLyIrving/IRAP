using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Telerik.WinControls.UI;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.Client.SubSystems;
using IRAP.Client.Global.GUI;
using IRAP.Entity.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP
{
    public partial class frmIRAPMain : Telerik.WinControls.UI.RadRibbonForm
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
                    RibbonTab ribbonPage = new RibbonTab()
                    {
                        Text = CurrentSubSystem.Instance.SysInfo.SystemName,
                    };
                    radRibbonBar.CommandTabs.Add(ribbonPage);

                    RadRibbonBarGroup group = null;
                    for (int i = 0; i < menuInfos.Count; i++)
                    {
                        SystemMenuInfoButtonStyle buttonInfo =
                            (SystemMenuInfoButtonStyle) menuInfos[i];
                        if (buttonInfo.ItemID < 0)
                        {
                            if ((buttonInfo.ToolBarNewSpace) ||
                                (group == null))
                            {
                                group = new RadRibbonBarGroup();
                                ribbonPage.Items.Add(group);
                            }
                            group.Items.Add(GenerateRibbonMenuButton(buttonInfo));
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
                        RibbonTab currentPage = null;
                        RadRibbonBarGroup currentGroup = null;
                        int j = 0;

                        for (int i = 0; i < menuInfos.Count; i++)
                        {
                            SystemMenuInfoMenuStyle menuInfo = (SystemMenuInfoMenuStyle) menuInfos[i];
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
                                    RibbonTab ribbonPage = new RibbonTab()
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
                                    radRibbonBar.CommandTabs.Add(ribbonPage);

                                    break;
                                case 3:
                                    if (menuInfo.ItemID >= 0)
                                    {
                                        if ((currentPage == null) ||
                                            (((MenuInfo) currentPage.Tag).ItemID != menuInfo.ItemID))
                                            currentPage = GetRibbonPageWithItemID(menuInfo.Parent);

                                        if (currentPage != null)
                                        {
                                            RadRibbonBarGroup newGroup = new RadRibbonBarGroup()
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
                                            currentPage.Items.Add(newGroup);
                                        }
                                    }
                                    else
                                    {
                                        // 先查找是否存在 ItemID==Parent的组
                                        if ((currentGroup == null) ||
                                            ((MenuInfo) currentGroup.Tag).ItemID != menuInfo.ItemID)
                                            currentGroup = GetRibbonPageGroupWithItemID(menuInfo.Parent);

                                        if (currentGroup == null)
                                        {
                                            currentPage = GetRibbonPageWithItemID(menuInfo.Parent);
                                            if (currentPage != null)
                                            {
                                                currentGroup = new RadRibbonBarGroup()
                                                {
                                                    Text = "",
                                                    Tag = currentPage.Tag,
                                                };
                                                currentPage.Items.Add(currentGroup);
                                            }
                                        }

                                        if (currentGroup != null)
                                        {
                                            currentGroup.Items.Add(GenerateRibbonMenuButton(menuInfo));
                                        }
                                    }

                                    break;
                                case 4:
                                    if ((currentGroup == null) ||
                                        ((SystemMenuInfoMenuStyle) currentGroup.Tag).ItemID != menuInfo.ItemID)
                                        currentGroup = GetRibbonPageGroupWithItemID(menuInfo.ItemID);

                                    if (currentGroup != null)
                                    {
                                        currentGroup.Items.Add(GenerateRibbonMenuButton(menuInfo));
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

        private RadButtonElement GenerateRibbonMenuButton(MenuInfo menuInfo)
        {
            RadButtonElement menuItem = new RadButtonElement()
            {
                Text =
                    menuInfo.HotKey.Trim() == "" ?
                        menuInfo.ItemText :
                        string.Format(
                            "{0}(&{1})",
                            menuInfo.ItemText,
                            menuInfo.HotKey),
                Tag = menuInfo,
                Image = Properties.Resources.ICON_Report,
                ImageAlignment = ContentAlignment.MiddleCenter,
                ToolTipText = menuInfo.MicroHelp,
            };
            menuItem.TextImageRelation = TextImageRelation.ImageAboveText;
            menuItem.Click += menuButtonItemClick;

            return menuItem;
        }

        private RadRibbonBarGroup GetRibbonPageGroupWithItemID(int itemID)
        {
            for (int i = 0; i < radRibbonBar.CommandTabs.Count; i++)
            {
                RibbonTab page = (RibbonTab) radRibbonBar.CommandTabs[i];
                for (int j = 0; j < page.Items.Count; j++)
                {
                    RadRibbonBarGroup group = (RadRibbonBarGroup) page.Items[j];
                    if (group.Tag != null)
                        if (((MenuInfo) group.Tag).ItemID == itemID)
                            return group;
                }
            }
            return null;
        }

        private RibbonTab GetRibbonPageWithItemID(int itemID)
        {
            for (int i = 0; i < radRibbonBar.CommandTabs.Count; i++)
            {
                RibbonTab page = (RibbonTab) radRibbonBar.CommandTabs[i];
                if (page.Tag != null)
                    if (((MenuInfo) page.Tag).ItemID == itemID)
                        return page;
            }
            return null;
        }

        private void menuButtonItemClick(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            RadButtonElement menuItem = null;
            frmCustomFuncBase childForm = null;
            bool activeMDIChildForm = false;

            if (sender is RadButtonElement)
            {
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    menuItem = sender as RadButtonElement;

                    #region 记录用户运行功能的动作
                    try
                    {
                        IRAPUser.Instance.RecordRunAFunction(
                            ((MenuInfo) menuItem.Tag).ItemID);
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
                            ((frmCustomFuncBase) MdiChildren[i]).RefreshGUIOptions =
                                IRAPUser.Instance.RefreshGUIOptions;
                            MdiChildren[i].Activate();
                            MdiChildren[i].Focus();
                            return;
                        }
                    }

                    #region 加载类库，并创建 Form 对象
                    string fileBuiltin = ((MenuInfo) menuItem.Tag).FileBuiltin.Replace("IRAP", "");
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
                                    ((MenuInfo) menuItem.Tag).FormName)));
                        childForm = (frmCustomFuncBase) obj;
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                        MessageBox.Show(
                            string.Format(
                                "[{0}(IRAP.Client.GUI.{1}.{2})]目前正在建设中......",
                                ((MenuInfo) menuItem.Tag).ItemText,
                                fileBuiltin,
                                ((MenuInfo) menuItem.Tag).FormName),
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    #endregion

                    #region 显示新创建的功能窗体
                    if (childForm != null)
                    {
                        childForm.Text = ((MenuInfo) menuItem.Tag).ItemText;
                        childForm.MdiParent = this;
                        childForm.Tag = menuItem.Tag;
                        childForm.Options = ucOptions;
                        childForm.RefreshGUIOptions = IRAPUser.Instance.RefreshGUIOptions;

                        if (childForm is frmCustomKanbanBase)
                        {
                            ((frmCustomKanbanBase) childForm).OnSwitch +=
                                new SwitchToNextFunctionHandler(PerformClickMenuWithItemID);
                            ((frmCustomKanbanBase) childForm).SystemMenu = radRibbonBar;
                            ((frmCustomKanbanBase) childForm).SysLogID = IRAPUser.Instance.SysLogID;
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
                            MessageBox.Show(
                                error.Message,
                                "系统信息",
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

        private void PerformClickMenuWithItemID(int itemID)
        {
            for (int i = 0; i < radRibbonBar.CommandTabs.Count; i++)
            {
                RibbonTab page = (RibbonTab) radRibbonBar.CommandTabs[i];
                for (int j = 0; j < page.Items.Count; j++)
                {
                    if (page.Items[j] is RadButtonElement)
                    {
                        RadButtonElement menuItem = (RadButtonElement) page.Items[j];
                        if (menuItem.Tag is MenuInfo)
                        {
                            MenuInfo menuInfo = (MenuInfo) menuItem.Tag;
                            if (Math.Abs(menuInfo.ItemID) == Math.Abs(itemID))
                            {
                                menuButtonItemClick(menuItem, new EventArgs());
                                return;
                            }
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

                cmdQuitSubSystem.Text =
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
                if (MessageBox.Show(
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

        private void cmdQuitSubSystem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
