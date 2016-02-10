namespace IRAP.Client.Global.GUI
{
    partial class frmCustomKanbanBase
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
            this.picConnectionStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblFuncName)).BeginInit();
            this.lblFuncName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConnectionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Controls.Add(this.picConnectionStatus);
            this.lblFuncName.Size = new System.Drawing.Size(907, 56);
            this.lblFuncName.Text = "frmCustomBase";
            // 
            // picConnectionStatus
            // 
            this.picConnectionStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picConnectionStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.picConnectionStatus.Location = new System.Drawing.Point(847, 0);
            this.picConnectionStatus.Name = "picConnectionStatus";
            this.picConnectionStatus.Size = new System.Drawing.Size(60, 56);
            this.picConnectionStatus.TabIndex = 0;
            this.picConnectionStatus.TabStop = false;
            this.picConnectionStatus.Click += new System.EventHandler(this.picConnectionStatus_Click);
            // 
            // frmCustomKanbanBase
            // 
            this.ClientSize = new System.Drawing.Size(907, 513);
            this.Name = "frmCustomKanbanBase";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Activated += new System.EventHandler(this.frmCustomKanbanBase_Activated);
            this.Shown += new System.EventHandler(this.frmCustomKanbanBase_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.lblFuncName)).EndInit();
            this.lblFuncName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picConnectionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picConnectionStatus;
    }
}
