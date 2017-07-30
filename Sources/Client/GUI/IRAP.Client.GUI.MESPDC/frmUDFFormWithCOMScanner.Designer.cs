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
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            resources.ApplyResources(this.lblFuncName, "lblFuncName");
            this.lblFuncName.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblFuncName.Appearance.Font")));
            this.lblFuncName.Appearance.FontSizeDelta = ((int)(resources.GetObject("lblFuncName.Appearance.FontSizeDelta")));
            this.lblFuncName.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblFuncName.Appearance.FontStyleDelta")));
            this.lblFuncName.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblFuncName.Appearance.ForeColor")));
            this.lblFuncName.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblFuncName.Appearance.GradientMode")));
            this.lblFuncName.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblFuncName.Appearance.Image")));
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // panelControl1
            // 
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.toolTipController.SetAllowHtmlText(this.panelControl1, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("panelControl1.AllowHtmlText"))));
            this.toolTipController.SetTitle(this.panelControl1, resources.GetString("panelControl1.Title"));
            this.toolTipController.SetToolTip(this.panelControl1, resources.GetString("panelControl1.ToolTip"));
            this.toolTipController.SetToolTipIconType(this.panelControl1, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("panelControl1.ToolTipIconType"))));
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.FontSizeDelta = ((int)(resources.GetObject("toolTipController.Appearance.FontSizeDelta")));
            this.toolTipController.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("toolTipController.Appearance.FontStyleDelta")));
            this.toolTipController.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("toolTipController.Appearance.GradientMode")));
            this.toolTipController.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("toolTipController.Appearance.Image")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.FontSizeDelta = ((int)(resources.GetObject("toolTipController.AppearanceTitle.FontSizeDelta")));
            this.toolTipController.AppearanceTitle.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("toolTipController.AppearanceTitle.FontStyleDelta")));
            this.toolTipController.AppearanceTitle.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("toolTipController.AppearanceTitle.GradientMode")));
            this.toolTipController.AppearanceTitle.Image = ((System.Drawing.Image)(resources.GetObject("toolTipController.AppearanceTitle.Image")));
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
            resources.ApplyResources(this.pnlBody, "pnlBody");
            this.toolTipController.SetAllowHtmlText(this.pnlBody, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("pnlBody.AllowHtmlText"))));
            this.pnlBody.Controls.Add(this.lstBarCodes);
            this.pnlBody.Controls.Add(this.groupControl1);
            this.pnlBody.Controls.Add(this.groupControl3);
            this.pnlBody.Name = "pnlBody";
            this.toolTipController.SetTitle(this.pnlBody, resources.GetString("pnlBody.Title"));
            this.toolTipController.SetToolTip(this.pnlBody, resources.GetString("pnlBody.ToolTip"));
            this.toolTipController.SetToolTipIconType(this.pnlBody, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("pnlBody.ToolTipIconType"))));
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
            this.groupControl1.AppearanceCaption.FontSizeDelta = ((int)(resources.GetObject("groupControl1.AppearanceCaption.FontSizeDelta")));
            this.groupControl1.AppearanceCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("groupControl1.AppearanceCaption.FontStyleDelta")));
            this.groupControl1.AppearanceCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("groupControl1.AppearanceCaption.GradientMode")));
            this.groupControl1.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.AppearanceCaption.Image")));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdSerialPortScanners);
            this.groupControl1.Name = "groupControl1";
            // 
            // grdSerialPortScanners
            // 
            resources.ApplyResources(this.grdSerialPortScanners, "grdSerialPortScanners");
            this.grdSerialPortScanners.EmbeddedNavigator.AccessibleDescription = resources.GetString("grdSerialPortScanners.EmbeddedNavigator.AccessibleDescription");
            this.grdSerialPortScanners.EmbeddedNavigator.AccessibleName = resources.GetString("grdSerialPortScanners.EmbeddedNavigator.AccessibleName");
            this.grdSerialPortScanners.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("grdSerialPortScanners.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.grdSerialPortScanners.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("grdSerialPortScanners.EmbeddedNavigator.Anchor")));
            this.grdSerialPortScanners.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grdSerialPortScanners.EmbeddedNavigator.BackgroundImage")));
            this.grdSerialPortScanners.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("grdSerialPortScanners.EmbeddedNavigator.BackgroundImageLayout")));
            this.grdSerialPortScanners.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("grdSerialPortScanners.EmbeddedNavigator.ImeMode")));
            this.grdSerialPortScanners.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("grdSerialPortScanners.EmbeddedNavigator.MaximumSize")));
            this.grdSerialPortScanners.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("grdSerialPortScanners.EmbeddedNavigator.TextLocation")));
            this.grdSerialPortScanners.EmbeddedNavigator.ToolTip = resources.GetString("grdSerialPortScanners.EmbeddedNavigator.ToolTip");
            this.grdSerialPortScanners.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("grdSerialPortScanners.EmbeddedNavigator.ToolTipIconType")));
            this.grdSerialPortScanners.EmbeddedNavigator.ToolTipTitle = resources.GetString("grdSerialPortScanners.EmbeddedNavigator.ToolTipTitle");
            this.grdSerialPortScanners.MainView = this.grdvSerialPortScanners;
            this.grdSerialPortScanners.Name = "grdSerialPortScanners";
            this.grdSerialPortScanners.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvSerialPortScanners});
            // 
            // grdvSerialPortScanners
            // 
            this.grdvSerialPortScanners.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("grdvSerialPortScanners.Appearance.HeaderPanel.Font")));
            this.grdvSerialPortScanners.Appearance.HeaderPanel.FontSizeDelta = ((int)(resources.GetObject("grdvSerialPortScanners.Appearance.HeaderPanel.FontSizeDelta")));
            this.grdvSerialPortScanners.Appearance.HeaderPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdvSerialPortScanners.Appearance.HeaderPanel.FontStyleDelta")));
            this.grdvSerialPortScanners.Appearance.HeaderPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdvSerialPortScanners.Appearance.HeaderPanel.GradientMode")));
            this.grdvSerialPortScanners.Appearance.HeaderPanel.Image = ((System.Drawing.Image)(resources.GetObject("grdvSerialPortScanners.Appearance.HeaderPanel.Image")));
            this.grdvSerialPortScanners.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvSerialPortScanners.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvSerialPortScanners.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvSerialPortScanners.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvSerialPortScanners.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("grdvSerialPortScanners.Appearance.Row.Font")));
            this.grdvSerialPortScanners.Appearance.Row.FontSizeDelta = ((int)(resources.GetObject("grdvSerialPortScanners.Appearance.Row.FontSizeDelta")));
            this.grdvSerialPortScanners.Appearance.Row.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdvSerialPortScanners.Appearance.Row.FontStyleDelta")));
            this.grdvSerialPortScanners.Appearance.Row.ForeColor = ((System.Drawing.Color)(resources.GetObject("grdvSerialPortScanners.Appearance.Row.ForeColor")));
            this.grdvSerialPortScanners.Appearance.Row.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdvSerialPortScanners.Appearance.Row.GradientMode")));
            this.grdvSerialPortScanners.Appearance.Row.Image = ((System.Drawing.Image)(resources.GetObject("grdvSerialPortScanners.Appearance.Row.Image")));
            this.grdvSerialPortScanners.Appearance.Row.Options.UseFont = true;
            this.grdvSerialPortScanners.Appearance.Row.Options.UseForeColor = true;
            resources.ApplyResources(this.grdvSerialPortScanners, "grdvSerialPortScanners");
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
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // gridColumn2
            // 
            resources.ApplyResources(this.gridColumn2, "gridColumn2");
            this.gridColumn2.FieldName = "WorkUnitCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // gridColumn3
            // 
            resources.ApplyResources(this.gridColumn3, "gridColumn3");
            this.gridColumn3.FieldName = "WorkUnitName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // gridColumn4
            // 
            resources.ApplyResources(this.gridColumn4, "gridColumn4");
            this.gridColumn4.FieldName = "BarCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // groupControl3
            // 
            resources.ApplyResources(this.groupControl3, "groupControl3");
            this.groupControl3.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("groupControl3.AppearanceCaption.Font")));
            this.groupControl3.AppearanceCaption.FontSizeDelta = ((int)(resources.GetObject("groupControl3.AppearanceCaption.FontSizeDelta")));
            this.groupControl3.AppearanceCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("groupControl3.AppearanceCaption.FontStyleDelta")));
            this.groupControl3.AppearanceCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("groupControl3.AppearanceCaption.GradientMode")));
            this.groupControl3.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupControl3.AppearanceCaption.Image")));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.grdBarCodeLogs);
            this.groupControl3.Name = "groupControl3";
            // 
            // grdBarCodeLogs
            // 
            resources.ApplyResources(this.grdBarCodeLogs, "grdBarCodeLogs");
            this.grdBarCodeLogs.EmbeddedNavigator.AccessibleDescription = resources.GetString("grdBarCodeLogs.EmbeddedNavigator.AccessibleDescription");
            this.grdBarCodeLogs.EmbeddedNavigator.AccessibleName = resources.GetString("grdBarCodeLogs.EmbeddedNavigator.AccessibleName");
            this.grdBarCodeLogs.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("grdBarCodeLogs.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.grdBarCodeLogs.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("grdBarCodeLogs.EmbeddedNavigator.Anchor")));
            this.grdBarCodeLogs.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grdBarCodeLogs.EmbeddedNavigator.BackgroundImage")));
            this.grdBarCodeLogs.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("grdBarCodeLogs.EmbeddedNavigator.BackgroundImageLayout")));
            this.grdBarCodeLogs.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("grdBarCodeLogs.EmbeddedNavigator.ImeMode")));
            this.grdBarCodeLogs.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("grdBarCodeLogs.EmbeddedNavigator.MaximumSize")));
            this.grdBarCodeLogs.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("grdBarCodeLogs.EmbeddedNavigator.TextLocation")));
            this.grdBarCodeLogs.EmbeddedNavigator.ToolTip = resources.GetString("grdBarCodeLogs.EmbeddedNavigator.ToolTip");
            this.grdBarCodeLogs.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("grdBarCodeLogs.EmbeddedNavigator.ToolTipIconType")));
            this.grdBarCodeLogs.EmbeddedNavigator.ToolTipTitle = resources.GetString("grdBarCodeLogs.EmbeddedNavigator.ToolTipTitle");
            this.grdBarCodeLogs.MainView = this.grdvBarCodeLogs;
            this.grdBarCodeLogs.Name = "grdBarCodeLogs";
            this.grdBarCodeLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvBarCodeLogs});
            // 
            // grdvBarCodeLogs
            // 
            this.grdvBarCodeLogs.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("grdvBarCodeLogs.Appearance.HeaderPanel.Font")));
            this.grdvBarCodeLogs.Appearance.HeaderPanel.FontSizeDelta = ((int)(resources.GetObject("grdvBarCodeLogs.Appearance.HeaderPanel.FontSizeDelta")));
            this.grdvBarCodeLogs.Appearance.HeaderPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdvBarCodeLogs.Appearance.HeaderPanel.FontStyleDelta")));
            this.grdvBarCodeLogs.Appearance.HeaderPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdvBarCodeLogs.Appearance.HeaderPanel.GradientMode")));
            this.grdvBarCodeLogs.Appearance.HeaderPanel.Image = ((System.Drawing.Image)(resources.GetObject("grdvBarCodeLogs.Appearance.HeaderPanel.Image")));
            this.grdvBarCodeLogs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvBarCodeLogs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvBarCodeLogs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvBarCodeLogs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvBarCodeLogs.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("grdvBarCodeLogs.Appearance.Row.Font")));
            this.grdvBarCodeLogs.Appearance.Row.FontSizeDelta = ((int)(resources.GetObject("grdvBarCodeLogs.Appearance.Row.FontSizeDelta")));
            this.grdvBarCodeLogs.Appearance.Row.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("grdvBarCodeLogs.Appearance.Row.FontStyleDelta")));
            this.grdvBarCodeLogs.Appearance.Row.ForeColor = ((System.Drawing.Color)(resources.GetObject("grdvBarCodeLogs.Appearance.Row.ForeColor")));
            this.grdvBarCodeLogs.Appearance.Row.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("grdvBarCodeLogs.Appearance.Row.GradientMode")));
            this.grdvBarCodeLogs.Appearance.Row.Image = ((System.Drawing.Image)(resources.GetObject("grdvBarCodeLogs.Appearance.Row.Image")));
            this.grdvBarCodeLogs.Appearance.Row.Options.UseFont = true;
            this.grdvBarCodeLogs.Appearance.Row.Options.UseForeColor = true;
            resources.ApplyResources(this.grdvBarCodeLogs, "grdvBarCodeLogs");
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
            formatConditionRuleValue2.Appearance.FontSizeDelta = ((int)(resources.GetObject("resource.FontSizeDelta")));
            formatConditionRuleValue2.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("resource.FontStyleDelta")));
            formatConditionRuleValue2.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("resource.ForeColor")));
            formatConditionRuleValue2.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("resource.GradientMode")));
            formatConditionRuleValue2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
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
            this.grdclmnProcessTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnSerialPort
            // 
            resources.ApplyResources(this.grdclmnSerialPort, "grdclmnSerialPort");
            this.grdclmnSerialPort.FieldName = "SerialPort";
            this.grdclmnSerialPort.Name = "grdclmnSerialPort";
            this.grdclmnSerialPort.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnMainBarcode
            // 
            resources.ApplyResources(this.grdclmnMainBarcode, "grdclmnMainBarcode");
            this.grdclmnMainBarcode.FieldName = "MainBarCode";
            this.grdclmnMainBarcode.Name = "grdclmnMainBarcode";
            this.grdclmnMainBarcode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnSerialNumber
            // 
            resources.ApplyResources(this.grdclmnSerialNumber, "grdclmnSerialNumber");
            this.grdclmnSerialNumber.FieldName = "SerialNumber";
            this.grdclmnSerialNumber.Name = "grdclmnSerialNumber";
            this.grdclmnSerialNumber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // grdclmnResultMessage
            // 
            resources.ApplyResources(this.grdclmnResultMessage, "grdclmnResultMessage");
            this.grdclmnResultMessage.FieldName = "ResultMessage";
            this.grdclmnResultMessage.Name = "grdclmnResultMessage";
            this.grdclmnResultMessage.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmUDFFormWithCOMScanner
            // 
            resources.ApplyResources(this, "$this");
            this.toolTipController.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("frmUDFFormWithCOMScanner.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("frmUDFFormWithCOMScanner.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("frmUDFFormWithCOMScanner.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmUDFFormWithCOMScanner.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.pnlBody);
            this.Name = "frmUDFFormWithCOMScanner";
            this.toolTipController.SetTitle(this, resources.GetString("$this.Title"));
            this.toolTipController.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.toolTipController.SetToolTipIconType(this, ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("$this.ToolTipIconType"))));
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
    }
}
