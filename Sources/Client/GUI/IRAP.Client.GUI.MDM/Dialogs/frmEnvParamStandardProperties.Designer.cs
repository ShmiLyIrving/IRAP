namespace IRAP.Client.GUI.MDM
{
    partial class frmEnvParamStandardProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvParamStandardProperties));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grdStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT20LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluParameterName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnLowLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCriterion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluCriterion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnHighLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUnitOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCollectingMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ciicCollectingMode = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grdclmnCollectingCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluParameterName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluCriterion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ciicCollectingMode)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lblTitle.Appearance.BackColor")));
            this.lblTitle.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblTitle.Appearance.Font")));
            this.lblTitle.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblTitle.Appearance.FontSizeDelta")));
            this.lblTitle.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblTitle.Appearance.FontStyleDelta")));
            this.lblTitle.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblTitle.Appearance.ForeColor")));
            this.lblTitle.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblTitle.Appearance.GradientMode")));
            this.lblTitle.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblTitle.Appearance.Image")));
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            // 
            // chkEffectiveType
            // 
            resources.ApplyResources(this.chkEffectiveType, "chkEffectiveType");
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
            // panelControl1
            // 
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.toolTipController.SetAllowHtmlText(this.panelControl1, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("panelControl1.AllowHtmlText"))));
            this.panelControl1.Controls.Add(this.grdStandards);
            this.panelControl1.Name = "panelControl1";
            this.toolTipController.SetTitle(this.panelControl1, resources.GetString("panelControl1.Title"));
            this.toolTipController.SetToolTip(this.panelControl1, resources.GetString("panelControl1.ToolTip"));
            this.toolTipController.SetToolTipIconType(this.panelControl1, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("panelControl1.ToolTipIconType"))));
            // 
            // grdStandards
            // 
            resources.ApplyResources(this.grdStandards, "grdStandards");
            this.grdStandards.EmbeddedNavigator.AccessibleDescription = resources.GetString("grdStandards.EmbeddedNavigator.AccessibleDescription");
            this.grdStandards.EmbeddedNavigator.AccessibleName = resources.GetString("grdStandards.EmbeddedNavigator.AccessibleName");
            this.grdStandards.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("grdStandards.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.grdStandards.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("grdStandards.EmbeddedNavigator.Anchor")));
            this.grdStandards.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grdStandards.EmbeddedNavigator.BackgroundImage")));
            this.grdStandards.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("grdStandards.EmbeddedNavigator.BackgroundImageLayout")));
            this.grdStandards.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("grdStandards.EmbeddedNavigator.ImeMode")));
            this.grdStandards.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("grdStandards.EmbeddedNavigator.MaximumSize")));
            this.grdStandards.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("grdStandards.EmbeddedNavigator.TextLocation")));
            this.grdStandards.EmbeddedNavigator.ToolTip = resources.GetString("grdStandards.EmbeddedNavigator.ToolTip");
            this.grdStandards.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("grdStandards.EmbeddedNavigator.ToolTipIconType")));
            this.grdStandards.EmbeddedNavigator.ToolTipTitle = resources.GetString("grdStandards.EmbeddedNavigator.ToolTipTitle");
            this.grdStandards.MainView = this.grdvStandards;
            this.grdStandards.Name = "grdStandards";
            this.grdStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riluParameterName,
            this.riluCriterion,
            this.ciicCollectingMode});
            this.grdStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvStandards});
            // 
            // grdvStandards
            // 
            this.grdvStandards.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("grdvStandards.Appearance.HeaderPanel.Font")));
            this.grdvStandards.Appearance.HeaderPanel.FontSizeDelta = ((int)(resources.GetObject("grdvStandards.Appearance.HeaderPanel.FontSizeDelta")));
            this.grdvStandards.Appearance.HeaderPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdvStandards.Appearance.HeaderPanel.FontStyleDelta")));
            this.grdvStandards.Appearance.HeaderPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdvStandards.Appearance.HeaderPanel.GradientMode")));
            this.grdvStandards.Appearance.HeaderPanel.Image = ((System.Drawing.Image)(resources.GetObject("grdvStandards.Appearance.HeaderPanel.Image")));
            this.grdvStandards.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvStandards.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("grdvStandards.Appearance.Row.Font")));
            this.grdvStandards.Appearance.Row.FontSizeDelta = ((int)(resources.GetObject("grdvStandards.Appearance.Row.FontSizeDelta")));
            this.grdvStandards.Appearance.Row.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdvStandards.Appearance.Row.FontStyleDelta")));
            this.grdvStandards.Appearance.Row.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdvStandards.Appearance.Row.GradientMode")));
            this.grdvStandards.Appearance.Row.Image = ((System.Drawing.Image)(resources.GetObject("grdvStandards.Appearance.Row.Image")));
            this.grdvStandards.Appearance.Row.Options.UseFont = true;
            resources.ApplyResources(this.grdvStandards, "grdvStandards");
            this.grdvStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnT20LeafID,
            this.grdclmnLowLimit,
            this.grdclmnCriterion,
            this.grdclmnHighLimit,
            this.grdclmnScale,
            this.grdclmnUnitOfMeasure,
            this.grdclmnCollectingMode,
            this.grdclmnCollectingCycle,
            this.grdclmnReference});
            this.grdvStandards.GridControl = this.grdStandards;
            this.grdvStandards.Name = "grdvStandards";
            this.grdvStandards.OptionsBehavior.Editable = false;
            this.grdvStandards.OptionsSelection.InvertSelection = true;
            this.grdvStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvStandards.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvStandards.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvStandards.OptionsView.EnableAppearanceOddRow = true;
            this.grdvStandards.OptionsView.RowAutoHeight = true;
            this.grdvStandards.OptionsView.ShowGroupPanel = false;
            this.grdvStandards.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvEnvParamStandards_InitNewRow);
            this.grdvStandards.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grdvEnvParamStandards_RowDeleted);
            this.grdvStandards.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdvEnvParamStandards_RowUpdated);
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("grdclmnOrdinal.AppearanceCell.FontSizeDelta")));
            this.grdclmnOrdinal.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnOrdinal.AppearanceCell.FontStyleDelta")));
            this.grdclmnOrdinal.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnOrdinal.AppearanceCell.GradientMode")));
            this.grdclmnOrdinal.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnOrdinal.AppearanceCell.Image")));
            this.grdclmnOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnOrdinal.AppearanceHeader.FontSizeDelta")));
            this.grdclmnOrdinal.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnOrdinal.AppearanceHeader.FontStyleDelta")));
            this.grdclmnOrdinal.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnOrdinal.AppearanceHeader.GradientMode")));
            this.grdclmnOrdinal.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnOrdinal.AppearanceHeader.Image")));
            this.grdclmnOrdinal.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnOrdinal, "grdclmnOrdinal");
            this.grdclmnOrdinal.FieldName = "Level";
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnT20LeafID
            // 
            this.grdclmnT20LeafID.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnT20LeafID.AppearanceHeader.FontSizeDelta")));
            this.grdclmnT20LeafID.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnT20LeafID.AppearanceHeader.FontStyleDelta")));
            this.grdclmnT20LeafID.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnT20LeafID.AppearanceHeader.GradientMode")));
            this.grdclmnT20LeafID.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnT20LeafID.AppearanceHeader.Image")));
            this.grdclmnT20LeafID.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT20LeafID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT20LeafID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnT20LeafID, "grdclmnT20LeafID");
            this.grdclmnT20LeafID.ColumnEdit = this.riluParameterName;
            this.grdclmnT20LeafID.FieldName = "T20LeafID";
            this.grdclmnT20LeafID.Name = "grdclmnT20LeafID";
            this.grdclmnT20LeafID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // riluParameterName
            // 
            resources.ApplyResources(this.riluParameterName, "riluParameterName");
            this.riluParameterName.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.riluParameterName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riluParameterName.Buttons"))))});
            this.riluParameterName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("riluParameterName.Columns"), resources.GetString("riluParameterName.Columns1"))});
            this.riluParameterName.Name = "riluParameterName";
            this.riluParameterName.ShowFooter = false;
            this.riluParameterName.ShowHeader = false;
            // 
            // grdclmnLowLimit
            // 
            this.grdclmnLowLimit.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnLowLimit.AppearanceHeader.FontSizeDelta")));
            this.grdclmnLowLimit.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnLowLimit.AppearanceHeader.FontStyleDelta")));
            this.grdclmnLowLimit.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnLowLimit.AppearanceHeader.GradientMode")));
            this.grdclmnLowLimit.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnLowLimit.AppearanceHeader.Image")));
            this.grdclmnLowLimit.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnLowLimit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnLowLimit.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnLowLimit, "grdclmnLowLimit");
            this.grdclmnLowLimit.FieldName = "LowLimit";
            this.grdclmnLowLimit.Name = "grdclmnLowLimit";
            this.grdclmnLowLimit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnCriterion
            // 
            this.grdclmnCriterion.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("grdclmnCriterion.AppearanceCell.FontSizeDelta")));
            this.grdclmnCriterion.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnCriterion.AppearanceCell.FontStyleDelta")));
            this.grdclmnCriterion.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnCriterion.AppearanceCell.GradientMode")));
            this.grdclmnCriterion.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnCriterion.AppearanceCell.Image")));
            this.grdclmnCriterion.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnCriterion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCriterion.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnCriterion.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnCriterion.AppearanceHeader.FontSizeDelta")));
            this.grdclmnCriterion.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnCriterion.AppearanceHeader.FontStyleDelta")));
            this.grdclmnCriterion.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnCriterion.AppearanceHeader.GradientMode")));
            this.grdclmnCriterion.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnCriterion.AppearanceHeader.Image")));
            this.grdclmnCriterion.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnCriterion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCriterion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnCriterion, "grdclmnCriterion");
            this.grdclmnCriterion.ColumnEdit = this.riluCriterion;
            this.grdclmnCriterion.FieldName = "Criterion";
            this.grdclmnCriterion.Name = "grdclmnCriterion";
            this.grdclmnCriterion.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // riluCriterion
            // 
            resources.ApplyResources(this.riluCriterion, "riluCriterion");
            this.riluCriterion.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.riluCriterion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riluCriterion.Buttons"))))});
            this.riluCriterion.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("riluCriterion.Columns"), resources.GetString("riluCriterion.Columns1"))});
            this.riluCriterion.Name = "riluCriterion";
            this.riluCriterion.ShowFooter = false;
            this.riluCriterion.ShowHeader = false;
            // 
            // grdclmnHighLimit
            // 
            this.grdclmnHighLimit.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnHighLimit.AppearanceHeader.FontSizeDelta")));
            this.grdclmnHighLimit.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnHighLimit.AppearanceHeader.FontStyleDelta")));
            this.grdclmnHighLimit.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnHighLimit.AppearanceHeader.GradientMode")));
            this.grdclmnHighLimit.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnHighLimit.AppearanceHeader.Image")));
            this.grdclmnHighLimit.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnHighLimit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnHighLimit.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnHighLimit, "grdclmnHighLimit");
            this.grdclmnHighLimit.FieldName = "HighLimit";
            this.grdclmnHighLimit.Name = "grdclmnHighLimit";
            this.grdclmnHighLimit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnScale
            // 
            this.grdclmnScale.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnScale.AppearanceHeader.FontSizeDelta")));
            this.grdclmnScale.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnScale.AppearanceHeader.FontStyleDelta")));
            this.grdclmnScale.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnScale.AppearanceHeader.GradientMode")));
            this.grdclmnScale.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnScale.AppearanceHeader.Image")));
            this.grdclmnScale.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnScale.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScale.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnScale, "grdclmnScale");
            this.grdclmnScale.FieldName = "Scale";
            this.grdclmnScale.Name = "grdclmnScale";
            this.grdclmnScale.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnUnitOfMeasure
            // 
            this.grdclmnUnitOfMeasure.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("grdclmnUnitOfMeasure.AppearanceCell.FontSizeDelta")));
            this.grdclmnUnitOfMeasure.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnUnitOfMeasure.AppearanceCell.FontStyleDelta")));
            this.grdclmnUnitOfMeasure.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnUnitOfMeasure.AppearanceCell.GradientMode")));
            this.grdclmnUnitOfMeasure.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnUnitOfMeasure.AppearanceCell.Image")));
            this.grdclmnUnitOfMeasure.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnUnitOfMeasure.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnUnitOfMeasure.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUnitOfMeasure.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnUnitOfMeasure.AppearanceHeader.FontSizeDelta")));
            this.grdclmnUnitOfMeasure.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnUnitOfMeasure.AppearanceHeader.FontStyleDelta")));
            this.grdclmnUnitOfMeasure.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnUnitOfMeasure.AppearanceHeader.GradientMode")));
            this.grdclmnUnitOfMeasure.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnUnitOfMeasure.AppearanceHeader.Image")));
            this.grdclmnUnitOfMeasure.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnUnitOfMeasure.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnUnitOfMeasure.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnUnitOfMeasure, "grdclmnUnitOfMeasure");
            this.grdclmnUnitOfMeasure.FieldName = "UnitOfMeasure";
            this.grdclmnUnitOfMeasure.Name = "grdclmnUnitOfMeasure";
            this.grdclmnUnitOfMeasure.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnCollectingMode
            // 
            this.grdclmnCollectingMode.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("grdclmnCollectingMode.AppearanceCell.FontSizeDelta")));
            this.grdclmnCollectingMode.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnCollectingMode.AppearanceCell.FontStyleDelta")));
            this.grdclmnCollectingMode.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnCollectingMode.AppearanceCell.GradientMode")));
            this.grdclmnCollectingMode.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnCollectingMode.AppearanceCell.Image")));
            this.grdclmnCollectingMode.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnCollectingMode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCollectingMode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnCollectingMode.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnCollectingMode.AppearanceHeader.FontSizeDelta")));
            this.grdclmnCollectingMode.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnCollectingMode.AppearanceHeader.FontStyleDelta")));
            this.grdclmnCollectingMode.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnCollectingMode.AppearanceHeader.GradientMode")));
            this.grdclmnCollectingMode.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnCollectingMode.AppearanceHeader.Image")));
            this.grdclmnCollectingMode.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnCollectingMode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCollectingMode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnCollectingMode, "grdclmnCollectingMode");
            this.grdclmnCollectingMode.ColumnEdit = this.ciicCollectingMode;
            this.grdclmnCollectingMode.FieldName = "RecordingMode";
            this.grdclmnCollectingMode.Name = "grdclmnCollectingMode";
            this.grdclmnCollectingMode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // ciicCollectingMode
            // 
            resources.ApplyResources(this.ciicCollectingMode, "ciicCollectingMode");
            this.ciicCollectingMode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ciicCollectingMode.Buttons"))))});
            this.ciicCollectingMode.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("ciicCollectingMode.Items"), ((object)(resources.GetObject("ciicCollectingMode.Items1"))), ((int)(resources.GetObject("ciicCollectingMode.Items2")))),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(resources.GetString("ciicCollectingMode.Items3"), ((object)(resources.GetObject("ciicCollectingMode.Items4"))), ((int)(resources.GetObject("ciicCollectingMode.Items5"))))});
            this.ciicCollectingMode.Name = "ciicCollectingMode";
            // 
            // grdclmnCollectingCycle
            // 
            this.grdclmnCollectingCycle.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnCollectingCycle.AppearanceHeader.FontSizeDelta")));
            this.grdclmnCollectingCycle.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnCollectingCycle.AppearanceHeader.FontStyleDelta")));
            this.grdclmnCollectingCycle.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnCollectingCycle.AppearanceHeader.GradientMode")));
            this.grdclmnCollectingCycle.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnCollectingCycle.AppearanceHeader.Image")));
            this.grdclmnCollectingCycle.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnCollectingCycle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCollectingCycle.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnCollectingCycle, "grdclmnCollectingCycle");
            this.grdclmnCollectingCycle.FieldName = "SamplingCycle";
            this.grdclmnCollectingCycle.Name = "grdclmnCollectingCycle";
            this.grdclmnCollectingCycle.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnReference
            // 
            this.grdclmnReference.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnReference.AppearanceHeader.FontSizeDelta")));
            this.grdclmnReference.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnReference.AppearanceHeader.FontStyleDelta")));
            this.grdclmnReference.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnReference.AppearanceHeader.GradientMode")));
            this.grdclmnReference.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnReference.AppearanceHeader.Image")));
            this.grdclmnReference.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnReference.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnReference.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnReference, "grdclmnReference");
            this.grdclmnReference.FieldName = "Reference";
            this.grdclmnReference.Name = "grdclmnReference";
            // 
            // frmEnvParamStandardProperties
            // 
            resources.ApplyResources(this, "$this");
            this.toolTipController.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("frmEnvParamStandardProperties.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("frmEnvParamStandardProperties.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("frmEnvParamStandardProperties.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmEnvParamStandardProperties.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.panelControl1);
            this.Name = "frmEnvParamStandardProperties";
            this.PropertiesType = "Environmental parameter standard";
            this.RowSetID = 11;
            this.toolTipController.SetTitle(this, resources.GetString("$this.Title"));
            this.toolTipController.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.toolTipController.SetToolTipIconType(this, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("$this.ToolTipIconType"))));
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluParameterName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluCriterion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ciicCollectingMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT20LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluParameterName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLowLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCriterion;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluCriterion;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnHighLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScale;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUnitOfMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCollectingMode;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox ciicCollectingMode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCollectingCycle;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
    }
}
