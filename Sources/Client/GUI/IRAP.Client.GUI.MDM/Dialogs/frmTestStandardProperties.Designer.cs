namespace IRAP.Client.GUI.MDM
{
    partial class frmTestStandardProperties
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
            this.grdclmnToolingOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT128LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluT128LeafID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.grdvT128LeafIDView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnLeafCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLeafName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLowLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCriterion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluCriterion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnHighLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUnitOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riieSOPImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.riicbManOrMachine = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.riicBackflushOnMR = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.riteNumericRate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT128LeafID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvT128LeafIDView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluCriterion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riieSOPImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicbManOrMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicBackflushOnMR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteNumericRate)).BeginInit();
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
            this.lblTitle.Text = "机器测试标准";
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
            this.panelControl1.TabIndex = 9;
            // 
            // grdStandards
            // 
            this.grdStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStandards.Location = new System.Drawing.Point(7, 7);
            this.grdStandards.MainView = this.grdvStandards;
            this.grdStandards.Name = "grdStandards";
            this.grdStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.risluT128LeafID,
            this.riieSOPImage,
            this.riicbManOrMachine,
            this.riluCriterion,
            this.riicBackflushOnMR,
            this.riteNumericRate});
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
            this.grdclmnToolingOrdinal,
            this.grdclmnT128LeafID,
            this.grdclmnLowLimit,
            this.grdclmnCriterion,
            this.grdclmnHighLimit,
            this.grdclmnScale,
            this.grdclmnUnitOfMeasure,
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
            // grdclmnT128LeafID
            // 
            this.grdclmnT128LeafID.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT128LeafID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT128LeafID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT128LeafID.Caption = "测试项目";
            this.grdclmnT128LeafID.ColumnEdit = this.risluT128LeafID;
            this.grdclmnT128LeafID.FieldName = "T128LeafID";
            this.grdclmnT128LeafID.Name = "grdclmnT128LeafID";
            this.grdclmnT128LeafID.Visible = true;
            this.grdclmnT128LeafID.VisibleIndex = 1;
            // 
            // risluT128LeafID
            // 
            this.risluT128LeafID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.risluT128LeafID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluT128LeafID.DisplayMember = "LeafName";
            this.risluT128LeafID.Name = "risluT128LeafID";
            this.risluT128LeafID.NullText = "";
            this.risluT128LeafID.ValueMember = "LeafID";
            this.risluT128LeafID.View = this.grdvT128LeafIDView;
            // 
            // grdvT128LeafIDView
            // 
            this.grdvT128LeafIDView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnLeafCode,
            this.grdclmnLeafName});
            this.grdvT128LeafIDView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdvT128LeafIDView.Name = "grdvT128LeafIDView";
            this.grdvT128LeafIDView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvT128LeafIDView.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnLeafCode
            // 
            this.grdclmnLeafCode.Caption = "测试项编号";
            this.grdclmnLeafCode.FieldName = "Code";
            this.grdclmnLeafCode.Name = "grdclmnLeafCode";
            // 
            // grdclmnLeafName
            // 
            this.grdclmnLeafName.Caption = "测试项名称";
            this.grdclmnLeafName.FieldName = "LeafName";
            this.grdclmnLeafName.Name = "grdclmnLeafName";
            // 
            // grdclmnLowLimit
            // 
            this.grdclmnLowLimit.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnLowLimit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnLowLimit.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLowLimit.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnLowLimit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnLowLimit.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLowLimit.Caption = "低限值";
            this.grdclmnLowLimit.FieldName = "LowLimit";
            this.grdclmnLowLimit.Name = "grdclmnLowLimit";
            this.grdclmnLowLimit.Visible = true;
            this.grdclmnLowLimit.VisibleIndex = 2;
            this.grdclmnLowLimit.Width = 180;
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
            this.grdclmnCriterion.Width = 95;
            // 
            // riluCriterion
            // 
            this.riluCriterion.AutoHeight = false;
            this.riluCriterion.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.riluCriterion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluCriterion.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeHint", "标准")});
            this.riluCriterion.DisplayMember = "TypeHint";
            this.riluCriterion.Name = "riluCriterion";
            this.riluCriterion.NullText = "";
            this.riluCriterion.ShowFooter = false;
            this.riluCriterion.ShowHeader = false;
            this.riluCriterion.ValueMember = "TypeCode";
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
            this.grdclmnScale.Caption = "放大数量级";
            this.grdclmnScale.FieldName = "Scale";
            this.grdclmnScale.Name = "grdclmnScale";
            this.grdclmnScale.Visible = true;
            this.grdclmnScale.VisibleIndex = 5;
            // 
            // grdclmnUnitOfMeasure
            // 
            this.grdclmnUnitOfMeasure.Caption = "计量单位";
            this.grdclmnUnitOfMeasure.FieldName = "UnitOfMeasure";
            this.grdclmnUnitOfMeasure.Name = "grdclmnUnitOfMeasure";
            this.grdclmnUnitOfMeasure.Visible = true;
            this.grdclmnUnitOfMeasure.VisibleIndex = 6;
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
            // riicBackflushOnMR
            // 
            this.riicBackflushOnMR.AutoHeight = false;
            this.riicBackflushOnMR.Caption = "实时扣料";
            this.riicBackflushOnMR.Name = "riicBackflushOnMR";
            // 
            // riteNumericRate
            // 
            this.riteNumericRate.AutoHeight = false;
            this.riteNumericRate.EditFormat.FormatString = "##.####";
            this.riteNumericRate.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riteNumericRate.Name = "riteNumericRate";
            // 
            // frmTestStandardProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmTestStandardProperties";
            this.PropertiesType = "机器测试标准";
            this.RowSetID = 3;
            this.Text = "机器测试标准属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT128LeafID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvT128LeafIDView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluCriterion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riieSOPImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicbManOrMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicBackflushOnMR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riteNumericRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToolingOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT128LeafID;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLowLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCriterion;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnHighLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScale;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUnitOfMeasure;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riicBackflushOnMR;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riteNumericRate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluT128LeafID;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvT128LeafIDView;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafName;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit riieSOPImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicbManOrMachine;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluCriterion;
    }
}
