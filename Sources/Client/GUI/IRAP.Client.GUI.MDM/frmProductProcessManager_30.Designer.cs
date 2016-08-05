namespace IRAP.Client.GUI.MDM
{
    partial class frmProductProcessManager_30
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductProcessManager_30));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.gpcProductList = new DevExpress.XtraEditors.GroupControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.grdProducts = new DevExpress.XtraGrid.GridControl();
            this.grdvProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnNodeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnNodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtFilter = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboProductType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.pnlWorkFlow = new DevExpress.XtraEditors.PanelControl();
            this.productProcessPanel = new IRAP.Client.GUI.MDM.ProductProcessPanel();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.pnlWorkFlowCommand = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.chkEffectiveType = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblProductName = new DevExpress.XtraEditors.LabelControl();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barWorkFlowTools = new DevExpress.XtraBars.Bar();
            this.bbiBegin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiProductWithMaterial = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNoMaterialProcessing = new DevExpress.XtraBars.BarButtonItem();
            this.bbiManualInspection = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMachineTesting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTroubleShooting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiProductPackaging = new DevExpress.XtraBars.BarButtonItem();
            this.bbiProductionOfMaterialAndManualInspection = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNoMaterialProcessingAndManualInspection = new DevExpress.XtraBars.BarButtonItem();
            this.bbiProductionOfMaterialAndMachineTesting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiProductPackagingAndAccessory = new DevExpress.XtraBars.BarButtonItem();
            this.bbiVirtualComposite = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEnd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLink = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbiOperationChoice = new DevExpress.XtraBars.BarButtonItem();
            this.bbiProcessProperties = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteNode = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMethodStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiInspectStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTestStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiToolingStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLoadingSheet = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUnloadingSheet = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPackagingStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMFGPrograms = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFailureModes = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOPStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEnvParamStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEnergyStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrepareStandard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPokaYokeRules = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMethodDocuments = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSkillMatrix = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteLine = new DevExpress.XtraBars.BarButtonItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ppmNode = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ppmLine = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ppmBlank = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcProductList)).BeginInit();
            this.gpcProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkFlow)).BeginInit();
            this.pnlWorkFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkFlowCommand)).BeginInit();
            this.pnlWorkFlowCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppmNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppmLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppmBlank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            resources.ApplyResources(this.lblFuncName, "lblFuncName");
            this.lblFuncName.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblFuncName.Appearance.Font")));
            this.lblFuncName.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblFuncName.Appearance.FontSizeDelta")));
            this.lblFuncName.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblFuncName.Appearance.FontStyleDelta")));
            this.lblFuncName.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblFuncName.Appearance.ForeColor")));
            this.lblFuncName.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblFuncName.Appearance.GradientMode")));
            this.lblFuncName.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblFuncName.Appearance.Image")));
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.toolTip.SetToolTip(this.lblFuncName, resources.GetString("lblFuncName.ToolTip1"));
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.FontSizeDelta = ((int)(resources.GetObject("toolTipController.Appearance.FontSizeDelta")));
            this.toolTipController.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("toolTipController.Appearance.FontStyleDelta")));
            this.toolTipController.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("toolTipController.Appearance.GradientMode")));
            this.toolTipController.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("toolTipController.Appearance.Image")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.FontSizeDelta = ((int)(resources.GetObject("toolTipController.AppearanceTitle.FontSizeDelta")));
            this.toolTipController.AppearanceTitle.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("toolTipController.AppearanceTitle.FontStyleDelta")));
            this.toolTipController.AppearanceTitle.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("toolTipController.AppearanceTitle.GradientMode")));
            this.toolTipController.AppearanceTitle.Image = ((System.Drawing.Image)(resources.GetObject("toolTipController.AppearanceTitle.Image")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // splitContainerControl
            // 
            resources.ApplyResources(this.splitContainerControl, "splitContainerControl");
            this.splitContainerControl.Name = "splitContainerControl";
            resources.ApplyResources(this.splitContainerControl.Panel1, "splitContainerControl.Panel1");
            this.splitContainerControl.Panel1.Controls.Add(this.gpcProductList);
            resources.ApplyResources(this.splitContainerControl.Panel2, "splitContainerControl.Panel2");
            this.splitContainerControl.Panel2.Controls.Add(this.pnlWorkFlow);
            this.splitContainerControl.Panel2.Controls.Add(this.pnlWorkFlowCommand);
            this.splitContainerControl.Panel2.Controls.Add(this.lblProductName);
            this.splitContainerControl.SplitterPosition = 385;
            this.toolTip.SetToolTip(this.splitContainerControl, resources.GetString("splitContainerControl.ToolTip"));
            // 
            // gpcProductList
            // 
            resources.ApplyResources(this.gpcProductList, "gpcProductList");
            this.gpcProductList.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("gpcProductList.Appearance.Font")));
            this.gpcProductList.Appearance.FontSizeDelta = ((int)(resources.GetObject("gpcProductList.Appearance.FontSizeDelta")));
            this.gpcProductList.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gpcProductList.Appearance.FontStyleDelta")));
            this.gpcProductList.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gpcProductList.Appearance.GradientMode")));
            this.gpcProductList.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("gpcProductList.Appearance.Image")));
            this.gpcProductList.Appearance.Options.UseFont = true;
            this.gpcProductList.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("gpcProductList.AppearanceCaption.Font")));
            this.gpcProductList.AppearanceCaption.FontSizeDelta = ((int)(resources.GetObject("gpcProductList.AppearanceCaption.FontSizeDelta")));
            this.gpcProductList.AppearanceCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gpcProductList.AppearanceCaption.FontStyleDelta")));
            this.gpcProductList.AppearanceCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gpcProductList.AppearanceCaption.GradientMode")));
            this.gpcProductList.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("gpcProductList.AppearanceCaption.Image")));
            this.gpcProductList.AppearanceCaption.Options.UseFont = true;
            this.gpcProductList.Controls.Add(this.panelControl3);
            this.gpcProductList.Controls.Add(this.panelControl2);
            this.gpcProductList.Name = "gpcProductList";
            this.toolTip.SetToolTip(this.gpcProductList, resources.GetString("gpcProductList.ToolTip"));
            // 
            // panelControl3
            // 
            resources.ApplyResources(this.panelControl3, "panelControl3");
            this.toolTipController.SetAllowHtmlText(this.panelControl3, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("panelControl3.AllowHtmlText"))));
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.grdProducts);
            this.panelControl3.Name = "panelControl3";
            this.toolTipController.SetTitle(this.panelControl3, resources.GetString("panelControl3.Title"));
            this.toolTip.SetToolTip(this.panelControl3, resources.GetString("panelControl3.ToolTip"));
            this.toolTipController.SetToolTip(this.panelControl3, resources.GetString("panelControl3.ToolTip1"));
            this.toolTipController.SetToolTipIconType(this.panelControl3, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("panelControl3.ToolTipIconType"))));
            // 
            // grdProducts
            // 
            resources.ApplyResources(this.grdProducts, "grdProducts");
            this.grdProducts.EmbeddedNavigator.AccessibleDescription = resources.GetString("grdProducts.EmbeddedNavigator.AccessibleDescription");
            this.grdProducts.EmbeddedNavigator.AccessibleName = resources.GetString("grdProducts.EmbeddedNavigator.AccessibleName");
            this.grdProducts.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("grdProducts.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.grdProducts.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("grdProducts.EmbeddedNavigator.Anchor")));
            this.grdProducts.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grdProducts.EmbeddedNavigator.BackgroundImage")));
            this.grdProducts.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("grdProducts.EmbeddedNavigator.BackgroundImageLayout")));
            this.grdProducts.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("grdProducts.EmbeddedNavigator.ImeMode")));
            this.grdProducts.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("grdProducts.EmbeddedNavigator.MaximumSize")));
            this.grdProducts.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("grdProducts.EmbeddedNavigator.TextLocation")));
            this.grdProducts.EmbeddedNavigator.ToolTip = resources.GetString("grdProducts.EmbeddedNavigator.ToolTip");
            this.grdProducts.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("grdProducts.EmbeddedNavigator.ToolTipIconType")));
            this.grdProducts.EmbeddedNavigator.ToolTipTitle = resources.GetString("grdProducts.EmbeddedNavigator.ToolTipTitle");
            this.grdProducts.MainView = this.grdvProducts;
            this.grdProducts.Name = "grdProducts";
            this.toolTip.SetToolTip(this.grdProducts, resources.GetString("grdProducts.ToolTip"));
            this.grdProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvProducts});
            // 
            // grdvProducts
            // 
            this.grdvProducts.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("grdvProducts.Appearance.HeaderPanel.Font")));
            this.grdvProducts.Appearance.HeaderPanel.FontSizeDelta = ((int)(resources.GetObject("grdvProducts.Appearance.HeaderPanel.FontSizeDelta")));
            this.grdvProducts.Appearance.HeaderPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdvProducts.Appearance.HeaderPanel.FontStyleDelta")));
            this.grdvProducts.Appearance.HeaderPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdvProducts.Appearance.HeaderPanel.GradientMode")));
            this.grdvProducts.Appearance.HeaderPanel.Image = ((System.Drawing.Image)(resources.GetObject("grdvProducts.Appearance.HeaderPanel.Image")));
            this.grdvProducts.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvProducts.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvProducts.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvProducts.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvProducts.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("grdvProducts.Appearance.Row.Font")));
            this.grdvProducts.Appearance.Row.FontSizeDelta = ((int)(resources.GetObject("grdvProducts.Appearance.Row.FontSizeDelta")));
            this.grdvProducts.Appearance.Row.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdvProducts.Appearance.Row.FontStyleDelta")));
            this.grdvProducts.Appearance.Row.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdvProducts.Appearance.Row.GradientMode")));
            this.grdvProducts.Appearance.Row.Image = ((System.Drawing.Image)(resources.GetObject("grdvProducts.Appearance.Row.Image")));
            this.grdvProducts.Appearance.Row.Options.UseFont = true;
            resources.ApplyResources(this.grdvProducts, "grdvProducts");
            this.grdvProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnNodeCode,
            this.grdclmnNodeName});
            this.grdvProducts.GridControl = this.grdProducts;
            this.grdvProducts.Name = "grdvProducts";
            this.grdvProducts.OptionsBehavior.Editable = false;
            this.grdvProducts.OptionsSelection.InvertSelection = true;
            this.grdvProducts.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvProducts.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvProducts.OptionsView.EnableAppearanceOddRow = true;
            this.grdvProducts.OptionsView.RowAutoHeight = true;
            this.grdvProducts.OptionsView.ShowGroupPanel = false;
            this.grdvProducts.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grdvProducts_RowClick);
            // 
            // grdclmnNodeCode
            // 
            resources.ApplyResources(this.grdclmnNodeCode, "grdclmnNodeCode");
            this.grdclmnNodeCode.FieldName = "NodeCode";
            this.grdclmnNodeCode.Name = "grdclmnNodeCode";
            this.grdclmnNodeCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnNodeName
            // 
            resources.ApplyResources(this.grdclmnNodeName, "grdclmnNodeName");
            this.grdclmnNodeName.FieldName = "NodeName";
            this.grdclmnNodeName.Name = "grdclmnNodeName";
            this.grdclmnNodeName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // panelControl2
            // 
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.toolTipController.SetAllowHtmlText(this.panelControl2, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("panelControl2.AllowHtmlText"))));
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.edtFilter);
            this.panelControl2.Controls.Add(this.btnSearch);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.cboProductType);
            this.panelControl2.Name = "panelControl2";
            this.toolTipController.SetTitle(this.panelControl2, resources.GetString("panelControl2.Title"));
            this.toolTip.SetToolTip(this.panelControl2, resources.GetString("panelControl2.ToolTip"));
            this.toolTipController.SetToolTip(this.panelControl2, resources.GetString("panelControl2.ToolTip1"));
            this.toolTipController.SetToolTipIconType(this.panelControl2, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("panelControl2.ToolTipIconType"))));
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl1.Appearance.Font")));
            this.labelControl1.Appearance.FontSizeDelta = ((int)(resources.GetObject("labelControl1.Appearance.FontSizeDelta")));
            this.labelControl1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("labelControl1.Appearance.FontStyleDelta")));
            this.labelControl1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("labelControl1.Appearance.GradientMode")));
            this.labelControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.Appearance.Image")));
            this.labelControl1.Name = "labelControl1";
            this.toolTip.SetToolTip(this.labelControl1, resources.GetString("labelControl1.ToolTip1"));
            // 
            // edtFilter
            // 
            resources.ApplyResources(this.edtFilter, "edtFilter");
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.AccessibleDescription = resources.GetString("edtFilter.Properties.AccessibleDescription");
            this.edtFilter.Properties.AccessibleName = resources.GetString("edtFilter.Properties.AccessibleName");
            this.edtFilter.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtFilter.Properties.Appearance.Font")));
            this.edtFilter.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("edtFilter.Properties.Appearance.FontSizeDelta")));
            this.edtFilter.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("edtFilter.Properties.Appearance.FontStyleDelta")));
            this.edtFilter.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("edtFilter.Properties.Appearance.GradientMode")));
            this.edtFilter.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("edtFilter.Properties.Appearance.Image")));
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.AutoHeight = ((bool)(resources.GetObject("edtFilter.Properties.AutoHeight")));
            this.edtFilter.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("edtFilter.Properties.Mask.AutoComplete")));
            this.edtFilter.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("edtFilter.Properties.Mask.BeepOnError")));
            this.edtFilter.Properties.Mask.EditMask = resources.GetString("edtFilter.Properties.Mask.EditMask");
            this.edtFilter.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("edtFilter.Properties.Mask.IgnoreMaskBlank")));
            this.edtFilter.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("edtFilter.Properties.Mask.MaskType")));
            this.edtFilter.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("edtFilter.Properties.Mask.PlaceHolder")));
            this.edtFilter.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("edtFilter.Properties.Mask.SaveLiteral")));
            this.edtFilter.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("edtFilter.Properties.Mask.ShowPlaceHolders")));
            this.edtFilter.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("edtFilter.Properties.Mask.UseMaskAsDisplayFormat")));
            this.edtFilter.Properties.NullValuePrompt = resources.GetString("edtFilter.Properties.NullValuePrompt");
            this.edtFilter.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("edtFilter.Properties.NullValuePromptShowForEmptyValue")));
            this.toolTip.SetToolTip(this.edtFilter, resources.GetString("edtFilter.ToolTip1"));
            this.edtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtFilter_KeyDown);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnSearch.Appearance.Font")));
            this.btnSearch.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnSearch.Appearance.FontSizeDelta")));
            this.btnSearch.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnSearch.Appearance.FontStyleDelta")));
            this.btnSearch.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnSearch.Appearance.GradientMode")));
            this.btnSearch.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Appearance.Image")));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Name = "btnSearch";
            this.toolTip.SetToolTip(this.btnSearch, resources.GetString("btnSearch.ToolTip1"));
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl2.Appearance.Font")));
            this.labelControl2.Appearance.FontSizeDelta = ((int)(resources.GetObject("labelControl2.Appearance.FontSizeDelta")));
            this.labelControl2.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("labelControl2.Appearance.FontStyleDelta")));
            this.labelControl2.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("labelControl2.Appearance.GradientMode")));
            this.labelControl2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl2.Appearance.Image")));
            this.labelControl2.Name = "labelControl2";
            this.toolTip.SetToolTip(this.labelControl2, resources.GetString("labelControl2.ToolTip1"));
            // 
            // cboProductType
            // 
            resources.ApplyResources(this.cboProductType, "cboProductType");
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Properties.AccessibleDescription = resources.GetString("cboProductType.Properties.AccessibleDescription");
            this.cboProductType.Properties.AccessibleName = resources.GetString("cboProductType.Properties.AccessibleName");
            this.cboProductType.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cboProductType.Properties.Appearance.Font")));
            this.cboProductType.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("cboProductType.Properties.Appearance.FontSizeDelta")));
            this.cboProductType.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cboProductType.Properties.Appearance.FontStyleDelta")));
            this.cboProductType.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cboProductType.Properties.Appearance.GradientMode")));
            this.cboProductType.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cboProductType.Properties.Appearance.Image")));
            this.cboProductType.Properties.Appearance.Options.UseFont = true;
            this.cboProductType.Properties.AutoHeight = ((bool)(resources.GetObject("cboProductType.Properties.AutoHeight")));
            this.cboProductType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboProductType.Properties.Buttons"))))});
            this.cboProductType.Properties.GlyphAlignment = ((DevExpress.Utils.HorzAlignment)(resources.GetObject("cboProductType.Properties.GlyphAlignment")));
            this.cboProductType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboProductType.Properties.Items"), ((object)(resources.GetObject("cboProductType.Properties.Items1"))), ((int)(resources.GetObject("cboProductType.Properties.Items2")))),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("cboProductType.Properties.Items3"), ((object)(resources.GetObject("cboProductType.Properties.Items4"))), ((int)(resources.GetObject("cboProductType.Properties.Items5"))))});
            this.cboProductType.Properties.NullValuePrompt = resources.GetString("cboProductType.Properties.NullValuePrompt");
            this.cboProductType.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cboProductType.Properties.NullValuePromptShowForEmptyValue")));
            this.toolTip.SetToolTip(this.cboProductType, resources.GetString("cboProductType.ToolTip1"));
            // 
            // pnlWorkFlow
            // 
            resources.ApplyResources(this.pnlWorkFlow, "pnlWorkFlow");
            this.toolTipController.SetAllowHtmlText(this.pnlWorkFlow, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("pnlWorkFlow.AllowHtmlText"))));
            this.pnlWorkFlow.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlWorkFlow.Controls.Add(this.productProcessPanel);
            this.pnlWorkFlow.Controls.Add(this.standaloneBarDockControl1);
            this.pnlWorkFlow.Name = "pnlWorkFlow";
            this.toolTipController.SetTitle(this.pnlWorkFlow, resources.GetString("pnlWorkFlow.Title"));
            this.toolTip.SetToolTip(this.pnlWorkFlow, resources.GetString("pnlWorkFlow.ToolTip"));
            this.toolTipController.SetToolTip(this.pnlWorkFlow, resources.GetString("pnlWorkFlow.ToolTip1"));
            this.toolTipController.SetToolTipIconType(this.pnlWorkFlow, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("pnlWorkFlow.ToolTipIconType"))));
            // 
            // productProcessPanel
            // 
            resources.ApplyResources(this.productProcessPanel, "productProcessPanel");
            this.toolTipController.SetAllowHtmlText(this.productProcessPanel, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("productProcessPanel.AllowHtmlText"))));
            this.productProcessPanel.BackgroundColor = System.Drawing.Color.White;
            this.productProcessPanel.Name = "productProcessPanel";
            this.productProcessPanel.Root = null;
            this.toolTipController.SetTitle(this.productProcessPanel, resources.GetString("productProcessPanel.Title"));
            this.toolTip.SetToolTip(this.productProcessPanel, resources.GetString("productProcessPanel.ToolTip"));
            this.toolTipController.SetToolTip(this.productProcessPanel, resources.GetString("productProcessPanel.ToolTip1"));
            this.toolTipController.SetToolTipIconType(this.productProcessPanel, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("productProcessPanel.ToolTipIconType"))));
            this.productProcessPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.productProcessPanel_MouseDown);
            this.productProcessPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.productProcessPanel_MouseMove);
            // 
            // standaloneBarDockControl1
            // 
            resources.ApplyResources(this.standaloneBarDockControl1, "standaloneBarDockControl1");
            this.standaloneBarDockControl1.Appearance.FontSizeDelta = ((int)(resources.GetObject("standaloneBarDockControl1.Appearance.FontSizeDelta")));
            this.standaloneBarDockControl1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("standaloneBarDockControl1.Appearance.FontStyleDelta")));
            this.standaloneBarDockControl1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("standaloneBarDockControl1.Appearance.GradientMode")));
            this.standaloneBarDockControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("standaloneBarDockControl1.Appearance.Image")));
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.toolTip.SetToolTip(this.standaloneBarDockControl1, resources.GetString("standaloneBarDockControl1.ToolTip"));
            // 
            // pnlWorkFlowCommand
            // 
            resources.ApplyResources(this.pnlWorkFlowCommand, "pnlWorkFlowCommand");
            this.toolTipController.SetAllowHtmlText(this.pnlWorkFlowCommand, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("pnlWorkFlowCommand.AllowHtmlText"))));
            this.pnlWorkFlowCommand.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlWorkFlowCommand.Controls.Add(this.btnSave);
            this.pnlWorkFlowCommand.Controls.Add(this.chkEffectiveType);
            this.pnlWorkFlowCommand.Controls.Add(this.btnCancel);
            this.pnlWorkFlowCommand.Name = "pnlWorkFlowCommand";
            this.toolTipController.SetTitle(this.pnlWorkFlowCommand, resources.GetString("pnlWorkFlowCommand.Title"));
            this.toolTip.SetToolTip(this.pnlWorkFlowCommand, resources.GetString("pnlWorkFlowCommand.ToolTip"));
            this.toolTipController.SetToolTip(this.pnlWorkFlowCommand, resources.GetString("pnlWorkFlowCommand.ToolTip1"));
            this.toolTipController.SetToolTipIconType(this.pnlWorkFlowCommand, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("pnlWorkFlowCommand.ToolTipIconType"))));
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnSave.Appearance.Font")));
            this.btnSave.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnSave.Appearance.FontSizeDelta")));
            this.btnSave.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnSave.Appearance.FontStyleDelta")));
            this.btnSave.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnSave.Appearance.GradientMode")));
            this.btnSave.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Appearance.Image")));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Name = "btnSave";
            this.toolTip.SetToolTip(this.btnSave, resources.GetString("btnSave.ToolTip1"));
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkEffectiveType
            // 
            resources.ApplyResources(this.chkEffectiveType, "chkEffectiveType");
            this.chkEffectiveType.Name = "chkEffectiveType";
            this.chkEffectiveType.Properties.AccessibleDescription = resources.GetString("chkEffectiveType.Properties.AccessibleDescription");
            this.chkEffectiveType.Properties.AccessibleName = resources.GetString("chkEffectiveType.Properties.AccessibleName");
            this.chkEffectiveType.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("chkEffectiveType.Properties.Appearance.Font")));
            this.chkEffectiveType.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("chkEffectiveType.Properties.Appearance.FontSizeDelta")));
            this.chkEffectiveType.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("chkEffectiveType.Properties.Appearance.FontStyleDelta")));
            this.chkEffectiveType.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("chkEffectiveType.Properties.Appearance.GradientMode")));
            this.chkEffectiveType.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("chkEffectiveType.Properties.Appearance.Image")));
            this.chkEffectiveType.Properties.Appearance.Options.UseFont = true;
            this.chkEffectiveType.Properties.Appearance.Options.UseTextOptions = true;
            this.chkEffectiveType.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.chkEffectiveType.Properties.AutoHeight = ((bool)(resources.GetObject("chkEffectiveType.Properties.AutoHeight")));
            this.chkEffectiveType.Properties.Caption = resources.GetString("chkEffectiveType.Properties.Caption");
            this.chkEffectiveType.Properties.DisplayValueChecked = resources.GetString("chkEffectiveType.Properties.DisplayValueChecked");
            this.chkEffectiveType.Properties.DisplayValueGrayed = resources.GetString("chkEffectiveType.Properties.DisplayValueGrayed");
            this.chkEffectiveType.Properties.DisplayValueUnchecked = resources.GetString("chkEffectiveType.Properties.DisplayValueUnchecked");
            this.toolTip.SetToolTip(this.chkEffectiveType, resources.GetString("chkEffectiveType.ToolTip1"));
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnCancel.Appearance.Font")));
            this.btnCancel.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnCancel.Appearance.FontSizeDelta")));
            this.btnCancel.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnCancel.Appearance.FontStyleDelta")));
            this.btnCancel.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnCancel.Appearance.GradientMode")));
            this.btnCancel.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Appearance.Image")));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Name = "btnCancel";
            this.toolTip.SetToolTip(this.btnCancel, resources.GetString("btnCancel.ToolTip1"));
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblProductName
            // 
            resources.ApplyResources(this.lblProductName, "lblProductName");
            this.lblProductName.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lblProductName.Appearance.BackColor")));
            this.lblProductName.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblProductName.Appearance.Font")));
            this.lblProductName.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblProductName.Appearance.FontSizeDelta")));
            this.lblProductName.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblProductName.Appearance.FontStyleDelta")));
            this.lblProductName.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblProductName.Appearance.ForeColor")));
            this.lblProductName.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblProductName.Appearance.GradientMode")));
            this.lblProductName.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblProductName.Appearance.Image")));
            this.lblProductName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblProductName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblProductName.Name = "lblProductName";
            this.toolTip.SetToolTip(this.lblProductName, resources.GetString("lblProductName.ToolTip1"));
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barWorkFlowTools});
            this.barManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            ((DevExpress.XtraBars.BarManagerCategory)(resources.GetObject("barManager.Categories"))),
            ((DevExpress.XtraBars.BarManagerCategory)(resources.GetObject("barManager.Categories1"))),
            ((DevExpress.XtraBars.BarManagerCategory)(resources.GetObject("barManager.Categories2"))),
            ((DevExpress.XtraBars.BarManagerCategory)(resources.GetObject("barManager.Categories3")))});
            this.barManager.Controller = this.barAndDockingController1;
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiBegin,
            this.bbiProductWithMaterial,
            this.bbiNoMaterialProcessing,
            this.bbiManualInspection,
            this.bbiMachineTesting,
            this.bbiTroubleShooting,
            this.bbiProductPackaging,
            this.bbiProductionOfMaterialAndManualInspection,
            this.bbiNoMaterialProcessingAndManualInspection,
            this.bbiProductionOfMaterialAndMachineTesting,
            this.bbiProductPackagingAndAccessory,
            this.bbiVirtualComposite,
            this.bbiEnd,
            this.bbiLink,
            this.bbiResetLayout,
            this.bbiOperationChoice,
            this.bbiProcessProperties,
            this.bbiDeleteNode,
            this.bbiMethodStandard,
            this.bbiInspectStandard,
            this.bbiTestStandard,
            this.bbiToolingStandard,
            this.bbiLoadingSheet,
            this.bbiUnloadingSheet,
            this.bbiPackagingStandard,
            this.bbiMFGPrograms,
            this.bbiFailureModes,
            this.bbiOPStandard,
            this.bbiEnvParamStandard,
            this.bbiEnergyStandard,
            this.bbiPrepareStandard,
            this.bbiPokaYokeRules,
            this.bbiMethodDocuments,
            this.bbiSkillMatrix,
            this.bbiDeleteLine});
            this.barManager.MaxItemId = 39;
            // 
            // barWorkFlowTools
            // 
            this.barWorkFlowTools.BarName = "Tools";
            this.barWorkFlowTools.DockCol = 0;
            this.barWorkFlowTools.DockRow = 0;
            this.barWorkFlowTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barWorkFlowTools.FloatLocation = new System.Drawing.Point(777, 290);
            this.barWorkFlowTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiBegin, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiProductWithMaterial),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNoMaterialProcessing),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiManualInspection),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiMachineTesting),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiTroubleShooting),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiProductPackaging),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiProductionOfMaterialAndManualInspection),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNoMaterialProcessingAndManualInspection),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiProductionOfMaterialAndMachineTesting),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiProductPackagingAndAccessory),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiVirtualComposite),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEnd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLink, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiResetLayout, true)});
            this.barWorkFlowTools.OptionsBar.AllowQuickCustomization = false;
            this.barWorkFlowTools.OptionsBar.DrawDragBorder = false;
            this.barWorkFlowTools.OptionsBar.MultiLine = true;
            this.barWorkFlowTools.OptionsBar.UseWholeRow = true;
            this.barWorkFlowTools.StandaloneBarDockControl = this.standaloneBarDockControl1;
            resources.ApplyResources(this.barWorkFlowTools, "barWorkFlowTools");
            // 
            // bbiBegin
            // 
            resources.ApplyResources(this.bbiBegin, "bbiBegin");
            this.bbiBegin.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiBegin.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiBegin.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.Begin;
            this.bbiBegin.Id = 0;
            this.bbiBegin.Name = "bbiBegin";
            this.bbiBegin.Tag = 0;
            this.bbiBegin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiProductWithMaterial
            // 
            resources.ApplyResources(this.bbiProductWithMaterial, "bbiProductWithMaterial");
            this.bbiProductWithMaterial.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiProductWithMaterial.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiProductWithMaterial.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.有料生产工序;
            this.bbiProductWithMaterial.Id = 1;
            this.bbiProductWithMaterial.Name = "bbiProductWithMaterial";
            this.bbiProductWithMaterial.Tag = 12158;
            this.bbiProductWithMaterial.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiProductWithMaterial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiNoMaterialProcessing
            // 
            resources.ApplyResources(this.bbiNoMaterialProcessing, "bbiNoMaterialProcessing");
            this.bbiNoMaterialProcessing.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiNoMaterialProcessing.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiNoMaterialProcessing.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.无料加工工序;
            this.bbiNoMaterialProcessing.Id = 2;
            this.bbiNoMaterialProcessing.Name = "bbiNoMaterialProcessing";
            this.bbiNoMaterialProcessing.Tag = 12159;
            this.bbiNoMaterialProcessing.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiNoMaterialProcessing.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiManualInspection
            // 
            resources.ApplyResources(this.bbiManualInspection, "bbiManualInspection");
            this.bbiManualInspection.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiManualInspection.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiManualInspection.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.人工检查工序;
            this.bbiManualInspection.Id = 3;
            this.bbiManualInspection.Name = "bbiManualInspection";
            this.bbiManualInspection.Tag = 12161;
            this.bbiManualInspection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiManualInspection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiMachineTesting
            // 
            resources.ApplyResources(this.bbiMachineTesting, "bbiMachineTesting");
            this.bbiMachineTesting.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiMachineTesting.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiMachineTesting.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.机器测试工序;
            this.bbiMachineTesting.Id = 4;
            this.bbiMachineTesting.Name = "bbiMachineTesting";
            this.bbiMachineTesting.Tag = 12165;
            this.bbiMachineTesting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiMachineTesting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiTroubleShooting
            // 
            resources.ApplyResources(this.bbiTroubleShooting, "bbiTroubleShooting");
            this.bbiTroubleShooting.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiTroubleShooting.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiTroubleShooting.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.故障维修工序;
            this.bbiTroubleShooting.Id = 5;
            this.bbiTroubleShooting.Name = "bbiTroubleShooting";
            this.bbiTroubleShooting.Tag = 12168;
            this.bbiTroubleShooting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiTroubleShooting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiProductPackaging
            // 
            resources.ApplyResources(this.bbiProductPackaging, "bbiProductPackaging");
            this.bbiProductPackaging.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiProductPackaging.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiProductPackaging.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.成品包装工序;
            this.bbiProductPackaging.Id = 6;
            this.bbiProductPackaging.Name = "bbiProductPackaging";
            this.bbiProductPackaging.Tag = 12166;
            this.bbiProductPackaging.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiProductPackaging.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiProductionOfMaterialAndManualInspection
            // 
            resources.ApplyResources(this.bbiProductionOfMaterialAndManualInspection, "bbiProductionOfMaterialAndManualInspection");
            this.bbiProductionOfMaterialAndManualInspection.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiProductionOfMaterialAndManualInspection.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiProductionOfMaterialAndManualInspection.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.有料生产_人工检查工序;
            this.bbiProductionOfMaterialAndManualInspection.Id = 7;
            this.bbiProductionOfMaterialAndManualInspection.Name = "bbiProductionOfMaterialAndManualInspection";
            this.bbiProductionOfMaterialAndManualInspection.Tag = 12180;
            this.bbiProductionOfMaterialAndManualInspection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiProductionOfMaterialAndManualInspection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiNoMaterialProcessingAndManualInspection
            // 
            resources.ApplyResources(this.bbiNoMaterialProcessingAndManualInspection, "bbiNoMaterialProcessingAndManualInspection");
            this.bbiNoMaterialProcessingAndManualInspection.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiNoMaterialProcessingAndManualInspection.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiNoMaterialProcessingAndManualInspection.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.无料加工_人工检查工序;
            this.bbiNoMaterialProcessingAndManualInspection.Id = 8;
            this.bbiNoMaterialProcessingAndManualInspection.Name = "bbiNoMaterialProcessingAndManualInspection";
            this.bbiNoMaterialProcessingAndManualInspection.Tag = 12182;
            this.bbiNoMaterialProcessingAndManualInspection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiNoMaterialProcessingAndManualInspection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiProductionOfMaterialAndMachineTesting
            // 
            resources.ApplyResources(this.bbiProductionOfMaterialAndMachineTesting, "bbiProductionOfMaterialAndMachineTesting");
            this.bbiProductionOfMaterialAndMachineTesting.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiProductionOfMaterialAndMachineTesting.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiProductionOfMaterialAndMachineTesting.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.有料生产_机器测试工序;
            this.bbiProductionOfMaterialAndMachineTesting.Id = 9;
            this.bbiProductionOfMaterialAndMachineTesting.Name = "bbiProductionOfMaterialAndMachineTesting";
            this.bbiProductionOfMaterialAndMachineTesting.Tag = 12221;
            this.bbiProductionOfMaterialAndMachineTesting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiProductionOfMaterialAndMachineTesting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiProductPackagingAndAccessory
            // 
            resources.ApplyResources(this.bbiProductPackagingAndAccessory, "bbiProductPackagingAndAccessory");
            this.bbiProductPackagingAndAccessory.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiProductPackagingAndAccessory.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiProductPackagingAndAccessory.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.成品包装_附件配套工序;
            this.bbiProductPackagingAndAccessory.Id = 10;
            this.bbiProductPackagingAndAccessory.Name = "bbiProductPackagingAndAccessory";
            this.bbiProductPackagingAndAccessory.Tag = 12222;
            this.bbiProductPackagingAndAccessory.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiProductPackagingAndAccessory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiVirtualComposite
            // 
            resources.ApplyResources(this.bbiVirtualComposite, "bbiVirtualComposite");
            this.bbiVirtualComposite.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiVirtualComposite.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiVirtualComposite.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.虚拟复合工序;
            this.bbiVirtualComposite.Id = 11;
            this.bbiVirtualComposite.Name = "bbiVirtualComposite";
            this.bbiVirtualComposite.Tag = 39490;
            this.bbiVirtualComposite.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiVirtualComposite.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiEnd
            // 
            resources.ApplyResources(this.bbiEnd, "bbiEnd");
            this.bbiEnd.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiEnd.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiEnd.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.End;
            this.bbiEnd.Id = 12;
            this.bbiEnd.Name = "bbiEnd";
            this.bbiEnd.Tag = 99;
            this.bbiEnd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiLink
            // 
            resources.ApplyResources(this.bbiLink, "bbiLink");
            this.bbiLink.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiLink.CategoryGuid = new System.Guid("b9d0cd77-a4ff-4502-9ac8-f9cf4ceaee4f");
            this.bbiLink.Glyph = global::IRAP.Client.GUI.MDM.Properties.Resources.line_arrow_end;
            this.bbiLink.Id = 13;
            this.bbiLink.Name = "bbiLink";
            this.bbiLink.Tag = 98;
            this.bbiLink.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemClick);
            // 
            // bbiResetLayout
            // 
            resources.ApplyResources(this.bbiResetLayout, "bbiResetLayout");
            this.bbiResetLayout.CategoryGuid = new System.Guid("a04e7f3e-e4a5-4061-827a-42fabc17b62c");
            this.bbiResetLayout.Id = 15;
            this.bbiResetLayout.Name = "bbiResetLayout";
            this.bbiResetLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiResetLayout_ItemClick);
            // 
            // barDockControlTop
            // 
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlTop.Appearance.FontSizeDelta")));
            this.barDockControlTop.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlTop.Appearance.FontStyleDelta")));
            this.barDockControlTop.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlTop.Appearance.GradientMode")));
            this.barDockControlTop.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlTop.Appearance.Image")));
            this.barDockControlTop.CausesValidation = false;
            this.toolTip.SetToolTip(this.barDockControlTop, resources.GetString("barDockControlTop.ToolTip"));
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlBottom.Appearance.FontSizeDelta")));
            this.barDockControlBottom.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlBottom.Appearance.FontStyleDelta")));
            this.barDockControlBottom.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlBottom.Appearance.GradientMode")));
            this.barDockControlBottom.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlBottom.Appearance.Image")));
            this.barDockControlBottom.CausesValidation = false;
            this.toolTip.SetToolTip(this.barDockControlBottom, resources.GetString("barDockControlBottom.ToolTip"));
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlLeft.Appearance.FontSizeDelta")));
            this.barDockControlLeft.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlLeft.Appearance.FontStyleDelta")));
            this.barDockControlLeft.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlLeft.Appearance.GradientMode")));
            this.barDockControlLeft.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlLeft.Appearance.Image")));
            this.barDockControlLeft.CausesValidation = false;
            this.toolTip.SetToolTip(this.barDockControlLeft, resources.GetString("barDockControlLeft.ToolTip"));
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlRight.Appearance.FontSizeDelta")));
            this.barDockControlRight.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlRight.Appearance.FontStyleDelta")));
            this.barDockControlRight.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlRight.Appearance.GradientMode")));
            this.barDockControlRight.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlRight.Appearance.Image")));
            this.barDockControlRight.CausesValidation = false;
            this.toolTip.SetToolTip(this.barDockControlRight, resources.GetString("barDockControlRight.ToolTip"));
            // 
            // bbiOperationChoice
            // 
            resources.ApplyResources(this.bbiOperationChoice, "bbiOperationChoice");
            this.bbiOperationChoice.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiOperationChoice.Id = 16;
            this.bbiOperationChoice.Name = "bbiOperationChoice";
            this.bbiOperationChoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiOperationChoice_ItemClick);
            // 
            // bbiProcessProperties
            // 
            resources.ApplyResources(this.bbiProcessProperties, "bbiProcessProperties");
            this.bbiProcessProperties.CategoryGuid = new System.Guid("01e60b0c-1bb3-4580-9933-5f2e8103e5ad");
            this.bbiProcessProperties.Id = 18;
            this.bbiProcessProperties.Name = "bbiProcessProperties";
            this.bbiProcessProperties.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiProcessProperties_ItemClick);
            // 
            // bbiDeleteNode
            // 
            resources.ApplyResources(this.bbiDeleteNode, "bbiDeleteNode");
            this.bbiDeleteNode.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiDeleteNode.Id = 20;
            this.bbiDeleteNode.Name = "bbiDeleteNode";
            this.bbiDeleteNode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDeleteNode_ItemClick);
            // 
            // bbiMethodStandard
            // 
            resources.ApplyResources(this.bbiMethodStandard, "bbiMethodStandard");
            this.bbiMethodStandard.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiMethodStandard.Id = 22;
            this.bbiMethodStandard.Name = "bbiMethodStandard";
            this.bbiMethodStandard.Tag = -354007;
            this.bbiMethodStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiInspectStandard
            // 
            resources.ApplyResources(this.bbiInspectStandard, "bbiInspectStandard");
            this.bbiInspectStandard.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiInspectStandard.Id = 23;
            this.bbiInspectStandard.Name = "bbiInspectStandard";
            this.bbiInspectStandard.Tag = -354008;
            this.bbiInspectStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiTestStandard
            // 
            resources.ApplyResources(this.bbiTestStandard, "bbiTestStandard");
            this.bbiTestStandard.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiTestStandard.Id = 24;
            this.bbiTestStandard.Name = "bbiTestStandard";
            this.bbiTestStandard.Tag = -354009;
            this.bbiTestStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiToolingStandard
            // 
            resources.ApplyResources(this.bbiToolingStandard, "bbiToolingStandard");
            this.bbiToolingStandard.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiToolingStandard.Id = 25;
            this.bbiToolingStandard.Name = "bbiToolingStandard";
            this.bbiToolingStandard.Tag = -354010;
            this.bbiToolingStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiLoadingSheet
            // 
            resources.ApplyResources(this.bbiLoadingSheet, "bbiLoadingSheet");
            this.bbiLoadingSheet.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiLoadingSheet.Id = 26;
            this.bbiLoadingSheet.Name = "bbiLoadingSheet";
            this.bbiLoadingSheet.Tag = -354011;
            this.bbiLoadingSheet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiUnloadingSheet
            // 
            resources.ApplyResources(this.bbiUnloadingSheet, "bbiUnloadingSheet");
            this.bbiUnloadingSheet.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiUnloadingSheet.Id = 27;
            this.bbiUnloadingSheet.Name = "bbiUnloadingSheet";
            this.bbiUnloadingSheet.Tag = -354012;
            this.bbiUnloadingSheet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiPackagingStandard
            // 
            resources.ApplyResources(this.bbiPackagingStandard, "bbiPackagingStandard");
            this.bbiPackagingStandard.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiPackagingStandard.Id = 28;
            this.bbiPackagingStandard.Name = "bbiPackagingStandard";
            this.bbiPackagingStandard.Tag = -354013;
            this.bbiPackagingStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiMFGPrograms
            // 
            resources.ApplyResources(this.bbiMFGPrograms, "bbiMFGPrograms");
            this.bbiMFGPrograms.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiMFGPrograms.Id = 29;
            this.bbiMFGPrograms.Name = "bbiMFGPrograms";
            this.bbiMFGPrograms.Tag = -373377;
            this.bbiMFGPrograms.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiFailureModes
            // 
            resources.ApplyResources(this.bbiFailureModes, "bbiFailureModes");
            this.bbiFailureModes.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiFailureModes.Id = 30;
            this.bbiFailureModes.Name = "bbiFailureModes";
            this.bbiFailureModes.Tag = -354014;
            this.bbiFailureModes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiOPStandard
            // 
            resources.ApplyResources(this.bbiOPStandard, "bbiOPStandard");
            this.bbiOPStandard.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiOPStandard.Id = 31;
            this.bbiOPStandard.Name = "bbiOPStandard";
            this.bbiOPStandard.Tag = -354015;
            this.bbiOPStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiEnvParamStandard
            // 
            resources.ApplyResources(this.bbiEnvParamStandard, "bbiEnvParamStandard");
            this.bbiEnvParamStandard.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiEnvParamStandard.Id = 32;
            this.bbiEnvParamStandard.Name = "bbiEnvParamStandard";
            this.bbiEnvParamStandard.Tag = -373386;
            this.bbiEnvParamStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiEnergyStandard
            // 
            resources.ApplyResources(this.bbiEnergyStandard, "bbiEnergyStandard");
            this.bbiEnergyStandard.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiEnergyStandard.Id = 33;
            this.bbiEnergyStandard.Name = "bbiEnergyStandard";
            this.bbiEnergyStandard.Tag = -373387;
            this.bbiEnergyStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiPrepareStandard
            // 
            resources.ApplyResources(this.bbiPrepareStandard, "bbiPrepareStandard");
            this.bbiPrepareStandard.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiPrepareStandard.Id = 34;
            this.bbiPrepareStandard.Name = "bbiPrepareStandard";
            this.bbiPrepareStandard.Tag = -373374;
            this.bbiPrepareStandard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiPokaYokeRules
            // 
            resources.ApplyResources(this.bbiPokaYokeRules, "bbiPokaYokeRules");
            this.bbiPokaYokeRules.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiPokaYokeRules.Id = 35;
            this.bbiPokaYokeRules.Name = "bbiPokaYokeRules";
            this.bbiPokaYokeRules.Tag = -354016;
            this.bbiPokaYokeRules.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiMethodDocuments
            // 
            resources.ApplyResources(this.bbiMethodDocuments, "bbiMethodDocuments");
            this.bbiMethodDocuments.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiMethodDocuments.Id = 36;
            this.bbiMethodDocuments.Name = "bbiMethodDocuments";
            this.bbiMethodDocuments.Tag = -373389;
            this.bbiMethodDocuments.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiSkillMatrix
            // 
            resources.ApplyResources(this.bbiSkillMatrix, "bbiSkillMatrix");
            this.bbiSkillMatrix.CategoryGuid = new System.Guid("b6b21380-5c70-4698-9514-fcb35ffaad03");
            this.bbiSkillMatrix.Id = 37;
            this.bbiSkillMatrix.Name = "bbiSkillMatrix";
            this.bbiSkillMatrix.Tag = -372154;
            this.bbiSkillMatrix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RowPropertiesMNG);
            // 
            // bbiDeleteLine
            // 
            resources.ApplyResources(this.bbiDeleteLine, "bbiDeleteLine");
            this.bbiDeleteLine.CategoryGuid = new System.Guid("01e60b0c-1bb3-4580-9933-5f2e8103e5ad");
            this.bbiDeleteLine.Id = 38;
            this.bbiDeleteLine.Name = "bbiDeleteLine";
            this.bbiDeleteLine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDeleteLine_ItemClick);
            // 
            // ppmNode
            // 
            this.ppmNode.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOperationChoice, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiMethodStandard, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiInspectStandard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiTestStandard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiToolingStandard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLoadingSheet),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiUnloadingSheet),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPackagingStandard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiMFGPrograms),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiFailureModes),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOPStandard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEnvParamStandard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEnergyStandard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrepareStandard),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPokaYokeRules),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiMethodDocuments),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSkillMatrix),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDeleteNode, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiResetLayout, true)});
            this.ppmNode.Manager = this.barManager;
            this.ppmNode.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("ppmNode.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.ppmNode.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ppmNode.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.ppmNode.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ppmNode.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.ppmNode.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("ppmNode.MenuAppearance.HeaderItemAppearance.Image")));
            this.ppmNode.Name = "ppmNode";
            // 
            // ppmLine
            // 
            this.ppmLine.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiProcessProperties),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDeleteLine, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiResetLayout, true)});
            this.ppmLine.Manager = this.barManager;
            this.ppmLine.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("ppmLine.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.ppmLine.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ppmLine.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.ppmLine.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ppmLine.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.ppmLine.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("ppmLine.MenuAppearance.HeaderItemAppearance.Image")));
            this.ppmLine.Name = "ppmLine";
            // 
            // ppmBlank
            // 
            this.ppmBlank.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiResetLayout, true)});
            this.ppmBlank.Manager = this.barManager;
            this.ppmBlank.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("ppmBlank.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.ppmBlank.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ppmBlank.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.ppmBlank.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ppmBlank.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.ppmBlank.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("ppmBlank.MenuAppearance.HeaderItemAppearance.Image")));
            this.ppmBlank.Name = "ppmBlank";
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PaintStyleName = "Skin";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // frmProductProcessManager_30
            // 
            resources.ApplyResources(this, "$this");
            this.toolTipController.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("frmProductProcessManager_30.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("frmProductProcessManager_30.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("frmProductProcessManager_30.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmProductProcessManager_30.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmProductProcessManager_30";
            this.toolTipController.SetTitle(this, resources.GetString("$this.Title"));
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.toolTipController.SetToolTip(this, resources.GetString("$this.ToolTip1"));
            this.toolTipController.SetToolTipIconType(this, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("$this.ToolTipIconType"))));
            this.Load += new System.EventHandler(this.frmProductProcessManager_30_Load);
            this.Shown += new System.EventHandler(this.frmProductProcessManager_30_Shown);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.splitContainerControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcProductList)).EndInit();
            this.gpcProductList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkFlow)).EndInit();
            this.pnlWorkFlow.ResumeLayout(false);
            this.pnlWorkFlow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkFlowCommand)).EndInit();
            this.pnlWorkFlowCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppmNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppmLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppmBlank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.GroupControl gpcProductList;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit edtFilter;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboProductType;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl grdProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvProducts;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnNodeCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnNodeName;
        private DevExpress.XtraEditors.LabelControl lblProductName;
        private DevExpress.XtraEditors.CheckEdit chkEffectiveType;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.PanelControl pnlWorkFlow;
        private DevExpress.XtraEditors.PanelControl pnlWorkFlowCommand;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barWorkFlowTools;
        private DevExpress.XtraBars.BarButtonItem bbiBegin;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiProductWithMaterial;
        private DevExpress.XtraBars.BarButtonItem bbiNoMaterialProcessing;
        private DevExpress.XtraBars.BarButtonItem bbiManualInspection;
        private DevExpress.XtraBars.BarButtonItem bbiMachineTesting;
        private DevExpress.XtraBars.BarButtonItem bbiTroubleShooting;
        private DevExpress.XtraBars.BarButtonItem bbiProductPackaging;
        private DevExpress.XtraBars.BarButtonItem bbiProductionOfMaterialAndManualInspection;
        private DevExpress.XtraBars.BarButtonItem bbiNoMaterialProcessingAndManualInspection;
        private DevExpress.XtraBars.BarButtonItem bbiProductionOfMaterialAndMachineTesting;
        private DevExpress.XtraBars.BarButtonItem bbiProductPackagingAndAccessory;
        private DevExpress.XtraBars.BarButtonItem bbiVirtualComposite;
        private DevExpress.XtraBars.BarButtonItem bbiEnd;
        private DevExpress.XtraBars.BarButtonItem bbiLink;
        private ProductProcessPanel productProcessPanel;
        private DevExpress.XtraBars.BarButtonItem bbiResetLayout;
        private System.Windows.Forms.ToolTip toolTip;
        private DevExpress.XtraBars.BarButtonItem bbiOperationChoice;
        private DevExpress.XtraBars.BarButtonItem bbiProcessProperties;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteNode;
        private DevExpress.XtraBars.PopupMenu ppmNode;
        private DevExpress.XtraBars.BarButtonItem bbiMethodStandard;
        private DevExpress.XtraBars.BarButtonItem bbiInspectStandard;
        private DevExpress.XtraBars.BarButtonItem bbiTestStandard;
        private DevExpress.XtraBars.BarButtonItem bbiToolingStandard;
        private DevExpress.XtraBars.BarButtonItem bbiLoadingSheet;
        private DevExpress.XtraBars.BarButtonItem bbiUnloadingSheet;
        private DevExpress.XtraBars.BarButtonItem bbiPackagingStandard;
        private DevExpress.XtraBars.BarButtonItem bbiMFGPrograms;
        private DevExpress.XtraBars.BarButtonItem bbiFailureModes;
        private DevExpress.XtraBars.BarButtonItem bbiOPStandard;
        private DevExpress.XtraBars.BarButtonItem bbiEnvParamStandard;
        private DevExpress.XtraBars.BarButtonItem bbiEnergyStandard;
        private DevExpress.XtraBars.BarButtonItem bbiPrepareStandard;
        private DevExpress.XtraBars.BarButtonItem bbiPokaYokeRules;
        private DevExpress.XtraBars.BarButtonItem bbiMethodDocuments;
        private DevExpress.XtraBars.BarButtonItem bbiSkillMatrix;
        private DevExpress.XtraBars.PopupMenu ppmLine;
        private DevExpress.XtraBars.PopupMenu ppmBlank;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteLine;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
    }
}
