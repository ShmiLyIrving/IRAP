using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global.Enums;
using IRAP.Entities.MDM;
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC.UserControls
{
    public partial class ucCasting : DevExpress.XtraEditors.XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string caption = "";

        private WIPStation station = null;
        /// <summary>
        /// 设备的当前生产状态
        /// </summary>
        private ProductionStatus prdtStatus = ProductionStatus.Idle;

        public ucCasting()
        {
            InitializeComponent();

            if (Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2) == "en")
                caption = "System information";
            else
                caption = "系统信息";
        }

        public ucCasting(WIPStation station) : this()
        {
            this.station = station;
        }

        private void RefreshForm()
        {
            switch (prdtStatus)
            {
                case ProductionStatus.Idle:
                    edtOperator.Enabled = true;
                    edtProductDate.Enabled = true;

                    tpBurden.PageEnabled = true;
                    tpSpectrum.PageEnabled = false;
                    tpMatieralAjustment.PageEnabled = false;
                    tpSample.PageEnabled = false;
                    tpBaked.PageEnabled = false;

                    break;
                case ProductionStatus.Busy:
                    edtOperator.Enabled = false;
                    edtProductDate.Enabled = false;

                    tpBurden.PageEnabled = false;
                    tpSpectrum.PageEnabled = true;
                    tpMatieralAjustment.PageEnabled = true;
                    tpSample.PageEnabled = true;
                    tpBaked.PageEnabled = true;

                    break;
            }
        }

        private SmeltBatchProductionInfo GetWorkUnitProductionInfo()
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
                SmeltBatchProductionInfo data = new SmeltBatchProductionInfo();

                IRAPMESSmeltClient.Instance.ufn_GetInfo_SmeltBatchProduct(
                            IRAPUser.Instance.CommunityID,
                            station.T107LeafID,
                            station.T216LeafID,
                            station.T133LeafID,
                            IRAPUser.Instance.SysLogID,
                            ref data,
                            out errCode,
                            out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    if (data.InProduction == 0)
                        return null;
                    else
                        return data;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void ucCasting_Load(object sender, EventArgs e)
        {
            SmeltBatchProductionInfo data = GetWorkUnitProductionInfo();
            if (data != null)
            {
                prdtStatus = ProductionStatus.Busy;

                edtOperator.Text =
                    string.Format(
                        "[{0}]{1}",
                        data.OperatorCode,
                        data.OperatorName);

                edtProductDate.DateTime = data.BatchStartDate;

                lblBatchNo.Text = data.BatchNumber;
            }
            else
            {
                prdtStatus = ProductionStatus.Idle;

                edtProductDate.DateTime = DateTime.Now;
            }

            RefreshForm();
        }

        private void edtProductDate_EditValueChanged(object sender, EventArgs e)
        {
            List<WaitingSmelt> datas = new List<WaitingSmelt>();
            int errCode = 0;
            string errText = "";

            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                if (prdtStatus == ProductionStatus.Idle)
                {
                    #region 获取已排定的未开始生产的炉次号
                    try
                    {
                        IRAPMESSmeltClient.Instance.ufn_GetList_WaitSmeltBatchProduction(
                            IRAPUser.Instance.CommunityID,
                            station.T107LeafID,
                            station.T216LeafID,
                            station.T133LeafID,
                            edtProductDate.DateTime.ToString("yyyy-MM-dd"),
                            IRAPUser.Instance.SysLogID,
                            ref datas,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("({0}){1}", errCode, errText),
                            strProcedureName);
                        if (errCode != 0)
                        {
                            XtraMessageBox.Show(
                                errText,
                                "提示信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (datas.Count > 0)
                                lblBatchNo.Text = datas[0].BatchNumber;
                            else
                            {
                                XtraMessageBox.Show(
                                    "没有找到已排定未开始生产的炉次了",
                                    "提示信息",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        XtraMessageBox.Show(
                            string.Format(
                                "获取未开工的炉次号时，发生错误：[{0}]", error.Message),
                            "提示信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    #endregion
                }

                #region 根据当前的炉次号，获取订单信息
                List<OrderInfo> orders = new List<OrderInfo>();

                IRAPMESSmeltClient.Instance.ufn_GetList_SmeltBatchPWONo(
                    IRAPUser.Instance.CommunityID,
                    lblBatchNo.Text,
                    IRAPUser.Instance.SysLogID,
                    ref orders,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                grdvSmeltPWOs.BeginDataUpdate();
                grdSmeltPWOs.DataSource = orders;
                grdvSmeltPWOs.EndDataUpdate();

                grdvSmeltPWOs.BestFitColumns();
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
