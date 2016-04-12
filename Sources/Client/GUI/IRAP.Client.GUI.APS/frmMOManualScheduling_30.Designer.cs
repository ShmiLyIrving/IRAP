namespace IRAP.Client.GUI.APS
{
    partial class frmMOManualScheduling_30
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn25 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn26 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn27 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn28 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn29 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn30 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn31 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn32 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn33 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn34 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdOrders = new Telerik.WinControls.UI.RadGridView();
            this.cboAreas = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblFuncName)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Size = new System.Drawing.Size(907, 56);
            this.lblFuncName.Text = "制造订单手工排程";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.radGroupBox1);
            this.panel1.Controls.Add(this.cboAreas);
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 457);
            this.panel1.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnRefresh.Location = new System.Drawing.Point(785, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.grdOrders);
            this.radGroupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.radGroupBox1.HeaderText = "制造订单列表";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 35);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(755, 410);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "制造订单列表";
            // 
            // grdOrders
            // 
            this.grdOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOrders.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdOrders.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            gridViewTextBoxColumn18.FieldName = "PriorityOrdinal";
            gridViewTextBoxColumn18.HeaderText = "优先顺序";
            gridViewTextBoxColumn18.Name = "clmnPriorityOrdinal";
            gridViewTextBoxColumn18.Width = 67;
            gridViewTextBoxColumn19.HeaderText = "制造订单号";
            gridViewTextBoxColumn19.Name = "column1";
            gridViewTextBoxColumn19.Width = 81;
            gridViewTextBoxColumn20.HeaderText = "行号";
            gridViewTextBoxColumn20.Name = "column2";
            gridViewTextBoxColumn20.Width = 38;
            gridViewTextBoxColumn21.HeaderText = "产品编号";
            gridViewTextBoxColumn21.Name = "column3";
            gridViewTextBoxColumn21.Width = 67;
            gridViewTextBoxColumn22.HeaderText = "产品名称";
            gridViewTextBoxColumn22.Name = "column4";
            gridViewTextBoxColumn22.Width = 67;
            gridViewTextBoxColumn23.HeaderText = "订单数量";
            gridViewTextBoxColumn23.Name = "column5";
            gridViewTextBoxColumn23.Width = 67;
            gridViewTextBoxColumn24.HeaderText = "完工数量";
            gridViewTextBoxColumn24.Name = "column6";
            gridViewTextBoxColumn24.Width = 67;
            gridViewTextBoxColumn25.HeaderText = "计量单位";
            gridViewTextBoxColumn25.Name = "column7";
            gridViewTextBoxColumn25.Width = 67;
            gridViewTextBoxColumn26.HeaderText = "计划投产日期";
            gridViewTextBoxColumn26.Name = "column8";
            gridViewTextBoxColumn26.Width = 96;
            gridViewTextBoxColumn27.HeaderText = "计划完工日期";
            gridViewTextBoxColumn27.Name = "column9";
            gridViewTextBoxColumn27.Width = 96;
            gridViewTextBoxColumn28.HeaderText = "排定生产线";
            gridViewTextBoxColumn28.Name = "column10";
            gridViewTextBoxColumn28.Width = 81;
            gridViewTextBoxColumn29.HeaderText = "排定生产时间";
            gridViewTextBoxColumn29.Name = "column11";
            gridViewTextBoxColumn29.Width = 96;
            gridViewTextBoxColumn30.HeaderText = "实际生产时间";
            gridViewTextBoxColumn30.Name = "column12";
            gridViewTextBoxColumn30.Width = 96;
            gridViewTextBoxColumn31.HeaderText = "订单状态";
            gridViewTextBoxColumn31.Name = "column13";
            gridViewTextBoxColumn31.Width = 67;
            gridViewTextBoxColumn32.HeaderText = "当前物料可供生产数量";
            gridViewTextBoxColumn32.Name = "column14";
            gridViewTextBoxColumn32.Width = 153;
            gridViewTextBoxColumn33.HeaderText = "预计物料备齐时间";
            gridViewTextBoxColumn33.Name = "column15";
            gridViewTextBoxColumn33.Width = 124;
            gridViewTextBoxColumn34.HeaderText = "column16";
            gridViewTextBoxColumn34.Name = "column16";
            gridViewTextBoxColumn34.Width = 78;
            this.grdOrders.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22,
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24,
            gridViewTextBoxColumn25,
            gridViewTextBoxColumn26,
            gridViewTextBoxColumn27,
            gridViewTextBoxColumn28,
            gridViewTextBoxColumn29,
            gridViewTextBoxColumn30,
            gridViewTextBoxColumn31,
            gridViewTextBoxColumn32,
            gridViewTextBoxColumn33,
            gridViewTextBoxColumn34});
            this.grdOrders.MasterTemplate.EnableGrouping = false;
            this.grdOrders.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.ReadOnly = true;
            this.grdOrders.Size = new System.Drawing.Size(745, 384);
            this.grdOrders.TabIndex = 0;
            this.grdOrders.Text = "radGridView1";
            // 
            // cboAreas
            // 
            this.cboAreas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAreas.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboAreas.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboAreas.Location = new System.Drawing.Point(184, 6);
            this.cboAreas.Name = "cboAreas";
            this.cboAreas.Size = new System.Drawing.Size(583, 24);
            this.cboAreas.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.radLabel1.Location = new System.Drawing.Point(12, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(166, 22);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "请选择进行排产的工段：";
            // 
            // frmMOManualScheduling_30
            // 
            this.ClientSize = new System.Drawing.Size(907, 513);
            this.Controls.Add(this.panel1);
            this.Name = "frmMOManualScheduling_30";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "制造订单手工排程";
            this.Activated += new System.EventHandler(this.frmMOManualScheduling_30_Activated);
            this.Shown += new System.EventHandler(this.frmMOManualScheduling_30_Shown);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lblFuncName)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdOrders;
        private Telerik.WinControls.UI.RadDropDownList cboAreas;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
