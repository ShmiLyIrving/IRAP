namespace IRAP.Client.GUI.MDM
{
    partial class frmMethodStandardProperties
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
            this.grdMethodStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvMethodStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnStandardOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStandardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluStandardName = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.risluStandardNameView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLowLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCriterion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluCriterion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnHighLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUnitOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRecordingMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluRecordingMode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnSamplingCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRTDBDSLinkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRTDBTagName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluStandardName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMethodStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMethodStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluStandardName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluStandardNameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluCriterion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluRecordingMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluStandardName)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTitle.Size = new System.Drawing.Size(652, 63);
            this.lblTitle.Text = "工艺参数标准";
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
            this.panelControl1.Controls.Add(this.grdMethodStandards);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 63);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(652, 440);
            this.panelControl1.TabIndex = 6;
            // 
            // grdMethodStandards
            // 
            this.grdMethodStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMethodStandards.Location = new System.Drawing.Point(7, 7);
            this.grdMethodStandards.MainView = this.grdvMethodStandards;
            this.grdMethodStandards.Name = "grdMethodStandards";
            this.grdMethodStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riluStandardName,
            this.riluCriterion,
            this.riluRecordingMode,
            this.risluStandardName});
            this.grdMethodStandards.Size = new System.Drawing.Size(638, 426);
            this.grdMethodStandards.TabIndex = 2;
            this.grdMethodStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvMethodStandards});
            // 
            // grdvMethodStandards
            // 
            this.grdvMethodStandards.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvMethodStandards.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvMethodStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvMethodStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvMethodStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvMethodStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvMethodStandards.Appearance.Row.Options.UseFont = true;
            this.grdvMethodStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnStandardOrdinal,
            this.grdclmnStandardName,
            this.grdclmnLowLimit,
            this.grdclmnCriterion,
            this.grdclmnHighLimit,
            this.grdclmnScale,
            this.grdclmnUnitOfMeasure,
            this.grdclmnRecordingMode,
            this.grdclmnSamplingCycle,
            this.grdclmnRTDBDSLinkID,
            this.grdclmnRTDBTagName,
            this.grdclmnReference});
            this.grdvMethodStandards.GridControl = this.grdMethodStandards;
            this.grdvMethodStandards.Name = "grdvMethodStandards";
            this.grdvMethodStandards.OptionsBehavior.Editable = false;
            this.grdvMethodStandards.OptionsSelection.InvertSelection = true;
            this.grdvMethodStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvMethodStandards.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvMethodStandards.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvMethodStandards.OptionsView.EnableAppearanceOddRow = true;
            this.grdvMethodStandards.OptionsView.RowAutoHeight = true;
            this.grdvMethodStandards.OptionsView.ShowGroupPanel = false;
            this.grdvMethodStandards.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvMethodStandards_InitNewRow);
            this.grdvMethodStandards.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grdvMethodStandards_RowDeleted);
            this.grdvMethodStandards.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdvMethodStandards_RowUpdated);
            // 
            // grdclmnStandardOrdinal
            // 
            this.grdclmnStandardOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnStandardOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnStandardOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStandardOrdinal.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnStandardOrdinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnStandardOrdinal.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStandardOrdinal.Caption = "序号";
            this.grdclmnStandardOrdinal.FieldName = "Level";
            this.grdclmnStandardOrdinal.Name = "grdclmnStandardOrdinal";
            this.grdclmnStandardOrdinal.Visible = true;
            this.grdclmnStandardOrdinal.VisibleIndex = 0;
            this.grdclmnStandardOrdinal.Width = 100;
            // 
            // grdclmnStandardName
            // 
            this.grdclmnStandardName.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnStandardName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnStandardName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStandardName.Caption = "工艺参数名称";
            this.grdclmnStandardName.ColumnEdit = this.risluStandardName;
            this.grdclmnStandardName.FieldName = "T20LeafID";
            this.grdclmnStandardName.Name = "grdclmnStandardName";
            this.grdclmnStandardName.Visible = true;
            this.grdclmnStandardName.VisibleIndex = 1;
            this.grdclmnStandardName.Width = 180;
            // 
            // risluStandardName
            // 
            this.risluStandardName.AutoHeight = false;
            this.risluStandardName.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.risluStandardName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluStandardName.DisplayMember = "CodeAndName";
            this.risluStandardName.Name = "risluStandardName";
            this.risluStandardName.NullText = "";
            this.risluStandardName.ValueMember = "LeafID";
            this.risluStandardName.View = this.risluStandardNameView;
            // 
            // risluStandardNameView
            // 
            this.risluStandardNameView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.risluStandardNameView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.risluStandardNameView.Name = "risluStandardNameView";
            this.risluStandardNameView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.risluStandardNameView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "工艺参数名称";
            this.gridColumn2.FieldName = "CodeAndName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // grdclmnLowLimit
            // 
            this.grdclmnLowLimit.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnLowLimit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnLowLimit.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLowLimit.Caption = "低限值";
            this.grdclmnLowLimit.FieldName = "LowLimit";
            this.grdclmnLowLimit.Name = "grdclmnLowLimit";
            this.grdclmnLowLimit.Visible = true;
            this.grdclmnLowLimit.VisibleIndex = 2;
            // 
            // grdclmnCriterion
            // 
            this.grdclmnCriterion.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnCriterion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCriterion.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnCriterion.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnCriterion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCriterion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnCriterion.Caption = "标准";
            this.grdclmnCriterion.ColumnEdit = this.riluCriterion;
            this.grdclmnCriterion.FieldName = "Criterion";
            this.grdclmnCriterion.Name = "grdclmnCriterion";
            this.grdclmnCriterion.Visible = true;
            this.grdclmnCriterion.VisibleIndex = 3;
            // 
            // riluCriterion
            // 
            this.riluCriterion.AutoHeight = false;
            this.riluCriterion.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.riluCriterion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluCriterion.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeHint", "Name2")});
            this.riluCriterion.Name = "riluCriterion";
            this.riluCriterion.ShowFooter = false;
            this.riluCriterion.ShowHeader = false;
            // 
            // grdclmnHighLimit
            // 
            this.grdclmnHighLimit.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnHighLimit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnHighLimit.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnHighLimit.Caption = "高限值";
            this.grdclmnHighLimit.FieldName = "HighLimit";
            this.grdclmnHighLimit.Name = "grdclmnHighLimit";
            this.grdclmnHighLimit.Visible = true;
            this.grdclmnHighLimit.VisibleIndex = 4;
            // 
            // grdclmnScale
            // 
            this.grdclmnScale.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnScale.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScale.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScale.Caption = "放大数量级";
            this.grdclmnScale.FieldName = "Scale";
            this.grdclmnScale.Name = "grdclmnScale";
            this.grdclmnScale.Visible = true;
            this.grdclmnScale.VisibleIndex = 5;
            // 
            // grdclmnUnitOfMeasure
            // 
            this.grdclmnUnitOfMeasure.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnUnitOfMeasure.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnUnitOfMeasure.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUnitOfMeasure.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnUnitOfMeasure.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnUnitOfMeasure.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUnitOfMeasure.Caption = "计量单位";
            this.grdclmnUnitOfMeasure.FieldName = "UnitOfMeasure";
            this.grdclmnUnitOfMeasure.Name = "grdclmnUnitOfMeasure";
            this.grdclmnUnitOfMeasure.Visible = true;
            this.grdclmnUnitOfMeasure.VisibleIndex = 6;
            // 
            // grdclmnRecordingMode
            // 
            this.grdclmnRecordingMode.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnRecordingMode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRecordingMode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRecordingMode.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnRecordingMode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRecordingMode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRecordingMode.Caption = "参数记录方式";
            this.grdclmnRecordingMode.ColumnEdit = this.riluRecordingMode;
            this.grdclmnRecordingMode.FieldName = "RecordingMode";
            this.grdclmnRecordingMode.Name = "grdclmnRecordingMode";
            this.grdclmnRecordingMode.Visible = true;
            this.grdclmnRecordingMode.VisibleIndex = 7;
            // 
            // riluRecordingMode
            // 
            this.riluRecordingMode.AutoHeight = false;
            this.riluRecordingMode.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.riluRecordingMode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluRecordingMode.Name = "riluRecordingMode";
            this.riluRecordingMode.ShowFooter = false;
            this.riluRecordingMode.ShowHeader = false;
            // 
            // grdclmnSamplingCycle
            // 
            this.grdclmnSamplingCycle.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnSamplingCycle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnSamplingCycle.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnSamplingCycle.Caption = "参数采样周期";
            this.grdclmnSamplingCycle.FieldName = "SamplingCycle";
            this.grdclmnSamplingCycle.Name = "grdclmnSamplingCycle";
            this.grdclmnSamplingCycle.Visible = true;
            this.grdclmnSamplingCycle.VisibleIndex = 8;
            // 
            // grdclmnRTDBDSLinkID
            // 
            this.grdclmnRTDBDSLinkID.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnRTDBDSLinkID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRTDBDSLinkID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRTDBDSLinkID.Caption = "实时数据库数据源连接标识";
            this.grdclmnRTDBDSLinkID.FieldName = "RTDBDSLinkID";
            this.grdclmnRTDBDSLinkID.Name = "grdclmnRTDBDSLinkID";
            this.grdclmnRTDBDSLinkID.Visible = true;
            this.grdclmnRTDBDSLinkID.VisibleIndex = 9;
            // 
            // grdclmnRTDBTagName
            // 
            this.grdclmnRTDBTagName.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnRTDBTagName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRTDBTagName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRTDBTagName.Caption = "实时数据库采集点标识";
            this.grdclmnRTDBTagName.FieldName = "RTDBTagName";
            this.grdclmnRTDBTagName.Name = "grdclmnRTDBTagName";
            this.grdclmnRTDBTagName.Visible = true;
            this.grdclmnRTDBTagName.VisibleIndex = 10;
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
            // riluStandardName
            // 
            this.riluStandardName.AutoHeight = false;
            this.riluStandardName.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.riluStandardName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluStandardName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NodeName", "Name1")});
            this.riluStandardName.Name = "riluStandardName";
            this.riluStandardName.ShowFooter = false;
            this.riluStandardName.ShowHeader = false;
            // 
            // frmMethodStandardProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmMethodStandardProperties";
            this.PropertiesType = "工艺参数标准";
            this.RowSetID = 1;
            this.Text = "工艺参数标准属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMethodStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMethodStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluStandardName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluStandardNameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluCriterion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluRecordingMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluStandardName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdMethodStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvMethodStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluStandardName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLowLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCriterion;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluCriterion;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnHighLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScale;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUnitOfMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRecordingMode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluRecordingMode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSamplingCycle;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRTDBDSLinkID;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRTDBTagName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluStandardName;
        private DevExpress.XtraGrid.Views.Grid.GridView risluStandardNameView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
