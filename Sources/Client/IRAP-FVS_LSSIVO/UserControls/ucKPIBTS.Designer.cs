namespace IRAP_FVS_LSSIVO.UserControls
{
    partial class ucKPIBTS
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picPlanBar = new System.Windows.Forms.PictureBox();
            this.picVernier = new System.Windows.Forms.PictureBox();
            this.picActualBar = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblKPI = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.picPlanBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVernier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActualBar)).BeginInit();
            this.SuspendLayout();
            // 
            // picPlanBar
            // 
            this.picPlanBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPlanBar.BackgroundImage = global::IRAP_FVS_LSSIVO.Properties.Resources.gray;
            this.picPlanBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlanBar.Location = new System.Drawing.Point(64, 27);
            this.picPlanBar.Name = "picPlanBar";
            this.picPlanBar.Size = new System.Drawing.Size(541, 22);
            this.picPlanBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlanBar.TabIndex = 0;
            this.picPlanBar.TabStop = false;
            // 
            // picVernier
            // 
            this.picVernier.BackColor = System.Drawing.Color.Transparent;
            this.picVernier.Image = global::IRAP_FVS_LSSIVO.Properties.Resources.bts;
            this.picVernier.Location = new System.Drawing.Point(400, 27);
            this.picVernier.Name = "picVernier";
            this.picVernier.Size = new System.Drawing.Size(16, 28);
            this.picVernier.TabIndex = 1;
            this.picVernier.TabStop = false;
            // 
            // picActualBar
            // 
            this.picActualBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picActualBar.Location = new System.Drawing.Point(64, 57);
            this.picActualBar.Name = "picActualBar";
            this.picActualBar.Size = new System.Drawing.Size(298, 22);
            this.picActualBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picActualBar.TabIndex = 2;
            this.picActualBar.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Location = new System.Drawing.Point(12, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 17);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "计划";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Location = new System.Drawing.Point(12, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 17);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "实际";
            // 
            // lblKPI
            // 
            this.lblKPI.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblKPI.Appearance.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKPI.Location = new System.Drawing.Point(374, 4);
            this.lblKPI.Name = "lblKPI";
            this.lblKPI.Size = new System.Drawing.Size(51, 14);
            this.lblKPI.TabIndex = 5;
            this.lblKPI.Text = "BTS 70%";
            // 
            // ucKPIBTS
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblKPI);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.picActualBar);
            this.Controls.Add(this.picVernier);
            this.Controls.Add(this.picPlanBar);
            this.Name = "ucKPIBTS";
            this.Size = new System.Drawing.Size(619, 89);
            this.SizeChanged += new System.EventHandler(this.ucKPIBTS_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picPlanBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVernier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picActualBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPlanBar;
        private System.Windows.Forms.PictureBox picVernier;
        private System.Windows.Forms.PictureBox picActualBar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblKPI;
    }
}
