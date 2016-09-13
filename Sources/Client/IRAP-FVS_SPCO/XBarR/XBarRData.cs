using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAP.Entity.MES;

namespace IRAP_FVS_SPCO.XBarR
{
    /// <summary>
    /// XBar-R控制图的数据
    /// </summary>
    public class XBarRData
    {
        private int ordinal;
        private Quantity xbar = new Quantity();
        private Quantity r = new Quantity();
        private List<XbarChartMeasureData> srcData = new List<XbarChartMeasureData>();
        private int srcDataCnt = 0;

        public XBarRData(int ordinal)
        {
            this.ordinal = ordinal;
        }

        /// <summary>
        /// 采样数据组序号
        /// </summary>
        public int Ordinal
        {
            get { return ordinal; }
        }
        /// <summary>
        /// 当前组中测量值的平均值
        /// </summary>
        public Quantity XBar
        {
            get { return xbar; }
        }
        /// <summary>
        /// 当前组中测量值的极差值
        /// </summary>
        public Quantity R
        {
            get { return r; }
        }
        /// <summary>
        /// 当前组中测量值的最大 FactID
        /// </summary>
        public long LastFactID
        {
            get
            {
                return srcData[srcDataCnt - 1].FactID;
            }
        }
        public List<XbarChartMeasureData> Source
        {
            get { return srcData; }
        }

        public void Add(XbarChartMeasureData measureData)
        {
            if (srcDataCnt >= XBarRConstant.Instance.CntOfPerGroup)
            {
                throw new Exception(string.Format("已经获得 {0} 个测量值！", srcDataCnt));
            }
            else
            {
                srcData.Add(measureData);
                srcDataCnt++;

                if (srcDataCnt == XBarRConstant.Instance.CntOfPerGroup)
                {
                    long sum = 0;
                    long minValue = srcData[0].Metric01.IntValue;
                    long maxValue = srcData[0].Metric01.IntValue;

                    for (int i = 0; i < srcData.Count; i++)
                    {
                        sum += srcData[i].Metric01.IntValue;
                        if (minValue > srcData[i].Metric01.DoubleValue)
                            minValue = srcData[i].Metric01.IntValue;
                        if (maxValue < srcData[i].Metric01.DoubleValue)
                            maxValue = srcData[i].Metric01.IntValue;
                    }

                    xbar.IntValue = sum / XBarRConstant.Instance.CntOfPerGroup;
                    r.IntValue = maxValue - minValue;

                    xbar.Scale = measureData.Metric01.Scale;
                    xbar.UnitOfMeasure = measureData.Metric01.UnitOfMeasure;

                    r.Scale = measureData.Metric01.Scale;
                    r.UnitOfMeasure = measureData.Metric01.UnitOfMeasure;
                }
            }
        }
    }
}
