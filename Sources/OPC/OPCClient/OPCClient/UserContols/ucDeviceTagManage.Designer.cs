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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDeviceTagManage));
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlDevices = new DevExpress.XtraTreeList.TreeList();
            this.tlcmDeviceCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gcTags = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmsDeviceList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmirefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoadDevices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSplitter1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiImportDeviceTags = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.Appearance.Image")));
            this.repositoryItemButtonEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemButtonEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.repositoryItemButtonEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(12, 12);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.tlDevices);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.Text = "设备列表";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcTags);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(908, 607);
            this.splitContainerControl1.SplitterPosition = 358;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tlDevices
            // 
            this.tlDevices.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tlDevices.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.SteelBlue;
            this.tlDevices.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Snow;
            this.tlDevices.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tlDevices.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tlDevices.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcmDeviceCode});
            this.tlDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDevices.Location = new System.Drawing.Point(5, 5);
            this.tlDevices.Name = "tlDevices";
            this.tlDevices.BeginUnboundLoad();
            this.tlDevices.AppendNode(new object[] {
            "设备列表"}, -1);
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
            this.tlDevices.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit2});
            this.tlDevices.Size = new System.Drawing.Size(344, 593);
            this.tlDevices.TabIndex = 0;
            this.tlDevices.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlDevices_FocusedNodeChanged);
            this.tlDevices.Load += new System.EventHandler(this.tlDevices_Load);
            this.tlDevices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tlDevices_MouseDown);
            // 
            // tlcmDeviceCode
            // 
            this.tlcmDeviceCode.Caption = "设备";
            this.tlcmDeviceCode.FieldName = "DeviceCode";
            this.tlcmDeviceCode.MinWidth = 34;
            this.tlcmDeviceCode.Name = "tlcmDeviceCode";
            this.tlcmDeviceCode.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.tlcmDeviceCode.Visible = true;
            this.tlcmDeviceCode.VisibleIndex = 0;
            this.tlcmDeviceCode.Width = 200;
            // 
            // repositoryItemButtonEdit2
            // 
            serializableAppearanceObject1.Options.UseImage = true;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit2.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemButtonEdit2.ContextImage = ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit2.ContextImage")));
            this.repositoryItemButtonEdit2.ContextImageAlignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.repositoryItemButtonEdit2.MaxLength = 50;
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gcTags
            // 
            this.gcTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTags.Location = new System.Drawing.Point(0, 0);
            this.gcTags.MainView = this.gridView1;
            this.gcTags.Name = "gcTags";
            this.gcTags.Size = new System.Drawing.Size(538, 607);
            this.gcTags.TabIndex = 0;
            this.gcTags.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcTags;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // cmsDeviceList
            // 
            this.cmsDeviceList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmirefresh,
            this.tsmiLoadDevices,
            this.tsmiDeleteDevice,
            this.tsmiSplitter1,
            this.tsmiImportDeviceTags});
            this.cmsDeviceList.Name = "cmsDeviceList";
            this.cmsDeviceList.Size = new System.Drawing.Size(158, 98);
            this.cmsDeviceList.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDeviceList_Opening);
            // 
            // tsmirefresh
            // 
            this.tsmirefresh.Name = "tsmirefresh";
            this.tsmirefresh.Size = new System.Drawing.Size(157, 22);
            this.tsmirefresh.Text = "刷新";
            this.tsmirefresh.Click += new System.EventHandler(this.tsmirefresh_Click);
            // 
            // tsmiLoadDevices
            // 
            this.tsmiLoadDevices.Name = "tsmiLoadDevices";
            this.tsmiLoadDevices.Size = new System.Drawing.Size(157, 22);
            this.tsmiLoadDevices.Text = "添加设备";
            this.tsmiLoadDevices.Click += new System.EventHandler(this.tsmiLoadDevices_Click);
            // 
            // tsmiDeleteDevice
            // 
            this.tsmiDeleteDevice.Name = "tsmiDeleteDevice";
            this.tsmiDeleteDevice.Size = new System.Drawing.Size(157, 22);
            this.tsmiDeleteDevice.Text = "删除所选设备";
            this.tsmiDeleteDevice.Click += new System.EventHandler(this.tsmiDeleteDevice_Click);
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
            this.tsmiImportDeviceTags.Click += new System.EventHandler(this.tsmiImportDeviceTags_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.cmsDeviceList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList tlDevices;
        private System.Windows.Forms.ContextMenuStrip cmsDeviceList;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadDevices;
        private System.Windows.Forms.ToolStripSeparator tsmiSplitter1;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportDeviceTags;
        private DevExpress.XtraGrid.GridControl gcTags;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteDevice;
        private System.Windows.Forms.ToolStripMenuItem tsmirefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcmDeviceCode;
    }
}
