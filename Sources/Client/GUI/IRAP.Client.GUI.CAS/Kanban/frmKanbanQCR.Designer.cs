namespace IRAP.Client.GUI.CAS
{
    partial class frmKanbanQCR
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.grdclmProductionStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdEvents = new DevExpress.XtraGrid.GridControl();
            this.gdvEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmCallingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmProductionLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmFailureCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmFailureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmResponsibleTeamName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmElapsedTimeInMinutes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmRespondingStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            this.grdclmProductionStatus.Caption = "是否已停产";
            this.grdclmProductionStatus.FieldName = "ProductionStatus";
            this.grdclmProductionStatus.Name = "grdclmProductionStatus";
            this.grdclmProductionStatus.Visible = true;
            this.grdclmProductionStatus.VisibleIndex = 6;
            this.grdclmProductionStatus.Width = 62;
            // 
            // grdEvents
            // 
            this.grdEvents.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEvents.Location = new System.Drawing.Point(0, 56);
            this.grdEvents.MainView = this.gdvEvents;
            this.grdEvents.Name = "grdEvents";
            this.grdEvents.Size = new System.Drawing.Size(891, 439);
            this.grdEvents.TabIndex = 3;
            this.grdEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvEvents});
            // 
            // gdvEvents
            // 
            this.gdvEvents.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.gdvEvents.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Green;
            this.gdvEvents.Appearance.HeaderPanel.Options.UseFont = true;
            this.gdvEvents.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gdvEvents.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gdvEvents.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdvEvents.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gdvEvents.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gdvEvents.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.gdvEvents.Appearance.Row.Options.UseFont = true;
            this.gdvEvents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmCallingTime,
            this.grdclmProductionLine,
            this.gridLineName,
            this.grdclmFailureCode,
            this.grdclmFailureName,
            this.grdclmResponsibleTeamName,
            this.grdclmProductionStatus,
            this.grdclmElapsedTimeInMinutes,
            this.grdclmRespondingStatus});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Blue;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.grdclmProductionStatus;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Name = "UnStopped";
            styleFormatCondition1.Value1 = "未停产";
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.grdclmProductionStatus;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Name = "Stopped";
            styleFormatCondition2.Value1 = "已停产";
            this.gdvEvents.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gdvEvents.GridControl = this.grdEvents;
            this.gdvEvents.Name = "gdvEvents";
            this.gdvEvents.OptionsBehavior.Editable = false;
            this.gdvEvents.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gdvEvents.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gdvEvents.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gdvEvents.OptionsView.RowAutoHeight = true;
            this.gdvEvents.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmCallingTime
            // 
            this.grdclmCallingTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmCallingTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmCallingTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmCallingTime.Caption = "呼叫时间";
            this.grdclmCallingTime.FieldName = "CallingTime";
            this.grdclmCallingTime.Name = "grdclmCallingTime";
            this.grdclmCallingTime.Visible = true;
            this.grdclmCallingTime.VisibleIndex = 0;
            this.grdclmCallingTime.Width = 60;
            // 
            // grdclmProductionLine
            // 
            this.grdclmProductionLine.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmProductionLine.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmProductionLine.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmProductionLine.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmProductionLine.Caption = "生产线";
            this.grdclmProductionLine.FieldName = "ProductionLine";
            this.grdclmProductionLine.Name = "grdclmProductionLine";
            this.grdclmProductionLine.Visible = true;
            this.grdclmProductionLine.VisibleIndex = 1;
            this.grdclmProductionLine.Width = 141;
            // 
            // gridLineName
            // 
            this.gridLineName.Caption = "产线名称";
            this.gridLineName.FieldName = "LineName";
            this.gridLineName.Name = "gridLineName";
            this.gridLineName.Visible = true;
            this.gridLineName.VisibleIndex = 2;
            // 
            // grdclmFailureCode
            // 
            this.grdclmFailureCode.Caption = "失效代码";
            this.grdclmFailureCode.FieldName = "FailureCode";
            this.grdclmFailureCode.Name = "grdclmFailureCode";
            this.grdclmFailureCode.Visible = true;
            this.grdclmFailureCode.VisibleIndex = 3;
            this.grdclmFailureCode.Width = 141;
            // 
            // grdclmFailureName
            // 
            this.grdclmFailureName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmFailureName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmFailureName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmFailureName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmFailureName.Caption = "失效名称";
            this.grdclmFailureName.FieldName = "FailureName";
            this.grdclmFailureName.Name = "grdclmFailureName";
            this.grdclmFailureName.Visible = true;
            this.grdclmFailureName.VisibleIndex = 4;
            this.grdclmFailureName.Width = 281;
            // 
            // grdclmResponsibleTeamName
            // 
            this.grdclmResponsibleTeamName.Caption = "责任团队";
            this.grdclmResponsibleTeamName.FieldName = "ResponsibleTeamName";
            this.grdclmResponsibleTeamName.Name = "grdclmResponsibleTeamName";
            this.grdclmResponsibleTeamName.Visible = true;
            this.grdclmResponsibleTeamName.VisibleIndex = 5;
            this.grdclmResponsibleTeamName.Width = 139;
            // 
            // grdclmElapsedTimeInMinutes
            // 
            this.grdclmElapsedTimeInMinutes.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmElapsedTimeInMinutes.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmElapsedTimeInMinutes.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.grdclmElapsedTimeInMinutes.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmElapsedTimeInMinutes.Caption = "已过时间";
            this.grdclmElapsedTimeInMinutes.FieldName = "ElapsedTimeInMinutes";
            this.grdclmElapsedTimeInMinutes.Name = "grdclmElapsedTimeInMinutes";
            this.grdclmElapsedTimeInMinutes.Visible = true;
            this.grdclmElapsedTimeInMinutes.VisibleIndex = 7;
            this.grdclmElapsedTimeInMinutes.Width = 126;
            // 
            // grdclmRespondingStatus
            // 
            this.grdclmRespondingStatus.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmRespondingStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmRespondingStatus.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.grdclmRespondingStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.grdclmRespondingStatus.Caption = "是否已响应";
            this.grdclmRespondingStatus.FieldName = "RespondingStatus";
            this.grdclmRespondingStatus.Name = "grdclmRespondingStatus";
            this.grdclmRespondingStatus.Visible = true;
            this.grdclmRespondingStatus.VisibleIndex = 8;
            this.grdclmRespondingStatus.Width = 112;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmKanbanQCR
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.grdEvents);
            this.Name = "frmKanbanQCR";
            this.Activated += new System.EventHandler(this.frmKanbanQCR_Activated);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.grdEvents, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvEvents;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmCallingTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductionLine;
        private DevExpress.XtraGrid.Columns.GridColumn gridLineName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmFailureCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmFailureName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmResponsibleTeamName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductionStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmElapsedTimeInMinutes;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmRespondingStatus;
        private System.Windows.Forms.Timer timer;
    }
}
