namespace IRAP.Client.GUI.CAS
{
    partial class frmAndonEventCall_30
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAndonEventCall_30));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.tcAndon = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.picGreen = new System.Windows.Forms.PictureBox();
            this.picYellow = new System.Windows.Forms.PictureBox();
            this.picRed = new System.Windows.Forms.PictureBox();
            this.picLights = new System.Windows.Forms.PictureBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.tmrRefreshLight = new System.Windows.Forms.Timer(this.components);
            this.tmrGetAndonEventStatus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcAndon)).BeginInit();
            this.tcAndon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "安灯呼叫";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 56);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(891, 439);
            this.panelControl2.TabIndex = 2;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.tcAndon);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(793, 439);
            this.panelControl4.TabIndex = 1;
            // 
            // tcAndon
            // 
            this.tcAndon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcAndon.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.tcAndon.Location = new System.Drawing.Point(12, 12);
            this.tcAndon.Margin = new System.Windows.Forms.Padding(10);
            this.tcAndon.Name = "tcAndon";
            this.tcAndon.SelectedTabPage = this.xtraTabPage1;
            this.tcAndon.Size = new System.Drawing.Size(768, 417);
            this.tcAndon.TabIndex = 0;
            this.tcAndon.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5,
            this.xtraTabPage6,
            this.xtraTabPage7});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(762, 398);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(762, 398);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(762, 398);
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(762, 398);
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(762, 398);
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(762, 398);
            // 
            // xtraTabPage7
            // 
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new System.Drawing.Size(762, 398);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.picGreen);
            this.panelControl3.Controls.Add(this.picYellow);
            this.panelControl3.Controls.Add(this.picRed);
            this.panelControl3.Controls.Add(this.picLights);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(793, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(98, 439);
            this.panelControl3.TabIndex = 0;
            // 
            // picGreen
            // 
            this.picGreen.BackColor = System.Drawing.Color.Transparent;
            this.picGreen.Image = global::IRAP.Client.GUI.CAS.Properties.Resources.绿色;
            this.picGreen.Location = new System.Drawing.Point(21, 161);
            this.picGreen.Name = "picGreen";
            this.picGreen.Size = new System.Drawing.Size(48, 48);
            this.picGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picGreen.TabIndex = 3;
            this.picGreen.TabStop = false;
            // 
            // picYellow
            // 
            this.picYellow.BackColor = System.Drawing.Color.Transparent;
            this.picYellow.Image = global::IRAP.Client.GUI.CAS.Properties.Resources.黄色;
            this.picYellow.Location = new System.Drawing.Point(21, 91);
            this.picYellow.Name = "picYellow";
            this.picYellow.Size = new System.Drawing.Size(48, 48);
            this.picYellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picYellow.TabIndex = 2;
            this.picYellow.TabStop = false;
            // 
            // picRed
            // 
            this.picRed.BackColor = System.Drawing.Color.Transparent;
            this.picRed.Image = global::IRAP.Client.GUI.CAS.Properties.Resources.红色;
            this.picRed.Location = new System.Drawing.Point(21, 22);
            this.picRed.Name = "picRed";
            this.picRed.Size = new System.Drawing.Size(48, 48);
            this.picRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRed.TabIndex = 1;
            this.picRed.TabStop = false;
            // 
            // picLights
            // 
            this.picLights.Image = global::IRAP.Client.GUI.CAS.Properties.Resources.Light;
            this.picLights.Location = new System.Drawing.Point(4, 3);
            this.picLights.Name = "picLights";
            this.picLights.Size = new System.Drawing.Size(90, 228);
            this.picLights.TabIndex = 0;
            this.picLights.TabStop = false;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::IRAP.Client.GUI.CAS.Properties.Resources.灰色, "灰色", typeof(global::IRAP.Client.GUI.CAS.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "灰色");
            // 
            // tmrRefreshLight
            // 
            this.tmrRefreshLight.Interval = 500;
            this.tmrRefreshLight.Tick += new System.EventHandler(this.tmrRefreshLight_Tick);
            // 
            // tmrGetAndonEventStatus
            // 
            this.tmrGetAndonEventStatus.Interval = 10000;
            this.tmrGetAndonEventStatus.Tick += new System.EventHandler(this.tmrGetAndonEventStatus_Tick);
            // 
            // frmAndonEventCall_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.panelControl2);
            this.Name = "frmAndonEventCall_30";
            this.Text = "安灯呼叫";
            this.Activated += new System.EventHandler(this.frmAndonEventCall_30_Activated);
            this.Shown += new System.EventHandler(this.frmAndonEventCall_30_Shown);
            this.Resize += new System.EventHandler(this.frmAndonEventCall_30_Resize);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcAndon)).EndInit();
            this.tcAndon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.PictureBox picLights;
        private DevExpress.XtraTab.XtraTabControl tcAndon;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage7;
        private System.Windows.Forms.PictureBox picGreen;
        private System.Windows.Forms.PictureBox picYellow;
        private System.Windows.Forms.PictureBox picRed;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.Timer tmrRefreshLight;
        private System.Windows.Forms.Timer tmrGetAndonEventStatus;
    }
}
