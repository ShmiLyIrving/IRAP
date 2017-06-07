using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

using DevExpress.XtraGrid.Views.Grid;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entities.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.FVS
{
    public partial class frmWIPWaitingMonitor : IRAP.Client.Global.GUI.frmCustomKanbanBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        List<Dashboard_WIPWaiting> datas = new List<Dashboard_WIPWaiting>();

        public frmWIPWaitingMonitor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取在制品停滞跟踪数据列表
        /// </summary>
        /// <param name="t132ClickStream"></param>
        private void GetDashboardWIPWaiting(string t132ClickStream)
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

                try
                {
                    IRAPFVSClient.Instance.ufn_Dashboard_WIPWaiting(
                        IRAPUser.Instance.CommunityID,
                        t132ClickStream,
                        IRAPUser.Instance.SysLogID,
                        ref datas,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    AddLog(new AppOperationLog(DateTime.Now, -1, error.Message));
                    SetConnectionStatus(false);
                    return;
                }

                WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                if (errCode == 0)
                {
                    datas = (from row in datas
                             where row.DLVProgress >= 0
                             select row).ToList<Dashboard_WIPWaiting>();

                    grdMODelivery.DataSource = datas;
                    grdvMODelivery.BestFitColumns();
                    grdvMODelivery.OptionsView.RowAutoHeight = true;

                    SetConnectionStatus(true);
                }
                else
                {
                    AddLog(new AppOperationLog(DateTime.Now, -1, errText));
                    SetConnectionStatus(false);
                    grdMODelivery.DataSource = null;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void SetWOStatusPanelColor()
        {
            lblStatusNormal.BackColor = ColorTranslator.FromHtml("#00FF00");
            lblStatusSlower.BackColor = ColorTranslator.FromHtml("#FBF179");
            lblStatusSlowest.BackColor = ColorTranslator.FromHtml("#FF0000");

            //grdclmnOrdinal.Caption = "序号\nItem";
            //grdclmnPWONo.Caption = "生产工单号\nPWO No";
            //grdclmnMONumber.Caption = "订单号\nMO No";
            //grdclmnMOLineNo.Caption = "行号\nLine No";
            //grdclmProductNo.Caption = "产品编号\nProduct No";
            //grdclmProductName.Caption = "产品名称\nProdut Name";
            //grdclmMinutesWaited.Caption = "等待时间\nWait for Time";
            //grdclmT216Name.Caption = "滞在工序\n";
            //grdclmDLVProgress.Caption = "等待状态\nWaitting Status";
            //grdclmContainerNo.Caption = "容器编号\nContainer No";
            //grdclmWIPQty.Caption = "在制品数量\nWIP Quantity";
            //grdclmT216Name.Caption = "滞在工序\nWaitting for Operation";
            grdclmnOrdinal.Caption = "序号";
            grdclmnPWONo.Caption = "生产工单号";
            grdclmnMONumber.Caption = "订单号";
            grdclmnMOLineNo.Caption = "行号";
            grdclmProductNo.Caption = "产品编号";
            grdclmProductName.Caption = "产品名称";
            grdclmMinutesWaited.Caption = "等待时间";
            grdclmT216Name.Caption = "滞在工序";
            grdclmDLVProgress.Caption = "等待状态";
            grdclmContainerNo.Caption = "容器编号";
            grdclmWIPQty.Caption = "在制品数量";
            grdclmT216Name.Caption = "滞在工序";
        }

        private void frmWIPWaitingMonitor_Load(object sender, EventArgs e)
        {
            SetWOStatusPanelColor();
        }

        private void frmWIPWaitingMonitor_Resize(object sender, EventArgs e)
        {
            pnlRemark.Left = (this.Width - pnlRemark.Width) / 2;
        }

        private void frmWIPWaitingMonitor_Activated(object sender, EventArgs e)
        {
            GetDashboardWIPWaiting(t132ClickStream);

            if (grdMODelivery.DataSource != null)
            {
                this.grdvMODelivery.MoveFirst();

                if (autoSwtich)
                {
                    if (this.datas.Count > 0)
                    {
                        timer.Interval = this.nextFunction.WaitForSeconds * 1000;
                    }
                    else
                    {
                        timer.Interval = 10000;
                    }
                }
                else
                {
                    timer.Interval = 60000;
                }

                timer.Enabled = false;
                if (grdvMODelivery.RowCount - 1 > 0 &&
                    grdvMODelivery.IsRowVisible(grdvMODelivery.RowCount - 1) != RowVisibleState.Visible)
                {
                    tmrPage.Interval = 5000;
                    tmrPage.Enabled = true;
                }
                else
                {
                    timer.Enabled = true;
                }
            }
            else
            {
                timer.Interval = 10000;
                timer.Enabled = true;
            }
        }

        private void grdvMODelivery_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column != grdclmDLVProgress)
                return;

            int colIndex = 0;
            int.TryParse(e.Value.ToString(), out colIndex);

            switch (colIndex)
            {
                case -1:
                    e.DisplayText = "计划";
                    break;
                case 0:
                    e.DisplayText = "正常";
                    break;
                case 1:
                    e.DisplayText = "偏快";
                    break;
                case 2:
                    e.DisplayText = "过快";
                    break;
                case 3:
                    e.DisplayText = "偏长";
                    break;
                case 4:
                    e.DisplayText = "过长";
                    break;
            }
        }

        private void grdvMODelivery_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            string colHtml = datas[rowIndex].BackgroundColor;
            colHtml = colHtml.Contains("#") ? colHtml : "#" + colHtml;
            e.Appearance.BackColor = ColorTranslator.FromHtml(colHtml);

            if (e.Column != grdclmDLVProgress)
                return;

            int colIndex = 0;
            int.TryParse(e.CellValue.ToString(), out colIndex);
            string col = "";

            switch (colIndex)
            {
                case -1:
                    col = "#4567AA";
                    e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                    break;
                case 0:
                    col = "#00FF00";
                    e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                    e.Appearance.ForeColor = Color.Black;
                    break;
                case 1:
                    col = "#24F0E1";
                    e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                    break;
                case 2:
                    col = "#3867F3";
                    e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                    e.Appearance.ForeColor = Color.White;
                    break;
                case 3:
                    col = "#FBF179";
                    e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                    break;
                case 4:
                    col = "#FF0000";
                    e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                    e.Appearance.ForeColor = Color.Black;
                    break;
            }
        }

        private void frmWIPWaitingMonitor_Shown(object sender, EventArgs e)
        {
            if (this.lblFuncName.Text.Contains("-"))
            {
                string lblName = this.lblFuncName.Text;
                this.lblFuncName.Text = lblName.Split('-')[1].ToString();
            }
            pnlRemark.Left = (this.Width - pnlRemark.Width) / 2;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            if (autoSwtich)
            {
                JumpToNextFunction();
                tmrPage.Enabled = false;
                return;
            }
            else
            {
                GetDashboardWIPWaiting(t132ClickStream);
                timer.Enabled = true;
            }
        }

        private void tmrPage_Tick(object sender, EventArgs e)
        {
            if (datas != null)
            {
                if (datas.Count > 0)
                {
                    if (grdvMODelivery.RowCount - 1 > 0)
                    {
                        if (grdvMODelivery.IsRowVisible(grdvMODelivery.RowCount - 1) == RowVisibleState.Visible) //如果滚到了底端
                        {
                            timer.Enabled = true;
                            this.grdvMODelivery.MoveFirst();
                        }
                    }
                    this.grdvMODelivery.MoveNextPage();
                }
            }
        }
    }
}
