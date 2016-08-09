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

        public frmCustomAndonForm()
        {
            InitializeComponent();
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

        private void frmCustomAndonForm_Activated(object sender, EventArgs e)
        {
            ProductionLineForStationBound currentLine = GetBoundAndonHost();
            if (currentLine != null)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                    lblProductionLine.Text = 
                        string.Format(
                            "Current production line: {0}",
                            currentLine.T134NodeName);
                else
                    lblProductionLine.Text = 
                        string.Format(
                            "当前产线：{0}",
                            currentLine.T134NodeName);
            }
            else
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                    lblProductionLine.Text = "Current production line: None";
                else
                    lblProductionLine.Text = "当前产线：无";
            }
        }
    }
}
