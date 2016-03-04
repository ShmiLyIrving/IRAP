using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 工艺参数标准
    /// </summary>
    public class MethodStandard : CustomStandard
    {
        /// <summary>
        /// 参数记录方式：
        /// 0-不采集；
        /// 1-按时间；
        /// 2-按产量
        /// </summary>
        public int RecordingMode { get; set; }
        /// <summary>
        /// 参数采样周期(秒/件)
        /// </summary>
        public long SamplingCycle { get; set; }
        /// <summary>
        /// 实时数据库数据源连接标识
        /// </summary>
        public int RTDBDSLinkID { get; set; }
        /// <summary>
        /// 实时数据库采集点标识
        /// </summary>
        public string RTDBTagName { get; set; }
        /// <summary>
        /// 是否来自模板(供参考)
        /// </summary>
        public bool Reference { get; set; }

        public new MethodStandard Clone()
        {
            return MemberwiseClone() as MethodStandard;
        }
    }
}