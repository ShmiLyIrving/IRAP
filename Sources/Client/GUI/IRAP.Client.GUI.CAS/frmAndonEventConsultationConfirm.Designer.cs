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
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lstWaitingforCall = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstWaitingforCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
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
            this.lblFuncName.Text = "会诊结果确认";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(891, 439);
            this.splitContainerControl.SplitterPosition = 380;
            this.splitContainerControl.TabIndex = 5;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.lstWaitingforCall);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(380, 439);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "正在进行会诊的安灯事件";
            // 
            // lstWaitingforCall
            // 
            this.lstWaitingforCall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWaitingforCall.Location = new System.Drawing.Point(5, 24);
            this.lstWaitingforCall.Name = "lstWaitingforCall";
            this.lstWaitingforCall.Size = new System.Drawing.Size(370, 410);
            this.lstWaitingforCall.TabIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.grdStaffs);
            this.groupControl2.Controls.Add(this.btnConfirm);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(506, 439);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "参与本次会诊的人员";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.Location = new System.Drawing.Point(413, 403);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(88, 31);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "责任确认";
            // 
            // grdStaffs
            // 
            this.grdStaffs.Location = new System.Drawing.Point(5, 24);
            this.grdStaffs.MainView = this.grdvStaffs;
            this.grdStaffs.Name = "grdStaffs";
            this.grdStaffs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpschkSelect});
            this.grdStaffs.Size = new System.Drawing.Size(496, 373);
            this.grdStaffs.TabIndex = 3;
            this.grdStaffs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvStaffs});
            // 
            // grdvStaffs
            // 
            this.grdvStaffs.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvStaffs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvStaffs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvStaffs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvStaffs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvStaffs.Appearance.Row.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            // frmAndonEventConsultationConfirm
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.splitContainerControl);
            this.Name = "frmAndonEventConsultationConfirm";
            this.Text = "会诊结果确认";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstWaitingforCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpschkSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ListBoxControl lstWaitingforCall;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
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
