namespace IRAP.Client.GUI.BatchSystem.UserControls
{
    partial class ucQualityInspecting_Furnace
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPWORemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnPWOModify = new DevExpress.XtraEditors.SimpleButton();
            this.vgrdInspectParams = new DevExpress.XtraVerticalGrid.VGridControl();
            this.btnSaveParams = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnPWONew = new DevExpress.XtraEditors.SimpleButton();
            this.edtOperatorCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdvPWOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdPWOs = new DevExpress.XtraGrid.GridControl();
            this.grdvBatchNos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnBatchNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdBatchNos = new DevExpress.XtraGrid.GridControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdInspectParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtOperatorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBatchNos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatchNos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPWORemove
            // 
            this.btnPWORemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWORemove.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnPWORemove.Appearance.Options.UseFont = true;
            this.btnPWORemove.Enabled = false;
            this.btnPWORemove.Location = new System.Drawing.Point(810, 175);
            this.btnPWORemove.Name = "btnPWORemove";
            this.btnPWORemove.Size = new System.Drawing.Size(95, 45);
            this.btnPWORemove.TabIndex = 11;
            this.btnPWORemove.Text = "删除";
            this.btnPWORemove.Click += new System.EventHandler(this.btnPWORemove_Click);
            // 
            // btnPWOModify
            // 
            this.btnPWOModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWOModify.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnPWOModify.Appearance.Options.UseFont = true;
            this.btnPWOModify.Enabled = false;
            this.btnPWOModify.Location = new System.Drawing.Point(810, 106);
            this.btnPWOModify.Name = "btnPWOModify";
            this.btnPWOModify.Size = new System.Drawing.Size(95, 45);
            this.btnPWOModify.TabIndex = 10;
            this.btnPWOModify.Text = "修改";
            this.btnPWOModify.Click += new System.EventHandler(this.btnPWOModify_Click);
            // 
            // vgrdInspectParams
            // 
            this.vgrdInspectParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vgrdInspectParams.Appearance.FocusedRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.vgrdInspectParams.Appearance.FocusedRecord.ForeColor = System.Drawing.Color.Blue;
            this.vgrdInspectParams.Appearance.FocusedRecord.Options.UseBackColor = true;
            this.vgrdInspectParams.Appearance.FocusedRecord.Options.UseForeColor = true;
            this.vgrdInspectParams.Appearance.PressedRow.Font = new System.Drawing.Font("新宋体", 12F);
            this.vgrdInspectParams.Appearance.PressedRow.Options.UseFont = true;
            this.vgrdInspectParams.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("新宋体", 12F);
            this.vgrdInspectParams.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vgrdInspectParams.Enabled = false;
            this.vgrdInspectParams.Location = new System.Drawing.Point(12, 37);
            this.vgrdInspectParams.Name = "vgrdInspectParams";
            this.vgrdInspectParams.OptionsBehavior.Editable = false;
            this.vgrdInspectParams.RowHeaderWidth = 113;
            this.vgrdInspectParams.Size = new System.Drawing.Size(772, 194);
            this.vgrdInspectParams.TabIndex = 8;
            // 
            // btnSaveParams
            // 
            this.btnSaveParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveParams.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnSaveParams.Appearance.Options.UseFont = true;
            this.btnSaveParams.Enabled = false;
            this.btnSaveParams.Location = new System.Drawing.Point(820, 268);
            this.btnSaveParams.Name = "btnSaveParams";
            this.btnSaveParams.Size = new System.Drawing.Size(95, 45);
            this.btnSaveParams.TabIndex = 12;
            this.btnSaveParams.Text = "保存";
            this.btnSaveParams.Click += new System.EventHandler(this.btnSaveParams_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnPWORemove);
            this.groupControl1.Controls.Add(this.btnPWOModify);
            this.groupControl1.Controls.Add(this.btnPWONew);
            this.groupControl1.Controls.Add(this.vgrdInspectParams);
            this.groupControl1.Location = new System.Drawing.Point(10, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(917, 243);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "检验内容";
            // 
            // btnPWONew
            // 
            this.btnPWONew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWONew.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnPWONew.Appearance.Options.UseFont = true;
            this.btnPWONew.Enabled = false;
            this.btnPWONew.Location = new System.Drawing.Point(810, 37);
            this.btnPWONew.Name = "btnPWONew";
            this.btnPWONew.Size = new System.Drawing.Size(95, 45);
            this.btnPWONew.TabIndex = 9;
            this.btnPWONew.Text = "新增";
            this.btnPWONew.Click += new System.EventHandler(this.btnPWONew_Click);
            // 
            // edtOperatorCode
            // 
            this.edtOperatorCode.EnterMoveNextControl = true;
            this.edtOperatorCode.Location = new System.Drawing.Point(125, 11);
            this.edtOperatorCode.Name = "edtOperatorCode";
            this.edtOperatorCode.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.edtOperatorCode.Properties.Appearance.Options.UseFont = true;
            this.edtOperatorCode.Size = new System.Drawing.Size(219, 22);
            this.edtOperatorCode.TabIndex = 3;
            this.edtOperatorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtOperatorCode_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(10, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(109, 20);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "检验人员：";
            // 
            // grdvPWOs
            // 
            this.grdvPWOs.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvPWOs.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.grdvPWOs.RowHeight = 34;
            this.grdvPWOs.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.grdvPWOs_FocusedRowObjectChanged);
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
            this.gridColumn5.FieldName = "Qty";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // grdPWOs
            // 
            this.grdPWOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPWOs.Location = new System.Drawing.Point(10, 10);
            this.grdPWOs.MainView = this.grdvPWOs;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.Size = new System.Drawing.Size(678, 141);
            this.grdPWOs.TabIndex = 1;
            this.grdPWOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPWOs});
            // 
            // grdvBatchNos
            // 
            this.grdvBatchNos.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdvBatchNos.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvBatchNos.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvBatchNos.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvBatchNos.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvBatchNos.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdvBatchNos.Appearance.Row.Options.UseFont = true;
            this.grdvBatchNos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnBatchNo});
            this.grdvBatchNos.GridControl = this.grdBatchNos;
            this.grdvBatchNos.Name = "grdvBatchNos";
            this.grdvBatchNos.OptionsBehavior.Editable = false;
            this.grdvBatchNos.OptionsView.ShowGroupPanel = false;
            this.grdvBatchNos.RowHeight = 34;
            this.grdvBatchNos.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.grdvBatchNos_FocusedRowObjectChanged);
            // 
            // grdclmnBatchNo
            // 
            this.grdclmnBatchNo.Caption = "炉次号";
            this.grdclmnBatchNo.FieldName = "BatchNumber";
            this.grdclmnBatchNo.Name = "grdclmnBatchNo";
            this.grdclmnBatchNo.Visible = true;
            this.grdclmnBatchNo.VisibleIndex = 0;
            // 
            // grdBatchNos
            // 
            this.grdBatchNos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBatchNos.Location = new System.Drawing.Point(10, 10);
            this.grdBatchNos.MainView = this.grdvBatchNos;
            this.grdBatchNos.Name = "grdBatchNos";
            this.grdBatchNos.Size = new System.Drawing.Size(186, 141);
            this.grdBatchNos.TabIndex = 1;
            this.grdBatchNos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvBatchNos});
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl2.Enabled = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(10, 41);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainerControl2.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel1.Controls.Add(this.grdBatchNos);
            this.splitContainerControl2.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl2.Panel1.ShowCaption = true;
            this.splitContainerControl2.Panel1.Text = "炉次";
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel2.Controls.Add(this.grdPWOs);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            this.splitContainerControl2.Panel2.Text = "生产工单";
            this.splitContainerControl2.Size = new System.Drawing.Size(917, 186);
            this.splitContainerControl2.SplitterPosition = 210;
            this.splitContainerControl2.TabIndex = 6;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 5);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.edtOperatorCode);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "生产信息";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.btnSaveParams);
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "检验信息";
            this.splitContainerControl1.Size = new System.Drawing.Size(941, 615);
            this.splitContainerControl1.SplitterPosition = 262;
            this.splitContainerControl1.TabIndex = 8;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ucQualityInspecting_Furnace
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucQualityInspecting_Furnace";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(951, 625);
            this.Enter += new System.EventHandler(this.ucQualityInspecting_Furnace_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.vgrdInspectParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtOperatorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvBatchNos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatchNos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPWORemove;
        private DevExpress.XtraEditors.SimpleButton btnPWOModify;
        private DevExpress.XtraVerticalGrid.VGridControl vgrdInspectParams;
        private DevExpress.XtraEditors.SimpleButton btnSaveParams;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPWONew;
        private DevExpress.XtraEditors.TextEdit edtOperatorCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductName;
        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnBatchNo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvBatchNos;
        private DevExpress.XtraGrid.GridControl grdBatchNos;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}
