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
            this.lbcFurnace.DataSource = GetFurnaces();
            dtProductDate.DateTime = DateTime.Now;
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
        /// 获取炉次号
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private List<WaitingSmelt> GetWaitingSmelts(string startDate)
        {
            int errCode;
            string errText;
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            try
            {
                List<WaitingSmelt> data = IRAPMESProductionClient.Instance.GetWaitingSmeilts(_communityID, _productionParam.T107LeafID,
                    _productionParam.T216LeafID, _productionParam.T133LeafID, startDate, _sysLogID, out errCode, out errText);
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
        private bool ProductionDateValidate()
        {
            string date = this.dtProductDate.EditValue == null ? null : this.dtProductDate.EditValue.ToString();
            if (string.IsNullOrEmpty(date))
            {
                this.dtProductDate.ErrorText = "请选择生产日期！";
                return false;
            }
            return true;
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
                var orderInfo = IRAPMESProductionClient.Instance.GetOrderInfo(_communityID, this.lblFurnaceTime.Text, _sysLogID,
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
                bool rePrinter = false;
                do
                {
                    if (_report.ShowPrintDialog(out prnSetting))
                    {
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
        /// <summary>
        /// 刷新订单信息
        /// </summary>
        private void RefreshOrderInfo()
        {
            if (!ProductionDateValidate())
            {
                this.lblFurnaceTime.Text = "";
                this.lblFurnaceTime.Tag = null;
                return;
            }
            string date = this.dtProductDate.EditValue == null ? null : this.dtProductDate.EditValue.ToString();
            List<WaitingSmelt> furnaces = GetWaitingSmelts(date);
            if (furnaces == null || furnaces.Count == 0 || furnaces[0] == null)
            {
                this.grdCtrProductionInfo.DataSource = null;
                this.lblFurnaceTime.Text = "";
                this.lblFurnaceTime.Tag = null;
                return;
            }
            WaitingSmelt currentFurnace = furnaces[0];
            this.lblFurnaceTime.Text = currentFurnace.BatchNumber;
            this.lblFurnaceTime.Tag = currentFurnace;
            InsertDataIntoOrderInfo();
        }
        #endregion
        #region 事件
        private void lbcFurnace_SelectedIndexChanged(object sender, EventArgs e)
        {
            _productionParam = lbcFurnace.SelectedItem as WIPStation;
            RefreshOrderInfo();
        }
       
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
                foreach (var item in data)
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
            RefreshOrderInfo();
        }
        #endregion


    }
}