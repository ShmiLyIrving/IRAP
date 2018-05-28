namespace BatchSystemMNGNT_Asimco
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.grdclmnErrCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSysParams = new DevExpress.XtraBars.BarButtonItem();
            this.sbMessage = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdLogs = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRetry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.grdvLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSKUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLogID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnExCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnTimeWritten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnItemNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnBinFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnBinTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnOrderLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLinkedLogID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRetry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdExChangeXML = new DevExpress.XtraGrid.GridControl();
            this.grdvExChangeXML = new DevExpress.XtraGrid.Views.Card.CardView();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdMaterialStore = new DevExpress.XtraGrid.GridControl();
            this.grdvMaterialStore = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtErrText = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClearCondition = new DevExpress.XtraEditors.SimpleButton();
            this.chkWaitForRetry = new DevExpress.XtraEditors.CheckEdit();
            this.edtMOLineNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.edtMONo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.edtRecvBatchNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.edtItemNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnGetLogs = new DevExpress.XtraEditors.SimpleButton();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::BatchSystemMNGNT_Asimco.frmWaitting), true, true);
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpWebServiceLogs = new DevExpress.XtraTab.XtraTabPage();
            this.tpUnclosedDelivery = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExChangeXML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvExChangeXML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterialStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMaterialStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErrText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkWaitForRetry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMOLineNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMONo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRecvBatchNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtItemNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpWebServiceLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdclmnErrCode
            // 
            this.grdclmnErrCode.Caption = "ErrCode";
            this.grdclmnErrCode.FieldName = "ErrCode";
            this.grdclmnErrCode.Name = "grdclmnErrCode";
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiSysParams,
            this.sbMessage});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1158, 156);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbiSysParams
            // 
            this.bbiSysParams.Caption = "系统参数(&S)";
            this.bbiSysParams.Id = 1;
            this.bbiSysParams.LargeGlyph = global::BatchSystemMNGNT_Asimco.Properties.Resources.系统参数;
            this.bbiSysParams.Name = "bbiSysParams";
            this.bbiSysParams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSysParams_ItemClick);
            // 
            // sbMessage
            // 
            this.sbMessage.Id = 1;
            this.sbMessage.Name = "sbMessage";
            this.sbMessage.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage1.Appearance.Options.UseFont = true;
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "系统功能";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSysParams);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.sbMessage);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 837);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1158, 21);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 46);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdLogs);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1146, 628);
            this.splitContainerControl1.SplitterPosition = 390;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grdLogs
            // 
            this.grdLogs.ContextMenuStrip = this.contextMenuStrip;
            this.grdLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogs.Location = new System.Drawing.Point(5, 5);
            this.grdLogs.MainView = this.grdvLogs;
            this.grdLogs.MenuManager = this.ribbon;
            this.grdLogs.Name = "grdLogs";
            this.grdLogs.Size = new System.Drawing.Size(734, 618);
            this.grdLogs.TabIndex = 1;
            this.grdLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvLogs});
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSelectAll,
            this.tsmiUnselectAll,
            this.toolStripMenuItem2,
            this.tsmiRetry,
            this.toolStripMenuItem1,
            this.tsmiDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(137, 104);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // tsmiSelectAll
            // 
            this.tsmiSelectAll.Name = "tsmiSelectAll";
            this.tsmiSelectAll.Size = new System.Drawing.Size(136, 22);
            this.tsmiSelectAll.Text = "选择全部";
            this.tsmiSelectAll.Click += new System.EventHandler(this.tsmiSelectAll_Click);
            // 
            // tsmiUnselectAll
            // 
            this.tsmiUnselectAll.Name = "tsmiUnselectAll";
            this.tsmiUnselectAll.Size = new System.Drawing.Size(136, 22);
            this.tsmiUnselectAll.Text = "全部不选择";
            this.tsmiUnselectAll.Click += new System.EventHandler(this.tsmiUnselectAll_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 6);
            this.toolStripMenuItem2.Visible = false;
            // 
            // tsmiRetry
            // 
            this.tsmiRetry.Name = "tsmiRetry";
            this.tsmiRetry.Size = new System.Drawing.Size(136, 22);
            this.tsmiRetry.Text = "重试";
            this.tsmiRetry.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(136, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // grdvLogs
            // 
            this.grdvLogs.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdvLogs.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdvLogs.Appearance.GroupPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvLogs.Appearance.GroupPanel.Options.UseFont = true;
            this.grdvLogs.Appearance.GroupRow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvLogs.Appearance.GroupRow.Options.UseFont = true;
            this.grdvLogs.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvLogs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvLogs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvLogs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvLogs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvLogs.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvLogs.Appearance.Row.ForeColor = System.Drawing.Color.Red;
            this.grdvLogs.Appearance.Row.Options.UseFont = true;
            this.grdvLogs.Appearance.Row.Options.UseForeColor = true;
            this.grdvLogs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnChoice,
            this.grdclmnSKUID,
            this.grdclmnLogID,
            this.grdclmnExCode,
            this.grdclmnTimeWritten,
            this.grdclmnItemNumber,
            this.grdclmnLotNumber,
            this.grdclmnBinFrom,
            this.grdclmnBinTo,
            this.grdclmnQuantity,
            this.grdclmnOrderNo,
            this.grdclmnOrderLineNo,
            this.grdclmnLinkedLogID,
            this.grdclmnRetry,
            this.grdclmnErrCode});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.grdclmnErrCode;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Green;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.NavajoWhite;
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "[ErrCode] <> 0 And [Retried] = 0";
            gridFormatRule2.Rule = formatConditionRuleExpression1;
            this.grdvLogs.FormatRules.Add(gridFormatRule1);
            this.grdvLogs.FormatRules.Add(gridFormatRule2);
            this.grdvLogs.GridControl = this.grdLogs;
            this.grdvLogs.GroupCount = 1;
            this.grdvLogs.Name = "grdvLogs";
            this.grdvLogs.OptionsDetail.EnableMasterViewMode = false;
            this.grdvLogs.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvLogs.OptionsView.EnableAppearanceOddRow = true;
            this.grdvLogs.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.grdclmnSKUID, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grdvLogs.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdvLogs_FocusedRowChanged);
            this.grdvLogs.DoubleClick += new System.EventHandler(this.grdvLogs_DoubleClick);
            // 
            // grdclmnChoice
            // 
            this.grdclmnChoice.Caption = "选择";
            this.grdclmnChoice.FieldName = "Checked";
            this.grdclmnChoice.Name = "grdclmnChoice";
            this.grdclmnChoice.Visible = true;
            this.grdclmnChoice.VisibleIndex = 0;
            // 
            // grdclmnSKUID
            // 
            this.grdclmnSKUID.Caption = "SKUID";
            this.grdclmnSKUID.FieldName = "SKUID";
            this.grdclmnSKUID.Name = "grdclmnSKUID";
            this.grdclmnSKUID.OptionsColumn.AllowEdit = false;
            this.grdclmnSKUID.Visible = true;
            this.grdclmnSKUID.VisibleIndex = 0;
            // 
            // grdclmnLogID
            // 
            this.grdclmnLogID.Caption = "LogID";
            this.grdclmnLogID.FieldName = "LogID";
            this.grdclmnLogID.Name = "grdclmnLogID";
            this.grdclmnLogID.OptionsColumn.AllowEdit = false;
            this.grdclmnLogID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnLogID.OptionsColumn.AllowMove = false;
            this.grdclmnLogID.Visible = true;
            this.grdclmnLogID.VisibleIndex = 1;
            // 
            // grdclmnExCode
            // 
            this.grdclmnExCode.Caption = "ExCode";
            this.grdclmnExCode.FieldName = "ExCode";
            this.grdclmnExCode.Name = "grdclmnExCode";
            this.grdclmnExCode.OptionsColumn.AllowEdit = false;
            this.grdclmnExCode.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnExCode.OptionsColumn.AllowMove = false;
            this.grdclmnExCode.Visible = true;
            this.grdclmnExCode.VisibleIndex = 2;
            // 
            // grdclmnTimeWritten
            // 
            this.grdclmnTimeWritten.Caption = "TimeWritten";
            this.grdclmnTimeWritten.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.grdclmnTimeWritten.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnTimeWritten.FieldName = "TimeWritten";
            this.grdclmnTimeWritten.Name = "grdclmnTimeWritten";
            this.grdclmnTimeWritten.OptionsColumn.AllowEdit = false;
            this.grdclmnTimeWritten.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnTimeWritten.OptionsColumn.AllowMove = false;
            this.grdclmnTimeWritten.Visible = true;
            this.grdclmnTimeWritten.VisibleIndex = 3;
            // 
            // grdclmnItemNumber
            // 
            this.grdclmnItemNumber.Caption = "ItemNumber";
            this.grdclmnItemNumber.FieldName = "ItemNumber";
            this.grdclmnItemNumber.Name = "grdclmnItemNumber";
            this.grdclmnItemNumber.OptionsColumn.AllowEdit = false;
            this.grdclmnItemNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnItemNumber.OptionsColumn.AllowMove = false;
            this.grdclmnItemNumber.Visible = true;
            this.grdclmnItemNumber.VisibleIndex = 4;
            // 
            // grdclmnLotNumber
            // 
            this.grdclmnLotNumber.Caption = "LotNumber";
            this.grdclmnLotNumber.FieldName = "LotNumber";
            this.grdclmnLotNumber.Name = "grdclmnLotNumber";
            this.grdclmnLotNumber.OptionsColumn.AllowEdit = false;
            this.grdclmnLotNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnLotNumber.OptionsColumn.AllowMove = false;
            this.grdclmnLotNumber.Visible = true;
            this.grdclmnLotNumber.VisibleIndex = 5;
            // 
            // grdclmnBinFrom
            // 
            this.grdclmnBinFrom.Caption = "BinFrom";
            this.grdclmnBinFrom.FieldName = "BinFrom";
            this.grdclmnBinFrom.Name = "grdclmnBinFrom";
            this.grdclmnBinFrom.OptionsColumn.AllowEdit = false;
            this.grdclmnBinFrom.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnBinFrom.OptionsColumn.AllowMove = false;
            this.grdclmnBinFrom.Visible = true;
            this.grdclmnBinFrom.VisibleIndex = 6;
            // 
            // grdclmnBinTo
            // 
            this.grdclmnBinTo.Caption = "BinTo";
            this.grdclmnBinTo.FieldName = "BinTo";
            this.grdclmnBinTo.Name = "grdclmnBinTo";
            this.grdclmnBinTo.OptionsColumn.AllowEdit = false;
            this.grdclmnBinTo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnBinTo.OptionsColumn.AllowMove = false;
            this.grdclmnBinTo.Visible = true;
            this.grdclmnBinTo.VisibleIndex = 7;
            // 
            // grdclmnQuantity
            // 
            this.grdclmnQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnQuantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQuantity.Caption = "Quantity";
            this.grdclmnQuantity.FieldName = "Quantity";
            this.grdclmnQuantity.Name = "grdclmnQuantity";
            this.grdclmnQuantity.OptionsColumn.AllowEdit = false;
            this.grdclmnQuantity.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnQuantity.OptionsColumn.AllowMove = false;
            this.grdclmnQuantity.Visible = true;
            this.grdclmnQuantity.VisibleIndex = 8;
            // 
            // grdclmnOrderNo
            // 
            this.grdclmnOrderNo.Caption = "OrderNo";
            this.grdclmnOrderNo.FieldName = "OrderNo";
            this.grdclmnOrderNo.Name = "grdclmnOrderNo";
            this.grdclmnOrderNo.OptionsColumn.AllowEdit = false;
            this.grdclmnOrderNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnOrderNo.OptionsColumn.AllowMove = false;
            this.grdclmnOrderNo.Visible = true;
            this.grdclmnOrderNo.VisibleIndex = 9;
            // 
            // grdclmnOrderLineNo
            // 
            this.grdclmnOrderLineNo.Caption = "OrderLineNo";
            this.grdclmnOrderLineNo.FieldName = "OrderLineNo";
            this.grdclmnOrderLineNo.Name = "grdclmnOrderLineNo";
            this.grdclmnOrderLineNo.OptionsColumn.AllowEdit = false;
            this.grdclmnOrderLineNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnOrderLineNo.OptionsColumn.AllowMove = false;
            this.grdclmnOrderLineNo.Visible = true;
            this.grdclmnOrderLineNo.VisibleIndex = 10;
            // 
            // grdclmnLinkedLogID
            // 
            this.grdclmnLinkedLogID.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnLinkedLogID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnLinkedLogID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLinkedLogID.Caption = "LinkedLogID";
            this.grdclmnLinkedLogID.FieldName = "LinkedLogID";
            this.grdclmnLinkedLogID.Name = "grdclmnLinkedLogID";
            this.grdclmnLinkedLogID.OptionsColumn.AllowEdit = false;
            this.grdclmnLinkedLogID.Visible = true;
            this.grdclmnLinkedLogID.VisibleIndex = 11;
            // 
            // grdclmnRetry
            // 
            this.grdclmnRetry.Caption = "重试";
            this.grdclmnRetry.FieldName = "Retried";
            this.grdclmnRetry.Name = "grdclmnRetry";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel1.Controls.Add(this.grdExChangeXML);
            this.splitContainerControl2.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl2.Panel1.Text = "Exchange XML";
            this.splitContainerControl2.Panel2.Controls.Add(this.splitContainerControl3);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(390, 628);
            this.splitContainerControl2.SplitterPosition = 352;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // grdExChangeXML
            // 
            this.grdExChangeXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdExChangeXML.Location = new System.Drawing.Point(5, 5);
            this.grdExChangeXML.MainView = this.grdvExChangeXML;
            this.grdExChangeXML.MenuManager = this.ribbon;
            this.grdExChangeXML.Name = "grdExChangeXML";
            this.grdExChangeXML.Padding = new System.Windows.Forms.Padding(5);
            this.grdExChangeXML.Size = new System.Drawing.Size(376, 250);
            this.grdExChangeXML.TabIndex = 0;
            this.grdExChangeXML.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvExChangeXML});
            // 
            // grdvExChangeXML
            // 
            this.grdvExChangeXML.Appearance.FieldCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdvExChangeXML.Appearance.FieldCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvExChangeXML.Appearance.FieldCaption.Options.UseBackColor = true;
            this.grdvExChangeXML.Appearance.FieldCaption.Options.UseFont = true;
            this.grdvExChangeXML.Appearance.FieldValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdvExChangeXML.Appearance.FieldValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvExChangeXML.Appearance.FieldValue.Options.UseBackColor = true;
            this.grdvExChangeXML.Appearance.FieldValue.Options.UseFont = true;
            this.grdvExChangeXML.FocusedCardTopFieldIndex = 0;
            this.grdvExChangeXML.GridControl = this.grdExChangeXML;
            this.grdvExChangeXML.Name = "grdvExChangeXML";
            this.grdvExChangeXML.OptionsBehavior.AutoHorzWidth = true;
            this.grdvExChangeXML.OptionsBehavior.ReadOnly = true;
            this.grdvExChangeXML.OptionsView.ShowCardCaption = false;
            this.grdvExChangeXML.OptionsView.ShowHorzScrollBar = false;
            this.grdvExChangeXML.OptionsView.ShowLines = false;
            this.grdvExChangeXML.OptionsView.ShowQuickCustomizeButton = false;
            this.grdvExChangeXML.OptionsView.ShowViewCaption = true;
            this.grdvExChangeXML.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.grdvExChangeXML.ViewCaption = "调用 WebService 的 XML 报文内容";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl3.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl3.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl3.Panel1.Controls.Add(this.grdMaterialStore);
            this.splitContainerControl3.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl3.Panel1.Text = "批次系统的库存";
            this.splitContainerControl3.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl3.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl3.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl3.Panel2.Controls.Add(this.edtErrText);
            this.splitContainerControl3.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl3.Panel2.ShowCaption = true;
            this.splitContainerControl3.Panel2.Text = "WebService 执行结果";
            this.splitContainerControl3.Size = new System.Drawing.Size(390, 352);
            this.splitContainerControl3.SplitterPosition = 147;
            this.splitContainerControl3.TabIndex = 0;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // grdMaterialStore
            // 
            this.grdMaterialStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaterialStore.Location = new System.Drawing.Point(5, 5);
            this.grdMaterialStore.MainView = this.grdvMaterialStore;
            this.grdMaterialStore.MenuManager = this.ribbon;
            this.grdMaterialStore.Name = "grdMaterialStore";
            this.grdMaterialStore.Padding = new System.Windows.Forms.Padding(5);
            this.grdMaterialStore.Size = new System.Drawing.Size(376, 133);
            this.grdMaterialStore.TabIndex = 1;
            this.grdMaterialStore.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvMaterialStore});
            // 
            // grdvMaterialStore
            // 
            this.grdvMaterialStore.Appearance.FieldCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdvMaterialStore.Appearance.FieldCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvMaterialStore.Appearance.FieldCaption.Options.UseBackColor = true;
            this.grdvMaterialStore.Appearance.FieldCaption.Options.UseFont = true;
            this.grdvMaterialStore.Appearance.FieldValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdvMaterialStore.Appearance.FieldValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvMaterialStore.Appearance.FieldValue.Options.UseBackColor = true;
            this.grdvMaterialStore.Appearance.FieldValue.Options.UseFont = true;
            this.grdvMaterialStore.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn16,
            this.gridColumn15});
            this.grdvMaterialStore.FocusedCardTopFieldIndex = 0;
            this.grdvMaterialStore.GridControl = this.grdMaterialStore;
            this.grdvMaterialStore.Name = "grdvMaterialStore";
            this.grdvMaterialStore.OptionsBehavior.AutoHorzWidth = true;
            this.grdvMaterialStore.OptionsBehavior.ReadOnly = true;
            this.grdvMaterialStore.OptionsView.ShowCardCaption = false;
            this.grdvMaterialStore.OptionsView.ShowHorzScrollBar = false;
            this.grdvMaterialStore.OptionsView.ShowLines = false;
            this.grdvMaterialStore.OptionsView.ShowQuickCustomizeButton = false;
            this.grdvMaterialStore.OptionsView.ShowViewCaption = true;
            this.grdvMaterialStore.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.grdvMaterialStore.ViewCaption = "批次系统的库存";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "标签号";
            this.gridColumn13.FieldName = "SKUID";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "批次号";
            this.gridColumn14.FieldName = "RecvBatchNo";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "所在库位号";
            this.gridColumn16.FieldName = "StorageBin";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 2;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "库存数量";
            this.gridColumn15.FieldName = "QtyInStore";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            // 
            // edtErrText
            // 
            this.edtErrText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtErrText.Location = new System.Drawing.Point(5, 5);
            this.edtErrText.MenuManager = this.ribbon;
            this.edtErrText.Name = "edtErrText";
            this.edtErrText.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtErrText.Properties.Appearance.Options.UseFont = true;
            this.edtErrText.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.edtErrText.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edtErrText.Properties.ReadOnly = true;
            this.edtErrText.Size = new System.Drawing.Size(376, 160);
            this.edtErrText.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelControl1.Appearance.Options.UseFont = true;
            this.panelControl1.Controls.Add(this.btnClearCondition);
            this.panelControl1.Controls.Add(this.chkWaitForRetry);
            this.panelControl1.Controls.Add(this.edtMOLineNo);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.edtMONo);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.edtRecvBatchNo);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.edtItemNumber);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.btnGetLogs);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(5, 5);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1146, 41);
            this.panelControl1.TabIndex = 0;
            // 
            // btnClearCondition
            // 
            this.btnClearCondition.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCondition.Appearance.Options.UseFont = true;
            this.btnClearCondition.Location = new System.Drawing.Point(973, 6);
            this.btnClearCondition.Name = "btnClearCondition";
            this.btnClearCondition.Size = new System.Drawing.Size(75, 26);
            this.btnClearCondition.TabIndex = 12;
            this.btnClearCondition.Text = "清除";
            this.btnClearCondition.Click += new System.EventHandler(this.btnClearCondition_Click);
            // 
            // chkWaitForRetry
            // 
            this.chkWaitForRetry.EditValue = true;
            this.chkWaitForRetry.Enabled = false;
            this.chkWaitForRetry.Location = new System.Drawing.Point(892, 8);
            this.chkWaitForRetry.MenuManager = this.ribbon;
            this.chkWaitForRetry.Name = "chkWaitForRetry";
            this.chkWaitForRetry.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWaitForRetry.Properties.Appearance.Options.UseFont = true;
            this.chkWaitForRetry.Properties.Caption = "等待重试";
            this.chkWaitForRetry.Size = new System.Drawing.Size(75, 24);
            this.chkWaitForRetry.TabIndex = 11;
            // 
            // edtMOLineNo
            // 
            this.edtMOLineNo.Location = new System.Drawing.Point(826, 7);
            this.edtMOLineNo.MenuManager = this.ribbon;
            this.edtMOLineNo.Name = "edtMOLineNo";
            this.edtMOLineNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtMOLineNo.Properties.Appearance.Options.UseFont = true;
            this.edtMOLineNo.Size = new System.Drawing.Size(60, 26);
            this.edtMOLineNo.TabIndex = 10;
            this.edtMOLineNo.EditValueChanged += new System.EventHandler(this.edtLinkedLogID_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(734, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(86, 20);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "OrderLineNo";
            // 
            // edtMONo
            // 
            this.edtMONo.Location = new System.Drawing.Point(536, 7);
            this.edtMONo.MenuManager = this.ribbon;
            this.edtMONo.Name = "edtMONo";
            this.edtMONo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtMONo.Properties.Appearance.Options.UseFont = true;
            this.edtMONo.Size = new System.Drawing.Size(192, 26);
            this.edtMONo.TabIndex = 8;
            this.edtMONo.EditValueChanged += new System.EventHandler(this.edtLinkedLogID_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(472, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 20);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "OrderNo";
            // 
            // edtRecvBatchNo
            // 
            this.edtRecvBatchNo.EditValue = "";
            this.edtRecvBatchNo.Location = new System.Drawing.Point(340, 7);
            this.edtRecvBatchNo.MenuManager = this.ribbon;
            this.edtRecvBatchNo.Name = "edtRecvBatchNo";
            this.edtRecvBatchNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtRecvBatchNo.Properties.Appearance.Options.UseFont = true;
            this.edtRecvBatchNo.Size = new System.Drawing.Size(126, 26);
            this.edtRecvBatchNo.TabIndex = 6;
            this.edtRecvBatchNo.EditValueChanged += new System.EventHandler(this.edtLinkedLogID_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(258, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 20);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "LotNumber";
            // 
            // edtItemNumber
            // 
            this.edtItemNumber.Location = new System.Drawing.Point(96, 7);
            this.edtItemNumber.MenuManager = this.ribbon;
            this.edtItemNumber.Name = "edtItemNumber";
            this.edtItemNumber.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtItemNumber.Properties.Appearance.Options.UseFont = true;
            this.edtItemNumber.Size = new System.Drawing.Size(156, 26);
            this.edtItemNumber.TabIndex = 4;
            this.edtItemNumber.EditValueChanged += new System.EventHandler(this.edtLinkedLogID_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(5, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 20);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "ItemNumber";
            // 
            // btnGetLogs
            // 
            this.btnGetLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetLogs.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetLogs.Appearance.Options.UseFont = true;
            this.btnGetLogs.Location = new System.Drawing.Point(1066, 6);
            this.btnGetLogs.Name = "btnGetLogs";
            this.btnGetLogs.Size = new System.Drawing.Size(75, 26);
            this.btnGetLogs.TabIndex = 0;
            this.btnGetLogs.Text = "获取";
            this.btnGetLogs.Click += new System.EventHandler(this.btnGetLogs_Click);
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 156);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpUnclosedDelivery;
            this.tcMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tcMain.Size = new System.Drawing.Size(1158, 681);
            this.tcMain.TabIndex = 5;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpWebServiceLogs,
            this.tpUnclosedDelivery});
            // 
            // tpWebServiceLogs
            // 
            this.tpWebServiceLogs.Controls.Add(this.splitContainerControl1);
            this.tpWebServiceLogs.Controls.Add(this.panelControl1);
            this.tpWebServiceLogs.Name = "tpWebServiceLogs";
            this.tpWebServiceLogs.Padding = new System.Windows.Forms.Padding(5);
            this.tpWebServiceLogs.Size = new System.Drawing.Size(1156, 679);
            this.tpWebServiceLogs.Text = "xtraTabPage1";
            // 
            // tpUnclosedDelivery
            // 
            this.tpUnclosedDelivery.Name = "tpUnclosedDelivery";
            this.tpUnclosedDelivery.Size = new System.Drawing.Size(1156, 679);
            this.tpUnclosedDelivery.Text = "xtraTabPage1";
            // 
            // frmMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1158, 858);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "批次系统-钢带库维护工具（亚新科双环活塞环有限公司）";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdvLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExChangeXML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvExChangeXML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterialStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMaterialStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErrText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkWaitForRetry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMOLineNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMONo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRecvBatchNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtItemNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpWebServiceLogs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem bbiSysParams;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdLogs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvLogs;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraEditors.SimpleButton btnGetLogs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSKUID;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLogID;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnExCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnItemNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLotNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnBinFrom;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnBinTo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrderLineNo;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.XtraEditors.CheckEdit chkWaitForRetry;
        private DevExpress.XtraEditors.TextEdit edtMOLineNo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit edtMONo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit edtRecvBatchNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit edtItemNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLinkedLogID;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraEditors.MemoEdit edtErrText;
        private DevExpress.XtraGrid.GridControl grdExChangeXML;
        private DevExpress.XtraGrid.Views.Card.CardView grdvExChangeXML;
        private DevExpress.XtraBars.BarStaticItem sbMessage;
        private DevExpress.XtraGrid.GridControl grdMaterialStore;
        private DevExpress.XtraGrid.Views.Card.CardView grdvMaterialStore;
        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpWebServiceLogs;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiRetry;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiUnselectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRetry;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnErrCode;
        private DevExpress.XtraEditors.SimpleButton btnClearCondition;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnTimeWritten;
        private DevExpress.XtraTab.XtraTabPage tpUnclosedDelivery;
    }
}