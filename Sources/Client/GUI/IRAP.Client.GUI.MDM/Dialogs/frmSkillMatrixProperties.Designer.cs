namespace IRAP.Client.GUI.MDM
{
    partial class frmSkillMatrixProperties
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
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluUserCode = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.risluUserCodeView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQualificationLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riicQualificationLevel = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluUserCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluUserCodeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicQualificationLevel)).BeginInit();
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
            this.lblTitle.Text = "员工技能矩阵";
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
            this.panelControl1.TabIndex = 9;
            // 
            // grdStandards
            // 
            this.grdStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStandards.Location = new System.Drawing.Point(7, 7);
            this.grdStandards.MainView = this.grdvStandards;
            this.grdStandards.Name = "grdStandards";
            this.grdStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riicQualificationLevel,
            this.risluUserCode});
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
            this.grdclmnOrdinal,
            this.grdclmnUserCode,
            this.grdclmnQualificationLevel,
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
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.Caption = "序号";
            this.grdclmnOrdinal.FieldName = "Level";
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
            this.grdclmnOrdinal.Width = 100;
            // 
            // grdclmnUserCode
            // 
            this.grdclmnUserCode.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnUserCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnUserCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUserCode.Caption = "操作工";
            this.grdclmnUserCode.ColumnEdit = this.risluUserCode;
            this.grdclmnUserCode.FieldName = "UserCode";
            this.grdclmnUserCode.Name = "grdclmnUserCode";
            this.grdclmnUserCode.Visible = true;
            this.grdclmnUserCode.VisibleIndex = 1;
            this.grdclmnUserCode.Width = 180;
            // 
            // risluUserCode
            // 
            this.risluUserCode.AutoHeight = false;
            this.risluUserCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluUserCode.DisplayMember = "CodeAndName";
            this.risluUserCode.Name = "risluUserCode";
            this.risluUserCode.NullText = "";
            this.risluUserCode.ValueMember = "UserCode";
            this.risluUserCode.View = this.risluUserCodeView;
            // 
            // risluUserCodeView
            // 
            this.risluUserCodeView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.risluUserCodeView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.risluUserCodeView.Name = "risluUserCodeView";
            this.risluUserCodeView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.risluUserCodeView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "用户号";
            this.gridColumn1.FieldName = "UserCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "用户名称";
            this.gridColumn2.FieldName = "UserName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "性别";
            this.gridColumn3.FieldName = "Gender";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "机构";
            this.gridColumn4.FieldName = "AgencyName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "角色";
            this.gridColumn5.FieldName = "RoleName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // grdclmnQualificationLevel
            // 
            this.grdclmnQualificationLevel.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQualificationLevel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnQualificationLevel.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQualificationLevel.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnQualificationLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnQualificationLevel.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQualificationLevel.Caption = "技能等级";
            this.grdclmnQualificationLevel.ColumnEdit = this.riicQualificationLevel;
            this.grdclmnQualificationLevel.FieldName = "QualificationLevel";
            this.grdclmnQualificationLevel.Name = "grdclmnQualificationLevel";
            this.grdclmnQualificationLevel.Visible = true;
            this.grdclmnQualificationLevel.VisibleIndex = 2;
            // 
            // riicQualificationLevel
            // 
            this.riicQualificationLevel.AutoHeight = false;
            this.riicQualificationLevel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riicQualificationLevel.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("优秀", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("老练", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("良好", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("合格", 4, -1)});
            this.riicQualificationLevel.Name = "riicQualificationLevel";
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
            // frmSkillMatrixProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmSkillMatrixProperties";
            this.PropertiesType = "员工技能矩阵";
            this.RowSetID = 16;
            this.Text = "员工技能矩阵行集属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluUserCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluUserCodeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicQualificationLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQualificationLevel;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicQualificationLevel;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluUserCode;
        private DevExpress.XtraGrid.Views.Grid.GridView risluUserCodeView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}
