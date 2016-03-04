using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IRAP.Global;
using IRAPShared;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 质量标准
    /// </summary>
    public class QualityStandard : CustomStandard
    {
        /// <summary>
        /// 首检应检数
        /// </summary>
        public long QtyForFirstInspection { get; set; }
        /// <summary>
        /// 过程检应检数（每次）
        /// </summary>
        public long QtyforInProcessInspection { get; set; }
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

        public new QualityStandard Clone()
        {
            QualityStandard rlt = MemberwiseClone() as QualityStandard;

            return rlt;
        }
    }
}