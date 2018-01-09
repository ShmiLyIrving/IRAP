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
        private List<SmeltMaterialItem> GetSmeltMaterialItems() {
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
                return data;
            } catch (Exception error) {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }
        
        private void SetSmeltMaterialItems(){
            var smeltMaterialItems = GetSmeltMaterialItems();
            if (smeltMaterialItems==null||smeltMaterialItems.Count == 0) {
                return;
            }
            this.grdBurdenInfo.DataSource = smeltMaterialItems;
            this.grdBurdenInfoView.Tag = smeltMaterialItems;
        }
        #endregion

        #region 事件

        private void ucFurnace_Load(object sender, EventArgs e) {
            SetWaitingFurnace();
            SetOrderInfo();
            SetSmeltMaterialItems();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            if (!OperatorCodeValidate()) {
                return;
            }
        }
        #endregion

       

    }
}
