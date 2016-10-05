using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 产线信息
    /// </summary>
    public class ProductionLineInfo
    {
        /// <summary>
        /// 分区键
        /// </summary>
        public long PartitioningKey { get; set; }
        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T134LeafID { get; set; }
        /// <summary>
        /// 产线实体标识
        /// </summary>
        public int T134EntityID { get; set; }
        /// <summary>
        /// 产线代码
        /// </summary>
        public string T134Code { get; set; }
        /// <summary>
        /// 产线替代代码
        /// </summary>
        public string T134AltCode { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        public string T134NodeName { get; set; }
        /// <summary>
        /// 正在生产的产品叶标识
        /// </summary>
        public int T102LeafID_InProduction { get; set; }

        public ProductionLineInfo Clone()
        {
            return MemberwiseClone() as ProductionLineInfo;
        }
    }
}