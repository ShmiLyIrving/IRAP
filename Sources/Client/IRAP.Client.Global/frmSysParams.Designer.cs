namespace IRAP.Client.Global
{
    partial class frmSysParams
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
            this.tcParams = new DevExpress.XtraTab.XtraTabControl();
            this.tpAndonParams = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tcControlBoxProperties = new DevExpress.XtraTab.XtraTabControl();
            this.tpNone = new DevExpress.XtraTab.XtraTabPage();
            this.tpZLan6042 = new DevExpress.XtraTab.XtraTabPage();
            this.edtZLan6042IPAddr = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboControlBoxType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tcParams)).BeginInit();
            this.tcParams.SuspendLayout();
            this.tpAndonParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcControlBoxProperties)).BeginInit();
            this.tcControlBoxProperties.SuspendLayout();
            this.tpZLan6042.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtZLan6042IPAddr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboControlBoxType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // tcParams
            // 
            this.tcParams.AppearancePage.Header.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.tcParams.AppearancePage.Header.Options.UseFont = true;
            this.tcParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcParams.Location = new System.Drawing.Point(10, 10);
            this.tcParams.Name = "tcParams";
            this.tcParams.SelectedTabPage = this.tpAndonParams;
            this.tcParams.Size = new System.Drawing.Size(689, 459);
            this.tcParams.TabIndex = 0;
            this.tcParams.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpAndonParams});
            // 
            // tpAndonParams
            // 
            this.tpAndonParams.Controls.Add(this.groupControl1);
            this.tpAndonParams.Name = "tpAndonParams";
            this.tpAndonParams.Padding = new System.Windows.Forms.Padding(5);
            this.tpAndonParams.Size = new System.Drawing.Size(684, 426);
            this.tpAndonParams.Text = "安灯配置参数";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.tcControlBoxProperties);
            this.groupControl1.Controls.Add(this.cboControlBoxType);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(674, 114);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "三色告警灯控制盒";
            // 
            // tcControlBoxProperties
            // 
            this.tcControlBoxProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcControlBoxProperties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tcControlBoxProperties.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tcControlBoxProperties.Location = new System.Drawing.Point(5, 67);
            this.tcControlBoxProperties.Name = "tcControlBoxProperties";
            this.tcControlBoxProperties.SelectedTabPage = this.tpNone;
            this.tcControlBoxProperties.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tcControlBoxProperties.Size = new System.Drawing.Size(664, 42);
            this.tcControlBoxProperties.TabIndex = 2;
            this.tcControlBoxProperties.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpNone,
            this.tpZLan6042});
            // 
            // tpNone
            // 
            this.tpNone.Name = "tpNone";
            this.tpNone.Size = new System.Drawing.Size(659, 37);
            this.tpNone.Text = "无控制盒";
            // 
            // tpZLan6042
            // 
            this.tpZLan6042.Controls.Add(this.edtZLan6042IPAddr);
            this.tpZLan6042.Controls.Add(this.labelControl2);
            this.tpZLan6042.Name = "tpZLan6042";
            this.tpZLan6042.Size = new System.Drawing.Size(659, 37);
            this.tpZLan6042.Text = "ZLan 6042";
            // 
            // edtZLan6042IPAddr
            // 
            this.edtZLan6042IPAddr.Location = new System.Drawing.Point(137, 5);
            this.edtZLan6042IPAddr.Name = "edtZLan6042IPAddr";
            this.edtZLan6042IPAddr.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtZLan6042IPAddr.Properties.Appearance.Options.UseFont = true;
            this.edtZLan6042IPAddr.Size = new System.Drawing.Size(247, 26);
            this.edtZLan6042IPAddr.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(3, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(128, 20);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "控制盒 IP 地址：";
            // 
            // cboControlBoxType
            // 
            this.cboControlBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboControlBoxType.EditValue = "NONE";
            this.cboControlBoxType.Location = new System.Drawing.Point(143, 35);
            this.cboControlBoxType.Name = "cboControlBoxType";
            this.cboControlBoxType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboControlBoxType.Properties.Appearance.Options.UseFont = true;
            this.cboControlBoxType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboControlBoxType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("无", "NONE", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("CH375 控制盒", "CH375", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("ZLan 6042 控制盒", "ZLAN6042", -1)});
            this.cboControlBoxType.Size = new System.Drawing.Size(522, 26);
            this.cboControlBoxType.TabIndex = 1;
            this.cboControlBoxType.SelectedIndexChanged += new System.EventHandler(this.cboControlBoxType_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(5, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(132, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "控制盒类型：";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(10, 474);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(689, 45);
            this.panelControl1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(482, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 35);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(578, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(10, 35);
            this.panelControl2.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(588, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(10, 469);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(689, 5);
            this.panelControl3.TabIndex = 2;
            // 
            // frmSysParams
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(709, 529);
            this.Controls.Add(this.tcParams);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmSysParams";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "配置";
            this.Shown += new System.EventHandler(this.frmSysParams_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tcParams)).EndInit();
            this.tcParams.ResumeLayout(false);
            this.tpAndonParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcControlBoxProperties)).EndInit();
            this.tcControlBoxProperties.ResumeLayout(false);
            this.tpZLan6042.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtZLan6042IPAddr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboControlBoxType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcParams;
        private DevExpress.XtraTab.XtraTabPage tpAndonParams;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboControlBoxType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabControl tcControlBoxProperties;
        private DevExpress.XtraTab.XtraTabPage tpZLan6042;
        private DevExpress.XtraEditors.TextEdit edtZLan6042IPAddr;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraTab.XtraTabPage tpNone;
    }
}
