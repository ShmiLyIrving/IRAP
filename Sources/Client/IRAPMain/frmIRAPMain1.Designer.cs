namespace IRAP
{
    partial class frmIRAPMain1
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
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.ucOptions = new IRAP.Client.SubSystems.ucOptions();
            this.radRibbonBar = new Telerik.WinControls.UI.RadRibbonBar();
            this.cmdQuitSubSystem = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 479);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(761, 27);
            this.radStatusStrip1.SizingGrip = false;
            this.radStatusStrip1.TabIndex = 1;
            this.radStatusStrip1.Text = "radStatusStrip1";
            // 
            // ucOptions
            // 
            this.ucOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucOptions.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucOptions.Location = new System.Drawing.Point(0, 148);
            this.ucOptions.Name = "ucOptions";
            this.ucOptions.Size = new System.Drawing.Size(761, 38);
            this.ucOptions.TabIndex = 2;
            this.ucOptions.Visible = false;
            // 
            // radRibbonBar
            // 
            // 
            // 
            // 
            this.radRibbonBar.ExitButton.Text = "Exit";
            this.radRibbonBar.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radRibbonBar.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radRibbonBar.Location = new System.Drawing.Point(0, 0);
            this.radRibbonBar.Name = "radRibbonBar";
            // 
            // 
            // 
            this.radRibbonBar.OptionsButton.Text = "Options";
            this.radRibbonBar.OptionsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // 
            // 
            this.radRibbonBar.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.radRibbonBar.Size = new System.Drawing.Size(761, 148);
            this.radRibbonBar.StartMenuItems.AddRange(new Telerik.WinControls.RadItem[] {
            this.cmdQuitSubSystem});
            this.radRibbonBar.TabIndex = 0;
            this.radRibbonBar.Text = "frmIRAPMain";
            // 
            // cmdQuitSubSystem
            // 
            this.cmdQuitSubSystem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQuitSubSystem.Name = "cmdQuitSubSystem";
            this.cmdQuitSubSystem.Text = "";
            this.cmdQuitSubSystem.Click += new System.EventHandler(this.cmdQuitSubSystem_Click);
            // 
            // frmIRAPMain1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 506);
            this.Controls.Add(this.ucOptions);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radRibbonBar);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = null;
            this.Name = "frmIRAPMain1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIRAPMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIRAPMain_FormClosing);
            this.Load += new System.EventHandler(this.frmIRAPMain_Load);
            this.Shown += new System.EventHandler(this.frmIRAPMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRibbonBar radRibbonBar;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Client.SubSystems.ucOptions ucOptions;
        private Telerik.WinControls.UI.RadMenuItem cmdQuitSubSystem;
    }
}
