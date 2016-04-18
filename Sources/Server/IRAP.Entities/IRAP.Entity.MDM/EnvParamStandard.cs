using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 工序生产环境参数标准
    /// </summary>
    public class EnvParamStandard
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 环境参数叶标识
        /// </summary>
        public int T20LeafID { get; set; }
        /// <summary>
        /// 环境参数名称
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
        /// 采集方式：0-不采集；1-定时采集
        /// </summary>
        public int CollectingMoe { get; set; }
        /// <summary>
        /// 采样周期(秒)
        /// </summary>
        public int CollectingCycle { get; set; }
        /// <summary>
        /// 是否来自模板
        /// </summary>
        public bool Reference { get; set; }

        public EnvParamStandard Clone()
        {
            return MemberwiseClone() as EnvParamStandard;
        }
    }
}