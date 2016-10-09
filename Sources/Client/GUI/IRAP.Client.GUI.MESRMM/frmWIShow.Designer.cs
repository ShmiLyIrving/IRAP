namespace IRAP.Client.GUI.MESRMM
{
    partial class frmWIShow
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
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpProductWI = new DevExpress.XtraTab.XtraTabPage();
            this.wbProductWIShow = new System.Windows.Forms.WebBrowser();
            this.tpProductSerialWI = new DevExpress.XtraTab.XtraTabPage();
            this.wbProductSerialWIShow = new System.Windows.Forms.WebBrowser();
            this.tpGeneralWI = new DevExpress.XtraTab.XtraTabPage();
            this.wbGeneralWIShow = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpProductWI.SuspendLayout();
            this.tpProductSerialWI.SuspendLayout();
            this.tpGeneralWI.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "作业指导书";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // tcMain
            // 
            this.tcMain.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.Appearance.Options.UseFont = true;
            this.tcMain.AppearancePage.Header.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.AppearancePage.Header.Options.UseFont = true;
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 56);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpProductWI;
            this.tcMain.Size = new System.Drawing.Size(891, 439);
            this.tcMain.TabIndex = 1;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpProductWI,
            this.tpProductSerialWI,
            this.tpGeneralWI});
            // 
            // tpProductWI
            // 
            this.tpProductWI.Controls.Add(this.wbProductWIShow);
            this.tpProductWI.Name = "tpProductWI";
            this.tpProductWI.Size = new System.Drawing.Size(885, 408);
            this.tpProductWI.Text = "产品作业指导书";
            // 
            // wbProductWIShow
            // 
            this.wbProductWIShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbProductWIShow.Location = new System.Drawing.Point(0, 0);
            this.wbProductWIShow.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbProductWIShow.Name = "wbProductWIShow";
            this.wbProductWIShow.Size = new System.Drawing.Size(885, 408);
            this.wbProductWIShow.TabIndex = 0;
            // 
            // tpProductSerialWI
            // 
            this.tpProductSerialWI.Controls.Add(this.wbProductSerialWIShow);
            this.tpProductSerialWI.Name = "tpProductSerialWI";
            this.tpProductSerialWI.Size = new System.Drawing.Size(885, 408);
            this.tpProductSerialWI.Text = "产品系列作业指导书";
            // 
            // wbProductSerialWIShow
            // 
            this.wbProductSerialWIShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbProductSerialWIShow.Location = new System.Drawing.Point(0, 0);
            this.wbProductSerialWIShow.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbProductSerialWIShow.Name = "wbProductSerialWIShow";
            this.wbProductSerialWIShow.Size = new System.Drawing.Size(885, 408);
            this.wbProductSerialWIShow.TabIndex = 0;
            // 
            // tpGeneralWI
            // 
            this.tpGeneralWI.Controls.Add(this.wbGeneralWIShow);
            this.tpGeneralWI.Name = "tpGeneralWI";
            this.tpGeneralWI.Size = new System.Drawing.Size(885, 408);
            this.tpGeneralWI.Text = "通用作业指导书";
            // 
            // wbGeneralWIShow
            // 
            this.wbGeneralWIShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbGeneralWIShow.Location = new System.Drawing.Point(0, 0);
            this.wbGeneralWIShow.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbGeneralWIShow.Name = "wbGeneralWIShow";
            this.wbGeneralWIShow.Size = new System.Drawing.Size(885, 408);
            this.wbGeneralWIShow.TabIndex = 0;
            // 
            // frmWIShow
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.tcMain);
            this.Name = "frmWIShow";
            this.Text = "作业指导书";
            this.Activated += new System.EventHandler(this.frmWIShow_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmWIShow_FormClosed);
            this.Shown += new System.EventHandler(this.frmWIShow_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.tcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpProductWI.ResumeLayout(false);
            this.tpProductSerialWI.ResumeLayout(false);
            this.tpGeneralWI.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpProductWI;
        private System.Windows.Forms.WebBrowser wbProductWIShow;
        private DevExpress.XtraTab.XtraTabPage tpProductSerialWI;
        private System.Windows.Forms.WebBrowser wbProductSerialWIShow;
        private DevExpress.XtraTab.XtraTabPage tpGeneralWI;
        private System.Windows.Forms.WebBrowser wbGeneralWIShow;
    }
}
