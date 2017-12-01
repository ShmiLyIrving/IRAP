namespace OPCClient.UserContols
{
    partial class ucOPCMonitor
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
            this.tcOPCMonitors = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcOPCMonitors)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTitle.Size = new System.Drawing.Size(836, 40);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.tcOPCMonitors);
            this.pnlBody.Size = new System.Drawing.Size(836, 541);
            // 
            // tcOPCMonitors
            // 
            this.tcOPCMonitors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOPCMonitors.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.tcOPCMonitors.Location = new System.Drawing.Point(12, 12);
            this.tcOPCMonitors.Name = "tcOPCMonitors";
            this.tcOPCMonitors.Size = new System.Drawing.Size(812, 517);
            this.tcOPCMonitors.TabIndex = 0;
            // 
            // ucOPCMonitor
            // 
            this.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.Name = "ucOPCMonitor";
            this.Size = new System.Drawing.Size(836, 581);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcOPCMonitors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcOPCMonitors;
    }
}
