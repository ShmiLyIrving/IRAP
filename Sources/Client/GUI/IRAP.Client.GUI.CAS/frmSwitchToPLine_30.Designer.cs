namespace IRAP.Client.GUI.CAS
{
    partial class frmSwitchToPLine_30
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
            this.gpcCurrentPLine = new DevExpress.XtraEditors.GroupControl();
            this.lblCurrentPLineName = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboProductionLines = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSwitch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcCurrentPLine)).BeginInit();
            this.gpcCurrentPLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductionLines.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(572, 56);
            this.lblFuncName.Text = "frmCustomBase";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(572, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // gpcCurrentPLine
            // 
            this.gpcCurrentPLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcCurrentPLine.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcCurrentPLine.Appearance.Options.UseFont = true;
            this.gpcCurrentPLine.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcCurrentPLine.AppearanceCaption.Options.UseFont = true;
            this.gpcCurrentPLine.Controls.Add(this.lblCurrentPLineName);
            this.gpcCurrentPLine.Location = new System.Drawing.Point(12, 62);
            this.gpcCurrentPLine.Name = "gpcCurrentPLine";
            this.gpcCurrentPLine.Padding = new System.Windows.Forms.Padding(10);
            this.gpcCurrentPLine.Size = new System.Drawing.Size(548, 91);
            this.gpcCurrentPLine.TabIndex = 1;
            this.gpcCurrentPLine.Text = "当前绑定的产线";
            // 
            // lblCurrentPLineName
            // 
            this.lblCurrentPLineName.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPLineName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCurrentPLineName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCurrentPLineName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCurrentPLineName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentPLineName.Location = new System.Drawing.Point(12, 33);
            this.lblCurrentPLineName.Name = "lblCurrentPLineName";
            this.lblCurrentPLineName.Size = new System.Drawing.Size(524, 46);
            this.lblCurrentPLineName.TabIndex = 0;
            this.lblCurrentPLineName.Text = "labelControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnSwitch);
            this.groupControl1.Controls.Add(this.cboProductionLines);
            this.groupControl1.Location = new System.Drawing.Point(12, 168);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(10);
            this.groupControl1.Size = new System.Drawing.Size(548, 91);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "可以切换的产线";
            // 
            // cboProductionLines
            // 
            this.cboProductionLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProductionLines.Location = new System.Drawing.Point(20, 44);
            this.cboProductionLines.Name = "cboProductionLines";
            this.cboProductionLines.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductionLines.Properties.Appearance.Options.UseFont = true;
            this.cboProductionLines.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProductionLines.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProductionLines.Size = new System.Drawing.Size(406, 22);
            this.cboProductionLines.TabIndex = 0;
            this.cboProductionLines.SelectedIndexChanged += new System.EventHandler(this.cboProductionLines_SelectedIndexChanged);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwitch.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch.Appearance.Options.UseFont = true;
            this.btnSwitch.Location = new System.Drawing.Point(444, 37);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(86, 39);
            this.btnSwitch.TabIndex = 1;
            this.btnSwitch.Text = "切换";
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // frmSwitchToPLine_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(572, 365);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gpcCurrentPLine);
            this.Name = "frmSwitchToPLine_30";
            this.Text = "产线切换";
            this.Activated += new System.EventHandler(this.frmSwitchToPLine_30_Activated);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.gpcCurrentPLine, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcCurrentPLine)).EndInit();
            this.gpcCurrentPLine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboProductionLines.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpcCurrentPLine;
        private DevExpress.XtraEditors.LabelControl lblCurrentPLineName;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnSwitch;
        private DevExpress.XtraEditors.ComboBoxEdit cboProductionLines;
    }
}
