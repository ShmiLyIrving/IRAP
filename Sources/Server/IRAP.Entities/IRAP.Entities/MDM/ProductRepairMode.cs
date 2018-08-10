using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    public class ProductRepairMode
    {
        /// <summary>
        /// 分区键
        /// </summary>
        public long PartitioningKey { get; set; }
        /// <summary>
        /// 叶标识
        /// </summary>
        public int LeafID { get; set; }
        /// <summary>
        /// 实体标识
        /// </summary>
        public int EntityID { get; set; }
        /// <summary>
        /// 实体代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public string LeafName { get; set; }
        /// <summary>
        /// 叶状态
        /// </summary>
        public int LeafStatus { get; set; }

        public ProductRepairMode Clone()
        {
            return MemberwiseClone() as ProductRepairMode;
        }
    }
}
