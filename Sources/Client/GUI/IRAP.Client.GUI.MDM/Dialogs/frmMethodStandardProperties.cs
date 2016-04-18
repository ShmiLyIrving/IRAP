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
    public partial class frmMethodStandardProperties : IRAP.Client.GUI.MDM.frmCustomProperites
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtMethodStandards = null;
        private DataTable dtRecordingMode = null;

        public frmMethodStandardProperties()
        {
            InitializeComponent();

            dtMethodStandards = new DataTable();
            dtMethodStandards.Columns.Add("Level", typeof(int));
            dtMethodStandards.Columns.Add("T20LeafID", typeof(int));
            dtMethodStandards.Columns.Add("ParameterName", typeof(string));
            dtMethodStandards.Columns.Add("LowLimit", typeof(long));
            dtMethodStandards.Columns.Add("Criterion", typeof(string));
            dtMethodStandards.Columns.Add("HighLimit", typeof(long));
            dtMethodStandards.Columns.Add("Scale", typeof(int));
            dtMethodStandards.Columns.Add("UnitOfMeasure", typeof(string));
            dtMethodStandards.Columns.Add("RecordingMode", typeof(int));
            dtMethodStandards.Columns.Add("SamplingCycle", typeof(long));
            dtMethodStandards.Columns.Add("RTDBDSLinkID", typeof(int));
            dtMethodStandards.Columns.Add("RTDBTagName", typeof(string));
            dtMethodStandards.Columns.Add("Reference", typeof(bool));
            grdMethodStandards.DataSource = dtMethodStandards;

            dtRecordingMode = new DataTable();
            dtRecordingMode.Columns.Add("ID", typeof(int));
            dtRecordingMode.Columns.Add("Name", typeof(string));
            dtRecordingMode.Rows.Add(new object[] { 0, "不采集" });
            dtRecordingMode.Rows.Add(new object[] { 1, "按时间" });
            dtRecordingMode.Rows.Add(new object[] { 2, "按产量" });

            GetStandardList();
            GetCriterionList();

            riluRecordingMode.DataSource = dtRecordingMode;
            riluRecordingMode.DisplayMember = "Name";
            riluRecordingMode.ValueMember = "ID";
            riluRecordingMode.NullText = "";
            riluRecordingMode.Columns.Clear();
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

                WriteLog.Instance.Write("获取工艺标准项列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleSubtreeLeaves(
                    IRAPUser.Instance.CommunityID,
                    20,
                    5140,   // 工艺参数
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
                    List<MethodStandard> standards = new List<MethodStandard>();

                    #region 获取指定产品和工序所对应的工艺标准
                    IRAPMDMClient.Instance.ufn_GetList_MethodStandard(
                        IRAPUser.Instance.CommunityID,
                        t102LeafID,
                        t216LeafID,
                        "",
                        IRAPUser.Instance.SysLogID,
                        ref standards,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    if (dtMethodStandards != null)
                    {
                        foreach (MethodStandard methodStandard in standards)
                        {
                            dtMethodStandards.Rows.Add(new object[]
                            {
                                methodStandard.Ordinal,
                                methodStandard.T20LeafID,
                                methodStandard.ParameterName,
                                methodStandard.LowLimit,
                                methodStandard.Criterion,
                                methodStandard.HighLimit,
                                methodStandard.Scale,
                                methodStandard.UnitOfMeasure,
                                methodStandard.RecordingMode,
                                methodStandard.SamplingCycle,
                                methodStandard.RTDBDSLinkID,
                                methodStandard.RTDBTagName,
                                methodStandard.Reference,
                            });
                        }
                    }

                    //for (int i = 0; i < grdvMethodStandards.Columns.Count; i++)
                    //    grdvMethodStandards.Columns[i].BestFit();
                    grdvMethodStandards.BestFitColumns();
                    grdvMethodStandards.LayoutChanged();

                    grdvMethodStandards.OptionsBehavior.Editable = true;
                    grdvMethodStandards.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                    grdMethodStandards.UseEmbeddedNavigator = true;
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

        /// <summary>
        /// 生成当前产品在当前工序的工艺参数标准行集属性XML串
        /// </summary>
        protected override string GenerateRSAttrXML()
        {
            string strMethodStandardXML = "";

            int i = 1;
            dtMethodStandards.DefaultView.Sort = "Level asc";
            DataTable dt = dtMethodStandards.Copy();
            dt = dtMethodStandards.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                strMethodStandardXML = strMethodStandardXML +
                    string.Format("<Row RealOrdinal=\"{0}\" T20LeafID=\"{1}\" LowLimit=\"{2}\" " +
                        "Criterion=\"{3}\" HighLimit=\"{4}\" Scale=\"{5}\" UnitOfMeasure=\"{6}\" " +
                        "RecordingMode=\"{7}\" SamplingCycle=\"{8}\" RTDBDSLinkID=\"{9}\" " +
                        "RTDBTagName=\"{10}\" />",
                        i++,
                        dr["T20LeafID"].ToString(),
                        dr["LowLimit"].ToString(),
                        dr["Criterion"].ToString(),
                        dr["HighLimit"].ToString(),
                        dr["Scale"].ToString(),
                        dr["UnitOfMeasure"].ToString(),
                        dr["RecordingMode"].ToString(),
                        dr["SamplingCycle"].ToString(),
                        dr["RTDBDSLinkID"].ToString(),
                        dr["RTDBTagName"].ToString());
            }

            return string.Format("<RSAttr>{0}</RSAttr>", strMethodStandardXML);
        }

        private void grdvMethodStandards_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvMethodStandards.GetDataRow(e.RowHandle);
            dr["Level"] = dtMethodStandards.Rows.Count + 1;
            dr["T20LeafID"] = 0;
            dr["ParameterName"] = "";
            dr["LowLimit"] = 0;
            dr["Criterion"] = "GELE";
            dr["HighLimit"] = 0;
            dr["Scale"] = 0;
            dr["UnitOfMeasure"] = "";
            dr["RecordingMode"] = 0;
            dr["SamplingCycle"] = 0;
            dr["RTDBDSLinkID"] = 0;
            dr["RTDBTagName"] = "";
            dr["Reference"] = false;

            SetEditorMode(true);
        }

        private void grdvMethodStandards_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            SetEditorMode(true);
        }

        private void grdvMethodStandards_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            SetEditorMode(true);
        }
    }
}
