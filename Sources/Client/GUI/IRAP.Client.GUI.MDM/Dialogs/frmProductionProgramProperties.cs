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
    public partial class frmProductionProgramProperties : IRAP.Client.GUI.MDM.frmCustomProperites
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtPrograms = null;

        public frmProductionProgramProperties()
        {
            InitializeComponent();

            dtPrograms = new DataTable();
            dtPrograms.Columns.Add("Level", typeof(int));
            dtPrograms.Columns.Add("T200LeafID", typeof(int));
            dtPrograms.Columns.Add("FlexibleLoaded", typeof(bool));
            dtPrograms.Columns.Add("PokaYokeRequired", typeof(bool));
            dtPrograms.Columns.Add("Reference", typeof(bool));
            grdProductionPrograms.DataSource = dtPrograms;

            risluPrograms.DisplayMember = "Name";
            risluPrograms.ValueMember = "LeafID";
            risluPrograms.NullText = "";

            GetProgramList();
        }

        private void GetProgramList()
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

                WriteLog.Instance.Write("获取生产程序列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    200,
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
                    risluPrograms.DataSource = programItems;
                }
                else
                {
                    risluPrograms.DataSource = null;
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

        /// <summary>
        /// 根据 T102LeafID 和 T216LeafID 获取行集属性值
        /// </summary>
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
                dtPrograms.Clear();

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
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
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
                    List<ProductionPrograms> datas = new List<ProductionPrograms>();

                    #region 获取指定产品和工序所对应的工装标准
                    IRAPMDMClient.Instance.ufn_GetList_ProductionPrograms(
                        IRAPUser.Instance.CommunityID,
                        t102LeafID,
                        t216LeafID,
                        "",
                        IRAPUser.Instance.SysLogID,
                        ref datas,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    if (dtPrograms != null)
                    {
                        foreach (ProductionPrograms data in datas)
                        {
                            dtPrograms.Rows.Add(new object[]
                            {
                                data.Ordinal,
                                data.T200LeafID,
                                data.FlexibleLoaded,
                                data.PokaYokeRequired,
                                data.Reference,
                            });
                        }
                    }
                    for (int i = 0; i < grdvProductionPrograms.Columns.Count; i++)
                    {
                        if (grdvProductionPrograms.Columns[i].Visible)
                            grdvProductionPrograms.Columns[i].BestFit();
                    }
                    grdvProductionPrograms.LayoutChanged();

                    grdvProductionPrograms.OptionsBehavior.Editable = true;
                    grdvProductionPrograms.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                    grdProductionPrograms.UseEmbeddedNavigator = true;
                    #endregion

                    #region 如果当前显示的数据是模板数据
                    if (datas.Count > 0 && datas[0].Reference)
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
            string strMethodStandardXML = "";

            int i = 1;
            dtPrograms.DefaultView.Sort = "Level asc";
            DataTable dt = dtPrograms.Copy();
            dt = dtPrograms.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                strMethodStandardXML = strMethodStandardXML +
                    string.Format("<Row RealOrdinal=\"{0}\" T200LeafID=\"{1}\" FlexibleLoaded=\"{2}\" " +
                        "PokaYokeRequired=\"{3}\"/>",
                        i++,
                        dr["T200LeafID"].ToString(),
                        (bool)dr["FlexibleLoaded"] ? "1" : "0",
                        (bool)dr["PokaYokeRequired"] ? "1" : "0");
            }

            return string.Format("<RSAttr>{0}</RSAttr>", strMethodStandardXML);
        }

        private void grdvProductionPrograms_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvProductionPrograms.GetDataRow(e.RowHandle);
            dr["Level"] = dtPrograms.Rows.Count + 1;
            dr["T200LeafID"] = 0;
            dr["FlexibleLoaded"] = false;
            dr["PokaYokeRequired"] = true;
            dr["Reference"] = false;

            SetEditorMode(true);
        }

        private void grdvProductionPrograms_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            SetEditorMode(true);
        }

        private void grdvProductionPrograms_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            SetEditorMode(true);
        }
    }
}
