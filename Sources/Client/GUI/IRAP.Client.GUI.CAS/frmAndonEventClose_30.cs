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
using IRAP.Entity.FVS;
using IRAP.Entity.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmAndonEventClose_30 : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private List<AndonEventToClose> events = new List<AndonEventToClose>();

        public frmAndonEventClose_30()
        {
            InitializeComponent();
        }

        private void GetAndonEventsToClose()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                WriteLog.Instance.Write("获取待关闭的安灯事件清单", strProcedureName);

                int errCode = 0;
                string errText = "";

                IRAPFVSClient.Instance.ufn_GetList_AndonEventsToClose(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref events,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {
                    grdAndonEvents.DataSource = events;
                    for (int i = 0; i < grdvAndonEvents.Columns.Count; i++)
                    {
                        grdvAndonEvents.Columns[i].BestFit();
                    }
                    grdvAndonEvents.OptionsView.RowAutoHeight = true;
                    grdvAndonEvents.LayoutChanged();
                }
                else
                {
                    grdAndonEvents.DataSource = null;
                    return;
                }
            }
            catch (Exception error)
            {
                grdAndonEvents.DataSource = null;
                WriteLog.Instance.Write(error.Message, strProcedureName);
                return;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmAndonEventClose_30_Activated(object sender, EventArgs e)
        {
            GetAndonEventsToClose();
        }

        private void grdvAndonEvents_Click(object sender, EventArgs e)
        {
            btnEventClose.Enabled = grdvAndonEvents.GetFocusedDataSourceRowIndex() >= 0;
        }

        private void btnEventClose_Click(object sender, EventArgs e)
        {
            if (grdvAndonEvents.GetFocusedDataSourceRowIndex() >= 0)
            {
                string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);

                int index = grdvAndonEvents.GetFocusedDataSourceRowIndex();

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    WriteLog.Instance.Write(string.Format("关闭安灯事件[{0}]", events[index].EventFactID), strProcedureName);
                    WriteLog.Instance.Write("采集关闭者的用户代码和满意度评分", strProcedureName);

                    string userCode = "";
                    int satisfactoryLevel = 0;

                    using (frmAndonEventCloseProperties formAndonEventClose = new frmAndonEventCloseProperties())
                    {
                        if (formAndonEventClose.ShowDialog() == DialogResult.Cancel)
                        {
                            WriteLog.Instance.Write(string.Format("取消关闭安灯事件[{0}]", events[index].EventFactID), strProcedureName);

                            GetAndonEventsToClose();

                            return;
                        }
                        else
                        {
                            userCode = formAndonEventClose.UserInfo.UserCode;
                            satisfactoryLevel = formAndonEventClose.Satisfactory;
                        }
                    }

                    WriteLog.Instance.Write(
                        string.Format("采集到关闭者代码[{0}]和满意度评分[{0}]",
                            userCode,
                            satisfactoryLevel),
                        strProcedureName);

                    int errCode = 0;
                    string errText = "";
                    long transactNo = 0;
                    long factID = 0;
                    string opNode = ((MenuInfo)Tag).OpNode;

                    transactNo = 
                        IRAPUTSClient.Instance.mfn_GetTransactNo(
                            IRAPUser.Instance.CommunityID, 
                            1, 
                            IRAPUser.Instance.SysLogID, 
                            opNode);
                    factID = 
                        IRAPUTSClient.Instance.mfn_GetFactID(
                            IRAPUser.Instance.CommunityID, 
                            1, 
                            IRAPUser.Instance.SysLogID, 
                            opNode);

                    IRAPFVSClient.Instance.usp_SaveFact_AndonEventClose(
                        IRAPUser.Instance.CommunityID,
                        transactNo,
                        factID,
                        events[index].EventFactID,
                        events[index].OpID,
                        userCode,
                        satisfactoryLevel,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    if (errCode == 0)
                    {
                        ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    GetAndonEventsToClose();
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    ShowMessageBox.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }
    }
}
