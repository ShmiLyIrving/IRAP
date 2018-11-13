namespace IRAP.Client.GUI.BatchSystem
{
    partial class frmPrdtBatchNumberTrack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrdtBatchNumberTrack));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lblEquipment = new DevExpress.XtraEditors.LabelControl();
            this.edtPrdtDate = new DevExpress.XtraEditors.DateEdit();
            this.icboEquipmentStyle = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.icboEquipment = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ilstBatchNo = new DevExpress.XtraEditors.ImageListBoxControl();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdPWOs = new DevExpress.XtraGrid.GridControl();
            this.grdvPWOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vgrdMethodParams = new DevExpress.XtraVerticalGrid.VGridControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPrdtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPrdtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icboEquipmentStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icboEquipment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ilstBatchNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdMethodParams)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "frmCustomBase";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblEquipment);
            this.splitContainerControl1.Panel1.Controls.Add(this.edtPrdtDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.icboEquipmentStyle);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.icboEquipment);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "查询条件";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(891, 439);
            this.splitContainerControl1.SplitterPosition = 75;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(775, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 29);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblEquipment
            // 
            this.lblEquipment.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipment.Location = new System.Drawing.Point(10, 12);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(48, 21);
            this.lblEquipment.TabIndex = 2;
            this.lblEquipment.Text = "设备：";
            // 
            // edtPrdtDate
            // 
            this.edtPrdtDate.EditValue = null;
            this.edtPrdtDate.Location = new System.Drawing.Point(556, 9);
            this.edtPrdtDate.Name = "edtPrdtDate";
            this.edtPrdtDate.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtPrdtDate.Properties.Appearance.Options.UseFont = true;
            this.edtPrdtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtPrdtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtPrdtDate.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.edtPrdtDate.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtPrdtDate.Properties.CalendarTimeProperties.EditFormat.FormatString = "yyyy-MM-dd";
            this.edtPrdtDate.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtPrdtDate.Properties.CalendarTimeProperties.Mask.EditMask = "yyyy-MM-dd";
            this.edtPrdtDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.edtPrdtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtPrdtDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.edtPrdtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtPrdtDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.edtPrdtDate.Size = new System.Drawing.Size(177, 28);
            this.edtPrdtDate.TabIndex = 4;
            // 
            // icboEquipmentStyle
            // 
            this.icboEquipmentStyle.EditValue = -373355;
            this.icboEquipmentStyle.Location = new System.Drawing.Point(64, 9);
            this.icboEquipmentStyle.Name = "icboEquipmentStyle";
            this.icboEquipmentStyle.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icboEquipmentStyle.Properties.Appearance.Options.UseFont = true;
            this.icboEquipmentStyle.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.icboEquipmentStyle.Properties.AppearanceDropDown.Options.UseFont = true;
            this.icboEquipmentStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icboEquipmentStyle.Properties.DropDownItemHeight = 35;
            this.icboEquipmentStyle.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("加热炉", -373355, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("清洗炉", -373356, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("回火炉", -373357, -1)});
            this.icboEquipmentStyle.Size = new System.Drawing.Size(150, 28);
            this.icboEquipmentStyle.TabIndex = 0;
            this.icboEquipmentStyle.SelectedIndexChanged += new System.EventHandler(this.icboEquipmentStyle_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(470, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 21);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "生产日期：";
            // 
            // icboEquipment
            // 
            this.icboEquipment.Location = new System.Drawing.Point(220, 9);
            this.icboEquipment.Name = "icboEquipment";
            this.icboEquipment.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icboEquipment.Properties.Appearance.Options.UseFont = true;
            this.icboEquipment.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.icboEquipment.Properties.AppearanceDropDown.Options.UseFont = true;
            this.icboEquipment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icboEquipment.Properties.DropDownItemHeight = 35;
            this.icboEquipment.Size = new System.Drawing.Size(232, 28);
            this.icboEquipment.TabIndex = 1;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl2.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel1.Controls.Add(this.ilstBatchNo);
            this.splitContainerControl2.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl2.Panel1.ShowCaption = true;
            this.splitContainerControl2.Panel1.Text = "炉次号";
            this.splitContainerControl2.Panel2.Controls.Add(this.splitContainerControl3);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(891, 359);
            this.splitContainerControl2.SplitterPosition = 244;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // ilstBatchNo
            // 
            this.ilstBatchNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ilstBatchNo.Appearance.Options.UseFont = true;
            this.ilstBatchNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilstBatchNo.ItemHeight = 30;
            this.ilstBatchNo.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("CE18103101", "CE18103101"),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("CE18103102", "CE18103102"),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("CE18103103", "CE18103103"),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("CE18103104", "CE18103104"),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("CE18103105", "CE18103105"),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("CE18103106", "CE18103106")});
            this.ilstBatchNo.Location = new System.Drawing.Point(10, 10);
            this.ilstBatchNo.Name = "ilstBatchNo";
            this.ilstBatchNo.Size = new System.Drawing.Size(220, 309);
            this.ilstBatchNo.TabIndex = 0;
            this.ilstBatchNo.SelectedIndexChanged += new System.EventHandler(this.ilstBatchNo_SelectedIndexChanged);
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl3.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl3.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl3.Panel1.Controls.Add(this.grdPWOs);
            this.splitContainerControl3.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl3.Panel1.ShowCaption = true;
            this.splitContainerControl3.Panel1.Text = "生产工单";
            this.splitContainerControl3.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.splitContainerControl3.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl3.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl3.Panel2.Controls.Add(this.vgrdMethodParams);
            this.splitContainerControl3.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl3.Panel2.ShowCaption = true;
            this.splitContainerControl3.Panel2.Text = "生产过程参数";
            this.splitContainerControl3.Size = new System.Drawing.Size(642, 359);
            this.splitContainerControl3.SplitterPosition = 195;
            this.splitContainerControl3.TabIndex = 0;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // grdPWOs
            // 
            this.grdPWOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPWOs.Location = new System.Drawing.Point(10, 10);
            this.grdPWOs.MainView = this.grdvPWOs;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.Size = new System.Drawing.Size(618, 145);
            this.grdPWOs.TabIndex = 1;
            this.grdPWOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPWOs});
            // 
            // grdvPWOs
            // 
            this.grdvPWOs.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvPWOs.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvPWOs.Appearance.Row.Options.UseFont = true;
            this.grdvPWOs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnPWONo,
            this.gridColumn2,
            this.grdclmnProductName,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.grdvPWOs.GridControl = this.grdPWOs;
            this.grdvPWOs.Name = "grdvPWOs";
            this.grdvPWOs.OptionsBehavior.Editable = false;
            this.grdvPWOs.OptionsView.ColumnAutoWidth = false;
            this.grdvPWOs.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.Caption = "工单号";
            this.grdclmnPWONo.FieldName = "PWONo";
            this.grdclmnPWONo.Name = "grdclmnPWONo";
            this.grdclmnPWONo.Visible = true;
            this.grdclmnPWONo.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "产品物料号";
            this.gridColumn2.FieldName = "T102Code";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // grdclmnProductName
            // 
            this.grdclmnProductName.Caption = "产品物料名称";
            this.grdclmnProductName.FieldName = "T102Name";
            this.grdclmnProductName.Name = "grdclmnProductName";
            this.grdclmnProductName.Visible = true;
            this.grdclmnProductName.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "批次号";
            this.gridColumn3.FieldName = "LotNumber";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "材质";
            this.gridColumn4.FieldName = "Texture";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn5.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.Caption = "生产数量";
            this.gridColumn5.FieldName = "Qty";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // vgrdMethodParams
            // 
            this.vgrdMethodParams.Appearance.FocusedRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.vgrdMethodParams.Appearance.FocusedRecord.ForeColor = System.Drawing.Color.Blue;
            this.vgrdMethodParams.Appearance.FocusedRecord.Options.UseBackColor = true;
            this.vgrdMethodParams.Appearance.FocusedRecord.Options.UseForeColor = true;
            this.vgrdMethodParams.Appearance.PressedRow.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.vgrdMethodParams.Appearance.PressedRow.Options.UseFont = true;
            this.vgrdMethodParams.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.vgrdMethodParams.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vgrdMethodParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgrdMethodParams.Location = new System.Drawing.Point(10, 10);
            this.vgrdMethodParams.Name = "vgrdMethodParams";
            this.vgrdMethodParams.OptionsBehavior.Editable = false;
            this.vgrdMethodParams.RowHeaderWidth = 113;
            this.vgrdMethodParams.Size = new System.Drawing.Size(618, 109);
            this.vgrdMethodParams.TabIndex = 8;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "机械设备.png");
            // 
            // frmPrdtBatchNumberTrack
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmPrdtBatchNumberTrack";
            this.Shown += new System.EventHandler(this.frmPrdtBatchNumberTrack_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPrdtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPrdtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icboEquipmentStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icboEquipment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ilstBatchNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdMethodParams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.ImageListBoxControl ilstBatchNo;
        private DevExpress.XtraEditors.ImageComboBoxEdit icboEquipmentStyle;
        private System.Windows.Forms.ImageList imageList;
        private DevExpress.XtraEditors.ImageComboBoxEdit icboEquipment;
        private DevExpress.XtraEditors.LabelControl lblEquipment;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.DateEdit edtPrdtDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraVerticalGrid.VGridControl vgrdMethodParams;
    }
}
