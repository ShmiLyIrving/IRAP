namespace IRAP.Client.GUI.MDM
{
    partial class frmTemplateManager
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
            DevExpress.Utils.SimpleContextButton simpleContextButton1 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton2 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton3 = new DevExpress.Utils.SimpleContextButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblCurrentTemplateName = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.previewControl = new FastReport.Preview.PreviewControl();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lstTemplates = new DevExpress.XtraEditors.ListBoxControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.tsmiReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.report = new FastReport.Report();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstTemplates)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblCurrentTemplateName);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(263, 45);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "当前标签";
            // 
            // lblCurrentTemplateName
            // 
            this.lblCurrentTemplateName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblCurrentTemplateName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCurrentTemplateName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentTemplateName.Location = new System.Drawing.Point(2, 22);
            this.lblCurrentTemplateName.Name = "lblCurrentTemplateName";
            this.lblCurrentTemplateName.Padding = new System.Windows.Forms.Padding(5);
            this.lblCurrentTemplateName.Size = new System.Drawing.Size(259, 24);
            this.lblCurrentTemplateName.TabIndex = 0;
            this.lblCurrentTemplateName.Text = "hyperlinkLabelControl1";
            this.lblCurrentTemplateName.Click += new System.EventHandler(this.lblCurrentTemplateName_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.previewControl);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(5, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(5);
            this.groupControl2.Size = new System.Drawing.Size(674, 558);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "标签预览";
            // 
            // previewControl
            // 
            this.previewControl.AutoScroll = true;
            this.previewControl.AutoSize = true;
            this.previewControl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl.Buttons = ((FastReport.PreviewButtons)((FastReport.PreviewButtons.Zoom | FastReport.PreviewButtons.Edit)));
            this.previewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.previewControl.Location = new System.Drawing.Point(7, 27);
            this.previewControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.previewControl.Name = "previewControl";
            this.previewControl.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl.Size = new System.Drawing.Size(660, 524);
            this.previewControl.StatusbarVisible = false;
            this.previewControl.TabIndex = 0;
            this.previewControl.ToolbarVisible = false;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.panelControl2);
            this.splitContainerControl.Panel1.Controls.Add(this.panelControl1);
            this.splitContainerControl.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(963, 568);
            this.splitContainerControl.SplitterPosition = 273;
            this.splitContainerControl.TabIndex = 2;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.groupControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(5, 50);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panelControl2.Size = new System.Drawing.Size(263, 513);
            this.panelControl2.TabIndex = 3;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.lstTemplates);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 5);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(263, 508);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "标签模板库";
            // 
            // lstTemplates
            // 
            simpleContextButton1.Id = new System.Guid("be9a2b9e-dd22-4f20-9bb4-2b6266fd194d");
            simpleContextButton1.Name = "SimpleContextButton";
            simpleContextButton2.Id = new System.Guid("ed44524c-8f52-4e01-a859-4726cc1bf043");
            simpleContextButton2.Name = "SimpleContextButton";
            simpleContextButton3.Id = new System.Guid("4096b981-4c56-4522-95b7-5529c73ab8eb");
            simpleContextButton3.Name = "SimpleContextButton";
            this.lstTemplates.ContextButtons.Add(simpleContextButton1);
            this.lstTemplates.ContextButtons.Add(simpleContextButton2);
            this.lstTemplates.ContextButtons.Add(simpleContextButton3);
            this.lstTemplates.ContextMenuStrip = this.contextMenuStrip;
            this.lstTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTemplates.Location = new System.Drawing.Point(2, 22);
            this.lstTemplates.Name = "lstTemplates";
            this.lstTemplates.Size = new System.Drawing.Size(259, 484);
            this.lstTemplates.TabIndex = 0;
            this.lstTemplates.SelectedIndexChanged += new System.EventHandler(this.lstTemplates_SelectedIndexChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReplace,
            this.toolStripMenuItem1,
            this.tsmiNew,
            this.tsmiEdit,
            this.tsmiDelete,
            this.toolStripMenuItem2,
            this.tsmiRename});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(213, 126);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // tsmiReplace
            // 
            this.tsmiReplace.Name = "tsmiReplace";
            this.tsmiReplace.Size = new System.Drawing.Size(212, 22);
            this.tsmiReplace.Text = "替换为当前模板(&R)";
            this.tsmiReplace.Click += new System.EventHandler(this.tsmiReplace_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(212, 22);
            this.tsmiNew.Text = "在当前模板基础上新增(&A)";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(212, 22);
            this.tsmiEdit.Text = "修改当前模板(&E)";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(212, 22);
            this.tsmiDelete.Text = "删除当前模板(&D)";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(209, 6);
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(212, 22);
            this.tsmiRename.Text = "重命名(&M)";
            this.tsmiRename.Click += new System.EventHandler(this.tsmiRename_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(5, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(263, 45);
            this.panelControl1.TabIndex = 2;
            // 
            // report
            // 
            this.report.ReportResourceString = "";
            this.report.StoreInResources = false;
            // 
            // frmTemplateManager
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 568);
            this.Controls.Add(this.splitContainerControl);
            this.Name = "frmTemplateManager";
            this.Text = "模板维护";
            this.Shown += new System.EventHandler(this.frmTemplateManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstTemplates)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.report)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ListBoxControl lstTemplates;
        private FastReport.Report report;
        private FastReport.Preview.PreviewControl previewControl;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblCurrentTemplateName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
    }
}
