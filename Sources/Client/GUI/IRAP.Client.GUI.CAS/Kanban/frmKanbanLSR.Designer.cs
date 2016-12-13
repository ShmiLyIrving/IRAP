namespace IRAP.Client.GUI.CAS
{
    partial class frmKanbanLSR
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
            this.grdclmLineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmStakeHolderRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmStakeHolderName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.grdclmProductionStatus.Caption = "是否已停线";
            this.grdclmProductionStatus.FieldName = "ProductionStatus";
            this.grdclmProductionStatus.Name = "grdclmProductionStatus";
            this.grdclmProductionStatus.Visible = true;
            this.grdclmProductionStatus.VisibleIndex = 4;
            this.grdclmProductionStatus.Width = 70;
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
            this.grdclmLineName,
            this.grdclmStakeHolderRole,
            this.grdclmStakeHolderName,
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
            this.grdclmCallingTime.Width = 53;
            // 
            // grdclmLineName
            // 
            this.grdclmLineName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmLineName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmLineName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmLineName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmLineName.Caption = "生产线";
            this.grdclmLineName.FieldName = "LineName";
            this.grdclmLineName.Name = "grdclmLineName";
            this.grdclmLineName.Visible = true;
            this.grdclmLineName.VisibleIndex = 1;
            this.grdclmLineName.Width = 128;
            // 
            // grdclmStakeHolderRole
            // 
            this.grdclmStakeHolderRole.Caption = "呼叫人员的角色";
            this.grdclmStakeHolderRole.FieldName = "StakeHolderRole";
            this.grdclmStakeHolderRole.Name = "grdclmStakeHolderRole";
            this.grdclmStakeHolderRole.Visible = true;
            this.grdclmStakeHolderRole.VisibleIndex = 2;
            // 
            // grdclmStakeHolderName
            // 
            this.grdclmStakeHolderName.Caption = "呼叫的人员";
            this.grdclmStakeHolderName.FieldName = "StakeHolderName";
            this.grdclmStakeHolderName.Name = "grdclmStakeHolderName";
            this.grdclmStakeHolderName.Visible = true;
            this.grdclmStakeHolderName.VisibleIndex = 3;
            this.grdclmStakeHolderName.Width = 161;
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
            this.grdclmElapsedTimeInMinutes.VisibleIndex = 5;
            this.grdclmElapsedTimeInMinutes.Width = 117;
            // 
            // grdclmRespondingStatus
            // 
            this.grdclmRespondingStatus.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmRespondingStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmRespondingStatus.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.grdclmRespondingStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.grdclmRespondingStatus.Caption = "是否响应";
            this.grdclmRespondingStatus.FieldName = "RespondingStatus";
            this.grdclmRespondingStatus.Name = "grdclmRespondingStatus";
            this.grdclmRespondingStatus.Visible = true;
            this.grdclmRespondingStatus.VisibleIndex = 6;
            this.grdclmRespondingStatus.Width = 39;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmKanbanLSR
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.grdEvents);
            this.Name = "frmKanbanLSR";
            this.Activated += new System.EventHandler(this.frmKanbanLSR_Activated);
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
        private DevExpress.XtraGrid.Columns.GridColumn grdclmLineName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmStakeHolderRole;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmStakeHolderName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductionStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmElapsedTimeInMinutes;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmRespondingStatus;
        private System.Windows.Forms.Timer timer;
    }
}
