namespace IRAP_UFMPS.UserControls
{
    partial class UCDealTypeInsertIntoTable
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
            this.tcDBParams = new DevExpress.XtraTab.XtraTabControl();
            this.tpDBParams = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtTableName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.edtDBName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.edtDBAddress = new DevExpress.XtraEditors.TextEdit();
            this.edtDBUserPWD = new DevExpress.XtraEditors.TextEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.edtDBUserID = new DevExpress.XtraEditors.TextEdit();
            this.tpDataFormatParams = new DevExpress.XtraTab.XtraTabPage();
            this.chkSaveIncludeFileName = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.edtDataStartLineNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.edtNumOfTextFields = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtSplitter = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tcDBParams)).BeginInit();
            this.tcDBParams.SuspendLayout();
            this.tpDBParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBUserPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBUserID.Properties)).BeginInit();
            this.tpDataFormatParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveIncludeFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDataStartLineNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNumOfTextFields.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSplitter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tcDBParams
            // 
            this.tcDBParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDBParams.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.tcDBParams.Location = new System.Drawing.Point(0, 0);
            this.tcDBParams.Name = "tcDBParams";
            this.tcDBParams.SelectedTabPage = this.tpDBParams;
            this.tcDBParams.Size = new System.Drawing.Size(621, 186);
            this.tcDBParams.TabIndex = 0;
            this.tcDBParams.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpDBParams,
            this.tpDataFormatParams});
            // 
            // tpDBParams
            // 
            this.tpDBParams.Controls.Add(this.labelControl1);
            this.tpDBParams.Controls.Add(this.edtTableName);
            this.tpDBParams.Controls.Add(this.labelControl18);
            this.tpDBParams.Controls.Add(this.edtDBName);
            this.tpDBParams.Controls.Add(this.labelControl22);
            this.tpDBParams.Controls.Add(this.edtDBAddress);
            this.tpDBParams.Controls.Add(this.edtDBUserPWD);
            this.tpDBParams.Controls.Add(this.labelControl20);
            this.tpDBParams.Controls.Add(this.labelControl19);
            this.tpDBParams.Controls.Add(this.edtDBUserID);
            this.tpDBParams.Name = "tpDBParams";
            this.tpDBParams.Size = new System.Drawing.Size(615, 157);
            this.tpDBParams.Text = "数据库连接配置";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(9, 120);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(169, 17);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "表名：";
            // 
            // edtTableName
            // 
            this.edtTableName.EnterMoveNextControl = true;
            this.edtTableName.Location = new System.Drawing.Point(184, 118);
            this.edtTableName.Name = "edtTableName";
            this.edtTableName.Properties.NullValuePrompt = "请输入数据库名";
            this.edtTableName.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtTableName.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtTableName.Size = new System.Drawing.Size(199, 20);
            this.edtTableName.TabIndex = 24;
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl18.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl18.Location = new System.Drawing.Point(9, 84);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(169, 17);
            this.labelControl18.TabIndex = 21;
            this.labelControl18.Text = "数据库名：";
            // 
            // edtDBName
            // 
            this.edtDBName.EnterMoveNextControl = true;
            this.edtDBName.Location = new System.Drawing.Point(184, 82);
            this.edtDBName.Name = "edtDBName";
            this.edtDBName.Properties.NullValuePrompt = "请输入数据库名";
            this.edtDBName.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtDBName.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtDBName.Size = new System.Drawing.Size(199, 20);
            this.edtDBName.TabIndex = 22;
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl22.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl22.Location = new System.Drawing.Point(9, 6);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(169, 17);
            this.labelControl22.TabIndex = 15;
            this.labelControl22.Text = "数据库服务器地址：";
            // 
            // edtDBAddress
            // 
            this.edtDBAddress.EnterMoveNextControl = true;
            this.edtDBAddress.Location = new System.Drawing.Point(184, 4);
            this.edtDBAddress.Name = "edtDBAddress";
            this.edtDBAddress.Properties.Mask.EditMask = "\\d\\d?\\d?\\.\\d\\d?\\d?\\.\\d\\d?\\d?\\.\\d\\d?\\d?";
            this.edtDBAddress.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.edtDBAddress.Properties.Mask.PlaceHolder = ' ';
            this.edtDBAddress.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtDBAddress.Properties.NullValuePrompt = "请输入数据库服务器地址";
            this.edtDBAddress.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtDBAddress.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtDBAddress.Size = new System.Drawing.Size(199, 20);
            this.edtDBAddress.TabIndex = 16;
            // 
            // edtDBUserPWD
            // 
            this.edtDBUserPWD.EnterMoveNextControl = true;
            this.edtDBUserPWD.Location = new System.Drawing.Point(184, 56);
            this.edtDBUserPWD.Name = "edtDBUserPWD";
            this.edtDBUserPWD.Properties.NullValuePrompt = "请输入数据库登录密码";
            this.edtDBUserPWD.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtDBUserPWD.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtDBUserPWD.Properties.UseSystemPasswordChar = true;
            this.edtDBUserPWD.Size = new System.Drawing.Size(199, 20);
            this.edtDBUserPWD.TabIndex = 20;
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl20.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl20.Location = new System.Drawing.Point(9, 32);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(169, 17);
            this.labelControl20.TabIndex = 17;
            this.labelControl20.Text = "数据库登录用户名：";
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl19.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl19.Location = new System.Drawing.Point(9, 58);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(169, 17);
            this.labelControl19.TabIndex = 19;
            this.labelControl19.Text = "数据库登录密码：";
            // 
            // edtDBUserID
            // 
            this.edtDBUserID.EnterMoveNextControl = true;
            this.edtDBUserID.Location = new System.Drawing.Point(184, 30);
            this.edtDBUserID.Name = "edtDBUserID";
            this.edtDBUserID.Properties.NullValuePrompt = "请输入登录数据库的用户名";
            this.edtDBUserID.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtDBUserID.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtDBUserID.Size = new System.Drawing.Size(199, 20);
            this.edtDBUserID.TabIndex = 18;
            // 
            // tpDataFormatParams
            // 
            this.tpDataFormatParams.Controls.Add(this.chkSaveIncludeFileName);
            this.tpDataFormatParams.Controls.Add(this.labelControl3);
            this.tpDataFormatParams.Controls.Add(this.edtDataStartLineNo);
            this.tpDataFormatParams.Controls.Add(this.labelControl24);
            this.tpDataFormatParams.Controls.Add(this.edtNumOfTextFields);
            this.tpDataFormatParams.Controls.Add(this.labelControl2);
            this.tpDataFormatParams.Controls.Add(this.edtSplitter);
            this.tpDataFormatParams.Name = "tpDataFormatParams";
            this.tpDataFormatParams.Size = new System.Drawing.Size(615, 157);
            this.tpDataFormatParams.Text = "文件格式参数";
            // 
            // chkSaveIncludeFileName
            // 
            this.chkSaveIncludeFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveIncludeFileName.Location = new System.Drawing.Point(184, 82);
            this.chkSaveIncludeFileName.Name = "chkSaveIncludeFileName";
            this.chkSaveIncludeFileName.Properties.Caption = "将文件名同时保存到表中";
            this.chkSaveIncludeFileName.Size = new System.Drawing.Size(428, 19);
            this.chkSaveIncludeFileName.TabIndex = 30;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(9, 58);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(169, 17);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "数据起始行号：";
            // 
            // edtDataStartLineNo
            // 
            this.edtDataStartLineNo.EnterMoveNextControl = true;
            this.edtDataStartLineNo.Location = new System.Drawing.Point(184, 56);
            this.edtDataStartLineNo.Name = "edtDataStartLineNo";
            this.edtDataStartLineNo.Properties.Mask.EditMask = "d";
            this.edtDataStartLineNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtDataStartLineNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtDataStartLineNo.Size = new System.Drawing.Size(43, 20);
            this.edtDataStartLineNo.TabIndex = 29;
            // 
            // labelControl24
            // 
            this.labelControl24.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl24.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl24.Location = new System.Drawing.Point(9, 32);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(169, 17);
            this.labelControl24.TabIndex = 25;
            this.labelControl24.Text = "数据域数量：";
            // 
            // edtNumOfTextFields
            // 
            this.edtNumOfTextFields.EnterMoveNextControl = true;
            this.edtNumOfTextFields.Location = new System.Drawing.Point(184, 30);
            this.edtNumOfTextFields.Name = "edtNumOfTextFields";
            this.edtNumOfTextFields.Properties.Mask.EditMask = "d";
            this.edtNumOfTextFields.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtNumOfTextFields.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtNumOfTextFields.Size = new System.Drawing.Size(43, 20);
            this.edtNumOfTextFields.TabIndex = 26;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(9, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(169, 17);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "数据域分割符：";
            // 
            // edtSplitter
            // 
            this.edtSplitter.EnterMoveNextControl = true;
            this.edtSplitter.Location = new System.Drawing.Point(184, 4);
            this.edtSplitter.Name = "edtSplitter";
            this.edtSplitter.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtSplitter.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtSplitter.Size = new System.Drawing.Size(50, 20);
            this.edtSplitter.TabIndex = 24;
            // 
            // UCDealTypeInsertIntoTable
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tcDBParams);
            this.Name = "UCDealTypeInsertIntoTable";
            this.Size = new System.Drawing.Size(621, 186);
            ((System.ComponentModel.ISupportInitialize)(this.tcDBParams)).EndInit();
            this.tcDBParams.ResumeLayout(false);
            this.tpDBParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBUserPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBUserID.Properties)).EndInit();
            this.tpDataFormatParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveIncludeFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDataStartLineNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNumOfTextFields.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSplitter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage tpDBParams;
        private DevExpress.XtraTab.XtraTabPage tpDataFormatParams;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        public DevExpress.XtraEditors.TextEdit edtDBName;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        public DevExpress.XtraEditors.TextEdit edtDBAddress;
        public DevExpress.XtraEditors.TextEdit edtDBUserPWD;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        public DevExpress.XtraEditors.TextEdit edtDBUserID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit edtTableName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit edtSplitter;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        public DevExpress.XtraEditors.TextEdit edtNumOfTextFields;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit edtDataStartLineNo;
        public DevExpress.XtraTab.XtraTabControl tcDBParams;
        public DevExpress.XtraEditors.CheckEdit chkSaveIncludeFileName;
    }
}
