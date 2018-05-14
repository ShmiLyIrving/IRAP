namespace IRAP.Client.GUI.SCES
{
    partial class frmMaterialsToDeliver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterialsToDeliver));
            this.grdMaterials = new DevExpress.XtraGrid.GridControl();
            this.grdvMaterials = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.report = new FastReport.Report();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnSpiliteOrderNotify = new DevExpress.XtraEditors.SimpleButton();
            this.btnSpilitePKGNotify = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdOrders = new DevExpress.XtraGrid.GridControl();
            this.grdvOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT134Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT134Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedQuantityString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedCloseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScheduleStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblNoneMaterialInStore = new DevExpress.XtraEditors.LabelControl();
            this.report1 = new FastReport.Report();
            this.btnCapacityModify = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdMaterials
            // 
            this.grdMaterials.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaterials.Location = new System.Drawing.Point(2, 27);
            this.grdMaterials.MainView = this.grdvMaterials;
            this.grdMaterials.Name = "grdMaterials";
            this.grdMaterials.Size = new System.Drawing.Size(972, 349);
            this.grdMaterials.TabIndex = 0;
            this.grdMaterials.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvMaterials});
            // 
            // grdvMaterials
            // 
            this.grdvMaterials.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvMaterials.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvMaterials.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvMaterials.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvMaterials.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvMaterials.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvMaterials.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvMaterials.Appearance.Row.Options.UseFont = true;
            this.grdvMaterials.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.grdvMaterials.GridControl = this.grdMaterials;
            this.grdvMaterials.Name = "grdvMaterials";
            this.grdvMaterials.OptionsBehavior.Editable = false;
            this.grdvMaterials.OptionsCustomization.AllowFilter = false;
            this.grdvMaterials.OptionsCustomization.AllowSort = false;
            this.grdvMaterials.OptionsMenu.EnableColumnMenu = false;
            this.grdvMaterials.OptionsView.ColumnAutoWidth = false;
            this.grdvMaterials.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "库位代码";
            this.gridColumn1.FieldName = "AtStoreLocCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "物料代码";
            this.gridColumn2.FieldName = "MaterialCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "物料名称";
            this.gridColumn3.FieldName = "MaterialDesc";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "批次号";
            this.gridColumn4.FieldName = "LotNumber";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.Caption = "生产日期";
            this.gridColumn5.FieldName = "MFGDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.Caption = "物料属性";
            this.gridColumn6.FieldName = "T131Code";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn7.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "需求数量";
            this.gridColumn7.FieldName = "SuggestedQuantityToPick";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn8.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.Caption = "库存数量";
            this.gridColumn8.FieldName = "QuantityInStore";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn9.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.Caption = "配送数量";
            this.gridColumn9.FieldName = "ActualQuantityToDeliver";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn10.AppearanceCell.Options.UseFont = true;
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn10.Caption = "备注";
            this.gridColumn10.FieldName = "ActualQtyDecompose";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(897, 517);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // report
            // 
            this.report.ReportResourceString = resources.GetString("report.ReportResourceString");
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(577, 517);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 33);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "打印配料单";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSpiliteOrderNotify
            // 
            this.btnSpiliteOrderNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpiliteOrderNotify.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpiliteOrderNotify.Appearance.Options.UseFont = true;
            this.btnSpiliteOrderNotify.Location = new System.Drawing.Point(674, 517);
            this.btnSpiliteOrderNotify.Name = "btnSpiliteOrderNotify";
            this.btnSpiliteOrderNotify.Size = new System.Drawing.Size(91, 33);
            this.btnSpiliteOrderNotify.TabIndex = 3;
            this.btnSpiliteOrderNotify.Text = "通知计划员";
            this.btnSpiliteOrderNotify.Visible = false;
            this.btnSpiliteOrderNotify.Click += new System.EventHandler(this.btnSpiliteOrderNotify_Click);
            // 
            // btnSpilitePKGNotify
            // 
            this.btnSpilitePKGNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpilitePKGNotify.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpilitePKGNotify.Appearance.Options.UseFont = true;
            this.btnSpilitePKGNotify.Location = new System.Drawing.Point(771, 517);
            this.btnSpilitePKGNotify.Name = "btnSpilitePKGNotify";
            this.btnSpilitePKGNotify.Size = new System.Drawing.Size(91, 33);
            this.btnSpilitePKGNotify.TabIndex = 4;
            this.btnSpilitePKGNotify.Text = "通知包装拆分";
            this.btnSpilitePKGNotify.Visible = false;
            this.btnSpilitePKGNotify.Click += new System.EventHandler(this.btnSpilitePKGNotify_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdOrders);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(976, 105);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "生产工单信息";
            // 
            // grdOrders
            // 
            this.grdOrders.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrders.Location = new System.Drawing.Point(2, 27);
            this.grdOrders.MainView = this.grdvOrders;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.Size = new System.Drawing.Size(972, 76);
            this.grdOrders.TabIndex = 2;
            this.grdOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOrders});
            // 
            // grdvOrders
            // 
            this.grdvOrders.Appearance.Preview.ForeColor = System.Drawing.Color.Blue;
            this.grdvOrders.Appearance.Preview.Options.UseForeColor = true;
            this.grdvOrders.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            this.grdvOrders.Appearance.Row.Options.UseForeColor = true;
            this.grdvOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnPWONo,
            this.grdclmnMONumber,
            this.grdclmnMOLineNo,
            this.grdclmnProductNo,
            this.grdclmnProductDescription,
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
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnPWONo.AppearanceCell.Options.UseFont = true;
            this.grdclmnPWONo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnPWONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWONo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPWONo.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
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
            this.grdclmnMONumber.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnMONumber.AppearanceCell.Options.UseFont = true;
            this.grdclmnMONumber.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMONumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnMONumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONumber.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMONumber.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
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
            this.grdclmnMOLineNo.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnMOLineNo.AppearanceCell.Options.UseFont = true;
            this.grdclmnMOLineNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
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
            this.grdclmnProductNo.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnProductNo.AppearanceCell.Options.UseFont = true;
            this.grdclmnProductNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
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
            this.grdclmnProductDescription.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnProductDescription.AppearanceCell.Options.UseFont = true;
            this.grdclmnProductDescription.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnProductDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductDescription.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
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
            this.grdclmnProductDescription.VisibleIndex = 5;
            // 
            // grdclmnT134Code
            // 
            this.grdclmnT134Code.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnT134Code.AppearanceCell.Options.UseFont = true;
            this.grdclmnT134Code.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT134Code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnT134Code.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT134Code.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
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
            this.grdclmnT134Code.VisibleIndex = 6;
            // 
            // grdclmnT134Name
            // 
            this.grdclmnT134Name.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnT134Name.AppearanceCell.Options.UseFont = true;
            this.grdclmnT134Name.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT134Name.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT134Name.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
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
            this.grdclmnT134Name.VisibleIndex = 7;
            // 
            // grdclmnPlannedQuantityString
            // 
            this.grdclmnPlannedQuantityString.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnPlannedQuantityString.AppearanceCell.Options.UseFont = true;
            this.grdclmnPlannedQuantityString.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedQuantityString.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnPlannedQuantityString.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedQuantityString.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdclmnPlannedQuantityString.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPlannedQuantityString.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedQuantityString.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedQuantityString.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedQuantityString.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedQuantityString.Caption = "排产数量";
            this.grdclmnPlannedQuantityString.FieldName = "PlannedQuantityString";
            this.grdclmnPlannedQuantityString.Name = "grdclmnPlannedQuantityString";
            this.grdclmnPlannedQuantityString.OptionsColumn.ReadOnly = true;
            // 
            // grdclmnPlannedStartDate
            // 
            this.grdclmnPlannedStartDate.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnPlannedStartDate.AppearanceCell.Options.UseFont = true;
            this.grdclmnPlannedStartDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedStartDate.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdclmnPlannedStartDate.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPlannedStartDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedStartDate.Caption = "计划开工日期";
            this.grdclmnPlannedStartDate.FieldName = "PlannedStartDate";
            this.grdclmnPlannedStartDate.Name = "grdclmnPlannedStartDate";
            this.grdclmnPlannedStartDate.Width = 82;
            // 
            // grdclmnPlannedCloseDate
            // 
            this.grdclmnPlannedCloseDate.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnPlannedCloseDate.AppearanceCell.Options.UseFont = true;
            this.grdclmnPlannedCloseDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedCloseDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdclmnPlannedCloseDate.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPlannedCloseDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedCloseDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedCloseDate.Caption = "计划完工日期";
            this.grdclmnPlannedCloseDate.FieldName = "PlannedCloseDate";
            this.grdclmnPlannedCloseDate.Name = "grdclmnPlannedCloseDate";
            this.grdclmnPlannedCloseDate.OptionsColumn.ReadOnly = true;
            this.grdclmnPlannedCloseDate.Width = 82;
            // 
            // grdclmnScheduleStartTime
            // 
            this.grdclmnScheduleStartTime.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnScheduleStartTime.AppearanceCell.Options.UseFont = true;
            this.grdclmnScheduleStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnScheduleStartTime.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F);
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
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.lblNoneMaterialInStore);
            this.groupControl2.Controls.Add(this.grdMaterials);
            this.groupControl2.Location = new System.Drawing.Point(12, 123);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(976, 378);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "所需物料配送清单";
            // 
            // lblNoneMaterialInStore
            // 
            this.lblNoneMaterialInStore.Appearance.BackColor = System.Drawing.Color.White;
            this.lblNoneMaterialInStore.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoneMaterialInStore.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblNoneMaterialInStore.Location = new System.Drawing.Point(355, 181);
            this.lblNoneMaterialInStore.Name = "lblNoneMaterialInStore";
            this.lblNoneMaterialInStore.Size = new System.Drawing.Size(247, 25);
            this.lblNoneMaterialInStore.TabIndex = 1;
            this.lblNoneMaterialInStore.Text = "当前工单所需的物料无库存！";
            this.lblNoneMaterialInStore.Visible = false;
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // btnCapacityModify
            // 
            this.btnCapacityModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapacityModify.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapacityModify.Appearance.Options.UseFont = true;
            this.btnCapacityModify.Location = new System.Drawing.Point(14, 517);
            this.btnCapacityModify.Name = "btnCapacityModify";
            this.btnCapacityModify.Size = new System.Drawing.Size(119, 33);
            this.btnCapacityModify.TabIndex = 7;
            this.btnCapacityModify.TabStop = false;
            this.btnCapacityModify.Text = "容器容量修改";
            this.btnCapacityModify.Visible = false;
            this.btnCapacityModify.Click += new System.EventHandler(this.btnCapacityModify_Click);
            // 
            // frmMaterialsToDeliver
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.btnCapacityModify);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnSpilitePKGNotify);
            this.Controls.Add(this.btnSpiliteOrderNotify);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "frmMaterialsToDeliver";
            this.Text = "物料配送";
            this.Shown += new System.EventHandler(this.frmMaterialToDeliverPreview_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMaterials;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvMaterials;
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
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private FastReport.Report report;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnSpiliteOrderNotify;
        private DevExpress.XtraEditors.SimpleButton btnSpilitePKGNotify;
        private DevExpress.XtraEditors.GroupControl groupControl1;
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
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlannedStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlannedCloseDate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScheduleStartTime;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl lblNoneMaterialInStore;
        private FastReport.Report report1;
        private DevExpress.XtraEditors.SimpleButton btnCapacityModify;
    }
}
