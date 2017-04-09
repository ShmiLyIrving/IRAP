using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Client.SubSystem;
using IRAP.Entities.MES;
using IRAP.Entities.MDM;
using IRAP.Entity.Kanban;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.Dialogs
{
    public partial class frmRepairItemEditor : IRAP.Client.Global.frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private Global.Enums.EditStatus editStatus;

        private string caption = "";
        private string cultureName = "";

        private DataTable dtSymbols = null;
        private List<FailureMode> failureModes = null;
        private List<DefectRootCause> defectRootCauses = null;
        private List<LeafSetEx> failureNatures = null;
        private List<LeafSetEx> failureDuties = null;
        private List<LeafSetEx> repairModes = null;

        private SubWIPIDCode_TSItem item = new SubWIPIDCode_TSItem() { SKUID1 = "", SKUID2 = "", };
        private string wipCode = "";

        public frmRepairItemEditor()
        {
            InitializeComponent();

            cultureName = Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToUpper();
            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System tips";
            else
                caption = "系统信息";
        }

        public frmRepairItemEditor(Global.Enums.EditStatus editStatus) : 
            this()
        {
            this.editStatus = editStatus;

            sccMain.Panel1.Text =
                string.Format(
                    sccMain.Panel1.Text,
                    EnumHelper.GetDescription(editStatus));
        }

        /// <summary>
        /// 子在制品代码
        /// </summary>
        public string WIPCode
        {
            get { return wipCode; }
            set { wipCode = value; }
        }

        /// <summary>
        /// 器件位号列表和物料列表
        /// </summary>
        public DataTable Symbols
        {
            get { return dtSymbols; }
            set
            {
                dtSymbols = value;

                cboSymbol.Properties.Items.Clear();
                foreach (DataRow dr in dtSymbols.Rows)
                {
                    if (dr["ItemName"].ToString() != "")
                        cboSymbol.Properties.Items.Add(dr["ItemName"].ToString());
                }
            }
        }

        /// <summary>
        /// 失效模式列表
        /// </summary>
        public List<FailureMode> FailureModes
        {
            get { return failureModes; }
            set
            {
                failureModes = value;

                foreach (FailureMode mode in failureModes)
                {
                    cboT118LeafID.Properties.Items.Add(mode.FailureCode);
                }

                if (failureModes.Count == 1)
                {
                    cboT118LeafID.Text = failureModes[0].FailureCode;
                    lblT118Name.Text = failureModes[0].FailureName;
                    item.T118LeafID = failureModes[0].FailureLeaf;

                    cboT118LeafID.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 根源工序列表
        /// </summary>
        public List<DefectRootCause> DefectRootCauses
        {
            get { return defectRootCauses; }
            set
            {
                defectRootCauses = value;

                foreach (DefectRootCause cause in defectRootCauses)
                {
                    cboT216LeafID.Properties.Items.Add(cause.OperationCode);
                }

                if (defectRootCauses.Count == 1)
                {
                    cboT216LeafID.Text = defectRootCauses[0].OperationCode;
                    lblT216Name.Text = defectRootCauses[0].OperationName;

                    item.T216LeafID = defectRootCauses[0].OperationLeaf;

                    cboT216LeafID.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 失效性质列表
        /// </summary>
        public List<LeafSetEx> FailureNatures
        {
            get { return failureNatures; }
            set
            {
                failureNatures = value;

                foreach (LeafSetEx item in value)
                {
                    cboT183LeafID.Properties.Items.Add(item.Code);
                }

                if (failureNatures.Count == 1)
                {
                    cboT183LeafID.Text = failureNatures[0].Code;
                    lblT183Name.Text = failureNatures[0].LeafName;

                    item.T183LeafID = failureNatures[0].LeafID;

                    cboT183LeafID.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 失效责任列表
        /// </summary>
        public List<LeafSetEx> FailureDuties
        {
            get { return failureDuties; }
            set
            {
                failureDuties = value;

                foreach (LeafSetEx item in value)
                {
                    cboT184LeafID.Properties.Items.Add(item.Code);
                }

                if (failureDuties.Count == 1)
                {
                    cboT184LeafID.Text = failureDuties[0].Code;
                    lblT184Name.Text = failureDuties[0].LeafName;

                    item.T184LeafID = failureDuties[0].LeafID;

                    cboT184LeafID.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 维修代码
        /// </summary>
        public List<LeafSetEx> RepairModes
        {
            get { return repairModes; }
            set
            {
                repairModes = value;

                foreach (LeafSetEx item in value)
                    cboT119LeafID.Properties.Items.Add(item.Code);
            }
        }

        public SubWIPIDCode_TSItem RepairItem
        {
            get { return item; }
            set
            {
                item = value;

                InitValue(item);
            }
        }

        private void InitValue(SubWIPIDCode_TSItem item)
        {
            #region 设置“器件位号/物料编号”
            if (item.T110LeafID != 0)
            {
                foreach (DataRow dr in dtSymbols.Rows)
                {
                    if ((int)dr["ItemType"] == 110)
                        if ((int)dr["ItemLeaf"] == item.T110LeafID)
                        {
                            cboSymbol.Text = dr["ItemName"].ToString();
                            lblSymbolText.Text = dr["ItemName"].ToString();
                            break;
                        }
                }
            }
            if (item.T101LeafID != 0)
            {
                foreach (DataRow dr in dtSymbols.Rows)
                {
                    if ((int)dr["ItemType"] == 101)
                        if ((int)dr["ItemLeaf"] == item.T101LeafID)
                        {
                            cboSymbol.Text = dr["ItemName"].ToString();
                            lblSymbolText.Text = dr["ItemName"].ToString();
                            break;
                        }
                }
            }
            #endregion

            #region 设置“失效模式”
            foreach (FailureMode mode in failureModes)
            {
                if (mode.FailureLeaf == item.T118LeafID)
                {
                    cboT118LeafID.Text = mode.FailureCode;
                    lblT118Name.Text = mode.FailureName;
                    break;
                }
            }
            #endregion

            #region 设置“失效点数”
            edtFailurePointCount.Text = item.FailurePointCount.ToString();
            #endregion

            #region 设置“根源工序”
            foreach (DefectRootCause cause in defectRootCauses)
            {
                if (cause.OperationLeaf == item.T216LeafID)
                {
                    cboT216LeafID.Text = cause.OperationCode;
                    lblT216Name.Text = cause.OperationName;
                    break;
                }
            }
            #endregion

            #region 设置“失效性质”
            foreach (LeafSetEx leaf in failureNatures)
            {
                if (leaf.LeafID == item.T183LeafID)
                {
                    cboT183LeafID.Text = leaf.Code;
                    lblT183Name.Text = leaf.LeafName;
                    break;
                }
            }
            #endregion

            #region 设置“失效责任”
            foreach (LeafSetEx leaf in failureDuties)
            {
                if (leaf.LeafID == item.T184LeafID)
                {
                    cboT184LeafID.Text = leaf.Code;
                    lblT184Name.Text = leaf.LeafName;
                    break;
                }
            }
            #endregion

            #region 设置“维修代码”
            foreach (LeafSetEx leaf in repairModes)
            {
                if (leaf.LeafID == item.T119LeafID)
                {
                    cboT119LeafID.Text = leaf.Code;
                    lblT119Name.Text = leaf.LeafName;
                    break;
                }
            }
            #endregion

            #region 设置“追溯参考值”
            edtTrackReferenceValue.Text = item.TrackReferenceValue;
            #endregion
        }

        private void frmRepairItemEditor_Load(object sender, EventArgs e)
        {
            switch (IRAPUser.Instance.CommunityID)
            {
                case 60013:
                    lblT118LeafID.Text = "不良现象";
                    lblT216LeafID.Visible = false;
                    lblT183LeafID.Text = "责任区分";
                    lblT184LeafID.Text = "责任部门";
                    lblTrackReferenceValue.Visible = false;
                    break;
            }
        }

        private void edtSymbol_Enter(object sender, EventArgs e)
        {
            ((TextEdit)sender).SelectAll();
        }

        private void edtSymbol_Validating(object sender, CancelEventArgs e)
        {
            if (cboSymbol.Text.Trim() == "")
            {
                lblSymbolText.Text = "";
                item.T110LeafID = 0;
                item.T101LeafID = 0;
                e.Cancel = false;
                return;
            }

            if (dtSymbols == null || dtSymbols.Rows.Count == 0)
            {
                cboSymbol.Text = "";

                lblSymbolText.Text = "系统未配置当前产品的器件位号列表和物料列表！";
                lblSymbolText.ForeColor = Color.Red;

                item.T110LeafID = 0;
                item.T101LeafID = 0;
                e.Cancel = false;
                return;
            }

            foreach (DataRow dr in dtSymbols.Rows)
            {
                if (dr["ItemName"].ToString() == cboSymbol.Text)
                {
                    switch ((int)dr["ItemType"])
                    {
                        case 110:
                            item.T110LeafID = (int)dr["ItemLeaf"];
                            break;
                        default:
                            item.T101LeafID = (int)dr["ItemLeaf"];
                            break;
                    }

                    lblSymbolText.Text = dr["ItemName"].ToString();
                    lblSymbolText.ForeColor = Color.Blue;
                    e.Cancel = false;
                    return;
                }
            }

            IRAPMessageBox.Instance.ShowErrorMessage(
                string.Format(
                    "没有找到[{0}]的器件位号或者物料号！",
                    cboSymbol.Text),
                caption);
            cboSymbol.Text = "";
            lblSymbolText.Text = "";
            e.Cancel = true;
        }

        private void edtT118LeafID_Validating(object sender, CancelEventArgs e)
        {
            if (cboT118LeafID.Text.Trim() == "")
            {
                lblT118Name.Text = "";
                item.T118LeafID = 0;
                e.Cancel = false;
                return;
            }

            if (failureModes.Count == 0)
            {
                cboT118LeafID.Text = "";

                lblT118Name.Text = string.Format("未配置{0}！", lblT118LeafID.Text);
                lblT118Name.ForeColor = Color.Red;

                item.T118LeafID = 0;

                e.Cancel = false;
                return;
            }

            foreach (FailureMode failure in failureModes)
            {
                if (failure.FailureCode == cboT118LeafID.Text)
                {
                    item.T118LeafID = failure.FailureLeaf;

                    lblT118Name.Text = failure.FailureName;
                    lblT118Name.ForeColor = Color.Blue;

                    e.Cancel = false;
                    return;
                }
            }

            IRAPMessageBox.Instance.ShowErrorMessage(
                string.Format(
                    "没有找到[{0}]{1}代码",
                    cboT118LeafID.Text,
                    lblT118LeafID.Text),
                caption);
            cboT118LeafID.Text = "";
            lblT118Name.Text = "";
            e.Cancel = true;
        }

        private void edtFailurePointCount_Validating(object sender, CancelEventArgs e)
        {
            if (edtFailurePointCount.Text.Trim() == "")
            {
                edtFailurePointCount.Text = "0";
                item.FailurePointCount = 0;
                e.Cancel = false;
                return;
            }

            int failPointCount = 0;
            if (int.TryParse(edtFailurePointCount.Text, out failPointCount))
            {
                item.FailurePointCount = failPointCount;
                e.Cancel = false;
            }
            else
            {
                item.FailurePointCount = 0;

                edtFailurePointCount.Text = "0";
                e.Cancel = true;
            }
        }

        private void edtT216LeafID_Validating(object sender, CancelEventArgs e)
        {
            if (cboT216LeafID.Text.Trim() == "")
            {
                lblT216Name.Text = "";
                item.T216LeafID = 0;
                e.Cancel = false;
                return;
            }

            if (DefectRootCauses.Count == 0)
            {
                cboT216LeafID.Text = "";

                lblT216Name.Text = string.Format("未配置{0}！", lblT216LeafID.Text);
                lblT216Name.ForeColor = Color.Red;

                item.T216LeafID = 0;

                e.Cancel = false;
                return;
            }

            foreach (DefectRootCause rootCause in defectRootCauses)
            {
                if (rootCause.OperationCode == cboT216LeafID.Text)
                {
                    item.T216LeafID = rootCause.OperationLeaf;

                    lblT216Name.Text = rootCause.OperationName;
                    lblT216Name.ForeColor = Color.Blue;

                    e.Cancel = false;
                    return;
                }
            }

            IRAPMessageBox.Instance.ShowErrorMessage(
                string.Format(
                    "没有找到[{0}]{1}代码",
                    cboT216LeafID.Text,
                    lblT216LeafID.Text),
                caption);
            cboT216LeafID.Text = "";
            lblT216Name.Text = "";
            e.Cancel = true;
        }

        private void edtT183LeafID_Validating(object sender, CancelEventArgs e)
        {
            if (cboT183LeafID.Text.Trim() == "")
            {
                lblT183Name.Text = "";
                item.T183LeafID = 0;
                e.Cancel = false;
                return;
            }

            if (failureNatures.Count == 0)
            {
                cboT183LeafID.Text = "";

                lblT183Name.Text = string.Format("未配置{0}！", lblT183LeafID.Text);
                lblT183Name.ForeColor = Color.Red;

                item.T183LeafID = 0;

                e.Cancel = false;
                return;
            }

            foreach (LeafSetEx nature in failureNatures)
            {
                if (nature.Code == cboT183LeafID.Text)
                {
                    item.T183LeafID = nature.LeafID;

                    lblT183Name.Text = nature.LeafName;
                    lblT183Name.ForeColor = Color.Blue;

                    e.Cancel = false;
                    return;
                }
            }

            IRAPMessageBox.Instance.ShowErrorMessage(
                string.Format(
                    "没有找到[{0}]{1}代码",
                    cboT183LeafID.Text,
                    lblT183LeafID.Text),
                caption);
            cboT183LeafID.Text = "";
            lblT183Name.Text = "";
            e.Cancel = true;
        }

        private void edtT184LeafID_Validating(object sender, CancelEventArgs e)
        {
            if (cboT184LeafID.Text.Trim() == "")
            {
                lblT184Name.Text = "";
                item.T184LeafID = 0;
                e.Cancel = false;
                return;
            }

            if (failureNatures.Count == 0)
            {
                cboT184LeafID.Text = "";

                lblT184Name.Text = string.Format("未配置{0}！", lblT184LeafID.Text);
                lblT184Name.ForeColor = Color.Red;

                item.T184LeafID = 0;

                e.Cancel = false;
                return;
            }

            foreach (LeafSetEx duty in failureDuties)
            {
                if (duty.Code == cboT184LeafID.Text)
                {
                    item.T184LeafID = duty.LeafID;

                    lblT184Name.Text = duty.LeafName;
                    lblT184Name.ForeColor = Color.Blue;

                    e.Cancel = false;
                    return;
                }
            }

            IRAPMessageBox.Instance.ShowErrorMessage(
                string.Format(
                    "没有找到[{0}]{1}代码",
                    cboT184LeafID.Text,
                    lblT184LeafID.Text),
                caption);
            cboT184LeafID.Text = "";
            lblT184Name.Text = "";
            e.Cancel = true;
        }

        private void edtT119LeafID_Validating(object sender, CancelEventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            if (cboT119LeafID.Text.Trim() == "")
            {
                lblT119Name.Text = "";
                item.T119LeafID = 0;
                e.Cancel = false;
                return;
            }

            if (failureNatures.Count == 0)
            {
                cboT119LeafID.Text = "";

                lblT119Name.Text = string.Format("未配置{0}！", lblT119LeafID.Text);
                lblT119Name.ForeColor = Color.Red;

                item.T119LeafID = 0;

                e.Cancel = false;
                return;
            }

            foreach (LeafSetEx repairMode in repairModes)
            {
                if (repairMode.Code == cboT119LeafID.Text)
                {
                    item.T119LeafID = repairMode.LeafID;

                    lblT119Name.Text = repairMode.LeafName;
                    lblT119Name.ForeColor = Color.Blue;

                    #region 
                    if (item.T119LeafID == 10700)
                    {
                        WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                        try
                        {
                            int errCode = 0;
                            string errText = "";
                            string skuID = "";

                            #region 获取更换后的 SKUID
                            IRAPMESTSClient.Instance.ufn_GetFIFOSKUIDinTSSite(
                                IRAPUser.Instance.CommunityID,
                                CurrentOptions.Instance.OptionOne.T107LeafID,
                                item.T101LeafID,
                                IRAPUser.Instance.SysLogID,
                                ref skuID,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(
                                string.Format("({0}){1}", errCode, errText),
                                strProcedureName);
                            if (errCode != 0)
                            {
                                XtraMessageBox.Show(
                                    errText,
                                    caption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                e.Cancel = true;
                                return;
                            }
                            else
                            {
                                if (skuID == "")
                                {
                                    XtraMessageBox.Show(
                                        "维修库位没有可用库存，请先进行维修领料！",
                                        caption,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);

                                    e.Cancel = true;
                                    return;
                                }
                                else
                                {
                                    item.SKUID2 = skuID;
                                }
                            }
                            #endregion

                            #region 获取原物料的 SKUID
                            IRAPMESTSClient.Instance.ufn_GetMaterialSKUIDBySymbol(
                                IRAPUser.Instance.CommunityID,
                                wipCode,
                                item.T110LeafID,
                                item.T101LeafID,
                                IRAPUser.Instance.SysLogID,
                                ref skuID,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(
                                string.Format("({0}){1}", errCode, errText),
                                strProcedureName);
                            if (errCode != 0)
                            {
                                XtraMessageBox.Show(
                                    errText,
                                    caption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                e.Cancel = true;
                                return;
                            }
                            else
                            {
                                item.SKUID1 = skuID;
                            }
                            #endregion
                        }
                        finally
                        {
                            WriteLog.Instance.WriteEndSplitter(strProcedureName);
                        }
                    }
                    #endregion

                    e.Cancel = false;
                    return;
                }
            }

            IRAPMessageBox.Instance.ShowErrorMessage(
                string.Format(
                    "没有找到[{0}]{1}代码",
                    cboT119LeafID.Text,
                    lblT119LeafID.Text),
                caption);
            cboT119LeafID.Text = "";
            lblT119Name.Text = "";
            e.Cancel = true;
        }

        private void edtTrackReferenceValue_Validating(object sender, CancelEventArgs e)
        {
            item.TrackReferenceValue = edtTrackReferenceValue.Text;
            e.Cancel = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (item.T110LeafID == 0 && item.T101LeafID == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    string.Format(
                        "[{0}]未输入！",
                        lblSymbolText.Text));
                cboSymbol.Focus();
                return;
            }
            if (item.T118LeafID == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    string.Format(
                        "[{0}]未输入！",
                        lblT118LeafID.Text));
                cboT118LeafID.Focus();
                return;
            }
            if (item.T216LeafID == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    string.Format(
                        "[{0}]未输入！",
                        lblT216LeafID.Text));
                cboT216LeafID.Focus();
                return;
            }
            if (item.T183LeafID == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    string.Format(
                        "[{0}]未输入！",
                        lblT183LeafID.Text));
                cboT183LeafID.Focus();
                return;
            }
            if (item.T184LeafID == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    string.Format(
                        "[{0}]未输入！",
                        lblT184LeafID.Text));
                cboT184LeafID.Focus();
                return;
            }
            if (item.T119LeafID == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    string.Format(
                        "[{0}]未输入！",
                        lblT119LeafID.Text));
                cboT119LeafID.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
