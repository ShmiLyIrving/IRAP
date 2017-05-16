namespace MaterialLabelPrint_Asimco
{
    partial class frmMainLabelPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainLabelPrint));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.edtPort = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtIPAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpLabels = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnS000001Label = new DevExpress.XtraEditors.SimpleButton();
            this.edtStoreSiteNoFillter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectNone = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetLabelFMTStrings = new DevExpress.XtraEditors.SimpleButton();
            this.grdLabels = new DevExpress.XtraGrid.GridControl();
            this.grdvLabels = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnCoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdclmnStoreSiteNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSKUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMaterialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpDBParams = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIPAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtStoreSiteNoFillter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvLabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 5);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel1.Controls.Add(this.edtPort);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.edtIPAddress);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "标签打印机设置";
            this.splitContainerControl1.Panel2.Controls.Add(this.tcMain);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(880, 725);
            this.splitContainerControl1.SplitterPosition = 70;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // edtPort
            // 
            this.edtPort.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edtPort.Location = new System.Drawing.Point(375, 7);
            this.edtPort.Name = "edtPort";
            this.edtPort.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtPort.Properties.Appearance.Options.UseFont = true;
            this.edtPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtPort.Size = new System.Drawing.Size(90, 26);
            this.edtPort.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl2.Location = new System.Drawing.Point(327, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 20);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "端口：";
            // 
            // edtIPAddress
            // 
            this.edtIPAddress.Location = new System.Drawing.Point(93, 7);
            this.edtIPAddress.Name = "edtIPAddress";
            this.edtIPAddress.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtIPAddress.Properties.Appearance.Options.UseFont = true;
            this.edtIPAddress.Size = new System.Drawing.Size(228, 26);
            this.edtIPAddress.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl1.Location = new System.Drawing.Point(17, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "网络地址：";
            // 
            // tcMain
            // 
            this.tcMain.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.Appearance.Options.UseFont = true;
            this.tcMain.AppearancePage.Header.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.AppearancePage.Header.Options.UseFont = true;
            this.tcMain.AppearancePage.HeaderActive.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.AppearancePage.HeaderActive.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.tcMain.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tcMain.AppearancePage.HeaderDisabled.ForeColor = System.Drawing.Color.Silver;
            this.tcMain.AppearancePage.HeaderDisabled.Options.UseForeColor = true;
            this.tcMain.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.AppearancePage.HeaderHotTracked.ForeColor = System.Drawing.Color.Blue;
            this.tcMain.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.tcMain.AppearancePage.HeaderHotTracked.Options.UseForeColor = true;
            this.tcMain.AppearancePage.PageClient.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.AppearancePage.PageClient.Options.UseFont = true;
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpLabels;
            this.tcMain.Size = new System.Drawing.Size(880, 650);
            this.tcMain.TabIndex = 0;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpLabels,
            this.tpDBParams});
            // 
            // tpLabels
            // 
            this.tpLabels.Controls.Add(this.splitContainerControl2);
            this.tpLabels.Name = "tpLabels";
            this.tpLabels.Padding = new System.Windows.Forms.Padding(10);
            this.tpLabels.Size = new System.Drawing.Size(874, 615);
            this.tpLabels.Text = "待打印的标签";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(10, 10);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.btnS000001Label);
            this.splitContainerControl2.Panel1.Controls.Add(this.edtStoreSiteNoFillter);
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnSelectNone);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnSelectAll);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnPrint);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnGetLabelFMTStrings);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl2.Panel2.Controls.Add(this.grdLabels);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            this.splitContainerControl2.Panel2.Text = "标签列表";
            this.splitContainerControl2.Size = new System.Drawing.Size(854, 595);
            this.splitContainerControl2.SplitterPosition = 45;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // btnS000001Label
            // 
            this.btnS000001Label.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnS000001Label.Appearance.Options.UseFont = true;
            this.btnS000001Label.Location = new System.Drawing.Point(366, 3);
            this.btnS000001Label.Name = "btnS000001Label";
            this.btnS000001Label.Size = new System.Drawing.Size(104, 37);
            this.btnS000001Label.TabIndex = 2;
            this.btnS000001Label.TabStop = false;
            this.btnS000001Label.Text = "线边库标签";
            this.btnS000001Label.Click += new System.EventHandler(this.btnS000001Label_Click);
            // 
            // edtStoreSiteNoFillter
            // 
            this.edtStoreSiteNoFillter.Location = new System.Drawing.Point(98, 9);
            this.edtStoreSiteNoFillter.Name = "edtStoreSiteNoFillter";
            this.edtStoreSiteNoFillter.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtStoreSiteNoFillter.Properties.Appearance.Options.UseFont = true;
            this.edtStoreSiteNoFillter.Size = new System.Drawing.Size(152, 26);
            this.edtStoreSiteNoFillter.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl3.Location = new System.Drawing.Point(8, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(84, 20);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "库位号过滤：";
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectNone.Appearance.Options.UseFont = true;
            this.btnSelectNone.Location = new System.Drawing.Point(613, 3);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(104, 37);
            this.btnSelectNone.TabIndex = 4;
            this.btnSelectNone.TabStop = false;
            this.btnSelectNone.Text = "全不选";
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Appearance.Options.UseFont = true;
            this.btnSelectAll.Location = new System.Drawing.Point(503, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(104, 37);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.TabStop = false;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Location = new System.Drawing.Point(743, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(104, 37);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnGetLabelFMTStrings
            // 
            this.btnGetLabelFMTStrings.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetLabelFMTStrings.Appearance.Options.UseFont = true;
            this.btnGetLabelFMTStrings.Location = new System.Drawing.Point(256, 3);
            this.btnGetLabelFMTStrings.Name = "btnGetLabelFMTStrings";
            this.btnGetLabelFMTStrings.Size = new System.Drawing.Size(104, 37);
            this.btnGetLabelFMTStrings.TabIndex = 1;
            this.btnGetLabelFMTStrings.TabStop = false;
            this.btnGetLabelFMTStrings.Text = "获取标签";
            this.btnGetLabelFMTStrings.Click += new System.EventHandler(this.btnGetLabelFMTStrings_Click);
            // 
            // grdLabels
            // 
            this.grdLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLabels.Location = new System.Drawing.Point(5, 5);
            this.grdLabels.MainView = this.grdvLabels;
            this.grdLabels.Name = "grdLabels";
            this.grdLabels.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdLabels.Size = new System.Drawing.Size(840, 506);
            this.grdLabels.TabIndex = 0;
            this.grdLabels.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvLabels});
            // 
            // grdvLabels
            // 
            this.grdvLabels.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvLabels.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvLabels.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvLabels.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvLabels.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvLabels.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvLabels.Appearance.Row.Options.UseFont = true;
            this.grdvLabels.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnCoice,
            this.grdclmnStoreSiteNo,
            this.grdclmnSKUID,
            this.grdclmnMaterialCode,
            this.grdclmnLotNumber,
            this.grdclmnQuantity});
            this.grdvLabels.GridControl = this.grdLabels;
            this.grdvLabels.Name = "grdvLabels";
            this.grdvLabels.OptionsView.ColumnAutoWidth = false;
            this.grdvLabels.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnCoice
            // 
            this.grdclmnCoice.Caption = "打印";
            this.grdclmnCoice.ColumnEdit = this.repositoryItemCheckEdit1;
            this.grdclmnCoice.FieldName = "Choice";
            this.grdclmnCoice.Name = "grdclmnCoice";
            this.grdclmnCoice.Visible = true;
            this.grdclmnCoice.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // grdclmnStoreSiteNo
            // 
            this.grdclmnStoreSiteNo.Caption = "库位号";
            this.grdclmnStoreSiteNo.FieldName = "StoreSiteNo";
            this.grdclmnStoreSiteNo.Name = "grdclmnStoreSiteNo";
            this.grdclmnStoreSiteNo.OptionsColumn.AllowEdit = false;
            this.grdclmnStoreSiteNo.OptionsColumn.ReadOnly = true;
            this.grdclmnStoreSiteNo.Visible = true;
            this.grdclmnStoreSiteNo.VisibleIndex = 1;
            // 
            // grdclmnSKUID
            // 
            this.grdclmnSKUID.Caption = "SKUID";
            this.grdclmnSKUID.FieldName = "SKUID";
            this.grdclmnSKUID.Name = "grdclmnSKUID";
            this.grdclmnSKUID.OptionsColumn.AllowEdit = false;
            this.grdclmnSKUID.OptionsColumn.ReadOnly = true;
            this.grdclmnSKUID.Visible = true;
            this.grdclmnSKUID.VisibleIndex = 2;
            // 
            // grdclmnMaterialCode
            // 
            this.grdclmnMaterialCode.Caption = "物料号";
            this.grdclmnMaterialCode.FieldName = "MaterialCode";
            this.grdclmnMaterialCode.Name = "grdclmnMaterialCode";
            this.grdclmnMaterialCode.OptionsColumn.AllowEdit = false;
            this.grdclmnMaterialCode.OptionsColumn.ReadOnly = true;
            this.grdclmnMaterialCode.Visible = true;
            this.grdclmnMaterialCode.VisibleIndex = 3;
            // 
            // grdclmnLotNumber
            // 
            this.grdclmnLotNumber.Caption = "进货批次号";
            this.grdclmnLotNumber.FieldName = "InLotNumber";
            this.grdclmnLotNumber.Name = "grdclmnLotNumber";
            this.grdclmnLotNumber.OptionsColumn.AllowEdit = false;
            this.grdclmnLotNumber.OptionsColumn.ReadOnly = true;
            this.grdclmnLotNumber.Visible = true;
            this.grdclmnLotNumber.VisibleIndex = 4;
            // 
            // grdclmnQuantity
            // 
            this.grdclmnQuantity.Caption = "数量";
            this.grdclmnQuantity.FieldName = "Quantity";
            this.grdclmnQuantity.Name = "grdclmnQuantity";
            this.grdclmnQuantity.OptionsColumn.AllowEdit = false;
            this.grdclmnQuantity.OptionsColumn.ReadOnly = true;
            this.grdclmnQuantity.Visible = true;
            this.grdclmnQuantity.VisibleIndex = 5;
            // 
            // tpDBParams
            // 
            this.tpDBParams.Name = "tpDBParams";
            this.tpDBParams.Size = new System.Drawing.Size(874, 615);
            this.tpDBParams.Text = "数据库连接配置";
            // 
            // frmMainLabelPrint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(890, 735);
            this.Controls.Add(this.splitContainerControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMainLabelPrint";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "双环钢带库物料标签批量打印";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIPAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpLabels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtStoreSiteNoFillter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvLabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.TextEdit edtIPAddress;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit edtPort;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpLabels;
        private DevExpress.XtraTab.XtraTabPage tpDBParams;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnGetLabelFMTStrings;
        private DevExpress.XtraGrid.GridControl grdLabels;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvLabels;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStoreSiteNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSKUID;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMaterialCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLotNumber;
        private DevExpress.XtraEditors.SimpleButton btnSelectNone;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.TextEdit edtStoreSiteNoFillter;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnS000001Label;
    }
}

