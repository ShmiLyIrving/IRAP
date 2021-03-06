﻿namespace IRAP.Client.GUI.AsimcoPrdtPackage.UserControls
{
    partial class ucPackabeLabelReprint
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
            this.richkChoice = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboPrinters = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcPackageSOs)).BeginInit();
            this.gpcPackageSOs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPackageLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPackageLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richkChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrinters.Properties)).BeginInit();
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
            this.gpcPackageSOs.Location = new System.Drawing.Point(13, 84);
            this.gpcPackageSOs.Name = "gpcPackageSOs";
            this.gpcPackageSOs.Padding = new System.Windows.Forms.Padding(5);
            this.gpcPackageSOs.Size = new System.Drawing.Size(748, 452);
            this.gpcPackageSOs.TabIndex = 3;
            this.gpcPackageSOs.Text = "待重打标签";
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
            this.grdPackageLabels.Size = new System.Drawing.Size(734, 413);
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
            this.grdclmnSupplyCode});
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
            // richkChoice
            // 
            this.richkChoice.AutoHeight = false;
            this.richkChoice.Name = "richkChoice";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(779, 14);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 41);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "打印标签";
            this.btnPrint.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl2.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.cboPrinters);
            this.groupControl2.Location = new System.Drawing.Point(13, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(748, 66);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "打印到";
            // 
            // cboPrinters
            // 
            this.cboPrinters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinters.Location = new System.Drawing.Point(14, 33);
            this.cboPrinters.Name = "cboPrinters";
            this.cboPrinters.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrinters.Properties.Appearance.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceDisabled.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceDropDown.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceFocused.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboPrinters.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPrinters.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPrinters.Size = new System.Drawing.Size(719, 20);
            this.cboPrinters.TabIndex = 11;
            this.cboPrinters.SelectedIndexChanged += new System.EventHandler(this.cboPrinters_SelectedIndexChanged);
            // 
            // ucPackabeLabelReprint
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.gpcPackageSOs);
            this.Name = "ucPackabeLabelReprint";
            this.Size = new System.Drawing.Size(882, 551);
            this.Load += new System.EventHandler(this.ucPackabeLabelReprint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gpcPackageSOs)).EndInit();
            this.gpcPackageSOs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPackageLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPackageLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richkChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPrinters.Properties)).EndInit();
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
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit richkChoice;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboPrinters;
    }
}
