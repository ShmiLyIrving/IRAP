namespace OPCClient.Dialogs
{
    partial class dlgAddorModifyServer
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
            this.labelcontrol1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtServerAddress = new DevExpress.XtraEditors.TextEdit();
            this.edtServerName = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHead)).BeginInit();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtServerAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtServerName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHead.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.pnlHead.Appearance.Options.UseBackColor = true;
            this.pnlHead.Appearance.Options.UseForeColor = true;
            this.pnlHead.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.pnlHead.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlHead.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlHead.Size = new System.Drawing.Size(379, 33);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.labelcontrol1);
            this.pnlBody.Controls.Add(this.edtServerName);
            this.pnlBody.Controls.Add(this.btnCancel);
            this.pnlBody.Controls.Add(this.btnOK);
            this.pnlBody.Controls.Add(this.edtServerAddress);
            this.pnlBody.Controls.Add(this.labelControl2);
            this.pnlBody.Location = new System.Drawing.Point(0, 33);
            this.pnlBody.Size = new System.Drawing.Size(379, 143);
            this.pnlBody.TabIndex = 0;
            // 
            // labelcontrol1
            // 
            this.labelcontrol1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelcontrol1.Location = new System.Drawing.Point(38, 21);
            this.labelcontrol1.Name = "labelcontrol1";
            this.labelcontrol1.Size = new System.Drawing.Size(84, 20);
            this.labelcontrol1.TabIndex = 0;
            this.labelcontrol1.Text = "服务器地址：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(38, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 20);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "服务器名称：";
            // 
            // edtServerAddress
            // 
            this.edtServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtServerAddress.Location = new System.Drawing.Point(149, 21);
            this.edtServerAddress.Name = "edtServerAddress";
            this.edtServerAddress.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtServerAddress.Properties.Appearance.Options.UseFont = true;
            this.edtServerAddress.Properties.Mask.EditMask = "\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}(:\\d+){0,1}";
            this.edtServerAddress.Properties.Mask.IgnoreMaskBlank = false;
            this.edtServerAddress.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.edtServerAddress.Size = new System.Drawing.Size(190, 26);
            this.edtServerAddress.TabIndex = 1;
            this.edtServerAddress.Tag = "1";
            // 
            // edtServerName
            // 
            this.edtServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtServerName.Location = new System.Drawing.Point(149, 55);
            this.edtServerName.Name = "edtServerName";
            this.edtServerName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtServerName.Properties.Appearance.Options.UseFont = true;
            this.edtServerName.Size = new System.Drawing.Size(190, 26);
            this.edtServerName.TabIndex = 2;
            this.edtServerName.Tag = "2";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(239, 105);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(38, 105);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 29);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "添加";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dlgAddorModifyServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 176);
            this.Name = "dlgAddorModifyServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加服务器";
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHead)).EndInit();
            this.pnlHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtServerAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtServerName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelcontrol1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit edtServerAddress;
        private DevExpress.XtraEditors.TextEdit edtServerName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}