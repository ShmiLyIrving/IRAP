using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IRAP.Entities.MES;
using System.Reflection;
using IRAP.Global;
using IRAP.WCF.Client.Method;
using IRAP.Entity.UTS;
using DevExpress.XtraGrid.Columns;
using System.Xml;
using IRAP.Client.GUI.MESPDC.Entities;
using DevExpress.XtraVerticalGrid.Rows;

namespace IRAP.Client.GUI.MESPDC.UserControls {
    public partial class ucFurnace : XtraUserControl {
        public ucFurnace(ProductionParam param, int communityID, int sysLogID) {
            InitializeComponent();
            this._productionParam = param;
            this._communityID = communityID;
            this._sysLogID = sysLogID;
        }
  
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private ImportParam _importPara = new ImportParam();
        private List<ImportMetaData> _importMetaData = new List<ImportMetaData>();
        private List<OrderInfo> _orderInfo = new List<OrderInfo>();
        private bool _ProductingNow = false;//是否正在生产

        #region 属性
        /// <summary>
        /// 熔炉信息
        /// </summary>
        public ProductionParam ProductionParam {
            get { return _productionParam; }
        }
        private ProductionParam _productionParam;

        /// <summary>
        /// 社区标识
        /// </summary>
        public int CommunityID {
            get { return _communityID; }
        }
        private int _communityID;

        /// <summary>
        /// 登录标识
        /// </summary>
        public int SysLogID {
            get { return _sysLogID; }
        }
        private int _sysLogID;

        #endregion

        #region 单头信息
        
       
        /// <summary>
        /// 操作工编号校验
        /// </summary>
        /// <returns></returns>
        private bool OperatorCodeValidate() {
            int errCode;
            string errText;
            string strProcedureName =string.Format("{0}.{1}",className,MethodBase.GetCurrentMethod().Name);
            var operatorCode = this.txtOperator.Text;
            if (string.IsNullOrEmpty(operatorCode)) {
                errCode = 9999;
                errText = "操作工编号不可为空！";
                this.txtOperator.ErrorText = errText;
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                return false;
            }
            try {
                var hasOperator = IRAPMESProductionClient.Instance.OperatorCodeValidate(_communityID,operatorCode, out errCode, out errText);
                if (!hasOperator) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    this.txtOperator.ErrorText = errText;
                }
                return hasOperator;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return false;
        }

