﻿namespace IRAP.Client.GUI.AsimcoPrdtPackage.Editor
{
    partial class frmPackageLabelPrint
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.edtBoxNumber = new DevExpress.XtraEditors.CalcEdit();
            this.edtCartonNumber = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboPackageLines = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboCustomers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnLabelPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboPrinters = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBoxNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCartonNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPackageLines.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrinters.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.edtBoxNumber);
            this.groupControl1.Controls.Add(this.edtCartonNumber);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Location = new System.Drawing.Point(12, 123);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(465, 66);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "待打印标签数量";
            // 
            // edtBoxNumber
            // 
            this.edtBoxNumber.EnterMoveNextControl = true;
            this.edtBoxNumber.Location = new System.Drawing.Point(330, 34);
            this.edtBoxNumber.Name = "edtBoxNumber";
            this.edtBoxNumber.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.edtBoxNumber.Properties.Appearance.Options.UseFont = true;
            this.edtBoxNumber.Properties.ReadOnly = true;
            this.edtBoxNumber.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtBoxNumber.Size = new System.Drawing.Size(120, 20);
            this.edtBoxNumber.TabIndex = 18;
            // 
            // edtCartonNumber
            // 
            this.edtCartonNumber.EnterMoveNextControl = true;
            this.edtCartonNumber.Location = new System.Drawing.Point(76, 34);
            this.edtCartonNumber.Name = "edtCartonNumber";
            this.edtCartonNumber.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.edtCartonNumber.Properties.Appearance.Options.UseFont = true;
            this.edtCartonNumber.Properties.Precision = 0;
            this.edtCartonNumber.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtCartonNumber.Size = new System.Drawing.Size(150, 20);
            this.edtCartonNumber.TabIndex = 17;
            this.edtCartonNumber.Validating += new System.ComponentModel.CancelEventHandler(this.edtCartonNumber_Validating);
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(261, 37);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 14);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "内箱数：";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(14, 37);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 14);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "外箱数：";
            // 
            // cboPackageLines
            // 
            this.cboPackageLines.Location = new System.Drawing.Point(12, 87);
            this.cboPackageLines.Name = "cboPackageLines";
            this.cboPackageLines.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPackageLines.Properties.Appearance.Options.UseFont = true;
            this.cboPackageLines.Properties.AppearanceDisabled.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPackageLines.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboPackageLines.Properties.AppearanceDropDown.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPackageLines.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboPackageLines.Properties.AppearanceFocused.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPackageLines.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboPackageLines.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPackageLines.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboPackageLines.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPackageLines.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPackageLines.Size = new System.Drawing.Size(465, 20);
            this.cboPackageLines.TabIndex = 12;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(12, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(126, 14);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "分配的包装线工位：";
            // 
            // cboCustomers
            // 
            this.cboCustomers.Location = new System.Drawing.Point(12, 32);
            this.cboCustomers.Name = "cboCustomers";
            this.cboCustomers.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCustomers.Properties.Appearance.Options.UseFont = true;
            this.cboCustomers.Properties.AppearanceDisabled.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboCustomers.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboCustomers.Properties.AppearanceDropDown.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboCustomers.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboCustomers.Properties.AppearanceFocused.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboCustomers.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboCustomers.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboCustomers.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboCustomers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCustomers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCustomers.Size = new System.Drawing.Size(465, 20);
            this.cboCustomers.TabIndex = 10;
            this.cboCustomers.SelectedIndexChanged += new System.EventHandler(this.cboCustomers_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(12, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "客户：";
            // 
            // btnLabelPrint
            // 
            this.btnLabelPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLabelPrint.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLabelPrint.Appearance.Options.UseFont = true;
            this.btnLabelPrint.Location = new System.Drawing.Point(501, 22);
            this.btnLabelPrint.Name = "btnLabelPrint";
            this.btnLabelPrint.Size = new System.Drawing.Size(109, 41);
            this.btnLabelPrint.TabIndex = 15;
            this.btnLabelPrint.Text = "打印标签";
            this.btnLabelPrint.Click += new System.EventHandler(this.btnLabelPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(501, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 41);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "关闭";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl2.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.cboPrinters);
            this.groupControl2.Location = new System.Drawing.Point(12, 204);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(465, 66);
            this.groupControl2.TabIndex = 14;
            this.groupControl2.Text = "打印到";
            // 
            // cboPrinters
            // 
            this.cboPrinters.Location = new System.Drawing.Point(14, 33);
            this.cboPrinters.Name = "cboPrinters";
            this.cboPrinters.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrinters.Properties.Appearance.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceDisabled.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceDropDown.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceFocused.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboPrinters.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("新宋体", 10.5F);
            this.cboPrinters.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboPrinters.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPrinters.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPrinters.Size = new System.Drawing.Size(436, 20);
            this.cboPrinters.TabIndex = 11;
            this.cboPrinters.SelectedIndexChanged += new System.EventHandler(this.cboPrinters_SelectedIndexChanged);
            // 
            // frmPackageLabelPrint
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(622, 285);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLabelPrint);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.cboPackageLines);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboCustomers);
            this.Controls.Add(this.labelControl2);
            this.Name = "frmPackageLabelPrint";
            this.Text = "";
            this.Shown += new System.EventHandler(this.frmPackageLabelPrint_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBoxNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCartonNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPackageLines.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPrinters.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cboPackageLines;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboCustomers;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnLabelPrint;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboPrinters;
        private DevExpress.XtraEditors.CalcEdit edtCartonNumber;
        private DevExpress.XtraEditors.CalcEdit edtBoxNumber;
    }
}
