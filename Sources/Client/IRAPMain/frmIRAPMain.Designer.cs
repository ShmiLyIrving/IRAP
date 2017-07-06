namespace IRAP
{
    partial class frmIRAPMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIRAPMain));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.cmdAbout = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.cmdQuitSubSystem = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.skinBarItem = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.btnItemParams = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ucOptions = new IRAP.Client.SubSystem.ucOptions();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.ribbonControl.AutoHideEmptyItems = true;
            this.ribbonControl.AutoSizeItems = true;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            resources.ApplyResources(this.ribbonControl, "ribbonControl");
            this.ribbonControl.Images = this.imageCollection;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.skinBarItem,
            this.barStaticItem1,
            this.btnItemParams});
            this.ribbonControl.LargeImages = this.imageCollection;
            this.ribbonControl.MaxItemId = 4;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl.Toolbar.ItemLinks.Add(this.skinBarItem);
            this.ribbonControl.Toolbar.ItemLinks.Add(this.btnItemParams);
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("backstageViewControl1.Appearance.Font")));
            this.backstageViewControl1.Appearance.Options.UseFont = true;
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            resources.ApplyResources(this.backstageViewControl1, "backstageViewControl1");
            this.backstageViewControl1.Items.Add(this.cmdAbout);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator1);
            this.backstageViewControl1.Items.Add(this.cmdQuitSubSystem);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.Ribbon = this.ribbonControl;
            this.backstageViewControl1.SelectedTab = this.cmdAbout;
            this.backstageViewControl1.SelectedTabIndex = 0;
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("backstageViewClientControl1.Appearance.Font")));
            this.backstageViewClientControl1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.backstageViewClientControl1, "backstageViewClientControl1");
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            // 
            // cmdAbout
            // 
            this.cmdAbout.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cmdAbout.Appearance.Font")));
            this.cmdAbout.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.cmdAbout, "cmdAbout");
            this.cmdAbout.ContentControl = this.backstageViewClientControl1;
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Selected = true;
            // 
            // backstageViewItemSeparator1
            // 
            this.backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // cmdQuitSubSystem
            // 
            this.cmdQuitSubSystem.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cmdQuitSubSystem.Appearance.Font")));
            this.cmdQuitSubSystem.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.cmdQuitSubSystem, "cmdQuitSubSystem");
            this.cmdQuitSubSystem.Name = "cmdQuitSubSystem";
            this.cmdQuitSubSystem.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.cmdQuitSubSystem_ItemClick);
            // 
            // imageCollection
            // 
            resources.ApplyResources(this.imageCollection, "imageCollection");
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // skinBarItem
            // 
            resources.ApplyResources(this.skinBarItem, "skinBarItem");
            // 
            // 
            // 
            this.skinBarItem.Gallery.ShowItemText = true;
            this.skinBarItem.Id = 1;
            this.skinBarItem.Name = "skinBarItem";
            this.skinBarItem.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.skinBarItem_GalleryItemClick);
            // 
            // barStaticItem1
            // 
            resources.ApplyResources(this.barStaticItem1, "barStaticItem1");
            this.barStaticItem1.Id = 2;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnItemParams
            // 
            resources.ApplyResources(this.btnItemParams, "btnItemParams");
            this.btnItemParams.Glyph = global::IRAP.Properties.Resources.Config_App;
            this.btnItemParams.Id = 3;
            this.btnItemParams.Name = "btnItemParams";
            this.btnItemParams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemParams_ItemClick);
            // 
            // ribbonStatusBar1
            // 
            resources.ApplyResources(this.ribbonStatusBar1, "ribbonStatusBar1");
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl;
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Blue";
            // 
            // ucOptions
            // 
            resources.ApplyResources(this.ucOptions, "ucOptions");
            this.ucOptions.Name = "ucOptions";
            // 
            // frmIRAPMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ucOptions);
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.IsMdiContainer = true;
            this.Name = "frmIRAPMain";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar1;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIRAPMain_FormClosing);
            this.Load += new System.EventHandler(this.frmIRAPMain_Load);
            this.Shown += new System.EventHandler(this.frmIRAPMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            this.backstageViewControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem cmdAbout;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem cmdQuitSubSystem;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinBarItem;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private Client.SubSystem.ucOptions ucOptions;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnItemParams;
    }
}