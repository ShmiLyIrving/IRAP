using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 工序生产准备标准
    /// </summary>
    public class PreparingStandard
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 生产准备项目叶标识
        /// </summary>
        public int T20LeafID { get; set; }
        /// <summary>
        /// 生产准备项目名称
        /// </summary>
        public string ItemName { get; set; }
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
        /// 记录方式（0=不记录 1=换型时记录）
        /// </summary>
        public int RecordingMode { get; set; }
        /// <summary>
        /// 是否来自模板(供参考)
        /// </summary>
        public bool Reference { get; set; }

        public PreparingStandard Clone()
        {
            return MemberwiseClone() as PreparingStandard;
        }
    }
}