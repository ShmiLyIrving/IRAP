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
using IRAP.Client.Global.GUI.Dialogs;
using IRAP.Client.User;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmCustomAndonForm : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        protected static ProductionLineForStationBound currentProductionLine = null;

        public frmCustomAndonForm()
        {
            InitializeComponent();

            lblProductionLine.Parent = lblFuncName;
        }

        /// <summary>
        /// 当前站点所绑定的产线
        /// </summary>
        /// <returns></returns>
        protected ProductionLineForStationBound GetBoundAndonHost()
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
                List<ProductionLineForStationBound> lines = new List<ProductionLineForStationBound>();

                IRAPMDMClient.Instance.ufn_GetList_StationBoundProductionLines(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref lines,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (ProductionLineForStationBound line in lines)
                    {
                        if (line.BoundToAndonHost)
                        {
                            WriteLog.Instance.Write(
                                string.Format(
                                    "当前站点绑定产线：({0}){1}",
                                    line.T134LeafID,
                                    line.T134NodeName),
                                strProcedureName);
                            return line;
                        }
                    }

                    WriteLog.Instance.Write("当前站点没有绑定任何产线！", strProcedureName);
                    return null;
                }
                else
                {
                    ShowMessageBox.Show(
                        errText,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                ShowMessageBox.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        protected void RefreshCurrentProductionLine()
        {
            currentProductionLine = GetBoundAndonHost();
            if (currentProductionLine != null)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                {
                    lblProductionLine.Text =
                        string.Format(
                            "Current production line: {0}",
                            currentProductionLine.T134NodeName);

                    if (currentProductionLine.IsStoped)
                    {
                        lblProductionLine.ForeColor = Color.Red;
                        lblProductionLine.Text += "  (Stopped)";
                    }
                    else
                    {
                        lblProductionLine.ForeColor = Color.Green;
                    }
                }
                else
                {
                    lblProductionLine.Text =
                        string.Format(
                            "当前产线：{0}",
                            currentProductionLine.T134NodeName);

                    if (currentProductionLine.IsStoped)
                    {
                        lblProductionLine.ForeColor = Color.Red;
                        lblProductionLine.Text += "  (已停线)";
                    }
                    else
                    {
                        lblProductionLine.ForeColor = Color.Green;
                    }
                }
            }
            else
            {
                lblProductionLine.ForeColor = Color.Green;

                if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                    lblProductionLine.Text = "Current production line: None";
                else
                    lblProductionLine.Text = "当前产线：无";
            }
        }

        private void frmCustomAndonForm_Activated(object sender, EventArgs e)
        {
            RefreshCurrentProductionLine();
        }
    }
}
