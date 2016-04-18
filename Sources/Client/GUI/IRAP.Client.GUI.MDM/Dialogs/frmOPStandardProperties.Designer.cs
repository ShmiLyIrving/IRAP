namespace IRAP.Client.GUI.MDM
{
    partial class frmOPStandardProperties
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grdOPStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvOPStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnToolingOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStepNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnResourceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnManOrMachine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riicbManOrMachine = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grdclmnT112LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluT112LeafID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnJobElementDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnStartTimeOffset = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnEndTimeOffset = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSOPImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riieSOPImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluT112LeafID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.risluT112LeafIDView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnLeafCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLeafName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOPStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOPStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicbManOrMachine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT112LeafID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riieSOPImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT112LeafID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT112LeafIDView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTitle.Size = new System.Drawing.Size(652, 63);
            this.lblTitle.Text = "生产作业标准";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            // 
            // chkEffectiveType
            // 
            this.chkEffectiveType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEffectiveType.Properties.Appearance.Options.UseFont = true;
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grdOPStandards);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 63);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(652, 440);
            this.panelControl1.TabIndex = 8;
            // 
            // grdOPStandards
            // 
            this.grdOPStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOPStandards.Location = new System.Drawing.Point(7, 7);
            this.grdOPStandards.MainView = this.grdvOPStandards;
            this.grdOPStandards.Name = "grdOPStandards";
            this.grdOPStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.risluT112LeafID,
            this.riieSOPImage,
            this.riicbManOrMachine,
            this.riluT112LeafID});
            this.grdOPStandards.Size = new System.Drawing.Size(638, 426);
            this.grdOPStandards.TabIndex = 2;
            this.grdOPStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOPStandards});
            // 
            // grdvOPStandards
            // 
            this.grdvOPStandards.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvOPStandards.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvOPStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvOPStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvOPStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvOPStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvOPStandards.Appearance.Row.Options.UseFont = true;
            this.grdvOPStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnToolingOrdinal,
            this.grdclmnStepNo,
            this.grdclmnResourceNo,
            this.grdclmnManOrMachine,
            this.grdclmnT112LeafID,
            this.grdclmnJobElementDesc,
            this.grdclmnStartTimeOffset,
            this.grdclmnEndTimeOffset,
            this.grdclmnSOPImage,
            this.grdclmnReference});
            this.grdvOPStandards.GridControl = this.grdOPStandards;
            this.grdvOPStandards.Name = "grdvOPStandards";
            this.grdvOPStandards.OptionsBehavior.Editable = false;
            this.grdvOPStandards.OptionsSelection.InvertSelection = true;
            this.grdvOPStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvOPStandards.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvOPStandards.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvOPStandards.OptionsView.EnableAppearanceOddRow = true;
            this.grdvOPStandards.OptionsView.RowAutoHeight = true;
            this.grdvOPStandards.OptionsView.ShowGroupPanel = false;
            this.grdvOPStandards.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvOPStandards_InitNewRow);
            this.grdvOPStandards.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grdvOPStandards_RowDeleted);
            this.grdvOPStandards.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdvOPStandards_RowUpdated);
            // 
            // grdclmnToolingOrdinal
            // 
            this.grdclmnToolingOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnToolingOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnToolingOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnToolingOrdinal.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnToolingOrdinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnToolingOrdinal.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnToolingOrdinal.Caption = "序号";
            this.grdclmnToolingOrdinal.FieldName = "Level";
            this.grdclmnToolingOrdinal.Name = "grdclmnToolingOrdinal";
            this.grdclmnToolingOrdinal.Visible = true;
            this.grdclmnToolingOrdinal.VisibleIndex = 0;
            this.grdclmnToolingOrdinal.Width = 100;
            // 
            // grdclmnStepNo
            // 
            this.grdclmnStepNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnStepNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnStepNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStepNo.Caption = "工序步骤序号";
            this.grdclmnStepNo.FieldName = "StepNo";
            this.grdclmnStepNo.Name = "grdclmnStepNo";
            this.grdclmnStepNo.Visible = true;
            this.grdclmnStepNo.VisibleIndex = 1;
            // 
            // grdclmnResourceNo
            // 
            this.grdclmnResourceNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnResourceNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnResourceNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnResourceNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnResourceNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnResourceNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnResourceNo.Caption = "生产资源序号";
            this.grdclmnResourceNo.FieldName = "T200LeafID";
            this.grdclmnResourceNo.Name = "grdclmnResourceNo";
            this.grdclmnResourceNo.Visible = true;
            this.grdclmnResourceNo.VisibleIndex = 2;
            this.grdclmnResourceNo.Width = 180;
            // 
            // grdclmnManOrMachine
            // 
            this.grdclmnManOrMachine.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnManOrMachine.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnManOrMachine.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnManOrMachine.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnManOrMachine.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnManOrMachine.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnManOrMachine.Caption = "人或设备";
            this.grdclmnManOrMachine.ColumnEdit = this.riicbManOrMachine;
            this.grdclmnManOrMachine.FieldName = "ManOrMachine";
            this.grdclmnManOrMachine.Name = "grdclmnManOrMachine";
            this.grdclmnManOrMachine.Visible = true;
            this.grdclmnManOrMachine.VisibleIndex = 3;
            this.grdclmnManOrMachine.Width = 95;
            // 
            // riicbManOrMachine
            // 
            this.riicbManOrMachine.AutoHeight = false;
            this.riicbManOrMachine.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riicbManOrMachine.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("人", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("设备", 2, -1)});
            this.riicbManOrMachine.Name = "riicbManOrMachine";
            // 
            // grdclmnT112LeafID
            // 
            this.grdclmnT112LeafID.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT112LeafID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT112LeafID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT112LeafID.Caption = "动作要素";
            this.grdclmnT112LeafID.ColumnEdit = this.riluT112LeafID;
            this.grdclmnT112LeafID.FieldName = "T112LeafID";
            this.grdclmnT112LeafID.Name = "grdclmnT112LeafID";
            this.grdclmnT112LeafID.Visible = true;
            this.grdclmnT112LeafID.VisibleIndex = 4;
            // 
            // riluT112LeafID
            // 
            this.riluT112LeafID.AutoHeight = false;
            this.riluT112LeafID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.riluT112LeafID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluT112LeafID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LeafName", "Name13")});
            this.riluT112LeafID.Name = "riluT112LeafID";
            this.riluT112LeafID.NullText = "";
            this.riluT112LeafID.ShowFooter = false;
            this.riluT112LeafID.ShowHeader = false;
            this.riluT112LeafID.ValueMember = "LeafID";
            // 
            // grdclmnJobElementDesc
            // 
            this.grdclmnJobElementDesc.Caption = "描述";
            this.grdclmnJobElementDesc.FieldName = "JobElementDesc";
            this.grdclmnJobElementDesc.Name = "grdclmnJobElementDesc";
            this.grdclmnJobElementDesc.Visible = true;
            this.grdclmnJobElementDesc.VisibleIndex = 5;
            // 
            // grdclmnStartTimeOffset
            // 
            this.grdclmnStartTimeOffset.Caption = "开始时间偏移量(ms)";
            this.grdclmnStartTimeOffset.FieldName = "StartTimeOffset";
            this.grdclmnStartTimeOffset.Name = "grdclmnStartTimeOffset";
            this.grdclmnStartTimeOffset.Visible = true;
            this.grdclmnStartTimeOffset.VisibleIndex = 6;
            // 
            // grdclmnEndTimeOffset
            // 
            this.grdclmnEndTimeOffset.Caption = "结束时间偏移量(ms)";
            this.grdclmnEndTimeOffset.FieldName = "EndTimeOffset";
            this.grdclmnEndTimeOffset.Name = "grdclmnEndTimeOffset";
            this.grdclmnEndTimeOffset.Visible = true;
            this.grdclmnEndTimeOffset.VisibleIndex = 7;
            // 
            // grdclmnSOPImage
            // 
            this.grdclmnSOPImage.Caption = "作业指导图像";
            this.grdclmnSOPImage.ColumnEdit = this.riieSOPImage;
            this.grdclmnSOPImage.FieldName = "SOPImage";
            this.grdclmnSOPImage.Name = "grdclmnSOPImage";
            this.grdclmnSOPImage.Visible = true;
            this.grdclmnSOPImage.VisibleIndex = 8;
            // 
            // riieSOPImage
            // 
            this.riieSOPImage.AutoHeight = false;
            this.riieSOPImage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riieSOPImage.Name = "riieSOPImage";
            // 
            // grdclmnReference
            // 
            this.grdclmnReference.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnReference.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnReference.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnReference.Caption = "是否模板数据";
            this.grdclmnReference.FieldName = "Reference";
            this.grdclmnReference.Name = "grdclmnReference";
            // 
            // risluT112LeafID
            // 
            this.risluT112LeafID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.risluT112LeafID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluT112LeafID.DisplayMember = "LeafName";
            this.risluT112LeafID.Name = "risluT112LeafID";
            this.risluT112LeafID.NullText = "";
            this.risluT112LeafID.ValueMember = "LeafID";
            this.risluT112LeafID.View = this.risluT112LeafIDView;
            // 
            // risluT112LeafIDView
            // 
            this.risluT112LeafIDView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnLeafCode,
            this.grdclmnLeafName});
            this.risluT112LeafIDView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.risluT112LeafIDView.Name = "risluT112LeafIDView";
            this.risluT112LeafIDView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.risluT112LeafIDView.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnLeafCode
            // 
            this.grdclmnLeafCode.Caption = "动作要素代码";
            this.grdclmnLeafCode.FieldName = "Code";
            this.grdclmnLeafCode.Name = "grdclmnLeafCode";
            // 
            // grdclmnLeafName
            // 
            this.grdclmnLeafName.Caption = "动作要素名称";
            this.grdclmnLeafName.FieldName = "LeafName";
            this.grdclmnLeafName.Name = "grdclmnLeafName";
            // 
            // frmOPStandardProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmOPStandardProperties";
            this.PropertiesType = "生产作业标准";
            this.RowSetID = 10;
            this.Text = "生产作业标准属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOPStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOPStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicbManOrMachine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT112LeafID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riieSOPImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT112LeafID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT112LeafIDView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdOPStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOPStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToolingOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnResourceNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluT112LeafID;
        private DevExpress.XtraGrid.Views.Grid.GridView risluT112LeafIDView;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnManOrMachine;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT112LeafID;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSOPImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit riieSOPImage;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStepNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicbManOrMachine;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnJobElementDesc;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStartTimeOffset;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEndTimeOffset;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluT112LeafID;
    }
}
