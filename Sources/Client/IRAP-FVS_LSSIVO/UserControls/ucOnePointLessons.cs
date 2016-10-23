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
using DevExpress.XtraTab;

using IRAP.Global;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucOnePointLessons : ucCustomFVSKanban
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int communityID = 0;
        private int t102LeafID = 0;
        private string shotTime = "";
        private long sysLogID = 0;

        private List<ucOnePointLesson> pages = new List<ucOnePointLesson>();

        public ucOnePointLessons()
        {
            InitializeComponent();
        }

        public void SetSearchCondition(
            int communityID,
            int t102LeafID,
            string shotTime,
            long sysLogID)
        {
            this.communityID = communityID;
            this.t102LeafID = t102LeafID;
            this.shotTime = shotTime;
            this.sysLogID = sysLogID;

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
                List<OnePointLesson> datas = new List<OnePointLesson>();

                IRAPMDMClient.Instance.ufn_GetList_OnePointLessons(
                    communityID,
                    t102LeafID,
                    shotTime,
                    sysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                {
                    foreach (OnePointLesson data in datas)
                    {
                        XtraTabPage tabPage = xtraTabControl1.TabPages.Add();
                        tabPage.Text = string.Format("NO.{0}", data.IssueNo.ToString("D2"));

                        List<OPLTrainee> trainees = new List<OPLTrainee>();
                        IRAPMDMClient.Instance.ufn_GetList_OPLTrainees(
                            communityID,
                            t102LeafID,
                            data.IssueNo,
                            "",
                            sysLogID,
                            ref trainees,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("({0}){1}", errCode, errText),
                            strProcedureName);

                        ucOnePointLesson opl = new ucOnePointLesson();
                        opl.Parent = tabPage;
                        opl.OnePointLesson = data.Clone();
                        opl.Trainee = trainees;
                        opl.Dock = DockStyle.Fill;
                        pages.Add(opl);
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
