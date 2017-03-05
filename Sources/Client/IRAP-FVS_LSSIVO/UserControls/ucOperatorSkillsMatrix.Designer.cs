namespace IRAP_FVS_LSSIVO.UserControls
{
    partial class ucOperatorSkillsMatrix
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
            this.grdclmnQualificationLevel1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUserName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQualificationLevel2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUserName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblWorkUnit = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdOperatorSkillMatrixs = new DevExpress.XtraGrid.GridControl();
            this.grdvOperatorSkillMatrixs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnT216Name1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT216Name2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vgrdOperatorSkills = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowT216Name = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUserName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOperatorSkillMatrixs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOperatorSkillMatrixs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdOperatorSkills)).BeginInit();
            this.SuspendLayout();
            // 
            // grdclmnQualificationLevel1
            // 
            this.grdclmnQualificationLevel1.Caption = "QualificationLevel1";
            this.grdclmnQualificationLevel1.FieldName = "QualificationLevel1";
            this.grdclmnQualificationLevel1.Name = "grdclmnQualificationLevel1";
            // 
            // grdclmnUserName1
            // 
            this.grdclmnUserName1.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnUserName1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnUserName1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUserName1.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnUserName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnUserName1.Caption = "姓名";
            this.grdclmnUserName1.FieldName = "UserName1";
            this.grdclmnUserName1.Name = "grdclmnUserName1";
            this.grdclmnUserName1.Visible = true;
            this.grdclmnUserName1.VisibleIndex = 1;
            // 
            // grdclmnQualificationLevel2
            // 
            this.grdclmnQualificationLevel2.Caption = "QualificationLevel2";
            this.grdclmnQualificationLevel2.FieldName = "QualificationLevel2";
            this.grdclmnQualificationLevel2.Name = "grdclmnQualificationLevel2";
            // 
            // grdclmnUserName2
            // 
            this.grdclmnUserName2.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnUserName2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnUserName2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUserName2.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnUserName2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnUserName2.Caption = "姓名";
            this.grdclmnUserName2.FieldName = "UserName2";
            this.grdclmnUserName2.Name = "grdclmnUserName2";
            this.grdclmnUserName2.Visible = true;
            this.grdclmnUserName2.VisibleIndex = 3;
            // 
            // lblWorkUnit
            // 
            this.lblWorkUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorkUnit.AutoSize = true;
            this.lblWorkUnit.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkUnit.Location = new System.Drawing.Point(13, 11);
            this.lblWorkUnit.Name = "lblWorkUnit";
            this.lblWorkUnit.Size = new System.Drawing.Size(63, 14);
            this.lblWorkUnit.TabIndex = 9;
            this.lblWorkUnit.Text = "上岗资质";
            this.lblWorkUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::IRAP_FVS_LSSIVO.Properties.Resources.red;
            this.pictureBox1.Location = new System.Drawing.Point(371, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 14);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(392, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "培训";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImage = global::IRAP_FVS_LSSIVO.Properties.Resources.yellow;
            this.pictureBox2.Location = new System.Drawing.Point(444, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 14);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(465, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "黄卡";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdOperatorSkillMatrixs
            // 
            this.grdOperatorSkillMatrixs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOperatorSkillMatrixs.Location = new System.Drawing.Point(8, 31);
            this.grdOperatorSkillMatrixs.MainView = this.grdvOperatorSkillMatrixs;
            this.grdOperatorSkillMatrixs.Name = "grdOperatorSkillMatrixs";
            this.grdOperatorSkillMatrixs.Size = new System.Drawing.Size(496, 268);
            this.grdOperatorSkillMatrixs.TabIndex = 14;
            this.grdOperatorSkillMatrixs.TabStop = false;
            this.grdOperatorSkillMatrixs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOperatorSkillMatrixs});
            this.grdOperatorSkillMatrixs.Visible = false;
            // 
            // grdvOperatorSkillMatrixs
            // 
            this.grdvOperatorSkillMatrixs.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvOperatorSkillMatrixs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvOperatorSkillMatrixs.Appearance.Row.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvOperatorSkillMatrixs.Appearance.Row.Options.UseFont = true;
            this.grdvOperatorSkillMatrixs.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grdvOperatorSkillMatrixs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnT216Name1,
            this.grdclmnUserName1,
            this.grdclmnT216Name2,
            this.grdclmnUserName2,
            this.grdclmnQualificationLevel1,
            this.grdclmnQualificationLevel2});
            this.grdvOperatorSkillMatrixs.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            gridFormatRule1.Column = this.grdclmnQualificationLevel1;
            gridFormatRule1.ColumnApplyTo = this.grdclmnUserName1;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = 2;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Column = this.grdclmnQualificationLevel1;
            gridFormatRule2.ColumnApplyTo = this.grdclmnUserName1;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.Red;
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = 3;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.Column = this.grdclmnQualificationLevel2;
            gridFormatRule3.ColumnApplyTo = this.grdclmnUserName2;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = 2;
            gridFormatRule3.Rule = formatConditionRuleValue3;
            gridFormatRule4.Column = this.grdclmnQualificationLevel2;
            gridFormatRule4.ColumnApplyTo = this.grdclmnUserName2;
            gridFormatRule4.Name = "Format3";
            formatConditionRuleValue4.Appearance.BackColor = System.Drawing.Color.Red;
            formatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue4.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue4.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue4.Value1 = 3;
            gridFormatRule4.Rule = formatConditionRuleValue4;
            this.grdvOperatorSkillMatrixs.FormatRules.Add(gridFormatRule1);
            this.grdvOperatorSkillMatrixs.FormatRules.Add(gridFormatRule2);
            this.grdvOperatorSkillMatrixs.FormatRules.Add(gridFormatRule3);
            this.grdvOperatorSkillMatrixs.FormatRules.Add(gridFormatRule4);
            this.grdvOperatorSkillMatrixs.GridControl = this.grdOperatorSkillMatrixs;
            this.grdvOperatorSkillMatrixs.Name = "grdvOperatorSkillMatrixs";
            this.grdvOperatorSkillMatrixs.OptionsBehavior.Editable = false;
            this.grdvOperatorSkillMatrixs.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvOperatorSkillMatrixs.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grdvOperatorSkillMatrixs.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grdvOperatorSkillMatrixs.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.grdvOperatorSkillMatrixs.OptionsView.ShowGroupPanel = false;
            this.grdvOperatorSkillMatrixs.OptionsView.ShowIndicator = false;
            this.grdvOperatorSkillMatrixs.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            // 
            // grdclmnT216Name1
            // 
            this.grdclmnT216Name1.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT216Name1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT216Name1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT216Name1.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT216Name1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT216Name1.Caption = "职务";
            this.grdclmnT216Name1.FieldName = "T216Name1";
            this.grdclmnT216Name1.Name = "grdclmnT216Name1";
            this.grdclmnT216Name1.Visible = true;
            this.grdclmnT216Name1.VisibleIndex = 0;
            // 
            // grdclmnT216Name2
            // 
            this.grdclmnT216Name2.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT216Name2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT216Name2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT216Name2.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT216Name2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT216Name2.Caption = "职务";
            this.grdclmnT216Name2.FieldName = "T216Name2";
            this.grdclmnT216Name2.Name = "grdclmnT216Name2";
            this.grdclmnT216Name2.Visible = true;
            this.grdclmnT216Name2.VisibleIndex = 2;
            // 
            // vgrdOperatorSkills
            // 
            this.vgrdOperatorSkills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vgrdOperatorSkills.Appearance.BandBorder.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.BandBorder.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.BandBorder.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.Category.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.Category.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.Category.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.CategoryExpandButton.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.CategoryExpandButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.CategoryExpandButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.DisabledRecordValue.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.DisabledRecordValue.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.DisabledRecordValue.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.DisabledRow.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.DisabledRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.DisabledRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.Empty.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.Empty.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.Empty.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.ExpandButton.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.ExpandButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.ExpandButton.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.FixedLine.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.FixedLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.FixedLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.FocusedCell.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.FocusedCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.FocusedCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.FocusedRecord.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.FocusedRecord.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.FocusedRecord.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.HideSelectionRow.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.HideSelectionRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.HideSelectionRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.HorzLine.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.HorzLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.HorzLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.ModifiedRecordValue.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.ModifiedRecordValue.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.ModifiedRecordValue.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.ModifiedRow.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.ModifiedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.ModifiedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.PressedRow.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.PressedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.PressedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.ReadOnlyRecordValue.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.ReadOnlyRecordValue.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.ReadOnlyRecordValue.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.ReadOnlyRow.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.ReadOnlyRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.ReadOnlyRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.RecordValue.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.RecordValue.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.RecordValue.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.RowHeaderPanel.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.RowHeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.RowHeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Appearance.VertLine.Options.UseTextOptions = true;
            this.vgrdOperatorSkills.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vgrdOperatorSkills.Appearance.VertLine.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vgrdOperatorSkills.Location = new System.Drawing.Point(8, 31);
            this.vgrdOperatorSkills.Name = "vgrdOperatorSkills";
            this.vgrdOperatorSkills.OptionsBehavior.Editable = false;
            this.vgrdOperatorSkills.RecordWidth = 74;
            this.vgrdOperatorSkills.RowHeaderWidth = 67;
            this.vgrdOperatorSkills.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowT216Name,
            this.rowUserName});
            this.vgrdOperatorSkills.Size = new System.Drawing.Size(496, 268);
            this.vgrdOperatorSkills.TabIndex = 15;
            this.vgrdOperatorSkills.CustomDrawRowValueCell += new DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventHandler(this.vgrdOperatorSkills_CustomDrawRowValueCell);
            // 
            // rowT216Name
            // 
            this.rowT216Name.Name = "rowT216Name";
            this.rowT216Name.Properties.Caption = "职务";
            this.rowT216Name.Properties.FieldName = "T216Name";
            // 
            // rowUserName
            // 
            this.rowUserName.Name = "rowUserName";
            this.rowUserName.Properties.Caption = "姓名";
            this.rowUserName.Properties.FieldName = "UserName";
            // 
            // ucOperatorSkillsMatrix
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vgrdOperatorSkills);
            this.Controls.Add(this.grdOperatorSkillMatrixs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblWorkUnit);
            this.Name = "ucOperatorSkillsMatrix";
            this.Size = new System.Drawing.Size(513, 308);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOperatorSkillMatrixs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOperatorSkillMatrixs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdOperatorSkills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWorkUnit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl grdOperatorSkillMatrixs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOperatorSkillMatrixs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT216Name1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserName1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT216Name2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserName2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQualificationLevel1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQualificationLevel2;
        private DevExpress.XtraVerticalGrid.VGridControl vgrdOperatorSkills;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowT216Name;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUserName;
    }
}
