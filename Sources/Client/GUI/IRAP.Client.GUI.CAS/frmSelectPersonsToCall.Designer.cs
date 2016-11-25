namespace IRAP.Client.GUI.CAS
{
    partial class frmSelectPersonsToCall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectPersonsToCall));
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCall = new DevExpress.XtraEditors.SimpleButton();
            this.chkProductionLineStopped = new DevExpress.XtraEditors.CheckEdit();
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.grdStaffs = new DevExpress.XtraGrid.GridControl();
            this.grdvStaffs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repiceChoice = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.grdclmnT2NodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkProductionLineStopped.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStaffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repiceChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(680, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 39);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCall
            // 
            this.btnCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCall.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCall.Appearance.Options.UseFont = true;
            this.btnCall.Location = new System.Drawing.Point(680, 12);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(92, 39);
            this.btnCall.TabIndex = 8;
            this.btnCall.Text = "呼叫";
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // chkProductionLineStopped
            // 
            this.chkProductionLineStopped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkProductionLineStopped.EditValue = true;
            this.chkProductionLineStopped.Location = new System.Drawing.Point(680, 98);
            this.chkProductionLineStopped.Name = "chkProductionLineStopped";
            this.chkProductionLineStopped.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkProductionLineStopped.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.chkProductionLineStopped.Properties.Appearance.Options.UseFont = true;
            this.chkProductionLineStopped.Properties.Appearance.Options.UseForeColor = true;
            this.chkProductionLineStopped.Properties.Caption = "已停产";
            this.chkProductionLineStopped.Size = new System.Drawing.Size(92, 21);
            this.chkProductionLineStopped.TabIndex = 7;
            // 
            // gpcAndonEvents
            // 
            this.gpcAndonEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcAndonEvents.Appearance.Font = new System.Drawing.Font("新宋体", 21.75F);
            this.gpcAndonEvents.Appearance.Options.UseFont = true;
            this.gpcAndonEvents.AppearanceCaption.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpcAndonEvents.AppearanceCaption.Options.UseFont = true;
            this.gpcAndonEvents.Controls.Add(this.grdStaffs);
            this.gpcAndonEvents.Location = new System.Drawing.Point(12, 12);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            this.gpcAndonEvents.Padding = new System.Windows.Forms.Padding(10);
            this.gpcAndonEvents.Size = new System.Drawing.Size(651, 538);
            this.gpcAndonEvents.TabIndex = 6;
            this.gpcAndonEvents.Text = "请选择需要呼叫的人员";
            // 
            // grdStaffs
            // 
            this.grdStaffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStaffs.Location = new System.Drawing.Point(12, 34);
            this.grdStaffs.MainView = this.grdvStaffs;
            this.grdStaffs.Name = "grdStaffs";
            this.grdStaffs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repiceChoice});
            this.grdStaffs.Size = new System.Drawing.Size(627, 492);
            this.grdStaffs.TabIndex = 2;
            this.grdStaffs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvStaffs});
            // 
            // grdvStaffs
            // 
            this.grdvStaffs.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvStaffs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvStaffs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvStaffs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvStaffs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvStaffs.Appearance.Row.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvStaffs.Appearance.Row.Options.UseFont = true;
            this.grdvStaffs.Appearance.Row.Options.UseTextOptions = true;
            this.grdvStaffs.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvStaffs.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvStaffs.ColumnPanelRowHeight = 40;
            this.grdvStaffs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnChoice,
            this.grdclmnT2NodeName,
            this.grdclmnUserCode,
            this.grdclmnUserName});
            this.grdvStaffs.GridControl = this.grdStaffs;
            this.grdvStaffs.Name = "grdvStaffs";
            this.grdvStaffs.OptionsView.ColumnAutoWidth = false;
            this.grdvStaffs.OptionsView.RowAutoHeight = true;
            this.grdvStaffs.OptionsView.ShowGroupPanel = false;
            this.grdvStaffs.RowHeight = 40;
            // 
            // grdclmnChoice
            // 
            this.grdclmnChoice.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnChoice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnChoice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnChoice.Caption = "选择";
            this.grdclmnChoice.ColumnEdit = this.repiceChoice;
            this.grdclmnChoice.FieldName = "Choice";
            this.grdclmnChoice.Name = "grdclmnChoice";
            this.grdclmnChoice.OptionsColumn.AllowMove = false;
            this.grdclmnChoice.Visible = true;
            this.grdclmnChoice.VisibleIndex = 0;
            // 
            // repiceChoice
            // 
            this.repiceChoice.Appearance.Font = new System.Drawing.Font("新宋体", 21.75F);
            this.repiceChoice.Appearance.Options.UseFont = true;
            this.repiceChoice.AutoHeight = false;
            this.repiceChoice.Caption = "Check";
            this.repiceChoice.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repiceChoice.ImageIndexChecked = 1;
            this.repiceChoice.ImageIndexUnchecked = 0;
            this.repiceChoice.Images = this.imageCollection;
            this.repiceChoice.Name = "repiceChoice";
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
            // grdclmnT2NodeName
            // 
            this.grdclmnT2NodeName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT2NodeName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT2NodeName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnT2NodeName.Caption = "角色";
            this.grdclmnT2NodeName.FieldName = "T2NodeName";
            this.grdclmnT2NodeName.Name = "grdclmnT2NodeName";
            this.grdclmnT2NodeName.OptionsColumn.AllowEdit = false;
            this.grdclmnT2NodeName.OptionsColumn.ReadOnly = true;
            this.grdclmnT2NodeName.Visible = true;
            this.grdclmnT2NodeName.VisibleIndex = 1;
            this.grdclmnT2NodeName.Width = 200;
            // 
            // grdclmnUserCode
            // 
            this.grdclmnUserCode.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnUserCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnUserCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUserCode.Caption = "工号";
            this.grdclmnUserCode.FieldName = "UserCode";
            this.grdclmnUserCode.Name = "grdclmnUserCode";
            this.grdclmnUserCode.Visible = true;
            this.grdclmnUserCode.VisibleIndex = 2;
            this.grdclmnUserCode.Width = 100;
            // 
            // grdclmnUserName
            // 
            this.grdclmnUserName.Caption = "姓名";
            this.grdclmnUserName.FieldName = "UserName";
            this.grdclmnUserName.Name = "grdclmnUserName";
            this.grdclmnUserName.Visible = true;
            this.grdclmnUserName.VisibleIndex = 3;
            this.grdclmnUserName.Width = 150;
            // 
            // frmSelectPersonsToCall
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.chkProductionLineStopped);
            this.Controls.Add(this.gpcAndonEvents);
            this.Name = "frmSelectPersonsToCall";
            this.Shown += new System.EventHandler(this.frmSelectPersonsToCall_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.chkProductionLineStopped.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repiceChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnCall;
        private DevExpress.XtraEditors.CheckEdit chkProductionLineStopped;
        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraGrid.GridControl grdStaffs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStaffs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repiceChoice;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT2NodeName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserName;
    }
}
