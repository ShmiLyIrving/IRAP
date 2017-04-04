namespace VA_ITCMS2000
{
    partial class frmSysParams
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
            this.tcParams = new System.Windows.Forms.TabControl();
            this.tpDBParams = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edtRefreshTimeSpan = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtDBName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edtDBUserPWD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtDBUserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtDBAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpMS2000 = new System.Windows.Forms.TabPage();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.edtStationID = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.edtIPServUserPWD = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edtIPServUserID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.edtIPServAddr = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tcParams.SuspendLayout();
            this.tpDBParams.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtRefreshTimeSpan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tpMS2000.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcParams
            // 
            this.tcParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcParams.Controls.Add(this.tpDBParams);
            this.tcParams.Controls.Add(this.tpMS2000);
            this.tcParams.Location = new System.Drawing.Point(12, 12);
            this.tcParams.Name = "tcParams";
            this.tcParams.SelectedIndex = 0;
            this.tcParams.Size = new System.Drawing.Size(717, 481);
            this.tcParams.TabIndex = 0;
            // 
            // tpDBParams
            // 
            this.tpDBParams.Controls.Add(this.groupBox2);
            this.tpDBParams.Controls.Add(this.groupBox1);
            this.tpDBParams.Location = new System.Drawing.Point(4, 29);
            this.tpDBParams.Name = "tpDBParams";
            this.tpDBParams.Padding = new System.Windows.Forms.Padding(3);
            this.tpDBParams.Size = new System.Drawing.Size(709, 448);
            this.tpDBParams.TabIndex = 0;
            this.tpDBParams.Text = "数据库参数";
            this.tpDBParams.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.edtStationID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.edtRefreshTimeSpan);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(697, 96);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "毫秒";
            // 
            // edtRefreshTimeSpan
            // 
            this.edtRefreshTimeSpan.Location = new System.Drawing.Point(156, 20);
            this.edtRefreshTimeSpan.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.edtRefreshTimeSpan.Name = "edtRefreshTimeSpan";
            this.edtRefreshTimeSpan.Size = new System.Drawing.Size(81, 26);
            this.edtRefreshTimeSpan.TabIndex = 9;
            this.edtRefreshTimeSpan.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "数据刷新间隔时间：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.edtDBName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.edtDBUserPWD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.edtDBUserID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.edtDBAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库连接参数";
            // 
            // edtDBName
            // 
            this.edtDBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDBName.Location = new System.Drawing.Point(114, 115);
            this.edtDBName.Name = "edtDBName";
            this.edtDBName.Size = new System.Drawing.Size(569, 26);
            this.edtDBName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "数据库名：";
            // 
            // edtDBUserPWD
            // 
            this.edtDBUserPWD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDBUserPWD.Location = new System.Drawing.Point(114, 83);
            this.edtDBUserPWD.Name = "edtDBUserPWD";
            this.edtDBUserPWD.PasswordChar = '*';
            this.edtDBUserPWD.Size = new System.Drawing.Size(569, 26);
            this.edtDBUserPWD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码：";
            // 
            // edtDBUserID
            // 
            this.edtDBUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDBUserID.Location = new System.Drawing.Point(114, 51);
            this.edtDBUserID.Name = "edtDBUserID";
            this.edtDBUserID.Size = new System.Drawing.Size(569, 26);
            this.edtDBUserID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名：";
            // 
            // edtDBAddress
            // 
            this.edtDBAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDBAddress.Location = new System.Drawing.Point(114, 19);
            this.edtDBAddress.Name = "edtDBAddress";
            this.edtDBAddress.Size = new System.Drawing.Size(569, 26);
            this.edtDBAddress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库地址：";
            // 
            // tpMS2000
            // 
            this.tpMS2000.Controls.Add(this.groupBox3);
            this.tpMS2000.Location = new System.Drawing.Point(4, 29);
            this.tpMS2000.Name = "tpMS2000";
            this.tpMS2000.Padding = new System.Windows.Forms.Padding(3);
            this.tpMS2000.Size = new System.Drawing.Size(709, 448);
            this.tpMS2000.TabIndex = 1;
            this.tpMS2000.Text = "IP 广播参数";
            this.tpMS2000.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(555, 499);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(643, 499);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "广播消息过滤串：";
            // 
            // edtStationID
            // 
            this.edtStationID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStationID.Location = new System.Drawing.Point(156, 52);
            this.edtStationID.Name = "edtStationID";
            this.edtStationID.Size = new System.Drawing.Size(527, 26);
            this.edtStationID.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.edtIPServUserPWD);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.edtIPServUserID);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.edtIPServAddr);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(697, 120);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IP 广播服务器参数";
            // 
            // edtIPServUserPWD
            // 
            this.edtIPServUserPWD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIPServUserPWD.Location = new System.Drawing.Point(114, 83);
            this.edtIPServUserPWD.Name = "edtIPServUserPWD";
            this.edtIPServUserPWD.PasswordChar = '*';
            this.edtIPServUserPWD.Size = new System.Drawing.Size(569, 26);
            this.edtIPServUserPWD.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "密码：";
            // 
            // edtIPServUserID
            // 
            this.edtIPServUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIPServUserID.Location = new System.Drawing.Point(114, 51);
            this.edtIPServUserID.Name = "edtIPServUserID";
            this.edtIPServUserID.Size = new System.Drawing.Size(569, 26);
            this.edtIPServUserID.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "用户名：";
            // 
            // edtIPServAddr
            // 
            this.edtIPServAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIPServAddr.Location = new System.Drawing.Point(114, 19);
            this.edtIPServAddr.Name = "edtIPServAddr";
            this.edtIPServAddr.Size = new System.Drawing.Size(569, 26);
            this.edtIPServAddr.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "服务器地址：";
            // 
            // frmSysParams
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(741, 539);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tcParams);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSysParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.frmSysParams_Load);
            this.tcParams.ResumeLayout(false);
            this.tpDBParams.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtRefreshTimeSpan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpMS2000.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcParams;
        private System.Windows.Forms.TabPage tpDBParams;
        private System.Windows.Forms.TabPage tpMS2000;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox edtDBName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtDBUserPWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtDBUserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtDBAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown edtRefreshTimeSpan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtStationID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox edtIPServUserPWD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox edtIPServUserID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox edtIPServAddr;
        private System.Windows.Forms.Label label11;
    }
}