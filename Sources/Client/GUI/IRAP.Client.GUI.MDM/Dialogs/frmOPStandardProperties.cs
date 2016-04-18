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
    public partial class frmOPStandardProperties : IRAP.Client.GUI.MDM.frmCustomProperites
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtOPStandards = null;

        public frmOPStandardProperties()
        {
            InitializeComponent();

            dtOPStandards = new DataTable();
            dtOPStandards.Columns.Add("Level", typeof(int));
            dtOPStandards.Columns.Add("StepNo", typeof(int));
            dtOPStandards.Columns.Add("ResourceNo", typeof(int));
            dtOPStandards.Columns.Add("ManOrMachine", typeof(int));
            dtOPStandards.Columns.Add("T112LeafID", typeof(int));
            dtOPStandards.Columns.Add("JobElementDesc", typeof(string));
            dtOPStandards.Columns.Add("StartTimeOffset", typeof(int));
            dtOPStandards.Columns.Add("EndTimeOffset", typeof(int));
            dtOPStandards.Columns.Add("SOPImage", typeof(Image));
            dtOPStandards.Columns.Add("Reference", typeof(bool));
            grdOPStandards.DataSource = dtOPStandards;

            risluT112LeafID.DisplayMember = "Name";
            risluT112LeafID.ValueMember = "LeafID";
            risluT112LeafID.NullText = "";

            GetT112List();
        }

        /// <summary>
        /// 获取动作要素清单
        /// </summary>
        private void GetT112List()
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

                WriteLog.Instance.Write("获取动作要素清单", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    112,
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
                    riluT112LeafID.DataSource = programItems;
                }
                else
                {
                    riluT112LeafID.DataSource = null;
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
                dtOPStandards.Clear();

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
                    List<OPStandard> datas = new List<OPStandard>();

                    #region 获取指定产品和工序所对应的工装标准
                    IRAPMDMClient.Instance.ufn_GetList_SOP(
                        IRAPUser.Instance.CommunityID,
                        t102LeafID,
                        t216LeafID,
                        "",
                        IRAPUser.Instance.SysLogID,
                        ref datas,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                    if (dtOPStandards != null)
                    {
                        foreach (OPStandard data in datas)
                        {
                            dtOPStandards.Rows.Add(new object[]
                            {
                                data.Ordinal,
                                data.StepNo,
                                data.ResourceNo,
                                data.ManOrMachine,
                                data.T112LeafID,
                                data.JobElementDesc,
                                data.StartTimeOffset,
                                data.EndTimeOffset,
                                data.ImageSOPImage,
                                data.Reference,
                            });
                        }
                    }
                    for (int i = 0; i < grdvOPStandards.Columns.Count; i++)
                    {
                        if (grdvOPStandards.Columns[i].Visible)
                            grdvOPStandards.Columns[i].BestFit();
                    }
                    grdvOPStandards.LayoutChanged();

                    grdvOPStandards.OptionsBehavior.Editable = true;
                    grdvOPStandards.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                    grdOPStandards.UseEmbeddedNavigator = true;
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
            dtOPStandards.DefaultView.Sort = "Level asc";
            DataTable dt = dtOPStandards.Copy();
            dt = dtOPStandards.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                #region 将图片转换成 Base64 编码的字符串
                byte[] bufferImage; 
                string buffer = "";
                if (dr["SOPImage"] != DBNull.Value)
                {
                    try
                    {
                        bufferImage = Tools.ImageToBytes((Image)dr["SOPImage"]);
                        buffer = Convert.ToBase64String(bufferImage);
                    }
                    catch
                    {
                        buffer = "";
                    }
                }
                #endregion

                strMethodStandardXML = strMethodStandardXML +
                    string.Format("<Row RealOrdinal=\"{0}\" StepNo=\"{1}\" ResourceNo=\"{2}\" " +
                        "ManOrMachine=\"{3}\" T112LeafID=\"{4}\" JobElementDesc=\"{5}\" " +
                        "StartTimeOffset=\"{6}\" EndTimeOffset=\"{7}\" SOPImage=\"{8}\"/>",
                        i++,
                        dr["StepNo"].ToString(),
                        dr["ResourceNo"].ToString(),
                        dr["ManOrMachine"].ToString(),
                        dr["T112LeafID"].ToString(),
                        dr["JobElementDesc"].ToString(),
                        dr["StartTimeOffset"].ToString(),
                        dr["EndTimeOffset"].ToString(),
                        buffer);
            }

            return string.Format("<RSAttr>{0}</RSAttr>", strMethodStandardXML);
        }

        private void grdvOPStandards_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvOPStandards.GetDataRow(e.RowHandle);
            dr["Level"] = dtOPStandards.Rows.Count + 1;
            dr["StepNo"] = dr["Level"];
            dr["ResourceNo"] = 0;
            dr["ManOrMachine"] = 1;
            dr["T112LeafID"] = 0;
            dr["JobElementDesc"] = "";
            dr["StartTimeOffset"] = 0;
            dr["EndTimeOffset"] = 0;
            dr["SOPImage"] = null;

            SetEditorMode(true);
        }

        private void grdvOPStandards_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            grdvOPStandards.BestFitColumns();
            SetEditorMode(true);
        }

        private void grdvOPStandards_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            grdvOPStandards.BestFitColumns();
            SetEditorMode(true);
        }
    }
}
