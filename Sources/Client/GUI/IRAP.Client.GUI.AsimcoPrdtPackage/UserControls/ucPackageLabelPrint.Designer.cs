namespace IRAP.Client.GUI.AsimcoPrdtPackage.UserControls
{
    partial class ucPackageLabelPrint
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
            this.grdPackageSOs = new DevExpress.XtraGrid.GridControl();
            this.grdvPackageSOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLabelPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gpcPackageSOs = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdPackageSOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPackageSOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcPackageSOs)).BeginInit();
            this.gpcPackageSOs.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPackageSOs
            // 
            this.grdPackageSOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPackageSOs.Location = new System.Drawing.Point(7, 32);
            this.grdPackageSOs.MainView = this.grdvPackageSOs;
            this.grdPackageSOs.Name = "grdPackageSOs";
            this.grdPackageSOs.Size = new System.Drawing.Size(734, 485);
            this.grdPackageSOs.TabIndex = 2;
            this.grdPackageSOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPackageSOs});
            // 
            // grdvPackageSOs
            // 
            this.grdvPackageSOs.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvPackageSOs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvPackageSOs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvPackageSOs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvPackageSOs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvPackageSOs.Appearance.Row.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvPackageSOs.Appearance.Row.Options.UseFont = true;
            this.grdvPackageSOs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grdvPackageSOs.GridControl = this.grdPackageSOs;
            this.grdvPackageSOs.Name = "grdvPackageSOs";
            this.grdvPackageSOs.OptionsBehavior.Editable = false;
            this.grdvPackageSOs.OptionsView.ColumnAutoWidth = false;
            this.grdvPackageSOs.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvPackageSOs.OptionsView.RowAutoHeight = true;
            this.grdvPackageSOs.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "订单号";
            this.gridColumn1.FieldName = "MONumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "行号";
            this.gridColumn2.FieldName = "MOLineNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "产品名称";
            this.gridColumn3.FieldName = "ProductdName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "客户名称";
            this.gridColumn7.FieldName = "CustomerName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "总数量";
            this.gridColumn4.FieldName = "PlanQty";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "已打印数量";
            this.gridColumn5.FieldName = "PrintedQty";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 90;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "剩余数量";
            this.gridColumn6.FieldName = "LeftQty";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // btnLabelPrint
            // 
            this.btnLabelPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLabelPrint.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLabelPrint.Appearance.Options.UseFont = true;
            this.btnLabelPrint.Location = new System.Drawing.Point(779, 14);
            this.btnLabelPrint.Name = "btnLabelPrint";
            this.btnLabelPrint.Size = new System.Drawing.Size(90, 41);
            this.btnLabelPrint.TabIndex = 9;
            this.btnLabelPrint.Text = "打印标签";
            this.btnLabelPrint.Click += new System.EventHandler(this.btnLabelPrint_Click);
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
            this.gpcPackageSOs.Controls.Add(this.grdPackageSOs);
            this.gpcPackageSOs.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("刷新订单", null)});
            this.gpcPackageSOs.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.gpcPackageSOs.Location = new System.Drawing.Point(13, 12);
            this.gpcPackageSOs.Name = "gpcPackageSOs";
            this.gpcPackageSOs.Padding = new System.Windows.Forms.Padding(5);
            this.gpcPackageSOs.Size = new System.Drawing.Size(748, 524);
            this.gpcPackageSOs.TabIndex = 1;
            this.gpcPackageSOs.Text = "待打印包装标签的订单";
            this.gpcPackageSOs.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.gpcPackageSOs_CustomButtonClick);
            // 
            // ucPackageLabelPrint
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gpcPackageSOs);
            this.Controls.Add(this.btnLabelPrint);
            this.Name = "ucPackageLabelPrint";
            this.Size = new System.Drawing.Size(882, 551);
            this.Load += new System.EventHandler(this.ucPackageLabelPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPackageSOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPackageSOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcPackageSOs)).EndInit();
            this.gpcPackageSOs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPackageSOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPackageSOs;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnLabelPrint;
        private DevExpress.XtraEditors.GroupControl gpcPackageSOs;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}
