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
    public partial class frmFailureModeProperties : IRAP.Client.GUI.MDM.frmCustomProperites
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtStandards = null;
        private int t216LeafID = 0;

        public frmFailureModeProperties()
        {
            InitializeComponent();

            dtStandards = new DataTable();
            dtStandards.Columns.Add("Level", typeof(int));
            dtStandards.Columns.Add("T118LeafID", typeof(int));
            dtStandards.Columns.Add("Reference", typeof(bool));
            grdStandards.DataSource = dtStandards;

            GetT118List();
        }

        private void GetT118List()
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

                WriteLog.Instance.Write("获取产品失效模式列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    118,
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
                    risluT118LeafID.DataSource = programItems;
                }
                else
                {
                    risluT118LeafID.DataSource = null;
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
                    string.Format("<Row RealOrdinal=\"{0}\" T118LeafID=\"{1}\" T216LeafID=\"{2}\"/>",
                        i++,
                        dr["T118LeafID"].ToString(),
                        dr["T216LeafID"].ToString());
            }

            return string.Format("<RSAttr>{0}</RSAttr>", strStandardXML);
        }

        public override void GetProperties(int t102LeafID, int t216LeafID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            this.t216LeafID = t216LeafID;

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
                    List<FailureModeCore> standards = new List<FailureModeCore>();

                    #region 获取指定产品和工序所对应的工艺标准
                    IRAPMDMClient.Instance.ufn_GetList_FailureModes_Core(
                        IRAPUser.Instance.CommunityID,
                        0,
                        t216LeafID,
                        0,
                        t102LeafID,
                        IRAPUser.Instance.SysLogID,
                        ref standards,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    if (dtStandards != null)
                    {
                        foreach (FailureModeCore standard in standards)
                        {
                            dtStandards.Rows.Add(new object[]
                            {
                                standard.Ordinal,
                                standard.T118LeafID,
                                false,
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
                    btnSave.Enabled = false;
                    #endregion
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void grdvStandards_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvStandards.GetDataRow(e.RowHandle);
            dr["Level"] = dtStandards.Rows.Count + 1;
            dr["T118LeafID"] = 0;
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
