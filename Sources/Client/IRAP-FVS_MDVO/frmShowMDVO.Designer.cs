namespace IRAP_FVS_MDVO
{
    partial class frmShowMDVO
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowMDVO));
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnClose = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnShowWorkUnitAndProduction = new DevExpress.XtraBars.Navigation.NavButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tcDocuments = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.tcDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.ButtonPadding = new System.Windows.Forms.Padding(12);
            this.tileNavPane1.Buttons.Add(this.btnClose);
            this.tileNavPane1.Buttons.Add(this.btnShowWorkUnitAndProduction);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            this.tileNavPane1.DefaultCategory.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane1.DefaultCategory.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavPane1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileNavPane1.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane1.Name = "tileNavPane1";
            this.tileNavPane1.OptionsPrimaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.OptionsSecondaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.Size = new System.Drawing.Size(740, 40);
            this.tileNavPane1.TabIndex = 0;
            this.tileNavPane1.Text = "tileNavPane1";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "关闭";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.btnClose_ElementClick);
            // 
            // btnShowWorkUnitAndProduction
            // 
            this.btnShowWorkUnitAndProduction.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnShowWorkUnitAndProduction.Caption = "";
            this.btnShowWorkUnitAndProduction.Enabled = false;
            this.btnShowWorkUnitAndProduction.Name = "btnShowWorkUnitAndProduction";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelControl1.Location = new System.Drawing.Point(0, 447);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(740, 54);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "江苏芍园科技有限责任公司 版权所有 2016";
            // 
            // tcDocuments
            // 
            this.tcDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcDocuments.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.tcDocuments.Appearance.Options.UseBackColor = true;
            this.tcDocuments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tcDocuments.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            this.tcDocuments.Location = new System.Drawing.Point(12, 87);
            this.tcDocuments.Name = "tcDocuments";
            this.tcDocuments.PaintStyleName = "Standard";
            this.tcDocuments.Size = new System.Drawing.Size(716, 344);
            this.tcDocuments.TabIndex = 2;
            this.tcDocuments.TabStop = false;
            // 
            // frmShowMDVO
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::IRAP_FVS_MDVO.Properties.Resources.KanbanBackground;
            this.ClientSize = new System.Drawing.Size(740, 501);
            this.ControlBox = false;
            this.Controls.Add(this.tcDocuments);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tileNavPane1);
            this.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmShowMDVO";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.tcDocuments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton btnClose;
        private DevExpress.XtraBars.Navigation.NavButton btnShowWorkUnitAndProduction;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabControl tcDocuments;
    }
}