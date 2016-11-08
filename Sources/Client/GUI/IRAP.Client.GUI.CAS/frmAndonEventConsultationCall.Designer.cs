namespace IRAP.Client.GUI.CAS
{
    partial class frmAndonEventConsultationCall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAndonEventConsultationCall));
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpIDCardnoRead = new DevExpress.XtraTab.XtraTabPage();
            this.pnlIDCardNoRead = new DevExpress.XtraEditors.PanelControl();
            this.edtIDCardNo = new DevExpress.XtraEditors.TextEdit();
            this.lblGetIDNo = new DevExpress.XtraEditors.LabelControl();
            this.tpAndonEvents = new DevExpress.XtraTab.XtraTabPage();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.grdStaffs = new DevExpress.XtraGrid.GridControl();
            this.grdvStaffs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpschkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.grdclmnUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnAgencyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnConsultationCall = new DevExpress.XtraEditors.SimpleButton();
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.cboAndonEvent = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpIDCardnoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIDCardNoRead)).BeginInit();
            this.pnlIDCardNoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).BeginInit();
            this.tpAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStaffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpschkSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAndonEvent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblFuncName.Appearance.Font")));
            this.lblFuncName.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblFuncName.Appearance.ForeColor")));
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.lblFuncName, "lblFuncName");
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // tcMain
            // 
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpAndonEvents;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpIDCardnoRead,
            this.tpAndonEvents});
            this.tcMain.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tcMain_SelectedPageChanged);
            // 
            // tpIDCardnoRead
            // 
            this.tpIDCardnoRead.Controls.Add(this.pnlIDCardNoRead);
            this.tpIDCardnoRead.Name = "tpIDCardnoRead";
            resources.ApplyResources(this.tpIDCardnoRead, "tpIDCardnoRead");
            // 
            // pnlIDCardNoRead
            // 
            this.pnlIDCardNoRead.ContentImage = global::IRAP.Client.GUI.CAS.Properties.Resources.AndonCall;
            this.pnlIDCardNoRead.Controls.Add(this.edtIDCardNo);
            this.pnlIDCardNoRead.Controls.Add(this.lblGetIDNo);
            resources.ApplyResources(this.pnlIDCardNoRead, "pnlIDCardNoRead");
            this.pnlIDCardNoRead.Name = "pnlIDCardNoRead";
            // 
            // edtIDCardNo
            // 
            resources.ApplyResources(this.edtIDCardNo, "edtIDCardNo");
            this.edtIDCardNo.Name = "edtIDCardNo";
            this.edtIDCardNo.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtIDCardNo.Properties.Appearance.Font")));
            this.edtIDCardNo.Properties.Appearance.Options.UseFont = true;
            this.edtIDCardNo.Properties.Appearance.Options.UseTextOptions = true;
            this.edtIDCardNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.edtIDCardNo.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edtIDCardNo.Properties.UseSystemPasswordChar = true;
            this.edtIDCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtIDCardNo_KeyDown);
            // 
            // lblGetIDNo
            // 
            this.lblGetIDNo.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblGetIDNo.Appearance.Font")));
            this.lblGetIDNo.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblGetIDNo.Appearance.ForeColor")));
            this.lblGetIDNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblGetIDNo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.lblGetIDNo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblGetIDNo, "lblGetIDNo");
            this.lblGetIDNo.Name = "lblGetIDNo";
            // 
            // tpAndonEvents
            // 
            this.tpAndonEvents.Controls.Add(this.btnReturn);
            this.tpAndonEvents.Controls.Add(this.groupControl3);
            this.tpAndonEvents.Controls.Add(this.btnConsultationCall);
            this.tpAndonEvents.Controls.Add(this.gpcAndonEvents);
            this.tpAndonEvents.Name = "tpAndonEvents";
            resources.ApplyResources(this.tpAndonEvents, "tpAndonEvents");
            // 
            // btnReturn
            // 
            resources.ApplyResources(this.btnReturn, "btnReturn");
            this.btnReturn.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnReturn.Appearance.Font")));
            this.btnReturn.Appearance.Options.UseFont = true;
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // groupControl3
            // 
            resources.ApplyResources(this.groupControl3, "groupControl3");
            this.groupControl3.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("groupControl3.Appearance.Font")));
            this.groupControl3.Appearance.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("groupControl3.AppearanceCaption.Font")));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.grdStaffs);
            this.groupControl3.Name = "groupControl3";
            // 
            // grdStaffs
            // 
            resources.ApplyResources(this.grdStaffs, "grdStaffs");
            this.grdStaffs.MainView = this.grdvStaffs;
            this.grdStaffs.Name = "grdStaffs";
            this.grdStaffs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpschkSelect});
            this.grdStaffs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvStaffs});
            // 
            // grdvStaffs
            // 
            this.grdvStaffs.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("grdvStaffs.Appearance.HeaderPanel.Font")));
            this.grdvStaffs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvStaffs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvStaffs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvStaffs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvStaffs.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("grdvStaffs.Appearance.Row.Font")));
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
            resources.ApplyResources(this.grdclmnChoice, "grdclmnChoice");
            this.grdclmnChoice.ColumnEdit = this.rpschkSelect;
            this.grdclmnChoice.FieldName = "Choice";
            this.grdclmnChoice.Name = "grdclmnChoice";
            this.grdclmnChoice.OptionsColumn.AllowMove = false;
            // 
            // rpschkSelect
            // 
            resources.ApplyResources(this.rpschkSelect, "rpschkSelect");
            this.rpschkSelect.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.rpschkSelect.ImageIndexChecked = 1;
            this.rpschkSelect.ImageIndexUnchecked = 0;
            this.rpschkSelect.Images = this.imageCollection;
            this.rpschkSelect.Name = "rpschkSelect";
            // 
            // imageCollection
            // 
            resources.ApplyResources(this.imageCollection, "imageCollection");
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("paperkind_a4.png", "images/pages/paperkind_a4.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/pages/paperkind_a4.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "paperkind_a4.png");
            this.imageCollection.InsertGalleryImage("apply_32x32.png", "images/actions/apply_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_32x32.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "apply_32x32.png");
            // 
            // grdclmnUserCode
            // 
            resources.ApplyResources(this.grdclmnUserCode, "grdclmnUserCode");
            this.grdclmnUserCode.FieldName = "UserCode";
            this.grdclmnUserCode.Name = "grdclmnUserCode";
            this.grdclmnUserCode.OptionsColumn.AllowEdit = false;
            this.grdclmnUserCode.OptionsColumn.ReadOnly = true;
            // 
            // grdclmnUserName
            // 
            resources.ApplyResources(this.grdclmnUserName, "grdclmnUserName");
            this.grdclmnUserName.FieldName = "UserName";
            this.grdclmnUserName.Name = "grdclmnUserName";
            this.grdclmnUserName.OptionsColumn.AllowEdit = false;
            this.grdclmnUserName.OptionsColumn.ReadOnly = true;
            // 
            // grdclmnRoleName
            // 
            this.grdclmnRoleName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnRoleName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRoleName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnRoleName, "grdclmnRoleName");
            this.grdclmnRoleName.FieldName = "RoleName";
            this.grdclmnRoleName.Name = "grdclmnRoleName";
            this.grdclmnRoleName.OptionsColumn.AllowEdit = false;
            this.grdclmnRoleName.OptionsColumn.ReadOnly = true;
            // 
            // grdclmnAgencyName
            // 
            this.grdclmnAgencyName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnAgencyName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnAgencyName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnAgencyName, "grdclmnAgencyName");
            this.grdclmnAgencyName.FieldName = "AgencyName";
            this.grdclmnAgencyName.Name = "grdclmnAgencyName";
            this.grdclmnAgencyName.OptionsColumn.AllowEdit = false;
            this.grdclmnAgencyName.OptionsColumn.ReadOnly = true;
            // 
            // btnConsultationCall
            // 
            resources.ApplyResources(this.btnConsultationCall, "btnConsultationCall");
            this.btnConsultationCall.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnConsultationCall.Appearance.Font")));
            this.btnConsultationCall.Appearance.Options.UseFont = true;
            this.btnConsultationCall.Name = "btnConsultationCall";
            this.btnConsultationCall.Click += new System.EventHandler(this.btnConsultationCall_Click);
            // 
            // gpcAndonEvents
            // 
            resources.ApplyResources(this.gpcAndonEvents, "gpcAndonEvents");
            this.gpcAndonEvents.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("gpcAndonEvents.Appearance.Font")));
            this.gpcAndonEvents.Appearance.Options.UseFont = true;
            this.gpcAndonEvents.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("gpcAndonEvents.AppearanceCaption.Font")));
            this.gpcAndonEvents.AppearanceCaption.Options.UseFont = true;
            this.gpcAndonEvents.Controls.Add(this.cboAndonEvent);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            // 
            // cboAndonEvent
            // 
            resources.ApplyResources(this.cboAndonEvent, "cboAndonEvent");
            this.cboAndonEvent.Name = "cboAndonEvent";
            this.cboAndonEvent.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cboAndonEvent.Properties.Appearance.Font")));
            this.cboAndonEvent.Properties.Appearance.Options.UseFont = true;
            this.cboAndonEvent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboAndonEvent.Properties.Buttons"))))});
            this.cboAndonEvent.SelectedIndexChanged += new System.EventHandler(this.cboAndonEvent_SelectedIndexChanged);
            // 
            // frmAndonEventConsultationCall
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tcMain);
            this.Name = "frmAndonEventConsultationCall";
            this.Shown += new System.EventHandler(this.frmAndonEventConsultation_Shown);
            this.Resize += new System.EventHandler(this.frmAndonEventConsultation_Resize);
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpschkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboAndonEvent.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpIDCardnoRead;
        private DevExpress.XtraEditors.PanelControl pnlIDCardNoRead;
        private DevExpress.XtraEditors.TextEdit edtIDCardNo;
        private DevExpress.XtraEditors.LabelControl lblGetIDNo;
        private DevExpress.XtraTab.XtraTabPage tpAndonEvents;
        private DevExpress.XtraEditors.SimpleButton btnConsultationCall;
        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.XtraEditors.ComboBoxEdit cboAndonEvent;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdStaffs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStaffs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpschkSelect;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRoleName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnAgencyName;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
    }
}
