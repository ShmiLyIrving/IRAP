using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 产品工艺流程节点
    /// </summary>
    public class ProductProcess
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 当前工序叶标识
        /// </summary>
        public int T216LeafID1 { get; set; }
        /// <summary>
        /// 当前工序代码
        /// </summary>
        public string T216Code1 { get; set; }
        /// <summary>
        /// 当前工序名称
        /// </summary>
        public string T216Name1 { get; set; }
        /// <summary>
        /// 路由控制策略值
        /// </summary>
        public long RoutingCondition { get; set; }
        /// <summary>
        /// 下一工序叶标识
        /// </summary>
        public int T216LeafID2 { get; set; }
        /// <summary>
        /// 下一工序代码
        /// </summary>
        public string T216Code2 { get; set; }
        /// <summary>
        /// 下一工序名称
        /// </summary>
        public string T216Name2 { get; set; }
        /// <summary>
        /// 分支流量低限值（%）
        /// </summary>
        public int MinPercent { get; set; }
        /// <summary>
        /// 分支流量高限值（%）
        /// </summary>
        public int MaxPercent { get; set; }
        /// <summary>
        /// 当前工位在制程中的进度（%）
        /// </summary>
        public int ProcessPercentage { get; set; }
        /// <summary>
        /// 是否引用的模板流程
        /// </summary>
        public bool Reference { get; set; }
        /// <summary>
        /// 标识类型
        /// </summary>
        public int T121LeafID { get; set; }
        /// <summary>
        /// 标识名称
        /// </summary>
        public string T121Name { get; set; }

        public ProductProcess Clone()
        {
            return MemberwiseClone() as ProductProcess;
        }
    }
}