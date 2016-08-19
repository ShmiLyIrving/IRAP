namespace IRAP.Client.GUI.CAS
{
    partial class frmKanbanPS_30
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
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.grdPrdtLines = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnArea = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnProductionLine = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnMaterial = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.bandedGridColumnMaterialTimeElapsed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumnEquipment = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnQualify = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnTooling = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumnSecurity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
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
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 449);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(891, 46);
            this.pnlBottom.TabIndex = 1;
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
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5});
            this.advBandedGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumnArea,
            this.bandedGridColumnProductionLine,
            this.bandedGridColumnMaterial,
            this.bandedGridColumnMaterialTimeElapsed,
            this.bandedGridColumnEquipment,
            this.bandedGridColumn5,
            this.bandedGridColumnQualify,
            this.bandedGridColumn7,
            this.bandedGridColumnTooling,
            this.bandedGridColumn9,
            this.bandedGridColumnSecurity,
            this.bandedGridColumn11,
            this.bandedGridColumn12,
            this.bandedGridColumn13,
            this.bandedGridColumn14,
            this.bandedGridColumn15,
            this.bandedGridColumn16,
            this.bandedGridColumn17});
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
            // gridBand2
            // 
            this.gridBand2.Columns.Add(this.bandedGridColumnArea);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 120;
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
            // gridBand4
            // 
            this.gridBand4.Caption = "gridBand4";
            this.gridBand4.Columns.Add(this.bandedGridColumnMaterial);
            this.gridBand4.Columns.Add(this.bandedGridColumnMaterialTimeElapsed);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 2;
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
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.CustomHeight = 75;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
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
            // gridBand5
            // 
            this.gridBand5.Caption = "gridBand5";
            this.gridBand5.Columns.Add(this.bandedGridColumnEquipment);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 3;
            this.gridBand5.Width = 75;
            // 
            // bandedGridColumnEquipment
            // 
            this.bandedGridColumnEquipment.Caption = "维修";
            this.bandedGridColumnEquipment.ColumnEdit = this.repositoryItemPictureEdit1;
            this.bandedGridColumnEquipment.FieldName = "EquipmentStatusPic";
            this.bandedGridColumnEquipment.Name = "bandedGridColumnEquipment";
            this.bandedGridColumnEquipment.RowCount = 2;
            this.bandedGridColumnEquipment.Visible = true;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "bandedGridColumn5";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            // 
            // bandedGridColumnQualify
            // 
            this.bandedGridColumnQualify.Caption = "质量";
            this.bandedGridColumnQualify.ColumnEdit = this.repositoryItemPictureEdit1;
            this.bandedGridColumnQualify.FieldName = "QualifyStatusPic";
            this.bandedGridColumnQualify.Name = "bandedGridColumnQualify";
            this.bandedGridColumnQualify.RowCount = 2;
            this.bandedGridColumnQualify.Visible = true;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.Caption = "bandedGridColumn7";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            // 
            // bandedGridColumnTooling
            // 
            this.bandedGridColumnTooling.Caption = "工装";
            this.bandedGridColumnTooling.FieldName = "ToolingStatusPic";
            this.bandedGridColumnTooling.Name = "bandedGridColumnTooling";
            this.bandedGridColumnTooling.RowCount = 2;
            this.bandedGridColumnTooling.Visible = true;
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.Caption = "bandedGridColumn9";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.Visible = true;
            // 
            // bandedGridColumnSecurity
            // 
            this.bandedGridColumnSecurity.Caption = "安全";
            this.bandedGridColumnSecurity.FieldName = "SecurityStatusPic";
            this.bandedGridColumnSecurity.Name = "bandedGridColumnSecurity";
            this.bandedGridColumnSecurity.Visible = true;
            // 
            // bandedGridColumn11
            // 
            this.bandedGridColumn11.Caption = "bandedGridColumn11";
            this.bandedGridColumn11.Name = "bandedGridColumn11";
            this.bandedGridColumn11.Visible = true;
            // 
            // bandedGridColumn12
            // 
            this.bandedGridColumn12.Caption = "bandedGridColumn12";
            this.bandedGridColumn12.Name = "bandedGridColumn12";
            this.bandedGridColumn12.Visible = true;
            // 
            // bandedGridColumn13
            // 
            this.bandedGridColumn13.Caption = "bandedGridColumn13";
            this.bandedGridColumn13.Name = "bandedGridColumn13";
            this.bandedGridColumn13.Visible = true;
            // 
            // bandedGridColumn14
            // 
            this.bandedGridColumn14.Caption = "bandedGridColumn14";
            this.bandedGridColumn14.Name = "bandedGridColumn14";
            this.bandedGridColumn14.Visible = true;
            // 
            // bandedGridColumn15
            // 
            this.bandedGridColumn15.Caption = "bandedGridColumn15";
            this.bandedGridColumn15.Name = "bandedGridColumn15";
            this.bandedGridColumn15.Visible = true;
            // 
            // bandedGridColumn16
            // 
            this.bandedGridColumn16.Caption = "bandedGridColumn16";
            this.bandedGridColumn16.Name = "bandedGridColumn16";
            this.bandedGridColumn16.Visible = true;
            // 
            // bandedGridColumn17
            // 
            this.bandedGridColumn17.Caption = "bandedGridColumn17";
            this.bandedGridColumn17.Name = "bandedGridColumn17";
            this.bandedGridColumn17.Visible = true;
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
            // frmKanbanPS_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.grdPrdtLines);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmKanbanPS_30";
            this.Text = "产线安灯状态";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.grdPrdtLines, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
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
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnArea;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnProductionLine;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnMaterial;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnMaterialTimeElapsed;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnEquipment;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnQualify;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnTooling;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumnSecurity;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn16;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn17;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
    }
}
