using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;

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
        private XBarR.XBarRChartType chartType = XBarR.XBarRChartType.Control;
        /// <summary>
        /// 统计过程判异规则
        /// </summary>
        private int spcRule = 0;
        private long lastFactID = 0;
        private List<XBarSourceData> measureDatas = new List<XBarSourceData>();

        public ucXBarRChart()
        {
            InitializeComponent();

            vgrdMeasureDatas.DataSource = measureDatas;
        }

        /// <summary>
        /// 判异准则规则
        /// </summary>
        public int SPCRule
        {
            get { return spcRule; }
            set { spcRule = value; }
        }

        /// <summary>
        /// 绘制 XBar-R 图
        /// </summary>
        /// <param name="stationUser"></param>
        /// <param name="workUnit"></param>
        /// <param name="pwoNo"></param>
        /// <param name="lcl"></param>
        /// <param name="ucl"></param>
        /// <param name="rlcl"></param>
        /// <param name="rucl"></param>
        /// <param name="t20LeafID"></param>
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

            #region 确定当前的 XBar-R 图是研究用图还是控制用图
            if (chartData.LCL == 0 &&
                chartData.UCL == 0 &&
                chartData.RLCL == 0 &&
                chartData.RUCL == 0)
                chartType = XBarR.XBarRChartType.Study;

            lblChartType.Visible = chartType == 0;
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

            #region 获取原始测量数据，根据每组测量数生成 XBar 和 R 图的点，并绘制图形
            List<XbarChartMeasureData> srcDatas = chartData.XMLToXBarChartDataList();
            List<XBarR.XBarRData> datas = new List<XBarR.XBarRData>();

            int ordinal = 1;
            XBarR.XBarRData pointData = new XBarR.XBarRData(ordinal++);
            measureDatas.Clear();
            for (int i = 1; i <= srcDatas.Count; i++)
            {
                pointData.Add(srcDatas[i - 1]);

                if (i % XBarR.XBarRConstant.Instance.CntOfPerGroup == 0)
                {
                    datas.Add(pointData);

                    // 将每组的原始测量值数据插入表格中
                    measureDatas.Add(new XBarSourceData()
                    {
                        Ordinal = pointData.Ordinal,
                        Metric01 = pointData.Source[0].Metric01.DoubleValue,
                        Metric02 = pointData.Source[1].Metric01.DoubleValue,
                        Metric03 = pointData.Source[2].Metric01.DoubleValue,
                        Metric04 = pointData.Source[3].Metric01.DoubleValue,
                        MeasureDate = pointData.Source[3].BusinessDT,
                        MeasureTime = pointData.Source[3].BusinessTM,
                    });

                    pointData = new XBarR.XBarRData(ordinal++);
                }
            }
            vgrdMeasureDatas.RefreshDataSource();

            DrawXBar(chartData, datas, font);
            DrawR(chartData, datas, font);
            #endregion

            Quantity xbarLCL = new Quantity()
            {
                Scale = chartData.Scale,
                UnitOfMeasure = chartData.UnitOfMeasure,
            };
            Quantity xbarUCL = xbarLCL.Clone();
            Quantity rLCL = xbarLCL.Clone();
            Quantity rUCL = xbarLCL.Clone();
            Quantity rBar = xbarLCL.Clone();

            switch (chartType)
            {
                case XBarR.XBarRChartType.Study:
                    #region 研究用控制图在收集满 25 组数据后，计算控制用控制图所需要的上下限
                    if (datas.Count == 25)
                    {
                        CalcLimitControlLine(
                            datas,
                            ref xbarLCL,
                            ref xbarUCL,
                            ref rLCL,
                            ref rUCL,
                            ref rBar);

                        #region 对 8 项判异准则进行判异
                        bool[] xbarCriteriaPassed = new bool[8];
                        bool[] rCriteriaPassed = new bool[8];

                        for (int i = 0; i < 8; i++)
                        {
                            xbarCriteriaPassed[i] = true;
                            rCriteriaPassed[i] = true;
                        }

                        XBarR.XBarRCriteria xbarCriteria =
                            new XBarR.XBarRCriteria(
                                xbarLCL,
                                xbarUCL,
                                (xbarLCL.DoubleValue + xbarUCL.DoubleValue) / 2,
                                spcRule);
                        XBarR.XBarRCriteria rCriteria =
                            new XBarR.XBarRCriteria(rLCL, rUCL, rBar.DoubleValue, spcRule);

                        List<long> wait4CriteriaXBarPoints = new List<long>();
                        List<long> wait4CriteriaRPoints = new List<long>();
                        for (int i = 0; i < datas.Count; i++)
                        {
                            #region 判异准则 1
                            xbarCriteriaPassed[0] =
                                xbarCriteriaPassed[0] &&
                                xbarCriteria.Criteria1Passed(datas[i].XBar.IntValue);
                            rCriteriaPassed[0] =
                                rCriteriaPassed[0] &&
                                rCriteria.Criteria1Passed(datas[i].R.IntValue);
                            #endregion

                            #region 判异准则 2
                            if (i + 6 < datas.Count)
                            {
                                wait4CriteriaXBarPoints.Clear();
                                wait4CriteriaRPoints.Clear();

                                for (int j = i; j < i + 6; j++)
                                {
                                    wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                    wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                                }

                                xbarCriteriaPassed[1] =
                                    xbarCriteriaPassed[1] &&
                                    xbarCriteria.Criteria2Passed(wait4CriteriaXBarPoints);
                                rCriteriaPassed[1] =
                                    rCriteriaPassed[1] &&
                                    rCriteria.Criteria2Passed(wait4CriteriaRPoints);
                            }
                            #endregion

                            #region 判异准则 3
                            if (i + 7 < datas.Count)
                            {
                                wait4CriteriaXBarPoints.Clear();
                                wait4CriteriaRPoints.Clear();

                                for (int j = i; j < i + 7; j++)
                                {
                                    wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                    wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                                }

                                xbarCriteriaPassed[2] =
                                    xbarCriteriaPassed[2] &&
                                    xbarCriteria.Criteria3Passed(wait4CriteriaXBarPoints);
                                rCriteriaPassed[2] =
                                    rCriteriaPassed[2] &&
                                    rCriteria.Criteria3Passed(wait4CriteriaRPoints);
                            }
                            #endregion

                            #region 判异准则 4
                            if (i + 14 < datas.Count)
                            {
                                wait4CriteriaXBarPoints.Clear();
                                wait4CriteriaRPoints.Clear();

                                for (int j = i; j < i + 14; j++)
                                {
                                    wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                    wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                                }

                                xbarCriteriaPassed[3] =
                                    xbarCriteriaPassed[3] &&
                                    xbarCriteria.Criteria4Passed(wait4CriteriaXBarPoints);
                                rCriteriaPassed[3] =
                                    rCriteriaPassed[3] &&
                                    rCriteria.Criteria4Passed(wait4CriteriaRPoints);
                            }
                            #endregion

                            #region 判异准则 5
                            if (i + 3 < datas.Count)
                            {
                                wait4CriteriaXBarPoints.Clear();
                                wait4CriteriaRPoints.Clear();

                                for (int j = i; j < i + 3; j++)
                                {
                                    wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                    wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                                }

                                xbarCriteriaPassed[4] =
                                    xbarCriteriaPassed[4] &&
                                    xbarCriteria.Criteria5Passed(wait4CriteriaXBarPoints);
                                rCriteriaPassed[4] =
                                    rCriteriaPassed[4] &&
                                    rCriteria.Criteria5Passed(wait4CriteriaRPoints);
                            }
                            #endregion

                            #region 判异准则 6
                            if (i + 5 < datas.Count)
                            {
                                wait4CriteriaXBarPoints.Clear();
                                wait4CriteriaRPoints.Clear();

                                for (int j = i; j < i + 5; j++)
                                {
                                    wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                    wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                                }

                                xbarCriteriaPassed[5] =
                                    xbarCriteriaPassed[5] &&
                                    xbarCriteria.Criteria6Passed(wait4CriteriaXBarPoints);
                                rCriteriaPassed[5] =
                                    rCriteriaPassed[5] &&
                                    rCriteria.Criteria6Passed(wait4CriteriaRPoints);
                            }
                            #endregion

                            #region 判异准则 7
                            if (i + 15 < datas.Count)
                            {
                                wait4CriteriaXBarPoints.Clear();
                                wait4CriteriaRPoints.Clear();

                                for (int j = i; j < i + 15; j++)
                                {
                                    wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                    wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                                }

                                xbarCriteriaPassed[6] =
                                    xbarCriteriaPassed[6] &&
                                    xbarCriteria.Criteria7Passed(wait4CriteriaXBarPoints);
                                rCriteriaPassed[6] =
                                    rCriteriaPassed[6] &&
                                    rCriteria.Criteria7Passed(wait4CriteriaRPoints);
                            }
                            #endregion

                            #region  判异准则 8
                            if (i + 8 < datas.Count)
                            {
                                wait4CriteriaXBarPoints.Clear();
                                wait4CriteriaRPoints.Clear();

                                for (int j = i; j < i + 8; j++)
                                {
                                    wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                    wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                                }

                                xbarCriteriaPassed[7] =
                                    xbarCriteriaPassed[7] &&
                                    xbarCriteria.Criteria8Passed(wait4CriteriaXBarPoints);
                                rCriteriaPassed[7] =
                                    rCriteriaPassed[7] &&
                                    rCriteria.Criteria8Passed(wait4CriteriaRPoints);
                            }
                            #endregion
                        }
                        #endregion

                        bool criteriaPassed = true;
                        for (int i = 0; i < 8; i++)
                        {
                            criteriaPassed =
                                criteriaPassed &&
                                xbarCriteriaPassed[i] &&
                                rCriteriaPassed[i];
                        }

                        if (!criteriaPassed)
                        {
                            #region 判异未通过，显示判异结果，并调用存储过程标示重新开始采集数据
                            using (XBarR.frmXBarRCriteriaMessage formMessage = new XBarR.frmXBarRCriteriaMessage())
                            {
                                formMessage.SetCriteriaResult(xbarCriteriaPassed, rCriteriaPassed);
                                formMessage.ShowDialog();
                            }
#if !DEBUG
                            if (chartData.C1ID != 0)
                            {
                                int errCode = 0;
                                string errText = "";

                                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                                try
                                {
                                    IRAPMESClient.Instance.usp_WriteLog_SPCReset(
                                        stationUser.CommunityID,
                                        chartData.C1ID,
                                        373565,
                                        stationUser.SysLogID,
                                        out errCode,
                                        out errText);
                                    WriteLog.Instance.Write(
                                        string.Format("({0}){1}", errCode, errText),
                                        strProcedureName);
                                    if (errCode != 0)
                                        IRAPMessageBox.Instance.Show(
                                            errText,
                                            "XBar-R 图重置数据采集",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                                }
                            }
#endif
                            #endregion

#if !DEBUG
                            #region 清除 XBar 图和 R 图中的内容
                            chartXBar.Series[0].Points.Clear();
                            chartR.Series[0].Points.Clear();
                            #endregion
#endif
                        }
                        else
                        {
                            #region 判异通过，计算 Cpk 值，若大于 1.33 则保存 LCL, UCL, RLCL, RUCL，否则重新开始采集数据
                            double currentCpk =
                                CalcCpk(
                                    chartData.LSLData,
                                    chartData.USLData,
                                    srcDatas,
                                    datas);
                            if (currentCpk >= 1.33)
                            {
                                // 以下调用存储过程，保存得到的 LCL, UCL, RLCL, RUCL
                                int errCode = 0;
                                string errText = "";

                                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                                try
                                {
                                    IRAPMESClient.Instance.usp_WriteLog_SPCCtrlLineSet(
                                        stationUser.CommunityID,
                                        chartData.C1ID,
                                        373565,
                                        xbarLCL.IntValue,
                                        xbarUCL.IntValue,
                                        rLCL.IntValue,
                                        rUCL.IntValue,
                                        rBar.IntValue,
                                        stationUser.SysLogID,
                                        out errCode,
                                        out errText);
                                    WriteLog.Instance.Write(
                                        string.Format("({0}){1}", errCode, errText),
                                        strProcedureName);
                                    if (errCode != 0)
                                        IRAPMessageBox.Instance.Show(
                                            errText,
                                            "XBar-R 图重置数据采集",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                                    else
                                    {
                                        IRAPMessageBox.Instance.Show(
                                            "XBar-R 图的控制线已经分析并保存完毕！",
                                            "研究用控制图",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                                        SaveC1IDLastFactID(
                                            chartData.C1ID,
                                            datas[datas.Count - 1].LastFactID);
                                    }
                                }
                                finally
                                {
                                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                                }
                            }
                            else
                            {
                                IRAPMessageBox.Instance.Show(
                                    string.Format(
                                        "当前 Cpk 值为 [{0}]，小于 1.33，请分析原因并采取措施后重新采集数据！",
                                        currentCpk.ToString("0.00")),
                                    "研究用控制图",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

#if !DEBUG
                                // 以下调用存储过程，重新采集数据
                                if (chartData.C1ID != 0)
                                {
                                    int errCode = 0;
                                    string errText = "";

                                    WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                                    try
                                    {
                                        IRAPMESClient.Instance.usp_WriteLog_SPCReset(
                                            stationUser.CommunityID,
                                            chartData.C1ID,
                                            373565,
                                            stationUser.SysLogID,
                                            out errCode,
                                            out errText);
                                        WriteLog.Instance.Write(
                                            string.Format("({0}){1}", errCode, errText),
                                            strProcedureName);
                                        if (errCode != 0)
                                            IRAPMessageBox.Instance.Show(
                                                errText,
                                                "XBar-R 图重置数据采集",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                                    }
                                    finally
                                    {
                                        WriteLog.Instance.WriteEndSplitter(strProcedureName);
                                    }
                                }

                                // 清除 XBar 图和 R 图中的内容
                                chartXBar.Series[0].Points.Clear();
                                chartR.Series[0].Points.Clear();
#endif
                            }
                            #endregion
                        }
                    }
                    #endregion
                    break;
                case XBarR.XBarRChartType.Control:
                    #region 控制用控制图直接绘制各上下限控制线，和 A/B/C 三个区域，并进行判异

                    #region 绘制 XBar 的中线
                    DrawAxisYConstantLine(
                        chartXBar,
                        (chartData.LCLData.DoubleValue + chartData.UCLData.DoubleValue) / 2,
                        string.Format(
                            "CL: {0}",
                            (chartData.LCLData.DoubleValue + chartData.UCLData.DoubleValue) / 2),
                        Color.Black,
                        Color.White);
                    #endregion

                    #region 绘制 XBar 图的上下控制线
                    SetDiagramWholeRanger(
                        chartXBar,
                        chartData.LCLData.DoubleValue,
                        chartData.UCLData.DoubleValue,
                        2);
                    DrawAsisYStrip(
                        chartXBar,
                        chartData.LCLData.DoubleValue,
                        (chartData.LCLData.DoubleValue  + chartData.UCLData.DoubleValue) / 2,
                        chartData.UCLData.DoubleValue);
                    DrawAxisYConstantLine(
                        chartXBar,
                        chartData.LCLData.DoubleValue,
                        string.Format(
                            "LCL: {0}",
                            chartData.LCLData.DoubleValue),
                        Color.Black,
                        Color.Black);
                    DrawAxisYConstantLine(
                        chartXBar,
                        chartData.UCLData.DoubleValue,
                        string.Format(
                            "UCL: {0}",
                            chartData.UCLData.DoubleValue),
                        Color.Black,
                        Color.Black);
                    #endregion

                    #region 绘制 R 图的中线
                    DrawAxisYConstantLine(
                        chartR,
                        chartData.RBarData.DoubleValue,
                        string.Format(
                            "CL: {0}",
                            chartData.RBarData.DoubleValue),
                        Color.Black,
                        Color.White);
                    #endregion

                    #region 绘制 R 图的上下控制线
                    SetDiagramWholeRanger(
                        chartR,
                        chartData.RLCLData.DoubleValue,
                        chartData.RUCLData.DoubleValue,
                        10);
                    DrawAsisYStrip(
                        chartR,
                        chartData.RLCLData.DoubleValue,
                        chartData.RBarData.DoubleValue,
                        chartData.RUCLData.DoubleValue);
                    DrawAxisYConstantLine(
                        chartR,
                        chartData.RLCLData.DoubleValue,
                        string.Format(
                            "LCL: {0}",
                            chartData.RLCLData.DoubleValue),
                        Color.Black,
                        Color.Black);
                    DrawAxisYConstantLine(
                        chartR,
                        chartData.RUCLData.DoubleValue,
                        string.Format(
                            "UCL: {0}",
                            chartData.RUCLData.DoubleValue),
                        Color.Black,
                        Color.Black);
                    #endregion

                    #region 对新增的数据组进行判异
                    lastFactID = GetC1IDLastFactID(chartData.C1ID);
                    if (datas.Count > 0 && lastFactID != datas[datas.Count - 1].LastFactID)
                    {
                        #region 对 8 项判异准则进行判异
                        bool[] xbarCriteriaPassed = new bool[8];
                        bool[] rCriteriaPassed = new bool[8];

                        for (int i = 0; i < 8; i++)
                        {
                            xbarCriteriaPassed[i] = true;
                            rCriteriaPassed[i] = true;
                        }

                        XBarR.XBarRCriteria xbarCriteria =
                            new XBarR.XBarRCriteria(
                                chartData.LCLData,
                                chartData.UCLData,
                                (chartData.LCLData.DoubleValue + chartData.UCLData.DoubleValue) / 2,
                                spcRule);
                        XBarR.XBarRCriteria rCriteria =
                            new XBarR.XBarRCriteria(
                                chartData.RLCLData,
                                chartData.RUCLData,
                                chartData.RBarData.DoubleValue,
                                spcRule);

                        List<long> wait4CriteriaXBarPoints = new List<long>();
                        List<long> wait4CriteriaRPoints = new List<long>();

                        int index = datas.Count - 1;

                        #region 判异准则 1
                        xbarCriteriaPassed[0] =
                            xbarCriteriaPassed[0] &&
                            xbarCriteria.Criteria1Passed(datas[index].XBar.IntValue);
                        rCriteriaPassed[0] =
                            rCriteriaPassed[0] &&
                            rCriteria.Criteria1Passed(datas[index].R.IntValue);
                        #endregion

                        #region 判异准则 2
                        if (datas.Count >= 6)
                        {
                            wait4CriteriaXBarPoints.Clear();
                            wait4CriteriaRPoints.Clear();

                            for (int j = index - 5; j <= index; j++)
                            {
                                wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                            }

                            xbarCriteriaPassed[1] =
                                xbarCriteriaPassed[1] &&
                                xbarCriteria.Criteria2Passed(wait4CriteriaXBarPoints);
                            rCriteriaPassed[1] =
                                rCriteriaPassed[1] &&
                                rCriteria.Criteria2Passed(wait4CriteriaRPoints);
                        }
                        #endregion

                        #region 判异准则 3
                        if (datas.Count >= 7)
                        {
                            wait4CriteriaXBarPoints.Clear();
                            wait4CriteriaRPoints.Clear();

                            for (int j = index - 6; j <= index; j++)
                            {
                                wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                            }

                            xbarCriteriaPassed[2] =
                                xbarCriteriaPassed[2] &&
                                xbarCriteria.Criteria3Passed(wait4CriteriaXBarPoints);
                            rCriteriaPassed[2] =
                                rCriteriaPassed[2] &&
                                rCriteria.Criteria3Passed(wait4CriteriaRPoints);
                        }
                        #endregion

                        #region 判异准则 4
                        if (datas.Count >= 14)
                        {
                            wait4CriteriaXBarPoints.Clear();
                            wait4CriteriaRPoints.Clear();

                            for (int j = index - 13; j <= index; j++)
                            {
                                wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                            }

                            xbarCriteriaPassed[3] =
                                xbarCriteriaPassed[3] &&
                                xbarCriteria.Criteria4Passed(wait4CriteriaXBarPoints);
                            rCriteriaPassed[3] =
                                rCriteriaPassed[3] &&
                                rCriteria.Criteria4Passed(wait4CriteriaRPoints);
                        }
                        #endregion

                        #region 判异准则 5
                        if (datas.Count >= 3)
                        {
                            wait4CriteriaXBarPoints.Clear();
                            wait4CriteriaRPoints.Clear();

                            for (int j = index - 2; j <= index; j++)
                            {
                                wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                            }

                            xbarCriteriaPassed[4] =
                                xbarCriteriaPassed[4] &&
                                xbarCriteria.Criteria5Passed(wait4CriteriaXBarPoints);
                            rCriteriaPassed[4] =
                                rCriteriaPassed[4] &&
                                rCriteria.Criteria5Passed(wait4CriteriaRPoints);
                        }
                        #endregion

                        #region 判异准则 6
                        if (datas.Count >= 5)
                        {
                            wait4CriteriaXBarPoints.Clear();
                            wait4CriteriaRPoints.Clear();

                            for (int j = index - 4; j <= index; j++)
                            {
                                wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                            }

                            xbarCriteriaPassed[5] =
                                xbarCriteriaPassed[5] &&
                                xbarCriteria.Criteria6Passed(wait4CriteriaXBarPoints);
                            rCriteriaPassed[5] =
                                rCriteriaPassed[5] &&
                                rCriteria.Criteria6Passed(wait4CriteriaRPoints);
                        }
                        #endregion

                        #region 判异准则 7
                        if (datas.Count >= 15)
                        {
                            wait4CriteriaXBarPoints.Clear();
                            wait4CriteriaRPoints.Clear();

                            for (int j = index - 14; j <= index; j++)
                            {
                                wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                            }

                            xbarCriteriaPassed[6] =
                                xbarCriteriaPassed[6] &&
                                xbarCriteria.Criteria7Passed(wait4CriteriaXBarPoints);
                            rCriteriaPassed[6] =
                                rCriteriaPassed[6] &&
                                rCriteria.Criteria7Passed(wait4CriteriaRPoints);
                        }
                        #endregion

                        #region  判异准则 8
                        if (datas.Count >= 8)
                        {
                            wait4CriteriaXBarPoints.Clear();
                            wait4CriteriaRPoints.Clear();

                            for (int j = index - 7; j <= index; j++)
                            {
                                wait4CriteriaXBarPoints.Add(datas[j].XBar.IntValue);
                                wait4CriteriaRPoints.Add(datas[j].R.IntValue);
                            }

                            xbarCriteriaPassed[7] =
                                xbarCriteriaPassed[7] &&
                                xbarCriteria.Criteria8Passed(wait4CriteriaXBarPoints);
                            rCriteriaPassed[7] =
                                rCriteriaPassed[7] &&
                                rCriteria.Criteria8Passed(wait4CriteriaRPoints);
                        }
                        #endregion

                        bool criteriaPassed = true;
                        for (int i = 0; i < 8; i++)
                        {
                            criteriaPassed =
                                criteriaPassed &&
                                xbarCriteriaPassed[i] &&
                                rCriteriaPassed[i];
                        }

                        if (!criteriaPassed)
                        {
                            #region 判异未通过，显示判异结果
                            using (XBarR.frmXBarRCriteriaMessage formMessage = new XBarR.frmXBarRCriteriaMessage())
                            {
                                formMessage.SetCriteriaResult(xbarCriteriaPassed, rCriteriaPassed);
                                formMessage.ShowDialog();
                            }
                            #endregion
                        }
                        #endregion

                        SaveC1IDLastFactID(chartData.C1ID, datas[datas.Count - 1].LastFactID);
                    }
                    #endregion

                    double cp = CalcCp(chartData.LSLData, chartData.USLData, datas);
                    double cpk = CalcCpk(chartData.LSLData, chartData.USLData, srcDatas, datas);
                    double pp = CalcPp(chartData.LSLData, chartData.USLData, srcDatas);
                    double ppk = CalcPpk(chartData.LSLData, chartData.USLData, srcDatas, datas);

                    lblCp.Text = string.Format("Cp : {0}", cp.ToString("0.0000"));
                    lblCpk.Text = string.Format("Cpk: {0}", cpk.ToString("0.0000"));
                    lblPp.Text = string.Format("Pp : {0}", pp.ToString("0.0000"));
                    lblPpk.Text = string.Format("Ppk: {0}", ppk.ToString("0.0000"));

                    #endregion
                    break; 
            }
        }

        private long GetC1IDLastFactID(long c1ID)
        {
            if (ConfigurationManager.AppSettings[c1ID.ToString()] != null)
            {
                long rlt = 0;
                Int64.TryParse(
                    ConfigurationManager.AppSettings[c1ID.ToString()].ToString(),
                    out rlt);
                return rlt;
            }
            else
                return 0;
        }

        private void SaveC1IDLastFactID(long c1ID, long factID)
        {
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[c1ID.ToString()] == null)
                config.AppSettings.Settings.Add(c1ID.ToString(), factID.ToString());
            else
                config.AppSettings.Settings[c1ID.ToString()].Value = factID.ToString();

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 计算平均值
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        private double Avg(List<double> datas)
        {
            double rlt = 0;
            for (int i = 0; i < datas.Count; i++)
                rlt += datas[i];
            return rlt / datas.Count;
        }

        /// <summary>
        /// 计算 Cp
        /// </summary>
        /// <returns></returns>
        private double CalcCp(
            Quantity lsl,
            Quantity usl,
            List<XBarR.XBarRData> xbarPoints)
        {
            double t = usl.DoubleValue - lsl.DoubleValue;
            double rBar = 0;
            double cp = 0;

            List<double> avgRDatas = new List<double>();
            for (int i = 0; i < xbarPoints.Count; i++)
            {
                avgRDatas.Add(xbarPoints[i].R.DoubleValue);
            }
            rBar = Avg(avgRDatas);

            cp = t / (6 * (rBar / XBarR.XBarRConstant.Instance.D2));
            return cp;
        }
        /// <summary>
        /// 计算 Cpk 值
        /// </summary>
        /// <param name="lsl"></param>
        /// <param name="usl"></param>
        /// <param name="xbarPoints"></param>
        /// <returns></returns>
        private double CalcCpk(
            Quantity lsl, 
            Quantity usl, 
            List<XbarChartMeasureData> measureDatas,
            List<XBarR.XBarRData> xbarPoints)
        {
            double t = usl.DoubleValue-lsl.DoubleValue;
            double middle = (usl.DoubleValue + lsl.DoubleValue) / 2;
            double xbarBar = 0;
            double rBar = 0;
            double cp = 0;
            double cpk = 0;

            List<double> avgXbarDatas = new List<double>();
            for (int i = 0; i < measureDatas.Count; i++)
            {
                avgXbarDatas.Add(measureDatas[i].Metric01.DoubleValue);
            }
            xbarBar = Avg(avgXbarDatas);

            List<double> avgRDatas = new List<double>();
            for (int i = 0; i < xbarPoints.Count; i++)
            {
                avgRDatas.Add(xbarPoints[i].R.DoubleValue);
            }
            rBar = Avg(avgRDatas);

            //cp = t / (6 * (rBar / XBarR.XBarRConstant.Instance.D2));
            cp = CalcCp(lsl, usl, xbarPoints);
            cpk = (1 - (2 * Math.Abs(middle - xbarBar)) / t) * cp;
            return cpk;
        }
        /// <summary>
        ///  计算 Pp 
        /// </summary>
        /// <param name="lsl"></param>
        /// <param name="usl"></param>
        /// <param name="measureDatas"></param>
        /// <returns></returns>
        private double CalcPp(
            Quantity lsl,
            Quantity usl,
            List<XbarChartMeasureData> measureDatas)
        {
            double t = usl.DoubleValue - lsl.DoubleValue;
            double sigma = 0;
            List<double> datas = new List<double>();

            double xbar = 0;
            foreach (XbarChartMeasureData data in measureDatas)
            {
                datas.Add(data.Metric01.DoubleValue);
            }
            xbar = Avg(datas);

            double sum = 0;
            double denominator = measureDatas.Count - 1;
            for (int i = 0; i < measureDatas.Count; i++)
            {
                sum += Math.Pow(measureDatas[i].Metric01.DoubleValue - xbar, 2) / denominator;
            }
            sigma = Math.Sqrt(sum);

            return t / (6 * sigma);
        }
        /// <summary>
        /// 计算 Ppk
        /// </summary>
        /// <param name="lsl"></param>
        /// <param name="usl"></param>
        /// <param name="measureDatas"></param>
        /// <param name="xbarPoints"></param>
        /// <returns></returns>
        private double CalcPpk(
            Quantity lsl,
            Quantity usl,
            List<XbarChartMeasureData> measureDatas,
            List<XBarR.XBarRData> xbarPoints)
        {
            double t = usl.DoubleValue - lsl.DoubleValue;
            double middle = (usl.DoubleValue + lsl.DoubleValue) / 2;
            double xbarBar = 0;
            double pp = 0;
            double ppk = 0;

            List<double> avgXbarDatas = new List<double>();
            for (int i = 0; i < measureDatas.Count; i++)
            {
                avgXbarDatas.Add(measureDatas[i].Metric01.DoubleValue);
            }
            xbarBar = Avg(avgXbarDatas);

            pp = CalcPp(lsl, usl, measureDatas);
            ppk = (1 - (2 * Math.Abs(middle - xbarBar)) / t) * pp;
            return ppk;
        }

        /// <summary>
        /// 计算并绘制 XBar 图和 R 图的上下限控制线
        /// </summary>
        /// <param name="xbarPoints"></param>
        private void CalcLimitControlLine(
            List<XBarR.XBarRData> xbarPoints, 
            ref Quantity lcl, 
            ref Quantity ucl,
            ref Quantity rlcl,
            ref Quantity rucl,
            ref Quantity rBar)
        {
            lcl.IntValue = 0;
            ucl.IntValue = 0;

            if (xbarPoints.Count < 25)
                return;

            List<double> xbarDatas = new List<double>();
            List<double> rDatas = new List<double>();
            double maxXBar = 0;
            double minXBar = 999999999;
            double maxR = 0;
            double minR = 999999999;
            foreach (XBarR.XBarRData point in xbarPoints)
            {
                xbarDatas.Add(point.XBar.DoubleValue);
                rDatas.Add(point.R.DoubleValue);

                maxXBar = Math.Max(maxXBar, point.XBar.DoubleValue);
                minXBar = Math.Min(minXBar, point.XBar.DoubleValue);
                maxR = Math.Max(maxR, point.R.DoubleValue);
                minR = Math.Min(minR, point.R.DoubleValue);
            }

            #region 计算 XBarBar
            Quantity xbarbarLine = lcl.Clone();
            xbarbarLine.DoubleValue = Avg(xbarDatas);
            #endregion

            #region 计算 RBar
            rBar = lcl.Clone();
            rBar.DoubleValue = Avg(rDatas);
            #endregion

            #region 计算 XBar 图的 LCL 和 UCL
            lcl.DoubleValue = xbarbarLine.DoubleValue - XBarR.XBarRConstant.Instance.A2 * rBar.DoubleValue;
            ucl.DoubleValue = xbarbarLine.DoubleValue + XBarR.XBarRConstant.Instance.A2 * rBar.DoubleValue;
            #endregion

            #region 计算 R 图的 LCL 和 UCL
            rlcl = lcl.Clone();
            rucl = lcl.Clone();
            rlcl.DoubleValue = XBarR.XBarRConstant.Instance.D3 * rBar.DoubleValue;
            rucl.DoubleValue = XBarR.XBarRConstant.Instance.D4 * rBar.DoubleValue;
            #endregion

            if (maxXBar < ucl.DoubleValue)
                maxXBar = ucl.DoubleValue;
            if (minXBar > lcl.DoubleValue)
                minXBar = lcl.DoubleValue;
            if (maxR < rucl.DoubleValue)
                maxR = rucl.DoubleValue;
            if (minR > rlcl.DoubleValue)
                minR = rlcl.DoubleValue;

            #region 绘制 XBar 的中线
            DrawAxisYConstantLine(
                chartXBar, 
                xbarbarLine.DoubleValue, 
                string.Format("CL: {0}", xbarbarLine.DoubleValue),
                Color.Black,
                Color.White);
            #endregion

            #region 绘制 XBar 图的上下控制线
            SetDiagramWholeRanger(chartXBar, maxXBar, minXBar, 2);// lcl.DoubleValue, ucl.DoubleValue);
            DrawAsisYStrip(chartXBar, lcl.DoubleValue, xbarbarLine.DoubleValue, ucl.DoubleValue);
            DrawAxisYConstantLine(
                chartXBar, 
                lcl.DoubleValue, 
                string.Format("LCL: {0}", lcl.DoubleValue),
                Color.Black,
                Color.Black);
            DrawAxisYConstantLine(
                chartXBar, 
                ucl.DoubleValue, 
                string.Format("UCL: {0}", ucl.DoubleValue),
                Color.Black,
                Color.Black);
            #endregion

            #region 绘制 R 图的中线
            DrawAxisYConstantLine(
                chartR,
                rBar.DoubleValue,
                string.Format("CL: {0}", rBar.DoubleValue),
                Color.Black,
                Color.White);
            #endregion

            #region 绘制 R 图的上下控制线
            SetDiagramWholeRanger(chartR, maxR, minR, 10); //rlcl.DoubleValue, rucl.DoubleValue);
            DrawAsisYStrip(chartR, rlcl.DoubleValue, rBar.DoubleValue, rucl.DoubleValue);
            DrawAxisYConstantLine(
                chartR, 
                rlcl.DoubleValue, 
                string.Format("LCL: {0}", rlcl.DoubleValue),
                Color.Black,
                Color.Black);
            DrawAxisYConstantLine(
                chartR, 
                rucl.DoubleValue, 
                string.Format("UCL: {0}", rucl.DoubleValue),
                Color.Black,
                Color.Black);
            #endregion
        }

        /// <summary>
        /// 绘制 Y 轴的分割线
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="lineValue"></param>
        /// <param name="lineColor"></param>
        private void DrawAxisYConstantLine(
            ChartControl chart,
            double lineValue,
            string lineCatpion,
            Color lineColor,
            Color titleColor)
        {
            XYDiagram xyDiagram = chart.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                ConstantLine constantLine = new ConstantLine();
                constantLine.ShowInLegend = false;
                constantLine.AxisValueSerializable = lineValue.ToString();
                constantLine.Color = lineColor;
                constantLine.LineStyle.Thickness = 2;
                constantLine.Title.Visible = true;
                constantLine.Title.Text = lineCatpion;
                constantLine.Title.Alignment = ConstantLineTitleAlignment.Near;
                constantLine.Title.TextColor = titleColor;
                xyDiagram.AxisY.ConstantLines.Add(constantLine);
            }
        }

        /// <summary>
        /// 绘制 Y 轴的色块
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        private void DrawAsisYStrip(
            ChartControl chart,
            double minValue,
            double midValue,
            double maxValue)
        {
            XYDiagram xyDiagram = chart.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                double splitterWidth1 = (maxValue - midValue) / 3;
                double splitterWidth2 = (midValue - minValue) / 3;

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
                strip.MinLimit.AxisValue = minValue + splitterWidth2;
                strip.MaxLimit.AxisValue = maxValue - splitterWidth1;
                xyDiagram.AxisY.Strips.Add(strip);

                strip = new Strip()
                {
                    Color = Color.FromArgb(0, 192, 0),
                    ShowInLegend = false,
                };
                strip.MinLimit.AxisValue = minValue + splitterWidth2 * 2;
                strip.MaxLimit.AxisValue = maxValue - splitterWidth1 * 2;
                xyDiagram.AxisY.Strips.Add(strip);
            }
        }

        /// <summary>
        /// 设置图形 Y 轴坐标范围
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        private void SetDiagramWholeRanger(
            ChartControl chart,
            double minValue,
            double maxValue,
            double sideMarginsValue)
        {
            XYDiagram xyDiagram = chart.Diagram as XYDiagram;
            if (xyDiagram != null)
            {
                WholeRange wholeRange = xyDiagram.AxisY.WholeRange;
                wholeRange.AlwaysShowZeroLevel = false;
                wholeRange.Auto = false;
                wholeRange.MinValue = minValue;// - (maxValue - minValue) / 2;
                wholeRange.MaxValue = maxValue;// + (maxValue - minValue) / 2;
                wholeRange.SideMarginsValue = sideMarginsValue;
                wholeRange.AutoSideMargins = false;
            }
        }

        /// <summary>
        /// 绘制 XBar 图
        /// </summary>
        /// <param name="data"></param>
        /// <param name="datas"></param>
        /// <param name="font"></param>
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
                ShowInLegend = false,
            };
            LineSeriesView view = new LineSeriesView();
            view.Color = Color.Blue;
            view.PointMarkerOptions.BorderColor = Color.Blue;
            view.PointMarkerOptions.Size = 7;       // 点的大小
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
                xyDiagram.AxisX.Title.Text = "子组";

                if (chartType == XBarR.XBarRChartType.Study)
                {
                    xyDiagram.AxisY.Strips.Clear();
                    xyDiagram.AxisY.ConstantLines.Clear();

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

        /// <summary>
        /// 绘制 R 图
        /// </summary>
        /// <param name="data"></param>
        /// <param name="datas"></param>
        /// <param name="font"></param>
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
                ShowInLegend = false,
            };
            LineSeriesView view = new LineSeriesView();
            view.Color = Color.Red;
            view.PointMarkerOptions.BorderColor = Color.Red;
            view.PointMarkerOptions.Size = 7;       // 点的大小
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
                xyDiagram.AxisX.Title.Text = "子组";

                if (chartType == XBarR.XBarRChartType.Study)
                {
                    xyDiagram.AxisY.Strips.Clear();
                    xyDiagram.AxisY.ConstantLines.Clear();
                }
            }

            chartR.Legend.Font = font;
            #endregion
        }

        private void ucXBarRChart_Resize(object sender, EventArgs e)
        {
            chartR.Height = pnlCharts.Height / 3;
        }
    }

    internal class XBarSourceData
    {
        public int Ordinal { get; set; }
        public double Metric01 { get; set; }
        public double Metric02 { get; set; }
        public double Metric03 { get; set; }
        public double Metric04 { get; set; }
        public string MeasureDate { get; set; }
        public string MeasureTime { get; set; }
    }
}