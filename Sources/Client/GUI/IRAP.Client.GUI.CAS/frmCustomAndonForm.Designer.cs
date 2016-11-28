namespace IRAP.Client.GUI.CAS
{
    partial class frmCustomAndonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomAndonForm));
            this.lblProductionLine = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblFuncName.Appearance.Font")));
            this.lblFuncName.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblFuncName.Appearance.ForeColor")));
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.lblFuncName, "lblFuncName");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblProductionLine);
            this.panelControl1.Controls.SetChildIndex(this.lblFuncName, 0);
            this.panelControl1.Controls.SetChildIndex(this.lblProductionLine, 0);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // lblProductionLine
            // 
            this.lblProductionLine.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lblProductionLine.Appearance.BackColor")));
            this.lblProductionLine.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblProductionLine.Appearance.Font")));
            this.lblProductionLine.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblProductionLine.Appearance.ForeColor")));
            this.lblProductionLine.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblProductionLine.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblProductionLine.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblProductionLine, "lblProductionLine");
            this.lblProductionLine.Name = "lblProductionLine";
            // 
            // frmCustomAndonForm
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.Name = "frmCustomAndonForm";
            this.Activated += new System.EventHandler(this.frmCustomAndonForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblProductionLine;
    }
}
