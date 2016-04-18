using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 质量检查标准
    /// </summary>
    public class InspectionStandard
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
        /// 首检应检数
        /// </summary>
        public long QtyForFirstInspection { get; set; }
        /// <summary>
        /// 过程检应检数(每次)
        /// </summary>
        public long QtyForInProcessInspection { get; set; }
        /// <summary>
        /// 过程检批量
        /// </summary>
        public long InProcessInspectionBatchSize { get; set; }
        /// <summary>
        /// 末检应检数
        /// </summary>
        public long QtyForLastInspection { get; set; }
        /// <summary>
        /// 是否全检
        /// </summary>
        public bool FullInspection { get; set; }
        /// <summary>
        /// 是否来自模板引用数据
        /// </summary>
        public bool Reference { get; set; }

        public InspectionStandard Clone()
        {
            return MemberwiseClone() as InspectionStandard;
        }
   }
}