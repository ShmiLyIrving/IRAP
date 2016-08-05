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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIRAPMain));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.cmdAbout = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.cmdQuitSubSystem = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.imageCollection = new DevExpress.Utils.ImageCollection();
            this.skinBarItem = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.ucOptions = new IRAP.Client.SubSystems.ucOptions();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            resources.ApplyResources(this.ribbonControl, "ribbonControl");
            this.ribbonControl.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.ribbonControl.AutoHideEmptyItems = true;
            this.ribbonControl.AutoSizeItems = true;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Images = this.imageCollection;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.skinBarItem,
            this.barStaticItem1});
            this.ribbonControl.LargeImages = this.imageCollection;
            this.ribbonControl.MaxItemId = 3;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.Toolbar.ItemLinks.Add(this.skinBarItem);
            // 
            // backstageViewControl1
            // 
            resources.ApplyResources(this.backstageViewControl1, "backstageViewControl1");
            this.backstageViewControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("backstageViewControl1.Appearance.Font")));
            this.backstageViewControl1.Appearance.FontSizeDelta = ((int)(resources.GetObject("backstageViewControl1.Appearance.FontSizeDelta")));
            this.backstageViewControl1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("backstageViewControl1.Appearance.FontStyleDelta")));
            this.backstageViewControl1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("backstageViewControl1.Appearance.GradientMode")));
            this.backstageViewControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("backstageViewControl1.Appearance.Image")));
            this.backstageViewControl1.Appearance.Options.UseFont = true;
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
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
            resources.ApplyResources(this.backstageViewClientControl1, "backstageViewClientControl1");
            this.backstageViewClientControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("backstageViewClientControl1.Appearance.Font")));
            this.backstageViewClientControl1.Appearance.FontSizeDelta = ((int)(resources.GetObject("backstageViewClientControl1.Appearance.FontSizeDelta")));
            this.backstageViewClientControl1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("backstageViewClientControl1.Appearance.FontStyleDelta")));
            this.backstageViewClientControl1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("backstageViewClientControl1.Appearance.GradientMode")));
            this.backstageViewClientControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("backstageViewClientControl1.Appearance.Image")));
            this.backstageViewClientControl1.Appearance.Options.UseFont = true;
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            // 
            // cmdAbout
            // 
            this.cmdAbout.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cmdAbout.Appearance.Font")));
            this.cmdAbout.Appearance.FontSizeDelta = ((int)(resources.GetObject("cmdAbout.Appearance.FontSizeDelta")));
            this.cmdAbout.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cmdAbout.Appearance.FontStyleDelta")));
            this.cmdAbout.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cmdAbout.Appearance.GradientMode")));
            this.cmdAbout.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cmdAbout.Appearance.Image")));
            this.cmdAbout.Appearance.Options.UseFont = true;
            this.cmdAbout.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("cmdAbout.AppearanceDisabled.FontSizeDelta")));
            this.cmdAbout.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cmdAbout.AppearanceDisabled.FontStyleDelta")));
            this.cmdAbout.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cmdAbout.AppearanceDisabled.GradientMode")));
            this.cmdAbout.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("cmdAbout.AppearanceDisabled.Image")));
            this.cmdAbout.AppearanceHover.FontSizeDelta = ((int)(resources.GetObject("cmdAbout.AppearanceHover.FontSizeDelta")));
            this.cmdAbout.AppearanceHover.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cmdAbout.AppearanceHover.FontStyleDelta")));
            this.cmdAbout.AppearanceHover.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cmdAbout.AppearanceHover.GradientMode")));
            this.cmdAbout.AppearanceHover.Image = ((System.Drawing.Image)(resources.GetObject("cmdAbout.AppearanceHover.Image")));
            this.cmdAbout.AppearanceSelected.FontSizeDelta = ((int)(resources.GetObject("cmdAbout.AppearanceSelected.FontSizeDelta")));
            this.cmdAbout.AppearanceSelected.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cmdAbout.AppearanceSelected.FontStyleDelta")));
            this.cmdAbout.AppearanceSelected.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cmdAbout.AppearanceSelected.GradientMode")));
            this.cmdAbout.AppearanceSelected.Image = ((System.Drawing.Image)(resources.GetObject("cmdAbout.AppearanceSelected.Image")));
            resources.ApplyResources(this.cmdAbout, "cmdAbout");
            this.cmdAbout.ContentControl = this.backstageViewClientControl1;
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Selected = true;
            // 
            // backstageViewItemSeparator1
            // 
            this.backstageViewItemSeparator1.Appearance.FontSizeDelta = ((int)(resources.GetObject("backstageViewItemSeparator1.Appearance.FontSizeDelta")));
            this.backstageViewItemSeparator1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("backstageViewItemSeparator1.Appearance.FontStyleDelta")));
            this.backstageViewItemSeparator1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("backstageViewItemSeparator1.Appearance.GradientMode")));
            this.backstageViewItemSeparator1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("backstageViewItemSeparator1.Appearance.Image")));
            this.backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // cmdQuitSubSystem
            // 
            this.cmdQuitSubSystem.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cmdQuitSubSystem.Appearance.Font")));
            this.cmdQuitSubSystem.Appearance.FontSizeDelta = ((int)(resources.GetObject("cmdQuitSubSystem.Appearance.FontSizeDelta")));
            this.cmdQuitSubSystem.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cmdQuitSubSystem.Appearance.FontStyleDelta")));
            this.cmdQuitSubSystem.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cmdQuitSubSystem.Appearance.GradientMode")));
            this.cmdQuitSubSystem.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuitSubSystem.Appearance.Image")));
            this.cmdQuitSubSystem.Appearance.Options.UseFont = true;
            this.cmdQuitSubSystem.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("cmdQuitSubSystem.AppearanceDisabled.FontSizeDelta")));
            this.cmdQuitSubSystem.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cmdQuitSubSystem.AppearanceDisabled.FontStyleDelta")));
            this.cmdQuitSubSystem.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cmdQuitSubSystem.AppearanceDisabled.GradientMode")));
            this.cmdQuitSubSystem.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuitSubSystem.AppearanceDisabled.Image")));
            this.cmdQuitSubSystem.AppearanceHover.FontSizeDelta = ((int)(resources.GetObject("cmdQuitSubSystem.AppearanceHover.FontSizeDelta")));
            this.cmdQuitSubSystem.AppearanceHover.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cmdQuitSubSystem.AppearanceHover.FontStyleDelta")));
            this.cmdQuitSubSystem.AppearanceHover.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cmdQuitSubSystem.AppearanceHover.GradientMode")));
            this.cmdQuitSubSystem.AppearanceHover.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuitSubSystem.AppearanceHover.Image")));
            this.cmdQuitSubSystem.AppearancePressed.FontSizeDelta = ((int)(resources.GetObject("cmdQuitSubSystem.AppearancePressed.FontSizeDelta")));
            this.cmdQuitSubSystem.AppearancePressed.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("cmdQuitSubSystem.AppearancePressed.FontStyleDelta")));
            this.cmdQuitSubSystem.AppearancePressed.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("cmdQuitSubSystem.AppearancePressed.GradientMode")));
            this.cmdQuitSubSystem.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuitSubSystem.AppearancePressed.Image")));
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
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ucOptions);
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.IsMdiContainer = true;
            this.Name = "frmIRAPMain";
            this.Ribbon = this.ribbonControl;
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
        private Client.SubSystems.ucOptions ucOptions;
    }
}