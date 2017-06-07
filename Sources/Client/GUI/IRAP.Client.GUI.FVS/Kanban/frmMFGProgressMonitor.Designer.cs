namespace IRAP.Client.GUI.FVS
{
    partial class frmMFGProgressMonitor
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
            this.grdclmnQtyToMFG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tmrPage = new System.Windows.Forms.Timer(this.components);
            this.grdWorkUnitProductionProgress = new DevExpress.XtraGrid.GridControl();
            this.grdvWorkUnitProductionProgress = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT107Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnInputContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmOutputContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStdCycleSeconds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductionProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkUnitProductionProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvWorkUnitProductionProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "生产进度跟踪看板";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdclmnQtyToMFG
            // 
            this.grdclmnQtyToMFG.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQtyToMFG.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnQtyToMFG.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyToMFG.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnQtyToMFG.Caption = "待加工产品数量";
            this.grdclmnQtyToMFG.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnQtyToMFG.FieldName = "QtyToMFG";
            this.grdclmnQtyToMFG.MaxWidth = 110;
            this.grdclmnQtyToMFG.Name = "grdclmnQtyToMFG";
            this.grdclmnQtyToMFG.Visible = true;
            this.grdclmnQtyToMFG.VisibleIndex = 5;
            this.grdclmnQtyToMFG.Width = 106;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tmrPage
            // 
            this.tmrPage.Tick += new System.EventHandler(this.tmrPage_Tick);
            // 
            // grdWorkUnitProductionProgress
            // 
            this.grdWorkUnitProductionProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorkUnitProductionProgress.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.grdWorkUnitProductionProgress.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.grdWorkUnitProductionProgress.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.grdWorkUnitProductionProgress.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.grdWorkUnitProductionProgress.EmbeddedNavigator.Buttons.First.Enabled = false;
            this.grdWorkUnitProductionProgress.EmbeddedNavigator.Buttons.Last.Enabled = false;
            this.grdWorkUnitProductionProgress.EmbeddedNavigator.Buttons.Next.Enabled = false;
            this.grdWorkUnitProductionProgress.EmbeddedNavigator.Buttons.Prev.Enabled = false;
            this.grdWorkUnitProductionProgress.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.grdWorkUnitProductionProgress.Location = new System.Drawing.Point(0, 56);
            this.grdWorkUnitProductionProgress.MainView = this.grdvWorkUnitProductionProgress;
            this.grdWorkUnitProductionProgress.Name = "grdWorkUnitProductionProgress";
            this.grdWorkUnitProductionProgress.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdWorkUnitProductionProgress.Size = new System.Drawing.Size(891, 439);
            this.grdWorkUnitProductionProgress.TabIndex = 3;
            this.grdWorkUnitProductionProgress.TabStop = false;
            this.grdWorkUnitProductionProgress.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvWorkUnitProductionProgress});
            // 
            // grdvWorkUnitProductionProgress
            // 
            this.grdvWorkUnitProductionProgress.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvWorkUnitProductionProgress.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Green;
            this.grdvWorkUnitProductionProgress.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvWorkUnitProductionProgress.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grdvWorkUnitProductionProgress.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvWorkUnitProductionProgress.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvWorkUnitProductionProgress.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvWorkUnitProductionProgress.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvWorkUnitProductionProgress.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvWorkUnitProductionProgress.Appearance.Row.Options.UseFont = true;
            this.grdvWorkUnitProductionProgress.Appearance.Row.Options.UseTextOptions = true;
            this.grdvWorkUnitProductionProgress.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvWorkUnitProductionProgress.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvWorkUnitProductionProgress.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnT107Name,
            this.grdclmnMONumber,
            this.grdclmnMOLineNo,
            this.grdclmnProductNo,
            this.grdclmProductName,
            this.grdclmnInputContainerNo,
            this.grdclmOutputContainerNo,
            this.grdclmnQtyToMFG,
            this.grdclmnQtyCompleted,
            this.grdclmnStdCycleSeconds,
            this.grdclmnStartTime,
            this.grdclmnEndTime,
            this.grdclmnProductionProgress});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.grdclmnQtyToMFG;
            gridFormatRule1.Name = "UnStopped";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Blue;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = "未停产";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.grdclmnQtyToMFG;
            gridFormatRule2.Name = "Stopped";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = "已停产";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.grdvWorkUnitProductionProgress.FormatRules.Add(gridFormatRule1);
            this.grdvWorkUnitProductionProgress.FormatRules.Add(gridFormatRule2);
            this.grdvWorkUnitProductionProgress.GridControl = this.grdWorkUnitProductionProgress;
            this.grdvWorkUnitProductionProgress.Name = "grdvWorkUnitProductionProgress";
            this.grdvWorkUnitProductionProgress.OptionsBehavior.Editable = false;
            this.grdvWorkUnitProductionProgress.OptionsCustomization.AllowFilter = false;
            this.grdvWorkUnitProductionProgress.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvWorkUnitProductionProgress.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grdvWorkUnitProductionProgress.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvWorkUnitProductionProgress.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvWorkUnitProductionProgress.OptionsView.EnableAppearanceOddRow = true;
            this.grdvWorkUnitProductionProgress.OptionsView.RowAutoHeight = true;
            this.grdvWorkUnitProductionProgress.OptionsView.ShowGroupPanel = false;
            this.grdvWorkUnitProductionProgress.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdvWorkUnitProductionProgress_CustomDrawCell);
            this.grdvWorkUnitProductionProgress.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grdvWorkUnitProductionProgress_CustomColumnDisplayText);
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.Caption = "序号";
            this.grdclmnOrdinal.FieldName = "Ordinal";
            this.grdclmnOrdinal.MaxWidth = 50;
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
            this.grdclmnOrdinal.Width = 20;
            // 
            // grdclmnT107Name
            // 
            this.grdclmnT107Name.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT107Name.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT107Name.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnT107Name.Caption = "工位名称";
            this.grdclmnT107Name.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnT107Name.FieldName = "T107Name";
            this.grdclmnT107Name.MinWidth = 160;
            this.grdclmnT107Name.Name = "grdclmnT107Name";
            this.grdclmnT107Name.Visible = true;
            this.grdclmnT107Name.VisibleIndex = 1;
            this.grdclmnT107Name.Width = 161;
            // 
            // grdclmnMONumber
            // 
            this.grdclmnMONumber.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMONumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONumber.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMONumber.Caption = "订单号";
            this.grdclmnMONumber.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnMONumber.FieldName = "MONumber";
            this.grdclmnMONumber.MinWidth = 130;
            this.grdclmnMONumber.Name = "grdclmnMONumber";
            this.grdclmnMONumber.Visible = true;
            this.grdclmnMONumber.VisibleIndex = 2;
            this.grdclmnMONumber.Width = 131;
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
            // grdclmnProductNo
            // 
            this.grdclmnProductNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnProductNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductNo.Caption = "产品编号";
            this.grdclmnProductNo.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnProductNo.FieldName = "ProductNoToShow";
            this.grdclmnProductNo.MaxWidth = 180;
            this.grdclmnProductNo.MinWidth = 180;
            this.grdclmnProductNo.Name = "grdclmnProductNo";
            this.grdclmnProductNo.Visible = true;
            this.grdclmnProductNo.VisibleIndex = 4;
            this.grdclmnProductNo.Width = 180;
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
            this.grdclmProductName.Width = 45;
            // 
            // grdclmnInputContainerNo
            // 
            this.grdclmnInputContainerNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnInputContainerNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnInputContainerNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnInputContainerNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnInputContainerNo.Caption = "待加工容器号";
            this.grdclmnInputContainerNo.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnInputContainerNo.FieldName = "InputContainerNo";
            this.grdclmnInputContainerNo.MaxWidth = 120;
            this.grdclmnInputContainerNo.MinWidth = 120;
            this.grdclmnInputContainerNo.Name = "grdclmnInputContainerNo";
            this.grdclmnInputContainerNo.Width = 120;
            // 
            // grdclmOutputContainerNo
            // 
            this.grdclmOutputContainerNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmOutputContainerNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmOutputContainerNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmOutputContainerNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmOutputContainerNo.Caption = "已加工容器号";
            this.grdclmOutputContainerNo.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmOutputContainerNo.FieldName = "OutputContainerNo";
            this.grdclmOutputContainerNo.MaxWidth = 100;
            this.grdclmOutputContainerNo.MinWidth = 100;
            this.grdclmOutputContainerNo.Name = "grdclmOutputContainerNo";
            this.grdclmOutputContainerNo.Width = 100;
            // 
            // grdclmnQtyCompleted
            // 
            this.grdclmnQtyCompleted.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQtyCompleted.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnQtyCompleted.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.grdclmnQtyCompleted.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyCompleted.Caption = "已报工产品数量";
            this.grdclmnQtyCompleted.FieldName = "QtyCompleted";
            this.grdclmnQtyCompleted.MaxWidth = 110;
            this.grdclmnQtyCompleted.Name = "grdclmnQtyCompleted";
            this.grdclmnQtyCompleted.Visible = true;
            this.grdclmnQtyCompleted.VisibleIndex = 6;
            this.grdclmnQtyCompleted.Width = 110;
            // 
            // grdclmnStdCycleSeconds
            // 
            this.grdclmnStdCycleSeconds.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnStdCycleSeconds.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnStdCycleSeconds.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStdCycleSeconds.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnStdCycleSeconds.Caption = "标准周期时间";
            this.grdclmnStdCycleSeconds.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnStdCycleSeconds.FieldName = "StdCycleSeconds";
            this.grdclmnStdCycleSeconds.MaxWidth = 110;
            this.grdclmnStdCycleSeconds.Name = "grdclmnStdCycleSeconds";
            this.grdclmnStdCycleSeconds.Visible = true;
            this.grdclmnStdCycleSeconds.VisibleIndex = 7;
            this.grdclmnStdCycleSeconds.Width = 110;
            // 
            // grdclmnStartTime
            // 
            this.grdclmnStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStartTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnStartTime.Caption = "开始生产时间";
            this.grdclmnStartTime.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnStartTime.FieldName = "StartTime";
            this.grdclmnStartTime.MaxWidth = 110;
            this.grdclmnStartTime.Name = "grdclmnStartTime";
            this.grdclmnStartTime.Visible = true;
            this.grdclmnStartTime.VisibleIndex = 8;
            this.grdclmnStartTime.Width = 60;
            // 
            // grdclmnEndTime
            // 
            this.grdclmnEndTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnEndTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnEndTime.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.grdclmnEndTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEndTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnEndTime.Caption = "应该结束时间";
            this.grdclmnEndTime.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnEndTime.FieldName = "EndTime";
            this.grdclmnEndTime.MaxWidth = 110;
            this.grdclmnEndTime.Name = "grdclmnEndTime";
            this.grdclmnEndTime.Visible = true;
            this.grdclmnEndTime.VisibleIndex = 9;
            this.grdclmnEndTime.Width = 65;
            // 
            // grdclmnProductionProgress
            // 
            this.grdclmnProductionProgress.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductionProgress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductionProgress.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductionProgress.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductionProgress.Caption = "生产进度状态";
            this.grdclmnProductionProgress.FieldName = "ProductionProgress";
            this.grdclmnProductionProgress.MaxWidth = 110;
            this.grdclmnProductionProgress.Name = "grdclmnProductionProgress";
            this.grdclmnProductionProgress.Visible = true;
            this.grdclmnProductionProgress.VisibleIndex = 10;
            this.grdclmnProductionProgress.Width = 95;
            // 
            // frmMFGProgressMonitor
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.grdWorkUnitProductionProgress);
            this.Name = "frmMFGProgressMonitor";
            this.Text = "生产进度跟踪看板";
            this.Activated += new System.EventHandler(this.frmMFGProgressMonitor_Activated);
            this.Load += new System.EventHandler(this.frmMFGProgressMonitor_Load);
            this.Shown += new System.EventHandler(this.frmMFGProgressMonitor_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.grdWorkUnitProductionProgress, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkUnitProductionProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvWorkUnitProductionProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer tmrPage;
        private DevExpress.XtraGrid.GridControl grdWorkUnitProductionProgress;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvWorkUnitProductionProgress;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT107Name;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnInputContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmOutputContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyToMFG;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyCompleted;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStdCycleSeconds;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductionProgress;
    }
}
