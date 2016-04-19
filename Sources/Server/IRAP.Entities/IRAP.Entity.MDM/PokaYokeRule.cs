using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 工序生产防错规则
    /// </summary>
    public class PokaYokeRule
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 防错规则叶标识
        /// </summary>
        public int T230LeafID { get; set; }
        /// <summary>
        /// 防错规则编号
        /// </summary>
        public string T230Code { get; set; }
        /// <summary>
        /// 防错规则名称
        /// </summary>
        public string T230Name { get; set; }
        /// <summary>
        /// 防错控制级别
        /// </summary>
        public int ControlLevel { get; set; }
        /// <summary>
        /// 低限控制值
        /// </summary>
        public long ControlLimit_Low { get; set; }
        /// <summary>
        /// 高限控制值
        /// </summary>
        public long ControlLimit_High { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// 是否来自模板(供参考)
        /// </summary>
        public bool Reference { get; set; }

        public PokaYokeRule Clone()
        {
            return MemberwiseClone() as PokaYokeRule;
        }
    }
}