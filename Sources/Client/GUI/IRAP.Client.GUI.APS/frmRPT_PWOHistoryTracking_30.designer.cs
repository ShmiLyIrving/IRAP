namespace IRAP.Client.GUI.MESRPT
{
    partial class frmRPT_PWOHistoryTracking_30
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
            this.pnlConditon = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dateTimeEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateTimeStart = new DevExpress.XtraEditors.DateEdit();
            this.lpProductGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.grdMOExecution = new DevExpress.XtraGrid.GridControl();
            this.gdvMOExecution = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmScheduleStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmScheduleCloseTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmActualStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmActualCloseTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmMaterialQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmWIPQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmScrapRate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConditon)).BeginInit();
            this.pnlConditon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lpProductGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMOExecution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMOExecution)).BeginInit();
            this.SuspendLayout();
            // lblFuncName
            // 
            this.lblFuncName.Size = new System.Drawing.Size(994, 56);
            this.lblFuncName.Text = "frmCustomBase";
            // 
            // pnlConditon
            // 
            this.pnlConditon.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.pnlConditon.Controls.Add(this.labelControl3);
            this.pnlConditon.Controls.Add(this.labelControl2);
            this.pnlConditon.Controls.Add(this.btnSearch);
            this.pnlConditon.Controls.Add(this.dateTimeEnd);
            this.pnlConditon.Controls.Add(this.dateTimeStart);
            this.pnlConditon.Controls.Add(this.lpProductGroup);
            this.pnlConditon.Controls.Add(this.labelControl1);
            this.pnlConditon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConditon.Location = new System.Drawing.Point(0, 56);
            this.pnlConditon.Name = "pnlConditon";
            this.pnlConditon.Size = new System.Drawing.Size(994, 57);
            this.pnlConditon.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(595, 20);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 19);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "结束时间：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(310, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 19);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "开始时间：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(882, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 35);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.EditValue = null;
            this.dateTimeEnd.Location = new System.Drawing.Point(686, 15);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimeEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimeEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateTimeEnd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateTimeEnd.Size = new System.Drawing.Size(187, 20);
            this.dateTimeEnd.TabIndex = 3;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.EditValue = null;
            this.dateTimeStart.Location = new System.Drawing.Point(401, 17);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimeStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimeStart.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateTimeStart.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateTimeStart.Size = new System.Drawing.Size(188, 20);
            this.dateTimeStart.TabIndex = 2;
            // 
            // lpProductGroup
            // 
            this.lpProductGroup.Location = new System.Drawing.Point(122, 17);
            this.lpProductGroup.Name = "lpProductGroup";
            this.lpProductGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lpProductGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("text", "产品族")});
            this.lpProductGroup.Properties.NullText = "";
            this.lpProductGroup.Properties.ShowFooter = false;
            this.lpProductGroup.Properties.ShowHeader = false;
            this.lpProductGroup.Size = new System.Drawing.Size(173, 20);
            this.lpProductGroup.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(14, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "请选择产品：";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.grdMOExecution);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 113);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(994, 297);
            this.pnlBody.TabIndex = 2;
            // 
            // grdMOExecution
            // 
            this.grdMOExecution.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdMOExecution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMOExecution.Location = new System.Drawing.Point(2, 2);
            this.grdMOExecution.MainView = this.gdvMOExecution;
            this.grdMOExecution.Name = "grdMOExecution";
            this.grdMOExecution.Size = new System.Drawing.Size(990, 293);
            this.grdMOExecution.TabIndex = 0;
            this.grdMOExecution.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvMOExecution});
            // 
            // gdvMOExecution
            // 
            this.gdvMOExecution.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmMONumber,
            this.grdclmMOLineNo,
            this.grdclmProductNo,
            this.grdclmProductName,
            this.grdclmScheduleStartTime,
            this.grdclmScheduleCloseTime,
            this.grdclmActualStartTime,
            this.grdclmActualCloseTime,
            this.grdclmOrderQty,
            this.grdclmMaterialQty,
            this.grdclmWIPQty,
            this.grdclmScrapRate});
            this.gdvMOExecution.GridControl = this.grdMOExecution;
            this.gdvMOExecution.Name = "gdvMOExecution";
            // 
            // grdclmMONumber
            // 
            this.grdclmMONumber.Caption = "订单号";
            this.grdclmMONumber.FieldName = "MONumber";
            this.grdclmMONumber.Name = "grdclmMONumber";
            this.grdclmMONumber.Visible = true;
            this.grdclmMONumber.VisibleIndex = 0;
            // 
            // grdclmMOLineNo
            // 
            this.grdclmMOLineNo.Caption = "行号";
            this.grdclmMOLineNo.FieldName = "MOLineNo";
            this.grdclmMOLineNo.Name = "grdclmMOLineNo";
            this.grdclmMOLineNo.Visible = true;
            this.grdclmMOLineNo.VisibleIndex = 1;
            // 
            // grdclmProductNo
            // 
            this.grdclmProductNo.Caption = "产品编号";
            this.grdclmProductNo.FieldName = "ProductNo";
            this.grdclmProductNo.Name = "grdclmProductNo";
            this.grdclmProductNo.Visible = true;
            this.grdclmProductNo.VisibleIndex = 2;
            // 
            // grdclmProductName
            // 
            this.grdclmProductName.Caption = "产品名称";
            this.grdclmProductName.FieldName = "ProductName";
            this.grdclmProductName.Name = "grdclmProductName";
            this.grdclmProductName.Visible = true;
            this.grdclmProductName.VisibleIndex = 3;
            // 
            // grdclmScheduleStartTime
            // 
            this.grdclmScheduleStartTime.Caption = "要求开工时间";
            this.grdclmScheduleStartTime.FieldName = "ScheduleStartTime";
            this.grdclmScheduleStartTime.Name = "grdclmScheduleStartTime";
            this.grdclmScheduleStartTime.Visible = true;
            this.grdclmScheduleStartTime.VisibleIndex = 4;
            // 
            // grdclmScheduleCloseTime
            // 
            this.grdclmScheduleCloseTime.Caption = "要求完工时间";
            this.grdclmScheduleCloseTime.FieldName = "ScheduleCloseTime";
            this.grdclmScheduleCloseTime.Name = "grdclmScheduleCloseTime";
            this.grdclmScheduleCloseTime.Visible = true;
            this.grdclmScheduleCloseTime.VisibleIndex = 5;
            // 
            // grdclmActualStartTime
            // 
            this.grdclmActualStartTime.Caption = "实际开工时间";
            this.grdclmActualStartTime.FieldName = "ActualStartTime";
            this.grdclmActualStartTime.Name = "grdclmActualStartTime";
            this.grdclmActualStartTime.Visible = true;
            this.grdclmActualStartTime.VisibleIndex = 6;
            // 
            // grdclmActualCloseTime
            // 
            this.grdclmActualCloseTime.Caption = "实际完工时间";
            this.grdclmActualCloseTime.FieldName = "ActualCloseTime";
            this.grdclmActualCloseTime.Name = "grdclmActualCloseTime";
            this.grdclmActualCloseTime.Visible = true;
            this.grdclmActualCloseTime.VisibleIndex = 7;
            // 
            // grdclmOrderQty
            // 
            this.grdclmOrderQty.Caption = "订单量";
            this.grdclmOrderQty.FieldName = "OrderQty";
            this.grdclmOrderQty.Name = "grdclmOrderQty";
            this.grdclmOrderQty.Visible = true;
            this.grdclmOrderQty.VisibleIndex = 8;
            // 
            // grdclmMaterialQty
            // 
            this.grdclmMaterialQty.Caption = "提料数";
            this.grdclmMaterialQty.FieldName = "MaterialQty";
            this.grdclmMaterialQty.Name = "grdclmMaterialQty";
            this.grdclmMaterialQty.Visible = true;
            this.grdclmMaterialQty.VisibleIndex = 9;
            // 
            // grdclmWIPQty
            // 
            this.grdclmWIPQty.Caption = "正品数";
            this.grdclmWIPQty.FieldName = "WIPQty";
            this.grdclmWIPQty.Name = "grdclmWIPQty";
            this.grdclmWIPQty.Visible = true;
            this.grdclmWIPQty.VisibleIndex = 10;
            // 
            // grdclmScrapRate
            // 
            this.grdclmScrapRate.Caption = "废品率(%)";
            this.grdclmScrapRate.FieldName = "ScrapRate";
            this.grdclmScrapRate.Name = "grdclmScrapRate";
            this.grdclmScrapRate.Visible = true;
            this.grdclmScrapRate.VisibleIndex = 11;
            // 
            // frmRPT_PWOHistoryTracking_30
            // 
            this.ClientSize = new System.Drawing.Size(994, 410);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlConditon);
            this.Name = "frmRPT_PWOHistoryTracking_30";
            this.Load += new System.EventHandler(this.frmRPT_PWOHistoryTracking_30_Load);
            this.Controls.SetChildIndex(this.pnlConditon, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlConditon)).EndInit();
            this.pnlConditon.ResumeLayout(false);
            this.pnlConditon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lpProductGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMOExecution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvMOExecution)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlConditon;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraGrid.GridControl grdMOExecution;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvMOExecution;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmMONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmScheduleStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmScheduleCloseTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmActualStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmActualCloseTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmMaterialQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmWIPQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmScrapRate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.DateEdit dateTimeEnd;
        private DevExpress.XtraEditors.DateEdit dateTimeStart;
        private DevExpress.XtraEditors.LookUpEdit lpProductGroup;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}