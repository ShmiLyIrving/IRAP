using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Kanban
{
    public class SelectedLeafEx
    {
        /// <summary>
        /// 分区键
        /// </summary>
        public long PartitioningKey { get; set; }
        /// <summary>
        /// 树标识
        /// </summary>
        public int TreeID { get; set; }
        /// <summary>
        /// 叶标识
        /// </summary>
        public int LeafID { get; set; }
        /// <summary>
        /// 实体标识
        /// </summary>
        public int EntityID { get; set; }
        /// <summary>
        /// 标识代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 叶名称
        /// </summary>
        public string LeafName { get; set; }
        /// <summary>
        /// 叶状态
        /// </summary>
        public int LeafStatus { get; set; }
        /// <summary>
        /// 遍历序号
        /// </summary>
        public double Ordinal { get; set; }

        public SelectedLeafEx Clone()
        {
            return MemberwiseClone() as SelectedLeafEx;
        }

        public override string ToString()
        {
            return LeafName;
        }
    }
}
