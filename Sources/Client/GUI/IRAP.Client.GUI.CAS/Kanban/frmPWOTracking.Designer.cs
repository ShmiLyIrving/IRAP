namespace IRAP.Client.GUI.CAS
{
    partial class frmPWOTracking
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.grdclmProductionStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdMOTracks = new DevExpress.XtraGrid.GridControl();
            this.grdvMOTracks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmMaterialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmPlannedStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmPlannedCloseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmScheduledStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmActualStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmPWOProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmOperationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmMaterialQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmWIPQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmScrapRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmBackgroundColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlRemark = new DevExpress.XtraEditors.PanelControl();
            this.lblStatus6 = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus5 = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus4 = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus3 = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus2 = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.tmrPage = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMOTracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMOTracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRemark)).BeginInit();
            this.pnlRemark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(1137, 56);
            this.lblFuncName.Text = "生产工单跟踪看板";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(1137, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdclmProductionStatus
            // 
            this.grdclmProductionStatus.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmProductionStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmProductionStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmProductionStatus.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmProductionStatus.Caption = "要求完工时间";
            this.grdclmProductionStatus.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmProductionStatus.FieldName = "ScheduledCloseTime";
            this.grdclmProductionStatus.MaxWidth = 120;
            this.grdclmProductionStatus.MinWidth = 120;
            this.grdclmProductionStatus.Name = "grdclmProductionStatus";
            this.grdclmProductionStatus.Visible = true;
            this.grdclmProductionStatus.VisibleIndex = 8;
            this.grdclmProductionStatus.Width = 120;
            // 
            // grdMOTracks
            // 
            this.grdMOTracks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMOTracks.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.grdMOTracks.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grdMOTracks.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grdMOTracks.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grdMOTracks.EmbeddedNavigator.Buttons.First.Enabled = false;
            this.grdMOTracks.EmbeddedNavigator.Buttons.Last.Enabled = false;
            this.grdMOTracks.EmbeddedNavigator.Buttons.Next.Enabled = false;
            this.grdMOTracks.EmbeddedNavigator.Buttons.Prev.Enabled = false;
            this.grdMOTracks.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grdMOTracks.Location = new System.Drawing.Point(0, 56);
            this.grdMOTracks.MainView = this.grdvMOTracks;
            this.grdMOTracks.Name = "grdMOTracks";
            this.grdMOTracks.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdMOTracks.Size = new System.Drawing.Size(1137, 367);
            this.grdMOTracks.TabIndex = 1;
            this.grdMOTracks.TabStop = false;
            this.grdMOTracks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvMOTracks});
            // 
            // grdvMOTracks
            // 
            this.grdvMOTracks.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvMOTracks.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Green;
            this.grdvMOTracks.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvMOTracks.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grdvMOTracks.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvMOTracks.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvMOTracks.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvMOTracks.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvMOTracks.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvMOTracks.Appearance.Row.Options.UseFont = true;
            this.grdvMOTracks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnMONumber,
            this.grdclmnMOLineNo,
            this.grdclmMaterialCode,
            this.grdclmMaterialName,
            this.grdclmPlannedStartDate,
            this.grdclmPlannedCloseDate,
            this.grdclmScheduledStartTime,
            this.grdclmActualStartTime,
            this.grdclmProductionStatus,
            this.grdclmPWOProgress,
            this.grdclmOperationName,
            this.grdclmOrderQty,
            this.grdclmMaterialQty,
            this.grdclmWIPQty,
            this.grdclmScrapRate,
            this.grdclmBackgroundColor});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.grdclmProductionStatus;
            gridFormatRule1.Name = "UnStopped";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Blue;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = "未停产";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.grdclmProductionStatus;
            gridFormatRule2.Name = "Stopped";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = "已停产";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.grdvMOTracks.FormatRules.Add(gridFormatRule1);
            this.grdvMOTracks.FormatRules.Add(gridFormatRule2);
            this.grdvMOTracks.GridControl = this.grdMOTracks;
            this.grdvMOTracks.Name = "grdvMOTracks";
            this.grdvMOTracks.OptionsBehavior.Editable = false;
            this.grdvMOTracks.OptionsCustomization.AllowFilter = false;
            this.grdvMOTracks.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvMOTracks.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grdvMOTracks.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvMOTracks.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvMOTracks.OptionsView.EnableAppearanceOddRow = true;
            this.grdvMOTracks.OptionsView.RowAutoHeight = true;
            this.grdvMOTracks.OptionsView.ShowGroupPanel = false;
            this.grdvMOTracks.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdvMOTracks_CustomDrawCell);
            this.grdvMOTracks.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grdvMOTracks_CustomColumnDisplayText);
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
            // grdclmnMONumber
            // 
            this.grdclmnMONumber.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMONumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMONumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONumber.Caption = "订单号";
            this.grdclmnMONumber.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnMONumber.FieldName = "MONumber";
            this.grdclmnMONumber.MinWidth = 73;
            this.grdclmnMONumber.Name = "grdclmnMONumber";
            this.grdclmnMONumber.Visible = true;
            this.grdclmnMONumber.VisibleIndex = 0;
            this.grdclmnMONumber.Width = 73;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
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
            this.grdclmnMOLineNo.VisibleIndex = 1;
            this.grdclmnMOLineNo.Width = 45;
            // 
            // grdclmMaterialCode
            // 
            this.grdclmMaterialCode.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmMaterialCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmMaterialCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmMaterialCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmMaterialCode.Caption = "物料号";
            this.grdclmMaterialCode.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmMaterialCode.FieldName = "ProductNo";
            this.grdclmMaterialCode.MaxWidth = 180;
            this.grdclmMaterialCode.MinWidth = 180;
            this.grdclmMaterialCode.Name = "grdclmMaterialCode";
            this.grdclmMaterialCode.Visible = true;
            this.grdclmMaterialCode.VisibleIndex = 2;
            this.grdclmMaterialCode.Width = 180;
            // 
            // grdclmMaterialName
            // 
            this.grdclmMaterialName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmMaterialName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmMaterialName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmMaterialName.Caption = "产品名称";
            this.grdclmMaterialName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmMaterialName.FieldName = "ProductName";
            this.grdclmMaterialName.MinWidth = 45;
            this.grdclmMaterialName.Name = "grdclmMaterialName";
            this.grdclmMaterialName.Visible = true;
            this.grdclmMaterialName.VisibleIndex = 3;
            this.grdclmMaterialName.Width = 65;
            // 
            // grdclmPlannedStartDate
            // 
            this.grdclmPlannedStartDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmPlannedStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmPlannedStartDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmPlannedStartDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmPlannedStartDate.Caption = "计划开工日期";
            this.grdclmPlannedStartDate.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmPlannedStartDate.FieldName = "PlannedStartDate";
            this.grdclmPlannedStartDate.MaxWidth = 100;
            this.grdclmPlannedStartDate.MinWidth = 100;
            this.grdclmPlannedStartDate.Name = "grdclmPlannedStartDate";
            this.grdclmPlannedStartDate.Visible = true;
            this.grdclmPlannedStartDate.VisibleIndex = 4;
            this.grdclmPlannedStartDate.Width = 100;
            // 
            // grdclmPlannedCloseDate
            // 
            this.grdclmPlannedCloseDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmPlannedCloseDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmPlannedCloseDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmPlannedCloseDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmPlannedCloseDate.Caption = "计划完工日期";
            this.grdclmPlannedCloseDate.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmPlannedCloseDate.FieldName = "PlannedCloseDate";
            this.grdclmPlannedCloseDate.MaxWidth = 120;
            this.grdclmPlannedCloseDate.MinWidth = 120;
            this.grdclmPlannedCloseDate.Name = "grdclmPlannedCloseDate";
            this.grdclmPlannedCloseDate.Visible = true;
            this.grdclmPlannedCloseDate.VisibleIndex = 5;
            this.grdclmPlannedCloseDate.Width = 120;
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
            this.grdclmScheduledStartTime.VisibleIndex = 6;
            this.grdclmScheduledStartTime.Width = 120;
            // 
            // grdclmActualStartTime
            // 
            this.grdclmActualStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmActualStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmActualStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmActualStartTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmActualStartTime.Caption = "实际开工时间";
            this.grdclmActualStartTime.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmActualStartTime.FieldName = "ActualStartTime";
            this.grdclmActualStartTime.MaxWidth = 120;
            this.grdclmActualStartTime.MinWidth = 120;
            this.grdclmActualStartTime.Name = "grdclmActualStartTime";
            this.grdclmActualStartTime.Visible = true;
            this.grdclmActualStartTime.VisibleIndex = 7;
            this.grdclmActualStartTime.Width = 120;
            // 
            // grdclmPWOProgress
            // 
            this.grdclmPWOProgress.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmPWOProgress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmPWOProgress.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmPWOProgress.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmPWOProgress.Caption = "工单进度状态";
            this.grdclmPWOProgress.FieldName = "PWOProgress";
            this.grdclmPWOProgress.MaxWidth = 60;
            this.grdclmPWOProgress.MinWidth = 45;
            this.grdclmPWOProgress.Name = "grdclmPWOProgress";
            this.grdclmPWOProgress.Visible = true;
            this.grdclmPWOProgress.VisibleIndex = 9;
            this.grdclmPWOProgress.Width = 60;
            // 
            // grdclmOperationName
            // 
            this.grdclmOperationName.Caption = "gridColumn12";
            this.grdclmOperationName.Name = "grdclmOperationName";
            this.grdclmOperationName.Visible = true;
            this.grdclmOperationName.VisibleIndex = 10;
            this.grdclmOperationName.Width = 65;
            // 
            // grdclmOrderQty
            // 
            this.grdclmOrderQty.Caption = "gridColumn13";
            this.grdclmOrderQty.Name = "grdclmOrderQty";
            this.grdclmOrderQty.Visible = true;
            this.grdclmOrderQty.VisibleIndex = 11;
            this.grdclmOrderQty.Width = 65;
            // 
            // grdclmMaterialQty
            // 
            this.grdclmMaterialQty.Caption = "gridColumn14";
            this.grdclmMaterialQty.Name = "grdclmMaterialQty";
            this.grdclmMaterialQty.Visible = true;
            this.grdclmMaterialQty.VisibleIndex = 12;
            this.grdclmMaterialQty.Width = 65;
            // 
            // grdclmWIPQty
            // 
            this.grdclmWIPQty.Caption = "gridColumn15";
            this.grdclmWIPQty.Name = "grdclmWIPQty";
            this.grdclmWIPQty.Visible = true;
            this.grdclmWIPQty.VisibleIndex = 13;
            this.grdclmWIPQty.Width = 65;
            // 
            // grdclmScrapRate
            // 
            this.grdclmScrapRate.Caption = "gridColumn16";
            this.grdclmScrapRate.Name = "grdclmScrapRate";
            this.grdclmScrapRate.Visible = true;
            this.grdclmScrapRate.VisibleIndex = 14;
            this.grdclmScrapRate.Width = 65;
            // 
            // grdclmBackgroundColor
            // 
            this.grdclmBackgroundColor.Caption = "gridColumn17";
            this.grdclmBackgroundColor.Name = "grdclmBackgroundColor";
            this.grdclmBackgroundColor.Visible = true;
            this.grdclmBackgroundColor.VisibleIndex = 15;
            this.grdclmBackgroundColor.Width = 95;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pnlRemark
            // 
            this.pnlRemark.Controls.Add(this.lblStatus6);
            this.pnlRemark.Controls.Add(this.lblStatus5);
            this.pnlRemark.Controls.Add(this.lblStatus4);
            this.pnlRemark.Controls.Add(this.lblStatus3);
            this.pnlRemark.Controls.Add(this.lblStatus2);
            this.pnlRemark.Controls.Add(this.lblStatus1);
            this.pnlRemark.Location = new System.Drawing.Point(214, 6);
            this.pnlRemark.Name = "pnlRemark";
            this.pnlRemark.Size = new System.Drawing.Size(625, 35);
            this.pnlRemark.TabIndex = 2;
            // 
            // lblStatus6
            // 
            this.lblStatus6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus6.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblStatus6.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus6.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblStatus6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus6.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStatus6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus6.Location = new System.Drawing.Point(519, 5);
            this.lblStatus6.Name = "lblStatus6";
            this.lblStatus6.Size = new System.Drawing.Size(96, 25);
            this.lblStatus6.TabIndex = 5;
            this.lblStatus6.Text = "过慢";
            // 
            // lblStatus5
            // 
            this.lblStatus5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus5.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblStatus5.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus5.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblStatus5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStatus5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus5.Location = new System.Drawing.Point(417, 5);
            this.lblStatus5.Name = "lblStatus5";
            this.lblStatus5.Size = new System.Drawing.Size(96, 25);
            this.lblStatus5.TabIndex = 4;
            this.lblStatus5.Text = "偏慢";
            // 
            // lblStatus4
            // 
            this.lblStatus4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus4.Appearance.BackColor = System.Drawing.Color.Red;
            this.lblStatus4.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus4.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblStatus4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStatus4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus4.Location = new System.Drawing.Point(315, 5);
            this.lblStatus4.Name = "lblStatus4";
            this.lblStatus4.Size = new System.Drawing.Size(96, 25);
            this.lblStatus4.TabIndex = 3;
            this.lblStatus4.Text = "过快";
            // 
            // lblStatus3
            // 
            this.lblStatus3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus3.Appearance.BackColor = System.Drawing.Color.Goldenrod;
            this.lblStatus3.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus3.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblStatus3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStatus3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus3.Location = new System.Drawing.Point(213, 5);
            this.lblStatus3.Name = "lblStatus3";
            this.lblStatus3.Size = new System.Drawing.Size(96, 25);
            this.lblStatus3.TabIndex = 2;
            this.lblStatus3.Text = "偏快";
            // 
            // lblStatus2
            // 
            this.lblStatus2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus2.Appearance.BackColor = System.Drawing.Color.Green;
            this.lblStatus2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus2.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblStatus2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStatus2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus2.Location = new System.Drawing.Point(111, 5);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(96, 25);
            this.lblStatus2.TabIndex = 1;
            this.lblStatus2.Text = "正常";
            // 
            // lblStatus1
            // 
            this.lblStatus1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblStatus1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus1.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblStatus1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStatus1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus1.Location = new System.Drawing.Point(9, 5);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(96, 25);
            this.lblStatus1.TabIndex = 0;
            this.lblStatus1.Text = "计划";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Appearance.Options.UseBackColor = true;
            this.pnlBottom.Controls.Add(this.pnlRemark);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 423);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1137, 46);
            this.pnlBottom.TabIndex = 3;
            // 
            // tmrPage
            // 
            this.tmrPage.Tick += new System.EventHandler(this.tmrPage_Tick);
            // 
            // frmPWOTracking
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1137, 469);
            this.Controls.Add(this.grdMOTracks);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmPWOTracking";
            this.Text = "生产工单跟踪看板";
            this.Activated += new System.EventHandler(this.frmPWOTracking_Activated);
            this.Load += new System.EventHandler(this.frmPWOTracking_Load);
            this.Shown += new System.EventHandler(this.frmPWOTracking_Shown);
            this.Resize += new System.EventHandler(this.frmPWOTracking_Resize);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.grdMOTracks, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMOTracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvMOTracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRemark)).EndInit();
            this.pnlRemark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMOTracks;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvMOTracks;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmMaterialCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmPlannedStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmPlannedCloseDate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmScheduledStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmActualStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductionStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmPWOProgress;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmOperationName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmMaterialQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmWIPQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmScrapRate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmBackgroundColor;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraEditors.PanelControl pnlRemark;
        private DevExpress.XtraEditors.LabelControl lblStatus6;
        private DevExpress.XtraEditors.LabelControl lblStatus5;
        private DevExpress.XtraEditors.LabelControl lblStatus4;
        private DevExpress.XtraEditors.LabelControl lblStatus3;
        private DevExpress.XtraEditors.LabelControl lblStatus2;
        private DevExpress.XtraEditors.LabelControl lblStatus1;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private System.Windows.Forms.Timer tmrPage;
    }
}
