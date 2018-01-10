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
            this.components = new System.ComponentModel.Container();
            this.grpCtrProductionInfo = new DevExpress.XtraEditors.GroupControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.grdCtrProductionInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelController = new DevExpress.XtraEditors.LabelControl();
            this.txtOperator = new DevExpress.XtraEditors.TextEdit();
            this.labelProductionDate = new DevExpress.XtraEditors.LabelControl();
            this.labelFurnaceTime = new DevExpress.XtraEditors.LabelControl();
            this.grpCtrlCurrentInfo = new DevExpress.XtraEditors.GroupControl();
            this.lblProductionTimeResult = new DevExpress.XtraEditors.LabelControl();
            this.lblProductionTime = new DevExpress.XtraEditors.LabelControl();
            this.labProductStartTimeResult = new DevExpress.XtraEditors.LabelControl();
            this.labCurrentFurnaceResult = new DevExpress.XtraEditors.LabelControl();
            this.labCurrentFurnace = new DevExpress.XtraEditors.LabelControl();
            this.labCtrlStartTime = new DevExpress.XtraEditors.LabelControl();
            this.tabCtrlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tabPgBurden = new DevExpress.XtraTab.XtraTabPage();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.grpProductPara = new DevExpress.XtraEditors.GroupControl();
            this.grdProductPara = new DevExpress.XtraGrid.GridControl();
            this.grdProductParaView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColT20Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpBurdenInfo = new DevExpress.XtraEditors.GroupControl();
            this.grdBurdenInfo = new DevExpress.XtraGrid.GridControl();
            this.grdBurdenInfoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColT101Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColT101Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColBatchLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ColQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPgSpectrum = new DevExpress.XtraTab.XtraTabPage();
            this.ucDetailGrid2 = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            this.tabPgMatieralAjustment = new DevExpress.XtraTab.XtraTabPage();
            this.ucDetailGrid3 = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            this.tabPgSample = new DevExpress.XtraTab.XtraTabPage();
            this.ucDetailGrid4 = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            this.tabPgBaked = new DevExpress.XtraTab.XtraTabPage();
            this.ucDetailGrid1 = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            this.dtProductDate = new DevExpress.XtraEditors.DateEdit();
            this.lblFurnaceTime = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrProductionInfo)).BeginInit();
            this.grpCtrProductionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlCurrentInfo)).BeginInit();
            this.grpCtrlCurrentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlDetail)).BeginInit();
            this.tabCtrlDetail.SuspendLayout();
            this.tabPgBurden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpProductPara)).BeginInit();
            this.grpProductPara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductParaView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBurdenInfo)).BeginInit();
            this.grpBurdenInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBurdenInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBurdenInfoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.tabPgSpectrum.SuspendLayout();
            this.tabPgMatieralAjustment.SuspendLayout();
            this.tabPgSample.SuspendLayout();
            this.tabPgBaked.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCtrProductionInfo
            // 
            this.grpCtrProductionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCtrProductionInfo.Controls.Add(this.btnPrint);
            this.grpCtrProductionInfo.Controls.Add(this.grdCtrProductionInfo);
            this.grpCtrProductionInfo.Location = new System.Drawing.Point(3, 38);
            this.grpCtrProductionInfo.Name = "grpCtrProductionInfo";
            this.grpCtrProductionInfo.Size = new System.Drawing.Size(517, 167);
            this.grpCtrProductionInfo.TabIndex = 0;
            this.grpCtrProductionInfo.Text = "生产信息";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(438, 141);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打印";
            // 
            // grdCtrProductionInfo
            // 
            this.grdCtrProductionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCtrProductionInfo.Location = new System.Drawing.Point(5, 24);
            this.grdCtrProductionInfo.MainView = this.gridView1;
            this.grdCtrProductionInfo.Name = "grdCtrProductionInfo";
            this.grdCtrProductionInfo.Size = new System.Drawing.Size(507, 112);
            this.grdCtrProductionInfo.TabIndex = 0;
            this.grdCtrProductionInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdCtrProductionInfo;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowPartialGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowPartialRedrawOnScrolling = false;
            this.gridView1.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView1.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowRowSizing = true;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelController
            // 
            this.labelController.Location = new System.Drawing.Point(9, 15);
            this.labelController.Name = "labelController";
            this.labelController.Size = new System.Drawing.Size(40, 14);
            this.labelController.TabIndex = 1;
            this.labelController.Text = "操作工:";
            // 
            // txtOperator
            // 
            this.txtOperator.Location = new System.Drawing.Point(55, 12);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Size = new System.Drawing.Size(127, 20);
            this.txtOperator.TabIndex = 2;
            // 
            // labelProductionDate
            // 
            this.labelProductionDate.Location = new System.Drawing.Point(204, 15);
            this.labelProductionDate.Name = "labelProductionDate";
            this.labelProductionDate.Size = new System.Drawing.Size(52, 14);
            this.labelProductionDate.TabIndex = 3;
            this.labelProductionDate.Text = "生产日期:";
            // 
            // labelFurnaceTime
            // 
            this.labelFurnaceTime.Location = new System.Drawing.Point(424, 15);
            this.labelFurnaceTime.Name = "labelFurnaceTime";
            this.labelFurnaceTime.Size = new System.Drawing.Size(28, 14);
            this.labelFurnaceTime.TabIndex = 5;
            this.labelFurnaceTime.Text = "炉次:";
            // 
            // grpCtrlCurrentInfo
            // 
            this.grpCtrlCurrentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCtrlCurrentInfo.Controls.Add(this.lblProductionTimeResult);
            this.grpCtrlCurrentInfo.Controls.Add(this.lblProductionTime);
            this.grpCtrlCurrentInfo.Controls.Add(this.labProductStartTimeResult);
            this.grpCtrlCurrentInfo.Controls.Add(this.labCurrentFurnaceResult);
            this.grpCtrlCurrentInfo.Controls.Add(this.labCurrentFurnace);
            this.grpCtrlCurrentInfo.Controls.Add(this.labCtrlStartTime);
            this.grpCtrlCurrentInfo.Location = new System.Drawing.Point(521, 38);
            this.grpCtrlCurrentInfo.Name = "grpCtrlCurrentInfo";
            this.grpCtrlCurrentInfo.Size = new System.Drawing.Size(254, 136);
            this.grpCtrlCurrentInfo.TabIndex = 8;
            this.grpCtrlCurrentInfo.Text = "当前熔炼信息";
            // 
            // lblProductionTimeResult
            // 
            this.lblProductionTimeResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductionTimeResult.AutoEllipsis = true;
            this.lblProductionTimeResult.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProductionTimeResult.Location = new System.Drawing.Point(100, 92);
            this.lblProductionTimeResult.Name = "lblProductionTimeResult";
            this.lblProductionTimeResult.Size = new System.Drawing.Size(146, 14);
            this.lblProductionTimeResult.TabIndex = 15;
            // 
            // lblProductionTime
            // 
            this.lblProductionTime.Location = new System.Drawing.Point(41, 92);
            this.lblProductionTime.Name = "lblProductionTime";
            this.lblProductionTime.Size = new System.Drawing.Size(52, 14);
            this.lblProductionTime.TabIndex = 14;
            this.lblProductionTime.Text = "生产时长:";
            // 
            // labProductStartTimeResult
            // 
            this.labProductStartTimeResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labProductStartTimeResult.AutoEllipsis = true;
            this.labProductStartTimeResult.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labProductStartTimeResult.Location = new System.Drawing.Point(100, 68);
            this.labProductStartTimeResult.Name = "labProductStartTimeResult";
            this.labProductStartTimeResult.Size = new System.Drawing.Size(146, 14);
            this.labProductStartTimeResult.TabIndex = 13;
            // 
            // labCurrentFurnaceResult
            // 
            this.labCurrentFurnaceResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labCurrentFurnaceResult.AutoEllipsis = true;
            this.labCurrentFurnaceResult.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labCurrentFurnaceResult.Location = new System.Drawing.Point(100, 44);
            this.labCurrentFurnaceResult.Name = "labCurrentFurnaceResult";
            this.labCurrentFurnaceResult.Size = new System.Drawing.Size(146, 14);
            this.labCurrentFurnaceResult.TabIndex = 12;
            // 
            // labCurrentFurnace
            // 
            this.labCurrentFurnace.Location = new System.Drawing.Point(30, 44);
            this.labCurrentFurnace.Name = "labCurrentFurnace";
            this.labCurrentFurnace.Size = new System.Drawing.Size(64, 14);
            this.labCurrentFurnace.TabIndex = 10;
            this.labCurrentFurnace.Text = "当前炉次号:";
            // 
            // labCtrlStartTime
            // 
            this.labCtrlStartTime.Location = new System.Drawing.Point(18, 68);
            this.labCtrlStartTime.Name = "labCtrlStartTime";
            this.labCtrlStartTime.Size = new System.Drawing.Size(76, 14);
            this.labCtrlStartTime.TabIndex = 8;
            this.labCtrlStartTime.Text = "生产开始时间:";
            // 
            // tabCtrlDetail
            // 
            this.tabCtrlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrlDetail.Location = new System.Drawing.Point(3, 211);
            this.tabCtrlDetail.MinimumSize = new System.Drawing.Size(0, 321);
            this.tabCtrlDetail.Name = "tabCtrlDetail";
            this.tabCtrlDetail.SelectedTabPage = this.tabPgBurden;
            this.tabCtrlDetail.Size = new System.Drawing.Size(772, 321);
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
            this.tabPgBurden.Controls.Add(this.btnStart);
            this.tabPgBurden.Controls.Add(this.grpProductPara);
            this.tabPgBurden.Controls.Add(this.grpBurdenInfo);
            this.tabPgBurden.Name = "tabPgBurden";
            this.tabPgBurden.Size = new System.Drawing.Size(766, 292);
            this.tabPgBurden.Text = "配料及开炉熔炼";
            this.tabPgBurden.Tooltip = "配料及开炉熔炼";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(685, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 45);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "生产开始";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // grpProductPara
            // 
            this.grpProductPara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProductPara.Controls.Add(this.grdProductPara);
            this.grpProductPara.Location = new System.Drawing.Point(381, 3);
            this.grpProductPara.Name = "grpProductPara";
            this.grpProductPara.Size = new System.Drawing.Size(302, 286);
            this.grpProductPara.TabIndex = 4;
            this.grpProductPara.Text = "生产开炉参数";
            // 
            // grdProductPara
            // 
            this.grdProductPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProductPara.Location = new System.Drawing.Point(2, 21);
            this.grdProductPara.MainView = this.grdProductParaView;
            this.grdProductPara.Name = "grdProductPara";
            this.grdProductPara.Size = new System.Drawing.Size(298, 263);
            this.grdProductPara.TabIndex = 0;
            this.grdProductPara.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdProductParaView});
            // 
            // grdProductParaView
            // 
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
            // grpBurdenInfo
            // 
            this.grpBurdenInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBurdenInfo.Controls.Add(this.grdBurdenInfo);
            this.grpBurdenInfo.Location = new System.Drawing.Point(3, 3);
            this.grpBurdenInfo.Name = "grpBurdenInfo";
            this.grpBurdenInfo.Size = new System.Drawing.Size(376, 286);
            this.grpBurdenInfo.TabIndex = 3;
            this.grpBurdenInfo.Text = "配料信息";
            // 
            // grdBurdenInfo
            // 
            this.grdBurdenInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBurdenInfo.Location = new System.Drawing.Point(2, 21);
            this.grdBurdenInfo.MainView = this.grdBurdenInfoView;
            this.grdBurdenInfo.Name = "grdBurdenInfo";
            this.grdBurdenInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.grdBurdenInfo.Size = new System.Drawing.Size(372, 263);
            this.grdBurdenInfo.TabIndex = 0;
            this.grdBurdenInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdBurdenInfoView});
            // 
            // grdBurdenInfoView
            // 
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
            // 
            // ColQty
            // 
            this.ColQty.Caption = "数量";
            this.ColQty.FieldName = "Qty";
            this.ColQty.Name = "ColQty";
            this.ColQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.ColQty.OptionsColumn.AllowMove = false;
            this.ColQty.Visible = true;
            this.ColQty.VisibleIndex = 3;
            // 
            // tabPgSpectrum
            // 
            this.tabPgSpectrum.AutoScroll = true;
            this.tabPgSpectrum.Controls.Add(this.ucDetailGrid2);
            this.tabPgSpectrum.Name = "tabPgSpectrum";
            this.tabPgSpectrum.Size = new System.Drawing.Size(766, 292);
            this.tabPgSpectrum.Text = "炉前光谱";
            this.tabPgSpectrum.Tooltip = "炉前光谱";
            // 
            // ucDetailGrid2
            // 
            this.ucDetailGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDetailGrid2.Location = new System.Drawing.Point(0, 0);
            this.ucDetailGrid2.Name = "ucDetailGrid2";
            this.ucDetailGrid2.Size = new System.Drawing.Size(766, 292);
            this.ucDetailGrid2.TabIndex = 0;
            // 
            // tabPgMatieralAjustment
            // 
            this.tabPgMatieralAjustment.Controls.Add(this.ucDetailGrid3);
            this.tabPgMatieralAjustment.Name = "tabPgMatieralAjustment";
            this.tabPgMatieralAjustment.Size = new System.Drawing.Size(766, 292);
            this.tabPgMatieralAjustment.Text = "原材料调整";
            this.tabPgMatieralAjustment.Tooltip = "原材料调整";
            // 
            // ucDetailGrid3
            // 
            this.ucDetailGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDetailGrid3.Location = new System.Drawing.Point(0, 0);
            this.ucDetailGrid3.Name = "ucDetailGrid3";
            this.ucDetailGrid3.Size = new System.Drawing.Size(766, 292);
            this.ucDetailGrid3.TabIndex = 0;
            // 
            // tabPgSample
            // 
            this.tabPgSample.Controls.Add(this.ucDetailGrid4);
            this.tabPgSample.Name = "tabPgSample";
            this.tabPgSample.Size = new System.Drawing.Size(766, 292);
            this.tabPgSample.Text = "浇三角试样";
            this.tabPgSample.Tooltip = "浇三角试样";
            // 
            // ucDetailGrid4
            // 
            this.ucDetailGrid4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDetailGrid4.Location = new System.Drawing.Point(0, 0);
            this.ucDetailGrid4.Name = "ucDetailGrid4";
            this.ucDetailGrid4.Size = new System.Drawing.Size(766, 292);
            this.ucDetailGrid4.TabIndex = 0;
            // 
            // tabPgBaked
            // 
            this.tabPgBaked.Controls.Add(this.ucDetailGrid1);
            this.tabPgBaked.Name = "tabPgBaked";
            this.tabPgBaked.Size = new System.Drawing.Size(766, 292);
            this.tabPgBaked.Text = "炉水出炉";
            this.tabPgBaked.Tooltip = "炉水出炉";
            // 
            // ucDetailGrid1
            // 
            this.ucDetailGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDetailGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucDetailGrid1.Name = "ucDetailGrid1";
            this.ucDetailGrid1.Size = new System.Drawing.Size(766, 292);
            this.ucDetailGrid1.TabIndex = 0;
            // 
            // dtProductDate
            // 
            this.dtProductDate.EditValue = new System.DateTime(2018, 1, 3, 14, 10, 9, 0);
            this.dtProductDate.Location = new System.Drawing.Point(263, 12);
            this.dtProductDate.Name = "dtProductDate";
            this.dtProductDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtProductDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.dtProductDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtProductDate.Properties.MinValue = new System.DateTime(2018, 1, 2, 14, 23, 17, 448);
            this.dtProductDate.Properties.NullDateCalendarValue = new System.DateTime(2018, 1, 3, 14, 12, 53, 0);
            this.dtProductDate.Size = new System.Drawing.Size(132, 20);
            this.dtProductDate.TabIndex = 10;
            // 
            // lblFurnaceTime
            // 
            this.lblFurnaceTime.AutoEllipsis = true;
            this.lblFurnaceTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFurnaceTime.Location = new System.Drawing.Point(458, 15);
            this.lblFurnaceTime.Name = "lblFurnaceTime";
            this.lblFurnaceTime.Size = new System.Drawing.Size(107, 14);
            this.lblFurnaceTime.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucFurnace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lblFurnaceTime);
            this.Controls.Add(this.dtProductDate);
            this.Controls.Add(this.tabCtrlDetail);
            this.Controls.Add(this.grpCtrlCurrentInfo);
            this.Controls.Add(this.labelFurnaceTime);
            this.Controls.Add(this.labelProductionDate);
            this.Controls.Add(this.txtOperator);
            this.Controls.Add(this.labelController);
            this.Controls.Add(this.grpCtrProductionInfo);
            this.Name = "ucFurnace";
            this.Size = new System.Drawing.Size(778, 535);
            this.Load += new System.EventHandler(this.ucFurnace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrProductionInfo)).EndInit();
            this.grpCtrProductionInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlCurrentInfo)).EndInit();
            this.grpCtrlCurrentInfo.ResumeLayout(false);
            this.grpCtrlCurrentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlDetail)).EndInit();
            this.tabCtrlDetail.ResumeLayout(false);
            this.tabPgBurden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpProductPara)).EndInit();
            this.grpProductPara.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProductPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductParaView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBurdenInfo)).EndInit();
            this.grpBurdenInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBurdenInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBurdenInfoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.tabPgSpectrum.ResumeLayout(false);
            this.tabPgMatieralAjustment.ResumeLayout(false);
            this.tabPgSample.ResumeLayout(false);
            this.tabPgBaked.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpCtrProductionInfo;
        private DevExpress.XtraEditors.LabelControl labelController;
        private DevExpress.XtraEditors.TextEdit txtOperator;
        private DevExpress.XtraEditors.LabelControl labelProductionDate;
        private DevExpress.XtraEditors.LabelControl labelFurnaceTime;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl grdCtrProductionInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl grpCtrlCurrentInfo;
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
        private ucDetailGrid ucDetailGrid2;
        private ucDetailGrid ucDetailGrid3;
        private ucDetailGrid ucDetailGrid4;
        private ucDetailGrid ucDetailGrid1;
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
    }
}
