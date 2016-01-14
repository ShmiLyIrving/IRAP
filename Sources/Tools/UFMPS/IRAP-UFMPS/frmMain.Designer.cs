namespace IRAP_UFMPS
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.pnlCommand = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.spccBody = new DevExpress.XtraEditors.SplitContainerControl();
            this.gpcTasks = new DevExpress.XtraEditors.GroupControl();
            this.tlTasks = new DevExpress.XtraTreeList.TreeList();
            this.tclmnStatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tclmnTaskName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tclmnWatchType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tclmnMonitorFolder = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tclmnDocProcessType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tcboSkinNames = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmnuNewTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuEditTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuDeleteTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmnuStartTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuStopTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmnuStartAllTasks = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuStopAllTasks = new System.Windows.Forms.ToolStripMenuItem();
            this.tcTaskLogs = new DevExpress.XtraTab.XtraTabControl();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cm_NotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmnQuit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommand)).BeginInit();
            this.pnlCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spccBody)).BeginInit();
            this.spccBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcTasks)).BeginInit();
            this.gpcTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlTasks)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcTaskLogs)).BeginInit();
            this.cm_NotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 346);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(740, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // pnlCommand
            // 
            this.pnlCommand.Controls.Add(this.btnClose);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCommand.Location = new System.Drawing.Point(615, 0);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(125, 346);
            this.pnlCommand.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(6, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // spccBody
            // 
            this.spccBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spccBody.Horizontal = false;
            this.spccBody.Location = new System.Drawing.Point(0, 0);
            this.spccBody.Name = "spccBody";
            this.spccBody.Panel1.Controls.Add(this.gpcTasks);
            this.spccBody.Panel1.Text = "Panel1";
            this.spccBody.Panel2.Controls.Add(this.tcTaskLogs);
            this.spccBody.Panel2.Text = "Panel2";
            this.spccBody.Size = new System.Drawing.Size(615, 346);
            this.spccBody.SplitterPosition = 266;
            this.spccBody.TabIndex = 3;
            this.spccBody.Text = "splitContainerControl1";
            // 
            // gpcTasks
            // 
            this.gpcTasks.Controls.Add(this.tlTasks);
            this.gpcTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpcTasks.Location = new System.Drawing.Point(0, 0);
            this.gpcTasks.Name = "gpcTasks";
            this.gpcTasks.Size = new System.Drawing.Size(615, 266);
            this.gpcTasks.TabIndex = 1;
            this.gpcTasks.Text = "监控任务";
            // 
            // tlTasks
            // 
            this.tlTasks.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tclmnStatus,
            this.tclmnTaskName,
            this.tclmnWatchType,
            this.tclmnMonitorFolder,
            this.tclmnDocProcessType});
            this.tlTasks.ContextMenuStrip = this.contextMenu;
            this.tlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlTasks.Location = new System.Drawing.Point(2, 22);
            this.tlTasks.Name = "tlTasks";
            this.tlTasks.OptionsBehavior.Editable = false;
            this.tlTasks.OptionsView.AutoWidth = false;
            this.tlTasks.OptionsView.ShowRoot = false;
            this.tlTasks.Size = new System.Drawing.Size(611, 242);
            this.tlTasks.TabIndex = 0;
            this.tlTasks.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlTasks_FocusedNodeChanged);
            this.tlTasks.DoubleClick += new System.EventHandler(this.tlTasks_DoubleClick);
            // 
            // tclmnStatus
            // 
            this.tclmnStatus.AppearanceCell.Options.UseTextOptions = true;
            this.tclmnStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tclmnStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.tclmnStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnStatus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tclmnStatus.Caption = "状态";
            this.tclmnStatus.FieldName = "状态";
            this.tclmnStatus.Name = "tclmnStatus";
            this.tclmnStatus.Visible = true;
            this.tclmnStatus.VisibleIndex = 0;
            // 
            // tclmnTaskName
            // 
            this.tclmnTaskName.AppearanceHeader.Options.UseTextOptions = true;
            this.tclmnTaskName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnTaskName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tclmnTaskName.Caption = "任务名称";
            this.tclmnTaskName.FieldName = "任务名称";
            this.tclmnTaskName.Name = "tclmnTaskName";
            this.tclmnTaskName.Visible = true;
            this.tclmnTaskName.VisibleIndex = 1;
            this.tclmnTaskName.Width = 235;
            // 
            // tclmnWatchType
            // 
            this.tclmnWatchType.AppearanceCell.Options.UseTextOptions = true;
            this.tclmnWatchType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnWatchType.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tclmnWatchType.AppearanceHeader.Options.UseTextOptions = true;
            this.tclmnWatchType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnWatchType.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tclmnWatchType.Caption = "监控方式";
            this.tclmnWatchType.FieldName = "监控方式";
            this.tclmnWatchType.Name = "tclmnWatchType";
            this.tclmnWatchType.Visible = true;
            this.tclmnWatchType.VisibleIndex = 2;
            this.tclmnWatchType.Width = 100;
            // 
            // tclmnMonitorFolder
            // 
            this.tclmnMonitorFolder.AppearanceHeader.Options.UseTextOptions = true;
            this.tclmnMonitorFolder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnMonitorFolder.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tclmnMonitorFolder.Caption = "监控文件夹";
            this.tclmnMonitorFolder.FieldName = "监控文件夹";
            this.tclmnMonitorFolder.Name = "tclmnMonitorFolder";
            this.tclmnMonitorFolder.Visible = true;
            this.tclmnMonitorFolder.VisibleIndex = 3;
            this.tclmnMonitorFolder.Width = 300;
            // 
            // tclmnDocProcessType
            // 
            this.tclmnDocProcessType.AppearanceHeader.Options.UseTextOptions = true;
            this.tclmnDocProcessType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnDocProcessType.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tclmnDocProcessType.Caption = "文件处理方式";
            this.tclmnDocProcessType.FieldName = "文件处理方式";
            this.tclmnDocProcessType.Name = "tclmnDocProcessType";
            this.tclmnDocProcessType.Visible = true;
            this.tclmnDocProcessType.VisibleIndex = 4;
            this.tclmnDocProcessType.Width = 200;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.tcboSkinNames,
            this.toolStripMenuItem1,
            this.tmnuNewTask,
            this.tmnuEditTask,
            this.tmnuDeleteTask,
            this.toolStripSeparator1,
            this.tmnuStartTask,
            this.tmnuStopTask,
            this.toolStripMenuItem2,
            this.tmnuStartAllTasks,
            this.tmnuStopAllTasks});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(221, 227);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItem3.Text = "皮肤";
            // 
            // tcboSkinNames
            // 
            this.tcboSkinNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tcboSkinNames.Name = "tcboSkinNames";
            this.tcboSkinNames.Size = new System.Drawing.Size(160, 25);
            this.tcboSkinNames.SelectedIndexChanged += new System.EventHandler(this.tcboSkinNames_SelectedIndexChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 6);
            // 
            // tmnuNewTask
            // 
            this.tmnuNewTask.Name = "tmnuNewTask";
            this.tmnuNewTask.Size = new System.Drawing.Size(220, 22);
            this.tmnuNewTask.Text = "新建任务(&N)";
            this.tmnuNewTask.Click += new System.EventHandler(this.tmnuNewTask_Click);
            // 
            // tmnuEditTask
            // 
            this.tmnuEditTask.Name = "tmnuEditTask";
            this.tmnuEditTask.Size = new System.Drawing.Size(220, 22);
            this.tmnuEditTask.Text = "修改任务(&E)";
            this.tmnuEditTask.Click += new System.EventHandler(this.tmnuEditTask_Click);
            // 
            // tmnuDeleteTask
            // 
            this.tmnuDeleteTask.Name = "tmnuDeleteTask";
            this.tmnuDeleteTask.Size = new System.Drawing.Size(220, 22);
            this.tmnuDeleteTask.Text = "删除任务(&D)";
            this.tmnuDeleteTask.Click += new System.EventHandler(this.tmnuDeleteTask_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // tmnuStartTask
            // 
            this.tmnuStartTask.Name = "tmnuStartTask";
            this.tmnuStartTask.Size = new System.Drawing.Size(220, 22);
            this.tmnuStartTask.Text = "启动任务(&S)";
            this.tmnuStartTask.Click += new System.EventHandler(this.tmnuStartTask_Click);
            // 
            // tmnuStopTask
            // 
            this.tmnuStopTask.Name = "tmnuStopTask";
            this.tmnuStopTask.Size = new System.Drawing.Size(220, 22);
            this.tmnuStopTask.Text = "停止任务(&P)";
            this.tmnuStopTask.Click += new System.EventHandler(this.tmnuStopTask_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 6);
            // 
            // tmnuStartAllTasks
            // 
            this.tmnuStartAllTasks.Name = "tmnuStartAllTasks";
            this.tmnuStartAllTasks.Size = new System.Drawing.Size(220, 22);
            this.tmnuStartAllTasks.Text = "启动所有任务(&A)";
            this.tmnuStartAllTasks.Click += new System.EventHandler(this.tmnuStartAllTasks_Click);
            // 
            // tmnuStopAllTasks
            // 
            this.tmnuStopAllTasks.Name = "tmnuStopAllTasks";
            this.tmnuStopAllTasks.Size = new System.Drawing.Size(220, 22);
            this.tmnuStopAllTasks.Text = "停止所有任务(&T)";
            this.tmnuStopAllTasks.Click += new System.EventHandler(this.tmnuStopAllTasks_Click);
            // 
            // tcTaskLogs
            // 
            this.tcTaskLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTaskLogs.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.tcTaskLogs.Location = new System.Drawing.Point(0, 0);
            this.tcTaskLogs.Name = "tcTaskLogs";
            this.tcTaskLogs.Size = new System.Drawing.Size(615, 75);
            this.tcTaskLogs.TabIndex = 0;
            this.tcTaskLogs.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tcTaskLogs_SelectedPageChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDown);
            // 
            // cm_NotifyIcon
            // 
            this.cm_NotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnQuit});
            this.cm_NotifyIcon.Name = "cm_NotifyIcon";
            this.cm_NotifyIcon.Size = new System.Drawing.Size(101, 26);
            // 
            // tmnQuit
            // 
            this.tmnQuit.Name = "tmnQuit";
            this.tmnQuit.Size = new System.Drawing.Size(100, 22);
            this.tmnQuit.Text = "退出";
            this.tmnQuit.Click += new System.EventHandler(this.tmnQuit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(740, 368);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.spccBody);
            this.Controls.Add(this.pnlCommand);
            this.Controls.Add(this.statusBar);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通用文件夹监控及处理服务";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommand)).EndInit();
            this.pnlCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spccBody)).EndInit();
            this.spccBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcTasks)).EndInit();
            this.gpcTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlTasks)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcTaskLogs)).EndInit();
            this.cm_NotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private DevExpress.XtraEditors.PanelControl pnlCommand;
        private DevExpress.XtraEditors.SplitContainerControl spccBody;
        private DevExpress.XtraEditors.GroupControl gpcTasks;
        private DevExpress.XtraTreeList.TreeList tlTasks;
        private DevExpress.XtraTab.XtraTabControl tcTaskLogs;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripComboBox tcboSkinNames;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tmnuNewTask;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclmnStatus;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclmnTaskName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclmnWatchType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclmnMonitorFolder;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclmnDocProcessType;
        private System.Windows.Forms.ToolStripMenuItem tmnuEditTask;
        private System.Windows.Forms.ToolStripMenuItem tmnuDeleteTask;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tmnuStartTask;
        private System.Windows.Forms.ToolStripMenuItem tmnuStopTask;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tmnuStartAllTasks;
        private System.Windows.Forms.ToolStripMenuItem tmnuStopAllTasks;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.ContextMenuStrip cm_NotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem tmnQuit;

    }
}