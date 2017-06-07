using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraGrid.Views.Grid;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.FVS
{
    public partial class frmMFGProgressMonitor : IRAP.Client.Global.GUI.frmCustomKanbanBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<Dashboard_WorkUnitProductionProgress> datas =
            new List<Dashboard_WorkUnitProductionProgress>();

        public frmMFGProgressMonitor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取制造订单跟踪看板数据
        /// </summary>
        /// <param name="t134ClickStream"></param>
        private void GetDashboardsWorkUnitProductionProgresses(string t134ClickStream)
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
                    IRAPFVSClient.Instance.ufn_Dashboard_WorkUnitProductionProgress(
                        IRAPUser.Instance.CommunityID,
                        t134ClickStream,
                        IRAPUser.Instance.SysLogID,
                        ref datas,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    AddLog(new AppOperationLog(DateTime.Now, -1, error.Message));
                    SetConnectionStatus(false);
                    return;
                }

                try
                {
                    if (errCode == 0)
                    {
                        grdWorkUnitProductionProgress.DataSource = datas;
                        grdvWorkUnitProductionProgress.BestFitColumns();
                        grdvWorkUnitProductionProgress.OptionsView.RowAutoHeight = true;

                        SetConnectionStatus(true);
                    }
                    else
                    {
                        AddLog(new AppOperationLog(DateTime.Now, errCode, errText));
                        SetConnectionStatus(false);
                        grdWorkUnitProductionProgress.DataSource = null;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    AddLog(new AppOperationLog(DateTime.Now, -1, error.Message));
                    SetConnectionStatus(false);
                    return;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void SetWOStatusPanelColor()
        {
            grdclmnOrdinal.Caption = "序号\nItem";
            grdclmnT107Name.Caption = "工位\nWork unit";
            grdclmnMONumber.Caption = "订单号\nMO No.";
            grdclmnMOLineNo.Caption = "行号\nLine No.";
            grdclmnProductNo.Caption = "产品编号\nProduct No.";
            grdclmnQtyToMFG.Caption = "待加工数量\nWIP quantity to be processed";
            grdclmnQtyCompleted.Caption = "已报工数量\nWIP quantity processed";
            grdclmnStdCycleSeconds.Caption = "标准周期时间\nStandard Cycle Time";
            grdclmnStartTime.Caption = "开始生产时间\nStart Time";
            grdclmnEndTime.Caption = "应该结束时间\nEstimated completion time";
            grdclmnProductionProgress.Caption = "生产进度状态\nProduction Progress Status";
        }

        private void frmMFGProgressMonitor_Load(object sender, EventArgs e)
        {
            SetWOStatusPanelColor();
        }

        private void frmMFGProgressMonitor_Shown(object sender, EventArgs e)
        {
            if (this.lblFuncName.Text.Contains("-"))
            {
                string lblName = this.lblFuncName.Text;
                this.lblFuncName.Text = lblName.Split('-')[1].ToString();
            }
        }

        private void frmMFGProgressMonitor_Activated(object sender, EventArgs e)
        {
            GetDashboardsWorkUnitProductionProgresses(t134ClickStream);

            if (grdWorkUnitProductionProgress.DataSource != null)
            {
                grdvWorkUnitProductionProgress.MoveFirst();

                if (autoSwtich)
                {
                    if (datas.Count > 0)
                    {
                        timer.Interval = nextFunction.WaitForSeconds * 1000;
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
                if (grdvWorkUnitProductionProgress.RowCount - 1 > 0 &&
                    grdvWorkUnitProductionProgress.IsRowVisible(
                        grdvWorkUnitProductionProgress.RowCount - 1) != RowVisibleState.Visible)
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

        private void grdvWorkUnitProductionProgress_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == grdclmnProductionProgress)
            {
                int colIndex = 0;
                int.TryParse(e.Value.ToString(), out colIndex);

                switch (colIndex)
                {
                    case -1:
                        e.DisplayText = "空闲";
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
            else if (e.Column == grdclmnMOLineNo)
            {
                if (Tools.ConvertToInt32(e.Value.ToString(), 0) == 0)
                {
                    e.DisplayText = "";
                }
                else
                {
                    e.DisplayText = e.Value.ToString();
                }
            }
            else if (e.Column == grdclmnQtyToMFG)
            {
                if (Tools.ConvertToInt32(e.Value.ToString(), 0) == 0)
                {
                    e.DisplayText = "";
                }
                else
                {
                    e.DisplayText = e.Value.ToString();
                }
            }
            else if (e.Column == grdclmnQtyCompleted)
            {
                if (Tools.ConvertToInt32(e.Value.ToString(), 0) == 0)
                {
                    e.DisplayText = "";
                }
                else
                {
                    e.DisplayText = e.Value.ToString();
                }
            }
            else if (e.Column == grdclmnStdCycleSeconds)
            {
                if ((double)e.Value == 0)
                {
                    e.DisplayText = "";
                }
                else
                {
                    e.DisplayText = ((double)e.Value).ToString("0.000 秒");
                }
            }
        }

        private void grdvWorkUnitProductionProgress_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            string colHtml = datas[rowIndex].BackgroundColor;
            colHtml = colHtml.Contains("#") ? colHtml : "#" + colHtml;
            e.Appearance.BackColor = ColorTranslator.FromHtml(colHtml);

            if (e.Column == grdclmnProductionProgress)
            {
                int colIndex = 0;
                int.TryParse(e.CellValue.ToString(), out colIndex);
                string col = "";

                switch (colIndex)
                {
                    case -1:
                        col = "#4567AA";
                        e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(col);
                        e.Appearance.ForeColor = Color.White;
                        break;
                    case 0:
                        col = "#00FF00";
                        e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(col);
                        e.Appearance.ForeColor = Color.Black;
                        break;
                    case 1:
                        col = "#24F0E1";
                        e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(col);
                        break;
                    case 2:
                        col = "#3867F3";
                        e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(col);
                        e.Appearance.ForeColor = Color.White;
                        break;
                    case 3:
                        col = "#FBF179";
                        e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(col);
                        break;
                    case 4:
                        col = "#FF0000";
                        e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(col);
                        e.Appearance.ForeColor = Color.White;
                        break;
                }
            }
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
                GetDashboardsWorkUnitProductionProgresses(t134ClickStream);
                timer.Enabled = true;
            }
        }

        private void tmrPage_Tick(object sender, EventArgs e)
        {
            if (datas != null)
            {
                if (datas.Count > 0)
                {
                    if (grdvWorkUnitProductionProgress.RowCount - 1 > 0)
                    {
                        if (grdvWorkUnitProductionProgress.IsRowVisible(grdvWorkUnitProductionProgress.RowCount - 1) == RowVisibleState.Visible) //如果滚到了底端
                        {
                            timer.Enabled = true;
                            this.grdvWorkUnitProductionProgress.MoveFirst();
                        }
                    }
                    this.grdvWorkUnitProductionProgress.MoveNextPage();
                }
            }
        }
    }
}
