namespace IRAP.Client.GUI.MESRPC
{
    partial class frmReworkRouteSetting
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.grdPWOs = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.grdvPWOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLineCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWOQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnReworkBasis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScheduledStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWOStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riicbPWOStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfiguration = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicbPWOStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(599, 56);
            this.lblFuncName.Text = "frmCustomBase";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(599, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdPWOs
            // 
            this.grdPWOs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPWOs.ContextMenuStrip = this.contextMenuStrip1;
            this.grdPWOs.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdPWOs.Location = new System.Drawing.Point(5, 62);
            this.grdPWOs.MainView = this.grdvPWOs;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riicbPWOStatus});
            this.grdPWOs.Size = new System.Drawing.Size(447, 401);
            this.grdPWOs.TabIndex = 10;
            this.grdPWOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPWOs});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConfiguration,
            this.toolStripMenuItem1,
            this.miRefresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 76);
            // 
            // miConfiguration
            // 
            this.miConfiguration.Name = "miConfiguration";
            this.miConfiguration.Size = new System.Drawing.Size(152, 22);
            this.miConfiguration.Text = "配置";
            this.miConfiguration.Click += new System.EventHandler(this.miConfiguration_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 6);
            // 
            // miRefresh
            // 
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.Size = new System.Drawing.Size(152, 22);
            this.miRefresh.Text = "刷新";
            this.miRefresh.Click += new System.EventHandler(this.miRefresh_Click);
            // 
            // grdvPWOs
            // 
            this.grdvPWOs.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvPWOs.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvPWOs.Appearance.Row.Options.UseFont = true;
            this.grdvPWOs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnPWONo,
            this.grdclmnProductNo,
            this.grdclmnProductDesc,
            this.grdclmnLineCode,
            this.grdclmnLineName,
            this.grdclmnPWOQuantity,
            this.grdclmnReworkBasis,
            this.grdclmnContainerNo,
            this.grdclmnScheduledStartTime,
            this.grdclmnPWOStatus});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Blue;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "未停产";
            styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "已停产";
            this.grdvPWOs.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.grdvPWOs.GridControl = this.grdPWOs;
            this.grdvPWOs.Name = "grdvPWOs";
            this.grdvPWOs.OptionsBehavior.Editable = false;
            this.grdvPWOs.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvPWOs.OptionsView.ColumnAutoWidth = false;
            this.grdvPWOs.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvPWOs.OptionsView.RowAutoHeight = true;
            this.grdvPWOs.OptionsView.ShowGroupPanel = false;
            this.grdvPWOs.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.grdvPWOs_FocusedRowObjectChanged);
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.Caption = "序号";
            this.grdclmnOrdinal.FieldName = "Ordinal";
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
            this.grdclmnOrdinal.Width = 65;
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.Caption = "工单号";
            this.grdclmnPWONo.FieldName = "PWONo";
            this.grdclmnPWONo.Name = "grdclmnPWONo";
            this.grdclmnPWONo.OptionsColumn.AllowEdit = false;
            this.grdclmnPWONo.Visible = true;
            this.grdclmnPWONo.VisibleIndex = 1;
            this.grdclmnPWONo.Width = 150;
            // 
            // grdclmnProductNo
            // 
            this.grdclmnProductNo.Caption = "产品编号";
            this.grdclmnProductNo.FieldName = "ProductNo";
            this.grdclmnProductNo.Name = "grdclmnProductNo";
            this.grdclmnProductNo.Visible = true;
            this.grdclmnProductNo.VisibleIndex = 2;
            this.grdclmnProductNo.Width = 150;
            // 
            // grdclmnProductDesc
            // 
            this.grdclmnProductDesc.Caption = "产品名称";
            this.grdclmnProductDesc.FieldName = "ProductDesc";
            this.grdclmnProductDesc.Name = "grdclmnProductDesc";
            this.grdclmnProductDesc.Visible = true;
            this.grdclmnProductDesc.VisibleIndex = 3;
            // 
            // grdclmnLineCode
            // 
            this.grdclmnLineCode.Caption = "产线代码";
            this.grdclmnLineCode.FieldName = "LineCode";
            this.grdclmnLineCode.Name = "grdclmnLineCode";
            this.grdclmnLineCode.Visible = true;
            this.grdclmnLineCode.VisibleIndex = 4;
            // 
            // grdclmnLineName
            // 
            this.grdclmnLineName.Caption = "产线名称";
            this.grdclmnLineName.FieldName = "LineName";
            this.grdclmnLineName.Name = "grdclmnLineName";
            this.grdclmnLineName.Visible = true;
            this.grdclmnLineName.VisibleIndex = 5;
            // 
            // grdclmnPWOQuantity
            // 
            this.grdclmnPWOQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPWOQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnPWOQuantity.Caption = "返工数量";
            this.grdclmnPWOQuantity.FieldName = "PWOQuantity";
            this.grdclmnPWOQuantity.Name = "grdclmnPWOQuantity";
            this.grdclmnPWOQuantity.Visible = true;
            this.grdclmnPWOQuantity.VisibleIndex = 6;
            // 
            // grdclmnReworkBasis
            // 
            this.grdclmnReworkBasis.Caption = "返工依据";
            this.grdclmnReworkBasis.FieldName = "ReworkBasis";
            this.grdclmnReworkBasis.Name = "grdclmnReworkBasis";
            this.grdclmnReworkBasis.Visible = true;
            this.grdclmnReworkBasis.VisibleIndex = 7;
            // 
            // grdclmnContainerNo
            // 
            this.grdclmnContainerNo.Caption = "容器编号";
            this.grdclmnContainerNo.FieldName = "ContainerNo";
            this.grdclmnContainerNo.Name = "grdclmnContainerNo";
            this.grdclmnContainerNo.Visible = true;
            this.grdclmnContainerNo.VisibleIndex = 8;
            // 
            // grdclmnScheduledStartTime
            // 
            this.grdclmnScheduledStartTime.Caption = "排定返工开始时间";
            this.grdclmnScheduledStartTime.FieldName = "ScheduledStartTime";
            this.grdclmnScheduledStartTime.Name = "grdclmnScheduledStartTime";
            this.grdclmnScheduledStartTime.Visible = true;
            this.grdclmnScheduledStartTime.VisibleIndex = 9;
            // 
            // grdclmnPWOStatus
            // 
            this.grdclmnPWOStatus.Caption = "返工状态";
            this.grdclmnPWOStatus.ColumnEdit = this.riicbPWOStatus;
            this.grdclmnPWOStatus.FieldName = "PWOStatus";
            this.grdclmnPWOStatus.Name = "grdclmnPWOStatus";
            this.grdclmnPWOStatus.Visible = true;
            this.grdclmnPWOStatus.VisibleIndex = 10;
            // 
            // riicbPWOStatus
            // 
            this.riicbPWOStatus.AutoHeight = false;
            this.riicbPWOStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riicbPWOStatus.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("1-工单新创建", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("2-工艺已设置", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("3-工装已备齐", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("4-物料已备齐", 4, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("5-返工已开始", 5, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("6-返工被搁置", 6, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("7-工单已取消", 7, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("8-工单已提交", 8, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("9-工单已关闭", 9, -1)});
            this.riicbPWOStatus.Name = "riicbPWOStatus";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(458, 107);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(129, 26);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfiguration.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguration.Appearance.Options.UseFont = true;
            this.btnConfiguration.Location = new System.Drawing.Point(458, 62);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(129, 26);
            this.btnConfiguration.TabIndex = 13;
            this.btnConfiguration.Text = "设置";
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // frmReworkRouteSetting
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(599, 466);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnConfiguration);
            this.Controls.Add(this.grdPWOs);
            this.Name = "frmReworkRouteSetting";
            this.Load += new System.EventHandler(this.frmReworkRouteSetting_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.grdPWOs, 0);
            this.Controls.SetChildIndex(this.btnConfiguration, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicbPWOStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductNo;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnConfiguration;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductDesc;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWOQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReworkBasis;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWOStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicbPWOStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLineCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLineName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScheduledStartTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miConfiguration;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
    }
}
