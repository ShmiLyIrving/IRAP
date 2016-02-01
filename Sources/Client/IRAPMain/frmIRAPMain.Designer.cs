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
            this.radRibbonBar1 = new Telerik.WinControls.UI.RadRibbonBar();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.ucOptions = new IRAP.Client.SubSystems.ucOptions();
            this.ribbonTab1 = new Telerik.WinControls.UI.RibbonTab();
            this.ribbonTab2 = new Telerik.WinControls.UI.RibbonTab();
            this.radRibbonBarGroup1 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.radRibbonBarGroup2 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.radButtonElement1 = new Telerik.WinControls.UI.RadButtonElement();
            this.radButtonElement2 = new Telerik.WinControls.UI.RadButtonElement();
            this.cmdQuitSubSystem = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radRibbonBar1
            // 
            this.radRibbonBar1.CommandTabs.AddRange(new Telerik.WinControls.RadItem[] {
            this.ribbonTab1,
            this.ribbonTab2});
            // 
            // 
            // 
            this.radRibbonBar1.ExitButton.Text = "Exit";
            this.radRibbonBar1.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radRibbonBar1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radRibbonBar1.Location = new System.Drawing.Point(0, 0);
            this.radRibbonBar1.Name = "radRibbonBar1";
            // 
            // 
            // 
            this.radRibbonBar1.OptionsButton.Text = "Options";
            this.radRibbonBar1.OptionsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // 
            // 
            this.radRibbonBar1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.radRibbonBar1.Size = new System.Drawing.Size(784, 162);
            this.radRibbonBar1.StartMenuItems.AddRange(new Telerik.WinControls.RadItem[] {
            this.cmdQuitSubSystem});
            this.radRibbonBar1.TabIndex = 0;
            this.radRibbonBar1.Text = "frmIRAPMain";
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 479);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(784, 27);
            this.radStatusStrip1.SizingGrip = false;
            this.radStatusStrip1.TabIndex = 1;
            this.radStatusStrip1.Text = "radStatusStrip1";
            // 
            // ucOptions
            // 
            this.ucOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucOptions.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucOptions.Location = new System.Drawing.Point(0, 162);
            this.ucOptions.Name = "ucOptions";
            this.ucOptions.Size = new System.Drawing.Size(784, 38);
            this.ucOptions.TabIndex = 2;
            this.ucOptions.Visible = false;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.IsSelected = true;
            this.ribbonTab1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radRibbonBarGroup1,
            this.radRibbonBarGroup2});
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "ribbonTab1";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "ribbonTab2";
            // 
            // radRibbonBarGroup1
            // 
            this.radRibbonBarGroup1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radButtonElement1,
            this.radButtonElement2});
            this.radRibbonBarGroup1.Name = "radRibbonBarGroup1";
            this.radRibbonBarGroup1.Text = "radRibbonBarGroup1";
            // 
            // radRibbonBarGroup2
            // 
            this.radRibbonBarGroup2.Name = "radRibbonBarGroup2";
            this.radRibbonBarGroup2.Text = "radRibbonBarGroup2";
            // 
            // radButtonElement1
            // 
            this.radButtonElement1.Name = "radButtonElement1";
            this.radButtonElement1.Text = "radButtonElement1";
            // 
            // radButtonElement2
            // 
            this.radButtonElement2.Name = "radButtonElement2";
            this.radButtonElement2.Text = "radButtonElement2";
            // 
            // cmdQuitSubSystem
            // 
            this.cmdQuitSubSystem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQuitSubSystem.Name = "cmdQuitSubSystem";
            this.cmdQuitSubSystem.Text = "";
            // 
            // frmIRAPMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 506);
            this.Controls.Add(this.ucOptions);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radRibbonBar1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Name = "frmIRAPMain";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIRAPMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIRAPMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRibbonBar radRibbonBar1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Client.SubSystems.ucOptions ucOptions;
        private Telerik.WinControls.UI.RibbonTab ribbonTab1;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup1;
        private Telerik.WinControls.UI.RadButtonElement radButtonElement1;
        private Telerik.WinControls.UI.RadButtonElement radButtonElement2;
        private Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup2;
        private Telerik.WinControls.UI.RibbonTab ribbonTab2;
        private Telerik.WinControls.UI.RadMenuItem cmdQuitSubSystem;
    }
}
