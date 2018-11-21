namespace IRAP.Client.GUI.BatchSystem
{
    partial class frmQualityInspecting_Ionitriding
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
            this.spccMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.ilstDevices = new DevExpress.XtraEditors.ImageListBoxControl();
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spccMain)).BeginInit();
            this.spccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ilstDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "离子氮化质量检查";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // spccMain
            // 
            this.spccMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spccMain.IsSplitterFixed = true;
            this.spccMain.Location = new System.Drawing.Point(0, 56);
            this.spccMain.Name = "spccMain";
            this.spccMain.Panel1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 14.25F);
            this.spccMain.Panel1.AppearanceCaption.Options.UseFont = true;
            this.spccMain.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.spccMain.Panel1.Controls.Add(this.ilstDevices);
            this.spccMain.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.spccMain.Panel1.ShowCaption = true;
            this.spccMain.Panel1.Text = "设备编号列表";
            this.spccMain.Panel2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 14.25F);
            this.spccMain.Panel2.AppearanceCaption.Options.UseFont = true;
            this.spccMain.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.spccMain.Panel2.Controls.Add(this.tcMain);
            this.spccMain.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.spccMain.Panel2.ShowCaption = true;
            this.spccMain.Panel2.Text = "质量检查";
            this.spccMain.Size = new System.Drawing.Size(891, 439);
            this.spccMain.SplitterPosition = 298;
            this.spccMain.TabIndex = 1;
            this.spccMain.Text = "splitContainerControl1";
            // 
            // ilstDevices
            // 
            this.ilstDevices.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ilstDevices.Appearance.Options.UseFont = true;
            this.ilstDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilstDevices.ItemHeight = 30;
            this.ilstDevices.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(null)});
            this.ilstDevices.Location = new System.Drawing.Point(5, 5);
            this.ilstDevices.Name = "ilstDevices";
            this.ilstDevices.Size = new System.Drawing.Size(284, 401);
            this.ilstDevices.TabIndex = 0;
            this.ilstDevices.SelectedIndexChanged += new System.EventHandler(this.ilstDevices_SelectedIndexChanged);
            // 
            // tcMain
            // 
            this.tcMain.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.Appearance.Options.UseFont = true;
            this.tcMain.AppearancePage.Header.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.AppearancePage.Header.Options.UseFont = true;
            this.tcMain.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.Blue;
            this.tcMain.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.tcMain.AppearancePage.HeaderHotTracked.BackColor = System.Drawing.Color.Blue;
            this.tcMain.AppearancePage.HeaderHotTracked.ForeColor = System.Drawing.Color.White;
            this.tcMain.AppearancePage.HeaderHotTracked.Options.UseBackColor = true;
            this.tcMain.AppearancePage.HeaderHotTracked.Options.UseForeColor = true;
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right;
            this.tcMain.Location = new System.Drawing.Point(5, 5);
            this.tcMain.Name = "tcMain";
            this.tcMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tcMain.Size = new System.Drawing.Size(574, 401);
            this.tcMain.TabIndex = 5;
            this.tcMain.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tcMain_SelectedPageChanged);
            // 
            // frmQualityInspecting_Ionitriding
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.spccMain);
            this.Name = "frmQualityInspecting_Ionitriding";
            this.Text = "离子氮化质量检查";
            this.Activated += new System.EventHandler(this.frmQualityInspecting_Ionitriding_Activated);
            this.Shown += new System.EventHandler(this.frmQualityInspecting_Ionitriding_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.spccMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spccMain)).EndInit();
            this.spccMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ilstDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl spccMain;
        private DevExpress.XtraEditors.ImageListBoxControl ilstDevices;
        private DevExpress.XtraTab.XtraTabControl tcMain;
    }
}
