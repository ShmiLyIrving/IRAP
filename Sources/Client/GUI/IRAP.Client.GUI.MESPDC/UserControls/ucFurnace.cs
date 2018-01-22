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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using IRAP.Client.Global.GUI.Dialogs;

namespace IRAP.Client.GUI.MESPDC.UserControls {
    public partial class ucFurnace : XtraUserControl {
        public ucFurnace(WIPStation param, int communityID, int sysLogID) {
            InitializeComponent();
            this._productionParam = param;
            this._communityID = communityID;
            this._sysLogID = sysLogID;
        }

        #region 字段
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private ImportParam _importPara = new ImportParam();
        private List<ImportMetaData> _importMetaData = new List<ImportMetaData>();
        private List<OrderInfo> _orderInfo = new List<OrderInfo>();
        private bool _ProductingNow = false;//是否正在生产
        private string _operatorCode;
        private string _operatorName;
        private BindingList<SmeltMaterialItemClient> _smeltMaterialItems = new BindingList<SmeltMaterialItemClient>();
        private int _readOnlyCount = 0;
        private FastReport.Report _report = new FastReport.Report();
        #endregion
         
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
            this.dtProductDate.ErrorText = "";
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
            _orderInfo = GetOrderInfo(); 
            InsertDataIntoOrderInfo();
        }

