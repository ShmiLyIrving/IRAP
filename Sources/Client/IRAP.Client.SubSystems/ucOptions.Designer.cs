namespace IRAP.Client.SubSystems
{
    partial class ucOptions
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cboProcesses = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.cboWorkUnits = new Telerik.WinControls.UI.RadDropDownList();
            this.btnSwitch = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProcesses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSwitch)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(128, 38);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "当前选项【一】";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboProcesses
            // 
            this.cboProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProcesses.Enabled = false;
            this.cboProcesses.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboProcesses.Location = new System.Drawing.Point(134, 6);
            this.cboProcesses.Name = "cboProcesses";
            this.cboProcesses.ReadOnly = true;
            this.cboProcesses.Size = new System.Drawing.Size(150, 24);
            this.cboProcesses.TabIndex = 1;
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.AutoSize = false;
            this.radLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radLabel2.Location = new System.Drawing.Point(290, 0);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(128, 38);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "当前选项【二】";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboWorkUnits
            // 
            this.cboWorkUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWorkUnits.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboWorkUnits.Location = new System.Drawing.Point(424, 6);
            this.cboWorkUnits.Name = "cboWorkUnits";
            this.cboWorkUnits.Size = new System.Drawing.Size(240, 24);
            this.cboWorkUnits.TabIndex = 2;
            // 
            // btnSwitch
            // 
            this.btnSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwitch.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSwitch.Location = new System.Drawing.Point(687, 6);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(85, 24);
            this.btnSwitch.TabIndex = 3;
            this.btnSwitch.TabStop = false;
            this.btnSwitch.Text = "切换";
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // ucOptions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.cboWorkUnits);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.cboProcesses);
            this.Controls.Add(this.radLabel1);
            this.Name = "ucOptions";
            this.Size = new System.Drawing.Size(778, 38);
            this.VisibleChanged += new System.EventHandler(this.ucOptions_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProcesses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSwitch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        public Telerik.WinControls.UI.RadDropDownList cboProcesses;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        public Telerik.WinControls.UI.RadDropDownList cboWorkUnits;
        private Telerik.WinControls.UI.RadButton btnSwitch;
    }
}
