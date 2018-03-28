namespace IRAP.Client.GUI.BatchSystem
{
    partial class frmRunningSPPModify
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRunningSPPModify));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lstEquipments = new DevExpress.XtraEditors.ListBoxControl();
            this.grdOrders = new DevExpress.XtraGrid.GridControl();
            this.grdvOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnTexture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grclmnT102Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlateNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMachineModelling = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFoldNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnErrText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribeDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlCommand = new System.Windows.Forms.Panel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstEquipments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeDelete)).BeginInit();
            this.pnlCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "在产计划修改";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "ErrCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 30;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.lstEquipments);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "设备";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.grdOrders);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "生产工单";
            this.splitContainerControl1.Size = new System.Drawing.Size(746, 439);
            this.splitContainerControl1.SplitterPosition = 267;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lstEquipments
            // 
            this.lstEquipments.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEquipments.Appearance.Options.UseFont = true;
            this.lstEquipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEquipments.Location = new System.Drawing.Point(5, 5);
            this.lstEquipments.Name = "lstEquipments";
            this.lstEquipments.Size = new System.Drawing.Size(253, 400);
            this.lstEquipments.TabIndex = 0;
            // 
            // grdOrders
            // 
            this.grdOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrders.Location = new System.Drawing.Point(5, 5);
            this.grdOrders.MainView = this.grdvOrders;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ribeDelete});
            this.grdOrders.Size = new System.Drawing.Size(460, 400);
            this.grdOrders.TabIndex = 1;
            this.grdOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOrders});
            // 
            // grdvOrders
            // 
            this.grdvOrders.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvOrders.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvOrders.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvOrders.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvOrders.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvOrders.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvOrders.Appearance.Row.ForeColor = System.Drawing.Color.Red;
            this.grdvOrders.Appearance.Row.Options.UseFont = true;
            this.grdvOrders.Appearance.Row.Options.UseForeColor = true;
            this.grdvOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnMONumber,
            this.grdclmnMOLineNo,
            this.grdclmnTexture,
            this.grclmnT102Code,
            this.grdclmnPlateNo,
            this.grdclmnLotNumber,
            this.grdclmnMachineModelling,
            this.grdclmnFoldNumber,
            this.gridColumn1,
            this.grdclmnErrText,
            this.grdclmnDelete,
            this.gridColumn2});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.gridColumn1;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Black;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = -1;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.gridColumn1;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Green;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = 0;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule2.StopIfTrue = true;
            this.grdvOrders.FormatRules.Add(gridFormatRule1);
            this.grdvOrders.FormatRules.Add(gridFormatRule2);
            this.grdvOrders.GridControl = this.grdOrders;
            this.grdvOrders.Name = "grdvOrders";
            this.grdvOrders.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdvOrders.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grdvOrders.OptionsView.ColumnAutoWidth = false;
            this.grdvOrders.OptionsView.RowAutoHeight = true;
            this.grdvOrders.OptionsView.ShowGroupPanel = false;
            this.grdvOrders.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvOrders_InitNewRow);
            this.grdvOrders.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.grdvOrders_BeforeLeaveRow);
            this.grdvOrders.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdvOrders_ValidateRow);
            // 
            // grdclmnMONumber
            // 
            this.grdclmnMONumber.Caption = "订单号";
            this.grdclmnMONumber.FieldName = "MONumber";
            this.grdclmnMONumber.Name = "grdclmnMONumber";
            this.grdclmnMONumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnMONumber.OptionsColumn.AllowMove = false;
            this.grdclmnMONumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnMONumber.Visible = true;
            this.grdclmnMONumber.VisibleIndex = 0;
            this.grdclmnMONumber.Width = 30;
            // 
            // grdclmnMOLineNo
            // 
            this.grdclmnMOLineNo.Caption = "行号";
            this.grdclmnMOLineNo.FieldName = "MOLineNo";
            this.grdclmnMOLineNo.Name = "grdclmnMOLineNo";
            this.grdclmnMOLineNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnMOLineNo.OptionsColumn.AllowMove = false;
            this.grdclmnMOLineNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnMOLineNo.Visible = true;
            this.grdclmnMOLineNo.VisibleIndex = 1;
            this.grdclmnMOLineNo.Width = 30;
            // 
            // grdclmnTexture
            // 
            this.grdclmnTexture.Caption = "材质";
            this.grdclmnTexture.FieldName = "T131Code";
            this.grdclmnTexture.Name = "grdclmnTexture";
            this.grdclmnTexture.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnTexture.OptionsColumn.AllowMove = false;
            this.grdclmnTexture.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnTexture.Visible = true;
            this.grdclmnTexture.VisibleIndex = 2;
            this.grdclmnTexture.Width = 30;
            // 
            // grclmnT102Code
            // 
            this.grclmnT102Code.Caption = "产品物料号";
            this.grclmnT102Code.FieldName = "T102Code";
            this.grclmnT102Code.Name = "grclmnT102Code";
            this.grclmnT102Code.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grclmnT102Code.OptionsColumn.AllowMove = false;
            this.grclmnT102Code.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grclmnT102Code.Visible = true;
            this.grclmnT102Code.VisibleIndex = 3;
            this.grclmnT102Code.Width = 30;
            // 
            // grdclmnPlateNo
            // 
            this.grdclmnPlateNo.Caption = "型板号";
            this.grdclmnPlateNo.FieldName = "PlateNo";
            this.grdclmnPlateNo.Name = "grdclmnPlateNo";
            this.grdclmnPlateNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnPlateNo.OptionsColumn.AllowMove = false;
            this.grdclmnPlateNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnPlateNo.Visible = true;
            this.grdclmnPlateNo.VisibleIndex = 4;
            this.grdclmnPlateNo.Width = 30;
            // 
            // grdclmnLotNumber
            // 
            this.grdclmnLotNumber.Caption = "毛坯批次号";
            this.grdclmnLotNumber.FieldName = "LotNumber";
            this.grdclmnLotNumber.Name = "grdclmnLotNumber";
            this.grdclmnLotNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnLotNumber.OptionsColumn.AllowMove = false;
            this.grdclmnLotNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnLotNumber.Visible = true;
            this.grdclmnLotNumber.VisibleIndex = 5;
            this.grdclmnLotNumber.Width = 30;
            // 
            // grdclmnMachineModelling
            // 
            this.grdclmnMachineModelling.Caption = "造型机台号";
            this.grdclmnMachineModelling.FieldName = "MachineModelling";
            this.grdclmnMachineModelling.Name = "grdclmnMachineModelling";
            this.grdclmnMachineModelling.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnMachineModelling.OptionsColumn.AllowMove = false;
            this.grdclmnMachineModelling.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnMachineModelling.Visible = true;
            this.grdclmnMachineModelling.VisibleIndex = 6;
            this.grdclmnMachineModelling.Width = 30;
            // 
            // grdclmnFoldNumber
            // 
            this.grdclmnFoldNumber.Caption = "叠数";
            this.grdclmnFoldNumber.FieldName = "FoldNumber";
            this.grdclmnFoldNumber.Name = "grdclmnFoldNumber";
            this.grdclmnFoldNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnFoldNumber.OptionsColumn.AllowMove = false;
            this.grdclmnFoldNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnFoldNumber.Visible = true;
            this.grdclmnFoldNumber.VisibleIndex = 7;
            this.grdclmnFoldNumber.Width = 30;
            // 
            // grdclmnErrText
            // 
            this.grdclmnErrText.Caption = "信息";
            this.grdclmnErrText.FieldName = "ErrText";
            this.grdclmnErrText.Name = "grdclmnErrText";
            this.grdclmnErrText.OptionsColumn.ReadOnly = true;
            this.grdclmnErrText.Visible = true;
            this.grdclmnErrText.VisibleIndex = 8;
            this.grdclmnErrText.Width = 30;
            // 
            // grdclmnDelete
            // 
            this.grdclmnDelete.Caption = "删除";
            this.grdclmnDelete.ColumnEdit = this.ribeDelete;
            this.grdclmnDelete.Name = "grdclmnDelete";
            this.grdclmnDelete.Visible = true;
            this.grdclmnDelete.VisibleIndex = 9;
            // 
            // ribeDelete
            // 
            this.ribeDelete.AutoHeight = false;
            this.ribeDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "DeleteRow", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("ribeDelete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.ribeDelete.Name = "ribeDelete";
            this.ribeDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.ribeDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ribeDelete_ButtonClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "RecordStatus";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // pnlCommand
            // 
            this.pnlCommand.Controls.Add(this.btnSave);
            this.pnlCommand.Controls.Add(this.btnRefresh);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCommand.Location = new System.Drawing.Point(746, 56);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(145, 439);
            this.pnlCommand.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(8, 402);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(8, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmRunningSPPModify
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.pnlCommand);
            this.Name = "frmRunningSPPModify";
            this.Text = "在产计划修改";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlCommand, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstEquipments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeDelete)).EndInit();
            this.pnlCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.Panel pnlCommand;
        private DevExpress.XtraEditors.ListBoxControl lstEquipments;
        private DevExpress.XtraGrid.GridControl grdOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOrders;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnTexture;
        private DevExpress.XtraGrid.Columns.GridColumn grclmnT102Code;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlateNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLotNumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMachineModelling;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFoldNumber;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnErrText;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribeDelete;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
