namespace IRAP.Client.Global.GUI.Dialogs
{
    partial class frmReadUserIDCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadUserIDCard));
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.edtIDCardNo = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblCaption.Appearance.Font")));
            this.lblCaption.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblCaption.Appearance.ForeColor")));
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCaption.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblCaption, "lblCaption");
            this.lblCaption.Name = "lblCaption";
            // 
            // edtIDCardNo
            // 
            resources.ApplyResources(this.edtIDCardNo, "edtIDCardNo");
            this.edtIDCardNo.Name = "edtIDCardNo";
            this.edtIDCardNo.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtIDCardNo.Properties.Appearance.Font")));
            this.edtIDCardNo.Properties.Appearance.Options.UseFont = true;
            this.edtIDCardNo.Properties.Appearance.Options.UseTextOptions = true;
            this.edtIDCardNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.edtIDCardNo.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edtIDCardNo.Properties.UseSystemPasswordChar = true;
            this.edtIDCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtIDCardNo_KeyDown);
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
            // frmReadUserIDCard
            // 
            this.Appearance.Options.UseFont = true;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::IRAP.Client.Global.GUI.Properties.Resources.AndonCall;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.edtIDCardNo);
            this.Controls.Add(this.lblCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReadUserIDCard";
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraEditors.TextEdit edtIDCardNo;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
