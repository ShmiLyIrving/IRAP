namespace IRAP.Client.GUI.MDM
{
    partial class frmLabelTemplateManager
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabelTemplateManager));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdAddressList = new DevExpress.XtraGrid.GridControl();
            this.grdvAddressList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT117Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnActions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribeActions = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cboCustomers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblPartNumber = new DevExpress.XtraEditors.LabelControl();
            this.edtPartNumber = new DevExpress.XtraEditors.TextEdit();
            this.report = new FastReport.Report();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAddressList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAddressList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPartNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "标签模板管理";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.grdAddressList);
            this.groupControl1.Controls.Add(this.cboCustomers);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.lblPartNumber);
            this.groupControl1.Controls.Add(this.edtPartNumber);
            this.groupControl1.Location = new System.Drawing.Point(12, 62);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(867, 421);
            this.groupControl1.TabIndex = 4;
            // 
            // grdAddressList
            // 
            this.grdAddressList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAddressList.Location = new System.Drawing.Point(16, 109);
            this.grdAddressList.MainView = this.grdvAddressList;
            this.grdAddressList.Name = "grdAddressList";
            this.grdAddressList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ribeActions});
            this.grdAddressList.Size = new System.Drawing.Size(835, 297);
            this.grdAddressList.TabIndex = 5;
            this.grdAddressList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvAddressList});
            // 
            // grdvAddressList
            // 
            this.grdvAddressList.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvAddressList.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvAddressList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvAddressList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvAddressList.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvAddressList.Appearance.Row.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvAddressList.Appearance.Row.Options.UseFont = true;
            this.grdvAddressList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnAddress,
            this.grdclmnT117Name,
            this.grdclmnActions});
            this.grdvAddressList.GridControl = this.grdAddressList;
            this.grdvAddressList.Name = "grdvAddressList";
            this.grdvAddressList.OptionsBehavior.Editable = false;
            this.grdvAddressList.OptionsView.ColumnAutoWidth = false;
            this.grdvAddressList.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnAddress
            // 
            this.grdclmnAddress.Caption = "收货地址";
            this.grdclmnAddress.FieldName = "Address";
            this.grdclmnAddress.Name = "grdclmnAddress";
            // 
            // grdclmnT117Name
            // 
            this.grdclmnT117Name.Caption = "标签模板名称";
            this.grdclmnT117Name.FieldName = "T117Name";
            this.grdclmnT117Name.Name = "grdclmnT117Name";
            // 
            // grdclmnActions
            // 
            this.grdclmnActions.ColumnEdit = this.ribeActions;
            this.grdclmnActions.Name = "grdclmnActions";
            this.grdclmnActions.Width = 120;
            // 
            // ribeActions
            // 
            this.ribeActions.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribeActions.Appearance.Options.UseFont = true;
            this.ribeActions.AutoHeight = false;
            serializableAppearanceObject1.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject1.Options.UseFont = true;
            this.ribeActions.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "选择标签模板", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.ribeActions.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.ribeActions.Name = "ribeActions";
            this.ribeActions.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.ribeActions.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ribeActions_ButtonClick);
            // 
            // cboCustomers
            // 
            this.cboCustomers.EnterMoveNextControl = true;
            this.cboCustomers.Location = new System.Drawing.Point(138, 67);
            this.cboCustomers.Name = "cboCustomers";
            this.cboCustomers.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F);
            this.cboCustomers.Properties.Appearance.Options.UseFont = true;
            this.cboCustomers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCustomers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCustomers.Size = new System.Drawing.Size(378, 24);
            this.cboCustomers.TabIndex = 4;
            this.cboCustomers.SelectedIndexChanged += new System.EventHandler(this.cboCustomers_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(16, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(116, 17);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "客户：";
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPartNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPartNumber.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPartNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPartNumber.Location = new System.Drawing.Point(16, 40);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(116, 17);
            this.lblPartNumber.TabIndex = 1;
            this.lblPartNumber.Text = "部件编号：";
            // 
            // edtPartNumber
            // 
            this.edtPartNumber.EnterMoveNextControl = true;
            this.edtPartNumber.Location = new System.Drawing.Point(138, 37);
            this.edtPartNumber.Name = "edtPartNumber";
            this.edtPartNumber.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F);
            this.edtPartNumber.Properties.Appearance.Options.UseFont = true;
            this.edtPartNumber.Size = new System.Drawing.Size(209, 24);
            this.edtPartNumber.TabIndex = 2;
            this.edtPartNumber.Validating += new System.ComponentModel.CancelEventHandler(this.edtPartNumber_Validating);
            // 
            // report
            // 
            this.report.ReportResourceString = resources.GetString("report.ReportResourceString");
            // 
            // frmLabelTemplateManager
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmLabelTemplateManager";
            this.Text = "标签模板管理";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAddressList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAddressList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribeActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPartNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboCustomers;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblPartNumber;
        private DevExpress.XtraEditors.TextEdit edtPartNumber;
        private FastReport.Report report;
        private DevExpress.XtraGrid.GridControl grdAddressList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAddressList;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnAddress;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT117Name;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnActions;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribeActions;
    }
}
