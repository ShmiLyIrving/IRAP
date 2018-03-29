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

using IRAP.Global;
using IRAP.Client.Global;
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
                    column.Caption = dc.Caption;
                    column.FieldName = dc.ColumnName;
                    column.ColumnEdit = ribeUpload;
                    column.Visible = true;
                    column.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
                }
                #endregion

                #region 增加字段
                {
                    // 记录的状态：0-已保存；1-新增；2-修改；3-删除
                    DataColumn dc = dtInspection.Columns.Add("RecordStatus", typeof(int));
                    dc.Caption = "记录状态";
                    GridColumn column = grdvInspectItems.Columns.Add();
                    column.Caption = dc.Caption;
                    column.Visible = true;
                    column.FieldName = dc.ColumnName;

                    // 每行记录的事实编号
                    dc = dtInspection.Columns.Add("FactID", typeof(long));
                    dc.Caption = "事实编号";
                    column = grdvInspectItems.Columns.Add();
                    column.Caption = dc.Caption;
                    column.Visible = true;
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
                //grdvInspectItems.ActiveFilterString = "[RecordStatus] <> 3";
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
                                dr["RecordStatus"] = 0;
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
                switch ((int)dr["RecordStatus"])
                {
                    case 1:
                    case 2:
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
                                    inspectionItems[i].T20Name));
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
                    case "查看":
                        break;
                }
            }
        }

        private void grdvInspectItems_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow dr = grdvInspectItems.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["RecordStatus"] = 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GenerateNewRSFactXML();
            WriteLog.Instance.Write(xmlRSFact.OuterXml);
        }

        private void grdvInspectItems_CustomColumnDisplayText(
            object sender, 
            CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column != null && e.Value != null)
            {
                if (e.Column.FieldName == "RecordStatus")
                {
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
                }
            }
        }

        private void grdvInspectItems_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            // 当单元格中的内容发生了变更后
            DataRow dr = grdvInspectItems.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                int recordStatus = (int)dr["RecordStatus"];
                switch (recordStatus)
                {
                    case 0:
                    case 2:
                        dr["RecordStatus"] = 2;
                        break;
                }
            }
        }
    }
}
