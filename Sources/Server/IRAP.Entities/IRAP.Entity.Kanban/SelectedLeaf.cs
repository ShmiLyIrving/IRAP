using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    /// <summary>
    /// 叶
    /// </summary>
    public class SelectedLeaf
    {
        /// <summary>
        /// 遍历序
        /// </summary>
        public double Ordinal { get; set; }
        /// <summary>
        /// 叶状态
        /// </summary>
        public int LeafStatus { get; set; }
        /// <summary>
        /// 实体代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 实体标识
        /// </summary>
        public int EntityID { get; set; }
        /// <summary>
        /// 叶标识
        /// </summary>
        public int LeafID { get; set; }
        /// <summary>
        /// 树标识
        /// </summary>
        public int TreeID { get; set; }

        /// <summary>
        /// 分区键
        /// </summary>
        public long PartitioningKey { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public int Father { get; set; }

        public SelectedLeaf Clone()
        {
            SelectedLeaf rlt = MemberwiseClone() as SelectedLeaf;

            return rlt;
        }
    }
}