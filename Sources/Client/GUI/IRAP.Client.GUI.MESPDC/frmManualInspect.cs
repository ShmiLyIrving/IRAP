using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;
using IRAP.Entities.MDM;
using IRAP.Entities.MES;
using IRAP.Entity.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmManualInspect : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<FailureMode> failureModes = new List<FailureMode>();
        private List<SymbolInspecting> symbols = new List<SymbolInspecting>();
        private List<SymbolInspecting> symbolsWithSubWIP = new List<SymbolInspecting>();
        private List<LeafSetEx> t183Items = new List<LeafSetEx>();
        private List<LeafSetEx> t184Items = new List<LeafSetEx>();
        private List<MFGOperation> t216Items = new List<MFGOperation>();

        private Inspecting wip = new Inspecting();
        private int currentProductLeaf = 0;
        private int currentWorkUnitLeaf = 0;

        public frmManualInspect()
        {
            InitializeComponent();
        }

        #region 自定义函数
        /// <summary>
        /// 根据产品和工位获取失效模式
        /// </summary>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        private void GetFailureModes(int productLeaf, int workUnitLeaf)
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

                IRAPMDMClient.Instance.ufn_GetList_FailureModes(
                    IRAPUser.Instance.CommunityID,
                    productLeaf,
                    workUnitLeaf,
                    IRAPUser.Instance.SysLogID,
                    ref failureModes,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据产品和工位获取部件位置清单
        /// </summary>
        /// <param name="productLeaf">产品叶标识</param>
        /// <param name="workUnitLeaf">工位叶标识</param>
        private void GetInspectingSymbols(int productLeaf, int workUnitLeaf)
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

                IRAPMDMClient.Instance.ufn_GetList_Symbols_Inspecting(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    productLeaf,
                    workUnitLeaf,
                    ref symbols,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}).{1}", errCode, errText),
                    strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据生产任务种类叶标识筛选出部件位置清单
        /// </summary>
        /// <param name="pwoCategoryLeaf">生产任务种类叶标识</param>
        /// <param name="symbols">当前产品和工位的所有部件位置清单</param>
        private void FilterInspectingSymbols(int pwoCategoryLeaf, List<SymbolInspecting> symbols)
        {
            symbolsWithSubWIP.Clear();
            foreach (SymbolInspecting symbol in symbols)
            {
                if (symbol.PWOCategoryLeaf == pwoCategoryLeaf)
                    symbolsWithSubWIP.Add(symbol.Clone());
            }
        }

        /// <summary>
        /// 获取缺陷分类项列表
        /// </summary>
        private void GetT183Items()
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

                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    183,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref t183Items,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取当前产品以及当前工序以前的所有制造工序清单
        /// </summary>
        private void GetT216Items(int productLeaf, int workUnitLeaf, int refUnixTime)
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

                IRAPMDMClient.Instance.ufn_GetList_PrevMFGOperations(
                    IRAPUser.Instance.CommunityID,
                    productLeaf,
                    workUnitLeaf,
                    refUnixTime,
                    IRAPUser.Instance.SysLogID,
                    ref t216Items,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}).{1}", errCode, errText),
                    strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取失效责任想列表
        /// </summary>
        private void GetT184Items()
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

                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    184,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref t184Items,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 框架窗体更新了选项后，本窗体需要处理的工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AfterOptionChanged(object sender, EventArgs e)
        {
            if (Options.SelectProduct != null && Options.SelectStation != null)
                if (currentProductLeaf != Options.SelectProduct.T102LeafID ||
                    currentWorkUnitLeaf != Options.SelectStation.T107LeafID)
                {
                    currentProductLeaf = Options.SelectProduct.T102LeafID;
                    currentWorkUnitLeaf = Options.SelectStation.T107LeafID;

                    GetFailureModes(currentProductLeaf, currentWorkUnitLeaf);
                    GetInspectingSymbols(currentProductLeaf, currentWorkUnitLeaf);
                    #region 调用的参数留待讨论
                    GetT216Items(currentProductLeaf, currentWorkUnitLeaf, 0);
                    #endregion

                    riluFailureMode.DataSource = failureModes;
                    riluT216LeafID.DataSource = t216Items;

                    Clear();

                    edtBarCode.Focus();
                }
        }

        /// <summary>
        /// 恢复人工检查初始状态
        /// </summary>
        private void Clear()
        {
            wip = new Inspecting();

            edtBarCode.Text = "";
            edtRouteCheckInf.Text = "";

            grdvSubWIPCodes.BeginUpdate();
            grdSubWIPCodes.DataSource = null;
            grdvSubWIPCodes.EndUpdate();

            grdvFailureItems.BeginUpdate();
            grdFailureItems.DataSource = null;
            grdvFailureItems.EndUpdate();

            cboCheckResult.SelectedIndex = -1;

            grdFailureItems.UseEmbeddedNavigator = false;
            grdvFailureItems.OptionsBehavior.Editable = false;
            grdvFailureItems.OptionsView.NewItemRowPosition =
                DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            gpcInspectStatus.Enabled = false;

            btnBarCodeConf.Enabled = false;
        }

        /// <summary>
        /// 验证当前输入的人工检查数据能否被保存
        /// </summary>
        /// <returns></returns>
        private bool CanSave()
        {
            if (wip.MainWIPIDCode.BarcodeStatus != 0 ||
                wip.MainWIPIDCode.RoutingStatus != 0)
                return false;

            foreach (SubWIPIDCodeInfo_Inspecting subWIP in wip.SubWIPIDCodes)
            {
                subWIP.GetListFromDataTable();

                switch (subWIP.InspectingStatus)
                {
                    case 0:
                        return false;
                    case 1:
                        break;
                    case 2:
                    case 3:
                        if (subWIP.FailureItems.Count == 0)
                            return false;
                        else
                        {
                            foreach (InspectingFailureItem item in subWIP.FailureItems)
                            {
                                if (item.T110LeafID == 0)
                                    return false;
                                if (item.T183LeafID == 0)
                                    return false;
                                if (item.T118LeafID == 0)
                                    return false;
                            }
                        }
                        break;
                }
            }

            return true;
        }

        /// <summary>
        /// 验证是否有子在制品需要送修
        /// </summary>
        /// <returns></returns>
        private bool IsSendToRepair()
        {
            foreach (SubWIPIDCodeInfo_Inspecting subWIP in wip.SubWIPIDCodes)
            {
                if (subWIP.InspectingStatus == 3)
                    return true;
            }
            return false;
        }

        private void RefreshT110LeafIDWithT101LeafID()
        {
            foreach (SubWIPIDCodeInfo_Inspecting subWIP in wip.SubWIPIDCodes)
            {
                subWIP.GetListFromDataTable();
                foreach (InspectingFailureItem item in subWIP.FailureItems)
                {
                    for (int i = 0; i < symbols.Count; i++)
                    {
                        if (item.T110LeafID == symbols[i].T110LeafID)
                        {
                            item.T101LeafID = symbols[i].ComponentLeafID;
                            break;
                        }
                    }
                }
            }
        }

        private int GetT101LeafIDWithT110LeafID(int t110LeafID)
        {
            foreach (SymbolInspecting symbol in symbols)
            {
                if (symbol.T110LeafID == t110LeafID)
                {
                    return symbol.ComponentLeafID;
                }
            }
            return 0;
        }
        #endregion

        private void frmManualInspect_Load(object sender, EventArgs e)
        {
            switch (IRAPUser.Instance.CommunityID)
            {
                case 60013:
                    grdclmnT118LeafID.Caption = "不良现象";
                    grdclmnT216LeafID.Visible = false;
                    grdclmnT183LeafID.Caption = "责任区分";
                    grdclmnT184LeafID.Caption = "责任部门";
                    break;
            }
        }

        private void frmManualInspect_Shown(object sender, EventArgs e)
        {
            Options.OptionChanged += AfterOptionChanged;

            if (Options.SelectProduct != null)
            {
                currentProductLeaf = Options.SelectProduct.T102LeafID;
                if (Options.SelectStation != null)
                {
                    currentWorkUnitLeaf = Options.SelectStation.T107LeafID;

                    GetFailureModes(currentProductLeaf, currentWorkUnitLeaf);
                    GetInspectingSymbols(currentProductLeaf, currentWorkUnitLeaf);
                    GetT183Items();
                    GetT184Items();
                    #region 调用的参数留待讨论
                    GetT216Items(currentProductLeaf, currentWorkUnitLeaf, 0);               // 此处应该送当前生产工单的创建时间
                    #endregion

                    risluSymbol.DataSource = symbolsWithSubWIP;
                    risluSymbol.DisplayMember = "T110OrComponentCode";
                    risluSymbol.ValueMember = "T110LeafID";
                    risluSymbol.NullText = "";

                    riluT101LeafID.DataSource = symbolsWithSubWIP;
                    riluT101LeafID.DisplayMember = "ComponentCode";
                    riluT101LeafID.ValueMember = "ComponentLeafID";
                    riluT101LeafID.NullText = "";

                    riluFailureMode.DataSource = failureModes;
                    riluFailureMode.DisplayMember = "FailureName";
                    riluFailureMode.ValueMember = "FailureLeaf";
                    riluFailureMode.NullText = "";

                    riluT183LeafID.DataSource = t183Items;
                    riluT183LeafID.DisplayMember = "LeafName";
                    riluT183LeafID.ValueMember = "LeafID";
                    riluT183LeafID.NullText = "";

                    riluT184LeafID.DataSource = t184Items;
                    riluT184LeafID.DisplayMember = "LeafName";
                    riluT184LeafID.ValueMember = "LeafID";
                    riluT184LeafID.NullText = "";

                    riluT216LeafID.DataSource = t216Items;
                    riluT216LeafID.DisplayMember = "T216CodeAndName";
                    riluT216LeafID.ValueMember = "T216LeafID";
                    riluT216LeafID.NullText = "";
                }
            }
        }

        private void frmManualInspect_Activated(object sender, EventArgs e)
        {
            Options.Visible = true;
        }

        private void frmManualInspect_Enter(object sender, EventArgs e)
        {
            if (Options.SelectStation != null)
            {
                edtTransitContainerNo.Text = Options.SelectStation.T107G02;
                edtPalletNo.Text = Options.SelectStation.T107G03;
            }
            else
            {
                edtTransitContainerNo.Text = "";
                edtPalletNo.Text = "";
            }
        }

        private void frmManualInspect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Options.OptionChanged -= AfterOptionChanged;
        }

        private void edtBarCode_Validating(object sender, CancelEventArgs e)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}",
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            if (Options.SelectProduct == null || Options.SelectStation == null)
            {
                WriteLog.Instance.Write("还没有配置产品列表和工位列表", strProcedureName);
                XtraMessageBox.Show(
                    "还没有配置产品列表和工位列表", 
                    "系统信息", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                Clear();

                return;
            }

            if (edtBarCode.Text.Trim() == "")
            {
                edtRouteCheckInf.Text = "";

                Clear();

                return;
            }

            string strBarCode = edtBarCode.Text;
            if (strBarCode == wip.MainWIPIDCode.AltWIPCode)
            {
                return;
            }
            else
            {
                Clear();
            }

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                edtBarCode.Text = strBarCode;

                wip = new Inspecting()
                {
                    ScanTime = DateTime.Now,
                };
                int errCode = 0;
                string errText = "";

                IRAPMESClient.Instance.mfn_GetInfo_WIPIDCode(
                    IRAPUser.Instance.CommunityID,
                    strBarCode,
                    Options.SelectProduct.T102LeafID,
                    Options.SelectStation.T107LeafID,
                    true,
                    IRAPUser.Instance.SysLogID,
                    ref wip,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    if (wip.MainWIPIDCode.BarcodeStatus == 0)
                    {
                        if (wip.MainWIPIDCode.RoutingStatus == 0)
                        {
                            edtRouteCheckInf.Text = wip.MainWIPIDCode.RoutingStatusStr;
                            edtRouteCheckInf.Properties.AppearanceDisabled.ForeColor = Color.Blue;

                            grdSubWIPCodes.DataSource = wip.SubWIPIDCodes;
                            grdvSubWIPCodes.BestFitColumns();

                            if (wip.SubWIPIDCodes.Count > 0)
                            {
                                grdvSubWIPCodes.FocusedRowHandle = 0;
                            }

                            gpcInspectStatus.Enabled = true;
                            e.Cancel = false;
                        }
                        else
                        {
                            edtBarCode.Text = "";

                            edtRouteCheckInf.Text = wip.MainWIPIDCode.RoutingStatusStr;
                            edtRouteCheckInf.Properties.AppearanceDisabled.ForeColor = Color.Red;

                            gpcInspectStatus.Enabled = false;
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        edtBarCode.Text = "";

                        edtRouteCheckInf.Text = wip.MainWIPIDCode.BarcodeStatusStr;
                        edtRouteCheckInf.Properties.AppearanceDisabled.ForeColor = Color.Red;

                        gpcInspectStatus.Enabled = false;
                        e.Cancel = true;
                    }
                }
                else
                {
                    edtBarCode.Text = "";

                    edtRouteCheckInf.Text = errText;
                    edtRouteCheckInf.Properties.AppearanceDisabled.ForeColor = Color.Red;

                    gpcInspectStatus.Enabled = false;
                    e.Cancel = true;
                }
            }
            catch (Exception error)
            {
                edtBarCode.Text = "";

                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                edtRouteCheckInf.Text = error.Message;
                edtRouteCheckInf.Properties.AppearanceDisabled.ForeColor = Color.Red;

                gpcInspectStatus.Enabled = false;
                e.Cancel = true;
            }
            finally
            {
                btnBarCodeConf.Enabled = CanSave();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

            if (btnBarCodeConf.Enabled)
                btnBarCodeConf.Focus();
        }

        private void grdvSubWIPCodes_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int rowIndex = e.FocusedRowHandle;

            if (rowIndex >= 0 && rowIndex < wip.SubWIPIDCodes.Count)
            {
                cboCheckResult.EditValue = wip.SubWIPIDCodes[rowIndex].InspectingStatus;
                FilterInspectingSymbols(
                    wip.SubWIPIDCodes[rowIndex].PWOCategoryLeaf,
                    symbols);
            }
        }

        private void cboCheckResult_SelectedValueChanged(object sender, EventArgs e)
        {
            int intCheckValue = 0;
            int rowIndex = grdvSubWIPCodes.GetFocusedDataSourceRowIndex();

            if (cboCheckResult.EditValue != null)
                intCheckValue = (int)cboCheckResult.EditValue;

            if (rowIndex >= 0 && rowIndex < wip.SubWIPIDCodes.Count)
            {
                wip.SubWIPIDCodes[rowIndex].InspectingStatus = intCheckValue;
            }

            switch (intCheckValue)
            {
                case 2:
                case 3:
                    grdvFailureItems.BeginUpdate();
                    if (rowIndex >= 0 && rowIndex < wip.SubWIPIDCodes.Count)
                        grdFailureItems.DataSource = wip.SubWIPIDCodes[rowIndex].FailureItemsDT;
                    grdvFailureItems.BestFitColumns();
                    grdvFailureItems.EndUpdate();

                    grdvFailureItems.OptionsBehavior.Editable = true;
                    grdvFailureItems.OptionsView.NewItemRowPosition =
                        DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                    grdFailureItems.UseEmbeddedNavigator = true;
                    break;
                default:
                    grdvFailureItems.BeginUpdate();
                    grdFailureItems.DataSource = null;
                    grdvFailureItems.LayoutChanged();
                    grdvFailureItems.EndUpdate();

                    grdvFailureItems.OptionsBehavior.Editable = false;
                    grdvFailureItems.OptionsView.NewItemRowPosition =
                        DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    grdFailureItems.UseEmbeddedNavigator = false;
                    break;
            }

            btnBarCodeConf.Enabled = CanSave();
        }

        private void btnBarCodeConf_Click(object sender, EventArgs e)
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

                RefreshT110LeafIDWithT101LeafID();

                IRAPMESMIClient.Instance.msp_SaveFact_ManualInspecting(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.UserCode,
                    IRAPUser.Instance.Agency.AgencyLeaf,
                    currentProductLeaf,
                    currentWorkUnitLeaf,
                    Options.SelectStation.T107EntityID,
                    Options.SelectProduct.T132LeafID,
                    IsSendToRepair() ? edtPalletNo.Text : edtTransitContainerNo.Text,
                    this.Text,
                    wip,
                    DateTime.Now,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText), 
                    strProcedureName);
                if (errCode == 0)
                {
                    Clear();
                    edtBarCode.Text = "";
                    edtBarCode.Focus();
                    return;
                }
                else
                {
                    XtraMessageBox.Show(
                        errText, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(
                    error.Message, 
                    strProcedureName, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void grdvFailureItems_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvFailureItems.GetDataRow(e.RowHandle);
            dr["T101LeafID"] = 0;
            dr["T110LeafID"] = 0;
            dr["T118LeafID"] = 0;
            dr["T183LeafID"] = 0;
            dr["T216LeafID"] = 0;
            dr["T183LeafID"] = 0;
            dr["T184LeafID"] = 0;
            dr["CntDefect"] = 0;
            grdvFailureItems.LayoutChanged();
        }

        private void grdvFailureItems_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            btnBarCodeConf.Enabled = CanSave();

            grdvFailureItems.BestFitColumns();
        }

        private void grdvFailureItems_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            btnBarCodeConf.Enabled = CanSave();

            grdvFailureItems.BestFitColumns();
        }

        private void grdvFailureItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == grdclmnT110LeafID)
            {
                DataRow dr = grdvFailureItems.GetDataRow(e.RowHandle);

                int t110LeafID = (int)dr["T110LeafID"];
                grdvFailureItems.BeginUpdate();
                dr["T101LeafID"] = GetT101LeafIDWithT110LeafID(t110LeafID);
                grdvFailureItems.EndUpdate();
            }
        }
    }
}
