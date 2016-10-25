using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.Utils;

using IRAP.Global;
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucFTT : ucCustomFVSKanban
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<TrendFTTofAPWO> trendDatas = new List<TrendFTTofAPWO>();
        private int communityID = 0;
        private string pwoNo = "";
        private long sysLogID = 0;

        public ucFTT()
        {
            InitializeComponent();
        }

        private void DrawFTTChart(
            int communityID, 
            string pwoNo,
            long sysLogID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int errCode = 0;
            string errText = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPFVSClient.Instance.ufn_GetTrend_FTTofAPWO(
                    communityID,
                    pwoNo,
                    sysLogID,
                    ref trendDatas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    return;
                }

                #region 绘制 FTT 趋势图
                chartFTT.Series.Clear();

                Series pointMeasureData = new Series("", ViewType.Line)
                {
                    ArgumentScaleType = ScaleType.Qualitative,
                    LabelsVisibility = DefaultBoolean.False,
                };
                LineSeriesView view = new LineSeriesView();
                view.Color = Color.Blue;
                view.PointMarkerOptions.BorderColor = Color.Blue;
                pointMeasureData.View = view;

                PointSeriesLabel label = pointMeasureData.Label as PointSeriesLabel;
                label.TextColor = Color.Black;

                foreach (TrendFTTofAPWO pointData in trendDatas)
                {
                    SeriesPoint point =
                            new SeriesPoint(
                                pointData.WorkingHourMiddleTime,
                                pointData.FTTRate);

                    pointMeasureData.Points.Add(point);
                }

                chartFTT.Series.Add(pointMeasureData);

                XYDiagram xyDiagram = chartFTT.Diagram as XYDiagram;
                if (xyDiagram != null)
                {
                    xyDiagram.AxisX.Title.Visibility = DefaultBoolean.False;
                    //xyDiagram.AxisX.Title.Text = "时间点";

                    WholeRange wholeRange = xyDiagram.AxisY.WholeRange;
                    wholeRange.AlwaysShowZeroLevel = false;
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetStructure_FTTofAPWO(
            int communityID,
            string pwoNo,
            long sysLogID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int errCode = 0;
            string errText = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<Structure_FFTofAPWO> datas = new List<Structure_FFTofAPWO>();
                lblStructFTTofAPWO.Text = "";

                IRAPFVSClient.Instance.ufn_GetStructure_FFTofAPWO(
                    communityID,
                    pwoNo,
                    sysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode == 0)
                {
                    foreach (Structure_FFTofAPWO data in datas)
                    {
                        lblStructFTTofAPWO.Text +=
                            string.Format(
                                "{0}  {1}% | ",
                                data.T216Name,
                                data.FTT.ToString("0.00"));
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void SetSearchCondition(
            int communityID,
            string pwoNo,
            long sysLogID)
        {
            this.communityID = communityID;
            this.pwoNo = pwoNo;
            this.sysLogID = sysLogID;

            DrawFTTChart(communityID, pwoNo, sysLogID);
            GetStructure_FTTofAPWO(communityID, pwoNo, sysLogID);
        }
    }
}
