namespace OPCClient.UserContols
{
    partial class ucDeviceTagManage
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlDevices = new DevExpress.XtraTreeList.TreeList();
            this.tlclmDeviceName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsDeviceList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiLoadDevices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSplitter1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiImportDeviceTags = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlDevices)).BeginInit();
            this.cmsDeviceList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTitle.Size = new System.Drawing.Size(932, 40);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.splitContainerControl1);
            this.pnlBody.Size = new System.Drawing.Size(932, 631);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(12, 12);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.tlDevices);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "设备列表";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(908, 607);
            this.splitContainerControl1.SplitterPosition = 358;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tlDevices
            // 
            this.tlDevices.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlclmDeviceName});
            this.tlDevices.ContextMenuStrip = this.cmsDeviceList;
            this.tlDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDevices.Location = new System.Drawing.Point(5, 5);
            this.tlDevices.Name = "tlDevices";
            this.tlDevices.BeginUnboundLoad();
            this.tlDevices.AppendNode(new object[] {
            "设备"}, -1);
            this.tlDevices.AppendNode(new object[] {
            "1#脱氢炉"}, 0);
            this.tlDevices.EndUnboundLoad();
            this.tlDevices.OptionsBehavior.Editable = false;
            this.tlDevices.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.tlDevices.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.tlDevices.OptionsSelection.SelectNodesOnRightClick = true;
            this.tlDevices.OptionsSelection.UseIndicatorForSelection = true;
            this.tlDevices.OptionsView.AutoWidth = false;
            this.tlDevices.OptionsView.ShowColumns = false;
            this.tlDevices.OptionsView.ShowHorzLines = false;
            this.tlDevices.OptionsView.ShowIndicator = false;
            this.tlDevices.OptionsView.ShowVertLines = false;
            this.tlDevices.Size = new System.Drawing.Size(344, 574);
            this.tlDevices.TabIndex = 0;
            // 
            // tlclmDeviceName
            // 
            this.tlclmDeviceName.Caption = "设备名称";
            this.tlclmDeviceName.FieldName = "DeviceName";
            this.tlclmDeviceName.MinWidth = 52;
            this.tlclmDeviceName.Name = "tlclmDeviceName";
            this.tlclmDeviceName.Visible = true;
            this.tlclmDeviceName.VisibleIndex = 0;
            this.tlclmDeviceName.Width = 238;
            // 
            // cmsDeviceList
            // 
            this.cmsDeviceList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadDevices,
            this.tsmiSplitter1,
            this.tsmiImportDeviceTags});
            this.cmsDeviceList.Name = "cmsDeviceList";
            this.cmsDeviceList.Size = new System.Drawing.Size(158, 54);
            this.cmsDeviceList.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDeviceList_Opening);
            // 
            // tsmiLoadDevices
            // 
            this.tsmiLoadDevices.Name = "tsmiLoadDevices";
            this.tsmiLoadDevices.Size = new System.Drawing.Size(157, 22);
            this.tsmiLoadDevices.Text = "加载";
            // 
            // tsmiSplitter1
            // 
            this.tsmiSplitter1.Name = "tsmiSplitter1";
            this.tsmiSplitter1.Size = new System.Drawing.Size(154, 6);
            // 
            // tsmiImportDeviceTags
            // 
            this.tsmiImportDeviceTags.Name = "tsmiImportDeviceTags";
            this.tsmiImportDeviceTags.Size = new System.Drawing.Size(157, 22);
            this.tsmiImportDeviceTags.Text = "导入设备标签...";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ucDeviceTagManage
            // 
            this.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.Name = "ucDeviceTagManage";
            this.Size = new System.Drawing.Size(932, 671);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlDevices)).EndInit();
            this.cmsDeviceList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList tlDevices;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlclmDeviceName;
        private System.Windows.Forms.ContextMenuStrip cmsDeviceList;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadDevices;
        private System.Windows.Forms.ToolStripSeparator tsmiSplitter1;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportDeviceTags;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
