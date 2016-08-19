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

        public ucXBarRChart()
        {
            InitializeComponent();
        }


        public void DrawChart(
            StationLogin stationUser,
            WIPStationProductionStatus workUnit,
            string pwoNo,
            int t20LeafID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            #region 获取 XBar-R 图数据
            EntitySPCChart data = new EntitySPCChart();
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
                    ref data,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                    return;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            #endregion

            Font font = new Font("新宋体", 12f);

            #region 填写表头
            picLogo.Image = data.CompanyLogoImage;
            lblTitle.Text = data.ChartTitle;
            lblChartCode.Text = data.FormCode;
            edtT1002Name.Text = data.T1002Name;
            edtT1Name.Text = data.T1Name;
            edtT216Name.Text = data.T216Name;
            edtT133Code.Text = data.T133Code;
            edtOperator.Text =
                string.Format(
                    "{0}[{1}]",
                    data.OperatorCode,
                    data.OperatorName);
            edtT102Name.Text = data.T102Name;
            edtT102Code.Text = data.T102Code;
            edtT20Name.Text = data.T20Name;
            edtEngineeringSpec.Text = data.EngineeringSpec;
            edtSamplingInterval.Text = data.SamplingInterval;
            edtMeasuredDate.Text = data.MeasuredDate;
            #endregion

            #region 绘制 XBar-R 图
            chartXBar.Series.Clear();

            Series pointMeasureData = new Series("测量值", ViewType.Point)
            {
                ArgumentScaleType = ScaleType.Qualitative,
                LabelsVisibility = DefaultBoolean.True,
            };
            PointSeriesView view = new PointSeriesView();
            view.Color = Color.Blue;
            view.PointMarkerOptions.BorderColor = Color.Blue;
            pointMeasureData.View = view;

            PointSeriesLabel label = pointMeasureData.Label as PointSeriesLabel;
            label.Font = font;
            label.TextColor = Color.Black;

            List<RainbowChartMeasureData> datas = data.XMLToRainbowChartDataList();
            foreach (RainbowChartMeasureData pointData in datas)
            {
                SeriesPoint point =
                    new SeriesPoint(
                        pointData.MeasureTime,
                        pointData.Metric01.DoubleValue);

                pointMeasureData.Points.Add(point);
            }

            chartXBar.Series.Add(pointMeasureData);

            XYDiagram xyDiagram = chartXBar.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                double midValue =
                    (data.LCLData.DoubleValue +
                     data.UCLData.DoubleValue) / 2;

                xyDiagram.DefaultPane.BackColor = Color.Red;

                xyDiagram.AxisX.Label.Font = font;
                xyDiagram.AxisY.Label.Font = font;
                xyDiagram.AxisX.Title.Font = font;

                xyDiagram.AxisX.Title.Visibility = DefaultBoolean.True;
                xyDiagram.AxisX.Title.Text = "时间点";

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

            chartXBar.Legend.Font = font;
            #endregion

            #region 如果有需要报警的消息，则弹出报警对话框
            switch (data.AnomalyType)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    XtraMessageBox.Show(
                        data.AnomalyDesc,
                        "测量数据异常",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    break;
            }
            #endregion
        }
    }
}