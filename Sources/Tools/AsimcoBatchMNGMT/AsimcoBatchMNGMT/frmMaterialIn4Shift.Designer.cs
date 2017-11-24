namespace AsimcoBatchMNGMT
{
    partial class frmMaterialIn4Shift
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
            this.grdStockDetailIn4Shift = new DevExpress.XtraGrid.GridControl();
            this.grdvStockDetailIn4Shift = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdStockDetailIn4Shift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStockDetailIn4Shift)).BeginInit();
            this.SuspendLayout();
            // 
            // grdStockDetailIn4Shift
            // 
            this.grdStockDetailIn4Shift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStockDetailIn4Shift.Location = new System.Drawing.Point(0, 0);
            this.grdStockDetailIn4Shift.MainView = this.grdvStockDetailIn4Shift;
            this.grdStockDetailIn4Shift.Name = "grdStockDetailIn4Shift";
            this.grdStockDetailIn4Shift.Size = new System.Drawing.Size(766, 448);
            this.grdStockDetailIn4Shift.TabIndex = 0;
            this.grdStockDetailIn4Shift.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvStockDetailIn4Shift});
            // 
            // grdvStockDetailIn4Shift
            // 
            this.grdvStockDetailIn4Shift.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvStockDetailIn4Shift.Appearance.Row.Options.UseFont = true;
            this.grdvStockDetailIn4Shift.GridControl = this.grdStockDetailIn4Shift;
            this.grdvStockDetailIn4Shift.Name = "grdvStockDetailIn4Shift";
            this.grdvStockDetailIn4Shift.OptionsCustomization.AllowGroup = false;
            this.grdvStockDetailIn4Shift.OptionsView.ShowGroupPanel = false;
            // 
            // frmserchstock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 448);
            this.Controls.Add(this.grdStockDetailIn4Shift);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmserchstock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找相似记录";
            ((System.ComponentModel.ISupportInitialize)(this.grdStockDetailIn4Shift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStockDetailIn4Shift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdStockDetailIn4Shift;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvStockDetailIn4Shift;
    }
}