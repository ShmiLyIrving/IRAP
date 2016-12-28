namespace IRAP.Client.GUI.MESPDC
{
    partial class frmProcessFIFO
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
            this.vgrdCurrentPWO = new DevExpress.XtraVerticalGrid.VGridControl();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.rowPWONo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPWOQuantity = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPWOStartTime = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPlannedCloseTime = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowT133Name = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowNotGoodQuantity = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowGoodRate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.cboDevices = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grdPWOofWait = new DevExpress.XtraGrid.GridControl();
            this.grdvPWOofWait = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWOQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT106Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWOStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProcessWaitTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdCurrentPWO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDevices.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOofWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOofWait)).BeginInit();
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
            this.lblFuncName.Text = "工序先进先出";
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
            this.splitContainerControl1.Location = new System.Drawing.Point(12, 12);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseTextOptions = true;
            this.splitContainerControl1.Panel1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.splitContainerControl1.Panel1.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.vgrdCurrentPWO);
            this.splitContainerControl1.Panel1.Controls.Add(this.cboDevices);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "当前正在生产的工单";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseTextOptions = true;
            this.splitContainerControl1.Panel2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.splitContainerControl1.Panel2.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.grdPWOofWait);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "待生产的工单";
            this.splitContainerControl1.Size = new System.Drawing.Size(750, 415);
            this.splitContainerControl1.SplitterPosition = 449;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // vgrdCurrentPWO
            // 
            this.vgrdCurrentPWO.Appearance.RecordValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vgrdCurrentPWO.Appearance.RecordValue.Options.UseFont = true;
            this.vgrdCurrentPWO.Appearance.RecordValue.Options.UseTextOptions = true;
            this.vgrdCurrentPWO.Appearance.RecordValue.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.vgrdCurrentPWO.Appearance.RecordValue.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdCurrentPWO.Appearance.RecordValue.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.vgrdCurrentPWO.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vgrdCurrentPWO.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vgrdCurrentPWO.Appearance.RowHeaderPanel.Options.UseTextOptions = true;
            this.vgrdCurrentPWO.Appearance.RowHeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdCurrentPWO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgrdCurrentPWO.Location = new System.Drawing.Point(10, 36);
            this.vgrdCurrentPWO.Name = "vgrdCurrentPWO";
            this.vgrdCurrentPWO.OptionsBehavior.Editable = false;
            this.vgrdCurrentPWO.OptionsView.MinRowAutoHeight = 30;
            this.vgrdCurrentPWO.RecordWidth = 209;
            this.vgrdCurrentPWO.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.vgrdCurrentPWO.RowHeaderWidth = 132;
            this.vgrdCurrentPWO.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowPWONo,
            this.rowPWOQuantity,
            this.rowPWOStartTime,
            this.rowPlannedCloseTime,
            this.rowT133Name,
            this.rowNotGoodQuantity,
            this.rowGoodRate});
            this.vgrdCurrentPWO.Size = new System.Drawing.Size(425, 340);
            this.vgrdCurrentPWO.TabIndex = 2;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // rowPWONo
            // 
            this.rowPWONo.Name = "rowPWONo";
            this.rowPWONo.Properties.Caption = "工单号";
            this.rowPWONo.Properties.FieldName = "PWONo";
            this.rowPWONo.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // rowPWOQuantity
            // 
            this.rowPWOQuantity.Name = "rowPWOQuantity";
            this.rowPWOQuantity.Properties.Caption = "数量";
            this.rowPWOQuantity.Properties.FieldName = "PWOQuantity";
            this.rowPWOQuantity.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // rowPWOStartTime
            // 
            this.rowPWOStartTime.Name = "rowPWOStartTime";
            this.rowPWOStartTime.Properties.Caption = "投入时间";
            this.rowPWOStartTime.Properties.FieldName = "PWOStartTime";
            this.rowPWOStartTime.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // rowPlannedCloseTime
            // 
            this.rowPlannedCloseTime.Name = "rowPlannedCloseTime";
            this.rowPlannedCloseTime.Properties.Caption = "计划入库时间";
            this.rowPlannedCloseTime.Properties.FieldName = "PlannedCloseTime";
            this.rowPlannedCloseTime.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // rowT133Name
            // 
            this.rowT133Name.Name = "rowT133Name";
            this.rowT133Name.Properties.Caption = "当前生产设备";
            this.rowT133Name.Properties.FieldName = "T133Name";
            this.rowT133Name.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // rowNotGoodQuantity
            // 
            this.rowNotGoodQuantity.Name = "rowNotGoodQuantity";
            this.rowNotGoodQuantity.Properties.Caption = "不合格品";
            this.rowNotGoodQuantity.Properties.FieldName = "NotGoodQuantity";
            this.rowNotGoodQuantity.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // rowGoodRate
            // 
            this.rowGoodRate.Name = "rowGoodRate";
            this.rowGoodRate.Properties.Caption = "合格率";
            this.rowGoodRate.Properties.FieldName = "GoodRate";
            this.rowGoodRate.Properties.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rowGoodRate.Properties.RowEdit = this.repositoryItemMemoEdit1;
            // 
            // cboDevices
            // 
            this.cboDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboDevices.Location = new System.Drawing.Point(10, 10);
            this.cboDevices.Name = "cboDevices";
            this.cboDevices.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboDevices.Properties.Appearance.Options.UseFont = true;
            this.cboDevices.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDevices.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDevices.Size = new System.Drawing.Size(425, 26);
            this.cboDevices.TabIndex = 1;
            this.cboDevices.SelectedIndexChanged += new System.EventHandler(this.cboDevices_SelectedIndexChanged);
            // 
            // grdPWOofWait
            // 
            this.grdPWOofWait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPWOofWait.Location = new System.Drawing.Point(10, 10);
            this.grdPWOofWait.MainView = this.grdvPWOofWait;
            this.grdPWOofWait.Name = "grdPWOofWait";
            this.grdPWOofWait.Size = new System.Drawing.Size(272, 366);
            this.grdPWOofWait.TabIndex = 0;
            this.grdPWOofWait.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPWOofWait});
            // 
            // grdvPWOofWait
            // 
            this.grdvPWOofWait.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvPWOofWait.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvPWOofWait.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvPWOofWait.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvPWOofWait.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvPWOofWait.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvPWOofWait.Appearance.Row.Options.UseFont = true;
            this.grdvPWOofWait.Appearance.Row.Options.UseTextOptions = true;
            this.grdvPWOofWait.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvPWOofWait.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnPWO,
            this.grdclmnPWOQuantity,
            this.grdclmnT106Code,
            this.grdclmnPWOStartTime,
            this.grdclmnProcessWaitTime});
            this.grdvPWOofWait.GridControl = this.grdPWOofWait;
            this.grdvPWOofWait.Name = "grdvPWOofWait";
            this.grdvPWOofWait.OptionsView.ColumnAutoWidth = false;
            this.grdvPWOofWait.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvPWOofWait.OptionsView.EnableAppearanceOddRow = true;
            this.grdvPWOofWait.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.Caption = "优先顺序";
            this.grdclmnOrdinal.FieldName = "Ordinal";
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
            // 
            // grdclmnPWO
            // 
            this.grdclmnPWO.Caption = "工单号";
            this.grdclmnPWO.FieldName = "PWONo";
            this.grdclmnPWO.Name = "grdclmnPWO";
            this.grdclmnPWO.Visible = true;
            this.grdclmnPWO.VisibleIndex = 1;
            // 
            // grdclmnPWOQuantity
            // 
            this.grdclmnPWOQuantity.Caption = "工单数量";
            this.grdclmnPWOQuantity.FieldName = "PWOQuantity";
            this.grdclmnPWOQuantity.Name = "grdclmnPWOQuantity";
            this.grdclmnPWOQuantity.Visible = true;
            this.grdclmnPWOQuantity.VisibleIndex = 2;
            // 
            // grdclmnT106Code
            // 
            this.grdclmnT106Code.Caption = "库位";
            this.grdclmnT106Code.FieldName = "T106Code";
            this.grdclmnT106Code.Name = "grdclmnT106Code";
            this.grdclmnT106Code.Visible = true;
            this.grdclmnT106Code.VisibleIndex = 3;
            // 
            // grdclmnPWOStartTime
            // 
            this.grdclmnPWOStartTime.Caption = "投入时间";
            this.grdclmnPWOStartTime.FieldName = "PWOStartTime";
            this.grdclmnPWOStartTime.Name = "grdclmnPWOStartTime";
            this.grdclmnPWOStartTime.Visible = true;
            this.grdclmnPWOStartTime.VisibleIndex = 4;
            // 
            // grdclmnProcessWaitTime
            // 
            this.grdclmnProcessWaitTime.Caption = "停留时间";
            this.grdclmnProcessWaitTime.FieldName = "ProcessWaitTime";
            this.grdclmnProcessWaitTime.Name = "grdclmnProcessWaitTime";
            this.grdclmnProcessWaitTime.Visible = true;
            this.grdclmnProcessWaitTime.VisibleIndex = 5;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.splitContainerControl1);
            this.panelControl2.Location = new System.Drawing.Point(0, 56);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(774, 439);
            this.panelControl2.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(792, 56);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 34);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmProcessFIFO
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panelControl2);
            this.Name = "frmProcessFIFO";
            this.Text = "工序先进先出";
            this.Activated += new System.EventHandler(this.frmProcessFIFO_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProcessFIFO_FormClosed);
            this.Load += new System.EventHandler(this.frmProcessFIFO_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vgrdCurrentPWO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDevices.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOofWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOofWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl grdPWOofWait;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOofWait;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboDevices;
        private DevExpress.XtraVerticalGrid.VGridControl vgrdCurrentPWO;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPWONo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPWOQuantity;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPWOStartTime;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPlannedCloseTime;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowT133Name;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowNotGoodQuantity;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowGoodRate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWO;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWOQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT106Code;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWOStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProcessWaitTime;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}
