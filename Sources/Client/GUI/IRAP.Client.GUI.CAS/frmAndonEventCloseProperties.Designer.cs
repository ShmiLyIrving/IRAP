namespace IRAP.Client.GUI.CAS
{
    partial class frmAndonEventCloseProperties
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
            this.lblReadUserIDCard = new DevExpress.XtraEditors.LabelControl();
            this.edtUserIDCardNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rgpSatisfactory = new DevExpress.XtraEditors.RadioGroup();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserIDCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpSatisfactory.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // lblReadUserIDCard
            // 
            this.lblReadUserIDCard.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadUserIDCard.Location = new System.Drawing.Point(28, 32);
            this.lblReadUserIDCard.Name = "lblReadUserIDCard";
            this.lblReadUserIDCard.Size = new System.Drawing.Size(64, 16);
            this.lblReadUserIDCard.TabIndex = 0;
            this.lblReadUserIDCard.Text = "请刷卡：";
            // 
            // edtUserIDCardNo
            // 
            this.edtUserIDCardNo.EnterMoveNextControl = true;
            this.edtUserIDCardNo.Location = new System.Drawing.Point(162, 29);
            this.edtUserIDCardNo.Name = "edtUserIDCardNo";
            this.edtUserIDCardNo.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUserIDCardNo.Properties.Appearance.Options.UseFont = true;
            this.edtUserIDCardNo.Properties.UseSystemPasswordChar = true;
            this.edtUserIDCardNo.Size = new System.Drawing.Size(231, 22);
            this.edtUserIDCardNo.TabIndex = 1;
            this.edtUserIDCardNo.Validating += new System.ComponentModel.CancelEventHandler(this.edtUserIDCardNo_Validating);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(28, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(128, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "用户满意度调查：";
            // 
            // rgpSatisfactory
            // 
            this.rgpSatisfactory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgpSatisfactory.Location = new System.Drawing.Point(162, 66);
            this.rgpSatisfactory.Name = "rgpSatisfactory";
            this.rgpSatisfactory.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgpSatisfactory.Properties.Appearance.Options.UseFont = true;
            this.rgpSatisfactory.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "1 - 非常满意"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "2 - 满意"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "3 - 一般"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "4 - 不满意")});
            this.rgpSatisfactory.Size = new System.Drawing.Size(231, 129);
            this.rgpSatisfactory.TabIndex = 3;
            this.rgpSatisfactory.SelectedIndexChanged += new System.EventHandler(this.rgpSatisfactory_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(412, 23);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 38);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(412, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 38);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            // 
            // frmAndonEventCloseProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(523, 219);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rgpSatisfactory);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.edtUserIDCardNo);
            this.Controls.Add(this.lblReadUserIDCard);
            this.Name = "frmAndonEventCloseProperties";
            this.Text = "关闭安灯事件";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmAndonEventCloseProperties_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.edtUserIDCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgpSatisfactory.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblReadUserIDCard;
        private DevExpress.XtraEditors.TextEdit edtUserIDCardNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup rgpSatisfactory;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
