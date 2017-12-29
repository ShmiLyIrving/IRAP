namespace IRAP.Client.GUI.MDM {
    partial class ColorLabel {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.panelColor = new System.Windows.Forms.Panel();
            this.labelMessage = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // panelColor
            // 
            this.panelColor.BackColor = System.Drawing.Color.Black;
            this.panelColor.Location = new System.Drawing.Point(0, 2);
            this.panelColor.Margin = new System.Windows.Forms.Padding(0);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(23, 15);
            this.panelColor.TabIndex = 0;
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessage.AutoEllipsis = true;
            this.labelMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelMessage.Location = new System.Drawing.Point(26, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(99, 15);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "测试";
            // 
            // ColorLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.panelColor);
            this.Name = "ColorLabel";
            this.Size = new System.Drawing.Size(128, 17);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelColor;
        private DevExpress.XtraEditors.LabelControl labelMessage;


    }
}
