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
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucAndonStatus : ucCustomFVSKanban
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int communityID = 0;
        private int t134LeafID = 0;
        private long sysLogID = 0;

        public ucAndonStatus()
        {
            InitializeComponent();
        }

        private void SetAndonLightStatus(
            LabelControl label,
            bool isLighting)
        {
            if (isLighting)
            {
                label.Appearance.Image = Properties.Resources.light_yellow;
                label.Appearance.ForeColor = Color.Red;
            }
            else
            {
                label.Appearance.Image = Properties.Resources.light_gray;
                label.Appearance.ForeColor = Color.Black;
            }
        }

        private void RefreshTheAndonStatus(
            int communityID,
            int t134LeafID,
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
                #region 初始化 Andon 状态灯为灭
                SetAndonLightStatus(lblSystem, false);
                SetAndonLightStatus(lblWarehouse, false);
                SetAndonLightStatus(lblTest, false);
                SetAndonLightStatus(lblTechnology, false);
                SetAndonLightStatus(lblEquipment, false);
                SetAndonLightStatus(lblProcedure, false);
                SetAndonLightStatus(lblPCBA, false);
                SetAndonLightStatus(lblOthers, false);
                SetAndonLightStatus(lblMaterialTrack, false);
                SetAndonLightStatus(lblQuality, false);
                SetAndonLightStatus(lblExpandPosition, false);
                #endregion

                int errCode = 0;
                string errText = "";
                List<AnomalyCauseType> datas = new List<AnomalyCauseType>();

                IRAPFVSClient.Instance.ufn_GetList_AnomalyCauseTypes(
                    communityID,
                    t134LeafID,
                    sysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (AnomalyCauseType data in datas)
                    {
                        if (data.Existence)
                        {
                            switch (data.T144LeafID)
                            {
                                case 2204030:
                                    SetAndonLightStatus(lblSystem, true);
                                    break;
                                case 2204031:
                                    SetAndonLightStatus(lblWarehouse, true);
                                    break;
                                case 2204032:
                                    SetAndonLightStatus(lblTest, true);
                                    break;
                                case 2204033:
                                    SetAndonLightStatus(lblTechnology, true);
                                    break;
                                case 1325160:
                                    SetAndonLightStatus(lblEquipment, true);
                                    break;
                                case 1325162:
                                    SetAndonLightStatus(lblProcedure, true);
                                    break;
                                case 2204034:
                                    SetAndonLightStatus(lblPCBA, true);
                                    break;
                                case 2204035:
                                    SetAndonLightStatus(lblOthers, true);
                                    break;
                                case 1325161:
                                    SetAndonLightStatus(lblMaterialTrack, true);
                                    break;
                                case 2204036:
                                    SetAndonLightStatus(lblQuality, true);
                                    break;
                                case 2204037:
                                    SetAndonLightStatus(lblExpandPosition, true);
                                    break;
                            }
                        }
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void SetSearchCondition(
            int communityID,
            int t134LeafID,
            long sysLogID)
        {
            this.communityID = communityID;
            this.t134LeafID = t134LeafID;
            this.sysLogID = sysLogID;

            RefreshTheAndonStatus(communityID, t134LeafID, sysLogID);
        }

        private void ucAndonStatus_SizeChanged(object sender, EventArgs e)
        {
            int totalWidth =
                (Width - lblSystem.Left - lblTitle.Left -
                (lblSystem.Width + lblWarehouse.Width +
                lblTest.Width + lblTechnology.Width +
                lblEquipment.Width + lblProcedure.Width +
                lblPCBA.Width + lblOthers.Width +
                lblMaterialTrack.Width + lblQuality.Width +
                lblExpandPosition.Width)) / 10;

            lblWarehouse.Left = lblSystem.Left + lblSystem.Width + totalWidth;
            lblTest.Left = lblWarehouse.Left + lblWarehouse.Width + totalWidth;
            lblTechnology.Left = lblTest.Left + lblTest.Width + totalWidth;
            lblEquipment.Left = lblTechnology.Left + lblTechnology.Width + totalWidth;
            lblProcedure.Left = lblEquipment.Left + lblEquipment.Width + totalWidth;
            lblPCBA.Left = lblProcedure.Left + lblProcedure.Width + totalWidth;
            lblOthers.Left = lblPCBA.Left + lblPCBA.Width + totalWidth;
            lblMaterialTrack.Left = lblOthers.Left + lblOthers.Width + totalWidth;
            lblQuality.Left = lblMaterialTrack.Left + lblMaterialTrack.Width + totalWidth;
            lblExpandPosition.Left = lblQuality.Left + lblQuality.Width + totalWidth;
        }
    }
}
