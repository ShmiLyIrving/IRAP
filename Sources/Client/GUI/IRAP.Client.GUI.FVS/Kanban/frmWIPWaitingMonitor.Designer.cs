namespace IRAP.Client.GUI.FVS
{
    partial class frmWIPWaitingMonitor
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue4 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.pnlRemark = new DevExpress.XtraEditors.PanelControl();
            this.lblStatusNormal = new DevExpress.XtraEditors.LabelControl();
            this.lblStatusSlower = new DevExpress.XtraEditors.LabelControl();
            this.lblStatusSlowest = new DevExpress.XtraEditors.LabelControl();
            this.grdMODelivery = new DevExpress.XtraGrid.GridControl();
            this.grdvMODelivery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grdclmnMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmMinutesWaited = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmDLVProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmWIPQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmT216Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmBackgroundColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer = new System.Windows.Forms.Timer();
            this.tmrPage = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRemark)).BeginInit();
            this.pnlRemark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMODelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMODelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "在制品停滞监控看板";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
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
            this.pnlBottom.TabIndex = 2;
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
            this.lblStatusNormal.Appearance.ForeColor = System.Drawing.Color.White;
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
            this.lblStatusSlower.Text = "偏长";
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
            this.lblStatusSlowest.Text = "过长";
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
            this.grdMODelivery.TabIndex = 3;
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
            this.grdclmMinutesWaited,
            this.grdclmDLVProgress,
            this.grdclmContainerNo,
            this.grdclmWIPQty,
            this.grdclmT216Name,
            this.grdclmBackgroundColor});
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Name = "UnStopped";
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Blue;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = "未停产";
            gridFormatRule3.Rule = formatConditionRuleValue3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Name = "Stopped";
            formatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue4.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue4.Value1 = "已停产";
            gridFormatRule4.Rule = formatConditionRuleValue4;
            this.grdvMODelivery.FormatRules.Add(gridFormatRule3);
            this.grdvMODelivery.FormatRules.Add(gridFormatRule4);
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
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
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
            this.grdclmnPWONo.VisibleIndex = 1;
            this.grdclmnPWONo.Width = 160;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
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
            this.grdclmnMONumber.VisibleIndex = 2;
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
            this.grdclmnMOLineNo.VisibleIndex = 3;
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
            this.grdclmProductNo.VisibleIndex = 4;
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
            this.grdclmProductName.Width = 65;
            // 
            // grdclmMinutesWaited
            // 
            this.grdclmMinutesWaited.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmMinutesWaited.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmMinutesWaited.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmMinutesWaited.Caption = "等待浪费时间";
            this.grdclmMinutesWaited.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmMinutesWaited.DisplayFormat.FormatString = "######### 分钟";
            this.grdclmMinutesWaited.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmMinutesWaited.FieldName = "MinutesWaited";
            this.grdclmMinutesWaited.Name = "grdclmMinutesWaited";
            this.grdclmMinutesWaited.Visible = true;
            this.grdclmMinutesWaited.VisibleIndex = 5;
            this.grdclmMinutesWaited.Width = 120;
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
            this.grdclmDLVProgress.Name = "grdclmDLVProgress";
            this.grdclmDLVProgress.Visible = true;
            this.grdclmDLVProgress.VisibleIndex = 6;
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
            this.grdclmContainerNo.Visible = true;
            this.grdclmContainerNo.VisibleIndex = 7;
            this.grdclmContainerNo.Width = 60;
            // 
            // grdclmWIPQty
            // 
            this.grdclmWIPQty.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmWIPQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmWIPQty.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.grdclmWIPQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmWIPQty.Caption = "在制品数量";
            this.grdclmWIPQty.FieldName = "WIPQty";
            this.grdclmWIPQty.Name = "grdclmWIPQty";
            this.grdclmWIPQty.Visible = true;
            this.grdclmWIPQty.VisibleIndex = 8;
            this.grdclmWIPQty.Width = 65;
            // 
            // grdclmT216Name
            // 
            this.grdclmT216Name.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmT216Name.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmT216Name.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmT216Name.Caption = "滞在工序";
            this.grdclmT216Name.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmT216Name.FieldName = "T216Name";
            this.grdclmT216Name.Name = "grdclmT216Name";
            this.grdclmT216Name.Visible = true;
            this.grdclmT216Name.VisibleIndex = 9;
            this.grdclmT216Name.Width = 100;
            // 
            // grdclmBackgroundColor
            // 
            this.grdclmBackgroundColor.Caption = "BackgroundColor";
            this.grdclmBackgroundColor.Name = "grdclmBackgroundColor";
            this.grdclmBackgroundColor.Width = 95;
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
            // frmWIPWaitingMonitor
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.grdMODelivery);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmWIPWaitingMonitor";
            this.Text = "在制品停滞监控看板";
            this.Activated += new System.EventHandler(this.frmWIPWaitingMonitor_Activated);
            this.Load += new System.EventHandler(this.frmWIPWaitingMonitor_Load);
            this.Shown += new System.EventHandler(this.frmWIPWaitingMonitor_Shown);
            this.Resize += new System.EventHandler(this.frmWIPWaitingMonitor_Resize);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.grdMODelivery, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlRemark)).EndInit();
            this.pnlRemark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMODelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMODelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.PanelControl pnlRemark;
        private DevExpress.XtraEditors.LabelControl lblStatusNormal;
        private DevExpress.XtraEditors.LabelControl lblStatusSlower;
        private DevExpress.XtraEditors.LabelControl lblStatusSlowest;
        private DevExpress.XtraGrid.GridControl grdMODelivery;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvMODelivery;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmMinutesWaited;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmT216Name;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmDLVProgress;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmWIPQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmBackgroundColor;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer tmrPage;
    }
}
