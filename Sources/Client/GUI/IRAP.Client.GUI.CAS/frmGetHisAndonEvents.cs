using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors.Controls;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.SSO;
using IRAP.Entities.FVS;
using IRAP.WCF.Client.Method;
using System.Reflection;
using IRAP.Entity.MDM;
using IRAP.Entity.FVS;
using IRAP.Entities.Kanban;
using IRAP.Entity.Kanban;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmGetHisAndonEvents : IRAP.Client.GUI.CAS.frmCustomAndonForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        public frmGetHisAndonEvents()
        {
            InitializeComponent();
        }

        private void Duringtype(object sender, EventArgs e)
        {
            int errCode=0;
            string errText="";
            List<Entity.Kanban.PeriodType> type = new List<Entity.Kanban.PeriodType>();

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            { 
            IRAPKBClient.Instance.sfn_GetList_ValidPeriodTypes(
                IRAPUser.Instance.CommunityID,
                IRAPUser.Instance.LanguageID,
                ref type,
                out errCode,
                out errText);

            WriteLog.Instance.Write(
                   string.Format("({0}){1}", errCode, errText),
                   strProcedureName);

                foreach (PeriodType data in type)
                {
                    comAndonEvent.Properties.Items.Add(data);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
