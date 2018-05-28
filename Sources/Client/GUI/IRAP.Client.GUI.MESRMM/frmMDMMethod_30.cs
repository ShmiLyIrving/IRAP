using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global.GUI;
using IRAP.Client.Global.GUI.Dialogs;
using IRAP.Entity.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESRMM
{
    public partial class frmMDMMethod_30 : frmCustomFuncBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<SubTreeLeaf> methodParams = new List<SubTreeLeaf>();
        private const int nodeID = 5140;

        public frmMDMMethod_30()
        {
            InitializeComponent();

            InitGridView();
            grdMethodParams.DataSource = InitDataTable("MethodParam");
        }

        private void GetMethodParams()
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                DataTable dt = grdMethodParams.DataSource as DataTable;
                dt.Clear();
                methodParams.Clear();

                int errCode = 0;
                string errText = "";

                WriteLog.Instance.Write("获取工艺参数列表", strProcedureName);
                IRAPKBClient.Instance.sfn_AccessibleSubtreeLeaves(
                    IRAPUser.Instance.CommunityID,
                    20,
                    nodeID,   // 工艺参数
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref methodParams,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);

                if (errCode == 0)
                {
                    // 获取可用的，并且取出重复记录的质量参数列表
                    methodParams =
                        (from data in methodParams
                         where data.LeafStatus == 0
                         select data).GroupBy(t => t.LeafID).Select(t => t.First()).ToList();

                    foreach (SubTreeLeaf param in methodParams)
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
                    XtraMessageBox.Show(
                        errText, 
                        "系统信息", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(
                    error.Message,
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 初始化 GridConrol
        /// </summary>
        private void InitGridView()
        {
            grdvMethodParams.OptionsView.ShowGroupPanel = false;
            grdvMethodParams.OptionsView.ShowIndicator = true;
            grdvMethodParams.IndicatorWidth = 40;
            grdvMethodParams.OptionsSelection.MultiSelect = false;
            grdvMethodParams.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            grdvMethodParams.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            grdvMethodParams.OptionsMenu.EnableColumnMenu = false;
            grdvMethodParams.OptionsBehavior.Editable = false;
            grdvMethodParams.OptionsCustomization.AllowFilter = false;
            grdvMethodParams.OptionsCustomization.AllowSort = false;
            grdvMethodParams.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private DataTable InitDataTable(string tableType)
        {
            DataTable dt = new DataTable();
            switch (tableType)
            {
                case "MethodParam":
                    dt.Columns.Add("LeafID", typeof(int));
                    dt.Columns.Add("NodeCode", typeof(string));
                    dt.Columns.Add("NodeName", typeof(string));
                    break;
            }
            return dt;
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

        private void frmMDMMethod_30_Shown(object sender, EventArgs e)
        {
            GetMethodParams();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (frmSubTreeLeafEditor editor = new frmSubTreeLeafEditor(nodeID))
            {
                while (editor.ShowDialog() == DialogResult.OK)
                {
                    #region 检查代码和名称是否有重复
                    if (FindNodeCodeInList(editor.NodeCode, methodParams) != -1)
                    {
                        XtraMessageBox.Show(
                            "工艺参数代码重复，请重新输入！",
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        continue;
                    }
                    if (editor.NodeName == "")
                    {
                        XtraMessageBox.Show(
                            "工艺参数名称不能空白！",
                            "系统信息", 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        continue;
                    }
                    if (FindNodeNameInList(editor.NodeName, methodParams) != -1)
                    {
                        XtraMessageBox.Show(
                            "工艺参数名称重复，请重新输入！",
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
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                }
            }

            GetMethodParams();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (frmSubTreeLeafEditor editor = new frmSubTreeLeafEditor(nodeID))
            {
                int index = grdvMethodParams.GetFocusedDataSourceRowIndex();
                if (index < 0 || index >= methodParams.Count)
                    return;

                editor.NodeCode = methodParams[index].NodeCode;
                editor.NodeName = methodParams[index].NodeName;

                while (editor.ShowDialog() == DialogResult.OK)
                {
                    #region 检查代码和名称是否有重复
                    int i;
                    i = FindNodeCodeInList(editor.NodeCode, methodParams);
                    if (i != -1 && methodParams[i].LeafID != methodParams[index].LeafID)
                    {
                        XtraMessageBox.Show(
                            "工艺参数代码重复，请重新输入！", 
                            "系统信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        continue;
                    }
                    if (editor.NodeName == "")
                    {
                        XtraMessageBox.Show(
                            "工艺参数名称不能空白！",
                            "系统信息", 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        continue;
                    }
                    i = FindNodeNameInList(editor.NodeName, methodParams);
                    if (i != -1 && methodParams[i].LeafID != methodParams[index].LeafID)
                    {
                        XtraMessageBox.Show(
                            "工艺参数名称重复，请重新输入！",
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
                        int errCode = 0;
                        string errText = "";

                        IRAPMESRMMClient.Instance.ssp_SaveADU_Parameters(
                            IRAPUser.Instance.CommunityID,
                            "U",
                            nodeID,
                            methodParams[index].LeafID,
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
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                }
            }

            GetMethodParams();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = grdvMethodParams.GetFocusedDataSourceRowIndex();
            if (index >= 0 && index < methodParams.Count)
            {
                if (XtraMessageBox.Show(
                    string.Format(
                        "请确定是否要删除【[{0}]{1}】？", 
                        methodParams[index].NodeCode, 
                        methodParams[index].NodeName),
                    "系统信息",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

                        IRAPMESRMMClient.Instance.ssp_SaveADU_Parameters(
                            IRAPUser.Instance.CommunityID,
                            "D",
                            nodeID,
                            methodParams[index].LeafID,
                            methodParams[index].NodeCode,
                            methodParams[index].NodeName,
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
                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                    }
                }
            }

            GetMethodParams();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetMethodParams();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            int index = grdvMethodParams.GetFocusedDataSourceRowIndex();
            if (index < 0 || index >= methodParams.Count)
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
