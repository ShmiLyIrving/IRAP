namespace IRAP.Client.GUI.MDM
{
    partial class frmCustomProperites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomProperites));
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnlWorkFlowCommand = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.chkEffectiveType = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkFlowCommand)).BeginInit();
            this.pnlWorkFlowCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
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
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lblTitle.Appearance.BackColor")));
            this.lblTitle.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblTitle.Appearance.Font")));
            this.lblTitle.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblTitle.Appearance.FontSizeDelta")));
            this.lblTitle.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblTitle.Appearance.FontStyleDelta")));
            this.lblTitle.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblTitle.Appearance.ForeColor")));
            this.lblTitle.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblTitle.Appearance.GradientMode")));
            this.lblTitle.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblTitle.Appearance.Image")));
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTitle.Name = "lblTitle";
            // 
            // pnlWorkFlowCommand
            // 
            resources.ApplyResources(this.pnlWorkFlowCommand, "pnlWorkFlowCommand");
            this.toolTipController.SetAllowHtmlText(this.pnlWorkFlowCommand, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("pnlWorkFlowCommand.AllowHtmlText"))));
            this.pnlWorkFlowCommand.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlWorkFlowCommand.Controls.Add(this.btnSave);
            this.pnlWorkFlowCommand.Controls.Add(this.chkEffectiveType);
            this.pnlWorkFlowCommand.Controls.Add(this.btnCancel);
            this.pnlWorkFlowCommand.Name = "pnlWorkFlowCommand";
            this.toolTipController.SetTitle(this.pnlWorkFlowCommand, resources.GetString("pnlWorkFlowCommand.Title"));
            this.toolTipController.SetToolTip(this.pnlWorkFlowCommand, resources.GetString("pnlWorkFlowCommand.ToolTip"));
            this.toolTipController.SetToolTipIconType(this.pnlWorkFlowCommand, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("pnlWorkFlowCommand.ToolTipIconType"))));
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnSave.Appearance.Font")));
            this.btnSave.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnSave.Appearance.FontSizeDelta")));
            this.btnSave.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnSave.Appearance.FontStyleDelta")));
            this.btnSave.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnSave.Appearance.GradientMode")));
            this.btnSave.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Appearance.Image")));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkEffectiveType
            // 
            resources.ApplyResources(this.chkEffectiveType, "chkEffectiveType");
            this.chkEffectiveType.Name = "chkEffectiveType";
            this.chkEffectiveType.Properties.AccessibleDescription = resources.GetString("chkEffectiveType.Properties.AccessibleDescription");
            this.chkEffectiveType.Properties.AccessibleName = resources.GetString("chkEffectiveType.Properties.AccessibleName");
            this.chkEffectiveType.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("chkEffectiveType.Properties.Appearance.Font")));
            this.chkEffectiveType.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("chkEffectiveType.Properties.Appearance.FontSizeDelta")));
            this.chkEffectiveType.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("chkEffectiveType.Properties.Appearance.FontStyleDelta")));
            this.chkEffectiveType.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("chkEffectiveType.Properties.Appearance.GradientMode")));
            this.chkEffectiveType.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("chkEffectiveType.Properties.Appearance.Image")));
            this.chkEffectiveType.Properties.Appearance.Options.UseFont = true;
            this.chkEffectiveType.Properties.Appearance.Options.UseTextOptions = true;
            this.chkEffectiveType.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.chkEffectiveType.Properties.AutoHeight = ((bool)(resources.GetObject("chkEffectiveType.Properties.AutoHeight")));
            this.chkEffectiveType.Properties.Caption = resources.GetString("chkEffectiveType.Properties.Caption");
            this.chkEffectiveType.Properties.DisplayValueChecked = resources.GetString("chkEffectiveType.Properties.DisplayValueChecked");
            this.chkEffectiveType.Properties.DisplayValueGrayed = resources.GetString("chkEffectiveType.Properties.DisplayValueGrayed");
            this.chkEffectiveType.Properties.DisplayValueUnchecked = resources.GetString("chkEffectiveType.Properties.DisplayValueUnchecked");
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
            // frmCustomProperites
            // 
            resources.ApplyResources(this, "$this");
            this.toolTipController.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("frmCustomProperites.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("frmCustomProperites.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("frmCustomProperites.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmCustomProperites.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.pnlWorkFlowCommand);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "frmCustomProperites";
            this.toolTipController.SetTitle(this, resources.GetString("$this.Title"));
            this.toolTipController.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.toolTipController.SetToolTipIconType(this, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("$this.ToolTipIconType"))));
            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkFlowCommand)).EndInit();
            this.pnlWorkFlowCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnlWorkFlowCommand;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        protected DevExpress.XtraEditors.LabelControl lblTitle;
        protected DevExpress.XtraEditors.SimpleButton btnSave;
        protected DevExpress.XtraEditors.CheckEdit chkEffectiveType;
    }
}
