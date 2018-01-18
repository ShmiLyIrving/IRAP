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
using IRAP.Entities.IRAP;
using IRAP.Client.User;
using IRAP.Entities.MDM;

namespace IRAP.Client.GUI.MESPDC.UserControls {
    public partial class ucFurnace : XtraUserControl {
        public ucFurnace(WIPStation param, int communityID, int sysLogID) {
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
        private string _operatorCode;
        private string _operatorName; 


        #region 属性
        /// <summary>
        /// 熔炉信息
        /// </summary>
        public WIPStation ProductionParam {
            get { return _productionParam; }
        }
        private WIPStation _productionParam;

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
            #region 注释
            //int errCode;
            //string errText;
            //string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            //var operatorCode = this.txtOperator.Text;
            //if (string.IsNullOrEmpty(operatorCode)) {
            //    errCode = 9999;
            //    errText = "操作工编号不可为空！";
            //    this.txtOperator.ErrorText = errText;
            //    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
            //    return false;
            //}
            //try {
            //    var hasOperator = IRAPMESProductionClient.Instance.OperatorCodeValidate(_communityID, operatorCode, out errCode, out errText);
            //    if (!hasOperator) {
            //        WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
            //        this.txtOperator.ErrorText = errText;
            //    }
            //    return hasOperator;
            //} catch (Exception error) {
            //    WriteLog.Instance.Write(error.Message, strProcedureName);
            //    XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //} finally {
            //    WriteLog.Instance.WriteEndSplitter(strProcedureName);
            //}
            //return false;
            #endregion
            string strProcedureName =string.Format("{0}.{1}",className,MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                int errCode = 0;
                string errText = "";
                List<STB006> users = new List<STB006>();
                var operatorCode =  this.txtOperator.Text;
            if (string.IsNullOrEmpty(operatorCode)) {
                errCode = 9999;
                errText = "操作工编号不可为空！";
                this.txtOperator.ErrorText = errText;
                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                return false;
            }
            if (operatorCode.IndexOf('[')>-1) {
                operatorCode = operatorCode.Substring(1, operatorCode.IndexOf(']') - 1);
            }

            IRAPUserClient.Instance.mfn_GetList_Users(_communityID, operatorCode, "", ref users, out errCode, out errText);
                WriteLog.Instance.Write( string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode != 0) {
                    this.txtOperator.ErrorText = errText;
                    return false;
                }
                if (users == null || users.Count == 0||users[0]==null) {
                    this.txtOperator.ErrorText = string.Format("未找到[{0}]的用户", operatorCode);
                    return false;
                }
                _operatorCode = users[0].UserCode;
                _operatorName = users[0].UserName;
                this.txtOperator.Text = string.Format("[{0}]{1}",_operatorCode,_operatorName);
                return true;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
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
            if (!ProductionDateValidate()) {
                this.lblFurnaceTime.Text = "";
                this.lblFurnaceTime.Tag = null; 
                return;
            }
            var date = this.dtProductDate.EditValue == null ? null : this.dtProductDate.EditValue.ToString();
            var furnaces = GetWaitingSmelts(date);
            if (furnaces == null || furnaces.Count == 0 || furnaces[0]==null) {
                this.lblFurnaceTime.Text = "";
                this.lblFurnaceTime.Tag = null; 
                return;
            }
            var currentFurnace = furnaces[0]; 
            this.lblFurnaceTime.Text = currentFurnace.BatchNumber;
            this.lblFurnaceTime.Tag = currentFurnace; 
        }

        private bool ProductionDateValidate() {
            var date = this.dtProductDate.EditValue == null ? null : this.dtProductDate.EditValue.ToString();
            if (string.IsNullOrEmpty(date)) {
                this.dtProductDate.ErrorText = "请选择生产日期！";
                return false;
            }
            return true;
        }
        #endregion

        #region 生产信息

        #region 动态获取订单列配置（已注释）
        //private bool GetImportInfoXml() {
        //    //todo:修改参数
        //    int t19LeafID = 373249;
        //    int txLeafID = 0;
        //    int sysLogID = 737942;

        //    int errCode;
        //    string errText;
        //    string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
        //    try {
        //        IRAPTreeClient.Instance.GetImportInfoEntity(_communityID, t19LeafID, txLeafID, sysLogID,
        //            out _importPara, out _importMetaData, out errCode, out errText);
        //        if (errCode != 0) {
        //            WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
        //            XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //        return true;
        //    } catch (Exception error) {
        //        WriteLog.Instance.Write(error.Message, strProcedureName);
        //        XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    } finally {
        //        WriteLog.Instance.WriteEndSplitter(strProcedureName);
        //    }
        //}

        //private void CreateGridColumn() {
        //    this.gridView1.Columns.Clear();
        //    if (_importMetaData == null||_importMetaData.Count == 0) {
        //        return;
        //    }
        //    foreach (ImportMetaData item in _importMetaData) {
        //        GridColumn col = new GridColumn();
        //        col.FieldName = item.ColName;
        //        col.Caption = item.ColDisplayName;
        //        col.Name = item.ColName;
        //        col.Visible = Convert.ToInt32(item.Visible) == 1;
        //        col.OptionsColumn.AllowEdit = Convert.ToInt32(item.EditEnabled) == 1;
        //        col.Tag = item;
        //        this.gridView1.Columns.Add(col);
        //    }
        //    this.gridView1.BestFitColumns();
        //}
        #endregion 

        private void SetOrderInfo() {
            //GetImportInfoXml();
            //CreateGridColumn();
            _orderInfo = GetOrderInfo();
            //if (!ColumnExistValidate()) {
            //    return;
            //}
            InsertDataIntoOrderInfo();
        }

        private void InsertDataIntoOrderInfo(){
            this.grdCtrProductionInfo.DataSource = null;
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
                var orderInfo = IRAPMESProductionClient.Instance.GetOrderInfo(_communityID, this.lblFurnaceTime.Text, _sysLogID,
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
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            int t131LeafID = 0;
            if (_ProductingNow) {
                var info = this.lblFurnaceTime.Tag as SmeltBatchProductionInfo;
                if (info != null) {
                    t131LeafID = info.T131LeafID;
                }
            } else {
                var info = this.lblFurnaceTime.Tag as WaitingSmelt;
                if (info != null) {
                    t131LeafID = info.T131LeafID;
                }
            }
            try {
                var data = IRAPMESProductionClient.Instance.GetSmeltMaterialItems(_communityID, t131LeafID, _productionParam.T216LeafID,
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
            this.grdBurdenInfo.DataSource = null;
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
            int t131LeafID = 0;
            if (_ProductingNow) {
                var info = this.lblFurnaceTime.Tag as SmeltBatchProductionInfo;
                if (info != null) {
                    t131LeafID = info.T131LeafID;
                }
            } else {
                var info = this.lblFurnaceTime.Tag as WaitingSmelt;
                if (info != null) {
                    t131LeafID = info.T131LeafID;
                }
            }
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var data = IRAPMESProductionClient.Instance.GetSmeltMethodItems(_communityID, t131LeafID, _productionParam.T216LeafID,
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
            this.grdProductPara.DataSource = null;
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
            var batchNumber = this.lblFurnaceTime.Text;
            var waitingSmelt = this.lblFurnaceTime.Tag as WaitingSmelt;
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                IRAPMESProductionClient.Instance.StartProduct(_communityID, _productionParam.T216LeafID, _productionParam.T107LeafID,
                   waitingSmelt.T131LeafID, _operatorCode, batchNumber, GetMaterialXml(), _sysLogID, out errCode, out errText);
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
        /// 生成保存xml
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetMaterialXml() { 
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("RSFact");
            xmlDoc.AppendChild(root);
            #region 配料信息
            var smeltMaterilItems = this.grdBurdenInfo.DataSource as List<SmeltMaterialItemClient>;
            if (smeltMaterilItems != null && smeltMaterilItems.Count > 0) {
                var rF13Node = xmlDoc.CreateElement("RF13_1");
                foreach (SmeltMaterialItemClient item in smeltMaterilItems) {
                    var row = xmlDoc.CreateElement("Row");
                    row.SetAttribute("Ordinal", "1");
                    row.SetAttribute("T101LeafID", item.T101LeafID.ToString());
                    row.SetAttribute("LotNumber", item.LotNumber);
                    row.SetAttribute("Qty", item.Qty.ToString());
                    row.SetAttribute("Scale", item.Scale.ToString());
                    row.SetAttribute("UnitOfMeasure", item.UnitOfMeasure);
                    rF13Node.AppendChild(row);
                }
                root.AppendChild(rF13Node);
            }
            #endregion
            #region 生产开炉参数
            var smeltMethodItems = this.grdProductPara.DataSource as List<SmeltMethodItemClient>;
            if (smeltMethodItems!=null||smeltMethodItems.Count>0) {
                var rF25Node = xmlDoc.CreateElement("RF25");
                foreach (SmeltMethodItemClient item in smeltMethodItems) {
                    var row = xmlDoc.CreateElement("Row");
                    row.SetAttribute("Ordinal","1");
                    row.SetAttribute("T20LeafID", item.T20LeafID.ToString());
                    row.SetAttribute("Metric01", item.Value);
                    row.SetAttribute("Scale", item.Scale.ToString());
                    row.SetAttribute("UnitOfMeasure", item.UnitOfMeasure);
                    rF25Node.AppendChild(row);
                }
                root.AppendChild(rF25Node);
            }
            #endregion
            return xmlDoc.OuterXml;
        }

         
        #endregion

        #region 重新加载
        /// <summary>
        /// 重新加载
        /// </summary>
        private List<SmeltBatchProductionInfo> ReLoadProduction() {   
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
                this.labProductStartTimeResult.Text = "";
                this.labProductStartTimeResult.Tag = null;
                this.labCurrentFurnaceResult.Text = "";
                this.grpCtrlCurrentInfo.Tag = null;
                this.lblProductionTimeResult.Text = "";
                return;
            }
            this.labProductStartTimeResult.Text = info.BatchStartDate.ToShortDateString();
            this.labProductStartTimeResult.Tag = info.BatchStartDate;
            this.labCurrentFurnaceResult.Text = info.BatchNumber; 
            this.grpCtrlCurrentInfo.Tag = info;
        }

        /// <summary>
        /// 生产开始时，清空第一个页签
        /// </summary>
        private void ChangeTabPage() {
            if (_ProductingNow) {
                this.grdBurdenInfoView.OptionsBehavior.Editable = false;
                this.grdProductParaView.OptionsBehavior.Editable = false;
                this.tabPgMatieralAjustment.PageEnabled = true;
                this.tabPgSample.PageEnabled = true;
                this.tabPgBaked.PageEnabled = true;
                this.tabPgSpectrum.PageEnabled = true;
                this.tabCtrlDetail.SelectedTabPage = this.tabPgSpectrum; 
            } else {
                this.grdBurdenInfoView.OptionsBehavior.Editable = true;
                this.grdProductParaView.OptionsBehavior.Editable = true;
                this.tabPgMatieralAjustment.PageEnabled = false;
                this.tabPgSample.PageEnabled = false;
                this.tabPgBaked.PageEnabled = false;
                this.tabPgSpectrum.PageEnabled = false;
                this.tabCtrlDetail.SelectedTabPage = this.tabPgBurden;
            }
            
        }

        #endregion

        #region 炉前光谱

        /// <summary>
        ///获取炉前光谱、浇三角试样、炉水出炉的参数
        /// </summary>
        private List<SmeltMethodItemByOpType> GetSmeltMethodItemByOpType(Optype opType) {
            var operatorCode = _operatorCode;
            var batchNumber = this.lblFurnaceTime.Text;
            int t131LeafID = 0;
            if (_ProductingNow) {
                var info = this.lblFurnaceTime.Tag as SmeltBatchProductionInfo;
                if (info != null) {
                    t131LeafID = info.T131LeafID;
                }
            } else {
                var info = this.lblFurnaceTime.Tag as WaitingSmelt;
                if (info != null) {
                    t131LeafID = info.T131LeafID;
                }
            }
            
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var datas = IRAPMESProductionClient.Instance.GetSmeltMethodItemByOpType(_communityID, GetOpType(opType),t131LeafID,
                    _productionParam.T216LeafID,batchNumber, _sysLogID, out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName); 
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
            grd.DataSource = null;
            DataTable dt = new DataTable();
            foreach (SmeltMethodItemByOpType item in items) {
                string colName = string.Format("Column{0}", item.Ordinal);
                DataColumn dc = dt.Columns.Add(colName, typeof(string));
                dc.Caption = item.T20Name;
                dc.ExtendedProperties["SmeltMethodItemByOpType"] = item;

                EditorRow row = new EditorRow();
                row.Properties.Caption = item.T20Name;
                row.Properties.FieldName = colName; 
                grd.vGridControl.Rows.Add(row);
            }
            dt.Columns.Add("FactID", typeof(string));
            dt.Columns.Add("ReadOnly", typeof(bool));
            FillOpTypeData(items,dt);
            grd.DataSource = dt;
            grd.ReadOnlyCount = dt.Rows.Count;
            grd.vGridControl.BestFit();
        }

        /// <summary>
        /// 获取历史记录
        /// </summary>
        /// <param name="items"></param>
        /// <param name="grd"></param>
        /// <RF25 >
        ///    <Row FactID="" Metric01=""> 								--  
		/// </RF25 >
        private void FillOpTypeData(List<SmeltMethodItemByOpType> items,DataTable dt) { 
            if (dt == null || items == null || items.Count == 0) {
                return;
            }
            
            foreach (var item in items) {
                if (string.IsNullOrEmpty(item.DataXML)) {
                    return;
                }
                var colName = string.Format("Column{0}", item.Ordinal);
                var col = dt.Columns[colName];
                if (col == null) {
                    return;
                }
                var doc = new XmlDocument();
                doc.LoadXml(item.DataXML);
                var nodes = doc.SelectNodes("RF25/Row");
                if (nodes == null||nodes.Count==0) {
                    return;
                }
                foreach (XmlElement node in nodes) {
                    var factID = node.Attributes["FactID"] == null ? null : node.Attributes["FactID"].Value;
                    if (string.IsNullOrEmpty(factID)) {
                        continue;
                    }
                    var value = node.Attributes["Metric01"] == null?null:node.Attributes["Metric01"].Value;
                    var rows = dt.Select(string.Format("FactID = {0}", factID));
                    if (rows == null||rows.Length==0) {
                        var row = dt.NewRow();
                        row["FactID"] = factID;
                        row[colName] = value;
                        row["ReadOnly"] = true;
                        dt.Rows.Add(row);
                        continue;
                    }
                    var row1 = rows[0];//不会有重复的factId，所以rows的个数一定为1或0
                    row1["FactID"] = factID;
                }
            } 
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
            DataTable data;
            switch (opType) {
                case Optype.Spectrum:
                    data = this.ucGrdSpectrum.DataSource as DataTable;
                    break;
                case Optype.Sample:
                    data = this.ucGrdSample.DataSource as DataTable;
                    break;
                case Optype.Baked:
                    data = this.ucGrdBaked.DataSource as DataTable;
                    break;
                default:
                    data = this.ucGrdSpectrum.DataSource as DataTable;
                    break;
            }
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                IRAPMESProductionClient.Instance.SaveSmeltBatch(_communityID,GetOpType(opType), _productionParam.T216LeafID,
                    _productionParam.T107LeafID, batchNumber, GetSaveMaterialXml(data), _sysLogID, out errCode, out errText);
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

        /// <summary>
        /// 生成保存xml
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetSaveMaterialXml(DataTable data) {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("RSFact");
            xmlDoc.AppendChild(root);
            var rF25Node = xmlDoc.CreateElement("RF25");
            if (data == null || data.Rows.Count == 0) {
                root.AppendChild(rF25Node);
                return xmlDoc.OuterXml;
            }
            for (int j = 0; j < data.Rows.Count; j++) {
                var colReadOnly = data.Columns["ReadOnly"]; 
                if (colReadOnly == null) {
                    continue;
                }
                var readOnly = data.Rows[j][colReadOnly].ToString();
                if (!string.IsNullOrEmpty(readOnly) && readOnly == "True") {
                    continue;
                }
                for (int i = 0; i < data.Columns.Count; i++) {
                    var col = data.Columns[i];
                    var item = col.ExtendedProperties["SmeltMethodItemByOpType"] as SmeltMethodItemByOpType;
                    if (item == null) {
                        continue;
                    }

                    var row = xmlDoc.CreateElement("Row");
                    row.SetAttribute("Ordinal", (j + 1).ToString());
                    row.SetAttribute("FactID", "");
                    row.SetAttribute("T20LeafID", item.T20LeafID.ToString());
                    row.SetAttribute("Metric01", data.Rows[j][i].ToString());
                    row.SetAttribute("Scale", item.Scale.ToString());
                    row.SetAttribute("UnitOfMeasure", item.UnitOfMeasure.ToString());
                    rF25Node.AppendChild(row);
                }
            }
            root.AppendChild(rF25Node);
            return xmlDoc.OuterXml;
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
            this.grdRowMaterial.DataSource = null;
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
                var qty = node.Attributes["Qty"] == null || string.IsNullOrEmpty(node.Attributes["Qty"].Value) ? 0 : Convert.ToInt32(node.Attributes["Qty"].Value);
                item.LotNumber = lotNumber;
                item.Qty = qty;
                items.Add(item);
            }
            return items;
        }
        #endregion

        #region 生产结束
        private bool StopProduction() {
            var batchNumber = this.lblFurnaceTime.Text;
            int errCode;
            string errText; 
             
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                IRAPMESProductionClient.Instance.SmeltBatchProductionEnd(_communityID,_productionParam.T216LeafID,
                    _productionParam.T107LeafID, batchNumber, _sysLogID, out errCode, out errText);
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

        #region 事件 
        private void btnStart_Click(object sender, EventArgs e) {
            if (!OperatorCodeValidate()) {
                return;
            }
            if (!ProductionDateValidate()) {
                return;
            }
            if (!StartProduction()) {
                return;
            }
            RefreshFurnace(true);
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
         
        private void ucGrdSpectrum_SaveClick(object sender, System.EventArgs e) {
            if (!SaveSmeltParas(Optype.Spectrum)) {
                return;
            }
            this.ucGrdSpectrum.DataSource.Rows.Clear();
            this.ucGrdSpectrum.DataSource.Columns.Clear();
            this.ucGrdSpectrum.vGridControl.Rows.Clear();
            SetParaGrid(Optype.Spectrum);

        }

        private void ucGrdSample_SaveClick(object sender, System.EventArgs e) {
            if (!SaveSmeltParas(Optype.Sample)) {
                return;
            }
            this.ucGrdSample.DataSource.Rows.Clear();
            this.ucGrdSample.DataSource.Columns.Clear();
            this.ucGrdSample.vGridControl.Rows.Clear();
            SetParaGrid(Optype.Sample);
        }

        private void ucGrdBaked_SaveClick(object sender, System.EventArgs e) {
            StopProduction();
            RefreshFurnace();
        }

        private void btnRowMaterialSave_Click(object sender, EventArgs e) {
            if (!RowMatierialAjudgement()) {
                return;
            }
            SetRowMaterial();
        }

        private void dtProductDate_EditValueChanged(object sender, EventArgs e) {
            RefreshFurnace();
        }
         
        #endregion  

        private void btnPrint_Click(object sender, EventArgs e) {
            //string strProcedureName =string.Format("{0}.{1}",className,MethodBase.GetCurrentMethod().Name);

            //WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            //try {
            //    string lotNumber = "";

            //    #region 调用存储过程，在系统中登记当前生产工单的物料配送信息已经被打印
            //    bool saveSucccessed = false;
            //    saveSucccessed = SavePWOMaterialDeliver();
            //    #endregion

            //    if (saveSucccessed) {
            //        #region 获取当前工单的生产批次号
            //        {
            //            int errCode = 0;
            //            string errText = "";

            //            IRAPMESClient.Instance.ufn_GetLotNumberFromPWO(
            //                IRAPUser.Instance.CommunityID,
            //                order.AF482PK,
            //                order.PWONo,
            //                ref lotNumber,
            //                out errCode,
            //                out errText);
            //            WriteLog.Instance.Write(
            //                string.Format("({0}){1}", errCode, errText),
            //                strProcedureName);
            //        }
            //        #endregion

            //        #region 打印
            //        MemoryStream ms;
            //        switch (IRAPUser.Instance.CommunityID) {
            //            case 60023:
            //                ms = new MemoryStream(Properties.Resources.WIPTransferTrackSheet_60023);
            //                break;
            //            default:
            //                ms = new MemoryStream(Properties.Resources.WIPTransferTrackSheet);
            //                break;
            //        }
            //        report.Load(ms);

            //        if (printWIPProductInfoTrack && IRAPUser.Instance.CommunityID == 60010) {
            //            ms = new MemoryStream(Properties.Resources.WIPProductInfoTrack);
            //            report1.Load(ms);
            //        }

            //        try {
            //            switch (IRAPUser.Instance.CommunityID) {
            //                case 60023:  // 新康达打印的生产流转卡
            //                    #region 获取生产流传卡打印的要素
            //                    int errCode = 0;
            //                    string errText = "";
            //                    List<ProductionFlowCard> datas = new List<ProductionFlowCard>();
            //                    IRAPSCESClient.Instance.ufn_GetList_ProductionFlowCard(
            //                        IRAPUser.Instance.CommunityID,
            //                        orderFactID,
            //                        IRAPUser.Instance.SysLogID,
            //                        ref datas,
            //                        out errCode,
            //                        out errText);
            //                    WriteLog.Instance.Write(
            //                        string.Format("({0}){1}", errCode, errText),
            //                        strProcedureName);
            //                    if (errCode != 0) {
            //                        ShowMessageBox.Show(
            //                            errText,
            //                            "获取流转卡打印要素",
            //                            MessageBoxButtons.OK,
            //                            MessageBoxIcon.Error);
            //                        return;
            //                    }
            //                    #endregion

            //                    #region 向内存表中插入记录，以便生成打印内容
            //                    DataSet ds = new DataSet();
            //                    DataTable dt = new DataTable();
            //                    dt.TableName = "ProductionFlowCard";
            //                    dt.Columns.Add("Ordinal", typeof(int));
            //                    dt.Columns.Add("T102Code", typeof(string));
            //                    dt.Columns.Add("T102NodeName", typeof(string));
            //                    dt.Columns.Add("PWONo", typeof(string));
            //                    dt.Columns.Add("PWOIssuingFactID", typeof(long));
            //                    dt.Columns.Add("MONumber", typeof(string));
            //                    dt.Columns.Add("OrderQty", typeof(string));
            //                    dt.Columns.Add("StartTime", typeof(string));
            //                    dt.Columns.Add("MaterialList", typeof(string));
            //                    dt.Columns.Add("T134NodeName", typeof(string));
            //                    dt.Columns.Add("T211NodeName", typeof(string));
            //                    dt.Columns.Add("T216Name", typeof(string));
            //                    dt.Columns.Add("T133Name", typeof(string));
            //                    dt.Columns.Add("T106Name", typeof(string));
            //                    dt.Columns.Add("Remark", typeof(string));

            //                    foreach (ProductionFlowCard data in datas) {
            //                        dt.Rows.Add(
            //                            data.Ordinal,
            //                            data.T102Code,
            //                            data.T102NodeName,
            //                            data.PWONo,
            //                            data.PWOIssuingFactID,
            //                            data.MONumber,
            //                            data.OrderQuantity.ToString(),
            //                            data.StartTime,
            //                            data.MaterialList,
            //                            data.T134NodeName,
            //                            data.T211NodeName,
            //                            data.T216Name,
            //                            data.T133Name,
            //                            data.T106Name,
            //                            data.Remark);
            //                    }

            //                    ds.Tables.Add(dt);
            //                    #endregion

            //                    report.RegisterData(ds);
            //                    report.GetDataSource("ProductionFlowCard").Enabled = true;

            //                    break;
            //                default:    // 仪征打印的生产流转卡
            //                    report.Parameters.FindByName("BarCode").Value = order.PWONo;
            //                    report.Parameters.FindByName("DeliveryWorkshop").Value = "";
            //                    report.Parameters.FindByName("StorehouseCode").Value =
            //                        string.Format(
            //                            "{0}({1})",
            //                            materials[0].T173Name,
            //                            materials[0].T173Code);
            //                    report.Parameters.FindByName("T106Code").Value = materials[0].AtStoreLocCode;
            //                    report.Parameters.FindByName("WorkshopName").Value =
            //                        string.Format(
            //                            "{0}({1})",
            //                            materials[0].DstWorkShopDesc,
            //                            materials[0].DstWorkShopCode);
            //                    report.Parameters.FindByName("ProductLine").Value = order.T134Name;
            //                    report.Parameters.FindByName("AdvicedPickedQty").Value = materials[0].SuggestedQuantityToPick;
            //                    report.Parameters.FindByName("StartingDate").Value = order.PlannedStartDate;
            //                    report.Parameters.FindByName("CompletingDate").Value = order.PlannedCloseDate;
            //                    report.Parameters.FindByName("PrintingDate").Value = DateTime.Now.ToString("yyyy-MM-dd");
            //                    report.Parameters.FindByName("Unit").Value = materials[0].UnitOfMeasure;
            //                    report.Parameters.FindByName("MONo").Value = order.MONumber;
            //                    report.Parameters.FindByName("LineNo").Value = order.MOLineNo;
            //                    report.Parameters.FindByName("LotNumber").Value = lotNumber;
            //                    report.Parameters.FindByName("MaterialTexture").Value = materials[0].T131Code;
            //                    report.Parameters.FindByName("ActualPickedBars").Value = materials[0].ActualQtyDecompose;
            //                    report.Parameters.FindByName("OrderQty").Value = order.PlannedQuantity;
            //                    report.Parameters.FindByName("MaterialCode").Value = materials[0].MaterialCode;
            //                    report.Parameters.FindByName("MaterialDescription").Value = materials[0].MaterialDesc;
            //                    report.Parameters.FindByName("TransferringInDate").Value = DateTime.Now.ToString("yyyy-MM-dd");
            //                    if (materials[0].ActualQuantityToDeliver.IntValue != 0)
            //                        report.Parameters.FindByName("InQuantity").Value = materials[0].ActualQuantityToDeliver.ToString();
            //                    else
            //                        report.Parameters.FindByName("InQuantity").Value = "";
            //                    report.Parameters.FindByName("FatherMaterialCode").Value = order.ProductNo;
            //                    report.Parameters.FindByName("FatherMaterialName").Value = order.ProductDesc;
            //                    report.Parameters.FindByName("DstT106Code").Value = materials[0].DstT106Code;
            //                    break;
            //            }

            //            if (printWIPProductInfoTrack && IRAPUser.Instance.CommunityID == 60010) {
            //                report1.Parameters.FindByName("BarCode").Value = order.PWONo;
            //                report1.Parameters.FindByName("DeliveryWorkshop").Value = "";
            //                report1.Parameters.FindByName("StorehouseCode").Value =
            //                    string.Format(
            //                        "{0}({1})",
            //                        materials[0].T173Name,
            //                        materials[0].T173Code);
            //                report1.Parameters.FindByName("T106Code").Value = materials[0].AtStoreLocCode;
            //                report1.Parameters.FindByName("WorkshopName").Value = materials[0].DstWorkShopCode;
            //                report1.Parameters.FindByName("ProductLine").Value = order.T134Name;
            //                report1.Parameters.FindByName("AdvicedPickedQty").Value = materials[0].SuggestedQuantityToPick;
            //                report1.Parameters.FindByName("StartingDate").Value = order.PlannedStartDate.Substring(5, 5);
            //                report1.Parameters.FindByName("CompletingDate").Value = order.PlannedCloseDate.Substring(5, 5);
            //                report1.Parameters.FindByName("PrintingDate").Value = DateTime.Now.ToString("MM-dd HH:mm:ss");
            //                report1.Parameters.FindByName("Unit").Value = materials[0].UnitOfMeasure;
            //                report1.Parameters.FindByName("MONo").Value = order.MONumber;
            //                report1.Parameters.FindByName("LineNo").Value = order.MOLineNo;
            //                report1.Parameters.FindByName("LotNumber").Value = lotNumber;
            //                report1.Parameters.FindByName("MaterialTexture").Value = materials[0].T131Code;
            //                report1.Parameters.FindByName("ActualPickedBars").Value = materials[0].ActualQtyDecompose;
            //                report1.Parameters.FindByName("OrderQty").Value = order.PlannedQuantity.IntValue.ToString();
            //                report1.Parameters.FindByName("MaterialCode").Value = materials[0].MaterialCode;
            //                report1.Parameters.FindByName("MaterialDescription").Value = materials[0].MaterialDesc;
            //                report1.Parameters.FindByName("TransferringInDate").Value = DateTime.Now.ToString("yyyy-MM-dd");
            //                if (materials[0].ActualQuantityToDeliver.IntValue != 0)
            //                    report1.Parameters.FindByName("InQuantity").Value = materials[0].ActualQuantityToDeliver.ToString();
            //                else
            //                    report1.Parameters.FindByName("InQuantity").Value = "";
            //                report1.Parameters.FindByName("FatherMaterialCode").Value = order.ProductNo;
            //                report1.Parameters.FindByName("FatherMaterialName").Value = order.ProductDesc;
            //                report1.Parameters.FindByName("DstT106Code").Value = materials[0].DstT106Code;
            //            }
            //        } catch (Exception error) {
            //            WriteLog.Instance.Write(error.Message, strProcedureName);
            //            ShowMessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        System.Drawing.Printing.PrinterSettings prnSetting =
            //            new System.Drawing.Printing.PrinterSettings();
            //        if (report.Prepare()) {
            //            bool rePrinter = false;
            //            do {
            //                if (report.ShowPrintDialog(out prnSetting)) {
            //                    report.PrintPrepared(prnSetting);
            //                    rePrinter = (
            //                        ShowMessageBox.Show(
            //                            "物料配送流转卡已经打印完成，是否需要重新打印？",
            //                            "系统信息",
            //                            MessageBoxButtons.YesNo,
            //                            MessageBoxIcon.Question,
            //                            MessageBoxDefaultButton.Button2) == DialogResult.Yes);
            //                }
            //            } while (rePrinter);
            //        }

            //        if (IRAPUser.Instance.CommunityID == 60010 && printWIPProductInfoTrack) {
            //            IRAPMessageBox.Instance.ShowInformation(
            //                "请将打印机中的打印纸更换为【产品信息跟踪卡】，更换完毕后点击确认开始打印");

            //            if (report1.Prepare()) {
            //                bool rePrint = false;
            //                do {
            //                    if (report1.ShowPrintDialog(out prnSetting)) {
            //                        report1.PrintPrepared(prnSetting);
            //                        rePrint =
            //                            (
            //                                ShowMessageBox.Show(
            //                                    "【产品信息跟踪卡】已经打印完成，是否需要重新打印？",
            //                                    "系统信息",
            //                                    MessageBoxButtons.YesNo,
            //                                    MessageBoxIcon.Question,
            //                                    MessageBoxDefaultButton.Button2) == DialogResult.Yes
            //                            );
            //                    }
            //                } while (rePrint);
            //            }
            //        }
            //        btnClose.PerformClick();
            //        #endregion
            //    }
            //} finally {
            //    WriteLog.Instance.WriteEndSplitter(strProcedureName);
            //}
        }

        /// <summary>
        /// 刷新页面
        /// </summary>
        public void RefreshFurnace() {
            RefreshFurnace(false);
        } 

        /// <summary>
        /// 刷新页面
        /// </summary>
        /// <param name="keepMaterial"></param>
        private void RefreshFurnace(bool keepMaterial) {
            var smeltBatchProductionInfos = ReLoadProduction();
            if (smeltBatchProductionInfos == null || smeltBatchProductionInfos.Count < 1 || smeltBatchProductionInfos[0] == null) {
                RefreshWithNoProduction(keepMaterial);
                return;
            }
            var currentInfo = smeltBatchProductionInfos[0];
            if (currentInfo.InProduction == 1) {//有在产产品
                _ProductingNow = true;
                if (!string.IsNullOrEmpty(currentInfo.OperatorCode)) {
                    this.txtOperator.Text = string.Format("[{0}]{1}", currentInfo.OperatorCode, currentInfo.OperatorName);
                }
                _operatorCode = currentInfo.OperatorCode;
                _operatorName = currentInfo.OperatorName;
                this.lblFurnaceTime.Text = currentInfo.BatchNumber;
                this.lblFurnaceTime.Tag = currentInfo;
                SetCurrentSmeltInfo(currentInfo);
                SetParaGrid(Optype.Spectrum);
                SetParaGrid(Optype.Sample);
                SetParaGrid(Optype.Baked);
                SetRowMaterial();
                SetOrderInfo();
                ChangeTabPage();
            } else if (currentInfo.InProduction == 0) {//没有在产产品
                RefreshWithNoProduction(keepMaterial);
            }   
        }

        /// <summary>
        /// 没有正在生产的产品
        /// </summary>
        private void RefreshWithNoProduction(bool keepMaterial) {
            _ProductingNow = false;
            SetCurrentSmeltInfo(null);
            SetWaitingFurnace();
            if (!keepMaterial) {
                SetSmeltMaterialItems();
                SetSmeltMethodItems();
            } 
            SetOrderInfo();
            ChangeTabPage();
        }
 
    }
}
