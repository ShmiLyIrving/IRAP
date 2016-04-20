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
    public partial class frmPokaYokeRuleProperties : IRAP.Client.GUI.MDM.frmCustomProperites
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtStandards = null;

        public frmPokaYokeRuleProperties()
        {
            InitializeComponent();

            dtStandards = new DataTable();
            dtStandards.Columns.Add("Level", typeof(int));
            dtStandards.Columns.Add("T230LeafID", typeof(int));
            dtStandards.Columns.Add("ControlLevel", typeof(int));
            dtStandards.Columns.Add("ControlLimit_Low", typeof(long));
            dtStandards.Columns.Add("ControlLimit_High", typeof(long));
            dtStandards.Columns.Add("UnitOfMeasure", typeof(string));
            dtStandards.Columns.Add("Reference", typeof(bool));
            grdStandards.DataSource = dtStandards;

            GetStandardList();
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
                List<LeafSetEx> rules = new List<LeafSetEx>();

                WriteLog.Instance.Write("获取防错规则列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    230,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref rules,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    riluT230Name.DataSource = rules;
                }
                else
                {
                    riluT230Name.DataSource = null;
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
                    List<PokaYokeRule> standards = new List<PokaYokeRule>();

                    #region 获取指定产品和工序所对应的生产环境参数
                    IRAPMDMClient.Instance.ufn_GetList_PokaYokeRules(
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
                        foreach (PokaYokeRule standard in standards)
                        {
                            dtStandards.Rows.Add(new object[]
                            {
                                standard.Ordinal,
                                standard.T230LeafID,
                                standard.ControlLevel,
                                standard.ControlLimit_Low,
                                standard.ControlLimit_High,
                                standard.UnitOfMeasure,
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
                    string.Format("<Row RealOrdinal=\"{0}\" T230LeafID=\"{1}\" ControlLevel=\"{2}\" " +
                        "ControlLimit_Low=\"{3}\" ControlLimit_High=\"{4}\" UnitOfMeasure=\"{5}\"/>",
                        i++,
                        dr["T230LeafID"].ToString(),
                        dr["ControlLevel"].ToString(),
                        dr["ControlLimit_Low"].ToString(),
                        dr["ControlLimit_High"].ToString(),
                        dr["UnitOfMeasure"].ToString());
            }

            return string.Format("<RSAttr>{0}</RSAttr>", strStandardXML);
        }

        private void grdvStandards_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvStandards.GetDataRow(e.RowHandle);
            dr["Level"] = dtStandards.Rows.Count + 1;
            dr["T230LeafID"] = 0;
            dr["ControlLevel"] = 0;
            dr["ControlLimit_Low"] = 0;
            dr["ControlLimit_High"] = 0;
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
