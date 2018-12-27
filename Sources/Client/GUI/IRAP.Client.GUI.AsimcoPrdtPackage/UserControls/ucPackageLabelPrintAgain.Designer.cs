namespace IRAP.Client.GUI.AsimcoPrdtPackage.UserControls
{
    partial class ucPackageLabelPrintAgain
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboPrinters = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnPrintBoxLabel = new DevExpress.XtraEditors.SimpleButton();
            this.edtBoxNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrinters.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBoxNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl2.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.cboPrinters);
            this.groupControl2.Location = new System.Drawing.Point(13, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(533, 66);
            this.groupControl2.TabIndex = 15;
            this.groupControl2.Text = "打印到";
            // 
            // cboPrinters
            // 
            this.cboPrinters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinters.Location = new System.Drawing.Point(14, 33);
            this.cboPrinters.Name = "cboPrinters";
            this.cboPrinters.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrinters.Properties.Appearance.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceDisabled.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceDropDown.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceFocused.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboPrinters.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPrinters.Size = new System.Drawing.Size(504, 20);
            this.cboPrinters.TabIndex = 11;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnPrintBoxLabel);
            this.groupControl1.Controls.Add(this.edtBoxNumber);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(13, 97);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(533, 66);
            this.groupControl1.TabIndex = 16;
            this.groupControl1.Text = "补打内标签";
            // 
            // btnPrintBoxLabel
            // 
            this.btnPrintBoxLabel.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.btnPrintBoxLabel.Appearance.Options.UseFont = true;
            this.btnPrintBoxLabel.Location = new System.Drawing.Point(424, 28);
            this.btnPrintBoxLabel.Name = "btnPrintBoxLabel";
            this.btnPrintBoxLabel.Size = new System.Drawing.Size(79, 32);
            this.btnPrintBoxLabel.TabIndex = 2;
            this.btnPrintBoxLabel.Text = "打印标签";
            this.btnPrintBoxLabel.Click += new System.EventHandler(this.btnPrintBoxLabel_Click);
            // 
            // edtBoxNumber
            // 
            this.edtBoxNumber.EditValue = "";
            this.edtBoxNumber.EnterMoveNextControl = true;
            this.edtBoxNumber.Location = new System.Drawing.Point(104, 34);
            this.edtBoxNumber.Name = "edtBoxNumber";
            this.edtBoxNumber.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.edtBoxNumber.Properties.Appearance.Options.UseFont = true;
            this.edtBoxNumber.Size = new System.Drawing.Size(286, 20);
            this.edtBoxNumber.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.labelControl1.Location = new System.Drawing.Point(14, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "请输入筒号：";
            // 
            // ucPackageLabelPrintAgain
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Name = "ucPackageLabelPrintAgain";
            this.Size = new System.Drawing.Size(882, 551);
            this.Load += new System.EventHandler(this.ucPackageLabelPrintAgain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPrinters.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBoxNumber.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboPrinters;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtBoxNumber;
        private DevExpress.XtraEditors.SimpleButton btnPrintBoxLabel;
    }
}
