namespace OPCClient.Dialogs
{
    partial class UDFdialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDFdialog));
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.pnlHead = new DevExpress.XtraEditors.PanelControl();
            this.btnSize = new DevExpress.XtraEditors.SimpleButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHead)).BeginInit();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pnlHead.Appearance.BackColor")));
            this.pnlHead.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("pnlHead.Appearance.ForeColor")));
            this.pnlHead.Appearance.Options.UseBackColor = true;
            this.pnlHead.Appearance.Options.UseForeColor = true;
            this.pnlHead.Controls.Add(this.btnSize);
            this.pnlHead.Controls.Add(this.lbTitle);
            this.pnlHead.Controls.Add(this.btnClose);
            resources.ApplyResources(this.pnlHead, "pnlHead");
            this.pnlHead.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.pnlHead.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlHead.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHead_MouseDown);
            // 
            // btnSize
            // 
            this.btnSize.AllowFocus = false;
            this.btnSize.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("btnSize.Appearance.BackColor")));
            this.btnSize.Appearance.Options.UseBackColor = true;
            this.btnSize.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            resources.ApplyResources(this.btnSize, "btnSize");
            this.btnSize.Image = ((System.Drawing.Image)(resources.GetObject("btnSize.Image")));
            this.btnSize.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSize.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSize.Name = "btnSize";
            this.btnSize.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSize.Click += new System.EventHandler(this.btnSize_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lbTitle, "lbTitle");
            this.lbTitle.ForeColor = System.Drawing.Color.Snow;
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHead_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("btnClose.Appearance.BackColor")));
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnClose.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnClose.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // pnlBody
            // 
            resources.ApplyResources(this.pnlBody, "pnlBody");
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHead_MouseDown);
            // 
            // UDFdialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UDFdialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UDFdialog_FormClosing_1);
            this.Load += new System.EventHandler(this.UDFdialog_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHead)).EndInit();
            this.pnlHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        protected DevExpress.XtraEditors.PanelControl pnlHead;
        private System.Windows.Forms.Label lbTitle;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        protected DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraEditors.SimpleButton btnSize;
    }
}