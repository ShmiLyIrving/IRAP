namespace OPCClient
{
    partial class frmOPCClientMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPCClientMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.bbiConfigOPCServers = new DevExpress.XtraBars.BarButtonItem();
            this.bbiConfigSysParams = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOPCTagCollection = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.ItemAppearance.Normal.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon.ExpandCollapseItem.ItemAppearance.Normal.Options.UseFont = true;
            this.ribbon.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon.Images = this.imageCollection;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiConfigOPCServers,
            this.bbiConfigSysParams,
            this.bbiOPCTagCollection});
            this.ribbon.LargeImages = this.imageCollection;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1034, 150);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("properties_32x32.png", "office2013/setup/properties_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/setup/properties_32x32.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "properties_32x32.png");
            this.imageCollection.InsertGalleryImage("build_32x32.png", "office2013/programming/build_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/programming/build_32x32.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "build_32x32.png");
            this.imageCollection.InsertGalleryImage("editdatasource_32x32.png", "office2013/data/editdatasource_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/editdatasource_32x32.png"), 2);
            this.imageCollection.Images.SetKeyName(2, "editdatasource_32x32.png");
            // 
            // bbiConfigOPCServers
            // 
            this.bbiConfigOPCServers.Caption = "OPC 服务地址配置";
            this.bbiConfigOPCServers.Id = 4;
            this.bbiConfigOPCServers.LargeImageIndex = 1;
            this.bbiConfigOPCServers.Name = "bbiConfigOPCServers";
            this.bbiConfigOPCServers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiConfigOPCServers_ItemClick);
            // 
            // bbiConfigSysParams
            // 
            this.bbiConfigSysParams.Caption = "系统参数配置";
            this.bbiConfigSysParams.Id = 5;
            this.bbiConfigSysParams.LargeImageIndex = 0;
            this.bbiConfigSysParams.Name = "bbiConfigSysParams";
            this.bbiConfigSysParams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiConfigSysParams_ItemClick);
            // 
            // bbiOPCTagCollection
            // 
            this.bbiOPCTagCollection.Caption = "设备参数采集";
            this.bbiOPCTagCollection.Id = 2;
            this.bbiOPCTagCollection.LargeImageIndex = 2;
            this.bbiOPCTagCollection.Name = "bbiOPCTagCollection";
            this.bbiOPCTagCollection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiOPCTagCollection_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "OPC 设备参数采集";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiOPCTagCollection);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "参数采集";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiConfigOPCServers);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiConfigSysParams);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "参数配置";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 743);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1034, 21);
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQuit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(100, 22);
            this.tsmiQuit.Text = "退出";
            this.tsmiQuit.Click += new System.EventHandler(this.tsmiQuit_Click);
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 150);
            this.tcMain.Name = "tcMain";
            this.tcMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tcMain.Size = new System.Drawing.Size(1034, 593);
            this.tcMain.TabIndex = 2;
            // 
            // frmOPCClientMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1034, 764);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOPCClientMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "IRAP OPC Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOPCClientMain_FormClosing);
            this.Load += new System.EventHandler(this.frmOPCClientMain_Load);
            this.Shown += new System.EventHandler(this.frmOPCClientMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.BarButtonItem bbiConfigOPCServers;
        private DevExpress.XtraBars.BarButtonItem bbiConfigSysParams;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private DevExpress.XtraTab.XtraTabControl tcMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private DevExpress.XtraBars.BarButtonItem bbiOPCTagCollection;
    }
}