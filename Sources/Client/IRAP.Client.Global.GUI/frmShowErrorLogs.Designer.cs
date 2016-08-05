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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowErrorLogs));
            this.gpcLogs = new DevExpress.XtraEditors.GroupControl();
            this.grdLogs = new DevExpress.XtraGrid.GridControl();
            this.grdvLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gpcLogs)).BeginInit();
            this.gpcLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.FontSizeDelta = ((int)(resources.GetObject("toolTipController.Appearance.FontSizeDelta")));
            this.toolTipController.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("toolTipController.Appearance.FontStyleDelta")));
            this.toolTipController.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("toolTipController.Appearance.GradientMode")));
            this.toolTipController.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("toolTipController.Appearance.Image")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.FontSizeDelta = ((int)(resources.GetObject("toolTipController.AppearanceTitle.FontSizeDelta")));
            this.toolTipController.AppearanceTitle.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("toolTipController.AppearanceTitle.FontStyleDelta")));
            this.toolTipController.AppearanceTitle.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("toolTipController.AppearanceTitle.GradientMode")));
            this.toolTipController.AppearanceTitle.Image = ((System.Drawing.Image)(resources.GetObject("toolTipController.AppearanceTitle.Image")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // gpcLogs
            // 
            resources.ApplyResources(this.gpcLogs, "gpcLogs");
            this.gpcLogs.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("gpcLogs.AppearanceCaption.Font")));
            this.gpcLogs.AppearanceCaption.FontSizeDelta = ((int)(resources.GetObject("gpcLogs.AppearanceCaption.FontSizeDelta")));
            this.gpcLogs.AppearanceCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gpcLogs.AppearanceCaption.FontStyleDelta")));
            this.gpcLogs.AppearanceCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gpcLogs.AppearanceCaption.GradientMode")));
            this.gpcLogs.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("gpcLogs.AppearanceCaption.Image")));
            this.gpcLogs.AppearanceCaption.Options.UseFont = true;
            this.gpcLogs.Controls.Add(this.grdLogs);
            this.gpcLogs.Name = "gpcLogs";
            // 
            // grdLogs
            // 
            resources.ApplyResources(this.grdLogs, "grdLogs");
            this.grdLogs.EmbeddedNavigator.AccessibleDescription = resources.GetString("grdLogs.EmbeddedNavigator.AccessibleDescription");
            this.grdLogs.EmbeddedNavigator.AccessibleName = resources.GetString("grdLogs.EmbeddedNavigator.AccessibleName");
            this.grdLogs.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("grdLogs.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.grdLogs.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("grdLogs.EmbeddedNavigator.Anchor")));
            this.grdLogs.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grdLogs.EmbeddedNavigator.BackgroundImage")));
            this.grdLogs.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("grdLogs.EmbeddedNavigator.BackgroundImageLayout")));
            this.grdLogs.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("grdLogs.EmbeddedNavigator.ImeMode")));
            this.grdLogs.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("grdLogs.EmbeddedNavigator.MaximumSize")));
            this.grdLogs.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("grdLogs.EmbeddedNavigator.TextLocation")));
            this.grdLogs.EmbeddedNavigator.ToolTip = resources.GetString("grdLogs.EmbeddedNavigator.ToolTip");
            this.grdLogs.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("grdLogs.EmbeddedNavigator.ToolTipIconType")));
            this.grdLogs.EmbeddedNavigator.ToolTipTitle = resources.GetString("grdLogs.EmbeddedNavigator.ToolTipTitle");
            this.grdLogs.MainView = this.grdvLogs;
            this.grdLogs.Name = "grdLogs";
            this.grdLogs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvLogs});
            // 
            // grdvLogs
            // 
            this.grdvLogs.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("grdvLogs.Appearance.HeaderPanel.Font")));
            this.grdvLogs.Appearance.HeaderPanel.FontSizeDelta = ((int)(resources.GetObject("grdvLogs.Appearance.HeaderPanel.FontSizeDelta")));
            this.grdvLogs.Appearance.HeaderPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdvLogs.Appearance.HeaderPanel.FontStyleDelta")));
            this.grdvLogs.Appearance.HeaderPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdvLogs.Appearance.HeaderPanel.GradientMode")));
            this.grdvLogs.Appearance.HeaderPanel.Image = ((System.Drawing.Image)(resources.GetObject("grdvLogs.Appearance.HeaderPanel.Image")));
            this.grdvLogs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvLogs.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("grdvLogs.Appearance.Row.Font")));
            this.grdvLogs.Appearance.Row.FontSizeDelta = ((int)(resources.GetObject("grdvLogs.Appearance.Row.FontSizeDelta")));
            this.grdvLogs.Appearance.Row.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdvLogs.Appearance.Row.FontStyleDelta")));
            this.grdvLogs.Appearance.Row.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdvLogs.Appearance.Row.GradientMode")));
            this.grdvLogs.Appearance.Row.Image = ((System.Drawing.Image)(resources.GetObject("grdvLogs.Appearance.Row.Image")));
            this.grdvLogs.Appearance.Row.Options.UseFont = true;
            resources.ApplyResources(this.grdvLogs, "grdvLogs");
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
            this.grdclmnTime.AppearanceCell.FontSizeDelta = ((int)(resources.GetObject("grdclmnTime.AppearanceCell.FontSizeDelta")));
            this.grdclmnTime.AppearanceCell.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnTime.AppearanceCell.FontStyleDelta")));
            this.grdclmnTime.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnTime.AppearanceCell.GradientMode")));
            this.grdclmnTime.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnTime.AppearanceCell.Image")));
            this.grdclmnTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnTime.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnTime.AppearanceHeader.FontSizeDelta")));
            this.grdclmnTime.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnTime.AppearanceHeader.FontStyleDelta")));
            this.grdclmnTime.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnTime.AppearanceHeader.GradientMode")));
            this.grdclmnTime.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnTime.AppearanceHeader.Image")));
            this.grdclmnTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnTime, "grdclmnTime");
            this.grdclmnTime.DisplayFormat.FormatString = "g";
            this.grdclmnTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grdclmnTime.FieldName = "Time";
            this.grdclmnTime.Name = "grdclmnTime";
            this.grdclmnTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnMessage
            // 
            this.grdclmnMessage.AppearanceHeader.FontSizeDelta = ((int)(resources.GetObject("grdclmnMessage.AppearanceHeader.FontSizeDelta")));
            this.grdclmnMessage.AppearanceHeader.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdclmnMessage.AppearanceHeader.FontStyleDelta")));
            this.grdclmnMessage.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdclmnMessage.AppearanceHeader.GradientMode")));
            this.grdclmnMessage.AppearanceHeader.Image = ((System.Drawing.Image)(resources.GetObject("grdclmnMessage.AppearanceHeader.Image")));
            this.grdclmnMessage.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMessage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMessage.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnMessage, "grdclmnMessage");
            this.grdclmnMessage.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnMessage.FieldName = "ErrText";
            this.grdclmnMessage.Name = "grdclmnMessage";
            this.grdclmnMessage.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // repositoryItemMemoEdit1
            // 
            resources.ApplyResources(this.repositoryItemMemoEdit1, "repositoryItemMemoEdit1");
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnClose.Appearance.Font")));
            this.btnClose.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnClose.Appearance.FontSizeDelta")));
            this.btnClose.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnClose.Appearance.FontStyleDelta")));
            this.btnClose.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnClose.Appearance.GradientMode")));
            this.btnClose.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Appearance.Image")));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowErrorLogs
            // 
            resources.ApplyResources(this, "$this");
            this.toolTipController.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("frmShowErrorLogs.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("frmShowErrorLogs.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("frmShowErrorLogs.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmShowErrorLogs.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpcLogs);
            this.Name = "frmShowErrorLogs";
            this.toolTipController.SetTitle(this, resources.GetString("$this.Title"));
            this.toolTipController.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.toolTipController.SetToolTipIconType(this, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("$this.ToolTipIconType"))));
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
