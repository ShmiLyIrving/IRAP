namespace IRAP.Client.GUI.FVS
{
    partial class frmMethodAndQualityStandardsWithProduct
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.tcStandards = new DevExpress.XtraTab.XtraTabControl();
            this.tpMethodStandards = new DevExpress.XtraTab.XtraTabPage();
            this.tpQualityStandards = new DevExpress.XtraTab.XtraTabPage();
            this.grdQualityStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvQualityStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnParameterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStandardString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdMethodStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMethodStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcStandards)).BeginInit();
            this.tcStandards.SuspendLayout();
            this.tpMethodStandards.SuspendLayout();
            this.tpQualityStandards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQualityStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvQualityStandards)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdMethodStandards
            // 
            this.grdMethodStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMethodStandards.Location = new System.Drawing.Point(10, 10);
            this.grdMethodStandards.MainView = this.grdvMethodStandards;
            this.grdMethodStandards.Name = "grdMethodStandards";
            this.grdMethodStandards.Size = new System.Drawing.Size(679, 438);
            this.grdMethodStandards.TabIndex = 0;
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
            this.grdvMethodStandards.Appearance.Row.Options.UseTextOptions = true;
            this.grdvMethodStandards.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvMethodStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnParameterName,
            this.grdclmnStandardString});
            this.grdvMethodStandards.GridControl = this.grdMethodStandards;
            this.grdvMethodStandards.Name = "grdvMethodStandards";
            this.grdvMethodStandards.OptionsCustomization.AllowSort = false;
            this.grdvMethodStandards.OptionsMenu.EnableColumnMenu = false;
            this.grdvMethodStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvMethodStandards.OptionsView.ShowGroupPanel = false;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(611, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 29);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            // 
            // tcStandards
            // 
            this.tcStandards.AppearancePage.Header.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcStandards.AppearancePage.Header.Options.UseFont = true;
            this.tcStandards.Location = new System.Drawing.Point(12, 12);
            this.tcStandards.Name = "tcStandards";
            this.tcStandards.SelectedTabPage = this.tpMethodStandards;
            this.tcStandards.Size = new System.Drawing.Size(705, 493);
            this.tcStandards.TabIndex = 2;
            this.tcStandards.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpMethodStandards,
            this.tpQualityStandards});
            // 
            // tpMethodStandards
            // 
            this.tpMethodStandards.Controls.Add(this.grdMethodStandards);
            this.tpMethodStandards.Name = "tpMethodStandards";
            this.tpMethodStandards.Padding = new System.Windows.Forms.Padding(10);
            this.tpMethodStandards.Size = new System.Drawing.Size(699, 458);
            this.tpMethodStandards.Text = "工艺参数";
            // 
            // tpQualityStandards
            // 
            this.tpQualityStandards.Controls.Add(this.grdQualityStandards);
            this.tpQualityStandards.Name = "tpQualityStandards";
            this.tpQualityStandards.Padding = new System.Windows.Forms.Padding(10);
            this.tpQualityStandards.Size = new System.Drawing.Size(699, 458);
            this.tpQualityStandards.Text = "质量标准";
            // 
            // grdQualityStandards
            // 
            this.grdQualityStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQualityStandards.Location = new System.Drawing.Point(10, 10);
            this.grdQualityStandards.MainView = this.grdvQualityStandards;
            this.grdQualityStandards.Name = "grdQualityStandards";
            this.grdQualityStandards.Size = new System.Drawing.Size(679, 438);
            this.grdQualityStandards.TabIndex = 1;
            this.grdQualityStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvQualityStandards});
            // 
            // grdvQualityStandards
            // 
            this.grdvQualityStandards.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvQualityStandards.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvQualityStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvQualityStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvQualityStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvQualityStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvQualityStandards.Appearance.Row.Options.UseFont = true;
            this.grdvQualityStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.grdvQualityStandards.GridControl = this.grdQualityStandards;
            this.grdvQualityStandards.Name = "grdvQualityStandards";
            this.grdvQualityStandards.OptionsCustomization.AllowSort = false;
            this.grdvQualityStandards.OptionsMenu.EnableColumnMenu = false;
            this.grdvQualityStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvQualityStandards.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.Caption = "序号";
            this.grdclmnOrdinal.FieldName = "Ordinal";
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
            // 
            // grdclmnParameterName
            // 
            this.grdclmnParameterName.Caption = "参数名称";
            this.grdclmnParameterName.FieldName = "ParameterName";
            this.grdclmnParameterName.Name = "grdclmnParameterName";
            this.grdclmnParameterName.Visible = true;
            this.grdclmnParameterName.VisibleIndex = 1;
            // 
            // grdclmnStandardString
            // 
            this.grdclmnStandardString.Caption = "标准";
            this.grdclmnStandardString.FieldName = "StandardString";
            this.grdclmnStandardString.Name = "grdclmnStandardString";
            this.grdclmnStandardString.Visible = true;
            this.grdclmnStandardString.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "序号";
            this.gridColumn1.FieldName = "Ordinal";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "参数名称";
            this.gridColumn2.FieldName = "ParameterName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "标准";
            this.gridColumn3.FieldName = "StandardString";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "首检";
            this.gridColumn4.FieldName = "QtyForFirstInspection";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.Caption = "过程检(每次)";
            this.gridColumn5.FieldName = "QtyForInProcessInspection";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.Caption = "末检";
            this.gridColumn6.FieldName = "QtyForLastInspection";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "过程检批量";
            this.gridColumn7.FieldName = "InProcessInspectionBatchSize";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // frmMethodAndQualityStandardsWithProduct
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(732, 551);
            this.Controls.Add(this.tcStandards);
            this.Controls.Add(this.btnClose);
            this.Name = "frmMethodAndQualityStandardsWithProduct";
            this.ShowIcon = false;
            this.Text = "工艺参数";
            ((System.ComponentModel.ISupportInitialize)(this.grdMethodStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMethodStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcStandards)).EndInit();
            this.tcStandards.ResumeLayout(false);
            this.tpMethodStandards.ResumeLayout(false);
            this.tpQualityStandards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQualityStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvQualityStandards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMethodStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvMethodStandards;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraTab.XtraTabControl tcStandards;
        private DevExpress.XtraTab.XtraTabPage tpMethodStandards;
        private DevExpress.XtraTab.XtraTabPage tpQualityStandards;
        private DevExpress.XtraGrid.GridControl grdQualityStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvQualityStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnParameterName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardString;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}
