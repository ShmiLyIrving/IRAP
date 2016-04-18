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
using IRAP.Entity.MDM;
using IRAP.Entity.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MDM
{
    public partial class frmToolingStandardProperties : frmCustomProperites
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtToolingStandards = null;
        private DataTable dtLifeControlMode = null;

        public frmToolingStandardProperties()
        {
            InitializeComponent();

            dtToolingStandards = new DataTable();
            dtToolingStandards.Columns.Add("Level", typeof(int));
            dtToolingStandards.Columns.Add("T210LeafID", typeof(int));
            dtToolingStandards.Columns.Add("LifeControlMode", typeof(int));
            dtToolingStandards.Columns.Add("LifeLimit", typeof(long));
            dtToolingStandards.Columns.Add("PokaYokeRequired", typeof(bool));
            dtToolingStandards.Columns.Add("Reference", typeof(bool));

            dtLifeControlMode = new DataTable();
            dtLifeControlMode.Columns.Add("ID", typeof(int));
            dtLifeControlMode.Columns.Add("Name", typeof(string));
            dtLifeControlMode.Rows.Add(new object[] { 0, "不控制" });
            dtLifeControlMode.Rows.Add(new object[] { 1, "按时间" });
            dtLifeControlMode.Rows.Add(new object[] { 2, "按产量" });

            risluToolingModelName.DisplayMember = "Name";
            risluToolingModelName.ValueMember = "LeafID";
            risluToolingModelName.NullText = "";

            riluLifeControlMode.DataSource = dtLifeControlMode;
            riluLifeControlMode.DisplayMember = "Name";
            riluLifeControlMode.ValueMember = "ID";
            riluLifeControlMode.NullText = "";

            GetToolingList();

            grdToolingStandards.DataSource = dtToolingStandards;
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
                dtToolingStandards.Clear();

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
                    List<ToolingStandard> standards = new List<ToolingStandard>();

                    #region 获取指定产品和工序所对应的工装标准
                    IRAPMDMClient.Instance.ufn_GetList_ToolingStandard(
                        IRAPUser.Instance.CommunityID,
                        t102LeafID,
                        t216LeafID,
                        "",
                        IRAPUser.Instance.SysLogID,
                        ref standards,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    if (dtToolingStandards != null)
                    {
                        foreach (ToolingStandard standard in standards)
                        {
                            dtToolingStandards.Rows.Add(new object[]
                            {
                                standard.Ordinal,
                                standard.T210LeafID,
                                standard.LifeControlMode,
                                standard.LifeLimit,
                                standard.PokaYokeRequired,
                                standard.Reference,
                            });
                        }
                    }
                    for (int i = 0; i < grdvToolingStandards.Columns.Count; i++)
                    {
                        if (grdvToolingStandards.Columns[i].Visible)
                            grdvToolingStandards.Columns[i].BestFit();
                    }
                    grdvToolingStandards.LayoutChanged();

                    grdvToolingStandards.OptionsBehavior.Editable = true;
                    grdvToolingStandards.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                    grdToolingStandards.UseEmbeddedNavigator = true;
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
        /// 获取工装列表
        /// </summary>
        private void GetToolingList()
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
                List<LeafSetEx> toolingItems = new List<LeafSetEx>();

                WriteLog.Instance.Write("获取工装列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    210,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref toolingItems,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    risluToolingModelName.DataSource = toolingItems;
                }
                else
                {
                    risluToolingModelName.DataSource = null;
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

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            base.btnSave_Click(sender, e);
        }

        protected override string GenerateRSAttrXML()
        {
            string strMethodStandardXML = "";

            int i = 1;
            dtToolingStandards.DefaultView.Sort = "Level asc";
            DataTable dt = dtToolingStandards.Copy();
            dt = dtToolingStandards.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                strMethodStandardXML = strMethodStandardXML +
                    string.Format("<Row RealOrdinal=\"{0}\" T210LeafID=\"{1}\" LifeControlMode=\"{2}\" " +
                        "LifeLimit=\"{3}\" PokaYokeRequired=\"{4}\"/>",
                        i++,
                        dr["T210LeafID"].ToString(),
                        dr["LifeControlMode"].ToString(),
                        dr["LifeLimit"].ToString(),
                        (bool)dr["PokaYokeRequired"] ? "1" : "0");
            }

            return string.Format("<RSAttr>{0}</RSAttr>", strMethodStandardXML);
        }

        private void grdvToolingStandards_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvToolingStandards.GetDataRow(e.RowHandle);
            dr["Level"] = dtToolingStandards.Rows.Count + 1;
            dr["T210LeafID"] = 0;
            dr["LifeControlMode"] = 0;
            dr["LifeLimit"] = 0;
            dr["PokaYokeRequired"] = true;
            dr["Reference"] = false;

            SetEditorMode(true);
        }

        private void grdvToolingStandards_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            SetEditorMode(true);
        }

        private void grdvToolingStandards_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            SetEditorMode(true);
        }
    }
}
