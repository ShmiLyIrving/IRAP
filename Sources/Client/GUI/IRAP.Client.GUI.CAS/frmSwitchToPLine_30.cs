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
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmSwitchToPLine_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private List<ProductionLineForStationBound> lines = new List<ProductionLineForStationBound>();

        public frmSwitchToPLine_30()
        {
            InitializeComponent();
        }

        private void frmSwitchToPLine_30_Activated(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                cboProductionLines.Properties.Items.Clear();
                btnSwitch.Enabled = false;
                WriteLog.Instance.Write("获取当前站点绑定的生产线清单", strProcedureName);

                int errCode = 0;
                string errText = "";

                IRAPMDMClient.Instance.ufn_GetList_StationBoundProductionLines(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref lines,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {
                    foreach (ProductionLineForStationBound line in lines)
                    {
                        cboProductionLines.Properties.Items.Add(line);
                    }

                    ProductionLineForStationBound currentPrdtLine = GetBoundedProductionLine(lines);
                    if (currentPrdtLine != null)
                    {
                        cboProductionLines.SelectedItem = currentPrdtLine;
                        lblCurrentPLineName.Text = currentPrdtLine.ToString();
                    }
                    else
                    {
                        lblCurrentPLineName.Text = "";
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

        private ProductionLineForStationBound GetBoundedProductionLine(List<ProductionLineForStationBound> prdtLines)
        {
            ProductionLineForStationBound prdtLine = null;
            foreach (ProductionLineForStationBound productionLine in lines)
            {
                if (productionLine.BoundToAndonHost)
                {
                    prdtLine = productionLine;
                    break;
                }
            }
            return prdtLine;
        }

        private void cboProductionLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductionLines.SelectedItem == null)
            {
                btnSwitch.Enabled = false;
                return;
            }

            ProductionLineForStationBound prdtLine = cboProductionLines.SelectedItem as ProductionLineForStationBound;
            btnSwitch.Enabled = prdtLine.ToString() != lblCurrentPLineName.Text;
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            ProductionLineForStationBound prdtLine = null;
            if (cboProductionLines.SelectedItem == null)
            {
                return;
            }
            else
            {
                prdtLine = cboProductionLines.SelectedItem as ProductionLineForStationBound;
            }

            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                WriteLog.Instance.Write("切换选定的生产线", strProcedureName);

                int errCode = 0;
                string errText = "";

                IRAPMDMClient.Instance.usp_SwitchToProductionLine(
                    IRAPUser.Instance.CommunityID,
                    prdtLine.HostName,
                    prdtLine.T134LeafID,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {
                    lblCurrentPLineName.Text = prdtLine.ToString();
                    btnSwitch.Enabled = false;
                    ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    ShowMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
