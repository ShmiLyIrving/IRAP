namespace IRAP.Client.GUI.MESPDC
{
    partial class frmUDFForm1Ex_30
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
            this.xucIRAPListView = new IRAP.Client.Global.GUI.xucIRAPListView();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(478, 56);
            this.lblFuncName.Text = "万能表单";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // xucIRAPListView
            // 
            this.xucIRAPListView.Caption = "操作日志";
            this.xucIRAPListView.Location = new System.Drawing.Point(12, 79);
            this.xucIRAPListView.MaxLineNumber = 1000;
            this.xucIRAPListView.Name = "xucIRAPListView";
            this.xucIRAPListView.Padding = new System.Windows.Forms.Padding(5);
            this.xucIRAPListView.Size = new System.Drawing.Size(454, 179);
            this.xucIRAPListView.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlBody.Controls.Add(this.xucIRAPListView);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 56);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(478, 269);
            this.pnlBody.TabIndex = 2;
            // 
            // frmUDFForm1Ex_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(478, 325);
            this.Controls.Add(this.pnlBody);
            this.Name = "frmUDFForm1Ex_30";
            this.Text = "万能表单";
            this.Activated += new System.EventHandler(this.frmUDFForm1Ex_30_Activated);
            this.Shown += new System.EventHandler(this.frmUDFForm1Ex_30_Shown);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Global.GUI.xucIRAPListView xucIRAPListView;
        private DevExpress.XtraEditors.PanelControl pnlBody;
    }
}
