namespace IRAP.Client.GUI.AsimcoPrdtPackage.UserControls
{
    partial class ucPackageLabelConfirm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpcPackageSOs = new DevExpress.XtraEditors.GroupControl();
            this.grdPackageLabels = new DevExpress.XtraGrid.GridControl();
            this.grdvPackageLabels = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCartonProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCartonNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnBoxNumberOfCarton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSupplyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPrintDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.richkChoice = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnRequestReprint = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gpcPackageSOs)).BeginInit();
            this.gpcPackageSOs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPackageLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPackageLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richkChoice)).BeginInit();
            this.SuspendLayout();
            // 
            // gpcPackageSOs
            // 
            this.gpcPackageSOs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcPackageSOs.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.gpcPackageSOs.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.gpcPackageSOs.Appearance.Options.UseBackColor = true;
            this.gpcPackageSOs.Appearance.Options.UseFont = true;
            this.gpcPackageSOs.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcPackageSOs.AppearanceCaption.Options.UseFont = true;
            this.gpcPackageSOs.Controls.Add(this.grdPackageLabels);
            this.gpcPackageSOs.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("刷新", null)});
            this.gpcPackageSOs.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.gpcPackageSOs.Location = new System.Drawing.Point(13, 12);
            this.gpcPackageSOs.Name = "gpcPackageSOs";
            this.gpcPackageSOs.Padding = new System.Windows.Forms.Padding(5);
            this.gpcPackageSOs.Size = new System.Drawing.Size(748, 524);
            this.gpcPackageSOs.TabIndex = 2;
            this.gpcPackageSOs.Text = "待确认标签";
            this.gpcPackageSOs.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.gpcPackageSOs_CustomButtonClick);
            // 
            // grdPackageLabels
            // 
            this.grdPackageLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPackageLabels.Location = new System.Drawing.Point(7, 32);
            this.grdPackageLabels.MainView = this.grdvPackageLabels;
            this.grdPackageLabels.Name = "grdPackageLabels";
            this.grdPackageLabels.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.richkChoice});
            this.grdPackageLabels.Size = new System.Drawing.Size(734, 485);
            this.grdPackageLabels.TabIndex = 2;
            this.grdPackageLabels.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPackageLabels});
            // 
            // grdvPackageLabels
            // 
            this.grdvPackageLabels.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvPackageLabels.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvPackageLabels.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvPackageLabels.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvPackageLabels.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvPackageLabels.Appearance.Row.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvPackageLabels.Appearance.Row.Options.UseFont = true;
            this.grdvPackageLabels.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnCartonProductNo,
            this.grdclmnCartonNumber,
            this.grdclmnBoxNumberOfCarton,
            this.grdclmnSupplyCode,
            this.grdclmnPrintDate,
            this.grdclmnChoice});
            this.grdvPackageLabels.GridControl = this.grdPackageLabels;
            this.grdvPackageLabels.Name = "grdvPackageLabels";
            this.grdvPackageLabels.OptionsView.ColumnAutoWidth = false;
            this.grdvPackageLabels.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvPackageLabels.OptionsView.RowAutoHeight = true;
            this.grdvPackageLabels.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.Caption = "序号";
            this.grdclmnOrdinal.FieldName = "Ordinal";
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnOrdinal.OptionsColumn.AllowMove = false;
            this.grdclmnOrdinal.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnOrdinal.OptionsColumn.ReadOnly = true;
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
            // 
            // grdclmnCartonProductNo
            // 
            this.grdclmnCartonProductNo.Caption = "物料号";
            this.grdclmnCartonProductNo.FieldName = "CartonProductNo";
            this.grdclmnCartonProductNo.Name = "grdclmnCartonProductNo";
            this.grdclmnCartonProductNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnCartonProductNo.OptionsColumn.AllowMove = false;
            this.grdclmnCartonProductNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnCartonProductNo.OptionsColumn.ReadOnly = true;
            this.grdclmnCartonProductNo.Visible = true;
            this.grdclmnCartonProductNo.VisibleIndex = 1;
            // 
            // grdclmnCartonNumber
            // 
            this.grdclmnCartonNumber.Caption = "外箱标签";
            this.grdclmnCartonNumber.FieldName = "CartonNumber";
            this.grdclmnCartonNumber.Name = "grdclmnCartonNumber";
            this.grdclmnCartonNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnCartonNumber.OptionsColumn.AllowMove = false;
            this.grdclmnCartonNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnCartonNumber.OptionsColumn.ReadOnly = true;
            this.grdclmnCartonNumber.Visible = true;
            this.grdclmnCartonNumber.VisibleIndex = 2;
            // 
            // grdclmnBoxNumberOfCarton
            // 
            this.grdclmnBoxNumberOfCarton.Caption = "内箱标签数量";
            this.grdclmnBoxNumberOfCarton.FieldName = "BoxNumberOfCarton";
            this.grdclmnBoxNumberOfCarton.Name = "grdclmnBoxNumberOfCarton";
            this.grdclmnBoxNumberOfCarton.OptionsColumn.ReadOnly = true;
            this.grdclmnBoxNumberOfCarton.Visible = true;
            this.grdclmnBoxNumberOfCarton.VisibleIndex = 3;
            this.grdclmnBoxNumberOfCarton.Width = 100;
            // 
            // grdclmnSupplyCode
            // 
            this.grdclmnSupplyCode.Caption = "客户";
            this.grdclmnSupplyCode.FieldName = "SupplyCode";
            this.grdclmnSupplyCode.Name = "grdclmnSupplyCode";
            this.grdclmnSupplyCode.OptionsColumn.ReadOnly = true;
            this.grdclmnSupplyCode.Visible = true;
            this.grdclmnSupplyCode.VisibleIndex = 4;
            this.grdclmnSupplyCode.Width = 90;
            // 
            // grdclmnPrintDate
            // 
            this.grdclmnPrintDate.Caption = "打印时间";
            this.grdclmnPrintDate.FieldName = "PrintDate";
            this.grdclmnPrintDate.Name = "grdclmnPrintDate";
            this.grdclmnPrintDate.OptionsColumn.ReadOnly = true;
            this.grdclmnPrintDate.Visible = true;
            this.grdclmnPrintDate.VisibleIndex = 5;
            // 
            // grdclmnChoice
            // 
            this.grdclmnChoice.Caption = "选择";
            this.grdclmnChoice.ColumnEdit = this.richkChoice;
            this.grdclmnChoice.FieldName = "Choice";
            this.grdclmnChoice.Name = "grdclmnChoice";
            this.grdclmnChoice.OptionsColumn.ShowCaption = false;
            this.grdclmnChoice.Visible = true;
            this.grdclmnChoice.VisibleIndex = 6;
            // 
            // richkChoice
            // 
            this.richkChoice.AutoHeight = false;
            this.richkChoice.Name = "richkChoice";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(779, 14);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 41);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnRequestReprint
            // 
            this.btnRequestReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestReprint.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestReprint.Appearance.Options.UseFont = true;
            this.btnRequestReprint.Location = new System.Drawing.Point(779, 194);
            this.btnRequestReprint.Name = "btnRequestReprint";
            this.btnRequestReprint.Size = new System.Drawing.Size(90, 41);
            this.btnRequestReprint.TabIndex = 13;
            this.btnRequestReprint.Text = "申请重打";
            this.btnRequestReprint.Click += new System.EventHandler(this.btnRequestReprint_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Appearance.Options.UseFont = true;
            this.btnSelectAll.Location = new System.Drawing.Point(779, 71);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(90, 27);
            this.btnSelectAll.TabIndex = 11;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnselectAll.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnselectAll.Appearance.Options.UseFont = true;
            this.btnUnselectAll.Location = new System.Drawing.Point(779, 104);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(90, 27);
            this.btnUnselectAll.TabIndex = 12;
            this.btnUnselectAll.Text = "全不选";
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // ucPackageLabelConfirm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnUnselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnRequestReprint);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.gpcPackageSOs);
            this.Name = "ucPackageLabelConfirm";
            this.Size = new System.Drawing.Size(882, 551);
            this.Load += new System.EventHandler(this.ucPackageLabelConfirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gpcPackageSOs)).EndInit();
            this.gpcPackageSOs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPackageLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPackageLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richkChoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpcPackageSOs;
        private DevExpress.XtraGrid.GridControl grdPackageLabels;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPackageLabels;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCartonProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCartonNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnBoxNumberOfCarton;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSupplyCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPrintDate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit richkChoice;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.SimpleButton btnRequestReprint;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnUnselectAll;
    }
}
