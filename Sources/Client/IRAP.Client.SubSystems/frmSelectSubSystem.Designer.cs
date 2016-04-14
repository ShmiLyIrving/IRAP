namespace IRAP.Client.SubSystems
{
    partial class frmSelectSubSystem
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lstSubSystems = new DevExpress.XtraEditors.ListBoxControl();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstSubSystems)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.lstSubSystems);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(3);
            this.groupControl1.Size = new System.Drawing.Size(417, 301);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "请选择子系统";
            // 
            // lstSubSystems
            // 
            this.lstSubSystems.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSubSystems.Appearance.Options.UseFont = true;
            this.lstSubSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSubSystems.Location = new System.Drawing.Point(5, 31);
            this.lstSubSystems.Name = "lstSubSystems";
            this.lstSubSystems.Size = new System.Drawing.Size(407, 265);
            this.lstSubSystems.TabIndex = 0;
            this.lstSubSystems.Click += new System.EventHandler(this.lstSubSystems_Click);
            this.lstSubSystems.DoubleClick += new System.EventHandler(this.lstSubSystems_DoubleClick);
            this.lstSubSystems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSubSystems_KeyDown);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Appearance.Options.UseFont = true;
            this.btnSelect.Location = new System.Drawing.Point(435, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(91, 30);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Appearance.Options.UseFont = true;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Location = new System.Drawing.Point(435, 283);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(91, 30);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "退出系统";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // frmSelectSubSystem
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(538, 325);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmSelectSubSystem";
            this.ShowInTaskbar = true;
            this.Text = "可用子系统";
            this.Load += new System.EventHandler(this.frmSelectSubSystem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstSubSystems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ListBoxControl lstSubSystems;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.SimpleButton btnQuit;
    }
}
