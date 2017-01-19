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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAndonEventClose_30));
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.grdAndonEvents = new DevExpress.XtraGrid.GridControl();
            this.grdvAndonEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnEventType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnEventDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grdclmnProductionLineStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rsichkProductionDown = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection();
            this.grdclmnCallingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCallUseName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsichkProductionDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
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
            this.grdAndonEvents.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.rsichkProductionDown});
            this.grdAndonEvents.Size = new System.Drawing.Size(918, 502);
            this.grdAndonEvents.TabIndex = 1;
            this.grdAndonEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvAndonEvents});
            // 
            // grdvAndonEvents
            // 
            this.grdvAndonEvents.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.grdclmnCallUseName,
            this.grdclmnRespondingTime,
            this.grdclmnFirstResponder,
            this.grdclmnTimeElapsed});
            this.grdvAndonEvents.GridControl = this.grdAndonEvents;
            this.grdvAndonEvents.Images = this.imageCollection;
            this.grdvAndonEvents.Name = "grdvAndonEvents";
            this.grdvAndonEvents.OptionsBehavior.Editable = false;
            this.grdvAndonEvents.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvAndonEvents.OptionsView.RowAutoHeight = true;
            this.grdvAndonEvents.OptionsView.ShowGroupPanel = false;
            this.grdvAndonEvents.RowHeight = 30;
            this.grdvAndonEvents.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.grdvAndonEvents_FocusedRowObjectChanged);
            // 
            // grdclmnEventType
            // 
            this.grdclmnEventType.Caption = "事件类型";
            this.grdclmnEventType.FieldName = "EventType";
            this.grdclmnEventType.MaxWidth = 90;
            this.grdclmnEventType.MinWidth = 90;
            this.grdclmnEventType.Name = "grdclmnEventType";
            this.grdclmnEventType.OptionsColumn.AllowEdit = false;
            this.grdclmnEventType.OptionsColumn.ReadOnly = true;
            this.grdclmnEventType.Visible = true;
            this.grdclmnEventType.VisibleIndex = 0;
            this.grdclmnEventType.Width = 90;
            // 
            // grdclmnEventDescription
            // 
            this.grdclmnEventDescription.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnEventDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEventDescription.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnEventDescription.Caption = "事件描述";
            this.grdclmnEventDescription.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnEventDescription.FieldName = "EventDescription";
            this.grdclmnEventDescription.Name = "grdclmnEventDescription";
            this.grdclmnEventDescription.OptionsColumn.AllowEdit = false;
            this.grdclmnEventDescription.OptionsColumn.ReadOnly = true;
            this.grdclmnEventDescription.Visible = true;
            this.grdclmnEventDescription.VisibleIndex = 1;
            this.grdclmnEventDescription.Width = 364;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // grdclmnProductionLineStatus
            // 
            this.grdclmnProductionLineStatus.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductionLineStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductionLineStatus.Caption = "是否已停产";
            this.grdclmnProductionLineStatus.ColumnEdit = this.rsichkProductionDown;
            this.grdclmnProductionLineStatus.FieldName = "ProductionDown";
            this.grdclmnProductionLineStatus.MaxWidth = 75;
            this.grdclmnProductionLineStatus.MinWidth = 75;
            this.grdclmnProductionLineStatus.Name = "grdclmnProductionLineStatus";
            this.grdclmnProductionLineStatus.Visible = true;
            this.grdclmnProductionLineStatus.VisibleIndex = 2;
            // 
            // rsichkProductionDown
            // 
            this.rsichkProductionDown.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.rsichkProductionDown.ImageIndexChecked = 1;
            this.rsichkProductionDown.ImageIndexUnchecked = 0;
            this.rsichkProductionDown.Images = this.imageCollection;
            this.rsichkProductionDown.Name = "rsichkProductionDown";
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("paperkind_a4.png", "images/pages/paperkind_a4.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/pages/paperkind_a4.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "paperkind_a4.png");
            this.imageCollection.InsertGalleryImage("apply_32x32.png", "images/actions/apply_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_32x32.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "apply_32x32.png");
            // 
            // grdclmnCallingTime
            // 
            this.grdclmnCallingTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnCallingTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCallingTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnCallingTime.Caption = "呼叫时间";
            this.grdclmnCallingTime.FieldName = "CallingTime";
            this.grdclmnCallingTime.MaxWidth = 90;
            this.grdclmnCallingTime.MinWidth = 90;
            this.grdclmnCallingTime.Name = "grdclmnCallingTime";
            this.grdclmnCallingTime.OptionsColumn.AllowEdit = false;
            this.grdclmnCallingTime.OptionsColumn.ReadOnly = true;
            this.grdclmnCallingTime.Visible = true;
            this.grdclmnCallingTime.VisibleIndex = 3;
            this.grdclmnCallingTime.Width = 90;
            // 
            // grdclmnCallUseName
            // 
            this.grdclmnCallUseName.Caption = "呼叫人";
            this.grdclmnCallUseName.FieldName = "CallUserName";
            this.grdclmnCallUseName.MaxWidth = 140;
            this.grdclmnCallUseName.MinWidth = 140;
            this.grdclmnCallUseName.Name = "grdclmnCallUseName";
            this.grdclmnCallUseName.Visible = true;
            this.grdclmnCallUseName.VisibleIndex = 4;
            this.grdclmnCallUseName.Width = 140;
            // 
            // grdclmnRespondingTime
            // 
            this.grdclmnRespondingTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnRespondingTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRespondingTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRespondingTime.Caption = "响应时间";
            this.grdclmnRespondingTime.FieldName = "RespondingTime";
            this.grdclmnRespondingTime.MaxWidth = 90;
            this.grdclmnRespondingTime.MinWidth = 90;
            this.grdclmnRespondingTime.Name = "grdclmnRespondingTime";
            this.grdclmnRespondingTime.Visible = true;
            this.grdclmnRespondingTime.VisibleIndex = 5;
            this.grdclmnRespondingTime.Width = 90;
            // 
            // grdclmnFirstResponder
            // 
            this.grdclmnFirstResponder.Caption = "责任响应人";
            this.grdclmnFirstResponder.FieldName = "FirstResponder";
            this.grdclmnFirstResponder.MaxWidth = 80;
            this.grdclmnFirstResponder.MinWidth = 80;
            this.grdclmnFirstResponder.Name = "grdclmnFirstResponder";
            this.grdclmnFirstResponder.Visible = true;
            this.grdclmnFirstResponder.VisibleIndex = 6;
            this.grdclmnFirstResponder.Width = 80;
            // 
            // grdclmnTimeElapsed
            // 
            this.grdclmnTimeElapsed.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnTimeElapsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnTimeElapsed.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnTimeElapsed.Caption = "已过时间";
            this.grdclmnTimeElapsed.FieldName = "TimeElapsed";
            this.grdclmnTimeElapsed.MaxWidth = 90;
            this.grdclmnTimeElapsed.MinWidth = 90;
            this.grdclmnTimeElapsed.Name = "grdclmnTimeElapsed";
            this.grdclmnTimeElapsed.OptionsColumn.AllowEdit = false;
            this.grdclmnTimeElapsed.OptionsColumn.ReadOnly = true;
            this.grdclmnTimeElapsed.Visible = true;
            this.grdclmnTimeElapsed.VisibleIndex = 7;
            this.grdclmnTimeElapsed.Width = 90;
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsichkProductionDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
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
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rsichkProductionDown;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCallUseName;
    }
}
