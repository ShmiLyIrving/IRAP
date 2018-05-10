namespace IRAP.Client.Global.GUI.Dialogs
{
    partial class frmSubTreeLeafEditor
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
            this.tcEditor = new DevExpress.XtraTab.XtraTabControl();
            this.tpProperties = new DevExpress.XtraTab.XtraTabPage();
            this.edtNodeName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtNodeCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tcEditor)).BeginInit();
            this.tcEditor.SuspendLayout();
            this.tpProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNodeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNodeCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // tcEditor
            // 
            this.tcEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcEditor.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcEditor.Appearance.Options.UseFont = true;
            this.tcEditor.Location = new System.Drawing.Point(12, 12);
            this.tcEditor.Name = "tcEditor";
            this.tcEditor.SelectedTabPage = this.tpProperties;
            this.tcEditor.Size = new System.Drawing.Size(309, 128);
            this.tcEditor.TabIndex = 1;
            this.tcEditor.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpProperties});
            // 
            // tpProperties
            // 
            this.tpProperties.Appearance.Header.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpProperties.Appearance.Header.Options.UseFont = true;
            this.tpProperties.Appearance.PageClient.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpProperties.Appearance.PageClient.Options.UseFont = true;
            this.tpProperties.Controls.Add(this.edtNodeName);
            this.tpProperties.Controls.Add(this.labelControl2);
            this.tpProperties.Controls.Add(this.edtNodeCode);
            this.tpProperties.Controls.Add(this.labelControl1);
            this.tpProperties.Name = "tpProperties";
            this.tpProperties.Size = new System.Drawing.Size(303, 93);
            this.tpProperties.Text = "节点属性";
            // 
            // edtNodeName
            // 
            this.edtNodeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNodeName.EnterMoveNextControl = true;
            this.edtNodeName.Location = new System.Drawing.Point(86, 48);
            this.edtNodeName.Name = "edtNodeName";
            this.edtNodeName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtNodeName.Properties.Appearance.Options.UseFont = true;
            this.edtNodeName.Size = new System.Drawing.Size(199, 26);
            this.edtNodeName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(22, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 20);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "名称：";
            // 
            // edtNodeCode
            // 
            this.edtNodeCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtNodeCode.EnterMoveNextControl = true;
            this.edtNodeCode.Location = new System.Drawing.Point(86, 16);
            this.edtNodeCode.Name = "edtNodeCode";
            this.edtNodeCode.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtNodeCode.Properties.Appearance.Options.UseFont = true;
            this.edtNodeCode.Size = new System.Drawing.Size(199, 26);
            this.edtNodeCode.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(22, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "代码：";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(340, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(340, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 33);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            // 
            // frmSubTreeLeafEditor
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(427, 152);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tcEditor);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.Name = "frmSubTreeLeafEditor";
            this.Text = "";
            this.Shown += new System.EventHandler(this.frmSubTreeLeafEditor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tcEditor)).EndInit();
            this.tcEditor.ResumeLayout(false);
            this.tpProperties.ResumeLayout(false);
            this.tpProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNodeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNodeCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcEditor;
        private DevExpress.XtraTab.XtraTabPage tpProperties;
        public DevExpress.XtraEditors.TextEdit edtNodeName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit edtNodeCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}
