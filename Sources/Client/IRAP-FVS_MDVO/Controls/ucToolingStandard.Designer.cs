namespace IRAP_FVS_MDVO.Controls
{
    partial class ucToolingStandard
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
            this.grdToolingStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvToolingStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnToolingOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnToolingModelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLifeControlMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluLifeControlMode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnLifeLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdToolingStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvToolingStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluLifeControlMode)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // grdToolingStandards
            // 
            this.grdToolingStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdToolingStandards.Location = new System.Drawing.Point(0, 0);
            this.grdToolingStandards.MainView = this.grdvToolingStandards;
            this.grdToolingStandards.Name = "grdToolingStandards";
            this.grdToolingStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riluLifeControlMode});
            this.grdToolingStandards.Size = new System.Drawing.Size(563, 346);
            this.grdToolingStandards.TabIndex = 1;
            this.grdToolingStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvToolingStandards});
            // 
            // grdvToolingStandards
            // 
            this.grdvToolingStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvToolingStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvToolingStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvToolingStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvToolingStandards.Appearance.Row.Options.UseFont = true;
            this.grdvToolingStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnToolingOrdinal,
            this.grdclmnToolingModelName,
            this.grdclmnLifeControlMode,
            this.grdclmnLifeLimit});
            this.grdvToolingStandards.GridControl = this.grdToolingStandards;
            this.grdvToolingStandards.Name = "grdvToolingStandards";
            this.grdvToolingStandards.OptionsBehavior.Editable = false;
            this.grdvToolingStandards.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvToolingStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvToolingStandards.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvToolingStandards.OptionsView.RowAutoHeight = true;
            this.grdvToolingStandards.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnToolingOrdinal
            // 
            this.grdclmnToolingOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnToolingOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnToolingOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnToolingOrdinal.Caption = "序号";
            this.grdclmnToolingOrdinal.FieldName = "Ordinal";
            this.grdclmnToolingOrdinal.Name = "grdclmnToolingOrdinal";
            this.grdclmnToolingOrdinal.Visible = true;
            this.grdclmnToolingOrdinal.VisibleIndex = 0;
            this.grdclmnToolingOrdinal.Width = 100;
            // 
            // grdclmnToolingModelName
            // 
            this.grdclmnToolingModelName.Caption = "工装名称";
            this.grdclmnToolingModelName.FieldName = "ToolingModelName";
            this.grdclmnToolingModelName.Name = "grdclmnToolingModelName";
            this.grdclmnToolingModelName.Visible = true;
            this.grdclmnToolingModelName.VisibleIndex = 1;
            this.grdclmnToolingModelName.Width = 180;
            // 
            // grdclmnLifeControlMode
            // 
            this.grdclmnLifeControlMode.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnLifeControlMode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnLifeControlMode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLifeControlMode.Caption = "寿命控制方式";
            this.grdclmnLifeControlMode.ColumnEdit = this.riluLifeControlMode;
            this.grdclmnLifeControlMode.FieldName = "LifeControlMode";
            this.grdclmnLifeControlMode.Name = "grdclmnLifeControlMode";
            this.grdclmnLifeControlMode.Visible = true;
            this.grdclmnLifeControlMode.VisibleIndex = 2;
            // 
            // riluLifeControlMode
            // 
            this.riluLifeControlMode.Appearance.Options.UseTextOptions = true;
            this.riluLifeControlMode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.riluLifeControlMode.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.riluLifeControlMode.AutoHeight = false;
            this.riluLifeControlMode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluLifeControlMode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name1", "Name1")});
            this.riluLifeControlMode.Name = "riluLifeControlMode";
            this.riluLifeControlMode.ShowFooter = false;
            this.riluLifeControlMode.ShowHeader = false;
            // 
            // grdclmnLifeLimit
            // 
            this.grdclmnLifeLimit.Caption = "寿命限制";
            this.grdclmnLifeLimit.FieldName = "LifeLimit";
            this.grdclmnLifeLimit.Name = "grdclmnLifeLimit";
            this.grdclmnLifeLimit.Visible = true;
            this.grdclmnLifeLimit.VisibleIndex = 3;
            // 
            // ucToolingStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.grdToolingStandards);
            this.Name = "ucToolingStandard";
            this.Size = new System.Drawing.Size(563, 346);
            ((System.ComponentModel.ISupportInitialize)(this.grdToolingStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvToolingStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluLifeControlMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdToolingStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvToolingStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToolingOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToolingModelName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLifeControlMode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLifeLimit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluLifeControlMode;
    }
}
