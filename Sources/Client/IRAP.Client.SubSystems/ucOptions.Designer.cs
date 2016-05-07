namespace IRAP.Client.SubSystems
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
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(128, 38);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "当前选项【一】";
            // 
            // cboProcesses
            // 
            this.cboProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProcesses.Enabled = false;
            this.cboProcesses.Location = new System.Drawing.Point(134, 6);
            this.cboProcesses.Name = "cboProcesses";
            this.cboProcesses.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProcesses.Properties.Appearance.Options.UseFont = true;
            this.cboProcesses.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProcesses.Properties.ReadOnly = true;
            this.cboProcesses.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProcesses.Size = new System.Drawing.Size(150, 26);
            this.cboProcesses.TabIndex = 1;
            this.cboProcesses.SelectedIndexChanged += new System.EventHandler(this.cboProcesses_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(290, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(128, 38);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "当前选项【二】";
            // 
            // cboWorkUnits
            // 
            this.cboWorkUnits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWorkUnits.Enabled = false;
            this.cboWorkUnits.Location = new System.Drawing.Point(424, 6);
            this.cboWorkUnits.Name = "cboWorkUnits";
            this.cboWorkUnits.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWorkUnits.Properties.Appearance.Options.UseFont = true;
            this.cboWorkUnits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboWorkUnits.Properties.ReadOnly = true;
            this.cboWorkUnits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboWorkUnits.Size = new System.Drawing.Size(240, 26);
            this.cboWorkUnits.TabIndex = 3;
            this.cboWorkUnits.SelectedIndexChanged += new System.EventHandler(this.cboWorkUnits_SelectedIndexChanged);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwitch.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch.Appearance.Options.UseFont = true;
            this.btnSwitch.Location = new System.Drawing.Point(687, 3);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(85, 29);
            this.btnSwitch.TabIndex = 4;
            this.btnSwitch.TabStop = false;
            this.btnSwitch.Text = "切换";
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // ucOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.cboWorkUnits);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboProcesses);
            this.Controls.Add(this.labelControl1);
            this.Name = "ucOptions";
            this.Size = new System.Drawing.Size(778, 38);
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
