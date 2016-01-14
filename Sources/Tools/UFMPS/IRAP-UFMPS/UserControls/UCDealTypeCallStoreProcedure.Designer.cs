namespace IRAP_UFMPS.UserControls
{
    partial class UCDealTypeCallStoreProcedure
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
            this.tcDBSPParams = new DevExpress.XtraTab.XtraTabControl();
            this.tpDBParams = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.edtDBName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.edtDBAddress = new DevExpress.XtraEditors.TextEdit();
            this.edtDBUserPWD = new DevExpress.XtraEditors.TextEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.edtDBUserID = new DevExpress.XtraEditors.TextEdit();
            this.tpSPParams = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.edtFirstRow = new DevExpress.XtraEditors.TextEdit();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.edtFormatFileName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            this.edtRowTerminator = new DevExpress.XtraEditors.TextEdit();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.edtFieldTerminator = new DevExpress.XtraEditors.TextEdit();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.edtNumFields = new DevExpress.XtraEditors.TextEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.edtImportTypeID = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tcDBSPParams)).BeginInit();
            this.tcDBSPParams.SuspendLayout();
            this.tpDBParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBUserPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBUserID.Properties)).BeginInit();
            this.tpSPParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFirstRow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFormatFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRowTerminator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldTerminator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNumFields.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtImportTypeID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tcDBSPParams
            // 
            this.tcDBSPParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDBSPParams.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.tcDBSPParams.Location = new System.Drawing.Point(0, 0);
            this.tcDBSPParams.Name = "tcDBSPParams";
            this.tcDBSPParams.SelectedTabPage = this.tpDBParams;
            this.tcDBSPParams.Size = new System.Drawing.Size(681, 163);
            this.tcDBSPParams.TabIndex = 16;
            this.tcDBSPParams.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpDBParams,
            this.tpSPParams});
            // 
            // tpDBParams
            // 
            this.tpDBParams.Controls.Add(this.labelControl18);
            this.tpDBParams.Controls.Add(this.edtDBName);
            this.tpDBParams.Controls.Add(this.labelControl22);
            this.tpDBParams.Controls.Add(this.edtDBAddress);
            this.tpDBParams.Controls.Add(this.edtDBUserPWD);
            this.tpDBParams.Controls.Add(this.labelControl20);
            this.tpDBParams.Controls.Add(this.labelControl19);
            this.tpDBParams.Controls.Add(this.edtDBUserID);
            this.tpDBParams.Name = "tpDBParams";
            this.tpDBParams.Size = new System.Drawing.Size(675, 134);
            this.tpDBParams.Text = "存储过程数据库链接配置";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl18.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl18.Location = new System.Drawing.Point(9, 84);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(169, 17);
            this.labelControl18.TabIndex = 13;
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
            this.edtDBName.TabIndex = 14;
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl22.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl22.Location = new System.Drawing.Point(9, 6);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(169, 17);
            this.labelControl22.TabIndex = 7;
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
            this.edtDBAddress.TabIndex = 8;
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
            this.edtDBUserPWD.TabIndex = 12;
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl20.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl20.Location = new System.Drawing.Point(9, 32);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(169, 17);
            this.labelControl20.TabIndex = 9;
            this.labelControl20.Text = "数据库登录用户名：";
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl19.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl19.Location = new System.Drawing.Point(9, 58);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(169, 17);
            this.labelControl19.TabIndex = 11;
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
            this.edtDBUserID.TabIndex = 10;
            // 
            // tpSPParams
            // 
            this.tpSPParams.Controls.Add(this.labelControl28);
            this.tpSPParams.Controls.Add(this.edtFirstRow);
            this.tpSPParams.Controls.Add(this.labelControl27);
            this.tpSPParams.Controls.Add(this.edtFormatFileName);
            this.tpSPParams.Controls.Add(this.labelControl26);
            this.tpSPParams.Controls.Add(this.edtRowTerminator);
            this.tpSPParams.Controls.Add(this.labelControl25);
            this.tpSPParams.Controls.Add(this.edtFieldTerminator);
            this.tpSPParams.Controls.Add(this.labelControl24);
            this.tpSPParams.Controls.Add(this.edtNumFields);
            this.tpSPParams.Controls.Add(this.labelControl23);
            this.tpSPParams.Controls.Add(this.edtImportTypeID);
            this.tpSPParams.Name = "tpSPParams";
            this.tpSPParams.Size = new System.Drawing.Size(675, 134);
            this.tpSPParams.Text = "存储过程参数配置";
            // 
            // labelControl28
            // 
            this.labelControl28.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl28.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl28.Location = new System.Drawing.Point(313, 32);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(169, 17);
            this.labelControl28.TabIndex = 13;
            this.labelControl28.Text = "首数据行行号：";
            // 
            // edtFirstRow
            // 
            this.edtFirstRow.EnterMoveNextControl = true;
            this.edtFirstRow.Location = new System.Drawing.Point(488, 30);
            this.edtFirstRow.Name = "edtFirstRow";
            this.edtFirstRow.Properties.Mask.EditMask = "d";
            this.edtFirstRow.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtFirstRow.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtFirstRow.Size = new System.Drawing.Size(43, 20);
            this.edtFirstRow.TabIndex = 14;
            // 
            // labelControl27
            // 
            this.labelControl27.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl27.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl27.Location = new System.Drawing.Point(9, 110);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(169, 17);
            this.labelControl27.TabIndex = 19;
            this.labelControl27.Text = "数据格式文件名：";
            // 
            // edtFormatFileName
            // 
            this.edtFormatFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFormatFileName.EnterMoveNextControl = true;
            this.edtFormatFileName.Location = new System.Drawing.Point(184, 108);
            this.edtFormatFileName.Name = "edtFormatFileName";
            this.edtFormatFileName.Size = new System.Drawing.Size(487, 20);
            this.edtFormatFileName.TabIndex = 20;
            // 
            // labelControl26
            // 
            this.labelControl26.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl26.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl26.Location = new System.Drawing.Point(9, 84);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(169, 17);
            this.labelControl26.TabIndex = 17;
            this.labelControl26.Text = "行终止符：";
            // 
            // edtRowTerminator
            // 
            this.edtRowTerminator.EnterMoveNextControl = true;
            this.edtRowTerminator.Location = new System.Drawing.Point(184, 82);
            this.edtRowTerminator.Name = "edtRowTerminator";
            this.edtRowTerminator.Size = new System.Drawing.Size(43, 20);
            this.edtRowTerminator.TabIndex = 18;
            // 
            // labelControl25
            // 
            this.labelControl25.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl25.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl25.Location = new System.Drawing.Point(9, 58);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(169, 17);
            this.labelControl25.TabIndex = 15;
            this.labelControl25.Text = "数据域分割符：";
            // 
            // edtFieldTerminator
            // 
            this.edtFieldTerminator.EnterMoveNextControl = true;
            this.edtFieldTerminator.Location = new System.Drawing.Point(184, 56);
            this.edtFieldTerminator.Name = "edtFieldTerminator";
            this.edtFieldTerminator.Size = new System.Drawing.Size(43, 20);
            this.edtFieldTerminator.TabIndex = 16;
            // 
            // labelControl24
            // 
            this.labelControl24.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl24.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl24.Location = new System.Drawing.Point(9, 32);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(169, 17);
            this.labelControl24.TabIndex = 11;
            this.labelControl24.Text = "数据域数量：";
            // 
            // edtNumFields
            // 
            this.edtNumFields.EnterMoveNextControl = true;
            this.edtNumFields.Location = new System.Drawing.Point(184, 30);
            this.edtNumFields.Name = "edtNumFields";
            this.edtNumFields.Properties.Mask.EditMask = "d";
            this.edtNumFields.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtNumFields.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtNumFields.Size = new System.Drawing.Size(43, 20);
            this.edtNumFields.TabIndex = 12;
            // 
            // labelControl23
            // 
            this.labelControl23.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl23.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl23.Location = new System.Drawing.Point(9, 6);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(169, 17);
            this.labelControl23.TabIndex = 9;
            this.labelControl23.Text = "导入类型标识：";
            // 
            // edtImportTypeID
            // 
            this.edtImportTypeID.EnterMoveNextControl = true;
            this.edtImportTypeID.Location = new System.Drawing.Point(184, 4);
            this.edtImportTypeID.Name = "edtImportTypeID";
            this.edtImportTypeID.Properties.Mask.EditMask = "d";
            this.edtImportTypeID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtImportTypeID.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtImportTypeID.Size = new System.Drawing.Size(43, 20);
            this.edtImportTypeID.TabIndex = 10;
            // 
            // UCDealTypeCallStoreProcedure
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tcDBSPParams);
            this.Name = "UCDealTypeCallStoreProcedure";
            this.Size = new System.Drawing.Size(681, 163);
            ((System.ComponentModel.ISupportInitialize)(this.tcDBSPParams)).EndInit();
            this.tcDBSPParams.ResumeLayout(false);
            this.tpDBParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDBName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBUserPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDBUserID.Properties)).EndInit();
            this.tpSPParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFirstRow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFormatFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRowTerminator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFieldTerminator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNumFields.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtImportTypeID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage tpDBParams;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraTab.XtraTabPage tpSPParams;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        public DevExpress.XtraTab.XtraTabControl tcDBSPParams;
        public DevExpress.XtraEditors.TextEdit edtDBName;
        public DevExpress.XtraEditors.TextEdit edtDBAddress;
        public DevExpress.XtraEditors.TextEdit edtDBUserPWD;
        public DevExpress.XtraEditors.TextEdit edtDBUserID;
        public DevExpress.XtraEditors.TextEdit edtFirstRow;
        public DevExpress.XtraEditors.TextEdit edtFormatFileName;
        public DevExpress.XtraEditors.TextEdit edtRowTerminator;
        public DevExpress.XtraEditors.TextEdit edtFieldTerminator;
        public DevExpress.XtraEditors.TextEdit edtNumFields;
        public DevExpress.XtraEditors.TextEdit edtImportTypeID;
    }
}
