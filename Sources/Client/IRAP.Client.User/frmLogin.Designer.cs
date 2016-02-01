namespace IRAP.Client.User
{
    partial class frmLogin
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.edtUserCode = new IRAP.Client.Global.Controls.IRAPTextBox();
            this.edtUserPWD = new IRAP.Client.Global.Controls.IRAPTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.cboAgencies = new Telerik.WinControls.UI.RadDropDownList();
            this.cboRoles = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.chkChangePWD = new Telerik.WinControls.UI.RadCheckBox();
            this.btnLogin = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserPWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgencies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChangePWD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(584, 227);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(81, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "用户(&U)：";
            // 
            // edtUserCode
            // 
            this.edtUserCode.EnterMoveNextControl = true;
            this.edtUserCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUserCode.Location = new System.Drawing.Point(671, 227);
            this.edtUserCode.Name = "edtUserCode";
            this.edtUserCode.Size = new System.Drawing.Size(168, 27);
            this.edtUserCode.TabIndex = 1;
            this.edtUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtUserCode_KeyDown);
            this.edtUserCode.Leave += new System.EventHandler(this.edtUserCode_Leave);
            // 
            // edtUserPWD
            // 
            this.edtUserPWD.EnterMoveNextControl = true;
            this.edtUserPWD.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUserPWD.Location = new System.Drawing.Point(671, 258);
            this.edtUserPWD.Name = "edtUserPWD";
            this.edtUserPWD.PasswordChar = '●';
            this.edtUserPWD.Size = new System.Drawing.Size(168, 27);
            this.edtUserPWD.TabIndex = 3;
            this.edtUserPWD.UseSystemPasswordChar = true;
            this.edtUserPWD.Leave += new System.EventHandler(this.edtUserPWD_Leave);
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(584, 258);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(78, 25);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "密码(&P)：";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(585, 291);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(80, 25);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "机构(&A)：";
            // 
            // cboAgencies
            // 
            this.cboAgencies.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgencies.Location = new System.Drawing.Point(671, 291);
            this.cboAgencies.Name = "cboAgencies";
            this.cboAgencies.Size = new System.Drawing.Size(168, 27);
            this.cboAgencies.TabIndex = 5;
            // 
            // cboRoles
            // 
            this.cboRoles.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoles.Location = new System.Drawing.Point(671, 322);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(168, 27);
            this.cboRoles.TabIndex = 7;
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.Color.Transparent;
            this.radLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(585, 322);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(79, 25);
            this.radLabel4.TabIndex = 6;
            this.radLabel4.Text = "角色(&R)：";
            // 
            // chkChangePWD
            // 
            this.chkChangePWD.BackColor = System.Drawing.Color.Transparent;
            this.chkChangePWD.Enabled = false;
            this.chkChangePWD.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChangePWD.Location = new System.Drawing.Point(277, 380);
            this.chkChangePWD.Name = "chkChangePWD";
            this.chkChangePWD.Size = new System.Drawing.Size(110, 25);
            this.chkChangePWD.TabIndex = 8;
            this.chkChangePWD.TabStop = false;
            this.chkChangePWD.Text = "修改密码(&C)";
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(638, 378);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(85, 30);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(754, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IRAP.Client.User.Properties.Resources.login;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1003, 571);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkChangePWD);
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.cboAgencies);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.edtUserPWD);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.edtUserCode);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmLogin";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserPWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgencies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChangePWD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private IRAP.Client.Global.Controls.IRAPTextBox edtUserCode;
        private IRAP.Client.Global.Controls.IRAPTextBox edtUserPWD;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList cboAgencies;
        private Telerik.WinControls.UI.RadDropDownList cboRoles;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadCheckBox chkChangePWD;
        private Telerik.WinControls.UI.RadButton btnLogin;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
