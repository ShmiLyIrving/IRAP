namespace IRAP.Client.GUI.MESPDC
{
    partial class frmProductionLabelPrint_Casting
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cboBatchNo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboFurnaces = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelProductionDate = new DevExpress.XtraEditors.LabelControl();
            this.dtProductDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelFurnaceTime = new DevExpress.XtraEditors.LabelControl();
            this.btn_Print = new DevExpress.XtraEditors.SimpleButton();
            this.grdCtrProductionInfo = new DevExpress.XtraGrid.GridControl();
            this.grdCtrProductionInfoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColT131Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColT102Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColPlateNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColLotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColMachineModelling = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColFoldNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBatchNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFurnaces.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFuncName.Size = new System.Drawing.Size(878, 56);
            this.lblFuncName.Text = "产品标识卡打印";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(878, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.LookAndFeel.SkinName = "Blue";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.cboBatchNo);
            this.panelControl2.Controls.Add(this.cboFurnaces);
            this.panelControl2.Controls.Add(this.labelProductionDate);
            this.panelControl2.Controls.Add(this.dtProductDate);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.labelFurnaceTime);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 56);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(878, 56);
            this.panelControl2.TabIndex = 2;
            // 
            // cboBatchNo
            // 
            this.cboBatchNo.Location = new System.Drawing.Point(683, 18);
            this.cboBatchNo.Name = "cboBatchNo";
            this.cboBatchNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboBatchNo.Properties.Appearance.Options.UseFont = true;
            this.cboBatchNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBatchNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBatchNo.Size = new System.Drawing.Size(162, 26);
            this.cboBatchNo.TabIndex = 11;
            this.cboBatchNo.SelectedIndexChanged += new System.EventHandler(this.cboBatchNo_SelectedIndexChanged);
            // 
            // cboFurnaces
            // 
            this.cboFurnaces.Location = new System.Drawing.Point(297, 18);
            this.cboFurnaces.Name = "cboFurnaces";
            this.cboFurnaces.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboFurnaces.Properties.Appearance.Options.UseFont = true;
            this.cboFurnaces.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFurnaces.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboFurnaces.Size = new System.Drawing.Size(332, 26);
            this.cboFurnaces.TabIndex = 11;
            this.cboFurnaces.SelectedIndexChanged += new System.EventHandler(this.cboFurnaces_SelectedIndexChanged);
            // 
            // labelProductionDate
            // 
            this.labelProductionDate.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductionDate.Location = new System.Drawing.Point(18, 21);
            this.labelProductionDate.Name = "labelProductionDate";
            this.labelProductionDate.Size = new System.Drawing.Size(70, 20);
            this.labelProductionDate.TabIndex = 3;
            this.labelProductionDate.Text = "生产日期：";
            // 
            // dtProductDate
            // 
            this.dtProductDate.EditValue = new System.DateTime(2018, 1, 25, 10, 41, 25, 67);
            this.dtProductDate.Location = new System.Drawing.Point(94, 18);
            this.dtProductDate.Name = "dtProductDate";
            this.dtProductDate.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtProductDate.Properties.Appearance.Options.UseFont = true;
            this.dtProductDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtProductDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.dtProductDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtProductDate.Properties.DisplayFormat.FormatString = "yyyy 年 M 月 d 日";
            this.dtProductDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtProductDate.Properties.EditFormat.FormatString = "yyyy 年 M 月 d 日";
            this.dtProductDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtProductDate.Properties.Mask.EditMask = "yyyy 年 M 月 d 日";
            this.dtProductDate.Properties.MinValue = new System.DateTime(2018, 1, 24, 10, 41, 25, 67);
            this.dtProductDate.Properties.NullDateCalendarValue = new System.DateTime(2018, 1, 25, 10, 41, 25, 67);
            this.dtProductDate.Size = new System.Drawing.Size(149, 26);
            this.dtProductDate.TabIndex = 10;
            this.dtProductDate.EditValueChanged += new System.EventHandler(this.dtProductDate_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(635, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 20);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "炉次：";
            // 
            // labelFurnaceTime
            // 
            this.labelFurnaceTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFurnaceTime.Location = new System.Drawing.Point(249, 21);
            this.labelFurnaceTime.Name = "labelFurnaceTime";
            this.labelFurnaceTime.Size = new System.Drawing.Size(42, 20);
            this.labelFurnaceTime.TabIndex = 5;
            this.labelFurnaceTime.Text = "设备：";
            // 
            // btn_Print
            // 
            this.btn_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Print.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.Appearance.Options.UseFont = true;
            this.btn_Print.Location = new System.Drawing.Point(786, 118);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(88, 45);
            this.btn_Print.TabIndex = 5;
            this.btn_Print.Text = "打印";
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // grdCtrProductionInfo
            // 
            this.grdCtrProductionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrProductionInfo.Location = new System.Drawing.Point(7, 7);
            this.grdCtrProductionInfo.MainView = this.grdCtrProductionInfoView;
            this.grdCtrProductionInfo.Margin = new System.Windows.Forms.Padding(5);
            this.grdCtrProductionInfo.Name = "grdCtrProductionInfo";
            this.grdCtrProductionInfo.Padding = new System.Windows.Forms.Padding(5);
            this.grdCtrProductionInfo.Size = new System.Drawing.Size(766, 393);
            this.grdCtrProductionInfo.TabIndex = 3;
            this.grdCtrProductionInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdCtrProductionInfoView,
            this.gridView1});
            // 
            // grdCtrProductionInfoView
            // 
            this.grdCtrProductionInfoView.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdCtrProductionInfoView.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdCtrProductionInfoView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdCtrProductionInfoView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdCtrProductionInfoView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdCtrProductionInfoView.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdCtrProductionInfoView.Appearance.Row.Options.UseFont = true;
            this.grdCtrProductionInfoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPrint,
            this.ColMONumber,
            this.ColMOLineNo,
            this.ColT131Name,
            this.ColT102Code,
            this.ColPlateNo,
            this.ColLotNumber,
            this.ColMachineModelling,
            this.ColFoldNumber});
            this.grdCtrProductionInfoView.GridControl = this.grdCtrProductionInfo;
            this.grdCtrProductionInfoView.Name = "grdCtrProductionInfoView";
            this.grdCtrProductionInfoView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grdCtrProductionInfoView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grdCtrProductionInfoView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.grdCtrProductionInfoView.OptionsBehavior.AllowPartialGroups = DevExpress.Utils.DefaultBoolean.False;
            this.grdCtrProductionInfoView.OptionsBehavior.AllowPartialRedrawOnScrolling = false;
            this.grdCtrProductionInfoView.OptionsBehavior.AutoPopulateColumns = false;
            this.grdCtrProductionInfoView.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.grdCtrProductionInfoView.OptionsCustomization.AllowColumnMoving = false;
            this.grdCtrProductionInfoView.OptionsCustomization.AllowGroup = false;
            this.grdCtrProductionInfoView.OptionsCustomization.AllowRowSizing = true;
            this.grdCtrProductionInfoView.OptionsView.ColumnAutoWidth = false;
            this.grdCtrProductionInfoView.OptionsView.ShowGroupPanel = false;
            // 
            // colPrint
            // 
            this.colPrint.Caption = "打印";
            this.colPrint.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPrint.FieldName = "IsPrint";
            this.colPrint.Name = "colPrint";
            this.colPrint.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPrint.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPrint.OptionsColumn.AllowMove = false;
            this.colPrint.OptionsColumn.AllowShowHide = false;
            this.colPrint.Visible = true;
            this.colPrint.VisibleIndex = 0;
            // 
            // ColMONumber
            // 
            this.ColMONumber.Caption = "订单号";
            this.ColMONumber.FieldName = "MONumber";
            this.ColMONumber.Name = "ColMONumber";
            this.ColMONumber.OptionsColumn.AllowEdit = false;
            this.ColMONumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColMONumber.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColMONumber.OptionsColumn.AllowMove = false;
            this.ColMONumber.OptionsColumn.ReadOnly = true;
            this.ColMONumber.Visible = true;
            this.ColMONumber.VisibleIndex = 1;
            // 
            // ColMOLineNo
            // 
            this.ColMOLineNo.Caption = "行号";
            this.ColMOLineNo.FieldName = "MOLineNo";
            this.ColMOLineNo.Name = "ColMOLineNo";
            this.ColMOLineNo.OptionsColumn.AllowEdit = false;
            this.ColMOLineNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColMOLineNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColMOLineNo.OptionsColumn.AllowMove = false;
            this.ColMOLineNo.OptionsColumn.ReadOnly = true;
            this.ColMOLineNo.Visible = true;
            this.ColMOLineNo.VisibleIndex = 2;
            // 
            // ColT131Name
            // 
            this.ColT131Name.Caption = "材质";
            this.ColT131Name.FieldName = "T131Name";
            this.ColT131Name.Name = "ColT131Name";
            this.ColT131Name.OptionsColumn.AllowEdit = false;
            this.ColT131Name.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColT131Name.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColT131Name.OptionsColumn.AllowMove = false;
            this.ColT131Name.OptionsColumn.ReadOnly = true;
            this.ColT131Name.Visible = true;
            this.ColT131Name.VisibleIndex = 3;
            // 
            // ColT102Code
            // 
            this.ColT102Code.Caption = "物料号";
            this.ColT102Code.FieldName = "T102Code";
            this.ColT102Code.Name = "ColT102Code";
            this.ColT102Code.OptionsColumn.AllowEdit = false;
            this.ColT102Code.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColT102Code.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColT102Code.OptionsColumn.AllowMove = false;
            this.ColT102Code.OptionsColumn.ReadOnly = true;
            this.ColT102Code.Visible = true;
            this.ColT102Code.VisibleIndex = 4;
            // 
            // ColPlateNo
            // 
            this.ColPlateNo.Caption = "型板";
            this.ColPlateNo.FieldName = "PlateNo";
            this.ColPlateNo.Name = "ColPlateNo";
            this.ColPlateNo.OptionsColumn.AllowEdit = false;
            this.ColPlateNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColPlateNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColPlateNo.OptionsColumn.AllowMove = false;
            this.ColPlateNo.OptionsColumn.ReadOnly = true;
            this.ColPlateNo.Visible = true;
            this.ColPlateNo.VisibleIndex = 5;
            // 
            // ColLotNumber
            // 
            this.ColLotNumber.Caption = "毛坯批次号";
            this.ColLotNumber.FieldName = "LotNumber";
            this.ColLotNumber.Name = "ColLotNumber";
            this.ColLotNumber.OptionsColumn.AllowEdit = false;
            this.ColLotNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColLotNumber.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColLotNumber.OptionsColumn.AllowMove = false;
            this.ColLotNumber.OptionsColumn.ReadOnly = true;
            this.ColLotNumber.Visible = true;
            this.ColLotNumber.VisibleIndex = 6;
            // 
            // ColMachineModelling
            // 
            this.ColMachineModelling.Caption = "造型机台";
            this.ColMachineModelling.FieldName = "MachineModelling";
            this.ColMachineModelling.Name = "ColMachineModelling";
            this.ColMachineModelling.OptionsColumn.AllowEdit = false;
            this.ColMachineModelling.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColMachineModelling.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColMachineModelling.OptionsColumn.AllowMove = false;
            this.ColMachineModelling.OptionsColumn.ReadOnly = true;
            this.ColMachineModelling.Visible = true;
            this.ColMachineModelling.VisibleIndex = 7;
            // 
            // ColFoldNumber
            // 
            this.ColFoldNumber.Caption = "叠数";
            this.ColFoldNumber.FieldName = "FoldNumber";
            this.ColFoldNumber.Name = "ColFoldNumber";
            this.ColFoldNumber.OptionsColumn.AllowEdit = false;
            this.ColFoldNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColFoldNumber.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColFoldNumber.OptionsColumn.AllowMove = false;
            this.ColFoldNumber.OptionsColumn.ReadOnly = true;
            this.ColFoldNumber.Visible = true;
            this.ColFoldNumber.VisibleIndex = 8;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdCtrProductionInfo;
            this.gridView1.Name = "gridView1";
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl3.Controls.Add(this.grdCtrProductionInfo);
            this.panelControl3.Location = new System.Drawing.Point(0, 116);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl3.Size = new System.Drawing.Size(780, 407);
            this.panelControl3.TabIndex = 6;
            // 
            // frmProductionLabelPrint_Casting
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 523);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.btn_Print);
            this.Name = "frmProductionLabelPrint_Casting";
            this.Text = "产品标识卡打印";
            this.Controls.SetChildIndex(this.btn_Print, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.panelControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBatchNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFurnaces.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelProductionDate;
        private DevExpress.XtraEditors.DateEdit dtProductDate;
        private DevExpress.XtraEditors.LabelControl labelFurnaceTime;
        private DevExpress.XtraEditors.SimpleButton btn_Print;
        private DevExpress.XtraEditors.ComboBoxEdit cboBatchNo;
        private DevExpress.XtraEditors.ComboBoxEdit cboFurnaces;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdCtrProductionInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdCtrProductionInfoView;
        private DevExpress.XtraGrid.Columns.GridColumn colPrint;
        private DevExpress.XtraGrid.Columns.GridColumn ColMONumber;
        private DevExpress.XtraGrid.Columns.GridColumn ColMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColT131Name;
        private DevExpress.XtraGrid.Columns.GridColumn ColT102Code;
        private DevExpress.XtraGrid.Columns.GridColumn ColPlateNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColLotNumber;
        private DevExpress.XtraGrid.Columns.GridColumn ColMachineModelling;
        private DevExpress.XtraGrid.Columns.GridColumn ColFoldNumber;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
    }
}