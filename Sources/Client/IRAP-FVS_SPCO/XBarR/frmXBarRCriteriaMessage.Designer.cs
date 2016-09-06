namespace IRAP_FVS_SPCO.XBarR
{
    partial class frmXBarRCriteriaMessage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXBarRCriteriaMessage));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdXBarCriteriaResult = new DevExpress.XtraGrid.GridControl();
            this.grdvXBarCriteriaResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdRCriterialResult = new DevExpress.XtraGrid.GridControl();
            this.grdvRCriteriaResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdXBarCriteriaResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvXBarCriteriaResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRCriterialResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvRCriteriaResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdXBarCriteriaResult);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(583, 237);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "XBar 图判异结果";
            // 
            // grdXBarCriteriaResult
            // 
            this.grdXBarCriteriaResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdXBarCriteriaResult.Location = new System.Drawing.Point(2, 23);
            this.grdXBarCriteriaResult.MainView = this.grdvXBarCriteriaResult;
            this.grdXBarCriteriaResult.Name = "grdXBarCriteriaResult";
            this.grdXBarCriteriaResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdXBarCriteriaResult.Size = new System.Drawing.Size(579, 212);
            this.grdXBarCriteriaResult.TabIndex = 0;
            this.grdXBarCriteriaResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvXBarCriteriaResult});
            // 
            // grdvXBarCriteriaResult
            // 
            this.grdvXBarCriteriaResult.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvXBarCriteriaResult.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvXBarCriteriaResult.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvXBarCriteriaResult.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvXBarCriteriaResult.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvXBarCriteriaResult.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvXBarCriteriaResult.Appearance.Row.Options.UseFont = true;
            this.grdvXBarCriteriaResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grdvXBarCriteriaResult.GridControl = this.grdXBarCriteriaResult;
            this.grdvXBarCriteriaResult.Name = "grdvXBarCriteriaResult";
            this.grdvXBarCriteriaResult.OptionsBehavior.ReadOnly = true;
            this.grdvXBarCriteriaResult.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.FieldName = "Ordinal";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ShowCaption = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "判异内容";
            this.gridColumn2.FieldName = "CriteriaContent";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 381;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "判异结果";
            this.gridColumn3.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn3.FieldName = "Result";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 130;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.PictureChecked = ((System.Drawing.Image)(resources.GetObject("repositoryItemCheckEdit1.PictureChecked")));
            this.repositoryItemCheckEdit1.PictureUnchecked = ((System.Drawing.Image)(resources.GetObject("repositoryItemCheckEdit1.PictureUnchecked")));
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.grdRCriterialResult);
            this.groupControl2.Location = new System.Drawing.Point(12, 255);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(583, 237);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "R 图判异结果";
            // 
            // grdRCriterialResult
            // 
            this.grdRCriterialResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRCriterialResult.Location = new System.Drawing.Point(2, 23);
            this.grdRCriterialResult.MainView = this.grdvRCriteriaResult;
            this.grdRCriterialResult.Name = "grdRCriterialResult";
            this.grdRCriterialResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.grdRCriterialResult.Size = new System.Drawing.Size(579, 212);
            this.grdRCriterialResult.TabIndex = 0;
            this.grdRCriterialResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvRCriteriaResult});
            // 
            // grdvRCriteriaResult
            // 
            this.grdvRCriteriaResult.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvRCriteriaResult.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvRCriteriaResult.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvRCriteriaResult.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvRCriteriaResult.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvRCriteriaResult.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvRCriteriaResult.Appearance.Row.Options.UseFont = true;
            this.grdvRCriteriaResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grdvRCriteriaResult.GridControl = this.grdRCriterialResult;
            this.grdvRCriteriaResult.Name = "grdvRCriteriaResult";
            this.grdvRCriteriaResult.OptionsBehavior.ReadOnly = true;
            this.grdvRCriteriaResult.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.FieldName = "Ordinal";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ShowCaption = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 50;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "判异内容";
            this.gridColumn5.FieldName = "CriteriaContent";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 381;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.Caption = "判异结果";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn6.FieldName = "Result";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 130;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.PictureChecked = ((System.Drawing.Image)(resources.GetObject("repositoryItemCheckEdit2.PictureChecked")));
            this.repositoryItemCheckEdit2.PictureUnchecked = ((System.Drawing.Image)(resources.GetObject("repositoryItemCheckEdit2.PictureUnchecked")));
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(601, 453);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 39);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmXBarRCriteriaMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 505);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXBarRCriteriaMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XBar-R 图判异结果";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdXBarCriteriaResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvXBarCriteriaResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRCriterialResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvRCriteriaResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdXBarCriteriaResult;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvXBarCriteriaResult;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdRCriterialResult;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvRCriteriaResult;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}