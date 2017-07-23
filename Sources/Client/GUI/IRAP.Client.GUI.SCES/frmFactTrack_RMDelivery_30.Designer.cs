namespace IRAP.Client.GUI.SCES
{
    partial class frmFactTrack_RMDelivery_30
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboPeriodType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.edtBeginDT = new System.Windows.Forms.DateTimePicker();
            this.edtEndDT = new System.Windows.Forms.DateTimePicker();
            this.btnPrevPeriod = new DevExpress.XtraEditors.SimpleButton();
            this.btnNextPeriod = new DevExpress.XtraEditors.SimpleButton();
            this.edtWorkCenter = new DevExpress.XtraEditors.TextEdit();
            this.lblWorkCenter = new DevExpress.XtraEditors.LabelControl();
            this.cboStoreSite = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWorkCenter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStoreSite.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(865, 56);
            this.lblFuncName.Text = "历史配送记录查询";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(865, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(865, 394);
            this.splitContainerControl1.SplitterPosition = 137;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboStoreSite);
            this.groupControl1.Controls.Add(this.lblWorkCenter);
            this.groupControl1.Controls.Add(this.edtWorkCenter);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cboPeriodType);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.edtBeginDT);
            this.groupControl1.Controls.Add(this.edtEndDT);
            this.groupControl1.Controls.Add(this.btnPrevPeriod);
            this.groupControl1.Controls.Add(this.btnNextPeriod);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(865, 137);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "查询条件";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(15, 72);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 20);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "时间粒度：";
            // 
            // cboPeriodType
            // 
            this.cboPeriodType.Location = new System.Drawing.Point(91, 69);
            this.cboPeriodType.Name = "cboPeriodType";
            this.cboPeriodType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodType.Properties.Appearance.Options.UseFont = true;
            this.cboPeriodType.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboPeriodType.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboPeriodType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboPeriodType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboPeriodType.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboPeriodType.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboPeriodType.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboPeriodType.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboPeriodType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPeriodType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPeriodType.Size = new System.Drawing.Size(131, 26);
            this.cboPeriodType.TabIndex = 13;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(228, 72);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 20);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "时间范围：";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(507, 72);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(16, 20);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "—";
            // 
            // edtBeginDT
            // 
            this.edtBeginDT.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.edtBeginDT.Enabled = false;
            this.edtBeginDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtBeginDT.Location = new System.Drawing.Point(329, 69);
            this.edtBeginDT.Name = "edtBeginDT";
            this.edtBeginDT.Size = new System.Drawing.Size(172, 26);
            this.edtBeginDT.TabIndex = 16;
            this.edtBeginDT.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // edtEndDT
            // 
            this.edtEndDT.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.edtEndDT.Enabled = false;
            this.edtEndDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtEndDT.Location = new System.Drawing.Point(529, 69);
            this.edtEndDT.Name = "edtEndDT";
            this.edtEndDT.Size = new System.Drawing.Size(172, 26);
            this.edtEndDT.TabIndex = 18;
            this.edtEndDT.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // btnPrevPeriod
            // 
            this.btnPrevPeriod.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevPeriod.Appearance.Options.UseFont = true;
            this.btnPrevPeriod.Location = new System.Drawing.Point(304, 69);
            this.btnPrevPeriod.Name = "btnPrevPeriod";
            this.btnPrevPeriod.Size = new System.Drawing.Size(19, 26);
            this.btnPrevPeriod.TabIndex = 15;
            this.btnPrevPeriod.TabStop = false;
            this.btnPrevPeriod.Text = "<";
            // 
            // btnNextPeriod
            // 
            this.btnNextPeriod.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPeriod.Appearance.Options.UseFont = true;
            this.btnNextPeriod.Location = new System.Drawing.Point(707, 69);
            this.btnNextPeriod.Name = "btnNextPeriod";
            this.btnNextPeriod.Size = new System.Drawing.Size(19, 26);
            this.btnNextPeriod.TabIndex = 19;
            this.btnNextPeriod.TabStop = false;
            this.btnNextPeriod.Text = ">";
            // 
            // edtWorkCenter
            // 
            this.edtWorkCenter.Location = new System.Drawing.Point(91, 101);
            this.edtWorkCenter.Name = "edtWorkCenter";
            this.edtWorkCenter.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtWorkCenter.Properties.Appearance.Options.UseFont = true;
            this.edtWorkCenter.Size = new System.Drawing.Size(247, 26);
            this.edtWorkCenter.TabIndex = 3;
            // 
            // lblWorkCenter
            // 
            this.lblWorkCenter.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkCenter.Location = new System.Drawing.Point(15, 104);
            this.lblWorkCenter.Name = "lblWorkCenter";
            this.lblWorkCenter.Size = new System.Drawing.Size(70, 20);
            this.lblWorkCenter.TabIndex = 20;
            this.lblWorkCenter.Text = "工作中心：";
            // 
            // cboStoreSite
            // 
            this.cboStoreSite.Location = new System.Drawing.Point(675, 45);
            this.cboStoreSite.Name = "cboStoreSite";
            this.cboStoreSite.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStoreSite.Properties.Appearance.Options.UseFont = true;
            this.cboStoreSite.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStoreSite.Size = new System.Drawing.Size(100, 26);
            this.cboStoreSite.TabIndex = 21;
            // 
            // frmFactTrack_RMDelivery_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(865, 450);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmFactTrack_RMDelivery_30";
            this.Text = "历史配送记录查询";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWorkCenter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStoreSite.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPrevPeriod;
        private DevExpress.XtraEditors.SimpleButton btnNextPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboPeriodType;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.DateTimePicker edtBeginDT;
        private System.Windows.Forms.DateTimePicker edtEndDT;
        private DevExpress.XtraEditors.ComboBoxEdit cboStoreSite;
        private DevExpress.XtraEditors.LabelControl lblWorkCenter;
        private DevExpress.XtraEditors.TextEdit edtWorkCenter;
    }
}
