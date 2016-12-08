namespace IRAP.Global
{
    partial class frmMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageBox));
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnYes = new DevExpress.XtraEditors.SimpleButton();
            this.btnNo = new DevExpress.XtraEditors.SimpleButton();
            this.btnAbort = new DevExpress.XtraEditors.SimpleButton();
            this.btnRetry = new DevExpress.XtraEditors.SimpleButton();
            this.btnIgnore = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.timer = new System.Windows.Forms.Timer();
            this.picIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblMessage.Appearance.Font")));
            this.lblMessage.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblMessage.Appearance.FontSizeDelta")));
            this.lblMessage.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblMessage.Appearance.FontStyleDelta")));
            this.lblMessage.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblMessage.Appearance.ForeColor")));
            this.lblMessage.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblMessage.Appearance.GradientMode")));
            this.lblMessage.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblMessage.Appearance.Image")));
            this.lblMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblMessage.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblMessage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblMessage.Name = "lblMessage";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnOK.Appearance.Font")));
            this.btnOK.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnOK.Appearance.FontSizeDelta")));
            this.btnOK.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnOK.Appearance.FontStyleDelta")));
            this.btnOK.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnOK.Appearance.GradientMode")));
            this.btnOK.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Appearance.Image")));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            // 
            // btnYes
            // 
            resources.ApplyResources(this.btnYes, "btnYes");
            this.btnYes.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnYes.Appearance.Font")));
            this.btnYes.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnYes.Appearance.FontSizeDelta")));
            this.btnYes.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnYes.Appearance.FontStyleDelta")));
            this.btnYes.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnYes.Appearance.GradientMode")));
            this.btnYes.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnYes.Appearance.Image")));
            this.btnYes.Appearance.Options.UseFont = true;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Name = "btnYes";
            // 
            // btnNo
            // 
            resources.ApplyResources(this.btnNo, "btnNo");
            this.btnNo.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnNo.Appearance.Font")));
            this.btnNo.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnNo.Appearance.FontSizeDelta")));
            this.btnNo.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnNo.Appearance.FontStyleDelta")));
            this.btnNo.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnNo.Appearance.GradientMode")));
            this.btnNo.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Appearance.Image")));
            this.btnNo.Appearance.Options.UseFont = true;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Name = "btnNo";
            // 
            // btnAbort
            // 
            resources.ApplyResources(this.btnAbort, "btnAbort");
            this.btnAbort.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnAbort.Appearance.Font")));
            this.btnAbort.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnAbort.Appearance.FontSizeDelta")));
            this.btnAbort.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnAbort.Appearance.FontStyleDelta")));
            this.btnAbort.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnAbort.Appearance.GradientMode")));
            this.btnAbort.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnAbort.Appearance.Image")));
            this.btnAbort.Appearance.Options.UseFont = true;
            this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAbort.Name = "btnAbort";
            // 
            // btnRetry
            // 
            resources.ApplyResources(this.btnRetry, "btnRetry");
            this.btnRetry.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnRetry.Appearance.Font")));
            this.btnRetry.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnRetry.Appearance.FontSizeDelta")));
            this.btnRetry.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnRetry.Appearance.FontStyleDelta")));
            this.btnRetry.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnRetry.Appearance.GradientMode")));
            this.btnRetry.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnRetry.Appearance.Image")));
            this.btnRetry.Appearance.Options.UseFont = true;
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRetry.Name = "btnRetry";
            // 
            // btnIgnore
            // 
            resources.ApplyResources(this.btnIgnore, "btnIgnore");
            this.btnIgnore.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnIgnore.Appearance.Font")));
            this.btnIgnore.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnIgnore.Appearance.FontSizeDelta")));
            this.btnIgnore.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnIgnore.Appearance.FontStyleDelta")));
            this.btnIgnore.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnIgnore.Appearance.GradientMode")));
            this.btnIgnore.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnIgnore.Appearance.Image")));
            this.btnIgnore.Appearance.Options.UseFont = true;
            this.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnIgnore.Name = "btnIgnore";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnCancel.Appearance.Font")));
            this.btnCancel.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnCancel.Appearance.FontSizeDelta")));
            this.btnCancel.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnCancel.Appearance.FontStyleDelta")));
            this.btnCancel.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnCancel.Appearance.GradientMode")));
            this.btnCancel.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Appearance.Image")));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnClose.Appearance.Font")));
            this.btnClose.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnClose.Appearance.FontSizeDelta")));
            this.btnClose.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnClose.Appearance.FontStyleDelta")));
            this.btnClose.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnClose.Appearance.GradientMode")));
            this.btnClose.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Appearance.Image")));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // picIcon
            // 
            resources.ApplyResources(this.picIcon, "picIcon");
            this.picIcon.Image = global::IRAP.Global.Properties.Resources.故障;
            this.picIcon.Name = "picIcon";
            this.picIcon.TabStop = false;
            // 
            // frmMessageBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.picIcon);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picIcon;
        public DevExpress.XtraEditors.LabelControl lblMessage;
        public DevExpress.XtraEditors.SimpleButton btnOK;
        public DevExpress.XtraEditors.SimpleButton btnYes;
        public DevExpress.XtraEditors.SimpleButton btnNo;
        public DevExpress.XtraEditors.SimpleButton btnAbort;
        public DevExpress.XtraEditors.SimpleButton btnRetry;
        public DevExpress.XtraEditors.SimpleButton btnIgnore;
        public DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Timer timer;
    }
}