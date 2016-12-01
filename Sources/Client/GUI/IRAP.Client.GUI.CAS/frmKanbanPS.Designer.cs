namespace IRAP.Client.GUI.CAS
{
    partial class frmKanbanPS
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
            this.components = new System.ComponentModel.Container();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.pnlRemark = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdPrdtLines = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnArea = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnProductionLine = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnEquipment = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.bandedGridColumnEquipmentTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnMaterial = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnMaterialTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnQualify = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnQualifyTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnTooling = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnToolingTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnSecurity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnSecurityTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnTechnology = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnTechnologyTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnDesign = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnDesignTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnOther = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnOtherTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tmrPage = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRemark)).BeginInit();
            this.pnlRemark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrdtLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "产线安灯状态";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Appearance.Options.UseBackColor = true;
            this.pnlBottom.Controls.Add(this.pnlRemark);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 449);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(891, 46);
            this.pnlBottom.TabIndex = 1;
            // 
            // pnlRemark
            // 
            this.pnlRemark.Controls.Add(this.labelControl4);
            this.pnlRemark.Controls.Add(this.labelControl3);
            this.pnlRemark.Controls.Add(this.labelControl2);
            this.pnlRemark.Controls.Add(this.labelControl1);
            this.pnlRemark.Location = new System.Drawing.Point(86, 0);
            this.pnlRemark.Name = "pnlRemark";
            this.pnlRemark.Size = new System.Drawing.Size(413, 46);
            this.pnlRemark.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.Red;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(311, 5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(96, 36);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "已停产";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Goldenrod;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(209, 5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(96, 36);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "未停产";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Green;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(107, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 36);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "无异常";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 36);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "未开通";
            // 
            // grdPrdtLines
            // 
            this.grdPrdtLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPrdtLines.Location = new System.Drawing.Point(0, 56);
            this.grdPrdtLines.MainView = this.advBandedGridView;
            this.grdPrdtLines.Name = "grdPrdtLines";
            this.grdPrdtLines.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemPictureEdit2,
            this.repositoryItemMemoEdit1});
            this.grdPrdtLines.Size = new System.Drawing.Size(891, 393);
            this.grdPrdtLines.TabIndex = 2;
            this.grdPrdtLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView,
            this.advBandedGridView1});
            // 
            // advBandedGridView
            // 
            this.advBandedGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advBandedGridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Green;
            this.advBandedGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.advBandedGridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.advBandedGridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.advBandedGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.advBandedGridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.advBandedGridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.advBandedGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand12,
            this.gridBand3,
            this.gridBand5,
            this.gridBand4,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand9,
            this.gridBand10,
            this.gridBand11});
            this.advBandedGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumnArea,
            this.bandedGridColumnProductionLine,
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
            this.advBandedGridView.GridControl = this.grdPrdtLines;
            this.advBandedGridView.Name = "advBandedGridView";
            this.advBandedGridView.OptionsBehavior.Editable = false;
            this.advBandedGridView.OptionsCustomization.AllowColumnMoving = false;
            this.advBandedGridView.OptionsCustomization.AllowColumnResizing = false;
            this.advBandedGridView.OptionsCustomization.AllowRowSizing = true;
            this.advBandedGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.advBandedGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.advBandedGridView.OptionsView.AllowHtmlDrawHeaders = true;
            this.advBandedGridView.OptionsView.ColumnAutoWidth = true;
            this.advBandedGridView.OptionsView.ShowBands = false;
            this.advBandedGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand12
            // 
            this.gridBand12.Caption = "gridBand12";
            this.gridBand12.Columns.Add(this.bandedGridColumnArea);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.VisibleIndex = 0;
            this.gridBand12.Width = 120;
            // 
            // bandedGridColumnArea
            // 
            this.bandedGridColumnArea.Caption = "车间";
            this.bandedGridColumnArea.FieldName = "NodeName";
            this.bandedGridColumnArea.Name = "bandedGridColumnArea";
            this.bandedGridColumnArea.RowCount = 3;
            this.bandedGridColumnArea.Visible = true;
            this.bandedGridColumnArea.Width = 120;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "gridBand3";
            this.gridBand3.Columns.Add(this.bandedGridColumnProductionLine);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            this.gridBand3.Width = 75;
            // 
            // bandedGridColumnProductionLine
            // 
            this.bandedGridColumnProductionLine.Caption = "生产线/工作中心";
            this.bandedGridColumnProductionLine.ColumnEdit = this.repositoryItemMemoEdit1;
            this.bandedGridColumnProductionLine.FieldName = "T134NodeName";
            this.bandedGridColumnProductionLine.Name = "bandedGridColumnProductionLine";
            this.bandedGridColumnProductionLine.RowCount = 3;
            this.bandedGridColumnProductionLine.Visible = true;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "gridBand5";
            this.gridBand5.Columns.Add(this.bandedGridColumnEquipment);
            this.gridBand5.Columns.Add(this.bandedGridColumnEquipmentTimeElapsed);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 2;
            this.gridBand5.Width = 89;
            // 
            // bandedGridColumnEquipment
            // 
            this.bandedGridColumnEquipment.Caption = "维修";
            this.bandedGridColumnEquipment.ColumnEdit = this.repositoryItemPictureEdit1;
            this.bandedGridColumnEquipment.FieldName = "EquipmentStatusPic";
            this.bandedGridColumnEquipment.Name = "bandedGridColumnEquipment";
            this.bandedGridColumnEquipment.RowCount = 2;
            this.bandedGridColumnEquipment.Visible = true;
            this.bandedGridColumnEquipment.Width = 89;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.CustomHeight = 75;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // bandedGridColumnEquipmentTimeElapsed
            // 
            this.bandedGridColumnEquipmentTimeElapsed.Caption = "已过时间";
            this.bandedGridColumnEquipmentTimeElapsed.Name = "bandedGridColumnEquipmentTimeElapsed";
            this.bandedGridColumnEquipmentTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnEquipmentTimeElapsed.RowIndex = 1;
            this.bandedGridColumnEquipmentTimeElapsed.Visible = true;
            this.bandedGridColumnEquipmentTimeElapsed.Width = 89;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "gridBand4";
            this.gridBand4.Columns.Add(this.bandedGridColumnMaterial);
            this.gridBand4.Columns.Add(this.bandedGridColumnMaterialTimeElapsed);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 75;
            // 
            // bandedGridColumnMaterial
            // 
            this.bandedGridColumnMaterial.Caption = "物料";
            this.bandedGridColumnMaterial.ColumnEdit = this.repositoryItemPictureEdit1;
            this.bandedGridColumnMaterial.FieldName = "MaterialStatusPic";
            this.bandedGridColumnMaterial.Name = "bandedGridColumnMaterial";
            this.bandedGridColumnMaterial.RowCount = 2;
            this.bandedGridColumnMaterial.Visible = true;
            // 
            // bandedGridColumnMaterialTimeElapsed
            // 
            this.bandedGridColumnMaterialTimeElapsed.Caption = "已过时间";
            this.bandedGridColumnMaterialTimeElapsed.FieldName = "MaterialTimeElapsedString";
            this.bandedGridColumnMaterialTimeElapsed.Name = "bandedGridColumnMaterialTimeElapsed";
            this.bandedGridColumnMaterialTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnMaterialTimeElapsed.RowIndex = 1;
            this.bandedGridColumnMaterialTimeElapsed.Visible = true;
            // 
            // gridBand6
            // 
            this.gridBand6.Caption = "gridBand6";
            this.gridBand6.Columns.Add(this.bandedGridColumnQualify);
            this.gridBand6.Columns.Add(this.bandedGridColumnQualifyTimeElapsed);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 4;
            this.gridBand6.Width = 94;
            // 
            // bandedGridColumnQualify
            // 
            this.bandedGridColumnQualify.Caption = "质量";
            this.bandedGridColumnQualify.ColumnEdit = this.repositoryItemPictureEdit1;
            this.bandedGridColumnQualify.FieldName = "QualifyStatusPic";
            this.bandedGridColumnQualify.Name = "bandedGridColumnQualify";
            this.bandedGridColumnQualify.RowCount = 2;
            this.bandedGridColumnQualify.Visible = true;
            this.bandedGridColumnQualify.Width = 94;
            // 
            // bandedGridColumnQualifyTimeElapsed
            // 
            this.bandedGridColumnQualifyTimeElapsed.Caption = "已过时间1";
            this.bandedGridColumnQualifyTimeElapsed.Name = "bandedGridColumnQualifyTimeElapsed";
            this.bandedGridColumnQualifyTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnQualifyTimeElapsed.RowIndex = 1;
            this.bandedGridColumnQualifyTimeElapsed.Visible = true;
            this.bandedGridColumnQualifyTimeElapsed.Width = 94;
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "gridBand7";
            this.gridBand7.Columns.Add(this.bandedGridColumnTooling);
            this.gridBand7.Columns.Add(this.bandedGridColumnToolingTimeElapsed);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 5;
            this.gridBand7.Width = 109;
            // 
            // bandedGridColumnTooling
            // 
            this.bandedGridColumnTooling.Caption = "工装";
            this.bandedGridColumnTooling.ColumnEdit = this.repositoryItemPictureEdit1;
            this.bandedGridColumnTooling.FieldName = "ToolingStatusPic";
            this.bandedGridColumnTooling.Name = "bandedGridColumnTooling";
            this.bandedGridColumnTooling.RowCount = 2;
            this.bandedGridColumnTooling.Visible = true;
            this.bandedGridColumnTooling.Width = 109;
            // 
            // bandedGridColumnToolingTimeElapsed
            // 
            this.bandedGridColumnToolingTimeElapsed.Caption = "已过时间2";
            this.bandedGridColumnToolingTimeElapsed.Name = "bandedGridColumnToolingTimeElapsed";
            this.bandedGridColumnToolingTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnToolingTimeElapsed.RowIndex = 1;
            this.bandedGridColumnToolingTimeElapsed.Visible = true;
            this.bandedGridColumnToolingTimeElapsed.Width = 109;
            // 
            // gridBand8
            // 
            this.gridBand8.Caption = "gridBand8";
            this.gridBand8.Columns.Add(this.bandedGridColumnSecurity);
            this.gridBand8.Columns.Add(this.bandedGridColumnSecurityTimeElapsed);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 6;
            this.gridBand8.Width = 86;
            // 
            // bandedGridColumnSecurity
            // 
            this.bandedGridColumnSecurity.Caption = "安全";
            this.bandedGridColumnSecurity.ColumnEdit = this.repositoryItemPictureEdit1;
            this.bandedGridColumnSecurity.FieldName = "SecurityStatusPic";
            this.bandedGridColumnSecurity.Name = "bandedGridColumnSecurity";
            this.bandedGridColumnSecurity.RowCount = 2;
            this.bandedGridColumnSecurity.Visible = true;
            this.bandedGridColumnSecurity.Width = 86;
            // 
            // bandedGridColumnSecurityTimeElapsed
            // 
            this.bandedGridColumnSecurityTimeElapsed.Caption = "已过时间3";
            this.bandedGridColumnSecurityTimeElapsed.Name = "bandedGridColumnSecurityTimeElapsed";
            this.bandedGridColumnSecurityTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnSecurityTimeElapsed.RowIndex = 1;
            this.bandedGridColumnSecurityTimeElapsed.Visible = true;
            this.bandedGridColumnSecurityTimeElapsed.Width = 86;
            // 
            // gridBand9
            // 
            this.gridBand9.Caption = "gridBand9";
            this.gridBand9.Columns.Add(this.bandedGridColumnTechnology);
            this.gridBand9.Columns.Add(this.bandedGridColumnTechnologyTimeElapsed);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 7;
            this.gridBand9.Width = 91;
            // 
            // bandedGridColumnTechnology
            // 
            this.bandedGridColumnTechnology.Caption = "技术";
            this.bandedGridColumnTechnology.ColumnEdit = this.repositoryItemPictureEdit1;
            this.bandedGridColumnTechnology.Name = "bandedGridColumnTechnology";
            this.bandedGridColumnTechnology.RowCount = 2;
            this.bandedGridColumnTechnology.Visible = true;
            this.bandedGridColumnTechnology.Width = 91;
            // 
            // bandedGridColumnTechnologyTimeElapsed
            // 
            this.bandedGridColumnTechnologyTimeElapsed.Caption = "已过时间4";
            this.bandedGridColumnTechnologyTimeElapsed.Name = "bandedGridColumnTechnologyTimeElapsed";
            this.bandedGridColumnTechnologyTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnTechnologyTimeElapsed.RowIndex = 1;
            this.bandedGridColumnTechnologyTimeElapsed.Visible = true;
            this.bandedGridColumnTechnologyTimeElapsed.Width = 91;
            // 
            // gridBand10
            // 
            this.gridBand10.Caption = "gridBand10";
            this.gridBand10.Columns.Add(this.bandedGridColumnDesign);
            this.gridBand10.Columns.Add(this.bandedGridColumnDesignTimeElapsed);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.VisibleIndex = 8;
            this.gridBand10.Width = 107;
            // 
            // bandedGridColumnDesign
            // 
            this.bandedGridColumnDesign.Caption = "设计";
            this.bandedGridColumnDesign.ColumnEdit = this.repositoryItemPictureEdit1;
            this.bandedGridColumnDesign.Name = "bandedGridColumnDesign";
            this.bandedGridColumnDesign.RowCount = 2;
            this.bandedGridColumnDesign.Visible = true;
            this.bandedGridColumnDesign.Width = 107;
            // 
            // bandedGridColumnDesignTimeElapsed
            // 
            this.bandedGridColumnDesignTimeElapsed.Caption = "已过时间5";
            this.bandedGridColumnDesignTimeElapsed.Name = "bandedGridColumnDesignTimeElapsed";
            this.bandedGridColumnDesignTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnDesignTimeElapsed.RowIndex = 1;
            this.bandedGridColumnDesignTimeElapsed.Visible = true;
            this.bandedGridColumnDesignTimeElapsed.Width = 107;
            // 
            // gridBand11
            // 
            this.gridBand11.Caption = "gridBand11";
            this.gridBand11.Columns.Add(this.bandedGridColumnOther);
            this.gridBand11.Columns.Add(this.bandedGridColumnOtherTimeElapsed);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.VisibleIndex = 9;
            this.gridBand11.Width = 126;
            // 
            // bandedGridColumnOther
            // 
            this.bandedGridColumnOther.Caption = "其他";
            this.bandedGridColumnOther.ColumnEdit = this.repositoryItemPictureEdit1;
            this.bandedGridColumnOther.Name = "bandedGridColumnOther";
            this.bandedGridColumnOther.RowCount = 2;
            this.bandedGridColumnOther.Visible = true;
            this.bandedGridColumnOther.Width = 126;
            // 
            // bandedGridColumnOtherTimeElapsed
            // 
            this.bandedGridColumnOtherTimeElapsed.Caption = "已过时间6";
            this.bandedGridColumnOtherTimeElapsed.Name = "bandedGridColumnOtherTimeElapsed";
            this.bandedGridColumnOtherTimeElapsed.OptionsColumn.ShowCaption = false;
            this.bandedGridColumnOtherTimeElapsed.RowIndex = 1;
            this.bandedGridColumnOtherTimeElapsed.Visible = true;
            this.bandedGridColumnOtherTimeElapsed.Width = 126;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.GridControl = this.grdPrdtLines;
            this.advBandedGridView1.Name = "advBandedGridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tmrPage
            // 
            this.tmrPage.Tick += new System.EventHandler(this.tmrPage_Tick);
            // 
            // frmKanbanPS
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.grdPrdtLines);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmKanbanPS";
            this.Text = "产线安灯状态";
            this.Activated += new System.EventHandler(this.frmKanbanPS_Activated);
            this.Resize += new System.EventHandler(this.frmKanbanPS_Resize);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.grdPrdtLines, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlRemark)).EndInit();
            this.pnlRemark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrdtLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraGrid.GridControl grdPrdtLines;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnArea;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnProductionLine;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnMaterial;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnMaterialTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnEquipment;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnEquipmentTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnQualify;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnQualifyTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnTooling;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnToolingTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnSecurity;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnSecurityTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnTechnology;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnTechnologyTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnDesign;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnDesignTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOther;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnOtherTimeElapsed;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer tmrPage;
        private DevExpress.XtraEditors.PanelControl pnlRemark;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
