using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.Global.GUI;
using IRAP.Client.User;
using IRAP.Entity.Kanban;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;
using IRAP.Components.WorkFlow;
using IRAP.Client.Global.Resources.Properties;

namespace IRAP.Client.GUI.MDM
{
    public partial class frmProductProcessManager_30 : frmCustomFuncBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private SelectNodeType selectNodeType = SelectNodeType.sntNone;
        /// <summary>
        /// 工序列表
        /// </summary>
        private List<ProcessOperation> operations = new List<ProcessOperation>();
        /// <summary>
        /// 绘制流程图节点列表
        /// </summary>
        private List<BarButtonItem> nodeButtons = new List<BarButtonItem>();
        /// <summary>
        /// 节点属性快捷菜单项列表
        /// </summary>
        private List<BarButtonItem> propMenuItems = new List<BarButtonItem>();
        private List<SubTreeLeaf> prdts = new List<SubTreeLeaf>();
        private List<LeafSetEx> t121Items = new List<LeafSetEx>();
        private List<ProductProcess> prdtProcesses = new List<ProductProcess>();
        /// <summary>
        /// 右键点击的 Item
        /// </summary>
        private IPaintItem itemRightClicked = null;
        /// <summary>
        /// 节点快捷菜单权限组列表
        /// </summary>
        private List<T116PropItemRight> popMenuRights = new List<T116PropItemRight>();
        /// <summary>
        /// 流程图内容是否只读
        /// </summary>
        private bool workFlowReadOnly = false;
        /// <summary>
        /// 鼠标所在的 Item
        /// </summary>
        private IPaintItem itemAtMousePosition = null;
        private Point mouseInposition = new Point(0, 0);

        public frmProductProcessManager_30()
        {
            InitializeComponent();

            bbiMethodStandard.Tag = -354007;
            bbiInspectStandard.Tag = -354008;
            bbiTestStandard.Tag = -354009;
            bbiToolingStandard.Tag = -354010;
            bbiLoadingSheet.Tag = -354011;
            bbiUnloadingSheet.Tag = -354012;
            bbiPackagingStandard.Tag = -354013;
            bbiMFGPrograms.Tag = -373377;
            bbiFailureModes.Tag = -354014;
            bbiOPStandard.Tag = -354015;
            bbiEnvParamStandard.Tag = -373386;
            bbiEnergyStandard.Tag = -373387;
            bbiPrepareStandard.Tag = -373374;
            bbiPokaYokeRules.Tag = -354016;
            bbiMethodDocuments.Tag = -373389;
            bbiSkillMatrix.Tag = -372154;

            // 增加绘制流程图节点列表
            nodeButtons.Add(bbiBegin);
            nodeButtons.Add(bbiProductWithMaterial);
            nodeButtons.Add(bbiNoMaterialProcessing);
            nodeButtons.Add(bbiManualInspection);
            nodeButtons.Add(bbiMachineTesting);
            nodeButtons.Add(bbiTroubleShooting);
            nodeButtons.Add(bbiProductPackaging);
            nodeButtons.Add(bbiProductionOfMaterialAndManualInspection);
            nodeButtons.Add(bbiNoMaterialProcessingAndManualInspection);
            nodeButtons.Add(bbiProductionOfMaterialAndMachineTesting);
            nodeButtons.Add(bbiProductPackagingAndAccessory);
            nodeButtons.Add(bbiVirtualComposite);
            nodeButtons.Add(bbiEnd);
            nodeButtons.Add(bbiLink);

            // 增加节点属性快捷菜单项列表
            propMenuItems.Add(bbiMethodStandard);
            propMenuItems.Add(bbiInspectStandard);
            propMenuItems.Add(bbiTestStandard);
            propMenuItems.Add(bbiToolingStandard);
            propMenuItems.Add(bbiLoadingSheet);
            propMenuItems.Add(bbiUnloadingSheet);
            propMenuItems.Add(bbiPackagingStandard);
            propMenuItems.Add(bbiMFGPrograms);
            propMenuItems.Add(bbiFailureModes);
            propMenuItems.Add(bbiOPStandard);
            propMenuItems.Add(bbiEnvParamStandard);
            propMenuItems.Add(bbiEnergyStandard);
            propMenuItems.Add(bbiPrepareStandard);
            propMenuItems.Add(bbiPokaYokeRules);
            propMenuItems.Add(bbiMethodDocuments);
            propMenuItems.Add(bbiSkillMatrix);
        }

