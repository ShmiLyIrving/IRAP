namespace IRAP_FVS_LSSIVO.UserControls
{
    partial class ucECNtoLine
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
            this.lblSystem = new DevExpress.XtraEditors.LabelControl();
            this.lblEquipment = new DevExpress.XtraEditors.LabelControl();
            this.lblMaterial = new DevExpress.XtraEditors.LabelControl();
            this.lblMethod = new DevExpress.XtraEditors.LabelControl();
            this.lblEnvironment = new DevExpress.XtraEditors.LabelControl();
            this.grdOpenPWOs = new DevExpress.XtraGrid.GridControl();
            this.grdvOpenPWOs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnT276Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnECorAlertNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnChangeContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnToImplementDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnToCloseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdOpenPWOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOpenPWOs)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSystem
            // 
            this.lblSystem.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSystem.Appearance.Image = global::IRAP_FVS_LSSIVO.Properties.Resources.light_gray;
            this.lblSystem.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.lblSystem.Location = new System.Drawing.Point(20, 10);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(32, 38);
            this.lblSystem.TabIndex = 6;
            this.lblSystem.Text = "人员";
            // 
            // lblEquipment
            // 
            this.lblEquipment.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEquipment.Appearance.Image = global::IRAP_FVS_LSSIVO.Properties.Resources.light_gray;
            this.lblEquipment.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.lblEquipment.Location = new System.Drawing.Point(72, 10);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(32, 38);
            this.lblEquipment.TabIndex = 7;
            this.lblEquipment.Text = "设备";
            // 
            // lblMaterial
            // 
            this.lblMaterial.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaterial.Appearance.Image = global::IRAP_FVS_LSSIVO.Properties.Resources.light_gray;
            this.lblMaterial.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.lblMaterial.Location = new System.Drawing.Point(124, 10);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(32, 38);
            this.lblMaterial.TabIndex = 8;
            this.lblMaterial.Text = "物料";
            // 
            // lblMethod
            // 
            this.lblMethod.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMethod.Appearance.Image = global::IRAP_FVS_LSSIVO.Properties.Resources.light_gray;
            this.lblMethod.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.lblMethod.Location = new System.Drawing.Point(174, 10);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(32, 38);
            this.lblMethod.TabIndex = 9;
            this.lblMethod.Text = "方法";
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEnvironment.Appearance.Image = global::IRAP_FVS_LSSIVO.Properties.Resources.light_gray;
            this.lblEnvironment.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.lblEnvironment.Location = new System.Drawing.Point(226, 10);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Size = new System.Drawing.Size(32, 38);
            this.lblEnvironment.TabIndex = 10;
            this.lblEnvironment.Text = "环境";
            // 
            // grdOpenPWOs
            // 
            this.grdOpenPWOs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOpenPWOs.Location = new System.Drawing.Point(3, 58);
            this.grdOpenPWOs.MainView = this.grdvOpenPWOs;
            this.grdOpenPWOs.Name = "grdOpenPWOs";
            this.grdOpenPWOs.Size = new System.Drawing.Size(604, 249);
            this.grdOpenPWOs.TabIndex = 11;
            this.grdOpenPWOs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOpenPWOs});
            // 
            // grdvOpenPWOs
            // 
            this.grdvOpenPWOs.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvOpenPWOs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvOpenPWOs.Appearance.Row.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvOpenPWOs.Appearance.Row.Options.UseFont = true;
            this.grdvOpenPWOs.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grdvOpenPWOs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnT276Name,
            this.grdclmnECorAlertNo,
            this.grdclmnChangeContent,
            this.grdclmnToImplementDate,
            this.grdclmnToCloseDate});
            this.grdvOpenPWOs.GridControl = this.grdOpenPWOs;
            this.grdvOpenPWOs.Name = "grdvOpenPWOs";
            this.grdvOpenPWOs.OptionsView.ShowGroupPanel = false;
            this.grdvOpenPWOs.OptionsView.ShowIndicator = false;
            this.grdvOpenPWOs.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            // 
            // grdclmnT276Name
            // 
            this.grdclmnT276Name.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT276Name.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT276Name.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnT276Name.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT276Name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT276Name.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT276Name.Caption = "变更类型";
            this.grdclmnT276Name.FieldName = "T276Name";
            this.grdclmnT276Name.MaxWidth = 75;
            this.grdclmnT276Name.MinWidth = 75;
            this.grdclmnT276Name.Name = "grdclmnT276Name";
            this.grdclmnT276Name.Visible = true;
            this.grdclmnT276Name.VisibleIndex = 0;
            // 
            // grdclmnECorAlertNo
            // 
            this.grdclmnECorAlertNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnECorAlertNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnECorAlertNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnECorAlertNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnECorAlertNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnECorAlertNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnECorAlertNo.Caption = "ECN to line Number";
            this.grdclmnECorAlertNo.FieldName = "ECorAlertNo";
            this.grdclmnECorAlertNo.MaxWidth = 170;
            this.grdclmnECorAlertNo.MinWidth = 170;
            this.grdclmnECorAlertNo.Name = "grdclmnECorAlertNo";
            this.grdclmnECorAlertNo.Visible = true;
            this.grdclmnECorAlertNo.VisibleIndex = 1;
            this.grdclmnECorAlertNo.Width = 170;
            // 
            // grdclmnChangeContent
            // 
            this.grdclmnChangeContent.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnChangeContent.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnChangeContent.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnChangeContent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnChangeContent.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnChangeContent.Caption = "变更内容";
            this.grdclmnChangeContent.FieldName = "ChangeContent";
            this.grdclmnChangeContent.Name = "grdclmnChangeContent";
            this.grdclmnChangeContent.Visible = true;
            this.grdclmnChangeContent.VisibleIndex = 2;
            this.grdclmnChangeContent.Width = 145;
            // 
            // grdclmnToImplementDate
            // 
            this.grdclmnToImplementDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnToImplementDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnToImplementDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnToImplementDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnToImplementDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnToImplementDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnToImplementDate.Caption = "预计实施日期";
            this.grdclmnToImplementDate.FieldName = "ToImplementDate";
            this.grdclmnToImplementDate.MaxWidth = 120;
            this.grdclmnToImplementDate.MinWidth = 120;
            this.grdclmnToImplementDate.Name = "grdclmnToImplementDate";
            this.grdclmnToImplementDate.Visible = true;
            this.grdclmnToImplementDate.VisibleIndex = 3;
            this.grdclmnToImplementDate.Width = 120;
            // 
            // grdclmnToCloseDate
            // 
            this.grdclmnToCloseDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnToCloseDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnToCloseDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnToCloseDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnToCloseDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnToCloseDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnToCloseDate.Caption = "预计关闭日期";
            this.grdclmnToCloseDate.FieldName = "ToCloseDate";
            this.grdclmnToCloseDate.MaxWidth = 120;
            this.grdclmnToCloseDate.MinWidth = 120;
            this.grdclmnToCloseDate.Name = "grdclmnToCloseDate";
            this.grdclmnToCloseDate.Visible = true;
            this.grdclmnToCloseDate.VisibleIndex = 4;
            this.grdclmnToCloseDate.Width = 120;
            // 
            // ucECNtoLine
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdOpenPWOs);
            this.Controls.Add(this.lblEnvironment);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.lblEquipment);
            this.Controls.Add(this.lblSystem);
            this.Name = "ucECNtoLine";
            this.Size = new System.Drawing.Size(610, 310);
            ((System.ComponentModel.ISupportInitialize)(this.grdOpenPWOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOpenPWOs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblSystem;
        private DevExpress.XtraEditors.LabelControl lblEquipment;
        private DevExpress.XtraEditors.LabelControl lblMaterial;
        private DevExpress.XtraEditors.LabelControl lblMethod;
        private DevExpress.XtraEditors.LabelControl lblEnvironment;
        private DevExpress.XtraGrid.GridControl grdOpenPWOs;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOpenPWOs;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT276Name;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnECorAlertNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChangeContent;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToImplementDate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnToCloseDate;
    }
}
