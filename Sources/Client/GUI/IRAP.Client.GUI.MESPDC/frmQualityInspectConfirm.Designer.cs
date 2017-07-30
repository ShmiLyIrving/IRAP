namespace IRAP.Client.GUI.MESPDC
{
    partial class frmQualityInspectConfirm
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
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdBatchNos = new DevExpress.XtraGrid.GridControl();
            this.grdvBatchNos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnBatchNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdPWOs = new DevExpress.XtraGrid.GridControl();
            this.grdvPWOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtOperatorCode = new DevExpress.XtraEditors.TextEdit();
            this.cboWorkUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnInspectConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnPWORemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnPWOModify = new DevExpress.XtraEditors.SimpleButton();
            this.btnPWONew = new DevExpress.XtraEditors.SimpleButton();
            this.vgrdInspectParams = new DevExpress.XtraVerticalGrid.VGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatchNos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBatchNos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOperatorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdInspectParams)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "frmCustomBase";
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
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.edtOperatorCode);
            this.splitContainerControl1.Panel1.Controls.Add(this.cboWorkUnit);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "生产信息";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.btnInspectConfirm);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "检验信息";
            this.splitContainerControl1.Size = new System.Drawing.Size(891, 551);
            this.splitContainerControl1.SplitterPosition = 262;
            this.splitContainerControl1.TabIndex = 7;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl2.Enabled = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(10, 35);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.splitContainerControl2.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel1.Controls.Add(this.grdBatchNos);
            this.splitContainerControl2.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl2.Panel1.ShowCaption = true;
            this.splitContainerControl2.Panel1.Text = "炉次";
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel2.Controls.Add(this.grdPWOs);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            this.splitContainerControl2.Panel2.Text = "生产工单";
            this.splitContainerControl2.Size = new System.Drawing.Size(867, 188);
            this.splitContainerControl2.SplitterPosition = 472;
            this.splitContainerControl2.TabIndex = 6;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // grdBatchNos
            // 
            this.grdBatchNos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBatchNos.Location = new System.Drawing.Point(10, 10);
            this.grdBatchNos.MainView = this.grdvBatchNos;
            this.grdBatchNos.Name = "grdBatchNos";
            this.grdBatchNos.Size = new System.Drawing.Size(448, 139);
            this.grdBatchNos.TabIndex = 1;
            this.grdBatchNos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvBatchNos});
            // 
            // grdvBatchNos
            // 
            this.grdvBatchNos.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvBatchNos.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvBatchNos.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvBatchNos.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvBatchNos.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvBatchNos.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvBatchNos.Appearance.Row.Options.UseFont = true;
            this.grdvBatchNos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnBatchNo});
            this.grdvBatchNos.GridControl = this.grdBatchNos;
            this.grdvBatchNos.Name = "grdvBatchNos";
            this.grdvBatchNos.OptionsBehavior.Editable = false;
            this.grdvBatchNos.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnBatchNo
            // 
            this.grdclmnBatchNo.Caption = "炉次号";
            this.grdclmnBatchNo.FieldName = "BatchNumber";
            this.grdclmnBatchNo.Name = "grdclmnBatchNo";
            this.grdclmnBatchNo.Visible = true;
            this.grdclmnBatchNo.VisibleIndex = 0;
            // 
            // grdPWOs
            // 
            this.grdPWOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPWOs.Location = new System.Drawing.Point(10, 10);
            this.grdPWOs.MainView = this.grdvPWOs;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.Size = new System.Drawing.Size(366, 139);
            this.grdPWOs.TabIndex = 1;
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
            this.gridColumn2.FieldName = "ProductNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // grdclmnProductName
            // 
            this.grdclmnProductName.Caption = "产品物料名称";
            this.grdclmnProductName.FieldName = "ProductName";
            this.grdclmnProductName.Name = "grdclmnProductName";
            this.grdclmnProductName.Visible = true;
            this.grdclmnProductName.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "批次号";
            this.gridColumn3.FieldName = "BatchNo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "材质";
            this.gridColumn4.FieldName = "TextureCode";
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
            // edtOperatorCode
            // 
            this.edtOperatorCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtOperatorCode.EnterMoveNextControl = true;
            this.edtOperatorCode.Location = new System.Drawing.Point(658, 3);
            this.edtOperatorCode.Name = "edtOperatorCode";
            this.edtOperatorCode.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtOperatorCode.Properties.Appearance.Options.UseFont = true;
            this.edtOperatorCode.Size = new System.Drawing.Size(219, 26);
            this.edtOperatorCode.TabIndex = 3;
            // 
            // cboWorkUnit
            // 
            this.cboWorkUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWorkUnit.Enabled = false;
            this.cboWorkUnit.Location = new System.Drawing.Point(69, 3);
            this.cboWorkUnit.Name = "cboWorkUnit";
            this.cboWorkUnit.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWorkUnit.Properties.Appearance.Options.UseFont = true;
            this.cboWorkUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboWorkUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboWorkUnit.Size = new System.Drawing.Size(417, 26);
            this.cboWorkUnit.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(542, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(110, 20);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "检验员：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(3, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 20);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "设备：";
            // 
            // btnInspectConfirm
            // 
            this.btnInspectConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInspectConfirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInspectConfirm.Appearance.Options.UseFont = true;
            this.btnInspectConfirm.Enabled = false;
            this.btnInspectConfirm.Location = new System.Drawing.Point(770, 215);
            this.btnInspectConfirm.Name = "btnInspectConfirm";
            this.btnInspectConfirm.Size = new System.Drawing.Size(95, 30);
            this.btnInspectConfirm.TabIndex = 12;
            this.btnInspectConfirm.Text = "确认";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnPWORemove);
            this.groupControl1.Controls.Add(this.btnPWOModify);
            this.groupControl1.Controls.Add(this.btnPWONew);
            this.groupControl1.Controls.Add(this.vgrdInspectParams);
            this.groupControl1.Location = new System.Drawing.Point(10, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(867, 194);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "检验内容";
            // 
            // btnPWORemove
            // 
            this.btnPWORemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWORemove.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWORemove.Appearance.Options.UseFont = true;
            this.btnPWORemove.Enabled = false;
            this.btnPWORemove.Location = new System.Drawing.Point(760, 127);
            this.btnPWORemove.Name = "btnPWORemove";
            this.btnPWORemove.Size = new System.Drawing.Size(95, 30);
            this.btnPWORemove.TabIndex = 11;
            this.btnPWORemove.Text = "删除";
            this.btnPWORemove.Visible = false;
            // 
            // btnPWOModify
            // 
            this.btnPWOModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWOModify.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWOModify.Appearance.Options.UseFont = true;
            this.btnPWOModify.Enabled = false;
            this.btnPWOModify.Location = new System.Drawing.Point(760, 84);
            this.btnPWOModify.Name = "btnPWOModify";
            this.btnPWOModify.Size = new System.Drawing.Size(95, 30);
            this.btnPWOModify.TabIndex = 10;
            this.btnPWOModify.Text = "修改";
            this.btnPWOModify.Visible = false;
            // 
            // btnPWONew
            // 
            this.btnPWONew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWONew.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWONew.Appearance.Options.UseFont = true;
            this.btnPWONew.Enabled = false;
            this.btnPWONew.Location = new System.Drawing.Point(760, 41);
            this.btnPWONew.Name = "btnPWONew";
            this.btnPWONew.Size = new System.Drawing.Size(95, 30);
            this.btnPWONew.TabIndex = 9;
            this.btnPWONew.Text = "新增";
            this.btnPWONew.Visible = false;
            // 
            // vgrdInspectParams
            // 
            this.vgrdInspectParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vgrdInspectParams.Appearance.PressedRow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vgrdInspectParams.Appearance.PressedRow.Options.UseFont = true;
            this.vgrdInspectParams.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.vgrdInspectParams.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vgrdInspectParams.Enabled = false;
            this.vgrdInspectParams.Location = new System.Drawing.Point(12, 41);
            this.vgrdInspectParams.Name = "vgrdInspectParams";
            this.vgrdInspectParams.OptionsBehavior.Editable = false;
            this.vgrdInspectParams.RowHeaderWidth = 113;
            this.vgrdInspectParams.Size = new System.Drawing.Size(722, 141);
            this.vgrdInspectParams.TabIndex = 8;
            // 
            // frmQualityInspectConfirm
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 607);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmQualityInspectConfirm";
            this.Text = "检验员确认";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBatchNos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBatchNos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOperatorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vgrdInspectParams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.GridControl grdBatchNos;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvBatchNos;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnBatchNo;
        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.TextEdit edtOperatorCode;
        private DevExpress.XtraEditors.ComboBoxEdit cboWorkUnit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnInspectConfirm;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPWORemove;
        private DevExpress.XtraEditors.SimpleButton btnPWOModify;
        private DevExpress.XtraEditors.SimpleButton btnPWONew;
        private DevExpress.XtraVerticalGrid.VGridControl vgrdInspectParams;
    }
}
