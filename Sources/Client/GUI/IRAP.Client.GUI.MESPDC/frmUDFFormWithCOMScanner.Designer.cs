namespace IRAP.Client.GUI.MESPDC
{
    partial class frmUDFFormWithCOMScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUDFFormWithCOMScanner));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.grdclmnResultCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.lstBarCodes = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdSerialPortScanners = new DevExpress.XtraGrid.GridControl();
            this.grdvSerialPortScanners = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.grdBarCodeLogs = new DevExpress.XtraGrid.GridControl();
            this.grdvBarCodeLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnProcessTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSerialPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMainBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSerialNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnResultMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBarCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSerialPortScanners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvSerialPortScanners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBarCodeLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBarCodeLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblFuncName.Appearance.Font")));
            this.lblFuncName.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblFuncName.Appearance.ForeColor")));
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.lblFuncName, "lblFuncName");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.SetChildIndex(this.lblFuncName, 0);
            this.panelControl1.Controls.SetChildIndex(this.textEdit1, 0);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdclmnResultCode
            // 
            resources.ApplyResources(this.grdclmnResultCode, "grdclmnResultCode");
            this.grdclmnResultCode.FieldName = "ResultCode";
            this.grdclmnResultCode.Name = "grdclmnResultCode";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.lstBarCodes);
            this.pnlBody.Controls.Add(this.groupControl1);
            this.pnlBody.Controls.Add(this.groupControl3);
            resources.ApplyResources(this.pnlBody, "pnlBody");
            this.pnlBody.Name = "pnlBody";
            // 
            // lstBarCodes
            // 
            resources.ApplyResources(this.lstBarCodes, "lstBarCodes");
            this.lstBarCodes.Name = "lstBarCodes";
            // 
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("groupControl1.AppearanceCaption.Font")));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdSerialPortScanners);
            this.groupControl1.Name = "groupControl1";
            // 
            // grdSerialPortScanners
            // 
            resources.ApplyResources(this.grdSerialPortScanners, "grdSerialPortScanners");
            this.grdSerialPortScanners.MainView = this.grdvSerialPortScanners;
            this.grdSerialPortScanners.Name = "grdSerialPortScanners";
            this.grdSerialPortScanners.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvSerialPortScanners});
            // 
            // grdvSerialPortScanners
            // 
            this.grdvSerialPortScanners.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("grdvSerialPortScanners.Appearance.HeaderPanel.Font")));
            this.grdvSerialPortScanners.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvSerialPortScanners.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvSerialPortScanners.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvSerialPortScanners.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvSerialPortScanners.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("grdvSerialPortScanners.Appearance.Row.Font")));
            this.grdvSerialPortScanners.Appearance.Row.ForeColor = ((System.Drawing.Color)(resources.GetObject("grdvSerialPortScanners.Appearance.Row.ForeColor")));
            this.grdvSerialPortScanners.Appearance.Row.Options.UseFont = true;
            this.grdvSerialPortScanners.Appearance.Row.Options.UseForeColor = true;
            this.grdvSerialPortScanners.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.grdvSerialPortScanners.GridControl = this.grdSerialPortScanners;
            this.grdvSerialPortScanners.Name = "grdvSerialPortScanners";
            this.grdvSerialPortScanners.OptionsBehavior.Editable = false;
            this.grdvSerialPortScanners.OptionsPrint.AutoResetPrintDocument = false;
            this.grdvSerialPortScanners.OptionsView.ColumnAutoWidth = false;
            this.grdvSerialPortScanners.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.FieldName = "PortName";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            resources.ApplyResources(this.gridColumn2, "gridColumn2");
            this.gridColumn2.FieldName = "WorkUnitCode";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            resources.ApplyResources(this.gridColumn3, "gridColumn3");
            this.gridColumn3.FieldName = "WorkUnitName";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            resources.ApplyResources(this.gridColumn4, "gridColumn4");
            this.gridColumn4.FieldName = "BarCode";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // groupControl3
            // 
            resources.ApplyResources(this.groupControl3, "groupControl3");
            this.groupControl3.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("groupControl3.AppearanceCaption.Font")));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.grdBarCodeLogs);
            this.groupControl3.Name = "groupControl3";
            // 
            // grdBarCodeLogs
            // 
            resources.ApplyResources(this.grdBarCodeLogs, "grdBarCodeLogs");
            this.grdBarCodeLogs.MainView = this.grdvBarCodeLogs;
            this.grdBarCodeLogs.Name = "grdBarCodeLogs";
            this.grdBarCodeLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvBarCodeLogs});
            // 
            // grdvBarCodeLogs
            // 
            this.grdvBarCodeLogs.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("grdvBarCodeLogs.Appearance.HeaderPanel.Font")));
            this.grdvBarCodeLogs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvBarCodeLogs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvBarCodeLogs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvBarCodeLogs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvBarCodeLogs.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("grdvBarCodeLogs.Appearance.Row.Font")));
            this.grdvBarCodeLogs.Appearance.Row.ForeColor = ((System.Drawing.Color)(resources.GetObject("grdvBarCodeLogs.Appearance.Row.ForeColor")));
            this.grdvBarCodeLogs.Appearance.Row.Options.UseFont = true;
            this.grdvBarCodeLogs.Appearance.Row.Options.UseForeColor = true;
            this.grdvBarCodeLogs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnProcessTime,
            this.grdclmnSerialPort,
            this.grdclmnMainBarcode,
            this.grdclmnSerialNumber,
            this.grdclmnResultMessage,
            this.grdclmnResultCode});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.grdclmnResultCode;
            gridFormatRule2.Name = "Format0";
            formatConditionRuleValue2.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("resource.ForeColor")));
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual;
            formatConditionRuleValue2.Value1 = 0;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.grdvBarCodeLogs.FormatRules.Add(gridFormatRule2);
            this.grdvBarCodeLogs.GridControl = this.grdBarCodeLogs;
            this.grdvBarCodeLogs.Name = "grdvBarCodeLogs";
            this.grdvBarCodeLogs.OptionsBehavior.Editable = false;
            this.grdvBarCodeLogs.OptionsPrint.AutoResetPrintDocument = false;
            this.grdvBarCodeLogs.OptionsView.ColumnAutoWidth = false;
            this.grdvBarCodeLogs.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnProcessTime
            // 
            resources.ApplyResources(this.grdclmnProcessTime, "grdclmnProcessTime");
            this.grdclmnProcessTime.FieldName = "ProcessTime";
            this.grdclmnProcessTime.Name = "grdclmnProcessTime";
            // 
            // grdclmnSerialPort
            // 
            resources.ApplyResources(this.grdclmnSerialPort, "grdclmnSerialPort");
            this.grdclmnSerialPort.FieldName = "SerialPort";
            this.grdclmnSerialPort.Name = "grdclmnSerialPort";
            // 
            // grdclmnMainBarcode
            // 
            resources.ApplyResources(this.grdclmnMainBarcode, "grdclmnMainBarcode");
            this.grdclmnMainBarcode.FieldName = "MainBarCode";
            this.grdclmnMainBarcode.Name = "grdclmnMainBarcode";
            // 
            // grdclmnSerialNumber
            // 
            resources.ApplyResources(this.grdclmnSerialNumber, "grdclmnSerialNumber");
            this.grdclmnSerialNumber.FieldName = "SerialNumber";
            this.grdclmnSerialNumber.Name = "grdclmnSerialNumber";
            // 
            // grdclmnResultMessage
            // 
            resources.ApplyResources(this.grdclmnResultMessage, "grdclmnResultMessage");
            this.grdclmnResultMessage.FieldName = "ResultMessage";
            this.grdclmnResultMessage.Name = "grdclmnResultMessage";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // textEdit1
            // 
            resources.ApplyResources(this.textEdit1, "textEdit1");
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("textEdit1.Properties.Appearance.Font")));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit1_KeyDown);
            // 
            // frmUDFFormWithCOMScanner
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlBody);
            this.Name = "frmUDFFormWithCOMScanner";
            this.Activated += new System.EventHandler(this.frmUDFFormWithCOMScanner_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUDFFormWithCOMScanner_FormClosed);
            this.Shown += new System.EventHandler(this.frmUDFFormWithCOMScanner_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstBarCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSerialPortScanners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvSerialPortScanners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBarCodeLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBarCodeLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraEditors.ListBoxControl lstBarCodes;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdSerialPortScanners;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvSerialPortScanners;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdBarCodeLogs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvBarCodeLogs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProcessTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMainBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSerialPort;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSerialNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnResultMessage;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnResultCode;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}
