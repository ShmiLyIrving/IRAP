namespace IRAP.Client.GUI.BatchSystem.UserControls
{
    partial class ucPrdtParams_Furnace
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ilstBatchNos = new DevExpress.XtraEditors.ImageListBoxControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblProductTimeSpan = new DevExpress.XtraEditors.LabelControl();
            this.lblBatchNo = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrentBatchNoName = new DevExpress.XtraEditors.LabelControl();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.edtOperatorCode = new DevExpress.XtraEditors.TextEdit();
            this.lblOperator = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectMaterialPreparation = new DevExpress.XtraEditors.SimpleButton();
            this.btnPWORemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnPWOModify = new DevExpress.XtraEditors.SimpleButton();
            this.btnPWONew = new DevExpress.XtraEditors.SimpleButton();
            this.grdPWOs = new DevExpress.XtraGrid.GridControl();
            this.grdvPWOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnParamEdit = new DevExpress.XtraEditors.SimpleButton();
            this.vgrdMethodParams = new DevExpress.XtraVerticalGrid.VGridControl();
            this.btnParamRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnParamNew = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnMaterialPreparation = new DevExpress.XtraEditors.SimpleButton();
            this.btnBegin = new DevExpress.XtraEditors.SimpleButton();
            this.btnEnd = new DevExpress.XtraEditors.SimpleButton();
            this.btnTerminate = new DevExpress.XtraEditors.SimpleButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ilstBatchNos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtOperatorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdMethodParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 5);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.ilstBatchNos);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "正在生产的炉次号";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1035, 569);
            this.splitContainerControl1.SplitterPosition = 229;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ilstBatchNos
            // 
            this.ilstBatchNos.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ilstBatchNos.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ilstBatchNos.Appearance.Options.UseFont = true;
            this.ilstBatchNos.Appearance.Options.UseForeColor = true;
            this.ilstBatchNos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilstBatchNos.ItemHeight = 35;
            this.ilstBatchNos.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, "CA18103001"),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, "<新炉次>")});
            this.ilstBatchNos.Location = new System.Drawing.Point(5, 5);
            this.ilstBatchNos.Name = "ilstBatchNos";
            this.ilstBatchNos.Size = new System.Drawing.Size(215, 525);
            this.ilstBatchNos.TabIndex = 0;
            this.ilstBatchNos.SelectedIndexChanged += new System.EventHandler(this.ilstBatchNos_SelectedIndexChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.splitContainerControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(5, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(791, 494);
            this.panelControl1.TabIndex = 0;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.splitContainerControl3);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl2.Panel2.Controls.Add(this.btnParamEdit);
            this.splitContainerControl2.Panel2.Controls.Add(this.vgrdMethodParams);
            this.splitContainerControl2.Panel2.Controls.Add(this.btnParamRemove);
            this.splitContainerControl2.Panel2.Controls.Add(this.btnParamNew);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            this.splitContainerControl2.Panel2.Text = "生产过程参数";
            this.splitContainerControl2.Size = new System.Drawing.Size(791, 494);
            this.splitContainerControl2.SplitterPosition = 308;
            this.splitContainerControl2.TabIndex = 2;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl3.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl3.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl3.Panel1.Controls.Add(this.lblProductTimeSpan);
            this.splitContainerControl3.Panel1.Controls.Add(this.lblBatchNo);
            this.splitContainerControl3.Panel1.Controls.Add(this.lblCurrentBatchNoName);
            this.splitContainerControl3.Panel1.Controls.Add(this.lblStartTime);
            this.splitContainerControl3.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl3.Panel1.ShowCaption = true;
            this.splitContainerControl3.Panel1.Text = "生产信息";
            this.splitContainerControl3.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl3.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl3.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl3.Panel2.Controls.Add(this.btnSelectMaterialPreparation);
            this.splitContainerControl3.Panel2.Controls.Add(this.btnPWORemove);
            this.splitContainerControl3.Panel2.Controls.Add(this.btnPWOModify);
            this.splitContainerControl3.Panel2.Controls.Add(this.btnPWONew);
            this.splitContainerControl3.Panel2.Controls.Add(this.grdPWOs);
            this.splitContainerControl3.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl3.Panel2.ShowCaption = true;
            this.splitContainerControl3.Panel2.Text = "生产产品信息";
            this.splitContainerControl3.Size = new System.Drawing.Size(791, 308);
            this.splitContainerControl3.SplitterPosition = 120;
            this.splitContainerControl3.TabIndex = 0;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // lblProductTimeSpan
            // 
            this.lblProductTimeSpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductTimeSpan.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblProductTimeSpan.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblProductTimeSpan.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblProductTimeSpan.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblProductTimeSpan.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProductTimeSpan.Location = new System.Drawing.Point(388, 60);
            this.lblProductTimeSpan.Name = "lblProductTimeSpan";
            this.lblProductTimeSpan.Size = new System.Drawing.Size(388, 20);
            this.lblProductTimeSpan.TabIndex = 11;
            // 
            // lblBatchNo
            // 
            this.lblBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBatchNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBatchNo.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblBatchNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBatchNo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblBatchNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBatchNo.Location = new System.Drawing.Point(564, 8);
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(212, 46);
            this.lblBatchNo.TabIndex = 10;
            // 
            // lblCurrentBatchNoName
            // 
            this.lblCurrentBatchNoName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentBatchNoName.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentBatchNoName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblCurrentBatchNoName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCurrentBatchNoName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCurrentBatchNoName.Location = new System.Drawing.Point(388, 8);
            this.lblCurrentBatchNoName.Name = "lblCurrentBatchNoName";
            this.lblCurrentBatchNoName.Size = new System.Drawing.Size(170, 46);
            this.lblCurrentBatchNoName.TabIndex = 9;
            this.lblCurrentBatchNoName.Text = "当前炉次：";
            // 
            // lblStartTime
            // 
            this.lblStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblStartTime.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblStartTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblStartTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStartTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStartTime.Location = new System.Drawing.Point(619, 34);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(157, 20);
            this.lblStartTime.TabIndex = 7;
            this.lblStartTime.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.edtOperatorCode);
            this.groupControl1.Controls.Add(this.lblOperator);
            this.groupControl1.Location = new System.Drawing.Point(8, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(360, 77);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "操作信息";
            // 
            // edtOperatorCode
            // 
            this.edtOperatorCode.EnterMoveNextControl = true;
            this.edtOperatorCode.Location = new System.Drawing.Point(75, 38);
            this.edtOperatorCode.Name = "edtOperatorCode";
            this.edtOperatorCode.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtOperatorCode.Properties.Appearance.Options.UseFont = true;
            this.edtOperatorCode.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.edtOperatorCode.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.edtOperatorCode.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtOperatorCode.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.edtOperatorCode.Size = new System.Drawing.Size(207, 26);
            this.edtOperatorCode.TabIndex = 1;
            this.edtOperatorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtOperatorCode_KeyDown);
            // 
            // lblOperator
            // 
            this.lblOperator.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblOperator.Location = new System.Drawing.Point(13, 41);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(56, 20);
            this.lblOperator.TabIndex = 0;
            this.lblOperator.Text = "操作工：";
            // 
            // btnSelectMaterialPreparation
            // 
            this.btnSelectMaterialPreparation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectMaterialPreparation.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectMaterialPreparation.Appearance.Options.UseFont = true;
            this.btnSelectMaterialPreparation.Location = new System.Drawing.Point(681, 7);
            this.btnSelectMaterialPreparation.Name = "btnSelectMaterialPreparation";
            this.btnSelectMaterialPreparation.Size = new System.Drawing.Size(95, 30);
            this.btnSelectMaterialPreparation.TabIndex = 6;
            this.btnSelectMaterialPreparation.Text = "备料选择";
            this.btnSelectMaterialPreparation.Click += new System.EventHandler(this.btnSelectMaterialPreparation_Click);
            // 
            // btnPWORemove
            // 
            this.btnPWORemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWORemove.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWORemove.Appearance.Options.UseFont = true;
            this.btnPWORemove.Location = new System.Drawing.Point(681, 79);
            this.btnPWORemove.Name = "btnPWORemove";
            this.btnPWORemove.Size = new System.Drawing.Size(95, 30);
            this.btnPWORemove.TabIndex = 5;
            this.btnPWORemove.Text = "删除";
            this.btnPWORemove.Visible = false;
            // 
            // btnPWOModify
            // 
            this.btnPWOModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWOModify.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWOModify.Appearance.Options.UseFont = true;
            this.btnPWOModify.Location = new System.Drawing.Point(681, 43);
            this.btnPWOModify.Name = "btnPWOModify";
            this.btnPWOModify.Size = new System.Drawing.Size(95, 30);
            this.btnPWOModify.TabIndex = 4;
            this.btnPWOModify.Text = "修改";
            this.btnPWOModify.Visible = false;
            // 
            // btnPWONew
            // 
            this.btnPWONew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWONew.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWONew.Appearance.Options.UseFont = true;
            this.btnPWONew.Location = new System.Drawing.Point(681, 7);
            this.btnPWONew.Name = "btnPWONew";
            this.btnPWONew.Size = new System.Drawing.Size(95, 30);
            this.btnPWONew.TabIndex = 3;
            this.btnPWONew.Text = "新增";
            this.btnPWONew.Visible = false;
            // 
            // grdPWOs
            // 
            this.grdPWOs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPWOs.Location = new System.Drawing.Point(8, 7);
            this.grdPWOs.MainView = this.grdvPWOs;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.Size = new System.Drawing.Size(657, 138);
            this.grdPWOs.TabIndex = 0;
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
            // btnParamEdit
            // 
            this.btnParamEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParamEdit.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParamEdit.Appearance.Options.UseFont = true;
            this.btnParamEdit.Location = new System.Drawing.Point(681, 58);
            this.btnParamEdit.Name = "btnParamEdit";
            this.btnParamEdit.Size = new System.Drawing.Size(95, 34);
            this.btnParamEdit.TabIndex = 7;
            this.btnParamEdit.Text = "修改";
            this.btnParamEdit.Click += new System.EventHandler(this.btnParamEdit_Click);
            // 
            // vgrdMethodParams
            // 
            this.vgrdMethodParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vgrdMethodParams.Appearance.FocusedRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.vgrdMethodParams.Appearance.FocusedRecord.ForeColor = System.Drawing.Color.Blue;
            this.vgrdMethodParams.Appearance.FocusedRecord.Options.UseBackColor = true;
            this.vgrdMethodParams.Appearance.FocusedRecord.Options.UseForeColor = true;
            this.vgrdMethodParams.Appearance.PressedRow.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.vgrdMethodParams.Appearance.PressedRow.Options.UseFont = true;
            this.vgrdMethodParams.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.vgrdMethodParams.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vgrdMethodParams.Location = new System.Drawing.Point(8, 8);
            this.vgrdMethodParams.Name = "vgrdMethodParams";
            this.vgrdMethodParams.OptionsBehavior.Editable = false;
            this.vgrdMethodParams.RowHeaderWidth = 113;
            this.vgrdMethodParams.Size = new System.Drawing.Size(651, 133);
            this.vgrdMethodParams.TabIndex = 10;
            // 
            // btnParamRemove
            // 
            this.btnParamRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParamRemove.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParamRemove.Appearance.Options.UseFont = true;
            this.btnParamRemove.Location = new System.Drawing.Point(681, 107);
            this.btnParamRemove.Name = "btnParamRemove";
            this.btnParamRemove.Size = new System.Drawing.Size(95, 34);
            this.btnParamRemove.TabIndex = 8;
            this.btnParamRemove.Text = "删除";
            this.btnParamRemove.Click += new System.EventHandler(this.btnParamRemove_Click);
            // 
            // btnParamNew
            // 
            this.btnParamNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParamNew.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParamNew.Appearance.Options.UseFont = true;
            this.btnParamNew.Location = new System.Drawing.Point(681, 8);
            this.btnParamNew.Name = "btnParamNew";
            this.btnParamNew.Size = new System.Drawing.Size(95, 34);
            this.btnParamNew.TabIndex = 6;
            this.btnParamNew.Text = "新增";
            this.btnParamNew.Click += new System.EventHandler(this.btnParamNew_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnMaterialPreparation);
            this.panelControl2.Controls.Add(this.btnBegin);
            this.panelControl2.Controls.Add(this.btnEnd);
            this.panelControl2.Controls.Add(this.btnTerminate);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(5, 499);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(791, 65);
            this.panelControl2.TabIndex = 1;
            // 
            // btnMaterialPreparation
            // 
            this.btnMaterialPreparation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMaterialPreparation.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterialPreparation.Appearance.Options.UseFont = true;
            this.btnMaterialPreparation.Location = new System.Drawing.Point(10, 13);
            this.btnMaterialPreparation.Name = "btnMaterialPreparation";
            this.btnMaterialPreparation.Size = new System.Drawing.Size(118, 43);
            this.btnMaterialPreparation.TabIndex = 9;
            this.btnMaterialPreparation.Text = "生产备料";
            this.btnMaterialPreparation.Click += new System.EventHandler(this.btnMaterialPreparation_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBegin.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBegin.Appearance.Options.UseFont = true;
            this.btnBegin.Location = new System.Drawing.Point(321, 13);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(118, 43);
            this.btnBegin.TabIndex = 6;
            this.btnBegin.Text = "生产开始";
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Appearance.Options.UseFont = true;
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(660, 13);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(118, 43);
            this.btnEnd.TabIndex = 8;
            this.btnEnd.Text = "生产结束";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnTerminate
            // 
            this.btnTerminate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminate.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminate.Appearance.Options.UseFont = true;
            this.btnTerminate.Location = new System.Drawing.Point(492, 13);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(118, 43);
            this.btnTerminate.TabIndex = 7;
            this.btnTerminate.Text = "生产终止";
            this.btnTerminate.Click += new System.EventHandler(this.btnTerminate_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ucPrdtParams_Furnace
            // 
            this.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucPrdtParams_Furnace";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1045, 579);
            this.Load += new System.EventHandler(this.ucPrdtParams_Furnace_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucPrdtParams_Furnace_Paint);
            this.Enter += new System.EventHandler(this.ucPrdtParams_Furnace_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ilstBatchNos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtOperatorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdMethodParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnBegin;
        private DevExpress.XtraEditors.SimpleButton btnEnd;
        private DevExpress.XtraEditors.SimpleButton btnTerminate;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraEditors.LabelControl lblProductTimeSpan;
        private DevExpress.XtraEditors.LabelControl lblBatchNo;
        private DevExpress.XtraEditors.LabelControl lblCurrentBatchNoName;
        private DevExpress.XtraEditors.LabelControl lblStartTime;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit edtOperatorCode;
        private DevExpress.XtraEditors.LabelControl lblOperator;
        private DevExpress.XtraEditors.SimpleButton btnPWORemove;
        private DevExpress.XtraEditors.SimpleButton btnPWOModify;
        private DevExpress.XtraEditors.SimpleButton btnPWONew;
        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraVerticalGrid.VGridControl vgrdMethodParams;
        private DevExpress.XtraEditors.SimpleButton btnParamRemove;
        private DevExpress.XtraEditors.SimpleButton btnParamNew;
        private DevExpress.XtraEditors.SimpleButton btnMaterialPreparation;
        private DevExpress.XtraEditors.SimpleButton btnSelectMaterialPreparation;
        private DevExpress.XtraEditors.ImageListBoxControl ilstBatchNos;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnParamEdit;
    }
}
