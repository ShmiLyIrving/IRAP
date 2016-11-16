using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Threading;
using System.Runtime.InteropServices;

using DevExpress.XtraTab;
using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.MDM;
using IRAP.Entity.SSO;
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventCall_30 : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<UserControls.ucAndonEventButton> buttons = new List<UserControls.ucAndonEventButton>();
        private List<AndonEventType> andonEventTypes = new List<AndonEventType>();
        /// <summary>
        /// 红色告警灯状态
        /// </summary>
        private Enums.LightStatus redLightStatus = Enums.LightStatus.Off;
        /// <summary>
        /// 黄色告警灯状态
        /// </summary>
        private Enums.LightStatus yellowLightStatus = Enums.LightStatus.Off;
        /// <summary>
        /// 绿色告警灯状态
        /// </summary>
        private Enums.LightStatus greenLightStatus = Enums.LightStatus.Off;
        /// <summary>
        /// 蓝色告警灯状态
        /// </summary>
        private Enums.LightStatus blueLightStatus = Enums.LightStatus.Off;
        /// <summary>
        /// 白色告警灯状态
        /// </summary>
        private Enums.LightStatus whiteLightStatus = Enums.LightStatus.Off;
        /// <summary>
        /// 蜂鸣器状态
        /// </summary>
        private Enums.LightStatus buzzingStatus = Enums.LightStatus.Off;
        /// <summary>
        /// 是否打开了告警灯的 USB 端口
        /// </summary>
        private long usbOpen = -1;
        private MenuInfo menuInfo = null;

        public frmAndonEventCall_30()
        {
            InitializeComponent();

            picRed.Parent = picLights;
            picYellow.Parent = picLights;
            picGreen.Parent = picLights;

            picRed.Image = Properties.Resources.灰色;
            picRed.Tag = (int)Enums.LightStatus.Off;

            picYellow.Image = Properties.Resources.灰色;
            picYellow.Tag = (int)Enums.LightStatus.Off;

            picGreen.Image = Properties.Resources.灰色;
            picGreen.Tag = (int)Enums.LightStatus.Off;

            GetAndonEventTypeButtonsStatus(ref andonEventTypes, false);
            CreateAndonEventButtons(andonEventTypes);

            tmrRefreshLight.Enabled = true;
            tmrGetAndonEventStatus.Enabled = true;
        }

        #region 自定义函数

        private void CreateAndonEventButtons(List<AndonEventType> andonEventTypes)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 根据获取的 Andon 事件类型列表，生成界面上的 Andon 事件点击按钮
                foreach (AndonEventType andonEventType in andonEventTypes)
                {
                    if (andonEventType.Available)
                    {
                        UserControls.ucAndonEventButton button = new UserControls.ucAndonEventButton()
                        {
                            EventTypeItem = andonEventType,
                        };

                        // 绑定 Andon 按钮点击事件
                        if (button.Available && button.Statue != 0)
                            button.MouseLeftClick += AndonEventCall;

                        buttons.Add(button);
                    }
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetAndonEventTypeButtonsStatus(ref List<AndonEventType> andonEventTypes, bool silent)
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

                IRAPMDMClient.Instance.ufn_GetList_AndonEventTypes(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref andonEventTypes,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format(
                        "({0}){1}",
                        errCode,
                        errText),
                    strProcedureName);
                if (errCode != 0 && !silent)
                {
                    string msgTitle = "";
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        msgTitle = "System Info";
                    else
                        msgTitle = "系统信息";

                    IRAPMessageBox.Instance.Show(errText, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                if (!silent)
                {
                    string msgTitle = "";
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        msgTitle = "System Info";
                    else
                        msgTitle = "系统信息";

                    IRAPMessageBox.Instance.Show(error.Message, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void AndonEventCall(object sender, EventArgs e)
        {
            if (sender is UserControls.ucAndonEventButton)
            {
                string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    tmrGetAndonEventStatus.Enabled = false;

                    AndonEventType andonEventTypeItem = ((UserControls.ucAndonEventButton)sender).EventTypeItem;

                    switch (andonEventTypeItem.EventTypeCode)
                    {
                        case "R":
                            using (frmSelectFailureModesByDeviceToCall formAndonCall =
                                new frmSelectFailureModesByDeviceToCall(
                                    andonEventTypeItem,
                                    menuInfo.OpNode,
                                    currentProductionLine))
                            {
                                formAndonCall.ShowDialog();
                            }
                            break;
                        case "O":
                            if (IRAPUser.Instance.CommunityID == 60006)
                            {
                                // 伟世通在进行其他支持呼叫时，使用定制界面
                                using (frmSelectPersonsToCall formAndonCall =
                                    new frmSelectPersonsToCall(
                                        andonEventTypeItem,
                                        menuInfo.OpNode,
                                        currentProductionLine))
                                {
                                    formAndonCall.ShowDialog();
                                }
                            }
                            else
                            {
                                // 其他支持呼叫，使用一般通用界面
                                using (frmSelectAndonObjectsToCall formAndonCall =
                                    new frmSelectAndonObjectsToCall(
                                        andonEventTypeItem,
                                        menuInfo.OpNode,
                                        currentProductionLine))
                                {
                                    formAndonCall.ShowDialog();
                                }
                            }
                            break;
                        default:
                            using (frmSelectAndonObjectsToCall formAndonCall =
                                new frmSelectAndonObjectsToCall(
                                    andonEventTypeItem,
                                    menuInfo.OpNode,
                                    currentProductionLine))
                            {
                                formAndonCall.ShowDialog();
                            }
                            break;
                    }

                    GetAndonLightsStatus();
                    GetAndonEventTypeButtonsStatus(ref andonEventTypes, false);
                    RefreshAndonEventTypeButtonsStatus(andonEventTypes, buttons);
                }
                finally
                {
                    tmrGetAndonEventStatus.Enabled = true;
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        /// <summary>
        /// 获取当前产线的安灯告警灯状态
        /// </summary>
        private void GetAndonLightsStatus()
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<AndonLightStatus> lights = new List<AndonLightStatus>();
                int errCode = 0;
                string errText = "";

                IRAPFVSClient.Instance.ufn_GetList_AndonLightStatus(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref lights,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                if (errCode == 0)
                {
                    if (lights.Count >= 7)
                        redLightStatus = (Enums.LightStatus)lights[6].LightStatus;
                    else
                        redLightStatus = Enums.LightStatus.Off;
                    if (lights.Count >= 8)
                        yellowLightStatus = (Enums.LightStatus)lights[7].LightStatus;
                    else
                        yellowLightStatus = Enums.LightStatus.Off;
                    if (lights.Count >= 9)
                        greenLightStatus = (Enums.LightStatus)lights[8].LightStatus;
                    else
                        greenLightStatus = Enums.LightStatus.Off;
                    if (lights.Count >= 10)
                        blueLightStatus = (Enums.LightStatus)lights[9].LightStatus;
                    else
                        blueLightStatus = Enums.LightStatus.Off;
                    if (lights.Count >= 11)
                        whiteLightStatus = (Enums.LightStatus)lights[10].LightStatus;
                    else
                        whiteLightStatus = Enums.LightStatus.Off;
                    if (lights.Count >= 12)
                        buzzingStatus = (Enums.LightStatus)lights[11].LightStatus;
                    else
                        buzzingStatus = Enums.LightStatus.Off;
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

        /// <summary>
        /// 重新布置界面上安灯时间呼叫按钮
        /// </summary>
        /// <param name="buttons"></param>
        /// <param name="tabControl"></param>
        private void ArrangeAndonEventTypeButtons(
            List<UserControls.ucAndonEventButton> buttons,
            XtraTabControl tabControl)
        {
            foreach (XtraTabPage tabPage in tabControl.TabPages)
            {
                tabPage.PageVisible = false;
                tabPage.Controls.Clear();
            }

            int idxPage = 0;
            XtraTabPage page = tabControl.TabPages[idxPage++];
            page.Text = "第 1 页";
            page.PageVisible = true;

            int intRow = 1;
            int intCol = 1;
            int intLeft = 0;
            int intTop = 0;
            foreach (UserControls.ucAndonEventButton button in buttons)
            {
                intLeft = (intRow - 1) * (button.Width + 5) + 5;
                intRow++;
                if (intLeft + button.Width > tabControl.Width)
                {
                    intRow = 1;
                    intCol++;

                    intLeft = (intRow - 1) * (button.Width + 5) + 5;
                    intRow++;
                }

                intTop = (intCol - 1) * (button.Height + 5) + 5;
                if (intTop + button.Height > tabControl.Height)
                {
                    if (idxPage >= tabControl.TabPages.Count)
                        return;
                    page = tabControl.TabPages[idxPage++];
                    page.Text = string.Format("第 {0} 页", idxPage);
                    page.PageVisible = true;

                    intCol = 1;
                    intTop = (intCol - 1) * (button.Height + 5) + 5;
                }

                button.Left = intLeft;
                button.Top = intTop;
                page.Controls.Add(button);
            }
        }

        private void RefreshAndonEventTypeButtonsStatus(
            List<AndonEventType> andonEventTypes,
            List<UserControls.ucAndonEventButton> buttons)
        {
            int i = 0;
            foreach (AndonEventType type in andonEventTypes)
            {
                if (i >= buttons.Count)
                    return;
                if (type.Available)
                {
                    buttons[i].EventTypeItem = type;
                    i++;
                }
            }
        }

        #endregion

        private void frmAndonEventCall_30_Shown(object sender, EventArgs e)
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

                    string msgText = "";
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        msgText = "The menu parameters is not correct!";
                    else
                        msgText = "没有正确的传入菜单参数！";
                    IRAPMessageBox.Instance.Show(
                        msgText,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                ArrangeAndonEventTypeButtons(buttons, tcAndon);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmAndonEventCall_30_Resize(object sender, EventArgs e)
        {
            ArrangeAndonEventTypeButtons(buttons, tcAndon);
        }

        private void frmAndonEventCall_30_Activated(object sender, EventArgs e)
        {
            GetAndonLightsStatus();
        }

        private void tmrRefreshLight_Tick(object sender, EventArgs e)
        {
            switch (redLightStatus)
            {
                case Enums.LightStatus.Off:
                    picRed.Image = Properties.Resources.灰色;
                    picRed.Tag = (int)Enums.LightStatus.Off;
                    break;
                case Enums.LightStatus.On:
                    picRed.Image = Properties.Resources.红色;
                    picRed.Tag = (int)Enums.LightStatus.On;
                    break;
                case Enums.LightStatus.Flash:
                    if ((int)picRed.Tag == (int)Enums.LightStatus.Off)
                    {
                        picRed.Image = Properties.Resources.红色;
                        picRed.Tag = (int)Enums.LightStatus.On;
                    }
                    else
                    {
                        picRed.Image = Properties.Resources.灰色;
                        picRed.Tag = (int)Enums.LightStatus.Off;
                    }
                    break;
            }

            switch (yellowLightStatus)
            {
                case Enums.LightStatus.Off:
                    picYellow.Image = Properties.Resources.灰色;
                    picYellow.Tag = (int)Enums.LightStatus.Off;
                    break;
                case Enums.LightStatus.On:
                    picYellow.Image = Properties.Resources.黄色;
                    picYellow.Tag = (int)Enums.LightStatus.On;
                    break;
                case Enums.LightStatus.Flash:
                    if ((int)picYellow.Tag == (int)Enums.LightStatus.Off)
                    {
                        picYellow.Image = Properties.Resources.黄色;
                        picYellow.Tag = (int)Enums.LightStatus.On;
                    }
                    else
                    {
                        picYellow.Image = Properties.Resources.灰色;
                        picYellow.Tag = (int)Enums.LightStatus.Off;
                    }
                    break;
            }

            switch (greenLightStatus)
            {
                case Enums.LightStatus.Off:
                    picGreen.Image = Properties.Resources.灰色;
                    picGreen.Tag = (int)Enums.LightStatus.Off;
                    break;
                case Enums.LightStatus.On:
                    picGreen.Image = Properties.Resources.绿色;
                    picGreen.Tag = (int)Enums.LightStatus.On;
                    break;
                case Enums.LightStatus.Flash:
                    if (picGreen.Image == Properties.Resources.灰色)
                    {
                        picGreen.Image = Properties.Resources.绿色;
                        picGreen.Tag = (int)Enums.LightStatus.On;
                    }
                    else
                    {
                        picGreen.Image = Properties.Resources.灰色;
                        picGreen.Tag = (int)Enums.LightStatus.Off;
                    }
                    break;
            }

            try
            {
                int red = 0;
                int yellow = 0;
                int green = 0;

                if ((int)picRed.Tag == (int)Enums.LightStatus.On)
                    red = 1;
                if ((int)picYellow.Tag == (int)Enums.LightStatus.On)
                    yellow = 1;
                if ((int)picGreen.Tag == (int)Enums.LightStatus.On)
                    green = 1;
                CH375.CH375Control.SetLightStatus(red, yellow, green);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message);
            }
        }

        private void tmrGetAndonEventStatus_Tick(object sender, EventArgs e)
        {
            tmrGetAndonEventStatus.Enabled = false;
            try
            {
                GetAndonLightsStatus();

                GetAndonEventTypeButtonsStatus(ref andonEventTypes, true);
                RefreshAndonEventTypeButtonsStatus(andonEventTypes, buttons);
            }
            catch
            {
                ;
            }
            finally
            {
                tmrGetAndonEventStatus.Enabled = true;
            }
        }

        private void frmAndonEventCall_30_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 窗体关闭的时候，同时关闭三色告警灯
            CH375.CH375Control.SetLightStatus(0, 0, 0);
        }
    }
}
