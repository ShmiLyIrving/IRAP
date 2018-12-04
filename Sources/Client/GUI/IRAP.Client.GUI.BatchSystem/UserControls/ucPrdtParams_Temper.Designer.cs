namespace IRAP.Client.GUI.BatchSystem.UserControls
{
    partial class ucPrdtParams_Temper
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
            this.lblBatchNo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboBatchNos = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDevices = new DevExpress.XtraEditors.LabelControl();
            this.cboDevices = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBatchNos = new DevExpress.XtraEditors.LabelControl();
            this.edtOperatorCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnPWOModify = new DevExpress.XtraEditors.SimpleButton();
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
            this.btnEnd = new DevExpress.XtraEditors.SimpleButton();
            this.btnTerminate = new DevExpress.XtraEditors.SimpleButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblCurrentTime = new DevExpress.XtraEditors.LabelControl();
            this.btnBegin = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBatchNos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDevices.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOperatorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdMethodParams)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 5);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl1.Panel2.Controls.Add(this.btnParamEdit);
            this.splitContainerControl1.Panel2.Controls.Add(this.vgrdMethodParams);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnParamRemove);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnParamNew);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "生产过程参数";
            this.splitContainerControl1.Size = new System.Drawing.Size(1035, 499);
            this.splitContainerControl1.SplitterPosition = 308;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainerControl2.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel1.Controls.Add(this.lblProductTimeSpan);
            this.splitContainerControl2.Panel1.Controls.Add(this.lblBatchNo);
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl2.Panel1.Controls.Add(this.lblStartTime);
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl2.Panel1.ShowCaption = true;
            this.splitContainerControl2.Panel1.Text = "生产信息";
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl2.Panel2.Controls.Add(this.btnPWOModify);
            this.splitContainerControl2.Panel2.Controls.Add(this.grdPWOs);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            this.splitContainerControl2.Panel2.Text = "生产产品信息";
            this.splitContainerControl2.Size = new System.Drawing.Size(1035, 308);
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
            this.lblProductTimeSpan.Location = new System.Drawing.Point(632, 60);
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
            this.lblBatchNo.Location = new System.Drawing.Point(808, 8);
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(212, 46);
            this.lblBatchNo.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(632, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(170, 46);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "当前炉次：";
            // 
            // lblStartTime
            // 
            this.lblStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartTime.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblStartTime.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblStartTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblStartTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStartTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStartTime.Location = new System.Drawing.Point(863, 34);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(157, 20);
            this.lblStartTime.TabIndex = 7;
            this.lblStartTime.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(759, 34);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(98, 20);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "生产开始时间：";
            this.labelControl4.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboBatchNos);
            this.groupControl1.Controls.Add(this.lblDevices);
            this.groupControl1.Controls.Add(this.cboDevices);
            this.groupControl1.Controls.Add(this.lblBatchNos);
            this.groupControl1.Controls.Add(this.edtOperatorCode);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(8, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(604, 81);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "操作信息";
            // 
            // cboBatchNos
            // 
            this.cboBatchNos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBatchNos.Location = new System.Drawing.Point(434, 38);
            this.cboBatchNos.Name = "cboBatchNos";
            this.cboBatchNos.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.cboBatchNos.Properties.Appearance.Options.UseFont = true;
            this.cboBatchNos.Properties.AppearanceDropDown.Font = new System.Drawing.Font("新宋体", 12F);
            this.cboBatchNos.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboBatchNos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBatchNos.Properties.DropDownItemHeight = 35;
            this.cboBatchNos.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBatchNos.Size = new System.Drawing.Size(158, 22);
            this.cboBatchNos.TabIndex = 9;
            this.cboBatchNos.SelectedIndexChanged += new System.EventHandler(this.cboBatchNos_SelectedIndexChanged);
            // 
            // lblDevices
            // 
            this.lblDevices.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.lblDevices.Location = new System.Drawing.Point(275, 41);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(48, 16);
            this.lblDevices.TabIndex = 8;
            this.lblDevices.Text = "设备：";
            // 
            // cboDevices
            // 
            this.cboDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDevices.Location = new System.Drawing.Point(329, 38);
            this.cboDevices.Name = "cboDevices";
            this.cboDevices.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.cboDevices.Properties.Appearance.Options.UseFont = true;
            this.cboDevices.Properties.AppearanceDropDown.Font = new System.Drawing.Font("新宋体", 12F);
            this.cboDevices.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDevices.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDevices.Properties.DropDownItemHeight = 35;
            this.cboDevices.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDevices.Size = new System.Drawing.Size(29, 22);
            this.cboDevices.TabIndex = 7;
            this.cboDevices.SelectedIndexChanged += new System.EventHandler(this.cboDevices_SelectedIndexChanged);
            // 
            // lblBatchNos
            // 
            this.lblBatchNos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBatchNos.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.lblBatchNos.Location = new System.Drawing.Point(364, 41);
            this.lblBatchNos.Name = "lblBatchNos";
            this.lblBatchNos.Size = new System.Drawing.Size(64, 16);
            this.lblBatchNos.TabIndex = 6;
            this.lblBatchNos.Text = "炉次号：";
            // 
            // edtOperatorCode
            // 
            this.edtOperatorCode.EditValue = "";
            this.edtOperatorCode.EnterMoveNextControl = true;
            this.edtOperatorCode.Location = new System.Drawing.Point(75, 38);
            this.edtOperatorCode.Name = "edtOperatorCode";
            this.edtOperatorCode.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.edtOperatorCode.Properties.Appearance.Options.UseFont = true;
            this.edtOperatorCode.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.edtOperatorCode.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.edtOperatorCode.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtOperatorCode.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.edtOperatorCode.Size = new System.Drawing.Size(194, 22);
            this.edtOperatorCode.TabIndex = 1;
            this.edtOperatorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtOperatorCode_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.labelControl1.Location = new System.Drawing.Point(5, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "操作工：";
            // 
            // btnPWOModify
            // 
            this.btnPWOModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPWOModify.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnPWOModify.Appearance.Options.UseFont = true;
            this.btnPWOModify.Location = new System.Drawing.Point(925, 7);
            this.btnPWOModify.Name = "btnPWOModify";
            this.btnPWOModify.Size = new System.Drawing.Size(95, 44);
            this.btnPWOModify.TabIndex = 4;
            this.btnPWOModify.Text = "修改";
            this.btnPWOModify.Click += new System.EventHandler(this.btnPWOModify_Click);
            // 
            // grdPWOs
            // 
            this.grdPWOs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPWOs.Location = new System.Drawing.Point(8, 7);
            this.grdPWOs.MainView = this.grdvPWOs;
            this.grdPWOs.Name = "grdPWOs";
            this.grdPWOs.Size = new System.Drawing.Size(901, 142);
            this.grdPWOs.TabIndex = 0;
            this.grdPWOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPWOs});
            // 
            // grdvPWOs
            // 
            this.grdvPWOs.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvPWOs.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvPWOs.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvPWOs.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F);
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
            this.grdvPWOs.RowHeight = 35;
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
            this.btnParamEdit.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnParamEdit.Appearance.Options.UseFont = true;
            this.btnParamEdit.Location = new System.Drawing.Point(925, 60);
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
            this.vgrdMethodParams.Appearance.PressedRow.Font = new System.Drawing.Font("新宋体", 12F);
            this.vgrdMethodParams.Appearance.PressedRow.Options.UseFont = true;
            this.vgrdMethodParams.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("新宋体", 12F);
            this.vgrdMethodParams.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vgrdMethodParams.Location = new System.Drawing.Point(8, 8);
            this.vgrdMethodParams.Name = "vgrdMethodParams";
            this.vgrdMethodParams.OptionsBehavior.Editable = false;
            this.vgrdMethodParams.RowHeaderWidth = 113;
            this.vgrdMethodParams.Size = new System.Drawing.Size(895, 142);
            this.vgrdMethodParams.TabIndex = 9;
            // 
            // btnParamRemove
            // 
            this.btnParamRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParamRemove.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnParamRemove.Appearance.Options.UseFont = true;
            this.btnParamRemove.Location = new System.Drawing.Point(925, 112);
            this.btnParamRemove.Name = "btnParamRemove";
            this.btnParamRemove.Size = new System.Drawing.Size(95, 34);
            this.btnParamRemove.TabIndex = 8;
            this.btnParamRemove.Text = "删除";
            this.btnParamRemove.Click += new System.EventHandler(this.btnParamRemove_Click);
            // 
            // btnParamNew
            // 
            this.btnParamNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParamNew.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnParamNew.Appearance.Options.UseFont = true;
            this.btnParamNew.Location = new System.Drawing.Point(925, 8);
            this.btnParamNew.Name = "btnParamNew";
            this.btnParamNew.Size = new System.Drawing.Size(95, 34);
            this.btnParamNew.TabIndex = 6;
            this.btnParamNew.Text = "新增";
            this.btnParamNew.Click += new System.EventHandler(this.btnParamNew_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnEnd.Appearance.Options.UseFont = true;
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(914, 517);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(118, 43);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.Text = "生产结束";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnTerminate
            // 
            this.btnTerminate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminate.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnTerminate.Appearance.Options.UseFont = true;
            this.btnTerminate.Location = new System.Drawing.Point(746, 517);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(118, 43);
            this.btnTerminate.TabIndex = 4;
            this.btnTerminate.Text = "生产终止";
            this.btnTerminate.Click += new System.EventHandler(this.btnTerminate_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            this.lblCurrentTime.TabIndex = 5;
            // 
            // btnBegin
            // 
            this.btnBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBegin.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnBegin.Appearance.Options.UseFont = true;
            this.btnBegin.Location = new System.Drawing.Point(575, 517);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(118, 43);
            this.btnBegin.TabIndex = 3;
            this.btnBegin.Text = "生产开始";
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // ucPrdtParams_Temper
            // 
            this.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnTerminate);
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucPrdtParams_Temper";
            this.Size = new System.Drawing.Size(1045, 579);
            this.Load += new System.EventHandler(this.ucFurnacePrdtParams_Load);
            this.Enter += new System.EventHandler(this.ucFurnacePrdtParams_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBatchNos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDevices.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOperatorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdMethodParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.LabelControl lblStartTime;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit edtOperatorCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPWOModify;
        private DevExpress.XtraGrid.GridControl grdPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnParamRemove;
        private DevExpress.XtraEditors.SimpleButton btnParamNew;
        private DevExpress.XtraEditors.SimpleButton btnEnd;
        private DevExpress.XtraEditors.SimpleButton btnTerminate;
        private DevExpress.XtraVerticalGrid.VGridControl vgrdMethodParams;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraEditors.LabelControl lblCurrentTime;
        private DevExpress.XtraEditors.LabelControl lblProductTimeSpan;
        private DevExpress.XtraEditors.LabelControl lblBatchNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnBegin;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnParamEdit;
        private DevExpress.XtraEditors.ComboBoxEdit cboBatchNos;
        private DevExpress.XtraEditors.LabelControl lblDevices;
        private DevExpress.XtraEditors.ComboBoxEdit cboDevices;
        private DevExpress.XtraEditors.LabelControl lblBatchNos;
    }
}
