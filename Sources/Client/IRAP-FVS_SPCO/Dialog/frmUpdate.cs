using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IRAP.Entity.SSO;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;
using System.Reflection;
using IRAP.Global;

namespace IRAP_FVS_SPCO
{
    public partial class frmUpdate : DevExpress.XtraEditors.XtraForm
    {
        private string className =
           MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private StationLogin stationUser = null;
        private List<NotOnStationEquipment> Rightlist = new List<NotOnStationEquipment>();

        public frmUpdate(StationLogin StationUser)
        {
            InitializeComponent();
            stationUser = StationUser;
            Rightlist = GetNotOnStationEquipments();
            this.grdRight.DataSource = Rightlist;
        }

        private List<NotOnStationEquipment> GetNotOnStationEquipments()
        {
            int errCode = 0;
            string errText = "";
            string strProcedureName =
                 string.Format(
                     "{0}.{1}",
                     className,
                     MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<NotOnStationEquipment> rlt =
                    new List<NotOnStationEquipment>();

                IRAPMDMClient.Instance.ufn_GetList_NotOnStationEquipment(
                    stationUser.CommunityID,
                    stationUser.SysLogID,
                    ref rlt,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("{0}.{1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                    return rlt;
                else
                {
                    XtraMessageBox.Show(errCode + ":" + errText);
                    return null;                    
                }

            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}