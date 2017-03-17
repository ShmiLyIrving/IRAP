namespace StationRegister
{
    partial class frmStationRegisterMain
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
            this.cboMadAddress = new DevExpress.XtraEditors.ComboBoxEdit();
            this.edtCommunityID = new DevExpress.XtraEditors.TextEdit();
            this.edtFuncGroupID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.edtTemplateSTN = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboMadAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCommunityID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuncGroupID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTemplateSTN.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "MAC 地址：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(12, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 20);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "社区标识：";
            // 
            // cboMadAddress
            // 
            this.cboMadAddress.Location = new System.Drawing.Point(124, 9);
            this.cboMadAddress.Name = "cboMadAddress";
            this.cboMadAddress.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMadAddress.Properties.Appearance.Options.UseFont = true;
            this.cboMadAddress.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMadAddress.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboMadAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMadAddress.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboMadAddress.Size = new System.Drawing.Size(234, 26);
            this.cboMadAddress.TabIndex = 2;
            // 
            // edtCommunityID
            // 
            this.edtCommunityID.Location = new System.Drawing.Point(124, 42);
            this.edtCommunityID.Name = "edtCommunityID";
            this.edtCommunityID.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtCommunityID.Properties.Appearance.Options.UseFont = true;
            this.edtCommunityID.Size = new System.Drawing.Size(122, 26);
            this.edtCommunityID.TabIndex = 3;
            // 
            // edtFuncGroupID
            // 
            this.edtFuncGroupID.Location = new System.Drawing.Point(124, 74);
            this.edtFuncGroupID.Name = "edtFuncGroupID";
            this.edtFuncGroupID.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtFuncGroupID.Properties.Appearance.Options.UseFont = true;
            this.edtFuncGroupID.Properties.Appearance.Options.UseTextOptions = true;
            this.edtFuncGroupID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtFuncGroupID.Size = new System.Drawing.Size(122, 26);
            this.edtFuncGroupID.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(12, 77);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(84, 20);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "功能组标识：";
            // 
            // edtTemplateSTN
            // 
            this.edtTemplateSTN.Location = new System.Drawing.Point(124, 106);
            this.edtTemplateSTN.Name = "edtTemplateSTN";
            this.edtTemplateSTN.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtTemplateSTN.Properties.Appearance.Options.UseFont = true;
            this.edtTemplateSTN.Size = new System.Drawing.Size(197, 26);
            this.edtTemplateSTN.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(12, 109);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 20);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "模板站点号：";
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Appearance.Options.UseFont = true;
            this.btnRegister.Location = new System.Drawing.Point(377, 5);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(93, 33);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "注册";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // frmStationRegisterMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(482, 140);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.edtTemplateSTN);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.edtFuncGroupID);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.edtCommunityID);
            this.Controls.Add(this.cboMadAddress);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStationRegisterMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "站点注册";
            this.Load += new System.EventHandler(this.frmStationRegisterMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboMadAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCommunityID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFuncGroupID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTemplateSTN.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboMadAddress;
        private DevExpress.XtraEditors.TextEdit edtCommunityID;
        private DevExpress.XtraEditors.TextEdit edtFuncGroupID;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit edtTemplateSTN;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnRegister;
    }
}

