namespace IRAP.Client.GUI.CAS
{
    partial class frmSelectFailureModesByDeviceToCall
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectFailureModesByDeviceToCall));
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.cboEquipmentList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdAndonCallObjects = new DevExpress.XtraGrid.GridControl();
            this.grdvAndonCallObjects = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnChoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repiceChoice = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdclmnEventDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkProductionLineStopped = new DevExpress.XtraEditors.CheckEdit();
            this.btnCall = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEquipmentList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonCallObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonCallObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repiceChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProductionLineStopped.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // imageCollection
            // 
            resources.ApplyResources(this.imageCollection, "imageCollection");
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("paperkind_a4.png", "images/pages/paperkind_a4.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/pages/paperkind_a4.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "paperkind_a4.png");
            this.imageCollection.InsertGalleryImage("apply_32x32.png", "images/actions/apply_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_32x32.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "apply_32x32.png");
            // 
            // gpcAndonEvents
            // 
            resources.ApplyResources(this.gpcAndonEvents, "gpcAndonEvents");
            this.gpcAndonEvents.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("gpcAndonEvents.Appearance.Font")));
            this.gpcAndonEvents.Appearance.Options.UseFont = true;
            this.gpcAndonEvents.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("gpcAndonEvents.AppearanceCaption.Font")));
            this.gpcAndonEvents.AppearanceCaption.Options.UseFont = true;
            this.gpcAndonEvents.Controls.Add(this.cboEquipmentList);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            // 
            // cboEquipmentList
            // 
            resources.ApplyResources(this.cboEquipmentList, "cboEquipmentList");
            this.cboEquipmentList.Name = "cboEquipmentList";
            this.cboEquipmentList.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cboEquipmentList.Properties.Appearance.Font")));
            this.cboEquipmentList.Properties.Appearance.Options.UseFont = true;
            this.cboEquipmentList.Properties.AppearanceDropDown.Font = ((System.Drawing.Font)(resources.GetObject("cboEquipmentList.Properties.AppearanceDropDown.Font")));
            this.cboEquipmentList.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboEquipmentList.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("cboEquipmentList.Properties.AppearanceFocused.Font")));
            this.cboEquipmentList.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboEquipmentList.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("cboEquipmentList.Properties.AppearanceReadOnly.Font")));
            this.cboEquipmentList.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboEquipmentList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboEquipmentList.Properties.Buttons"))))});
            this.cboEquipmentList.Properties.DropDownItemHeight = 30;
            this.cboEquipmentList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboEquipmentList.SelectedIndexChanged += new System.EventHandler(this.cboEquipmentList_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("groupControl1.Appearance.Font")));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("groupControl1.AppearanceCaption.Font")));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdAndonCallObjects);
            this.groupControl1.Name = "groupControl1";
            // 
            // grdAndonCallObjects
            // 
            resources.ApplyResources(this.grdAndonCallObjects, "grdAndonCallObjects");
            this.grdAndonCallObjects.MainView = this.grdvAndonCallObjects;
            this.grdAndonCallObjects.Name = "grdAndonCallObjects";
            this.grdAndonCallObjects.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repiceChoice});
            this.grdAndonCallObjects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvAndonCallObjects});
            // 
            // grdvAndonCallObjects
            // 
            this.grdvAndonCallObjects.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("grdvAndonCallObjects.Appearance.HeaderPanel.Font")));
            this.grdvAndonCallObjects.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvAndonCallObjects.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvAndonCallObjects.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvAndonCallObjects.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvAndonCallObjects.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvAndonCallObjects.Appearance.Row.Font = ((System.Drawing.Font)(resources.GetObject("grdvAndonCallObjects.Appearance.Row.Font")));
            this.grdvAndonCallObjects.Appearance.Row.Options.UseFont = true;
            this.grdvAndonCallObjects.Appearance.Row.Options.UseTextOptions = true;
            this.grdvAndonCallObjects.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvAndonCallObjects.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvAndonCallObjects.ColumnPanelRowHeight = 40;
            this.grdvAndonCallObjects.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnChoice,
            this.grdclmnEventDescription});
            this.grdvAndonCallObjects.GridControl = this.grdAndonCallObjects;
            this.grdvAndonCallObjects.Name = "grdvAndonCallObjects";
            this.grdvAndonCallObjects.OptionsView.ColumnAutoWidth = false;
            this.grdvAndonCallObjects.OptionsView.RowAutoHeight = true;
            this.grdvAndonCallObjects.OptionsView.ShowGroupPanel = false;
            this.grdvAndonCallObjects.RowHeight = 40;
            // 
            // grdclmnChoice
            // 
            this.grdclmnChoice.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("grdclmnChoice.AppearanceCell.Font")));
            this.grdclmnChoice.AppearanceCell.Options.UseFont = true;
            this.grdclmnChoice.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnChoice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnChoice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnChoice.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("grdclmnChoice.AppearanceHeader.Font")));
            this.grdclmnChoice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnChoice.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnChoice, "grdclmnChoice");
            this.grdclmnChoice.ColumnEdit = this.repiceChoice;
            this.grdclmnChoice.FieldName = "Choice";
            this.grdclmnChoice.Name = "grdclmnChoice";
            this.grdclmnChoice.OptionsColumn.AllowMove = false;
            // 
            // repiceChoice
            // 
            this.repiceChoice.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("repiceChoice.Appearance.Font")));
            this.repiceChoice.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.repiceChoice, "repiceChoice");
            this.repiceChoice.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repiceChoice.ImageIndexChecked = 1;
            this.repiceChoice.ImageIndexUnchecked = 0;
            this.repiceChoice.Images = this.imageCollection;
            this.repiceChoice.Name = "repiceChoice";
            // 
            // grdclmnEventDescription
            // 
            this.grdclmnEventDescription.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("grdclmnEventDescription.AppearanceCell.Font")));
            this.grdclmnEventDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEventDescription.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnEventDescription.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("grdclmnEventDescription.AppearanceHeader.Font")));
            this.grdclmnEventDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnEventDescription.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.grdclmnEventDescription, "grdclmnEventDescription");
            this.grdclmnEventDescription.FieldName = "ObjectDesc";
            this.grdclmnEventDescription.Name = "grdclmnEventDescription";
            this.grdclmnEventDescription.OptionsColumn.AllowEdit = false;
            this.grdclmnEventDescription.OptionsColumn.ReadOnly = true;
            // 
            // chkProductionLineStopped
            // 
            resources.ApplyResources(this.chkProductionLineStopped, "chkProductionLineStopped");
            this.chkProductionLineStopped.Name = "chkProductionLineStopped";
            this.chkProductionLineStopped.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("chkProductionLineStopped.Properties.Appearance.Font")));
            this.chkProductionLineStopped.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("chkProductionLineStopped.Properties.Appearance.ForeColor")));
            this.chkProductionLineStopped.Properties.Appearance.Options.UseFont = true;
            this.chkProductionLineStopped.Properties.Appearance.Options.UseForeColor = true;
            this.chkProductionLineStopped.Properties.Appearance.Options.UseTextOptions = true;
            this.chkProductionLineStopped.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.chkProductionLineStopped.Properties.Caption = resources.GetString("chkProductionLineStopped.Properties.Caption");
            // 
            // btnCall
            // 
            resources.ApplyResources(this.btnCall, "btnCall");
            this.btnCall.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnCall.Appearance.Font")));
            this.btnCall.Appearance.Options.UseFont = true;
            this.btnCall.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCall.Name = "btnCall";
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnClose.Appearance.Font")));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Name = "btnClose";
            // 
            // frmSelectFailureModesByDeviceToCall
            // 
            this.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("frmSelectFailureModesByDeviceToCall.Appearance.ForeColor")));
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.CancelButton = this.btnClose;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkProductionLineStopped);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gpcAndonEvents);
            this.Name = "frmSelectFailureModesByDeviceToCall";
            this.Shown += new System.EventHandler(this.frmSelectFailureModesByDeviceToCall_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboEquipmentList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonCallObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonCallObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repiceChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProductionLineStopped.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.XtraEditors.ComboBoxEdit cboEquipmentList;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdAndonCallObjects;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAndonCallObjects;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnChoice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repiceChoice;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEventDescription;
        private DevExpress.XtraEditors.CheckEdit chkProductionLineStopped;
        private DevExpress.XtraEditors.SimpleButton btnCall;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
