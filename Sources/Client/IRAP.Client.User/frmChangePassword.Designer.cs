namespace IRAP.Client.User
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtPassword = new DevExpress.XtraEditors.TextEdit();
            this.edtConfPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtConfPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl2.Appearance.Font")));
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // edtPassword
            // 
            resources.ApplyResources(this.edtPassword, "edtPassword");
            this.edtPassword.EnterMoveNextControl = true;
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtPassword.Properties.Appearance.Font")));
            this.edtPassword.Properties.Appearance.Options.UseFont = true;
            this.edtPassword.Properties.UseSystemPasswordChar = true;
            this.edtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.edtPassword_Validating);
            // 
            // edtConfPassword
            // 
            resources.ApplyResources(this.edtConfPassword, "edtConfPassword");
            this.edtConfPassword.EnterMoveNextControl = true;
            this.edtConfPassword.Name = "edtConfPassword";
            this.edtConfPassword.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtConfPassword.Properties.Appearance.Font")));
            this.edtConfPassword.Properties.Appearance.Options.UseFont = true;
            this.edtConfPassword.Properties.UseSystemPasswordChar = true;
            this.edtConfPassword.Validating += new System.ComponentModel.CancelEventHandler(this.edtPassword_Validating);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl1.Appearance.Font")));
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnCancel.Appearance.Font")));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnOK.Appearance.Font")));
            this.btnOK.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmChangePassword
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.edtConfPassword);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.edtPassword);
            this.Name = "frmChangePassword";
            ((System.ComponentModel.ISupportInitialize)(this.edtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtConfPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit edtPassword;
        private DevExpress.XtraEditors.TextEdit edtConfPassword;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}
