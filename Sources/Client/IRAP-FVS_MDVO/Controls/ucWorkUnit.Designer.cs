namespace IRAP_FVS_MDVO
{
    partial class ucWorkUnit
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
            this.lblEquipmentName = new DevExpress.XtraEditors.LabelControl();
            this.lblWorkingStatus = new DevExpress.XtraEditors.LabelControl();
            this.picEquipment = new System.Windows.Forms.PictureBox();
            this.lblMemo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.picEquipment)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEquipmentName
            // 
            this.lblEquipmentName.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblEquipmentName.Appearance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipmentName.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblEquipmentName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblEquipmentName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblEquipmentName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblEquipmentName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEquipmentName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEquipmentName.Location = new System.Drawing.Point(0, 0);
            this.lblEquipmentName.Name = "lblEquipmentName";
            this.lblEquipmentName.Size = new System.Drawing.Size(260, 49);
            this.lblEquipmentName.TabIndex = 0;
            this.lblEquipmentName.Text = "labelControl1";
            // 
            // lblWorkingStatus
            // 
            this.lblWorkingStatus.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkingStatus.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWorkingStatus.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lblWorkingStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblWorkingStatus.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblWorkingStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWorkingStatus.Location = new System.Drawing.Point(187, 28);
            this.lblWorkingStatus.Name = "lblWorkingStatus";
            this.lblWorkingStatus.Size = new System.Drawing.Size(68, 21);
            this.lblWorkingStatus.TabIndex = 1;
            this.lblWorkingStatus.Text = "开始生产";
            // 
            // picEquipment
            // 
            this.picEquipment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEquipment.Location = new System.Drawing.Point(5, 55);
            this.picEquipment.Name = "picEquipment";
            this.picEquipment.Size = new System.Drawing.Size(250, 200);
            this.picEquipment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEquipment.TabIndex = 2;
            this.picEquipment.TabStop = false;
            this.picEquipment.Click += new System.EventHandler(this.picEquipment_Click);
            // 
            // lblMemo
            // 
            this.lblMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemo.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMemo.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblMemo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblMemo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMemo.Location = new System.Drawing.Point(5, 273);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(250, 162);
            this.lblMemo.TabIndex = 3;
            this.lblMemo.Text = "labelControl1";
            this.lblMemo.Click += new System.EventHandler(this.lblMemo_Click);
            // 
            // ucWorkUnit
            // 
            this.Appearance.BackColor = System.Drawing.Color.Green;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.picEquipment);
            this.Controls.Add(this.lblWorkingStatus);
            this.Controls.Add(this.lblEquipmentName);
            this.Name = "ucWorkUnit";
            this.Size = new System.Drawing.Size(260, 438);
            ((System.ComponentModel.ISupportInitialize)(this.picEquipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblEquipmentName;
        private DevExpress.XtraEditors.LabelControl lblWorkingStatus;
        private System.Windows.Forms.PictureBox picEquipment;
        private DevExpress.XtraEditors.LabelControl lblMemo;
    }
}
