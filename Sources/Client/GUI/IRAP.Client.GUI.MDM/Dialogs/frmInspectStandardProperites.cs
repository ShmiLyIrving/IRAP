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
    public partial class frmInspectStandardProperites : IRAP.Client.GUI.MDM.frmCustomProperites
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtInspectStandards = new DataTable();

        public frmInspectStandardProperites()
        {
            InitializeComponent();

            dtInspectStandards.Columns.Add("Level", typeof(int));
            dtInspectStandards.Columns.Add("T20LeafID", typeof(int));
            dtInspectStandards.Columns.Add("ParameterName", typeof(string));
            dtInspectStandards.Columns.Add("LowLimit", typeof(long));
            dtInspectStandards.Columns.Add("Criterion", typeof(string));
            dtInspectStandards.Columns.Add("HighLimit", typeof(long));
            dtInspectStandards.Columns.Add("Scale", typeof(int));
            dtInspectStandards.Columns.Add("UnitOfMeasure", typeof(string));
            dtInspectStandards.Columns.Add("QtyForFirstInspection", typeof(long));
            dtInspectStandards.Columns.Add("QtyForInProcessInspection", typeof(long));
            dtInspectStandards.Columns.Add("InProcessInspectionBatchSize", typeof(long));
            dtInspectStandards.Columns.Add("QtyForLastInspection", typeof(long));
            dtInspectStandards.Columns.Add("FullInspection", typeof(bool));
            dtInspectStandards.Columns.Add("Reference", typeof(bool));
            grdInspectStandards.DataSource = dtInspectStandards;

            GetStandardList();
            GetCriterionList();
        }

        /// <summary>
        /// 获取标准项列表
        /// </summary>
        private void GetStandardList()
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
                List<SubTreeLeaf> standardItems = new List<SubTreeLeaf>();

                WriteLog.Instance.Write("获取质量标准项列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleSubtreeLeaves(
                    IRAPUser.Instance.CommunityID,
                    20,
                    5094,   // 质量标准
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref standardItems,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    for (int i = standardItems.Count - 1; i >= 0; i--)
                        if (standardItems[i].LeafStatus != 0)
                            standardItems.Remove(standardItems[i]);
                    riluStandardName.DataSource = standardItems;
                }

                riluStandardName.DisplayMember = "NodeName";
                riluStandardName.ValueMember = "LeafID";
                riluStandardName.NullText = "";
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

        private void GetCriterionList()
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

        public override void GetProperties(int t102LeafID, int t216LeafID)
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

                #region 获取产品与工序的关联ID
                IRAPMDMClient.Instance.ufn_GetMethodID(
                    IRAPUser.Instance.CommunityID,
                    t102LeafID,
                    216,
                    t216LeafID,
                    IRAPUser.Instance.SysLogID,
                    ref c64ID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                #endregion

                if (c64ID == 0)
                {
                    XtraMessageBox.Show(
                        "当前产品和工序的关联未生成！",
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    List<InspectionStandard> standards = new List<InspectionStandard>();

                    #region 获取指定产品和工序所对应的质量检查标准
                    IRAPMDMClient.Instance.ufn_GetList_InspectionStandard(
                        IRAPUser.Instance.CommunityID,
                        t102LeafID,
                        t216LeafID,
                        "",
                        IRAPUser.Instance.SysLogID,
                        ref standards,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    if (dtInspectStandards != null)
                    {
                        foreach (InspectionStandard standard in standards)
                        {
                            dtInspectStandards.Rows.Add(new object[]
                            {
                                standard.Ordinal,
                                standard.T20LeafID,
                                standard.ParameterName,
                                standard.LowLimit,
                                standard.Criterion,
                                standard.HighLimit,
                                standard.Scale,
                                standard.UnitOfMeasure,
                                standard.QtyForFirstInspection,
                                standard.QtyForInProcessInspection,
                                standard.InProcessInspectionBatchSize,
                                standard.QtyForLastInspection,
                                standard.FullInspection,
                                standard.Reference,
                            });
                        }
                    }

                    //for (int i = 0; i < grdvMethodStandards.Columns.Count; i++)
                    //    grdvMethodStandards.Columns[i].BestFit();
                    grdvInspectStandards.BestFitColumns();
                    grdvInspectStandards.LayoutChanged();

                    grdvInspectStandards.OptionsBehavior.Editable = true;
                    grdvInspectStandards.OptionsView.NewItemRowPosition = 
                        DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                    grdInspectStandards.UseEmbeddedNavigator = true;
                    #endregion

                    #region 如果当前显示的数据是模板数据
                    if (standards.Count > 0 && standards[0].Reference)
                    {
                        lblTitle.Text += "（模板数据）";

                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }
                    #endregion
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        protected override string GenerateRSAttrXML()
        {
            string strQualityStandardXML = "";

            int i = 1;
            dtInspectStandards.DefaultView.Sort = "Level asc";
            DataTable dt = dtInspectStandards.Copy();
            dt = dtInspectStandards.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                strQualityStandardXML = strQualityStandardXML +
                    string.Format("<Row RealOrdinal=\"{0}\" T20LeafID=\"{1}\" LowLimit=\"{2}\" " +
                        "Criterion=\"{3}\" HighLimit=\"{4}\" Scale=\"{5}\" UnitOfMeasure=\"{6}\" " +
                        "LeastFirstInspectionQty=\"{7}\" LeastInProcessInspectionQty=\"{8}\" " +
                        "InProcessInspectionFrequency=\"{9}\" LeastFinalInspectionQty=\"{10}\" " +
                        "FullInspection=\"{11}\"/>",
                        i++,
                        dr["T20LeafID"].ToString(),
                        dr["LowLimit"].ToString(),
                        dr["Criterion"].ToString(),
                        dr["HighLimit"].ToString(),
                        dr["Scale"].ToString(),
                        dr["UnitOfMeasure"].ToString(),
                        dr["QtyForFirstInspection"].ToString(),
                        dr["QtyForInProcessInspection"].ToString(),
                        dr["InProcessInspectionBatchSize"].ToString(),
                        dr["QtyForLastInspection"].ToString(),
                        (bool)dr["FullInspection"] ? 1 : 0);
            }

            return string.Format("<RSAttr>{0}</RSAttr>", strQualityStandardXML);
        }

        private void grdvInspectStandards_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvInspectStandards.GetDataRow(e.RowHandle);
            dr["Level"] = dtInspectStandards.Rows.Count + 1;
            dr["T20LeafID"] = 0;
            dr["ParameterName"] = "";
            dr["LowLimit"] = 0;
            dr["Criterion"] = "GELE";
            dr["HighLimit"] = 0;
            dr["Scale"] = 0;
            dr["UnitOfMeasure"] = "";
            dr["QtyForFirstInspection"] = 0;
            dr["QtyForInProcessInspection"] = 0;
            dr["InProcessInspectionBatchSize"] = 0;
            dr["QtyForLastInspection"] = 0;
            dr["FullInspection"] = false;
            dr["Reference"] = false;

            SetEditorMode(true);

            grdvInspectStandards.BestFitColumns();
        }

        private void grdvInspectStandards_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            grdvInspectStandards.BestFitColumns();
            SetEditorMode(true);
        }

        private void grdvInspectStandards_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            grdvInspectStandards.BestFitColumns();
            SetEditorMode(true);
        }
    }
}
