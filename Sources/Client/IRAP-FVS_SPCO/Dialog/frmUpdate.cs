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
using System.Xml;

namespace IRAP_FVS_SPCO
{
    public partial class frmUpdate : DevExpress.XtraEditors.XtraForm
    {
        private string className =
           MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private StationLogin stationUser = null;
        private List<StationEquipment> ListRight = new List<StationEquipment>();
        private List<StationEquipment> TempRight = new List<StationEquipment>();
        private List<StationEquipment> ListLeft = new List<StationEquipment>();
        private List<StationEquipment> TempLeft = new List<StationEquipment>();
        private int LimitCoungt = 0;
        public frmUpdate(StationLogin StationUser)
        {
            InitializeComponent();
            stationUser = StationUser;
            ListRight.Clear();
            ListLeft.Clear();
            ListRight =TempRight = GetNotOnStationEquipments();
            ListLeft =TempLeft = GetOnStationEquipments();
            if (ListLeft != null)
            {
                LimitCoungt = ListLeft.Count;
            }
            this.grdRight.DataSource = TempRight;
            this.grdLeft.DataSource = TempLeft;         
        }

        private List<StationEquipment> GetNotOnStationEquipments()
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
                List<StationEquipment> rlt =
                    new List<StationEquipment>();

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
        private List<StationEquipment> GetOnStationEquipments()
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
                List<StationEquipment> rlt =
                    new List<StationEquipment>();

                IRAPMDMClient.Instance.ufn_GetList_OnStationT133(
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

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (grvRight.GetFocusedDataSourceRowIndex() > -1)
            {
                StationEquipment temp = TempRight[grvRight.GetFocusedDataSourceRowIndex()];
                TempRight.RemoveAt(grvRight.GetFocusedDataSourceRowIndex());
                TempLeft.Add(temp);
                grvLeft.RefreshData();
                grvRight.RefreshData();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (grvLeft.GetFocusedDataSourceRowIndex() > LimitCoungt-1)
            {
                StationEquipment temp = TempLeft[grvLeft.GetFocusedDataSourceRowIndex()];
                TempLeft.RemoveAt(grvLeft.GetFocusedDataSourceRowIndex());
                TempRight.Add(temp);
                grvLeft.RefreshData();
                grvRight.RefreshData();
            }
        }

        private void grvLeft_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if(e.RowHandle<LimitCoungt)
            {
                e.Appearance.BackColor = Color.DarkOrange;
                e.Appearance.ForeColor = Color.Azure;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string xml = "<T133></T133>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            for (int i = LimitCoungt; i < grvLeft.RowCount; i++)
            {
                int handle = grvLeft.GetDataSourceRowIndex(i);
                XmlElement n = doc.CreateElement("T133_1");
                n.SetAttribute("Ordinal", "");
                n.SetAttribute("T133LeafID", TempLeft[handle].T133LeafID.ToString());
                n.SetAttribute("T133Code", TempLeft[handle].T133Code.ToString());
                n.SetAttribute("OP", "A");
                doc.FirstChild.AppendChild(n);
            }
            MDVC(doc.OuterXml);
        }

        private void MDVC(string xml)
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

                IRAPMDMClient.Instance.usp_SaveFact_MDVCSetting(
                    stationUser.CommunityID,
                    xml,
                    stationUser.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {

                }
                else
                {
                    XtraMessageBox.Show(errText, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}