namespace IRAP.Client.GUI.SCES
{
    partial class frmDeliveryMngmt_30
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeliveryMngmt_30));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitmDeliver = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeprater = new System.Windows.Forms.ToolStripSeparator();
            this.mitmRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSyncMO = new DevExpress.XtraEditors.SimpleButton();
            this.btnReprint = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboDstStoreSites = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnDeliver = new DevExpress.XtraEditors.SimpleButton();
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.grdOrders = new DevExpress.XtraGrid.GridControl();
            this.grdvOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSubMaterialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT134Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT134Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedQuantityString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedCloseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScheduleStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.report = new FastReport.Report();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.btnReprint1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearchByMaterialCode = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeliver1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.grdPWOs = new DevExpress.XtraGrid.GridControl();
            this.grdvPWOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.edtSubMaterialCode = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDstStoreSites.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSubMaterialCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(827, 56);
            this.lblFuncName.Text = "物料配送管理";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(827, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmDeliver,
            this.tsmiSeprater,
            this.mitmRefresh});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(107, 58);
            // 
            // mitmDeliver
            // 
            this.mitmDeliver.Name = "mitmDeliver";
            this.mitmDeliver.Size = new System.Drawing.Size(106, 24);
            this.mitmDeliver.Text = "配送";
            this.mitmDeliver.Click += new System.EventHandler(this.mitmDeliver_Click);
            // 
            // tsmiSeprater
            // 
            this.tsmiSeprater.Name = "tsmiSeprater";
            this.tsmiSeprater.Size = new System.Drawing.Size(103, 6);
            // 
            // mitmRefresh
            // 
            this.mitmRefresh.Name = "mitmRefresh";
            this.mitmRefresh.Size = new System.Drawing.Size(106, 24);
            this.mitmRefresh.Text = "刷新";
            this.mitmRefresh.Click += new System.EventHandler(this.mitmRefresh_Click);
            // 
            // btnSyncMO
            // 
            this.btnSyncMO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncMO.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnSyncMO.Appearance.Options.UseFont = true;
            this.btnSyncMO.Location = new System.Drawing.Point(706, 178);
            this.btnSyncMO.Name = "btnSyncMO";
            this.btnSyncMO.Size = new System.Drawing.Size(108, 28);
            this.btnSyncMO.TabIndex = 4;
            this.btnSyncMO.Text = "同步四班订单";
            this.btnSyncMO.Click += new System.EventHandler(this.btnSyncMO_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprint.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnReprint.Appearance.Options.UseFont = true;
            this.btnReprint.Location = new System.Drawing.Point(706, 343);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(108, 28);
            this.btnReprint.TabIndex = 5;
            this.btnReprint.Text = "补打";
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(706, 126);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(108, 28);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboDstStoreSites);
            this.groupControl1.Location = new System.Drawing.Point(9, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl1.Size = new System.Drawing.Size(691, 65);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "目标仓储地点";
            // 
            // cboDstStoreSites
            // 
            this.cboDstStoreSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDstStoreSites.Location = new System.Drawing.Point(7, 28);
            this.cboDstStoreSites.MinimumSize = new System.Drawing.Size(0, 28);
            this.cboDstStoreSites.Name = "cboDstStoreSites";
            this.cboDstStoreSites.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.cboDstStoreSites.Properties.Appearance.Options.UseFont = true;
            this.cboDstStoreSites.Properties.AppearanceDropDown.Font = new System.Drawing.Font("新宋体", 12F);
            this.cboDstStoreSites.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDstStoreSites.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDstStoreSites.Properties.DropDownItemHeight = 28;
            this.cboDstStoreSites.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDstStoreSites.Size = new System.Drawing.Size(677, 28);
            this.cboDstStoreSites.TabIndex = 0;
            this.cboDstStoreSites.SelectedIndexChanged += new System.EventHandler(this.cboDstStoreSites_SelectedIndexChanged);
            // 
            // btnDeliver
            // 
            this.btnDeliver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeliver.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnDeliver.Appearance.Options.UseFont = true;
            this.btnDeliver.Location = new System.Drawing.Point(706, 83);
            this.btnDeliver.Name = "btnDeliver";
            this.btnDeliver.Size = new System.Drawing.Size(108, 28);
            this.btnDeliver.TabIndex = 2;
            this.btnDeliver.Text = "配送";
            this.btnDeliver.Click += new System.EventHandler(this.btnDeliver_Click);
            // 
            // gpcAndonEvents
            // 
            this.gpcAndonEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcAndonEvents.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.gpcAndonEvents.Appearance.Options.UseFont = true;
            this.gpcAndonEvents.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.gpcAndonEvents.AppearanceCaption.Options.UseFont = true;
            this.gpcAndonEvents.Controls.Add(this.grdOrders);
            this.gpcAndonEvents.Location = new System.Drawing.Point(9, 83);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            this.gpcAndonEvents.Padding = new System.Windows.Forms.Padding(5);
            this.gpcAndonEvents.Size = new System.Drawing.Size(691, 288);
            this.gpcAndonEvents.TabIndex = 1;
            this.gpcAndonEvents.Text = "待处理的配料单列表";
            // 
            // grdOrders
            // 
            this.grdOrders.ContextMenuStrip = this.contextMenuStrip;
            this.grdOrders.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrders.Location = new System.Drawing.Point(7, 28);
            this.grdOrders.MainView = this.grdvOrders;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.Size = new System.Drawing.Size(677, 253);
            this.grdOrders.TabIndex = 1;
            this.grdOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOrders});
            // 
            // grdvOrders
            // 
            this.grdvOrders.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdvOrders.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvOrders.Appearance.Preview.ForeColor = System.Drawing.Color.Blue;
            this.grdvOrders.Appearance.Preview.Options.UseForeColor = true;
            this.grdvOrders.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdvOrders.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            this.grdvOrders.Appearance.Row.Options.UseFont = true;
            this.grdvOrders.Appearance.Row.Options.UseForeColor = true;
            this.grdvOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnPWONo,
            this.grdclmnMONumber,
            this.grdclmnMOLineNo,
            this.grdclmnProductNo,
            this.grdclmnProductDescription,
            this.grdclmnSubMaterialCode,
            this.grdclmnT134Code,
            this.grdclmnT134Name,
            this.grdclmnPlannedQuantityString,
            this.grdclmnPlannedStartDate,
            this.grdclmnPlannedCloseDate,
            this.grdclmnScheduleStartTime});
            this.grdvOrders.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.grdvOrders.GridControl = this.grdOrders;
            this.grdvOrders.Name = "grdvOrders";
            this.grdvOrders.OptionsBehavior.Editable = false;
            this.grdvOrders.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvOrders.OptionsView.ColumnAutoWidth = false;
            this.grdvOrders.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvOrders.OptionsView.EnableAppearanceOddRow = true;
            this.grdvOrders.OptionsView.ShowGroupPanel = false;
            this.grdvOrders.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdvOrders_FocusedRowChanged);
            this.grdvOrders.DoubleClick += new System.EventHandler(this.grdvOrders_DoubleClick);
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnPWONo.AppearanceCell.Options.UseFont = true;
            this.grdclmnPWONo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnPWONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWONo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPWONo.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnPWONo.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPWONo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPWONo.Caption = "生产工单号";
            this.grdclmnPWONo.FieldName = "PWONo";
            this.grdclmnPWONo.Name = "grdclmnPWONo";
            this.grdclmnPWONo.OptionsColumn.ReadOnly = true;
            this.grdclmnPWONo.Visible = true;
            this.grdclmnPWONo.VisibleIndex = 3;
            this.grdclmnPWONo.Width = 120;
            // 
            // grdclmnMONumber
            // 
            this.grdclmnMONumber.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnMONumber.AppearanceCell.Options.UseFont = true;
            this.grdclmnMONumber.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMONumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnMONumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONumber.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMONumber.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnMONumber.AppearanceHeader.Options.UseFont = true;
            this.grdclmnMONumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMONumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMONumber.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONumber.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMONumber.Caption = "制造订单号";
            this.grdclmnMONumber.FieldName = "MONumber";
            this.grdclmnMONumber.Name = "grdclmnMONumber";
            this.grdclmnMONumber.OptionsColumn.ReadOnly = true;
            this.grdclmnMONumber.Visible = true;
            this.grdclmnMONumber.VisibleIndex = 1;
            this.grdclmnMONumber.Width = 120;
            // 
            // grdclmnMOLineNo
            // 
            this.grdclmnMOLineNo.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnMOLineNo.AppearanceCell.Options.UseFont = true;
            this.grdclmnMOLineNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnMOLineNo.AppearanceHeader.Options.UseFont = true;
            this.grdclmnMOLineNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMOLineNo.Caption = "行号";
            this.grdclmnMOLineNo.FieldName = "MOLineNo";
            this.grdclmnMOLineNo.Name = "grdclmnMOLineNo";
            this.grdclmnMOLineNo.OptionsColumn.ReadOnly = true;
            this.grdclmnMOLineNo.Visible = true;
            this.grdclmnMOLineNo.VisibleIndex = 2;
            // 
            // grdclmnProductNo
            // 
            this.grdclmnProductNo.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnProductNo.AppearanceCell.Options.UseFont = true;
            this.grdclmnProductNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnProductNo.AppearanceHeader.Options.UseFont = true;
            this.grdclmnProductNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductNo.Caption = "产品编号";
            this.grdclmnProductNo.FieldName = "ProductNo";
            this.grdclmnProductNo.Name = "grdclmnProductNo";
            this.grdclmnProductNo.OptionsColumn.ReadOnly = true;
            this.grdclmnProductNo.Visible = true;
            this.grdclmnProductNo.VisibleIndex = 4;
            // 
            // grdclmnProductDescription
            // 
            this.grdclmnProductDescription.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnProductDescription.AppearanceCell.Options.UseFont = true;
            this.grdclmnProductDescription.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnProductDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductDescription.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnProductDescription.AppearanceHeader.Options.UseFont = true;
            this.grdclmnProductDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnProductDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductDescription.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductDescription.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductDescription.Caption = "产品名称";
            this.grdclmnProductDescription.FieldName = "ProductDesc";
            this.grdclmnProductDescription.Name = "grdclmnProductDescription";
            this.grdclmnProductDescription.OptionsColumn.ReadOnly = true;
            this.grdclmnProductDescription.Visible = true;
            this.grdclmnProductDescription.VisibleIndex = 6;
            // 
            // grdclmnSubMaterialCode
            // 
            this.grdclmnSubMaterialCode.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnSubMaterialCode.AppearanceCell.Options.UseFont = true;
            this.grdclmnSubMaterialCode.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnSubMaterialCode.AppearanceHeader.Options.UseFont = true;
            this.grdclmnSubMaterialCode.Caption = "子项物料号";
            this.grdclmnSubMaterialCode.FieldName = "SubMaterialCode";
            this.grdclmnSubMaterialCode.Name = "grdclmnSubMaterialCode";
            this.grdclmnSubMaterialCode.Visible = true;
            this.grdclmnSubMaterialCode.VisibleIndex = 5;
            // 
            // grdclmnT134Code
            // 
            this.grdclmnT134Code.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnT134Code.AppearanceCell.Options.UseFont = true;
            this.grdclmnT134Code.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT134Code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnT134Code.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT134Code.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnT134Code.AppearanceHeader.Options.UseFont = true;
            this.grdclmnT134Code.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT134Code.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT134Code.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT134Code.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnT134Code.Caption = "产线代码";
            this.grdclmnT134Code.FieldName = "T134Code";
            this.grdclmnT134Code.Name = "grdclmnT134Code";
            this.grdclmnT134Code.OptionsColumn.ReadOnly = true;
            this.grdclmnT134Code.Visible = true;
            this.grdclmnT134Code.VisibleIndex = 10;
            // 
            // grdclmnT134Name
            // 
            this.grdclmnT134Name.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnT134Name.AppearanceCell.Options.UseFont = true;
            this.grdclmnT134Name.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT134Name.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT134Name.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnT134Name.AppearanceHeader.Options.UseFont = true;
            this.grdclmnT134Name.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT134Name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT134Name.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT134Name.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnT134Name.Caption = "产线名称";
            this.grdclmnT134Name.FieldName = "T134Name";
            this.grdclmnT134Name.Name = "grdclmnT134Name";
            this.grdclmnT134Name.OptionsColumn.ReadOnly = true;
            this.grdclmnT134Name.Visible = true;
            this.grdclmnT134Name.VisibleIndex = 11;
            // 
            // grdclmnPlannedQuantityString
            // 
            this.grdclmnPlannedQuantityString.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnPlannedQuantityString.AppearanceCell.Options.UseFont = true;
            this.grdclmnPlannedQuantityString.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedQuantityString.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnPlannedQuantityString.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedQuantityString.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnPlannedQuantityString.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPlannedQuantityString.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedQuantityString.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedQuantityString.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedQuantityString.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedQuantityString.Caption = "排产数量";
            this.grdclmnPlannedQuantityString.FieldName = "PlannedQuantity";
            this.grdclmnPlannedQuantityString.Name = "grdclmnPlannedQuantityString";
            this.grdclmnPlannedQuantityString.OptionsColumn.ReadOnly = true;
            this.grdclmnPlannedQuantityString.Visible = true;
            this.grdclmnPlannedQuantityString.VisibleIndex = 7;
            // 
            // grdclmnPlannedStartDate
            // 
            this.grdclmnPlannedStartDate.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnPlannedStartDate.AppearanceCell.Options.UseFont = true;
            this.grdclmnPlannedStartDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedStartDate.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnPlannedStartDate.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPlannedStartDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedStartDate.Caption = "计划开工日期";
            this.grdclmnPlannedStartDate.FieldName = "PlannedStartDate";
            this.grdclmnPlannedStartDate.Name = "grdclmnPlannedStartDate";
            this.grdclmnPlannedStartDate.Visible = true;
            this.grdclmnPlannedStartDate.VisibleIndex = 8;
            this.grdclmnPlannedStartDate.Width = 82;
            // 
            // grdclmnPlannedCloseDate
            // 
            this.grdclmnPlannedCloseDate.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnPlannedCloseDate.AppearanceCell.Options.UseFont = true;
            this.grdclmnPlannedCloseDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedCloseDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnPlannedCloseDate.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPlannedCloseDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedCloseDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedCloseDate.Caption = "计划完工日期";
            this.grdclmnPlannedCloseDate.FieldName = "PlannedCloseDate";
            this.grdclmnPlannedCloseDate.Name = "grdclmnPlannedCloseDate";
            this.grdclmnPlannedCloseDate.OptionsColumn.ReadOnly = true;
            this.grdclmnPlannedCloseDate.Visible = true;
            this.grdclmnPlannedCloseDate.VisibleIndex = 9;
            this.grdclmnPlannedCloseDate.Width = 82;
            // 
            // grdclmnScheduleStartTime
            // 
            this.grdclmnScheduleStartTime.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnScheduleStartTime.AppearanceCell.Options.UseFont = true;
            this.grdclmnScheduleStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnScheduleStartTime.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnScheduleStartTime.AppearanceHeader.Options.UseFont = true;
            this.grdclmnScheduleStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnScheduleStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnScheduleStartTime.Caption = "要求送达时间";
            this.grdclmnScheduleStartTime.FieldName = "RequireDeliveryTime";
            this.grdclmnScheduleStartTime.Name = "grdclmnScheduleStartTime";
            this.grdclmnScheduleStartTime.Visible = true;
            this.grdclmnScheduleStartTime.VisibleIndex = 0;
            this.grdclmnScheduleStartTime.Width = 161;
            // 
            // report
            // 
            this.report.ReportResourceString = resources.GetString("report.ReportResourceString");
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("新宋体", 12F);
            this.xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold);
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("新宋体", 12F);
            this.xtraTabControl1.AppearancePage.HeaderDisabled.ForeColor = System.Drawing.Color.Silver;
            this.xtraTabControl1.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderDisabled.Options.UseForeColor = true;
            this.xtraTabControl1.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Underline);
            this.xtraTabControl1.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.PageClient.Font = new System.Drawing.Font("新宋体", 12F);
            this.xtraTabControl1.AppearancePage.PageClient.Options.UseFont = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 56);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(827, 410);
            this.xtraTabControl1.TabIndex = 6;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btnReprint);
            this.xtraTabPage1.Controls.Add(this.btnSyncMO);
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Controls.Add(this.gpcAndonEvents);
            this.xtraTabPage1.Controls.Add(this.btnRefresh);
            this.xtraTabPage1.Controls.Add(this.btnDeliver);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(821, 379);
            this.xtraTabPage1.Text = "按目标仓储地点";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.btnReprint1);
            this.xtraTabPage2.Controls.Add(this.btnSearchByMaterialCode);
            this.xtraTabPage2.Controls.Add(this.btnDeliver1);
            this.xtraTabPage2.Controls.Add(this.groupControl3);
            this.xtraTabPage2.Controls.Add(this.groupControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(821, 379);
            this.xtraTabPage2.Text = "按子项物料";
            // 
            // btnReprint1
            // 
            this.btnReprint1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprint1.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnReprint1.Appearance.Options.UseFont = true;
            this.btnReprint1.Location = new System.Drawing.Point(706, 343);
            this.btnReprint1.Name = "btnReprint1";
            this.btnReprint1.Size = new System.Drawing.Size(108, 28);
            this.btnReprint1.TabIndex = 8;
            this.btnReprint1.Text = "补打";
            this.btnReprint1.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnSearchByMaterialCode
            // 
            this.btnSearchByMaterialCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchByMaterialCode.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnSearchByMaterialCode.Appearance.Options.UseFont = true;
            this.btnSearchByMaterialCode.Location = new System.Drawing.Point(706, 40);
            this.btnSearchByMaterialCode.Name = "btnSearchByMaterialCode";
            this.btnSearchByMaterialCode.Size = new System.Drawing.Size(108, 28);
            this.btnSearchByMaterialCode.TabIndex = 2;
            this.btnSearchByMaterialCode.Text = "查询";
            this.btnSearchByMaterialCode.Click += new System.EventHandler(this.btnSearchByMaterialCode_Click);
            // 
            // btnDeliver1
            // 
            this.btnDeliver1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeliver1.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnDeliver1.Appearance.Options.UseFont = true;
            this.btnDeliver1.Location = new System.Drawing.Point(706, 83);
            this.btnDeliver1.Name = "btnDeliver1";
            this.btnDeliver1.Size = new System.Drawing.Size(108, 28);
            this.btnDeliver1.TabIndex = 3;
            this.btnDeliver1.Text = "配送";
            this.btnDeliver1.Click += new System.EventHandler(this.btnDeliver1_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.groupControl3.Appearance.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.grdPWOs);
            this.groupControl3.Location = new System.Drawing.Point(9, 83);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl3.Size = new System.Drawing.Size(691, 288);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "待处理的配料单列表";
            // 
            // grdPWOs
            // 
            this.grdPWOs.ContextMenuStrip = this.contextMenuStrip;
            this.grdPWOs.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdPWOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPWOs.Location = new System.Drawing.Point(7, 28);
            this.grdPWOs.MainView = this.grdvPWOs;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.Size = new System.Drawing.Size(677, 253);
            this.grdPWOs.TabIndex = 1;
            this.grdPWOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPWOs});
            // 
            // grdvPWOs
            // 
            this.grdvPWOs.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvPWOs.Appearance.Preview.ForeColor = System.Drawing.Color.Blue;
            this.grdvPWOs.Appearance.Preview.Options.UseForeColor = true;
            this.grdvPWOs.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdvPWOs.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            this.grdvPWOs.Appearance.Row.Options.UseFont = true;
            this.grdvPWOs.Appearance.Row.Options.UseForeColor = true;
            this.grdvPWOs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.grdvPWOs.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.grdvPWOs.GridControl = this.grdPWOs;
            this.grdvPWOs.Name = "grdvPWOs";
            this.grdvPWOs.OptionsBehavior.Editable = false;
            this.grdvPWOs.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvPWOs.OptionsView.ColumnAutoWidth = false;
            this.grdvPWOs.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvPWOs.OptionsView.EnableAppearanceOddRow = true;
            this.grdvPWOs.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "目标仓储地点";
            this.gridColumn13.FieldName = "T173Name";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "生产工单号";
            this.gridColumn1.FieldName = "PWONo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 120;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "制造订单号";
            this.gridColumn2.FieldName = "MONumber";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.Caption = "行号";
            this.gridColumn3.FieldName = "MOLineNo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.Caption = "产品编号";
            this.gridColumn4.FieldName = "ProductNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn5.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn5.Caption = "产品名称";
            this.gridColumn5.FieldName = "ProductDesc";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "子项物料号";
            this.gridColumn6.FieldName = "SubMaterialCode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn7.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn7.Caption = "产线代码";
            this.gridColumn7.FieldName = "T134Code";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 11;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn8.Caption = "产线名称";
            this.gridColumn8.FieldName = "T134Name";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 12;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn9.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn9.Caption = "排产数量";
            this.gridColumn9.FieldName = "PlannedQuantity";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn10.AppearanceCell.Options.UseFont = true;
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn10.Caption = "计划开工日期";
            this.gridColumn10.FieldName = "PlannedStartDate";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 82;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn11.AppearanceCell.Options.UseFont = true;
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn11.Caption = "计划完工日期";
            this.gridColumn11.FieldName = "PlannedCloseDate";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 82;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn12.AppearanceCell.Options.UseFont = true;
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn12.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn12.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn12.Caption = "要求送达时间";
            this.gridColumn12.FieldName = "RequireDeliveryTime";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            this.gridColumn12.Width = 161;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.edtSubMaterialCode);
            this.groupControl2.Location = new System.Drawing.Point(9, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl2.Size = new System.Drawing.Size(278, 65);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "子项物料号";
            // 
            // edtSubMaterialCode
            // 
            this.edtSubMaterialCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtSubMaterialCode.Location = new System.Drawing.Point(7, 28);
            this.edtSubMaterialCode.MinimumSize = new System.Drawing.Size(0, 28);
            this.edtSubMaterialCode.Name = "edtSubMaterialCode";
            this.edtSubMaterialCode.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.edtSubMaterialCode.Properties.Appearance.Options.UseFont = true;
            this.edtSubMaterialCode.Size = new System.Drawing.Size(264, 28);
            this.edtSubMaterialCode.TabIndex = 1;
            this.edtSubMaterialCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtSubMaterialCode_KeyDown);
            // 
            // frmDeliveryMngmt_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(827, 466);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "frmDeliveryMngmt_30";
            this.Text = "物料配送管理";
            this.Shown += new System.EventHandler(this.frmDeliveryMngmt_30_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboDstStoreSites.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSubMaterialCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mitmDeliver;
        private System.Windows.Forms.ToolStripSeparator tsmiSeprater;
        private System.Windows.Forms.ToolStripMenuItem mitmRefresh;
        private DevExpress.XtraEditors.SimpleButton btnDeliver;
        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.XtraGrid.GridControl grdOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOrders;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT134Code;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT134Name;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlannedQuantityString;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlannedCloseDate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScheduleStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlannedStartDate;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboDstStoreSites;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private FastReport.Report report;
        private DevExpress.XtraEditors.SimpleButton btnReprint;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSubMaterialCode;
        private DevExpress.XtraEditors.SimpleButton btnSyncMO;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit edtSubMaterialCode;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.SimpleButton btnSearchByMaterialCode;
        private DevExpress.XtraEditors.SimpleButton btnDeliver1;
        private DevExpress.XtraEditors.SimpleButton btnReprint1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
    }
}
