namespace IRAP.Client.GUI.MDM
{
    partial class frmMethodDocumentProperties
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
            this.grdStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnStandardOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT186LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluT186LeafID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.grdvT186LeafIDView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribeFileName = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grdclmnFileSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnVersionNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnECorAlertCtrlNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnApprovedBy1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnApprovedBy2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnApprovedBy3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFileContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT186LeafID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvT186LeafIDView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeFileName)).BeginInit();
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
            this.lblTitle.Text = "工艺文档清单";
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
            this.panelControl1.Controls.Add(this.grdStandards);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 63);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(652, 440);
            this.panelControl1.TabIndex = 7;
            // 
            // grdStandards
            // 
            this.grdStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStandards.Location = new System.Drawing.Point(7, 7);
            this.grdStandards.MainView = this.grdvStandards;
            this.grdStandards.Name = "grdStandards";
            this.grdStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.risluT186LeafID,
            this.ribeFileName});
            this.grdStandards.Size = new System.Drawing.Size(638, 426);
            this.grdStandards.TabIndex = 2;
            this.grdStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvStandards});
            // 
            // grdvStandards
            // 
            this.grdvStandards.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvStandards.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvStandards.Appearance.Row.Options.UseFont = true;
            this.grdvStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnStandardOrdinal,
            this.grdclmnT186LeafID,
            this.grdclmnFileName,
            this.grdclmnFileSize,
            this.grdclmnVersionNo,
            this.grdclmnECorAlertCtrlNo,
            this.grdclmnApprovedBy1,
            this.grdclmnApprovedBy2,
            this.grdclmnApprovedBy3,
            this.grdclmnFileContent,
            this.grdclmnReference});
            this.grdvStandards.GridControl = this.grdStandards;
            this.grdvStandards.Name = "grdvStandards";
            this.grdvStandards.OptionsBehavior.Editable = false;
            this.grdvStandards.OptionsSelection.InvertSelection = true;
            this.grdvStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvStandards.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvStandards.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvStandards.OptionsView.EnableAppearanceOddRow = true;
            this.grdvStandards.OptionsView.RowAutoHeight = true;
            this.grdvStandards.OptionsView.ShowGroupPanel = false;
            this.grdvStandards.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvStandards_InitNewRow);
            this.grdvStandards.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grdvStandards_RowDeleted);
            this.grdvStandards.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdvStandards_RowUpdated);
            // 
            // grdclmnStandardOrdinal
            // 
            this.grdclmnStandardOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnStandardOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnStandardOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStandardOrdinal.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnStandardOrdinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnStandardOrdinal.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnStandardOrdinal.Caption = "序号";
            this.grdclmnStandardOrdinal.FieldName = "Level";
            this.grdclmnStandardOrdinal.Name = "grdclmnStandardOrdinal";
            this.grdclmnStandardOrdinal.Visible = true;
            this.grdclmnStandardOrdinal.VisibleIndex = 0;
            this.grdclmnStandardOrdinal.Width = 100;
            // 
            // grdclmnT186LeafID
            // 
            this.grdclmnT186LeafID.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT186LeafID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT186LeafID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT186LeafID.Caption = "文档类型";
            this.grdclmnT186LeafID.ColumnEdit = this.risluT186LeafID;
            this.grdclmnT186LeafID.FieldName = "T186LeafID";
            this.grdclmnT186LeafID.Name = "grdclmnT186LeafID";
            this.grdclmnT186LeafID.Visible = true;
            this.grdclmnT186LeafID.VisibleIndex = 1;
            this.grdclmnT186LeafID.Width = 180;
            // 
            // risluT186LeafID
            // 
            this.risluT186LeafID.AutoHeight = false;
            this.risluT186LeafID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.risluT186LeafID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluT186LeafID.DisplayMember = "CodeAndName";
            this.risluT186LeafID.Name = "risluT186LeafID";
            this.risluT186LeafID.NullText = "";
            this.risluT186LeafID.ValueMember = "LeafID";
            this.risluT186LeafID.View = this.grdvT186LeafIDView;
            // 
            // grdvT186LeafIDView
            // 
            this.grdvT186LeafIDView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.grdvT186LeafIDView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdvT186LeafIDView.Name = "grdvT186LeafIDView";
            this.grdvT186LeafIDView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvT186LeafIDView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "文件类型";
            this.gridColumn2.FieldName = "CodeAndName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // grdclmnFileName
            // 
            this.grdclmnFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnFileName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnFileName.Caption = "文件名";
            this.grdclmnFileName.ColumnEdit = this.ribeFileName;
            this.grdclmnFileName.FieldName = "FileName";
            this.grdclmnFileName.Name = "grdclmnFileName";
            this.grdclmnFileName.Visible = true;
            this.grdclmnFileName.VisibleIndex = 2;
            // 
            // ribeFileName
            // 
            this.ribeFileName.AutoHeight = false;
            this.ribeFileName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ribeFileName.Name = "ribeFileName";
            this.ribeFileName.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ribeFileName_ButtonPressed);
            // 
            // grdclmnFileSize
            // 
            this.grdclmnFileSize.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnFileSize.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnFileSize.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnFileSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnFileSize.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnFileSize.Caption = "文件大小";
            this.grdclmnFileSize.FieldName = "FileSize";
            this.grdclmnFileSize.Name = "grdclmnFileSize";
            this.grdclmnFileSize.Visible = true;
            this.grdclmnFileSize.VisibleIndex = 3;
            // 
            // grdclmnVersionNo
            // 
            this.grdclmnVersionNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnVersionNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnVersionNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnVersionNo.Caption = "版本号";
            this.grdclmnVersionNo.FieldName = "VersionNo";
            this.grdclmnVersionNo.Name = "grdclmnVersionNo";
            this.grdclmnVersionNo.Visible = true;
            this.grdclmnVersionNo.VisibleIndex = 4;
            // 
            // grdclmnECorAlertCtrlNo
            // 
            this.grdclmnECorAlertCtrlNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnECorAlertCtrlNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnECorAlertCtrlNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnECorAlertCtrlNo.Caption = "ECorAlertCtrlNo";
            this.grdclmnECorAlertCtrlNo.FieldName = "ECorAlertCtrlNo";
            this.grdclmnECorAlertCtrlNo.Name = "grdclmnECorAlertCtrlNo";
            this.grdclmnECorAlertCtrlNo.Visible = true;
            this.grdclmnECorAlertCtrlNo.VisibleIndex = 5;
            // 
            // grdclmnApprovedBy1
            // 
            this.grdclmnApprovedBy1.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnApprovedBy1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnApprovedBy1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnApprovedBy1.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnApprovedBy1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnApprovedBy1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnApprovedBy1.Caption = "批准人1";
            this.grdclmnApprovedBy1.FieldName = "ApprovedBy1";
            this.grdclmnApprovedBy1.Name = "grdclmnApprovedBy1";
            this.grdclmnApprovedBy1.Visible = true;
            this.grdclmnApprovedBy1.VisibleIndex = 6;
            // 
            // grdclmnApprovedBy2
            // 
            this.grdclmnApprovedBy2.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnApprovedBy2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnApprovedBy2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnApprovedBy2.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnApprovedBy2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnApprovedBy2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnApprovedBy2.Caption = "批准人2";
            this.grdclmnApprovedBy2.FieldName = "ApprovedBy2";
            this.grdclmnApprovedBy2.Name = "grdclmnApprovedBy2";
            this.grdclmnApprovedBy2.Visible = true;
            this.grdclmnApprovedBy2.VisibleIndex = 7;
            // 
            // grdclmnApprovedBy3
            // 
            this.grdclmnApprovedBy3.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnApprovedBy3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnApprovedBy3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnApprovedBy3.Caption = "批准人3";
            this.grdclmnApprovedBy3.FieldName = "Approvedby3";
            this.grdclmnApprovedBy3.Name = "grdclmnApprovedBy3";
            this.grdclmnApprovedBy3.Visible = true;
            this.grdclmnApprovedBy3.VisibleIndex = 8;
            // 
            // grdclmnFileContent
            // 
            this.grdclmnFileContent.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnFileContent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnFileContent.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnFileContent.Caption = "文件内容";
            this.grdclmnFileContent.FieldName = "FileContent";
            this.grdclmnFileContent.Name = "grdclmnFileContent";
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
            // openFileDialog
            // 
            this.openFileDialog.Filter = "所有文件(*.*)|*.*";
            this.openFileDialog.Title = "请选择工艺文档文件：";
            // 
            // frmMethodDocumentProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmMethodDocumentProperties";
            this.PropertiesType = "工艺文档清单";
            this.RowSetID = 15;
            this.Text = "工艺文档清单行集属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT186LeafID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvT186LeafIDView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeFileName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnStandardOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT186LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluT186LeafID;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvT186LeafIDView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFileName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFileSize;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnVersionNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnECorAlertCtrlNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnApprovedBy1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnApprovedBy2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnApprovedBy3;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFileContent;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribeFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
