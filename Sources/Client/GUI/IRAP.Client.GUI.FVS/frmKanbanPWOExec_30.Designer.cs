namespace IRAP.Client.GUI.FVS
{
    partial class frmKanbanPWOExec_30
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lstT103LeafSet = new DevExpress.XtraEditors.ListBoxControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.grdPWOs = new DevExpress.XtraGrid.GridControl();
            this.cardView = new DevExpress.XtraGrid.Views.Card.CardView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitmMethodAndQualityStandard = new System.Windows.Forms.ToolStripMenuItem();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWOQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnWIPQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStationMFGTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnThroughPutTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnAccumMCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScrapedQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFPYPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnAtStationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnAtStationName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstT103LeafSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "frmCustomBase";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.Controls.Add(this.lstT103LeafSet);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "生产任务种类";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainerControl1.Panel2.Controls.Add(this.grdPWOs);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "生产工单清单";
            this.splitContainerControl1.Size = new System.Drawing.Size(891, 479);
            this.splitContainerControl1.SplitterPosition = 220;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lstT103LeafSet
            // 
            this.lstT103LeafSet.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lstT103LeafSet.Appearance.Options.UseFont = true;
            this.lstT103LeafSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstT103LeafSet.Location = new System.Drawing.Point(10, 10);
            this.lstT103LeafSet.Name = "lstT103LeafSet";
            this.lstT103LeafSet.Size = new System.Drawing.Size(196, 429);
            this.lstT103LeafSet.TabIndex = 3;
            this.lstT103LeafSet.SelectedIndexChanged += new System.EventHandler(this.lstT103LeafSet_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(577, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 33);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grdPWOs
            // 
            this.grdPWOs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPWOs.Location = new System.Drawing.Point(18, 10);
            this.grdPWOs.MainView = this.cardView;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.Size = new System.Drawing.Size(553, 429);
            this.grdPWOs.TabIndex = 5;
            this.grdPWOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView});
            this.grdPWOs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cardView_MouseMove);
            // 
            // cardView
            // 
            this.cardView.Appearance.CardCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardView.Appearance.CardCaption.Options.UseFont = true;
            this.cardView.Appearance.FieldCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cardView.Appearance.FieldCaption.Options.UseFont = true;
            this.cardView.Appearance.FieldValue.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cardView.Appearance.FieldValue.Options.UseFont = true;
            this.cardView.Appearance.ViewCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cardView.Appearance.ViewCaption.Options.UseFont = true;
            this.cardView.CardCaptionFormat = "生产工单";
            this.cardView.CardWidth = 400;
            this.cardView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnPWONo,
            this.grdclmnMONo,
            this.grdclmnMOLineNo,
            this.grdclmnProductNo,
            this.grdclmnProductName,
            this.grdclmnLotNumber,
            this.grdclmnPWOQuantity,
            this.grdclmnWIPQuantity,
            this.grdclmnContainerNo,
            this.grdclmnStationMFGTime,
            this.grdclmnThroughPutTime,
            this.grdclmnAccumMCT,
            this.grdclmnScrapedQuantity,
            this.grdclmnFPYPercentage,
            this.grdclmnAtStationCode,
            this.grdclmnAtStationName});
            this.cardView.FocusedCardTopFieldIndex = 0;
            this.cardView.GridControl = this.grdPWOs;
            this.cardView.Name = "cardView";
            this.cardView.OptionsBehavior.Editable = false;
            this.cardView.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.cardView.OptionsView.ShowQuickCustomizeButton = false;
            this.cardView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.cardView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cardView_MouseMove);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmMethodAndQualityStandard});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(209, 48);
            // 
            // mitmMethodAndQualityStandard
            // 
            this.mitmMethodAndQualityStandard.Name = "mitmMethodAndQualityStandard";
            this.mitmMethodAndQualityStandard.Size = new System.Drawing.Size(208, 22);
            this.mitmMethodAndQualityStandard.Text = "查看工艺参数和质量标准";
            this.mitmMethodAndQualityStandard.Click += new System.EventHandler(this.mitmMethodAndQualityStandard_Click);
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWONo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWONo.Caption = "生产工单号";
            this.grdclmnPWONo.FieldName = "PWONo";
            this.grdclmnPWONo.Name = "grdclmnPWONo";
            this.grdclmnPWONo.Visible = true;
            this.grdclmnPWONo.VisibleIndex = 0;
            // 
            // grdclmnMONo
            // 
            this.grdclmnMONo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnMONo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONo.Caption = "制造订单号";
            this.grdclmnMONo.FieldName = "MONumber";
            this.grdclmnMONo.Name = "grdclmnMONo";
            this.grdclmnMONo.Visible = true;
            this.grdclmnMONo.VisibleIndex = 1;
            // 
            // grdclmnMOLineNo
            // 
            this.grdclmnMOLineNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.Caption = "行号";
            this.grdclmnMOLineNo.FieldName = "MOLineNo";
            this.grdclmnMOLineNo.Name = "grdclmnMOLineNo";
            this.grdclmnMOLineNo.Visible = true;
            this.grdclmnMOLineNo.VisibleIndex = 2;
            // 
            // grdclmnProductNo
            // 
            this.grdclmnProductNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.Caption = "产品编号";
            this.grdclmnProductNo.FieldName = "ProductNo";
            this.grdclmnProductNo.Name = "grdclmnProductNo";
            this.grdclmnProductNo.Visible = true;
            this.grdclmnProductNo.VisibleIndex = 3;
            // 
            // grdclmnProductName
            // 
            this.grdclmnProductName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnProductName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnProductName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductName.Caption = "产品名称";
            this.grdclmnProductName.FieldName = "ProductName";
            this.grdclmnProductName.Name = "grdclmnProductName";
            this.grdclmnProductName.Visible = true;
            this.grdclmnProductName.VisibleIndex = 4;
            // 
            // grdclmnLotNumber
            // 
            this.grdclmnLotNumber.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnLotNumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLotNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnLotNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnLotNumber.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLotNumber.Caption = "生产批号";
            this.grdclmnLotNumber.FieldName = "LotNumber";
            this.grdclmnLotNumber.Name = "grdclmnLotNumber";
            this.grdclmnLotNumber.Visible = true;
            this.grdclmnLotNumber.VisibleIndex = 5;
            // 
            // grdclmnPWOQuantity
            // 
            this.grdclmnPWOQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPWOQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnPWOQuantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWOQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPWOQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnPWOQuantity.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWOQuantity.Caption = "生产工单数量";
            this.grdclmnPWOQuantity.FieldName = "PWOQuantity";
            this.grdclmnPWOQuantity.Name = "grdclmnPWOQuantity";
            this.grdclmnPWOQuantity.Visible = true;
            this.grdclmnPWOQuantity.VisibleIndex = 6;
            // 
            // grdclmnWIPQuantity
            // 
            this.grdclmnWIPQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnWIPQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnWIPQuantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnWIPQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnWIPQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnWIPQuantity.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnWIPQuantity.Caption = "在制品数量";
            this.grdclmnWIPQuantity.FieldName = "WIPQuantity";
            this.grdclmnWIPQuantity.Name = "grdclmnWIPQuantity";
            this.grdclmnWIPQuantity.Visible = true;
            this.grdclmnWIPQuantity.VisibleIndex = 7;
            // 
            // grdclmnContainerNo
            // 
            this.grdclmnContainerNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnContainerNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnContainerNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnContainerNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnContainerNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnContainerNo.Caption = "在制品容器编号";
            this.grdclmnContainerNo.FieldName = "ContainerNo";
            this.grdclmnContainerNo.Name = "grdclmnContainerNo";
            this.grdclmnContainerNo.Visible = true;
            this.grdclmnContainerNo.VisibleIndex = 8;
            // 
            // grdclmnStationMFGTime
            // 
            this.grdclmnStationMFGTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnStationMFGTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnStationMFGTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStationMFGTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnStationMFGTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnStationMFGTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStationMFGTime.Caption = "工位累计加工时间";
            this.grdclmnStationMFGTime.DisplayFormat.FormatString = "0 min";
            this.grdclmnStationMFGTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnStationMFGTime.FieldName = "StationMFGTime";
            this.grdclmnStationMFGTime.Name = "grdclmnStationMFGTime";
            this.grdclmnStationMFGTime.Visible = true;
            this.grdclmnStationMFGTime.VisibleIndex = 9;
            // 
            // grdclmnThroughPutTime
            // 
            this.grdclmnThroughPutTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnThroughPutTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnThroughPutTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnThroughPutTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnThroughPutTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnThroughPutTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnThroughPutTime.Caption = "工段制程时间";
            this.grdclmnThroughPutTime.DisplayFormat.FormatString = "0 min";
            this.grdclmnThroughPutTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnThroughPutTime.FieldName = "ThroughPutTime";
            this.grdclmnThroughPutTime.Name = "grdclmnThroughPutTime";
            this.grdclmnThroughPutTime.Visible = true;
            this.grdclmnThroughPutTime.VisibleIndex = 10;
            // 
            // grdclmnAccumMCT
            // 
            this.grdclmnAccumMCT.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnAccumMCT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnAccumMCT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnAccumMCT.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnAccumMCT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnAccumMCT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnAccumMCT.Caption = "累计制造周期时间";
            this.grdclmnAccumMCT.DisplayFormat.FormatString = "0 min";
            this.grdclmnAccumMCT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnAccumMCT.FieldName = "AccumMCT";
            this.grdclmnAccumMCT.Name = "grdclmnAccumMCT";
            this.grdclmnAccumMCT.Visible = true;
            this.grdclmnAccumMCT.VisibleIndex = 11;
            // 
            // grdclmnScrapedQuantity
            // 
            this.grdclmnScrapedQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnScrapedQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnScrapedQuantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScrapedQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnScrapedQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnScrapedQuantity.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScrapedQuantity.Caption = "废品数量";
            this.grdclmnScrapedQuantity.FieldName = "ScrapedQuantity";
            this.grdclmnScrapedQuantity.Name = "grdclmnScrapedQuantity";
            this.grdclmnScrapedQuantity.Visible = true;
            this.grdclmnScrapedQuantity.VisibleIndex = 12;
            // 
            // grdclmnFPYPercentage
            // 
            this.grdclmnFPYPercentage.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnFPYPercentage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnFPYPercentage.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnFPYPercentage.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnFPYPercentage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnFPYPercentage.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnFPYPercentage.Caption = "一次性通过率";
            this.grdclmnFPYPercentage.DisplayFormat.FormatString = "0.00 %";
            this.grdclmnFPYPercentage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnFPYPercentage.FieldName = "FPYPercentage";
            this.grdclmnFPYPercentage.Name = "grdclmnFPYPercentage";
            this.grdclmnFPYPercentage.Visible = true;
            this.grdclmnFPYPercentage.VisibleIndex = 13;
            // 
            // grdclmnAtStationCode
            // 
            this.grdclmnAtStationCode.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnAtStationCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnAtStationCode.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnAtStationCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnAtStationCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnAtStationCode.Caption = "滞在工位代码";
            this.grdclmnAtStationCode.FieldName = "AtStationCode";
            this.grdclmnAtStationCode.Name = "grdclmnAtStationCode";
            this.grdclmnAtStationCode.Visible = true;
            this.grdclmnAtStationCode.VisibleIndex = 14;
            // 
            // grdclmnAtStationName
            // 
            this.grdclmnAtStationName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnAtStationName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnAtStationName.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnAtStationName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnAtStationName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnAtStationName.Caption = "滞在工位名称";
            this.grdclmnAtStationName.FieldName = "AtStationName";
            this.grdclmnAtStationName.Name = "grdclmnAtStationName";
            this.grdclmnAtStationName.Visible = true;
            this.grdclmnAtStationName.VisibleIndex = 15;
            // 
            // frmKanbanPWOExec_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 535);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmKanbanPWOExec_30";
            this.Text = "生产工单监控看板";
            this.Shown += new System.EventHandler(this.frmKanbanPWOExec_30_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstT103LeafSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.ListBoxControl lstT103LeafSet;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Views.Card.CardView cardView;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mitmMethodAndQualityStandard;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLotNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWOQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnWIPQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStationMFGTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnThroughPutTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnAccumMCT;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScrapedQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFPYPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnAtStationCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnAtStationName;
    }
}
