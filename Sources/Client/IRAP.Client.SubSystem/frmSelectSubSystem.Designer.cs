namespace IRAP.Client.SubSystem
{
    partial class frmSelectSubSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectSubSystem));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lstSubSystems = new DevExpress.XtraEditors.ListBoxControl();
            this.btnQuit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstSubSystems)).BeginInit();
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
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("groupControl1.AppearanceCaption.Font")));
            this.groupControl1.AppearanceCaption.FontSizeDelta = ((int)(resources.GetObject("groupControl1.AppearanceCaption.FontSizeDelta")));
            this.groupControl1.AppearanceCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("groupControl1.AppearanceCaption.FontStyleDelta")));
            this.groupControl1.AppearanceCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("groupControl1.AppearanceCaption.GradientMode")));
            this.groupControl1.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.AppearanceCaption.Image")));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.lstSubSystems);
            this.groupControl1.Name = "groupControl1";
            // 
            // lstSubSystems
            // 
            resources.ApplyResources(this.lstSubSystems, "lstSubSystems");
            this.lstSubSystems.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lstSubSystems.Appearance.Font")));
            this.lstSubSystems.Appearance.FontSizeDelta = ((int)(resources.GetObject("lstSubSystems.Appearance.FontSizeDelta")));
            this.lstSubSystems.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lstSubSystems.Appearance.FontStyleDelta")));
            this.lstSubSystems.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lstSubSystems.Appearance.GradientMode")));
            this.lstSubSystems.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lstSubSystems.Appearance.Image")));
            this.lstSubSystems.Appearance.Options.UseFont = true;
            this.lstSubSystems.Name = "lstSubSystems";
            this.lstSubSystems.Click += new System.EventHandler(this.lstSubSystems_Click);
            this.lstSubSystems.DoubleClick += new System.EventHandler(this.lstSubSystems_DoubleClick);
            // 
            // btnQuit
            // 
            resources.ApplyResources(this.btnQuit, "btnQuit");
            this.btnQuit.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnQuit.Appearance.Font")));
            this.btnQuit.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnQuit.Appearance.FontSizeDelta")));
            this.btnQuit.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnQuit.Appearance.FontStyleDelta")));
            this.btnQuit.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnQuit.Appearance.GradientMode")));
            this.btnQuit.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Appearance.Image")));
            this.btnQuit.Appearance.Options.UseFont = true;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSelect
            // 
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnSelect.Appearance.Font")));
            this.btnSelect.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnSelect.Appearance.FontSizeDelta")));
            this.btnSelect.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnSelect.Appearance.FontStyleDelta")));
            this.btnSelect.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnSelect.Appearance.GradientMode")));
            this.btnSelect.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Appearance.Image")));
            this.btnSelect.Appearance.Options.UseFont = true;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmSelectSubSystem
            // 
            resources.ApplyResources(this, "$this");
            this.toolTipController.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("frmSelectSubSystem.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("frmSelectSubSystem.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("frmSelectSubSystem.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmSelectSubSystem.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnQuit;
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmSelectSubSystem";
            this.ShowInTaskbar = true;
            this.toolTipController.SetTitle(this, resources.GetString("$this.Title"));
            this.toolTipController.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.toolTipController.SetToolTipIconType(this, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("$this.ToolTipIconType"))));
            this.Load += new System.EventHandler(this.frmSelectSubSystem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSubSystems_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstSubSystems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ListBoxControl lstSubSystems;
        private DevExpress.XtraEditors.SimpleButton btnQuit;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
    }
}
