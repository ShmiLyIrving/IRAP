namespace IRAP.Client.Global.GUI
{
    partial class frmCustomFuncBase
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
            this.lblFuncName = new Telerik.WinControls.UI.RadLabel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lblFuncName)).BeginInit();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.AutoSize = false;
            this.lblFuncName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFuncName.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Location = new System.Drawing.Point(0, 0);
            this.lblFuncName.Name = "lblFuncName";
            this.lblFuncName.Size = new System.Drawing.Size(899, 56);
            this.lblFuncName.TabIndex = 0;
            this.lblFuncName.Text = "lblFuncName";
            this.lblFuncName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblFuncName);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(899, 56);
            this.pnlTitle.TabIndex = 2;
            // 
            // frmCustomFuncBase
            // 
            this.ClientSize = new System.Drawing.Size(899, 504);
            this.Controls.Add(this.pnlTitle);
            this.Name = "frmCustomFuncBase";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Activated += new System.EventHandler(this.frmCustomFuncBase_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustomFuncBase_FormClosed);
            this.Shown += new System.EventHandler(this.frmCustomFuncBase_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.lblFuncName)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Telerik.WinControls.UI.RadLabel lblFuncName;
        private System.Windows.Forms.Panel pnlTitle;
    }
}
