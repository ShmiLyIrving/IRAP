using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IRAP.Entities.MDM;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraEditors;
using IRAP.Client.Global.Enums;
using IRAP.Entities.MES;
using System.Reflection;
using IRAP.Global;
using IRAP.WCF.Client.Method;
using IRAP.Client.User;
using System.Xml;

namespace IRAP.Client.GUI.MESPDC.UserControls
{
    public partial class ucPhysicochemicalFurnace : UserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private DataTable dtInspection = new DataTable();
        private string optype;
        private List<SmeltInspectionItem> inspectionItems = new List<SmeltInspectionItem>();
        private OrderInfo pwo;
        private int inspectionidx = 0;

        public string Optype
        {
            get
            {
                return optype;
            }

            set
            {
                optype = value;
            }
        }
        public ucPhysicochemicalFurnace()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 生成理化检验值临时表
        /// </summary>
        /// <param name="items"></param>
        public void InitInspectionItemsGrid(List<SmeltInspectionItem> items)
        {
            dtInspection.Clear();
            dtInspection.Columns.Clear();

            vgrdInspectParams.Rows.Clear();
            if (items.Count > 0)
            {
                foreach (var item in items)
                {
                    string colName = string.Format("Column{0}", item.Ordinal);
                    DataColumn dc = dtInspection.Columns.Add(colName, typeof(string));
                    dc.Caption = item.T20Name;

                    EditorRow row = new EditorRow();
                    row.Properties.Caption = item.T20Name;
                    row.Properties.FieldName = colName;
                    vgrdInspectParams.Rows.Add(row);
                }

                for (int i = 0; i < dtInspection.Columns.Count; i++)
                {
                    items[i].ResolveDataXML();
                    for (int j = 0; j < items[i].ItemValues.Count; j++)
                    {
                        DataRow dr = null;
                        if (dtInspection.Rows.Count < j + 1)
                        {
                            dr = dtInspection.NewRow();
                            dtInspection.Rows.Add(dr);
                        }
                        else
                        {
                            dr = dtInspection.Rows[j];
                        }

                        dr[i] = items[i].ItemValues[j].Metric01;
                    }
                }
                inspectionidx = items[0].ItemValues.Count;
                this.vgrdInspectParams.DataSource = dtInspection;
                this.vgrdInspectParams.BestFit();
            }
        }
        /// <summary>
        /// 根据炉次号获取检验项
        /// </summary>
        /// <param name="batchNumer"></param>
        /// <returns></returns>
        private List<SmeltInspectionItem> GetSmeltInspectItems()
        {
            List<SmeltInspectionItem> rlt = new List<SmeltInspectionItem>();
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
                int t102LeafID = 0;
                int t216LeafID = 0;
                string pwoNo = "";
                IRAPMDMClient.Instance.ufn_GetList_SmeltInspectionItems(
                            IRAPUser.Instance.CommunityID,
                            frmPhysicochemicalInspectionBatchSystem.currentOpType,
                            t102LeafID,
                            t216LeafID,
                            pwoNo,
                            frmPhysicochemicalInspectionBatchSystem.currentBatchNo,
                            IRAPUser.Instance.SysLogID,
                            ref rlt,
                            out errCode,
                            out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                string errMsg =
                    string.Format(
                        "获取工单信息列表时发生错误：[{0}]",
                        error.Message);
                WriteLog.Instance.Write(errMsg, strProcedureName);

                XtraMessageBox.Show(
                    errMsg,
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return rlt;
        }

        public void RefreshUC()
        {
            inspectionItems = GetSmeltInspectItems();

            if (inspectionItems.Count > 0)
            {
                InitInspectionItemsGrid(inspectionItems);
                RefreshCtrl();
            }
            else
            {
                XtraMessageBox.Show(
                    string.Format(
                        "根据炉次号[{0}]无法找到检验项，可能该炉次号不存在或还未开始生产",
                        frmPhysicochemicalInspectionBatchSystem.currentBatchNo),
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                InitInspectionItemsGrid(new List<SmeltInspectionItem>());
            }
        }

        public void RefreshCtrl()
        {
            if (frmPhysicochemicalInspectionBatchSystem.currentBatchNo == null)
            {
                btnAdd.Enabled = false;
                btn_save.Enabled = false;
            }
            else
            {

                if (vgrdInspectParams.Rows.Count > 0)
                {
                    btnAdd.Enabled = true;
                    btn_save.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = false;
                    btn_save.Enabled = false;
                }
            }
        }
        public void RefreshUC(OrderInfo Pwo)
        {
            inspectionItems.Clear();
            if (Pwo != null)
            {
                pwo = Pwo;
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

                    IRAPMDMClient.Instance.ufn_GetList_SmeltInspectionItems(
                        IRAPUser.Instance.CommunityID,
                        frmPhysicochemicalInspectionBatchSystem.currentOpType,
                        Pwo.T102LeafID,
                        Pwo.T216LeafID,
                        Pwo.PWONo,
                        Pwo.BatchNumber,
                        IRAPUser.Instance.SysLogID,
                        ref inspectionItems,
                        out errCode,
                        out errText);
                    if (errCode != 0)
                    {
                        XtraMessageBox.Show(
                            errText,
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
                if (inspectionItems.Count < 0)
                {
                    XtraMessageBox.Show(
                        string.Format(
                            "未找到[({0}){1}]的检验项，可能主数据没有配置",
                            Pwo.T102Code,
                            Pwo.T102Name),
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    InitInspectionItemsGrid(new List<SmeltInspectionItem>());
                }
            }
            InitInspectionItemsGrid(inspectionItems);
            RefreshCtrl();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dtInspection.Columns.Count < 0)
            {
                XtraMessageBox.Show(
                    "当前没有配置检验项",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            using (Dialogs.frmNoneblankEditor formEditor =
                new Dialogs.frmNoneblankEditor(
                    EditStatus.New,
                    "新增",
                    dtInspection,
                    -1))
            {
                if (formEditor.ShowDialog() == DialogResult.OK)
                {
                    vgrdInspectParams.RefreshDataSource();
                    frmPhysicochemicalInspectionBatchSystem.saveState = false;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            if (dtInspection.Columns.Count < 0)
            {
                XtraMessageBox.Show(
                    "当前生产工单的在制品没有配置检验项",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (dtInspection.Rows.Count < 0)
            {
                XtraMessageBox.Show(
                    "当前生产工单还没有输入检验值",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (frmPhysicochemicalInspectionBatchSystem.saveState == true)
            {
                XtraMessageBox.Show(
                    "未做任何修改",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (optype == "MPLH")        //毛坯理化
            {
                if (SaveFact_SmeltBatchInspecting(pwo.FactID, pwo.T102LeafID, pwo.T107LeafID, pwo.LotNumber,pwo.PWONo))
                {
                    frmPhysicochemicalInspectionBatchSystem.saveState = true;
                    dtInspection.Rows.Clear();
                    dtInspection.Columns.Clear();
                    vgrdInspectParams.Rows.Clear();
                    RefreshUC(pwo);
                }
            }
            else if (optype == "LQLH" || optype == "LHLH")    //炉前理化,炉后理化
            {
                if (SaveFact_SmeltBatchManualInspecting(0, 0, 0, "0"))
                {
                    frmPhysicochemicalInspectionBatchSystem.saveState = true;
                    dtInspection.Rows.Clear();
                    dtInspection.Columns.Clear();
                    vgrdInspectParams.Rows.Clear();
                    RefreshUC();
                }
            }
        }
        /// <summary>
        /// 炉前炉后检验保存
        /// </summary>
        /// <param name="factID"></param>
        /// <param name="t102LeafID"></param>
        /// <param name="t107LeafID"></param>
        /// <param name="lotNumber"></param>
        /// <returns></returns>
        private bool SaveFact_SmeltBatchManualInspecting(
            long factID,
            int t102LeafID,
            int t107LeafID,
            string lotNumber)
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
                IRAPMESClient.Instance.usp_SaveFact_SmeltBatchManualInspecting(
                IRAPUser.Instance.CommunityID,
                factID,
                optype,
                t102LeafID,
                t107LeafID,
                frmPhysicochemicalInspectionBatchSystem.currentBatchNo,
                lotNumber,
                GenerateRSFactXML(),
                IRAPUser.Instance.SysLogID,
                out errCode,
                out errText);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return true;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
        /// <summary>
        /// 理化检验保存
        /// </summary>
        /// <param name="factID"></param>
        /// <param name="t102LeafID"></param>
        /// <param name="t107LeafID"></param>
        /// <param name="lotNumber"></param>
        /// <param name="pWONo"></param>
        /// <returns></returns>
        private bool SaveFact_SmeltBatchInspecting(
            long factID,
            int t102LeafID,
            int t107LeafID,
            string lotNumber,
            string pWONo)
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
                string RSFact = GenerateRSFactXML();
                if(!string.IsNullOrEmpty(frmPhysicochemicalInspectionBatchSystem.currentbase64))
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(RSFact);
                    xdoc.FirstChild.FirstChild.Attributes["IQCReport"].InnerText = frmPhysicochemicalInspectionBatchSystem.currentbase64;
                    RSFact = xdoc.InnerXml;
                }
                IRAPMESClient.Instance.usp_SaveFact_SmeltBatchInspecting(
                IRAPUser.Instance.CommunityID,
                factID,
                optype,
                t102LeafID,
                t107LeafID,
                frmPhysicochemicalInspectionBatchSystem.currentBatchNo,
                lotNumber,
                pWONo,
                RSFact,
                IRAPUser.Instance.SysLogID,
                out errCode,
                out errText);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    frmPhysicochemicalInspectionBatchSystem.currentbase64 = "";
                    return true;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
        private string GenerateRSFactXML()
        {
            string rlt = "";
            int rowNo = 0;
            for (int i = inspectionidx; i < dtInspection.Rows.Count; i++)
            {
                rowNo++;
                for (int j = 0; j < dtInspection.Columns.Count; j++)
                {
                    rlt +=
                        string.Format(
                            "<RF6_2 RowNum=\"{0}\" Ordinal=\"{1}\" " +
                            "T20LeafID=\"{2}\" LowLimit=\"\" " +
                            "Criterion=\"\" HighLimit=\"\" UnitOfMeasure=\"\" " +
                            "Metric01=\"{3}\" IQCReport=\"\" />",
                            rowNo,
                            inspectionItems[j].Ordinal,
                            inspectionItems[j].T20LeafID,
                            dtInspection.Rows[i][j].ToString());
                }
            }

            rlt = string.Format("<RSFact>{0}</RSFact>", rlt);
            return rlt;
        }
    }
}
