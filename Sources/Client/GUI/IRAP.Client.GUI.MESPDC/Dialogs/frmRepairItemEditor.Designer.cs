namespace IRAP.Client.GUI.MESPDC.Dialogs
{
    partial class frmRepairItemEditor
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
            this.lblSymbol = new DevExpress.XtraEditors.LabelControl();
            this.sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.cboT119LeafID = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboT184LeafID = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboT183LeafID = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboT216LeafID = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboT118LeafID = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboSymbol = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblT119Name = new DevExpress.XtraEditors.LabelControl();
            this.lblT184Name = new DevExpress.XtraEditors.LabelControl();
            this.lblT183Name = new DevExpress.XtraEditors.LabelControl();
            this.lblT216Name = new DevExpress.XtraEditors.LabelControl();
            this.lblT118Name = new DevExpress.XtraEditors.LabelControl();
            this.lblTrackReferenceValue = new DevExpress.XtraEditors.LabelControl();
            this.edtTrackReferenceValue = new DevExpress.XtraEditors.TextEdit();
            this.lblT119LeafID = new DevExpress.XtraEditors.LabelControl();
            this.lblT184LeafID = new DevExpress.XtraEditors.LabelControl();
            this.lblT183LeafID = new DevExpress.XtraEditors.LabelControl();
            this.lblT216LeafID = new DevExpress.XtraEditors.LabelControl();
            this.lblFailurePointCount = new DevExpress.XtraEditors.LabelControl();
            this.edtFailurePointCount = new DevExpress.XtraEditors.TextEdit();
            this.lblT118LeafID = new DevExpress.XtraEditors.LabelControl();
            this.lblSymbolText = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).BeginInit();
            this.sccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboT119LeafID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboT184LeafID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboT183LeafID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboT216LeafID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboT118LeafID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSymbol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrackReferenceValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFailurePointCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // lblSymbol
            // 
            this.lblSymbol.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSymbol.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblSymbol.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblSymbol.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSymbol.Location = new System.Drawing.Point(13, 11);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(116, 20);
            this.lblSymbol.TabIndex = 0;
            this.lblSymbol.Text = "器件位号/物料编号";
            // 
            // sccMain
            // 
            this.sccMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.sccMain.IsSplitterFixed = true;
            this.sccMain.Location = new System.Drawing.Point(10, 10);
            this.sccMain.Name = "sccMain";
            this.sccMain.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.sccMain.Panel1.AppearanceCaption.Options.UseFont = true;
            this.sccMain.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.sccMain.Panel1.Controls.Add(this.cboT119LeafID);
            this.sccMain.Panel1.Controls.Add(this.cboT184LeafID);
            this.sccMain.Panel1.Controls.Add(this.cboT183LeafID);
            this.sccMain.Panel1.Controls.Add(this.cboT216LeafID);
            this.sccMain.Panel1.Controls.Add(this.cboT118LeafID);
            this.sccMain.Panel1.Controls.Add(this.cboSymbol);
            this.sccMain.Panel1.Controls.Add(this.lblT119Name);
            this.sccMain.Panel1.Controls.Add(this.lblT184Name);
            this.sccMain.Panel1.Controls.Add(this.lblT183Name);
            this.sccMain.Panel1.Controls.Add(this.lblT216Name);
            this.sccMain.Panel1.Controls.Add(this.lblT118Name);
            this.sccMain.Panel1.Controls.Add(this.lblTrackReferenceValue);
            this.sccMain.Panel1.Controls.Add(this.edtTrackReferenceValue);
            this.sccMain.Panel1.Controls.Add(this.lblT119LeafID);
            this.sccMain.Panel1.Controls.Add(this.lblT184LeafID);
            this.sccMain.Panel1.Controls.Add(this.lblT183LeafID);
            this.sccMain.Panel1.Controls.Add(this.lblT216LeafID);
            this.sccMain.Panel1.Controls.Add(this.lblFailurePointCount);
            this.sccMain.Panel1.Controls.Add(this.edtFailurePointCount);
            this.sccMain.Panel1.Controls.Add(this.lblT118LeafID);
            this.sccMain.Panel1.Controls.Add(this.lblSymbolText);
            this.sccMain.Panel1.Controls.Add(this.lblSymbol);
            this.sccMain.Panel1.ShowCaption = true;
            this.sccMain.Panel1.Text = "{0}维修项";
            this.sccMain.Panel2.Controls.Add(this.btnCancel);
            this.sccMain.Panel2.Controls.Add(this.btnSave);
            this.sccMain.Panel2.Text = "Panel2";
            this.sccMain.Size = new System.Drawing.Size(734, 322);
            this.sccMain.SplitterPosition = 112;
            this.sccMain.TabIndex = 3;
            this.sccMain.Text = "splitContainerControl1";
            // 
            // cboT119LeafID
            // 
            this.cboT119LeafID.EnterMoveNextControl = true;
            this.cboT119LeafID.Location = new System.Drawing.Point(151, 223);
            this.cboT119LeafID.Name = "cboT119LeafID";
            this.cboT119LeafID.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboT119LeafID.Properties.Appearance.Options.UseFont = true;
            this.cboT119LeafID.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.cboT119LeafID.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboT119LeafID.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.cboT119LeafID.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboT119LeafID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboT119LeafID.Size = new System.Drawing.Size(163, 26);
            this.cboT119LeafID.TabIndex = 14;
            this.cboT119LeafID.Enter += new System.EventHandler(this.edtSymbol_Enter);
            this.cboT119LeafID.Validating += new System.ComponentModel.CancelEventHandler(this.edtT119LeafID_Validating);
            // 
            // cboT184LeafID
            // 
            this.cboT184LeafID.EnterMoveNextControl = true;
            this.cboT184LeafID.Location = new System.Drawing.Point(151, 191);
            this.cboT184LeafID.Name = "cboT184LeafID";
            this.cboT184LeafID.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboT184LeafID.Properties.Appearance.Options.UseFont = true;
            this.cboT184LeafID.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.cboT184LeafID.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboT184LeafID.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.cboT184LeafID.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboT184LeafID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboT184LeafID.Size = new System.Drawing.Size(163, 26);
            this.cboT184LeafID.TabIndex = 12;
            this.cboT184LeafID.Enter += new System.EventHandler(this.edtSymbol_Enter);
            this.cboT184LeafID.Validating += new System.ComponentModel.CancelEventHandler(this.edtT184LeafID_Validating);
            // 
            // cboT183LeafID
            // 
            this.cboT183LeafID.EnterMoveNextControl = true;
            this.cboT183LeafID.Location = new System.Drawing.Point(151, 159);
            this.cboT183LeafID.Name = "cboT183LeafID";
            this.cboT183LeafID.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboT183LeafID.Properties.Appearance.Options.UseFont = true;
            this.cboT183LeafID.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.cboT183LeafID.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboT183LeafID.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.cboT183LeafID.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboT183LeafID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboT183LeafID.Size = new System.Drawing.Size(163, 26);
            this.cboT183LeafID.TabIndex = 10;
            this.cboT183LeafID.Enter += new System.EventHandler(this.edtSymbol_Enter);
            this.cboT183LeafID.Validating += new System.ComponentModel.CancelEventHandler(this.edtT183LeafID_Validating);
            // 
            // cboT216LeafID
            // 
            this.cboT216LeafID.EnterMoveNextControl = true;
            this.cboT216LeafID.Location = new System.Drawing.Point(151, 127);
            this.cboT216LeafID.Name = "cboT216LeafID";
            this.cboT216LeafID.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboT216LeafID.Properties.Appearance.Options.UseFont = true;
            this.cboT216LeafID.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.cboT216LeafID.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboT216LeafID.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.cboT216LeafID.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboT216LeafID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboT216LeafID.Size = new System.Drawing.Size(163, 26);
            this.cboT216LeafID.TabIndex = 8;
            this.cboT216LeafID.Enter += new System.EventHandler(this.edtSymbol_Enter);
            this.cboT216LeafID.Validating += new System.ComponentModel.CancelEventHandler(this.edtT216LeafID_Validating);
            // 
            // cboT118LeafID
            // 
            this.cboT118LeafID.EnterMoveNextControl = true;
            this.cboT118LeafID.Location = new System.Drawing.Point(151, 63);
            this.cboT118LeafID.Name = "cboT118LeafID";
            this.cboT118LeafID.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboT118LeafID.Properties.Appearance.Options.UseFont = true;
            this.cboT118LeafID.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.cboT118LeafID.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboT118LeafID.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.cboT118LeafID.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboT118LeafID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboT118LeafID.Size = new System.Drawing.Size(163, 26);
            this.cboT118LeafID.TabIndex = 4;
            this.cboT118LeafID.Enter += new System.EventHandler(this.edtSymbol_Enter);
            this.cboT118LeafID.Validating += new System.ComponentModel.CancelEventHandler(this.edtT118LeafID_Validating);
            // 
            // cboSymbol
            // 
            this.cboSymbol.EnterMoveNextControl = true;
            this.cboSymbol.Location = new System.Drawing.Point(151, 8);
            this.cboSymbol.Name = "cboSymbol";
            this.cboSymbol.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSymbol.Properties.Appearance.Options.UseFont = true;
            this.cboSymbol.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.cboSymbol.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.cboSymbol.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.cboSymbol.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.cboSymbol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSymbol.Size = new System.Drawing.Size(226, 26);
            this.cboSymbol.TabIndex = 1;
            this.cboSymbol.Enter += new System.EventHandler(this.edtSymbol_Enter);
            this.cboSymbol.Validating += new System.ComponentModel.CancelEventHandler(this.edtSymbol_Validating);
            // 
            // lblT119Name
            // 
            this.lblT119Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblT119Name.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT119Name.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblT119Name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT119Name.Location = new System.Drawing.Point(320, 226);
            this.lblT119Name.Name = "lblT119Name";
            this.lblT119Name.Size = new System.Drawing.Size(282, 20);
            this.lblT119Name.TabIndex = 22;
            // 
            // lblT184Name
            // 
            this.lblT184Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblT184Name.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT184Name.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblT184Name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT184Name.Location = new System.Drawing.Point(320, 194);
            this.lblT184Name.Name = "lblT184Name";
            this.lblT184Name.Size = new System.Drawing.Size(282, 20);
            this.lblT184Name.TabIndex = 21;
            // 
            // lblT183Name
            // 
            this.lblT183Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblT183Name.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT183Name.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblT183Name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT183Name.Location = new System.Drawing.Point(320, 162);
            this.lblT183Name.Name = "lblT183Name";
            this.lblT183Name.Size = new System.Drawing.Size(282, 20);
            this.lblT183Name.TabIndex = 20;
            // 
            // lblT216Name
            // 
            this.lblT216Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblT216Name.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT216Name.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblT216Name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT216Name.Location = new System.Drawing.Point(320, 130);
            this.lblT216Name.Name = "lblT216Name";
            this.lblT216Name.Size = new System.Drawing.Size(282, 20);
            this.lblT216Name.TabIndex = 19;
            // 
            // lblT118Name
            // 
            this.lblT118Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblT118Name.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT118Name.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblT118Name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT118Name.Location = new System.Drawing.Point(320, 66);
            this.lblT118Name.Name = "lblT118Name";
            this.lblT118Name.Size = new System.Drawing.Size(282, 20);
            this.lblT118Name.TabIndex = 17;
            // 
            // lblTrackReferenceValue
            // 
            this.lblTrackReferenceValue.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackReferenceValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTrackReferenceValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTrackReferenceValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTrackReferenceValue.Location = new System.Drawing.Point(13, 258);
            this.lblTrackReferenceValue.Name = "lblTrackReferenceValue";
            this.lblTrackReferenceValue.Size = new System.Drawing.Size(116, 20);
            this.lblTrackReferenceValue.TabIndex = 15;
            this.lblTrackReferenceValue.Text = "追溯参考值";
            // 
            // edtTrackReferenceValue
            // 
            this.edtTrackReferenceValue.EnterMoveNextControl = true;
            this.edtTrackReferenceValue.Location = new System.Drawing.Point(151, 255);
            this.edtTrackReferenceValue.Name = "edtTrackReferenceValue";
            this.edtTrackReferenceValue.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtTrackReferenceValue.Properties.Appearance.Options.UseFont = true;
            this.edtTrackReferenceValue.Properties.Appearance.Options.UseTextOptions = true;
            this.edtTrackReferenceValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtTrackReferenceValue.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edtTrackReferenceValue.Size = new System.Drawing.Size(163, 26);
            this.edtTrackReferenceValue.TabIndex = 16;
            this.edtTrackReferenceValue.Enter += new System.EventHandler(this.edtSymbol_Enter);
            this.edtTrackReferenceValue.Validating += new System.ComponentModel.CancelEventHandler(this.edtTrackReferenceValue_Validating);
            // 
            // lblT119LeafID
            // 
            this.lblT119LeafID.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT119LeafID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblT119LeafID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblT119LeafID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT119LeafID.Location = new System.Drawing.Point(13, 226);
            this.lblT119LeafID.Name = "lblT119LeafID";
            this.lblT119LeafID.Size = new System.Drawing.Size(116, 20);
            this.lblT119LeafID.TabIndex = 13;
            this.lblT119LeafID.Text = "维修模式";
            // 
            // lblT184LeafID
            // 
            this.lblT184LeafID.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT184LeafID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblT184LeafID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblT184LeafID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT184LeafID.Location = new System.Drawing.Point(13, 194);
            this.lblT184LeafID.Name = "lblT184LeafID";
            this.lblT184LeafID.Size = new System.Drawing.Size(116, 20);
            this.lblT184LeafID.TabIndex = 11;
            this.lblT184LeafID.Text = "失效责任";
            // 
            // lblT183LeafID
            // 
            this.lblT183LeafID.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT183LeafID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblT183LeafID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblT183LeafID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT183LeafID.Location = new System.Drawing.Point(13, 162);
            this.lblT183LeafID.Name = "lblT183LeafID";
            this.lblT183LeafID.Size = new System.Drawing.Size(116, 20);
            this.lblT183LeafID.TabIndex = 9;
            this.lblT183LeafID.Text = "失效性质";
            // 
            // lblT216LeafID
            // 
            this.lblT216LeafID.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT216LeafID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblT216LeafID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblT216LeafID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT216LeafID.Location = new System.Drawing.Point(13, 130);
            this.lblT216LeafID.Name = "lblT216LeafID";
            this.lblT216LeafID.Size = new System.Drawing.Size(116, 20);
            this.lblT216LeafID.TabIndex = 7;
            this.lblT216LeafID.Text = "根源工序";
            // 
            // lblFailurePointCount
            // 
            this.lblFailurePointCount.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailurePointCount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblFailurePointCount.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFailurePointCount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFailurePointCount.Location = new System.Drawing.Point(13, 98);
            this.lblFailurePointCount.Name = "lblFailurePointCount";
            this.lblFailurePointCount.Size = new System.Drawing.Size(116, 20);
            this.lblFailurePointCount.TabIndex = 5;
            this.lblFailurePointCount.Text = "失效点数";
            // 
            // edtFailurePointCount
            // 
            this.edtFailurePointCount.EnterMoveNextControl = true;
            this.edtFailurePointCount.Location = new System.Drawing.Point(151, 95);
            this.edtFailurePointCount.Name = "edtFailurePointCount";
            this.edtFailurePointCount.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtFailurePointCount.Properties.Appearance.Options.UseFont = true;
            this.edtFailurePointCount.Properties.Appearance.Options.UseTextOptions = true;
            this.edtFailurePointCount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtFailurePointCount.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edtFailurePointCount.Size = new System.Drawing.Size(163, 26);
            this.edtFailurePointCount.TabIndex = 6;
            this.edtFailurePointCount.Enter += new System.EventHandler(this.edtSymbol_Enter);
            this.edtFailurePointCount.Validating += new System.ComponentModel.CancelEventHandler(this.edtFailurePointCount_Validating);
            // 
            // lblT118LeafID
            // 
            this.lblT118LeafID.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT118LeafID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblT118LeafID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblT118LeafID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblT118LeafID.Location = new System.Drawing.Point(13, 66);
            this.lblT118LeafID.Name = "lblT118LeafID";
            this.lblT118LeafID.Size = new System.Drawing.Size(116, 20);
            this.lblT118LeafID.TabIndex = 3;
            this.lblT118LeafID.Text = "失效模式";
            // 
            // lblSymbolText
            // 
            this.lblSymbolText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSymbolText.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSymbolText.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblSymbolText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSymbolText.Location = new System.Drawing.Point(13, 37);
            this.lblSymbolText.Name = "lblSymbolText";
            this.lblSymbolText.Size = new System.Drawing.Size(589, 20);
            this.lblSymbolText.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(15, 70);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(15, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmRepairItemEditor
            // 
            this.Appearance.Options.UseFont = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(754, 342);
            this.Controls.Add(this.sccMain);
            this.Name = "frmRepairItemEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "维修项";
            this.Load += new System.EventHandler(this.frmRepairItemEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).EndInit();
            this.sccMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboT119LeafID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboT184LeafID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboT183LeafID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboT216LeafID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboT118LeafID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSymbol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTrackReferenceValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFailurePointCount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblSymbol;
        private DevExpress.XtraEditors.SplitContainerControl sccMain;
        private DevExpress.XtraEditors.LabelControl lblSymbolText;
        private DevExpress.XtraEditors.LabelControl lblT118LeafID;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl lblFailurePointCount;
        private DevExpress.XtraEditors.TextEdit edtFailurePointCount;
        private DevExpress.XtraEditors.LabelControl lblT216LeafID;
        private DevExpress.XtraEditors.LabelControl lblT183LeafID;
        private DevExpress.XtraEditors.LabelControl lblT184LeafID;
        private DevExpress.XtraEditors.LabelControl lblTrackReferenceValue;
        private DevExpress.XtraEditors.TextEdit edtTrackReferenceValue;
        private DevExpress.XtraEditors.LabelControl lblT119LeafID;
        private DevExpress.XtraEditors.LabelControl lblT119Name;
        private DevExpress.XtraEditors.LabelControl lblT184Name;
        private DevExpress.XtraEditors.LabelControl lblT183Name;
        private DevExpress.XtraEditors.LabelControl lblT216Name;
        private DevExpress.XtraEditors.LabelControl lblT118Name;
        private DevExpress.XtraEditors.ComboBoxEdit cboSymbol;
        private DevExpress.XtraEditors.ComboBoxEdit cboT118LeafID;
        private DevExpress.XtraEditors.ComboBoxEdit cboT216LeafID;
        private DevExpress.XtraEditors.ComboBoxEdit cboT183LeafID;
        private DevExpress.XtraEditors.ComboBoxEdit cboT184LeafID;
        private DevExpress.XtraEditors.ComboBoxEdit cboT119LeafID;
    }
}
