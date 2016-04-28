namespace IRAP.Client.GUI.MDM
{
    partial class frmFailureModeProperties
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
            this.grdclmnToolingOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT118LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluT118LeafID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.grdvT118LeafIDView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnLeafCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLeafName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT216LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluSourceOperation = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.risluSourceOperationView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT118LeafID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvT118LeafIDView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluSourceOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluSourceOperationView)).BeginInit();
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
            this.lblTitle.Text = "失效模式清单";
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
            this.panelControl1.TabIndex = 10;
            // 
            // grdStandards
            // 
            this.grdStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStandards.Location = new System.Drawing.Point(7, 7);
            this.grdStandards.MainView = this.grdvStandards;
            this.grdStandards.Name = "grdStandards";
            this.grdStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.risluT118LeafID,
            this.risluSourceOperation});
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
            this.grdclmnToolingOrdinal,
            this.grdclmnT118LeafID,
            this.grdclmnT216LeafID,
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
            // grdclmnT118LeafID
            // 
            this.grdclmnT118LeafID.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT118LeafID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT118LeafID.Caption = "产品失效模式";
            this.grdclmnT118LeafID.ColumnEdit = this.risluT118LeafID;
            this.grdclmnT118LeafID.FieldName = "T118LeafID";
            this.grdclmnT118LeafID.Name = "grdclmnT118LeafID";
            this.grdclmnT118LeafID.Visible = true;
            this.grdclmnT118LeafID.VisibleIndex = 1;
            // 
            // risluT118LeafID
            // 
            this.risluT118LeafID.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.risluT118LeafID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluT118LeafID.DisplayMember = "Name";
            this.risluT118LeafID.Name = "risluT118LeafID";
            this.risluT118LeafID.NullText = "";
            this.risluT118LeafID.ValueMember = "LeafID";
            this.risluT118LeafID.View = this.grdvT118LeafIDView;
            // 
            // grdvT118LeafIDView
            // 
            this.grdvT118LeafIDView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnLeafCode,
            this.grdclmnLeafName});
            this.grdvT118LeafIDView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grdvT118LeafIDView.Name = "grdvT118LeafIDView";
            this.grdvT118LeafIDView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvT118LeafIDView.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnLeafCode
            // 
            this.grdclmnLeafCode.Caption = "失效模式编号";
            this.grdclmnLeafCode.FieldName = "Code";
            this.grdclmnLeafCode.Name = "grdclmnLeafCode";
            this.grdclmnLeafCode.Visible = true;
            this.grdclmnLeafCode.VisibleIndex = 0;
            // 
            // grdclmnLeafName
            // 
            this.grdclmnLeafName.Caption = "失效模式名称";
            this.grdclmnLeafName.FieldName = "LeafName";
            this.grdclmnLeafName.Name = "grdclmnLeafName";
            this.grdclmnLeafName.Visible = true;
            this.grdclmnLeafName.VisibleIndex = 1;
            // 
            // grdclmnT216LeafID
            // 
            this.grdclmnT216LeafID.Caption = "根源工序";
            this.grdclmnT216LeafID.ColumnEdit = this.risluSourceOperation;
            this.grdclmnT216LeafID.FieldName = "T216LeafID";
            this.grdclmnT216LeafID.Name = "grdclmnT216LeafID";
            this.grdclmnT216LeafID.Visible = true;
            this.grdclmnT216LeafID.VisibleIndex = 2;
            // 
            // risluSourceOperation
            // 
            this.risluSourceOperation.AutoHeight = false;
            this.risluSourceOperation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluSourceOperation.DisplayMember = "T216Name";
            this.risluSourceOperation.Name = "risluSourceOperation";
            this.risluSourceOperation.NullText = "";
            this.risluSourceOperation.ValueMember = "T216Leaf";
            this.risluSourceOperation.View = this.risluSourceOperationView;
            // 
            // risluSourceOperationView
            // 
            this.risluSourceOperationView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.risluSourceOperationView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.risluSourceOperationView.Name = "risluSourceOperationView";
            this.risluSourceOperationView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.risluSourceOperationView.OptionsView.ShowGroupPanel = false;
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "工序代码";
            this.gridColumn1.FieldName = "T216Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "工序名称";
            this.gridColumn2.FieldName = "T216Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // frmFailureModeProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmFailureModeProperties";
            this.PropertiesType = "失效模式清单";
            this.RowSetID = 9;
            this.Text = "失效模式清单行集属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluT118LeafID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvT118LeafIDView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluSourceOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluSourceOperationView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToolingOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT118LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluT118LeafID;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvT118LeafIDView;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT216LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluSourceOperation;
        private DevExpress.XtraGrid.Views.Grid.GridView risluSourceOperationView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
