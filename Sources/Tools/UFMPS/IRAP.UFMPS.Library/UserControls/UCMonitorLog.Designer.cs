namespace IRAP.UFMPS.Library.UserControls
{
    partial class UCMonitorLog
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlLog = new DevExpress.XtraTreeList.TreeList();
            this.tclmnTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tclmnMessage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tlLog)).BeginInit();
            this.SuspendLayout();
            // 
            // tlLog
            // 
            this.tlLog.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tclmnTime,
            this.tclmnMessage});
            this.tlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlLog.Location = new System.Drawing.Point(0, 0);
            this.tlLog.Name = "tlLog";
            this.tlLog.OptionsBehavior.Editable = false;
            this.tlLog.OptionsView.AutoWidth = false;
            this.tlLog.Size = new System.Drawing.Size(593, 408);
            this.tlLog.TabIndex = 1;
            // 
            // tclmnTime
            // 
            this.tclmnTime.AppearanceHeader.Options.UseTextOptions = true;
            this.tclmnTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tclmnTime.Caption = "时间";
            this.tclmnTime.FieldName = "时间";
            this.tclmnTime.Format.FormatString = "d";
            this.tclmnTime.Name = "tclmnTime";
            this.tclmnTime.OptionsColumn.AllowFocus = false;
            this.tclmnTime.OptionsColumn.AllowMove = false;
            this.tclmnTime.OptionsColumn.AllowSort = false;
            this.tclmnTime.Visible = true;
            this.tclmnTime.VisibleIndex = 0;
            this.tclmnTime.Width = 160;
            // 
            // tclmnMessage
            // 
            this.tclmnMessage.AppearanceHeader.Options.UseTextOptions = true;
            this.tclmnMessage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnMessage.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tclmnMessage.Caption = "日志";
            this.tclmnMessage.FieldName = "日志";
            this.tclmnMessage.Name = "tclmnMessage";
            this.tclmnMessage.OptionsColumn.AllowMove = false;
            this.tclmnMessage.OptionsColumn.AllowSort = false;
            this.tclmnMessage.Visible = true;
            this.tclmnMessage.VisibleIndex = 1;
            this.tclmnMessage.Width = 287;
            // 
            // UCMonitorLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlLog);
            this.Name = "UCMonitorLog";
            this.Size = new System.Drawing.Size(593, 408);
            ((System.ComponentModel.ISupportInitialize)(this.tlLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.Columns.TreeListColumn tclmnTime;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclmnMessage;
        public DevExpress.XtraTreeList.TreeList tlLog;
    }
}
