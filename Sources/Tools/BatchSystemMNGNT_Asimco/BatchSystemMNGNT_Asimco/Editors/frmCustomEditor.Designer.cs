namespace BatchSystemMNGNT_Asimco.Editors
{
    partial class frmCustomEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.edtErrText = new DevExpress.XtraEditors.MemoEdit();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnFindDatas = new DevExpress.XtraEditors.SimpleButton();
            this.btnFindData = new DevExpress.XtraEditors.SimpleButton();
            this.edt4ShiftBIN = new DevExpress.XtraEditors.TextEdit();
            this.lblBIN = new DevExpress.XtraEditors.LabelControl();
            this.edt4ShiftQTY_BY_LOC = new DevExpress.XtraEditors.TextEdit();
            this.lblQTY_BY_LOC = new DevExpress.XtraEditors.LabelControl();
            this.edtQtyInStore = new DevExpress.XtraEditors.TextEdit();
            this.lblQtyInStore = new DevExpress.XtraEditors.LabelControl();
            this.edtT106Code = new DevExpress.XtraEditors.TextEdit();
            this.lblT106Code = new DevExpress.XtraEditors.LabelControl();
            this.edtRecvBatchNo = new DevExpress.XtraEditors.TextEdit();
            this.lblRecvBatchNo = new DevExpress.XtraEditors.LabelControl();
            this.edtSKUID = new DevExpress.XtraEditors.TextEdit();
            this.lblSKUID = new DevExpress.XtraEditors.LabelControl();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.chkModifyRecvBatchNo = new DevExpress.XtraEditors.CheckEdit();
            this.chkModifyQtyInStore = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtErrText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt4ShiftBIN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt4ShiftQTY_BY_LOC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQtyInStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtT106Code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRecvBatchNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKUID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkModifyRecvBatchNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkModifyQtyInStore.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(12, 12);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(753, 502);
            this.splitContainerControl1.SplitterPosition = 437;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.edtErrText);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 321);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl2.Size = new System.Drawing.Size(304, 181);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "WebService 执行结果";
            // 
            // edtErrText
            // 
            this.edtErrText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtErrText.Location = new System.Drawing.Point(7, 26);
            this.edtErrText.Name = "edtErrText";
            this.edtErrText.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtErrText.Properties.Appearance.Options.UseFont = true;
            this.edtErrText.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.edtErrText.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edtErrText.Properties.ReadOnly = true;
            this.edtErrText.Size = new System.Drawing.Size(290, 148);
            this.edtErrText.TabIndex = 1;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl2.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel1.Controls.Add(this.btnFindDatas);
            this.splitContainerControl2.Panel1.Controls.Add(this.btnFindData);
            this.splitContainerControl2.Panel1.Controls.Add(this.edt4ShiftBIN);
            this.splitContainerControl2.Panel1.Controls.Add(this.lblBIN);
            this.splitContainerControl2.Panel1.Controls.Add(this.edt4ShiftQTY_BY_LOC);
            this.splitContainerControl2.Panel1.Controls.Add(this.lblQTY_BY_LOC);
            this.splitContainerControl2.Panel1.ShowCaption = true;
            this.splitContainerControl2.Panel1.Text = "四班库存";
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel2.Controls.Add(this.chkModifyQtyInStore);
            this.splitContainerControl2.Panel2.Controls.Add(this.chkModifyRecvBatchNo);
            this.splitContainerControl2.Panel2.Controls.Add(this.edtQtyInStore);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblQtyInStore);
            this.splitContainerControl2.Panel2.Controls.Add(this.edtT106Code);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblT106Code);
            this.splitContainerControl2.Panel2.Controls.Add(this.edtRecvBatchNo);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblRecvBatchNo);
            this.splitContainerControl2.Panel2.Controls.Add(this.edtSKUID);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblSKUID);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            this.splitContainerControl2.Panel2.Text = "批次系统库存";
            this.splitContainerControl2.Size = new System.Drawing.Size(304, 321);
            this.splitContainerControl2.SplitterPosition = 143;
            this.splitContainerControl2.TabIndex = 1;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // btnFindDatas
            // 
            this.btnFindDatas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindDatas.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindDatas.Appearance.Options.UseFont = true;
            this.btnFindDatas.Location = new System.Drawing.Point(170, 71);
            this.btnFindDatas.Name = "btnFindDatas";
            this.btnFindDatas.Size = new System.Drawing.Size(125, 32);
            this.btnFindDatas.TabIndex = 4;
            this.btnFindDatas.Text = "查找相似记录";
            this.btnFindDatas.Click += new System.EventHandler(this.btnFindDatas_Click);
            // 
            // btnFindData
            // 
            this.btnFindData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFindData.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindData.Appearance.Options.UseFont = true;
            this.btnFindData.Location = new System.Drawing.Point(5, 71);
            this.btnFindData.Name = "btnFindData";
            this.btnFindData.Size = new System.Drawing.Size(125, 32);
            this.btnFindData.TabIndex = 3;
            this.btnFindData.Text = "查找对应记录";
            this.btnFindData.Click += new System.EventHandler(this.btnFindData_Click);
            // 
            // edt4ShiftBIN
            // 
            this.edt4ShiftBIN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edt4ShiftBIN.EditValue = "";
            this.edt4ShiftBIN.EnterMoveNextControl = true;
            this.edt4ShiftBIN.Location = new System.Drawing.Point(108, 2);
            this.edt4ShiftBIN.Name = "edt4ShiftBIN";
            this.edt4ShiftBIN.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edt4ShiftBIN.Properties.Appearance.Options.UseFont = true;
            this.edt4ShiftBIN.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.edt4ShiftBIN.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edt4ShiftBIN.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.edt4ShiftBIN.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edt4ShiftBIN.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edt4ShiftBIN.Properties.ReadOnly = true;
            this.edt4ShiftBIN.Size = new System.Drawing.Size(187, 26);
            this.edt4ShiftBIN.TabIndex = 1;
            // 
            // lblBIN
            // 
            this.lblBIN.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblBIN.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBIN.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblBIN.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBIN.Location = new System.Drawing.Point(5, 5);
            this.lblBIN.Name = "lblBIN";
            this.lblBIN.Size = new System.Drawing.Size(97, 20);
            this.lblBIN.TabIndex = 5;
            this.lblBIN.Text = "四班库位号";
            // 
            // edt4ShiftQTY_BY_LOC
            // 
            this.edt4ShiftQTY_BY_LOC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edt4ShiftQTY_BY_LOC.EditValue = "";
            this.edt4ShiftQTY_BY_LOC.EnterMoveNextControl = true;
            this.edt4ShiftQTY_BY_LOC.Location = new System.Drawing.Point(108, 34);
            this.edt4ShiftQTY_BY_LOC.Name = "edt4ShiftQTY_BY_LOC";
            this.edt4ShiftQTY_BY_LOC.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edt4ShiftQTY_BY_LOC.Properties.Appearance.Options.UseFont = true;
            this.edt4ShiftQTY_BY_LOC.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.edt4ShiftQTY_BY_LOC.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edt4ShiftQTY_BY_LOC.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.edt4ShiftQTY_BY_LOC.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edt4ShiftQTY_BY_LOC.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edt4ShiftQTY_BY_LOC.Properties.ReadOnly = true;
            this.edt4ShiftQTY_BY_LOC.Size = new System.Drawing.Size(187, 26);
            this.edt4ShiftQTY_BY_LOC.TabIndex = 2;
            // 
            // lblQTY_BY_LOC
            // 
            this.lblQTY_BY_LOC.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblQTY_BY_LOC.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblQTY_BY_LOC.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblQTY_BY_LOC.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblQTY_BY_LOC.Location = new System.Drawing.Point(5, 37);
            this.lblQTY_BY_LOC.Name = "lblQTY_BY_LOC";
            this.lblQTY_BY_LOC.Size = new System.Drawing.Size(97, 20);
            this.lblQTY_BY_LOC.TabIndex = 3;
            this.lblQTY_BY_LOC.Text = "库存数量";
            // 
            // edtQtyInStore
            // 
            this.edtQtyInStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtQtyInStore.EditValue = "无库存";
            this.edtQtyInStore.EnterMoveNextControl = true;
            this.edtQtyInStore.Location = new System.Drawing.Point(108, 104);
            this.edtQtyInStore.Name = "edtQtyInStore";
            this.edtQtyInStore.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtQtyInStore.Properties.Appearance.Options.UseFont = true;
            this.edtQtyInStore.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.edtQtyInStore.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edtQtyInStore.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.edtQtyInStore.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtQtyInStore.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edtQtyInStore.Properties.ReadOnly = true;
            this.edtQtyInStore.Size = new System.Drawing.Size(164, 26);
            this.edtQtyInStore.TabIndex = 4;
            // 
            // lblQtyInStore
            // 
            this.lblQtyInStore.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblQtyInStore.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblQtyInStore.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblQtyInStore.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblQtyInStore.Location = new System.Drawing.Point(5, 107);
            this.lblQtyInStore.Name = "lblQtyInStore";
            this.lblQtyInStore.Size = new System.Drawing.Size(97, 20);
            this.lblQtyInStore.TabIndex = 13;
            this.lblQtyInStore.Text = "库存数量";
            // 
            // edtT106Code
            // 
            this.edtT106Code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtT106Code.EditValue = "无库存";
            this.edtT106Code.EnterMoveNextControl = true;
            this.edtT106Code.Location = new System.Drawing.Point(108, 72);
            this.edtT106Code.Name = "edtT106Code";
            this.edtT106Code.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtT106Code.Properties.Appearance.Options.UseFont = true;
            this.edtT106Code.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.edtT106Code.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edtT106Code.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.edtT106Code.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtT106Code.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edtT106Code.Properties.ReadOnly = true;
            this.edtT106Code.Size = new System.Drawing.Size(164, 26);
            this.edtT106Code.TabIndex = 3;
            // 
            // lblT106Code
            // 
            this.lblT106Code.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblT106Code.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblT106Code.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblT106Code.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT106Code.Location = new System.Drawing.Point(5, 75);
            this.lblT106Code.Name = "lblT106Code";
            this.lblT106Code.Size = new System.Drawing.Size(97, 20);
            this.lblT106Code.TabIndex = 11;
            this.lblT106Code.Text = "批次库位号";
            // 
            // edtRecvBatchNo
            // 
            this.edtRecvBatchNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtRecvBatchNo.EditValue = "无库存";
            this.edtRecvBatchNo.EnterMoveNextControl = true;
            this.edtRecvBatchNo.Location = new System.Drawing.Point(108, 40);
            this.edtRecvBatchNo.Name = "edtRecvBatchNo";
            this.edtRecvBatchNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtRecvBatchNo.Properties.Appearance.Options.UseFont = true;
            this.edtRecvBatchNo.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.edtRecvBatchNo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edtRecvBatchNo.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.edtRecvBatchNo.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtRecvBatchNo.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edtRecvBatchNo.Properties.ReadOnly = true;
            this.edtRecvBatchNo.Size = new System.Drawing.Size(164, 26);
            this.edtRecvBatchNo.TabIndex = 2;
            // 
            // lblRecvBatchNo
            // 
            this.lblRecvBatchNo.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblRecvBatchNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblRecvBatchNo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblRecvBatchNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRecvBatchNo.Location = new System.Drawing.Point(5, 43);
            this.lblRecvBatchNo.Name = "lblRecvBatchNo";
            this.lblRecvBatchNo.Size = new System.Drawing.Size(97, 20);
            this.lblRecvBatchNo.TabIndex = 9;
            this.lblRecvBatchNo.Text = "批次号";
            // 
            // edtSKUID
            // 
            this.edtSKUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSKUID.EditValue = "";
            this.edtSKUID.EnterMoveNextControl = true;
            this.edtSKUID.Location = new System.Drawing.Point(108, 8);
            this.edtSKUID.Name = "edtSKUID";
            this.edtSKUID.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtSKUID.Properties.Appearance.Options.UseFont = true;
            this.edtSKUID.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.edtSKUID.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.edtSKUID.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.edtSKUID.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtSKUID.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edtSKUID.Properties.ReadOnly = true;
            this.edtSKUID.Size = new System.Drawing.Size(164, 26);
            this.edtSKUID.TabIndex = 1;
            // 
            // lblSKUID
            // 
            this.lblSKUID.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblSKUID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblSKUID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSKUID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSKUID.Location = new System.Drawing.Point(5, 11);
            this.lblSKUID.Name = "lblSKUID";
            this.lblSKUID.Size = new System.Drawing.Size(97, 20);
            this.lblSKUID.TabIndex = 7;
            this.lblSKUID.Text = "物料标签号";
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Appearance.Options.UseFont = true;
            this.btnExecute.Location = new System.Drawing.Point(780, 12);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(103, 31);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "执行";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(780, 483);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 31);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            // 
            // chkModifyRecvBatchNo
            // 
            this.chkModifyRecvBatchNo.Location = new System.Drawing.Point(279, 43);
            this.chkModifyRecvBatchNo.Name = "chkModifyRecvBatchNo";
            this.chkModifyRecvBatchNo.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModifyRecvBatchNo.Properties.Appearance.Options.UseFont = true;
            this.chkModifyRecvBatchNo.Properties.Caption = "";
            this.chkModifyRecvBatchNo.Size = new System.Drawing.Size(16, 19);
            this.chkModifyRecvBatchNo.TabIndex = 14;
            this.chkModifyRecvBatchNo.CheckedChanged += new System.EventHandler(this.chkModifyRecvBatchNo_CheckedChanged);
            // 
            // chkModifyQtyInStore
            // 
            this.chkModifyQtyInStore.Location = new System.Drawing.Point(279, 107);
            this.chkModifyQtyInStore.Name = "chkModifyQtyInStore";
            this.chkModifyQtyInStore.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModifyQtyInStore.Properties.Appearance.Options.UseFont = true;
            this.chkModifyQtyInStore.Properties.Caption = "";
            this.chkModifyQtyInStore.Size = new System.Drawing.Size(16, 19);
            this.chkModifyQtyInStore.TabIndex = 15;
            this.chkModifyQtyInStore.CheckedChanged += new System.EventHandler(this.chkModifyQtyInStore_CheckedChanged);
            // 
            // frmCustomEditor
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(895, 526);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.splitContainerControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCustomEditor";
            this.Load += new System.EventHandler(this.frmCustomEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtErrText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edt4ShiftBIN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt4ShiftQTY_BY_LOC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtQtyInStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtT106Code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRecvBatchNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSKUID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkModifyRecvBatchNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkModifyQtyInStore.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        public DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.TextEdit edt4ShiftBIN;
        private DevExpress.XtraEditors.LabelControl lblBIN;
        private DevExpress.XtraEditors.TextEdit edt4ShiftQTY_BY_LOC;
        private DevExpress.XtraEditors.LabelControl lblQTY_BY_LOC;
        private DevExpress.XtraEditors.SimpleButton btnFindDatas;
        private DevExpress.XtraEditors.SimpleButton btnFindData;
        protected DevExpress.XtraEditors.MemoEdit edtErrText;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit edtSKUID;
        private DevExpress.XtraEditors.LabelControl lblSKUID;
        private DevExpress.XtraEditors.TextEdit edtQtyInStore;
        private DevExpress.XtraEditors.LabelControl lblQtyInStore;
        private DevExpress.XtraEditors.TextEdit edtT106Code;
        private DevExpress.XtraEditors.LabelControl lblT106Code;
        private DevExpress.XtraEditors.TextEdit edtRecvBatchNo;
        private DevExpress.XtraEditors.LabelControl lblRecvBatchNo;
        private DevExpress.XtraEditors.CheckEdit chkModifyQtyInStore;
        private DevExpress.XtraEditors.CheckEdit chkModifyRecvBatchNo;
    }
}