        #region 自定义函数
        private void LoadProcessOperations()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            int errCode = 0;
            string errText = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPMDMClient.Instance.ufn_GetList_ProcessOperations(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref operations,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
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

        private ProcessOperation GetProcessOperation(
            List<ProcessOperation> list,
            int t216LeafID)
        {
            foreach (ProcessOperation op in list)
            {
                if (op.T216Leaf == t216LeafID)
                    return op;
            }
            return null;
        }

        private void SetButtonVisibleWithT116LeafID(int t116LeafID)
        {
            foreach (BarButtonItem button in nodeButtons)
            {
                if (button.Tag != null)
                {
                    if ((int)button.Tag == t116LeafID)
                    {
                        button.Visibility = BarItemVisibility.Always;
                        break;
                    }
                }
            }
        }

        private void BarButtonItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item is BarButtonItem)
            {
                BarButtonItem button = e.Item as BarButtonItem;
                foreach (BarButtonItem but in nodeButtons)
                {
                    if (but != button)
                        but.Down = false;
                }
                if (button.Down)
                {
                    selectNodeType = (SelectNodeType)((int)button.Tag);
                }
                else
                {
                    selectNodeType = SelectNodeType.sntNone;
                }

                // 设置流程图中是否需要画连接线的状态
                productProcessPanel.DrawingLink = bbiLink.Down;
            }
        }

        /// <summary>
        /// 获取产成品或者半成品列表
        /// </summary>
        private void GetProductList(int nodeID, string filterString)
        {
            string strProcedureName = className + ".GetProductList";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                WriteLog.Instance.Write("获取产成品或半成品", strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";

                    IRAPKBClient.Instance.mfn_SubtreeLeaves(
                        IRAPUser.Instance.CommunityID,
                        102,
                        nodeID,
                        filterString,
                        ref prdts,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    if (prdts != null)
                    {
                        SubTreeLeaf_CompareByCode cbc = new SubTreeLeaf_CompareByCode();
                        prdts.Sort(cbc);
                    }
                    grdProducts.DataSource = prdts;

                    grdvProducts.BestFitColumns();
                    grdvProducts.LayoutChanged();
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);

                    grdProducts.DataSource = null;
                    grdvProducts.LayoutChanged();
                }
            }
            finally
            {
                ClearProcessPanel();

                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void ClearProcessPanel()
        {
            lblProductName.Text = "";

            productProcessPanel.Items.Clear();
            productProcessPanel.Refresh();
            pnlWorkFlow.Enabled = false;

            SetEditorMode(false);
        }

        private void SetEditorMode(bool isEdit)
        {
            gpcProductList.Enabled = !isEdit;
            btnSave.Enabled = isEdit;
            btnCancel.Enabled = isEdit;
        }

        /// <summary>
        /// 获取 T121 列表
        /// </summary>
        private void LoadT121Items()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            int errCode = 0;
            string errText = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                t121Items.Clear();
                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    121,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref t121Items,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
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

        private OperationNode FindItemNode(int T216LeafID)
        {
            foreach (IPaintItem item in productProcessPanel.Items)
            {
                if (item is OperationNode)
                {
                    OperationNode node = item as OperationNode;
                    if (node.Tag != null && node.Tag is ProcessOperation)
                    {
                        if ((node.Tag as ProcessOperation).T216Leaf == T216LeafID)
                        {
                            return node;
                        }
                    }
                }
            }

            return null;
        }

        private void NewWorkFlowLine(CustomItemNode from, CustomItemNode to, ProductProcess tag)
        {
            ProcessLine line = new ProcessLine()
            {
                ItemFrom = from,
                ItemTo = to,
                Tag = tag,
            };

            from.NextLinks.Add(line);
            to.PrevLinks.Add(line);
        }

        private void GenerateWorkFlow(List<ProductProcess> datas)
        {
            // 清除流程图节点
            productProcessPanel.Items.Clear();

            int left = 0;
            int top = 100;
            int widthNodeSplit = 150;

            ItemBegin root =
                new ItemBegin(
                    productProcessPanel.BufferGraphics,
                    new Point(left, top));
            productProcessPanel.Root = root;
            productProcessPanel.Items.Add(root);

            ItemEnd end =
                new ItemEnd(
                    productProcessPanel.BufferGraphics,
                    new Point(left, top));
            productProcessPanel.Items.Add(end);

            int X = root.ItemLocate.X + root.ItemImage.Width + widthNodeSplit;
            foreach (ProductProcess process in datas)
            {
                if (process.Reference)
                    productProcessPanel.BackgroundColor = Color.Yellow;
                else
                    productProcessPanel.BackgroundColor = Color.White;

                OperationNode prevNode = FindItemNode(process.T216LeafID1);
                if (prevNode == null)
                {
                    ProcessOperation operation =
                        GetProcessOperation(operations, process.T216LeafID1);

                    prevNode =
                        OperationNodeFactory.CreateInstance(
                            productProcessPanel.BufferGraphics,
                            new Point(X, top),
                            operation);
                    productProcessPanel.Items.Add(prevNode);

                    X = prevNode.FromPoint.X + widthNodeSplit;

                    NewWorkFlowLine(root, prevNode, null);
                }

                if (process.T216LeafID2 == 0)
                {
                    NewWorkFlowLine(prevNode, end, process);
                }
                else
                {
                    OperationNode nextNode = FindItemNode(process.T216LeafID2);
                    if (nextNode == null)
                    {
                        ProcessOperation operation =
                            GetProcessOperation(operations, process.T216LeafID2);

                        nextNode = OperationNodeFactory.CreateInstance(
                            productProcessPanel.BufferGraphics,
                            new Point(X, top),
                            operation);
                        productProcessPanel.Items.Add(nextNode);

                        X = nextNode.FromPoint.X + widthNodeSplit;
                    }

                    NewWorkFlowLine(prevNode, nextNode, process);
                }
            }

            end.ItemLocate = new Point(X, top);

            productProcessPanel.ResetLayout();
            RefreshToolButtonShowStatus(true);
        }

        private void RefreshToolButtonShowStatus(bool enabled)
        {
            bbiBegin.Enabled = enabled && productProcessPanel.Root == null;
            bbiEnd.Enabled = enabled && !EndNodeExists();
        }

        private bool EndNodeExists()
        {
            foreach (IPaintItem item in productProcessPanel.Items)
            {
                if (item is ItemEnd)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 根据 T216LeafID 查找流程图中是否已经存在该工序节点
        /// </summary>
        private bool LeafIDInNodesExists(int t216LeafID)
        {
            foreach (IPaintItem item in productProcessPanel.Items)
            {
                if (item is OperationNode)
                {
                    OperationNode node = item as OperationNode;
                    if (node.Tag != null && node.Tag is ProcessOperation)
                    {
                        if ((node.Tag as ProcessOperation).T216Leaf == t216LeafID)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private BarButtonItem FindBarButtonItem(int menuItemID)
        {
            foreach (BarButtonItem item in propMenuItems)
            {
                if ((int)item.Tag == menuItemID)
                    return item;
            }
            return null;
        }

        private List<MethodMMenu> GetPopMenuRightsWithT116LeafID(int t116Leaf)
        {
            foreach (T116PropItemRight t116Right in popMenuRights)
            {
                if (t116Right.T116LeafID == t116Leaf)
                    return t116Right.Rights;
            }

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
                List<MethodMMenu> datas = new List<MethodMMenu>();

                IRAPMDMClient.Instance.ufn_GetList_MethodMMenu(
                    IRAPUser.Instance.CommunityID,
                    t116Leaf,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                {
                    popMenuRights.Add(
                        new T116PropItemRight()
                        {
                            T116LeafID = t116Leaf,
                            Rights = datas,
                        });
                }
                return datas;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 删除一条流程图节点之间的连接线
        /// </summary>
        /// <param name="line">待删除的连接线</param>
        private void RemoveLine(ProcessLine line)
        {
            line.ItemFrom.NextLinks.Remove(line);
            line.ItemTo.PrevLinks.Remove(line);

            line.ItemFrom = null;
            line.ItemTo = null;

            line = null;

            productProcessPanel.SetNodeLevel();
        }

        private string GenerateRSAttrXML()
        {
            string strProductProcessXML = "";

            int i = 1;
            int dealNumber = 1;
            int level = 1;
            while (dealNumber > 0)
            {
                dealNumber = 0;
                foreach (IPaintItem item in productProcessPanel.Items)
                {
                    if (item is ItemNode)
                    {
                        if ((item as ItemNode).Level == level)
                        {
                            dealNumber++;
                            foreach (ItemLink link in (item as ItemNode).NextLinks)
                            {
                                ProcessLine line = link as ProcessLine;
                                if (line.Tag != null)
                                {
                                    strProductProcessXML = strProductProcessXML +
                                        string.Format(
                                            "<Row RealOrdinal=\"{0}\" T216LeafID1=\"{1}\" " +
                                            "RoutingCondition=\"{2}\" T216LeafID2=\"{3}\" " +
                                            "MinPercent=\"{4}\" MaxPercent=\"{5}\" " +
                                            "ProcessPercentage=\"{6}\" T121LeafID=\"{7}\"/>",
                                            i++,
                                            line.Tag.T216LeafID1,
                                            0,
                                            line.Tag.T216LeafID2,
                                            line.Tag.MinPercent,
                                            line.Tag.MaxPercent,
                                            line.Tag.ProcessPercentage,
                                            line.Tag.T121LeafID);
                                }
                            }
                        }
                    }
                }

                level++;
            }

            return string.Format("<RSAttr>{0}</RSAttr>", strProductProcessXML);
        }
        #endregion

        private void frmProductProcessManager_30_Load(object sender, EventArgs e)
        {
            // 获取可用工序列表，并根据工序类型设置流程图中工序类型按钮的可见性
            LoadProcessOperations();
            foreach (ProcessOperation operation in operations)
            {
                SetButtonVisibleWithT116LeafID(operation.T116Leaf);
            }

            // 获取在制品标识类型列表
            LoadT121Items();

            ClearProcessPanel();
        }

        private void productProcessPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // 隐藏提示信息框
            toolTip.Hide(productProcessPanel);

            Point location =
                new Point(
                    e.X + productProcessPanel.HorizontalScroll.Value,
                    e.Y + productProcessPanel.VerticalScroll.Value);
            itemRightClicked = null;

            #region 鼠标左键点击后的处理代码
            if (e.Button == MouseButtons.Left)
            {
                switch (selectNodeType)
                {
                    case SelectNodeType.sntNone:    // 未选中工具栏中的任何按钮，不进行任何处理
                        break;
                    case SelectNodeType.sntBegin:   // 在流程图中添加一个开始节点
                        if (productProcessPanel.Root == null)
                        {
                            ItemBegin begin =
                                new ItemBegin(
                                    productProcessPanel.BufferGraphics,
                                    new Point(location.X, location.Y));
                            productProcessPanel.Root = begin;
                            productProcessPanel.Items.Add(begin);
                            productProcessPanel.Refresh();
                            SetEditorMode(true);

                            bbiBegin.Enabled = false;
                            bbiBegin.Down = false;
                            selectNodeType = SelectNodeType.sntNone;
                        }
                        else
                        {
                            XtraMessageBox.Show(
                                "流程图中只允许一个 Begin 节点！",
                                Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                        break;
                    case SelectNodeType.sntEnd:     // 在流程图中添加一个结束节点
                        if (!EndNodeExists())
                        {
                            ItemEnd end =
                                new ItemEnd(
                                    productProcessPanel.BufferGraphics,
                                    new Point(location.X, location.Y));
                            productProcessPanel.Items.Add(end);
                            productProcessPanel.Refresh();
                            SetEditorMode(true);

                            bbiEnd.Enabled = false;
                            bbiEnd.Down = false;
                            selectNodeType = SelectNodeType.sntNone;
                        }
                        else
                        {
                            XtraMessageBox.Show(
                                "流程图中只允许一个 End 节点！",
                                Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                        break;
                    case SelectNodeType.sntLink:    // 在工具栏中选中了连接线按钮
                        break;
                    case SelectNodeType.sntMachineTesting:                        // 在工具栏中选中了节点按钮
                    case SelectNodeType.sntManualInspection:
                    case SelectNodeType.sntNoMaterialProcessing:
                    case SelectNodeType.sntNoMaterialProcessingAndManualInspection:
                    case SelectNodeType.sntProductionOfMaterial:
                    case SelectNodeType.sntProductionOfMaterialAndMachineTesting:
                    case SelectNodeType.sntProductionOfMaterialAndManualInspection:
                    case SelectNodeType.sntProductPackaging:
                    case SelectNodeType.sntProductPackagingAndAccessory:
                    case SelectNodeType.sntTroubleShooting:
                    case SelectNodeType.sntVirtualComposite:
                        using (frmSelectOperation selectOperation = new frmSelectOperation())
                        {
                            foreach (ProcessOperation operation in operations)
                            {
                                if (operation.T116Leaf == (int)selectNodeType &&
                                    !LeafIDInNodesExists(operation.T216Leaf))
                                {
                                    selectOperation.cboOperations.Properties.Items.Add(operation.Clone());
                                }
                            }

                            if (selectOperation.ShowDialog() == DialogResult.OK)
                            {
                                if (selectOperation.OperationSelected != null)
                                {
                                    OperationNode node =
                                        OperationNodeFactory.CreateInstance(
                                            productProcessPanel.BufferGraphics,
                                            new Point(
                                                location.X,
                                                location.Y),
                                            selectOperation.OperationSelected.Clone());
                                    productProcessPanel.Items.Add(node);
                                    productProcessPanel.Refresh();

                                    SetEditorMode(true);
                                }
                            }
                        }
                        break;
                    default:        // 其它情况，不进行任何处理
                        break;
                }
            }
            #endregion
            else
            #region 鼠标右键点击后的处理代码
            if (e.Button == MouseButtons.Right)
            {
                #region 在节点上点击鼠标右键后的处理
                IPaintItem item = productProcessPanel.GetItemAtPoint(location);
                if (item != null)
                {
                    if (item is ItemBegin || item is ItemEnd)
                    {
                        ppmBlank.ShowPopup(productProcessPanel.PointToScreen(e.Location));
                        return;
                    }
                    else
                    {
                        if (item is OperationNode && (item as OperationNode).Tag is ProcessOperation)
                        {
                            itemRightClicked = item;

                            // 显示右键菜单
                            ProcessOperation op = (item as OperationNode).Tag as ProcessOperation;
                            List<MethodMMenu> rights = GetPopMenuRightsWithT116LeafID(op.T116Leaf);
                            foreach (BarButtonItem barButtonItem in propMenuItems)
                            {
                                barButtonItem.Visibility = BarItemVisibility.Never;
                                barButtonItem.Enabled = false;
                            }
                            foreach (MethodMMenu methodMMenu in rights)
                            {
                                BarButtonItem barButtonItem = FindBarButtonItem(methodMMenu.MenuItemID);
                                if (barButtonItem != null)
                                {
                                    barButtonItem.Enabled = methodMMenu.IsEnabled;
                                    if (methodMMenu.IsVisible)
                                        barButtonItem.Visibility = BarItemVisibility.Always;
                                    else
                                        barButtonItem.Visibility = BarItemVisibility.Never;
                                }
                            }
                            ppmNode.ShowPopup(productProcessPanel.PointToScreen(e.Location));
                        }
                        return;
                    }
                }
                #endregion

                #region 在连接线上点击鼠标右键后的处理
                IPaintItem line = productProcessPanel.GetLineAtPoint(location);
                if (line != null)
                {
                    if (line is ProcessLine)
                    {
                        itemRightClicked = line;

                        ProcessLine processLine = line as ProcessLine;
                        if (processLine.Tag != null)
                            bbiProcessProperties.Enabled = true;
                        else
                            bbiProcessProperties.Enabled = false;

                        ppmLine.ShowPopup(productProcessPanel.PointToScreen(e.Location));
                    }

                    return;
                }
                #endregion

                ppmBlank.ShowPopup(productProcessPanel.PointToScreen(e.Location));
            }
            #endregion
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (edtFilter.Text.Trim() == "")
            {
                if (XtraMessageBox.Show(
                        string.Format(
                            "您没有输入过滤条件，在加载{0}列表的时候，" +
                            "需要较长时间。\n\n请问：是否要继续？",
                            cboProductType.SelectedText),
                        Text,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }

            int nodeID = (int)cboProductType.EditValue;
            GetProductList(nodeID, edtFilter.Text.Trim());
            ClearProcessPanel();

            grdvProducts_RowClick(grdvProducts, null);
        }

        private void edtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnSearch.PerformClick();
        }

        private void grdvProducts_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int index = grdvProducts.GetFocusedDataSourceRowIndex();
            if (index >= 0 && index < prdts.Count)
            {
                string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);
                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    lblProductName.Text =
                        string.Format(
                            "{0}\"{1}\"的工艺流程",
                            cboProductType.SelectedItem.ToString(),
                            prdts[index].NodeName);
                    SetEditorMode(false);

                    int errCode = 0;
                    string errText = "";

                    IRAPMDMClient.Instance.ufn_GetInfo_ProductProcess(
                        IRAPUser.Instance.CommunityID,
                        prdts[index].LeafID,
                        "",
                        IRAPUser.Instance.SysLogID,
                        ref prdtProcesses,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    pnlWorkFlow.Enabled = true;
                    GenerateWorkFlow(prdtProcesses);

                    if (prdtProcesses.Count > 0 && prdtProcesses[0].Reference)
                    {
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
            else
            {
                ClearProcessPanel();
            }
        }

        private void bbiResetLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            productProcessPanel.ResetLayout();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grdvProducts_RowClick(
                grdvProducts,
                new DevExpress.XtraGrid.Views.Grid.RowClickEventArgs(
                    new DevExpress.Utils.DXMouseEventArgs(
                        MouseButtons.Left,
                        1,
                        0,
                        0,
                        0),
                    grdvProducts.GetFocusedDataSourceRowIndex()));
        }

        private void frmProductProcessManager_30_Shown(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            List<MethodMMenu> datas = new List<MethodMMenu>();
            int errCode = 0;
            string errText = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPMDMClient.Instance.ufn_GetList_MethodMMenu(
                    IRAPUser.Instance.CommunityID,
                    0,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0 &&
                    datas.Count > 0 &&
                    datas[0].IsEnabled)
                {

                }
                else
                {
                    foreach (BarButtonItem item in nodeButtons)
                        item.Visibility = BarItemVisibility.Never;
                    foreach (BarButtonItem item in propMenuItems)
                        item.Visibility = BarItemVisibility.Never;

                    bbiOperationChoice.Visibility = BarItemVisibility.Never;
                    bbiProcessProperties.Visibility = BarItemVisibility.Never;
                    bbiDeleteLine.Visibility = BarItemVisibility.Never;
                    bbiDeleteNode.Visibility = BarItemVisibility.Never;

                    pnlWorkFlowCommand.Visible = false;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

        }

        private void bbiOperationChoice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (itemRightClicked is OperationNode &&
                (itemRightClicked as OperationNode).Tag is ProcessOperation)
            {
                int t116LeafID =
                    ((itemRightClicked as OperationNode).Tag as ProcessOperation).T116Leaf;
                using (frmSelectOperation selectOperation = new frmSelectOperation())
                {

                    foreach (ProcessOperation operation in operations)
                    {
                        if (operation.T116Leaf == t116LeafID &&
                            !LeafIDInNodesExists(operation.T216Leaf))
                        {
                            selectOperation.cboOperations.Properties.Items.Add(operation);
                        }
                    }

                    if (selectOperation.ShowDialog() == DialogResult.OK)
                    {
                        if (selectOperation.OperationSelected != null)
                        {
                            OperationNode node = itemRightClicked as OperationNode;
                            node.Tag = selectOperation.OperationSelected;

                            productProcessPanel.Refresh();

                            SetEditorMode(true);
                        }
                    }
                }
            }

            itemRightClicked = null;
        }

        private void bbiProcessProperties_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (itemRightClicked is ProcessLine)
            {
                using (frmProcessProperties processProperties = new frmProcessProperties())
                {
                    processProperties.T121Items = t121Items;
                    processProperties.ProcessProperties =
                        (itemRightClicked as ProcessLine).Tag;
                    if (processProperties.ShowDialog() == DialogResult.OK)
                    {
                        (itemRightClicked as ProcessLine).Tag =
                            processProperties.ProcessProperties;
                        SetEditorMode(true);
                    }
                }
            }

            itemRightClicked = null;
        }

        private void bbiDeleteNode_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (itemRightClicked is OperationNode)
            {
                OperationNode node = itemRightClicked as OperationNode;
                for (int i = node.PrevLinks.Count - 1; i >= 0; i--)
                {
                    RemoveLine(node.PrevLinks[i] as ProcessLine);
                }
                for (int i = node.NextLinks.Count - 1; i >= 0; i--)
                {
                    RemoveLine(node.NextLinks[i] as ProcessLine);
                }

                productProcessPanel.Items.Remove(node);
                productProcessPanel.Refresh();

                itemRightClicked = null;

                SetEditorMode(true);
            }
        }

        private void bbiDeleteLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (itemRightClicked is ProcessLine)
            {
                RemoveLine(itemRightClicked as ProcessLine);
                productProcessPanel.Refresh();

                itemRightClicked = null;

                SetEditorMode(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 保存修改后的产品工艺流程
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
                string effectiveTime = "";

                if (!chkEffectiveType.Checked)
                {
                    #region 要求输入生效日期和时间
                    #endregion
                }

                #region 流程图路由及在制品标识类型校验
                foreach (IPaintItem iitem in productProcessPanel.Items)
                {
                    if (iitem is OperationNode)
                    {
                        OperationNode node = iitem as OperationNode;

                        if (!node.CheckValid())
                        {
                            XtraMessageBox.Show(
                                "流程中存在未配置完整路由的工序",
                                "路由错误",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        foreach (ItemLink link in node.NextLinks)
                        {
                            if (link is ProcessLine)
                            {
                                ProcessLine line = link as ProcessLine;
                                if (line.Tag.T121LeafID == 0)
                                {
                                    XtraMessageBox.Show(
                                        "工艺流程中的在制品标识类型必须设置！",
                                        "系统信息",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Asterisk);
                                    return;
                                }
                            }
                        }
                    }
                }
                #endregion

                IRAPMDMClient.Instance.ssp_SaveRSAttrChange(
                    IRAPUser.Instance.CommunityID,
                    102,
                    prdts[grdvProducts.GetFocusedDataSourceRowIndex()].LeafID,
                    9,
                    "",
                    effectiveTime,
                    true,
                    GenerateRSAttrXML(),
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format(
                        "({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    grdvProducts_RowClick(
                        grdvProducts,
                        new DevExpress.XtraGrid.Views.Grid.RowClickEventArgs(
                            new DevExpress.Utils.DXMouseEventArgs(
                                MouseButtons.Left,
                                1,
                                0,
                                0,
                                0),
                            grdvProducts.GetFocusedDataSourceRowIndex()));
                }
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            #endregion

            SetEditorMode(false);
        }

        private void productProcessPanel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseInposition =
                new Point(
                    e.X + productProcessPanel.HorizontalScroll.Value,
                    e.Y + productProcessPanel.VerticalScroll.Value);
            IPaintItem item = productProcessPanel.GetItemAtPoint(mouseInposition);
            if (item == null)
                item = productProcessPanel.GetLineAtPoint(mouseInposition);

            if (e.Button == MouseButtons.None)
            {
                if (item != itemAtMousePosition)
                {
                    if (item is ItemNode)
                    {
                    }
                    else if (item is ProcessLine)
                    {
                        if ((item as ProcessLine).Tag != null)
                        {
                            toolTip.ToolTipTitle = "流程属性";
                            toolTip.Show(
                                string.Format(
                                    "分支流量低限值：{0}\n" +
                                    "分支流量高限值：{1}\n" +
                                    "制程进度：{2}\n" +
                                    "在制品标识类型：{3}",
                                    (item as ProcessLine).Tag.MinPercent,
                                    (item as ProcessLine).Tag.MaxPercent,
                                    (item as ProcessLine).Tag.ProcessPercentage,
                                    (item as ProcessLine).Tag.T121Name),
                                productProcessPanel,
                                e.X,
                                e.Y);
                        }
                    }
                    else
                    {
                        toolTip.Hide(productProcessPanel);
                    }
                }

                itemAtMousePosition = item;
            }
        }

        private void RowPropertiesMNG(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag != null && e.Item.Tag is int)
            {
                int itemID = (int)e.Item.Tag;

                if (itemRightClicked is OperationNode)
                {
                    OperationNode node = itemRightClicked as OperationNode;
                    if (node.Tag is ProcessOperation)
                    {
                        frmCustomProperites propertiesForm = PropertiesFormFactory.CreateInstance(itemID);
                        if (propertiesForm == null)
                        {
                            XtraMessageBox.Show(
                                string.Format(
                                    "功能[{0}]正在紧张开发中！",
                                    e.Item.Caption),
                                Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            using (propertiesForm)
                            {
                                if (propertiesForm is frmFailureModeProperties)
                                {
                                    int currentLevel = (itemRightClicked as OperationNode).Level;

                                    List<ProcessOperation> prevOperations = new List<ProcessOperation>();
                                    for (int i = 0; i < productProcessPanel.Items.Count; i++)
                                    {
                                        if (productProcessPanel.Items[i] is OperationNode)
                                        {
                                            OperationNode nodePrev
                                                = productProcessPanel.Items[i] as OperationNode;
                                            if (nodePrev.Level > 0 && nodePrev.Level < currentLevel)
                                                prevOperations.Add((nodePrev.Tag as ProcessOperation).Clone());
                                        }
                                    }

                                    ((frmFailureModeProperties)propertiesForm).Operations = prevOperations;
                                }

                                propertiesForm.SetCaption(
                                    prdts[grdvProducts.GetFocusedDataSourceRowIndex()].NodeName,
                                    (node.Tag as ProcessOperation).T216Name);
                                propertiesForm.Size = pnlWorkFlow.Size;

                                propertiesForm.GetProperties(
                                    prdts[grdvProducts.GetFocusedDataSourceRowIndex()].LeafID,
                                    (node.Tag as ProcessOperation).T216Leaf);

                                propertiesForm.ShowDialog();
                            }
                        }
                    }
                }
            }
        }
    }

    internal class T116PropItemRight
    {
        private List<MethodMMenu> menuRights = new List<MethodMMenu>();

        /// <summary>
        /// 工序类型（T116）标识
        /// </summary>
        public int T116LeafID { get; set; }

        public List<MethodMMenu> Rights
        {
            get { return menuRights; }
            set { menuRights = value; }
        }
    }
}
