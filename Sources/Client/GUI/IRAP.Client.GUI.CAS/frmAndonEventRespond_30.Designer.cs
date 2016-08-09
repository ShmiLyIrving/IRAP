namespace IRAP.Client.GUI.CAS
{
    partial class frmAndonEventRespond_30
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAndonEventRespond_30));
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpIDCardnoRead = new DevExpress.XtraTab.XtraTabPage();
            this.pnlIDCardNoRead = new DevExpress.XtraEditors.PanelControl();
            this.edtIDCardNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tpAndonEvents = new DevExpress.XtraTab.XtraTabPage();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.chkCallOtherOneAndonEvents = new DevExpress.XtraEditors.CheckEdit();
            this.btnResponse = new DevExpress.XtraEditors.SimpleButton();
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.grdAndonEvents = new DevExpress.XtraGrid.GridControl();
            this.grdvAndonEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpschkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.grdclmnEventType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnEventDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCallingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnTimeElapsed = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpIDCardnoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIDCardNoRead)).BeginInit();
            this.pnlIDCardNoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).BeginInit();
            this.tpAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCallOtherOneAndonEvents.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpschkSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(1020, 56);
            this.lblFuncName.Text = "安灯事件响应";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(1020, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.tcMain.Location = new System.Drawing.Point(0, 56);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpAndonEvents;
            this.tcMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tcMain.Size = new System.Drawing.Size(1020, 686);
            this.tcMain.TabIndex = 1;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpIDCardnoRead,
            this.tpAndonEvents});
            this.tcMain.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tcMain_SelectedPageChanged);
            // 
            // tpIDCardnoRead
            // 
            this.tpIDCardnoRead.Controls.Add(this.pnlIDCardNoRead);
            this.tpIDCardnoRead.Name = "tpIDCardnoRead";
            this.tpIDCardnoRead.Size = new System.Drawing.Size(1014, 680);
            // 
            // pnlIDCardNoRead
            // 
            this.pnlIDCardNoRead.ContentImage = global::IRAP.Client.GUI.CAS.Properties.Resources.AndonCall;
            this.pnlIDCardNoRead.Controls.Add(this.edtIDCardNo);
            this.pnlIDCardNoRead.Controls.Add(this.labelControl1);
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
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(465, 272);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(300, 38);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "请刷卡，获取呼叫您的安灯事件";
            // 
            // tpAndonEvents
            // 
            this.tpAndonEvents.Controls.Add(this.btnReturn);
            this.tpAndonEvents.Controls.Add(this.chkCallOtherOneAndonEvents);
            this.tpAndonEvents.Controls.Add(this.btnResponse);
            this.tpAndonEvents.Controls.Add(this.gpcAndonEvents);
            this.tpAndonEvents.Name = "tpAndonEvents";
            this.tpAndonEvents.Size = new System.Drawing.Size(1014, 680);
            this.tpAndonEvents.Text = "xtraTabPage2";
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Appearance.Options.UseFont = true;
            this.btnReturn.Location = new System.Drawing.Point(882, 626);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(117, 36);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // chkCallOtherOneAndonEvents
            // 
            this.chkCallOtherOneAndonEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCallOtherOneAndonEvents.Location = new System.Drawing.Point(22, 641);
            this.chkCallOtherOneAndonEvents.Name = "chkCallOtherOneAndonEvents";
            this.chkCallOtherOneAndonEvents.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCallOtherOneAndonEvents.Properties.Appearance.Options.UseFont = true;
            this.chkCallOtherOneAndonEvents.Properties.Caption = "呼叫同伴的未响应事件";
            this.chkCallOtherOneAndonEvents.Size = new System.Drawing.Size(187, 20);
            this.chkCallOtherOneAndonEvents.TabIndex = 1;
            this.chkCallOtherOneAndonEvents.TabStop = false;
            this.chkCallOtherOneAndonEvents.CheckedChanged += new System.EventHandler(this.chkCallOtherOneAndonEvents_CheckedChanged);
            // 
            // btnResponse
            // 
            this.btnResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResponse.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResponse.Appearance.Options.UseFont = true;
            this.btnResponse.Location = new System.Drawing.Point(882, 17);
            this.btnResponse.Name = "btnResponse";
            this.btnResponse.Size = new System.Drawing.Size(117, 36);
            this.btnResponse.TabIndex = 2;
            this.btnResponse.Text = "响应";
            this.btnResponse.Click += new System.EventHandler(this.btnResponse_Click);
            // 
            // gpcAndonEvents
            // 
            this.gpcAndonEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcAndonEvents.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcAndonEvents.Appearance.Options.UseFont = true;
            this.gpcAndonEvents.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcAndonEvents.AppearanceCaption.Options.UseFont = true;
            this.gpcAndonEvents.Controls.Add(this.grdAndonEvents);
            this.gpcAndonEvents.Location = new System.Drawing.Point(22, 17);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            this.gpcAndonEvents.Padding = new System.Windows.Forms.Padding(5);
            this.gpcAndonEvents.Size = new System.Drawing.Size(837, 602);
            this.gpcAndonEvents.TabIndex = 0;
            this.gpcAndonEvents.Text = "呼叫我的安灯事件";
            // 
            // grdAndonEvents
            // 
            this.grdAndonEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAndonEvents.Location = new System.Drawing.Point(7, 31);
            this.grdAndonEvents.MainView = this.grdvAndonEvents;
            this.grdAndonEvents.Name = "grdAndonEvents";
            this.grdAndonEvents.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpschkSelect});
            this.grdAndonEvents.Size = new System.Drawing.Size(823, 564);
            this.grdAndonEvents.TabIndex = 0;
            this.grdAndonEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvAndonEvents});
            // 
            // grdvAndonEvents
            // 
            this.grdvAndonEvents.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvAndonEvents.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvAndonEvents.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvAndonEvents.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvAndonEvents.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvAndonEvents.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvAndonEvents.Appearance.Row.Options.UseFont = true;
            this.grdvAndonEvents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnChoice,
            this.grdclmnEventType,
            this.grdclmnEventDescription,
            this.grdclmnCallingTime,
            this.grdclmnTimeElapsed});
            this.grdvAndonEvents.GridControl = this.grdAndonEvents;
            this.grdvAndonEvents.Name = "grdvAndonEvents";
            this.grdvAndonEvents.OptionsView.ColumnAutoWidth = false;
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
            this.grdclmnChoice.Visible = true;
            this.grdclmnChoice.VisibleIndex = 0;
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
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("paperkind_a4.png", "images/pages/paperkind_a4.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/pages/paperkind_a4.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "paperkind_a4.png");
            this.imageCollection.InsertGalleryImage("apply_32x32.png", "images/actions/apply_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_32x32.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "apply_32x32.png");
            // 
            // grdclmnEventType
            // 
            this.grdclmnEventType.Caption = "事件类型";
            this.grdclmnEventType.FieldName = "EventType";
            this.grdclmnEventType.Name = "grdclmnEventType";
            this.grdclmnEventType.OptionsColumn.AllowEdit = false;
            this.grdclmnEventType.OptionsColumn.ReadOnly = true;
            this.grdclmnEventType.Visible = true;
            this.grdclmnEventType.VisibleIndex = 1;
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
            this.grdclmnEventDescription.VisibleIndex = 2;
            this.grdclmnEventDescription.Width = 300;
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
            this.grdclmnTimeElapsed.VisibleIndex = 4;
            this.grdclmnTimeElapsed.Width = 120;
            // 
            // frmAndonEventRespond_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1020, 742);
            this.Controls.Add(this.tcMain);
            this.Name = "frmAndonEventRespond_30";
            this.Text = "安灯事件响应";
            this.Shown += new System.EventHandler(this.frmAndonEventRespond_30_Shown);
            this.Resize += new System.EventHandler(this.frmAndonEventRespond_30_Resize);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.tcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpIDCardnoRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlIDCardNoRead)).EndInit();
            this.pnlIDCardNoRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).EndInit();
            this.tpAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkCallOtherOneAndonEvents.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpschkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpIDCardnoRead;
        private DevExpress.XtraTab.XtraTabPage tpAndonEvents;
        private DevExpress.XtraEditors.PanelControl pnlIDCardNoRead;
        private DevExpress.XtraEditors.TextEdit edtIDCardNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.XtraGrid.GridControl grdAndonEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAndonEvents;
        private DevExpress.XtraEditors.CheckEdit chkCallOtherOneAndonEvents;
        private DevExpress.XtraEditors.SimpleButton btnResponse;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpschkSelect;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEventType;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEventDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCallingTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnTimeElapsed;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
    }
}
