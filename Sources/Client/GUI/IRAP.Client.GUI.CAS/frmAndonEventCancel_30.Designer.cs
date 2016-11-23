namespace IRAP.Client.GUI.CAS
{
    partial class frmAndonEventCancel_30
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAndonEventCancel_30));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpAndonEvents = new DevExpress.XtraTab.XtraTabPage();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.grdAndonEvents = new DevExpress.XtraGrid.GridControl();
            this.grdvAndonEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpschkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdclmnEventType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnEventDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCallingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnTimeElapsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.tpIDCardnoRead = new DevExpress.XtraTab.XtraTabPage();
            this.pnlIDCardNoRead = new DevExpress.XtraEditors.PanelControl();
            this.edtIDCardNo = new DevExpress.XtraEditors.TextEdit();
            this.lblGetIDNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpschkSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.tpIDCardnoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIDCardNoRead)).BeginInit();
            this.pnlIDCardNoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(916, 56);
            this.lblFuncName.Text = "安灯事件撤销";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(916, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
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
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 56);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpAndonEvents;
            this.tcMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tcMain.Size = new System.Drawing.Size(916, 505);
            this.tcMain.TabIndex = 2;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpIDCardnoRead,
            this.tpAndonEvents});
            this.tcMain.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tcMain_SelectedPageChanged);
            // 
            // tpAndonEvents
            // 
            this.tpAndonEvents.Controls.Add(this.btnReturn);
            this.tpAndonEvents.Controls.Add(this.btnCancel);
            this.tpAndonEvents.Controls.Add(this.gpcAndonEvents);
            this.tpAndonEvents.Name = "tpAndonEvents";
            this.tpAndonEvents.Size = new System.Drawing.Size(910, 499);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Appearance.Font = new System.Drawing.Font("等线", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.Appearance.Options.UseFont = true;
            this.btnReturn.Location = new System.Drawing.Point(778, 445);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(117, 36);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("等线", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(778, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "撤销呼叫";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.gpcAndonEvents.Location = new System.Drawing.Point(22, 17);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            this.gpcAndonEvents.Padding = new System.Windows.Forms.Padding(5);
            this.gpcAndonEvents.Size = new System.Drawing.Size(733, 464);
            this.gpcAndonEvents.TabIndex = 0;
            this.gpcAndonEvents.Text = "您触发的安灯事件";
            // 
            // grdAndonEvents
            // 
            this.grdAndonEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.grdAndonEvents.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdAndonEvents.Location = new System.Drawing.Point(7, 31);
            this.grdAndonEvents.MainView = this.grdvAndonEvents;
            this.grdAndonEvents.Name = "grdAndonEvents";
            this.grdAndonEvents.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpschkSelect,
            this.repositoryItemMemoEdit1});
            this.grdAndonEvents.Size = new System.Drawing.Size(719, 426);
            this.grdAndonEvents.TabIndex = 0;
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
            this.grdvAndonEvents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnChoice,
            this.grdclmnEventType,
            this.grdclmnEventDescription,
            this.grdclmnCallingTime,
            this.grdclmnTimeElapsed});
            this.grdvAndonEvents.GridControl = this.grdAndonEvents;
            this.grdvAndonEvents.Name = "grdvAndonEvents";
            this.grdvAndonEvents.OptionsView.RowAutoHeight = true;
            this.grdvAndonEvents.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnChoice
            // 
            this.grdclmnChoice.Caption = "选择";
            this.grdclmnChoice.ColumnEdit = this.rpschkSelect;
            this.grdclmnChoice.FieldName = "Choice";
            this.grdclmnChoice.Name = "grdclmnChoice";
            this.grdclmnChoice.OptionsColumn.AllowMove = false;
            // 
            // rpschkSelect
            // 
            this.rpschkSelect.AutoHeight = false;
            this.rpschkSelect.Caption = "Check";
            this.rpschkSelect.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.rpschkSelect.ImageIndexChecked = 1;
            this.rpschkSelect.ImageIndexUnchecked = 0;
            this.rpschkSelect.Images = this.imageCollection;
            this.rpschkSelect.Name = "rpschkSelect";
            // 
            // grdclmnEventType
            // 
            this.grdclmnEventType.Caption = "事件类型";
            this.grdclmnEventType.FieldName = "EventType";
            this.grdclmnEventType.MaxWidth = 100;
            this.grdclmnEventType.MinWidth = 100;
            this.grdclmnEventType.Name = "grdclmnEventType";
            this.grdclmnEventType.OptionsColumn.AllowEdit = false;
            this.grdclmnEventType.OptionsColumn.ReadOnly = true;
            this.grdclmnEventType.Visible = true;
            this.grdclmnEventType.VisibleIndex = 0;
            this.grdclmnEventType.Width = 100;
            // 
            // grdclmnEventDescription
            // 
            this.grdclmnEventDescription.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnEventDescription.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnEventDescription.Caption = "事件描述";
            this.grdclmnEventDescription.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnEventDescription.FieldName = "EventDescription";
            this.grdclmnEventDescription.Name = "grdclmnEventDescription";
            this.grdclmnEventDescription.OptionsColumn.AllowEdit = false;
            this.grdclmnEventDescription.OptionsColumn.ReadOnly = true;
            this.grdclmnEventDescription.Visible = true;
            this.grdclmnEventDescription.VisibleIndex = 1;
            this.grdclmnEventDescription.Width = 388;
            // 
            // grdclmnCallingTime
            // 
            this.grdclmnCallingTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnCallingTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCallingTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnCallingTime.Caption = "呼叫时间";
            this.grdclmnCallingTime.FieldName = "CallingTime";
            this.grdclmnCallingTime.MaxWidth = 100;
            this.grdclmnCallingTime.MinWidth = 100;
            this.grdclmnCallingTime.Name = "grdclmnCallingTime";
            this.grdclmnCallingTime.OptionsColumn.AllowEdit = false;
            this.grdclmnCallingTime.OptionsColumn.ReadOnly = true;
            this.grdclmnCallingTime.Visible = true;
            this.grdclmnCallingTime.VisibleIndex = 2;
            this.grdclmnCallingTime.Width = 100;
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
            this.grdclmnTimeElapsed.VisibleIndex = 3;
            this.grdclmnTimeElapsed.Width = 90;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // tpIDCardnoRead
            // 
            this.tpIDCardnoRead.Controls.Add(this.pnlIDCardNoRead);
            this.tpIDCardnoRead.Name = "tpIDCardnoRead";
            this.tpIDCardnoRead.Size = new System.Drawing.Size(910, 499);
            // 
            // pnlIDCardNoRead
            // 
            this.pnlIDCardNoRead.ContentImage = global::IRAP.Client.GUI.CAS.Properties.Resources.AndonCall;
            this.pnlIDCardNoRead.Controls.Add(this.edtIDCardNo);
            this.pnlIDCardNoRead.Controls.Add(this.lblGetIDNo);
            this.pnlIDCardNoRead.Location = new System.Drawing.Point(22, 26);
            this.pnlIDCardNoRead.Name = "pnlIDCardNoRead";
            this.pnlIDCardNoRead.Size = new System.Drawing.Size(800, 600);
            this.pnlIDCardNoRead.TabIndex = 0;
            // 
            // edtIDCardNo
            // 
            this.edtIDCardNo.EditValue = "";
            this.edtIDCardNo.Location = new System.Drawing.Point(465, 316);
            this.edtIDCardNo.Name = "edtIDCardNo";
            this.edtIDCardNo.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtIDCardNo.Properties.Appearance.Options.UseFont = true;
            this.edtIDCardNo.Properties.Appearance.Options.UseTextOptions = true;
            this.edtIDCardNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.edtIDCardNo.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edtIDCardNo.Properties.UseSystemPasswordChar = true;
            this.edtIDCardNo.Size = new System.Drawing.Size(300, 26);
            this.edtIDCardNo.TabIndex = 1;
            this.edtIDCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtIDCardNo_KeyDown);
            // 
            // lblGetIDNo
            // 
            this.lblGetIDNo.Appearance.Font = new System.Drawing.Font("等线", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGetIDNo.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblGetIDNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblGetIDNo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.lblGetIDNo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblGetIDNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGetIDNo.Location = new System.Drawing.Point(465, 234);
            this.lblGetIDNo.Name = "lblGetIDNo";
            this.lblGetIDNo.Size = new System.Drawing.Size(300, 76);
            this.lblGetIDNo.TabIndex = 0;
            this.lblGetIDNo.Text = "请刷卡，获取您触发的安灯事件";
            // 
            // frmAndonEventCancel_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(916, 561);
            this.Controls.Add(this.tcMain);
            this.Name = "frmAndonEventCancel_30";
            this.Text = "安灯事件撤销";
            this.Activated += new System.EventHandler(this.frmAndonEventCancel_30_Activated);
            this.Shown += new System.EventHandler(this.frmAndonEventCancel_30_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmAndonEventCancel_30_Paint);
            this.Resize += new System.EventHandler(this.frmAndonEventCancel_30_Resize);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.tcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpschkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.tpIDCardnoRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlIDCardNoRead)).EndInit();
            this.pnlIDCardNoRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpAndonEvents;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.XtraGrid.GridControl grdAndonEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAndonEvents;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpschkSelect;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEventType;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEventDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCallingTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnTimeElapsed;
        private DevExpress.XtraTab.XtraTabPage tpIDCardnoRead;
        private DevExpress.XtraEditors.PanelControl pnlIDCardNoRead;
        private DevExpress.XtraEditors.TextEdit edtIDCardNo;
        private DevExpress.XtraEditors.LabelControl lblGetIDNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}
