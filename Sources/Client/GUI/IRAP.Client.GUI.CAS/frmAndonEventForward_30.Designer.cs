namespace IRAP.Client.GUI.CAS
{
    partial class frmAndonEventForward_30
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAndonEventForward_30));
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpIDCardnoRead = new DevExpress.XtraTab.XtraTabPage();
            this.pnlIDCardNoRead = new DevExpress.XtraEditors.PanelControl();
            this.edtIDCardNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tpAndonEvents = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboAndonEvents = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.btnForward = new DevExpress.XtraEditors.SimpleButton();
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.grdStaffs = new DevExpress.XtraGrid.GridControl();
            this.grdvStaffs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpschkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdclmnUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnAgencyName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpIDCardnoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIDCardNoRead)).BeginInit();
            this.pnlIDCardNoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).BeginInit();
            this.tpAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAndonEvents.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStaffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpschkSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(914, 56);
            this.lblFuncName.Text = "安灯追加呼叫";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(914, 56);
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
            this.tcMain.Size = new System.Drawing.Size(914, 628);
            this.tcMain.TabIndex = 3;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpIDCardnoRead,
            this.tpAndonEvents});
            // 
            // tpIDCardnoRead
            // 
            this.tpIDCardnoRead.Controls.Add(this.pnlIDCardNoRead);
            this.tpIDCardnoRead.Name = "tpIDCardnoRead";
            this.tpIDCardnoRead.Size = new System.Drawing.Size(908, 622);
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
            this.tpAndonEvents.Controls.Add(this.groupControl1);
            this.tpAndonEvents.Controls.Add(this.btnReturn);
            this.tpAndonEvents.Controls.Add(this.btnForward);
            this.tpAndonEvents.Controls.Add(this.gpcAndonEvents);
            this.tpAndonEvents.Name = "tpAndonEvents";
            this.tpAndonEvents.Size = new System.Drawing.Size(908, 622);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboAndonEvents);
            this.groupControl1.Location = new System.Drawing.Point(22, 17);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl1.Size = new System.Drawing.Size(731, 60);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "呼叫您的安灯事件";
            // 
            // cboAndonEvents
            // 
            this.cboAndonEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboAndonEvents.Location = new System.Drawing.Point(7, 31);
            this.cboAndonEvents.Name = "cboAndonEvents";
            this.cboAndonEvents.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboAndonEvents.Properties.Appearance.Options.UseFont = true;
            this.cboAndonEvents.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAndonEvents.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAndonEvents.Size = new System.Drawing.Size(717, 22);
            this.cboAndonEvents.TabIndex = 0;
            this.cboAndonEvents.SelectedIndexChanged += new System.EventHandler(this.cboAndonEvents_SelectedIndexChanged);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Appearance.Options.UseFont = true;
            this.btnReturn.Location = new System.Drawing.Point(776, 568);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(117, 36);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnForward
            // 
            this.btnForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForward.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.Appearance.Options.UseFont = true;
            this.btnForward.Location = new System.Drawing.Point(776, 83);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(117, 36);
            this.btnForward.TabIndex = 2;
            this.btnForward.Text = "追加呼叫";
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
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
            this.gpcAndonEvents.Controls.Add(this.grdStaffs);
            this.gpcAndonEvents.Location = new System.Drawing.Point(22, 83);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            this.gpcAndonEvents.Padding = new System.Windows.Forms.Padding(5);
            this.gpcAndonEvents.Size = new System.Drawing.Size(731, 521);
            this.gpcAndonEvents.TabIndex = 1;
            this.gpcAndonEvents.Text = "请选择追加呼叫的人员";
            // 
            // grdStaffs
            // 
            this.grdStaffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStaffs.Location = new System.Drawing.Point(7, 31);
            this.grdStaffs.MainView = this.grdvStaffs;
            this.grdStaffs.Name = "grdStaffs";
            this.grdStaffs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpschkSelect});
            this.grdStaffs.Size = new System.Drawing.Size(717, 483);
            this.grdStaffs.TabIndex = 0;
            this.grdStaffs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvStaffs});
            // 
            // grdvStaffs
            // 
            this.grdvStaffs.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvStaffs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvStaffs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvStaffs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvStaffs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvStaffs.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvStaffs.Appearance.Row.Options.UseFont = true;
            this.grdvStaffs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnChoice,
            this.grdclmnUserCode,
            this.grdclmnUserName,
            this.grdclmnRoleName,
            this.grdclmnAgencyName});
            this.grdvStaffs.GridControl = this.grdStaffs;
            this.grdvStaffs.Name = "grdvStaffs";
            this.grdvStaffs.OptionsView.ColumnAutoWidth = false;
            this.grdvStaffs.OptionsView.RowAutoHeight = true;
            this.grdvStaffs.OptionsView.ShowGroupPanel = false;
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
            // grdclmnUserCode
            // 
            this.grdclmnUserCode.Caption = "工号";
            this.grdclmnUserCode.FieldName = "UserCode";
            this.grdclmnUserCode.Name = "grdclmnUserCode";
            this.grdclmnUserCode.OptionsColumn.AllowEdit = false;
            this.grdclmnUserCode.OptionsColumn.ReadOnly = true;
            this.grdclmnUserCode.Visible = true;
            this.grdclmnUserCode.VisibleIndex = 1;
            this.grdclmnUserCode.Width = 97;
            // 
            // grdclmnUserName
            // 
            this.grdclmnUserName.Caption = "姓名";
            this.grdclmnUserName.FieldName = "UserName";
            this.grdclmnUserName.Name = "grdclmnUserName";
            this.grdclmnUserName.OptionsColumn.AllowEdit = false;
            this.grdclmnUserName.OptionsColumn.ReadOnly = true;
            this.grdclmnUserName.Visible = true;
            this.grdclmnUserName.VisibleIndex = 2;
            this.grdclmnUserName.Width = 161;
            // 
            // grdclmnRoleName
            // 
            this.grdclmnRoleName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnRoleName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRoleName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRoleName.Caption = "角色";
            this.grdclmnRoleName.FieldName = "RoleName";
            this.grdclmnRoleName.Name = "grdclmnRoleName";
            this.grdclmnRoleName.OptionsColumn.AllowEdit = false;
            this.grdclmnRoleName.OptionsColumn.ReadOnly = true;
            this.grdclmnRoleName.Visible = true;
            this.grdclmnRoleName.VisibleIndex = 3;
            this.grdclmnRoleName.Width = 127;
            // 
            // grdclmnAgencyName
            // 
            this.grdclmnAgencyName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnAgencyName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnAgencyName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnAgencyName.Caption = "部门";
            this.grdclmnAgencyName.FieldName = "AgencyName";
            this.grdclmnAgencyName.Name = "grdclmnAgencyName";
            this.grdclmnAgencyName.OptionsColumn.AllowEdit = false;
            this.grdclmnAgencyName.OptionsColumn.ReadOnly = true;
            this.grdclmnAgencyName.Visible = true;
            this.grdclmnAgencyName.VisibleIndex = 4;
            this.grdclmnAgencyName.Width = 145;
            // 
            // frmAndonEventForward_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(914, 684);
            this.Controls.Add(this.tcMain);
            this.Name = "frmAndonEventForward_30";
            this.Text = "安灯追加呼叫";
            this.Shown += new System.EventHandler(this.frmAndonEventForward_30_Shown);
            this.Resize += new System.EventHandler(this.frmAndonEventForward_30_Resize);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.tcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpIDCardnoRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlIDCardNoRead)).EndInit();
            this.pnlIDCardNoRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).EndInit();
            this.tpAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboAndonEvents.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpschkSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpIDCardnoRead;
        private DevExpress.XtraEditors.PanelControl pnlIDCardNoRead;
        private DevExpress.XtraEditors.TextEdit edtIDCardNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabPage tpAndonEvents;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraEditors.SimpleButton btnForward;
        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.XtraGrid.GridControl grdStaffs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStaffs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpschkSelect;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRoleName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnAgencyName;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboAndonEvents;
    }
}
