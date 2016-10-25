namespace IRAP_FVS_LSSIVO
{
    partial class frmKPIDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBanner = new DevExpress.XtraEditors.PanelControl();
            this.lblServerTime = new DevExpress.XtraEditors.LabelControl();
            this.lblCompanyName = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.timerServerTime = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBanner)).BeginInit();
            this.pnlBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBanner
            // 
            this.pnlBanner.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBanner.Controls.Add(this.lblServerTime);
            this.pnlBanner.Controls.Add(this.lblCompanyName);
            this.pnlBanner.Controls.Add(this.picLogo);
            this.pnlBanner.Controls.Add(this.picBackground);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(5, 5);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(976, 65);
            this.pnlBanner.TabIndex = 0;
            // 
            // lblServerTime
            // 
            this.lblServerTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerTime.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblServerTime.Appearance.Font = new System.Drawing.Font("等线", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblServerTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblServerTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblServerTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblServerTime.Location = new System.Drawing.Point(743, 9);
            this.lblServerTime.Name = "lblServerTime";
            this.lblServerTime.Size = new System.Drawing.Size(211, 47);
            this.lblServerTime.TabIndex = 3;
            this.lblServerTime.Text = "当前时间";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompanyName.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblCompanyName.Appearance.Font = new System.Drawing.Font("等线", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompanyName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCompanyName.Location = new System.Drawing.Point(91, 9);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(635, 47);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "标题";
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = global::IRAP_FVS_LSSIVO.Properties.Resources.gray;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(75, 65);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // picBackground
            // 
            this.picBackground.BackgroundImage = global::IRAP_FVS_LSSIVO.Properties.Resources.gray;
            this.picBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBackground.ContextMenuStrip = this.contextMenuStrip;
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(976, 65);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 0;
            this.picBackground.TabStop = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackgroundImage = global::IRAP_FVS_LSSIVO.Properties.Resources.gray;
            this.contextMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiClose});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(117, 26);
            // 
            // smiClose
            // 
            this.smiClose.Name = "smiClose";
            this.smiClose.Size = new System.Drawing.Size(116, 22);
            this.smiClose.Text = "关闭(&C)";
            this.smiClose.Click += new System.EventHandler(this.smiClose_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.ContextMenuStrip = this.contextMenuStrip;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(5, 70);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(976, 639);
            this.pnlBody.TabIndex = 1;
            this.pnlBody.Resize += new System.EventHandler(this.pnlBody_Resize);
            // 
            // timerServerTime
            // 
            this.timerServerTime.Enabled = true;
            this.timerServerTime.Interval = 1000;
            this.timerServerTime.Tick += new System.EventHandler(this.timerServerTime_Tick);
            // 
            // frmKPIDashboard
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(986, 714);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBanner);
            this.Font = new System.Drawing.Font("等线", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmKPIDashboard";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmOEEDashboard_Load);
            this.Shown += new System.EventHandler(this.frmOEEDashboard_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBanner)).EndInit();
            this.pnlBanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBanner;
        private System.Windows.Forms.PictureBox picBackground;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem smiClose;
        private System.Windows.Forms.PictureBox picLogo;
        private DevExpress.XtraEditors.LabelControl lblServerTime;
        private DevExpress.XtraEditors.LabelControl lblCompanyName;
        private System.Windows.Forms.Timer timerServerTime;
    }
}