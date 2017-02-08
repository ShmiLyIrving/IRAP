namespace IRAP.Client.GUI.MESPDC
{
    partial class frmFailureInspect_BWI
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtProductCardNo = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdFailureModes = new DevExpress.XtraGrid.GridControl();
            this.grdvFailureModes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnT118NodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtProductCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFailureModes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvFailureModes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "不良品数量登记";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 65);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(120, 20);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "生产卡卡号：";
            // 
            // edtProductCardNo
            // 
            this.edtProductCardNo.EnterMoveNextControl = true;
            this.edtProductCardNo.Location = new System.Drawing.Point(138, 62);
            this.edtProductCardNo.Name = "edtProductCardNo";
            this.edtProductCardNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtProductCardNo.Properties.Appearance.Options.UseFont = true;
            this.edtProductCardNo.Size = new System.Drawing.Size(333, 26);
            this.edtProductCardNo.TabIndex = 2;
            this.edtProductCardNo.Validating += new System.ComponentModel.CancelEventHandler(this.edtProductCardNo_Validating);
            this.edtProductCardNo.Validated += new System.EventHandler(this.edtProductCardNo_Validated);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdFailureModes);
            this.groupControl1.Location = new System.Drawing.Point(12, 94);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(10);
            this.groupControl1.Size = new System.Drawing.Size(750, 389);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "不良品数量登记";
            // 
            // grdFailureModes
            // 
            this.grdFailureModes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFailureModes.Location = new System.Drawing.Point(12, 37);
            this.grdFailureModes.MainView = this.grdvFailureModes;
            this.grdFailureModes.Name = "grdFailureModes";
            this.grdFailureModes.Size = new System.Drawing.Size(726, 340);
            this.grdFailureModes.TabIndex = 0;
            this.grdFailureModes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvFailureModes});
            // 
            // grdvFailureModes
            // 
            this.grdvFailureModes.Appearance.FooterPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvFailureModes.Appearance.FooterPanel.Options.UseFont = true;
            this.grdvFailureModes.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvFailureModes.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvFailureModes.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvFailureModes.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvFailureModes.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvFailureModes.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvFailureModes.Appearance.Row.Options.UseFont = true;
            this.grdvFailureModes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnT118NodeName,
            this.grdclmnQty});
            this.grdvFailureModes.GridControl = this.grdFailureModes;
            this.grdvFailureModes.Name = "grdvFailureModes";
            this.grdvFailureModes.OptionsView.ColumnAutoWidth = false;
            this.grdvFailureModes.OptionsView.ShowFooter = true;
            this.grdvFailureModes.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnT118NodeName
            // 
            this.grdclmnT118NodeName.Caption = "报废名称";
            this.grdclmnT118NodeName.FieldName = "T118NodeName";
            this.grdclmnT118NodeName.Name = "grdclmnT118NodeName";
            this.grdclmnT118NodeName.OptionsColumn.AllowEdit = false;
            this.grdclmnT118NodeName.OptionsColumn.AllowMove = false;
            this.grdclmnT118NodeName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnT118NodeName.OptionsColumn.ReadOnly = true;
            this.grdclmnT118NodeName.Visible = true;
            this.grdclmnT118NodeName.VisibleIndex = 0;
            this.grdclmnT118NodeName.Width = 560;
            // 
            // grdclmnQty
            // 
            this.grdclmnQty.Caption = "报废数量";
            this.grdclmnQty.FieldName = "Qty";
            this.grdclmnQty.Name = "grdclmnQty";
            this.grdclmnQty.OptionsColumn.AllowMove = false;
            this.grdclmnQty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "合计(Total): {0}")});
            this.grdclmnQty.Visible = true;
            this.grdclmnQty.VisibleIndex = 1;
            this.grdclmnQty.Width = 200;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(782, 62);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 38);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "提交";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Location = new System.Drawing.Point(782, 106);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 38);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清除";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmFailureInspect_BWI
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.edtProductCardNo);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmFailureInspect_BWI";
            this.Text = "不良品数量登记";
            this.Activated += new System.EventHandler(this.frmFailureInspect_BWI_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFailureInspect_BWI_FormClosed);
            this.Load += new System.EventHandler(this.frmFailureInspect_BWI_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.edtProductCardNo, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtProductCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFailureModes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvFailureModes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtProductCardNo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdFailureModes;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvFailureModes;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT118NodeName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQty;
    }
}
