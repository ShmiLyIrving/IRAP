namespace IRAP_FVS_Kanban
{
    partial class frmConfig
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdScreens = new DevExpress.XtraGrid.GridControl();
            this.grdvScreens = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnShowed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnDeviceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnSysLogID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScreens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvScreens)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 270);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(438, 38);
            this.panelControl1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(356, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(264, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grdScreens);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(438, 270);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "屏幕是否显示（✔：显示 □：不显示）";
            // 
            // grdScreens
            // 
            this.grdScreens.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdScreens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdScreens.Location = new System.Drawing.Point(2, 22);
            this.grdScreens.MainView = this.grdvScreens;
            this.grdScreens.Name = "grdScreens";
            this.grdScreens.Size = new System.Drawing.Size(434, 246);
            this.grdScreens.TabIndex = 0;
            this.grdScreens.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvScreens});
            // 
            // grdvScreens
            // 
            this.grdvScreens.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvScreens.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvScreens.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvScreens.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvScreens.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvScreens.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvScreens.Appearance.Row.Options.UseFont = true;
            this.grdvScreens.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnShowed,
            this.grdclmnDeviceName,
            this.grdclmnSysLogID});
            this.grdvScreens.GridControl = this.grdScreens;
            this.grdvScreens.Name = "grdvScreens";
            this.grdvScreens.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnShowed
            // 
            this.grdclmnShowed.Caption = "是否显示";
            this.grdclmnShowed.FieldName = "Show";
            this.grdclmnShowed.Name = "grdclmnShowed";
            this.grdclmnShowed.Visible = true;
            this.grdclmnShowed.VisibleIndex = 0;
            this.grdclmnShowed.Width = 68;
            // 
            // grdclmnDeviceName
            // 
            this.grdclmnDeviceName.Caption = "屏幕名称";
            this.grdclmnDeviceName.FieldName = "DeviceName";
            this.grdclmnDeviceName.Name = "grdclmnDeviceName";
            this.grdclmnDeviceName.OptionsColumn.AllowEdit = false;
            this.grdclmnDeviceName.Visible = true;
            this.grdclmnDeviceName.VisibleIndex = 1;
            this.grdclmnDeviceName.Width = 190;
            // 
            // grdclmnSysLogID
            // 
            this.grdclmnSysLogID.Caption = "屏幕标识";
            this.grdclmnSysLogID.FieldName = "SysLogID";
            this.grdclmnSysLogID.Name = "grdclmnSysLogID";
            this.grdclmnSysLogID.Visible = true;
            this.grdclmnSysLogID.VisibleIndex = 2;
            this.grdclmnSysLogID.Width = 107;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 308);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmConfig";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdScreens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvScreens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdScreens;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvScreens;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnShowed;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnDeviceName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnSysLogID;
    }
}