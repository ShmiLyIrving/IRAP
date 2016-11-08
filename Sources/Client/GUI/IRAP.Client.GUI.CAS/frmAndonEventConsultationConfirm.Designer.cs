namespace IRAP.Client.GUI.CAS
{
    partial class frmAndonEventConsultationConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAndonEventConsultationConfirm));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboAndonEvent = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdStaffs = new DevExpress.XtraGrid.GridControl();
            this.grdvStaffs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpschkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.grdclmnUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnAgencyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAndonEvent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStaffs)).BeginInit();
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
            this.lblFuncName.Text = "会诊结果确认";
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
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboAndonEvent);
            this.groupControl1.Location = new System.Drawing.Point(12, 62);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl1.Size = new System.Drawing.Size(773, 62);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "正在进行会诊的安灯事件";
            // 
            // cboAndonEvent
            // 
            this.cboAndonEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboAndonEvent.Location = new System.Drawing.Point(7, 29);
            this.cboAndonEvent.Name = "cboAndonEvent";
            this.cboAndonEvent.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F);
            this.cboAndonEvent.Properties.Appearance.Options.UseFont = true;
            this.cboAndonEvent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAndonEvent.Size = new System.Drawing.Size(759, 24);
            this.cboAndonEvent.TabIndex = 2;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.grdStaffs);
            this.groupControl2.Location = new System.Drawing.Point(12, 130);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl2.Size = new System.Drawing.Size(773, 353);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "参与本次会诊的人员";
            // 
            // grdStaffs
            // 
            this.grdStaffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStaffs.Location = new System.Drawing.Point(7, 29);
            this.grdStaffs.MainView = this.grdvStaffs;
            this.grdStaffs.Name = "grdStaffs";
            this.grdStaffs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpschkSelect});
            this.grdStaffs.Size = new System.Drawing.Size(759, 317);
            this.grdStaffs.TabIndex = 1;
            this.grdStaffs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvStaffs});
            // 
            // grdvStaffs
            // 
            this.grdvStaffs.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 12F);
            this.grdvStaffs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvStaffs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvStaffs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvStaffs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvStaffs.Appearance.Row.Font = new System.Drawing.Font("等线", 12F);
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
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("paperkind_a4.png", "images/pages/paperkind_a4.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/pages/paperkind_a4.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "paperkind_a4.png");
            this.imageCollection.InsertGalleryImage("apply_32x32.png", "images/actions/apply_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_32x32.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "apply_32x32.png");
            // 
            // grdclmnUserCode
            // 
            this.grdclmnUserCode.Caption = "工号";
            this.grdclmnUserCode.FieldName = "UserCode";
            this.grdclmnUserCode.Name = "grdclmnUserCode";
            this.grdclmnUserCode.OptionsColumn.AllowEdit = false;
            this.grdclmnUserCode.OptionsColumn.ReadOnly = true;
            this.grdclmnUserCode.Visible = true;
            this.grdclmnUserCode.VisibleIndex = 3;
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
            this.grdclmnUserName.VisibleIndex = 4;
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
            this.grdclmnRoleName.VisibleIndex = 2;
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
            this.grdclmnAgencyName.VisibleIndex = 1;
            this.grdclmnAgencyName.Width = 145;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(791, 130);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(88, 31);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "责任确认";
            // 
            // frmAndonEventConsultationConfirm
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmAndonEventConsultationConfirm";
            this.Text = "会诊结果确认";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.btnConfirm, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboAndonEvent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpschkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.ComboBoxEdit cboAndonEvent;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraGrid.GridControl grdStaffs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStaffs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpschkSelect;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRoleName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnAgencyName;
    }
}
