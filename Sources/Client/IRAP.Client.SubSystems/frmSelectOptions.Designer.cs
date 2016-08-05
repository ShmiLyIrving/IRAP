namespace IRAP.Client.SubSystems
{
    partial class frmSelectOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectOptions));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lstProcesses = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lstWorkUnits = new DevExpress.XtraEditors.ListBoxControl();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstProcesses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstWorkUnits)).BeginInit();
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
            this.groupControl1.Controls.Add(this.lstProcesses);
            this.groupControl1.Name = "groupControl1";
            // 
            // lstProcesses
            // 
            resources.ApplyResources(this.lstProcesses, "lstProcesses");
            this.lstProcesses.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lstProcesses.Appearance.Font")));
            this.lstProcesses.Appearance.FontSizeDelta = ((int)(resources.GetObject("lstProcesses.Appearance.FontSizeDelta")));
            this.lstProcesses.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lstProcesses.Appearance.FontStyleDelta")));
            this.lstProcesses.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lstProcesses.Appearance.GradientMode")));
            this.lstProcesses.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lstProcesses.Appearance.Image")));
            this.lstProcesses.Appearance.Options.UseFont = true;
            this.lstProcesses.Name = "lstProcesses";
            this.lstProcesses.SelectedIndexChanged += new System.EventHandler(this.lstProcesses_SelectedIndexChanged);
            // 
            // groupControl2
            // 
            resources.ApplyResources(this.groupControl2, "groupControl2");
            this.groupControl2.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("groupControl2.AppearanceCaption.Font")));
            this.groupControl2.AppearanceCaption.FontSizeDelta = ((int)(resources.GetObject("groupControl2.AppearanceCaption.FontSizeDelta")));
            this.groupControl2.AppearanceCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("groupControl2.AppearanceCaption.FontStyleDelta")));
            this.groupControl2.AppearanceCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("groupControl2.AppearanceCaption.GradientMode")));
            this.groupControl2.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.AppearanceCaption.Image")));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.lstWorkUnits);
            this.groupControl2.Name = "groupControl2";
            // 
            // lstWorkUnits
            // 
            resources.ApplyResources(this.lstWorkUnits, "lstWorkUnits");
            this.lstWorkUnits.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lstWorkUnits.Appearance.Font")));
            this.lstWorkUnits.Appearance.FontSizeDelta = ((int)(resources.GetObject("lstWorkUnits.Appearance.FontSizeDelta")));
            this.lstWorkUnits.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lstWorkUnits.Appearance.FontStyleDelta")));
            this.lstWorkUnits.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lstWorkUnits.Appearance.GradientMode")));
            this.lstWorkUnits.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lstWorkUnits.Appearance.Image")));
            this.lstWorkUnits.Appearance.Options.UseFont = true;
            this.lstWorkUnits.Name = "lstWorkUnits";
            this.lstWorkUnits.Click += new System.EventHandler(this.lstWorkUnits_Click);
            this.lstWorkUnits.DoubleClick += new System.EventHandler(this.lstWorkUnits_DoubleClick);
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
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnCancel.Appearance.Font")));
            this.btnCancel.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnCancel.Appearance.FontSizeDelta")));
            this.btnCancel.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnCancel.Appearance.FontStyleDelta")));
            this.btnCancel.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnCancel.Appearance.GradientMode")));
            this.btnCancel.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Appearance.Image")));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // frmSelectOptions
            // 
            resources.ApplyResources(this, "$this");
            this.toolTipController.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("frmSelectOptions.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("frmSelectOptions.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("frmSelectOptions.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmSelectOptions.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmSelectOptions";
            this.toolTipController.SetTitle(this, resources.GetString("$this.Title"));
            this.toolTipController.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.toolTipController.SetToolTipIconType(this, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("$this.ToolTipIconType"))));
            this.Load += new System.EventHandler(this.frmSelectOptions_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSelectOptions_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstProcesses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstWorkUnits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ListBoxControl lstProcesses;
        private DevExpress.XtraEditors.ListBoxControl lstWorkUnits;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
