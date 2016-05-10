namespace UpdateBuilder
{
    partial class frmUpdateProjectFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateProjectFile));
            DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule1 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule2 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule treeListFormatRule3 = new DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.tlcFileExists = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcFileName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcNeedUpgrade = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcVersion = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcMD5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnFileAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveFiles = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddFilesInDirectory = new DevExpress.XtraBars.BarButtonItem();
            this.btnGenerate = new DevExpress.XtraBars.BarButtonItem();
            this.btnProperties = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tvlUpgradeFiles = new DevExpress.XtraTreeList.TreeList();
            this.tlcSelected = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvlUpgradeFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlcFileExists
            // 
            this.tlcFileExists.Caption = "treeListColumn1";
            this.tlcFileExists.FieldName = "FileExists";
            this.tlcFileExists.Name = "tlcFileExists";
            // 
            // tlcFileName
            // 
            this.tlcFileName.AppearanceCell.Options.UseTextOptions = true;
            this.tlcFileName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tlcFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcFileName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tlcFileName.Caption = "文件名";
            this.tlcFileName.FieldName = "FileName";
            this.tlcFileName.Name = "tlcFileName";
            this.tlcFileName.OptionsColumn.AllowEdit = false;
            this.tlcFileName.OptionsColumn.AllowMove = false;
            this.tlcFileName.Visible = true;
            this.tlcFileName.VisibleIndex = 1;
            this.tlcFileName.Width = 291;
            // 
            // tlcNeedUpgrade
            // 
            this.tlcNeedUpgrade.Caption = "treeListColumn1";
            this.tlcNeedUpgrade.FieldName = "NeedUpgraded";
            this.tlcNeedUpgrade.Name = "tlcNeedUpgrade";
            // 
            // tlcVersion
            // 
            this.tlcVersion.AppearanceCell.Options.UseTextOptions = true;
            this.tlcVersion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcVersion.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tlcVersion.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcVersion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcVersion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tlcVersion.Caption = "版本号";
            this.tlcVersion.FieldName = "CurrentVersion";
            this.tlcVersion.Name = "tlcVersion";
            this.tlcVersion.OptionsColumn.AllowEdit = false;
            this.tlcVersion.OptionsColumn.AllowMove = false;
            this.tlcVersion.Visible = true;
            this.tlcVersion.VisibleIndex = 2;
            this.tlcVersion.Width = 148;
            // 
            // tlcMD5
            // 
            this.tlcMD5.AppearanceCell.Options.UseTextOptions = true;
            this.tlcMD5.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tlcMD5.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcMD5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcMD5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tlcMD5.Caption = "MD5值";
            this.tlcMD5.FieldName = "CurrentMD5";
            this.tlcMD5.Name = "tlcMD5";
            this.tlcMD5.OptionsColumn.AllowEdit = false;
            this.tlcMD5.OptionsColumn.AllowMove = false;
            this.tlcMD5.Visible = true;
            this.tlcMD5.VisibleIndex = 3;
            this.tlcMD5.Width = 148;
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnFileAdd,
            this.btnRemoveFiles,
            this.btnAddFilesInDirectory,
            this.btnGenerate,
            this.btnProperties});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(665, 151);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnFileAdd
            // 
            this.btnFileAdd.Caption = "添加文件";
            this.btnFileAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFileAdd.Glyph")));
            this.btnFileAdd.Id = 1;
            this.btnFileAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFileAdd.LargeGlyph")));
            this.btnFileAdd.Name = "btnFileAdd";
            this.btnFileAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFileAdd_ItemClick);
            // 
            // btnRemoveFiles
            // 
            this.btnRemoveFiles.Caption = "删除文件";
            this.btnRemoveFiles.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveFiles.Glyph")));
            this.btnRemoveFiles.Id = 3;
            this.btnRemoveFiles.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveFiles.LargeGlyph")));
            this.btnRemoveFiles.Name = "btnRemoveFiles";
            this.btnRemoveFiles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveFiles_ItemClick);
            // 
            // btnAddFilesInDirectory
            // 
            this.btnAddFilesInDirectory.Caption = "添加目录中的文件";
            this.btnAddFilesInDirectory.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddFilesInDirectory.Glyph")));
            this.btnAddFilesInDirectory.Id = 5;
            this.btnAddFilesInDirectory.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddFilesInDirectory.LargeGlyph")));
            this.btnAddFilesInDirectory.Name = "btnAddFilesInDirectory";
            this.btnAddFilesInDirectory.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnAddFilesInDirectory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddFilesInDirectory_ItemClick);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Caption = "生成配置文件";
            this.btnGenerate.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGenerate.Glyph")));
            this.btnGenerate.Id = 6;
            this.btnGenerate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnGenerate.LargeGlyph")));
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerate_ItemClick);
            // 
            // btnProperties
            // 
            this.btnProperties.Caption = "属性";
            this.btnProperties.Glyph = ((System.Drawing.Image)(resources.GetObject("btnProperties.Glyph")));
            this.btnProperties.Id = 7;
            this.btnProperties.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnProperties.LargeGlyph")));
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "项目";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGenerate, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnProperties, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFileAdd, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAddFilesInDirectory);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRemoveFiles, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "更新/升级文件";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 406);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(665, 23);
            // 
            // tvlUpgradeFiles
            // 
            this.tvlUpgradeFiles.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcSelected,
            this.tlcFileName,
            this.tlcVersion,
            this.tlcMD5,
            this.tlcFileExists,
            this.tlcNeedUpgrade});
            this.tvlUpgradeFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            treeListFormatRule1.ApplyToRow = true;
            treeListFormatRule1.Column = this.tlcFileExists;
            treeListFormatRule1.ColumnApplyTo = this.tlcFileName;
            treeListFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Silver;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = false;
            treeListFormatRule1.Rule = formatConditionRuleValue1;
            treeListFormatRule1.StopIfTrue = true;
            treeListFormatRule2.Column = this.tlcNeedUpgrade;
            treeListFormatRule2.ColumnApplyTo = this.tlcVersion;
            treeListFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.Green;
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Expression = "NeedUpgraded";
            formatConditionRuleValue2.Value1 = true;
            treeListFormatRule2.Rule = formatConditionRuleValue2;
            treeListFormatRule3.Column = this.tlcNeedUpgrade;
            treeListFormatRule3.ColumnApplyTo = this.tlcMD5;
            treeListFormatRule3.Name = "Format2";
            formatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.Green;
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Expression = "NeedUpgraded";
            formatConditionRuleValue3.Value1 = true;
            treeListFormatRule3.Rule = formatConditionRuleValue3;
            this.tvlUpgradeFiles.FormatRules.Add(treeListFormatRule1);
            this.tvlUpgradeFiles.FormatRules.Add(treeListFormatRule2);
            this.tvlUpgradeFiles.FormatRules.Add(treeListFormatRule3);
            this.tvlUpgradeFiles.Location = new System.Drawing.Point(0, 151);
            this.tvlUpgradeFiles.Name = "tvlUpgradeFiles";
            this.tvlUpgradeFiles.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.tvlUpgradeFiles.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.tvlUpgradeFiles.OptionsSelection.MultiSelect = true;
            this.tvlUpgradeFiles.OptionsView.AutoWidth = false;
            this.tvlUpgradeFiles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.tvlUpgradeFiles.Size = new System.Drawing.Size(665, 255);
            this.tvlUpgradeFiles.TabIndex = 2;
            // 
            // tlcSelected
            // 
            this.tlcSelected.AppearanceCell.Options.UseTextOptions = true;
            this.tlcSelected.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcSelected.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tlcSelected.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcSelected.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcSelected.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tlcSelected.Caption = " ";
            this.tlcSelected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.tlcSelected.FieldName = "Selected";
            this.tlcSelected.MinWidth = 34;
            this.tlcSelected.Name = "tlcSelected";
            this.tlcSelected.Visible = true;
            this.tlcSelected.VisibleIndex = 0;
            this.tlcSelected.Width = 34;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "执行文件(*.exe)|*.exe|类库文件(*.dll)|*.dll|配置文件(*.ini;*.config)|*.ini;*.config|所有文件(*.*)" +
    "|*.*";
            this.openFileDialog.Multiselect = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.Filter = "升级配置文件(*.xml)|*.xml";
            this.saveFileDialog.Title = "升级配置文件名";
            // 
            // frmUpdateProjectFile
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(665, 429);
            this.Controls.Add(this.tvlUpgradeFiles);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmUpdateProjectFile";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "升级项目文件";
            this.Load += new System.EventHandler(this.frmUpdateProjectFile_Load);
            this.Shown += new System.EventHandler(this.frmUpdateProjectFile_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvlUpgradeFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnFileAdd;
        private DevExpress.XtraBars.BarButtonItem btnRemoveFiles;
        private DevExpress.XtraBars.BarButtonItem btnAddFilesInDirectory;
        private DevExpress.XtraTreeList.TreeList tvlUpgradeFiles;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcFileName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcVersion;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcMD5;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private DevExpress.XtraBars.BarButtonItem btnGenerate;
        private DevExpress.XtraBars.BarButtonItem btnProperties;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcFileExists;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcNeedUpgrade;
    }
}