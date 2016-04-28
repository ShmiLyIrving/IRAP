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
    public partial class frmMethodDocumentProperties : IRAP.Client.GUI.MDM.frmCustomProperites
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtStandards = null;

        public frmMethodDocumentProperties()
        {
            InitializeComponent();

            dtStandards = new DataTable();
            dtStandards.Columns.Add("Level", typeof(int));
            dtStandards.Columns.Add("T186LeafID", typeof(int));
            dtStandards.Columns.Add("FileName", typeof(string));
            dtStandards.Columns.Add("FileSize", typeof(int));
            dtStandards.Columns.Add("VersionNo", typeof(int));
            dtStandards.Columns.Add("ECorAlertCtrlNo", typeof(string));
            dtStandards.Columns.Add("ApprovedBy1", typeof(string));
            dtStandards.Columns.Add("ApprovedBy2", typeof(string));
            dtStandards.Columns.Add("ApprovedBy3", typeof(string));
            dtStandards.Columns.Add("FileContent", typeof(string));
            dtStandards.Columns.Add("Reference", typeof(bool));
            grdStandards.DataSource = dtStandards;

            GetT186List();
        }

        private void GetT186List()
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
                List<LeafSetEx> standardItems = new List<LeafSetEx>();

                WriteLog.Instance.Write("获取文档类型列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    186,
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
                    risluT186LeafID.DataSource = standardItems;
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
            return base.GenerateRSAttrXML();
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
                    //IRAPMDMClient.Instance.ufn_GetList_MethodStandard(
                    //    IRAPUser.Instance.CommunityID,
                    //    t102LeafID,
                    //    t216LeafID,
                    //    "",
                    //    IRAPUser.Instance.SysLogID,
                    //    ref standards,
                    //    out errCode,
                    //    out errText);
                    //WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    //if (dtMethodStandards != null)
                    //{
                    //    foreach (MethodStandard methodStandard in standards)
                    //    {
                    //        dtMethodStandards.Rows.Add(new object[]
                    //        {
                    //            methodStandard.Ordinal,
                    //            methodStandard.T20LeafID,
                    //            methodStandard.ParameterName,
                    //            methodStandard.LowLimit,
                    //            methodStandard.Criterion,
                    //            methodStandard.HighLimit,
                    //            methodStandard.Scale,
                    //            methodStandard.UnitOfMeasure,
                    //            methodStandard.RecordingMode,
                    //            methodStandard.SamplingCycle,
                    //            methodStandard.RTDBDSLinkID,
                    //            methodStandard.RTDBTagName,
                    //            methodStandard.Reference,
                    //        });
                    //    }
                    //}

                    //for (int i = 0; i < grdvMethodStandards.Columns.Count; i++)
                    //    grdvMethodStandards.Columns[i].BestFit();
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

        private void grdvStandards_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvStandards.GetDataRow(e.RowHandle);
            dr["Level"] = dtStandards.Rows.Count + 1;
            dr["T186LeafID"] = 0;
            dr["FileName"] = "";
            dr["FileSize"] = 0;
            dr["VersionNo"] = 0;
            dr["ECorAlertCtrlNo"] = "";
            dr["ApprovedBy1"] = "";
            dr["ApprovedBy2"] = "";
            dr["ApprovedBy3"] = "";
            dr["FileContent"] = "";
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

        private void ribeFileName_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = grdvStandards.GetFocusedDataRow();
                if (dr == null)
                {
                    grdvStandards.AddNewRow();
                    dr = grdvStandards.GetFocusedDataRow();
                }

                dr["FileName"] = openFileDialog.FileName;
                grdvStandards.LayoutChanged();

                grdvStandards.BestFitColumns();
            }
        }
    }
}
