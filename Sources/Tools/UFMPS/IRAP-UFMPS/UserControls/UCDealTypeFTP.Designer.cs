namespace IRAP_UFMPS.UserControls
{
    partial class UCDealTypeFTP
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.edtFTPUserPWD = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.edtFTPUserID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.edtFTPPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.edtFTPAdress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.edtFTPUserPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFTPUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFTPPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFTPAdress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtFTPUserPWD
            // 
            this.edtFTPUserPWD.EnterMoveNextControl = true;
            this.edtFTPUserPWD.Location = new System.Drawing.Point(185, 83);
            this.edtFTPUserPWD.Name = "edtFTPUserPWD";
            this.edtFTPUserPWD.Properties.NullValuePrompt = "请输入登录口令";
            this.edtFTPUserPWD.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtFTPUserPWD.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtFTPUserPWD.Properties.UseSystemPasswordChar = true;
            this.edtFTPUserPWD.Size = new System.Drawing.Size(144, 20);
            this.edtFTPUserPWD.TabIndex = 22;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.Location = new System.Drawing.Point(10, 85);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(169, 17);
            this.labelControl14.TabIndex = 21;
            this.labelControl14.Text = "登录口令：";
            // 
            // edtFTPUserID
            // 
            this.edtFTPUserID.EnterMoveNextControl = true;
            this.edtFTPUserID.Location = new System.Drawing.Point(185, 57);
            this.edtFTPUserID.Name = "edtFTPUserID";
            this.edtFTPUserID.Properties.NullValuePrompt = "请输入登录用户名（请注意大小写）";
            this.edtFTPUserID.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtFTPUserID.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtFTPUserID.Size = new System.Drawing.Size(209, 20);
            this.edtFTPUserID.TabIndex = 20;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl13.Location = new System.Drawing.Point(10, 59);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(169, 17);
            this.labelControl13.TabIndex = 19;
            this.labelControl13.Text = "登录用户名：";
            // 
            // edtFTPPort
            // 
            this.edtFTPPort.EnterMoveNextControl = true;
            this.edtFTPPort.Location = new System.Drawing.Point(185, 31);
            this.edtFTPPort.Name = "edtFTPPort";
            this.edtFTPPort.Properties.Mask.EditMask = "d";
            this.edtFTPPort.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtFTPPort.Properties.Mask.PlaceHolder = ' ';
            this.edtFTPPort.Properties.Mask.ShowPlaceHolders = false;
            this.edtFTPPort.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtFTPPort.Properties.NullValuePrompt = "请输入 FTP 服务器的端口号";
            this.edtFTPPort.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtFTPPort.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtFTPPort.Size = new System.Drawing.Size(144, 20);
            this.edtFTPPort.TabIndex = 18;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.Location = new System.Drawing.Point(10, 33);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(169, 17);
            this.labelControl12.TabIndex = 17;
            this.labelControl12.Text = "FTP 服务器端口号：";
            // 
            // edtFTPAdress
            // 
            this.edtFTPAdress.EnterMoveNextControl = true;
            this.edtFTPAdress.Location = new System.Drawing.Point(185, 5);
            this.edtFTPAdress.Name = "edtFTPAdress";
            this.edtFTPAdress.Properties.Mask.EditMask = "\\d\\d?\\d?\\.\\d\\d?\\d?\\.\\d\\d?\\d?\\.\\d\\d?\\d?";
            this.edtFTPAdress.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.edtFTPAdress.Properties.NullValuePrompt = "请输入 FTP 服务器地址";
            this.edtFTPAdress.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtFTPAdress.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtFTPAdress.Size = new System.Drawing.Size(253, 20);
            this.edtFTPAdress.TabIndex = 16;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.Location = new System.Drawing.Point(10, 7);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(169, 17);
            this.labelControl11.TabIndex = 15;
            this.labelControl11.Text = "FTP 服务器地址：";
            // 
            // UCDealTypeFTP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.edtFTPUserPWD);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.edtFTPUserID);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.edtFTPPort);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.edtFTPAdress);
            this.Controls.Add(this.labelControl11);
            this.Name = "UCDealTypeFTP";
            this.Size = new System.Drawing.Size(681, 110);
            ((System.ComponentModel.ISupportInitialize)(this.edtFTPUserPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFTPUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFTPPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFTPAdress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        public DevExpress.XtraEditors.TextEdit edtFTPUserPWD;
        public DevExpress.XtraEditors.TextEdit edtFTPUserID;
        public DevExpress.XtraEditors.TextEdit edtFTPPort;
        public DevExpress.XtraEditors.TextEdit edtFTPAdress;
    }
}
