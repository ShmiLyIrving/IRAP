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
using DevExpress.XtraCharts;
using DevExpress.Utils;

using IRAP.Global;
using IRAP.Entity.MES;
using IRAP.Entity.MDM;
using IRAP.Entity.SSO;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_SPCO
{
    public partial class ucRainBowChart : DevExpress.XtraEditors.XtraUserControl
    {
        public enum XbarRChartType
        {
            Study = 0,
            Control,
        };

        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private XbarRChartType chartType = XbarRChartType.Study;

        public ucRainBowChart()
        {
            InitializeComponent();
        }

        public int TimeOutThreshold
        {
            get { return timerWarning.Interval; }
            set
            {
//#if DEBUG
                //timerWarning.Interval = 3000;
//#else
                timerWarning.Interval = value; 
//#endif
            }
        }

        public void DrawChart(
            StationLogin stationUser,
            WIPStationProductionStatus workUnit,
            string pwoNo,
            int t47LeafID,
            int t216LeafID,
            int t133LeafID,
            int t20LeafID)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            int errCode = 0;
            string errText = "";


#region 获取Xbar-R图数据
            EntitySPCChart data = new EntitySPCChart();
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPMESClient.Instance.ufn_GetInfo_SPCChart(
                    stationUser.CommunityID, // 60010,
                    pwoNo, // "1C3PK1A7BA50422003",
                    t47LeafID, // 373564,
                    t216LeafID, // 2155621,
                    t133LeafID, //2155684,
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

            if (data.UCL != 0 || data.LCL != 0)
                chartType = XbarRChartType.Control;

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

#region 绘制彩虹图
            chartRainBow.Series.Clear();

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

            double maxValue = 0;
            double minValue = 0;

            List<RainbowChartMeasureData> datas = data.XMLToRainbowChartDataList();
            List<ConstantLine> clineAxisXs = new List<ConstantLine>();
            int opType = -1;
            int ocCount = 0;

            foreach (RainbowChartMeasureData pointData in datas)
            {
                if (maxValue == 0 || maxValue < pointData.Metric01.DoubleValue)
                    maxValue = pointData.Metric01.DoubleValue;
                if (minValue == 0 || minValue > pointData.Metric01.DoubleValue)
                    minValue = pointData.Metric01.DoubleValue;

                SeriesPoint point =
                        new SeriesPoint(
                            string.Format(
                                "{0}\n{1}",
                                pointData.Ordinal,
                                pointData.MeasureTime),
                            pointData.Metric01.DoubleValue);

                pointMeasureData.Points.Add(point);

                if (opType != pointData.OpType)
                {
                    ocCount = 0;
                    opType = pointData.OpType;

                    if (opType == 4 || opType == 5 || opType == 6)
                    {
                        ConstantLine clineX = new ConstantLine();
                        clineX.ShowInLegend = false;
                        clineX.AxisValueSerializable = point.Argument;
                        switch (opType)
                        {
                            case 4:
                                clineX.Title.Text = "首检开始";
                                break;
                            case 5:
                                clineX.Title.Text = "过程检开始";
                                break;
                            case 6:
                                clineX.Title.Text = "末检开始";
                                break;
                        }
                        clineX.Title.Alignment = ConstantLineTitleAlignment.Far;
                        clineX.Title.TextColor = Color.Black;
                        clineX.Title.Font = font;

                        clineAxisXs.Add(clineX);
                    }
                }

                if (pointData.OpType == 5)
                {
                    if (ocCount >= 2)
                    {
                        if (ocCount % 2 == 0)
                        {
                            clineAxisXs.Add(
                                new ConstantLine()
                                {
                                    ShowInLegend = false,
                                    AxisValueSerializable = point.Argument,
                                });
                        }
                    }

                    ocCount++;
                }
            }

            chartRainBow.Series.Add(pointMeasureData);

            XYDiagram xyDiagram = chartRainBow.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                double midValue =
                    (data.LCLData.DoubleValue +
                     data.UCLData.DoubleValue) / 2;
                double splitData =
                    (data.USLData.DoubleValue -
                     data.LSLData.DoubleValue) / 4;
                double ucl = data.USLData.DoubleValue - splitData;
                double lcl = data.LSLData.DoubleValue + splitData;

                xyDiagram.DefaultPane.BackColor = Color.Red;

                xyDiagram.AxisX.Label.Font = font;
                xyDiagram.AxisY.Label.Font = font;
                xyDiagram.AxisX.Title.Font = font;

                xyDiagram.AxisX.Title.Visibility = DefaultBoolean.True;
                xyDiagram.AxisX.Title.Text = "时间点";

                xyDiagram.AxisY.Strips.Clear();
                xyDiagram.AxisY.ConstantLines.Clear();
                xyDiagram.AxisX.ConstantLines.Clear();

#region 画中值线
                ConstantLine constantLine = new ConstantLine();
                constantLine.ShowInLegend = false;
                constantLine.AxisValueSerializable = midValue.ToString();
                constantLine.Color = Color.Black;
                constantLine.LineStyle.Thickness = 3;
                constantLine.Title.Text = "M";
                constantLine.Title.Font = font;
                xyDiagram.AxisY.ConstantLines.Add(constantLine);
#endregion

                constantLine = new ConstantLine();
                constantLine.ShowInLegend = false;
                constantLine.AxisValueSerializable = data.UCLData.DoubleValue.ToString();// ucl.ToString();
                constantLine.Color = Color.Black;
                constantLine.LineStyle.Thickness = 2;
                constantLine.Title.Text = "P-C";
                constantLine.Title.Font = font;
                xyDiagram.AxisY.ConstantLines.Add(constantLine);

                constantLine = new ConstantLine();
                constantLine.ShowInLegend = false;
                constantLine.AxisValueSerializable = data.LCLData.DoubleValue.ToString();// lcl.ToString();
                constantLine.Color = Color.Black;
                constantLine.LineStyle.Thickness = 2;
                constantLine.Title.Text = "P-C";
                constantLine.Title.Font = font;
                xyDiagram.AxisY.ConstantLines.Add(constantLine);

                constantLine = new ConstantLine();
                constantLine.ShowInLegend = false;
                constantLine.AxisValueSerializable = data.USLData.DoubleValue.ToString();
                constantLine.Color = Color.Black;
                constantLine.LineStyle.Thickness = 2;
                constantLine.Title.Text = "Tu";
                constantLine.Title.Font = font;
                xyDiagram.AxisY.ConstantLines.Add(constantLine);

                constantLine = new ConstantLine();
                constantLine.ShowInLegend = false;
                constantLine.AxisValueSerializable = data.LSLData.DoubleValue.ToString();
                constantLine.Color = Color.Black;
                constantLine.LineStyle.Thickness = 2;
                constantLine.Title.Text = "Tl";
                constantLine.Title.Font = font;
                xyDiagram.AxisY.ConstantLines.Add(constantLine);

                foreach (ConstantLine lineX in clineAxisXs)
                {
                    xyDiagram.AxisX.ConstantLines.Add(lineX);
                }

                WholeRange wholeRange = xyDiagram.AxisY.WholeRange;
                wholeRange.AlwaysShowZeroLevel = false;
                wholeRange.Auto = false;
                //if (minValue > data.LSLData.DoubleValue)
                //    wholeRange.MinValue = data.LSLData.DoubleValue;
                //else
                //    wholeRange.MinValue = minValue;
                //if (maxValue < data.USLData.DoubleValue)
                //    wholeRange.MaxValue = data.USLData.DoubleValue;
                //else
                //    wholeRange.MaxValue = maxValue;
                wholeRange.MinValue = data.LSLData.DoubleValue;
                wholeRange.MaxValue = data.USLData.DoubleValue;
                wholeRange.SideMarginsValue = splitData;
                wholeRange.AutoSideMargins = false;

                //VisualRange visualRange = xyDiagram.AxisY.VisualRange;
                //visualRange.Auto = false;
                //visualRange.MinValue = data.LSLData.DoubleValue;
                //visualRange.MaxValue = data.USLData.DoubleValue;
                //visualRange.SideMarginsValue = 1;
                //visualRange.AutoSideMargins = true;

                Strip strip = new Strip();
                strip.Color = Color.Yellow;
                strip.MinLimit.AxisValue = data.LSLData.DoubleValue;
                strip.MaxLimit.AxisValue = data.USLData.DoubleValue;
                strip.ShowInLegend = false;
                xyDiagram.AxisY.Strips.Add(strip);

                strip = new Strip();
                strip.Color = Color.Lime;
                strip.MinLimit.AxisValue = data.LCLData.DoubleValue;
                strip.MaxLimit.AxisValue = data.UCLData.DoubleValue;
                strip.ShowInLegend = false;
                xyDiagram.AxisY.Strips.Add(strip);

                //strip = new Strip();
                //strip.Color = Color.Yellow;
                //strip.MinLimit.AxisValue = data.UCLData.DoubleValue;
                //strip.MaxLimit.AxisValue = data.USLData.DoubleValue;
                //strip.ShowInLegend = false;
                //xyDiagram.AxisY.Strips.Add(strip);
            }

            chartRainBow.Legend.Font = font;
#endregion

#region 如果有需要报警的消息，则弹出报警对话框
            switch (data.AnomalyType)
            {
                case 0:
                    #region 如果是正常，则根据首检5片及过程检2片之后启动超时报警
                    if (datas.Count > 0)
                    {
                        bool startCountdown = false;
                        int lastOpType = 0;
                        int numCheckPoint = 0;
                        for (int i = 0; i < datas.Count; i++)
                        {
                            if (lastOpType != datas[i].OpType)
                            {
                                lastOpType = datas[i].OpType;
                                numCheckPoint = 1;
                                startCountdown = false;
                                continue;
                            }
                            else
                                numCheckPoint++;

                            if (lastOpType == 4 && numCheckPoint % 5 == 0)
                            {
                                startCountdown = true;
                            }
                            if (lastOpType == 5 && numCheckPoint % 2 == 0)
                            {
                                startCountdown = true;
                            }
                        }

                        IRAPMessageBox.Instance.Hide();

                        if (startCountdown)
                        {
                            timerWarning.Enabled = false;
                            Thread.Sleep(100);
                            timerWarning.Enabled = true;
                        }
                    }
                    else
                    {
                        IRAPMessageBox.Instance.Hide();
                        timerWarning.Enabled = false;
                    }
#endregion
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    IRAPMessageBox.Instance.Hide();
                    timerWarning.Enabled = false;

                    IRAPMessageBox.Instance.Show(
                    //XtraMessageBox.Show(
                        data.AnomalyDesc,
                        "测量数据异常",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

#if !DEBUG
#region 重置统计过程
                    if (data.C1ID != 0)
                    {
                        WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                        try
                        {
                            IRAPMESClient.Instance.usp_WriteLog_SPCReset(
                                stationUser.CommunityID,
                                data.C1ID,
                                stationUser.SysLogID,
                                out errCode,
                                out errText);
                            WriteLog.Instance.Write(
                                string.Format("({0}){1}", errCode, errText),
                                strProcedureName);
                        }
                        finally
                        {
                            WriteLog.Instance.WriteEndSplitter(strProcedureName);
                        }

                        //DrawChart(stationUser, workUnit, pwoNo, t47LeafID, t216LeafID, t133LeafID, t20LeafID);
                    }
#endregion
#endif

                    break;
            }
#endregion
        }

        private void timerWarning_Tick(object sender, EventArgs e)
        {
            timerWarning.Enabled = false;
            IRAPMessageBox.Instance.Show("请及时进行过程检！", "", MessageBoxIcon.Exclamation);
        }
    }
}
