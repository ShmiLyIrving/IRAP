namespace IRAP.Client.GUI.SCES
{
    partial class frmFactTrack_RMDelivery_30
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnPrevPeriod = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.btnNextPeriod = new DevExpress.XtraEditors.SimpleButton();
            this.cboStoreSite = new DevExpress.XtraEditors.ComboBoxEdit();
            this.edtBeginDT = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtEndDT = new System.Windows.Forms.DateTimePicker();
            this.cboPeriodType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblWorkCenter = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.edtWorkCenter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.grdResults = new DevExpress.XtraGrid.GridControl();
            this.grdvResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScheduledStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMaterialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyToDeliver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRequestedArrivalTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMaterialDeliverTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnDeliverTimeSpan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyDelivered = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnDeliverer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnOTDStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnExportTo = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboStoreSite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWorkCenter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(865, 56);
            this.lblFuncName.Text = "历史配送记录查询";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(865, 56);
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.btnPrevPeriod);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnGetData);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnNextPeriod);
            this.splitContainerControl1.Panel1.Controls.Add(this.cboStoreSite);
            this.splitContainerControl1.Panel1.Controls.Add(this.edtBeginDT);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.edtEndDT);
            this.splitContainerControl1.Panel1.Controls.Add(this.cboPeriodType);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblWorkCenter);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.edtWorkCenter);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "查询条件";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.grdResults);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "查询结果";
            this.splitContainerControl1.Size = new System.Drawing.Size(865, 406);
            this.splitContainerControl1.SplitterPosition = 97;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnPrevPeriod
            // 
            this.btnPrevPeriod.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevPeriod.Appearance.Options.UseFont = true;
            this.btnPrevPeriod.Location = new System.Drawing.Point(302, 38);
            this.btnPrevPeriod.Name = "btnPrevPeriod";
            this.btnPrevPeriod.Size = new System.Drawing.Size(19, 26);
            this.btnPrevPeriod.TabIndex = 15;
            this.btnPrevPeriod.TabStop = false;
            this.btnPrevPeriod.Text = "<";
            this.btnPrevPeriod.Click += new System.EventHandler(this.btnPrevPeriod_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Appearance.Options.UseFont = true;
            this.btnGetData.Location = new System.Drawing.Point(753, 6);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(98, 31);
            this.btnGetData.TabIndex = 23;
            this.btnGetData.TabStop = false;
            this.btnGetData.Text = "查询(&S)";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnNextPeriod
            // 
            this.btnNextPeriod.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPeriod.Appearance.Options.UseFont = true;
            this.btnNextPeriod.Location = new System.Drawing.Point(705, 38);
            this.btnNextPeriod.Name = "btnNextPeriod";
            this.btnNextPeriod.Size = new System.Drawing.Size(19, 26);
            this.btnNextPeriod.TabIndex = 19;
            this.btnNextPeriod.TabStop = false;
            this.btnNextPeriod.Text = ">";
            this.btnNextPeriod.Click += new System.EventHandler(this.btnNextPeriod_Click);
            // 
            // cboStoreSite
            // 
            this.cboStoreSite.Location = new System.Drawing.Point(89, 6);
            this.cboStoreSite.Name = "cboStoreSite";
            this.cboStoreSite.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStoreSite.Properties.Appearance.Options.UseFont = true;
            this.cboStoreSite.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStoreSite.Size = new System.Drawing.Size(653, 26);
            this.cboStoreSite.TabIndex = 21;
            // 
            // edtBeginDT
            // 
            this.edtBeginDT.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.edtBeginDT.Enabled = false;
            this.edtBeginDT.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtBeginDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtBeginDT.Location = new System.Drawing.Point(327, 38);
            this.edtBeginDT.Name = "edtBeginDT";
            this.edtBeginDT.Size = new System.Drawing.Size(172, 26);
            this.edtBeginDT.TabIndex = 16;
            this.edtBeginDT.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(13, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 20);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "仓储地点：";
            // 
            // edtEndDT
            // 
            this.edtEndDT.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtEndDT.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.edtEndDT.Enabled = false;
            this.edtEndDT.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtEndDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtEndDT.Location = new System.Drawing.Point(527, 38);
            this.edtEndDT.Name = "edtEndDT";
            this.edtEndDT.Size = new System.Drawing.Size(172, 26);
            this.edtEndDT.TabIndex = 18;
            this.edtEndDT.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // cboPeriodType
            // 
            this.cboPeriodType.Location = new System.Drawing.Point(89, 38);
            this.cboPeriodType.Name = "cboPeriodType";
            this.cboPeriodType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodType.Properties.Appearance.Options.UseFont = true;
            this.cboPeriodType.Properties.AppearanceDisabled.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboPeriodType.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboPeriodType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboPeriodType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboPeriodType.Properties.AppearanceFocused.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboPeriodType.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboPeriodType.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboPeriodType.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboPeriodType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPeriodType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPeriodType.Size = new System.Drawing.Size(131, 26);
            this.cboPeriodType.TabIndex = 13;
            this.cboPeriodType.SelectedIndexChanged += new System.EventHandler(this.cboPeriodType_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(226, 41);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 20);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "时间范围：";
            // 
            // lblWorkCenter
            // 
            this.lblWorkCenter.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkCenter.Location = new System.Drawing.Point(13, 73);
            this.lblWorkCenter.Name = "lblWorkCenter";
            this.lblWorkCenter.Size = new System.Drawing.Size(70, 20);
            this.lblWorkCenter.TabIndex = 20;
            this.lblWorkCenter.Text = "工作中心：";
            this.lblWorkCenter.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(505, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(16, 20);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "—";
            // 
            // edtWorkCenter
            // 
            this.edtWorkCenter.Location = new System.Drawing.Point(89, 70);
            this.edtWorkCenter.Name = "edtWorkCenter";
            this.edtWorkCenter.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtWorkCenter.Properties.Appearance.Options.UseFont = true;
            this.edtWorkCenter.Size = new System.Drawing.Size(247, 26);
            this.edtWorkCenter.TabIndex = 3;
            this.edtWorkCenter.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(13, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 20);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "时间粒度：";
            // 
            // grdResults
            // 
            this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResults.Location = new System.Drawing.Point(5, 5);
            this.grdResults.MainView = this.grdvResults;
            this.grdResults.Name = "grdResults";
            this.grdResults.Size = new System.Drawing.Size(728, 265);
            this.grdResults.TabIndex = 0;
            this.grdResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvResults});
            // 
            // grdvResults
            // 
            this.grdvResults.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvResults.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvResults.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvResults.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvResults.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvResults.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvResults.Appearance.Preview.ForeColor = System.Drawing.Color.Blue;
            this.grdvResults.Appearance.Preview.Options.UseForeColor = true;
            this.grdvResults.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvResults.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            this.grdvResults.Appearance.Row.Options.UseFont = true;
            this.grdvResults.Appearance.Row.Options.UseForeColor = true;
            this.grdvResults.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnMONumber,
            this.grdclmnMOLineNo,
            this.grdclmnPWONo,
            this.grdclmnProductNo,
            this.grdclmnProductdName,
            this.grdclmnOrderQty,
            this.grdclmnScheduledStartTime,
            this.grdclmnMaterialCode,
            this.grdclmnMaterialName,
            this.grdclmnQtyToDeliver,
            this.grdclmnRequestedArrivalTime,
            this.grdclmnMaterialDeliverTime,
            this.grdclmnDeliverTimeSpan,
            this.grdclmnQtyDelivered,
            this.grdclmnDeliverer,
            this.grdclmnOTDStatus});
            this.grdvResults.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.grdvResults.GridControl = this.grdResults;
            this.grdvResults.Name = "grdvResults";
            this.grdvResults.OptionsBehavior.Editable = false;
            this.grdvResults.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvResults.OptionsView.ColumnAutoWidth = false;
            this.grdvResults.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvResults.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvResults.OptionsView.EnableAppearanceOddRow = true;
            this.grdvResults.OptionsView.RowAutoHeight = true;
            this.grdvResults.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnMONumber
            // 
            this.grdclmnMONumber.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnMONumber.AppearanceCell.Options.UseFont = true;
            this.grdclmnMONumber.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMONumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnMONumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONumber.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMONumber.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnMONumber.AppearanceHeader.Options.UseFont = true;
            this.grdclmnMONumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMONumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMONumber.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONumber.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMONumber.Caption = "制造订单";
            this.grdclmnMONumber.FieldName = "MONumber";
            this.grdclmnMONumber.Name = "grdclmnMONumber";
            this.grdclmnMONumber.OptionsColumn.ReadOnly = true;
            this.grdclmnMONumber.Visible = true;
            this.grdclmnMONumber.VisibleIndex = 0;
            this.grdclmnMONumber.Width = 120;
            // 
            // grdclmnMOLineNo
            // 
            this.grdclmnMOLineNo.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnMOLineNo.AppearanceCell.Options.UseFont = true;
            this.grdclmnMOLineNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMOLineNo.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnMOLineNo.AppearanceHeader.Options.UseFont = true;
            this.grdclmnMOLineNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMOLineNo.Caption = "行号";
            this.grdclmnMOLineNo.FieldName = "MOLineNo";
            this.grdclmnMOLineNo.Name = "grdclmnMOLineNo";
            this.grdclmnMOLineNo.OptionsColumn.ReadOnly = true;
            this.grdclmnMOLineNo.Visible = true;
            this.grdclmnMOLineNo.VisibleIndex = 1;
            this.grdclmnMOLineNo.Width = 120;
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnPWONo.AppearanceCell.Options.UseFont = true;
            this.grdclmnPWONo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnPWONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWONo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPWONo.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnPWONo.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPWONo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPWONo.Caption = "生产工单号";
            this.grdclmnPWONo.FieldName = "PWONo";
            this.grdclmnPWONo.Name = "grdclmnPWONo";
            this.grdclmnPWONo.OptionsColumn.ReadOnly = true;
            this.grdclmnPWONo.Visible = true;
            this.grdclmnPWONo.VisibleIndex = 2;
            // 
            // grdclmnProductNo
            // 
            this.grdclmnProductNo.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnProductNo.AppearanceCell.Options.UseFont = true;
            this.grdclmnProductNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnProductNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductNo.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnProductNo.AppearanceHeader.Options.UseFont = true;
            this.grdclmnProductNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductNo.Caption = "产品编号";
            this.grdclmnProductNo.FieldName = "ProductNo";
            this.grdclmnProductNo.Name = "grdclmnProductNo";
            this.grdclmnProductNo.OptionsColumn.ReadOnly = true;
            this.grdclmnProductNo.Visible = true;
            this.grdclmnProductNo.VisibleIndex = 3;
            // 
            // grdclmnProductdName
            // 
            this.grdclmnProductdName.Caption = "产品名称";
            this.grdclmnProductdName.FieldName = "ProductDesc";
            this.grdclmnProductdName.Name = "grdclmnProductdName";
            this.grdclmnProductdName.Visible = true;
            this.grdclmnProductdName.VisibleIndex = 4;
            // 
            // grdclmnOrderQty
            // 
            this.grdclmnOrderQty.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnOrderQty.AppearanceCell.Options.UseFont = true;
            this.grdclmnOrderQty.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrderQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnOrderQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrderQty.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnOrderQty.AppearanceHeader.Options.UseFont = true;
            this.grdclmnOrderQty.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnOrderQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrderQty.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrderQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnOrderQty.Caption = "工单数量";
            this.grdclmnOrderQty.FieldName = "OrderQty";
            this.grdclmnOrderQty.Name = "grdclmnOrderQty";
            this.grdclmnOrderQty.OptionsColumn.ReadOnly = true;
            this.grdclmnOrderQty.Visible = true;
            this.grdclmnOrderQty.VisibleIndex = 5;
            // 
            // grdclmnScheduledStartTime
            // 
            this.grdclmnScheduledStartTime.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnScheduledStartTime.AppearanceCell.Options.UseFont = true;
            this.grdclmnScheduledStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnScheduledStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScheduledStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScheduledStartTime.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnScheduledStartTime.AppearanceHeader.Options.UseFont = true;
            this.grdclmnScheduledStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnScheduledStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScheduledStartTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScheduledStartTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnScheduledStartTime.Caption = "排定生产时间";
            this.grdclmnScheduledStartTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.grdclmnScheduledStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnScheduledStartTime.FieldName = "ScheduledStartTime";
            this.grdclmnScheduledStartTime.Name = "grdclmnScheduledStartTime";
            this.grdclmnScheduledStartTime.OptionsColumn.ReadOnly = true;
            this.grdclmnScheduledStartTime.Visible = true;
            this.grdclmnScheduledStartTime.VisibleIndex = 6;
            // 
            // grdclmnMaterialCode
            // 
            this.grdclmnMaterialCode.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnMaterialCode.AppearanceCell.Options.UseFont = true;
            this.grdclmnMaterialCode.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMaterialCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnMaterialCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMaterialCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMaterialCode.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnMaterialCode.AppearanceHeader.Options.UseFont = true;
            this.grdclmnMaterialCode.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMaterialCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMaterialCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMaterialCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMaterialCode.Caption = "要求配送物料号";
            this.grdclmnMaterialCode.FieldName = "MaterialCode";
            this.grdclmnMaterialCode.Name = "grdclmnMaterialCode";
            this.grdclmnMaterialCode.Visible = true;
            this.grdclmnMaterialCode.VisibleIndex = 7;
            // 
            // grdclmnMaterialName
            // 
            this.grdclmnMaterialName.Caption = "物料名称";
            this.grdclmnMaterialName.FieldName = "MaterialDesc";
            this.grdclmnMaterialName.Name = "grdclmnMaterialName";
            this.grdclmnMaterialName.Visible = true;
            this.grdclmnMaterialName.VisibleIndex = 8;
            // 
            // grdclmnQtyToDeliver
            // 
            this.grdclmnQtyToDeliver.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnQtyToDeliver.AppearanceCell.Options.UseFont = true;
            this.grdclmnQtyToDeliver.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQtyToDeliver.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnQtyToDeliver.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyToDeliver.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnQtyToDeliver.AppearanceHeader.Options.UseFont = true;
            this.grdclmnQtyToDeliver.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnQtyToDeliver.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnQtyToDeliver.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyToDeliver.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnQtyToDeliver.Caption = "要求配送数量";
            this.grdclmnQtyToDeliver.FieldName = "QtyToDeliver";
            this.grdclmnQtyToDeliver.Name = "grdclmnQtyToDeliver";
            this.grdclmnQtyToDeliver.Visible = true;
            this.grdclmnQtyToDeliver.VisibleIndex = 9;
            // 
            // grdclmnRequestedArrivalTime
            // 
            this.grdclmnRequestedArrivalTime.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnRequestedArrivalTime.AppearanceCell.Options.UseFont = true;
            this.grdclmnRequestedArrivalTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnRequestedArrivalTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRequestedArrivalTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRequestedArrivalTime.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnRequestedArrivalTime.AppearanceHeader.Options.UseFont = true;
            this.grdclmnRequestedArrivalTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnRequestedArrivalTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRequestedArrivalTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRequestedArrivalTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnRequestedArrivalTime.Caption = "要求送达时间";
            this.grdclmnRequestedArrivalTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.grdclmnRequestedArrivalTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnRequestedArrivalTime.FieldName = "RequestedArrivalTime";
            this.grdclmnRequestedArrivalTime.Name = "grdclmnRequestedArrivalTime";
            this.grdclmnRequestedArrivalTime.Visible = true;
            this.grdclmnRequestedArrivalTime.VisibleIndex = 10;
            // 
            // grdclmnMaterialDeliverTime
            // 
            this.grdclmnMaterialDeliverTime.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnMaterialDeliverTime.AppearanceCell.Options.UseFont = true;
            this.grdclmnMaterialDeliverTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMaterialDeliverTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMaterialDeliverTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMaterialDeliverTime.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnMaterialDeliverTime.AppearanceHeader.Options.UseFont = true;
            this.grdclmnMaterialDeliverTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMaterialDeliverTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMaterialDeliverTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMaterialDeliverTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMaterialDeliverTime.Caption = "实际配送时间";
            this.grdclmnMaterialDeliverTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.grdclmnMaterialDeliverTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnMaterialDeliverTime.FieldName = "MaterialDeliverTime";
            this.grdclmnMaterialDeliverTime.Name = "grdclmnMaterialDeliverTime";
            this.grdclmnMaterialDeliverTime.Visible = true;
            this.grdclmnMaterialDeliverTime.VisibleIndex = 11;
            // 
            // grdclmnDeliverTimeSpan
            // 
            this.grdclmnDeliverTimeSpan.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnDeliverTimeSpan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnDeliverTimeSpan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnDeliverTimeSpan.Caption = "时间差";
            this.grdclmnDeliverTimeSpan.FieldName = "DeliverTimeSpan";
            this.grdclmnDeliverTimeSpan.Name = "grdclmnDeliverTimeSpan";
            this.grdclmnDeliverTimeSpan.Visible = true;
            this.grdclmnDeliverTimeSpan.VisibleIndex = 12;
            // 
            // grdclmnQtyDelivered
            // 
            this.grdclmnQtyDelivered.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnQtyDelivered.AppearanceCell.Options.UseFont = true;
            this.grdclmnQtyDelivered.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQtyDelivered.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnQtyDelivered.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyDelivered.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnQtyDelivered.AppearanceHeader.Options.UseFont = true;
            this.grdclmnQtyDelivered.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnQtyDelivered.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnQtyDelivered.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyDelivered.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnQtyDelivered.Caption = "实际配送数量";
            this.grdclmnQtyDelivered.FieldName = "QtyDelivered";
            this.grdclmnQtyDelivered.Name = "grdclmnQtyDelivered";
            this.grdclmnQtyDelivered.Visible = true;
            this.grdclmnQtyDelivered.VisibleIndex = 13;
            // 
            // grdclmnDeliverer
            // 
            this.grdclmnDeliverer.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnDeliverer.AppearanceCell.Options.UseFont = true;
            this.grdclmnDeliverer.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnDeliverer.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnDeliverer.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnDeliverer.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnDeliverer.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnDeliverer.AppearanceHeader.Options.UseFont = true;
            this.grdclmnDeliverer.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnDeliverer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnDeliverer.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnDeliverer.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnDeliverer.Caption = "配送人";
            this.grdclmnDeliverer.FieldName = "Deliverer";
            this.grdclmnDeliverer.Name = "grdclmnDeliverer";
            this.grdclmnDeliverer.Visible = true;
            this.grdclmnDeliverer.VisibleIndex = 14;
            // 
            // grdclmnOTDStatus
            // 
            this.grdclmnOTDStatus.AppearanceCell.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnOTDStatus.AppearanceCell.Options.UseFont = true;
            this.grdclmnOTDStatus.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOTDStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOTDStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOTDStatus.AppearanceHeader.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdclmnOTDStatus.AppearanceHeader.Options.UseFont = true;
            this.grdclmnOTDStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnOTDStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOTDStatus.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOTDStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnOTDStatus.Caption = "准时配送状态";
            this.grdclmnOTDStatus.FieldName = "OTDStatusString";
            this.grdclmnOTDStatus.Name = "grdclmnOTDStatus";
            this.grdclmnOTDStatus.Visible = true;
            this.grdclmnOTDStatus.VisibleIndex = 15;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnExportTo);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(733, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.panelControl2.Size = new System.Drawing.Size(123, 265);
            this.panelControl2.TabIndex = 1;
            // 
            // btnExportTo
            // 
            this.btnExportTo.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportTo.Appearance.Options.UseFont = true;
            this.btnExportTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExportTo.Location = new System.Drawing.Point(10, 5);
            this.btnExportTo.Name = "btnExportTo";
            this.btnExportTo.Size = new System.Drawing.Size(103, 31);
            this.btnExportTo.TabIndex = 24;
            this.btnExportTo.TabStop = false;
            this.btnExportTo.Text = "导出(&E)...";
            this.btnExportTo.Click += new System.EventHandler(this.btnExportTo_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xlsx";
            this.saveFileDialog.Filter = "Excel 文件(*.xlsx)|*.xlsx";
            this.saveFileDialog.Title = "导出到......";
            // 
            // frmFactTrack_RMDelivery_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(865, 462);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmFactTrack_RMDelivery_30";
            this.Text = "历史配送记录查询";
            this.Shown += new System.EventHandler(this.frmFactTrack_RMDelivery_30_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboStoreSite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWorkCenter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnPrevPeriod;
        private DevExpress.XtraEditors.SimpleButton btnNextPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboPeriodType;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.DateTimePicker edtBeginDT;
        private System.Windows.Forms.DateTimePicker edtEndDT;
        private DevExpress.XtraEditors.ComboBoxEdit cboStoreSite;
        private DevExpress.XtraEditors.LabelControl lblWorkCenter;
        private DevExpress.XtraEditors.TextEdit edtWorkCenter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraGrid.GridControl grdResults;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvResults;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScheduledStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMaterialCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyToDeliver;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRequestedArrivalTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMaterialDeliverTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyDelivered;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOTDStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnDeliverer;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnDeliverTimeSpan;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductdName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMaterialName;
        private DevExpress.XtraEditors.SimpleButton btnExportTo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}
