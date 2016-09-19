namespace IRAP.Client.GUI.MESPDC
{
    partial class frmManufactureRecord
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.grdclmnResultCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdSerialPortScanners = new DevExpress.XtraGrid.GridControl();
            this.grdvSerialPortScanners = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lstBarCodes = new DevExpress.XtraEditors.ListBoxControl();
            this.edtContainerNo2 = new DevExpress.XtraEditors.TextEdit();
            this.edtContainerNo1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.grdBarCodeLogs = new DevExpress.XtraGrid.GridControl();
            this.grdvBarCodeLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnProcessTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMainBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSubBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSerialNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnResultMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSerialPortScanners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvSerialPortScanners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBarCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtContainerNo2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtContainerNo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBarCodeLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBarCodeLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(769, 56);
            this.lblFuncName.Text = "生产记载";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(769, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdclmnResultCode
            // 
            this.grdclmnResultCode.Caption = "gridColumn10";
            this.grdclmnResultCode.FieldName = "ResultCode";
            this.grdclmnResultCode.Name = "grdclmnResultCode";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdSerialPortScanners);
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl1.Size = new System.Drawing.Size(473, 167);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "条码";
            // 
            // grdSerialPortScanners
            // 
            this.grdSerialPortScanners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSerialPortScanners.Location = new System.Drawing.Point(7, 28);
            this.grdSerialPortScanners.MainView = this.grdvSerialPortScanners;
            this.grdSerialPortScanners.Name = "grdSerialPortScanners";
            this.grdSerialPortScanners.Size = new System.Drawing.Size(459, 132);
            this.grdSerialPortScanners.TabIndex = 0;
            this.grdSerialPortScanners.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvSerialPortScanners});
            // 
            // grdvSerialPortScanners
            // 
            this.grdvSerialPortScanners.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvSerialPortScanners.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvSerialPortScanners.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvSerialPortScanners.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvSerialPortScanners.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvSerialPortScanners.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvSerialPortScanners.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            this.grdvSerialPortScanners.Appearance.Row.Options.UseFont = true;
            this.grdvSerialPortScanners.Appearance.Row.Options.UseForeColor = true;
            this.grdvSerialPortScanners.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.grdvSerialPortScanners.GridControl = this.grdSerialPortScanners;
            this.grdvSerialPortScanners.Name = "grdvSerialPortScanners";
            this.grdvSerialPortScanners.OptionsPrint.AutoResetPrintDocument = false;
            this.grdvSerialPortScanners.OptionsView.ColumnAutoWidth = false;
            this.grdvSerialPortScanners.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "端口";
            this.gridColumn1.FieldName = "PortName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "工位代码";
            this.gridColumn2.FieldName = "WorkUnitCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "工位名称";
            this.gridColumn3.FieldName = "WorkUnitName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "扫描到的条码";
            this.gridColumn4.FieldName = "BarCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 83;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.lstBarCodes);
            this.groupControl2.Controls.Add(this.edtContainerNo2);
            this.groupControl2.Controls.Add(this.edtContainerNo1);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(484, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl2.Size = new System.Drawing.Size(280, 167);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "当前工位在产品容器";
            // 
            // lstBarCodes
            // 
            this.lstBarCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBarCodes.Location = new System.Drawing.Point(10, 98);
            this.lstBarCodes.Name = "lstBarCodes";
            this.lstBarCodes.Size = new System.Drawing.Size(258, 59);
            this.lstBarCodes.TabIndex = 4;
            this.lstBarCodes.Visible = false;
            // 
            // edtContainerNo2
            // 
            this.edtContainerNo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtContainerNo2.Location = new System.Drawing.Point(95, 56);
            this.edtContainerNo2.Name = "edtContainerNo2";
            this.edtContainerNo2.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtContainerNo2.Properties.Appearance.Options.UseFont = true;
            this.edtContainerNo2.Size = new System.Drawing.Size(173, 22);
            this.edtContainerNo2.TabIndex = 3;
            // 
            // edtContainerNo1
            // 
            this.edtContainerNo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtContainerNo1.Location = new System.Drawing.Point(95, 28);
            this.edtContainerNo1.Name = "edtContainerNo1";
            this.edtContainerNo1.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtContainerNo1.Properties.Appearance.Options.UseFont = true;
            this.edtContainerNo1.Size = new System.Drawing.Size(173, 22);
            this.edtContainerNo1.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(10, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "托盘编号:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(10, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "中转箱号:";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.grdBarCodeLogs);
            this.groupControl3.Location = new System.Drawing.Point(5, 178);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl3.Size = new System.Drawing.Size(759, 271);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "处理信息";
            // 
            // grdBarCodeLogs
            // 
            this.grdBarCodeLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBarCodeLogs.Location = new System.Drawing.Point(7, 28);
            this.grdBarCodeLogs.MainView = this.grdvBarCodeLogs;
            this.grdBarCodeLogs.Name = "grdBarCodeLogs";
            this.grdBarCodeLogs.Size = new System.Drawing.Size(745, 236);
            this.grdBarCodeLogs.TabIndex = 0;
            this.grdBarCodeLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvBarCodeLogs});
            // 
            // grdvBarCodeLogs
            // 
            this.grdvBarCodeLogs.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvBarCodeLogs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvBarCodeLogs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvBarCodeLogs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvBarCodeLogs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvBarCodeLogs.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvBarCodeLogs.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            this.grdvBarCodeLogs.Appearance.Row.Options.UseFont = true;
            this.grdvBarCodeLogs.Appearance.Row.Options.UseForeColor = true;
            this.grdvBarCodeLogs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnProcessTime,
            this.grdclmnMainBarcode,
            this.grdclmnSubBarcode,
            this.grdclmnSerialNumber,
            this.grdclmnResultMessage,
            this.grdclmnResultCode});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.grdclmnResultCode;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.grdvBarCodeLogs.FormatRules.Add(gridFormatRule1);
            this.grdvBarCodeLogs.GridControl = this.grdBarCodeLogs;
            this.grdvBarCodeLogs.Name = "grdvBarCodeLogs";
            this.grdvBarCodeLogs.OptionsPrint.AutoResetPrintDocument = false;
            this.grdvBarCodeLogs.OptionsView.ColumnAutoWidth = false;
            this.grdvBarCodeLogs.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnProcessTime
            // 
            this.grdclmnProcessTime.Caption = "处理时间";
            this.grdclmnProcessTime.FieldName = "ProcessTime";
            this.grdclmnProcessTime.Name = "grdclmnProcessTime";
            this.grdclmnProcessTime.Visible = true;
            this.grdclmnProcessTime.VisibleIndex = 0;
            // 
            // grdclmnMainBarcode
            // 
            this.grdclmnMainBarcode.Caption = "主标识条码";
            this.grdclmnMainBarcode.FieldName = "MainBarCode";
            this.grdclmnMainBarcode.Name = "grdclmnMainBarcode";
            this.grdclmnMainBarcode.Visible = true;
            this.grdclmnMainBarcode.VisibleIndex = 1;
            // 
            // grdclmnSubBarcode
            // 
            this.grdclmnSubBarcode.Caption = "副标识条码";
            this.grdclmnSubBarcode.FieldName = "SubBarCode";
            this.grdclmnSubBarcode.Name = "grdclmnSubBarcode";
            this.grdclmnSubBarcode.Visible = true;
            this.grdclmnSubBarcode.VisibleIndex = 2;
            // 
            // grdclmnSerialNumber
            // 
            this.grdclmnSerialNumber.Caption = "产品序列号";
            this.grdclmnSerialNumber.FieldName = "SerialNumber";
            this.grdclmnSerialNumber.Name = "grdclmnSerialNumber";
            this.grdclmnSerialNumber.Visible = true;
            this.grdclmnSerialNumber.VisibleIndex = 3;
            // 
            // grdclmnResultMessage
            // 
            this.grdclmnResultMessage.Caption = "处理信息";
            this.grdclmnResultMessage.FieldName = "ResultMessage";
            this.grdclmnResultMessage.Name = "grdclmnResultMessage";
            this.grdclmnResultMessage.Visible = true;
            this.grdclmnResultMessage.VisibleIndex = 4;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.groupControl1);
            this.pnlBody.Controls.Add(this.groupControl2);
            this.pnlBody.Controls.Add(this.groupControl3);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 56);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(769, 454);
            this.pnlBody.TabIndex = 3;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmManufactureRecord
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(769, 510);
            this.Controls.Add(this.pnlBody);
            this.Name = "frmManufactureRecord";
            this.Text = "生产记载";
            this.Activated += new System.EventHandler(this.frmManufactureRecord_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmManufactureRecord_FormClosed);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSerialPortScanners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvSerialPortScanners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBarCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtContainerNo2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtContainerNo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBarCodeLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBarCodeLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdSerialPortScanners;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvSerialPortScanners;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.TextEdit edtContainerNo2;
        private DevExpress.XtraEditors.TextEdit edtContainerNo1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdBarCodeLogs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvBarCodeLogs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProcessTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMainBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSubBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSerialNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnResultMessage;
        private DevExpress.XtraEditors.ListBoxControl lstBarCodes;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnResultCode;
    }
}
