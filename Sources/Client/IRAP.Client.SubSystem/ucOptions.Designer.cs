namespace IRAP.Client.SubSystem
{
    partial class ucOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOptions));
            this.lblOptionOne = new DevExpress.XtraEditors.LabelControl();
            this.cboOptionsOne = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblOptionTwo = new DevExpress.XtraEditors.LabelControl();
            this.cboOptionsTwo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSwitch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboOptionsOne.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOptionsTwo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOptionOne
            // 
            this.lblOptionOne.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblOptionOne.Appearance.Font")));
            this.lblOptionOne.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblOptionOne.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.lblOptionOne, "lblOptionOne");
            this.lblOptionOne.Name = "lblOptionOne";
            // 
            // cboOptionsOne
            // 
            resources.ApplyResources(this.cboOptionsOne, "cboOptionsOne");
            this.cboOptionsOne.Name = "cboOptionsOne";
            this.cboOptionsOne.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cboOptionsOne.Properties.Appearance.Font")));
            this.cboOptionsOne.Properties.Appearance.Options.UseFont = true;
            this.cboOptionsOne.Properties.AppearanceDisabled.BackColor = ((System.Drawing.Color)(resources.GetObject("cboOptionsOne.Properties.AppearanceDisabled.BackColor")));
            this.cboOptionsOne.Properties.AppearanceDisabled.ForeColor = ((System.Drawing.Color)(resources.GetObject("cboOptionsOne.Properties.AppearanceDisabled.ForeColor")));
            this.cboOptionsOne.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.cboOptionsOne.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboOptionsOne.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboOptionsOne.Properties.Buttons"))))});
            this.cboOptionsOne.Properties.ReadOnly = true;
            this.cboOptionsOne.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboOptionsOne.SelectedIndexChanged += new System.EventHandler(this.cboOptionsOne_SelectedIndexChanged);
            // 
            // lblOptionTwo
            // 
            resources.ApplyResources(this.lblOptionTwo, "lblOptionTwo");
            this.lblOptionTwo.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblOptionTwo.Appearance.Font")));
            this.lblOptionTwo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblOptionTwo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblOptionTwo.Name = "lblOptionTwo";
            // 
            // cboOptionsTwo
            // 
            resources.ApplyResources(this.cboOptionsTwo, "cboOptionsTwo");
            this.cboOptionsTwo.Name = "cboOptionsTwo";
            this.cboOptionsTwo.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cboOptionsTwo.Properties.Appearance.Font")));
            this.cboOptionsTwo.Properties.Appearance.Options.UseFont = true;
            this.cboOptionsTwo.Properties.AppearanceDisabled.BackColor = ((System.Drawing.Color)(resources.GetObject("cboOptionsTwo.Properties.AppearanceDisabled.BackColor")));
            this.cboOptionsTwo.Properties.AppearanceDisabled.ForeColor = ((System.Drawing.Color)(resources.GetObject("cboOptionsTwo.Properties.AppearanceDisabled.ForeColor")));
            this.cboOptionsTwo.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.cboOptionsTwo.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboOptionsTwo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboOptionsTwo.Properties.Buttons"))))});
            this.cboOptionsTwo.Properties.ReadOnly = true;
            this.cboOptionsTwo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboOptionsTwo.SelectedIndexChanged += new System.EventHandler(this.cboOptionsTwo_SelectedIndexChanged);
            // 
            // btnSwitch
            // 
            resources.ApplyResources(this.btnSwitch, "btnSwitch");
            this.btnSwitch.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnSwitch.Appearance.Font")));
            this.btnSwitch.Appearance.Options.UseFont = true;
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.TabStop = false;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // ucOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.cboOptionsTwo);
            this.Controls.Add(this.lblOptionTwo);
            this.Controls.Add(this.cboOptionsOne);
            this.Controls.Add(this.lblOptionOne);
            this.Name = "ucOptions";
            this.VisibleChanged += new System.EventHandler(this.ucOptions_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.cboOptionsOne.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOptionsTwo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblOptionOne;
        private DevExpress.XtraEditors.ComboBoxEdit cboOptionsOne;
        private DevExpress.XtraEditors.LabelControl lblOptionTwo;
        private DevExpress.XtraEditors.ComboBoxEdit cboOptionsTwo;
        private DevExpress.XtraEditors.SimpleButton btnSwitch;
    }
}
