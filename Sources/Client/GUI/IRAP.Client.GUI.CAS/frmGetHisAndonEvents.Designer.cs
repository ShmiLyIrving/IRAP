namespace IRAP.Client.GUI.CAS
{
    partial class frmGetHisAndonEvents
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
            this.btnGetAndonEvents = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lnklblNext = new System.Windows.Forms.LinkLabel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lnklblPrev = new System.Windows.Forms.LinkLabel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPeriodTypes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.edtEndDT = new System.Windows.Forms.DateTimePicker();
            this.cboAndonEventTypes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.edtBeginDT = new System.Windows.Forms.DateTimePicker();
            this.grdAndonEvents = new DevExpress.XtraGrid.GridControl();
            this.grdvAndonEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdlcmnEventName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnEventDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grdclmnCallUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRespondUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCallingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRespondingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnClosingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnCancelTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAndonEventTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(962, 56);
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(962, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // btnGetAndonEvents
            // 
            this.btnGetAndonEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetAndonEvents.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetAndonEvents.Appearance.Options.UseFont = true;
            this.btnGetAndonEvents.Location = new System.Drawing.Point(13, 6);
            this.btnGetAndonEvents.Name = "btnGetAndonEvents";
            this.btnGetAndonEvents.Size = new System.Drawing.Size(79, 32);
            this.btnGetAndonEvents.TabIndex = 2;
            this.btnGetAndonEvents.Text = "查询";
            this.btnGetAndonEvents.Click += new System.EventHandler(this.btnGetAndonEvents_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.AppearanceCaption.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.lnklblNext);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.lnklblPrev);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.label1);
            this.splitContainerControl1.Panel1.Controls.Add(this.cboPeriodTypes);
            this.splitContainerControl1.Panel1.Controls.Add(this.edtEndDT);
            this.splitContainerControl1.Panel1.Controls.Add(this.cboAndonEventTypes);
            this.splitContainerControl1.Panel1.Controls.Add(this.edtBeginDT);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "查询条件";
            this.splitContainerControl1.Panel2.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel2.Controls.Add(this.grdAndonEvents);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel2.ShowCaption = true;
            this.splitContainerControl1.Panel2.Text = "查询到的安灯事件列表";
            this.splitContainerControl1.Size = new System.Drawing.Size(853, 457);
            this.splitContainerControl1.SplitterPosition = 102;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl3.Location = new System.Drawing.Point(222, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 20);
            this.labelControl3.TabIndex = 30;
            this.labelControl3.Text = "时间段：";
            // 
            // lnklblNext
            // 
            this.lnklblNext.AutoSize = true;
            this.lnklblNext.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lnklblNext.Location = new System.Drawing.Point(690, 12);
            this.lnklblNext.Name = "lnklblNext";
            this.lnklblNext.Size = new System.Drawing.Size(29, 20);
            this.lnklblNext.TabIndex = 29;
            this.lnklblNext.TabStop = true;
            this.lnklblNext.Text = ">>";
            this.lnklblNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblNext_LinkClicked);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl1.Location = new System.Drawing.Point(51, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 20);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "期间类型：";
            // 
            // lnklblPrev
            // 
            this.lnklblPrev.AutoSize = true;
            this.lnklblPrev.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lnklblPrev.Location = new System.Drawing.Point(284, 12);
            this.lnklblPrev.Name = "lnklblPrev";
            this.lnklblPrev.Size = new System.Drawing.Size(29, 20);
            this.lnklblPrev.TabIndex = 28;
            this.lnklblPrev.TabStop = true;
            this.lnklblPrev.Text = "<<";
            this.lnklblPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblPrev_LinkClicked);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl2.Location = new System.Drawing.Point(23, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(98, 20);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "安灯事件类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.label1.Location = new System.Drawing.Point(492, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "―";
            // 
            // cboPeriodTypes
            // 
            this.cboPeriodTypes.Location = new System.Drawing.Point(127, 9);
            this.cboPeriodTypes.Name = "cboPeriodTypes";
            this.cboPeriodTypes.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboPeriodTypes.Properties.Appearance.Options.UseFont = true;
            this.cboPeriodTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPeriodTypes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPeriodTypes.Size = new System.Drawing.Size(80, 26);
            this.cboPeriodTypes.TabIndex = 18;
            this.cboPeriodTypes.SelectedIndexChanged += new System.EventHandler(this.cboPeriodTypes_SelectedIndexChanged);
            // 
            // edtEndDT
            // 
            this.edtEndDT.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.edtEndDT.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtEndDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtEndDT.Location = new System.Drawing.Point(513, 9);
            this.edtEndDT.Name = "edtEndDT";
            this.edtEndDT.Size = new System.Drawing.Size(171, 26);
            this.edtEndDT.TabIndex = 26;
            this.edtEndDT.Value = new System.DateTime(2016, 11, 22, 0, 0, 0, 0);
            // 
            // cboAndonEventTypes
            // 
            this.cboAndonEventTypes.Location = new System.Drawing.Point(127, 41);
            this.cboAndonEventTypes.Name = "cboAndonEventTypes";
            this.cboAndonEventTypes.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboAndonEventTypes.Properties.Appearance.Options.UseFont = true;
            this.cboAndonEventTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAndonEventTypes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAndonEventTypes.Size = new System.Drawing.Size(202, 26);
            this.cboAndonEventTypes.TabIndex = 19;
            // 
            // edtBeginDT
            // 
            this.edtBeginDT.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.edtBeginDT.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtBeginDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.edtBeginDT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.edtBeginDT.Location = new System.Drawing.Point(315, 9);
            this.edtBeginDT.Name = "edtBeginDT";
            this.edtBeginDT.Size = new System.Drawing.Size(171, 26);
            this.edtBeginDT.TabIndex = 25;
            this.edtBeginDT.Value = new System.DateTime(2016, 11, 22, 0, 0, 0, 0);
            // 
            // grdAndonEvents
            // 
            this.grdAndonEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAndonEvents.Location = new System.Drawing.Point(5, 5);
            this.grdAndonEvents.MainView = this.grdvAndonEvents;
            this.grdAndonEvents.Name = "grdAndonEvents";
            this.grdAndonEvents.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdAndonEvents.Size = new System.Drawing.Size(839, 311);
            this.grdAndonEvents.TabIndex = 0;
            this.grdAndonEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvAndonEvents});
            // 
            // grdvAndonEvents
            // 
            this.grdvAndonEvents.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvAndonEvents.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvAndonEvents.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvAndonEvents.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvAndonEvents.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvAndonEvents.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvAndonEvents.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvAndonEvents.Appearance.Row.Options.UseFont = true;
            this.grdvAndonEvents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdlcmnEventName,
            this.grdclmnEventDescription,
            this.grdclmnCallUserName,
            this.grdclmnRespondUserName,
            this.grdclmnCallingTime,
            this.grdclmnRespondingTime,
            this.grdclmnClosingTime,
            this.grdclmnCancelTime});
            this.grdvAndonEvents.GridControl = this.grdAndonEvents;
            this.grdvAndonEvents.Name = "grdvAndonEvents";
            this.grdvAndonEvents.OptionsBehavior.Editable = false;
            this.grdvAndonEvents.OptionsView.ColumnAutoWidth = false;
            this.grdvAndonEvents.OptionsView.RowAutoHeight = true;
            this.grdvAndonEvents.OptionsView.ShowGroupPanel = false;
            // 
            // grdlcmnEventName
            // 
            this.grdlcmnEventName.AppearanceCell.Options.UseTextOptions = true;
            this.grdlcmnEventName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdlcmnEventName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdlcmnEventName.Caption = "事件类型";
            this.grdlcmnEventName.FieldName = "EventName";
            this.grdlcmnEventName.MaxWidth = 80;
            this.grdlcmnEventName.MinWidth = 80;
            this.grdlcmnEventName.Name = "grdlcmnEventName";
            this.grdlcmnEventName.Visible = true;
            this.grdlcmnEventName.VisibleIndex = 0;
            this.grdlcmnEventName.Width = 80;
            // 
            // grdclmnEventDescription
            // 
            this.grdclmnEventDescription.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnEventDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEventDescription.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnEventDescription.Caption = "事件描述";
            this.grdclmnEventDescription.ColumnEdit = this.repositoryItemMemoEdit1;
            this.grdclmnEventDescription.FieldName = "EventDescription";
            this.grdclmnEventDescription.Name = "grdclmnEventDescription";
            this.grdclmnEventDescription.Visible = true;
            this.grdclmnEventDescription.VisibleIndex = 1;
            this.grdclmnEventDescription.Width = 20;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // grdclmnCallUserName
            // 
            this.grdclmnCallUserName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnCallUserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCallUserName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnCallUserName.Caption = "呼叫人";
            this.grdclmnCallUserName.FieldName = "CallUserName";
            this.grdclmnCallUserName.MaxWidth = 100;
            this.grdclmnCallUserName.MinWidth = 100;
            this.grdclmnCallUserName.Name = "grdclmnCallUserName";
            this.grdclmnCallUserName.Visible = true;
            this.grdclmnCallUserName.VisibleIndex = 3;
            this.grdclmnCallUserName.Width = 100;
            // 
            // grdclmnRespondUserName
            // 
            this.grdclmnRespondUserName.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnRespondUserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRespondUserName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRespondUserName.Caption = "责任响应人";
            this.grdclmnRespondUserName.FieldName = "RespondUserName";
            this.grdclmnRespondUserName.MaxWidth = 100;
            this.grdclmnRespondUserName.MinWidth = 100;
            this.grdclmnRespondUserName.Name = "grdclmnRespondUserName";
            this.grdclmnRespondUserName.Visible = true;
            this.grdclmnRespondUserName.VisibleIndex = 5;
            this.grdclmnRespondUserName.Width = 100;
            // 
            // grdclmnCallingTime
            // 
            this.grdclmnCallingTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnCallingTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCallingTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnCallingTime.Caption = "呼叫时间";
            this.grdclmnCallingTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.grdclmnCallingTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnCallingTime.FieldName = "CallingTime";
            this.grdclmnCallingTime.MaxWidth = 160;
            this.grdclmnCallingTime.MinWidth = 160;
            this.grdclmnCallingTime.Name = "grdclmnCallingTime";
            this.grdclmnCallingTime.Visible = true;
            this.grdclmnCallingTime.VisibleIndex = 2;
            this.grdclmnCallingTime.Width = 160;
            // 
            // grdclmnRespondingTime
            // 
            this.grdclmnRespondingTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnRespondingTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRespondingTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRespondingTime.Caption = "响应时间";
            this.grdclmnRespondingTime.FieldName = "RespondingTime";
            this.grdclmnRespondingTime.MaxWidth = 160;
            this.grdclmnRespondingTime.MinWidth = 160;
            this.grdclmnRespondingTime.Name = "grdclmnRespondingTime";
            this.grdclmnRespondingTime.Visible = true;
            this.grdclmnRespondingTime.VisibleIndex = 4;
            this.grdclmnRespondingTime.Width = 160;
            // 
            // grdclmnClosingTime
            // 
            this.grdclmnClosingTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnClosingTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnClosingTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnClosingTime.Caption = "关闭时间";
            this.grdclmnClosingTime.FieldName = "EventClosingTime";
            this.grdclmnClosingTime.MaxWidth = 160;
            this.grdclmnClosingTime.MinWidth = 160;
            this.grdclmnClosingTime.Name = "grdclmnClosingTime";
            this.grdclmnClosingTime.Visible = true;
            this.grdclmnClosingTime.VisibleIndex = 6;
            this.grdclmnClosingTime.Width = 160;
            // 
            // grdclmnCancelTime
            // 
            this.grdclmnCancelTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnCancelTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnCancelTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnCancelTime.Caption = "撤销时间";
            this.grdclmnCancelTime.FieldName = "EventCancelTime";
            this.grdclmnCancelTime.MaxWidth = 160;
            this.grdclmnCancelTime.MinWidth = 160;
            this.grdclmnCancelTime.Name = "grdclmnCancelTime";
            this.grdclmnCancelTime.Visible = true;
            this.grdclmnCancelTime.VisibleIndex = 7;
            this.grdclmnCancelTime.Width = 160;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2.IsSplitterFixed = true;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.splitContainerControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.btnGetAndonEvents);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(962, 457);
            this.splitContainerControl2.SplitterPosition = 104;
            this.splitContainerControl2.TabIndex = 5;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // frmGetHisAndonEvents
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(962, 513);
            this.Controls.Add(this.splitContainerControl2);
            this.Name = "frmGetHisAndonEvents";
            this.Activated += new System.EventHandler(this.frmGetHisAndonEvents_Activated);
            this.Shown += new System.EventHandler(this.frmGetHisAndonEvents_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAndonEventTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvAndonEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnGetAndonEvents;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.LinkLabel lnklblNext;
        private System.Windows.Forms.LinkLabel lnklblPrev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker edtEndDT;
        private System.Windows.Forms.DateTimePicker edtBeginDT;
        private DevExpress.XtraEditors.ComboBoxEdit cboAndonEventTypes;
        private DevExpress.XtraEditors.ComboBoxEdit cboPeriodTypes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdAndonEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvAndonEvents;
        private DevExpress.XtraGrid.Columns.GridColumn grdlcmnEventName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEventDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCallUserName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRespondUserName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCallingTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRespondingTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnClosingTime;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnCancelTime;
    }
}
