using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAPShared;

namespace IRAP.Entity.MDM
{
    public class CustomStandard
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 参数叶标识
        /// </summary>
        public int T20LeafID { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// 低限值
        /// </summary>
        public long LowLimit { get; set; }
        /// <summary>
        /// 标准
        /// </summary>
        public string Criterion { get; set; }
        /// <summary>
        /// 高限值
        /// </summary>
        public long HighLimit { get; set; }
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
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
        /// <summary>
        /// 中值
        /// </summary>
        [IRAPORMMap(ORMMap = false)]
        public string MiddleValue
        {
            get
            {
                switch (Criterion.ToUpper())
                {
                    case "GELE":
                    case "GTLT":
                    case "GTLE":
                    case "GELT":
                        double doubleLow = LowLimit / Math.Pow(10, Scale);
                        double doubleHigh = HighLimit / Math.Pow(10, Scale);
                        string middleValue = "";

                        if (Scale > 0)
                        {
                            string strFormat = "";
                            middleValue = ((doubleLow + doubleHigh) / 2).ToString("0." + strFormat.PadLeft(Scale, '0'));
                        }
                        else
                        {
                            middleValue = ((doubleLow + doubleHigh) / 2).ToString("0");
                        }

                        return string.Format("{0} {1}", middleValue, UnitOfMeasure);
                    default:
                        return "";
                }
            }
        }

        public CustomStandard Clone()
        {
            return MemberwiseClone() as CustomStandard;
        }
    }
}