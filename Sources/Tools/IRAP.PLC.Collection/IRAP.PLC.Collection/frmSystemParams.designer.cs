namespace IRAP.PLC.Collection
{
    partial class frmSystemParams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemParams));
            this.gpxESBParams = new System.Windows.Forms.GroupBox();
            this.edtQueueName = new System.Windows.Forms.TextBox();
            this.lblQueueName = new System.Windows.Forms.Label();
            this.edtBrokeURI = new System.Windows.Forms.TextBox();
            this.lblBrokeURI = new System.Windows.Forms.Label();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtUpgradeURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkWriteLog = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtT216Code = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.edtLastCheckPoint = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDeviceType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.edtDeltaTimeSpan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.edtDBFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtT133Code = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.edtExCode = new System.Windows.Forms.TextBox();
            this.gpxESBParams.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDeviceType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gpxESBParams
            // 
            resources.ApplyResources(this.gpxESBParams, "gpxESBParams");
            this.gpxESBParams.Controls.Add(this.edtExCode);
            this.gpxESBParams.Controls.Add(this.label9);
            this.gpxESBParams.Controls.Add(this.edtQueueName);
            this.gpxESBParams.Controls.Add(this.lblQueueName);
            this.gpxESBParams.Controls.Add(this.edtBrokeURI);
            this.gpxESBParams.Controls.Add(this.lblBrokeURI);
            this.gpxESBParams.Name = "gpxESBParams";
            this.gpxESBParams.TabStop = false;
            // 
            // edtQueueName
            // 
            resources.ApplyResources(this.edtQueueName, "edtQueueName");
            this.edtQueueName.Name = "edtQueueName";
            this.edtQueueName.Validated += new System.EventHandler(this.edtQueueName_Validated);
            // 
            // lblQueueName
            // 
            resources.ApplyResources(this.lblQueueName, "lblQueueName");
            this.lblQueueName.Name = "lblQueueName";
            // 
            // edtBrokeURI
            // 
            resources.ApplyResources(this.edtBrokeURI, "edtBrokeURI");
            this.edtBrokeURI.Name = "edtBrokeURI";
            this.edtBrokeURI.Validated += new System.EventHandler(this.edtBrokeURI_Validated);
            // 
            // lblBrokeURI
            // 
            resources.ApplyResources(this.lblBrokeURI, "lblBrokeURI");
            this.lblBrokeURI.Name = "lblBrokeURI";
            // 
            // btnSwitch
            // 
            resources.ApplyResources(this.btnSwitch, "btnSwitch");
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.TabStop = false;
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.edtUpgradeURL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // edtUpgradeURL
            // 
            resources.ApplyResources(this.edtUpgradeURL, "edtUpgradeURL");
            this.edtUpgradeURL.Name = "edtUpgradeURL";
            this.edtUpgradeURL.Validated += new System.EventHandler(this.edtUpgradeURL_Validated);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkWriteLog
            // 
            resources.ApplyResources(this.chkWriteLog, "chkWriteLog");
            this.chkWriteLog.Name = "chkWriteLog";
            this.chkWriteLog.UseVisualStyleBackColor = true;
            this.chkWriteLog.CheckedChanged += new System.EventHandler(this.chkWriteLog_CheckedChanged);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.edtT216Code);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.edtLastCheckPoint);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cboDeviceType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.edtDeltaTimeSpan);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSelectFile);
            this.groupBox2.Controls.Add(this.edtDBFileName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.edtT133Code);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // edtT216Code
            // 
            resources.ApplyResources(this.edtT216Code, "edtT216Code");
            this.edtT216Code.Name = "edtT216Code";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Name = "label7";
            // 
            // edtLastCheckPoint
            // 
            resources.ApplyResources(this.edtLastCheckPoint, "edtLastCheckPoint");
            this.edtLastCheckPoint.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtLastCheckPoint.Name = "edtLastCheckPoint";
            this.edtLastCheckPoint.ValueChanged += new System.EventHandler(this.edtLastCheckPoint_ValueChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // cboDeviceType
            // 
            resources.ApplyResources(this.cboDeviceType, "cboDeviceType");
            this.cboDeviceType.Name = "cboDeviceType";
            this.cboDeviceType.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cboDeviceType.Properties.Appearance.Font")));
            this.cboDeviceType.Properties.Appearance.Options.UseFont = true;
            this.cboDeviceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboDeviceType.Properties.Buttons"))))});
            this.cboDeviceType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDeviceType.SelectedIndexChanged += new System.EventHandler(this.cboDeviceType_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // edtDeltaTimeSpan
            // 
            resources.ApplyResources(this.edtDeltaTimeSpan, "edtDeltaTimeSpan");
            this.edtDeltaTimeSpan.Name = "edtDeltaTimeSpan";
            this.edtDeltaTimeSpan.Validated += new System.EventHandler(this.edtDeltaTimeSpan_Validated);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btnSelectFile
            // 
            resources.ApplyResources(this.btnSelectFile, "btnSelectFile");
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.TabStop = false;
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // edtDBFileName
            // 
            resources.ApplyResources(this.edtDBFileName, "edtDBFileName");
            this.edtDBFileName.Name = "edtDBFileName";
            this.edtDBFileName.Validating += new System.ComponentModel.CancelEventHandler(this.edtDBFileName_Validating);
            this.edtDBFileName.Validated += new System.EventHandler(this.edtDBFileName_Validated);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // edtT133Code
            // 
            resources.ApplyResources(this.edtT133Code, "edtT133Code");
            this.edtT133Code.Name = "edtT133Code";
            this.edtT133Code.Validated += new System.EventHandler(this.edtT133Code_Validated);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "mdb";
            this.openFileDialog.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // edtExCode
            // 
            resources.ApplyResources(this.edtExCode, "edtExCode");
            this.edtExCode.Name = "edtExCode";
            this.edtExCode.Validated += new System.EventHandler(this.edtExCode_Validated);
            // 
            // frmSystemParams
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkWriteLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.gpxESBParams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSystemParams";
            this.Load += new System.EventHandler(this.frmSystemParams_Load);
            this.gpxESBParams.ResumeLayout(false);
            this.gpxESBParams.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDeviceType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpxESBParams;
        private System.Windows.Forms.Label lblBrokeURI;
        private System.Windows.Forms.TextBox edtQueueName;
        private System.Windows.Forms.Label lblQueueName;
        private System.Windows.Forms.TextBox edtBrokeURI;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox edtUpgradeURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkWriteLog;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox edtT133Code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox edtDBFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox edtDeltaTimeSpan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.ComboBoxEdit cboDeviceType;
        private System.Windows.Forms.DateTimePicker edtLastCheckPoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edtT216Code;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox edtExCode;
        private System.Windows.Forms.Label label9;
    }
}