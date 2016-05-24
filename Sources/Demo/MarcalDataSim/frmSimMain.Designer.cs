namespace MarcalDataSim
{
    partial class frmSimMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSimMain));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtSimData = new DevExpress.XtraEditors.TextEdit();
            this.mmeLogs = new DevExpress.XtraEditors.MemoEdit();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.rgpUnifOfMeasure = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.edtSimData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeLogs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpUnifOfMeasure.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Location = new System.Drawing.Point(14, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(128, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "模拟的量仪数据：";
            // 
            // edtSimData
            // 
            this.edtSimData.Location = new System.Drawing.Point(148, 9);
            this.edtSimData.Name = "edtSimData";
            this.edtSimData.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edtSimData.Properties.Appearance.Options.UseFont = true;
            this.edtSimData.Size = new System.Drawing.Size(96, 22);
            this.edtSimData.TabIndex = 1;
            // 
            // mmeLogs
            // 
            this.mmeLogs.Location = new System.Drawing.Point(14, 45);
            this.mmeLogs.Name = "mmeLogs";
            this.mmeLogs.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mmeLogs.Properties.Appearance.Options.UseFont = true;
            this.mmeLogs.Properties.ReadOnly = true;
            this.mmeLogs.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mmeLogs.Size = new System.Drawing.Size(393, 247);
            this.mmeLogs.TabIndex = 4;
            // 
            // btnSend
            // 
            this.btnSend.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Appearance.Options.UseFont = true;
            this.btnSend.Location = new System.Drawing.Point(426, 10);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(426, 269);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Metropolis";
            // 
            // rgpUnifOfMeasure
            // 
            this.rgpUnifOfMeasure.EditValue = "mm";
            this.rgpUnifOfMeasure.Location = new System.Drawing.Point(260, 8);
            this.rgpUnifOfMeasure.Name = "rgpUnifOfMeasure";
            this.rgpUnifOfMeasure.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgpUnifOfMeasure.Properties.Appearance.Options.UseFont = true;
            this.rgpUnifOfMeasure.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgpUnifOfMeasure.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("um", "um"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("mm", "mm")});
            this.rgpUnifOfMeasure.Size = new System.Drawing.Size(115, 27);
            this.rgpUnifOfMeasure.TabIndex = 7;
            // 
            // frmSimMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(513, 304);
            this.Controls.Add(this.rgpUnifOfMeasure);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.mmeLogs);
            this.Controls.Add(this.edtSimData);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Metropolis";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSimMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSimMain";
            ((System.ComponentModel.ISupportInitialize)(this.edtSimData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeLogs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpUnifOfMeasure.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtSimData;
        private DevExpress.XtraEditors.MemoEdit mmeLogs;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraEditors.RadioGroup rgpUnifOfMeasure;
    }
}