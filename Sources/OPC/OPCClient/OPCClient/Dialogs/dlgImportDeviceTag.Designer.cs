namespace OPCClient.Dialogs
{
    partial class dlgImportDeviceTag
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.edtFileName = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtKepServChannel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtKepServDevice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.grdTags = new DevExpress.XtraGrid.GridControl();
            this.grdvTags = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkIncludeTitle = new DevExpress.XtraEditors.CheckEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.edtKepServName = new DevExpress.XtraEditors.TextEdit();
            this.cboKepServAddr = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHead)).BeginInit();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServChannel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServDevice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKepServAddr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHead.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.pnlHead.Appearance.Options.UseBackColor = true;
            this.pnlHead.Appearance.Options.UseForeColor = true;
            this.pnlHead.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.pnlHead.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlHead.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlHead.Size = new System.Drawing.Size(897, 33);
            // 
            // pnlBody
            // 
            this.pnlBody.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlBody.Appearance.Options.UseBackColor = true;
            this.pnlBody.Controls.Add(this.cboKepServAddr);
            this.pnlBody.Controls.Add(this.btnOK);
            this.pnlBody.Controls.Add(this.chkIncludeTitle);
            this.pnlBody.Controls.Add(this.grdTags);
            this.pnlBody.Controls.Add(this.edtFileName);
            this.pnlBody.Controls.Add(this.edtKepServName);
            this.pnlBody.Controls.Add(this.labelControl4);
            this.pnlBody.Controls.Add(this.edtKepServDevice);
            this.pnlBody.Controls.Add(this.labelControl3);
            this.pnlBody.Controls.Add(this.edtKepServChannel);
            this.pnlBody.Controls.Add(this.labelControl2);
            this.pnlBody.Controls.Add(this.labelControl1);
            this.pnlBody.Controls.Add(this.labelControl5);
            this.pnlBody.Location = new System.Drawing.Point(0, 33);
            this.pnlBody.Size = new System.Drawing.Size(897, 571);
            this.pnlBody.TabIndex = 0;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(10, 141);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(132, 17);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "设备标签文件名：";
            // 
            // edtFileName
            // 
            this.edtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFileName.Location = new System.Drawing.Point(146, 139);
            this.edtFileName.Name = "edtFileName";
            this.edtFileName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtFileName.Properties.Appearance.Options.UseFont = true;
            this.edtFileName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtFileName.Size = new System.Drawing.Size(482, 26);
            this.edtFileName.TabIndex = 5;
            this.edtFileName.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtFileName_ButtonClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(9, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(132, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "KepServer 地址：";
            // 
            // edtKepServChannel
            // 
            this.edtKepServChannel.Location = new System.Drawing.Point(147, 74);
            this.edtKepServChannel.Name = "edtKepServChannel";
            this.edtKepServChannel.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtKepServChannel.Properties.Appearance.Options.UseFont = true;
            this.edtKepServChannel.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.edtKepServChannel.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.edtKepServChannel.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtKepServChannel.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.edtKepServChannel.Size = new System.Drawing.Size(210, 26);
            this.edtKepServChannel.TabIndex = 3;
            this.edtKepServChannel.Tag = "2";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(10, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(132, 17);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "KepServer Channel：";
            // 
            // edtKepServDevice
            // 
            this.edtKepServDevice.Location = new System.Drawing.Point(147, 106);
            this.edtKepServDevice.Name = "edtKepServDevice";
            this.edtKepServDevice.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtKepServDevice.Properties.Appearance.Options.UseFont = true;
            this.edtKepServDevice.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.edtKepServDevice.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.edtKepServDevice.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtKepServDevice.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.edtKepServDevice.Size = new System.Drawing.Size(210, 26);
            this.edtKepServDevice.TabIndex = 4;
            this.edtKepServDevice.Tag = "3";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(10, 109);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(132, 17);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "KepServer Device：";
            // 
            // grdTags
            // 
            this.grdTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTags.Location = new System.Drawing.Point(9, 178);
            this.grdTags.MainView = this.grdvTags;
            this.grdTags.Name = "grdTags";
            this.grdTags.Size = new System.Drawing.Size(730, 388);
            this.grdTags.TabIndex = 9;
            this.grdTags.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvTags});
            // 
            // grdvTags
            // 
            this.grdvTags.GridControl = this.grdTags;
            this.grdvTags.Name = "grdvTags";
            this.grdvTags.OptionsView.ColumnAutoWidth = false;
            this.grdvTags.OptionsView.ShowGroupPanel = false;
            // 
            // chkIncludeTitle
            // 
            this.chkIncludeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludeTitle.EditValue = true;
            this.chkIncludeTitle.Location = new System.Drawing.Point(634, 140);
            this.chkIncludeTitle.Name = "chkIncludeTitle";
            this.chkIncludeTitle.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncludeTitle.Properties.Appearance.Options.UseFont = true;
            this.chkIncludeTitle.Properties.Caption = "首行为标题行";
            this.chkIncludeTitle.Size = new System.Drawing.Size(106, 24);
            this.chkIncludeTitle.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(789, 541);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 25);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定导入";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(9, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(132, 17);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "KepServer Name：";
            // 
            // edtKepServName
            // 
            this.edtKepServName.Enabled = false;
            this.edtKepServName.Location = new System.Drawing.Point(147, 42);
            this.edtKepServName.Name = "edtKepServName";
            this.edtKepServName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtKepServName.Properties.Appearance.Options.UseFont = true;
            this.edtKepServName.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.edtKepServName.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.edtKepServName.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtKepServName.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.edtKepServName.Size = new System.Drawing.Size(210, 26);
            this.edtKepServName.TabIndex = 2;
            this.edtKepServName.Tag = "4";
            // 
            // cboKepServAddr
            // 
            this.cboKepServAddr.Location = new System.Drawing.Point(147, 10);
            this.cboKepServAddr.Name = "cboKepServAddr";
            this.cboKepServAddr.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKepServAddr.Properties.Appearance.Options.UseFont = true;
            this.cboKepServAddr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKepServAddr.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboKepServAddr.Size = new System.Drawing.Size(210, 26);
            this.cboKepServAddr.TabIndex = 1;
            this.cboKepServAddr.Tag = "1";
            this.cboKepServAddr.SelectedIndexChanged += new System.EventHandler(this.cboKepServAddr_SelectedIndexChanged);
            // 
            // dlgImportDeviceTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 604);
            this.Name = "dlgImportDeviceTag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备标签导入";
            this.Load += new System.EventHandler(this.dlgImportDeviceTag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHead)).EndInit();
            this.pnlHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServChannel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServDevice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKepServAddr.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ButtonEdit edtFileName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtKepServChannel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit edtKepServDevice;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl grdTags;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvTags;
        private DevExpress.XtraEditors.CheckEdit chkIncludeTitle;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit edtKepServName;
        private DevExpress.XtraEditors.ComboBoxEdit cboKepServAddr;
    }
}