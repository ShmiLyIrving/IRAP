using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    /// <summary>
    /// Andon指示灯状态
    /// </summary>
    public class AndonLightStatus
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 告警灯描述
        /// </summary>
        public string LightDesc { get; set; }
        /// <summary>
        /// 是否仅仅是逻辑灯
        /// </summary>
        public bool LogicalOnly { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Available { get; set; }
        /// <summary>
        /// 告警灯状态（0-灭；1-亮；2-闪）
        /// </summary>
        public int LightStatus { get; set; }

        public AndonLightStatus Clone()
        {
            AndonLightStatus rlt = MemberwiseClone() as AndonLightStatus;

            return rlt;
        }
    }
}