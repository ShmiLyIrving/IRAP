namespace UpdateBuilder
{
    partial class frmUpgradeBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpgradeBuilder));
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.tbiAbout = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator2 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.btnQuit = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.lblVersion = new DevExpress.XtraBars.BarStaticItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAll = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewProject = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenProject = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnRegisterApp = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            this.backstageViewClientControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.lblVersion,
            this.btnSave,
            this.btnSaveAll,
            this.btnSaveAs,
            this.btnNewProject,
            this.btnOpenProject,
            this.btnRegisterApp});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 12;
            this.ribbonControl.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.Size = new System.Drawing.Size(725, 151);
            this.ribbonControl.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl.Merge += new DevExpress.XtraBars.Ribbon.RibbonMergeEventHandler(this.ribbonControl_Merge);
            this.ribbonControl.UnMerge += new DevExpress.XtraBars.Ribbon.RibbonMergeEventHandler(this.ribbonControl_UnMerge);
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator1);
            this.backstageViewControl1.Items.Add(this.tbiAbout);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator2);
            this.backstageViewControl1.Items.Add(this.btnQuit);
            this.backstageViewControl1.Location = new System.Drawing.Point(12, 176);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.Ribbon = this.ribbonControl;
            this.backstageViewControl1.SelectedTab = this.tbiAbout;
            this.backstageViewControl1.SelectedTabIndex = 1;
            this.backstageViewControl1.Size = new System.Drawing.Size(480, 303);
            this.backstageViewControl1.TabIndex = 1;
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Controls.Add(this.pictureBox1);
            this.backstageViewClientControl1.Location = new System.Drawing.Point(133, 63);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(346, 239);
            this.backstageViewClientControl1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::UpdateBuilder.Properties.Resources.IRAP芍园;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 233);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // backstageViewItemSeparator1
            // 
            this.backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // tbiAbout
            // 
            this.tbiAbout.Caption = "关于...";
            this.tbiAbout.ContentControl = this.backstageViewClientControl1;
            this.tbiAbout.Name = "tbiAbout";
            this.tbiAbout.Selected = true;
            // 
            // backstageViewItemSeparator2
            // 
            this.backstageViewItemSeparator2.Name = "backstageViewItemSeparator2";
            // 
            // btnQuit
            // 
            this.btnQuit.Caption = "退出";
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.btnQuit_ItemClick);
            // 
            // lblVersion
            // 
            this.lblVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblVersion.Caption = "江苏芍园科技有限责任公司";
            this.lblVersion.Description = "江苏芍园科技有限责任公司";
            this.lblVersion.Id = 4;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnSave
            // 
            this.btnSave.Caption = "保存";
            this.btnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSave.Glyph")));
            this.btnSave.Id = 5;
            this.btnSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSave.LargeGlyph")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Caption = "全部保存";
            this.btnSaveAll.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAll.Glyph")));
            this.btnSaveAll.Id = 6;
            this.btnSaveAll.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAll.LargeGlyph")));
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAll_ItemClick);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Caption = "另存为...";
            this.btnSaveAs.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Glyph")));
            this.btnSaveAs.Id = 7;
            this.btnSaveAs.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.LargeGlyph")));
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAs_ItemClick);
            // 
            // btnNewProject
            // 
            this.btnNewProject.Caption = "新建";
            this.btnNewProject.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNewProject.Glyph")));
            this.btnNewProject.Id = 9;
            this.btnNewProject.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNewProject.LargeGlyph")));
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewProject_ItemClick);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.Caption = "打开";
            this.btnOpenProject.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpenProject.Glyph")));
            this.btnOpenProject.Id = 10;
            this.btnOpenProject.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpenProject.LargeGlyph")));
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenProject_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "项目";
            // 
            // ribbonPageGroup
            // 
            this.ribbonPageGroup.ItemLinks.Add(this.btnNewProject, true);
            this.ribbonPageGroup.ItemLinks.Add(this.btnOpenProject);
            this.ribbonPageGroup.ItemLinks.Add(this.btnSave, true);
            this.ribbonPageGroup.ItemLinks.Add(this.btnSaveAll);
            this.ribbonPageGroup.ItemLinks.Add(this.btnSaveAs);
            this.ribbonPageGroup.Name = "ribbonPageGroup";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.lblVersion);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 499);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(725, 23);
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "upb";
            this.openFileDialog.Filter = "自动升级配置项目文件(*.upb)|*.upb";
            this.openFileDialog.Title = "选择“自动升级配置项目文件”";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "系统";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRegisterApp);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "系统功能";
            // 
            // btnRegisterApp
            // 
            this.btnRegisterApp.Caption = "注册文件类型";
            this.btnRegisterApp.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRegisterApp.Glyph")));
            this.btnRegisterApp.Id = 11;
            this.btnRegisterApp.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRegisterApp.LargeGlyph")));
            this.btnRegisterApp.Name = "btnRegisterApp";
            this.btnRegisterApp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRegisterApp_ItemClick);
            // 
            // frmUpgradeBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 522);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmUpgradeBuilder";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "自动升级配置管理工具";
            this.Load += new System.EventHandler(this.frmUpgradeBuilder_Load);
            this.Shown += new System.EventHandler(this.frmUpgradeBuilder_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            this.backstageViewControl1.ResumeLayout(false);
            this.backstageViewClientControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem tbiAbout;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator2;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem btnQuit;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem lblVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAll;
        private DevExpress.XtraBars.BarButtonItem btnSaveAs;
        private DevExpress.XtraBars.BarButtonItem btnNewProject;
        private DevExpress.XtraBars.BarButtonItem btnOpenProject;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraBars.BarButtonItem btnRegisterApp;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}

