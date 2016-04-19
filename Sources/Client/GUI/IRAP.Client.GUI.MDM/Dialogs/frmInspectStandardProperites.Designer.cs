namespace IRAP.Client.GUI.MDM
{
    partial class frmInspectStandardProperites
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
            this.grdInspectStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvInspectStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnStandardOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStandardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluStandardName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnLowLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCriterion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluCriterion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnHighLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUnitOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyForFirstInspection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyForInProcessInspection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnInProcessInspectionBatchSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyForLastInspection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFullInspection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riceFullInspection = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.riluRecordingMode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInspectStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvInspectStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluStandardName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluCriterion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceFullInspection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluRecordingMode)).BeginInit();
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
            this.lblTitle.Text = "质量检查标准";
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
            this.panelControl1.Controls.Add(this.grdInspectStandards);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 63);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(652, 440);
            this.panelControl1.TabIndex = 6;
            // 
            // grdInspectStandards
            // 
            this.grdInspectStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInspectStandards.Location = new System.Drawing.Point(7, 7);
            this.grdInspectStandards.MainView = this.grdvInspectStandards;
            this.grdInspectStandards.Name = "grdInspectStandards";
            this.grdInspectStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riluStandardName,
            this.riluCriterion,
            this.riluRecordingMode,
            this.riceFullInspection});
            this.grdInspectStandards.Size = new System.Drawing.Size(638, 426);
            this.grdInspectStandards.TabIndex = 2;
            this.grdInspectStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvInspectStandards});
            // 
            // grdvInspectStandards
            // 
            this.grdvInspectStandards.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvInspectStandards.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvInspectStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvInspectStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvInspectStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvInspectStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvInspectStandards.Appearance.Row.Options.UseFont = true;
            this.grdvInspectStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnStandardOrdinal,
            this.grdclmnStandardName,
            this.grdclmnLowLimit,
            this.grdclmnCriterion,
            this.grdclmnHighLimit,
            this.grdclmnScale,
            this.grdclmnUnitOfMeasure,
            this.grdclmnQtyForFirstInspection,
            this.grdclmnQtyForInProcessInspection,
            this.grdclmnInProcessInspectionBatchSize,
            this.grdclmnQtyForLastInspection,
            this.grdclmnReference,
            this.grdclmnFullInspection});
            this.grdvInspectStandards.GridControl = this.grdInspectStandards;
            this.grdvInspectStandards.Name = "grdvInspectStandards";
            this.grdvInspectStandards.OptionsBehavior.Editable = false;
            this.grdvInspectStandards.OptionsSelection.InvertSelection = true;
            this.grdvInspectStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvInspectStandards.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvInspectStandards.OptionsView.RowAutoHeight = true;
            this.grdvInspectStandards.OptionsView.ShowGroupPanel = false;
            this.grdvInspectStandards.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvInspectStandards_InitNewRow);
            this.grdvInspectStandards.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grdvInspectStandards_RowDeleted);
            this.grdvInspectStandards.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdvInspectStandards_RowUpdated);
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
            this.grdclmnStandardName.Caption = "质量参数名称";
            this.grdclmnStandardName.ColumnEdit = this.riluStandardName;
            this.grdclmnStandardName.FieldName = "T20LeafID";
            this.grdclmnStandardName.Name = "grdclmnStandardName";
            this.grdclmnStandardName.Visible = true;
            this.grdclmnStandardName.VisibleIndex = 1;
            this.grdclmnStandardName.Width = 180;
            // 
            // riluStandardName
            // 
            this.riluStandardName.AutoHeight = false;
            this.riluStandardName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluStandardName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NodeName", "Name1")});
            this.riluStandardName.Name = "riluStandardName";
            this.riluStandardName.NullText = "";
            this.riluStandardName.ShowFooter = false;
            this.riluStandardName.ShowHeader = false;
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
            this.riluCriterion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluCriterion.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeHint", "Name2")});
            this.riluCriterion.Name = "riluCriterion";
            this.riluCriterion.NullText = "";
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
            // grdclmnQtyForFirstInspection
            // 
            this.grdclmnQtyForFirstInspection.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQtyForFirstInspection.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnQtyForFirstInspection.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyForFirstInspection.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnQtyForFirstInspection.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnQtyForFirstInspection.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyForFirstInspection.Caption = "首检应检数";
            this.grdclmnQtyForFirstInspection.FieldName = "QtyForFirstInspection";
            this.grdclmnQtyForFirstInspection.Name = "grdclmnQtyForFirstInspection";
            this.grdclmnQtyForFirstInspection.Visible = true;
            this.grdclmnQtyForFirstInspection.VisibleIndex = 7;
            // 
            // grdclmnQtyForInProcessInspection
            // 
            this.grdclmnQtyForInProcessInspection.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnQtyForInProcessInspection.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnQtyForInProcessInspection.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyForInProcessInspection.Caption = "过程检应检数(每次)";
            this.grdclmnQtyForInProcessInspection.FieldName = "QtyForInProcessInspection";
            this.grdclmnQtyForInProcessInspection.Name = "grdclmnQtyForInProcessInspection";
            this.grdclmnQtyForInProcessInspection.Visible = true;
            this.grdclmnQtyForInProcessInspection.VisibleIndex = 8;
            // 
            // grdclmnInProcessInspectionBatchSize
            // 
            this.grdclmnInProcessInspectionBatchSize.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnInProcessInspectionBatchSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnInProcessInspectionBatchSize.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnInProcessInspectionBatchSize.Caption = "过程检批量";
            this.grdclmnInProcessInspectionBatchSize.FieldName = "InProcessInspectionBatchSize";
            this.grdclmnInProcessInspectionBatchSize.Name = "grdclmnInProcessInspectionBatchSize";
            this.grdclmnInProcessInspectionBatchSize.Visible = true;
            this.grdclmnInProcessInspectionBatchSize.VisibleIndex = 9;
            // 
            // grdclmnQtyForLastInspection
            // 
            this.grdclmnQtyForLastInspection.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnQtyForLastInspection.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnQtyForLastInspection.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyForLastInspection.Caption = "末检应检数";
            this.grdclmnQtyForLastInspection.FieldName = "QtyForLastInspection";
            this.grdclmnQtyForLastInspection.Name = "grdclmnQtyForLastInspection";
            this.grdclmnQtyForLastInspection.Visible = true;
            this.grdclmnQtyForLastInspection.VisibleIndex = 10;
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
            // grdclmnFullInspection
            // 
            this.grdclmnFullInspection.Caption = "全检";
            this.grdclmnFullInspection.ColumnEdit = this.riceFullInspection;
            this.grdclmnFullInspection.FieldName = "FullInspection";
            this.grdclmnFullInspection.Name = "grdclmnFullInspection";
            this.grdclmnFullInspection.Visible = true;
            this.grdclmnFullInspection.VisibleIndex = 11;
            // 
            // riceFullInspection
            // 
            this.riceFullInspection.AutoHeight = false;
            this.riceFullInspection.Caption = "全检";
            this.riceFullInspection.DisplayValueChecked = "是";
            this.riceFullInspection.DisplayValueUnchecked = "否";
            this.riceFullInspection.Name = "riceFullInspection";
            // 
            // riluRecordingMode
            // 
            this.riluRecordingMode.AutoHeight = false;
            this.riluRecordingMode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluRecordingMode.Name = "riluRecordingMode";
            this.riluRecordingMode.NullText = "";
            this.riluRecordingMode.ShowFooter = false;
            this.riluRecordingMode.ShowHeader = false;
            // 
            // frmInspectStandardProperites
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmInspectStandardProperites";
            this.PropertiesType = "质量检查标准";
            this.RowSetID = 2;
            this.Text = "质量检查标准属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInspectStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvInspectStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluStandardName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluCriterion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceFullInspection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluRecordingMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdInspectStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvInspectStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluStandardName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLowLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCriterion;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluCriterion;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnHighLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScale;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUnitOfMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyForFirstInspection;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyForInProcessInspection;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnInProcessInspectionBatchSize;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyForLastInspection;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFullInspection;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riceFullInspection;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluRecordingMode;
    }
}
