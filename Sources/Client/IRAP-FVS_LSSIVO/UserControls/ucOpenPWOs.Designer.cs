namespace IRAP_FVS_LSSIVO.UserControls
{
    partial class ucOpenPWOs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue4 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue5 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.grdclmnBTSStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdOpenPWOs = new DevExpress.XtraGrid.GridControl();
            this.grdvOpenPWOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPWOStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnActualStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnActualQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdOpenPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOpenPWOs)).BeginInit();
            this.SuspendLayout();
            // 
            // grdclmnBTSStatus
            // 
            this.grdclmnBTSStatus.Caption = "gridColumn1";
            this.grdclmnBTSStatus.FieldName = "BTSStatus";
            this.grdclmnBTSStatus.Name = "grdclmnBTSStatus";
            // 
            // grdOpenPWOs
            // 
            this.grdOpenPWOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOpenPWOs.Location = new System.Drawing.Point(5, 5);
            this.grdOpenPWOs.MainView = this.grdvOpenPWOs;
            this.grdOpenPWOs.Name = "grdOpenPWOs";
            this.grdOpenPWOs.Size = new System.Drawing.Size(449, 300);
            this.grdOpenPWOs.TabIndex = 0;
            this.grdOpenPWOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOpenPWOs});
            // 
            // grdvOpenPWOs
            // 
            this.grdvOpenPWOs.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvOpenPWOs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvOpenPWOs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvOpenPWOs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvOpenPWOs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvOpenPWOs.Appearance.Row.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvOpenPWOs.Appearance.Row.Options.UseFont = true;
            this.grdvOpenPWOs.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grdvOpenPWOs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnPWOStatus,
            this.grdclmnProductNo,
            this.grdclmnPWONo,
            this.grdclmnOrderQty,
            this.grdclmnActualStartTime,
            this.grdclmnActualQuantity,
            this.grdclmnBTSStatus});
            this.grdvOpenPWOs.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.grdclmnBTSStatus;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Green;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.grdclmnBTSStatus;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Yellow;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = 1;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.grdclmnBTSStatus;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = 2;
            gridFormatRule3.Rule = formatConditionRuleValue3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Column = this.grdclmnBTSStatus;
            gridFormatRule4.Name = "Format3";
            formatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.Fuchsia;
            formatConditionRuleValue4.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue4.Value1 = 3;
            gridFormatRule4.Rule = formatConditionRuleValue4;
            gridFormatRule5.ApplyToRow = true;
            gridFormatRule5.Column = this.grdclmnBTSStatus;
            gridFormatRule5.Name = "Format4";
            formatConditionRuleValue5.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue5.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue5.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue5.Value1 = 4;
            gridFormatRule5.Rule = formatConditionRuleValue5;
            this.grdvOpenPWOs.FormatRules.Add(gridFormatRule1);
            this.grdvOpenPWOs.FormatRules.Add(gridFormatRule2);
            this.grdvOpenPWOs.FormatRules.Add(gridFormatRule3);
            this.grdvOpenPWOs.FormatRules.Add(gridFormatRule4);
            this.grdvOpenPWOs.FormatRules.Add(gridFormatRule5);
            this.grdvOpenPWOs.GridControl = this.grdOpenPWOs;
            this.grdvOpenPWOs.Name = "grdvOpenPWOs";
            this.grdvOpenPWOs.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvOpenPWOs.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grdvOpenPWOs.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grdvOpenPWOs.OptionsView.ShowGroupPanel = false;
            this.grdvOpenPWOs.OptionsView.ShowIndicator = false;
            this.grdvOpenPWOs.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // grdclmnPWOStatus
            // 
            this.grdclmnPWOStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPWOStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPWOStatus.Caption = "工单";
            this.grdclmnPWOStatus.FieldName = "PWOStatus";
            this.grdclmnPWOStatus.Name = "grdclmnPWOStatus";
            this.grdclmnPWOStatus.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnPWOStatus.OptionsFilter.AllowFilter = false;
            this.grdclmnPWOStatus.Visible = true;
            this.grdclmnPWOStatus.VisibleIndex = 0;
            // 
            // grdclmnProductNo
            // 
            this.grdclmnProductNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductNo.Caption = "产品编号";
            this.grdclmnProductNo.FieldName = "ProductNo";
            this.grdclmnProductNo.Name = "grdclmnProductNo";
            this.grdclmnProductNo.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnProductNo.OptionsFilter.AllowFilter = false;
            this.grdclmnProductNo.Visible = true;
            this.grdclmnProductNo.VisibleIndex = 1;
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPWONo.Caption = "工单号";
            this.grdclmnPWONo.FieldName = "PWONo";
            this.grdclmnPWONo.Name = "grdclmnPWONo";
            this.grdclmnPWONo.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnPWONo.OptionsFilter.AllowFilter = false;
            this.grdclmnPWONo.Visible = true;
            this.grdclmnPWONo.VisibleIndex = 2;
            // 
            // grdclmnOrderQty
            // 
            this.grdclmnOrderQty.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrderQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnOrderQty.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnOrderQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrderQty.Caption = "计划量";
            this.grdclmnOrderQty.FieldName = "OrderQty";
            this.grdclmnOrderQty.Name = "grdclmnOrderQty";
            this.grdclmnOrderQty.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnOrderQty.OptionsFilter.AllowFilter = false;
            this.grdclmnOrderQty.Visible = true;
            this.grdclmnOrderQty.VisibleIndex = 3;
            // 
            // grdclmnActualStartTime
            // 
            this.grdclmnActualStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnActualStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnActualStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnActualStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnActualStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnActualStartTime.Caption = "开始时间";
            this.grdclmnActualStartTime.DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            this.grdclmnActualStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grdclmnActualStartTime.FieldName = "ActualStartTime";
            this.grdclmnActualStartTime.Name = "grdclmnActualStartTime";
            this.grdclmnActualStartTime.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnActualStartTime.OptionsFilter.AllowFilter = false;
            this.grdclmnActualStartTime.Visible = true;
            this.grdclmnActualStartTime.VisibleIndex = 4;
            // 
            // grdclmnActualQuantity
            // 
            this.grdclmnActualQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnActualQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnActualQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnActualQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnActualQuantity.Caption = "完成量";
            this.grdclmnActualQuantity.FieldName = "ActualQuantity";
            this.grdclmnActualQuantity.Name = "grdclmnActualQuantity";
            this.grdclmnActualQuantity.OptionsFilter.AllowAutoFilter = false;
            this.grdclmnActualQuantity.OptionsFilter.AllowFilter = false;
            this.grdclmnActualQuantity.Visible = true;
            this.grdclmnActualQuantity.VisibleIndex = 5;
            // 
            // ucOpenPWOs
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdOpenPWOs);
            this.Name = "ucOpenPWOs";
            this.Padding = new System.Windows.Forms.Padding(5);
            ((System.ComponentModel.ISupportInitialize)(this.grdOpenPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOpenPWOs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdOpenPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOpenPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWOStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnActualStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnActualQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnBTSStatus;
    }
}
