namespace IRAP.Client.GUI.CAS
{
    partial class frmAndonEventClose_30
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
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.grdAndonEvents = new DevExpress.XtraGrid.GridControl();
            this.grdvAndonEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnEventType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnEventDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductionLineStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCallingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRespondingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFirstResponder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnTimeElapsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnEventCauseConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnEventClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(1098, 56);
            this.lblFuncName.Text = "安灯关闭";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(1098, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // gpcAndonEvents
            // 
            this.gpcAndonEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcAndonEvents.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpcAndonEvents.Appearance.Options.UseFont = true;
            this.gpcAndonEvents.AppearanceCaption.Font = new System.Drawing.Font("等线", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpcAndonEvents.AppearanceCaption.Options.UseFont = true;
            this.gpcAndonEvents.Controls.Add(this.grdAndonEvents);
            this.gpcAndonEvents.Location = new System.Drawing.Point(12, 62);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            this.gpcAndonEvents.Padding = new System.Windows.Forms.Padding(10);
            this.gpcAndonEvents.Size = new System.Drawing.Size(942, 550);
            this.gpcAndonEvents.TabIndex = 1;
            this.gpcAndonEvents.Text = "待关闭的安灯事件";
            // 
            // grdAndonEvents
            // 
            this.grdAndonEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAndonEvents.Location = new System.Drawing.Point(12, 36);
            this.grdAndonEvents.MainView = this.grdvAndonEvents;
            this.grdAndonEvents.Name = "grdAndonEvents";
            this.grdAndonEvents.Size = new System.Drawing.Size(918, 502);
            this.grdAndonEvents.TabIndex = 1;
            this.grdAndonEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvAndonEvents});
            // 
            // grdvAndonEvents
            // 
            this.grdvAndonEvents.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvAndonEvents.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvAndonEvents.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvAndonEvents.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvAndonEvents.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvAndonEvents.Appearance.Row.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvAndonEvents.Appearance.Row.Options.UseFont = true;
            this.grdvAndonEvents.ColumnPanelRowHeight = 30;
            this.grdvAndonEvents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnEventType,
            this.grdclmnEventDescription,
            this.grdclmnProductionLineStatus,
            this.grdclmnCallingTime,
            this.grdclmnRespondingTime,
            this.grdclmnFirstResponder,
            this.grdclmnTimeElapsed});
            this.grdvAndonEvents.GridControl = this.grdAndonEvents;
            this.grdvAndonEvents.Name = "grdvAndonEvents";
            this.grdvAndonEvents.OptionsBehavior.Editable = false;
            this.grdvAndonEvents.OptionsView.ColumnAutoWidth = false;
            this.grdvAndonEvents.OptionsView.RowAutoHeight = true;
            this.grdvAndonEvents.OptionsView.ShowGroupPanel = false;
            this.grdvAndonEvents.RowHeight = 30;
            this.grdvAndonEvents.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.grdvAndonEvents_FocusedRowObjectChanged);
            // 
            // grdclmnEventType
            // 
            this.grdclmnEventType.Caption = "事件类型";
            this.grdclmnEventType.FieldName = "EventType";
            this.grdclmnEventType.Name = "grdclmnEventType";
            this.grdclmnEventType.OptionsColumn.AllowEdit = false;
            this.grdclmnEventType.OptionsColumn.ReadOnly = true;
            this.grdclmnEventType.Visible = true;
            this.grdclmnEventType.VisibleIndex = 0;
            this.grdclmnEventType.Width = 200;
            // 
            // grdclmnEventDescription
            // 
            this.grdclmnEventDescription.Caption = "事件描述";
            this.grdclmnEventDescription.FieldName = "EventDescription";
            this.grdclmnEventDescription.Name = "grdclmnEventDescription";
            this.grdclmnEventDescription.OptionsColumn.AllowEdit = false;
            this.grdclmnEventDescription.OptionsColumn.ReadOnly = true;
            this.grdclmnEventDescription.Visible = true;
            this.grdclmnEventDescription.VisibleIndex = 1;
            this.grdclmnEventDescription.Width = 300;
            // 
            // grdclmnProductionLineStatus
            // 
            this.grdclmnProductionLineStatus.Caption = "是否已停线";
            this.grdclmnProductionLineStatus.FieldName = "ProductionLineStatus";
            this.grdclmnProductionLineStatus.Name = "grdclmnProductionLineStatus";
            this.grdclmnProductionLineStatus.Visible = true;
            this.grdclmnProductionLineStatus.VisibleIndex = 2;
            // 
            // grdclmnCallingTime
            // 
            this.grdclmnCallingTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnCallingTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCallingTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnCallingTime.Caption = "呼叫时间";
            this.grdclmnCallingTime.FieldName = "CallingTime";
            this.grdclmnCallingTime.Name = "grdclmnCallingTime";
            this.grdclmnCallingTime.OptionsColumn.AllowEdit = false;
            this.grdclmnCallingTime.OptionsColumn.ReadOnly = true;
            this.grdclmnCallingTime.Visible = true;
            this.grdclmnCallingTime.VisibleIndex = 3;
            this.grdclmnCallingTime.Width = 120;
            // 
            // grdclmnRespondingTime
            // 
            this.grdclmnRespondingTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnRespondingTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRespondingTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRespondingTime.Caption = "响应时间";
            this.grdclmnRespondingTime.FieldName = "RespondingTime";
            this.grdclmnRespondingTime.Name = "grdclmnRespondingTime";
            this.grdclmnRespondingTime.Visible = true;
            this.grdclmnRespondingTime.VisibleIndex = 4;
            // 
            // grdclmnFirstResponder
            // 
            this.grdclmnFirstResponder.Caption = "责任响应人";
            this.grdclmnFirstResponder.FieldName = "FirstResponder";
            this.grdclmnFirstResponder.Name = "grdclmnFirstResponder";
            this.grdclmnFirstResponder.Visible = true;
            this.grdclmnFirstResponder.VisibleIndex = 5;
            // 
            // grdclmnTimeElapsed
            // 
            this.grdclmnTimeElapsed.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnTimeElapsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnTimeElapsed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnTimeElapsed.Caption = "已过时间";
            this.grdclmnTimeElapsed.FieldName = "TimeElapsed";
            this.grdclmnTimeElapsed.Name = "grdclmnTimeElapsed";
            this.grdclmnTimeElapsed.OptionsColumn.AllowEdit = false;
            this.grdclmnTimeElapsed.OptionsColumn.ReadOnly = true;
            this.grdclmnTimeElapsed.Visible = true;
            this.grdclmnTimeElapsed.VisibleIndex = 6;
            this.grdclmnTimeElapsed.Width = 120;
            // 
            // btnEventCauseConfirm
            // 
            this.btnEventCauseConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEventCauseConfirm.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEventCauseConfirm.Appearance.Options.UseFont = true;
            this.btnEventCauseConfirm.Enabled = false;
            this.btnEventCauseConfirm.Location = new System.Drawing.Point(969, 62);
            this.btnEventCauseConfirm.Name = "btnEventCauseConfirm";
            this.btnEventCauseConfirm.Size = new System.Drawing.Size(117, 36);
            this.btnEventCauseConfirm.TabIndex = 2;
            this.btnEventCauseConfirm.Text = "原因确认";
            this.btnEventCauseConfirm.Click += new System.EventHandler(this.btnEventCauseConfirm_Click);
            // 
            // btnEventClose
            // 
            this.btnEventClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEventClose.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEventClose.Appearance.Options.UseFont = true;
            this.btnEventClose.Enabled = false;
            this.btnEventClose.Location = new System.Drawing.Point(969, 104);
            this.btnEventClose.Name = "btnEventClose";
            this.btnEventClose.Size = new System.Drawing.Size(117, 36);
            this.btnEventClose.TabIndex = 3;
            this.btnEventClose.Text = "关闭呼叫";
            this.btnEventClose.Click += new System.EventHandler(this.btnEventClose_Click);
            // 
            // frmAndonEventClose_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1098, 624);
            this.Controls.Add(this.btnEventClose);
            this.Controls.Add(this.btnEventCauseConfirm);
            this.Controls.Add(this.gpcAndonEvents);
            this.Name = "frmAndonEventClose_30";
            this.Text = "安灯关闭";
            this.Activated += new System.EventHandler(this.frmAndonEventClose_30_Activated);
            this.Shown += new System.EventHandler(this.frmAndonEventClose_30_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.gpcAndonEvents, 0);
            this.Controls.SetChildIndex(this.btnEventCauseConfirm, 0);
            this.Controls.SetChildIndex(this.btnEventClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.XtraEditors.SimpleButton btnEventCauseConfirm;
        private DevExpress.XtraGrid.GridControl grdAndonEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAndonEvents;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEventType;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEventDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductionLineStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCallingTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRespondingTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFirstResponder;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnTimeElapsed;
        private DevExpress.XtraEditors.SimpleButton btnEventClose;
    }
}
