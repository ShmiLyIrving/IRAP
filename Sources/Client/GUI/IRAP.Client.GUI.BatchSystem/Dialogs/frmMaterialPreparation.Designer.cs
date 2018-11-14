namespace IRAP.Client.GUI.BatchSystem.Dialogs
{
    partial class frmMaterialPreparation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterialPreparation));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ilstMaterialPreparation = new DevExpress.XtraEditors.ImageListBoxControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMPRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnMPNew = new DevExpress.XtraEditors.SimpleButton();
            this.grdPWOs = new DevExpress.XtraGrid.GridControl();
            this.grdvPWOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPWORemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnPWOModify = new DevExpress.XtraEditors.SimpleButton();
            this.btnPWONew = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ilstMaterialPreparation)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.splitContainerControl1.Location = new System.Drawing.Point(10, 10);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.ilstMaterialPreparation);
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "已备料";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.grdPWOs);
            this.splitContainerControl1.Panel2.Controls.Add(this.panel2);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "备料框中的产品";
            this.splitContainerControl1.Size = new System.Drawing.Size(1114, 530);
            this.splitContainerControl1.SplitterPosition = 254;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ilstMaterialPreparation
            // 
            this.ilstMaterialPreparation.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ilstMaterialPreparation.Appearance.Options.UseFont = true;
            this.ilstMaterialPreparation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilstMaterialPreparation.ImageList = this.imageList;
            this.ilstMaterialPreparation.ItemAutoHeight = true;
            this.ilstMaterialPreparation.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("HAHA", "ABC", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, "123", 0)});
            this.ilstMaterialPreparation.Location = new System.Drawing.Point(5, 5);
            this.ilstMaterialPreparation.Name = "ilstMaterialPreparation";
            this.ilstMaterialPreparation.Size = new System.Drawing.Size(240, 430);
            this.ilstMaterialPreparation.TabIndex = 0;
            this.ilstMaterialPreparation.SelectedIndexChanged += new System.EventHandler(this.ilstMaterialPreparation_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "send_container_clock.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMPRemove);
            this.panel1.Controls.Add(this.btnMPNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 435);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 60);
            this.panel1.TabIndex = 1;
            // 
            // btnMPRemove
            // 
            this.btnMPRemove.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMPRemove.Appearance.Options.UseFont = true;
            this.btnMPRemove.Location = new System.Drawing.Point(142, 15);
            this.btnMPRemove.Name = "btnMPRemove";
            this.btnMPRemove.Size = new System.Drawing.Size(95, 41);
            this.btnMPRemove.TabIndex = 1;
            this.btnMPRemove.Text = "删除";
            this.btnMPRemove.Click += new System.EventHandler(this.btnMPRemove_Click);
            // 
            // btnMPNew
            // 
            this.btnMPNew.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMPNew.Appearance.Options.UseFont = true;
            this.btnMPNew.Location = new System.Drawing.Point(3, 15);
            this.btnMPNew.Name = "btnMPNew";
            this.btnMPNew.Size = new System.Drawing.Size(95, 41);
            this.btnMPNew.TabIndex = 0;
            this.btnMPNew.Text = "新增";
            this.btnMPNew.Click += new System.EventHandler(this.btnMPNew_Click);
            // 
            // grdPWOs
            // 
            this.grdPWOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPWOs.Location = new System.Drawing.Point(5, 5);
            this.grdPWOs.MainView = this.grdvPWOs;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.Size = new System.Drawing.Size(841, 430);
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
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn6});
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
            this.gridColumn5.Caption = "大头数量";
            this.gridColumn5.FieldName = "Quantity1";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPWORemove);
            this.panel2.Controls.Add(this.btnPWOModify);
            this.panel2.Controls.Add(this.btnPWONew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 435);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 60);
            this.panel2.TabIndex = 3;
            // 
            // btnPWORemove
            // 
            this.btnPWORemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWORemove.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWORemove.Appearance.Options.UseFont = true;
            this.btnPWORemove.Location = new System.Drawing.Point(743, 16);
            this.btnPWORemove.Name = "btnPWORemove";
            this.btnPWORemove.Size = new System.Drawing.Size(95, 41);
            this.btnPWORemove.TabIndex = 8;
            this.btnPWORemove.Text = "删除";
            this.btnPWORemove.Click += new System.EventHandler(this.btnPWORemove_Click);
            // 
            // btnPWOModify
            // 
            this.btnPWOModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWOModify.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWOModify.Appearance.Options.UseFont = true;
            this.btnPWOModify.Location = new System.Drawing.Point(628, 16);
            this.btnPWOModify.Name = "btnPWOModify";
            this.btnPWOModify.Size = new System.Drawing.Size(95, 41);
            this.btnPWOModify.TabIndex = 7;
            this.btnPWOModify.Text = "修改";
            this.btnPWOModify.Click += new System.EventHandler(this.btnPWOModify_Click);
            // 
            // btnPWONew
            // 
            this.btnPWONew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWONew.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWONew.Appearance.Options.UseFont = true;
            this.btnPWONew.Location = new System.Drawing.Point(510, 16);
            this.btnPWONew.Name = "btnPWONew";
            this.btnPWONew.Size = new System.Drawing.Size(95, 41);
            this.btnPWONew.TabIndex = 6;
            this.btnPWONew.Text = "新增";
            this.btnPWONew.Click += new System.EventHandler(this.btnPWONew_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "小头数量";
            this.gridColumn1.FieldName = "Quantity2";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "备注";
            this.gridColumn6.FieldName = "DisplayRemark";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            // 
            // frmMaterialPreparation
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1134, 550);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmMaterialPreparation";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "加热炉生产备料";
            this.Shown += new System.EventHandler(this.frmMaterialPreparation_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMaterialPreparation_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ilstMaterialPreparation)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.ImageListBoxControl ilstMaterialPreparation;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnMPRemove;
        private DevExpress.XtraEditors.SimpleButton btnMPNew;
        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnPWORemove;
        private DevExpress.XtraEditors.SimpleButton btnPWOModify;
        private DevExpress.XtraEditors.SimpleButton btnPWONew;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}
