namespace IRAP.Client.GUI.MESPDC.UserControls {
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
            this.labMessage = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // panelColor
            // 
            this.panelColor.BackColor = System.Drawing.Color.Black;
            this.panelColor.Location = new System.Drawing.Point(0, 0);
            this.panelColor.Margin = new System.Windows.Forms.Padding(0);
            this.panelColor.MaximumSize = new System.Drawing.Size(31, 20);
            this.panelColor.MinimumSize = new System.Drawing.Size(31, 20);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(31, 20);
            this.panelColor.TabIndex = 0;
            // 
            // labMessage
            // 
            this.labMessage.Location = new System.Drawing.Point(32, 3);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(0, 14);
            this.labMessage.TabIndex = 1;
            // 
            // ColorLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.panelColor);
            this.MaximumSize = new System.Drawing.Size(0, 20);
            this.MinimumSize = new System.Drawing.Size(0, 20);
            this.Name = "ColorLabel";
            this.Size = new System.Drawing.Size(35, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelColor;
        private DevExpress.XtraEditors.LabelControl labMessage;


    }
}
