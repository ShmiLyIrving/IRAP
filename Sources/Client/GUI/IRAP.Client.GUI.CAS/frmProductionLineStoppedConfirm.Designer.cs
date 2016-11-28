namespace IRAP.Client.GUI.CAS
{
    partial class frmProductionLineStoppedConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionLineStoppedConfirm));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdAndonEvents = new DevExpress.XtraGrid.GridControl();
            this.grdvAndonEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnResourceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grdclmnElapsedSeconds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductionDown = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rsiChecked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.grdclmnCallingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.btnStoppedConfirm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsiChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "产线停线确认";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdAndonEvents);
            this.groupControl1.Location = new System.Drawing.Point(12, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl1.Size = new System.Drawing.Size(758, 421);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "待关联停线的安灯事件列表";
            // 
            // grdAndonEvents
            // 
            this.grdAndonEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAndonEvents.Location = new System.Drawing.Point(7, 33);
            this.grdAndonEvents.MainView = this.grdvAndonEvents;
            this.grdAndonEvents.Name = "grdAndonEvents";
            this.grdAndonEvents.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.rsiChecked});
            this.grdAndonEvents.Size = new System.Drawing.Size(744, 381);
            this.grdAndonEvents.TabIndex = 2;
            this.grdAndonEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvAndonEvents});
            // 
            // grdvAndonEvents
            // 
            this.grdvAndonEvents.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.grdvAndonEvents.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvAndonEvents.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvAndonEvents.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvAndonEvents.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvAndonEvents.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.grdvAndonEvents.Appearance.Row.Options.UseFont = true;
            this.grdvAndonEvents.ColumnPanelRowHeight = 30;
            this.grdvAndonEvents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnResourceName,
            this.grdclmnElapsedSeconds,
            this.grdclmnProductionDown,
            this.grdclmnCallingTime});
            this.grdvAndonEvents.GridControl = this.grdAndonEvents;
            this.grdvAndonEvents.Name = "grdvAndonEvents";
            this.grdvAndonEvents.OptionsBehavior.Editable = false;
            this.grdvAndonEvents.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvAndonEvents.OptionsView.RowAutoHeight = true;
            this.grdvAndonEvents.OptionsView.ShowGroupPanel = false;
            this.grdvAndonEvents.RowHeight = 30;
            this.grdvAndonEvents.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdvAndonEvents_FocusedRowChanged);
            // 
            // grdclmnResourceName
            // 
            this.grdclmnResourceName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnResourceName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnResourceName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnResourceName.Caption = "事件描述";
            this.grdclmnResourceName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnResourceName.FieldName = "ResourceName";
            this.grdclmnResourceName.Name = "grdclmnResourceName";
            this.grdclmnResourceName.OptionsColumn.AllowEdit = false;
            this.grdclmnResourceName.OptionsColumn.ReadOnly = true;
            this.grdclmnResourceName.Visible = true;
            this.grdclmnResourceName.VisibleIndex = 0;
            this.grdclmnResourceName.Width = 364;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // grdclmnElapsedSeconds
            // 
            this.grdclmnElapsedSeconds.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnElapsedSeconds.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnElapsedSeconds.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnElapsedSeconds.Caption = "已过时间(s)";
            this.grdclmnElapsedSeconds.FieldName = "ElapsedSeconds";
            this.grdclmnElapsedSeconds.MaxWidth = 90;
            this.grdclmnElapsedSeconds.MinWidth = 90;
            this.grdclmnElapsedSeconds.Name = "grdclmnElapsedSeconds";
            this.grdclmnElapsedSeconds.OptionsColumn.AllowEdit = false;
            this.grdclmnElapsedSeconds.OptionsColumn.ReadOnly = true;
            this.grdclmnElapsedSeconds.Visible = true;
            this.grdclmnElapsedSeconds.VisibleIndex = 1;
            this.grdclmnElapsedSeconds.Width = 90;
            // 
            // grdclmnProductionDown
            // 
            this.grdclmnProductionDown.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductionDown.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductionDown.Caption = "停产";
            this.grdclmnProductionDown.ColumnEdit = this.rsiChecked;
            this.grdclmnProductionDown.FieldName = "ProductionDown";
            this.grdclmnProductionDown.MaxWidth = 75;
            this.grdclmnProductionDown.MinWidth = 75;
            this.grdclmnProductionDown.Name = "grdclmnProductionDown";
            this.grdclmnProductionDown.Visible = true;
            this.grdclmnProductionDown.VisibleIndex = 2;
            // 
            // rsiChecked
            // 
            this.rsiChecked.AutoHeight = false;
            this.rsiChecked.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.rsiChecked.ImageIndexChecked = 1;
            this.rsiChecked.ImageIndexUnchecked = 0;
            this.rsiChecked.Images = this.imageCollection;
            this.rsiChecked.Name = "rsiChecked";
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
            this.grdclmnCallingTime.Caption = "响应";
            this.grdclmnCallingTime.ColumnEdit = this.rsiChecked;
            this.grdclmnCallingTime.FieldName = "OnSiteResponded";
            this.grdclmnCallingTime.MaxWidth = 90;
            this.grdclmnCallingTime.MinWidth = 90;
            this.grdclmnCallingTime.Name = "grdclmnCallingTime";
            this.grdclmnCallingTime.OptionsColumn.AllowEdit = false;
            this.grdclmnCallingTime.OptionsColumn.ReadOnly = true;
            this.grdclmnCallingTime.Visible = true;
            this.grdclmnCallingTime.VisibleIndex = 3;
            this.grdclmnCallingTime.Width = 90;
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBody.Controls.Add(this.btnStoppedConfirm);
            this.pnlBody.Controls.Add(this.groupControl1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 56);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(891, 439);
            this.pnlBody.TabIndex = 2;
            // 
            // btnStoppedConfirm
            // 
            this.btnStoppedConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStoppedConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnStoppedConfirm.Appearance.Options.UseFont = true;
            this.btnStoppedConfirm.Enabled = false;
            this.btnStoppedConfirm.Location = new System.Drawing.Point(782, 6);
            this.btnStoppedConfirm.Name = "btnStoppedConfirm";
            this.btnStoppedConfirm.Size = new System.Drawing.Size(97, 36);
            this.btnStoppedConfirm.TabIndex = 2;
            this.btnStoppedConfirm.Text = "停线登记";
            this.btnStoppedConfirm.Click += new System.EventHandler(this.btnStoppedConfirm_Click);
            // 
            // frmProductionLineStoppedConfirm
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.pnlBody);
            this.Name = "frmProductionLineStoppedConfirm";
            this.Text = "产线停线确认";
            this.Activated += new System.EventHandler(this.frmProductionLineStoppedConfirm_Activated);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsiChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraGrid.GridControl grdAndonEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAndonEvents;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnResourceName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductionDown;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCallingTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnElapsedSeconds;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rsiChecked;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.SimpleButton btnStoppedConfirm;
    }
}
