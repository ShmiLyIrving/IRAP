namespace IRAP.Client.Global.GUI
{
    partial class frmShowErrorLogs
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
            this.gpcLogs = new DevExpress.XtraEditors.GroupControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grdLogs = new DevExpress.XtraGrid.GridControl();
            this.grdvLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcLogs)).BeginInit();
            this.gpcLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvLogs)).BeginInit();
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
            // gpcLogs
            // 
            this.gpcLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcLogs.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcLogs.AppearanceCaption.Options.UseFont = true;
            this.gpcLogs.Controls.Add(this.grdLogs);
            this.gpcLogs.Location = new System.Drawing.Point(12, 12);
            this.gpcLogs.Name = "gpcLogs";
            this.gpcLogs.Padding = new System.Windows.Forms.Padding(3);
            this.gpcLogs.Size = new System.Drawing.Size(648, 417);
            this.gpcLogs.TabIndex = 0;
            this.gpcLogs.Text = "日志";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(666, 399);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdLogs
            // 
            this.grdLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogs.Location = new System.Drawing.Point(5, 31);
            this.grdLogs.MainView = this.grdvLogs;
            this.grdLogs.Name = "grdLogs";
            this.grdLogs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdLogs.Size = new System.Drawing.Size(638, 381);
            this.grdLogs.TabIndex = 0;
            this.grdLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvLogs});
            // 
            // grdvLogs
            // 
            this.grdvLogs.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvLogs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvLogs.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvLogs.Appearance.Row.Options.UseFont = true;
            this.grdvLogs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnTime,
            this.grdclmnMessage});
            this.grdvLogs.GridControl = this.grdLogs;
            this.grdvLogs.Name = "grdvLogs";
            this.grdvLogs.OptionsBehavior.Editable = false;
            this.grdvLogs.OptionsCustomization.AllowRowSizing = true;
            this.grdvLogs.OptionsView.ColumnAutoWidth = false;
            this.grdvLogs.OptionsView.RowAutoHeight = true;
            this.grdvLogs.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnTime
            // 
            this.grdclmnTime.Caption = "时间";
            this.grdclmnTime.DisplayFormat.FormatString = "g";
            this.grdclmnTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grdclmnTime.FieldName = "Time";
            this.grdclmnTime.Name = "grdclmnTime";
            this.grdclmnTime.Visible = true;
            this.grdclmnTime.VisibleIndex = 0;
            this.grdclmnTime.Width = 172;
            // 
            // grdclmnMessage
            // 
            this.grdclmnMessage.Caption = "日志信息";
            this.grdclmnMessage.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnMessage.FieldName = "ErrText";
            this.grdclmnMessage.Name = "grdclmnMessage";
            this.grdclmnMessage.Visible = true;
            this.grdclmnMessage.VisibleIndex = 1;
            this.grdclmnMessage.Width = 432;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // frmShowErrorLogs
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(763, 443);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpcLogs);
            this.Name = "frmShowErrorLogs";
            this.Text = "查看日志信息";
            ((System.ComponentModel.ISupportInitialize)(this.gpcLogs)).EndInit();
            this.gpcLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpcLogs;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.GridControl grdLogs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvLogs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMessage;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}
