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
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnPrintCartonLabel = new DevExpress.XtraEditors.SimpleButton();
            this.edtCartonNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.rbByCartonNumber = new DevExpress.XtraEditors.CheckEdit();
            this.rbByMONumber = new DevExpress.XtraEditors.CheckEdit();
            this.edtMONumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.edtMOLineNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrinters.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBoxNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtCartonNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbByCartonNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbByMONumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMONumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMOLineNo.Properties)).BeginInit();
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
            this.groupControl2.TabIndex = 1;
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
            this.cboPrinters.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPrinters.Size = new System.Drawing.Size(504, 20);
            this.cboPrinters.TabIndex = 11;
            this.cboPrinters.SelectedIndexChanged += new System.EventHandler(this.cboPrinters_SelectedIndexChanged);
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
            this.groupControl1.Location = new System.Drawing.Point(13, 259);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(533, 66);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "补打内标签";
            // 
            // btnPrintBoxLabel
            // 
            this.btnPrintBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.edtBoxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // groupControl3
            // 
            this.groupControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl3.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.Appearance.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.btnPrintCartonLabel);
            this.groupControl3.Controls.Add(this.edtMOLineNo);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.edtMONumber);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.rbByMONumber);
            this.groupControl3.Controls.Add(this.rbByCartonNumber);
            this.groupControl3.Controls.Add(this.edtCartonNumber);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Location = new System.Drawing.Point(13, 84);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(533, 169);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "补打外标签";
            // 
            // btnPrintCartonLabel
            // 
            this.btnPrintCartonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintCartonLabel.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.btnPrintCartonLabel.Appearance.Options.UseFont = true;
            this.btnPrintCartonLabel.Location = new System.Drawing.Point(424, 27);
            this.btnPrintCartonLabel.Name = "btnPrintCartonLabel";
            this.btnPrintCartonLabel.Size = new System.Drawing.Size(79, 32);
            this.btnPrintCartonLabel.TabIndex = 2;
            this.btnPrintCartonLabel.Text = "打印标签";
            this.btnPrintCartonLabel.Click += new System.EventHandler(this.btnPrintCartonLabel_Click);
            // 
            // edtCartonNumber
            // 
            this.edtCartonNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtCartonNumber.EditValue = "";
            this.edtCartonNumber.EnterMoveNextControl = true;
            this.edtCartonNumber.Location = new System.Drawing.Point(160, 58);
            this.edtCartonNumber.Name = "edtCartonNumber";
            this.edtCartonNumber.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.edtCartonNumber.Properties.Appearance.Options.UseFont = true;
            this.edtCartonNumber.Size = new System.Drawing.Size(230, 20);
            this.edtCartonNumber.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.labelControl2.Location = new System.Drawing.Point(28, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(126, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "请输入外箱标签号：";
            // 
            // rbByCartonNumber
            // 
            this.rbByCartonNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbByCartonNumber.Location = new System.Drawing.Point(14, 33);
            this.rbByCartonNumber.Name = "rbByCartonNumber";
            this.rbByCartonNumber.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.rbByCartonNumber.Properties.Appearance.Options.UseFont = true;
            this.rbByCartonNumber.Properties.Caption = "按外箱标签号";
            this.rbByCartonNumber.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rbByCartonNumber.Properties.RadioGroupIndex = 1;
            this.rbByCartonNumber.Size = new System.Drawing.Size(376, 19);
            this.rbByCartonNumber.TabIndex = 0;
            this.rbByCartonNumber.CheckedChanged += new System.EventHandler(this.rbByCartonNumber_CheckedChanged);
            // 
            // rbByMONumber
            // 
            this.rbByMONumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbByMONumber.Location = new System.Drawing.Point(14, 84);
            this.rbByMONumber.Name = "rbByMONumber";
            this.rbByMONumber.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.rbByMONumber.Properties.Appearance.Options.UseFont = true;
            this.rbByMONumber.Properties.Caption = "按订单号和行号";
            this.rbByMONumber.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rbByMONumber.Properties.RadioGroupIndex = 1;
            this.rbByMONumber.Size = new System.Drawing.Size(376, 19);
            this.rbByMONumber.TabIndex = 2;
            this.rbByMONumber.TabStop = false;
            // 
            // edtMONumber
            // 
            this.edtMONumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMONumber.EditValue = "";
            this.edtMONumber.Enabled = false;
            this.edtMONumber.EnterMoveNextControl = true;
            this.edtMONumber.Location = new System.Drawing.Point(160, 109);
            this.edtMONumber.Name = "edtMONumber";
            this.edtMONumber.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.edtMONumber.Properties.Appearance.Options.UseFont = true;
            this.edtMONumber.Size = new System.Drawing.Size(230, 20);
            this.edtMONumber.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.labelControl3.Location = new System.Drawing.Point(28, 112);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(98, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "请输入订单号：";
            // 
            // edtMOLineNo
            // 
            this.edtMOLineNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMOLineNo.EditValue = "";
            this.edtMOLineNo.Enabled = false;
            this.edtMOLineNo.EnterMoveNextControl = true;
            this.edtMOLineNo.Location = new System.Drawing.Point(160, 135);
            this.edtMOLineNo.Name = "edtMOLineNo";
            this.edtMOLineNo.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.edtMOLineNo.Properties.Appearance.Options.UseFont = true;
            this.edtMOLineNo.Size = new System.Drawing.Size(230, 20);
            this.edtMOLineNo.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.labelControl4.Location = new System.Drawing.Point(28, 138);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 14);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "请输入行号：";
            // 
            // ucPackageLabelPrintAgain
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupControl3);
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtCartonNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbByCartonNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbByMONumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMONumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMOLineNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboPrinters;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtBoxNumber;
        private DevExpress.XtraEditors.SimpleButton btnPrintBoxLabel;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnPrintCartonLabel;
        private DevExpress.XtraEditors.TextEdit edtCartonNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit edtMOLineNo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit edtMONumber;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit rbByMONumber;
        private DevExpress.XtraEditors.CheckEdit rbByCartonNumber;
    }
}
