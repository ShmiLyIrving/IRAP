using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.Global.GUI;
using IRAP.Client.Global.GUI.Dialogs;
using IRAP.Client.User;
using IRAP.Entity.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESRMM
{
    public partial class frmMDMInspection_30 : frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<SubTreeLeaf> qualityParams = new List<SubTreeLeaf>();
        private const int nodeID = 5094;

        public frmMDMInspection_30()
        {
            InitializeComponent();

            InitGridView();
            grdQualityParams.DataSource = InitDataTable("QualityParam");
        }

        private void InitGridView()
        {
            grdvQualityParams.OptionsView.ShowGroupPanel = false;
            grdvQualityParams.OptionsView.ShowIndicator = true;
            grdvQualityParams.IndicatorWidth = 40;
            grdvQualityParams.OptionsSelection.MultiSelect = false;
            grdvQualityParams.VertScrollVisibility = ScrollVisibility.Auto;
            grdvQualityParams.HorzScrollVisibility = ScrollVisibility.Never;
            grdvQualityParams.OptionsMenu.EnableColumnMenu = false;
            grdvQualityParams.OptionsBehavior.Editable = false;
            grdvQualityParams.OptionsCustomization.AllowFilter = false;
            grdvQualityParams.OptionsCustomization.AllowSort = false;
            grdvQualityParams.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
        }

        private DataTable InitDataTable(string tableType)
        {
            DataTable dt = new DataTable();
            switch (tableType)
            {
                case "QualityParam":
                    dt.Columns.Add("LeafID", typeof(int));
                    dt.Columns.Add("NodeCode", typeof(string));
                    dt.Columns.Add("NodeName", typeof(string));
                    break;
            }
            return dt;
        }

        private void GetQualityParams()
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                TWaitting.Instance.ShowWaitForm("正在获取质量参数列表");

                DataTable dt = grdQualityParams.DataSource as DataTable;
                dt.Clear();
                qualityParams.Clear();

                int errCode = 0;
                string errText = "";

                WriteLog.Instance.Write("获取质量参数列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleSubtreeLeaves(
                    IRAPUser.Instance.CommunityID,
                    20,
                    nodeID,   // 工艺参数
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref qualityParams,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                if (errCode == 0)
                {
                    // 获取可用的，并且取出重复记录的质量参数列表
                    qualityParams =
                        (from data in qualityParams
                         where data.LeafStatus == 0
                         select data).GroupBy(t=>t.LeafID).Select(t=>t.First()).ToList();

                    foreach (SubTreeLeaf param in qualityParams)
                    {
                        dt.Rows.Add(new object[]
                            {
                                param.LeafID,
                                param.NodeCode,
                                param.NodeName,
                            });
                    }
                }
                else
                {
                    grdQualityParams.DataSource = null;
                    XtraMessageBox.Show(errText, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private int FindNodeCodeInList(string nodeCode, List<SubTreeLeaf> leaves)
        {
            if (nodeCode == "")
                return -1;

            int rlt = -1;
            for (int i = 0; i < leaves.Count; i++)
            {
                if (leaves[i].NodeCode == nodeCode)
                {
                    rlt = i;
                    break;
                }
            }
            return rlt;
        }

        private int FindNodeNameInList(string nodeName, List<SubTreeLeaf> leaves)
        {
            int rlt = -1;
            for (int i = 0; i < leaves.Count; i++)
            {
                if (leaves[i].NodeName == nodeName)
                {
                    rlt = i;
                    break;
                }
            }
            return rlt;
        }

        private void frmMDMInspection_30_Shown(object sender, EventArgs e)
        {
            GetQualityParams();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (frmSubTreeLeafEditor editor = new frmSubTreeLeafEditor(nodeID))
            {
                while (editor.ShowDialog() == DialogResult.OK)
                {
                    #region 检查代码和名称是否有重复
                    if (FindNodeCodeInList(editor.NodeCode, qualityParams) != -1)
                    {
                        XtraMessageBox.Show(
                            "质量参数代码重复，请重新输入！", 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        continue;
                    }
                    if (editor.NodeName == "")
                    {
                        XtraMessageBox.Show(
                            "质量参数名称不能空白！", 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        continue;
                    }
                    if (FindNodeNameInList(editor.NodeName, qualityParams) != -1)
                    {
                        XtraMessageBox.Show(
                            "质量参数名称重复，请重新输入！", 
                            "系统信息", 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        continue;
                    }
                    #endregion

                    string strProcedureName = 
                        string.Format(
                            "{0}.{1}", 
                            className, 
                            MethodBase.GetCurrentMethod().Name);
                    WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                    try
                    {
                        TWaitting.Instance.ShowWaitForm("");

                        int errCode = 0;
                        string errText = "";

                        IRAPMESRMMClient.Instance.ssp_SaveADU_Parameters(
                            IRAPUser.Instance.CommunityID,
                            "A",
                            nodeID,
                            0,
                            editor.NodeCode,
                            editor.NodeName,
                            IRAPUser.Instance.SysLogID,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("({0}){1}", errCode, errText), 
                            strProcedureName);

                        if (errCode == 0)
                        {
                            XtraMessageBox.Show(
                                errText, 
                                "系统信息", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Asterisk);
                            break;
                        }
                        else
                            XtraMessageBox.Show(
                                errText, 
                                "系统信息", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                    }
                    finally
                    {
                        TWaitting.Instance.CloseWaitForm();

                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                }
            }

            GetQualityParams();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (frmSubTreeLeafEditor editor = new frmSubTreeLeafEditor(nodeID))
            {
                int index = grdvQualityParams.GetFocusedDataSourceRowIndex();
                if (index < 0 || index >= qualityParams.Count)
                    return;

                editor.NodeCode = qualityParams[index].NodeCode;
                editor.NodeName = qualityParams[index].NodeName;

                while (editor.ShowDialog() == DialogResult.OK)
                {
                    #region 检查代码和名称是否有重复
                    int i;
                    i = FindNodeCodeInList(editor.NodeCode, qualityParams);
                    if (i != -1 && qualityParams[i].LeafID != qualityParams[index].LeafID)
                    {
                        XtraMessageBox.Show(
                            "质量参数代码重复，请重新输入！",
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        continue;
                    }
                    if (editor.NodeName == "")
                    {
                        XtraMessageBox.Show(
                            "质量参数名称不能空白！",
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        continue;
                    }
                    i = FindNodeNameInList(editor.NodeName, qualityParams);
                    if (i != -1 && qualityParams[i].LeafID != qualityParams[index].LeafID)
                    {
                        XtraMessageBox.Show(
                            "质量参数名称重复，请重新输入！", 
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        continue;
                    }
                    #endregion

                    string strProcedureName = 
                        string.Format(
                            "{0}.{1}", 
                            className, 
                            MethodBase.GetCurrentMethod().Name);
                    WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                    try
                    {
                        TWaitting.Instance.ShowWaitForm("");

                        int errCode = 0;
                        string errText = "";

                        IRAPMESRMMClient.Instance.ssp_SaveADU_Parameters(
                            IRAPUser.Instance.CommunityID,
                            "U",
                            nodeID,
                            qualityParams[index].LeafID,
                            editor.NodeCode,
                            editor.NodeName,
                            IRAPUser.Instance.SysLogID,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("({0}){1}", errCode, errText),
                            strProcedureName);

                        if (errCode == 0)
                        {
                            XtraMessageBox.Show(
                                errText, 
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
                            break;
                        }
                        else
                            XtraMessageBox.Show(
                                errText, 
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                    finally
                    {
                        TWaitting.Instance.CloseWaitForm();

                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                }
            }

            GetQualityParams();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = grdvQualityParams.GetFocusedDataSourceRowIndex();
            if (index >= 0 && index < qualityParams.Count)
            {
                if (XtraMessageBox.Show(
                    string.Format(
                        "请确定是否要删除【[{0}]{1}】？",
                        qualityParams[index].NodeCode,
                        qualityParams[index].NodeName),
                    "系统信息",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string strProcedureName = 
                        string.Format("{0}.{1}",
                        className, 
                        MethodBase.GetCurrentMethod().Name);
                    WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                    try
                    {
                        TWaitting.Instance.ShowWaitForm("");

                        int errCode = 0;
                        string errText = "";

                        IRAPMESRMMClient.Instance.ssp_SaveADU_Parameters(
                            IRAPUser.Instance.CommunityID,
                            "D",
                            nodeID,
                            qualityParams[index].LeafID,
                            qualityParams[index].NodeCode,
                            qualityParams[index].NodeName,
                            IRAPUser.Instance.SysLogID,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("({0}){1}", errCode, errText), 
                            strProcedureName);

                        if (errCode == 0)
                        {
                            XtraMessageBox.Show(
                                errText,
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
                        }
                        else
                            XtraMessageBox.Show(
                                errText, 
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                    finally
                    {
                        TWaitting.Instance.CloseWaitForm();

                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                }
            }

            GetQualityParams();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetQualityParams();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            int index = grdvQualityParams.GetFocusedDataSourceRowIndex();
            if (index < 0 || index >= qualityParams.Count)
            {
                tsmiEdit.Enabled = false;
                tsmiDelete.Enabled = false;
            }
            else
            {
                tsmiEdit.Enabled = true;
                tsmiEdit.Enabled = true;
            }
        }
    }
}
