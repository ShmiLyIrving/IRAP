using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// SPC控制图信息
    /// </summary>
    public class EntitySPCChart
    {
        private Quantity lslQuantity = new Quantity();
        private Quantity uslQuantity = new Quantity();
        private Quantity lclQuantity = new Quantity();
        private Quantity uclQuantity = new Quantity();
        private Quantity rlclQuantity = new Quantity();
        private Quantity ruclQuantity = new Quantity();
        private Quantity rbarQuantity = new Quantity();
        private string chartDataXML = "";
        private byte[] companyLogo;
        private Image companyLogoImage = null;

        /// <summary>
        /// 控制图标题
        /// </summary>
        public string ChartTitle { get; set; }
        /// <summary>
        /// 公司Logo
        /// </summary>
        public byte[] CompanyLogo
        {
            get { return companyLogo; }
            set
            {
                companyLogo = value;
                companyLogoImage = Tools.BytesToImage(value);
            }
        }
        /// <summary>
        /// 表单代号
        /// </summary>
        public string FormCode { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string T1002Name { get; set; }
        /// <summary>
        /// 班组名称
        /// </summary>
        public string T1Name { get; set; }
        /// <summary>
        /// 工序代码
        /// </summary>
        public string T216Code { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string T216Name { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string T133Code { get; set; }
        /// <summary>
        /// 操作工工号
        /// </summary>
        public string OperatorCode { get; set; }
        /// <summary>
        /// 操作工姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string T102Name { get; set; }
        /// <summary>
        /// 质量特性
        /// </summary>
        public string T20Name { get; set; }
        /// <summary>
        /// 工程规范(中值±公差)
        /// </summary>
        public string EngineeringSpec { get; set; }
        /// <summary>
        /// 抽样间隔
        /// </summary>
        public string SamplingInterval { get; set; }
        /// <summary>
        /// 单次采样样本大小
        /// </summary>
        public string SampleSize { get; set; }
        /// <summary>
        /// 规范下限
        /// </summary>
        public long LSL
        {
            get { return lslQuantity.IntValue; }
            set { lslQuantity.IntValue = value; }
        }
        /// <summary>
        /// 规范上限
        /// </summary>
        public long USL
        {
            get { return uslQuantity.IntValue; }
            set { uslQuantity.IntValue = value; }
        }
        /// <summary>
        /// 控制下限
        /// </summary>
        public long LCL
        {
            get { return lclQuantity.IntValue; }
            set { lclQuantity.IntValue = value; }
        }
        /// <summary>
        /// 控制上限
        /// </summary>
        public long UCL
        {
            get { return uclQuantity.IntValue; }
            set { uclQuantity.IntValue = value; }
        }
        /// <summary>
        /// 极差控制线下限
        /// </summary>
        public long RLCL
        {
            get { return rlclQuantity.IntValue; }
            set { rlclQuantity.IntValue = value; }
        }
        /// <summary>
        /// 极差控制线上限
        /// </summary>
        public long RUCL
        {
            get { return ruclQuantity.IntValue; }
            set { ruclQuantity.IntValue = value; }
        }
        public long RBar
        {
            get { return rbarQuantity.IntValue; }
            set { rbarQuantity.IntValue = value; }
        }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale
        {
            get { return lslQuantity.Scale; }
            set
            {
                lslQuantity.Scale = value;
                uslQuantity.Scale = value;
                lclQuantity.Scale = value;
                uclQuantity.Scale = value;
                rlclQuantity.Scale = value;
                ruclQuantity.Scale = value;
                rbarQuantity.Scale = value;
            }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return lslQuantity.UnitOfMeasure; }
            set
            {
                lslQuantity.UnitOfMeasure = value;
                uslQuantity.UnitOfMeasure = value;
                lclQuantity.UnitOfMeasure = value;
                uclQuantity.UnitOfMeasure = value;
                rlclQuantity.UnitOfMeasure = value;
                ruclQuantity.UnitOfMeasure = value;
                rbarQuantity.UnitOfMeasure = value;
            }
        }
        /// <summary>
        /// CP值
        /// </summary>
        public decimal CP { get; set; }
        /// <summary>
        /// CPK值
        /// </summary>
        public decimal CPK { get; set; }
        /// <summary>
        /// PP值
        /// </summary>
        public decimal PP { get; set; }
        /// <summary>
        /// PPK值
        /// </summary>
        public decimal PPK { get; set; }
        /// <summary>
        /// 控制线设定日期
        /// </summary>
        public string CLimitSetDate { get; set; }
        /// <summary>
        /// 测量日期
        /// </summary>
        public string MeasuredDate { get; set; }
        /// <summary>
        /// 控制图数据
        /// </summary>
        public string ChartDataXML
        {
            get { return chartDataXML; }
            set { chartDataXML = value; }
        }
        /// <summary>
        /// 异常类型(0=无异常)
        /// 针对彩虹图
        /// 1=首检或调整后采样未达标(少于5件)
        /// 2=首检或调整后未全部落入绿区
        /// 3-首检或调整结束后连续两数据落入同一侧黄区
        /// 4-首检或调整结束后连续两数据落入两边黄区
        /// 5-首检或调整结束后出现数据落入红区
        /// </summary>
        public int AnomalyType { get; set; }
        /// <summary>
        /// 异常描述
        /// </summary>
        public string AnomalyDesc { get; set; }
        /// <summary>
        /// 产品工位关联标识(发出调整指令或设置控
        /// 制线调用存储过程用)
        /// </summary>
        public int C1ID { get; set; }

        [IRAPORMMap(ORMMap = false)]
        public Quantity LSLData
        {
            get { return lslQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity USLData
        {
            get { return uslQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity LCLData
        {
            get { return lclQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity UCLData
        {
            get { return uclQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity RLCLData
        {
            get { return rlclQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity RUCLData
        {
            get { return ruclQuantity; }
        }
        [IRAPORMMap(ORMMap =false)]
        public Quantity RBarData
        {
            get { return rbarQuantity; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Image CompanyLogoImage { get { return companyLogoImage; } }

        public EntitySPCChart Clone()
        {
            EntitySPCChart rlt = MemberwiseClone() as EntitySPCChart;
            rlt.lslQuantity = lslQuantity.Clone();
            rlt.uslQuantity = uslQuantity.Clone();
            rlt.lclQuantity = lclQuantity.Clone();
            rlt.uclQuantity = uclQuantity.Clone();
            rlt.rlclQuantity = rlclQuantity.Clone();
            rlt.ruclQuantity = ruclQuantity.Clone();
            rlt.rbarQuantity = rbarQuantity.Clone();

            return rlt;
        }

        public List<RainbowChartMeasureData> XMLToRainbowChartDataList()
        {
            List<RainbowChartMeasureData> rlt = new List<RainbowChartMeasureData>();

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(chartDataXML);
                XmlNodeList nodes = xmlDoc.SelectNodes("ChartData/Row");
                foreach (XmlNode node in nodes)
                {
                    RainbowChartMeasureData data = new RainbowChartMeasureData();
                    if (node.Attributes["Ordinal"] != null)
                        data.Ordinal = int.Parse(node.Attributes["Ordinal"].Value);
                    else
                        continue;

                    if (node.Attributes["OpType"] != null)
                        data.OpType = int.Parse(node.Attributes["OpType"].Value);
                    else
                        continue;

                    if (node.Attributes["LSL"] != null)
                        data.LSL.IntValue = long.Parse(node.Attributes["LSL"].Value);
                    else
                        continue;

                    if (node.Attributes["USL"] != null)
                        data.USL.IntValue = long.Parse(node.Attributes["USL"].Value);
                    else
                        continue;

                    if (node.Attributes["LCL"] != null)
                        data.LCL.IntValue = long.Parse(node.Attributes["LCL"].Value);
                    else
                        continue;

                    if (node.Attributes["UCL"] != null)
                        data.UCL.IntValue = long.Parse(node.Attributes["UCL"].Value);
                    else
                        continue;

                    if (node.Attributes["Metric01"] != null)
                        data.Metric01.IntValue = long.Parse(node.Attributes["Metric01"].Value);
                    else
                        continue;

                    if (node.Attributes["MeasureTime"] != null)
                        data.MeasureTime = node.Attributes["MeasureTime"].Value;
                    else
                        continue;

                    data.Scale = Scale;
                    data.UnitOfMeasure = UnitOfMeasure;

                    rlt.Add(data);
                }
            }
            catch { rlt = new List<RainbowChartMeasureData>(); }
            finally
            {
                xmlDoc = null;
            }

            return rlt;
        }

        public List<XbarChartMeasureData> XMLToXBarChartDataList()
        {
            List<XbarChartMeasureData> datas = new List<XbarChartMeasureData>();

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(chartDataXML);
                XmlNodeList nodes = xmlDoc.SelectNodes("ChartData/Row");
                foreach (XmlNode node in nodes)
                {
                    XbarChartMeasureData data = new XbarChartMeasureData();
                    if (node.Attributes["Ordinal"] != null)
                        data.Ordinal = int.Parse(node.Attributes["Ordinal"].Value);

                    if (node.Attributes["Metric01"] != null)
                        data.Metric01.IntValue = long.Parse(node.Attributes["Metric01"].Value);

                    if (node.Attributes["FactID"] != null)
                        data.FactID = long.Parse(node.Attributes["FactID"].Value);

                    if (node.Attributes["WFInstanceID"] != null)
                        data.WFInstanceID = node.Attributes["WFInstanceID"].Value;

                    if (node.Attributes["BusinessDate"] != null)
                        data.BusinessDate = node.Attributes["BusinessDate"].Value;

                    data.Scale = Scale;
                    data.UnitOfMeasure = UnitOfMeasure;

                    datas.Add(data);
                }
            }
            catch { datas = new List<XbarChartMeasureData>(); }
            finally
            {
                xmlDoc = null;
            }

            return datas;
        }
    }

    /// <summary>
    /// SPC 彩虹图测量数据
    /// </summary>
    public class RainbowChartMeasureData
    {
        private Quantity lsl = new Quantity();
        private Quantity usl = new Quantity();
        private Quantity lcl = new Quantity();
        private Quantity ucl = new Quantity();
        private Quantity metric01 = new Quantity();

        public int Ordinal { get; set; }
        public int OpType { get; set; }
        public Quantity LSL
        {
            get { return lsl; }
        }
        public Quantity USL
        {
            get { return usl; }
        }
        public Quantity LCL
        {
            get { return lcl; }
        }
        public Quantity UCL
        {
            get { return ucl; }
        }
        public Quantity Metric01
        {
            get { return metric01; }
        }
        public string MeasureTime { get; set; }
        public int Scale
        {
            get { return lsl.Scale; }
            set
            {
                lsl.Scale = value;
                usl.Scale = value;
                lcl.Scale = value;
                ucl.Scale = value;
                metric01.Scale = value;
            }
        }
        public string UnitOfMeasure
        {
            get { return lsl.UnitOfMeasure; }
            set
            {
                lsl.UnitOfMeasure = value;
                usl.UnitOfMeasure = value;
                lcl.UnitOfMeasure = value;
                ucl.UnitOfMeasure = value;
                metric01.UnitOfMeasure = value;
            }
        }

        public RainbowChartMeasureData Clone()
        {
            RainbowChartMeasureData rlt = MemberwiseClone() as RainbowChartMeasureData;
            rlt.lsl = lsl.Clone();
            rlt.usl = usl.Clone();
            rlt.lcl = lcl.Clone();
            rlt.ucl = ucl.Clone();
            rlt.metric01 = metric01.Clone();

            return rlt;
        }
    }

    /// <summary>
    /// SPC XBar-R图测量数据
    /// </summary>
    public class XbarChartMeasureData
    {
        private Quantity metricQuantity = new Quantity();

        public int Ordinal { get; set; }
        public Quantity Metric01
        {
            get { return metricQuantity; }
        }
        public long FactID { get; set; }
        public string WFInstanceID { get; set; }
        public string BusinessDate { get; set; }
        public int Scale
        {
            get { return metricQuantity.Scale; }
            set
            {
                metricQuantity.Scale = value;
            }
        }
        public string UnitOfMeasure
        {
            get { return metricQuantity.UnitOfMeasure; }
            set
            {
                metricQuantity.UnitOfMeasure = value;
            }
        }
        public string BusinessDT
        {
            get { return BusinessDate.Substring(0, 10); }
        }
        public string BusinessTM
        {
            get { return BusinessDate.Substring(11, 8); }
        }

        public XbarChartMeasureData Clone()
        {
            XbarChartMeasureData rlt = MemberwiseClone() as XbarChartMeasureData;
            metricQuantity = metricQuantity.Clone();

            return rlt;
        }
    }
}
