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
    public partial class frmEnergyStandardProperties : IRAP.Client.GUI.MDM.frmCustomProperites
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtStandards = null;

        public frmEnergyStandardProperties()
        {
            InitializeComponent();

            dtStandards = new DataTable();
            dtStandards.Columns.Add("Level", typeof(int));
            dtStandards.Columns.Add("T20LeafID", typeof(int));
            dtStandards.Columns.Add("LowLimit", typeof(int));
            dtStandards.Columns.Add("Criterion", typeof(string));
            dtStandards.Columns.Add("HighLimit", typeof(int));
            dtStandards.Columns.Add("Scale", typeof(int));
            dtStandards.Columns.Add("UnitOfMeasure", typeof(string));
            dtStandards.Columns.Add("RecordingMode", typeof(int));
            dtStandards.Columns.Add("SamplingCycle", typeof(int));
            dtStandards.Columns.Add("Reference", typeof(bool));
            grdStandards.DataSource = dtStandards;


            GetStandardList();
            GetCriterionList();
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

                WriteLog.Instance.Write("获取能源质量参数项列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleSubtreeLeaves(
                    IRAPUser.Instance.CommunityID,
                    20,
                    5419,   // 能源质量参数节点标识
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
                    riluParameterName.DataSource = standardItems;
                }

                riluParameterName.DisplayMember = "NodeName";
                riluParameterName.ValueMember = "LeafID";
                riluParameterName.NullText = "";
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
                    List<EnergyStandard> standards = new List<EnergyStandard>();

                    #region 获取指定产品和工序所对应的能源质量参数
                    IRAPMDMClient.Instance.ufn_GetList_EnergyStandard(
                        IRAPUser.Instance.CommunityID,
                        t102LeafID,
                        t216LeafID,
                        "",
                        IRAPUser.Instance.SysLogID,
                        ref standards,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText), 
                        strProcedureName);

                    if (dtStandards != null)
                    {
                        foreach (EnergyStandard standard in standards)
                        {
                            dtStandards.Rows.Add(new object[]
                            {
                                standard.Ordinal,
                                standard.T20LeafID,
                                standard.ParameterName,
                                standard.LowLimit,
                                standard.Criterion,
                                standard.HighLimit,
                                standard.Scale,
                                standard.UnitOfMeasure,
                                standard.CollectingMode,
                                standard.CollectingCycle,
                                standard.Reference,
                            });
                        }
                    }

                    grdvStandards.BestFitColumns();
                    grdvStandards.LayoutChanged();

                    grdvStandards.OptionsBehavior.Editable = true;
                    grdvStandards.OptionsView.NewItemRowPosition = 
                        DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                    grdStandards.UseEmbeddedNavigator = true;
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
            string strStandardXML = "";

            int i = 1;
            dtStandards.DefaultView.Sort = "Level asc";
            DataTable dt = dtStandards.Copy();
            dt = dtStandards.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                strStandardXML = strStandardXML +
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
                        0,
                        "");
            }

            return string.Format("<RSAttr>{0}</RSAttr>", strStandardXML);
        }

        private void grdvStandards_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvStandards.GetDataRow(e.RowHandle);
            dr["Level"] = dtStandards.Rows.Count + 1;
            dr["T20LeafID"] = 0;
            dr["ParameterName"] = "";
            dr["LowLimit"] = 0;
            dr["Criterion"] = "GELE";
            dr["HighLimit"] = 0;
            dr["Scale"] = 0;
            dr["UnitOfMeasure"] = "";
            dr["RecordingMode"] = 0;
            dr["SamplingCycle"] = 0;
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
