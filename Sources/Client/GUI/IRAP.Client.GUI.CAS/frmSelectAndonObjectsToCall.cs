using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global.GUI.Dialogs;
using IRAP.Entity.SSO;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmSelectAndonObjectsToCall : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private AndonEventType andonEventType = null;
        private List<AndonCallObject> objectsOfAndonCall = new List<AndonCallObject>();
        private string opNode = "";
        private ProductionLineForStationBound productionLine = null;

        public frmSelectAndonObjectsToCall()
        {
            InitializeComponent();
        }

        public frmSelectAndonObjectsToCall(
            AndonEventType andonEventTypeItem,
            string opNode,
            ProductionLineForStationBound pLine) : this()
        {
            andonEventType = andonEventTypeItem;
            this.opNode = opNode;
            productionLine = pLine;

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
            {
                Text = string.Format("Andon call for {0}", andonEventType.EventTypeName);
                gpcAndonEvents.Text = string.Format("Please select {0}", andonEventType.CaptionName);
            }
            else
            {
                Text = string.Format("呼叫{0}", andonEventType.EventTypeName);
                gpcAndonEvents.Text = string.Format("请选择{0}", andonEventType.CaptionName);
            }

            // 如果呼叫事件类型是“安全”，则隐藏多选栏
            if (andonEventType.EventTypeCode == "S")
                grdclmnChoice.Visible = false;
        }

        private void frmSelectAndonObjectsToCall_Shown(object sender, EventArgs e)
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

                IRAPMDMClient.Instance.ufn_GetList_AndonCallObjects(
                    IRAPUser.Instance.CommunityID,
                    andonEventType.EventTypeLeaf,
                    0,
                    0,
                    IRAPUser.Instance.SysLogID,
                    ref objectsOfAndonCall,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText), 
                    strProcedureName);
                if (errCode != 0)
                {
                    ShowMessageBox.Show(
                        string.Format("({0}){1}", errCode, errText), 
                        this.Text, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }

                grdAndonCallObjects.DataSource = objectsOfAndonCall;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                ShowMessageBox.Show(
                    error.Message, 
                    this.Text, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            string userIDCardNo = "";
            switch (andonEventType.EventTypeCode)
            {
                case "S":       // 安全事件呼叫，一次只能呼叫一个
                    int index = grdvAndonCallObjects.GetFocusedDataSourceRowIndex();
                    if (index >= 0)
                    {
                        if (SaveAndonEventCall(objectsOfAndonCall[index], ref userIDCardNo))
                            btnClose.PerformClick();
                    }
                    break;
                default:
                    int intSelectedCount = 0;
                    foreach (AndonCallObject andonObject in objectsOfAndonCall)
                    {
                        if (andonObject.Choice)
                        {
                            intSelectedCount++;
                            if (!SaveAndonEventCall(andonObject, ref userIDCardNo))
                                return;
                        }
                    }

                    if (intSelectedCount <= 0)
                    {
                        string msgText = "";
                        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                            msgText = "Please select at least one item that needs to be called.";
                        else
                            msgText = "请至少选择一项需要呼叫的内容！";

                        ShowMessageBox.Show(
                            msgText,
                            this.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        grdAndonCallObjects.Focus();
                        return;
                    }
                    else
                    {
                        btnClose.PerformClick();
                    }
                    break;
            }
        }

        /// <summary>
        /// 保存安灯事件呼叫事实
        /// </summary>
        private bool SaveAndonEventCall(AndonCallObject andonObject, ref string userIDCardNo)
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
                long transactNo = 0;
                long factID = 0;
                UserInfo staff = new UserInfo();

                #region 获取呼叫者的身份信息
                WriteLog.Instance.Write("获取呼叫者的身份信息", strProcedureName);

                if (userIDCardNo == "")
                {
                    userIDCardNo = ReadUserIDCard.Instance.Execute();
                    if (ReadUserIDCard.Instance.DialogResult!= DialogResult.OK)
                    {
                        userIDCardNo = "";
                        return false;
                    }
                }

                if (userIDCardNo == "")
                {
                    WriteLog.Instance.Write("没有输入ID卡号，不能呼叫安灯事件。", strProcedureName);

                    string msgText = "";
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                        msgText = "There is no caller information, can not call!";
                    else
                        msgText = "没有呼叫者信息，不能呼叫！";
                    ShowMessageBox.Show(
                        msgText,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    try
                    {
                        IRAPUserClient.Instance.sfn_GetInfo_UserFromIDCode(
                            IRAPUser.Instance.CommunityID,
                            userIDCardNo,
                            ref staff,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("({0}){1}", errCode, errText),
                            strProcedureName);
                        if (errCode != 0)
                        {
                            ShowMessageBox.Show(
                                errText,
                                this.Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        string msgText = "";
                        if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                            msgText = "Error occurred while verifying the ID card number, {0}.";
                        else
                            msgText = "验证 ID 卡号时发生错误：{0}";
                        ShowMessageBox.Show(
                            string.Format(msgText,
                                error.Message),
                            this.Text);
                        return false;
                    }
                }
                WriteLog.Instance.Write("成功获得呼叫者的身份信息", strProcedureName);
                #endregion

                #region 将交易操作员切换成上述验证身份后的人员
                WriteLog.Instance.Write(
                    string.Format(
                        "将交易操作员切换为：({0}){1}",
                        staff.UserCode,
                        staff.UserName),
                    strProcedureName);
                transactNo =
                    IRAPUTSClient.Instance.mfn_GetTransactNo(
                        IRAPUser.Instance.CommunityID,
                        1,
                        IRAPUser.Instance.SysLogID,
                        opNode);

                IRAPUserClient.Instance.ssp_ReplaceTranOperator(
                    IRAPUser.Instance.CommunityID,
                    transactNo,
                    staff.UserCode,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    ShowMessageBox.Show(
                        errText,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                WriteLog.Instance.Write("切换成功！", strProcedureName);
                #endregion

                #region 保存安灯事件呼叫事实
                WriteLog.Instance.Write("保存安灯事件呼叫事实", strProcedureName);
                factID =
                    IRAPUTSClient.Instance.mfn_GetFactID(
                        IRAPUser.Instance.CommunityID,
                        1,
                        IRAPUser.Instance.SysLogID,
                        opNode);

                IRAPFVSClient.Instance.usp_SaveFact_AndonEventCallFromProductionLine(
                    IRAPUser.Instance.CommunityID,
                    transactNo,
                    factID,
                    andonEventType.EventTypeLeaf,
                    productionLine.T134LeafID,
                    0,
                    andonObject.TreeID,
                    andonObject.LeafID,
                    andonObject.Code,
                    chkProductionLineStopped.Checked,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode != 0)
                {
                    ShowMessageBox.Show(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    return false;
                }
                else
                {
                    string msgText = "";
                    if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                    {
                        msgText = "The Andon call {0} result: {1}";
                    }
                    else
                    {
                        msgText = "安灯呼叫【{0}】：{1}";
                    }
                    ShowMessageBox.Show(
                        string.Format(
                            msgText,
                            andonObject.ObjectDesc,
                            errText),
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return true;
                }
                #endregion
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                ShowMessageBox.Show(error.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
