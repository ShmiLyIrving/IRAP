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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboProcesses = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboWorkUnits = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSwitch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboProcesses.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkUnits.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl1.Appearance.Font")));
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // cboProcesses
            // 
            resources.ApplyResources(this.cboProcesses, "cboProcesses");
            this.cboProcesses.Name = "cboProcesses";
            this.cboProcesses.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cboProcesses.Properties.Appearance.Font")));
            this.cboProcesses.Properties.Appearance.Options.UseFont = true;
            this.cboProcesses.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboProcesses.Properties.Buttons"))))});
            this.cboProcesses.Properties.ReadOnly = true;
            this.cboProcesses.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProcesses.SelectedIndexChanged += new System.EventHandler(this.cboProcesses_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl2.Appearance.Font")));
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.Name = "labelControl2";
            // 
            // cboWorkUnits
            // 
            resources.ApplyResources(this.cboWorkUnits, "cboWorkUnits");
            this.cboWorkUnits.Name = "cboWorkUnits";
            this.cboWorkUnits.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cboWorkUnits.Properties.Appearance.Font")));
            this.cboWorkUnits.Properties.Appearance.Options.UseFont = true;
            this.cboWorkUnits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboWorkUnits.Properties.Buttons"))))});
            this.cboWorkUnits.Properties.ReadOnly = true;
            this.cboWorkUnits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboWorkUnits.SelectedIndexChanged += new System.EventHandler(this.cboWorkUnits_SelectedIndexChanged);
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
            this.Controls.Add(this.cboWorkUnits);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboProcesses);
            this.Controls.Add(this.labelControl1);
            this.Name = "ucOptions";
            this.VisibleChanged += new System.EventHandler(this.ucOptions_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.cboProcesses.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkUnits.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboProcesses;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboWorkUnits;
        private DevExpress.XtraEditors.SimpleButton btnSwitch;
    }
}
