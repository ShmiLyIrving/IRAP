namespace IRAP.Client.GUI.MESPDC.UserControls
{
    partial class ucBatchSysProduction
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
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblProductTimeSpan = new DevExpress.XtraEditors.LabelControl();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.lblBatchNo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboPrdtType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPrdtType = new DevExpress.XtraEditors.LabelControl();
            this.edtOperatorCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            this.btnParamRemove = new DevExpress.XtraEditors.SimpleButton();
            this.vgrdMethodParams = new DevExpress.XtraVerticalGrid.VGridControl();
            this.btnParamNew = new DevExpress.XtraEditors.SimpleButton();
            this.grdParams = new DevExpress.XtraGrid.GridControl();
            this.grdvParams = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnParamName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue07 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue08 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue09 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmParamValue16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBegin = new DevExpress.XtraEditors.SimpleButton();
            this.btnEnd = new DevExpress.XtraEditors.SimpleButton();
            this.lblCurrentTime = new DevExpress.XtraEditors.LabelControl();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrdtType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOperatorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdMethodParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvParams)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(3, 3);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel2.Controls.Add(this.btnParamRemove);
            this.splitContainerControl1.Panel2.Controls.Add(this.vgrdMethodParams);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnParamNew);
            this.splitContainerControl1.Panel2.Controls.Add(this.grdParams);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "生产过程参数";
            this.splitContainerControl1.Size = new System.Drawing.Size(1039, 499);
            this.splitContainerControl1.SplitterPosition = 308;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl2.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl2.Panel1.Controls.Add(this.lblProductTimeSpan);
            this.splitContainerControl2.Panel1.Controls.Add(this.lblStartTime);
            this.splitContainerControl2.Panel1.Controls.Add(this.lblBatchNo);
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl2.Panel1.ShowCaption = true;
            this.splitContainerControl2.Panel1.Text = "生产信息";
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl2.Panel2.Controls.Add(this.btnPWORemove);
            this.splitContainerControl2.Panel2.Controls.Add(this.btnPWOModify);
            this.splitContainerControl2.Panel2.Controls.Add(this.btnPWONew);
            this.splitContainerControl2.Panel2.Controls.Add(this.grdPWOs);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            this.splitContainerControl2.Panel2.Text = "生产产品信息";
            this.splitContainerControl2.Size = new System.Drawing.Size(1039, 308);
            this.splitContainerControl2.SplitterPosition = 120;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // lblProductTimeSpan
            // 
            this.lblProductTimeSpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductTimeSpan.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblProductTimeSpan.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblProductTimeSpan.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblProductTimeSpan.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblProductTimeSpan.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProductTimeSpan.Location = new System.Drawing.Point(867, 60);
            this.lblProductTimeSpan.Name = "lblProductTimeSpan";
            this.lblProductTimeSpan.Size = new System.Drawing.Size(157, 20);
            this.lblProductTimeSpan.TabIndex = 8;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblStartTime.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblStartTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblStartTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStartTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStartTime.Location = new System.Drawing.Point(867, 34);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(157, 20);
            this.lblStartTime.TabIndex = 7;
            // 
            // lblBatchNo
            // 
            this.lblBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBatchNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblBatchNo.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblBatchNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBatchNo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblBatchNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBatchNo.Location = new System.Drawing.Point(867, 8);
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(157, 20);
            this.lblBatchNo.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(763, 60);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(98, 20);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "生产时长：";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(763, 34);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(98, 20);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "生产开始时间：";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(763, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(98, 20);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "当前炉次：";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboPrdtType);
            this.groupControl1.Controls.Add(this.lblPrdtType);
            this.groupControl1.Controls.Add(this.edtOperatorCode);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(8, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(604, 77);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "操作信息";
            // 
            // cboPrdtType
            // 
            this.cboPrdtType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrdtType.Location = new System.Drawing.Point(461, 38);
            this.cboPrdtType.Name = "cboPrdtType";
            this.cboPrdtType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrdtType.Properties.Appearance.Options.UseFont = true;
            this.cboPrdtType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPrdtType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPrdtType.Size = new System.Drawing.Size(131, 26);
            this.cboPrdtType.TabIndex = 3;
            // 
            // lblPrdtType
            // 
            this.lblPrdtType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrdtType.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblPrdtType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPrdtType.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPrdtType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPrdtType.Location = new System.Drawing.Point(357, 41);
            this.lblPrdtType.Name = "lblPrdtType";
            this.lblPrdtType.Size = new System.Drawing.Size(98, 20);
            this.lblPrdtType.TabIndex = 2;
            this.lblPrdtType.Text = "产品类别：";
            // 
            // edtOperatorCode
            // 
            this.edtOperatorCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtOperatorCode.EnterMoveNextControl = true;
            this.edtOperatorCode.Location = new System.Drawing.Point(75, 38);
            this.edtOperatorCode.Name = "edtOperatorCode";
            this.edtOperatorCode.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtOperatorCode.Properties.Appearance.Options.UseFont = true;
            this.edtOperatorCode.Size = new System.Drawing.Size(268, 26);
            this.edtOperatorCode.TabIndex = 1;
            this.edtOperatorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtOperatorCode_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl1.Location = new System.Drawing.Point(13, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "操作工：";
            // 
            // btnPWORemove
            // 
            this.btnPWORemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWORemove.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWORemove.Appearance.Options.UseFont = true;
            this.btnPWORemove.Location = new System.Drawing.Point(929, 93);
            this.btnPWORemove.Name = "btnPWORemove";
            this.btnPWORemove.Size = new System.Drawing.Size(95, 30);
            this.btnPWORemove.TabIndex = 5;
            this.btnPWORemove.Text = "删除";
            this.btnPWORemove.Click += new System.EventHandler(this.btnPWORemove_Click);
            // 
            // btnPWOModify
            // 
            this.btnPWOModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWOModify.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWOModify.Appearance.Options.UseFont = true;
            this.btnPWOModify.Location = new System.Drawing.Point(929, 50);
            this.btnPWOModify.Name = "btnPWOModify";
            this.btnPWOModify.Size = new System.Drawing.Size(95, 30);
            this.btnPWOModify.TabIndex = 4;
            this.btnPWOModify.Text = "修改";
            this.btnPWOModify.Click += new System.EventHandler(this.btnPWOModify_Click);
            // 
            // btnPWONew
            // 
            this.btnPWONew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWONew.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWONew.Appearance.Options.UseFont = true;
            this.btnPWONew.Location = new System.Drawing.Point(929, 7);
            this.btnPWONew.Name = "btnPWONew";
            this.btnPWONew.Size = new System.Drawing.Size(95, 30);
            this.btnPWONew.TabIndex = 3;
            this.btnPWONew.Text = "新增";
            this.btnPWONew.Click += new System.EventHandler(this.btnPWONew_Click);
            // 
            // grdPWOs
            // 
            this.grdPWOs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPWOs.Location = new System.Drawing.Point(8, 7);
            this.grdPWOs.MainView = this.grdvPWOs;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.Size = new System.Drawing.Size(905, 138);
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
            // btnParamRemove
            // 
            this.btnParamRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParamRemove.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParamRemove.Appearance.Options.UseFont = true;
            this.btnParamRemove.Location = new System.Drawing.Point(929, 44);
            this.btnParamRemove.Name = "btnParamRemove";
            this.btnParamRemove.Size = new System.Drawing.Size(95, 30);
            this.btnParamRemove.TabIndex = 8;
            this.btnParamRemove.Text = "删除";
            // 
            // vgrdMethodParams
            // 
            this.vgrdMethodParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vgrdMethodParams.Appearance.PressedRow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vgrdMethodParams.Appearance.PressedRow.Options.UseFont = true;
            this.vgrdMethodParams.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.vgrdMethodParams.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vgrdMethodParams.Location = new System.Drawing.Point(8, 8);
            this.vgrdMethodParams.Name = "vgrdMethodParams";
            this.vgrdMethodParams.OptionsBehavior.Editable = false;
            this.vgrdMethodParams.RowHeaderWidth = 113;
            this.vgrdMethodParams.Size = new System.Drawing.Size(905, 138);
            this.vgrdMethodParams.TabIndex = 7;
            // 
            // btnParamNew
            // 
            this.btnParamNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParamNew.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParamNew.Appearance.Options.UseFont = true;
            this.btnParamNew.Location = new System.Drawing.Point(929, 8);
            this.btnParamNew.Name = "btnParamNew";
            this.btnParamNew.Size = new System.Drawing.Size(95, 30);
            this.btnParamNew.TabIndex = 6;
            this.btnParamNew.Text = "新增";
            // 
            // grdParams
            // 
            this.grdParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdParams.Location = new System.Drawing.Point(8, 8);
            this.grdParams.MainView = this.grdvParams;
            this.grdParams.Name = "grdParams";
            this.grdParams.Size = new System.Drawing.Size(905, 138);
            this.grdParams.TabIndex = 1;
            this.grdParams.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvParams});
            this.grdParams.Visible = false;
            // 
            // grdvParams
            // 
            this.grdvParams.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvParams.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvParams.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvParams.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvParams.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvParams.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvParams.Appearance.Row.Options.UseFont = true;
            this.grdvParams.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnParamName,
            this.grdclmParamValue01,
            this.grdclmParamValue02,
            this.grdclmParamValue03,
            this.grdclmParamValue04,
            this.grdclmParamValue05,
            this.grdclmParamValue06,
            this.grdclmParamValue07,
            this.grdclmParamValue08,
            this.grdclmParamValue09,
            this.grdclmParamValue10,
            this.grdclmParamValue11,
            this.grdclmParamValue12,
            this.grdclmParamValue13,
            this.grdclmParamValue14,
            this.grdclmParamValue15,
            this.grdclmParamValue16});
            this.grdvParams.GridControl = this.grdParams;
            this.grdvParams.Name = "grdvParams";
            this.grdvParams.OptionsView.ColumnAutoWidth = false;
            this.grdvParams.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnParamName
            // 
            this.grdclmnParamName.Caption = "工艺参数名称";
            this.grdclmnParamName.FieldName = "StandardName";
            this.grdclmnParamName.Name = "grdclmnParamName";
            this.grdclmnParamName.Visible = true;
            this.grdclmnParamName.VisibleIndex = 0;
            // 
            // grdclmParamValue01
            // 
            this.grdclmParamValue01.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue01.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue01.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue01.Caption = "工艺参数值 1";
            this.grdclmParamValue01.FieldName = "Value01";
            this.grdclmParamValue01.Name = "grdclmParamValue01";
            this.grdclmParamValue01.Visible = true;
            this.grdclmParamValue01.VisibleIndex = 1;
            // 
            // grdclmParamValue02
            // 
            this.grdclmParamValue02.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue02.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue02.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue02.Caption = "工艺参数值 2";
            this.grdclmParamValue02.FieldName = "Value02";
            this.grdclmParamValue02.Name = "grdclmParamValue02";
            // 
            // grdclmParamValue03
            // 
            this.grdclmParamValue03.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue03.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue03.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue03.Caption = "工艺参数值 3";
            this.grdclmParamValue03.FieldName = "Value03";
            this.grdclmParamValue03.Name = "grdclmParamValue03";
            // 
            // grdclmParamValue04
            // 
            this.grdclmParamValue04.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue04.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue04.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue04.Caption = "工艺参数值 4";
            this.grdclmParamValue04.FieldName = "Value04";
            this.grdclmParamValue04.Name = "grdclmParamValue04";
            // 
            // grdclmParamValue05
            // 
            this.grdclmParamValue05.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue05.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue05.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue05.Caption = "工艺参数值 5";
            this.grdclmParamValue05.FieldName = "Value05";
            this.grdclmParamValue05.Name = "grdclmParamValue05";
            // 
            // grdclmParamValue06
            // 
            this.grdclmParamValue06.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue06.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue06.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue06.Caption = "工艺参数值 6";
            this.grdclmParamValue06.FieldName = "Value06";
            this.grdclmParamValue06.Name = "grdclmParamValue06";
            // 
            // grdclmParamValue07
            // 
            this.grdclmParamValue07.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue07.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue07.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue07.Caption = "工艺参数值 7";
            this.grdclmParamValue07.FieldName = "Value07";
            this.grdclmParamValue07.Name = "grdclmParamValue07";
            // 
            // grdclmParamValue08
            // 
            this.grdclmParamValue08.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue08.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue08.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue08.Caption = "工艺参数值 8";
            this.grdclmParamValue08.FieldName = "Value08";
            this.grdclmParamValue08.Name = "grdclmParamValue08";
            // 
            // grdclmParamValue09
            // 
            this.grdclmParamValue09.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue09.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue09.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue09.Caption = "工艺参数值 9";
            this.grdclmParamValue09.FieldName = "Value09";
            this.grdclmParamValue09.Name = "grdclmParamValue09";
            // 
            // grdclmParamValue10
            // 
            this.grdclmParamValue10.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue10.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue10.Caption = "工艺参数值 10";
            this.grdclmParamValue10.FieldName = "Value10";
            this.grdclmParamValue10.Name = "grdclmParamValue10";
            // 
            // grdclmParamValue11
            // 
            this.grdclmParamValue11.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue11.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue11.Caption = "工艺参数值 11";
            this.grdclmParamValue11.FieldName = "Value11";
            this.grdclmParamValue11.Name = "grdclmParamValue11";
            // 
            // grdclmParamValue12
            // 
            this.grdclmParamValue12.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue12.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue12.Caption = "工艺参数值 12";
            this.grdclmParamValue12.FieldName = "Value12";
            this.grdclmParamValue12.Name = "grdclmParamValue12";
            // 
            // grdclmParamValue13
            // 
            this.grdclmParamValue13.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue13.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue13.Caption = "工艺参数值 13";
            this.grdclmParamValue13.FieldName = "Value13";
            this.grdclmParamValue13.Name = "grdclmParamValue13";
            // 
            // grdclmParamValue14
            // 
            this.grdclmParamValue14.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue14.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue14.Caption = "工艺参数值 14";
            this.grdclmParamValue14.FieldName = "Value14";
            this.grdclmParamValue14.Name = "grdclmParamValue14";
            // 
            // grdclmParamValue15
            // 
            this.grdclmParamValue15.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue15.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue15.Caption = "工艺参数值 15";
            this.grdclmParamValue15.FieldName = "Value15";
            this.grdclmParamValue15.Name = "grdclmParamValue15";
            // 
            // grdclmParamValue16
            // 
            this.grdclmParamValue16.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmParamValue16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmParamValue16.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmParamValue16.Caption = "工艺参数值 16";
            this.grdclmParamValue16.FieldName = "Value16";
            this.grdclmParamValue16.Name = "grdclmParamValue16";
            // 
            // btnBegin
            // 
            this.btnBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBegin.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBegin.Appearance.Options.UseFont = true;
            this.btnBegin.Location = new System.Drawing.Point(743, 522);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(118, 43);
            this.btnBegin.TabIndex = 1;
            this.btnBegin.Text = "生产开始";
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Appearance.Options.UseFont = true;
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(911, 522);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(118, 43);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "生产结束";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentTime.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTime.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentTime.Location = new System.Drawing.Point(13, 535);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(0, 19);
            this.lblCurrentTime.TabIndex = 3;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ucBatchSysProduction
            // 
            this.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucBatchSysProduction";
            this.Size = new System.Drawing.Size(1045, 579);
            this.Load += new System.EventHandler(this.ucBatchSysProduction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrdtType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOperatorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdMethodParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblPrdtType;
        private DevExpress.XtraEditors.TextEdit edtOperatorCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblProductTimeSpan;
        private DevExpress.XtraEditors.LabelControl lblStartTime;
        private DevExpress.XtraEditors.LabelControl lblBatchNo;
        private DevExpress.XtraEditors.SimpleButton btnBegin;
        private DevExpress.XtraEditors.SimpleButton btnEnd;
        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOs;
        private DevExpress.XtraEditors.SimpleButton btnPWORemove;
        private DevExpress.XtraEditors.SimpleButton btnPWOModify;
        private DevExpress.XtraEditors.SimpleButton btnPWONew;
        private DevExpress.XtraEditors.SimpleButton btnParamNew;
        private DevExpress.XtraGrid.GridControl grdParams;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvParams;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnParamName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue01;
        private DevExpress.XtraEditors.ComboBoxEdit cboPrdtType;
        private DevExpress.XtraEditors.LabelControl lblCurrentTime;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue02;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue03;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue04;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue05;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue06;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue07;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue08;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue09;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue10;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue11;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue12;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue13;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue14;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue15;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmParamValue16;
        private DevExpress.XtraVerticalGrid.VGridControl vgrdMethodParams;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductName;
        private DevExpress.XtraEditors.SimpleButton btnParamRemove;
    }
}
