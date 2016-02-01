using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.Client.SubSystems;
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

                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        //private RibbonPageGroup GetRibbonPageGroupWithItemID(int itemID)
        //{
        //    throw new System.NotImplementedException();
        //}

        //private RibbonPage GetRibbonPageWithItemID(int itemID)
        //{
        //    throw new System.NotImplementedException();
        //}

        //private void menuButtonItemClick(object sender, ItemClickEventArgs e)
        //{
        //    throw new System.NotImplementedException();
        //}

        private void PerformClickMenuWithItemID(int itemID)
        {
            throw new System.NotImplementedException();
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
    }
}
