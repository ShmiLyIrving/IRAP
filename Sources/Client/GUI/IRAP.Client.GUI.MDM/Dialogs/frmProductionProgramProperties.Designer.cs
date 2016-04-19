namespace IRAP.Client.GUI.MDM
{
    partial class frmProductionProgramProperties
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
            this.grdProductionPrograms = new DevExpress.XtraGrid.GridControl();
            this.grdvProductionPrograms = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnToolingOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnToolingModelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluPrograms = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.risluProgramsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnLeafCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLeafName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFlexibleLoaded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilcFlexibleLoaded = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdclmnPokaYokeRequired = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rilcPokaYokeRequired = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductionPrograms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvProductionPrograms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluPrograms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluProgramsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilcFlexibleLoaded)).BeginInit();
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
            this.lblTitle.Text = "生产程序标准";
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
            this.panelControl1.Controls.Add(this.grdProductionPrograms);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 63);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(652, 440);
            this.panelControl1.TabIndex = 7;
            // 
            // grdProductionPrograms
            // 
            this.grdProductionPrograms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProductionPrograms.Location = new System.Drawing.Point(7, 7);
            this.grdProductionPrograms.MainView = this.grdvProductionPrograms;
            this.grdProductionPrograms.Name = "grdProductionPrograms";
            this.grdProductionPrograms.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rilcPokaYokeRequired,
            this.risluPrograms,
            this.rilcFlexibleLoaded});
            this.grdProductionPrograms.Size = new System.Drawing.Size(638, 426);
            this.grdProductionPrograms.TabIndex = 2;
            this.grdProductionPrograms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvProductionPrograms});
            // 
            // grdvProductionPrograms
            // 
            this.grdvProductionPrograms.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvProductionPrograms.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvProductionPrograms.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvProductionPrograms.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvProductionPrograms.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvProductionPrograms.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvProductionPrograms.Appearance.Row.Options.UseFont = true;
            this.grdvProductionPrograms.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnToolingOrdinal,
            this.grdclmnToolingModelName,
            this.grdclmnFlexibleLoaded,
            this.grdclmnPokaYokeRequired,
            this.grdclmnReference});
            this.grdvProductionPrograms.GridControl = this.grdProductionPrograms;
            this.grdvProductionPrograms.Name = "grdvProductionPrograms";
            this.grdvProductionPrograms.OptionsBehavior.Editable = false;
            this.grdvProductionPrograms.OptionsSelection.InvertSelection = true;
            this.grdvProductionPrograms.OptionsView.ColumnAutoWidth = false;
            this.grdvProductionPrograms.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvProductionPrograms.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvProductionPrograms.OptionsView.EnableAppearanceOddRow = true;
            this.grdvProductionPrograms.OptionsView.RowAutoHeight = true;
            this.grdvProductionPrograms.OptionsView.ShowGroupPanel = false;
            this.grdvProductionPrograms.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvProductionPrograms_InitNewRow);
            this.grdvProductionPrograms.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grdvProductionPrograms_RowDeleted);
            this.grdvProductionPrograms.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdvProductionPrograms_RowUpdated);
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
            this.grdclmnToolingModelName.Caption = "生产程序";
            this.grdclmnToolingModelName.ColumnEdit = this.risluPrograms;
            this.grdclmnToolingModelName.FieldName = "T200LeafID";
            this.grdclmnToolingModelName.Name = "grdclmnToolingModelName";
            this.grdclmnToolingModelName.Visible = true;
            this.grdclmnToolingModelName.VisibleIndex = 1;
            this.grdclmnToolingModelName.Width = 180;
            // 
            // risluPrograms
            // 
            this.risluPrograms.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.risluPrograms.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluPrograms.DisplayMember = "Name";
            this.risluPrograms.Name = "risluPrograms";
            this.risluPrograms.NullText = "";
            this.risluPrograms.ValueMember = "LeafID";
            this.risluPrograms.View = this.risluProgramsView;
            // 
            // risluProgramsView
            // 
            this.risluProgramsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnLeafCode,
            this.grdclmnLeafName});
            this.risluProgramsView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.risluProgramsView.Name = "risluProgramsView";
            this.risluProgramsView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.risluProgramsView.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnLeafCode
            // 
            this.grdclmnLeafCode.Caption = "生产程序名";
            this.grdclmnLeafCode.FieldName = "Code";
            this.grdclmnLeafCode.Name = "grdclmnLeafCode";
            // 
            // grdclmnLeafName
            // 
            this.grdclmnLeafName.Caption = "生产程序描述";
            this.grdclmnLeafName.FieldName = "LeafName";
            this.grdclmnLeafName.Name = "grdclmnLeafName";
            // 
            // grdclmnFlexibleLoaded
            // 
            this.grdclmnFlexibleLoaded.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnFlexibleLoaded.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnFlexibleLoaded.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnFlexibleLoaded.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnFlexibleLoaded.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnFlexibleLoaded.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnFlexibleLoaded.Caption = "支持柔性加载";
            this.grdclmnFlexibleLoaded.ColumnEdit = this.rilcFlexibleLoaded;
            this.grdclmnFlexibleLoaded.FieldName = "FlexibleLoaded";
            this.grdclmnFlexibleLoaded.Name = "grdclmnFlexibleLoaded";
            this.grdclmnFlexibleLoaded.Visible = true;
            this.grdclmnFlexibleLoaded.VisibleIndex = 2;
            this.grdclmnFlexibleLoaded.Width = 95;
            // 
            // rilcFlexibleLoaded
            // 
            this.rilcFlexibleLoaded.AutoHeight = false;
            this.rilcFlexibleLoaded.Caption = "支持";
            this.rilcFlexibleLoaded.Name = "rilcFlexibleLoaded";
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
            this.grdclmnPokaYokeRequired.VisibleIndex = 3;
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
            // frmProductionProgramProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmProductionProgramProperties";
            this.PropertiesType = "生产程序标准";
            this.RowSetID = 8;
            this.Text = "生产程序标准属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProductionPrograms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvProductionPrograms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluPrograms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluProgramsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilcFlexibleLoaded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rilcPokaYokeRequired)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdProductionPrograms;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvProductionPrograms;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToolingOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToolingModelName;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluPrograms;
        private DevExpress.XtraGrid.Views.Grid.GridView risluProgramsView;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLeafName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFlexibleLoaded;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPokaYokeRequired;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rilcPokaYokeRequired;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rilcFlexibleLoaded;
    }
}
