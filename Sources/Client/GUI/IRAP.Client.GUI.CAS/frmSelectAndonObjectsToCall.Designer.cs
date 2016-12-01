namespace IRAP.Client.GUI.CAS
{
    partial class frmSelectAndonObjectsToCall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectAndonObjectsToCall));
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.grdAndonCallObjects = new DevExpress.XtraGrid.GridControl();
            this.grdvAndonCallObjects = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repiceChoice = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.grdclmnEventDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkProductionLineStopped = new DevExpress.XtraEditors.CheckEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCall = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonCallObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonCallObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repiceChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProductionLineStopped.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.gpcAndonEvents.Appearance.Font = new System.Drawing.Font("新宋体", 21.75F);
            this.gpcAndonEvents.Appearance.Options.UseFont = true;
            this.gpcAndonEvents.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.gpcAndonEvents.AppearanceCaption.Options.UseFont = true;
            this.gpcAndonEvents.Controls.Add(this.grdAndonCallObjects);
            this.gpcAndonEvents.Location = new System.Drawing.Point(12, 12);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            this.gpcAndonEvents.Padding = new System.Windows.Forms.Padding(5);
            this.gpcAndonEvents.Size = new System.Drawing.Size(651, 538);
            this.gpcAndonEvents.TabIndex = 2;
            this.gpcAndonEvents.Text = "请选择需要呼叫的内容";
            // 
            // grdAndonCallObjects
            // 
            this.grdAndonCallObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAndonCallObjects.Location = new System.Drawing.Point(7, 28);
            this.grdAndonCallObjects.MainView = this.grdvAndonCallObjects;
            this.grdAndonCallObjects.Name = "grdAndonCallObjects";
            this.grdAndonCallObjects.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repiceChoice});
            this.grdAndonCallObjects.Size = new System.Drawing.Size(637, 503);
            this.grdAndonCallObjects.TabIndex = 1;
            this.grdAndonCallObjects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvAndonCallObjects});
            // 
            // grdvAndonCallObjects
            // 
            this.grdvAndonCallObjects.ColumnPanelRowHeight = 40;
            this.grdvAndonCallObjects.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnChoice,
            this.grdclmnEventDescription});
            this.grdvAndonCallObjects.GridControl = this.grdAndonCallObjects;
            this.grdvAndonCallObjects.Name = "grdvAndonCallObjects";
            this.grdvAndonCallObjects.OptionsView.ColumnAutoWidth = false;
            this.grdvAndonCallObjects.OptionsView.RowAutoHeight = true;
            this.grdvAndonCallObjects.OptionsView.ShowGroupPanel = false;
            this.grdvAndonCallObjects.RowHeight = 40;
            // 
            // grdclmnChoice
            // 
            this.grdclmnChoice.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnChoice.AppearanceCell.Options.UseFont = true;
            this.grdclmnChoice.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnChoice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnChoice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnChoice.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnChoice.AppearanceHeader.Options.UseFont = true;
            this.grdclmnChoice.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnChoice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnChoice.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            // grdclmnEventDescription
            // 
            this.grdclmnEventDescription.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnEventDescription.AppearanceCell.Options.UseFont = true;
            this.grdclmnEventDescription.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnEventDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEventDescription.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnEventDescription.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnEventDescription.AppearanceHeader.Options.UseFont = true;
            this.grdclmnEventDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnEventDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnEventDescription.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEventDescription.Caption = "呼叫内容";
            this.grdclmnEventDescription.FieldName = "ObjectDesc";
            this.grdclmnEventDescription.Name = "grdclmnEventDescription";
            this.grdclmnEventDescription.OptionsColumn.AllowEdit = false;
            this.grdclmnEventDescription.OptionsColumn.ReadOnly = true;
            this.grdclmnEventDescription.Visible = true;
            this.grdclmnEventDescription.VisibleIndex = 1;
            this.grdclmnEventDescription.Width = 400;
            // 
            // chkProductionLineStopped
            // 
            this.chkProductionLineStopped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkProductionLineStopped.EditValue = true;
            this.chkProductionLineStopped.Location = new System.Drawing.Point(680, 98);
            this.chkProductionLineStopped.Name = "chkProductionLineStopped";
            this.chkProductionLineStopped.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.chkProductionLineStopped.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.chkProductionLineStopped.Properties.Appearance.Options.UseFont = true;
            this.chkProductionLineStopped.Properties.Appearance.Options.UseForeColor = true;
            this.chkProductionLineStopped.Properties.Caption = "已停产";
            this.chkProductionLineStopped.Size = new System.Drawing.Size(92, 20);
            this.chkProductionLineStopped.TabIndex = 3;
            this.chkProductionLineStopped.TabStop = false;
            this.chkProductionLineStopped.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(680, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 39);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCall
            // 
            this.btnCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCall.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnCall.Appearance.Options.UseFont = true;
            this.btnCall.Location = new System.Drawing.Point(680, 12);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(92, 39);
            this.btnCall.TabIndex = 4;
            this.btnCall.Text = "呼叫";
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // frmSelectAndonObjectsToCall
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.chkProductionLineStopped);
            this.Controls.Add(this.gpcAndonEvents);
            this.Name = "frmSelectAndonObjectsToCall";
            this.Shown += new System.EventHandler(this.frmSelectAndonObjectsToCall_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonCallObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonCallObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repiceChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProductionLineStopped.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.XtraGrid.GridControl grdAndonCallObjects;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAndonCallObjects;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repiceChoice;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEventDescription;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.CheckEdit chkProductionLineStopped;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnCall;
    }
}
