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
            this.lblFuncName.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblFuncName.Appearance.Font")));
            this.lblFuncName.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblFuncName.Appearance.ForeColor")));
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.lblFuncName, "lblFuncName");
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // pnlBody
            // 
            this.pnlBody.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pnlBody.Appearance.BackColor")));
            this.pnlBody.Appearance.Options.UseBackColor = true;
            this.pnlBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBody.Controls.Add(this.xucIRAPListView);
            resources.ApplyResources(this.pnlBody, "pnlBody");
            this.pnlBody.Name = "pnlBody";
            // 
            // xucIRAPListView
            // 
            this.xucIRAPListView.Caption = "操作日志";
            resources.ApplyResources(this.xucIRAPListView, "xucIRAPListView");
            this.xucIRAPListView.MaxLineNumber = 1000;
            this.xucIRAPListView.Name = "xucIRAPListView";
            // 
            // frmUDFForm1Ex
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlBody);
            this.Name = "frmUDFForm1Ex";
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
