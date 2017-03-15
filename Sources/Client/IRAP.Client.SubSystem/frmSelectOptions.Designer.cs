namespace IRAP.Client.SubSystem
{
    partial class frmSelectOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectOptions));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lstOptionOnes = new DevExpress.XtraEditors.ListBoxControl();
            this.lstOptionTwos = new DevExpress.XtraEditors.ListBoxControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.edtSearchCondition = new DevExpress.XtraEditors.TextEdit();
            this.btnShowAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstOptionOnes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOptionTwos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchCondition.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // splitContainerControl1
            // 
            resources.ApplyResources(this.splitContainerControl1, "splitContainerControl1");
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("splitContainerControl1.Panel1.AppearanceCaption.Font")));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.lstOptionOnes);
            resources.ApplyResources(this.splitContainerControl1.Panel1, "splitContainerControl1.Panel1");
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("splitContainerControl1.Panel2.AppearanceCaption.Font")));
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.lstOptionTwos);
            resources.ApplyResources(this.splitContainerControl1.Panel2, "splitContainerControl1.Panel2");
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.SplitterPosition = 232;
            // 
            // lstOptionOnes
            // 
            this.lstOptionOnes.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lstOptionOnes.Appearance.Font")));
            this.lstOptionOnes.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.lstOptionOnes, "lstOptionOnes");
            this.lstOptionOnes.Name = "lstOptionOnes";
            this.lstOptionOnes.SelectedIndexChanged += new System.EventHandler(this.lstOptionTwos_SelectedIndexChanged);
            // 
            // lstOptionTwos
            // 
            this.lstOptionTwos.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lstOptionTwos.Appearance.Font")));
            this.lstOptionTwos.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.lstOptionTwos, "lstOptionTwos");
            this.lstOptionTwos.Name = "lstOptionTwos";
            this.lstOptionTwos.Click += new System.EventHandler(this.lstWorkUnits_Click);
            this.lstOptionTwos.DoubleClick += new System.EventHandler(this.lstWorkUnits_DoubleClick);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("splitContainerControl2.AppearanceCaption.Font")));
            this.splitContainerControl2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.IsSplitterFixed = true;
            resources.ApplyResources(this.splitContainerControl2, "splitContainerControl2");
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.splitContainerControl1);
            resources.ApplyResources(this.splitContainerControl2.Panel1, "splitContainerControl2.Panel1");
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("splitContainerControl2.Panel2.AppearanceCaption.Font")));
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel2.Controls.Add(this.edtSearchCondition);
            this.splitContainerControl2.Panel2.Controls.Add(this.btnShowAll);
            this.splitContainerControl2.Panel2.Controls.Add(this.btnSearch);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            resources.ApplyResources(this.splitContainerControl2.Panel2, "splitContainerControl2.Panel2");
            this.splitContainerControl2.SplitterPosition = 71;
            // 
            // edtSearchCondition
            // 
            resources.ApplyResources(this.edtSearchCondition, "edtSearchCondition");
            this.edtSearchCondition.Name = "edtSearchCondition";
            this.edtSearchCondition.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtSearchCondition.Properties.Appearance.Font")));
            this.edtSearchCondition.Properties.Appearance.Options.UseFont = true;
            this.edtSearchCondition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtSearchCondition_KeyDown);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnShowAll.Appearance.Font")));
            this.btnShowAll.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btnShowAll, "btnShowAll");
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnSearch.Appearance.Font")));
            this.btnSearch.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnCancel.Appearance.Font")));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            // 
            // btnSelect
            // 
            this.btnSelect.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnSelect.Appearance.Font")));
            this.btnSelect.Appearance.Options.UseFont = true;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmSelectOptions
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitContainerControl2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Name = "frmSelectOptions";
            this.Load += new System.EventHandler(this.frmSelectOptions_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSelectOptions_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstOptionOnes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOptionTwos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchCondition.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.ListBoxControl lstOptionOnes;
        private DevExpress.XtraEditors.ListBoxControl lstOptionTwos;
        private DevExpress.XtraEditors.SimpleButton btnShowAll;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit edtSearchCondition;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
    }
}
