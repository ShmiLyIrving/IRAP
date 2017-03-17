using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;
using IRAP.Entity.SSO;
using IRAP.Entity.FVS;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESRMM
{
    public partial class frmWIShow : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string url = "";
        private bool isShowProductWI = true;
        private bool isShowProductSerialWI = true;
        private bool isShowGeneralWI = true;

        private MenuInfo menuInfo = null;

        private int lastProcessLeaf = 0;
        private int lastWorkUnitLeaf = 0;

        private EventHandler onOptionChanged = null;

        public frmWIShow()
        {
            InitializeComponent();

            tcMain.SelectedTabPage = tpProductWI;
        }

        private void OptionChanged(object sender, EventArgs e)
        {
            frmWIShow_Activated(this, null);
        }

        private void ShowProductWI(int t120LeafID, int workUnitLeafID)
        {
            if (tpProductWI.PageVisible)
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
                    EWIShowPaperInfo data = new EWIShowPaperInfo();

                    IRAPFVSClient.Instance.ufn_EWI_GetInfo_ShowPaper(
                        IRAPUser.Instance.CommunityID,
                        t120LeafID,
                        workUnitLeafID,
                        IRAPUser.Instance.SysLogID,
                        ref data,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode != 0)
                    {
                        IRAPMessageBox.Instance.Show(
                            errText,
                            tpProductWI.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        tpProductWI.Text =
                            string.Format(
                                "{0}_{1}_{2}",
                                data.PartNumber,
                                data.WorkUnit,
                                data.VersionNo);
                        string prdtUrl =
                            string.Format(
                                url,
                                data.PartNumber,
                                data.WorkUnit,
                                data.VersionNo,
                                IRAPUser.Instance.SysLogID);
                        WriteLog.Instance.Write(
                            string.Format("作业指导书显示的地址：[{0}]", prdtUrl),
                            strProcedureName);

                        wbProductWIShow.Navigate(prdtUrl);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                    IRAPMessageBox.Instance.Show(
                        error.Message,
                        tpProductWI.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void ShowProductSerialWI(int t120LeafID, int workUnitLeafID)
        {
            if (tpProductSerialWI.PageVisible)
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
                    EWIPSShowPaperInfo data = new EWIPSShowPaperInfo();

                    IRAPFVSClient.Instance.ufn_EWI_GetInfo_PSShowPaper(
                        IRAPUser.Instance.CommunityID,
                        t120LeafID,
                        workUnitLeafID,
                        IRAPUser.Instance.SysLogID,
                        ref data,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode != 0)
                    {
                        IRAPMessageBox.Instance.Show(
                            errText,
                            tpProductSerialWI.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        tpProductSerialWI.Text =
                            string.Format(
                                "{0}_{1}_{2}",
                                data.ProductSeries,
                                data.WorkUnit,
                                data.VersionNo);
                        string prdtUrl =
                            string.Format(
                                url,
                                data.ProductSeries,
                                data.WorkUnit,
                                data.VersionNo,
                                IRAPUser.Instance.SysLogID);
                        WriteLog.Instance.Write(
                            string.Format("作业指导书显示的地址：[{0}]", prdtUrl),
                            strProcedureName);

                        wbProductSerialWIShow.Navigate(prdtUrl);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                    IRAPMessageBox.Instance.Show(
                        error.Message,
                        tpProductSerialWI.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void ShowGeneralWI(int t120LeafID, int workUnitLeafID)
        {
            if (tpGeneralWI.PageVisible)
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
                    EWIPSShowPaperInfo data = new EWIPSShowPaperInfo();

                    IRAPFVSClient.Instance.ufn_EWI_GetInfo_PSShowPaper(
                        IRAPUser.Instance.CommunityID,
                        t120LeafID,
                        workUnitLeafID,
                        IRAPUser.Instance.SysLogID,
                        ref data,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode != 0)
                    {
                        IRAPMessageBox.Instance.Show(
                            errText,
                            tpGeneralWI.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        tpGeneralWI.Text =
                            string.Format(
                                "{0}_{1}_{2}",
                                data.ProductSeries,
                                data.WorkUnit,
                                data.VersionNo);
                        string prdtUrl =
                            string.Format(
                                url,
                                data.ProductSeries,
                                data.WorkUnit,
                                data.VersionNo,
                                IRAPUser.Instance.SysLogID);
                        WriteLog.Instance.Write(
                            string.Format("作业指导书显示的地址：[{0}]", prdtUrl),
                            strProcedureName);

                        wbGeneralWIShow.Navigate(prdtUrl);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                    IRAPMessageBox.Instance.Show(
                        error.Message,
                        tpGeneralWI.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void frmWIShow_Activated(object sender, EventArgs e)
        {
            Options.Visible = true;

            if (url != "")
                if (CurrentOptions.Instance.OptionOne != null &&
                    CurrentOptions.Instance.OptionTwo != null)
                {
                    if (CurrentOptions.Instance.OptionTwo.T120LeafID != lastProcessLeaf ||
                        CurrentOptions.Instance.OptionOne.T107LeafID != lastWorkUnitLeaf)
                    {
                        lastProcessLeaf = CurrentOptions.Instance.OptionTwo.T120LeafID;
                        lastWorkUnitLeaf = CurrentOptions.Instance.OptionOne.T107LeafID;

                        ShowProductWI(lastProcessLeaf, lastWorkUnitLeaf);
                        ShowProductSerialWI(lastProcessLeaf, lastWorkUnitLeaf);
                        ShowGeneralWI(lastProcessLeaf, lastWorkUnitLeaf);
                    }
                }
        }

        private void frmWIShow_Shown(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            onOptionChanged = new EventHandler(OptionChanged);
            Options.OptionChanged += onOptionChanged;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (this.Tag is MenuInfo)
                {
                    menuInfo = this.Tag as MenuInfo;
                }
                else
                {
                    WriteLog.Instance.Write("没有正确的传入菜单参数", strProcedureName);
                    return;
                }

                try
                {
                    if (menuInfo.Parameters == "")
                    {
                        WriteLog.Instance.Write("菜单参数中没有正确配置呈现作业指导书的参数", strProcedureName);
                    }
                    else
                    {
                        #region 解析菜单参数
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(string.Format("<Root>{0}</Root>", menuInfo.Parameters));

                        foreach (XmlNode node in xml.SelectNodes("Root/Param"))
                        {
                            if (node.Attributes["URL"] != null)
                                url = node.Attributes["URL"].Value;
                            if (node.Attributes["ProductWI"] != null)
                                isShowProductWI = node.Attributes["ProductWI"].Value == "1";
                            if (node.Attributes["ProductSerialWI"] != null)
                                isShowProductSerialWI = node.Attributes["ProductSerialWI"].Value == "1";
                            if (node.Attributes["GeneralWI"] != null)
                                isShowGeneralWI = node.Attributes["GeneralWI"].Value == "1";
                        }
                        #endregion

                        tpProductWI.PageVisible = isShowProductWI;
                        tpProductSerialWI.PageVisible = isShowProductSerialWI;
                        tpGeneralWI.PageVisible = isShowGeneralWI;

                        frmWIShow_Activated(this, null);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmWIShow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Options.OptionChanged -= onOptionChanged;
        }
    }
}
