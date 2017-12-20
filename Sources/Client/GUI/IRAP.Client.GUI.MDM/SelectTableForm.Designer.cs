namespace IRAP.Client.GUI.MDM {
    partial class SelectTableForm {
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.comboxSheets = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOK = new DevExpress.XtraEditors.CheckButton();
            this.btnCancel = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboxSheets.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Dock = System.Windows.Forms.DockStyle.None;
            this.lblFuncName.Location = new System.Drawing.Point(12, 23);
            this.lblFuncName.Size = new System.Drawing.Size(152, 23);
            this.lblFuncName.Text = "请选择导入Sheet：";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.comboxSheets);
            this.panelControl1.Size = new System.Drawing.Size(412, 121);
            this.panelControl1.Controls.SetChildIndex(this.lblFuncName, 0);
            this.panelControl1.Controls.SetChildIndex(this.comboxSheets, 0);
            this.panelControl1.Controls.SetChildIndex(this.btnOK, 0);
            this.panelControl1.Controls.SetChildIndex(this.btnCancel, 0);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // comboxSheets
            // 
            this.comboxSheets.Location = new System.Drawing.Point(152, 24);
            this.comboxSheets.Name = "comboxSheets";
            this.comboxSheets.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboxSheets.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboxSheets.Size = new System.Drawing.Size(238, 20);
            this.comboxSheets.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(251, 66);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(59, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.CheckedChanged += new System.EventHandler(this.btnOK_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(331, 66);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.CheckedChanged += new System.EventHandler(this.btnCancel_CheckedChanged);
            // 
            // SelectTableForm
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(412, 113);
            this.Name = "SelectTableForm";
            this.Text = "导入Sheet选择";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboxSheets.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboxSheets;
        private DevExpress.XtraEditors.CheckButton btnCancel;
        private DevExpress.XtraEditors.CheckButton btnOK;
    }
}
