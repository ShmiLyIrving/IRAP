using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.FVS
{
    /// <summary>
    /// 生产异常问题根源类型
    /// </summary>
    public class AnomalyCauseType
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 根源叶标识
        /// </summary>
        public int T144LeafID { get; set; }
        /// <summary>
        /// 根源名称
        /// </summary>
        public string T144Name { get; set; }
        /// <summary>
        /// 是否存在此根源的停线问题
        /// </summary>
        public bool Existence { get; set; }

        public AnomalyCauseType Clone()
        {
            return MemberwiseClone() as AnomalyCauseType;
        }
    }
}