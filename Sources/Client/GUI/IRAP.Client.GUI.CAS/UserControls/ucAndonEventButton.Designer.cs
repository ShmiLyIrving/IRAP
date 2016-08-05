namespace IRAP.Client.GUI.CAS.UserControls
{
    partial class ucAndonEventButton
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
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.pnlAndonEventButton = new DevExpress.XtraEditors.PanelControl();
            this.picButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAndonEventButton)).BeginInit();
            this.pnlAndonEventButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picButton)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("新宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(176, 30);
            this.lblCaption.TabIndex = 0;
            // 
            // pnlAndonEventButton
            // 
            this.pnlAndonEventButton.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlAndonEventButton.Appearance.Options.UseBackColor = true;
            this.pnlAndonEventButton.Controls.Add(this.picButton);
            this.pnlAndonEventButton.Controls.Add(this.lblCaption);
            this.pnlAndonEventButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAndonEventButton.Location = new System.Drawing.Point(0, 0);
            this.pnlAndonEventButton.Name = "pnlAndonEventButton";
            this.pnlAndonEventButton.Size = new System.Drawing.Size(180, 180);
            this.pnlAndonEventButton.TabIndex = 0;
            // 
            // picButton
            // 
            this.picButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picButton.Location = new System.Drawing.Point(25, 36);
            this.picButton.Name = "picButton";
            this.picButton.Size = new System.Drawing.Size(128, 128);
            this.picButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picButton.TabIndex = 1;
            this.picButton.TabStop = false;
            this.picButton.Click += new System.EventHandler(this.picButton_Click);
            // 
            // ucAndonEventButton
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAndonEventButton);
            this.Name = "ucAndonEventButton";
            this.Size = new System.Drawing.Size(180, 180);
            ((System.ComponentModel.ISupportInitialize)(this.pnlAndonEventButton)).EndInit();
            this.pnlAndonEventButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraEditors.PanelControl pnlAndonEventButton;
        public System.Windows.Forms.PictureBox picButton;
    }
}
