namespace IRAPPrinterServer
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
            this.edtFilterString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gpbGenPDFAndPrintMode = new System.Windows.Forms.GroupBox();
            this.chkGenPDFtoPrint = new System.Windows.Forms.CheckBox();
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPDFPrinterStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gpxESBParams.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpbGenPDFAndPrintMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpxESBParams
            // 
            resources.ApplyResources(this.gpxESBParams, "gpxESBParams");
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
            this.groupBox1.Controls.Add(this.edtUpgradeURL);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
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
            this.groupBox2.Controls.Add(this.edtFilterString);
            this.groupBox2.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // edtFilterString
            // 
            resources.ApplyResources(this.edtFilterString, "edtFilterString");
            this.edtFilterString.Name = "edtFilterString";
            this.edtFilterString.Validated += new System.EventHandler(this.edtT133Code_Validated);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // gpbGenPDFAndPrintMode
            // 
            this.gpbGenPDFAndPrintMode.Controls.Add(this.chkGenPDFtoPrint);
            this.gpbGenPDFAndPrintMode.Controls.Add(this.cboPrinter);
            this.gpbGenPDFAndPrintMode.Controls.Add(this.label4);
            this.gpbGenPDFAndPrintMode.Controls.Add(this.lblPDFPrinterStatus);
            this.gpbGenPDFAndPrintMode.Controls.Add(this.label3);
            resources.ApplyResources(this.gpbGenPDFAndPrintMode, "gpbGenPDFAndPrintMode");
            this.gpbGenPDFAndPrintMode.Name = "gpbGenPDFAndPrintMode";
            this.gpbGenPDFAndPrintMode.TabStop = false;
            // 
            // chkGenPDFtoPrint
            // 
            resources.ApplyResources(this.chkGenPDFtoPrint, "chkGenPDFtoPrint");
            this.chkGenPDFtoPrint.Name = "chkGenPDFtoPrint";
            this.chkGenPDFtoPrint.UseVisualStyleBackColor = true;
            this.chkGenPDFtoPrint.CheckedChanged += new System.EventHandler(this.chkGenPDFtoPrint_CheckedChanged);
            // 
            // cboPrinter
            // 
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.FormattingEnabled = true;
            resources.ApplyResources(this.cboPrinter, "cboPrinter");
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.SelectedIndexChanged += new System.EventHandler(this.cboPrinter_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lblPDFPrinterStatus
            // 
            resources.ApplyResources(this.lblPDFPrinterStatus, "lblPDFPrinterStatus");
            this.lblPDFPrinterStatus.Name = "lblPDFPrinterStatus";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // frmSystemParams
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gpbGenPDFAndPrintMode);
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
            this.gpbGenPDFAndPrintMode.ResumeLayout(false);
            this.gpbGenPDFAndPrintMode.PerformLayout();
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
        private System.Windows.Forms.TextBox edtFilterString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpbGenPDFAndPrintMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPDFPrinterStatus;
        private System.Windows.Forms.ComboBox cboPrinter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkGenPDFtoPrint;
    }
}