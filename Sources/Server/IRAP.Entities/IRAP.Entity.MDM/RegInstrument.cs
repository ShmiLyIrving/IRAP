using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 注册的测量仪表信息
    /// </summary>
    public class RegInstrument
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 量仪IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 量仪设备编号
        /// </summary>
        public string InstrumentCode { get; set; }
        /// <summary>
        /// 测量的特性参数叶标识
        /// </summary>
        public int T20LeafID { get; set; }
        /// <summary>
        /// 策略的特性参数名称
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// 数据报文长度
        /// </summary>
        public int LengthOfDataMsg { get; set; }
        /// <summary>
        /// 放大数量级（相对与特性参数检测标准）
        /// </summary>
        public int Scale { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string UnitOfMeasure { get; set; }

        public RegInstrument Clone()
        {
            return MemberwiseClone() as RegInstrument;
        }
    }
}