using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Data;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.Global.Enums;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.UserControls
{
    public partial class ucPCInspect : XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private DataTable dtInspection = new DataTable();
        private DataTable dtDelta = null;

        private List<SmeltInspectionItem> inspectionItems = new List<SmeltInspectionItem>();
        private OrderInfo pwoInfo = null;
        private XmlDocument xmlRSFact = new XmlDocument();

        public ucPCInspect()
        {
            InitializeComponent();

            grdvInspectItems.Columns.Clear();
        }

        /// <summary>
        /// 生成理化检验值临时表
        /// </summary>
        /// <param name="items"></param>
        private void InitInspectionItemsGrid(List<SmeltInspectionItem> items)
        {
            dtInspection.Clear();
            dtInspection.Columns.Clear();
            grdvInspectItems.Columns.Clear();

            if (items.Count > 0)
            {
                #region 生成临时表结构
                foreach (SmeltInspectionItem item in items)
                {
                    string colName = string.Format("Column{0}", item.Ordinal);
                    DataColumn dc = dtInspection.Columns.Add(colName, typeof(string));
                    dc.Caption = item.T20Name;

                    GridColumn column = grdvInspectItems.Columns.Add();
                    column.Caption = item.T20Name;
                    column.FieldName = colName;
                    column.Visible = true;
                    column.OptionsFilter.AllowFilter = false;
                }
                #endregion

                #region 增加附件字段
                {
                    DataColumn dc = dtInspection.Columns.Add("AttachedFile", typeof(string));
                    dc.Caption = "附件";
                    GridColumn column = grdvInspectItems.Columns.Add();
                    //column.Caption = dc.Caption;
                    //column.FieldName = dc.ColumnName;
                    //column.ColumnEdit = ribeUpload;
                    //column.Visible = false;
                    //column.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
                }
                {
                    DataColumn dc = dtInspection.Columns.Add("HasIQCReport", typeof(int));
                    dc.Caption = "附件";
                    GridColumn column = grdvInspectItems.Columns.Add();
                    column.Caption = dc.Caption;
                    column.FieldName = dc.ColumnName;
                    column.ColumnEdit = ribeUpload;
                    ribeUpload.TextEditStyle = TextEditStyles.DisableTextEditor;
                    column.Visible = true;
                    column.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
                    //column.OptionsColumn.AllowEdit = false;
                }
                #endregion

                #region 增加字段
                {
                    // 记录的状态：0-已保存；1-新增；2-修改；3-删除
                    DataColumn dc = dtInspection.Columns.Add("RecordStatus", typeof(int));
                    dc.Caption = "记录状态";
                    GridColumn column = grdvInspectItems.Columns.Add();
                    column.Name = string.Format("grdclmn{0}", dc.ColumnName);
                    column.Caption = dc.Caption;
                    column.Visible = true;
                    column.FieldName = dc.ColumnName;
                    column.OptionsColumn.AllowEdit = false;

                    // 每行记录的事实编号
                    dc = dtInspection.Columns.Add("FactID", typeof(long));
                    dc.Caption = "事实编号";
                    column = grdvInspectItems.Columns.Add();
                    column.Name = string.Format("grdclmn{0}", dc.ColumnName);
                    column.Caption = dc.Caption;
#if DEBUG
                    column.Visible = true;
#else
                    column.Visible = false;
#endif
                    column.FieldName = dc.ColumnName;
                    column.OptionsColumn.AllowEdit = false;
                }
                #endregion

                #region 增加删除当前行的按钮
                {
                    GridColumn column = grdvInspectItems.Columns.Add();
                    column.Caption = "删除";
                    column.ColumnEdit = ribeDeleteRow;
                    column.Visible = true;
                    column.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
                }
                #endregion

                #region 过滤已删除行
#if DEBUG
#else
                grdvInspectItems.ActiveFilterString = "[RecordStatus] <> 3";
#endif
                #endregion

                #region 设置第一个列进行排序
                if (grdvInspectItems.Columns.Count > 0)
                {
                    grdvInspectItems.Columns[0].SortOrder = ColumnSortOrder.Ascending;
                }
                #endregion

                #region 向 DataTable 中填充数据
                for (int i = 0; i < dtInspection.Columns.Count; i++)
                {
                    if (i < items.Count)
                    {
                        items[i].ResolveDataXML();
                        for (int j = 0; j < items[i].ItemValues.Count; j++)
                        {
                            DataRow dr = null;
                            if (dtInspection.Rows.Count < j + 1)
                            {
                                dr = dtInspection.NewRow();
                                dr["AttachedFile"] = "";
                                dr["RecordStatus"] = 0;
                                dr["HasIQCReport"] = 0;
                                dr["FactID"] = 0;
                                dtInspection.Rows.Add(dr);
                            }
                            else
                            {
                                dr = dtInspection.Rows[j];
                            }

                            dr[i] = items[i].ItemValues[j].Metric01;
                            if ((long)dr["FactID"] == 0)
                                dr["FactID"] = items[i].ItemValues[j].FactID;
                            if (i == 0)
                                dr["HasIQCReport"] = items[i].ItemValues[j].HasIQCReport;
                        }
                    }
                }
                #endregion

                dtDelta = dtInspection.Copy();

                grdvInspectItems.BeginUpdate();
                grdInspectItems.DataSource = dtInspection;
                grdvInspectItems.EndUpdate();
                grdvInspectItems.BestFitColumns();
            }
        }

        /// <summary>
        /// 刷新页面上的控件显示状态
        /// </summary>
        private void RefreshControls()
        {
            if (pwoInfo == null)
            {
                grdvInspectItems.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

                btnSave.Enabled = false;
            }
            else
            {
                grdvInspectItems.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

                btnSave.Enabled = true;
            }
        }

        /// <summary>
        /// 初始化 XMLDocument
        /// </summary>
        private void InitXMLDocumemt()
        {
            xmlRSFact = new XmlDocument();
            XmlNode root = xmlRSFact.CreateElement("RSFact");
            xmlRSFact.AppendChild(root);
        }

        /// <summary>
        /// 生成需要新增的检验数据 XML 串
        /// </summary>
        private void GenerateNewRSFactXML()
        {
            XmlNode root = xmlRSFact.SelectSingleNode("RSFact");
            if (root == null)
            {
                root = xmlRSFact.CreateElement("RSFact");
                xmlRSFact.AppendChild(root);
            }

            int rowIdx = 1;
            foreach (DataRow dr in dtInspection.Rows)
            {
                EditStatus recordStatus = (EditStatus)dr["RecordStatus"];
                switch (recordStatus)
                {
                    case EditStatus.New:
                    case EditStatus.Edit:
                        #region 生成新增的 XML 节点
                        XmlNode rsfactNode = xmlRSFact.CreateElement("RF6_2");
                        root.AppendChild(rsfactNode);

                        for (int i = 0; i < inspectionItems.Count; i++)
                        {
                            XmlNode node = null;
                            if (i == 0)
                                node = rsfactNode;
                            else
                            {
                                node = xmlRSFact.CreateElement("RF6_2");
                                root.AppendChild(node);
                            }

                            node.Attributes.Append(
                                XMLHelper.CreateAttribute(
                                    xmlRSFact,
                                    "RowNum",
                                    rowIdx.ToString()));
                            node.Attributes.Append(
                                XMLHelper.CreateAttribute(
                                    xmlRSFact,
                                    "Ordinal",
                                    inspectionItems[i].Ordinal.ToString()));
                            node.Attributes.Append(
                                XMLHelper.CreateAttribute(
                                    xmlRSFact,
                                    "T20LeafID",
                                    inspectionItems[i].T20LeafID.ToString()));
                            node.Attributes.Append(
                                XMLHelper.CreateAttribute(
                                    xmlRSFact,
                                    "LowLimit",
                                    ""));
                            node.Attributes.Append(
                                XMLHelper.CreateAttribute(
                                    xmlRSFact,
                                    "Criterion",
                                    ""));
                            node.Attributes.Append(
                                XMLHelper.CreateAttribute(
                                    xmlRSFact,
                                    "HighLimit",
                                    ""));
                            node.Attributes.Append(
                                XMLHelper.CreateAttribute(
                                    xmlRSFact,
                                    "UnitOfMeasure",
                                    inspectionItems[i].UnitOfMeasure));
                            node.Attributes.Append(
                                XMLHelper.CreateAttribute(
                                    xmlRSFact,
                                    "Metric01",
                                    dr[string.Format(
                                        "Column{0}",
                                        inspectionItems[i].Ordinal)].ToString()));
                        }

                        rsfactNode.Attributes.Append(
                            XMLHelper.CreateAttribute(
                                xmlRSFact,
                                "IQCReport",
                                dr["AttachedFile"].ToString()));

                        rowIdx++;
                        #endregion

                        break;
                }
            }
        }

        /// <summary>
        /// 根据工单刷新检验项及检验项数据
        /// </summary>
        /// <param name="pwo">工单</param>
        public void RefreshUC(OrderInfo pwo)
        {
            inspectionItems.Clear();
            InitXMLDocumemt();

            pwoInfo = pwo;

            if (pwo != null)
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

                    IRAPMDMClient.Instance.ufn_GetList_SmeltInspectionItems(
                        IRAPUser.Instance.CommunityID,
                        frmPhysicochemicalInspectionBatchSystem.currentOpType,
                        pwo.T102LeafID,
                        pwo.T216LeafID,
                        pwo.PWONo,
                        pwo.BatchNumber,
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
                            pwo.T102Code,
                            pwo.T102Name),
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            InitInspectionItemsGrid(inspectionItems);

            RefreshControls();
        }

        private bool RemoveInspectItems(OrderInfo pwoInfo)
        {
            int errCode = 0;
            string errText = "";
            int countDeal = 0;

            foreach (DataRow dr in dtInspection.Rows)
            {
                EditStatus recordStatus = (EditStatus)dr["RecordStatus"];
                switch (recordStatus)
                {
                    case EditStatus.Edit:
                    case EditStatus.Delete:
                        if (dr["AttachedFile"].ToString() == "" &&
                            (int)dr["HasIQCReport"] == 1)
                        {
                            DataRow dr1 = dr;
                            GetIQCReportFromDB(ref dr1);
                        }

                        countDeal++;
                        try
                        {
                            IRAPMESBatchClient.Instance.usp_SaveFact_SmeltBatchMethodCancel(
                                IRAPUser.Instance.CommunityID,
                                pwoInfo.T216LeafID,
                                pwoInfo.T107LeafID,
                                pwoInfo.BatchNumber,
                                "D",
                                (long)dr["FactID"],
                                IRAPUser.Instance.SysLogID,
                                out errCode,
                                out errText);
                            if (errCode != 0)
                            {
                                XtraMessageBox.Show(
                                    string.Format(
                                        "已经成功删除了[{0}]条记录。\n"+
                                        "但是有错误发生：[{1}]\n"+
                                        "终止继续处理",
                                        countDeal,
                                        errText),
                                    "提示信息",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        catch (Exception error)
                        {
                            XtraMessageBox.Show(
                                string.Format(
                                    "已经成功删除了[{0}]条记录。\n" +
                                    "但是有错误发生：[{1}]\n" +
                                    "终止继续处理",
                                    countDeal,
                                    error.Message),
                                "提示信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        /// <summary>
        /// 通过调用函数，获取指定事实编号的检验报告文件 
        /// </summary>
        /// <param name="dr"></param>
        private void GetIQCReportFromDB(ref DataRow dr)
        {
            if (dr == null || 
                dr["FactID"] == null ||
                (long)dr["FactID"] <= 0)
                return;

            string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);

            int errCode = 0;
            string errText = "";
            List<BatchIQCReport> datas = new List<BatchIQCReport>();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("正在获取检验报告内容");
            try
            {
                IRAPMDMClient.Instance.ufn_GetList_BatchIDC_IQCReport(
                    IRAPUser.Instance.CommunityID,
                    (long)dr["FactID"],
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    if (datas.Count > 0)
                    {
                        if (dr["AttachedFile"] != null)
                        {
                            string contentAttachedFile = Encoding.ASCII.GetString(datas[0].IQCReport);
                            dr["AttachedFile"] = contentAttachedFile.Replace("\0", "");
                        }
                    }
                }
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void ribeButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DataRow dr = grdvInspectItems.GetFocusedDataRow();
            if (dr != null)
            {
                switch (e.Button.Caption)
                {
                    case "Upload":
                        openFileDialog.Title = "选择要上传的文件";
                        if (openFileDialog.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                        else
                        {
                            grdvInspectItems.BeginDataUpdate();

                            TWaitting.Instance.ShowWaitForm("正在读取需要上传的文件内容");
                            try
                            {
                                dr["AttachedFile"] = Tools.FileToBase64(openFileDialog.FileName);
                                dr["HasIQCReport"] = 1;
                                dr["RecordStatus"] = 2;
                            }
                            finally
                            {
                                TWaitting.Instance.CloseWaitForm();
                            }
                            grdvInspectItems.EndDataUpdate();
                            grdvInspectItems.BestFitColumns();
                        }
                        break;
                    case "DeleteRow":
                        if (XtraMessageBox.Show(
                            "请确认是否要删除当前行？",
                            "提示",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            int indexFocused = grdvInspectItems.FocusedRowHandle;

                            grdvInspectItems.BeginDataUpdate();
                            try
                            {
                                if (Convert.ToInt32(dr["RecordStatus"]) == 1)
                                    dtInspection.Rows.Remove(dr);
                                else
                                {
                                    dr["RecordStatus"] = 3;
                                }
                            }
                            finally
                            {
                                grdvInspectItems.EndDataUpdate();
                                grdvInspectItems.BestFitColumns();
                            }

                            if (dtInspection.Rows.Count > 0)
                            {
                                if (indexFocused >= dtInspection.Rows.Count)
                                    grdvInspectItems.FocusedRowHandle = dtInspection.Rows.Count - 1;
                                else
                                    grdvInspectItems.FocusedRowHandle = indexFocused;
                            }
                        }
                        break;
                    case "Preview":
                        if ((dr["AttachedFile"] == DBNull.Value ||
                            dr["AttachedFile"].ToString() == "") &&
                            (int)dr["HasIQCReport"] == 1)
                            GetIQCReportFromDB(ref dr);

                        if (dr["AttachedFile"].ToString() != "")
                            using (Dialogs.frmShowPDFFileContent frmShowPDF =
                                new Dialogs.frmShowPDFFileContent())
                            {
                                frmShowPDF.Base64String = (string)dr["AttachedFile"];
                                frmShowPDF.ShowDialog();
                            }
                        else
                        {
                            XtraMessageBox.Show(
                                "还没有上传检验报告",
                                "提示信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }

        private void grdvInspectItems_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow dr = grdvInspectItems.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["AttachedFile"] = "";
                dr["HasIQCReport"] = 0;
                dr["RecordStatus"] = 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                    string.Format(
                        "{0}.{1}",
                        className,
                        MethodBase.GetCurrentMethod().Name);

            int needDealCount = 0;
            foreach (DataRow dr in dtInspection.Rows)
            {
                switch ((EditStatus)((int)dr["RecordStatus"]))
                {
                    case EditStatus.Delete:
                    case EditStatus.New:
                    case EditStatus.Edit:
                        needDealCount++;
                        break;
                }
            }
            if (needDealCount == 0)
            {
                XtraMessageBox.Show(
                    "当前内容没有更改，不需要保存",
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (RemoveInspectItems(pwoInfo))
                {
                    GenerateNewRSFactXML();
                    if (xmlRSFact.FirstChild.HasChildNodes)
                    {
                        int errCode = 0;
                        string errText = "";

                        IRAPMESSmeltClient.Instance.usp_SaveFact_SmeltBatchInspecting(
                            IRAPUser.Instance.CommunityID,
                            pwoInfo.FactID,
                            "MPLH",
                            pwoInfo.T102LeafID,
                            pwoInfo.T107LeafID,
                            pwoInfo.BatchNumber,
                            pwoInfo.LotNumber,
                            pwoInfo.PWONo,
                            xmlRSFact.OuterXml,
                            IRAPUser.Instance.SysLogID,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("({0}){1}", errCode, errText),
                            strProcedureName);
                        if (errCode == 0)
                            XtraMessageBox.Show(
                                "毛坯理化检验数据已经保存完毕",
                                "提示信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        else
                            XtraMessageBox.Show(
                                errText,
                                "提示信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                    else
                    {
                        XtraMessageBox.Show(
                            "毛坯理化检验数据已经保存完毕",
                            "提示信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

            RefreshUC(pwoInfo);
        }

        private void grdvInspectItems_CustomColumnDisplayText(
            object sender, 
            CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column != null && e.Value != null)
            {
                switch (e.Column.FieldName)
                {
                    case "RecordStatus":
                        switch ((int)e.Value)
                        {
                            case 0:
                                e.DisplayText = "正常";
                                break;
                            case 1:
                                e.DisplayText = "新增";
                                break;
                            case 2:
                                e.DisplayText = "修改";
                                break;
                            case 3:
                                e.DisplayText = "删除";
                                break;
                        }
                        break;
                    case "HasIQCReport":
                        switch ((int)e.Value)
                        {
                            case 1:
                                e.DisplayText = "有";
                                break;
                            default:
                                e.DisplayText = "无";
                                break;
                        }
                        break;
                }
            }
        }

        private void grdvInspectItems_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            // 当单元格中的内容发生了变更后
            DataRow dr = grdvInspectItems.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                EditStatus recordStatus = (EditStatus)(int)dr["RecordStatus"];
                switch (recordStatus)
                {
                    case EditStatus.Browse:
                        GetIQCReportFromDB(ref dr);
                        dr["RecordStatus"] = (int)EditStatus.Edit;
                        break;
                }
            }
        }
    }
}
