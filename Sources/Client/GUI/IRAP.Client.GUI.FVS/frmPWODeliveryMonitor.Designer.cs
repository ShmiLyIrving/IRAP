namespace IRAP.Client.GUI.FVS
{
    partial class frmPWODeliveryMonitor
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.grdclmActualArrivalTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.pnlRemark = new DevExpress.XtraEditors.PanelControl();
            this.lblStatusNormal = new DevExpress.XtraEditors.LabelControl();
            this.lblStatusSlower = new DevExpress.XtraEditors.LabelControl();
            this.lblStatusSlowest = new DevExpress.XtraEditors.LabelControl();
            this.timer = new System.Windows.Forms.Timer();
            this.tmrPage = new System.Windows.Forms.Timer();
            this.grdMODelivery = new DevExpress.XtraGrid.GridControl();
            this.grdvMODelivery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmScheduledStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmRequiredArrivalTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmResidueMinutes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmDLVProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmMaterialQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmBackgroundColor = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRemark)).BeginInit();
            this.pnlRemark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMODelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMODelivery)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "物料配送跟踪看板";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdclmActualArrivalTime
            // 
            this.grdclmActualArrivalTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmActualArrivalTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmActualArrivalTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmActualArrivalTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmActualArrivalTime.Caption = "实际送达时间";
            this.grdclmActualArrivalTime.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmActualArrivalTime.FieldName = "ActualArrivalTime";
            this.grdclmActualArrivalTime.MaxWidth = 120;
            this.grdclmActualArrivalTime.MinWidth = 120;
            this.grdclmActualArrivalTime.Name = "grdclmActualArrivalTime";
            this.grdclmActualArrivalTime.Visible = true;
            this.grdclmActualArrivalTime.VisibleIndex = 7;
            this.grdclmActualArrivalTime.Width = 120;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Appearance.Options.UseBackColor = true;
            this.pnlBottom.Controls.Add(this.pnlRemark);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 449);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(891, 46);
            this.pnlBottom.TabIndex = 1;
            // 
            // pnlRemark
            // 
            this.pnlRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlRemark.Controls.Add(this.lblStatusNormal);
            this.pnlRemark.Controls.Add(this.lblStatusSlower);
            this.pnlRemark.Controls.Add(this.lblStatusSlowest);
            this.pnlRemark.Location = new System.Drawing.Point(156, 5);
            this.pnlRemark.Name = "pnlRemark";
            this.pnlRemark.Size = new System.Drawing.Size(320, 35);
            this.pnlRemark.TabIndex = 2;
            // 
            // lblStatusNormal
            // 
            this.lblStatusNormal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusNormal.Appearance.BackColor = System.Drawing.Color.Green;
            this.lblStatusNormal.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusNormal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatusNormal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStatusNormal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatusNormal.Location = new System.Drawing.Point(10, 6);
            this.lblStatusNormal.Name = "lblStatusNormal";
            this.lblStatusNormal.Size = new System.Drawing.Size(96, 25);
            this.lblStatusNormal.TabIndex = 2;
            this.lblStatusNormal.Text = "正常";
            // 
            // lblStatusSlower
            // 
            this.lblStatusSlower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusSlower.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblStatusSlower.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusSlower.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatusSlower.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStatusSlower.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatusSlower.Location = new System.Drawing.Point(112, 6);
            this.lblStatusSlower.Name = "lblStatusSlower";
            this.lblStatusSlower.Size = new System.Drawing.Size(96, 25);
            this.lblStatusSlower.TabIndex = 1;
            this.lblStatusSlower.Text = "偏慢";
            // 
            // lblStatusSlowest
            // 
            this.lblStatusSlowest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusSlowest.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblStatusSlowest.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusSlowest.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatusSlowest.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStatusSlowest.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatusSlowest.Location = new System.Drawing.Point(214, 6);
            this.lblStatusSlowest.Name = "lblStatusSlowest";
            this.lblStatusSlowest.Size = new System.Drawing.Size(96, 25);
            this.lblStatusSlowest.TabIndex = 0;
            this.lblStatusSlowest.Text = "过慢";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tmrPage
            // 
            this.tmrPage.Interval = 1000;
            this.tmrPage.Tick += new System.EventHandler(this.tmrPage_Tick);
            // 
            // grdMODelivery
            // 
            this.grdMODelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMODelivery.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.grdMODelivery.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grdMODelivery.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grdMODelivery.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grdMODelivery.EmbeddedNavigator.Buttons.First.Enabled = false;
            this.grdMODelivery.EmbeddedNavigator.Buttons.Last.Enabled = false;
            this.grdMODelivery.EmbeddedNavigator.Buttons.Next.Enabled = false;
            this.grdMODelivery.EmbeddedNavigator.Buttons.Prev.Enabled = false;
            this.grdMODelivery.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grdMODelivery.Location = new System.Drawing.Point(0, 56);
            this.grdMODelivery.MainView = this.grdvMODelivery;
            this.grdMODelivery.Name = "grdMODelivery";
            this.grdMODelivery.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdMODelivery.Size = new System.Drawing.Size(891, 393);
            this.grdMODelivery.TabIndex = 2;
            this.grdMODelivery.TabStop = false;
            this.grdMODelivery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvMODelivery});
            // 
            // grdvMODelivery
            // 
            this.grdvMODelivery.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvMODelivery.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Green;
            this.grdvMODelivery.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvMODelivery.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grdvMODelivery.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvMODelivery.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvMODelivery.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvMODelivery.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvMODelivery.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvMODelivery.Appearance.Row.Options.UseFont = true;
            this.grdvMODelivery.Appearance.Row.Options.UseTextOptions = true;
            this.grdvMODelivery.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvMODelivery.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvMODelivery.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnPWONo,
            this.grdclmnMONumber,
            this.grdclmnMOLineNo,
            this.grdclmProductNo,
            this.grdclmProductName,
            this.grdclmScheduledStartTime,
            this.grdclmRequiredArrivalTime,
            this.grdclmActualArrivalTime,
            this.grdclmResidueMinutes,
            this.grdclmDLVProgress,
            this.grdclmContainerNo,
            this.grdclmMaterialQty,
            this.grdclmBackgroundColor});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.grdclmActualArrivalTime;
            gridFormatRule1.Name = "UnStopped";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Blue;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = "未停产";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.grdclmActualArrivalTime;
            gridFormatRule2.Name = "Stopped";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = "已停产";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.grdvMODelivery.FormatRules.Add(gridFormatRule1);
            this.grdvMODelivery.FormatRules.Add(gridFormatRule2);
            this.grdvMODelivery.GridControl = this.grdMODelivery;
            this.grdvMODelivery.Name = "grdvMODelivery";
            this.grdvMODelivery.OptionsBehavior.Editable = false;
            this.grdvMODelivery.OptionsCustomization.AllowFilter = false;
            this.grdvMODelivery.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvMODelivery.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grdvMODelivery.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvMODelivery.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvMODelivery.OptionsView.EnableAppearanceOddRow = true;
            this.grdvMODelivery.OptionsView.RowAutoHeight = true;
            this.grdvMODelivery.OptionsView.ShowGroupPanel = false;
            this.grdvMODelivery.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdvMODelivery_CustomDrawCell);
            this.grdvMODelivery.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grdvMODelivery_CustomColumnDisplayText);
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.Caption = "序号";
            this.grdclmnOrdinal.FieldName = "Ordinal";
            this.grdclmnOrdinal.MinWidth = 45;
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Width = 49;
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnPWONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWONo.Caption = "生产工单号";
            this.grdclmnPWONo.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnPWONo.FieldName = "PWONo";
            this.grdclmnPWONo.MinWidth = 160;
            this.grdclmnPWONo.Name = "grdclmnPWONo";
            this.grdclmnPWONo.Visible = true;
            this.grdclmnPWONo.VisibleIndex = 0;
            this.grdclmnPWONo.Width = 160;
            // 
            // grdclmnMONumber
            // 
            this.grdclmnMONumber.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMONumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONumber.Caption = "订单号";
            this.grdclmnMONumber.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnMONumber.FieldName = "MONumber";
            this.grdclmnMONumber.MinWidth = 73;
            this.grdclmnMONumber.Name = "grdclmnMONumber";
            this.grdclmnMONumber.Visible = true;
            this.grdclmnMONumber.VisibleIndex = 1;
            this.grdclmnMONumber.Width = 73;
            // 
            // grdclmnMOLineNo
            // 
            this.grdclmnMOLineNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMOLineNo.Caption = "行号";
            this.grdclmnMOLineNo.FieldName = "MOLineNo";
            this.grdclmnMOLineNo.MaxWidth = 45;
            this.grdclmnMOLineNo.MinWidth = 45;
            this.grdclmnMOLineNo.Name = "grdclmnMOLineNo";
            this.grdclmnMOLineNo.Visible = true;
            this.grdclmnMOLineNo.VisibleIndex = 2;
            this.grdclmnMOLineNo.Width = 45;
            // 
            // grdclmProductNo
            // 
            this.grdclmProductNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmProductNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmProductNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmProductNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmProductNo.Caption = "产品编号";
            this.grdclmProductNo.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmProductNo.FieldName = "ProductNo";
            this.grdclmProductNo.MaxWidth = 180;
            this.grdclmProductNo.MinWidth = 180;
            this.grdclmProductNo.Name = "grdclmProductNo";
            this.grdclmProductNo.Visible = true;
            this.grdclmProductNo.VisibleIndex = 3;
            this.grdclmProductNo.Width = 180;
            // 
            // grdclmProductName
            // 
            this.grdclmProductName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmProductName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmProductName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmProductName.Caption = "产品名称";
            this.grdclmProductName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmProductName.FieldName = "ProductName";
            this.grdclmProductName.MinWidth = 45;
            this.grdclmProductName.Name = "grdclmProductName";
            this.grdclmProductName.Visible = true;
            this.grdclmProductName.VisibleIndex = 4;
            this.grdclmProductName.Width = 65;
            // 
            // grdclmScheduledStartTime
            // 
            this.grdclmScheduledStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmScheduledStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmScheduledStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmScheduledStartTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmScheduledStartTime.Caption = "排定生产时间";
            this.grdclmScheduledStartTime.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmScheduledStartTime.FieldName = "ScheduledStartTime";
            this.grdclmScheduledStartTime.MaxWidth = 120;
            this.grdclmScheduledStartTime.MinWidth = 120;
            this.grdclmScheduledStartTime.Name = "grdclmScheduledStartTime";
            this.grdclmScheduledStartTime.Visible = true;
            this.grdclmScheduledStartTime.VisibleIndex = 5;
            this.grdclmScheduledStartTime.Width = 120;
            // 
            // grdclmRequiredArrivalTime
            // 
            this.grdclmRequiredArrivalTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmRequiredArrivalTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmRequiredArrivalTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmRequiredArrivalTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmRequiredArrivalTime.Caption = "要求送达时间";
            this.grdclmRequiredArrivalTime.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmRequiredArrivalTime.FieldName = "RequiredArrivalTime";
            this.grdclmRequiredArrivalTime.MaxWidth = 100;
            this.grdclmRequiredArrivalTime.MinWidth = 100;
            this.grdclmRequiredArrivalTime.Name = "grdclmRequiredArrivalTime";
            this.grdclmRequiredArrivalTime.Visible = true;
            this.grdclmRequiredArrivalTime.VisibleIndex = 6;
            this.grdclmRequiredArrivalTime.Width = 100;
            // 
            // grdclmResidueMinutes
            // 
            this.grdclmResidueMinutes.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmResidueMinutes.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmResidueMinutes.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.grdclmResidueMinutes.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmResidueMinutes.Caption = "剩余分钟数";
            this.grdclmResidueMinutes.FieldName = "ResidueMinutes";
            this.grdclmResidueMinutes.MaxWidth = 120;
            this.grdclmResidueMinutes.MinWidth = 120;
            this.grdclmResidueMinutes.Name = "grdclmResidueMinutes";
            this.grdclmResidueMinutes.Visible = true;
            this.grdclmResidueMinutes.VisibleIndex = 8;
            this.grdclmResidueMinutes.Width = 120;
            // 
            // grdclmDLVProgress
            // 
            this.grdclmDLVProgress.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmDLVProgress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmDLVProgress.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmDLVProgress.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmDLVProgress.Caption = "配送进度状态";
            this.grdclmDLVProgress.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmDLVProgress.FieldName = "DLVProgress";
            this.grdclmDLVProgress.MaxWidth = 120;
            this.grdclmDLVProgress.MinWidth = 120;
            this.grdclmDLVProgress.Name = "grdclmDLVProgress";
            this.grdclmDLVProgress.Visible = true;
            this.grdclmDLVProgress.VisibleIndex = 9;
            this.grdclmDLVProgress.Width = 120;
            // 
            // grdclmContainerNo
            // 
            this.grdclmContainerNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmContainerNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmContainerNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmContainerNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmContainerNo.Caption = "容器编号";
            this.grdclmContainerNo.FieldName = "ContainerNo";
            this.grdclmContainerNo.MaxWidth = 60;
            this.grdclmContainerNo.MinWidth = 45;
            this.grdclmContainerNo.Name = "grdclmContainerNo";
            this.grdclmContainerNo.Width = 60;
            // 
            // grdclmMaterialQty
            // 
            this.grdclmMaterialQty.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmMaterialQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmMaterialQty.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.grdclmMaterialQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmMaterialQty.Caption = "配送数量";
            this.grdclmMaterialQty.FieldName = "MaterialQty";
            this.grdclmMaterialQty.Name = "grdclmMaterialQty";
            this.grdclmMaterialQty.Width = 65;
            // 
            // grdclmBackgroundColor
            // 
            this.grdclmBackgroundColor.Caption = "gridColumn17";
            this.grdclmBackgroundColor.Name = "grdclmBackgroundColor";
            this.grdclmBackgroundColor.Width = 95;
            // 
            // frmPWODeliveryMonitor
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.grdMODelivery);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmPWODeliveryMonitor";
            this.Text = "物料配送跟踪看板";
            this.Activated += new System.EventHandler(this.frmPWODeliveryMonitor_Activated);
            this.Load += new System.EventHandler(this.frmPWODeliveryMonitor_Load);
            this.Shown += new System.EventHandler(this.frmPWODeliveryMonitor_Shown);
            this.Resize += new System.EventHandler(this.frmPWODeliveryMonitor_Resize);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.grdMODelivery, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlRemark)).EndInit();
            this.pnlRemark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMODelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMODelivery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.PanelControl pnlRemark;
        private DevExpress.XtraEditors.LabelControl lblStatusNormal;
        private DevExpress.XtraEditors.LabelControl lblStatusSlower;
        private DevExpress.XtraEditors.LabelControl lblStatusSlowest;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer tmrPage;
        private DevExpress.XtraGrid.GridControl grdMODelivery;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvMODelivery;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmRequiredArrivalTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmActualArrivalTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmScheduledStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmResidueMinutes;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmDLVProgress;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmMaterialQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmBackgroundColor;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
    }
}
