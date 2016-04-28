namespace IRAP.Client.GUI.MDM
{
    partial class frmToolingStandardProperties
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
            this.grdToolingStandards = new DevExpress.XtraGrid.GridControl();
            this.grdvToolingStandards = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnToolingOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnToolingModelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluToolingModelName = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.risluToolingNameView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnLeafCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLeafName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLifeControlMode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluLifeControlMode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnLifeLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPokaYokeRequired = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilcPokaYokeRequired = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdToolingStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvToolingStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluToolingModelName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluToolingNameView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluLifeControlMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilcPokaYokeRequired)).BeginInit();
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
            this.lblTitle.Text = "工装使用标准";
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
            this.panelControl1.Controls.Add(this.grdToolingStandards);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 63);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(652, 440);
            this.panelControl1.TabIndex = 6;
            // 
            // grdToolingStandards
            // 
            this.grdToolingStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdToolingStandards.Location = new System.Drawing.Point(7, 7);
            this.grdToolingStandards.MainView = this.grdvToolingStandards;
            this.grdToolingStandards.Name = "grdToolingStandards";
            this.grdToolingStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riluLifeControlMode,
            this.rilcPokaYokeRequired,
            this.risluToolingModelName});
            this.grdToolingStandards.Size = new System.Drawing.Size(638, 426);
            this.grdToolingStandards.TabIndex = 2;
            this.grdToolingStandards.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvToolingStandards});
            // 
            // grdvToolingStandards
            // 
            this.grdvToolingStandards.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvToolingStandards.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvToolingStandards.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvToolingStandards.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvToolingStandards.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvToolingStandards.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvToolingStandards.Appearance.Row.Options.UseFont = true;
            this.grdvToolingStandards.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnToolingOrdinal,
            this.grdclmnToolingModelName,
            this.grdclmnLifeControlMode,
            this.grdclmnLifeLimit,
            this.grdclmnPokaYokeRequired,
            this.grdclmnReference});
            this.grdvToolingStandards.GridControl = this.grdToolingStandards;
            this.grdvToolingStandards.Name = "grdvToolingStandards";
            this.grdvToolingStandards.OptionsBehavior.Editable = false;
            this.grdvToolingStandards.OptionsSelection.InvertSelection = true;
            this.grdvToolingStandards.OptionsView.ColumnAutoWidth = false;
            this.grdvToolingStandards.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvToolingStandards.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvToolingStandards.OptionsView.EnableAppearanceOddRow = true;
            this.grdvToolingStandards.OptionsView.RowAutoHeight = true;
            this.grdvToolingStandards.OptionsView.ShowGroupPanel = false;
            this.grdvToolingStandards.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvToolingStandards_InitNewRow);
            this.grdvToolingStandards.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grdvToolingStandards_RowDeleted);
            this.grdvToolingStandards.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdvToolingStandards_RowUpdated);
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
            // grdclmnToolingModelName
            // 
            this.grdclmnToolingModelName.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnToolingModelName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnToolingModelName.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnToolingModelName.Caption = "工装名称";
            this.grdclmnToolingModelName.ColumnEdit = this.risluToolingModelName;
            this.grdclmnToolingModelName.FieldName = "T210LeafID";
            this.grdclmnToolingModelName.Name = "grdclmnToolingModelName";
            this.grdclmnToolingModelName.Visible = true;
            this.grdclmnToolingModelName.VisibleIndex = 1;
            this.grdclmnToolingModelName.Width = 180;
            // 
            // risluToolingModelName
            // 
            this.risluToolingModelName.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.risluToolingModelName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluToolingModelName.DisplayMember = "CodeAndName";
            this.risluToolingModelName.Name = "risluToolingModelName";
            this.risluToolingModelName.NullText = "";
            this.risluToolingModelName.ValueMember = "LeafID";
            this.risluToolingModelName.View = this.risluToolingNameView;
            // 
            // risluToolingNameView
            // 
            this.risluToolingNameView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnLeafCode,
            this.grdclmnLeafName});
            this.risluToolingNameView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.risluToolingNameView.Name = "risluToolingNameView";
            this.risluToolingNameView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.risluToolingNameView.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnLeafCode
            // 
            this.grdclmnLeafCode.Caption = "工装代码";
            this.grdclmnLeafCode.FieldName = "Code";
            this.grdclmnLeafCode.Name = "grdclmnLeafCode";
            this.grdclmnLeafCode.Visible = true;
            this.grdclmnLeafCode.VisibleIndex = 0;
            // 
            // grdclmnLeafName
            // 
            this.grdclmnLeafName.Caption = "工装名称";
            this.grdclmnLeafName.FieldName = "LeafName";
            this.grdclmnLeafName.Name = "grdclmnLeafName";
            this.grdclmnLeafName.Visible = true;
            this.grdclmnLeafName.VisibleIndex = 1;
            // 
            // grdclmnLifeControlMode
            // 
            this.grdclmnLifeControlMode.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnLifeControlMode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnLifeControlMode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLifeControlMode.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnLifeControlMode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnLifeControlMode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLifeControlMode.Caption = "寿命控制方式";
            this.grdclmnLifeControlMode.ColumnEdit = this.riluLifeControlMode;
            this.grdclmnLifeControlMode.FieldName = "LifeControlMode";
            this.grdclmnLifeControlMode.Name = "grdclmnLifeControlMode";
            this.grdclmnLifeControlMode.Visible = true;
            this.grdclmnLifeControlMode.VisibleIndex = 2;
            this.grdclmnLifeControlMode.Width = 95;
            // 
            // riluLifeControlMode
            // 
            this.riluLifeControlMode.AutoHeight = false;
            this.riluLifeControlMode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluLifeControlMode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name12")});
            this.riluLifeControlMode.Name = "riluLifeControlMode";
            this.riluLifeControlMode.NullText = "";
            this.riluLifeControlMode.ShowFooter = false;
            this.riluLifeControlMode.ShowHeader = false;
            // 
            // grdclmnLifeLimit
            // 
            this.grdclmnLifeLimit.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnLifeLimit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnLifeLimit.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLifeLimit.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnLifeLimit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnLifeLimit.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnLifeLimit.Caption = "寿命限制";
            this.grdclmnLifeLimit.FieldName = "LifeLimit";
            this.grdclmnLifeLimit.Name = "grdclmnLifeLimit";
            this.grdclmnLifeLimit.Visible = true;
            this.grdclmnLifeLimit.VisibleIndex = 3;
            // 
            // grdclmnPokaYokeRequired
            // 
            this.grdclmnPokaYokeRequired.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPokaYokeRequired.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPokaYokeRequired.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPokaYokeRequired.Caption = "防错";
            this.grdclmnPokaYokeRequired.ColumnEdit = this.rilcPokaYokeRequired;
            this.grdclmnPokaYokeRequired.FieldName = "PokaYokeRequired";
            this.grdclmnPokaYokeRequired.Name = "grdclmnPokaYokeRequired";
            this.grdclmnPokaYokeRequired.Visible = true;
            this.grdclmnPokaYokeRequired.VisibleIndex = 4;
            // 
            // rilcPokaYokeRequired
            // 
            this.rilcPokaYokeRequired.AutoHeight = false;
            this.rilcPokaYokeRequired.Caption = "防错";
            this.rilcPokaYokeRequired.Name = "rilcPokaYokeRequired";
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
            // frmToolingStandardProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmToolingStandardProperties";
            this.PropertiesType = "工装使用标准";
            this.RowSetID = 4;
            this.Text = "工装使用标准属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdToolingStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvToolingStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluToolingModelName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluToolingNameView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluLifeControlMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilcPokaYokeRequired)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdToolingStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvToolingStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToolingOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToolingModelName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLifeControlMode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLifeLimit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPokaYokeRequired;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluLifeControlMode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rilcPokaYokeRequired;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluToolingModelName;
        private DevExpress.XtraGrid.Views.Grid.GridView risluToolingNameView;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafName;
    }
}
