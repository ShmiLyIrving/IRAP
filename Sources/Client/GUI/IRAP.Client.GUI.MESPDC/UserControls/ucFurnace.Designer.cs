namespace IRAP.Client.GUI.MESPDC.UserControls {
    partial class ucFurnace {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.grpCtrProductionInfo = new DevExpress.XtraEditors.GroupControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.grdCtrProductionInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelController = new DevExpress.XtraEditors.LabelControl();
            this.txtController = new DevExpress.XtraEditors.TextEdit();
            this.labelProductionDate = new DevExpress.XtraEditors.LabelControl();
            this.txtProductDate = new DevExpress.XtraEditors.TextEdit();
            this.labelFurnaceTime = new DevExpress.XtraEditors.LabelControl();
            this.cmbFurnaceTime = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grpCtrlCurrentInfo = new DevExpress.XtraEditors.GroupControl();
            this.labProductStartTimeResult = new DevExpress.XtraEditors.LabelControl();
            this.labCurrentFurnaceResult = new DevExpress.XtraEditors.LabelControl();
            this.labCurrentFurnace = new DevExpress.XtraEditors.LabelControl();
            this.labCtrlStartTime = new DevExpress.XtraEditors.LabelControl();
            this.tabCtrlDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tabPgBurden = new DevExpress.XtraTab.XtraTabPage();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.grpProductPara = new DevExpress.XtraEditors.GroupControl();
            this.grdProductPara = new DevExpress.XtraVerticalGrid.VGridControl();
            this.grpBurdenInfo = new DevExpress.XtraEditors.GroupControl();
            this.grdBurdenInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPgSpectrum = new DevExpress.XtraTab.XtraTabPage();
            this.tabPgMatieralAjustment = new DevExpress.XtraTab.XtraTabPage();
            this.tabPgSample = new DevExpress.XtraTab.XtraTabPage();
            this.tabPgBaked = new DevExpress.XtraTab.XtraTabPage();
            this.ucDetailGrid1 = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            this.ucDetailGrid2 = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            this.ucDetailGrid3 = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            this.ucDetailGrid4 = new IRAP.Client.GUI.MESPDC.UserControls.ucDetailGrid();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrProductionInfo)).BeginInit();
            this.grpCtrProductionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtController.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFurnaceTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlCurrentInfo)).BeginInit();
            this.grpCtrlCurrentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlDetail)).BeginInit();
            this.tabCtrlDetail.SuspendLayout();
            this.tabPgBurden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpProductPara)).BeginInit();
            this.grpProductPara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBurdenInfo)).BeginInit();
            this.grpBurdenInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBurdenInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tabPgSpectrum.SuspendLayout();
            this.tabPgMatieralAjustment.SuspendLayout();
            this.tabPgSample.SuspendLayout();
            this.tabPgBaked.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCtrProductionInfo
            // 
            this.grpCtrProductionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCtrProductionInfo.Controls.Add(this.btnPrint);
            this.grpCtrProductionInfo.Controls.Add(this.grdCtrProductionInfo);
            this.grpCtrProductionInfo.Location = new System.Drawing.Point(3, 38);
            this.grpCtrProductionInfo.Name = "grpCtrProductionInfo";
            this.grpCtrProductionInfo.Size = new System.Drawing.Size(494, 233);
            this.grpCtrProductionInfo.TabIndex = 0;
            this.grpCtrProductionInfo.Text = "生产信息";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(414, 205);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打印";
            // 
            // grdCtrProductionInfo
            // 
            this.grdCtrProductionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCtrProductionInfo.Location = new System.Drawing.Point(5, 24);
            this.grdCtrProductionInfo.MainView = this.gridView1;
            this.grdCtrProductionInfo.Name = "grdCtrProductionInfo";
            this.grdCtrProductionInfo.Size = new System.Drawing.Size(484, 178);
            this.grdCtrProductionInfo.TabIndex = 0;
            this.grdCtrProductionInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdCtrProductionInfo;
            this.gridView1.Name = "gridView1";
            // 
            // labelController
            // 
            this.labelController.Location = new System.Drawing.Point(9, 15);
            this.labelController.Name = "labelController";
            this.labelController.Size = new System.Drawing.Size(40, 14);
            this.labelController.TabIndex = 1;
            this.labelController.Text = "操作工:";
            // 
            // txtController
            // 
            this.txtController.Location = new System.Drawing.Point(55, 12);
            this.txtController.Name = "txtController";
            this.txtController.Size = new System.Drawing.Size(100, 20);
            this.txtController.TabIndex = 2;
            // 
            // labelProductionDate
            // 
            this.labelProductionDate.Location = new System.Drawing.Point(182, 15);
            this.labelProductionDate.Name = "labelProductionDate";
            this.labelProductionDate.Size = new System.Drawing.Size(52, 14);
            this.labelProductionDate.TabIndex = 3;
            this.labelProductionDate.Text = "生产日期:";
            // 
            // txtProductDate
            // 
            this.txtProductDate.Location = new System.Drawing.Point(240, 12);
            this.txtProductDate.Name = "txtProductDate";
            this.txtProductDate.Size = new System.Drawing.Size(100, 20);
            this.txtProductDate.TabIndex = 4;
            // 
            // labelFurnaceTime
            // 
            this.labelFurnaceTime.Location = new System.Drawing.Point(363, 15);
            this.labelFurnaceTime.Name = "labelFurnaceTime";
            this.labelFurnaceTime.Size = new System.Drawing.Size(28, 14);
            this.labelFurnaceTime.TabIndex = 5;
            this.labelFurnaceTime.Text = "炉次:";
            // 
            // cmbFurnaceTime
            // 
            this.cmbFurnaceTime.Location = new System.Drawing.Point(397, 12);
            this.cmbFurnaceTime.Name = "cmbFurnaceTime";
            this.cmbFurnaceTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFurnaceTime.Size = new System.Drawing.Size(100, 20);
            this.cmbFurnaceTime.TabIndex = 7;
            // 
            // grpCtrlCurrentInfo
            // 
            this.grpCtrlCurrentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCtrlCurrentInfo.Controls.Add(this.labProductStartTimeResult);
            this.grpCtrlCurrentInfo.Controls.Add(this.labCurrentFurnaceResult);
            this.grpCtrlCurrentInfo.Controls.Add(this.labCurrentFurnace);
            this.grpCtrlCurrentInfo.Controls.Add(this.labCtrlStartTime);
            this.grpCtrlCurrentInfo.Location = new System.Drawing.Point(503, 38);
            this.grpCtrlCurrentInfo.Name = "grpCtrlCurrentInfo";
            this.grpCtrlCurrentInfo.Size = new System.Drawing.Size(272, 115);
            this.grpCtrlCurrentInfo.TabIndex = 8;
            this.grpCtrlCurrentInfo.Text = "当前熔炼信息";
            // 
            // labProductStartTimeResult
            // 
            this.labProductStartTimeResult.Location = new System.Drawing.Point(100, 43);
            this.labProductStartTimeResult.Name = "labProductStartTimeResult";
            this.labProductStartTimeResult.Size = new System.Drawing.Size(0, 14);
            this.labProductStartTimeResult.TabIndex = 13;
            // 
            // labCurrentFurnaceResult
            // 
            this.labCurrentFurnaceResult.Location = new System.Drawing.Point(100, 81);
            this.labCurrentFurnaceResult.Name = "labCurrentFurnaceResult";
            this.labCurrentFurnaceResult.Size = new System.Drawing.Size(0, 14);
            this.labCurrentFurnaceResult.TabIndex = 12;
            // 
            // labCurrentFurnace
            // 
            this.labCurrentFurnace.Location = new System.Drawing.Point(30, 81);
            this.labCurrentFurnace.Name = "labCurrentFurnace";
            this.labCurrentFurnace.Size = new System.Drawing.Size(64, 14);
            this.labCurrentFurnace.TabIndex = 10;
            this.labCurrentFurnace.Text = "当前炉次号:";
            // 
            // labCtrlStartTime
            // 
            this.labCtrlStartTime.Location = new System.Drawing.Point(18, 43);
            this.labCtrlStartTime.Name = "labCtrlStartTime";
            this.labCtrlStartTime.Size = new System.Drawing.Size(76, 14);
            this.labCtrlStartTime.TabIndex = 8;
            this.labCtrlStartTime.Text = "生产开始时间:";
            // 
            // tabCtrlDetail
            // 
            this.tabCtrlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrlDetail.Location = new System.Drawing.Point(3, 277);
            this.tabCtrlDetail.Name = "tabCtrlDetail";
            this.tabCtrlDetail.SelectedTabPage = this.tabPgBurden;
            this.tabCtrlDetail.Size = new System.Drawing.Size(772, 255);
            this.tabCtrlDetail.TabIndex = 9;
            this.tabCtrlDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPgBurden,
            this.tabPgSpectrum,
            this.tabPgMatieralAjustment,
            this.tabPgSample,
            this.tabPgBaked});
            // 
            // tabPgBurden
            // 
            this.tabPgBurden.AutoScroll = true;
            this.tabPgBurden.Controls.Add(this.btnStart);
            this.tabPgBurden.Controls.Add(this.grpProductPara);
            this.tabPgBurden.Controls.Add(this.grpBurdenInfo);
            this.tabPgBurden.Name = "tabPgBurden";
            this.tabPgBurden.Size = new System.Drawing.Size(766, 226);
            this.tabPgBurden.Text = "配料及开炉熔炼";
            this.tabPgBurden.Tooltip = "配料及开炉熔炼";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(685, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 45);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "生产开始";
            // 
            // grpProductPara
            // 
            this.grpProductPara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProductPara.Controls.Add(this.grdProductPara);
            this.grpProductPara.Location = new System.Drawing.Point(384, 3);
            this.grpProductPara.Name = "grpProductPara";
            this.grpProductPara.Size = new System.Drawing.Size(298, 220);
            this.grpProductPara.TabIndex = 4;
            this.grpProductPara.Text = "生产开炉参数";
            // 
            // grdProductPara
            // 
            this.grdProductPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProductPara.Location = new System.Drawing.Point(2, 21);
            this.grdProductPara.Name = "grdProductPara";
            this.grdProductPara.Size = new System.Drawing.Size(294, 197);
            this.grdProductPara.TabIndex = 0;
            // 
            // grpBurdenInfo
            // 
            this.grpBurdenInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBurdenInfo.Controls.Add(this.grdBurdenInfo);
            this.grpBurdenInfo.Location = new System.Drawing.Point(3, 3);
            this.grpBurdenInfo.Name = "grpBurdenInfo";
            this.grpBurdenInfo.Size = new System.Drawing.Size(378, 220);
            this.grpBurdenInfo.TabIndex = 3;
            this.grpBurdenInfo.Text = "配料信息";
            // 
            // grdBurdenInfo
            // 
            this.grdBurdenInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBurdenInfo.Location = new System.Drawing.Point(2, 21);
            this.grdBurdenInfo.MainView = this.gridView2;
            this.grdBurdenInfo.Name = "grdBurdenInfo";
            this.grdBurdenInfo.Size = new System.Drawing.Size(374, 197);
            this.grdBurdenInfo.TabIndex = 0;
            this.grdBurdenInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdBurdenInfo;
            this.gridView2.Name = "gridView2";
            // 
            // tabPgSpectrum
            // 
            this.tabPgSpectrum.AutoScroll = true;
            this.tabPgSpectrum.Controls.Add(this.ucDetailGrid2);
            this.tabPgSpectrum.Name = "tabPgSpectrum";
            this.tabPgSpectrum.Size = new System.Drawing.Size(766, 226);
            this.tabPgSpectrum.Text = "炉前光谱";
            this.tabPgSpectrum.Tooltip = "炉前光谱";
            // 
            // tabPgMatieralAjustment
            // 
            this.tabPgMatieralAjustment.Controls.Add(this.ucDetailGrid3);
            this.tabPgMatieralAjustment.Name = "tabPgMatieralAjustment";
            this.tabPgMatieralAjustment.Size = new System.Drawing.Size(766, 226);
            this.tabPgMatieralAjustment.Text = "原材料调整";
            this.tabPgMatieralAjustment.Tooltip = "原材料调整";
            // 
            // tabPgSample
            // 
            this.tabPgSample.Controls.Add(this.ucDetailGrid4);
            this.tabPgSample.Name = "tabPgSample";
            this.tabPgSample.Size = new System.Drawing.Size(766, 226);
            this.tabPgSample.Text = "浇三角试样";
            this.tabPgSample.Tooltip = "浇三角试样";
            // 
            // tabPgBaked
            // 
            this.tabPgBaked.Controls.Add(this.ucDetailGrid1);
            this.tabPgBaked.Name = "tabPgBaked";
            this.tabPgBaked.Size = new System.Drawing.Size(766, 226);
            this.tabPgBaked.Text = "炉水出炉";
            this.tabPgBaked.Tooltip = "炉水出炉";
            // 
            // ucDetailGrid1
            // 
            this.ucDetailGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDetailGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucDetailGrid1.Name = "ucDetailGrid1";
            this.ucDetailGrid1.Size = new System.Drawing.Size(766, 226);
            this.ucDetailGrid1.TabIndex = 0;
            // 
            // ucDetailGrid2
            // 
            this.ucDetailGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDetailGrid2.Location = new System.Drawing.Point(0, 0);
            this.ucDetailGrid2.Name = "ucDetailGrid2";
            this.ucDetailGrid2.Size = new System.Drawing.Size(766, 226);
            this.ucDetailGrid2.TabIndex = 0;
            // 
            // ucDetailGrid3
            // 
            this.ucDetailGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDetailGrid3.Location = new System.Drawing.Point(0, 0);
            this.ucDetailGrid3.Name = "ucDetailGrid3";
            this.ucDetailGrid3.Size = new System.Drawing.Size(766, 226);
            this.ucDetailGrid3.TabIndex = 0;
            // 
            // ucDetailGrid4
            // 
            this.ucDetailGrid4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDetailGrid4.Location = new System.Drawing.Point(0, 0);
            this.ucDetailGrid4.Name = "ucDetailGrid4";
            this.ucDetailGrid4.Size = new System.Drawing.Size(766, 226);
            this.ucDetailGrid4.TabIndex = 0;
            // 
            // ucFurnace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCtrlDetail);
            this.Controls.Add(this.grpCtrlCurrentInfo);
            this.Controls.Add(this.cmbFurnaceTime);
            this.Controls.Add(this.labelFurnaceTime);
            this.Controls.Add(this.txtProductDate);
            this.Controls.Add(this.labelProductionDate);
            this.Controls.Add(this.txtController);
            this.Controls.Add(this.labelController);
            this.Controls.Add(this.grpCtrProductionInfo);
            this.Name = "ucFurnace";
            this.Size = new System.Drawing.Size(778, 535);
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrProductionInfo)).EndInit();
            this.grpCtrProductionInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrProductionInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtController.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFurnaceTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCtrlCurrentInfo)).EndInit();
            this.grpCtrlCurrentInfo.ResumeLayout(false);
            this.grpCtrlCurrentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCtrlDetail)).EndInit();
            this.tabCtrlDetail.ResumeLayout(false);
            this.tabPgBurden.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpProductPara)).EndInit();
            this.grpProductPara.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProductPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBurdenInfo)).EndInit();
            this.grpBurdenInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBurdenInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tabPgSpectrum.ResumeLayout(false);
            this.tabPgMatieralAjustment.ResumeLayout(false);
            this.tabPgSample.ResumeLayout(false);
            this.tabPgBaked.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpCtrProductionInfo;
        private DevExpress.XtraEditors.LabelControl labelController;
        private DevExpress.XtraEditors.TextEdit txtController;
        private DevExpress.XtraEditors.LabelControl labelProductionDate;
        private DevExpress.XtraEditors.TextEdit txtProductDate;
        private DevExpress.XtraEditors.LabelControl labelFurnaceTime;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl grdCtrProductionInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFurnaceTime;
        private DevExpress.XtraEditors.GroupControl grpCtrlCurrentInfo;
        private DevExpress.XtraTab.XtraTabControl tabCtrlDetail;
        private DevExpress.XtraEditors.LabelControl labProductStartTimeResult;
        private DevExpress.XtraEditors.LabelControl labCurrentFurnaceResult;
        private DevExpress.XtraEditors.LabelControl labCurrentFurnace;
        private DevExpress.XtraEditors.LabelControl labCtrlStartTime;
        private DevExpress.XtraTab.XtraTabPage tabPgBurden;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.GroupControl grpProductPara;
        private DevExpress.XtraVerticalGrid.VGridControl grdProductPara;
        private DevExpress.XtraEditors.GroupControl grpBurdenInfo;
        private DevExpress.XtraGrid.GridControl grdBurdenInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraTab.XtraTabPage tabPgSpectrum;
        private DevExpress.XtraTab.XtraTabPage tabPgMatieralAjustment;
        private DevExpress.XtraTab.XtraTabPage tabPgSample;
        private DevExpress.XtraTab.XtraTabPage tabPgBaked;
        private ucDetailGrid ucDetailGrid2;
        private ucDetailGrid ucDetailGrid3;
        private ucDetailGrid ucDetailGrid4;
        private ucDetailGrid ucDetailGrid1;
    }
}
