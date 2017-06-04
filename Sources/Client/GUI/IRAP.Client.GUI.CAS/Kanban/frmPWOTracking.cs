using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;

using DevExpress.XtraGrid.Views.Grid;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entity.SSO;
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmPWOTracking : IRAP.Client.Global.GUI.frmCustomKanbanBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<Dashboard_MOTrack> moTracks = new List<Dashboard_MOTrack>();

        public frmPWOTracking()
        {
            InitializeComponent();
        }

        private void SetWOStatusPanelColor()
        {
            lblStatus1.BackColor = ColorTranslator.FromHtml("#4567AA");
            lblStatus2.BackColor = ColorTranslator.FromHtml("#00FF00");
            lblStatus3.BackColor = ColorTranslator.FromHtml("#24F0E1");
            lblStatus4.BackColor = ColorTranslator.FromHtml("#3867F3");
            lblStatus5.BackColor = ColorTranslator.FromHtml("#FBF179");
            lblStatus6.BackColor = ColorTranslator.FromHtml("#FF0000");

            lblStatus2.ForeColor = Color.Black;
            lblStatus3.ForeColor = Color.Black;
            lblStatus5.ForeColor = Color.Black;

            //grdclmnOrdinal.Caption = "项目\nItem";
            //grdclmnMONumber.Caption = "订单号\nMO No.";
            //grdclmnMOLineNo.Caption = "行号\nLine No.";
            //grdclmMaterialCode.Caption = "物料号\nPart number";
            //grdclmMaterialName.Caption = "产品名称\nProduct name";
            //grdclmPlannedStartDate.Caption = "计划开工日期\nPlanned start date";
        }

        private void GetDashboardMOTracks()
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
                    IRAPFVSClient.Instance.ufn_Dashboard_MOTrack(
                        IRAPUser.Instance.CommunityID,
                        t132ClickStream,
                        SysLogID,
                        ref moTracks,
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

                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    moTracks = (from row in moTracks
                                where row.PWOProgress > 0
                                select row).ToList();
                    grdMOTracks.DataSource = moTracks;
                    grdvMOTracks.BestFitColumns();
                    grdvMOTracks.OptionsView.RowAutoHeight = true;

                    SetConnectionStatus(true);
                }
                else
                {
                    AddLog(new AppOperationLog(DateTime.Now, -1, errText));
                    SetConnectionStatus(false);
                    grdMOTracks.DataSource = null;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmPWOTracking_Load(object sender, EventArgs e)
        {
            SetWOStatusPanelColor();
        }

        private void frmPWOTracking_Resize(object sender, EventArgs e)
        {
            pnlRemark.Left = (this.Width - pnlRemark.Width) / 2;
        }

        private void frmPWOTracking_Shown(object sender, EventArgs e)
        {
            try
            {
                if (lblFuncName.Text.Contains("-"))
                {
                    string lblName = lblFuncName.Text;
                    lblFuncName.Text = lblName.Split('-')[1].ToString();
                }
                pnlRemark.Left = (Width - pnlRemark.Width) / 2;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(
                    error.Message,
                    string.Format(
                        "{0}.{1}", 
                        className, 
                        MethodBase.GetCurrentMethod().Name));
            }
        }

        private void frmPWOTracking_Activated(object sender, EventArgs e)
        {
            try
            {
                if (Tag is MenuInfo)
                {
                    GetDashboardMOTracks();
                    grdvMOTracks.MoveFirst();

                    if (autoSwtich)
                    {
                        if (this.moTracks.Count > 0)
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
                    if (grdvMOTracks.RowCount - 1 > 0 &&
                        grdvMOTracks.IsRowVisible(grdvMOTracks.RowCount - 1) != RowVisibleState.Visible)
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
                    AddLog(new AppOperationLog(
                        DateTime.Now,
                        -1,
                        "没有正确的传入菜单参数！"));
                    timer.Enabled = false;
                    return;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message,
                    string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name));
            }
        }

        private void grdvMOTracks_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                int rowIndex = e.RowHandle;
                string colHtml = moTracks[rowIndex].BackgroundColor;
                colHtml = colHtml.Contains("#") ? colHtml : "#" + colHtml;
                e.Appearance.BackColor = ColorTranslator.FromHtml(colHtml);

                if (e.Column != grdclmPWOProgress) return;
                int colIndex = 0;
                int.TryParse(e.CellValue.ToString(), out colIndex);
                switch (colIndex)
                {
                    case -1:
                        {
                            string col = "#4567AA";
                            e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                        }
                        break;
                    case 0:
                        {
                            string col = "#00FF00";
                            e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                            e.Appearance.ForeColor = Color.Black;
                        }
                        break;
                    case 1:
                        {
                            string col = "#24F0E1";
                            e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                        }
                        break;
                    case 2:
                        {
                            string col = "#3867F3";
                            e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                            e.Appearance.ForeColor = Color.White;
                        }
                        break;
                    case 3:
                        {
                            string col = "#FBF179";
                            e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                        }
                        break;
                    case 4:
                        {
                            string col = "#FF0000";
                            e.Appearance.BackColor = ColorTranslator.FromHtml(col);
                            e.Appearance.ForeColor = Color.White;
                        }
                        break;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message,
                    string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name));
            }
        }

        private void grdvMOTracks_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column != grdclmPWOProgress) return;
            int colIndex = 0;
            int.TryParse(e.Value.ToString(), out colIndex);
            switch (colIndex)
            {
                case -1:
                    {
                        e.DisplayText = "计划";
                    }
                    break;
                case 0:
                    {
                        e.DisplayText = "正常";
                    }
                    break;
                case 1:
                    {
                        e.DisplayText = "偏快";
                    }
                    break;
                case 2:
                    {
                        e.DisplayText = "过快";
                    }
                    break;
                case 3:
                    {
                        e.DisplayText = "偏慢";
                    }
                    break;
                case 4:
                    {
                        e.DisplayText = "过慢";
                    }
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
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
                    GetDashboardMOTracks();
                    timer.Enabled = true;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message,
                    string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name));
            }
        }

        private void tmrPage_Tick(object sender, EventArgs e)
        {
            try
            {
                if (moTracks.Count > 0)
                {
                    if (grdvMOTracks.RowCount - 1 > 0)
                    {
                        if (grdvMOTracks.IsRowVisible(grdvMOTracks.RowCount - 1) == RowVisibleState.Visible) //如果滚到了底端
                        {
                            timer.Enabled = true;
                            grdvMOTracks.MoveFirst();
                        }
                    }
                    grdvMOTracks.MoveNextPage();
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message,
                    string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name));
            }
        }
    }
}
