using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

using DevExpress.XtraEditors;
using DevExpress.Utils;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;
using IRAP.Client.GUI.MESPDC.Actions;
using IRAP.Entity.SSO;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmUDFForm1Ex : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private MenuInfo menuInfo = null;
        private UDFForm1Ex busUDFForm = new UDFForm1Ex();
        private TextEdit firstFocusedObject = null;
        private List<FormCtrlInfo> controls = new List<FormCtrlInfo>();
        private List<LabelControl> _labels = new List<LabelControl>();
        private List<TextEdit> _edits = new List<TextEdit>();
        private List<SimpleButton> _buttons = new List<SimpleButton>();
        private SimpleButton mustAllInputButton = null;
        private SimpleButton reprintLabelButton = null;

        private string message = "";
        private string caption = "";

        private const int WS_SHOWNORMAL = 1;
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public frmUDFForm1Ex()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";
        }

        #region 运行时创建控件
        private LabelControl CreateLabel(FormCtrlInfo ctrlInfo)
        {
            LabelControl rlt = new LabelControl();

            rlt.Name = ctrlInfo.ToString();
            //rlt.Parent = pnlBody;
            rlt.AutoSizeMode = LabelAutoSizeMode.None;
            rlt.Location = new Point(ctrlInfo.CtrlLeft, ctrlInfo.CtrlTop);
            rlt.Size = new Size(ctrlInfo.CtrlWidth, ctrlInfo.CtrlHeight);
            rlt.Text = ctrlInfo.Caption;
            switch (ctrlInfo.Alignment.ToUpper())
            {
                case "LEFT":
                    rlt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    break;
                case "RIGHT":
                    rlt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                default:
                    rlt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    break;
            }
            rlt.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            rlt.Appearance.Font = new Font(ctrlInfo.FontName, ctrlInfo.FontSizeFloat);
            rlt.Appearance.ForeColor = Color.FromArgb(ctrlInfo.FontColor);

            rlt.ToolTip = ctrlInfo.Hint;
            rlt.ToolTipController = this.toolTipController;
            rlt.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            {
                rlt.ToolTipTitle = "Tip";
            }
            else
            {
                rlt.ToolTipTitle = "提示信息";
            }

            rlt.Enabled = ctrlInfo.Enabled;
            rlt.Visible = ctrlInfo.Visible;
            rlt.Appearance.TextOptions.WordWrap = ctrlInfo.WordWrap ? WordWrap.Wrap : WordWrap.NoWrap;

            rlt.Tag = ctrlInfo;

            pnlBody.Controls.Add(rlt);
            return rlt;
        }

        private TextEdit CreateEdit(FormCtrlInfo ctrlInfo)
        {
            TextEdit rlt = new TextEdit();

            rlt.Name = ctrlInfo.ToString();
            //rlt.Parent = this.pnlBody;
            rlt.Location = new Point(ctrlInfo.CtrlLeft, ctrlInfo.CtrlTop);
            rlt.Size = new Size(ctrlInfo.CtrlWidth, ctrlInfo.CtrlHeight);

            switch (ctrlInfo.Alignment.ToUpper())
            {
                case "LEFT":
                    rlt.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case "RIGHT":
                    rlt.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                default:
                    rlt.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
            }
            rlt.Properties.Appearance.TextOptions.VAlignment = VertAlignment.Default;

            rlt.Font = new Font(ctrlInfo.FontName, ctrlInfo.FontSizeFloat);
            rlt.Properties.Appearance.ForeColor = Color.FromArgb(ctrlInfo.FontColor);
            rlt.TabIndex = ctrlInfo.TabOrder;

            rlt.ToolTip = ctrlInfo.Hint;
            rlt.ToolTipController = this.toolTipController;
            rlt.ToolTipIconType = ToolTipIconType.Information;
            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            {
                rlt.ToolTipTitle = "Tip";
            }
            else
            {
                rlt.ToolTipTitle = "提示信息";
            }

            rlt.ImeMode = ImeMode.Disable;
            rlt.Enabled = ctrlInfo.Enabled;
            rlt.Visible = ctrlInfo.Visible;
            rlt.EnterMoveNextControl = true;

            rlt.Text = ctrlInfo.DefaultValueStr;

            // 如果当前站点是平板电脑，则自动打开软键盘
            WriteLog.Instance.Write("设置是否自动打开软键盘");
            if (IRAPUser.Instance.HostName.Substring(0, 2) == "04")
            {
                rlt.Enter += new EventHandler(TextEditGotFocus);
            }
            rlt.TextChanged += new EventHandler(TextEditTextChanged);
            rlt.KeyDown += new KeyEventHandler(TextEditKeyDown);
            rlt.Leave += new EventHandler(TextEditLeave);
            if (ctrlInfo.CheckRequired)
            {
                rlt.Validating += new CancelEventHandler(TextEditValidating);
            }

            rlt.Tag = ctrlInfo;

            pnlBody.Controls.Add(rlt);
            return rlt;
        }

        private TextEdit CreateSecurityEdit(FormCtrlInfo ctrlInfo)
        {
            TextEdit rlt = CreateEdit(ctrlInfo);
            rlt.Properties.PasswordChar = '*';
            return rlt;
        }

        private SimpleButton CreateButton(FormCtrlInfo ctrlInfo)
        {
            SimpleButton rlt = new SimpleButton();

            rlt.Name = ctrlInfo.ToString();
            //rlt.Parent = this.pnlBody;

            rlt.Location = new Point(ctrlInfo.CtrlLeft, ctrlInfo.CtrlTop);
            rlt.Size = new Size(ctrlInfo.CtrlWidth, ctrlInfo.CtrlHeight);

            rlt.Text = ctrlInfo.Caption;

            rlt.Font = new Font(ctrlInfo.FontName, ctrlInfo.FontSizeFloat);
            rlt.Appearance.ForeColor = Color.FromArgb(ctrlInfo.FontColor);

            rlt.TabIndex = ctrlInfo.TabOrder;

            rlt.ToolTip = ctrlInfo.Hint;
            rlt.ToolTipController = this.toolTipController;
            rlt.ToolTipIconType = ToolTipIconType.Information;
            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            {
                rlt.ToolTipTitle = "Tip";
            }
            else
            {
                rlt.ToolTipTitle = "提示信息";
            }

            rlt.Enabled = ctrlInfo.Enabled;
            rlt.Visible = ctrlInfo.Visible;

            rlt.Tag = ctrlInfo;

            pnlBody.Controls.Add(rlt);
            return rlt;
        }
        #endregion

        #region 自定义事件
        private void TextEditGotFocus(object sender, EventArgs e)
        {
            #region 如果当前站点是 Pad 则自动打开操作系统自带的软键盘
            if (IRAPUser.Instance.HostName.Substring(0, 2) == "04")
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process p in processes)
                {
                    try
                    {
                        if (p.ProcessName.ToLower() == "osk")
                        {
                            return;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                using (Command cmd = new Command())
                {
                    cmd.RunCmd(@"C:\Windows\System32\OSK.exe");
                }

                {
                    SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);

                    // 将焦点移回当前程序，并且是最大化
                    ShowWindowAsync(
                        Process.GetCurrentProcess().MainWindowHandle,
                        3);
                }
            }
            #endregion
        }

        private void TextEditKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is TextEdit)
                {
                    TextEdit edit = sender as TextEdit;
                    FormCtrlInfo ctrl = edit.Tag as FormCtrlInfo;

                    busUDFForm.ClearOutputStr();

                    if (edit.Text.Trim() != "")
                    {
                        int idxEdit = _edits.IndexOf(edit);
                        busUDFForm.SetStrParameterValue(edit.Text.Trim(), idxEdit + 1);

                        if (IsNoEmptyInput())
                        {
                            mustAllInputButton.PerformClick();
                        }
                        else
                        {
                            SelectNextControl(edit, false, false, false, true);
                        }
                    }
                }
            }
        }

        private void TextEditLeave(object sender, EventArgs e)
        {
            //busUDFForm.ClearOutputStr();
            //RefreshTheButtonControl();

            //TextEdit edit = sender as TextEdit;

            //if (edit.Text.Trim() != "")
            //{
            //    if (_edits.IndexOf(edit) == _edits.Count - 1)
            //    {
            //        if (_buttons.Count == 1)
            //        {
            //            mustAllInputButton.PerformClick();
            //            _edits[0].Focus();
            //        }
            //        else
            //            mustAllInputButton.Focus();
            //    }
            //}
        }
        #endregion

        #region 自定义函数
        private bool IsNoEmptyInput()
        {
            foreach (TextEdit edit in _edits)
            {
                if (edit.Visible && edit.Enabled && edit.Text == "")
                {
                    return false;

                }
            }
            return true;
        }

        private void CreateDynamicControls()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                try
                {

                    IRAPMDMClient.Instance.sfn_FunctionFormCtrls(
                        IRAPUser.Instance.CommunityID,
                        menuInfo.ItemID,
                        IRAPConst.Instance.IRAP_PROGLANGUAGEID,
                        IRAPUser.Instance.SysLogID,
                        ref controls,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}",
                            errCode, errText),
                        strProcedureName);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message);
                    XtraMessageBox.Show(
                        error.Message,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                int intLogTop = 0;
                foreach (FormCtrlInfo control in controls)
                {
                    BaseControl objControl = null;
                    WriteLog.Instance.Write(
                        string.Format("创建控件：{0}", control.ToString()),
                        strProcedureName);
                    switch (control.CtrlType.ToUpper())
                    {
                        case "LABEL":
                            objControl = CreateLabel(control);
                            _labels.Add(objControl as LabelControl);
                            break;
                        case "EDITBOX":
                            objControl = CreateEdit(control);
                            if (firstFocusedObject == null && (objControl as TextEdit).Visible && (objControl as TextEdit).Enabled)
                            {
                                WriteLog.Instance.Write("设置获得焦点的第一个文本编辑控件", strProcedureName);
                                firstFocusedObject = objControl as TextEdit;
                            }
                            _edits.Add(objControl as TextEdit);
                            break;
                        case "SECURITYEDIT":
                            objControl = CreateSecurityEdit(control);
                            if (firstFocusedObject == null && (objControl as TextEdit).Visible && (objControl as TextEdit).Enabled)
                            {
                                WriteLog.Instance.Write("设置获得焦点的第一个安全文本编辑控件", strProcedureName);
                                firstFocusedObject = objControl as TextEdit;
                            }
                            _edits.Add(objControl as TextEdit);
                            break;
                        case "BUTTON":
                            objControl = CreateButton(control);
                            _buttons.Add(objControl as SimpleButton);

                            if (mustAllInputButton == null)
                            {
                                mustAllInputButton = objControl as SimpleButton;
                                // 强制设置第一个按钮的功能为 ButtonSaveDataClick
                                mustAllInputButton.Click += new EventHandler(this.ButtonSaveDataClick);

                                busUDFForm.NumTransToApply = control.NumTransToApply;
                                busUDFForm.NumFactsToApply = control.NumFactsToApply;
                            }

                            break;
                        case "BACKGROUND":
                            break;
                    }

                    if (objControl.Visible)
                    {
                        if (intLogTop <= objControl.Top + objControl.Height)
                        {
                            intLogTop = objControl.Top + objControl.Height;
                        }
                    }
                }

                if (_buttons.Count >= 2)
                {
                    reprintLabelButton = _buttons[1];
                    // 强制设置第二个按钮的功能为 ReprintLabel 
                    reprintLabelButton.Click += this.ButtonReprintClick;
                }

                // 为第三个及以后的按钮订阅单击事件
                for (int i = 2; i < _buttons.Count; i++)
                {
                    if ((_buttons[i].Tag as FormCtrlInfo).RunFormClassName.Trim() == "")
                    {
                        _buttons[i].Click += new EventHandler(this.ButtonSaveDataClick);
                    }
                    else
                    {
                        _buttons[i].Click += new EventHandler(this.ButtonOpenFormClick);
                    }
                }

                // 设置日志的位置和大小
                xucIRAPListView.Top = intLogTop + xucIRAPListView.Left;
                xucIRAPListView.Width = pnlBody.Width - xucIRAPListView.Left * 2;
                xucIRAPListView.Height = pnlBody.Height - xucIRAPListView.Top - xucIRAPListView.Left;
                xucIRAPListView.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
                xucIRAPListView.TabIndex = controls.Count + 1;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private LabelControl FindLabelWithTagOrdinal(int ordinal)
        {
            foreach (LabelControl label in _labels)
            {
                if ((label.Tag as FormCtrlInfo).Ordinal == ordinal)
                    return label;
            }
            return null;
        }

        private TextEdit FindTextEditWithTagOrdinal(int ordinal)
        {
            foreach (TextEdit edit in _edits)
            {
                if ((edit.Tag as FormCtrlInfo).Ordinal == ordinal)
                {
                    return edit;
                }
            }
            return null;
        }

        private SimpleButton FindButtonWithTagOrdinal(int ordinal)
        {
            foreach (SimpleButton button in _buttons)
            {
                if ((button.Tag as FormCtrlInfo).Ordinal == ordinal)
                {
                    return button;
                }
            }
            return null;
        }

        private void RefreshLabel(LabelControl label, FormCtrlInfo ctrl)
        {
            label.Location = new Point(ctrl.CtrlLeft, ctrl.CtrlTop);
            label.Size = new Size(ctrl.CtrlWidth, ctrl.CtrlHeight);
            label.Text = ctrl.Caption;
            switch (ctrl.Alignment.ToUpper())
            {
                case "LEFT":
                    label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    break;
                case "RIGHT":
                    label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                default:
                    label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    break;
            }
            label.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            label.Appearance.Font = new Font(ctrl.FontName, ctrl.FontSizeFloat);
            label.Appearance.ForeColor = Color.FromArgb(ctrl.FontColor);

            label.ToolTip = ctrl.Hint;
            label.ToolTipController = this.toolTipController;
            label.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            {
                label.ToolTipTitle = "Tip";
            }
            else
            {
                label.ToolTipTitle = "提示信息";
            }

            label.Enabled = ctrl.Enabled;
            label.Visible = ctrl.Visible;
            label.Appearance.TextOptions.WordWrap = ctrl.WordWrap ? WordWrap.Wrap : WordWrap.NoWrap;

            label.Tag = ctrl;
        }

        private void RefreshTextEdit(TextEdit edit, FormCtrlInfo ctrl)
        {
            edit.Location = new Point(ctrl.CtrlLeft, ctrl.CtrlTop);
            edit.Size = new Size(ctrl.CtrlWidth, ctrl.CtrlHeight);

            switch (ctrl.Alignment.ToUpper())
            {
                case "LEFT":
                    edit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
                case "RIGHT":
                    edit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                default:
                    edit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
            }
            edit.Properties.Appearance.TextOptions.VAlignment = VertAlignment.Default;

            edit.Font = new Font(ctrl.FontName, ctrl.FontSizeFloat);
            edit.Properties.Appearance.ForeColor = Color.FromArgb(ctrl.FontColor);
            edit.TabIndex = ctrl.TabOrder;

            edit.ToolTip = ctrl.Hint;
            edit.ToolTipController = this.toolTipController;
            edit.ToolTipIconType = ToolTipIconType.Information;
            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            {
                edit.ToolTipTitle = "Tip";
            }
            else
            {
                edit.ToolTipTitle = "提示信息";
            }

            edit.ImeMode = ImeMode.Disable;
            edit.Enabled = ctrl.Enabled;
            edit.Visible = ctrl.Visible;
            edit.EnterMoveNextControl = true;

            edit.Text = ctrl.DefaultValueStr;

            edit.Tag = ctrl;
        }

        private void RefreshButton(SimpleButton button, FormCtrlInfo ctrl)
        {
            button.Location = new Point(ctrl.CtrlLeft, ctrl.CtrlTop);
            button.Size = new Size(ctrl.CtrlWidth, ctrl.CtrlHeight);

            button.Text = ctrl.Caption;

            button.Font = new Font(ctrl.FontName, ctrl.FontSizeFloat);
            button.Appearance.ForeColor = Color.FromArgb(ctrl.FontColor);

            button.TabIndex = ctrl.TabOrder;

            button.ToolTip = ctrl.Hint;
            button.ToolTipController = this.toolTipController;
            button.ToolTipIconType = ToolTipIconType.Information;
            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            {
                button.ToolTipTitle = "Tip";
            }
            else
            {
                button.ToolTipTitle = "提示信息";
            }

            button.Enabled = ctrl.Enabled;
            button.Visible = ctrl.Visible;

            button.Tag = ctrl;
        }

        private void RefreshForm()
        {
            if (menuInfo == null)
                return;

            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<FormCtrlInfo> ctrls = new List<FormCtrlInfo>();

                IRAPMDMClient.Instance.sfn_FunctionFormCtrls(
                    IRAPUser.Instance.CommunityID,
                    menuInfo.ItemID,
                    IRAPConst.Instance.IRAP_PROGLANGUAGEID,
                    IRAPUser.Instance.SysLogID,
                    ref ctrls,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (FormCtrlInfo ctrl in ctrls)
                    {
                        switch (ctrl.CtrlType)
                        {
                            case "Label":
                                LabelControl label = FindLabelWithTagOrdinal(ctrl.Ordinal);
                                if (label != null)
                                {
                                    RefreshLabel(label, ctrl);
                                }
                                break;
                            case "EditBox":
                                TextEdit edit = FindTextEditWithTagOrdinal(ctrl.Ordinal);
                                if (edit != null)
                                {
                                    RefreshTextEdit(edit, ctrl);
                                }
                                break;
                            case "Button":
                                SimpleButton button = FindButtonWithTagOrdinal(ctrl.Ordinal);
                                if (button != null)
                                {
                                    RefreshButton(button, ctrl);
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void ButtonSaveDataClick(object sender, EventArgs e)
        {
            if (sender is SimpleButton)
            {
                string strProcedureName = 
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                (sender as SimpleButton).Enabled = false;

                foreach (TextEdit edit in _edits)
                {
                    if (edit.Enabled)
                        edit.Enabled = false;
                }

                try
                {
                    for (int i = 0; i < _edits.Count; i++)
                    {
                        if (_edits[i].Text.Trim() == "" 
                            && _edits[i].Visible 
                            && _edits[i].Enabled)
                        //    busUDFForm.SetStrParameterValue(_edits[i].Text.Trim(), i + 1);
                        //else
                        {
                            _edits[i].Focus();
                            return;
                        }
                        else
                        {
                            busUDFForm.SetStrParameterValue(_edits[i].Text.Trim(), i + 1);
                        }
                    }

                    try
                    {
                        object tag = null;

                        busUDFForm.SaveOLTPUDFFormData(
                            CurrentOptions.Instance.OptionTwo.T102LeafID,
                            CurrentOptions.Instance.OptionOne.T107LeafID,
                            new ExtendEventHandler(RefreshForm),
                            ref tag);
                        WriteLog.Instance.Write(
                            string.Format(
                                "{0}.{1}",
                                busUDFForm.ErrorCode,
                                busUDFForm.ErrorMessage),
                            strProcedureName);
                        xucIRAPListView.WriteLog(
                            busUDFForm.ErrorCode,
                            busUDFForm.ErrorMessage,
                            DateTime.Now);

                        WriteLog.Instance.Write(
                            string.Format("Output={0}", busUDFForm.OutputStr),
                            strProcedureName);
                        if (busUDFForm.OutputStr != "")
                        {
                            try
                            {
                                UDFActions.DoActions(
                                    busUDFForm.OutputStr,
                                    new ExtendEventHandler(RefreshForm),
                                    ref tag);
                            }
                            catch (Exception error)
                            {
                                WriteLog.Instance.Write(
                                    string.Format("错误信息:{0}。跟踪堆栈:{1}。",
                                        error.Message,
                                        error.StackTrace),
                                    strProcedureName);
                                xucIRAPListView.WriteLog(-1, error.Message, DateTime.Now);
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        xucIRAPListView.WriteLog(-1, error.Message, DateTime.Now);
                    }
                }
                finally
                {
                    ClearTheInputs();

                    (sender as SimpleButton).Enabled = true;
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void ButtonOpenFormClick(object sender, EventArgs e)
        {
            if (sender is SimpleButton)
            {
                string strProcedureName = string.Format("{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

                (sender as SimpleButton).Enabled = false;
                try
                {
                    string classFileName = string.Format(@"{1}\IRAP.Client.GUI.{0}.dll",
                            ((FormCtrlInfo)(sender as SimpleButton).Tag).RunFormAtLibraryName,
                            Application.StartupPath);

                    if (!File.Exists(classFileName))
                    {
                        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                            message =
                                string.Format(
                                    "Class library file: {0} does not exist！",
                                    classFileName);
                        else
                            message =
                                string.Format(
                                    "类库文件：{0} 不存在！",
                                    classFileName);
                        IRAPMessageBox.Instance.ShowErrorMessage(
                            message,
                            caption);
                        return;
                    }

                    Assembly asm = Assembly.LoadFile(classFileName);
                    if (asm == null)
                    {
                        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                            message =
                                string.Format(
                                    "Unable to load IRAP.Client.GUI.{0}.dll",
                                    ((FormCtrlInfo)(sender as SimpleButton).Tag).RunFormAtLibraryName);
                        else
                            message =
                                string.Format(
                                    "无法加载：IRAP.Client.GUI.{0}",
                                    ((FormCtrlInfo)(sender as SimpleButton).Tag).RunFormAtLibraryName);

                        IRAPMessageBox.Instance.ShowErrorMessage(
                            message,
                            caption);

                        return;
                    }

                    frmCustomBase childForm = null;
                    try
                    {
                        object obj = Activator.CreateInstance(
                            asm.GetType(string.Format("IRAP.Client.GUI.{0}.{1}",
                                ((FormCtrlInfo)(sender as SimpleButton).Tag).RunFormAtLibraryName,
                                ((FormCtrlInfo)(sender as SimpleButton).Tag).RunFormClassName)));


                        childForm = obj as IRAP.Client.Global.frmCustomBase;
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);

                        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                            message = "IRAP.Client.GUI.{0}.{1} is under construction...";
                        else
                            message = "IRAP.Client.GUI.{0}.{1}正在建设中......";

                        MessageBox.Show(string.Format(message,
                                ((FormCtrlInfo)(sender as SimpleButton).Tag).RunFormAtLibraryName,
                                ((FormCtrlInfo)(sender as SimpleButton).Tag).RunFormClassName),
                            caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                        return;
                    }

                    childForm.ShowDialog();
                }
                finally
                {
                    (sender as SimpleButton).Enabled = true;
                }

                RefreshTheButtonControl();
            }
        }

        private void TextEditValidating(object sender, CancelEventArgs e)
        {
            if (sender is TextEdit)
            {
                TextEdit edtOrigin = sender as TextEdit;

                if (edtOrigin.Text.Trim() != "")
                {
                    try
                    {
                        int errCode = 0;
                        string errorMessage = "";

                        if (IRAPUTSClient.Instance.ufn_OLTP_StringValid(
                                menuInfo.Parameters,
                                CurrentOptions.Instance.OptionTwo.T120LeafID,
                                CurrentOptions.Instance.OptionOne.T107LeafID,
                                edtOrigin.Text.Trim(),
                                menuInfo.OpNode,
                                menuInfo.Parameters,
                                edtOrigin.TabIndex,
                                IRAPUser.Instance.SysLogID,
                                out errCode,
                                out errorMessage))
                        {
                            e.Cancel = false;
                        }
                        else
                        {
                            XtraMessageBox.Show(
                                errorMessage,
                                Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            edtOrigin.Text = "";
                            e.Cancel = true;
                        }
                    }
                    catch (Exception error)
                    {
                        XtraMessageBox.Show(
                            error.Message,
                            Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        edtOrigin.Text = "";
                        e.Cancel = true;
                    }
                    finally
                    {
                        RefreshTheButtonControl();
                    }
                }
            }

            if (mustAllInputButton.Enabled)
            {
                if (_buttons.Count == 1 || _buttons.Count == 2)
                {
                    // 如果 mustAllInputButton 是可用的，则直接执行该按钮的点击事件，
                    // 而不再将焦点设置到该按钮上。
                    mustAllInputButton.PerformClick();
                }
                else
                    mustAllInputButton.Focus();
            }
        }

        private void TextEditTextChanged(object sender, EventArgs e)
        {
            //RefreshTheButtonControl();
        }

        private void RefreshTheButtonControl()
        {
            if (mustAllInputButton != null)
            {
                mustAllInputButton.Enabled = true;
                foreach (TextEdit edit in _edits)
                {
                    if (edit.Visible && edit.Enabled)
                    {
                        mustAllInputButton.Enabled = mustAllInputButton.Enabled && (edit.Text.Trim() != "");
                    }
                }

                if (reprintLabelButton != null)
                {
                    reprintLabelButton.Enabled = busUDFForm.OutputStr != "";
                }

                if (mustAllInputButton.Enabled)
                {
                    Application.DoEvents();
                    Thread.Sleep(200);
                }
            }
        }

        private void ButtonReprintClick(object sender, EventArgs e)
        {
            if (sender is SimpleButton)
            {
                SimpleButton button = sender as SimpleButton;
                try
                {
                    button.Enabled = false;
                    busUDFForm.PrintLabel();
                }
                finally
                {
                    button.Enabled = true;
                }

                RefreshTheButtonControl();
                firstFocusedObject.Focus();
            }
        }

        private void ClearTheInputs()
        {
            for (int i = 0; i < _edits.Count; i++)
            {
                _edits[i].Enabled = (_edits[i].Tag as FormCtrlInfo).Enabled;
                _edits[i].Visible = (_edits[i].Tag as FormCtrlInfo).Visible;
                _edits[i].Text = (_edits[i].Tag as FormCtrlInfo).DefaultValueStr;

                Application.DoEvents();
            }

            if (firstFocusedObject != null)
            {
                foreach (TextEdit edit in _edits)
                {
                    if (edit.Enabled && edit.Visible)
                    {
                        edit.Focus();
                        return;
                    }
                }
            }
        }
        #endregion

        private void frmUDFForm1Ex_Shown(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (this.Tag is MenuInfo)
                {
                    menuInfo = this.Tag as MenuInfo;
                }
                else
                {
                    WriteLog.Instance.Write("没有正确的传入菜单参数", strProcedureName);

                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        message = "Menu parameters is incorrect!";
                    else
                        message = "没有正确的传入菜单参数！";

                    IRAPMessageBox.Instance.ShowErrorMessage(
                        message,
                        caption);
                    return;
                }

                try
                {
                    busUDFForm.SetCtrlParameter(menuInfo.Parameters);
                    busUDFForm.OpNode = menuInfo.OpNode;

                    CreateDynamicControls();

                    frmUDFForm1Ex_Activated(this, null);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    XtraMessageBox.Show(
                        error.Message,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                WriteLog.Instance.Write("");
            }
        }

        private void frmUDFForm1Ex_Activated(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                Options.Visible = true;

                if (firstFocusedObject != null)
                {
                    firstFocusedObject.Focus();
                }

                RefreshForm();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
