namespace IRAP.Client.GUI.MESPDC
{
    partial class frmUDFForm1Ex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUDFForm1Ex));
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.xucIRAPListView = new IRAP.Client.Global.GUI.xucIRAPListView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            resources.ApplyResources(this.lblFuncName, "lblFuncName");
            this.lblFuncName.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblFuncName.Appearance.Font")));
            this.lblFuncName.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblFuncName.Appearance.FontSizeDelta")));
            this.lblFuncName.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblFuncName.Appearance.FontStyleDelta")));
            this.lblFuncName.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblFuncName.Appearance.ForeColor")));
            this.lblFuncName.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblFuncName.Appearance.GradientMode")));
            this.lblFuncName.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblFuncName.Appearance.Image")));
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // panelControl1
            // 
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.toolTipController.SetAllowHtmlText(this.panelControl1, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("panelControl1.AllowHtmlText"))));
            this.toolTipController.SetTitle(this.panelControl1, resources.GetString("panelControl1.Title"));
            this.toolTipController.SetToolTip(this.panelControl1, resources.GetString("panelControl1.ToolTip"));
            this.toolTipController.SetToolTipIconType(this.panelControl1, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("panelControl1.ToolTipIconType"))));
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
            // pnlBody
            // 
            resources.ApplyResources(this.pnlBody, "pnlBody");
            this.toolTipController.SetAllowHtmlText(this.pnlBody, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("pnlBody.AllowHtmlText"))));
            this.pnlBody.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pnlBody.Appearance.BackColor")));
            this.pnlBody.Appearance.FontSizeDelta = ((int)(resources.GetObject("pnlBody.Appearance.FontSizeDelta")));
            this.pnlBody.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("pnlBody.Appearance.FontStyleDelta")));
            this.pnlBody.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("pnlBody.Appearance.GradientMode")));
            this.pnlBody.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("pnlBody.Appearance.Image")));
            this.pnlBody.Appearance.Options.UseBackColor = true;
            this.pnlBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBody.Controls.Add(this.xucIRAPListView);
            this.pnlBody.Name = "pnlBody";
            this.toolTipController.SetTitle(this.pnlBody, resources.GetString("pnlBody.Title"));
            this.toolTipController.SetToolTip(this.pnlBody, resources.GetString("pnlBody.ToolTip"));
            this.toolTipController.SetToolTipIconType(this.pnlBody, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("pnlBody.ToolTipIconType"))));
            // 
            // xucIRAPListView
            // 
            resources.ApplyResources(this.xucIRAPListView, "xucIRAPListView");
            this.toolTipController.SetAllowHtmlText(this.xucIRAPListView, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("xucIRAPListView.AllowHtmlText"))));
            this.xucIRAPListView.Caption = "操作日志";
            this.xucIRAPListView.MaxLineNumber = 1000;
            this.xucIRAPListView.Name = "xucIRAPListView";
            this.toolTipController.SetTitle(this.xucIRAPListView, resources.GetString("xucIRAPListView.Title"));
            this.toolTipController.SetToolTip(this.xucIRAPListView, resources.GetString("xucIRAPListView.ToolTip"));
            this.toolTipController.SetToolTipIconType(this.xucIRAPListView, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("xucIRAPListView.ToolTipIconType"))));
            // 
            // frmUDFForm1Ex
            // 
            resources.ApplyResources(this, "$this");
            this.toolTipController.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("frmUDFForm1Ex.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("frmUDFForm1Ex.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("frmUDFForm1Ex.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmUDFForm1Ex.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.pnlBody);
            this.Name = "frmUDFForm1Ex";
            this.toolTipController.SetTitle(this, resources.GetString("$this.Title"));
            this.toolTipController.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.toolTipController.SetToolTipIconType(this, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("$this.ToolTipIconType"))));
            this.Activated += new System.EventHandler(this.frmUDFForm1Ex_Activated);
            this.Shown += new System.EventHandler(this.frmUDFForm1Ex_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBody;
        private Global.GUI.xucIRAPListView xucIRAPListView;
    }
}
