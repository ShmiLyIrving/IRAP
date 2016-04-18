using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 工装标准
    /// </summary>
    public class ToolingStandard
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 工装叶标识
        /// </summary>
        public int T210LeafID { get; set; }
        /// <summary>
        /// 工装型号名称
        /// </summary>
        public string ToolingModelName { get; set; }
        /// <summary>
        /// 寿命控制方式（0-不控制；1-按时间；2-按产量）
        /// </summary>
        public int LifeControlMode { get; set; }
        /// <summary>
        /// 寿命限制
        /// </summary>
        public long LifeLimit { get; set; }
        /// <summary>
        /// 是否要求防错
        /// </summary>
        public bool PokaYokeRequired { get; set; }
        /// <summary>
        /// 是否来自模板（供参考）
        /// </summary>
        public bool Reference { get; set; }

        public override string ToString()
        {
            return ToolingModelName;
        }

        public ToolingStandard Clone()
        {
            return MemberwiseClone() as ToolingStandard;
        }
    }
}