using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    /// <summary>
    /// 质量问题分析Pareto图记录
    /// </summary>
    public class LineQualityProblemInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 缺陷代码
        /// </summary>
        public string DefectCode { get; set; }
        /// <summary>
        /// 缺陷类型
        /// </summary>
        public string DefectType { get; set; }
        /// <summary>
        /// 缺陷计数
        /// </summary>
        public int DefectCounts { get; set; }
        /// <summary>
        /// 缺陷占比
        /// </summary>
        public decimal ParetoRatio { get; set; }
        /// <summary>
        /// 总产出数
        /// </summary>
        public decimal TotalOutput { get; set; }
        /// <summary>
        /// 缺陷率(废品率)
        /// </summary>
        public decimal DefectRate { get; set; }

        public LineQualityProblemInfo Clone()
        {
            LineQualityProblemInfo rlt = MemberwiseClone() as LineQualityProblemInfo;

            return rlt;
        }
    }
}