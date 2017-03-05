using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 测试数据行
    /// </summary>
    public class RSFactTestData
    {
        private Quantity testData01 = new Quantity();
        private Quantity testData02 = new Quantity();
        private Quantity testData03 = new Quantity();
        private Quantity testData04 = new Quantity();
        private Quantity testData05 = new Quantity();
        private Quantity testData06 = new Quantity();
        private Quantity testData07 = new Quantity();
        private Quantity testData08 = new Quantity();
        private Quantity testData09 = new Quantity();
        private Quantity testData10 = new Quantity();
        private Quantity testData11 = new Quantity();
        private Quantity testData12 = new Quantity();
        private Quantity testData13 = new Quantity();
        private Quantity testData14 = new Quantity();
        private Quantity testData15 = new Quantity();
        private Quantity testData16 = new Quantity();
        private Quantity testData17 = new Quantity();
        private Quantity testData18 = new Quantity();
        private Quantity testData19 = new Quantity();
        private Quantity testData20 = new Quantity();
        private Quantity testData21 = new Quantity();
        private Quantity testData22 = new Quantity();
        private Quantity testData23 = new Quantity();
        private Quantity testData24 = new Quantity();
        private Quantity testData25 = new Quantity();
        private Quantity testData26 = new Quantity();
        private Quantity testData27 = new Quantity();
        private Quantity testData28 = new Quantity();
        private Quantity testData29 = new Quantity();
        private Quantity testData30 = new Quantity();
        private Quantity testData31 = new Quantity();
        private Quantity testData32 = new Quantity();

        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 测试项目叶标识
        /// </summary>
        public int T128LeafID { get; set; }
        /// <summary>
        /// 测试项目名称
        /// </summary>
        public string MetricName { get; set; }
        /// <summary>
        /// 低限值
        /// </summary>
        public long LowLimit { get; set; }
        /// <summary>
        /// 通过标准
        /// </summary>
        public string Criterion { get; set; }
        /// <summary>
        /// 高限值
        /// </summary>
        public long HighLimit { get; set; }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale
        {
            get { return testData01.Scale; }
            set
            {
                testData01.Scale = value;
                testData02.Scale = value;
                testData03.Scale = value;
                testData04.Scale = value;
                testData05.Scale = value;
                testData06.Scale = value;
                testData07.Scale = value;
                testData08.Scale = value;
                testData09.Scale = value;
                testData10.Scale = value;
                testData11.Scale = value;
                testData12.Scale = value;
                testData13.Scale = value;
                testData14.Scale = value;
                testData15.Scale = value;
                testData16.Scale = value;
                testData17.Scale = value;
                testData18.Scale = value;
                testData19.Scale = value;
                testData20.Scale = value;
                testData21.Scale = value;
                testData22.Scale = value;
                testData23.Scale = value;
                testData24.Scale = value;
                testData25.Scale = value;
                testData26.Scale = value;
                testData27.Scale = value;
                testData28.Scale = value;
                testData29.Scale = value;
                testData30.Scale = value;
                testData31.Scale = value;
                testData32.Scale = value;
            }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure
        {
            get { return testData01.UnitOfMeasure; }
            set
            {
                testData01.UnitOfMeasure = value;
                testData02.UnitOfMeasure = value;
                testData03.UnitOfMeasure = value;
                testData04.UnitOfMeasure = value;
                testData05.UnitOfMeasure = value;
                testData06.UnitOfMeasure = value;
                testData07.UnitOfMeasure = value;
                testData08.UnitOfMeasure = value;
                testData09.UnitOfMeasure = value;
                testData10.UnitOfMeasure = value;
                testData11.UnitOfMeasure = value;
                testData12.UnitOfMeasure = value;
                testData13.UnitOfMeasure = value;
                testData14.UnitOfMeasure = value;
                testData15.UnitOfMeasure = value;
                testData16.UnitOfMeasure = value;
                testData17.UnitOfMeasure = value;
                testData18.UnitOfMeasure = value;
                testData19.UnitOfMeasure = value;
                testData20.UnitOfMeasure = value;
                testData21.UnitOfMeasure = value;
                testData22.UnitOfMeasure = value;
                testData23.UnitOfMeasure = value;
                testData24.UnitOfMeasure = value;
                testData25.UnitOfMeasure = value;
                testData26.UnitOfMeasure = value;
                testData27.UnitOfMeasure = value;
                testData28.UnitOfMeasure = value;
                testData29.UnitOfMeasure = value;
                testData30.UnitOfMeasure = value;
                testData31.UnitOfMeasure = value;
                testData32.UnitOfMeasure = value;
            }
        }
        /// <summary>
        /// 单项测试结论(P= 通过 F= 失败)
        /// </summary>
        public string Conclusion { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 第01通道测试值
        /// </summary>
        public long Metric01
        {
            get { return testData01.IntValue; }
            set { testData01.IntValue = value; }
        }
        /// <summary>
        /// 第02通道测试值
        /// </summary>
        public long Metric02
        {
            get { return testData02.IntValue; }
            set { testData02.IntValue = value; }
        }
        /// <summary>
        /// 第03通道测试值
        /// </summary>
        public long Metric03
        {
            get { return testData03.IntValue; }
            set { testData03.IntValue = value; }
        }
        /// <summary>
        /// 第04通道测试值
        /// </summary>
        public long Metric04
        {
            get { return testData04.IntValue; }
            set { testData04.IntValue = value; }
        }
        /// <summary>
        /// 第05通道测试值
        /// </summary>
        public long Metric05
        {
            get { return testData05.IntValue; }
            set { testData05.IntValue = value; }
        }
        /// <summary>
        /// 第06通道测试值
        /// </summary>
        public long Metric06
        {
            get { return testData06.IntValue; }
            set { testData06.IntValue = value; }
        }
        /// <summary>
        /// 第07通道测试值
        /// </summary>
        public long Metric07
        {
            get { return testData07.IntValue; }
            set { testData07.IntValue = value; }
        }
        /// <summary>
        /// 第08通道测试值
        /// </summary>
        public long Metric08
        {
            get { return testData08.IntValue; }
            set { testData08.IntValue = value; }
        }
        /// <summary>
        /// 第09通道测试值
        /// </summary>
        public long Metric09
        {
            get { return testData09.IntValue; }
            set { testData09.IntValue = value; }
        }
        /// <summary>
        /// 第10通道测试值
        /// </summary>
        public long Metric10
        {
            get { return testData10.IntValue; }
            set { testData10.IntValue = value; }
        }
        /// <summary>
        /// 第11通道测试值
        /// </summary>
        public long Metric11
        {
            get { return testData11.IntValue; }
            set { testData11.IntValue = value; }
        }
        /// <summary>
        /// 第12通道测试值
        /// </summary>
        public long Metric12
        {
            get { return testData12.IntValue; }
            set { testData12.IntValue = value; }
        }
        /// <summary>
        /// 第13通道测试值
        /// </summary>
        public long Metric13
        {
            get { return testData13.IntValue; }
            set { testData13.IntValue = value; }
        }
        /// <summary>
        /// 第14通道测试值
        /// </summary>
        public long Metric14
        {
            get { return testData14.IntValue; }
            set { testData14.IntValue = value; }
        }
        /// <summary>
        /// 第15通道测试值
        /// </summary>
        public long Metric15
        {
            get { return testData15.IntValue; }
            set { testData15.IntValue = value; }
        }
        /// <summary>
        /// 第16通道测试值
        /// </summary>
        public long Metric16
        {
            get { return testData16.IntValue; }
            set { testData16.IntValue = value; }
        }
        /// <summary>
        /// 第17通道测试值
        /// </summary>
        public long Metric17
        {
            get { return testData17.IntValue; }
            set { testData17.IntValue = value; }
        }
        /// <summary>
        /// 第18通道测试值
        /// </summary>
        public long Metric18
        {
            get { return testData18.IntValue; }
            set { testData18.IntValue = value; }
        }
        /// <summary>
        /// 第19通道测试值
        /// </summary>
        public long Metric19
        {
            get { return testData19.IntValue; }
            set { testData19.IntValue = value; }
        }
        /// <summary>
        /// 第20通道测试值
        /// </summary>
        public long Metric20
        {
            get { return testData20.IntValue; }
            set { testData20.IntValue = value; }
        }
        /// <summary>
        /// 第21通道测试值
        /// </summary>
        public long Metric21
        {
            get { return testData21.IntValue; }
            set { testData21.IntValue = value; }
        }
        /// <summary>
        /// 第22通道测试值
        /// </summary>
        public long Metric22
        {
            get { return testData22.IntValue; }
            set { testData22.IntValue = value; }
        }
        /// <summary>
        /// 第23通道测试值
        /// </summary>
        public long Metric23
        {
            get { return testData23.IntValue; }
            set { testData23.IntValue = value; }
        }
        /// <summary>
        /// 第24通道测试值
        /// </summary>
        public long Metric24
        {
            get { return testData24.IntValue; }
            set { testData24.IntValue = value; }
        }
        /// <summary>
        /// 第25通道测试值
        /// </summary>
        public long Metric25
        {
            get { return testData25.IntValue; }
            set { testData25.IntValue = value; }
        }
        /// <summary>
        /// 第26通道测试值
        /// </summary>
        public long Metric26
        {
            get { return testData26.IntValue; }
            set { testData26.IntValue = value; }
        }
        /// <summary>
        /// 第27通道测试值
        /// </summary>
        public long Metric27
        {
            get { return testData27.IntValue; }
            set { testData27.IntValue = value; }
        }
        /// <summary>
        /// 第28通道测试值
        /// </summary>
        public long Metric28
        {
            get { return testData28.IntValue; }
            set { testData28.IntValue = value; }
        }
        /// <summary>
        /// 第29通道测试值
        /// </summary>
        public long Metric29
        {
            get { return testData29.IntValue; }
            set { testData29.IntValue = value; }
        }
        /// <summary>
        /// 第30通道测试值
        /// </summary>
        public long Metric30
        {
            get { return testData30.IntValue; }
            set { testData30.IntValue = value; }
        }
        /// <summary>
        /// 第31通道测试值
        /// </summary>
        public long Metric31
        {
            get { return testData31.IntValue; }
            set { testData31.IntValue = value; }
        }
        /// <summary>
        /// 第32通道测试值
        /// </summary>
        public long Metric32
        {
            get { return testData32.IntValue; }
            set { testData32.IntValue = value; }
        }

        #region 加工以后的测试数据
        /// <summary>
        /// 参数标准
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public string StandardString
        {
            get
            {
                double doubleLow = LowLimit / Math.Pow(10, Scale);
                double doubleHigh = HighLimit / Math.Pow(10, Scale);

                string low = "";
                string high = "";

                if (Scale > 0)
                {
                    string strFormat = "";
                    low = doubleLow.ToString("0." + strFormat.PadLeft(Scale, '0'));
                    high = doubleHigh.ToString("0." + strFormat.PadLeft(Scale, '0'));
                }
                else
                {
                    low = doubleLow.ToString("0");
                    high = doubleHigh.ToString("0");
                }

                switch (Criterion.ToUpper())
                {
                    case "EQ":
                        return string.Format("＝ {0}{1}", low, UnitOfMeasure);
                    case "NE":
                        return string.Format("≠ {0}{1}", low, UnitOfMeasure);
                    case "GELE":
                        return string.Format("{0} ≤值≤ {1} {2}", low, high, UnitOfMeasure);
                    case "GTLT":
                        return string.Format("{0} ＜值＜ {1} {2}", low, high, UnitOfMeasure);
                    case "GTLE":
                        return string.Format("{0} ＜值≤ {1} {2}", low, high, UnitOfMeasure);
                    case "GELT":
                        return string.Format("{0} ≤值＜ {1} {2}", low, high, UnitOfMeasure);
                    case "BOOL":
                        return "通过";
                    case "GE":
                        return string.Format("{0} ≤值 {1}", low, UnitOfMeasure);
                    case "LE":
                        return string.Format("{0} ≥值 {1}", high, UnitOfMeasure);
                    case "GT":
                        return string.Format("{0} <值 {1}", low, UnitOfMeasure);
                    case "LT":
                        return string.Format("{0} >值 {1}", high, UnitOfMeasure);
                    default:
                        return string.Format("未定义的标准代码[{0}]", Criterion);
                }
            }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData01
        {
            get { return testData01; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData02
        {
            get { return testData02; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData03
        {
            get { return testData03; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData04
        {
            get { return testData04; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData05
        {
            get { return testData05; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData06
        {
            get { return testData06; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData07
        {
            get { return testData07; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData08
        {
            get { return testData08; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData09
        {
            get { return testData09; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData10
        {
            get { return testData10; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData11
        {
            get { return testData11; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData12
        {
            get { return testData12; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData13
        {
            get { return testData13; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData14
        {
            get { return testData14; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData15
        {
            get { return testData15; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData16
        {
            get { return testData16; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData17
        {
            get { return testData17; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData18
        {
            get { return testData18; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData19
        {
            get { return testData19; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData20
        {
            get { return testData20; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData21
        {
            get { return testData21; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData22
        {
            get { return testData22; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData23
        {
            get { return testData23; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData24
        {
            get { return testData24; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData25
        {
            get { return testData25; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData26
        {
            get { return testData26; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData27
        {
            get { return testData27; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData28
        {
            get { return testData28; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData29
        {
            get { return testData29; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData30
        {
            get { return testData30; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData31
        {
            get { return testData31; }
        }
        [IRAPORMMap(ORMMap = false)]
        public Quantity TestData32
        {
            get { return testData32; }
        }
        #endregion

        public RSFactTestData Clone()
        {
            RSFactTestData rlt = MemberwiseClone() as RSFactTestData;

            rlt.testData01 = testData01.Clone();
            rlt.testData02 = testData02.Clone();
            rlt.testData03 = testData03.Clone();
            rlt.testData04 = testData04.Clone();
            rlt.testData05 = testData05.Clone();
            rlt.testData06 = testData06.Clone();
            rlt.testData07 = testData07.Clone();
            rlt.testData08 = testData08.Clone();
            rlt.testData09 = testData09.Clone();
            rlt.testData10 = testData10.Clone();
            rlt.testData11 = testData11.Clone();
            rlt.testData12 = testData12.Clone();
            rlt.testData13 = testData13.Clone();
            rlt.testData14 = testData14.Clone();
            rlt.testData15 = testData15.Clone();
            rlt.testData16 = testData16.Clone();
            rlt.testData17 = testData17.Clone();
            rlt.testData18 = testData18.Clone();
            rlt.testData19 = testData19.Clone();
            rlt.testData20 = testData20.Clone();
            rlt.testData21 = testData21.Clone();
            rlt.testData22 = testData22.Clone();
            rlt.testData23 = testData23.Clone();
            rlt.testData24 = testData24.Clone();
            rlt.testData25 = testData25.Clone();
            rlt.testData26 = testData26.Clone();
            rlt.testData27 = testData27.Clone();
            rlt.testData28 = testData28.Clone();
            rlt.testData29 = testData29.Clone();
            rlt.testData30 = testData30.Clone();
            rlt.testData31 = testData31.Clone();
            rlt.testData32 = testData32.Clone();

            return rlt;
        }
    }
}
