namespace IRAP_UFMPS
{
    partial class frmTaskEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskEditor));
            this.pnlEditorBody = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboWatchType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.edtWatchFolder = new DevExpress.XtraEditors.ButtonEdit();
            this.pnlWatchTypeFlagFile = new DevExpress.XtraEditors.PanelControl();
            this.ucWatchTypeFlagFile = new IRAP_UFMPS.UserControls.UCWatchTypeFlagFile();
            this.pnlWatchTypeNormal = new DevExpress.XtraEditors.PanelControl();
            this.ucWatchTypeNormal = new IRAP_UFMPS.UserControls.UCWatchTypeNormal();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.chkBackupFileFlag = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.edtBackupFileFolder = new DevExpress.XtraEditors.ButtonEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.pnlDealTypeInsertIntoTable = new DevExpress.XtraEditors.PanelControl();
            this.ucDealTypeInsertIntoTable = new IRAP_UFMPS.UserControls.UCDealTypeInsertIntoTable();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.pnlDealTypeMoveToFolder = new DevExpress.XtraEditors.PanelControl();
            this.ucDealTypeMoveToFolder = new IRAP_UFMPS.UserControls.UCDealTypeMoveToFolder();
            this.pnlDealTypeCallStoreProcedure = new DevExpress.XtraEditors.PanelControl();
            this.ucDealTypeCallStoreProcedure = new IRAP_UFMPS.UserControls.UCDealTypeCallStoreProcedure();
            this.cboFileDealType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.pnlDealTypeFTP = new DevExpress.XtraEditors.PanelControl();
            this.ucDealTypeFTP = new IRAP_UFMPS.UserControls.UCDealTypeFTP();
            this.edtTaskName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEditorBody)).BeginInit();
            this.pnlEditorBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWatchType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWatchFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWatchTypeFlagFile)).BeginInit();
            this.pnlWatchTypeFlagFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWatchTypeNormal)).BeginInit();
            this.pnlWatchTypeNormal.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBackupFileFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBackupFileFolder.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDealTypeInsertIntoTable)).BeginInit();
            this.pnlDealTypeInsertIntoTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDealTypeMoveToFolder)).BeginInit();
            this.pnlDealTypeMoveToFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDealTypeCallStoreProcedure)).BeginInit();
            this.pnlDealTypeCallStoreProcedure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFileDealType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDealTypeFTP)).BeginInit();
            this.pnlDealTypeFTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEditorBody
            // 
            this.pnlEditorBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEditorBody.Controls.Add(this.xtraTabControl1);
            this.pnlEditorBody.Controls.Add(this.edtTaskName);
            this.pnlEditorBody.Controls.Add(this.labelControl1);
            this.pnlEditorBody.Location = new System.Drawing.Point(12, 12);
            this.pnlEditorBody.Name = "pnlEditorBody";
            this.pnlEditorBody.Size = new System.Drawing.Size(691, 304);
            this.pnlEditorBody.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(5, 38);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(681, 259);
            this.xtraTabControl1.TabIndex = 21;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.cboWatchType);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.edtWatchFolder);
            this.xtraTabPage1.Controls.Add(this.pnlWatchTypeFlagFile);
            this.xtraTabPage1.Controls.Add(this.pnlWatchTypeNormal);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(676, 233);
            this.xtraTabPage1.Text = "监控模式";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "文件夹监控类型：";
            // 
            // cboWatchType
            // 
            this.cboWatchType.EnterMoveNextControl = true;
            this.cboWatchType.Location = new System.Drawing.Point(111, 10);
            this.cboWatchType.Name = "cboWatchType";
            this.cboWatchType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboWatchType.Size = new System.Drawing.Size(208, 20);
            this.cboWatchType.TabIndex = 3;
            this.cboWatchType.SelectedIndexChanged += new System.EventHandler(this.cboWatchType_SelectedIndexChanged);
            this.cboWatchType.EditValueChanged += new System.EventHandler(this.cboWatchType_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(33, 44);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "监控文件夹：";
            // 
            // edtWatchFolder
            // 
            this.edtWatchFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWatchFolder.EnterMoveNextControl = true;
            this.edtWatchFolder.Location = new System.Drawing.Point(179, 41);
            this.edtWatchFolder.Name = "edtWatchFolder";
            this.edtWatchFolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtWatchFolder.Properties.NullValuePrompt = "请输入需要监控的文件夹或者点击右侧按钮来选择文件夹";
            this.edtWatchFolder.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtWatchFolder.Size = new System.Drawing.Size(492, 20);
            this.edtWatchFolder.TabIndex = 5;
            this.edtWatchFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtWatchFolder_ButtonClick);
            // 
            // pnlWatchTypeFlagFile
            // 
            this.pnlWatchTypeFlagFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWatchTypeFlagFile.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlWatchTypeFlagFile.Appearance.Options.UseBackColor = true;
            this.pnlWatchTypeFlagFile.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlWatchTypeFlagFile.Controls.Add(this.ucWatchTypeFlagFile);
            this.pnlWatchTypeFlagFile.Location = new System.Drawing.Point(-6, 64);
            this.pnlWatchTypeFlagFile.Name = "pnlWatchTypeFlagFile";
            this.pnlWatchTypeFlagFile.Size = new System.Drawing.Size(686, 124);
            this.pnlWatchTypeFlagFile.TabIndex = 6;
            this.pnlWatchTypeFlagFile.Visible = false;
            // 
            // ucWatchTypeFlagFile
            // 
            this.ucWatchTypeFlagFile.BackColor = System.Drawing.Color.Transparent;
            this.ucWatchTypeFlagFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWatchTypeFlagFile.Location = new System.Drawing.Point(0, 0);
            this.ucWatchTypeFlagFile.Name = "ucWatchTypeFlagFile";
            this.ucWatchTypeFlagFile.Size = new System.Drawing.Size(686, 124);
            this.ucWatchTypeFlagFile.TabIndex = 0;
            // 
            // pnlWatchTypeNormal
            // 
            this.pnlWatchTypeNormal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWatchTypeNormal.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlWatchTypeNormal.Appearance.Options.UseBackColor = true;
            this.pnlWatchTypeNormal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlWatchTypeNormal.Controls.Add(this.ucWatchTypeNormal);
            this.pnlWatchTypeNormal.Location = new System.Drawing.Point(-6, 64);
            this.pnlWatchTypeNormal.Name = "pnlWatchTypeNormal";
            this.pnlWatchTypeNormal.Size = new System.Drawing.Size(686, 83);
            this.pnlWatchTypeNormal.TabIndex = 7;
            this.pnlWatchTypeNormal.Visible = false;
            // 
            // ucWatchTypeNormal
            // 
            this.ucWatchTypeNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWatchTypeNormal.Location = new System.Drawing.Point(0, 0);
            this.ucWatchTypeNormal.Name = "ucWatchTypeNormal";
            this.ucWatchTypeNormal.Size = new System.Drawing.Size(686, 83);
            this.ucWatchTypeNormal.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.chkBackupFileFlag);
            this.xtraTabPage2.Controls.Add(this.labelControl8);
            this.xtraTabPage2.Controls.Add(this.edtBackupFileFolder);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(676, 233);
            this.xtraTabPage2.Text = "备份模式";
            // 
            // chkBackupFileFlag
            // 
            this.chkBackupFileFlag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBackupFileFlag.EnterMoveNextControl = true;
            this.chkBackupFileFlag.Location = new System.Drawing.Point(9, 13);
            this.chkBackupFileFlag.Name = "chkBackupFileFlag";
            this.chkBackupFileFlag.Properties.Caption = "备份处理的文件";
            this.chkBackupFileFlag.Size = new System.Drawing.Size(310, 19);
            this.chkBackupFileFlag.TabIndex = 8;
            this.chkBackupFileFlag.CheckedChanged += new System.EventHandler(this.chkBackupFileFlag_CheckedChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(49, 38);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(72, 14);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "备份文件夹：";
            // 
            // edtBackupFileFolder
            // 
            this.edtBackupFileFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBackupFileFolder.Enabled = false;
            this.edtBackupFileFolder.EnterMoveNextControl = true;
            this.edtBackupFileFolder.Location = new System.Drawing.Point(183, 35);
            this.edtBackupFileFolder.Name = "edtBackupFileFolder";
            this.edtBackupFileFolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtBackupFileFolder.Properties.NullValuePrompt = "请输入备份文件夹或者点击右侧按钮来选择文件夹";
            this.edtBackupFileFolder.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtBackupFileFolder.Size = new System.Drawing.Size(487, 20);
            this.edtBackupFileFolder.TabIndex = 13;
            this.edtBackupFileFolder.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtBackupFileFolder_ButtonClick);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.pnlDealTypeInsertIntoTable);
            this.xtraTabPage3.Controls.Add(this.labelControl10);
            this.xtraTabPage3.Controls.Add(this.pnlDealTypeMoveToFolder);
            this.xtraTabPage3.Controls.Add(this.pnlDealTypeCallStoreProcedure);
            this.xtraTabPage3.Controls.Add(this.cboFileDealType);
            this.xtraTabPage3.Controls.Add(this.pnlDealTypeFTP);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(676, 233);
            this.xtraTabPage3.Text = "处理模式";
            // 
            // pnlDealTypeInsertIntoTable
            // 
            this.pnlDealTypeInsertIntoTable.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlDealTypeInsertIntoTable.Appearance.Options.UseBackColor = true;
            this.pnlDealTypeInsertIntoTable.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDealTypeInsertIntoTable.Controls.Add(this.ucDealTypeInsertIntoTable);
            this.pnlDealTypeInsertIntoTable.Location = new System.Drawing.Point(9, 36);
            this.pnlDealTypeInsertIntoTable.Name = "pnlDealTypeInsertIntoTable";
            this.pnlDealTypeInsertIntoTable.Size = new System.Drawing.Size(664, 180);
            this.pnlDealTypeInsertIntoTable.TabIndex = 21;
            this.pnlDealTypeInsertIntoTable.Visible = false;
            // 
            // ucDealTypeInsertIntoTable
            // 
            this.ucDealTypeInsertIntoTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDealTypeInsertIntoTable.Location = new System.Drawing.Point(0, 0);
            this.ucDealTypeInsertIntoTable.Name = "ucDealTypeInsertIntoTable";
            this.ucDealTypeInsertIntoTable.Size = new System.Drawing.Size(664, 180);
            this.ucDealTypeInsertIntoTable.TabIndex = 0;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(9, 13);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(84, 14);
            this.labelControl10.TabIndex = 14;
            this.labelControl10.Text = "文件处理类型：";
            // 
            // pnlDealTypeMoveToFolder
            // 
            this.pnlDealTypeMoveToFolder.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlDealTypeMoveToFolder.Appearance.Options.UseBackColor = true;
            this.pnlDealTypeMoveToFolder.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDealTypeMoveToFolder.Controls.Add(this.ucDealTypeMoveToFolder);
            this.pnlDealTypeMoveToFolder.Location = new System.Drawing.Point(9, 36);
            this.pnlDealTypeMoveToFolder.Name = "pnlDealTypeMoveToFolder";
            this.pnlDealTypeMoveToFolder.Size = new System.Drawing.Size(667, 32);
            this.pnlDealTypeMoveToFolder.TabIndex = 17;
            this.pnlDealTypeMoveToFolder.Visible = false;
            // 
            // ucDealTypeMoveToFolder
            // 
            this.ucDealTypeMoveToFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDealTypeMoveToFolder.Location = new System.Drawing.Point(0, 0);
            this.ucDealTypeMoveToFolder.Name = "ucDealTypeMoveToFolder";
            this.ucDealTypeMoveToFolder.Size = new System.Drawing.Size(667, 32);
            this.ucDealTypeMoveToFolder.TabIndex = 0;
            // 
            // pnlDealTypeCallStoreProcedure
            // 
            this.pnlDealTypeCallStoreProcedure.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlDealTypeCallStoreProcedure.Appearance.Options.UseBackColor = true;
            this.pnlDealTypeCallStoreProcedure.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDealTypeCallStoreProcedure.Controls.Add(this.ucDealTypeCallStoreProcedure);
            this.pnlDealTypeCallStoreProcedure.Location = new System.Drawing.Point(9, 36);
            this.pnlDealTypeCallStoreProcedure.Name = "pnlDealTypeCallStoreProcedure";
            this.pnlDealTypeCallStoreProcedure.Size = new System.Drawing.Size(662, 180);
            this.pnlDealTypeCallStoreProcedure.TabIndex = 20;
            this.pnlDealTypeCallStoreProcedure.Visible = false;
            // 
            // ucDealTypeCallStoreProcedure
            // 
            this.ucDealTypeCallStoreProcedure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDealTypeCallStoreProcedure.Location = new System.Drawing.Point(0, 0);
            this.ucDealTypeCallStoreProcedure.Name = "ucDealTypeCallStoreProcedure";
            this.ucDealTypeCallStoreProcedure.Size = new System.Drawing.Size(662, 180);
            this.ucDealTypeCallStoreProcedure.TabIndex = 0;
            // 
            // cboFileDealType
            // 
            this.cboFileDealType.EnterMoveNextControl = true;
            this.cboFileDealType.Location = new System.Drawing.Point(111, 10);
            this.cboFileDealType.Name = "cboFileDealType";
            this.cboFileDealType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFileDealType.Size = new System.Drawing.Size(208, 20);
            this.cboFileDealType.TabIndex = 15;
            this.cboFileDealType.SelectedIndexChanged += new System.EventHandler(this.cboFileDealType_SelectedIndexChanged);
            // 
            // pnlDealTypeFTP
            // 
            this.pnlDealTypeFTP.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlDealTypeFTP.Appearance.Options.UseBackColor = true;
            this.pnlDealTypeFTP.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDealTypeFTP.Controls.Add(this.ucDealTypeFTP);
            this.pnlDealTypeFTP.Location = new System.Drawing.Point(9, 36);
            this.pnlDealTypeFTP.Name = "pnlDealTypeFTP";
            this.pnlDealTypeFTP.Size = new System.Drawing.Size(681, 110);
            this.pnlDealTypeFTP.TabIndex = 16;
            this.pnlDealTypeFTP.Visible = false;
            // 
            // ucDealTypeFTP
            // 
            this.ucDealTypeFTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDealTypeFTP.Location = new System.Drawing.Point(0, 0);
            this.ucDealTypeFTP.Name = "ucDealTypeFTP";
            this.ucDealTypeFTP.Size = new System.Drawing.Size(681, 110);
            this.ucDealTypeFTP.TabIndex = 0;
            // 
            // edtTaskName
            // 
            this.edtTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTaskName.EnterMoveNextControl = true;
            this.edtTaskName.Location = new System.Drawing.Point(101, 12);
            this.edtTaskName.Name = "edtTaskName";
            this.edtTaskName.Properties.NullValuePrompt = "请输入文件夹监控任务的名称";
            this.edtTaskName.Properties.NullValuePromptShowForEmptyValue = true;
            this.edtTaskName.Properties.ShowNullValuePromptWhenFocused = true;
            this.edtTaskName.Size = new System.Drawing.Size(576, 20);
            this.edtTaskName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "任务名称：";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(507, 322);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 31);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(608, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 31);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmTaskEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(715, 357);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlEditorBody);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaskEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTaskEditor";
            this.Load += new System.EventHandler(this.frmTaskEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEditorBody)).EndInit();
            this.pnlEditorBody.ResumeLayout(false);
            this.pnlEditorBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWatchType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWatchFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWatchTypeFlagFile)).EndInit();
            this.pnlWatchTypeFlagFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlWatchTypeNormal)).EndInit();
            this.pnlWatchTypeNormal.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBackupFileFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBackupFileFolder.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDealTypeInsertIntoTable)).EndInit();
            this.pnlDealTypeInsertIntoTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDealTypeMoveToFolder)).EndInit();
            this.pnlDealTypeMoveToFolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDealTypeCallStoreProcedure)).EndInit();
            this.pnlDealTypeCallStoreProcedure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboFileDealType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDealTypeFTP)).EndInit();
            this.pnlDealTypeFTP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTaskName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlEditorBody;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit edtTaskName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboWatchType;
        private DevExpress.XtraEditors.PanelControl pnlWatchTypeFlagFile;
        private DevExpress.XtraEditors.ButtonEdit edtWatchFolder;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl pnlDealTypeFTP;
        private DevExpress.XtraEditors.ImageComboBoxEdit cboFileDealType;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ButtonEdit edtBackupFileFolder;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.CheckEdit chkBackupFileFlag;
        private DevExpress.XtraEditors.PanelControl pnlWatchTypeNormal;
        private DevExpress.XtraEditors.PanelControl pnlDealTypeCallStoreProcedure;
        private DevExpress.XtraEditors.PanelControl pnlDealTypeMoveToFolder;
        private UserControls.UCWatchTypeNormal ucWatchTypeNormal;
        private UserControls.UCWatchTypeFlagFile ucWatchTypeFlagFile;
        private UserControls.UCDealTypeCallStoreProcedure ucDealTypeCallStoreProcedure;
        private UserControls.UCDealTypeMoveToFolder ucDealTypeMoveToFolder;
        private UserControls.UCDealTypeFTP ucDealTypeFTP;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.PanelControl pnlDealTypeInsertIntoTable;
        private UserControls.UCDealTypeInsertIntoTable ucDealTypeInsertIntoTable;
    }
}