namespace OPCClient.UserContols
{
    partial class ucConfigOPCServers
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
            this.grdOPCServers = new DevExpress.XtraGrid.GridControl();
            this.grdvOPCServers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridclmnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOPCServers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOPCServers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.panelControl1);
            this.pnlBody.Controls.Add(this.panelControl2);
            this.pnlBody.Size = new System.Drawing.Size(532, 386);
            // 
            // grdOPCServers
            // 
            this.grdOPCServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOPCServers.Location = new System.Drawing.Point(0, 0);
            this.grdOPCServers.MainView = this.grdvOPCServers;
            this.grdOPCServers.Name = "grdOPCServers";
            this.grdOPCServers.Size = new System.Drawing.Size(372, 362);
            this.grdOPCServers.TabIndex = 0;
            this.grdOPCServers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOPCServers});
            // 
            // grdvOPCServers
            // 
            this.grdvOPCServers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnAddress,
            this.gridclmnName});
            this.grdvOPCServers.GridControl = this.grdOPCServers;
            this.grdvOPCServers.Name = "grdvOPCServers";
            this.grdvOPCServers.OptionsBehavior.Editable = false;
            this.grdvOPCServers.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnAddress
            // 
            this.grdclmnAddress.Caption = "OPCServer IP 地址";
            this.grdclmnAddress.FieldName = "Address";
            this.grdclmnAddress.Name = "grdclmnAddress";
            this.grdclmnAddress.Visible = true;
            this.grdclmnAddress.VisibleIndex = 0;
            // 
            // gridclmnName
            // 
            this.gridclmnName.Caption = "OPCServer 服务器名";
            this.gridclmnName.FieldName = "Name";
            this.gridclmnName.Name = "gridclmnName";
            this.gridclmnName.Visible = true;
            this.gridclmnName.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.grdOPCServers);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(372, 362);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(384, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(136, 362);
            this.panelControl2.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(21, 39);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 33);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(21, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 33);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucConfigOPCServers
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.Name = "ucConfigOPCServers";
            this.Size = new System.Drawing.Size(532, 411);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOPCServers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOPCServers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdOPCServers;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOPCServers;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridclmnName;
    }
}
