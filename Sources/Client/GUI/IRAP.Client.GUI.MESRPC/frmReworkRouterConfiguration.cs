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
using IRAP.Client.Global.Enums;
using IRAP.Entities.MES;
using IRAP.Entity.MES;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESRPC
{
    public partial class frmReworkRouterConfiguration : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private OpenReworkPWO pwo = new OpenReworkPWO();
        private EditStatus mode;
        private List<WorkUnit> workUnits = new List<WorkUnit>();
        private List<GUIReworkRouter> routers = new List<GUIReworkRouter>();
        private List<ReworkPWOUnloadingSheetItem> unloadingSheet = new List<ReworkPWOUnloadingSheetItem>();
        private List<CurrentLoadingSheetItem> loadingSheet = new List<CurrentLoadingSheetItem>();
        private Point point = new Point();

        public frmReworkRouterConfiguration()
        {
            InitializeComponent();
        }

        public OpenReworkPWO ReworkPWO
        {
            get { return pwo; }
            set
            {
                pwo = value;
                if (pwo != null)
                {
                    gpcReworkRouter.Text = string.Format("工单[{0}]的返工路由表，产品：[{1}]{2}",
                        pwo.PWONo,
                        pwo.ProductNo,
                        pwo.ProductDesc);
                    gpcUnloadingSheet.Text = string.Format("工单[{0}]的卸料表，产品：[{1}]{2}",
                        pwo.PWONo,
                        pwo.ProductNo,
                        pwo.ProductDesc);
                }
                else
                {
                    gpcReworkRouter.Text = "返工路由表";
                    gpcUnloadingSheet.Text = "返工卸料表";
                }
            }
        }

        public EditStatus Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                switch (mode)
                {
                    case EditStatus.New:
                    case EditStatus.Edit:
                        break;
                    case EditStatus.Browse:
                        splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
                        grdRouters.ContextMenuStrip = null;
                        btnSave.Visible = false;
                        btnCancel.Text = "关闭";
                        break;
                }
            }
        }

        #region 自定义函数
        /// <summary>
        /// 获取当前返工工单所能配置的返工工位清单
        /// </summary>
        private void GetWorkUnitsByProduct()
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                workUnits.Clear();
                if (pwo != null)
                {
                    WriteLog.Instance.Write("根据产品获取工位列表", strProcedureName);
                    try
                    {
                        int errCode = 0;
                        string errText = "";

                        IRAPMDMClient.Instance.ufn_GetList_WorkUnits(
                            IRAPUser.Instance.CommunityID,
                            pwo.T134LeafID,
                            pwo.T102LeafID,
                            IRAPUser.Instance.SysLogID,
                            ref workUnits,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取指定返工工单的返工路由表
        /// </summary>
        private void GetPWOReworkRoutingTBL()
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<ReworkRouter> reworkRoutingTBL = new List<ReworkRouter>();
                if (pwo != null)
                {
                    WriteLog.Instance.Write("获取指定返工工单的返工路由表", strProcedureName);
                    try
                    {
                        int errCode = 0;
                        string errText = "";

                        IRAPMESClient.Instance.ufn_GetReworkRoutingTBL(
                            IRAPUser.Instance.CommunityID,
                            pwo.TF482PK,
                            pwo.PWOIssuingFactID,
                            IRAPUser.Instance.SysLogID,
                            ref reworkRoutingTBL,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                        if (errCode == 0 && reworkRoutingTBL.Count > 0)
                        {
                            foreach (ReworkRouter router in reworkRoutingTBL)
                            {
                                GUIReworkRouter guiRouter = new GUIReworkRouter();
                                guiRouter.Ordinal = router.Ordinal;
                                guiRouter.CurrWorkUnit = GetWorkUnitWithLeafID(router.T107LeafID1);
                                guiRouter.NextWorkUnit = GetWorkUnitWithLeafID(router.T107LeafID2);

                                routers.Add(guiRouter);
                            }
                            ArrangeReworkRouters();
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取指定返工工单的卸料表
        /// </summary>
        private void GetPWOReworkUnloadingSheet()
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (pwo != null)
                {
                    WriteLog.Instance.Write("获取指定返工工单的返工路由表", strProcedureName);
                    try
                    {
                        int errCode = 0;
                        string errText = "";

                        IRAPMESClient.Instance.ufn_GetReworkPWOUnloadingSheet(
                            IRAPUser.Instance.CommunityID,
                            pwo.TF482PK,
                            pwo.PWOIssuingFactID,
                            IRAPUser.Instance.SysLogID,
                            ref unloadingSheet,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                        grdUnloadingSheet.DataSource = unloadingSheet;
                        grdvUnloadingSheet.BestFitColumns();

                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取当前版本工位和产品的装料表
        /// </summary>
        /// <param name="t102LeafID"></param>
        /// <param name="t107LeafID"></param>
        private void GetCurrentLoadingSheet(int t102LeafID, int t107LeafID)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            grdvLoadingSheet.BeginUpdate();
            try
            {
                WriteLog.Instance.Write("获取当前版本工位和产品的装料表", strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";

                    IRAPMDMClient.Instance.ufn_GetLoadingSheet_Current(
                        IRAPUser.Instance.CommunityID,
                        t102LeafID,
                        t107LeafID,
                        IRAPUser.Instance.SysLogID,
                        ref loadingSheet,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    grdLoadingSheet.DataSource = loadingSheet;
                    grdvLoadingSheet.BestFitColumns();
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                }
            }
            finally
            {
                grdvLoadingSheet.EndUpdate();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据工位LeafID获取工位对象
        /// </summary>
        /// <param name="T107LeafID"></param>
        /// <returns></returns>
        private WorkUnit GetWorkUnitWithLeafID(int T107LeafID)
        {
            foreach (WorkUnit workUnit in workUnits)
            {
                if (workUnit.T107LeafID == T107LeafID)
                    return workUnit.Clone();
            }
            return null;
        }

        /// <summary>
        /// 向当前可用工位ListBox中填充工位
        /// </summary>
        private void FillAvailableWorkUnits()
        {
            lstAvailableWorkUnits.Items.Clear();

            foreach (WorkUnit workUnit in workUnits)
            {
                if (workUnit.T116LeafID != 12168)
                    lstAvailableWorkUnits.Items.Add(workUnit);
            }
        }

        private void ArrangeReworkRouters()
        {
            grdvRouters.BeginUpdate();
            try
            {
                if (routers.Count > 0)
                {
                    for (int i = 0; i < routers.Count; i++)
                    {
                        routers[i].Ordinal = i + 1;
                        //routers[i].PrevWorkUnit = routers[i + 1].CurrWorkUnit.Clone();
                    }
                    //routers[routers.Count - 1].Ordinal = routers.Count;
                    //routers[routers.Count - 1].PrevWorkUnit = null;

                    btnSave.Enabled = true;
                }
                else
                    btnSave.Enabled = false;
            }
            finally
            {
                grdvRouters.EndUpdate();
            }
        }

        /// <summary>
        /// 在返工工位下拉列表中查找是否有重复的工位对象
        /// </summary>
        /// <param name="sources">返工工位下拉列表</param>
        /// <param name="workUnit">工位对象</param>
        /// <returns></returns>
        private bool FindWorkUnitInComboBox(ComboBoxEdit sources, WorkUnit workUnit)
        {
            for (int i = 0; i < sources.Properties.Items.Count; i++)
            {
                WorkUnit source = sources.Properties.Items[i] as WorkUnit;
                if (workUnit.T107LeafID == source.T107LeafID)
                    return true;
            }
            return false;
        }
        #endregion

        private void frmReworkRouterConfiguration_Load(object sender, EventArgs e)
        {
            grdRouters.AllowDrop = true;
            grdUnloadingSheet.AllowDrop = true;

            #region 返工路由表
            GetWorkUnitsByProduct();
            FillAvailableWorkUnits();
            GetPWOReworkRoutingTBL();

            grdRouters.DataSource = routers;
            #endregion

            #region 返工卸料表
            GetPWOReworkUnloadingSheet();

            grdUnloadingSheet.DataSource = unloadingSheet;
            #endregion
        }

        private void lstAvailableWorkUnits_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = lstAvailableWorkUnits.IndexFromPoint(new Point(e.X, e.Y));
                if (index >= 0)
                {
                    lstAvailableWorkUnits.SelectedIndex = index;
                    lstAvailableWorkUnits.DoDragDrop(lstAvailableWorkUnits.Items[index],
                        DragDropEffects.Copy);
                }
            }
        }

        private void grdRouters_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(WorkUnit)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void grdRouters_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(WorkUnit)))
            {
                WorkUnit source = (WorkUnit)e.Data.GetData(typeof(WorkUnit));

                // 获取鼠标拖放位置
                point = grdRouters.PointToClient(new Point(e.X, e.Y));
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grdvRouters.CalcHitInfo(point);

                if (hi.RowHandle >= 0 && hi.RowHandle < routers.Count)
                {
                    if (hi.Column == grdclmnCurrWorkUnit)
                    {
                        if (routers[hi.RowHandle].NextWorkUnit.T107LeafID == source.T107LeafID)
                        {
                            XtraMessageBox.Show("当前工位和下一工位不能是相同的工位！",
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            routers[hi.RowHandle].CurrWorkUnit = source.Clone();
                            ArrangeReworkRouters();
                        }
                    }
                    else if (hi.Column == grdclmnPrevWorkUnit)
                    {
                        if (routers[hi.RowHandle].CurrWorkUnit.T107LeafID == source.T107LeafID)
                        {
                            XtraMessageBox.Show("当前工位和下一工位不能是相同的工位！",
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            routers[hi.RowHandle].NextWorkUnit = source.Clone();
                            ArrangeReworkRouters();
                        }
                    }
                }
                else
                {
                    GUIReworkRouter router = new GUIReworkRouter() { CurrWorkUnit = source.Clone() };
                    routers.Add(router);
                    grdvRouters.FocusedRowHandle = routers.Count - 1;
                    ArrangeReworkRouters();
                }
            }
        }

        private void ctxmenuGrid_Opening(object sender, CancelEventArgs e)
        {
            int index = grdvRouters.GetFocusedDataSourceRowIndex();
            if (index >= 0 && index < routers.Count)
            {
                miDelete.Enabled = true;
                miMoveUp.Enabled = index > 0;
                miMoveDown.Enabled = index < routers.Count - 1;
            }
            else
            {
                miMoveUp.Enabled = false;
                miMoveDown.Enabled = false;
                miDelete.Enabled = false;
            }
        }

        private void miMoveUp_Click(object sender, EventArgs e)
        {
            int index = grdvRouters.GetFocusedDataSourceRowIndex();
            if (index >= 0 && index < routers.Count)
            {
                GUIReworkRouter router = routers[index];
                routers.Remove(router);
                routers.Insert(index - 1, router);

                ArrangeReworkRouters();
            }
        }

        private void miMoveDown_Click(object sender, EventArgs e)
        {
            int index = grdvRouters.GetFocusedDataSourceRowIndex();
            if (index >= 0 && index < routers.Count)
            {
                GUIReworkRouter router = routers[index];
                routers.Remove(router);
                routers.Insert(index + 1, router);

                ArrangeReworkRouters();
            }
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            int index = grdvRouters.GetFocusedDataSourceRowIndex();
            if (index >= 0 && index < routers.Count)
            {
                routers.Remove(routers[index]);
                ArrangeReworkRouters();
            }
        }

        private void miClearPrevWorkUnit_Click(object sender, EventArgs e)
        {
            int index = grdvRouters.GetFocusedDataSourceRowIndex();
            if (index >= 0 && index < routers.Count)
            {
                routers[index].NextWorkUnit = null;
                ArrangeReworkRouters();
            }
        }

        private void tcReworkConfiguration_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tpUnloadingSheet)
            {
                cboReworkUnits.Properties.Items.Clear();
                foreach (GUIReworkRouter router in routers)
                {
                    if (router.CurrWorkUnit.T116LeafID == 12158)
                    {
                        if (!(FindWorkUnitInComboBox(cboReworkUnits, router.CurrWorkUnit)))
                        {
                            cboReworkUnits.Properties.Items.Add(router.CurrWorkUnit.Clone());
                        }
                    }
                }

                cboReworkUnits.SelectedItem = null;

                grdvLoadingSheet.BeginUpdate();
                loadingSheet.Clear();
                grdvLoadingSheet.EndUpdate();
            }
        }

        private void cboReworkUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReworkUnits.SelectedItem != null)
            {
                WorkUnit workUnit = cboReworkUnits.SelectedItem as WorkUnit;
                GetCurrentLoadingSheet(pwo.T102LeafID, workUnit.T107LeafID);
            }
        }

        private void grdLoadingSheet_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 获取鼠标拖放位置
                Point point = new Point(e.X, e.Y);
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grdvLoadingSheet.CalcHitInfo(point);

                if (hi.RowHandle >= 0 && hi.RowHandle < loadingSheet.Count)
                {
                    grdvLoadingSheet.FocusedRowHandle = hi.RowHandle;

                    int index = grdvLoadingSheet.GetFocusedDataSourceRowIndex();
                    grdLoadingSheet.DoDragDrop(loadingSheet[index],
                        DragDropEffects.Copy);
                }
            }
        }

        private void grdUnloadingSheet_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CurrentLoadingSheetItem)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void grdUnloadingSheet_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CurrentLoadingSheetItem)))
            {
                CurrentLoadingSheetItem item = e.Data.GetData(typeof(CurrentLoadingSheetItem))
                    as CurrentLoadingSheetItem;
                using (frmReworkUnloadingSheetItem_SymbolSelect form =
                    new frmReworkUnloadingSheetItem_SymbolSelect(item,
                        cboReworkUnits.SelectedItem as WorkUnit,
                        pwo.T102LeafID))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        grdvUnloadingSheet.BeginUpdate();
                        foreach (ReworkPWOUnloadingSheetItem unloadingSheetItem in form.UnloadingSheetItems)
                        {
                            unloadingSheet.Add(unloadingSheetItem.Clone());
                        }
                        grdvUnloadingSheet.BestFitColumns();
                        grdvUnloadingSheet.EndUpdate();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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

                string reworkRoutingXML = "";
                string reworkUnloadingSheetXML = "";

                #region 创建返工路由表XML
                foreach (GUIReworkRouter router in routers)
                {
                    reworkRoutingXML += string.Format("<RF3 Ordinal=\"{0}\" " +
                        "T107LeafID1=\"{1}\" T107LeafID2=\"{2}\" T116LeafID=\"{3}\" />",
                        router.Ordinal,
                        router.CurrWorkUnit.T107LeafID,
                        router.NextWorkUnit.T107LeafID,
                        router.CurrWorkUnit.T116LeafID);
                }
                reworkRoutingXML = string.Format("<RSFact>{0}</RSFact>", reworkRoutingXML);
                #endregion

                #region 返工卸料表XML
                for (int i = 0; i < unloadingSheet.Count; i++)
                {
                    ReworkPWOUnloadingSheetItem item = unloadingSheet[i];
                    reworkUnloadingSheetXML += string.Format("<RF4 Ordinal=\"{0}\" " +
                        "T107LeafID=\"{1}\" T108LeafID=\"{2}\" T110LeafID=\"{3}\" " +
                        "T101LeafID=\"{4}\" T102LeafID=\"{5}\" UnloadQty=\"{6}\" " +
                        "ScrapOnUnloading=\"{7}\" />",
                        i + 1,
                        item.T107LeafID,
                        item.T108LeafID,
                        item.T110LeafID,
                        item.T101LeafID,
                        item.T102LeafID,
                        item.UnloadQty,
                        item.ScrapOnUnloading ? 1 : 0);
                }
                reworkUnloadingSheetXML = string.Format("<RSFact>{0}</RSFact>", reworkUnloadingSheetXML);
                #endregion

                try
                {
                    IRAPMESClient.Instance.usp_SaveRSFacts_ReworkPWO(
                        IRAPUser.Instance.CommunityID,
                        pwo.TF482PK,
                        pwo.PWOIssuingFactID,
                        reworkRoutingXML,
                        reworkUnloadingSheetXML,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    if (errCode == 0)
                    {
                        MessageBox.Show(errText, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show(errText, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    MessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }

    internal class GUIReworkRouter
    {
        private WorkUnit currWorkUnit = new WorkUnit();
        private WorkUnit nextWorkUnit = new WorkUnit();

        public int Ordinal { get; set; }
        public WorkUnit CurrWorkUnit { get; set; }
        public WorkUnit NextWorkUnit { get; set; }

        public GUIReworkRouter Clone()
        {
            return MemberwiseClone() as GUIReworkRouter;
        }
    }
}
