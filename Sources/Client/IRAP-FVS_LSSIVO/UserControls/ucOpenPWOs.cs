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
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucOpenPWOs : ucCustomFVSKanban
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ucOpenPWOs()
        {
            InitializeComponent();
        }

        public void GetOpenPWOsOfALine(
            int communityID,
            int resourceTreeID,
            int leafID,
            long sysLogID)
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
                    grdOpenPWOs.DataSource = pwos;
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
    }
}
