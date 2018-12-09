namespace IRAPWebAPIClient
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExTest = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.edtExCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtClientID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboContextType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboModuleName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtRequest = new DevExpress.XtraEditors.MemoEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.edtResponse = new DevExpress.XtraEditors.MemoEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtRequest.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtResponse.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExTest);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.edtExCode);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.edtClientID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboContextType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboModuleName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.edtAddress);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 117);
            this.panel1.TabIndex = 0;
            // 
            // btnExTest
            // 
            this.btnExTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExTest.Location = new System.Drawing.Point(693, 12);
            this.btnExTest.Name = "btnExTest";
            this.btnExTest.Size = new System.Drawing.Size(94, 38);
            this.btnExTest.TabIndex = 11;
            this.btnExTest.Text = "交易测试";
            this.btnExTest.UseVisualStyleBackColor = true;
            this.btnExTest.Visible = false;
            this.btnExTest.Click += new System.EventHandler(this.btnExTest_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(693, 67);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 38);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "提交";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // edtExCode
            // 
            this.edtExCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtExCode.Location = new System.Drawing.Point(107, 73);
            this.edtExCode.Name = "edtExCode";
            this.edtExCode.Size = new System.Drawing.Size(562, 23);
            this.edtExCode.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "交易代码：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtClientID
            // 
            this.edtClientID.Location = new System.Drawing.Point(541, 41);
            this.edtClientID.Name = "edtClientID";
            this.edtClientID.Size = new System.Drawing.Size(128, 23);
            this.edtClientID.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(434, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "客户 ID：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboContextType
            // 
            this.cboContextType.FormattingEnabled = true;
            this.cboContextType.Items.AddRange(new object[] {
            "json",
            "xml"});
            this.cboContextType.Location = new System.Drawing.Point(341, 39);
            this.cboContextType.Name = "cboContextType";
            this.cboContextType.Size = new System.Drawing.Size(87, 25);
            this.cboContextType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(234, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "报文类型：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboModuleName
            // 
            this.cboModuleName.FormattingEnabled = true;
            this.cboModuleName.Items.AddRange(new object[] {
            "Exchange"});
            this.cboModuleName.Location = new System.Drawing.Point(107, 39);
            this.cboModuleName.Name = "cboModuleName";
            this.cboModuleName.Size = new System.Drawing.Size(121, 25);
            this.cboModuleName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "模块：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // edtAddress
            // 
            this.edtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAddress.Location = new System.Drawing.Point(107, 7);
            this.edtAddress.Name = "edtAddress";
            this.edtAddress.Size = new System.Drawing.Size(418, 23);
            this.edtAddress.TabIndex = 1;
            this.edtAddress.Text = "http://127.0.0.1:55552/";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 117);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(808, 498);
            this.splitContainer1.SplitterDistance = 168;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtRequest);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(798, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请求报文";
            // 
            // edtRequest
            // 
            this.edtRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtRequest.Location = new System.Drawing.Point(10, 26);
            this.edtRequest.Name = "edtRequest";
            this.edtRequest.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 10.5F);
            this.edtRequest.Properties.Appearance.Options.UseFont = true;
            this.edtRequest.Size = new System.Drawing.Size(778, 122);
            this.edtRequest.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtResponse);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(798, 316);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "响应报文";
            // 
            // edtResponse
            // 
            this.edtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtResponse.Location = new System.Drawing.Point(10, 26);
            this.edtResponse.Name = "edtResponse";
            this.edtResponse.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 10.5F);
            this.edtResponse.Properties.Appearance.Options.UseFont = true;
            this.edtResponse.Size = new System.Drawing.Size(778, 280);
            this.edtResponse.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(808, 615);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IRAP-GeneralGateway Client Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtRequest.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtResponse.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox edtExCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edtClientID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboContextType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboModuleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExTest;
        private DevExpress.XtraEditors.MemoEdit edtResponse;
        private DevExpress.XtraEditors.MemoEdit edtRequest;
    }
}

