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
    public partial class ucECNtoLine : ucCustomFVSKanban
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int communityID = 0;
        private int t102LeafID = 0;
        private long sysLogID = 0;
        private List<LabelControl> lights = new List<LabelControl>();

        public ucECNtoLine()
        {
            InitializeComponent();

            lights.Add(lblSystem);
            lights.Add(lblEquipment);
            lights.Add(lblMaterial);
            lights.Add(lblMethod);
            lights.Add(lblEquipment);
        }
        private void SetLightStatus(
            LabelControl label,
            OpenChangeSummary data)
        {
            if (data.Existence)
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

        private void GetECNtolineDatas(
            int communityID,
            int t102LeafID,
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
                List<OpenChangeSummary> lightDatas = new List<OpenChangeSummary>();
                List<OpenChangeInfo> datas = new List<OpenChangeInfo>();

                try
                {
                    IRAPMESClient.Instance.ufn_GetSummary_OpenChanges(
                        communityID,
                        t102LeafID,
                        sysLogID,
                        ref lightDatas,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode == 0)
                    {
                        for (int i = 0; i < lights.Count; i++)
                        {
                            lights[i].Visible = false;
                            if (i < lightDatas.Count)
                            {
                                lights[i].Visible = true;
                                SetLightStatus(lights[i], lightDatas[i]);
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }

                try
                {
                    IRAPMESClient.Instance.ufn_GetFactList_OpenChanges(
                        communityID,
                        t102LeafID,
                        sysLogID,
                        ref datas,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);
                    if (errCode == 0)
                    {
                        grdOpenPWOs.DataSource = datas;
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
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void SetSearchCondition(
            int communityID,
            int t102LeafID,
            long sysLogID)
        {
            this.communityID = communityID;
            this.t102LeafID = t102LeafID;
            this.sysLogID = sysLogID;

            GetECNtolineDatas(communityID, t102LeafID, sysLogID);
        }
    }
}
