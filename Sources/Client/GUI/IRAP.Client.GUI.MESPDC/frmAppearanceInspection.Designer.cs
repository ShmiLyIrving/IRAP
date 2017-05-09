namespace IRAP.Client.GUI.MESPDC
{
    partial class frmAppearanceInspection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppearanceInspection));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.edtWIPBarCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdFailureModes = new DevExpress.XtraGrid.GridControl();
            this.grdvFailureModes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riceSelected = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.grdclmnFailureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtWIPBarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFailureModes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvFailureModes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(893, 56);
            this.lblFuncName.Text = "外观检查";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(893, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.btnOK);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(893, 442);
            this.splitContainerControl1.SplitterPosition = 121;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.IsSplitterFixed = true;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl2.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl2.Panel1.Controls.Add(this.edtWIPBarCode);
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl2.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl2.Panel1.ShowCaption = true;
            this.splitContainerControl2.Panel1.Text = "产品";
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl2.Panel2.Controls.Add(this.grdFailureModes);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            this.splitContainerControl2.Panel2.Text = "失效模式";
            this.splitContainerControl2.Size = new System.Drawing.Size(767, 442);
            this.splitContainerControl2.SplitterPosition = 78;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // edtWIPBarCode
            // 
            this.edtWIPBarCode.EnterMoveNextControl = true;
            this.edtWIPBarCode.Location = new System.Drawing.Point(144, 11);
            this.edtWIPBarCode.Name = "edtWIPBarCode";
            this.edtWIPBarCode.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.edtWIPBarCode.Properties.Appearance.Options.UseFont = true;
            this.edtWIPBarCode.Size = new System.Drawing.Size(450, 28);
            this.edtWIPBarCode.TabIndex = 1;
            this.edtWIPBarCode.Validating += new System.ComponentModel.CancelEventHandler(this.edtWIPBarCode_Validating);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl1.Location = new System.Drawing.Point(10, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(128, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "请扫描产品条码：";
            // 
            // grdFailureModes
            // 
            this.grdFailureModes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFailureModes.Location = new System.Drawing.Point(10, 10);
            this.grdFailureModes.MainView = this.grdvFailureModes;
            this.grdFailureModes.Name = "grdFailureModes";
            this.grdFailureModes.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riceSelected});
            this.grdFailureModes.Size = new System.Drawing.Size(743, 309);
            this.grdFailureModes.TabIndex = 0;
            this.grdFailureModes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvFailureModes});
            // 
            // grdvFailureModes
            // 
            this.grdvFailureModes.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvFailureModes.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvFailureModes.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvFailureModes.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvFailureModes.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvFailureModes.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvFailureModes.Appearance.Row.Options.UseFont = true;
            this.grdvFailureModes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnSelected,
            this.grdclmnFailureName});
            this.grdvFailureModes.GridControl = this.grdFailureModes;
            this.grdvFailureModes.Name = "grdvFailureModes";
            this.grdvFailureModes.OptionsView.ColumnAutoWidth = false;
            this.grdvFailureModes.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnSelected
            // 
            this.grdclmnSelected.Caption = "选择";
            this.grdclmnSelected.ColumnEdit = this.riceSelected;
            this.grdclmnSelected.FieldName = "Selected";
            this.grdclmnSelected.Name = "grdclmnSelected";
            this.grdclmnSelected.Visible = true;
            this.grdclmnSelected.VisibleIndex = 0;
            // 
            // riceSelected
            // 
            this.riceSelected.AutoHeight = false;
            this.riceSelected.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.riceSelected.ImageIndexChecked = 0;
            this.riceSelected.ImageIndexUnchecked = 1;
            this.riceSelected.Images = this.imageCollection;
            this.riceSelected.Name = "riceSelected";
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("apply_32x32.png", "images/actions/apply_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_32x32.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "apply_32x32.png");
            this.imageCollection.InsertGalleryImage("paperkind_a4.png", "images/pages/paperkind_a4.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/pages/paperkind_a4.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "paperkind_a4.png");
            // 
            // grdclmnFailureName
            // 
            this.grdclmnFailureName.Caption = "失效模式";
            this.grdclmnFailureName.FieldName = "FailureMode.FailureName";
            this.grdclmnFailureName.Name = "grdclmnFailureName";
            this.grdclmnFailureName.OptionsColumn.AllowEdit = false;
            this.grdclmnFailureName.Visible = true;
            this.grdclmnFailureName.VisibleIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(13, 34);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmAppearanceInspection
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(893, 498);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmAppearanceInspection";
            this.Text = "外观检查";
            this.Activated += new System.EventHandler(this.frmAppearanceInspection_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAppearanceInspection_FormClosed);
            this.Load += new System.EventHandler(this.frmAppearanceInspection_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtWIPBarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFailureModes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvFailureModes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riceSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.GridControl grdFailureModes;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvFailureModes;
        private DevExpress.XtraEditors.TextEdit edtWIPBarCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSelected;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFailureName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit riceSelected;
        private DevExpress.Utils.ImageCollection imageCollection;
    }
}
