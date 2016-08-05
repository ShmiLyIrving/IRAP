namespace IRAP.AutoUpgrade
{
    partial class frmShowUpgrade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowUpgrade));
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblMessage.Appearance.Font")));
            this.lblMessage.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblMessage.Appearance.FontSizeDelta")));
            this.lblMessage.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblMessage.Appearance.FontStyleDelta")));
            this.lblMessage.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblMessage.Appearance.GradientMode")));
            this.lblMessage.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblMessage.Appearance.Image")));
            this.lblMessage.Name = "lblMessage";
            // 
            // frmShowUpgrade
            // 
            resources.ApplyResources(this, "$this");
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("frmShowUpgrade.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("frmShowUpgrade.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("frmShowUpgrade.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmShowUpgrade.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::IRAP.AutoUpgrade.Properties.Resources.login;
            this.ControlBox = false;
            this.Controls.Add(this.lblMessage);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowUpgrade";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMessage;
    }
}