namespace IRAP.Client.GUI.MDM {
    partial class frmGeneralImport {
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
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelRight = new DevExpress.XtraEditors.PanelControl();
            this.colorPanel1 = new IRAP.Client.GUI.MDM.ColorPanel();
            this.checkEditLog = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditImportAll = new DevExpress.XtraEditors.CheckEdit();
            this.btnLoadPart = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelState = new DevExpress.XtraEditors.LabelControl();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnValidate = new DevExpress.XtraEditors.SimpleButton();
            this.panelRightTop = new DevExpress.XtraLayout.LayoutControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemSelect = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditImportAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelRightTop)).BeginInit();
            this.panelRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // treeList
            // 
            this.treeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeList.Caption = "导航树";
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList.CustomizationFormBounds = new System.Drawing.Rectangle(954, 430, 216, 208);
            this.treeList.KeyFieldName = "NodeID";
            this.treeList.Location = new System.Drawing.Point(3, 62);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeList.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeList.ParentFieldName = "Parent";
            this.treeList.Size = new System.Drawing.Size(270, 430);
            this.treeList.TabIndex = 1;
            this.treeList.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList_AfterFocusNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "导航树";
            this.treeListColumn1.FieldName = "NodeName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowMove = false;
            this.treeListColumn1.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.treeListColumn1.OptionsColumn.AllowSize = false;
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.OptionsColumn.ReadOnly = true;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.Controls.Add(this.colorPanel1);
            this.panelRight.Controls.Add(this.checkEditLog);
            this.panelRight.Controls.Add(this.checkEditImportAll);
            this.panelRight.Controls.Add(this.btnLoadPart);
            this.panelRight.Controls.Add(this.gridControl1);
            this.panelRight.Controls.Add(this.labelState);
            this.panelRight.Controls.Add(this.btnLoad);
            this.panelRight.Controls.Add(this.btnValidate);
            this.panelRight.Controls.Add(this.panelRightTop);
            this.panelRight.Location = new System.Drawing.Point(279, 62);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(605, 430);
            this.panelRight.TabIndex = 3;
            // 
            // colorPanel1
            // 
            this.colorPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorPanel1.AutoScroll = true;
            this.colorPanel1.EachRowNumber = 6;
            this.colorPanel1.Location = new System.Drawing.Point(8, 43);
            this.colorPanel1.Name = "colorPanel1";
            this.colorPanel1.Size = new System.Drawing.Size(587, 25);
            this.colorPanel1.TabIndex = 20;
            // 
            // checkEditLog
            // 
            this.checkEditLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkEditLog.AutoSizeInLayoutControl = true;
            this.checkEditLog.EditValue = true;
            this.checkEditLog.Location = new System.Drawing.Point(360, 406);
            this.checkEditLog.Name = "checkEditLog";
            this.checkEditLog.Properties.Caption = "加载后是否迁移导入日志";
            this.checkEditLog.Size = new System.Drawing.Size(184, 19);
            this.checkEditLog.TabIndex = 17;
            // 
            // checkEditImportAll
            // 
            this.checkEditImportAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkEditImportAll.EditValue = true;
            this.checkEditImportAll.Location = new System.Drawing.Point(248, 406);
            this.checkEditImportAll.Name = "checkEditImportAll";
            this.checkEditImportAll.Properties.Caption = "是否导入全量";
            this.checkEditImportAll.Size = new System.Drawing.Size(105, 19);
            this.checkEditImportAll.TabIndex = 16;
            // 
            // btnLoadPart
            // 
            this.btnLoadPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadPart.Enabled = false;
            this.btnLoadPart.Location = new System.Drawing.Point(167, 402);
            this.btnLoadPart.Name = "btnLoadPart";
            this.btnLoadPart.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLoadPart.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPart.TabIndex = 15;
            this.btnLoadPart.Text = "部分加载";
            this.btnLoadPart.Click += new System.EventHandler(this.btnLoadPart_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(5, 73);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(586, 298);
            this.gridControl1.TabIndex = 14;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridView1.OptionsMenu.ShowSplitItem = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // labelState
            // 
            this.labelState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelState.Location = new System.Drawing.Point(11, 378);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(0, 14);
            this.labelState.TabIndex = 19;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(86, 402);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "加载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnValidate.Enabled = false;
            this.btnValidate.Location = new System.Drawing.Point(5, 402);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 12;
            this.btnValidate.Text = "验证";
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // panelRightTop
            // 
            this.panelRightTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRightTop.AutoScroll = false;
            this.panelRightTop.Controls.Add(this.btnExport);
            this.panelRightTop.Controls.Add(this.btnImport);
            this.panelRightTop.Controls.Add(this.comboBoxEdit1);
            this.panelRightTop.Location = new System.Drawing.Point(1, 2);
            this.panelRightTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelRightTop.Name = "panelRightTop";
            this.panelRightTop.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(337, 135, 250, 350);
            this.panelRightTop.Root = this.layoutControlGroup2;
            this.panelRightTop.Size = new System.Drawing.Size(601, 46);
            this.panelRightTop.TabIndex = 11;
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(416, 12);
            this.btnExport.MaximumSize = new System.Drawing.Size(68, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnExport.Size = new System.Drawing.Size(68, 22);
            this.btnExport.StyleController = this.panelRightTop;
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.AllowFocus = false;
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(344, 12);
            this.btnImport.MaximumSize = new System.Drawing.Size(68, 0);
            this.btnImport.MinimumSize = new System.Drawing.Size(68, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnImport.Size = new System.Drawing.Size(68, 22);
            this.btnImport.StyleController = this.panelRightTop;
            this.btnImport.TabIndex = 17;
            this.btnImport.Text = "导入";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(158, 12);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(182, 20);
            this.comboBoxEdit1.StyleController = this.panelRightTop;
            this.comboBoxEdit1.TabIndex = 4;
            this.comboBoxEdit1.SelectedValueChanged += new System.EventHandler(this.comboBoxEdit1_SelectedValueChanged);
            this.comboBoxEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.comboBoxEdit1_QueryPopUp);
            this.comboBoxEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxEdit1_KeyDown);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutItemSelect,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(-1, 0);
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(601, 46);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutItemSelect
            // 
            this.layoutItemSelect.Control = this.comboBoxEdit1;
            this.layoutItemSelect.Location = new System.Drawing.Point(0, 0);
            this.layoutItemSelect.Name = "layoutItemSelect";
            this.layoutItemSelect.Size = new System.Drawing.Size(333, 26);
            this.layoutItemSelect.Text = "请选择一个具体产线或区域";
            this.layoutItemSelect.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutItemSelect.TextSize = new System.Drawing.Size(144, 14);
            this.layoutItemSelect.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(477, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(104, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.layoutControlItem1.Control = this.btnImport;
            this.layoutControlItem1.Location = new System.Drawing.Point(333, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(72, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.layoutControlItem2.Control = this.btnExport;
            this.layoutControlItem2.Location = new System.Drawing.Point(405, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(72, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmGeneralImport
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.treeList);
            this.Name = "frmGeneralImport";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmGeneralImport_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.treeList, 0);
            this.Controls.SetChildIndex(this.panelRight, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditImportAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelRightTop)).EndInit();
            this.panelRightTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.PanelControl panelRight;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraLayout.LayoutControl panelRightTop;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemSelect;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraEditors.SimpleButton btnValidate;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.CheckEdit checkEditLog;
        private DevExpress.XtraEditors.CheckEdit checkEditImportAll;
        private DevExpress.XtraEditors.SimpleButton btnLoadPart;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LabelControl labelState;
        private ColorPanel colorPanel1;
    }
}
