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
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;

using IRAP.Global;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucOperatorSkillsMatrix : ucCustomFVSKanban
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int communityID = 0;
        private int t102LeafID = 0;
        private int t134LeafID = 0;
        private string shotTime = "";
        private long sysLogID = 0;
        //private List<SkillMatrix> operators = new List<SkillMatrix>();
        private List<OperatorSkillMatrix> operators = new List<OperatorSkillMatrix>();

        public ucOperatorSkillsMatrix()
        {
            InitializeComponent();
        }

        private void GetOperatorSkillMatrix(
            int communityID,
            int t102LeafID,
            int t134LeafID,
            string shotTime,
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
                operators.Clear();

                int errCode = 0;
                string errText = "";
                //List<OperatorSkillMatrix> datas = new List<OperatorSkillMatrix>();

                IRAPMDMClient.Instance.ufn_GetSkillMatrix_Operators(
                    communityID,
                    t102LeafID,
                    t134LeafID,
                    shotTime,
                    sysLogID,
                    ref operators,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                {
                    //for (int i = 0; i < datas.Count; i += 2)
                    //{
                    //    SkillMatrix op = new SkillMatrix()
                    //    {
                    //        T216Name1 = datas[i].T216Name,
                    //        UserName1 = datas[i].UserName,
                    //        QualificationLevel1 = datas[i].QualificationLevel,
                    //    };

                    //    if (i + 1 < datas.Count)
                    //    {
                    //        op.T216Name2 = datas[i + 1].T216Name;
                    //        op.UserName2 = datas[i + 1].UserName;
                    //        op.QualificationLevel2 = datas[i + 1].QualificationLevel;
                    //    }

                    //    operators.Add(op);
                    //}

                    //grdOperatorSkillMatrixs.DataSource = operators;
                    vgrdOperatorSkills.DataSource = operators;
                }

                FillGridDataWidth();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void SetSearchCondition(
            int communityID,
            int t102LeafID,
            int t134LeafID,
            string shotTime,
            long sysLogID)
        {
            this.communityID = communityID;
            this.t102LeafID = t102LeafID;
            this.t134LeafID = t134LeafID;
            this.shotTime = shotTime;
            this.sysLogID = sysLogID;

            GetOperatorSkillMatrix(
                communityID,
                t102LeafID,
                t134LeafID,
                shotTime,
                sysLogID);
        }

        private void FillGridDataWidth()
        {
            if (operators.Count > 0)
            {
                int recordWidth = (vgrdOperatorSkills.Width - vgrdOperatorSkills.RowHeaderWidth) / operators.Count;
                if (recordWidth > vgrdOperatorSkills.RecordMinWidth)
                {
                    vgrdOperatorSkills.RecordWidth = recordWidth;
                    vgrdOperatorSkills.ScrollVisibility = ScrollVisibility.Vertical;
                }
                else
                {
                    vgrdOperatorSkills.ScrollVisibility = ScrollVisibility.Auto;
                }
            }
        }

        private void vgrdOperatorSkills_CustomDrawRowValueCell(object sender, CustomDrawRowValueCellEventArgs e)
        {
            if (e.Row == rowUserName)
            {
                if (e.RecordIndex >= 0 && e.RecordIndex < operators.Count)
                {
                    switch (operators[e.RecordIndex].QualificationLevel)
                    {
                        case 2:
                            e.Appearance.BackColor = Color.FromArgb(255, 192, 128);
                            e.Appearance.ForeColor = Color.Black;
                            break;
                        case 3:
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.White;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    internal class SkillMatrix
    {
        public string T216Name1 { get; set; }
        public string UserName1 { get; set; }
        public int QualificationLevel1 { get; set; }
        public string T216Name2 { get; set; }
        public string UserName2 { get; set; }
        public int QualificationLevel2 { get; set; }
    }
}
