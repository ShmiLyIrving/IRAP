namespace IRAP.Client.GUI.MDM
{
    partial class frmPokaYokeRuleProperties
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
            this.grdclmnT230LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluT230Name = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnControlLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnControlLimit_Low = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnControlLimit_High = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUnitOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnReference = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT230Name)).BeginInit();
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
            this.lblTitle.Text = "生产防错规则";
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
            this.panelControl1.TabIndex = 8;
            // 
            // grdStandards
            // 
            this.grdStandards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStandards.Location = new System.Drawing.Point(7, 7);
            this.grdStandards.MainView = this.grdvStandards;
            this.grdStandards.Name = "grdStandards";
            this.grdStandards.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riluT230Name});
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
            this.grdclmnT230LeafID,
            this.grdclmnControlLevel,
            this.grdclmnControlLimit_Low,
            this.grdclmnControlLimit_High,
            this.grdclmnUnitOfMeasure,
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
            // grdclmnT230LeafID
            // 
            this.grdclmnT230LeafID.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT230LeafID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT230LeafID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT230LeafID.Caption = "防错规则";
            this.grdclmnT230LeafID.ColumnEdit = this.riluT230Name;
            this.grdclmnT230LeafID.FieldName = "T230LeafID";
            this.grdclmnT230LeafID.Name = "grdclmnT230LeafID";
            this.grdclmnT230LeafID.Visible = true;
            this.grdclmnT230LeafID.VisibleIndex = 1;
            this.grdclmnT230LeafID.Width = 180;
            // 
            // riluT230Name
            // 
            this.riluT230Name.AutoHeight = false;
            this.riluT230Name.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.riluT230Name.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluT230Name.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LeafName", "防错规则名称")});
            this.riluT230Name.Name = "riluT230Name";
            this.riluT230Name.NullText = "";
            this.riluT230Name.ShowFooter = false;
            this.riluT230Name.ShowHeader = false;
            this.riluT230Name.ValueMember = "LeafID";
            // 
            // grdclmnControlLevel
            // 
            this.grdclmnControlLevel.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnControlLevel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnControlLevel.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnControlLevel.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnControlLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnControlLevel.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnControlLevel.Caption = "防错控制级别";
            this.grdclmnControlLevel.FieldName = "ControlLevel";
            this.grdclmnControlLevel.Name = "grdclmnControlLevel";
            this.grdclmnControlLevel.Visible = true;
            this.grdclmnControlLevel.VisibleIndex = 2;
            // 
            // grdclmnControlLimit_Low
            // 
            this.grdclmnControlLimit_Low.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnControlLimit_Low.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnControlLimit_Low.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnControlLimit_Low.Caption = "控制低限值";
            this.grdclmnControlLimit_Low.FieldName = "ControlLimit_Low";
            this.grdclmnControlLimit_Low.Name = "grdclmnControlLimit_Low";
            this.grdclmnControlLimit_Low.Visible = true;
            this.grdclmnControlLimit_Low.VisibleIndex = 3;
            // 
            // grdclmnControlLimit_High
            // 
            this.grdclmnControlLimit_High.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnControlLimit_High.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnControlLimit_High.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnControlLimit_High.Caption = "控制高限值";
            this.grdclmnControlLimit_High.FieldName = "ControlLimit_High";
            this.grdclmnControlLimit_High.Name = "grdclmnControlLimit_High";
            this.grdclmnControlLimit_High.Visible = true;
            this.grdclmnControlLimit_High.VisibleIndex = 4;
            // 
            // grdclmnUnitOfMeasure
            // 
            this.grdclmnUnitOfMeasure.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnUnitOfMeasure.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUnitOfMeasure.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnUnitOfMeasure.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnUnitOfMeasure.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUnitOfMeasure.Caption = "计量单位";
            this.grdclmnUnitOfMeasure.FieldName = "UnitOfMeasure";
            this.grdclmnUnitOfMeasure.Name = "grdclmnUnitOfMeasure";
            this.grdclmnUnitOfMeasure.Visible = true;
            this.grdclmnUnitOfMeasure.VisibleIndex = 5;
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
            // frmPokaYokeRuleProperties
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(759, 503);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmPokaYokeRuleProperties";
            this.PropertiesType = "生产防错规则";
            this.RowSetID = 14;
            this.Text = "生产防错规则行集属性";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStandards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT230Name)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdStandards;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStandards;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT230LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluT230Name;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnControlLimit_Low;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnControlLevel;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnControlLimit_High;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUnitOfMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnReference;
    }
}
