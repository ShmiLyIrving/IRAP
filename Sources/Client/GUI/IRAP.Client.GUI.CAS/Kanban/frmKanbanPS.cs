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
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.Client.GUI.CAS.Entities;
using IRAP.Client.SubSystem;
using IRAP.Entities.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.CAS
{
    public partial class frmKanbanPS : IRAP.Client.Global.GUI.frmCustomKanbanBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<AndonProductionLineStatus> pdtLines = new List<AndonProductionLineStatus>();
        /// <summary>
        /// 每页显示的记录数
        /// </summary>
        private int recordCountforPerPage = 0;
        /// <summary>
        /// 当前页显示的第一条记录位置
        /// </summary>
        private int currentRecordNo = 0;
        /// <summary>
        /// 在表格中显示的内容集
        /// </summary>
        private List<AndonProductionLineStatus> pdtLinesToShow = new List<AndonProductionLineStatus>();

        public frmKanbanPS()
        {
            InitializeComponent();

            switch (IRAPUser.Instance.CommunityID)
            {
                case 60006:
                    bandedGridColumnArea.Caption = "区域";
                    bandedGridColumnProductionLine.Caption = "生产线";
                    bandedGridColumnMaterial.Caption = "物料";
                    bandedGridColumnEquipment.Caption = "维修";
                    bandedGridColumnQualify.Caption = "质量";
                    bandedGridColumnTooling.Caption = "工装";
                    bandedGridColumnSecurity.Caption = "安全";
                    bandedGridColumnTechnology.Caption = "技术";
                    bandedGridColumnDesign.Caption = "设计";
                    bandedGridColumnOther.Caption = "其他";

                    grdbndTooling.Visible = false;
                    grdbndSafety.Visible = false;
                    grdbndTechnology.Visible = false;
                    grdbndDesign.Visible = false;

                    lblNone.Visible = false;
                    lblMicroAbnormal.Visible = false;

                    lblGreatAbnormal.Text = "有异常";
                    break;
                default:
                    bandedGridColumnArea.Caption = "车间\nWorkshop";
                    bandedGridColumnProductionLine.Caption = "生产线/工作中心\nLine/Work Center";
                    bandedGridColumnMaterial.Caption = "物料\nMaterial";
                    bandedGridColumnEquipment.Caption = "维修\nMaintenance";
                    bandedGridColumnQualify.Caption = "质量\nQuality";
                    bandedGridColumnTooling.Caption = "工装\nTooling";
                    bandedGridColumnSecurity.Caption = "安全\nSafety";
                    bandedGridColumnTechnology.Caption = "技术\nTechnology";
                    bandedGridColumnDesign.Caption = "设计\nDesign";
                    bandedGridColumnOther.Caption = "其他\nOthers";
                    break;
            }
        }

        private void ShowAndonStatusWithProductionLine()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<ProductionSurveillance> lines = null;

                try
                {
                    lines = GetAllPrdtLinesAndonStatus();

                    pdtLines.Clear();
                    AndonProductionLineStatus pdtLine = null;
                    foreach (ProductionSurveillance lineEventStatus in lines)
                    {
                        if (pdtLine == null || pdtLine.T134LeafID != lineEventStatus.LeafID)
                        {
                            pdtLine = new AndonProductionLineStatus()
                            {
                                NodeID = lineEventStatus.T134NodeID,
                                NodeName = lineEventStatus.T134NodeName,
                                T134LeafID = lineEventStatus.LeafID,
                                T134NodeName = lineEventStatus.NodeName,
                            };
                            pdtLines.Add(pdtLine);
                        }

                        switch (lineEventStatus.T179Code)
                        {
                            case "M":
                                pdtLine.MaterialStatus = lineEventStatus.ResourceStatus;
                                pdtLine.MaterialTimeElapsed = lineEventStatus.ElapsedSeconds;
                                pdtLine.MaterialResponded = lineEventStatus.OnSiteResponded;
                                break;
                            case "R":
                                pdtLine.EquipmentStatus = lineEventStatus.ResourceStatus;
                                pdtLine.EquipmentTimeElapsed = lineEventStatus.ElapsedSeconds;
                                pdtLine.EquipmentResponded = lineEventStatus.OnSiteResponded;
                                break;
                            case "Q":
                                pdtLine.QualifyStatus = lineEventStatus.ResourceStatus;
                                pdtLine.QualifyTimeElapsed = lineEventStatus.ElapsedSeconds;
                                pdtLine.QualifyResponded = lineEventStatus.OnSiteResponded;
                                break;
                            case "O":
                                pdtLine.OtherStatus = lineEventStatus.ResourceStatus;
                                pdtLine.OtherTimeElapsed = lineEventStatus.ElapsedSeconds;
                                pdtLine.OtherResponded = lineEventStatus.OnSiteResponded;
                                break;
                            case "S":
                                pdtLine.SecurityStatus = lineEventStatus.ResourceStatus;
                                pdtLine.SecurityTimeElapsed = lineEventStatus.ElapsedSeconds;
                                pdtLine.SecurityResponded = lineEventStatus.OnSiteResponded;
                                break;
                            case "T":
                                pdtLine.ToolingStatus = lineEventStatus.ResourceStatus;
                                pdtLine.ToolingTimeElapsed = lineEventStatus.ElapsedSeconds;
                                pdtLine.ToolingResponded = lineEventStatus.OnSiteResponded;
                                break;
                            case "D":
                                pdtLine.DesignStatus = lineEventStatus.ResourceStatus;
                                pdtLine.DesignTimeElapsed = lineEventStatus.ElapsedSeconds;
                                pdtLine.DesignResponded = lineEventStatus.OnSiteResponded;
                                break;
                            case "X":
                                pdtLine.TechnologyStatus = lineEventStatus.ResourceStatus;
                                pdtLine.TechnologyTimeElapsed = lineEventStatus.ElapsedSeconds;
                                pdtLine.TechnologyResponded = lineEventStatus.OnSiteResponded;
                                break;
                        }
                    }

                    ShowProductionLineStatus();
                    SetConnectionStatus(true);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    SetConnectionStatus(false);

                    AppOperationLog log = new AppOperationLog()
                    {
                        Time = DateTime.Now,
                        ErrCode = -1,
                        ErrText = error.Message,
                    };
                    AddLog(log);
                }

                frmKanbanPS_Resize(this, null);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private List<ProductionSurveillance> GetAllPrdtLinesAndonStatus()
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<ProductionSurveillance> prdtLines = new List<ProductionSurveillance>();
                int opNode = Tools.ConvertToInt32(menuInfo.OpNode);

                int errCode = 0;
                string errText = "";

                WriteLog.Instance.Write(
                    "调用 ufn_GetKanban_ProductionSurveillance 函数，获取产线 Andon 状态信息", 
                    strProcedureName);
                IRAPFVSClient.Instance.ufn_GetKanban_ProductionSurveillance(
                    IRAPUser.Instance.CommunityID,
                    t134ClickStream,
                    opNode,
                    SysLogID,
                    ref prdtLines,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format(
                        "({0}){1}", errCode, errText), 
                    strProcedureName);

                if (errCode != 0)
                    throw new Exception(errText);

                return prdtLines;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ShowProductionLineStatus()
        {
            pdtLinesToShow.Clear();

            // 根据站点，分屏显示或者显示全部产线安灯事件状态
            switch (CurrentStationInfo.Instance.Station.HostParameter)
            {
                case 1:         // 表示当前站点为监控站点，需要自动刷屏
                    for (int i = currentRecordNo; i < currentRecordNo + recordCountforPerPage; i++)
                    {
                        if (i >= pdtLines.Count)
                            break;
                        AndonProductionLineStatus line = pdtLines[i].Clone();
                        pdtLinesToShow.Add(line);
                    }
                    break;
                default:
                    foreach (AndonProductionLineStatus line in pdtLines)
                    {
                        pdtLinesToShow.Add(line.Clone());
                    }
                    break;
            }

            grdPrdtLines.DataSource = pdtLinesToShow;
        }

        private void frmKanbanPS_Activated(object sender, EventArgs e)
        {
            grdPrdtLines.MainView = advBandedGridView;

            ShowAndonStatusWithProductionLine();
            advBandedGridView.MoveFirst();

            if (autoSwtich)
            {
                if (this.pdtLines.Count > 0)
                {
                    timer.Interval = this.nextFunction.WaitForSeconds * 1000;
                }
                else
                {
                    timer.Interval = 1000;
                }
            }
            else
            {
                timer.Interval = 60000;
            }
            timer.Enabled = false;
            if (advBandedGridView.RowCount - 1 > 0 &&
                advBandedGridView.IsRowVisible(advBandedGridView.RowCount - 1) != RowVisibleState.Visible) //如果滚到了底端
            {
                tmrPage.Enabled = true;
                tmrPage.Interval = 5000;
            }
            else
            {
                timer.Enabled = true;
            }
        }

        private void frmKanbanPS_Resize(object sender, EventArgs e)
        {
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
                ShowAndonStatusWithProductionLine();
                timer.Enabled = true;
            }
        }

        private void tmrPage_Tick(object sender, EventArgs e)
        {
            if (pdtLinesToShow.Count > 0)
            {
                if (advBandedGridView.RowCount - 1 > 0 &&
                    advBandedGridView.IsRowVisible(advBandedGridView.RowCount - 1) == RowVisibleState.Visible) //如果滚到了底端
                {
                    timer.Enabled = true;
                    this.advBandedGridView.MoveFirst();
                }
                this.advBandedGridView.MoveNextPage();
            }
        }
    }
}
