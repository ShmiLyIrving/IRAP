namespace IRAP.Client.GUI.FVS
{
    partial class frmEmployeesAtWorking
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdEmployees = new DevExpress.XtraGrid.GridControl();
            this.grdvEmployees = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQdTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(888, 56);
            this.lblFuncName.Text = "当前签到的员工";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(888, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdEmployees);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(888, 451);
            this.splitContainerControl1.SplitterPosition = 120;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grdEmployees
            // 
            this.grdEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEmployees.Location = new System.Drawing.Point(10, 10);
            this.grdEmployees.MainView = this.grdvEmployees;
            this.grdEmployees.Name = "grdEmployees";
            this.grdEmployees.Size = new System.Drawing.Size(743, 431);
            this.grdEmployees.TabIndex = 0;
            this.grdEmployees.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvEmployees});
            // 
            // grdvEmployees
            // 
            this.grdvEmployees.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvEmployees.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvEmployees.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvEmployees.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvEmployees.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvEmployees.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvEmployees.Appearance.Row.Options.UseFont = true;
            this.grdvEmployees.Appearance.Row.Options.UseTextOptions = true;
            this.grdvEmployees.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvEmployees.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnUserCode,
            this.grdclmnUserName,
            this.grdclmnQdTime});
            this.grdvEmployees.GridControl = this.grdEmployees;
            this.grdvEmployees.Name = "grdvEmployees";
            this.grdvEmployees.OptionsBehavior.Editable = false;
            this.grdvEmployees.OptionsView.ColumnAutoWidth = false;
            this.grdvEmployees.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnUserCode
            // 
            this.grdclmnUserCode.Caption = "工号";
            this.grdclmnUserCode.FieldName = "UserCode";
            this.grdclmnUserCode.Name = "grdclmnUserCode";
            this.grdclmnUserCode.Visible = true;
            this.grdclmnUserCode.VisibleIndex = 0;
            // 
            // grdclmnUserName
            // 
            this.grdclmnUserName.Caption = "姓名";
            this.grdclmnUserName.FieldName = "UserName";
            this.grdclmnUserName.Name = "grdclmnUserName";
            this.grdclmnUserName.Visible = true;
            this.grdclmnUserName.VisibleIndex = 1;
            // 
            // grdclmnQdTime
            // 
            this.grdclmnQdTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQdTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnQdTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQdTime.Caption = "签到时间";
            this.grdclmnQdTime.FieldName = "QdTime";
            this.grdclmnQdTime.Name = "grdclmnQdTime";
            this.grdclmnQdTime.Visible = true;
            this.grdclmnQdTime.VisibleIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRefresh.Location = new System.Drawing.Point(10, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 37);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmEmployeesAtWorking
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(888, 507);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmEmployeesAtWorking";
            this.Text = "当前签到的员工";
            this.Shown += new System.EventHandler(this.frmEmployeesAtWorking_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl grdEmployees;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvEmployees;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUserName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQdTime;
    }
}
