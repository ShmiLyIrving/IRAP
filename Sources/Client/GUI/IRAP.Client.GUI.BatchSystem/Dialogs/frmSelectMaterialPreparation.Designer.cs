namespace IRAP.Client.GUI.BatchSystem.Dialogs
{
    partial class frmSelectMaterialPreparation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectMaterialPreparation));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ilstMaterialPreparation = new DevExpress.XtraEditors.ImageListBoxControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.grdPWOs = new DevExpress.XtraGrid.GridControl();
            this.grdvPWOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ilstMaterialPreparation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.ilstMaterialPreparation);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "已备料";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.grdPWOs);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "备料框中的产品";
            this.splitContainerControl1.Size = new System.Drawing.Size(1114, 362);
            this.splitContainerControl1.SplitterPosition = 254;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ilstMaterialPreparation
            // 
            this.ilstMaterialPreparation.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ilstMaterialPreparation.Appearance.Options.UseFont = true;
            this.ilstMaterialPreparation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilstMaterialPreparation.ImageList = this.imageList;
            this.ilstMaterialPreparation.ItemAutoHeight = true;
            this.ilstMaterialPreparation.Location = new System.Drawing.Point(5, 5);
            this.ilstMaterialPreparation.Name = "ilstMaterialPreparation";
            this.ilstMaterialPreparation.Size = new System.Drawing.Size(240, 322);
            this.ilstMaterialPreparation.TabIndex = 0;
            this.ilstMaterialPreparation.SelectedIndexChanged += new System.EventHandler(this.ilstMaterialPreparation_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "send_container_clock.png");
            // 
            // grdPWOs
            // 
            this.grdPWOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPWOs.Location = new System.Drawing.Point(5, 5);
            this.grdPWOs.MainView = this.grdvPWOs;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.Size = new System.Drawing.Size(841, 322);
            this.grdPWOs.TabIndex = 2;
            this.grdPWOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPWOs});
            // 
            // grdvPWOs
            // 
            this.grdvPWOs.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvPWOs.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvPWOs.Appearance.Row.Options.UseFont = true;
            this.grdvPWOs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnPWONo,
            this.gridColumn2,
            this.grdclmnProductName,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.grdvPWOs.GridControl = this.grdPWOs;
            this.grdvPWOs.Name = "grdvPWOs";
            this.grdvPWOs.OptionsBehavior.Editable = false;
            this.grdvPWOs.OptionsView.ColumnAutoWidth = false;
            this.grdvPWOs.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.Caption = "工单号";
            this.grdclmnPWONo.FieldName = "PWONo";
            this.grdclmnPWONo.Name = "grdclmnPWONo";
            this.grdclmnPWONo.Visible = true;
            this.grdclmnPWONo.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "产品物料号";
            this.gridColumn2.FieldName = "T102Code";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // grdclmnProductName
            // 
            this.grdclmnProductName.Caption = "产品物料名称";
            this.grdclmnProductName.FieldName = "T102Name";
            this.grdclmnProductName.Name = "grdclmnProductName";
            this.grdclmnProductName.Visible = true;
            this.grdclmnProductName.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "批次号";
            this.gridColumn3.FieldName = "LotNumber";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "材质";
            this.gridColumn4.FieldName = "Texture";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn5.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.Caption = "生产数量";
            this.gridColumn5.FieldName = "Quantity";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(10, 10);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.splitContainerControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerControl2.Panel2.Controls.Add(this.btnSelect);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1114, 416);
            this.splitContainerControl2.SplitterPosition = 49;
            this.splitContainerControl2.TabIndex = 4;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1019, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 41);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Appearance.Options.UseFont = true;
            this.btnSelect.Location = new System.Drawing.Point(879, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(95, 41);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmSelectMaterialPreparation
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1134, 436);
            this.Controls.Add(this.splitContainerControl2);
            this.Name = "frmSelectMaterialPreparation";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "备料选择";
            this.Shown += new System.EventHandler(this.frmSelectMaterialPreparation_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSelectMaterialPreparation_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ilstMaterialPreparation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.ImageListBoxControl ilstMaterialPreparation;
        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.ImageList imageList;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
    }
}
