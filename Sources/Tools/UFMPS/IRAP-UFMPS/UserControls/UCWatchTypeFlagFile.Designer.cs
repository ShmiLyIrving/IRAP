namespace IRAP_UFMPS.UserControls
{
    partial class UCWatchTypeFlagFile
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
            this.edtFlagFileDataFileFolder = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.edtFlagFileDataFileExt = new DevExpress.XtraEditors.TextEdit();
            this.rbFlagFileGetDataFileType_1 = new System.Windows.Forms.RadioButton();
            this.rbFlagFileGetDataFileType_0 = new System.Windows.Forms.RadioButton();
            this.edtFlagFileName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.edtFlagFileDataFileFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFlagFileDataFileExt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFlagFileName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtFlagFileDataFileFolder
            // 
            this.edtFlagFileDataFileFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFlagFileDataFileFolder.EnterMoveNextControl = true;
            this.edtFlagFileDataFileFolder.Location = new System.Drawing.Point(185, 81);
            this.edtFlagFileDataFileFolder.Name = "edtFlagFileDataFileFolder";
            this.edtFlagFileDataFileFolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtFlagFileDataFileFolder.Properties.NullValuePrompt = "请输入数据文件所在的文件夹（如果空白，则默认为监控文件夹）";
            this.edtFlagFileDataFileFolder.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtFlagFileDataFileFolder.Size = new System.Drawing.Size(487, 20);
            this.edtFlagFileDataFileFolder.TabIndex = 20;
            this.edtFlagFileDataFileFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtFlagFileDataFileFolder_ButtonClick);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(39, 84);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(72, 14);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "数据文件夹：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(39, 34);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 14);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "数据文件名：";
            // 
            // edtFlagFileDataFileExt
            // 
            this.edtFlagFileDataFileExt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFlagFileDataFileExt.Enabled = false;
            this.edtFlagFileDataFileExt.EnterMoveNextControl = true;
            this.edtFlagFileDataFileExt.Location = new System.Drawing.Point(369, 31);
            this.edtFlagFileDataFileExt.Name = "edtFlagFileDataFileExt";
            this.edtFlagFileDataFileExt.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Silver;
            this.edtFlagFileDataFileExt.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtFlagFileDataFileExt.Properties.NullValuePrompt = "请输入数据文件扩展名（不需要加“*”和“.”）";
            this.edtFlagFileDataFileExt.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtFlagFileDataFileExt.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtFlagFileDataFileExt.Size = new System.Drawing.Size(303, 20);
            this.edtFlagFileDataFileExt.TabIndex = 17;
            // 
            // rbFlagFileGetDataFileType_1
            // 
            this.rbFlagFileGetDataFileType_1.AutoSize = true;
            this.rbFlagFileGetDataFileType_1.Checked = true;
            this.rbFlagFileGetDataFileType_1.Location = new System.Drawing.Point(185, 56);
            this.rbFlagFileGetDataFileType_1.Name = "rbFlagFileGetDataFileType_1";
            this.rbFlagFileGetDataFileType_1.Size = new System.Drawing.Size(167, 16);
            this.rbFlagFileGetDataFileType_1.TabIndex = 16;
            this.rbFlagFileGetDataFileType_1.TabStop = true;
            this.rbFlagFileGetDataFileType_1.Text = "文件名在信号旗文件内容中";
            this.rbFlagFileGetDataFileType_1.UseVisualStyleBackColor = true;
            // 
            // rbFlagFileGetDataFileType_0
            // 
            this.rbFlagFileGetDataFileType_0.AutoSize = true;
            this.rbFlagFileGetDataFileType_0.Location = new System.Drawing.Point(185, 34);
            this.rbFlagFileGetDataFileType_0.Name = "rbFlagFileGetDataFileType_0";
            this.rbFlagFileGetDataFileType_0.Size = new System.Drawing.Size(167, 16);
            this.rbFlagFileGetDataFileType_0.TabIndex = 15;
            this.rbFlagFileGetDataFileType_0.Text = "替换信号旗文件扩展名为：";
            this.rbFlagFileGetDataFileType_0.UseVisualStyleBackColor = true;
            this.rbFlagFileGetDataFileType_0.CheckedChanged += new System.EventHandler(this.rbFlagFileGetDataFileType_0_CheckedChanged);
            // 
            // edtFlagFileName
            // 
            this.edtFlagFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFlagFileName.EnterMoveNextControl = true;
            this.edtFlagFileName.Location = new System.Drawing.Point(185, 5);
            this.edtFlagFileName.Name = "edtFlagFileName";
            this.edtFlagFileName.Properties.NullValuePrompt = "请输入信号旗文件名，可以使用通配符（?和*）";
            this.edtFlagFileName.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtFlagFileName.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtFlagFileName.Size = new System.Drawing.Size(487, 20);
            this.edtFlagFileName.TabIndex = 14;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(39, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 14);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "信号旗文件：";
            // 
            // UCWatchTypeFlagFile
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.edtFlagFileDataFileFolder);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.edtFlagFileDataFileExt);
            this.Controls.Add(this.rbFlagFileGetDataFileType_1);
            this.Controls.Add(this.rbFlagFileGetDataFileType_0);
            this.Controls.Add(this.edtFlagFileName);
            this.Controls.Add(this.labelControl4);
            this.Name = "UCWatchTypeFlagFile";
            this.Size = new System.Drawing.Size(681, 114);
            ((System.ComponentModel.ISupportInitialize)(this.edtFlagFileDataFileFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFlagFileDataFileExt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFlagFileName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.ButtonEdit edtFlagFileDataFileFolder;
        public DevExpress.XtraEditors.TextEdit edtFlagFileDataFileExt;
        public System.Windows.Forms.RadioButton rbFlagFileGetDataFileType_1;
        public System.Windows.Forms.RadioButton rbFlagFileGetDataFileType_0;
        public DevExpress.XtraEditors.TextEdit edtFlagFileName;
    }
}
