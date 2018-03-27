using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IRAP.Entities.MDM;
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;
using System.Reflection;
using IRAP.Client.User;
using IRAP.Global;
using System.IO;
using IRAP.Client.Global.GUI.Dialogs;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmProductionLabelPrint_Casting : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        public frmProductionLabelPrint_Casting()
        {
            InitializeComponent();
            List<WIPStation> Stations = GetFurnaces();
            foreach (WIPStation station in Stations)
            {
                cboFurnaces.Properties.Items.Add(station);
            }
            dtProductDate.DateTime = DateTime.Now;
            this.cboFurnaces.SelectedIndex = 0;
        }
        #region 字段
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private int _communityID = IRAPUser.Instance.CommunityID;
        private long _sysLogID =IRAPUser.Instance.SysLogID;
        private WIPStation _productionParam;
        private List<OrderInfo> _orderInfo = new List<OrderInfo>();
        private FastReport.Report _report = new FastReport.Report();
        #endregion
        #region 方法
        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <returns></returns>
        private List<WIPStation> GetFurnaces()
        {
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                List<WIPStation> data = IRAPMESProductionClient.Instance.GetFurnaceLists(_communityID, _sysLogID, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return data;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }
        /// <summary>
        /// 获取指定设备上指定日期的所有炉次号
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private List<WaitingSmelt> GetAllSmelts(string startDate)
        {
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                List<WaitingSmelt> data = IRAPMESProductionClient.Instance.GetAllSmelts(_communityID, 0,
                    0, _productionParam.T133LeafID, startDate, _sysLogID, out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return data;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return null;
        }
        private bool ProductionValidate()
        {
            string date = this.dtProductDate.EditValue == null ? null : this.dtProductDate.EditValue.ToString();
            string Furnace = this.cboFurnaces.Text;
            if (!string.IsNullOrEmpty(date)&&!string.IsNullOrEmpty(Furnace))
            {
                return true;
            }
            else if(string.IsNullOrEmpty(date))
            {
                this.dtProductDate.ErrorText = "请选择生产日期！";
            }
            else if(string.IsNullOrEmpty(Furnace))
            {
                this.cboFurnaces.ErrorText = "请选择设备！";
            }
            return false;
        }
        private void InsertDataIntoOrderInfo()
        {
            _orderInfo = GetOrderInfo();
            this.grdCtrProductionInfo.DataSource = null;
            if (_orderInfo == null || _orderInfo.Count == 0)
            {
                return;
            }
            this.grdCtrProductionInfo.DataSource = _orderInfo;
            this.grdCtrProductionInfoView.BestFitColumns();
        }
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <returns></returns>
        private List<OrderInfo> GetOrderInfo()
        {
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                List<OrderInfo> orderInfo = IRAPMESProductionClient.Instance.GetOrderInfo(_communityID, this.cboBatchNo.Text, _sysLogID,
                    out errCode, out errText);
                if (errCode != 0)
                {
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    XtraMessageBox.Show(errText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return orderInfo;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                XtraMessageBox.Show(error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
        /// <summary>
        /// 订单打印
        /// </summary>
        /// <param name="info"></param>
        private void PrintOrderInfo(OrderInfo info)
        {
            if (info == null)
            {
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
            if (_report.Prepare())
            {
                // 取消循环打印-李智颖 2018-3-2
                //bool rePrinter = false;
                //do
                //{
                    if (_report.ShowPrintDialog(out prnSetting))
                    {
                        _report.PrintPrepared(prnSetting);
                        //rePrinter = (
                        //    ShowMessageBox.Show(
                        //        "铸造产品标识卡已经打印完成，是否需要重新打印？",
                        //        "系统信息",
                        //        MessageBoxButtons.YesNo,
                        //        MessageBoxIcon.Question,
                        //        MessageBoxDefaultButton.Button2) == DialogResult.Yes);
                    }
                //} while (rePrinter);
            }
        }
        /// <summary>
        /// 刷新炉次列表
        /// </summary>
        private void RefreshBatchNo()
        {
            if (!ProductionValidate())
            {
                this.cboBatchNo.Properties.Items.Clear();
                this.cboBatchNo.Text = null;
                this.cboBatchNo.Tag = null;
                return;
            }
            this.dtProductDate.ErrorText = null;
            this.cboFurnaces.ErrorText = null;
            string date = this.dtProductDate.EditValue == null ? null : this.dtProductDate.EditValue.ToString();
            List<WaitingSmelt> furnaces = GetAllSmelts(date);
            if (furnaces == null || furnaces.Count == 0 || furnaces[0] == null)
            {
                this.grdCtrProductionInfo.DataSource = null;
                this.cboBatchNo.Properties.Items.Clear();
                this.cboBatchNo.Text = null;
                this.cboBatchNo.Tag = null;
                this.cboBatchNo.ErrorText = "没有发现当前日期设备上的炉次号！";
                return;
            }
            this.cboBatchNo.Properties.Items.Clear();
            this.cboBatchNo.Text = null;
            this.cboBatchNo.ErrorText = null;
            WaitingSmelt currentFurnace = furnaces[0];
            foreach (WaitingSmelt smelt in furnaces)
            {
                cboBatchNo.Properties.Items.Add(smelt);
            }
            cboBatchNo.SelectedIndex = 0;
            this.cboBatchNo.Tag = currentFurnace;
        }
        #endregion
        #region 事件       
        private void btn_Print_Click(object sender, EventArgs e)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<OrderInfo> data = this.grdCtrProductionInfo.DataSource as List<OrderInfo>;
                if (data == null || data.Count == 0)
                {
                    return;
                }
                MemoryStream ms;
                ms = new MemoryStream(Properties.Resources.双环_铸造产品标识卡);
                _report.Load(ms);
                foreach (OrderInfo item in data)
                {
                    if (item.IsPrint)
                    {
                        PrintOrderInfo(item);
                    }
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                ShowMessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
        private void dtProductDate_EditValueChanged(object sender, EventArgs e)
        {
            RefreshBatchNo();
        }
       
        private void cboFurnaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            _productionParam = cboFurnaces.SelectedItem as WIPStation;
            RefreshBatchNo();
        }

        private void cboBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertDataIntoOrderInfo();
        }
        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBatchNo();
        }
    }
}