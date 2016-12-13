namespace IRAP.Client.GUI.CAS
{
    partial class frmKanbanAI
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.grdHosts = new DevExpress.XtraGrid.GridControl();
            this.BandedGridViewHost = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnMaterial = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.bandedGridColumnMaterialTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnEquipment = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnEquipmentTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnQualify = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnQualifyTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnTooling = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnToolingTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnSecurity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnSecurityTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnTechnology = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnTechnologyTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnDesign = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnDesignTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnOther = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnOtherTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.grdvPtdtLines = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductionLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnEquipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQuality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnTooling = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSecurity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnTechnology = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnDesign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnOther = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.timer1 = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BandedGridViewHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPtdtLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Location = new System.Drawing.Point(2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 26);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grdHosts
            // 
            this.grdHosts.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdHosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHosts.Location = new System.Drawing.Point(0, 56);
            this.grdHosts.MainView = this.BandedGridViewHost;
            this.grdHosts.Name = "grdHosts";
            this.grdHosts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit9,
            this.repositoryItemPictureEdit10});
            this.grdHosts.Size = new System.Drawing.Size(891, 409);
            this.grdHosts.TabIndex = 5;
            this.grdHosts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.BandedGridViewHost,
            this.grdvPtdtLines});
            // 
            // BandedGridViewHost
            // 
            this.BandedGridViewHost.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Green;
            this.BandedGridViewHost.Appearance.FocusedCell.Options.UseForeColor = true;
            this.BandedGridViewHost.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.BandedGridViewHost.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Green;
            this.BandedGridViewHost.Appearance.FocusedRow.Options.UseBackColor = true;
            this.BandedGridViewHost.Appearance.FocusedRow.Options.UseForeColor = true;
            this.BandedGridViewHost.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.BandedGridViewHost.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.BandedGridViewHost.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
            this.BandedGridViewHost.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.White;
            this.BandedGridViewHost.Appearance.SelectedRow.Options.UseBackColor = true;
            this.BandedGridViewHost.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand9,
            this.gridBand10});
            this.BandedGridViewHost.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumnMaterial,
            this.bandedGridColumnMaterialTimeElapsed,
            this.bandedGridColumnEquipment,
            this.bandedGridColumnEquipmentTimeElapsed,
            this.bandedGridColumnQualify,
            this.bandedGridColumnQualifyTimeElapsed,
            this.bandedGridColumnTooling,
            this.bandedGridColumnToolingTimeElapsed,
            this.bandedGridColumnSecurity,
            this.bandedGridColumnSecurityTimeElapsed,
            this.bandedGridColumnTechnology,
            this.bandedGridColumnTechnologyTimeElapsed,
            this.bandedGridColumnDesign,
            this.bandedGridColumnDesignTimeElapsed,
            this.bandedGridColumnOther,
            this.bandedGridColumnOtherTimeElapsed});
            this.BandedGridViewHost.DetailHeight = 550;
            this.BandedGridViewHost.GridControl = this.grdHosts;
            this.BandedGridViewHost.Name = "BandedGridViewHost";
            this.BandedGridViewHost.OptionsBehavior.Editable = false;
            this.BandedGridViewHost.OptionsCustomization.AllowColumnMoving = false;
            this.BandedGridViewHost.OptionsCustomization.AllowColumnResizing = false;
            this.BandedGridViewHost.OptionsCustomization.AllowRowSizing = true;
            this.BandedGridViewHost.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.BandedGridViewHost.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.BandedGridViewHost.OptionsView.ColumnAutoWidth = true;
            this.BandedGridViewHost.OptionsView.ShowBands = false;
            this.BandedGridViewHost.OptionsView.ShowColumnHeaders = false;
            this.BandedGridViewHost.OptionsView.ShowGroupPanel = false;
            this.BandedGridViewHost.OptionsView.ShowIndicator = false;
            this.BandedGridViewHost.RowHeight = 35;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridBand3.Columns.Add(this.bandedGridColumnMaterial);
            this.gridBand3.Columns.Add(this.bandedGridColumnMaterialTimeElapsed);
            this.gridBand3.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand3.MinWidth = 20;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 0;
            this.gridBand3.Width = 160;
            // 
            // bandedGridColumnMaterial
            // 
            this.bandedGridColumnMaterial.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnMaterial.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnMaterial.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnMaterial.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnMaterial.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnMaterial.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnMaterial.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnMaterial.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnMaterial.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnMaterial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnMaterial.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnMaterial.ColumnEdit = this.repositoryItemPictureEdit9;
            this.bandedGridColumnMaterial.FieldName = "Pic0";
            this.bandedGridColumnMaterial.Name = "bandedGridColumnMaterial";
            this.bandedGridColumnMaterial.RowCount = 2;
            this.bandedGridColumnMaterial.Visible = true;
            this.bandedGridColumnMaterial.Width = 160;
            // 
            // repositoryItemPictureEdit9
            // 
            this.repositoryItemPictureEdit9.CustomHeight = 75;
            this.repositoryItemPictureEdit9.Name = "repositoryItemPictureEdit9";
            this.repositoryItemPictureEdit9.NullText = "   ";
            this.repositoryItemPictureEdit9.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // bandedGridColumnMaterialTimeElapsed
            // 
            this.bandedGridColumnMaterialTimeElapsed.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnMaterialTimeElapsed.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceCell.Options.UseBackColor = true;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceCell.Options.UseForeColor = true;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnMaterialTimeElapsed.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnMaterialTimeElapsed.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnMaterialTimeElapsed.Caption = "HostName";
            this.bandedGridColumnMaterialTimeElapsed.FieldName = "Des0";
            this.bandedGridColumnMaterialTimeElapsed.Name = "bandedGridColumnMaterialTimeElapsed";
            this.bandedGridColumnMaterialTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnMaterialTimeElapsed.RowIndex = 1;
            this.bandedGridColumnMaterialTimeElapsed.Visible = true;
            this.bandedGridColumnMaterialTimeElapsed.Width = 160;
            // 
            // gridBand4
            // 
            this.gridBand4.Columns.Add(this.bandedGridColumnEquipment);
            this.gridBand4.Columns.Add(this.bandedGridColumnEquipmentTimeElapsed);
            this.gridBand4.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 1;
            this.gridBand4.Width = 160;
            // 
            // bandedGridColumnEquipment
            // 
            this.bandedGridColumnEquipment.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnEquipment.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnEquipment.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnEquipment.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnEquipment.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnEquipment.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnEquipment.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnEquipment.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnEquipment.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnEquipment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnEquipment.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnEquipment.ColumnEdit = this.repositoryItemPictureEdit9;
            this.bandedGridColumnEquipment.FieldName = "Pic1";
            this.bandedGridColumnEquipment.Name = "bandedGridColumnEquipment";
            this.bandedGridColumnEquipment.RowCount = 2;
            this.bandedGridColumnEquipment.Visible = true;
            this.bandedGridColumnEquipment.Width = 160;
            // 
            // bandedGridColumnEquipmentTimeElapsed
            // 
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceCell.Options.UseBackColor = true;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceCell.Options.UseForeColor = true;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnEquipmentTimeElapsed.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnEquipmentTimeElapsed.Caption = "HostName";
            this.bandedGridColumnEquipmentTimeElapsed.FieldName = "Des1";
            this.bandedGridColumnEquipmentTimeElapsed.Name = "bandedGridColumnEquipmentTimeElapsed";
            this.bandedGridColumnEquipmentTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnEquipmentTimeElapsed.RowIndex = 1;
            this.bandedGridColumnEquipmentTimeElapsed.Visible = true;
            this.bandedGridColumnEquipmentTimeElapsed.Width = 160;
            // 
            // gridBand5
            // 
            this.gridBand5.Columns.Add(this.bandedGridColumnQualify);
            this.gridBand5.Columns.Add(this.bandedGridColumnQualifyTimeElapsed);
            this.gridBand5.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 2;
            this.gridBand5.Width = 160;
            // 
            // bandedGridColumnQualify
            // 
            this.bandedGridColumnQualify.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnQualify.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnQualify.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnQualify.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnQualify.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnQualify.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnQualify.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnQualify.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnQualify.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnQualify.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnQualify.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnQualify.ColumnEdit = this.repositoryItemPictureEdit9;
            this.bandedGridColumnQualify.FieldName = "Pic2";
            this.bandedGridColumnQualify.Name = "bandedGridColumnQualify";
            this.bandedGridColumnQualify.RowCount = 2;
            this.bandedGridColumnQualify.Visible = true;
            this.bandedGridColumnQualify.Width = 160;
            // 
            // bandedGridColumnQualifyTimeElapsed
            // 
            this.bandedGridColumnQualifyTimeElapsed.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnQualifyTimeElapsed.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceCell.Options.UseBackColor = true;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceCell.Options.UseForeColor = true;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnQualifyTimeElapsed.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnQualifyTimeElapsed.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnQualifyTimeElapsed.Caption = "HostName";
            this.bandedGridColumnQualifyTimeElapsed.FieldName = "Des2";
            this.bandedGridColumnQualifyTimeElapsed.Name = "bandedGridColumnQualifyTimeElapsed";
            this.bandedGridColumnQualifyTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnQualifyTimeElapsed.RowIndex = 1;
            this.bandedGridColumnQualifyTimeElapsed.Visible = true;
            this.bandedGridColumnQualifyTimeElapsed.Width = 160;
            // 
            // gridBand6
            // 
            this.gridBand6.Columns.Add(this.bandedGridColumnTooling);
            this.gridBand6.Columns.Add(this.bandedGridColumnToolingTimeElapsed);
            this.gridBand6.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 3;
            this.gridBand6.Width = 160;
            // 
            // bandedGridColumnTooling
            // 
            this.bandedGridColumnTooling.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnTooling.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnTooling.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnTooling.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnTooling.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnTooling.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnTooling.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnTooling.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnTooling.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnTooling.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnTooling.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnTooling.ColumnEdit = this.repositoryItemPictureEdit9;
            this.bandedGridColumnTooling.FieldName = "Pic3";
            this.bandedGridColumnTooling.Name = "bandedGridColumnTooling";
            this.bandedGridColumnTooling.RowCount = 2;
            this.bandedGridColumnTooling.Visible = true;
            this.bandedGridColumnTooling.Width = 160;
            // 
            // bandedGridColumnToolingTimeElapsed
            // 
            this.bandedGridColumnToolingTimeElapsed.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnToolingTimeElapsed.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnToolingTimeElapsed.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnToolingTimeElapsed.AppearanceCell.Options.UseForeColor = true;
            this.bandedGridColumnToolingTimeElapsed.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumnToolingTimeElapsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnToolingTimeElapsed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnToolingTimeElapsed.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnToolingTimeElapsed.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnToolingTimeElapsed.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnToolingTimeElapsed.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnToolingTimeElapsed.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnToolingTimeElapsed.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnToolingTimeElapsed.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnToolingTimeElapsed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnToolingTimeElapsed.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnToolingTimeElapsed.Caption = "HostName";
            this.bandedGridColumnToolingTimeElapsed.FieldName = "Des3";
            this.bandedGridColumnToolingTimeElapsed.Name = "bandedGridColumnToolingTimeElapsed";
            this.bandedGridColumnToolingTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnToolingTimeElapsed.RowIndex = 1;
            this.bandedGridColumnToolingTimeElapsed.Visible = true;
            this.bandedGridColumnToolingTimeElapsed.Width = 160;
            // 
            // gridBand7
            // 
            this.gridBand7.Columns.Add(this.bandedGridColumnSecurity);
            this.gridBand7.Columns.Add(this.bandedGridColumnSecurityTimeElapsed);
            this.gridBand7.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 4;
            this.gridBand7.Width = 160;
            // 
            // bandedGridColumnSecurity
            // 
            this.bandedGridColumnSecurity.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnSecurity.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnSecurity.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnSecurity.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnSecurity.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnSecurity.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnSecurity.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnSecurity.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnSecurity.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnSecurity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnSecurity.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnSecurity.ColumnEdit = this.repositoryItemPictureEdit9;
            this.bandedGridColumnSecurity.FieldName = "Pic4";
            this.bandedGridColumnSecurity.Name = "bandedGridColumnSecurity";
            this.bandedGridColumnSecurity.RowCount = 2;
            this.bandedGridColumnSecurity.Visible = true;
            this.bandedGridColumnSecurity.Width = 160;
            // 
            // bandedGridColumnSecurityTimeElapsed
            // 
            this.bandedGridColumnSecurityTimeElapsed.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnSecurityTimeElapsed.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceCell.Options.UseForeColor = true;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnSecurityTimeElapsed.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnSecurityTimeElapsed.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnSecurityTimeElapsed.Caption = "HostName";
            this.bandedGridColumnSecurityTimeElapsed.FieldName = "Des4";
            this.bandedGridColumnSecurityTimeElapsed.Name = "bandedGridColumnSecurityTimeElapsed";
            this.bandedGridColumnSecurityTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnSecurityTimeElapsed.RowIndex = 1;
            this.bandedGridColumnSecurityTimeElapsed.Visible = true;
            this.bandedGridColumnSecurityTimeElapsed.Width = 160;
            // 
            // gridBand8
            // 
            this.gridBand8.Columns.Add(this.bandedGridColumnTechnology);
            this.gridBand8.Columns.Add(this.bandedGridColumnTechnologyTimeElapsed);
            this.gridBand8.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 5;
            this.gridBand8.Width = 160;
            // 
            // bandedGridColumnTechnology
            // 
            this.bandedGridColumnTechnology.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnTechnology.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnTechnology.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnTechnology.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnTechnology.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnTechnology.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnTechnology.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnTechnology.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnTechnology.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnTechnology.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnTechnology.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnTechnology.ColumnEdit = this.repositoryItemPictureEdit9;
            this.bandedGridColumnTechnology.FieldName = "Pic5";
            this.bandedGridColumnTechnology.Name = "bandedGridColumnTechnology";
            this.bandedGridColumnTechnology.RowCount = 2;
            this.bandedGridColumnTechnology.Visible = true;
            this.bandedGridColumnTechnology.Width = 160;
            // 
            // bandedGridColumnTechnologyTimeElapsed
            // 
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceCell.Options.UseForeColor = true;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnTechnologyTimeElapsed.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnTechnologyTimeElapsed.Caption = "HostName";
            this.bandedGridColumnTechnologyTimeElapsed.FieldName = "Des5";
            this.bandedGridColumnTechnologyTimeElapsed.Name = "bandedGridColumnTechnologyTimeElapsed";
            this.bandedGridColumnTechnologyTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnTechnologyTimeElapsed.RowIndex = 1;
            this.bandedGridColumnTechnologyTimeElapsed.Visible = true;
            this.bandedGridColumnTechnologyTimeElapsed.Width = 160;
            // 
            // gridBand9
            // 
            this.gridBand9.Columns.Add(this.bandedGridColumnDesign);
            this.gridBand9.Columns.Add(this.bandedGridColumnDesignTimeElapsed);
            this.gridBand9.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 6;
            this.gridBand9.Width = 160;
            // 
            // bandedGridColumnDesign
            // 
            this.bandedGridColumnDesign.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnDesign.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnDesign.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnDesign.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnDesign.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnDesign.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnDesign.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnDesign.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnDesign.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnDesign.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnDesign.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnDesign.ColumnEdit = this.repositoryItemPictureEdit9;
            this.bandedGridColumnDesign.FieldName = "Pic6";
            this.bandedGridColumnDesign.Name = "bandedGridColumnDesign";
            this.bandedGridColumnDesign.RowCount = 2;
            this.bandedGridColumnDesign.Visible = true;
            this.bandedGridColumnDesign.Width = 160;
            // 
            // bandedGridColumnDesignTimeElapsed
            // 
            this.bandedGridColumnDesignTimeElapsed.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnDesignTimeElapsed.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnDesignTimeElapsed.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnDesignTimeElapsed.AppearanceCell.Options.UseForeColor = true;
            this.bandedGridColumnDesignTimeElapsed.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumnDesignTimeElapsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnDesignTimeElapsed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnDesignTimeElapsed.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnDesignTimeElapsed.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnDesignTimeElapsed.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnDesignTimeElapsed.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnDesignTimeElapsed.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnDesignTimeElapsed.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnDesignTimeElapsed.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnDesignTimeElapsed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnDesignTimeElapsed.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnDesignTimeElapsed.Caption = "HostName";
            this.bandedGridColumnDesignTimeElapsed.FieldName = "Des6";
            this.bandedGridColumnDesignTimeElapsed.Name = "bandedGridColumnDesignTimeElapsed";
            this.bandedGridColumnDesignTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnDesignTimeElapsed.RowIndex = 1;
            this.bandedGridColumnDesignTimeElapsed.Visible = true;
            this.bandedGridColumnDesignTimeElapsed.Width = 160;
            // 
            // gridBand10
            // 
            this.gridBand10.Columns.Add(this.bandedGridColumnOther);
            this.gridBand10.Columns.Add(this.bandedGridColumnOtherTimeElapsed);
            this.gridBand10.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.VisibleIndex = 7;
            this.gridBand10.Width = 160;
            // 
            // bandedGridColumnOther
            // 
            this.bandedGridColumnOther.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnOther.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnOther.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnOther.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnOther.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnOther.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnOther.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnOther.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnOther.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnOther.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnOther.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnOther.ColumnEdit = this.repositoryItemPictureEdit9;
            this.bandedGridColumnOther.FieldName = "Pic7";
            this.bandedGridColumnOther.Name = "bandedGridColumnOther";
            this.bandedGridColumnOther.RowCount = 2;
            this.bandedGridColumnOther.Visible = true;
            this.bandedGridColumnOther.Width = 160;
            // 
            // bandedGridColumnOtherTimeElapsed
            // 
            this.bandedGridColumnOtherTimeElapsed.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnOtherTimeElapsed.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnOtherTimeElapsed.AppearanceCell.Options.UseFont = true;
            this.bandedGridColumnOtherTimeElapsed.AppearanceCell.Options.UseForeColor = true;
            this.bandedGridColumnOtherTimeElapsed.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumnOtherTimeElapsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnOtherTimeElapsed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnOtherTimeElapsed.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.bandedGridColumnOtherTimeElapsed.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bandedGridColumnOtherTimeElapsed.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.bandedGridColumnOtherTimeElapsed.AppearanceHeader.Options.UseBackColor = true;
            this.bandedGridColumnOtherTimeElapsed.AppearanceHeader.Options.UseFont = true;
            this.bandedGridColumnOtherTimeElapsed.AppearanceHeader.Options.UseForeColor = true;
            this.bandedGridColumnOtherTimeElapsed.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumnOtherTimeElapsed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumnOtherTimeElapsed.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridColumnOtherTimeElapsed.Caption = "HostName";
            this.bandedGridColumnOtherTimeElapsed.FieldName = "Des7";
            this.bandedGridColumnOtherTimeElapsed.Name = "bandedGridColumnOtherTimeElapsed";
            this.bandedGridColumnOtherTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnOtherTimeElapsed.RowIndex = 1;
            this.bandedGridColumnOtherTimeElapsed.Visible = true;
            this.bandedGridColumnOtherTimeElapsed.Width = 160;
            // 
            // repositoryItemPictureEdit10
            // 
            this.repositoryItemPictureEdit10.Name = "repositoryItemPictureEdit10";
            // 
            // grdvPtdtLines
            // 
            this.grdvPtdtLines.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.grdvPtdtLines.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdvPtdtLines.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
            this.grdvPtdtLines.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdvPtdtLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnArea,
            this.grdclmnProductionLine,
            this.grdclmnMaterial,
            this.grdclmnEquipment,
            this.grdclmnQuality,
            this.grdclmnTooling,
            this.grdclmnSecurity,
            this.grdclmnTechnology,
            this.grdclmnDesign,
            this.grdclmnOther});
            this.grdvPtdtLines.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.grdvPtdtLines.GridControl = this.grdHosts;
            this.grdvPtdtLines.Name = "grdvPtdtLines";
            this.grdvPtdtLines.OptionsBehavior.Editable = false;
            this.grdvPtdtLines.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvPtdtLines.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grdvPtdtLines.OptionsView.AllowCellMerge = true;
            this.grdvPtdtLines.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.NeverAnimate;
            this.grdvPtdtLines.OptionsView.ColumnAutoWidth = false;
            this.grdvPtdtLines.OptionsView.ShowGroupPanel = false;
            this.grdvPtdtLines.RowHeight = 75;
            // 
            // grdclmnArea
            // 
            this.grdclmnArea.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.grdclmnArea.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnArea.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.grdclmnArea.AppearanceCell.Options.UseBackColor = true;
            this.grdclmnArea.AppearanceCell.Options.UseFont = true;
            this.grdclmnArea.AppearanceCell.Options.UseForeColor = true;
            this.grdclmnArea.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.grdclmnArea.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnArea.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.grdclmnArea.AppearanceHeader.Options.UseBackColor = true;
            this.grdclmnArea.AppearanceHeader.Options.UseFont = true;
            this.grdclmnArea.AppearanceHeader.Options.UseForeColor = true;
            this.grdclmnArea.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnArea.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnArea.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnArea.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnArea.Caption = "区域";
            this.grdclmnArea.FieldName = "NodeName";
            this.grdclmnArea.Name = "grdclmnArea";
            this.grdclmnArea.Visible = true;
            this.grdclmnArea.VisibleIndex = 0;
            // 
            // grdclmnProductionLine
            // 
            this.grdclmnProductionLine.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.grdclmnProductionLine.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnProductionLine.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.grdclmnProductionLine.AppearanceCell.Options.UseBackColor = true;
            this.grdclmnProductionLine.AppearanceCell.Options.UseFont = true;
            this.grdclmnProductionLine.AppearanceCell.Options.UseForeColor = true;
            this.grdclmnProductionLine.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.grdclmnProductionLine.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnProductionLine.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.grdclmnProductionLine.AppearanceHeader.Options.UseBackColor = true;
            this.grdclmnProductionLine.AppearanceHeader.Options.UseFont = true;
            this.grdclmnProductionLine.AppearanceHeader.Options.UseForeColor = true;
            this.grdclmnProductionLine.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnProductionLine.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductionLine.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductionLine.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductionLine.Caption = "生产线/工作中心";
            this.grdclmnProductionLine.FieldName = "T134NodeName";
            this.grdclmnProductionLine.Name = "grdclmnProductionLine";
            this.grdclmnProductionLine.Visible = true;
            this.grdclmnProductionLine.VisibleIndex = 1;
            // 
            // grdclmnMaterial
            // 
            this.grdclmnMaterial.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.grdclmnMaterial.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnMaterial.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.grdclmnMaterial.AppearanceCell.Options.UseBackColor = true;
            this.grdclmnMaterial.AppearanceCell.Options.UseFont = true;
            this.grdclmnMaterial.AppearanceCell.Options.UseForeColor = true;
            this.grdclmnMaterial.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.grdclmnMaterial.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnMaterial.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.grdclmnMaterial.AppearanceHeader.Options.UseBackColor = true;
            this.grdclmnMaterial.AppearanceHeader.Options.UseFont = true;
            this.grdclmnMaterial.AppearanceHeader.Options.UseForeColor = true;
            this.grdclmnMaterial.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMaterial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMaterial.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMaterial.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMaterial.Caption = "物料";
            this.grdclmnMaterial.ColumnEdit = this.repositoryItemPictureEdit9;
            this.grdclmnMaterial.FieldName = "MaterialStatusPic";
            this.grdclmnMaterial.Name = "grdclmnMaterial";
            this.grdclmnMaterial.Visible = true;
            this.grdclmnMaterial.VisibleIndex = 2;
            // 
            // grdclmnEquipment
            // 
            this.grdclmnEquipment.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.grdclmnEquipment.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnEquipment.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.grdclmnEquipment.AppearanceCell.Options.UseBackColor = true;
            this.grdclmnEquipment.AppearanceCell.Options.UseFont = true;
            this.grdclmnEquipment.AppearanceCell.Options.UseForeColor = true;
            this.grdclmnEquipment.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.grdclmnEquipment.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnEquipment.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.grdclmnEquipment.AppearanceHeader.Options.UseBackColor = true;
            this.grdclmnEquipment.AppearanceHeader.Options.UseFont = true;
            this.grdclmnEquipment.AppearanceHeader.Options.UseForeColor = true;
            this.grdclmnEquipment.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnEquipment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnEquipment.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEquipment.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnEquipment.Caption = "维修";
            this.grdclmnEquipment.ColumnEdit = this.repositoryItemPictureEdit10;
            this.grdclmnEquipment.FieldName = "EquipmentStatusPic";
            this.grdclmnEquipment.Name = "grdclmnEquipment";
            this.grdclmnEquipment.Visible = true;
            this.grdclmnEquipment.VisibleIndex = 3;
            // 
            // grdclmnQuality
            // 
            this.grdclmnQuality.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.grdclmnQuality.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnQuality.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.grdclmnQuality.AppearanceCell.Options.UseBackColor = true;
            this.grdclmnQuality.AppearanceCell.Options.UseFont = true;
            this.grdclmnQuality.AppearanceCell.Options.UseForeColor = true;
            this.grdclmnQuality.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.grdclmnQuality.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnQuality.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.grdclmnQuality.AppearanceHeader.Options.UseBackColor = true;
            this.grdclmnQuality.AppearanceHeader.Options.UseFont = true;
            this.grdclmnQuality.AppearanceHeader.Options.UseForeColor = true;
            this.grdclmnQuality.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnQuality.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnQuality.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQuality.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnQuality.Caption = "质量";
            this.grdclmnQuality.ColumnEdit = this.repositoryItemPictureEdit9;
            this.grdclmnQuality.FieldName = "QualifyStatusPic";
            this.grdclmnQuality.Name = "grdclmnQuality";
            this.grdclmnQuality.Visible = true;
            this.grdclmnQuality.VisibleIndex = 4;
            // 
            // grdclmnTooling
            // 
            this.grdclmnTooling.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.grdclmnTooling.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnTooling.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.grdclmnTooling.AppearanceCell.Options.UseBackColor = true;
            this.grdclmnTooling.AppearanceCell.Options.UseFont = true;
            this.grdclmnTooling.AppearanceCell.Options.UseForeColor = true;
            this.grdclmnTooling.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.grdclmnTooling.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnTooling.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.grdclmnTooling.AppearanceHeader.Options.UseBackColor = true;
            this.grdclmnTooling.AppearanceHeader.Options.UseFont = true;
            this.grdclmnTooling.AppearanceHeader.Options.UseForeColor = true;
            this.grdclmnTooling.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnTooling.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnTooling.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnTooling.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnTooling.Caption = "工装";
            this.grdclmnTooling.ColumnEdit = this.repositoryItemPictureEdit9;
            this.grdclmnTooling.FieldName = "ToolingStatusPic";
            this.grdclmnTooling.Name = "grdclmnTooling";
            this.grdclmnTooling.Visible = true;
            this.grdclmnTooling.VisibleIndex = 5;
            // 
            // grdclmnSecurity
            // 
            this.grdclmnSecurity.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.grdclmnSecurity.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnSecurity.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.grdclmnSecurity.AppearanceCell.Options.UseBackColor = true;
            this.grdclmnSecurity.AppearanceCell.Options.UseFont = true;
            this.grdclmnSecurity.AppearanceCell.Options.UseForeColor = true;
            this.grdclmnSecurity.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.grdclmnSecurity.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnSecurity.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.grdclmnSecurity.AppearanceHeader.Options.UseBackColor = true;
            this.grdclmnSecurity.AppearanceHeader.Options.UseFont = true;
            this.grdclmnSecurity.AppearanceHeader.Options.UseForeColor = true;
            this.grdclmnSecurity.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnSecurity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnSecurity.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnSecurity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnSecurity.Caption = "安全";
            this.grdclmnSecurity.ColumnEdit = this.repositoryItemPictureEdit9;
            this.grdclmnSecurity.FieldName = "SecurityStatusPic";
            this.grdclmnSecurity.Name = "grdclmnSecurity";
            this.grdclmnSecurity.Visible = true;
            this.grdclmnSecurity.VisibleIndex = 6;
            // 
            // grdclmnTechnology
            // 
            this.grdclmnTechnology.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.grdclmnTechnology.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnTechnology.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.grdclmnTechnology.AppearanceCell.Options.UseBackColor = true;
            this.grdclmnTechnology.AppearanceCell.Options.UseFont = true;
            this.grdclmnTechnology.AppearanceCell.Options.UseForeColor = true;
            this.grdclmnTechnology.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.grdclmnTechnology.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnTechnology.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.grdclmnTechnology.AppearanceHeader.Options.UseBackColor = true;
            this.grdclmnTechnology.AppearanceHeader.Options.UseFont = true;
            this.grdclmnTechnology.AppearanceHeader.Options.UseForeColor = true;
            this.grdclmnTechnology.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnTechnology.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnTechnology.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnTechnology.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnTechnology.Caption = "技术";
            this.grdclmnTechnology.ColumnEdit = this.repositoryItemPictureEdit9;
            this.grdclmnTechnology.FieldName = "TechnologyStatusPic";
            this.grdclmnTechnology.Name = "grdclmnTechnology";
            this.grdclmnTechnology.Visible = true;
            this.grdclmnTechnology.VisibleIndex = 7;
            // 
            // grdclmnDesign
            // 
            this.grdclmnDesign.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.grdclmnDesign.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnDesign.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.grdclmnDesign.AppearanceCell.Options.UseBackColor = true;
            this.grdclmnDesign.AppearanceCell.Options.UseFont = true;
            this.grdclmnDesign.AppearanceCell.Options.UseForeColor = true;
            this.grdclmnDesign.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.grdclmnDesign.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnDesign.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.grdclmnDesign.AppearanceHeader.Options.UseBackColor = true;
            this.grdclmnDesign.AppearanceHeader.Options.UseFont = true;
            this.grdclmnDesign.AppearanceHeader.Options.UseForeColor = true;
            this.grdclmnDesign.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnDesign.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnDesign.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnDesign.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnDesign.Caption = "设计";
            this.grdclmnDesign.ColumnEdit = this.repositoryItemPictureEdit9;
            this.grdclmnDesign.FieldName = "DesignStatusPic";
            this.grdclmnDesign.Name = "grdclmnDesign";
            this.grdclmnDesign.Visible = true;
            this.grdclmnDesign.VisibleIndex = 8;
            // 
            // grdclmnOther
            // 
            this.grdclmnOther.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.grdclmnOther.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnOther.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.grdclmnOther.AppearanceCell.Options.UseBackColor = true;
            this.grdclmnOther.AppearanceCell.Options.UseFont = true;
            this.grdclmnOther.AppearanceCell.Options.UseForeColor = true;
            this.grdclmnOther.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.grdclmnOther.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnOther.AppearanceHeader.ForeColor = System.Drawing.Color.Green;
            this.grdclmnOther.AppearanceHeader.Options.UseBackColor = true;
            this.grdclmnOther.AppearanceHeader.Options.UseFont = true;
            this.grdclmnOther.AppearanceHeader.Options.UseForeColor = true;
            this.grdclmnOther.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnOther.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOther.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOther.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnOther.Caption = "其他";
            this.grdclmnOther.ColumnEdit = this.repositoryItemPictureEdit9;
            this.grdclmnOther.FieldName = "OtherStatusPic";
            this.grdclmnOther.Name = "grdclmnOther";
            this.grdclmnOther.Visible = true;
            this.grdclmnOther.VisibleIndex = 9;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnRefresh);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 465);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(891, 30);
            this.panelControl2.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmKanbanAI
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.grdHosts);
            this.Controls.Add(this.panelControl2);
            this.Name = "frmKanbanAI";
            this.Activated += new System.EventHandler(this.frmMonitorHostName_Activated);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.grdHosts, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BandedGridViewHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPtdtLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl grdHosts;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView BandedGridViewHost;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnMaterial;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnMaterialTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnEquipment;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnEquipmentTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnQualify;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnQualifyTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnTooling;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnToolingTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnSecurity;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnSecurityTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnTechnology;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnTechnologyTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnDesign;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnDesignTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOther;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOtherTimeElapsed;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit10;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPtdtLines;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnArea;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductionLine;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEquipment;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQuality;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnTooling;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSecurity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnTechnology;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnDesign;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOther;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Timer timer1;
    }
}
