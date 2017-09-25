namespace IRAP.Client.GUI.SCES.Dialogs
{
    partial class frmPWOReprint_Asimco
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.edtMOLineNo = new DevExpress.XtraEditors.TextEdit();
            this.edtMONumber = new DevExpress.XtraEditors.TextEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMOLineNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMONumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl1.Location = new System.Drawing.Point(14, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "制造订单号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelControl2.Location = new System.Drawing.Point(14, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(112, 21);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "制造订单行号：";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.edtMOLineNo);
            this.groupControl1.Controls.Add(this.edtMONumber);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(408, 110);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "请输入订单信息：";
            // 
            // edtMOLineNo
            // 
            this.edtMOLineNo.Location = new System.Drawing.Point(142, 71);
            this.edtMOLineNo.Name = "edtMOLineNo";
            this.edtMOLineNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.edtMOLineNo.Properties.Appearance.Options.UseFont = true;
            this.edtMOLineNo.Size = new System.Drawing.Size(155, 28);
            this.edtMOLineNo.TabIndex = 3;
            // 
            // edtMONumber
            // 
            this.edtMONumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMONumber.Location = new System.Drawing.Point(142, 37);
            this.edtMONumber.Name = "edtMONumber";
            this.edtMONumber.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.edtMONumber.Properties.Appearance.Options.UseFont = true;
            this.edtMONumber.Size = new System.Drawing.Size(247, 28);
            this.edtMONumber.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(439, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 28);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(439, 94);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            // 
            // frmPWOReprint_Asimco
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(546, 134);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Name = "frmPWOReprint_Asimco";
            this.Text = "生产工单补打";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMOLineNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMONumber.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit edtMOLineNo;
        private DevExpress.XtraEditors.TextEdit edtMONumber;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
