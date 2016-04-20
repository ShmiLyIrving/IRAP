namespace IRAP.Client.GUI.MDM
{
    partial class frmPrepareStandardProperties
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
            this.grdStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT20LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluT20LeafID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnLowLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCriterion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluCriterion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnHighLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUnitOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRecordingMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ciicRecordingMode = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT20LeafID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluCriterion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ciicRecordingMode)).BeginInit();
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
            this.lblTitle.Text = "生产准备事项";
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
            this.panelControl1.Controls.Add(this.grdStandards);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 63);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(652, 440);
            this.panelControl1.TabIndex = 8;
            // 
            // grdStandards
            // 
            this.grdStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStandards.Location = new System.Drawing.Point(7, 7);
            this.grdStandards.MainView = this.grdvStandards;
            this.grdStandards.Name = "grdStandards";
            this.grdStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riluT20LeafID,
            this.riluCriterion,
            this.ciicRecordingMode});
            this.grdStandards.Size = new System.Drawing.Size(638, 426);
            this.grdStandards.TabIndex = 2;
            this.grdStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvStandards});
            // 
            // grdvStandards
            // 
            this.grdvStandards.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvStandards.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvStandards.Appearance.Row.Options.UseFont = true;
            this.grdvStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnT20LeafID,
            this.grdclmnLowLimit,
            this.grdclmnCriterion,
            this.grdclmnHighLimit,
            this.grdclmnScale,
            this.grdclmnUnitOfMeasure,
            this.grdclmnRecordingMode,
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
            this.grdvStandards.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvStandards_InitNewRow);
            this.grdvStandards.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grdvStandards_RowDeleted);
            this.grdvStandards.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdvStandards_RowUpdated);
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.Caption = "序号";
            this.grdclmnOrdinal.FieldName = "Level";
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
            this.grdclmnOrdinal.Width = 100;
            // 
            // grdclmnT20LeafID
            // 
            this.grdclmnT20LeafID.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT20LeafID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT20LeafID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT20LeafID.Caption = "生产准备项目";
            this.grdclmnT20LeafID.ColumnEdit = this.riluT20LeafID;
            this.grdclmnT20LeafID.FieldName = "T20LeafID";
            this.grdclmnT20LeafID.Name = "grdclmnT20LeafID";
            this.grdclmnT20LeafID.Visible = true;
            this.grdclmnT20LeafID.VisibleIndex = 1;
            this.grdclmnT20LeafID.Width = 180;
            // 
            // riluT20LeafID
            // 
            this.riluT20LeafID.AutoHeight = false;
            this.riluT20LeafID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.riluT20LeafID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluT20LeafID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NodeName", "Name1")});
            this.riluT20LeafID.Name = "riluT20LeafID";
            this.riluT20LeafID.NullText = "";
            this.riluT20LeafID.ShowFooter = false;
            this.riluT20LeafID.ShowHeader = false;
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
            // grdclmnRecordingMode
            // 
            this.grdclmnRecordingMode.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnRecordingMode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRecordingMode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRecordingMode.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnRecordingMode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRecordingMode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRecordingMode.Caption = "采集方式";
            this.grdclmnRecordingMode.ColumnEdit = this.ciicRecordingMode;
            this.grdclmnRecordingMode.FieldName = "RecordingMode";
            this.grdclmnRecordingMode.Name = "grdclmnRecordingMode";
            this.grdclmnRecordingMode.Visible = true;
            this.grdclmnRecordingMode.VisibleIndex = 7;
            // 
            // ciicRecordingMode
            // 
            this.ciicRecordingMode.AutoHeight = false;
            this.ciicRecordingMode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ciicRecordingMode.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("不记录", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("换型时记录", 1, -1)});
            this.ciicRecordingMode.Name = "ciicRecordingMode";
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
            // frmPrepareStandardProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmPrepareStandardProperties";
            this.PropertiesType = "生产准备事项";
            this.RowSetID = 13;
            this.Text = "生产准备事项行集属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT20LeafID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluCriterion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ciicRecordingMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT20LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluT20LeafID;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLowLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCriterion;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluCriterion;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnHighLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScale;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUnitOfMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRecordingMode;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox ciicRecordingMode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
    }
}
