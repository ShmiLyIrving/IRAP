namespace IRAP.Client.Global.GUI
{
    partial class frmShowErrorLogs
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdLogs = new Telerik.WinControls.UI.RadGridView();
            this.gpcLogs = new Telerik.WinControls.UI.RadGroupBox();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcLogs)).BeginInit();
            this.gpcLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLogs
            // 
            this.grdLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLogs.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLogs.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            gridViewDateTimeColumn2.FieldName = "Time";
            gridViewDateTimeColumn2.HeaderText = "时间";
            gridViewDateTimeColumn2.Name = "clmLogTime";
            gridViewDateTimeColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn2.Width = 172;
            gridViewTextBoxColumn2.FieldName = "ErrText";
            gridViewTextBoxColumn2.HeaderText = "日志信息";
            gridViewTextBoxColumn2.Name = "clmLogMessage";
            gridViewTextBoxColumn2.Width = 400;
            gridViewTextBoxColumn2.WrapText = true;
            this.grdLogs.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDateTimeColumn2,
            gridViewTextBoxColumn2});
            this.grdLogs.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdLogs.Name = "grdLogs";
            this.grdLogs.ReadOnly = true;
            this.grdLogs.ShowGroupPanel = false;
            this.grdLogs.Size = new System.Drawing.Size(616, 402);
            this.grdLogs.TabIndex = 0;
            this.grdLogs.Text = "radGridView1";
            // 
            // gpcLogs
            // 
            this.gpcLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gpcLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcLogs.Controls.Add(this.grdLogs);
            this.gpcLogs.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcLogs.HeaderText = "日志";
            this.gpcLogs.Location = new System.Drawing.Point(12, 12);
            this.gpcLogs.Name = "gpcLogs";
            this.gpcLogs.Size = new System.Drawing.Size(626, 428);
            this.gpcLogs.TabIndex = 1;
            this.gpcLogs.Text = "日志";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(652, 403);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 37);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowErrorLogs
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(771, 452);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpcLogs);
            this.Name = "frmShowErrorLogs";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "查看日志信息";
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcLogs)).EndInit();
            this.gpcLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdLogs;
        private Telerik.WinControls.UI.RadGroupBox gpcLogs;
        private Telerik.WinControls.UI.RadButton btnClose;
    }
}
