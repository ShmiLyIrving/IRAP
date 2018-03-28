using System;
namespace IRAP.Client.GUI.MESPDC.UserControls {
    partial class ucFurnace {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.grdCtrProductionInfo = new DevExpress.XtraGrid.GridControl();
            this.grdCtrProductionInfoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ColMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColT131Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColT102Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColPlateNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColLotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColMachineModelling = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColFoldNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelController = new DevExpress.XtraEditors.LabelControl();
            this.txtOperator = new DevExpress.XtraEditors.TextEdit();
            this.labelProductionDate = new DevExpress.XtraEditors.LabelControl();
            this.labelFurnaceTime = new DevExpress.XtraEditors.LabelControl();
            this.lblProductionTimeResult = new DevExpress.XtraEditors.LabelControl();
            this.lblProductionTime = new DevExpress.XtraEditors.LabelControl();
            this.labProductStartTimeResult = new DevExpress.XtraEditors.LabelControl();
            this.labCurrentFurnaceResult = new DevExpress.XtraEditors.LabelControl();
            this.labCurrentFurnace = new DevExpress.XtraEditors.LabelControl();
            this.labCtrlStartTime = new DevExpress.XtraEditors.LabelControl();
            this.tabCtrlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tabPgBurden = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpBurdenInfo = new DevExpress.XtraEditors.GroupControl();
            this.grdBurdenInfo = new DevExpress.XtraGrid.GridControl();
            this.grdBurdenInfoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColT101Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColT101Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColBatchLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ColQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpProductPara = new DevExpress.XtraEditors.GroupControl();
            this.grdProductPara = new DevExpress.XtraGrid.GridControl();
            this.grdProductParaView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColT20Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.tabPgSpectrum = new DevExpress.XtraTab.XtraTabPage();
            this.ucGrdSpectrum = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            this.tabPgMatieralAjustment = new DevExpress.XtraTab.XtraTabPage();
            this.btnRowMaterialDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnRowMaterialSave = new DevExpress.XtraEditors.SimpleButton();
            this.grdRowMaterial = new DevExpress.XtraGrid.GridControl();
            this.grdRowMaterialView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPgSample = new DevExpress.XtraTab.XtraTabPage();
            this.ucGrdSample = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            this.tabPgBaked = new DevExpress.XtraTab.XtraTabPage();
            this.ucGrdBaked = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            this.dtProductDate = new DevExpress.XtraEditors.DateEdit();
            this.lblFurnaceTime = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlDetail)).BeginInit();
            this.tabCtrlDetail.SuspendLayout();
            this.tabPgBurden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBurdenInfo)).BeginInit();
            this.grpBurdenInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBurdenInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBurdenInfoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpProductPara)).BeginInit();
            this.grpProductPara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductParaView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.tabPgSpectrum.SuspendLayout();
            this.tabPgMatieralAjustment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRowMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRowMaterialView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.tabPgSample.SuspendLayout();
            this.tabPgBaked.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPrint.Location = new System.Drawing.Point(5, 84);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 32);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // grdCtrProductionInfo
            // 
            this.grdCtrProductionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrProductionInfo.Location = new System.Drawing.Point(5, 5);
            this.grdCtrProductionInfo.MainView = this.grdCtrProductionInfoView;
            this.grdCtrProductionInfo.Name = "grdCtrProductionInfo";
            this.grdCtrProductionInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdCtrProductionInfo.Size = new System.Drawing.Size(494, 111);
            this.grdCtrProductionInfo.TabIndex = 0;
            this.grdCtrProductionInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdCtrProductionInfoView});
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
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
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
            // labelController
            // 
            this.labelController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelController.Location = new System.Drawing.Point(3, 3);
            this.labelController.Name = "labelController";
            this.labelController.Size = new System.Drawing.Size(56, 20);
            this.labelController.TabIndex = 1;
            this.labelController.Text = "操作工：";
            // 
            // txtOperator
            // 
            this.txtOperator.EnterMoveNextControl = true;
            this.txtOperator.Location = new System.Drawing.Point(65, 0);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOperator.Properties.Appearance.Options.UseFont = true;
            this.txtOperator.Size = new System.Drawing.Size(189, 26);
            this.txtOperator.TabIndex = 2;
            this.txtOperator.Validating += new System.ComponentModel.CancelEventHandler(this.txtOperator_Validating);
            // 
            // labelProductionDate
            // 
            this.labelProductionDate.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductionDate.Location = new System.Drawing.Point(260, 3);
            this.labelProductionDate.Name = "labelProductionDate";
            this.labelProductionDate.Size = new System.Drawing.Size(70, 20);
            this.labelProductionDate.TabIndex = 3;
            this.labelProductionDate.Text = "生产日期：";
            // 
            // labelFurnaceTime
            // 
            this.labelFurnaceTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFurnaceTime.Location = new System.Drawing.Point(491, 3);
            this.labelFurnaceTime.Name = "labelFurnaceTime";
            this.labelFurnaceTime.Size = new System.Drawing.Size(42, 20);
            this.labelFurnaceTime.TabIndex = 5;
            this.labelFurnaceTime.Text = "炉次：";
            // 
            // lblProductionTimeResult
            // 
            this.lblProductionTimeResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductionTimeResult.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductionTimeResult.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblProductionTimeResult.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblProductionTimeResult.AutoEllipsis = true;
            this.lblProductionTimeResult.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProductionTimeResult.Location = new System.Drawing.Point(130, 89);
            this.lblProductionTimeResult.Name = "lblProductionTimeResult";
            this.lblProductionTimeResult.Size = new System.Drawing.Size(171, 14);
            this.lblProductionTimeResult.TabIndex = 15;
            // 
            // lblProductionTime
            // 
            this.lblProductionTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductionTime.Location = new System.Drawing.Point(44, 86);
            this.lblProductionTime.Name = "lblProductionTime";
            this.lblProductionTime.Size = new System.Drawing.Size(80, 21);
            this.lblProductionTime.TabIndex = 14;
            this.lblProductionTime.Text = "生产时长：";
            // 
            // labProductStartTimeResult
            // 
            this.labProductStartTimeResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labProductStartTimeResult.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labProductStartTimeResult.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labProductStartTimeResult.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labProductStartTimeResult.AutoEllipsis = true;
            this.labProductStartTimeResult.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labProductStartTimeResult.Location = new System.Drawing.Point(130, 54);
            this.labProductStartTimeResult.Name = "labProductStartTimeResult";
            this.labProductStartTimeResult.Size = new System.Drawing.Size(171, 14);
            this.labProductStartTimeResult.TabIndex = 13;
            // 
            // labCurrentFurnaceResult
            // 
            this.labCurrentFurnaceResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labCurrentFurnaceResult.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCurrentFurnaceResult.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labCurrentFurnaceResult.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labCurrentFurnaceResult.AutoEllipsis = true;
            this.labCurrentFurnaceResult.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCurrentFurnaceResult.Location = new System.Drawing.Point(130, 19);
            this.labCurrentFurnaceResult.Name = "labCurrentFurnaceResult";
            this.labCurrentFurnaceResult.Size = new System.Drawing.Size(171, 14);
            this.labCurrentFurnaceResult.TabIndex = 12;
            // 
            // labCurrentFurnace
            // 
            this.labCurrentFurnace.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCurrentFurnace.Location = new System.Drawing.Point(28, 16);
            this.labCurrentFurnace.Name = "labCurrentFurnace";
            this.labCurrentFurnace.Size = new System.Drawing.Size(96, 21);
            this.labCurrentFurnace.TabIndex = 10;
            this.labCurrentFurnace.Text = "当前炉次号：";
            // 
            // labCtrlStartTime
            // 
            this.labCtrlStartTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCtrlStartTime.Location = new System.Drawing.Point(12, 51);
            this.labCtrlStartTime.Name = "labCtrlStartTime";
            this.labCtrlStartTime.Size = new System.Drawing.Size(112, 21);
            this.labCtrlStartTime.TabIndex = 8;
            this.labCtrlStartTime.Text = "生产开始时间：";
            // 
            // tabCtrlDetail
            // 
            this.tabCtrlDetail.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrlDetail.Appearance.Options.UseFont = true;
            this.tabCtrlDetail.AppearancePage.Header.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tabCtrlDetail.AppearancePage.Header.Options.UseFont = true;
            this.tabCtrlDetail.AppearancePage.HeaderActive.Font = new System.Drawing.Font("微软雅黑", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabCtrlDetail.AppearancePage.HeaderActive.FontStyleDelta = System.Drawing.FontStyle.Underline;
            this.tabCtrlDetail.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.Blue;
            this.tabCtrlDetail.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabCtrlDetail.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.tabCtrlDetail.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Underline);
            this.tabCtrlDetail.AppearancePage.HeaderHotTracked.FontStyleDelta = System.Drawing.FontStyle.Underline;
            this.tabCtrlDetail.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.tabCtrlDetail.AppearancePage.PageClient.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tabCtrlDetail.AppearancePage.PageClient.Options.UseFont = true;
            this.tabCtrlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlDetail.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlDetail.Name = "tabCtrlDetail";
            this.tabCtrlDetail.SelectedTabPage = this.tabPgBurden;
            this.tabCtrlDetail.Size = new System.Drawing.Size(926, 293);
            this.tabCtrlDetail.TabIndex = 9;
            this.tabCtrlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPgBurden,
            this.tabPgSpectrum,
            this.tabPgMatieralAjustment,
            this.tabPgSample,
            this.tabPgBaked});
            // 
            // tabPgBurden
            // 
            this.tabPgBurden.AutoScroll = true;
            this.tabPgBurden.Controls.Add(this.splitContainerControl3);
            this.tabPgBurden.Controls.Add(this.panelControl4);
            this.tabPgBurden.Name = "tabPgBurden";
            this.tabPgBurden.Size = new System.Drawing.Size(920, 258);
            this.tabPgBurden.Text = "配料及开炉熔炼";
            this.tabPgBurden.Tooltip = "配料及开炉熔炼";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.grpBurdenInfo);
            this.splitContainerControl3.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.grpProductPara);
            this.splitContainerControl3.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(806, 258);
            this.splitContainerControl3.SplitterPosition = 395;
            this.splitContainerControl3.TabIndex = 7;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // grpBurdenInfo
            // 
            this.grpBurdenInfo.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grpBurdenInfo.AppearanceCaption.Options.UseFont = true;
            this.grpBurdenInfo.Controls.Add(this.grdBurdenInfo);
            this.grpBurdenInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBurdenInfo.Location = new System.Drawing.Point(5, 5);
            this.grpBurdenInfo.Name = "grpBurdenInfo";
            this.grpBurdenInfo.Size = new System.Drawing.Size(396, 248);
            this.grpBurdenInfo.TabIndex = 3;
            this.grpBurdenInfo.Text = "配料信息";
            // 
            // grdBurdenInfo
            // 
            this.grdBurdenInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBurdenInfo.Location = new System.Drawing.Point(2, 27);
            this.grdBurdenInfo.MainView = this.grdBurdenInfoView;
            this.grdBurdenInfo.Name = "grdBurdenInfo";
            this.grdBurdenInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.grdBurdenInfo.Size = new System.Drawing.Size(392, 219);
            this.grdBurdenInfo.TabIndex = 0;
            this.grdBurdenInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdBurdenInfoView});
            // 
            // grdBurdenInfoView
            // 
            this.grdBurdenInfoView.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdBurdenInfoView.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdBurdenInfoView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdBurdenInfoView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdBurdenInfoView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdBurdenInfoView.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdBurdenInfoView.Appearance.Row.Options.UseFont = true;
            this.grdBurdenInfoView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColT101Code,
            this.ColT101Name,
            this.ColBatchLot,
            this.ColQty});
            this.grdBurdenInfoView.GridControl = this.grdBurdenInfo;
            this.grdBurdenInfoView.Name = "grdBurdenInfoView";
            this.grdBurdenInfoView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grdBurdenInfoView.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.grdBurdenInfoView.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grdBurdenInfoView.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grdBurdenInfoView.OptionsCustomization.AllowColumnMoving = false;
            this.grdBurdenInfoView.OptionsCustomization.AllowGroup = false;
            this.grdBurdenInfoView.OptionsMenu.EnableColumnMenu = false;
            this.grdBurdenInfoView.OptionsMenu.EnableFooterMenu = false;
            this.grdBurdenInfoView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdBurdenInfoView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.grdBurdenInfoView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.grdBurdenInfoView.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.grdBurdenInfoView.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.grdBurdenInfoView.OptionsMenu.ShowSplitItem = false;
            this.grdBurdenInfoView.OptionsView.ShowGroupPanel = false;
            this.grdBurdenInfoView.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.grdBurdenInfoView_CustomRowCellEditForEditing);
            // 
            // ColT101Code
            // 
            this.ColT101Code.Caption = "原材料编号";
            this.ColT101Code.FieldName = "T101Code";
            this.ColT101Code.Name = "ColT101Code";
            this.ColT101Code.OptionsColumn.AllowEdit = false;
            this.ColT101Code.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColT101Code.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColT101Code.OptionsColumn.AllowMove = false;
            this.ColT101Code.OptionsColumn.ReadOnly = true;
            this.ColT101Code.Visible = true;
            this.ColT101Code.VisibleIndex = 0;
            // 
            // ColT101Name
            // 
            this.ColT101Name.Caption = "原材料名称";
            this.ColT101Name.FieldName = "T101Name";
            this.ColT101Name.Name = "ColT101Name";
            this.ColT101Name.OptionsColumn.AllowEdit = false;
            this.ColT101Name.OptionsColumn.AllowMove = false;
            this.ColT101Name.OptionsColumn.ReadOnly = true;
            this.ColT101Name.Visible = true;
            this.ColT101Name.VisibleIndex = 1;
            // 
            // ColBatchLot
            // 
            this.ColBatchLot.Caption = "批次号";
            this.ColBatchLot.ColumnEdit = this.repositoryItemComboBox1;
            this.ColBatchLot.FieldName = "LotNumber";
            this.ColBatchLot.Name = "ColBatchLot";
            this.ColBatchLot.OptionsColumn.AllowMove = false;
            this.ColBatchLot.Visible = true;
            this.ColBatchLot.VisibleIndex = 2;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.ReadOnly = true;
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // ColQty
            // 
            this.ColQty.Caption = "数量";
            this.ColQty.DisplayFormat.FormatString = "#,##0.00";
            this.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColQty.FieldName = "MaterialQuantity";
            this.ColQty.Name = "ColQty";
            this.ColQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColQty.OptionsColumn.AllowMove = false;
            this.ColQty.Visible = true;
            this.ColQty.VisibleIndex = 3;
            // 
            // grpProductPara
            // 
            this.grpProductPara.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grpProductPara.AppearanceCaption.Options.UseFont = true;
            this.grpProductPara.Controls.Add(this.grdProductPara);
            this.grpProductPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProductPara.Location = new System.Drawing.Point(5, 5);
            this.grpProductPara.Name = "grpProductPara";
            this.grpProductPara.Size = new System.Drawing.Size(385, 248);
            this.grpProductPara.TabIndex = 4;
            this.grpProductPara.Text = "生产开炉参数";
            // 
            // grdProductPara
            // 
            this.grdProductPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProductPara.Location = new System.Drawing.Point(2, 27);
            this.grdProductPara.MainView = this.grdProductParaView;
            this.grdProductPara.Name = "grdProductPara";
            this.grdProductPara.Size = new System.Drawing.Size(381, 219);
            this.grdProductPara.TabIndex = 0;
            this.grdProductPara.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdProductParaView});
            // 
            // grdProductParaView
            // 
            this.grdProductParaView.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdProductParaView.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdProductParaView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdProductParaView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdProductParaView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdProductParaView.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdProductParaView.Appearance.Row.Options.UseFont = true;
            this.grdProductParaView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColT20Name,
            this.ColValue});
            this.grdProductParaView.GridControl = this.grdProductPara;
            this.grdProductParaView.Name = "grdProductParaView";
            this.grdProductParaView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.grdProductParaView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grdProductParaView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grdProductParaView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.grdProductParaView.OptionsMenu.EnableColumnMenu = false;
            this.grdProductParaView.OptionsMenu.EnableFooterMenu = false;
            this.grdProductParaView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdProductParaView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.grdProductParaView.OptionsView.ShowGroupPanel = false;
            // 
            // ColT20Name
            // 
            this.ColT20Name.Caption = "参数名称";
            this.ColT20Name.FieldName = "T20Name";
            this.ColT20Name.Name = "ColT20Name";
            this.ColT20Name.OptionsColumn.AllowEdit = false;
            this.ColT20Name.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColT20Name.OptionsColumn.AllowMove = false;
            this.ColT20Name.OptionsColumn.ReadOnly = true;
            this.ColT20Name.Visible = true;
            this.ColT20Name.VisibleIndex = 0;
            // 
            // ColValue
            // 
            this.ColValue.Caption = "参数值";
            this.ColValue.FieldName = "Value";
            this.ColValue.Name = "ColValue";
            this.ColValue.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColValue.OptionsColumn.AllowMove = false;
            this.ColValue.Visible = true;
            this.ColValue.VisibleIndex = 1;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.btnStart);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl4.Location = new System.Drawing.Point(806, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl4.Size = new System.Drawing.Size(114, 258);
            this.panelControl4.TabIndex = 6;
            // 
            // btnStart
            // 
            this.btnStart.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnStart.Appearance.Options.UseFont = true;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStart.Location = new System.Drawing.Point(7, 219);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 32);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "生产开始";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabPgSpectrum
            // 
            this.tabPgSpectrum.AutoScroll = true;
            this.tabPgSpectrum.Controls.Add(this.ucGrdSpectrum);
            this.tabPgSpectrum.Name = "tabPgSpectrum";
            this.tabPgSpectrum.Size = new System.Drawing.Size(920, 258);
            this.tabPgSpectrum.Text = "炉前光谱";
            this.tabPgSpectrum.Tooltip = "炉前光谱";
            // 
            // ucGrdSpectrum
            // 
            this.ucGrdSpectrum.DataSource = null;
            this.ucGrdSpectrum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGrdSpectrum.Location = new System.Drawing.Point(0, 0);
            this.ucGrdSpectrum.Name = "ucGrdSpectrum";
            this.ucGrdSpectrum.ReadOnlyCount = 0;
            this.ucGrdSpectrum.SaveBtnText = "保存";
            this.ucGrdSpectrum.Size = new System.Drawing.Size(920, 258);
            this.ucGrdSpectrum.TabIndex = 0;
            this.ucGrdSpectrum.Title = "参数";
            // 
            // tabPgMatieralAjustment
            // 
            this.tabPgMatieralAjustment.Controls.Add(this.btnRowMaterialDelete);
            this.tabPgMatieralAjustment.Controls.Add(this.btnRowMaterialSave);
            this.tabPgMatieralAjustment.Controls.Add(this.grdRowMaterial);
            this.tabPgMatieralAjustment.Name = "tabPgMatieralAjustment";
            this.tabPgMatieralAjustment.Size = new System.Drawing.Size(920, 258);
            this.tabPgMatieralAjustment.Text = "原材料调整";
            this.tabPgMatieralAjustment.Tooltip = "原材料调整";
            // 
            // btnRowMaterialDelete
            // 
            this.btnRowMaterialDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRowMaterialDelete.Location = new System.Drawing.Point(843, 2);
            this.btnRowMaterialDelete.Name = "btnRowMaterialDelete";
            this.btnRowMaterialDelete.Size = new System.Drawing.Size(74, 33);
            this.btnRowMaterialDelete.TabIndex = 7;
            this.btnRowMaterialDelete.Text = "删除";
            this.btnRowMaterialDelete.Click += new System.EventHandler(this.btnRowMaterialDelete_Click);
            // 
            // btnRowMaterialSave
            // 
            this.btnRowMaterialSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRowMaterialSave.Location = new System.Drawing.Point(843, 222);
            this.btnRowMaterialSave.Name = "btnRowMaterialSave";
            this.btnRowMaterialSave.Size = new System.Drawing.Size(74, 33);
            this.btnRowMaterialSave.TabIndex = 6;
            this.btnRowMaterialSave.Text = "保存";
            this.btnRowMaterialSave.Click += new System.EventHandler(this.btnRowMaterialSave_Click);
            // 
            // grdRowMaterial
            // 
            this.grdRowMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRowMaterial.Location = new System.Drawing.Point(1, 2);
            this.grdRowMaterial.MainView = this.grdRowMaterialView;
            this.grdRowMaterial.Name = "grdRowMaterial";
            this.grdRowMaterial.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox2});
            this.grdRowMaterial.Size = new System.Drawing.Size(839, 253);
            this.grdRowMaterial.TabIndex = 1;
            this.grdRowMaterial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdRowMaterialView});
            // 
            // grdRowMaterialView
            // 
            this.grdRowMaterialView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.grdRowMaterialView.GridControl = this.grdRowMaterial;
            this.grdRowMaterialView.Name = "grdRowMaterialView";
            this.grdRowMaterialView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdRowMaterialView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grdRowMaterialView.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.grdRowMaterialView.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.grdRowMaterialView.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grdRowMaterialView.OptionsCustomization.AllowColumnMoving = false;
            this.grdRowMaterialView.OptionsCustomization.AllowGroup = false;
            this.grdRowMaterialView.OptionsMenu.EnableColumnMenu = false;
            this.grdRowMaterialView.OptionsMenu.EnableFooterMenu = false;
            this.grdRowMaterialView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdRowMaterialView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.grdRowMaterialView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.grdRowMaterialView.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.grdRowMaterialView.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.grdRowMaterialView.OptionsMenu.ShowSplitItem = false;
            this.grdRowMaterialView.OptionsNavigation.AutoFocusNewRow = true;
            this.grdRowMaterialView.OptionsNavigation.EnterMoveNextColumn = true;
            this.grdRowMaterialView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdRowMaterialView.OptionsView.ShowGroupPanel = false;
            this.grdRowMaterialView.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.grdRowMaterialView_CustomRowCellEditForEditing);
            this.grdRowMaterialView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grdRowMaterialView_ShowingEditor);
            this.grdRowMaterialView.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.grdRowMaterialView_RowDeleting);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "原材料编号";
            this.gridColumn1.FieldName = "T101Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "原材料名称";
            this.gridColumn2.FieldName = "T101Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "批次号";
            this.gridColumn3.ColumnEdit = this.repositoryItemComboBox2;
            this.gridColumn3.FieldName = "LotNumber";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox2.ReadOnly = true;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "数量";
            this.gridColumn4.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "MaterialQuantity";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // tabPgSample
            // 
            this.tabPgSample.Controls.Add(this.ucGrdSample);
            this.tabPgSample.Name = "tabPgSample";
            this.tabPgSample.Size = new System.Drawing.Size(920, 258);
            this.tabPgSample.Text = "浇三角试样";
            this.tabPgSample.Tooltip = "浇三角试样";
            // 
            // ucGrdSample
            // 
            this.ucGrdSample.DataSource = null;
            this.ucGrdSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGrdSample.Location = new System.Drawing.Point(0, 0);
            this.ucGrdSample.Name = "ucGrdSample";
            this.ucGrdSample.ReadOnlyCount = 0;
            this.ucGrdSample.SaveBtnText = "保存";
            this.ucGrdSample.Size = new System.Drawing.Size(920, 258);
            this.ucGrdSample.TabIndex = 0;
            this.ucGrdSample.Title = "参数";
            // 
            // tabPgBaked
            // 
            this.tabPgBaked.Controls.Add(this.ucGrdBaked);
            this.tabPgBaked.Name = "tabPgBaked";
            this.tabPgBaked.Size = new System.Drawing.Size(920, 258);
            this.tabPgBaked.Text = "炉水出炉";
            this.tabPgBaked.Tooltip = "炉水出炉";
            // 
            // ucGrdBaked
            // 
            this.ucGrdBaked.DataSource = null;
            this.ucGrdBaked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGrdBaked.Location = new System.Drawing.Point(0, 0);
            this.ucGrdBaked.Name = "ucGrdBaked";
            this.ucGrdBaked.ReadOnlyCount = 0;
            this.ucGrdBaked.SaveBtnText = "生产结束";
            this.ucGrdBaked.Size = new System.Drawing.Size(920, 258);
            this.ucGrdBaked.TabIndex = 0;
            this.ucGrdBaked.Title = "参数";
            // 
            // dtProductDate
            // 
            this.dtProductDate.EditValue = new System.DateTime(2018, 1, 25, 10, 41, 25, 67);
            this.dtProductDate.Location = new System.Drawing.Point(336, 0);
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
            // lblFurnaceTime
            // 
            this.lblFurnaceTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFurnaceTime.AutoEllipsis = true;
            this.lblFurnaceTime.Location = new System.Drawing.Point(539, 3);
            this.lblFurnaceTime.Name = "lblFurnaceTime";
            this.lblFurnaceTime.Size = new System.Drawing.Size(10, 20);
            this.lblFurnaceTime.TabIndex = 12;
            this.lblFurnaceTime.Text = "A";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 34);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tabCtrlDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(926, 448);
            this.splitContainerControl1.SplitterPosition = 150;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.splitContainerControl2.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel1.Controls.Add(this.panelControl2);
            this.splitContainerControl2.Panel1.Controls.Add(this.panelControl3);
            this.splitContainerControl2.Panel1.ShowCaption = true;
            this.splitContainerControl2.Panel1.Text = "生产信息";
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel2.Controls.Add(this.lblProductionTimeResult);
            this.splitContainerControl2.Panel2.Controls.Add(this.labCurrentFurnace);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblProductionTime);
            this.splitContainerControl2.Panel2.Controls.Add(this.labCtrlStartTime);
            this.splitContainerControl2.Panel2.Controls.Add(this.labProductStartTimeResult);
            this.splitContainerControl2.Panel2.Controls.Add(this.labCurrentFurnaceResult);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            this.splitContainerControl2.Panel2.Text = "当前熔炼信息";
            this.splitContainerControl2.Size = new System.Drawing.Size(926, 150);
            this.splitContainerControl2.SplitterPosition = 313;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.grdCtrProductionInfo);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl2.Size = new System.Drawing.Size(504, 121);
            this.panelControl2.TabIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.btnPrint);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(504, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl3.Size = new System.Drawing.Size(100, 121);
            this.panelControl3.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelController);
            this.panelControl1.Controls.Add(this.txtOperator);
            this.panelControl1.Controls.Add(this.lblFurnaceTime);
            this.panelControl1.Controls.Add(this.labelProductionDate);
            this.panelControl1.Controls.Add(this.dtProductDate);
            this.panelControl1.Controls.Add(this.labelFurnaceTime);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(5, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(926, 29);
            this.panelControl1.TabIndex = 0;
            // 
            // ucFurnace
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucFurnace";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(936, 487);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlDetail)).EndInit();
            this.tabCtrlDetail.ResumeLayout(false);
            this.tabPgBurden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpBurdenInfo)).EndInit();
            this.grpBurdenInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBurdenInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBurdenInfoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpProductPara)).EndInit();
            this.grpProductPara.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProductPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductParaView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.tabPgSpectrum.ResumeLayout(false);
            this.tabPgMatieralAjustment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRowMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRowMaterialView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.tabPgSample.ResumeLayout(false);
            this.tabPgBaked.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelController;
        private DevExpress.XtraEditors.TextEdit txtOperator;
        private DevExpress.XtraEditors.LabelControl labelProductionDate;
        private DevExpress.XtraEditors.LabelControl labelFurnaceTime;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl grdCtrProductionInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdCtrProductionInfoView;
        private DevExpress.XtraTab.XtraTabControl tabCtrlDetail;
        private DevExpress.XtraEditors.LabelControl labProductStartTimeResult;
        private DevExpress.XtraEditors.LabelControl labCurrentFurnaceResult;
        private DevExpress.XtraEditors.LabelControl labCurrentFurnace;
        private DevExpress.XtraEditors.LabelControl labCtrlStartTime;
        private DevExpress.XtraTab.XtraTabPage tabPgBurden;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.GroupControl grpProductPara;
        private DevExpress.XtraEditors.GroupControl grpBurdenInfo;
        private DevExpress.XtraGrid.GridControl grdBurdenInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdBurdenInfoView;
        private DevExpress.XtraTab.XtraTabPage tabPgSpectrum;
        private DevExpress.XtraTab.XtraTabPage tabPgMatieralAjustment;
        private DevExpress.XtraTab.XtraTabPage tabPgSample;
        private DevExpress.XtraTab.XtraTabPage tabPgBaked;
        private ucDetailGrid ucGrdSample;
        private ucDetailGrid ucGrdBaked;
        private DevExpress.XtraEditors.DateEdit dtProductDate;
        private DevExpress.XtraEditors.LabelControl lblFurnaceTime;
        private DevExpress.XtraGrid.Columns.GridColumn ColT101Code;
        private DevExpress.XtraGrid.Columns.GridColumn ColT101Name;
        private DevExpress.XtraGrid.Columns.GridColumn ColBatchLot;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn ColQty;
        private DevExpress.XtraGrid.GridControl grdProductPara;
        private DevExpress.XtraGrid.Views.Grid.GridView grdProductParaView;
        private DevExpress.XtraGrid.Columns.GridColumn ColT20Name;
        private DevExpress.XtraGrid.Columns.GridColumn ColValue;
        private DevExpress.XtraEditors.LabelControl lblProductionTimeResult;
        private DevExpress.XtraEditors.LabelControl lblProductionTime;
        private System.Windows.Forms.Timer timer1;
        private ucDetailGrid ucGrdSpectrum;
        private DevExpress.XtraGrid.GridControl grdRowMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView grdRowMaterialView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnRowMaterialSave;
        private DevExpress.XtraGrid.Columns.GridColumn colPrint;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn ColMONumber;
        private DevExpress.XtraGrid.Columns.GridColumn ColMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColT131Name;
        private DevExpress.XtraGrid.Columns.GridColumn ColT102Code;
        private DevExpress.XtraGrid.Columns.GridColumn ColPlateNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColLotNumber;
        private DevExpress.XtraGrid.Columns.GridColumn ColMachineModelling;
        private DevExpress.XtraGrid.Columns.GridColumn ColFoldNumber;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnRowMaterialDelete;
    }
}
