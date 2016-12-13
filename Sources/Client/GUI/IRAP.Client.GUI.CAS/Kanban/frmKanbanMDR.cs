using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Global;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmKanbanMDR : IRAP.Client.Global.GUI.frmCustomKanbanBase
    {
        private string className =
             MethodBase.GetCurrentMethod().DeclaringType.FullName;
        List<Entity.FVS.AndonEventKanbanMDR> events =
                           new List<Entity.FVS.AndonEventKanbanMDR>();

        public frmKanbanMDR()
        {
            InitializeComponent();
        }

        private void GetEvents()
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
                    IRAPFVSClient.Instance.ufn_GetAndonEventKanban_MDR(
                        IRAPUser.Instance.CommunityID,
                        t134ClickStream,
                        IRAPUser.Instance.SysLogID,
                        ref events,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    AddLog(new AppOperationLog(DateTime.Now, -1, error.Message));
                    SetConnectionStatus(false);
                    return;
                }
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {
                    grdEvents.DataSource = events;
                    for (int i = 0; i < gdvEvents.Columns.Count; i++)
                    {
                        if (gdvEvents.Columns[i].Visible)
                            gdvEvents.Columns[i].BestFit();
                    }
                    gdvEvents.OptionsView.RowAutoHeight = true;
                    gdvEvents.LayoutChanged();

                    SetConnectionStatus(true);
                }
                else
                {
                    AddLog(new AppOperationLog(DateTime.Now, -1, errText));
                    SetConnectionStatus(false);
                    grdEvents.DataSource = null;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmKanbanMDR_Activated(object sender, EventArgs e)
        {
            if (this.Tag is SystemMenuInfoButtonStyle)
            {
                menuInfo = this.Tag as SystemMenuInfoButtonStyle;
                GetEvents();

                if (autoSwtich)
                {
                    if (this.events.Count > 0)
                    {
                        timer.Interval = this.nextFunction.WaitForSeconds * 1000;
                    }
                    else
                    {
                        timer.Interval = 1000;
                    }
                }
                else
                {
                    timer.Interval = 60000;
                }

                timer.Enabled = true;
            }
            else
            {
                AppOperationLog log = new AppOperationLog(DateTime.Now, -1, "没有正确的传入菜单参数！");
                AddLog(log);
                timer.Enabled = false;
                return;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;

            if (autoSwtich)
            {
                JumpToNextFunction();
                return;
            }
            else
            {
                GetEvents();
                timer.Enabled = true;
            }
        }
    }
}
