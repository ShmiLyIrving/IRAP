using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entity.Kanban;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MDM
{
    public partial class frmTestStandardProperties : IRAP.Client.GUI.MDM.frmCustomProperites
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtStandards = null;

        public frmTestStandardProperties()
        {
            InitializeComponent();

            dtStandards = new DataTable();
            dtStandards.Columns.Add("Level", typeof(int));
            dtStandards.Columns.Add("T128LeafID", typeof(int));
            dtStandards.Columns.Add("LowLimit", typeof(long));
            dtStandards.Columns.Add("Criterion", typeof(string));
            dtStandards.Columns.Add("HighLimit", typeof(long));
            dtStandards.Columns.Add("Scale", typeof(int));
            dtStandards.Columns.Add("UnitOfMeasure", typeof(string));
            dtStandards.Columns.Add("Reference", typeof(bool));
            grdStandards.DataSource = dtStandards;

            GetT128List();
            GetCriterion();
        }

        private void GetT128List()
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
                List<LeafSetEx> programItems = new List<LeafSetEx>();

                WriteLog.Instance.Write("获取测试项目列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    128,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref programItems,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    risluT128LeafID.DataSource = programItems;
                }
                else
                {
                    risluT128LeafID.DataSource = null;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetCriterion()
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
                List<ScopeCriterionType> criterionItems = new List<ScopeCriterionType>();

                WriteLog.Instance.Write("获取比较标准项列表", strProcedureName);
                IRAPKBClient.Instance.sfn_GetList_ScopeCriterionType(
                    IRAPUser.Instance.SysLogID,
                    ref criterionItems,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {
                    riluCriterion.DataSource = criterionItems;
                }

                riluCriterion.DisplayMember = "TypeHint";
                riluCriterion.ValueMember = "TypeCode";
                riluCriterion.NullText = "";
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        protected override string GenerateRSAttrXML()
        {
            string strMethodStandardXML = "";

            int i = 1;
            dtStandards.DefaultView.Sort = "Level asc";
            DataTable dt = dtStandards.Copy();
            dt = dtStandards.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                strMethodStandardXML = strMethodStandardXML +
                    string.Format("<Row RealOrdinal=\"{0}\" T128LeafID=\"{1}\" LowLimit=\"{2}\" " +
                        "Criterion=\"{3}\" HighLimit=\"{4}\" Scale=\"{5}\" UnitOfMeasure=\"{6}\"/>",
                        i++,
                        dr["T128LeafID"].ToString(),
                        dr["LowLimit"].ToString(),
                        dr["Criterion"].ToString(),
                        dr["HighLimit"].ToString(),
                        dr["Scale"].ToString(),
                        dr["UnitOfMeasure"].ToString());
            }

            return string.Format("<RSAttr>{0}</RSAttr>", strMethodStandardXML);
        }

        public override void GetProperties(int t102LeafID, int t216LeafID)
        {
            base.GetProperties(t102LeafID, t216LeafID);
        }

        private void grdvStandards_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvStandards.GetDataRow(e.RowHandle);
            dr["Level"] = dtStandards.Rows.Count + 1;
            dr["T128LeafID"] = 0;
            dr["LowLimit"] = 0;
            dr["Criterion"] = "GELE";
            dr["HighLimit"] = 0;
            dr["Scale"] = 0;
            dr["UnitOfMeasure"] = "";
            dr["Reference"] = false;

            SetEditorMode(true);
        }

        private void grdvStandards_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            grdvStandards.BestFitColumns();
            SetEditorMode(true);
        }

        private void grdvStandards_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            grdvStandards.BestFitColumns();
            SetEditorMode(true);
        }
    }
}
