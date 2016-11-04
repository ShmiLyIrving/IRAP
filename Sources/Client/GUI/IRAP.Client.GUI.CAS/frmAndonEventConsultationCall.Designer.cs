namespace IRAP.Client.GUI.CAS
{
    partial class frmAndonEventConsultationCall
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
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpAndonEvents = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lstWaitingforCall = new DevExpress.XtraEditors.ListBoxControl();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lstReadyToCall = new DevExpress.XtraEditors.ListBoxControl();
            this.btnConsultationCall = new DevExpress.XtraEditors.SimpleButton();
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.cboAndonEvent = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tpIDCardnoRead = new DevExpress.XtraTab.XtraTabPage();
            this.pnlIDCardNoRead = new DevExpress.XtraEditors.PanelControl();
            this.edtIDCardNo = new DevExpress.XtraEditors.TextEdit();
            this.lblGetIDNo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstWaitingforCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstReadyToCall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAndonEvent.Properties)).BeginInit();
            this.tpIDCardnoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIDCardNoRead)).BeginInit();
            this.pnlIDCardNoRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "安灯事件会诊呼叫";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.tcMain.Location = new System.Drawing.Point(0, 56);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.tpAndonEvents;
            this.tcMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tcMain.Size = new System.Drawing.Size(891, 652);
            this.tcMain.TabIndex = 2;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpIDCardnoRead,
            this.tpAndonEvents});
            // 
            // tpAndonEvents
            // 
            this.tpAndonEvents.Controls.Add(this.splitContainerControl);
            this.tpAndonEvents.Controls.Add(this.gpcAndonEvents);
            this.tpAndonEvents.Name = "tpAndonEvents";
            this.tpAndonEvents.Size = new System.Drawing.Size(885, 646);
            this.tpAndonEvents.Text = "xtraTabPage2";
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl.Location = new System.Drawing.Point(22, 81);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(847, 547);
            this.splitContainerControl.SplitterPosition = 380;
            this.splitContainerControl.TabIndex = 4;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.lstWaitingforCall);
            this.groupControl1.Controls.Add(this.cboType);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(380, 547);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "可以呼叫的人员";
            // 
            // lstWaitingforCall
            // 
            this.lstWaitingforCall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWaitingforCall.Location = new System.Drawing.Point(5, 50);
            this.lstWaitingforCall.Name = "lstWaitingforCall";
            this.lstWaitingforCall.Size = new System.Drawing.Size(370, 492);
            this.lstWaitingforCall.TabIndex = 1;
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.Location = new System.Drawing.Point(5, 24);
            this.cboType.Name = "cboType";
            this.cboType.Properties.Appearance.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.Properties.Appearance.Options.UseFont = true;
            this.cboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboType.Size = new System.Drawing.Size(370, 20);
            this.cboType.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.lstReadyToCall);
            this.groupControl2.Controls.Add(this.btnConsultationCall);
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(462, 547);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "准备呼叫的人员";
            // 
            // lstReadyToCall
            // 
            this.lstReadyToCall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstReadyToCall.Location = new System.Drawing.Point(5, 24);
            this.lstReadyToCall.Name = "lstReadyToCall";
            this.lstReadyToCall.Size = new System.Drawing.Size(452, 481);
            this.lstReadyToCall.TabIndex = 1;
            // 
            // btnConsultationCall
            // 
            this.btnConsultationCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultationCall.Appearance.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConsultationCall.Appearance.Options.UseFont = true;
            this.btnConsultationCall.Location = new System.Drawing.Point(369, 511);
            this.btnConsultationCall.Name = "btnConsultationCall";
            this.btnConsultationCall.Size = new System.Drawing.Size(88, 31);
            this.btnConsultationCall.TabIndex = 2;
            this.btnConsultationCall.Text = "呼叫";
            // 
            // gpcAndonEvents
            // 
            this.gpcAndonEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcAndonEvents.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcAndonEvents.Appearance.Options.UseFont = true;
            this.gpcAndonEvents.AppearanceCaption.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpcAndonEvents.AppearanceCaption.Options.UseFont = true;
            this.gpcAndonEvents.Controls.Add(this.cboAndonEvent);
            this.gpcAndonEvents.Location = new System.Drawing.Point(22, 17);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            this.gpcAndonEvents.Padding = new System.Windows.Forms.Padding(5);
            this.gpcAndonEvents.Size = new System.Drawing.Size(847, 58);
            this.gpcAndonEvents.TabIndex = 0;
            this.gpcAndonEvents.Text = "我响应的安灯事件";
            // 
            // cboAndonEvent
            // 
            this.cboAndonEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAndonEvent.Location = new System.Drawing.Point(10, 29);
            this.cboAndonEvent.Name = "cboAndonEvent";
            this.cboAndonEvent.Properties.Appearance.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAndonEvent.Properties.Appearance.Options.UseFont = true;
            this.cboAndonEvent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAndonEvent.Size = new System.Drawing.Size(827, 20);
            this.cboAndonEvent.TabIndex = 1;
            // 
            // tpIDCardnoRead
            // 
            this.tpIDCardnoRead.Controls.Add(this.pnlIDCardNoRead);
            this.tpIDCardnoRead.Name = "tpIDCardnoRead";
            this.tpIDCardnoRead.Size = new System.Drawing.Size(885, 646);
            // 
            // pnlIDCardNoRead
            // 
            this.pnlIDCardNoRead.ContentImage = global::IRAP.Client.GUI.CAS.Properties.Resources.AndonCall;
            this.pnlIDCardNoRead.Controls.Add(this.edtIDCardNo);
            this.pnlIDCardNoRead.Controls.Add(this.lblGetIDNo);
            this.pnlIDCardNoRead.Location = new System.Drawing.Point(22, 26);
            this.pnlIDCardNoRead.Name = "pnlIDCardNoRead";
            this.pnlIDCardNoRead.Size = new System.Drawing.Size(800, 600);
            this.pnlIDCardNoRead.TabIndex = 0;
            // 
            // edtIDCardNo
            // 
            this.edtIDCardNo.EditValue = "";
            this.edtIDCardNo.Location = new System.Drawing.Point(465, 316);
            this.edtIDCardNo.Name = "edtIDCardNo";
            this.edtIDCardNo.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtIDCardNo.Properties.Appearance.Options.UseFont = true;
            this.edtIDCardNo.Properties.Appearance.Options.UseTextOptions = true;
            this.edtIDCardNo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.edtIDCardNo.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.edtIDCardNo.Properties.UseSystemPasswordChar = true;
            this.edtIDCardNo.Size = new System.Drawing.Size(300, 26);
            this.edtIDCardNo.TabIndex = 1;
            this.edtIDCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtIDCardNo_KeyDown);
            // 
            // lblGetIDNo
            // 
            this.lblGetIDNo.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGetIDNo.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblGetIDNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblGetIDNo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.lblGetIDNo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblGetIDNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGetIDNo.Location = new System.Drawing.Point(465, 234);
            this.lblGetIDNo.Name = "lblGetIDNo";
            this.lblGetIDNo.Size = new System.Drawing.Size(300, 76);
            this.lblGetIDNo.TabIndex = 0;
            this.lblGetIDNo.Text = "    请刷卡或输入工号，获取呼叫您的安灯事件：";
            // 
            // frmAndonEventConsultationCall
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 708);
            this.Controls.Add(this.tcMain);
            this.Name = "frmAndonEventConsultationCall";
            this.Text = "安灯事件会诊呼叫";
            this.Shown += new System.EventHandler(this.frmAndonEventConsultation_Shown);
            this.Resize += new System.EventHandler(this.frmAndonEventConsultation_Resize);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.tcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstWaitingforCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstReadyToCall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboAndonEvent.Properties)).EndInit();
            this.tpIDCardnoRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlIDCardNoRead)).EndInit();
            this.pnlIDCardNoRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtIDCardNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage tpIDCardnoRead;
        private DevExpress.XtraEditors.PanelControl pnlIDCardNoRead;
        private DevExpress.XtraEditors.TextEdit edtIDCardNo;
        private DevExpress.XtraEditors.LabelControl lblGetIDNo;
        private DevExpress.XtraTab.XtraTabPage tpAndonEvents;
        private DevExpress.XtraEditors.SimpleButton btnConsultationCall;
        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.XtraEditors.ComboBoxEdit cboAndonEvent;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ListBoxControl lstWaitingforCall;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ListBoxControl lstReadyToCall;
    }
}