        /// <summary>
        /// 获取炉次号
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private List<WaitingSmelt> GetWaitingSmelts(string startDate) {
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var data = IRAPMESProductionClient.Instance.GetWaitingSmeilts(_communityID,_productionParam.T107LeafID,
                    _productionParam.T216LeafID, _productionParam.T133LeafID, startDate, _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return data;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        /// <summary>
        /// 设置炉次号
        /// </summary>
        private void SetWaitingFurnace(){
            var date = this.dtProductDate.EditValue == null ? null : this.dtProductDate.EditValue.ToString();
            if (string.IsNullOrEmpty(date)) {
                this.dtProductDate.ErrorText = "请选择生产日期！";
                return;
            }
            var furnaces = GetWaitingSmelts(date);
            if (furnaces == null||furnaces.Count==0) {
                return;
            }
            var currentFurnace = furnaces[0];
            if (currentFurnace == null) {
                return;
            }
            this.lblFurnaceTime.Text = currentFurnace.BatchNumber;
            this.lblFurnaceTime.Tag = currentFurnace;
        }
        #endregion

        #region 生产信息
        private bool GetImportInfoXml() {
            //todo:修改参数
            int t19LeafID = 373249;
            int txLeafID = 0;
            int sysLogID = 737942;

            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                IRAPTreeClient.Instance.GetImportInfoEntity(_communityID, t19LeafID, txLeafID, sysLogID,
                    out _importPara, out _importMetaData, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void CreateGridColumn() {
            this.gridView1.Columns.Clear();
            if (_importMetaData == null||_importMetaData.Count == 0) {
                return;
            }
            foreach (ImportMetaData item in _importMetaData) {
                GridColumn col = new GridColumn();
                col.FieldName = item.ColName;
                col.Caption = item.ColDisplayName;
                col.Name = item.ColName;
                col.Visible = Convert.ToInt32(item.Visible) == 1;
                col.OptionsColumn.AllowEdit = Convert.ToInt32(item.EditEnabled) == 1;
                col.Tag = item;
                this.gridView1.Columns.Add(col);
            }
            this.gridView1.BestFitColumns();
        }

        private void SetOrderInfo() {
            GetImportInfoXml();
            CreateGridColumn();
            _orderInfo = GetOrderInfo();
            if (!ColumnExistValidate()) {
                return;
            }
            InsertDataIntoOrderInfo();
        }

        private void InsertDataIntoOrderInfo(){
            if (_orderInfo ==null||_orderInfo.Count==0) {
                return;
            }
            this.grdCtrProductionInfo.DataSource = _orderInfo;
        }

        private List<OrderInfo> GetOrderInfo() {
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var orderInfo = IRAPMESProductionClient.Instance.GetOrderInfo(_communityID,((WaitingSmelt)this.lblFurnaceTime.Tag).BatchNumber,_sysLogID,
                    out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return orderInfo;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 判断列是否存在
        /// </summary>
        /// <returns></returns>
        private bool ColumnExistValidate() {
            if (_importMetaData == null || _importMetaData.Count == 0) {
                return false;
            }
            OrderInfo or = new OrderInfo();
            foreach (ImportMetaData meta in _importMetaData) {
                var pro = or.GetType().GetProperty(meta.ColName);
                if (pro == null) {
                    continue;
                }
                return true;
            }
            return false;
        }

        #endregion

        #region 配料及开炉熔炼
        /// <summary>
        /// 获取配料信息
        /// </summary>
        private List<SmeltMaterialItemClient> GetSmeltMaterialItems() {
            var batchNumber = this.lblFurnaceTime.Text;
            var waitingSmelt = this.lblFurnaceTime.Tag as WaitingSmelt;
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var data = IRAPMESProductionClient.Instance.GetSmeltMaterialItems(_communityID, waitingSmelt.T131LeafID, _productionParam.T216LeafID,
                    batchNumber, _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                var datas = new List<SmeltMaterialItemClient>();
                foreach (SmeltMaterialItem item in data) { 
                    datas.Add(SmeltMaterialItemClient.Mapper<SmeltMaterialItemClient, SmeltMaterialItem>(item));
                }
                return datas;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }
        
        /// <summary>
        /// 设置配料信息
        /// </summary>
        private void SetSmeltMaterialItems(){
            var smeltMaterialItems = GetSmeltMaterialItems();
            if (smeltMaterialItems==null||smeltMaterialItems.Count == 0) {
                return;
            }
            this.grdBurdenInfo.DataSource = smeltMaterialItems;
            this.grdBurdenInfoView.Tag = smeltMaterialItems;
        }

        /// <summary>
        /// 获取生产开炉参数
        /// </summary>
        private List<SmeltMethodItemClient> GetSmeltMethodItems() {
            var batchNumber = this.lblFurnaceTime.Text;
            var waitingSmelt = this.lblFurnaceTime.Tag as WaitingSmelt;
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var data = IRAPMESProductionClient.Instance.GetSmeltMethodItems(_communityID, waitingSmelt.T131LeafID, _productionParam.T216LeafID,
                    batchNumber, _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                var datas = new List<SmeltMethodItemClient>();
                foreach (SmeltMethodItem item in data) {
                    datas.Add(SmeltMethodItemClient.Mapper<SmeltMethodItemClient, SmeltMethodItem>(item));
                }
                return datas;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        private void SetSmeltMethodItems() {
            var smeltMethodItems = GetSmeltMethodItems();
            if (smeltMethodItems==null||smeltMethodItems.Count==0) {
                return;
            }
            this.grdProductPara.DataSource = smeltMethodItems;
            this.grdProductParaView.Tag = smeltMethodItems;
        }
        #endregion

        #region 开始生产
        /// <summary>
        /// 开始生产
        /// </summary>
        private bool StartProduction() {
            var operatorCode = this.txtOperator.Text;
            var batchNumber = this.lblFurnaceTime.Text;
            var waitingSmelt = this.lblFurnaceTime.Tag as WaitingSmelt;
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                IRAPMESProductionClient.Instance.StartProduct(_communityID, _productionParam.T216LeafID, _productionParam.T107LeafID,
                   waitingSmelt.T131LeafID, operatorCode, batchNumber, "", _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return false;
        }

        /// <summary>
        /// 创建保存工艺参数xml
        /// </summary>
        //private string CreateRSFactXml() {
        //    XmlDocument xmlDoc = new XmlDocument();
        //    XmlElement root = xmlDoc.CreateElement("RSFact");
        //    xmlDoc.AppendChild(root);
        //    //配料信息
            

        //    var rF13Data = grdBurdenInfo.DataSource as List<SmeltMaterialItem>;
        //    if (rF13Data!=null&&rF13Data.Count>0) {
        //        foreach (SmeltMaterialItem smeltMaterialItem in rF13Data) {
        //            XmlNode rF13Node = xmlDoc.CreateElement("RF13_1");
        //        }
        //    }

        //    root.AppendChild(rF13Node);
        //    //生产开炉参数
        //    XmlNode rF25Node = xmlDoc.CreateElement("RF25");



            
        //    root.AppendChild(rF25Node);
        //    return xmlDoc.OuterXml;
        //}

        #endregion

        #region 重新加载
        /// <summary>
        /// 重新加载
        /// </summary>
        private List<SmeltBatchProductionInfo> ReLoadProduction() {
            var operatorCode = this.txtOperator.Text;
            var batchNumber = this.lblFurnaceTime.Text;
            var waitingSmelt = this.lblFurnaceTime.Tag as WaitingSmelt;
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var datas = IRAPMESProductionClient.Instance.ReloadSmeltBatchProduct(_communityID,_productionParam.T107LeafID, _productionParam.T216LeafID, 
                   _productionParam.T133LeafID, _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return datas;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        private void SetCurrentSmeltInfo(SmeltBatchProductionInfo info) {
            if (info == null) {
                return;
            }
            this.labProductStartTimeResult.Text = info.BatchStartDate.ToShortDateString();
            this.labProductStartTimeResult.Tag = info.BatchStartDate;
            this.labCurrentFurnaceResult.Text = info.BatchNumber;
            this._ProductingNow = info.InProduction == 1; 
        }

        /// <summary>
        /// 生产开始时，清空第一个页签
        /// </summary>
        private void ChangeTabPage() {
            this.tabCtrlDetail.SelectedTabPage = this.tabPgSpectrum;
            this.tabPgBurden.PageEnabled = false;
        }

        #endregion

        #region 炉前光谱

        /// <summary>
        ///获取炉前光谱、浇三角试样、炉水出炉的参数
        /// </summary>
        private List<SmeltMethodItemByOpType> GetSmeltMethodItemByOpType(Optype opType) {
            var operatorCode = this.txtOperator.Text;
            var batchNumber = this.lblFurnaceTime.Text;
            var waitingSmelt = this.lblFurnaceTime.Tag as WaitingSmelt;
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var datas = IRAPMESProductionClient.Instance.GetSmeltMethodItemByOpType(_communityID, GetOpType(opType),waitingSmelt.T131LeafID,
                    _productionParam.T216LeafID,batchNumber, _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return datas;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }

        private void SetParaGrid(Optype opType) {
            switch (opType) {
                case Optype.Spectrum:
                    this.ucGrdSpectrum.Clear();
                    break;
                case Optype.Sample:
                    this.ucGrdSample.Clear();
                    break;
                case Optype.Baked:
                    this.ucGrdBaked.Clear();
                    break;
            }

            var spectrumSmeltMethodItems = GetSmeltMethodItemByOpType(opType);
            if (spectrumSmeltMethodItems==null||spectrumSmeltMethodItems.Count == 0) {
                return;
            }
            InitInspectionItemsGrid(spectrumSmeltMethodItems, opType);
        } 

        /// <summary>
        /// 生成参数值临时表
        /// </summary>
        /// <param name="items"></param>
        private void InitInspectionItemsGrid(List<SmeltMethodItemByOpType> items,Optype opType) {
            ucDetailGrid grd = this.ucGrdSpectrum;
            switch (opType) {
                case Optype.Spectrum:
                    grd = this.ucGrdSpectrum;
                    break;
                case Optype.Sample:
                     grd = this.ucGrdSample;
                    break;
                case Optype.Baked:
                    grd = this.ucGrdBaked;
                    break; 
            }
            DataTable dt = new DataTable();
            foreach (SmeltMethodItemByOpType item in items) {
                string colName = string.Format("Column{0}", item.Ordinal);
                DataColumn dc = dt.Columns.Add(colName, typeof(string));
                dc.Caption = item.T20Name;

                EditorRow row = new EditorRow();
                row.Properties.Caption = item.T20Name;
                row.Properties.FieldName = colName;
                grd.vGridControl.Rows.Add(row);
            }

            grd.DataSource = dt;
            grd.vGridControl.BestFit();
        }

        private string GetOpType(Optype opType) {
            switch (opType) {
                default:
                case Optype.Spectrum:
                    return "LQGP";
                case Optype.Sample:
                    return "SSJSY";
                case Optype.Baked:
                    return "LLCL"; 
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        private bool SaveSmeltParas(Optype opType) { 
            var batchNumber = this.lblFurnaceTime.Text; 
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                IRAPMESProductionClient.Instance.SaveSmeltBatch(_communityID,GetOpType(opType), _productionParam.T216LeafID,
                    _productionParam.T107LeafID, batchNumber, "", _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } 
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                return true;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return false;
        }

        #endregion

        #region 原材料调整
        /// <summary>
        /// 原材料调整保存
        /// </summary>
        private bool RowMatierialAjudgement() {
            var operatorCode = this.txtOperator.Text;
            var batchNumber = this.lblFurnaceTime.Text;
            var waitingSmelt = this.lblFurnaceTime.Tag as WaitingSmelt;
            var xml = GetRowMaterialXml(this.grdRowMaterial.DataSource as List<SmeltMaterialItemClient>);
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                IRAPMESProductionClient.Instance.SaveSmeltBatchMaterial(_communityID, _productionParam.T216LeafID, _productionParam.T107LeafID,
                    batchNumber, xml, _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return false;
        }

        private void SetRowMaterial() { 
            var smeltMaterialItems = GetSmeltMaterialItems();
            if (smeltMaterialItems == null || smeltMaterialItems.Count == 0) {
                return;
            }
            List<SmeltMaterialItemClient> newData = new List<SmeltMaterialItemClient>();
            foreach (SmeltMaterialItemClient item in smeltMaterialItems) {
                var historySmelt = GetHistorySmeltMaterial(item);
                if (historySmelt ==null||historySmelt.Count == 0) {
                    continue;
                }
                newData.AddRange(historySmelt);
            }
            newData.AddRange(smeltMaterialItems);
            this.grdRowMaterial.DataSource = newData;
        }

        private string GetRowMaterialXml(List<SmeltMaterialItemClient> data) { 
            if (data==null||data.Count == 0) {
                return null;
            }
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("RSFact");
            xmlDoc.AppendChild(root);  
            
            foreach (SmeltMaterialItemClient item in data) {
                if (item.IsReadOnly) {
                    continue;
                }
                var rF13Node = xmlDoc.CreateElement("RF13_1");
                rF13Node.SetAttribute("Ordinal", item.Ordinal.ToString());
                rF13Node.SetAttribute("T101LeafID", item.T101LeafID.ToString());
                rF13Node.SetAttribute("LotNumber", item.LotNumber.ToString());
                rF13Node.SetAttribute("Qty", item.Qty.ToString());
                root.AppendChild(rF13Node);
            }
            return xmlDoc.OuterXml;
        }

        /// <summary>
        /// 获取历史数据
        /// </summary>
        /// <param name="rowSmelt"></param>
        /// <returns></returns>
        private List<SmeltMaterialItemClient> GetHistorySmeltMaterial(SmeltMaterialItemClient rowSmelt) {
            if (string.IsNullOrEmpty(rowSmelt.DataXML)) {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(rowSmelt.DataXML);
            var nodes = doc.SelectNodes("RF13/Row");
            if (nodes==null||nodes.Count==0) {
                return null;
            }
            List<SmeltMaterialItemClient> items = new List<SmeltMaterialItemClient>();
            foreach (XmlNode node in nodes) {
                SmeltMaterialItemClient item = new SmeltMaterialItemClient()
                { IsReadOnly = true,T101Code = rowSmelt.T101Code,T101LeafID = rowSmelt.T101LeafID,T101Name = rowSmelt.T101Name};
                var lotNumber = node.Attributes["LotNumber"] == null ? "" : node.Attributes["LotNumber"].Value;
                var qty = node.Attributes["Qty"] == null ? 0 : Convert.ToInt32(node.Attributes["Qty"].Value);
                item.LotNumber = lotNumber;
                item.Qty = qty;
                items.Add(item);
            }
            return items;
        }
        #endregion

        #region 事件

        private void ucFurnace_Load(object sender, EventArgs e) {
            SetWaitingFurnace();
            SetOrderInfo();
            SetSmeltMaterialItems();
            SetSmeltMethodItems();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            if (!OperatorCodeValidate()) {
                return;
            }
            if (!StartProduction()) {
                return;
            }
            var smeltBatchProductionInfos = ReLoadProduction();
            if (smeltBatchProductionInfos==null||smeltBatchProductionInfos.Count<1||smeltBatchProductionInfos[0]==null) {
                return;
            }
            SetCurrentSmeltInfo(smeltBatchProductionInfos[0]);
            ChangeTabPage();
            SetParaGrid(Optype.Spectrum);
            SetParaGrid(Optype.Sample);
            SetParaGrid(Optype.Baked);
            SetRowMaterial();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (!_ProductingNow) {
                return;
            }
            var now = DateTime.Now;
            var startDateTime = (DateTime)this.labProductStartTimeResult.Tag; 
            var span = now - startDateTime;
            lblProductionTimeResult.Text = "";
            if (span.Days != 0)
                lblProductionTimeResult.Text = string.Format("{0}天", span.Days);
            if (span.Hours != 0)
                lblProductionTimeResult.Text += string.Format("{0}小时", span.Hours);
            if (span.Minutes != 0)
                lblProductionTimeResult.Text += string.Format("{0}分钟", span.Minutes);
            if (span.Seconds != 0)
                lblProductionTimeResult.Text += string.Format("{0}秒", span.Seconds);

        }
         
        void ucGrdSpectrum_SaveClick(object sender, System.EventArgs e) {
            if (!SaveSmeltParas(Optype.Spectrum)) {
                return;
            }
            this.ucGrdSpectrum.DataSource.Rows.Clear();
            this.ucGrdSpectrum.DataSource.Columns.Clear();
            this.ucGrdSpectrum.vGridControl.Rows.Clear(); 
        }

        private void btnRowMaterialSave_Click(object sender, EventArgs e) {
            if (!RowMatierialAjudgement()) {
                return;
            }
            SetRowMaterial();
        }
        #endregion  

        private void btnPrint_Click(object sender, EventArgs e) {

        }
    }
}
