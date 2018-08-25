namespace IRAP.Client.GUI.SCES.Dialogs
{
    partial class frmActualQtyToDeliverEditor
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.edtNewActualQtyToDeliver = new DevExpress.XtraEditors.TextEdit();
            this.lblNewCapacity = new DevExpress.XtraEditors.LabelControl();
            this.edtCurrentActualQtyToDeliver = new DevExpress.XtraEditors.TextEdit();
            this.lblCurrentCapacity = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.edtNewActualQtyToDeliver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentActualQtyToDeliver.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(241, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 27);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(150, 95);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 27);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // edtNewActualQtyToDeliver
            // 
            this.edtNewActualQtyToDeliver.EnterMoveNextControl = true;
            this.edtNewActualQtyToDeliver.Location = new System.Drawing.Point(145, 57);
            this.edtNewActualQtyToDeliver.Name = "edtNewActualQtyToDeliver";
            this.edtNewActualQtyToDeliver.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtNewActualQtyToDeliver.Properties.Appearance.Options.UseFont = true;
            this.edtNewActualQtyToDeliver.Size = new System.Drawing.Size(168, 26);
            this.edtNewActualQtyToDeliver.TabIndex = 9;
            // 
            // lblNewCapacity
            // 
            this.lblNewCapacity.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCapacity.Location = new System.Drawing.Point(27, 60);
            this.lblNewCapacity.Name = "lblNewCapacity";
            this.lblNewCapacity.Size = new System.Drawing.Size(112, 20);
            this.lblNewCapacity.TabIndex = 8;
            this.lblNewCapacity.Text = "新“配送数量”：";
            // 
            // edtCurrentActualQtyToDeliver
            // 
            this.edtCurrentActualQtyToDeliver.Enabled = false;
            this.edtCurrentActualQtyToDeliver.Location = new System.Drawing.Point(145, 25);
            this.edtCurrentActualQtyToDeliver.Name = "edtCurrentActualQtyToDeliver";
            this.edtCurrentActualQtyToDeliver.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtCurrentActualQtyToDeliver.Properties.Appearance.Options.UseFont = true;
            this.edtCurrentActualQtyToDeliver.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.edtCurrentActualQtyToDeliver.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.edtCurrentActualQtyToDeliver.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtCurrentActualQtyToDeliver.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.edtCurrentActualQtyToDeliver.Size = new System.Drawing.Size(168, 26);
            this.edtCurrentActualQtyToDeliver.TabIndex = 7;
            // 
            // lblCurrentCapacity
            // 
            this.lblCurrentCapacity.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCapacity.Location = new System.Drawing.Point(27, 28);
            this.lblCurrentCapacity.Name = "lblCurrentCapacity";
            this.lblCurrentCapacity.Size = new System.Drawing.Size(112, 20);
            this.lblCurrentCapacity.TabIndex = 6;
            this.lblCurrentCapacity.Text = "原“配送数量”：";
            // 
            // frmActualQtyToDeliverEditor
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(338, 134);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.edtNewActualQtyToDeliver);
            this.Controls.Add(this.lblNewCapacity);
            this.Controls.Add(this.edtCurrentActualQtyToDeliver);
            this.Controls.Add(this.lblCurrentCapacity);
            this.Name = "frmActualQtyToDeliverEditor";
            this.Shown += new System.EventHandler(this.frmActualQtyToDeliverEditor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.edtNewActualQtyToDeliver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentActualQtyToDeliver.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.TextEdit edtNewActualQtyToDeliver;
        private DevExpress.XtraEditors.LabelControl lblNewCapacity;
        private DevExpress.XtraEditors.TextEdit edtCurrentActualQtyToDeliver;
        private DevExpress.XtraEditors.LabelControl lblCurrentCapacity;
    }
}
