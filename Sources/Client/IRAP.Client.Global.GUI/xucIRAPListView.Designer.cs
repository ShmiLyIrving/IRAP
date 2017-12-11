namespace IRAP.Client.Global.GUI
{
    partial class xucIRAPListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xucIRAPListView));
            this.gpcLogs = new DevExpress.XtraEditors.GroupControl();
            this.tlLogs = new DevExpress.XtraTreeList.TreeList();
            this.tclmnTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tclmnErrCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tclmnErrText = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gpcLogs)).BeginInit();
            this.gpcLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // gpcLogs
            // 
            this.gpcLogs.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("gpcLogs.Appearance.Font")));
            this.gpcLogs.Appearance.Options.UseFont = true;
            this.gpcLogs.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("gpcLogs.AppearanceCaption.Font")));
            this.gpcLogs.AppearanceCaption.Options.UseFont = true;
            this.gpcLogs.Controls.Add(this.tlLogs);
            resources.ApplyResources(this.gpcLogs, "gpcLogs");
            this.gpcLogs.Name = "gpcLogs";
            // 
            // tlLogs
            // 
            resources.ApplyResources(this.tlLogs, "tlLogs");
            this.tlLogs.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tclmnTime,
            this.tclmnErrCode,
            this.tclmnErrText});
            this.tlLogs.Name = "tlLogs";
            this.tlLogs.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.tlLogs.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.tlLogs.OptionsView.AutoWidth = false;
            this.tlLogs.OptionsView.ShowRoot = false;
            this.tlLogs.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.tlLogs_CustomDrawNodeCell);
            // 
            // tclmnTime
            // 
            this.tclmnTime.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("tclmnTime.AppearanceCell.Font")));
            this.tclmnTime.AppearanceCell.Options.UseFont = true;
            this.tclmnTime.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("tclmnTime.AppearanceHeader.Font")));
            this.tclmnTime.AppearanceHeader.Options.UseFont = true;
            this.tclmnTime.AppearanceHeader.Options.UseTextOptions = true;
            this.tclmnTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.tclmnTime, "tclmnTime");
            this.tclmnTime.FieldName = "操作时间";
            this.tclmnTime.Name = "tclmnTime";
            this.tclmnTime.OptionsColumn.AllowEdit = false;
            this.tclmnTime.OptionsColumn.AllowMove = false;
            this.tclmnTime.OptionsColumn.AllowSort = false;
            this.tclmnTime.OptionsColumn.ReadOnly = true;
            this.tclmnTime.OptionsFilter.AllowFilter = false;
            // 
            // tclmnErrCode
            // 
            this.tclmnErrCode.AppearanceHeader.Options.UseTextOptions = true;
            this.tclmnErrCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnErrCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.tclmnErrCode, "tclmnErrCode");
            this.tclmnErrCode.FieldName = "错误代码";
            this.tclmnErrCode.Name = "tclmnErrCode";
            // 
            // tclmnErrText
            // 
            this.tclmnErrText.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("tclmnErrText.AppearanceCell.Font")));
            this.tclmnErrText.AppearanceCell.Options.UseFont = true;
            this.tclmnErrText.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("tclmnErrText.AppearanceHeader.Font")));
            this.tclmnErrText.AppearanceHeader.Options.UseFont = true;
            this.tclmnErrText.AppearanceHeader.Options.UseTextOptions = true;
            this.tclmnErrText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tclmnErrText.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.tclmnErrText, "tclmnErrText");
            this.tclmnErrText.FieldName = "操作结果";
            this.tclmnErrText.Name = "tclmnErrText";
            this.tclmnErrText.OptionsColumn.AllowEdit = false;
            this.tclmnErrText.OptionsColumn.AllowMove = false;
            this.tclmnErrText.OptionsColumn.AllowSort = false;
            this.tclmnErrText.OptionsColumn.ReadOnly = true;
            this.tclmnErrText.OptionsFilter.AllowFilter = false;
            // 
            // xucIRAPListView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gpcLogs);
            this.Name = "xucIRAPListView";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.gpcLogs)).EndInit();
            this.gpcLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpcLogs;
        private DevExpress.XtraTreeList.TreeList tlLogs;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclmnTime;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclmnErrCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclmnErrText;
    }
}
