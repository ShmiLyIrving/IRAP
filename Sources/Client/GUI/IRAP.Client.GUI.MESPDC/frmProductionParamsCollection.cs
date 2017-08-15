using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

using DevExpress.XtraEditors;
using DevExpress.XtraTab;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmProductionParamsCollection : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<Entities.EntityEquipmentInfo> equipments = 
            new List<Entities.EntityEquipmentInfo>();

        public frmProductionParamsCollection()
        {
            InitializeComponent();
        }

        private void GetStations()
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
                List<WIPStation> stations = new List<WIPStation>();

                equipments.Clear();
                IRAPMDMClient.Instance.ufn_GetList_WIPStationsOfAHost(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref stations,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    foreach (WIPStation station in stations)
                    {
                        equipments.Add(
                            new Entities.EntityEquipmentInfo()
                            {
                                Ordinal = station.Ordinal,
                                T107LeafID = station.T107LeafID,
                                T107EntityID = station.T107EntityID,
                                T107Code = station.T107Code,
                                T107AltCode = station.T107AltCode,
                                T107Name = station.T107Name,
                                T134LeafID = station.T134LeafID,
                                T134EntityID = station.T134EntityID,
                                T134Code = station.T134Code,
                                T134AltCode = station.T134AltCode,
                                T216LeafID = station.T216LeafID,
                                T216EntityID = station.T216EntityID,
                                T216Code = station.T216Code,
                                T216AltCode = station.T216AltCode,
                                T216Name = station.T216Name,
                                T133LeafID = station.T133LeafID,
                                T133EntityID = station.T133EntityID,
                                T133Code = station.T133Code,
                                T133AltCode = station.T133AltCode,
                            });
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmProductionParamsCollection_Shown(object sender, EventArgs e)
        {
            GetStations();

            equipments.Sort(new Entities.EntityEquipmentInfo_CompareByT133AltCode());

            foreach (Entities.EntityEquipmentInfo equipment in equipments)
            {
                XtraTabPage page = new XtraTabPage();
                page.Text = equipment.ToString();

                UserControls.ucBatchSysProduction prdt = new UserControls.ucBatchSysProduction(equipment);
                prdt.Dock = DockStyle.Fill;

                page.Controls.Add(prdt);

                tcMain.TabPages.Add(page);
            }
        }
    }
}
