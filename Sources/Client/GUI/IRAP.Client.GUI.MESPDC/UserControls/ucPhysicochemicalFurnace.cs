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

namespace IRAP.Client.GUI.MESPDC.UserControls
{
    public partial class ucPhysicochemicalFurnace : UserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private DataTable dtInspection =new DataTable();
        private string optype;
        private List<SmeltInspectionItem> inspectionItems = new List<SmeltInspectionItem>();
        private BatchPWOInfo pwo;

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

            this.vgrdInspectParams.DataSource = dtInspection;
            this.vgrdInspectParams.BestFit();
        }
        /// <summary>
        /// 根据炉次号获取检验项
        /// </summary>
        /// <param name="batchNumer"></param>
        /// <returns></returns>
        private List<SmeltInspectionItem> GetInspectItems()
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
                if (frmPhysicochemicalInspectionBatchSystem.currentOpType == "MPLH")
                {

                }
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
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
#if DEBUG
            for (int i = 0; i < 5; i++)
            {
                Random r = new Random();

                SmeltInspectionItem item = new SmeltInspectionItem();
                item.Ordinal = i;
                item.Scale = 6;
                item.T20Code = "131231";
                item.T20LeafID = 1231231;
                item.T20Name = r.Next(1, 10000).ToString();
                item.UnitOfMeasure = "4";
                item.DataXML = "<RF25><Row FactID =\"" + r.Next(1, 10000).ToString() + "\" Metric01=\"" + r.Next(1, 10000).ToString() + "\"></Row><Row FactID =\"" + r.Next(1, 10000).ToString() + "\" Metric01=\"" + r.Next(1, 10000).ToString() + "\"></Row></RF25>";
                rlt.Add(item);
            }
#endif
            return rlt;
        }

        public void RefreshUC()
        {
            inspectionItems = GetInspectItems();

            if (inspectionItems.Count > 0)
            {
                InitInspectionItemsGrid(inspectionItems);
            }
            else
            {
                XtraMessageBox.Show("输入的炉次号不合法");
            }
        }
        public void RefreshUC(BatchPWOInfo Pwo)
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
                else
                {
                    InitInspectionItemsGrid(inspectionItems);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
#if DEBUG
            for (int i = 0; i < 5; i++)
            {
                Random r = new Random();

                SmeltInspectionItem item = new SmeltInspectionItem();
                item.Ordinal = i;
                item.Scale = 6;
                item.T20Code = "131231";
                item.T20LeafID = 1231231;
                item.T20Name = r.Next(1, 10000).ToString();
                item.UnitOfMeasure = "4";
                item.DataXML = "<RF25><Row FactID =\"" + r.Next(1, 10000).ToString() + "\" Metric01=\"" + r.Next(1, 10000).ToString() + "\"></Row><Row FactID =\"" + r.Next(1, 10000).ToString() + "\" Metric01=\"" + r.Next(1, 10000).ToString() + "\"></Row></RF25>";
                inspectionItems.Add(item);
            }
#endif
            if (inspectionItems.Count > 0)
            {
                InitInspectionItemsGrid(inspectionItems);
            }
            else
            {
                XtraMessageBox.Show("输入的炉次号不合法");
            }
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
                    frmPhysicochemicalInspectionBatchSystem.savestate = false;
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

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            if (optype =="MPLH")        //毛坯理化
            {
                try
                {
                    int errCode = 0;
                    string errText = "";
                    IRAPMESClient.Instance.usp_SaveFact_SmeltBatchManualInspecting(
                    IRAPUser.Instance.CommunityID,
                    pwo.FactID,
                    optype,
                    pwo.T102LeafID,
                    int.Parse(pwo.T107LeafID),
                    pwo.BatchNumber,
                    pwo.LotNumber,
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
                    }
                    else
                    {
                        XtraMessageBox.Show(
                            errText,
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        dtInspection.Rows.Clear();
                        dtInspection.Columns.Clear();
                        vgrdInspectParams.Rows.Clear();
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
            else if(optype =="LQLH"||optype=="LHLH")    //炉前理化,炉后理化
            {
                try
                {
                    int errCode = 0;
                    string errText = "";
                    IRAPMESClient.Instance.usp_SaveFact_SmeltBatchManualInspecting(
                    IRAPUser.Instance.CommunityID,
                    0,
                    optype,
                    0,
                    0,
                    frmPhysicochemicalInspectionBatchSystem.currentBatchNo,
                    "0",
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
                    }
                    else
                    {
                        XtraMessageBox.Show(
                            errText,
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        //dtInspection.Rows.Clear();
                        //dtInspection.Columns.Clear();
                        //vgrdInspectParams.Rows.Clear();
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }
        private string GenerateRSFactXML()
        {
            string rlt = "";

            for (int i = 0; i < dtInspection.Rows.Count; i++)
            {
                int rowNo = i + 1;
                for (int j = 0; j < dtInspection.Columns.Count; j++)
                {
                    rlt +=
                        string.Format(
                            "<RF6_2 RowNum=\"{0}\" Ordinal=\"{1}\" " +
                            "T20LeafID=\"{2}\" LowLimit=\"\" " +
                            "Criterion=\"\" HighLimit=\"\" UnitOfMeasure=\"\" " +
                            "Metric01=\"{3}\" />",
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
