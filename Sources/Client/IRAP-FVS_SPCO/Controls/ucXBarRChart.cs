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
using IRAP.Entity.MES;
using IRAP.Entity.MDM;
using IRAP.Entity.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_SPCO
{
    public partial class ucXBarRChart : DevExpress.XtraEditors.XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        /// <summary>
        /// XBar-R 图的类型：0-研究控制图；1-控制控制图
        /// </summary>
        private int chartType = 0; 

        public ucXBarRChart()
        {
            InitializeComponent();
        }


        public void DrawChart(
            StationLogin stationUser,
            WIPStationProductionStatus workUnit,
            string pwoNo,
            long lcl,
            long ucl,
            long rlcl,
            long rucl,
            int t20LeafID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            #region 确定当前的 XBar-R 图是研究用图还是控制用图
            if (lcl == 0 &&
                ucl == 0 &&
                rlcl == 0 &&
                rucl == 0)
                chartType = 0;
            else
                chartType = 1;

            lblChartType.Visible = chartType == 0;
            #endregion

            chartXBar.Series.Clear();
            chartR.Series.Clear();

            #region 获取 XBar-R 图数据
            EntitySPCChart chartData = new EntitySPCChart();
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPMESClient.Instance.ufn_GetInfo_SPCChart(
                    stationUser.CommunityID, //60010,
                    pwoNo, //"1C3PK1A7BA50422003",
                    workUnit.T47LeafID, // 373564,
                    workUnit.T216LeafID, // 2155621,
                    workUnit.T133LeafID, //2155684,
                    t20LeafID, //352942,
                    stationUser.SysLogID, //101,
                    ref chartData,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    IRAPMessageBox.Instance.Show(errText, "获取 XBar-R 图数据", MessageBoxIcon.Error, 10);
                    return;
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            #endregion

            Font font = new Font("新宋体", 12f);

            #region 填写表头
            picLogo.Image = chartData.CompanyLogoImage;
            lblTitle.Text = chartData.ChartTitle;
            lblChartCode.Text = chartData.FormCode;
            edtT1002Name.Text = chartData.T1002Name;
            edtT1Name.Text = chartData.T1Name;
            edtT216Name.Text = chartData.T216Name;
            edtT133Code.Text = chartData.T133Code;
            edtOperator.Text =
                string.Format(
                    "{0}[{1}]",
                    chartData.OperatorCode,
                    chartData.OperatorName);
            edtT102Name.Text = chartData.T102Name;
            edtT102Code.Text = chartData.T102Code;
            edtT20Name.Text = chartData.T20Name;
            edtEngineeringSpec.Text = chartData.EngineeringSpec;
            edtSamplingInterval.Text = chartData.SamplingInterval;
            edtMeasuredDate.Text = chartData.MeasuredDate;
            #endregion

            List<XbarChartMeasureData> srcDatas = chartData.XMLToXBarChartDataList();
            List<XBarR.XBarRData> datas = new List<XBarR.XBarRData>();

            int ordinal = 1;
            XBarR.XBarRData pointData = new XBarR.XBarRData(ordinal++);
            for (int i = 1; i <= srcDatas.Count; i++)
            {
                pointData.Add(srcDatas[i - 1]);

                if (i % XBarR.XBarRConstant.Instance.CntOfPerGroup == 0)
                {
                    datas.Add(pointData);
                    pointData = new XBarR.XBarRData(ordinal++);
                }
            }

            DrawXBar(chartData, datas, font);
            DrawR(chartData, datas, font);

            Quantity xbarLCL = new Quantity()
            {
                Scale = chartData.Scale,
                UnitOfMeasure = chartData.UnitOfMeasure,
            };
            Quantity xbarUCL = xbarLCL.Clone();
            Quantity rLCL = xbarLCL.Clone();
            Quantity rUCL = xbarLCL.Clone();

            switch (chartType)
            {
                case 0:
                    if (datas.Count == 25)
                    {
                        CalcLimitControlLine(datas, ref xbarLCL, ref xbarUCL);
                    }
                    break;
                case 1:
                    break;
            }

            #region 如果有需要报警的消息，则弹出报警对话框
            switch (chartData.AnomalyType)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    XtraMessageBox.Show(
                        chartData.AnomalyDesc,
                        "测量数据异常",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    break;
            }
            #endregion
        }

        private long Avg(List<long> datas)
        {
            long rlt = 0;
            for (int i = 0; i < datas.Count; i++)
                rlt += datas[i];
            return rlt / datas.Count;
        }

        /// <summary>
        /// 计算 XBar-R 上下限控制线
        /// </summary>
        /// <param name="xbarPoints"></param>
        private void CalcLimitControlLine(List<XBarR.XBarRData> xbarPoints, ref Quantity lcl, ref Quantity ucl)
        {
            lcl.IntValue = 0;
            ucl.IntValue = 0;

            if (xbarPoints.Count < 25)
                return;

            List<long> xbarDatas = new List<long>();
            List<long> rDatas = new List<long>();
            foreach (XBarR.XBarRData point in xbarPoints)
            {
                xbarDatas.Add(point.XBar.IntValue);
                rDatas.Add(point.R.IntValue);
            }

            #region 计算 XBarBar
            Quantity xbarbarLine = lcl.Clone();
            lcl.IntValue = 0;
            xbarbarLine.IntValue = Avg(xbarDatas);
            #endregion

            #region 计算 RBar
            Quantity rbarLine = lcl.Clone();
            rbarLine.IntValue = 0;
            rbarLine.IntValue = Avg(rDatas);
            #endregion

            #region 计算 XBar 图的 LCL 和 UCL
            lcl.DoubleValue = xbarbarLine.DoubleValue - XBarR.XBarRConstant.Instance.A2 * rbarLine.DoubleValue;
            ucl.DoubleValue = xbarbarLine.DoubleValue + XBarR.XBarRConstant.Instance.A2 * rbarLine.DoubleValue;
            #endregion

            #region 计算 R 图的 LCL 和 UCL
            Quantity rlcl = lcl.Clone();
            Quantity rucl = lcl.Clone();
            rlcl.DoubleValue = XBarR.XBarRConstant.Instance.D3 * rbarLine.DoubleValue;
            rucl.DoubleValue = XBarR.XBarRConstant.Instance.D4 * rbarLine.DoubleValue;
            #endregion

            #region 绘制 XBar 的中线
            DrawAxisYConstantLine(chartXBar, xbarbarLine.DoubleValue, Color.Black);
            #endregion

            #region 绘制 XBar 图的上下控制线
            SetDiagramWholeRanger(chartXBar, lcl.DoubleValue, ucl.DoubleValue);
            DrawAsisYStrip(chartXBar, lcl.DoubleValue, ucl.DoubleValue);
            DrawAxisYConstantLine(chartXBar, lcl.DoubleValue, Color.Black);
            DrawAxisYConstantLine(chartXBar, ucl.DoubleValue, Color.Black);
            #endregion

            #region 绘制 R 图的中线
            DrawAxisYConstantLine(chartR, rbarLine.DoubleValue, Color.Black);
            #endregion

            #region 绘制 R 图的上下控制线
            SetDiagramWholeRanger(chartR, rlcl.DoubleValue, rucl.DoubleValue);
            DrawAsisYStrip(chartR, rlcl.DoubleValue, rucl.DoubleValue);
            DrawAxisYConstantLine(chartR, rlcl.DoubleValue, Color.Black);
            DrawAxisYConstantLine(chartR, rucl.DoubleValue, Color.Black);
            #endregion
        }

        private void DrawAxisYConstantLine(
            ChartControl chart,
            double lineValue,
            Color lineColor)
        {
            XYDiagram xyDiagram = chart.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                ConstantLine constantLine = new ConstantLine();
                constantLine.ShowInLegend = false;
                constantLine.AxisValueSerializable = lineValue.ToString();
                constantLine.Color = lineColor;
                constantLine.LineStyle.Thickness = 2;
                constantLine.Title.Visible = false;
                xyDiagram.AxisY.ConstantLines.Add(constantLine);
            }
        }

        private void DrawAsisYStrip(
            ChartControl chart,
            double minValue,
            double maxValue)
        {
            XYDiagram xyDiagram = chart.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                double splitterWidth = (maxValue - minValue) / 6;

                Strip strip = new Strip();
                strip.Color = Color.Yellow;
                strip.MinLimit.AxisValue = minValue;
                strip.MaxLimit.AxisValue = maxValue;
                strip.ShowInLegend = false;
                xyDiagram.AxisY.Strips.Add(strip);

                strip = new Strip()
                {
                    Color = Color.LightGreen,
                    ShowInLegend = false,
                };
                strip.MinLimit.AxisValue = minValue + splitterWidth;
                strip.MaxLimit.AxisValue = maxValue - splitterWidth;
                xyDiagram.AxisY.Strips.Add(strip);

                strip = new Strip()
                {
                    Color = Color.FromArgb(0, 192, 0),
                    ShowInLegend = false,
                };
                strip.MinLimit.AxisValue = minValue + splitterWidth * 2;
                strip.MaxLimit.AxisValue = maxValue - splitterWidth * 2;
                xyDiagram.AxisY.Strips.Add(strip);
            }
        }

        private void SetDiagramWholeRanger(
            ChartControl chart,
            double minValue,
            double maxValue)
        {
            XYDiagram xyDiagram = chart.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                WholeRange wholeRange = xyDiagram.AxisY.WholeRange;
                wholeRange.AlwaysShowZeroLevel = false;
                wholeRange.Auto = false;
                wholeRange.MinValue = minValue;// - (maxValue - minValue) / 2;
                wholeRange.MaxValue = maxValue;// + (maxValue - minValue) / 2;
                wholeRange.SideMarginsValue = 1;
                wholeRange.AutoSideMargins = false;
            }
        }

        private void DrawXBar(
            EntitySPCChart data,
            List<XBarR.XBarRData> datas, 
            Font font)
        {
            #region 绘制 XBar 图
            Series pointMeasureData = new Series("XBar.", ViewType.Line)
            {
                ArgumentScaleType = ScaleType.Qualitative,
                LabelsVisibility = DefaultBoolean.True,
            };
            LineSeriesView view = new LineSeriesView();
            view.Color = Color.Blue;
            view.PointMarkerOptions.BorderColor = Color.Blue;
            view.MarkerVisibility = DefaultBoolean.True;
            pointMeasureData.View = view;

            PointSeriesLabel label = pointMeasureData.Label as PointSeriesLabel;
            label.Font = font;
            label.TextColor = Color.Black;

            double minValue = 0;
            double maxValue = 0;
            if (datas.Count > 0)
            {
                minValue = datas[0].XBar.DoubleValue;
                maxValue = datas[0].XBar.DoubleValue;
            }
            foreach (XBarR.XBarRData pointData in datas)
            {
                SeriesPoint point =
                    new SeriesPoint(
                        pointData.Ordinal,
                        pointData.XBar.DoubleValue);

                if (minValue > pointData.XBar.DoubleValue)
                    minValue = pointData.XBar.DoubleValue;
                if (maxValue < pointData.XBar.DoubleValue)
                    maxValue = pointData.XBar.DoubleValue;

                pointMeasureData.Points.Add(point);
            }

            chartXBar.Series.Add(pointMeasureData);

            XYDiagram xyDiagram = chartXBar.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                double midValue =
                    (data.LCLData.DoubleValue +
                     data.UCLData.DoubleValue) / 2;

                xyDiagram.AxisX.Label.Font = font;
                xyDiagram.AxisY.Label.Font = font;
                xyDiagram.AxisX.Title.Font = font;

                xyDiagram.AxisX.Title.Visibility = DefaultBoolean.True;
                xyDiagram.AxisX.Title.Text = "测量组";

                if (chartType == 1)
                {
                    xyDiagram.DefaultPane.BackColor = Color.Red;

                    xyDiagram.AxisY.Strips.Clear();
                    xyDiagram.AxisY.ConstantLines.Clear();

                    ConstantLine constantLine = new ConstantLine();
                    constantLine.ShowInLegend = false;
                    constantLine.AxisValueSerializable = midValue.ToString();
                    constantLine.Title.Visible = false;
                    xyDiagram.AxisY.ConstantLines.Add(constantLine);

                    WholeRange wholeRange = xyDiagram.AxisY.WholeRange;
                    wholeRange.AlwaysShowZeroLevel = false;
                    wholeRange.Auto = false;
                    wholeRange.MinValue = data.LSLData.DoubleValue;
                    wholeRange.MaxValue = data.USLData.DoubleValue;
                    wholeRange.SideMarginsValue = 1;
                    wholeRange.AutoSideMargins = false;

                    VisualRange visualRange = xyDiagram.AxisY.VisualRange;
                    visualRange.Auto = false;
                    visualRange.MinValue = data.LSLData.DoubleValue;
                    visualRange.MaxValue = data.USLData.DoubleValue;
                    visualRange.SideMarginsValue = 1;
                    visualRange.AutoSideMargins = true;

                    Strip strip = new Strip();
                    strip.Color = Color.Yellow;
                    strip.MinLimit.AxisValue = data.LSLData.DoubleValue;
                    strip.MaxLimit.AxisValue = data.LCLData.DoubleValue;
                    strip.ShowInLegend = false;
                    xyDiagram.AxisY.Strips.Add(strip);

                    strip = new Strip();
                    strip.Color = Color.Lime;
                    strip.MinLimit.AxisValue = data.LCLData.DoubleValue;
                    strip.MaxLimit.AxisValue = data.UCLData.DoubleValue;
                    strip.ShowInLegend = false;
                    xyDiagram.AxisY.Strips.Add(strip);

                    strip = new Strip();
                    strip.Color = Color.Yellow;
                    strip.MinLimit.AxisValue = data.UCLData.DoubleValue;
                    strip.MaxLimit.AxisValue = data.USLData.DoubleValue;
                    strip.ShowInLegend = false;
                    xyDiagram.AxisY.Strips.Add(strip);
                }
                else
                {
                    WholeRange wholeRange = xyDiagram.AxisY.WholeRange;
                    wholeRange.AlwaysShowZeroLevel = false;
                    wholeRange.Auto = false;
                    wholeRange.MinValue = minValue - (maxValue - minValue) / 2;
                    wholeRange.MaxValue = maxValue + (maxValue - minValue) / 2;
                    wholeRange.SideMarginsValue = 1;
                    wholeRange.AutoSideMargins = false;
                }
            }

            chartXBar.Legend.Font = font;
            #endregion
        }

        private void DrawR(
            EntitySPCChart data,
            List<XBarR.XBarRData> datas,
            Font font)
        {
            #region 绘制 R 图
            Series pointMeasureData = new Series("R   .", ViewType.Line)
            {
                ArgumentScaleType = ScaleType.Qualitative,
                LabelsVisibility = DefaultBoolean.True,
            };
            LineSeriesView view = new LineSeriesView();
            view.Color = Color.Red;
            view.PointMarkerOptions.BorderColor = Color.Blue;
            view.MarkerVisibility = DefaultBoolean.True;
            pointMeasureData.View = view;

            PointSeriesLabel label = pointMeasureData.Label as PointSeriesLabel;
            label.Font = font;
            label.TextColor = Color.Black;

            foreach (XBarR.XBarRData pointData in datas)
            {
                SeriesPoint point =
                    new SeriesPoint(
                        pointData.Ordinal,
                        pointData.R.DoubleValue);

                pointMeasureData.Points.Add(point);
            }

            chartR.Series.Add(pointMeasureData);

            XYDiagram xyDiagram = chartR.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                double midValue =
                    (data.LCLData.DoubleValue +
                     data.UCLData.DoubleValue) / 2;

                xyDiagram.AxisX.Label.Font = font;
                xyDiagram.AxisY.Label.Font = font;
                xyDiagram.AxisX.Title.Font = font;

                xyDiagram.AxisX.Title.Visibility = DefaultBoolean.True;
                xyDiagram.AxisX.Title.Text = "测量组";

                if (chartType == 1)
                {
                    xyDiagram.DefaultPane.BackColor = Color.Red;

                    xyDiagram.AxisY.Strips.Clear();
                    xyDiagram.AxisY.ConstantLines.Clear();

                    ConstantLine constantLine = new ConstantLine();
                    constantLine.ShowInLegend = false;
                    constantLine.AxisValueSerializable = midValue.ToString();
                    constantLine.Title.Visible = false;
                    xyDiagram.AxisY.ConstantLines.Add(constantLine);

                    WholeRange wholeRange = xyDiagram.AxisY.WholeRange;
                    wholeRange.AlwaysShowZeroLevel = false;
                    wholeRange.Auto = false;
                    wholeRange.MinValue = data.LSLData.DoubleValue;
                    wholeRange.MaxValue = data.USLData.DoubleValue;
                    wholeRange.SideMarginsValue = 1;
                    wholeRange.AutoSideMargins = false;

                    VisualRange visualRange = xyDiagram.AxisY.VisualRange;
                    visualRange.Auto = false;
                    visualRange.MinValue = data.LSLData.DoubleValue;
                    visualRange.MaxValue = data.USLData.DoubleValue;
                    visualRange.SideMarginsValue = 1;
                    visualRange.AutoSideMargins = true;

                    Strip strip = new Strip();
                    strip.Color = Color.Yellow;
                    strip.MinLimit.AxisValue = data.LSLData.DoubleValue;
                    strip.MaxLimit.AxisValue = data.LCLData.DoubleValue;
                    strip.ShowInLegend = false;
                    xyDiagram.AxisY.Strips.Add(strip);

                    strip = new Strip();
                    strip.Color = Color.Lime;
                    strip.MinLimit.AxisValue = data.LCLData.DoubleValue;
                    strip.MaxLimit.AxisValue = data.UCLData.DoubleValue;
                    strip.ShowInLegend = false;
                    xyDiagram.AxisY.Strips.Add(strip);

                    strip = new Strip();
                    strip.Color = Color.Yellow;
                    strip.MinLimit.AxisValue = data.UCLData.DoubleValue;
                    strip.MaxLimit.AxisValue = data.USLData.DoubleValue;
                    strip.ShowInLegend = false;
                    xyDiagram.AxisY.Strips.Add(strip);
                }
            }

            chartR.Legend.Font = font;
            #endregion
        }
    }
}