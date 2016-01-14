namespace IRAP_UFMPS.UserControls
{
    partial class UCWatchTypeNormal
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
            this.chkNormalKeepUndealFile = new DevExpress.XtraEditors.CheckEdit();
            this.edtNormalKeepUndealFileFolder = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.edtNormalWatchFileExts = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkNormalKeepUndealFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNormalKeepUndealFileFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNormalWatchFileExts.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkNormalKeepUndealFile
            // 
            this.chkNormalKeepUndealFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNormalKeepUndealFile.EnterMoveNextControl = true;
            this.chkNormalKeepUndealFile.Location = new System.Drawing.Point(185, 31);
            this.chkNormalKeepUndealFile.Name = "chkNormalKeepUndealFile";
            this.chkNormalKeepUndealFile.Properties.Caption = "保留不需处理的文件";
            this.chkNormalKeepUndealFile.Size = new System.Drawing.Size(487, 19);
            this.chkNormalKeepUndealFile.TabIndex = 18;
            this.chkNormalKeepUndealFile.CheckedChanged += new System.EventHandler(this.chkNormalKeepUndealFile_CheckedChanged);
            // 
            // edtNormalKeepUndealFileFolder
            // 
            this.edtNormalKeepUndealFileFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNormalKeepUndealFileFolder.Enabled = false;
            this.edtNormalKeepUndealFileFolder.EnterMoveNextControl = true;
            this.edtNormalKeepUndealFileFolder.Location = new System.Drawing.Point(282, 53);
            this.edtNormalKeepUndealFileFolder.Name = "edtNormalKeepUndealFileFolder";
            this.edtNormalKeepUndealFileFolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtNormalKeepUndealFileFolder.Properties.NullValuePrompt = "请输入需要保留文件的文件夹或者点击右侧按钮来选择文件夹";
            this.edtNormalKeepUndealFileFolder.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtNormalKeepUndealFileFolder.Size = new System.Drawing.Size(390, 20);
            this.edtNormalKeepUndealFileFolder.TabIndex = 17;
            this.edtNormalKeepUndealFileFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtNormalKeepUndealFileFolder_ButtonClick);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(185, 56);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(84, 14);
            this.labelControl7.TabIndex = 16;
            this.labelControl7.Text = "保留到文件夹：";
            // 
            // edtNormalWatchFileExts
            // 
            this.edtNormalWatchFileExts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNormalWatchFileExts.EnterMoveNextControl = true;
            this.edtNormalWatchFileExts.Location = new System.Drawing.Point(185, 5);
            this.edtNormalWatchFileExts.Name = "edtNormalWatchFileExts";
            this.edtNormalWatchFileExts.Properties.NullValuePrompt = "请输入需要处理文件的扩展名（如果空白则处理全部文件）";
            this.edtNormalWatchFileExts.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtNormalWatchFileExts.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtNormalWatchFileExts.Size = new System.Drawing.Size(487, 20);
            this.edtNormalWatchFileExts.TabIndex = 15;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(39, 8);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(96, 14);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "需要处理的文件：";
            // 
            // UCWatchTypeNormal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.chkNormalKeepUndealFile);
            this.Controls.Add(this.edtNormalKeepUndealFileFolder);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.edtNormalWatchFileExts);
            this.Controls.Add(this.labelControl9);
            this.Name = "UCWatchTypeNormal";
            this.Size = new System.Drawing.Size(681, 83);
            ((System.ComponentModel.ISupportInitialize)(this.chkNormalKeepUndealFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNormalKeepUndealFileFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNormalWatchFileExts.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        public DevExpress.XtraEditors.CheckEdit chkNormalKeepUndealFile;
        public DevExpress.XtraEditors.ButtonEdit edtNormalKeepUndealFileFolder;
        public DevExpress.XtraEditors.TextEdit edtNormalWatchFileExts;
    }
}
