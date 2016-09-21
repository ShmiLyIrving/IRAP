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

using DevExpress.XtraEditors;
using DevExpress.Utils;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystems;
using IRAP.Client.GUI.MESPDC.Actions;
using IRAP.Entity.SSO;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmUDFForm1Ex_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private MenuInfo menuInfo = null;
        private UDFForm1Ex_30 busUDFForm = new UDFForm1Ex_30();
        private TextEdit firstFocusedObject = null;
        private List<FormCtrlInfo> controls = new List<FormCtrlInfo>();
        private List<LabelControl> _labels = new List<LabelControl>();
        private List<TextEdit> _edits = new List<TextEdit>();
        private List<SimpleButton> _buttons = new List<SimpleButton>();
        private SimpleButton mustAllInputButton = null;
        private SimpleButton reprintLabelButton = null;

        public frmUDFForm1Ex_30()
        {
            InitializeComponent();
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
            rlt.ToolTipTitle = "提示信息";

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
            rlt.ToolTipTitle = "提示信息";

            rlt.Enabled = ctrlInfo.Enabled;
            rlt.Visible = ctrlInfo.Visible;
            rlt.EnterMoveNextControl = false;

            rlt.Text = ctrlInfo.DefaultValueStr;

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
            rlt.ToolTipTitle = "提示信息";

            rlt.Enabled = ctrlInfo.Enabled;
            rlt.Visible = ctrlInfo.Visible;

            rlt.Tag = ctrlInfo;

            pnlBody.Controls.Add(rlt);
            return rlt;
        }
        #endregion

        #region 自定义事件
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

                        if (idxEdit == _edits.Count - 1)
                        {
                            mustAllInputButton.PerformClick();
                        }
                        else
                        {
                            _edits[idxEdit + 1].Focus();
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

        private void RefreshForm()
        {
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
                                    label.Text = ctrl.Caption;
                                    label.Top = ctrl.CtrlTop;
                                    label.Left = ctrl.CtrlLeft;

                                    label.Enabled = ctrl.Enabled;
                                    label.Visible = ctrl.Visible;

                                    label.ToolTip = ctrl.Hint;

                                    label.Tag = ctrl;
                                }
                                break;
                            case "EditBox":
                                TextEdit edit = FindTextEditWithTagOrdinal(ctrl.Ordinal);
                                if (edit != null)
                                {
                                    edit.Top = ctrl.CtrlTop;
                                    edit.Left = ctrl.CtrlLeft;

                                    edit.Enabled = ctrl.Enabled;
                                    edit.Visible = ctrl.Visible;

                                    edit.ToolTip = ctrl.Hint;

                                    edit.Tag = ctrl;
                                }
                                break;
                            case "Button":
                                SimpleButton button = FindButtonWithTagOrdinal(ctrl.Ordinal);
                                if (button != null)
                                {
                                    button.Top = ctrl.CtrlTop;
                                    button.Left = ctrl.CtrlLeft;

                                    button.Enabled = ctrl.Enabled;
                                    button.Visible = ctrl.Visible;

                                    button.ToolTip = ctrl.Hint;

                                    button.Tag = ctrl;
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
                string strProcedureName = string.Format("{0}.{1}",
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
                        if (_edits[i].Text.Trim() == "")
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
                        busUDFForm.SaveOLTPUDFFormData(
                            CurrentOptions.Instance.Process.T102LeafID,
                            CurrentOptions.Instance.WorkUnit.WorkUnitLeaf);
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

                        if (busUDFForm.ErrorCode == 0)
                        {
                            WriteLog.Instance.Write(
                                string.Format("Output={0}", busUDFForm.OutputStr), 
                                strProcedureName);
                            if (busUDFForm.OutputStr != "")
                            {
                                try
                                {
                                    UDFActions.DoActions(
                                        busUDFForm.OutputStr, 
                                        new ExtendEventHandler(RefreshForm));
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
                        MessageBox.Show(string.Format("类库文件：{0} 不存在！",
                                    classFileName),
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        return;
                    }

                    Assembly asm = Assembly.LoadFile(classFileName);
                    if (asm == null)
                    {
                        MessageBox.Show(string.Format("无法加载：IRAP.Client.GUI.{0}",
                            ((FormCtrlInfo)(sender as SimpleButton).Tag).RunFormAtLibraryName));
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
                        MessageBox.Show(string.Format("IRAP.Client.GUI.{0}.{1}正在建设中......",
                                ((FormCtrlInfo)(sender as SimpleButton).Tag).RunFormAtLibraryName,
                                ((FormCtrlInfo)(sender as SimpleButton).Tag).RunFormClassName),
                            "系统信息",
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
                                CurrentOptions.Instance.Process.T120LeafID,
                                CurrentOptions.Instance.WorkUnit.WorkUnitLeaf,
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

        private void frmUDFForm1Ex_30_Shown(object sender, EventArgs e)
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
                    XtraMessageBox.Show(
                        "没有正确的传入菜单参数！", 
                        Text,
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    busUDFForm.SetCtrlParameter(menuInfo.Parameters);
                    busUDFForm.OpNode = menuInfo.OpNode;

                    CreateDynamicControls();

                    frmUDFForm1Ex_30_Activated(this, null);
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

        private void frmUDFForm1Ex_30_Activated(object sender, EventArgs e)
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
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
