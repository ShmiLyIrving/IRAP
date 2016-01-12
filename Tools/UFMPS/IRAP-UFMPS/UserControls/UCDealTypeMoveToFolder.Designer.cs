namespace IRAP_UFMPS.UserControls
{
    partial class UCDealTypeMoveToFolder
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
            this.edtCopyDestinationFolder = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.edtCopyDestinationFolder.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtCopyDestinationFolder
            // 
            this.edtCopyDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtCopyDestinationFolder.EnterMoveNextControl = true;
            this.edtCopyDestinationFolder.Location = new System.Drawing.Point(185, 5);
            this.edtCopyDestinationFolder.Name = "edtCopyDestinationFolder";
            this.edtCopyDestinationFolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtCopyDestinationFolder.Properties.NullValuePrompt = "请输入需要监控的文件夹或者点击右侧按钮来选择文件夹";
            this.edtCopyDestinationFolder.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtCopyDestinationFolder.Size = new System.Drawing.Size(487, 20);
            this.edtCopyDestinationFolder.TabIndex = 17;
            this.edtCopyDestinationFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtCopyDestinationFolder_ButtonClick);
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl21.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl21.Location = new System.Drawing.Point(10, 7);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(169, 17);
            this.labelControl21.TabIndex = 16;
            this.labelControl21.Text = "目的文件夹：";
            // 
            // UCDealTypeMoveToFolder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.edtCopyDestinationFolder);
            this.Controls.Add(this.labelControl21);
            this.Name = "UCDealTypeMoveToFolder";
            this.Size = new System.Drawing.Size(681, 32);
            ((System.ComponentModel.ISupportInitialize)(this.edtCopyDestinationFolder.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl21;
        public DevExpress.XtraEditors.ButtonEdit edtCopyDestinationFolder;
    }
}
