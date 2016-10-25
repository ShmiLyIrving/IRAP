using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Entity.MES;
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucOpenPWOs : ucCustomFVSKanban
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int communityID = 0;
        private int resourceTreeID = 0;
        private int leafID = 0;
        private long sysLogID = 0;
        private ucKPIBTS kpi = null;

        public ucOpenPWOs()
        {
            InitializeComponent();
        }

        private void RefreshOpenPWOs(
            int communityID,
            int resourceTreeID,
            int leafID,
            long sysLogID,
            ref string pwoNo)
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
                List<OpenPWO> pwos = new List<OpenPWO>();
                pwoNo = "";

                IRAPMESClient.Instance.ufn_GetList_OpenPWOsOfALine(
                    communityID,
                    resourceTreeID,
                    leafID,
                    sysLogID,
                    ref pwos,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    List<OpenPWO> openPWOs = new List<OpenPWO>();

                    int i = 0;
                    foreach (OpenPWO pwo in pwos)
                    {
                        if (i > 1)
                            break;

                        if (i == 0 && pwo.PWOStatus == 5)
                        {
                            if (kpi.Tag is LineKPI_BTS)
                            {
                                LineKPI_BTS kpiData = (LineKPI_BTS)kpi.Tag;
                                OpenPWO openPWO = pwo.Clone();

                                openPWO.ActualQuantity = kpiData.ActualQuantity.DoubleValue;
                                openPWO.ActualStartTime = kpiData.ActualStartTime;
                                openPWO.BTSStatus = kpiData.BTSStatus;
                                pwoNo = kpiData.PWONo;

                                openPWOs.Add(openPWO);

                                i++;
                            }
                        }
                        else
                        {
                            pwo.BTSStatus = -1;
                            openPWOs.Add(pwo.Clone());

                            i += 2;
                        }

                    }

                    grdOpenPWOs.DataSource = openPWOs;
                    grdvOpenPWOs.BestFitColumns();
                }
                else
                {
                    grdOpenPWOs.DataSource = null;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void SetSearchCondition(
            int communityID,
            int resourceTreeID,
            int leafID,
            long sysLogID,
            ucKPIBTS kpi,
            ref string pwoNo)
        {
            this.communityID = communityID;
            this.resourceTreeID = resourceTreeID;
            this.leafID = leafID;
            this.sysLogID = sysLogID;
            this.kpi = kpi;

            RefreshOpenPWOs(communityID, resourceTreeID, leafID, sysLogID, ref pwoNo);
        }
    }
}
