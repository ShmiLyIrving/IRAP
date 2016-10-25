namespace IRAP_FVS_LSSIVO.UserControls
{
    partial class ucInstrumentPanel
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
            this.pnlTitle = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.picKPI = new System.Windows.Forms.PictureBox();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.lblValue = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTitle)).BeginInit();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.picTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(324, 68);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("等线", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTitle.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(2, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 64);
            this.lblTitle.TabIndex = 1;
            // 
            // picTitle
            // 
            this.picTitle.BackgroundImage = global::IRAP_FVS_LSSIVO.Properties.Resources.rectangle_gray;
            this.picTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTitle.Location = new System.Drawing.Point(2, 2);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(320, 64);
            this.picTitle.TabIndex = 0;
            this.picTitle.TabStop = false;
            // 
            // picKPI
            // 
            this.picKPI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picKPI.BackgroundImage = global::IRAP_FVS_LSSIVO.Properties.Resources.circular_gray;
            this.picKPI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picKPI.Location = new System.Drawing.Point(22, 22);
            this.picKPI.Name = "picKPI";
            this.picKPI.Size = new System.Drawing.Size(279, 288);
            this.picKPI.TabIndex = 1;
            this.picKPI.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.pnlBody.Appearance.Options.UseBackColor = true;
            this.pnlBody.Controls.Add(this.lblValue);
            this.pnlBody.Controls.Add(this.picKPI);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 68);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(324, 330);
            this.pnlBody.TabIndex = 2;
            // 
            // lblValue
            // 
            this.lblValue.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblValue.Appearance.Font = new System.Drawing.Font("等线", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblValue.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue.Location = new System.Drawing.Point(2, 2);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(320, 326);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "85.0%";
            // 
            // ucInstrumentPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTitle);
            this.Name = "ucInstrumentPanel";
            this.Size = new System.Drawing.Size(324, 398);
            this.Resize += new System.EventHandler(this.ucInstrumentPanel_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTitle)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTitle;
        private System.Windows.Forms.PictureBox picTitle;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.PictureBox picKPI;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraEditors.LabelControl lblValue;
    }
}
