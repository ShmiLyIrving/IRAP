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
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ucOptions = new IRAP.Client.SubSystems.ucOptions();
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
            this.ribbonControl.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControl.Images = this.imageCollection;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.skinBarItem,
            this.barStaticItem1});
            this.ribbonControl.LargeImages = this.imageCollection;
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 3;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.Size = new System.Drawing.Size(734, 55);
            this.ribbonControl.Toolbar.ItemLinks.Add(this.skinBarItem);
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backstageViewControl1.Appearance.Options.UseFont = true;
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backstageViewControl1.Items.Add(this.cmdAbout);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator1);
            this.backstageViewControl1.Items.Add(this.cmdQuitSubSystem);
            this.backstageViewControl1.Location = new System.Drawing.Point(73, 220);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.Ribbon = this.ribbonControl;
            this.backstageViewControl1.SelectedTab = this.cmdAbout;
            this.backstageViewControl1.SelectedTabIndex = 0;
            this.backstageViewControl1.Size = new System.Drawing.Size(480, 200);
            this.backstageViewControl1.TabIndex = 1;
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backstageViewClientControl1.Appearance.Options.UseFont = true;
            this.backstageViewClientControl1.Location = new System.Drawing.Point(133, 63);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(346, 136);
            this.backstageViewClientControl1.TabIndex = 1;
            // 
            // cmdAbout
            // 
            this.cmdAbout.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdAbout.Appearance.Options.UseFont = true;
            this.cmdAbout.Caption = "关于...";
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
            this.cmdQuitSubSystem.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdQuitSubSystem.Appearance.Options.UseFont = true;
            this.cmdQuitSubSystem.Caption = "退出[{0}]";
            this.cmdQuitSubSystem.Name = "cmdQuitSubSystem";
            this.cmdQuitSubSystem.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.cmdQuitSubSystem_ItemClick);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(48, 48);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // skinBarItem
            // 
            this.skinBarItem.Caption = "皮肤";
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
            this.barStaticItem1.Caption = "江苏芍园科技有限责任公司 版权所有";
            this.barStaticItem1.Description = "江苏芍园科技有限责任公司 版权所有";
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
            this.ucOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucOptions.Location = new System.Drawing.Point(0, 55);
            this.ucOptions.Name = "ucOptions";
            this.ucOptions.Size = new System.Drawing.Size(734, 47);
            this.ucOptions.TabIndex = 2;
            this.ucOptions.Visible = false;
            // 
            // frmIRAPMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(734, 506);
            this.Controls.Add(this.ucOptions);
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmIRAPMain";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIRAPMain";
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