namespace IRAP.Client.User
{
    partial class frmLogin
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtUserCode = new DevExpress.XtraEditors.TextEdit();
            this.edtUserPWD = new DevExpress.XtraEditors.TextEdit();
            this.cboAgencies = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboRoles = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.chkChangePWD = new DevExpress.XtraEditors.CheckEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgencies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChangePWD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(595, 224);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用户(&U)：";
            // 
            // edtUserCode
            // 
            this.edtUserCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserCode.EnterMoveNextControl = true;
            this.edtUserCode.Location = new System.Drawing.Point(671, 221);
            this.edtUserCode.Name = "edtUserCode";
            this.edtUserCode.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUserCode.Properties.Appearance.Options.UseFont = true;
            this.edtUserCode.Size = new System.Drawing.Size(171, 28);
            this.edtUserCode.TabIndex = 1;
            this.edtUserCode.Leave += new System.EventHandler(this.edtUserCode_Leave);
            // 
            // edtUserPWD
            // 
            this.edtUserPWD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserPWD.EnterMoveNextControl = true;
            this.edtUserPWD.Location = new System.Drawing.Point(671, 255);
            this.edtUserPWD.Name = "edtUserPWD";
            this.edtUserPWD.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUserPWD.Properties.Appearance.Options.UseFont = true;
            this.edtUserPWD.Properties.UseSystemPasswordChar = true;
            this.edtUserPWD.Size = new System.Drawing.Size(171, 28);
            this.edtUserPWD.TabIndex = 2;
            this.edtUserPWD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtUserPWD_KeyDown);
            this.edtUserPWD.Validating += new System.ComponentModel.CancelEventHandler(this.edtUserPWD_Validating);
            // 
            // cboAgencies
            // 
            this.cboAgencies.Enabled = false;
            this.cboAgencies.EnterMoveNextControl = true;
            this.cboAgencies.Location = new System.Drawing.Point(671, 289);
            this.cboAgencies.Name = "cboAgencies";
            this.cboAgencies.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgencies.Properties.Appearance.Options.UseFont = true;
            this.cboAgencies.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgencies.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboAgencies.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgencies.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboAgencies.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgencies.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboAgencies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAgencies.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAgencies.Size = new System.Drawing.Size(171, 28);
            this.cboAgencies.TabIndex = 3;
            // 
            // cboRoles
            // 
            this.cboRoles.Enabled = false;
            this.cboRoles.EnterMoveNextControl = true;
            this.cboRoles.Location = new System.Drawing.Point(671, 323);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoles.Properties.Appearance.Options.UseFont = true;
            this.cboRoles.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoles.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboRoles.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoles.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboRoles.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoles.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboRoles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRoles.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboRoles.Size = new System.Drawing.Size(171, 28);
            this.cboRoles.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(595, 258);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 21);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "密码(&P)：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(595, 292);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 21);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "机构(&A)：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(595, 326);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 21);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "角色(&R)：";
            // 
            // chkChangePWD
            // 
            this.chkChangePWD.Enabled = false;
            this.chkChangePWD.Location = new System.Drawing.Point(272, 382);
            this.chkChangePWD.Name = "chkChangePWD";
            this.chkChangePWD.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChangePWD.Properties.Appearance.Options.UseFont = true;
            this.chkChangePWD.Properties.Caption = "修改密码(&C)";
            this.chkChangePWD.Size = new System.Drawing.Size(130, 25);
            this.chkChangePWD.TabIndex = 8;
            this.chkChangePWD.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(638, 378);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(85, 30);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(757, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            // 
            // frmLogin
            // 
            this.Appearance.Options.UseFont = true;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::IRAP.Client.User.Properties.Resources.login;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1003, 571);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkChangePWD);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.cboAgencies);
            this.Controls.Add(this.edtUserPWD);
            this.Controls.Add(this.edtUserCode);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.ShowInTaskbar = true;
            this.Text = "用户登录";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.edtUserCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgencies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChangePWD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtUserCode;
        private DevExpress.XtraEditors.TextEdit edtUserPWD;
        private DevExpress.XtraEditors.ComboBoxEdit cboAgencies;
        private DevExpress.XtraEditors.ComboBoxEdit cboRoles;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit chkChangePWD;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
