namespace IRAP.Client.GUI.MESPDC
{
    partial class frmProductionParamsCollection
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(961, 56);
            this.lblFuncName.Text = "生产";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(961, 56);
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
            this.tcMain.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.Appearance.Options.UseFont = true;
            this.tcMain.AppearancePage.Header.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.AppearancePage.Header.Options.UseFont = true;
            this.tcMain.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.Blue;
            this.tcMain.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.tcMain.AppearancePage.HeaderHotTracked.BackColor = System.Drawing.Color.Blue;
            this.tcMain.AppearancePage.HeaderHotTracked.ForeColor = System.Drawing.Color.White;
            this.tcMain.AppearancePage.HeaderHotTracked.Options.UseBackColor = true;
            this.tcMain.AppearancePage.HeaderHotTracked.Options.UseForeColor = true;
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 56);
            this.tcMain.Name = "tcMain";
            this.tcMain.Size = new System.Drawing.Size(961, 541);
            this.tcMain.TabIndex = 1;
            // 
            // frmProductionParamsCollection
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(961, 597);
            this.Controls.Add(this.tcMain);
            this.Name = "frmProductionParamsCollection";
            this.Text = "生产";
            this.Shown += new System.EventHandler(this.frmProductionParamsCollection_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.tcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMain;
    }
}
