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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboTransferPrinter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnTransferPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.cboProductionTrack = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnProductionTrackPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMOLineNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMONumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTransferPrinter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductionTrack.Properties)).BeginInit();
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
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl1.Location = new System.Drawing.Point(14, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "订单号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl2.Location = new System.Drawing.Point(442, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 20);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "行号：";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.edtMOLineNo);
            this.groupControl1.Controls.Add(this.edtMONumber);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(560, 74);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "请输入订单信息：";
            // 
            // edtMOLineNo
            // 
            this.edtMOLineNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMOLineNo.Location = new System.Drawing.Point(490, 36);
            this.edtMOLineNo.Name = "edtMOLineNo";
            this.edtMOLineNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtMOLineNo.Properties.Appearance.Options.UseFont = true;
            this.edtMOLineNo.Size = new System.Drawing.Size(58, 26);
            this.edtMOLineNo.TabIndex = 3;
            this.edtMOLineNo.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.EditValueChanging);
            // 
            // edtMONumber
            // 
            this.edtMONumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMONumber.Location = new System.Drawing.Point(76, 36);
            this.edtMONumber.Name = "edtMONumber";
            this.edtMONumber.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtMONumber.Properties.Appearance.Options.UseFont = true;
            this.edtMONumber.Size = new System.Drawing.Size(360, 26);
            this.edtMONumber.TabIndex = 2;
            this.edtMONumber.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.EditValueChanging);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(477, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 28);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "打印";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(477, 260);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.cboTransferPrinter);
            this.groupControl2.Controls.Add(this.btnTransferPrint);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Location = new System.Drawing.Point(12, 92);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(560, 74);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "打印产品进出车间流转卡";
            // 
            // cboTransferPrinter
            // 
            this.cboTransferPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTransferPrinter.Location = new System.Drawing.Point(76, 36);
            this.cboTransferPrinter.Name = "cboTransferPrinter";
            this.cboTransferPrinter.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboTransferPrinter.Properties.Appearance.Options.UseFont = true;
            this.cboTransferPrinter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTransferPrinter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTransferPrinter.Size = new System.Drawing.Size(360, 26);
            this.cboTransferPrinter.TabIndex = 5;
            this.cboTransferPrinter.SelectedIndexChanged += new System.EventHandler(this.cboTransferPrinter_SelectedIndexChanged);
            // 
            // btnTransferPrint
            // 
            this.btnTransferPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransferPrint.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnTransferPrint.Appearance.Options.UseFont = true;
            this.btnTransferPrint.Enabled = false;
            this.btnTransferPrint.Location = new System.Drawing.Point(473, 34);
            this.btnTransferPrint.Name = "btnTransferPrint";
            this.btnTransferPrint.Size = new System.Drawing.Size(75, 28);
            this.btnTransferPrint.TabIndex = 4;
            this.btnTransferPrint.Text = "打印";
            this.btnTransferPrint.Click += new System.EventHandler(this.btnTransferPrint_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl3.Location = new System.Drawing.Point(14, 39);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 20);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "打印机：";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl3.Appearance.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.cboProductionTrack);
            this.groupControl3.Controls.Add(this.btnProductionTrackPrint);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Location = new System.Drawing.Point(12, 172);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(560, 74);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "打印产品信息跟踪卡";
            // 
            // cboProductionTrack
            // 
            this.cboProductionTrack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProductionTrack.Location = new System.Drawing.Point(76, 36);
            this.cboProductionTrack.Name = "cboProductionTrack";
            this.cboProductionTrack.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboProductionTrack.Properties.Appearance.Options.UseFont = true;
            this.cboProductionTrack.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProductionTrack.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProductionTrack.Size = new System.Drawing.Size(360, 26);
            this.cboProductionTrack.TabIndex = 5;
            this.cboProductionTrack.SelectedIndexChanged += new System.EventHandler(this.cboProductionTrack_SelectedIndexChanged);
            // 
            // btnProductionTrackPrint
            // 
            this.btnProductionTrackPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProductionTrackPrint.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnProductionTrackPrint.Appearance.Options.UseFont = true;
            this.btnProductionTrackPrint.Enabled = false;
            this.btnProductionTrackPrint.Location = new System.Drawing.Point(473, 34);
            this.btnProductionTrackPrint.Name = "btnProductionTrackPrint";
            this.btnProductionTrackPrint.Size = new System.Drawing.Size(75, 28);
            this.btnProductionTrackPrint.TabIndex = 4;
            this.btnProductionTrackPrint.Text = "打印";
            this.btnProductionTrackPrint.Click += new System.EventHandler(this.btnProductionTrackPrint_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl4.Location = new System.Drawing.Point(14, 39);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 20);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "打印机：";
            // 
            // frmPWOReprint_Asimco
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(584, 300);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTransferPrinter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductionTrack.Properties)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboTransferPrinter;
        private DevExpress.XtraEditors.SimpleButton btnTransferPrint;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboProductionTrack;
        private DevExpress.XtraEditors.SimpleButton btnProductionTrackPrint;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
