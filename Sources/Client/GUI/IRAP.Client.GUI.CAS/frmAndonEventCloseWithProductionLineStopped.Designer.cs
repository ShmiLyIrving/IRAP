namespace IRAP.Client.GUI.CAS
{
    partial class frmAndonEventCloseWithProductionLineStopped
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAndonEventCloseWithProductionLineStopped));
            this.rgpSatisfactory = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtUserIDCardNo = new DevExpress.XtraEditors.TextEdit();
            this.lblReadUserIDCard = new DevExpress.XtraEditors.LabelControl();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdAndonEvents = new DevExpress.XtraGrid.GridControl();
            this.grdvAndonEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rsiChecked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdclmnResourceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grdclmnElapsedSeconds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductionDown = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCallingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.rgpSatisfactory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserIDCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsiChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // rgpSatisfactory
            // 
            this.rgpSatisfactory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgpSatisfactory.Location = new System.Drawing.Point(146, 46);
            this.rgpSatisfactory.Name = "rgpSatisfactory";
            this.rgpSatisfactory.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rgpSatisfactory.Properties.Appearance.Options.UseFont = true;
            this.rgpSatisfactory.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "1 - 非常满意"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "2 - 满意"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "3 - 一般"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "4 - 不满意")});
            this.rgpSatisfactory.Size = new System.Drawing.Size(433, 129);
            this.rgpSatisfactory.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl1.Location = new System.Drawing.Point(12, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(128, 21);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "用户满意度调查：";
            // 
            // edtUserIDCardNo
            // 
            this.edtUserIDCardNo.EnterMoveNextControl = true;
            this.edtUserIDCardNo.Location = new System.Drawing.Point(146, 9);
            this.edtUserIDCardNo.Name = "edtUserIDCardNo";
            this.edtUserIDCardNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.edtUserIDCardNo.Properties.Appearance.Options.UseFont = true;
            this.edtUserIDCardNo.Properties.UseSystemPasswordChar = true;
            this.edtUserIDCardNo.Size = new System.Drawing.Size(433, 28);
            this.edtUserIDCardNo.TabIndex = 5;
            this.edtUserIDCardNo.Validating += new System.ComponentModel.CancelEventHandler(this.edtUserIDCardNo_Validating);
            // 
            // lblReadUserIDCard
            // 
            this.lblReadUserIDCard.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblReadUserIDCard.Location = new System.Drawing.Point(12, 12);
            this.lblReadUserIDCard.Name = "lblReadUserIDCard";
            this.lblReadUserIDCard.Size = new System.Drawing.Size(128, 21);
            this.lblReadUserIDCard.TabIndex = 4;
            this.lblReadUserIDCard.Text = "请输入您的工号：";
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
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdAndonEvents);
            this.groupControl1.Controls.Add(this.lblMessage);
            this.groupControl1.Location = new System.Drawing.Point(12, 216);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl1.Size = new System.Drawing.Size(682, 260);
            this.groupControl1.TabIndex = 8;
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
            this.grdAndonEvents.Size = new System.Drawing.Size(668, 183);
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
            this.grdclmnChoice,
            this.grdclmnResourceName,
            this.grdclmnElapsedSeconds,
            this.grdclmnProductionDown,
            this.grdclmnCallingTime});
            this.grdvAndonEvents.GridControl = this.grdAndonEvents;
            this.grdvAndonEvents.Name = "grdvAndonEvents";
            this.grdvAndonEvents.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvAndonEvents.OptionsView.RowAutoHeight = true;
            this.grdvAndonEvents.OptionsView.ShowGroupPanel = false;
            this.grdvAndonEvents.RowHeight = 30;
            // 
            // grdclmnChoice
            // 
            this.grdclmnChoice.Caption = "选择";
            this.grdclmnChoice.ColumnEdit = this.rsiChecked;
            this.grdclmnChoice.FieldName = "Choice";
            this.grdclmnChoice.MaxWidth = 50;
            this.grdclmnChoice.MinWidth = 50;
            this.grdclmnChoice.Name = "grdclmnChoice";
            this.grdclmnChoice.Visible = true;
            this.grdclmnChoice.VisibleIndex = 0;
            this.grdclmnChoice.Width = 50;
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
            this.grdclmnResourceName.VisibleIndex = 1;
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
            this.grdclmnElapsedSeconds.VisibleIndex = 2;
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
            this.grdclmnProductionDown.OptionsColumn.AllowEdit = false;
            this.grdclmnProductionDown.Visible = true;
            this.grdclmnProductionDown.VisibleIndex = 3;
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
            this.grdclmnCallingTime.VisibleIndex = 4;
            this.grdclmnCallingTime.Width = 90;
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Location = new System.Drawing.Point(7, 216);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(668, 37);
            this.lblMessage.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(595, 56);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 38);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(595, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 38);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Location = new System.Drawing.Point(12, 190);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(574, 19);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "如果当前产线还没有恢复生产，请在下面列表中选择一条停产的安灯事件作为停线的关联事件";
            // 
            // frmAndonEventCloseWithProductionLineStopped
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(706, 488);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.rgpSatisfactory);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.edtUserIDCardNo);
            this.Controls.Add(this.lblReadUserIDCard);
            this.Name = "frmAndonEventCloseWithProductionLineStopped";
            this.Text = "关闭安灯事件";
            ((System.ComponentModel.ISupportInitialize)(this.rgpSatisfactory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserIDCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsiChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup rgpSatisfactory;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtUserIDCardNo;
        private DevExpress.XtraEditors.LabelControl lblReadUserIDCard;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdAndonEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAndonEvents;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnResourceName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnElapsedSeconds;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductionDown;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rsiChecked;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCallingTime;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
    }
}
