using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraTab;

using IRAP.Global;
using IRAP.Entity.SSO;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_MDVO
{
    public partial class frmShowMDVO : DevExpress.XtraEditors.XtraForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private StationLogin stationInfo = null;
        private WIPStationProductionStatus workUnit = null;
        private int c64ID = 0;
        private int t216LeafID = 0;
        private List<StandardType> panels = new List<StandardType>();
        private Controls.ucCustomDocumentKanban kanban = null;

        public frmShowMDVO()
        {
            InitializeComponent();
        }

        public frmShowMDVO(StationLogin stationInfo) : this()
        {
            this.stationInfo = stationInfo;
        }

        public WIPStationProductionStatus WorkUnit
        {
            get { return workUnit; }
            set
            {
                workUnit = value.Clone();
                Initialize();

                if (value.PWONo_InExecution != "")
                {
                    btnShowWorkUnitAndProduction.Caption = 
                        string.Format(
                            "[{0}]{1}: {2}[生产工单号：{3}]",
                            value.T107Code, 
                            value.T107Name, 
                            value.T102Code_InProduction, 
                            value.PWONo_InExecution);
                }
                else
                {
                    btnShowWorkUnitAndProduction.Caption = 
                        string.Format(
                            "[{0}]{1}: {2}[待生产工单号：{3}]",
                            value.T107Code, 
                            value.T107Name, 
                            value.T102Code_InProduction, 
                            value.NextPWOToExecute);
                }
            }
        }

        #region 自定义函数
        private void Initialize()
        {
            if (stationInfo == null)
                throw new Exception("没有获得站点登录信息");

            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                #region 获取 MethodID
                IRAPMDMClient.Instance.ufn_GetMethodID(
                    stationInfo.CommunityID,
                    workUnit.T102LeafID_InProduction,
                    107,
                    workUnit.T107LeafID,
                    workUnit.PWONo_InExecution != "" ?
                        workUnit.PWOCreatedUnixTime_Current :
                        workUnit.PWOCreatedUnixTime_Next,
                    ref c64ID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode != 0)
                    throw new Exception(errText);
                #endregion

                #region 获取 T216LeafID
                IRAPMDMClient.Instance.ufn_GetT216LeafID(
                    stationInfo.CommunityID,
                    workUnit.T102LeafID_InProduction,
                    workUnit.T107LeafID,
                    workUnit.PWONo_InExecution != "" ?
                        workUnit.PWOCreatedUnixTime_Current :
                        workUnit.PWOCreatedUnixTime_Next,
                    ref t216LeafID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode != 0)
                    throw new Exception(errText);
                #endregion

                #region 获取需要显示的可视化列表
                IRAPMDMClient.Instance.ufn_GetList_AvailableMethodStandards(
                    stationInfo.CommunityID,
                    c64ID,
                    stationInfo.LanguageID,
                    ref panels,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode != 0)
                    throw new Exception(errText);
                #endregion

                for (int i = 0; i < panels.Count; i++)
                {
                    XtraTabPage document = new XtraTabPage();
                    document.Text = panels[i].StandardName;

                    switch (panels[i].StandardID)
                    {
                        case 1:
                            kanban = new Controls.ucMethodStandard();
                            break;
                        case 2:
                            kanban = new Controls.ucInspectStandard();
                            break;
                        case 4:
                            kanban = new Controls.ucToolingStandard();
                            break;
                    }
                    if (kanban != null)
                    {
                        kanban.CommunityID = stationInfo.CommunityID;
                        kanban.SysLogID = stationInfo.SysLogID;
                        kanban.T102LeafID = workUnit.T102LeafID_InProduction;
                        kanban.T216LeafID = t216LeafID;

                        kanban.Parent = document;
                        kanban.Dock = DockStyle.Fill;
                    }

                    tcDocuments.TabPages.Add(document);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
        #endregion

        private void btnClose_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            Close();
        }
    }
}