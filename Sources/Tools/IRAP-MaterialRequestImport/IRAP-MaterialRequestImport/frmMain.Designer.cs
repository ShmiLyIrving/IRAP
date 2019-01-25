namespace IRAP_MaterialRequestImport
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.grdclmnErrCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiReadFromExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDataValidate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDataUpload = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUserInfo = new DevExpress.XtraBars.BarStaticItem();
            this.bsiDBAddress = new DevExpress.XtraBars.BarStaticItem();
            this.bsiVersion = new DevExpress.XtraBars.BarStaticItem();
            this.bbiAbout = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grdvDatas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMaterialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnReqQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSrcLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnDstLoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRoutingCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnErrText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvDatas)).BeginInit();
            this.SuspendLayout();
            // 
            // grdclmnErrCode
            // 
            this.grdclmnErrCode.FieldName = "ErrCode";
            this.grdclmnErrCode.Name = "grdclmnErrCode";
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiReadFromExcel,
            this.bbiDataValidate,
            this.bbiDataUpload,
            this.bsiUserInfo,
            this.bsiDBAddress,
            this.bsiVersion,
            this.bbiAbout});
            this.ribbon.LargeImages = this.imageCollection;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(959, 149);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbiReadFromExcel
            // 
            this.bbiReadFromExcel.Caption = "物料需求读取";
            this.bbiReadFromExcel.Id = 1;
            this.bbiReadFromExcel.LargeImageIndex = 0;
            this.bbiReadFromExcel.Name = "bbiReadFromExcel";
            this.bbiReadFromExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReadFromExcel_ItemClick);
            // 
            // bbiDataValidate
            // 
            this.bbiDataValidate.Caption = "校验数据";
            this.bbiDataValidate.Id = 2;
            this.bbiDataValidate.LargeImageIndex = 1;
            this.bbiDataValidate.Name = "bbiDataValidate";
            this.bbiDataValidate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDataValidate_ItemClick);
            // 
            // bbiDataUpload
            // 
            this.bbiDataUpload.Caption = "上传物料需求";
            this.bbiDataUpload.Id = 3;
            this.bbiDataUpload.LargeImageIndex = 2;
            this.bbiDataUpload.Name = "bbiDataUpload";
            this.bbiDataUpload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDataUpload_ItemClick);
            // 
            // bsiUserInfo
            // 
            this.bsiUserInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiUserInfo.Caption = "登录用户：超级用户|机构：IRAP开发中心|角色：系统开发人员";
            this.bsiUserInfo.Id = 4;
            this.bsiUserInfo.Name = "bsiUserInfo";
            this.bsiUserInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiDBAddress
            // 
            this.bsiDBAddress.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiDBAddress.Caption = "数据库：192.168.97.208";
            this.bsiDBAddress.Id = 7;
            this.bsiDBAddress.Name = "bsiDBAddress";
            this.bsiDBAddress.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiVersion
            // 
            this.bsiVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiVersion.Caption = "版本：5.0";
            this.bsiVersion.Id = 8;
            this.bsiVersion.Name = "bsiVersion";
            this.bsiVersion.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiAbout
            // 
            this.bbiAbout.Caption = "　关于　";
            this.bbiAbout.Id = 9;
            this.bbiAbout.LargeImageIndex = 3;
            this.bbiAbout.Name = "bbiAbout";
            this.bbiAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAbout_ItemClick);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "import.png");
            this.imageCollection.Images.SetKeyName(1, "stock_task.png");
            this.imageCollection.Images.SetKeyName(2, "upload_database.png");
            this.imageCollection.Images.SetKeyName(3, "kdeprint_printer_infos.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "供应链系统";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiReadFromExcel);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDataValidate, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDataUpload, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "物料需求";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiAbout);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiUserInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiVersion, true);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiDBAddress, true);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 620);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(959, 23);
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Xmas 2008 Blue";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.grdData);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 149);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(11);
            this.pnlBody.Size = new System.Drawing.Size(959, 471);
            this.pnlBody.TabIndex = 2;
            // 
            // grdData
            // 
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(14, 14);
            this.grdData.MainView = this.grdvDatas;
            this.grdData.MenuManager = this.ribbon;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(931, 443);
            this.grdData.TabIndex = 0;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvDatas});
            // 
            // grdvDatas
            // 
            this.grdvDatas.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvDatas.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvDatas.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvDatas.Appearance.Row.ForeColor = System.Drawing.Color.Red;
            this.grdvDatas.Appearance.Row.Options.UseForeColor = true;
            this.grdvDatas.Appearance.Row.Options.UseTextOptions = true;
            this.grdvDatas.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvDatas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnMaterialCode,
            this.grdclmnReqQty,
            this.grdclmnSrcLoc,
            this.grdclmnDstLoc,
            this.grdclmnRoutingCode,
            this.grdclmnRemark,
            this.grdclmnErrCode,
            this.grdclmnErrText});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.grdclmnErrCode;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Green;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.grdclmnErrCode;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = -1;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.grdvDatas.FormatRules.Add(gridFormatRule1);
            this.grdvDatas.FormatRules.Add(gridFormatRule2);
            this.grdvDatas.GridControl = this.grdData;
            this.grdvDatas.Name = "grdvDatas";
            this.grdvDatas.OptionsBehavior.Editable = false;
            this.grdvDatas.OptionsView.ColumnAutoWidth = false;
            this.grdvDatas.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.Caption = "序号";
            this.grdclmnOrdinal.FieldName = "Ordinal";
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
            // 
            // grdclmnMaterialCode
            // 
            this.grdclmnMaterialCode.Caption = "物料号";
            this.grdclmnMaterialCode.FieldName = "MaterialCode";
            this.grdclmnMaterialCode.Name = "grdclmnMaterialCode";
            this.grdclmnMaterialCode.Visible = true;
            this.grdclmnMaterialCode.VisibleIndex = 1;
            // 
            // grdclmnReqQty
            // 
            this.grdclmnReqQty.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnReqQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnReqQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnReqQty.Caption = "需求数量";
            this.grdclmnReqQty.FieldName = "ReqQty";
            this.grdclmnReqQty.Name = "grdclmnReqQty";
            this.grdclmnReqQty.Visible = true;
            this.grdclmnReqQty.VisibleIndex = 2;
            // 
            // grdclmnSrcLoc
            // 
            this.grdclmnSrcLoc.Caption = "源库位";
            this.grdclmnSrcLoc.FieldName = "SrcLoc";
            this.grdclmnSrcLoc.Name = "grdclmnSrcLoc";
            this.grdclmnSrcLoc.Visible = true;
            this.grdclmnSrcLoc.VisibleIndex = 3;
            // 
            // grdclmnDstLoc
            // 
            this.grdclmnDstLoc.Caption = "目的库位";
            this.grdclmnDstLoc.FieldName = "DstLoc";
            this.grdclmnDstLoc.Name = "grdclmnDstLoc";
            this.grdclmnDstLoc.Visible = true;
            this.grdclmnDstLoc.VisibleIndex = 4;
            // 
            // grdclmnRoutingCode
            // 
            this.grdclmnRoutingCode.Caption = "配送路径";
            this.grdclmnRoutingCode.FieldName = "RoutingCode";
            this.grdclmnRoutingCode.Name = "grdclmnRoutingCode";
            this.grdclmnRoutingCode.Visible = true;
            this.grdclmnRoutingCode.VisibleIndex = 5;
            // 
            // grdclmnRemark
            // 
            this.grdclmnRemark.Caption = "备注";
            this.grdclmnRemark.FieldName = "Remark";
            this.grdclmnRemark.Name = "grdclmnRemark";
            this.grdclmnRemark.Visible = true;
            this.grdclmnRemark.VisibleIndex = 6;
            // 
            // grdclmnErrText
            // 
            this.grdclmnErrText.Caption = "校验结果";
            this.grdclmnErrText.FieldName = "ErrText";
            this.grdclmnErrText.Name = "grdclmnErrText";
            this.grdclmnErrText.Visible = true;
            this.grdclmnErrText.VisibleIndex = 7;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "物料需求文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件(*.*)|*.*";
            this.openFileDialog.Title = "请选择物料需求数据文件";
            // 
            // frmMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(959, 643);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "物料需求导入";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvDatas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraBars.BarButtonItem bbiReadFromExcel;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.BarButtonItem bbiDataValidate;
        private DevExpress.XtraBars.BarButtonItem bbiDataUpload;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvDatas;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMaterialCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReqQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSrcLoc;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnDstLoc;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRoutingCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRemark;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnErrCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnErrText;
        private DevExpress.XtraBars.BarStaticItem bsiUserInfo;
        private DevExpress.XtraBars.BarStaticItem bsiDBAddress;
        private DevExpress.XtraBars.BarStaticItem bsiVersion;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraBars.BarButtonItem bbiAbout;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}