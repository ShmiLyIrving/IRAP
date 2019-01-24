namespace IRAP_MaterialRequestImport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtUserPWD = new DevExpress.XtraEditors.TextEdit();
            this.edtUserCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboAgencies = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboRoles = new DevExpress.XtraEditors.ComboBoxEdit();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtUserPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgencies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoles.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(758, 379);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取消";
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(639, 379);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(85, 30);
            this.btnLogin.TabIndex = 19;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl4.Location = new System.Drawing.Point(596, 323);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 14);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "角色(&R)：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Location = new System.Drawing.Point(596, 297);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 14);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "机构(&A)：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Location = new System.Drawing.Point(596, 271);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 14);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "密码(&P)：";
            // 
            // edtUserPWD
            // 
            this.edtUserPWD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserPWD.EnterMoveNextControl = true;
            this.edtUserPWD.Location = new System.Drawing.Point(665, 268);
            this.edtUserPWD.Name = "edtUserPWD";
            this.edtUserPWD.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edtUserPWD.Properties.Appearance.Options.UseFont = true;
            this.edtUserPWD.Properties.UseSystemPasswordChar = true;
            this.edtUserPWD.Size = new System.Drawing.Size(178, 20);
            this.edtUserPWD.TabIndex = 2;
            this.edtUserPWD.Validating += new System.ComponentModel.CancelEventHandler(this.edtUserPWD_Validating);
            // 
            // edtUserCode
            // 
            this.edtUserCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserCode.EnterMoveNextControl = true;
            this.edtUserCode.Location = new System.Drawing.Point(665, 242);
            this.edtUserCode.Name = "edtUserCode";
            this.edtUserCode.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edtUserCode.Properties.Appearance.Options.UseFont = true;
            this.edtUserCode.Size = new System.Drawing.Size(178, 20);
            this.edtUserCode.TabIndex = 1;
            this.edtUserCode.Validating += new System.ComponentModel.CancelEventHandler(this.edtUserCode_Validating);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Location = new System.Drawing.Point(596, 245);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "用户(&U)：";
            // 
            // cboAgencies
            // 
            this.cboAgencies.Enabled = false;
            this.cboAgencies.Location = new System.Drawing.Point(665, 294);
            this.cboAgencies.Name = "cboAgencies";
            this.cboAgencies.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgencies.Properties.Appearance.Options.UseFont = true;
            this.cboAgencies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAgencies.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAgencies.Size = new System.Drawing.Size(178, 20);
            this.cboAgencies.TabIndex = 3;
            // 
            // cboRoles
            // 
            this.cboRoles.Enabled = false;
            this.cboRoles.Location = new System.Drawing.Point(665, 320);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoles.Properties.Appearance.Options.UseFont = true;
            this.cboRoles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRoles.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboRoles.Size = new System.Drawing.Size(178, 20);
            this.cboRoles.TabIndex = 21;
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Xmas 2008 Blue";
            // 
            // frmLogin
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1003, 571);
            this.ControlBox = false;
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.cboAgencies);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.edtUserPWD);
            this.Controls.Add(this.edtUserCode);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.edtUserPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgencies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoles.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit edtUserPWD;
        private DevExpress.XtraEditors.TextEdit edtUserCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboAgencies;
        private DevExpress.XtraEditors.ComboBoxEdit cboRoles;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
    }
}