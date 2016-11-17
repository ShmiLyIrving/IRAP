namespace IRAP.Client.GUI.CAS.UserControls
{
    partial class ucFailureModes
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdAndonCallObjects = new DevExpress.XtraGrid.GridControl();
            this.grdvAndonCallObjects = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnEventDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repiceChoice = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonCallObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonCallObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repiceChoice)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(0, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(365, 31);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "失效模式：";
            // 
            // grdAndonCallObjects
            // 
            this.grdAndonCallObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAndonCallObjects.Location = new System.Drawing.Point(0, 31);
            this.grdAndonCallObjects.MainView = this.grdvAndonCallObjects;
            this.grdAndonCallObjects.Name = "grdAndonCallObjects";
            this.grdAndonCallObjects.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repiceChoice});
            this.grdAndonCallObjects.Size = new System.Drawing.Size(365, 303);
            this.grdAndonCallObjects.TabIndex = 6;
            this.grdAndonCallObjects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvAndonCallObjects});
            // 
            // grdvAndonCallObjects
            // 
            this.grdvAndonCallObjects.Appearance.FocusedCell.BackColor = System.Drawing.Color.Blue;
            this.grdvAndonCallObjects.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grdvAndonCallObjects.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdvAndonCallObjects.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdvAndonCallObjects.Appearance.FocusedRow.BackColor = System.Drawing.Color.Blue;
            this.grdvAndonCallObjects.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grdvAndonCallObjects.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdvAndonCallObjects.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grdvAndonCallObjects.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 12F);
            this.grdvAndonCallObjects.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvAndonCallObjects.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvAndonCallObjects.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvAndonCallObjects.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvAndonCallObjects.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvAndonCallObjects.Appearance.Row.Font = new System.Drawing.Font("等线", 12F);
            this.grdvAndonCallObjects.Appearance.Row.Options.UseFont = true;
            this.grdvAndonCallObjects.Appearance.Row.Options.UseTextOptions = true;
            this.grdvAndonCallObjects.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvAndonCallObjects.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvAndonCallObjects.ColumnPanelRowHeight = 30;
            this.grdvAndonCallObjects.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnEventDescription});
            this.grdvAndonCallObjects.GridControl = this.grdAndonCallObjects;
            this.grdvAndonCallObjects.Name = "grdvAndonCallObjects";
            this.grdvAndonCallObjects.OptionsView.ColumnAutoWidth = false;
            this.grdvAndonCallObjects.OptionsView.RowAutoHeight = true;
            this.grdvAndonCallObjects.OptionsView.ShowGroupPanel = false;
            this.grdvAndonCallObjects.RowHeight = 30;
            // 
            // grdclmnEventDescription
            // 
            this.grdclmnEventDescription.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnEventDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEventDescription.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnEventDescription.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdclmnEventDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnEventDescription.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEventDescription.Caption = "失效模式";
            this.grdclmnEventDescription.FieldName = "ObjectDesc";
            this.grdclmnEventDescription.Name = "grdclmnEventDescription";
            this.grdclmnEventDescription.OptionsColumn.AllowEdit = false;
            this.grdclmnEventDescription.OptionsColumn.ReadOnly = true;
            this.grdclmnEventDescription.Visible = true;
            this.grdclmnEventDescription.VisibleIndex = 0;
            this.grdclmnEventDescription.Width = 400;
            // 
            // repiceChoice
            // 
            this.repiceChoice.Appearance.Font = new System.Drawing.Font("新宋体", 21.75F);
            this.repiceChoice.Appearance.Options.UseFont = true;
            this.repiceChoice.AutoHeight = false;
            this.repiceChoice.Caption = "Check";
            this.repiceChoice.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repiceChoice.ImageIndexChecked = 1;
            this.repiceChoice.ImageIndexUnchecked = 0;
            this.repiceChoice.Name = "repiceChoice";
            // 
            // ucFailureModes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdAndonCallObjects);
            this.Controls.Add(this.labelControl2);
            this.Name = "ucFailureModes";
            this.Size = new System.Drawing.Size(365, 334);
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonCallObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonCallObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repiceChoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grdAndonCallObjects;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAndonCallObjects;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEventDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repiceChoice;
    }
}
