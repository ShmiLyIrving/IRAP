namespace IRAP_FVS_MDVO.Controls
{
    partial class ucMethodStandard
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
            this.grdMethodStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvMethodStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnStandardOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStandardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStandardValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMiddleValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdMethodStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMethodStandards)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // grdMethodStandards
            // 
            this.grdMethodStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMethodStandards.Location = new System.Drawing.Point(5, 5);
            this.grdMethodStandards.MainView = this.grdvMethodStandards;
            this.grdMethodStandards.Name = "grdMethodStandards";
            this.grdMethodStandards.Size = new System.Drawing.Size(397, 277);
            this.grdMethodStandards.TabIndex = 0;
            this.grdMethodStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvMethodStandards});
            // 
            // grdvMethodStandards
            // 
            this.grdvMethodStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvMethodStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvMethodStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvMethodStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvMethodStandards.Appearance.Row.Options.UseFont = true;
            this.grdvMethodStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnStandardOrdinal,
            this.grdclmnStandardName,
            this.grdclmnStandardValue,
            this.grdclmnMiddleValue});
            this.grdvMethodStandards.GridControl = this.grdMethodStandards;
            this.grdvMethodStandards.Name = "grdvMethodStandards";
            this.grdvMethodStandards.OptionsBehavior.Editable = false;
            this.grdvMethodStandards.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvMethodStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvMethodStandards.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvMethodStandards.OptionsView.RowAutoHeight = true;
            this.grdvMethodStandards.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnStandardOrdinal
            // 
            this.grdclmnStandardOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnStandardOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnStandardOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStandardOrdinal.Caption = "序号";
            this.grdclmnStandardOrdinal.FieldName = "Ordinal";
            this.grdclmnStandardOrdinal.Name = "grdclmnStandardOrdinal";
            this.grdclmnStandardOrdinal.Visible = true;
            this.grdclmnStandardOrdinal.VisibleIndex = 0;
            this.grdclmnStandardOrdinal.Width = 100;
            // 
            // grdclmnStandardName
            // 
            this.grdclmnStandardName.Caption = "工艺参数名称";
            this.grdclmnStandardName.FieldName = "ParameterName";
            this.grdclmnStandardName.Name = "grdclmnStandardName";
            this.grdclmnStandardName.Visible = true;
            this.grdclmnStandardName.VisibleIndex = 1;
            this.grdclmnStandardName.Width = 180;
            // 
            // grdclmnStandardValue
            // 
            this.grdclmnStandardValue.Caption = "参数标准";
            this.grdclmnStandardValue.FieldName = "StandardString";
            this.grdclmnStandardValue.Name = "grdclmnStandardValue";
            this.grdclmnStandardValue.Visible = true;
            this.grdclmnStandardValue.VisibleIndex = 2;
            // 
            // grdclmnMiddleValue
            // 
            this.grdclmnMiddleValue.Caption = "中值";
            this.grdclmnMiddleValue.FieldName = "MiddleValue";
            this.grdclmnMiddleValue.Name = "grdclmnMiddleValue";
            this.grdclmnMiddleValue.Visible = true;
            this.grdclmnMiddleValue.VisibleIndex = 3;
            // 
            // ucMethodStandard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grdMethodStandards);
            this.Name = "ucMethodStandard";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(407, 287);
            ((System.ComponentModel.ISupportInitialize)(this.grdMethodStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMethodStandards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMethodStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvMethodStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardValue;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMiddleValue;
    }
}
