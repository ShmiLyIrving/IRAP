namespace IRAP.Client.GUI.MDM
{
    partial class frmLoadingStandardProperties
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grdOPStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvOPStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnToolingOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStepNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSlotCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT101LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT102LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUsageQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUnitOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnBackflushOnMR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riicBackflushOnMR = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdclmnSlotCapacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFeedingAlarmingThreshold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnEstimatedScrapRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riteNumericRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grdclmnScrapingAlarmingThreshold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFluxLowLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFluxHighLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFeedingTimeOffsetLowLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFeedingTimeOffsetHighLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnComponentLocList = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluT112LeafID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnLeafCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLeafName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riieSOPImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.riicbManOrMachine = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.riluT112LeafID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOPStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOPStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicBackflushOnMR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteNumericRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT112LeafID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riieSOPImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicbManOrMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT112LeafID)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTitle.Text = "工装使用标准";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            // 
            // chkEffectiveType
            // 
            this.chkEffectiveType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEffectiveType.Properties.Appearance.Options.UseFont = true;
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grdOPStandards);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 63);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(652, 440);
            this.panelControl1.TabIndex = 10;
            // 
            // grdOPStandards
            // 
            this.grdOPStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOPStandards.Location = new System.Drawing.Point(7, 7);
            this.grdOPStandards.MainView = this.grdvOPStandards;
            this.grdOPStandards.Name = "grdOPStandards";
            this.grdOPStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.risluT112LeafID,
            this.riieSOPImage,
            this.riicbManOrMachine,
            this.riluT112LeafID,
            this.riicBackflushOnMR,
            this.riteNumericRate});
            this.grdOPStandards.Size = new System.Drawing.Size(638, 426);
            this.grdOPStandards.TabIndex = 2;
            this.grdOPStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOPStandards});
            // 
            // grdvOPStandards
            // 
            this.grdvOPStandards.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvOPStandards.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvOPStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvOPStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvOPStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvOPStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvOPStandards.Appearance.Row.Options.UseFont = true;
            this.grdvOPStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnToolingOrdinal,
            this.grdclmnStepNo,
            this.grdclmnSlotCode,
            this.grdclmnT101LeafID,
            this.grdclmnT102LeafID,
            this.grdclmnUsageQty,
            this.grdclmnScale,
            this.grdclmnUnitOfMeasure,
            this.grdclmnBackflushOnMR,
            this.grdclmnSlotCapacity,
            this.grdclmnFeedingAlarmingThreshold,
            this.grdclmnEstimatedScrapRate,
            this.grdclmnScrapingAlarmingThreshold,
            this.grdclmnFluxLowLimit,
            this.grdclmnFluxHighLimit,
            this.grdclmnFeedingTimeOffsetLowLimit,
            this.grdclmnFeedingTimeOffsetHighLimit,
            this.grdclmnComponentLocList,
            this.grdclmnReference});
            this.grdvOPStandards.GridControl = this.grdOPStandards;
            this.grdvOPStandards.Name = "grdvOPStandards";
            this.grdvOPStandards.OptionsBehavior.Editable = false;
            this.grdvOPStandards.OptionsSelection.InvertSelection = true;
            this.grdvOPStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvOPStandards.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvOPStandards.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvOPStandards.OptionsView.EnableAppearanceOddRow = true;
            this.grdvOPStandards.OptionsView.RowAutoHeight = true;
            this.grdvOPStandards.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnToolingOrdinal
            // 
            this.grdclmnToolingOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnToolingOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnToolingOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnToolingOrdinal.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnToolingOrdinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnToolingOrdinal.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnToolingOrdinal.Caption = "序号";
            this.grdclmnToolingOrdinal.FieldName = "Level";
            this.grdclmnToolingOrdinal.Name = "grdclmnToolingOrdinal";
            this.grdclmnToolingOrdinal.Visible = true;
            this.grdclmnToolingOrdinal.VisibleIndex = 0;
            this.grdclmnToolingOrdinal.Width = 100;
            // 
            // grdclmnStepNo
            // 
            this.grdclmnStepNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnStepNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnStepNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStepNo.Caption = "工序步骤";
            this.grdclmnStepNo.FieldName = "StepNo";
            this.grdclmnStepNo.Name = "grdclmnStepNo";
            this.grdclmnStepNo.Visible = true;
            this.grdclmnStepNo.VisibleIndex = 1;
            // 
            // grdclmnSlotCode
            // 
            this.grdclmnSlotCode.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnSlotCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnSlotCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnSlotCode.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnSlotCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnSlotCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnSlotCode.Caption = "料槽编号";
            this.grdclmnSlotCode.FieldName = "SlotCode";
            this.grdclmnSlotCode.Name = "grdclmnSlotCode";
            this.grdclmnSlotCode.Visible = true;
            this.grdclmnSlotCode.VisibleIndex = 2;
            this.grdclmnSlotCode.Width = 180;
            // 
            // grdclmnT101LeafID
            // 
            this.grdclmnT101LeafID.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT101LeafID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT101LeafID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT101LeafID.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT101LeafID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT101LeafID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT101LeafID.Caption = "原辅材料";
            this.grdclmnT101LeafID.FieldName = "T101LeafID";
            this.grdclmnT101LeafID.Name = "grdclmnT101LeafID";
            this.grdclmnT101LeafID.Visible = true;
            this.grdclmnT101LeafID.VisibleIndex = 3;
            this.grdclmnT101LeafID.Width = 95;
            // 
            // grdclmnT102LeafID
            // 
            this.grdclmnT102LeafID.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT102LeafID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT102LeafID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT102LeafID.Caption = "半成品";
            this.grdclmnT102LeafID.FieldName = "T102LeafID";
            this.grdclmnT102LeafID.Name = "grdclmnT102LeafID";
            this.grdclmnT102LeafID.Visible = true;
            this.grdclmnT102LeafID.VisibleIndex = 4;
            // 
            // grdclmnUsageQty
            // 
            this.grdclmnUsageQty.Caption = "用量或配方百分比";
            this.grdclmnUsageQty.FieldName = "UsageQty";
            this.grdclmnUsageQty.Name = "grdclmnUsageQty";
            this.grdclmnUsageQty.Visible = true;
            this.grdclmnUsageQty.VisibleIndex = 5;
            // 
            // grdclmnScale
            // 
            this.grdclmnScale.Caption = "放大数量级";
            this.grdclmnScale.FieldName = "Scale";
            this.grdclmnScale.Name = "grdclmnScale";
            this.grdclmnScale.Visible = true;
            this.grdclmnScale.VisibleIndex = 6;
            // 
            // grdclmnUnitOfMeasure
            // 
            this.grdclmnUnitOfMeasure.Caption = "计量单位";
            this.grdclmnUnitOfMeasure.FieldName = "UnitOfMeasure";
            this.grdclmnUnitOfMeasure.Name = "grdclmnUnitOfMeasure";
            this.grdclmnUnitOfMeasure.Visible = true;
            this.grdclmnUnitOfMeasure.VisibleIndex = 7;
            // 
            // grdclmnBackflushOnMR
            // 
            this.grdclmnBackflushOnMR.Caption = "实时扣料";
            this.grdclmnBackflushOnMR.ColumnEdit = this.riicBackflushOnMR;
            this.grdclmnBackflushOnMR.FieldName = "BackflushOnMR";
            this.grdclmnBackflushOnMR.Name = "grdclmnBackflushOnMR";
            this.grdclmnBackflushOnMR.Visible = true;
            this.grdclmnBackflushOnMR.VisibleIndex = 8;
            // 
            // riicBackflushOnMR
            // 
            this.riicBackflushOnMR.AutoHeight = false;
            this.riicBackflushOnMR.Caption = "实时扣料";
            this.riicBackflushOnMR.Name = "riicBackflushOnMR";
            // 
            // grdclmnSlotCapacity
            // 
            this.grdclmnSlotCapacity.Caption = "料槽容量";
            this.grdclmnSlotCapacity.FieldName = "SlotCapacity";
            this.grdclmnSlotCapacity.Name = "grdclmnSlotCapacity";
            this.grdclmnSlotCapacity.Visible = true;
            this.grdclmnSlotCapacity.VisibleIndex = 9;
            // 
            // grdclmnFeedingAlarmingThreshold
            // 
            this.grdclmnFeedingAlarmingThreshold.Caption = "加接料告警阀门值";
            this.grdclmnFeedingAlarmingThreshold.FieldName = "FeedingAlarmingThreshold";
            this.grdclmnFeedingAlarmingThreshold.Name = "grdclmnFeedingAlarmingThreshold";
            this.grdclmnFeedingAlarmingThreshold.Visible = true;
            this.grdclmnFeedingAlarmingThreshold.VisibleIndex = 10;
            // 
            // grdclmnEstimatedScrapRate
            // 
            this.grdclmnEstimatedScrapRate.Caption = "预估抛料率";
            this.grdclmnEstimatedScrapRate.ColumnEdit = this.riteNumericRate;
            this.grdclmnEstimatedScrapRate.FieldName = "EstimatedScrapRate";
            this.grdclmnEstimatedScrapRate.Name = "grdclmnEstimatedScrapRate";
            this.grdclmnEstimatedScrapRate.Visible = true;
            this.grdclmnEstimatedScrapRate.VisibleIndex = 11;
            // 
            // riteNumericRate
            // 
            this.riteNumericRate.AutoHeight = false;
            this.riteNumericRate.EditFormat.FormatString = "##.####";
            this.riteNumericRate.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riteNumericRate.Name = "riteNumericRate";
            // 
            // grdclmnScrapingAlarmingThreshold
            // 
            this.grdclmnScrapingAlarmingThreshold.Caption = "抛料告警阀门值";
            this.grdclmnScrapingAlarmingThreshold.ColumnEdit = this.riteNumericRate;
            this.grdclmnScrapingAlarmingThreshold.FieldName = "ScrapingAlarmingThreshold";
            this.grdclmnScrapingAlarmingThreshold.Name = "grdclmnScrapingAlarmingThreshold";
            this.grdclmnScrapingAlarmingThreshold.Visible = true;
            this.grdclmnScrapingAlarmingThreshold.VisibleIndex = 12;
            // 
            // grdclmnFluxLowLimit
            // 
            this.grdclmnFluxLowLimit.Caption = "流量低限值(流程制造用)";
            this.grdclmnFluxLowLimit.FieldName = "FluxLowLimit";
            this.grdclmnFluxLowLimit.Name = "grdclmnFluxLowLimit";
            this.grdclmnFluxLowLimit.Visible = true;
            this.grdclmnFluxLowLimit.VisibleIndex = 13;
            // 
            // grdclmnFluxHighLimit
            // 
            this.grdclmnFluxHighLimit.Caption = "流量高限值(流程制造用)";
            this.grdclmnFluxHighLimit.FieldName = "FluxHighLimit";
            this.grdclmnFluxHighLimit.Name = "grdclmnFluxHighLimit";
            this.grdclmnFluxHighLimit.Visible = true;
            this.grdclmnFluxHighLimit.VisibleIndex = 14;
            // 
            // grdclmnFeedingTimeOffsetLowLimit
            // 
            this.grdclmnFeedingTimeOffsetLowLimit.Caption = "加料时间偏移量低限(ms)";
            this.grdclmnFeedingTimeOffsetLowLimit.FieldName = "FeedingTimeOffsetLowLimit";
            this.grdclmnFeedingTimeOffsetLowLimit.Name = "grdclmnFeedingTimeOffsetLowLimit";
            this.grdclmnFeedingTimeOffsetLowLimit.Visible = true;
            this.grdclmnFeedingTimeOffsetLowLimit.VisibleIndex = 15;
            // 
            // grdclmnFeedingTimeOffsetHighLimit
            // 
            this.grdclmnFeedingTimeOffsetHighLimit.Caption = "加料时间偏移量高限(ms)";
            this.grdclmnFeedingTimeOffsetHighLimit.FieldName = "FeedingTimeOffsetHighLimit";
            this.grdclmnFeedingTimeOffsetHighLimit.Name = "grdclmnFeedingTimeOffsetHighLimit";
            this.grdclmnFeedingTimeOffsetHighLimit.Visible = true;
            this.grdclmnFeedingTimeOffsetHighLimit.VisibleIndex = 16;
            // 
            // grdclmnComponentLocList
            // 
            this.grdclmnComponentLocList.Caption = "部件位置清单";
            this.grdclmnComponentLocList.FieldName = "ComponentLocList";
            this.grdclmnComponentLocList.Name = "grdclmnComponentLocList";
            this.grdclmnComponentLocList.Visible = true;
            this.grdclmnComponentLocList.VisibleIndex = 17;
            // 
            // grdclmnReference
            // 
            this.grdclmnReference.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnReference.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnReference.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnReference.Caption = "是否模板数据";
            this.grdclmnReference.FieldName = "Reference";
            this.grdclmnReference.Name = "grdclmnReference";
            // 
            // risluT112LeafID
            // 
            this.risluT112LeafID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.risluT112LeafID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluT112LeafID.DisplayMember = "LeafName";
            this.risluT112LeafID.Name = "risluT112LeafID";
            this.risluT112LeafID.NullText = "";
            this.risluT112LeafID.ValueMember = "LeafID";
            this.risluT112LeafID.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnLeafCode,
            this.grdclmnLeafName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnLeafCode
            // 
            this.grdclmnLeafCode.Caption = "动作要素代码";
            this.grdclmnLeafCode.FieldName = "Code";
            this.grdclmnLeafCode.Name = "grdclmnLeafCode";
            // 
            // grdclmnLeafName
            // 
            this.grdclmnLeafName.Caption = "动作要素名称";
            this.grdclmnLeafName.FieldName = "LeafName";
            this.grdclmnLeafName.Name = "grdclmnLeafName";
            // 
            // riieSOPImage
            // 
            this.riieSOPImage.AutoHeight = false;
            this.riieSOPImage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riieSOPImage.Name = "riieSOPImage";
            // 
            // riicbManOrMachine
            // 
            this.riicbManOrMachine.AutoHeight = false;
            this.riicbManOrMachine.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riicbManOrMachine.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("人", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("设备", 2, -1)});
            this.riicbManOrMachine.Name = "riicbManOrMachine";
            // 
            // riluT112LeafID
            // 
            this.riluT112LeafID.AutoHeight = false;
            this.riluT112LeafID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.riluT112LeafID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluT112LeafID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LeafName", "Name13")});
            this.riluT112LeafID.Name = "riluT112LeafID";
            this.riluT112LeafID.NullText = "";
            this.riluT112LeafID.ShowFooter = false;
            this.riluT112LeafID.ShowHeader = false;
            this.riluT112LeafID.ValueMember = "LeafID";
            // 
            // frmLoadingStandardProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmLoadingStandardProperties";
            this.PropertiesType = "物料装料标准";
            this.RowSetID = 5;
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOPStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOPStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicBackflushOnMR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteNumericRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT112LeafID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riieSOPImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicbManOrMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT112LeafID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdOPStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOPStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToolingOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStepNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSlotCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT101LeafID;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT102LeafID;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUsageQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScale;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUnitOfMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnBackflushOnMR;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riicBackflushOnMR;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSlotCapacity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFeedingAlarmingThreshold;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEstimatedScrapRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riteNumericRate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScrapingAlarmingThreshold;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFluxLowLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFluxHighLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFeedingTimeOffsetLowLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFeedingTimeOffsetHighLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnComponentLocList;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluT112LeafID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafName;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit riieSOPImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicbManOrMachine;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluT112LeafID;
    }
}
