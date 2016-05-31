namespace IRAP_FVS_MDVO.Controls
{
    partial class ucInspectStandard
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
            this.grdInspectStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvInspectStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnStandardOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStandardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStandardString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMiddleValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyForFirstInspection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyForInProcessInspection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnInProcessInspectionBatchSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyForLastInspection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFullInspection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.picProductImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdInspectStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvInspectStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // grdInspectStandards
            // 
            this.grdInspectStandards.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdInspectStandards.Location = new System.Drawing.Point(0, 0);
            this.grdInspectStandards.MainView = this.grdvInspectStandards;
            this.grdInspectStandards.Name = "grdInspectStandards";
            this.grdInspectStandards.Size = new System.Drawing.Size(397, 431);
            this.grdInspectStandards.TabIndex = 1;
            this.grdInspectStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvInspectStandards});
            // 
            // grdvInspectStandards
            // 
            this.grdvInspectStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvInspectStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvInspectStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvInspectStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvInspectStandards.Appearance.Row.Options.UseFont = true;
            this.grdvInspectStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnStandardOrdinal,
            this.grdclmnStandardName,
            this.grdclmnStandardString,
            this.grdclmnMiddleValue,
            this.grdclmnQtyForFirstInspection,
            this.grdclmnQtyForInProcessInspection,
            this.grdclmnInProcessInspectionBatchSize,
            this.grdclmnQtyForLastInspection,
            this.grdclmnFullInspection});
            this.grdvInspectStandards.GridControl = this.grdInspectStandards;
            this.grdvInspectStandards.Name = "grdvInspectStandards";
            this.grdvInspectStandards.OptionsBehavior.Editable = false;
            this.grdvInspectStandards.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvInspectStandards.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvInspectStandards.OptionsView.RowAutoHeight = true;
            this.grdvInspectStandards.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnStandardOrdinal
            // 
            this.grdclmnStandardOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnStandardOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnStandardOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStandardOrdinal.Caption = "序号";
            this.grdclmnStandardOrdinal.FieldName = "Ordinal";
            this.grdclmnStandardOrdinal.MaxWidth = 50;
            this.grdclmnStandardOrdinal.Name = "grdclmnStandardOrdinal";
            this.grdclmnStandardOrdinal.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnStandardOrdinal.OptionsFilter.AllowFilter = false;
            this.grdclmnStandardOrdinal.Visible = true;
            this.grdclmnStandardOrdinal.VisibleIndex = 0;
            this.grdclmnStandardOrdinal.Width = 25;
            // 
            // grdclmnStandardName
            // 
            this.grdclmnStandardName.Caption = "检查参数名称";
            this.grdclmnStandardName.FieldName = "ParameterName";
            this.grdclmnStandardName.Name = "grdclmnStandardName";
            this.grdclmnStandardName.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnStandardName.OptionsFilter.AllowFilter = false;
            this.grdclmnStandardName.Visible = true;
            this.grdclmnStandardName.VisibleIndex = 1;
            // 
            // grdclmnStandardString
            // 
            this.grdclmnStandardString.Caption = "检查参数标准";
            this.grdclmnStandardString.FieldName = "StandardString";
            this.grdclmnStandardString.Name = "grdclmnStandardString";
            this.grdclmnStandardString.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnStandardString.OptionsFilter.AllowFilter = false;
            this.grdclmnStandardString.Visible = true;
            this.grdclmnStandardString.VisibleIndex = 2;
            this.grdclmnStandardString.Width = 109;
            // 
            // grdclmnMiddleValue
            // 
            this.grdclmnMiddleValue.Caption = "中值";
            this.grdclmnMiddleValue.FieldName = "MiddleValue";
            this.grdclmnMiddleValue.Name = "grdclmnMiddleValue";
            this.grdclmnMiddleValue.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnMiddleValue.OptionsFilter.AllowFilter = false;
            this.grdclmnMiddleValue.Visible = true;
            this.grdclmnMiddleValue.VisibleIndex = 3;
            this.grdclmnMiddleValue.Width = 66;
            // 
            // grdclmnQtyForFirstInspection
            // 
            this.grdclmnQtyForFirstInspection.Caption = "首检应检数";
            this.grdclmnQtyForFirstInspection.FieldName = "QtyForFirstInspection";
            this.grdclmnQtyForFirstInspection.MaxWidth = 50;
            this.grdclmnQtyForFirstInspection.Name = "grdclmnQtyForFirstInspection";
            this.grdclmnQtyForFirstInspection.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnQtyForFirstInspection.OptionsFilter.AllowFilter = false;
            this.grdclmnQtyForFirstInspection.Visible = true;
            this.grdclmnQtyForFirstInspection.VisibleIndex = 4;
            this.grdclmnQtyForFirstInspection.Width = 20;
            // 
            // grdclmnQtyForInProcessInspection
            // 
            this.grdclmnQtyForInProcessInspection.Caption = "过程检应检数(每次)";
            this.grdclmnQtyForInProcessInspection.FieldName = "QtyForInProcessInspection";
            this.grdclmnQtyForInProcessInspection.MaxWidth = 50;
            this.grdclmnQtyForInProcessInspection.Name = "grdclmnQtyForInProcessInspection";
            this.grdclmnQtyForInProcessInspection.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnQtyForInProcessInspection.OptionsFilter.AllowFilter = false;
            this.grdclmnQtyForInProcessInspection.Visible = true;
            this.grdclmnQtyForInProcessInspection.VisibleIndex = 5;
            this.grdclmnQtyForInProcessInspection.Width = 20;
            // 
            // grdclmnInProcessInspectionBatchSize
            // 
            this.grdclmnInProcessInspectionBatchSize.Caption = "过程检批量";
            this.grdclmnInProcessInspectionBatchSize.FieldName = "InProcessInspectionBatchSize";
            this.grdclmnInProcessInspectionBatchSize.MaxWidth = 50;
            this.grdclmnInProcessInspectionBatchSize.Name = "grdclmnInProcessInspectionBatchSize";
            this.grdclmnInProcessInspectionBatchSize.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnInProcessInspectionBatchSize.OptionsFilter.AllowFilter = false;
            this.grdclmnInProcessInspectionBatchSize.Visible = true;
            this.grdclmnInProcessInspectionBatchSize.VisibleIndex = 6;
            this.grdclmnInProcessInspectionBatchSize.Width = 20;
            // 
            // grdclmnQtyForLastInspection
            // 
            this.grdclmnQtyForLastInspection.Caption = "末检应检数";
            this.grdclmnQtyForLastInspection.FieldName = "QtyForLastInspection";
            this.grdclmnQtyForLastInspection.MaxWidth = 50;
            this.grdclmnQtyForLastInspection.Name = "grdclmnQtyForLastInspection";
            this.grdclmnQtyForLastInspection.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnQtyForLastInspection.OptionsFilter.AllowFilter = false;
            this.grdclmnQtyForLastInspection.Visible = true;
            this.grdclmnQtyForLastInspection.VisibleIndex = 7;
            this.grdclmnQtyForLastInspection.Width = 20;
            // 
            // grdclmnFullInspection
            // 
            this.grdclmnFullInspection.Caption = "全检";
            this.grdclmnFullInspection.FieldName = "FullInspection";
            this.grdclmnFullInspection.MaxWidth = 50;
            this.grdclmnFullInspection.Name = "grdclmnFullInspection";
            this.grdclmnFullInspection.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnFullInspection.OptionsFilter.AllowFilter = false;
            this.grdclmnFullInspection.Visible = true;
            this.grdclmnFullInspection.VisibleIndex = 8;
            this.grdclmnFullInspection.Width = 20;
            // 
            // picProductImage
            // 
            this.picProductImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picProductImage.Location = new System.Drawing.Point(397, 0);
            this.picProductImage.Name = "picProductImage";
            this.picProductImage.Size = new System.Drawing.Size(178, 431);
            this.picProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProductImage.TabIndex = 2;
            this.picProductImage.TabStop = false;
            // 
            // ucInspectStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.picProductImage);
            this.Controls.Add(this.grdInspectStandards);
            this.Name = "ucInspectStandard";
            this.Size = new System.Drawing.Size(575, 431);
            this.Resize += new System.EventHandler(this.ucInspectStandard_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdInspectStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvInspectStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdInspectStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvInspectStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardString;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMiddleValue;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyForFirstInspection;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyForInProcessInspection;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnInProcessInspectionBatchSize;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyForLastInspection;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFullInspection;
        private System.Windows.Forms.PictureBox picProductImage;
    }
}
