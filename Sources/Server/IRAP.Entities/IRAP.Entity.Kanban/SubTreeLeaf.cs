using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.Kanban
{
    public class SubTreeLeaf
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
        /// 实体代码
        /// </summary>
        public string NodeCode { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 父结点标识
        /// </summary>
        public int Father { get; set; }
        /// <summary>
        /// 结点深度（叶）
        /// </summary>
        public int NodeDepth { get; set; }
        /// <summary>
        /// 实体标识
        /// </summary>
        public int EntityID { get; set; }
        /// <summary>
        /// 叶状态
        /// </summary>
        public int LeafStatus { get; set; }
        /// <summary>
        /// 权限控制点
        /// </summary>
        public int CSTRoot { get; set; }
        /// <summary>
        /// 自定义遍历序
        /// </summary>
        public double UDFOrdinal { get; set; }
        /// <summary>
        /// 名称标识
        /// </summary>
        public int NameID { get; set; }
        /// <summary>
        /// 图标标识
        /// </summary>
        public int IconID { get; set; }
        /// <summary>
        /// 助记码
        /// </summary>
        public string HelpMemoryCode { get; set; }
        /// <summary>
        /// 第一检索码
        /// </summary>
        public string SearchCode1 { get; set; }
        /// <summary>
        /// 第二检索码
        /// </summary>
        public string SearchCode2 { get; set; }

        public SubTreeLeaf Clone()
        {
            SubTreeLeaf rlt = MemberwiseClone() as SubTreeLeaf;

            return rlt;
        }
    }
}