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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtFileName = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.edtKepServAddr = new DevExpress.XtraEditors.TextEdit();
            this.edtKepServChannel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.edtKepServDevice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.grdTags = new DevExpress.XtraGrid.GridControl();
            this.grdvTags = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkIncludeTitle = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServAddr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServChannel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServDevice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeTitle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 111);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(154, 20);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "设备标签文件名：";
            // 
            // edtFileName
            // 
            this.edtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFileName.Location = new System.Drawing.Point(172, 108);
            this.edtFileName.Name = "edtFileName";
            this.edtFileName.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtFileName.Properties.Appearance.Options.UseFont = true;
            this.edtFileName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtFileName.Size = new System.Drawing.Size(346, 26);
            this.edtFileName.TabIndex = 8;
            this.edtFileName.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtFileName_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(12, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(154, 20);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "KepServer 地址：";
            // 
            // edtKepServAddr
            // 
            this.edtKepServAddr.Enabled = false;
            this.edtKepServAddr.Location = new System.Drawing.Point(172, 12);
            this.edtKepServAddr.Name = "edtKepServAddr";
            this.edtKepServAddr.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtKepServAddr.Properties.Appearance.Options.UseFont = true;
            this.edtKepServAddr.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.edtKepServAddr.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.edtKepServAddr.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtKepServAddr.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.edtKepServAddr.Size = new System.Drawing.Size(209, 26);
            this.edtKepServAddr.TabIndex = 2;
            // 
            // edtKepServChannel
            // 
            this.edtKepServChannel.Enabled = false;
            this.edtKepServChannel.Location = new System.Drawing.Point(172, 44);
            this.edtKepServChannel.Name = "edtKepServChannel";
            this.edtKepServChannel.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtKepServChannel.Properties.Appearance.Options.UseFont = true;
            this.edtKepServChannel.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.edtKepServChannel.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.edtKepServChannel.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtKepServChannel.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.edtKepServChannel.Size = new System.Drawing.Size(245, 26);
            this.edtKepServChannel.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(12, 47);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(154, 20);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "KepServer Channel：";
            // 
            // edtKepServDevice
            // 
            this.edtKepServDevice.Enabled = false;
            this.edtKepServDevice.Location = new System.Drawing.Point(172, 76);
            this.edtKepServDevice.Name = "edtKepServDevice";
            this.edtKepServDevice.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtKepServDevice.Properties.Appearance.Options.UseFont = true;
            this.edtKepServDevice.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.edtKepServDevice.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.edtKepServDevice.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtKepServDevice.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.edtKepServDevice.Size = new System.Drawing.Size(245, 26);
            this.edtKepServDevice.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(12, 79);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(154, 20);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "KepServer Device：";
            // 
            // grdTags
            // 
            this.grdTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTags.Location = new System.Drawing.Point(12, 140);
            this.grdTags.MainView = this.grdvTags;
            this.grdTags.Name = "grdTags";
            this.grdTags.Size = new System.Drawing.Size(625, 280);
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
            this.chkIncludeTitle.Location = new System.Drawing.Point(524, 110);
            this.chkIncludeTitle.Name = "chkIncludeTitle";
            this.chkIncludeTitle.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncludeTitle.Properties.Appearance.Options.UseFont = true;
            this.chkIncludeTitle.Properties.Caption = "首行为标题行";
            this.chkIncludeTitle.Size = new System.Drawing.Size(113, 24);
            this.chkIncludeTitle.TabIndex = 10;
            // 
            // dlgImportDeviceTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 432);
            this.Controls.Add(this.chkIncludeTitle);
            this.Controls.Add(this.grdTags);
            this.Controls.Add(this.edtKepServDevice);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.edtKepServChannel);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.edtKepServAddr);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.edtFileName);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgImportDeviceTag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备标签导入";
            ((System.ComponentModel.ISupportInitialize)(this.edtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServAddr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServChannel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKepServDevice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeTitle.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit edtFileName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit edtKepServAddr;
        private DevExpress.XtraEditors.TextEdit edtKepServChannel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit edtKepServDevice;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.GridControl grdTags;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvTags;
        private DevExpress.XtraEditors.CheckEdit chkIncludeTitle;
    }
}