        private void InsertDataIntoOrderInfo(){
            this.grdCtrProductionInfo.BeginUpdate();
            this.grdCtrProductionInfo.DataSource = null;
            if (_orderInfo ==null||_orderInfo.Count==0) {
                return;
            }
            this.grdCtrProductionInfo.DataSource = _orderInfo;
            this.grdCtrProductionInfoView.BestFitColumns();
            this.grdCtrProductionInfo.EndUpdate();
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

        #endregion

        #region 配料及开炉熔炼
        /// <summary>
        /// 获取配料信息
        /// </summary>
        private BindingList<SmeltMaterialItemClient> GetSmeltMaterialItems() {
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
                var datas = new BindingList<SmeltMaterialItemClient>();
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
            this.grdBurdenInfo.BeginUpdate();
            this.grdBurdenInfo.DataSource = null;
            var smeltMaterialItems = GetSmeltMaterialItems();
            if (smeltMaterialItems==null||smeltMaterialItems.Count == 0) {
                return;
            }
            this.grdBurdenInfo.DataSource = smeltMaterialItems;
            this.grdBurdenInfoView.Tag = smeltMaterialItems;
            this.grdBurdenInfoView.BestFitColumns();
            this.grdBurdenInfo.EndUpdate();
        }

        private List<SmeltBatchMaterial> GetLotNumber(int t101LeafID) {
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try {
                var data = IRAPMESProductionClient.Instance.GetSmeltBatchMaterial(_communityID, t101LeafID, _sysLogID,
                    out errCode, out errText);
                if (errCode != 0) {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                } 
                return data;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void SetLotNumber(GridView view, CustomRowCellEditEventArgs e) {
            if (e.RowHandle < 0) {
                return;
            }
            view.BeginUpdate();
            var edit = new RepositoryItemComboBox();
            var currentRow = view.GetFocusedRow() as SmeltMaterialItemClient;
            if (currentRow == null) {
                return;
            }
            var data = GetLotNumber(currentRow.T101LeafID);
            if (data == null || data.Count == 0) {
                return;
            }
            currentRow.LotNumber = data[0] == null ? 0 : data[0].LotNumber;
            foreach (var item in data) {
                if (data == null) {
                    continue;
                }
                edit.Items.Add(item.LotNumber);
            }
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            e.RepositoryItem = edit;
            view.EndUpdate();
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
            this.grdProductPara.BeginUpdate();
            this.grdProductPara.DataSource = null;
            var smeltMethodItems = GetSmeltMethodItems();
            if (smeltMethodItems==null||smeltMethodItems.Count==0) {
                return;
            }
            this.grdProductPara.DataSource = smeltMethodItems;
            this.grdProductParaView.Tag = smeltMethodItems;
            this.grdProductPara.EndUpdate();
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
                    row.SetAttribute("LotNumber", item.LotNumber.ToString());
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
            grd.vGridControl.BeginUpdate();
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
            grd.vGridControl.EndUpdate();
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
                    row1[colName] = value;
                    row1["ReadOnly"] = true;
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
            var xml = GetRowMaterialXml(this.grdRowMaterial.DataSource as BindingList<SmeltMaterialItemClient>);
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
            this.grdRowMaterial.BeginUpdate();
            this.grdRowMaterial.DataSource = null;
            _readOnlyCount = 0;
            _smeltMaterialItems = GetSmeltMaterialItems();
            if (_smeltMaterialItems == null || _smeltMaterialItems.Count == 0) {
                return;
            }
            BindingList<SmeltMaterialItemClient> newData = new BindingList<SmeltMaterialItemClient>();
            foreach (SmeltMaterialItemClient item in _smeltMaterialItems) {
                GetHistorySmeltMaterial(item, newData); 
            } 
            this.grdRowMaterial.DataSource = newData;
            _readOnlyCount = newData.Count;
            this.grdRowMaterialView.BestFitColumns();
            this.grdRowMaterialView.Tag = new List<SmeltMaterialItemClient>(newData);
            this.grdRowMaterial.EndUpdate();
        }

        private string GetRowMaterialXml(BindingList<SmeltMaterialItemClient> data) { 
            if (data==null||data.Count == 0) {
                return null;
            }
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("RSFact");
            xmlDoc.AppendChild(root);
            var rF13Node = xmlDoc.CreateElement("RF13_1");
            foreach (SmeltMaterialItemClient item in data) {
                if (item.IsReadOnly) {
                    continue;
                }
                var row = xmlDoc.CreateElement("Row");
                row.SetAttribute("Ordinal", item.Ordinal.ToString());
                row.SetAttribute("T101LeafID", item.T101LeafID.ToString());
                row.SetAttribute("LotNumber", item.LotNumber.ToString());
                row.SetAttribute("Qty", item.Qty.ToString());
                row.SetAttribute("Scale", item.Scale.ToString());
                row.SetAttribute("UnitOfMeasure", item.UnitOfMeasure);
                rF13Node.AppendChild(row);
            }
            root.AppendChild(rF13Node);
            return xmlDoc.OuterXml; 
        }

        /// <summary>
        /// 获取历史数据
        /// </summary>
        /// <param name="rowSmelt"></param>
        /// <returns></returns>
        private void GetHistorySmeltMaterial(SmeltMaterialItemClient rowSmelt, BindingList<SmeltMaterialItemClient> items) {
            if (string.IsNullOrEmpty(rowSmelt.DataXML)) {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(rowSmelt.DataXML);
            var nodes = doc.SelectNodes("RF13_1/Row");
            if (nodes==null||nodes.Count==0) {
                return;
            } 
            foreach (XmlNode node in nodes) {
                SmeltMaterialItemClient item = new SmeltMaterialItemClient()
                { IsReadOnly = true,T101Code = rowSmelt.T101Code,T101LeafID = rowSmelt.T101LeafID,T101Name = rowSmelt.T101Name};
                var lotNumber = node.Attributes["LotNumber"] == null || string.IsNullOrEmpty(node.Attributes["LotNumber"].Value) ? 0 : Convert.ToInt32(node.Attributes["LotNumber"].Value);
                var qty = node.Attributes["Qty"] == null || string.IsNullOrEmpty(node.Attributes["Qty"].Value) ? 0 : Convert.ToInt64(node.Attributes["Qty"].Value);
                item.LotNumber = lotNumber;
                item.Qty = qty;
                items.Add(item);
            } 
        }

        private string[] GetT101Code(List<SmeltMaterialItemClient> items) {
            if (items == null || items.Count == 0) {
                return null;
            }
            List<string> list = new List<string>(); 
            for (int i = 0; i < items.Count; i++) {
                if (list.Contains(items[i].T101Code)) {
                    continue;
                }
                list.Add(items[i].T101Code);
            }
            return list.ToArray<string>();
        }

        private void SetT101Code(GridView view, CustomRowCellEditEventArgs e) { 
            var smelts = view.Tag as List<SmeltMaterialItemClient>;
            if (smelts == null || smelts.Count == 0) {
                return;
            }
            RepositoryItemComboBox edit = new RepositoryItemComboBox();
            edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            edit.Items.AddRange(GetT101Code(smelts));
            edit.SelectedValueChanged += edit_SelectedValueChanged;
            e.RepositoryItem = edit;
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

        #region 刷新页面
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
                this.SuspendLayout();
                _ProductingNow = true;
                if (!string.IsNullOrEmpty(currentInfo.OperatorCode)) {
                    this.txtOperator.Text = string.Format("[{0}]{1}", currentInfo.OperatorCode, currentInfo.OperatorName);
                }
                _operatorCode = currentInfo.OperatorCode;
                _operatorName = currentInfo.OperatorName;
                this.txtOperator.Enabled = false;
                this.dtProductDate.Enabled = false;
                this.lblFurnaceTime.Text = currentInfo.BatchNumber;
                this.lblFurnaceTime.Tag = currentInfo;
                SetCurrentSmeltInfo(currentInfo);
                SetParaGrid(Optype.Spectrum);
                SetParaGrid(Optype.Sample);
                SetParaGrid(Optype.Baked);
                SetRowMaterial();
                SetOrderInfo();
                ChangeTabPage();
                this.ResumeLayout();
            } else if (currentInfo.InProduction == 0) {//没有在产产品
                RefreshWithNoProduction(keepMaterial);
            }
        }

        /// <summary>
        /// 没有正在生产的产品
        /// </summary>
        private void RefreshWithNoProduction(bool keepMaterial) {
            this.SuspendLayout();
            _ProductingNow = false;
            this.txtOperator.Enabled = true;
            this.dtProductDate.Enabled = true;
            SetCurrentSmeltInfo(null);
            SetWaitingFurnace();
            if (!keepMaterial) {
                SetSmeltMaterialItems();
                SetSmeltMethodItems();
            }
            SetOrderInfo();
            ChangeTabPage();
            this.ResumeLayout();
        }
        #endregion

        #region 打印
        private void PrintOrderInfo(OrderInfo info) {
            if (info == null) {
                return;
            }
            _report.Parameters.FindByName("PWONo").Value = info.PWONo;
            _report.Parameters.FindByName("PlatNo").Value = info.PlateNo;
            _report.Parameters.FindByName("T102Code").Value = info.T102Code;
            _report.Parameters.FindByName("LotNumber").Value = info.LotNumber;
            _report.Parameters.FindByName("MachineModeling").Value = info.MachineModelling;
            _report.Parameters.FindByName("Texture").Value = info.Texture;
            _report.Parameters.FindByName("BatchNumber").Value = info.BatchNumber;
            System.Drawing.Printing.PrinterSettings prnSetting =
                     new System.Drawing.Printing.PrinterSettings();
            if (_report.Prepare()) {
                bool rePrinter = false;
                do {
                    if (_report.ShowPrintDialog(out prnSetting)) {
                        _report.PrintPrepared(prnSetting);
                        rePrinter = (
                            ShowMessageBox.Show(
                                "铸造产品标识卡已经打印完成，是否需要重新打印？",
                                "系统信息",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes);
                    }
                } while (rePrinter);
            }
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

        private void grdBurdenInfoView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
            if (e.Column.FieldName == "LotNumber") {
                SetLotNumber(sender as GridView, e); 
            }
        }

        private void grdRowMaterialView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
            if (e.Column.FieldName == "LotNumber") {
                SetLotNumber(sender as GridView, e);
                return;
            }
            if (e.Column.FieldName == "T101Code") {
                SetT101Code(sender as GridView, e);
                return;
            }
        }

        private void edit_SelectedValueChanged(object sender, EventArgs e) {
            var edit = sender as ComboBoxEdit;
            if (edit.EditValue == null) {
                return;
            }
            var t101Code = edit.EditValue.ToString();
            var newData = this.grdRowMaterialView.GetFocusedRow() as SmeltMaterialItemClient;
            if (newData == null) {
                return;
            }
            newData.T101Code = t101Code; 
            var currentItems = _smeltMaterialItems.Where(p => p.T101Code == t101Code).ToList<SmeltMaterialItemClient>();
            if (currentItems == null || currentItems.Count == 0) {
                return;
            }
            var currentItem = currentItems[0];
            if (currentItem == null) {
                return;
            }
            newData.T101Name = currentItem.T101Name;
            newData.T101LeafID = currentItem.T101LeafID;
            newData.UnitOfMeasure = currentItem.UnitOfMeasure;
            newData.Scale = currentItem.Scale;
            this.grdRowMaterialView.UpdateCurrentRow();
          }

        private void grdRowMaterialView_ShowingEditor(object sender, CancelEventArgs e) {
            var view = sender as GridView;
            var currentItem = view.GetFocusedRow() as SmeltMaterialItemClient;
            if (currentItem == null) {
                return;
            }
            if (currentItem.IsReadOnly) {
                e.Cancel = true;
            }
        }

        private void grdRowMaterialView_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e) {
            var view = sender as GridView;
            if (view == null) {
                return;
            }
            var item = view.GetFocusedRow() as SmeltMaterialItemClient;
            if (item == null) {
                return;
            }
            if (item.IsReadOnly) {
                e.Cancel = true;
            }
        }

        private void grdRowMaterialView_RowClick(object sender, RowClickEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var currentRow = this.grdRowMaterialView.GetFocusedRow() as SmeltMaterialItemClient;
            if (currentRow == null) {
                return;
            }
            if (currentRow.IsReadOnly) {
                return;
            }
            this.grdRowMaterialView.DeleteSelectedRows();
        }

        private void btnPrint_Click(object sender, EventArgs e) {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try {
                var data = this.grdCtrProductionInfo.DataSource as List<OrderInfo>;
                if (data == null || data.Count == 0) {
                    return;
                }
                MemoryStream ms;
                ms = new MemoryStream(Properties.Resources.双环_铸造产品标识卡);
                _report.Load(ms);
                foreach (var item in data) {
                    if (item.IsPrint) {
                        PrintOrderInfo(item);
                    }
                }
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                ShowMessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
        #endregion   

        #region 界面优化
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;//用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }
        #endregion
         
    }
}
