using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.SSO
{
    /// <summary>
    /// 工艺流程或工作流程
    /// </summary>
    public class ProcessInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 产品叶标识
        /// </summary>
        public int T102LeafID { get; set; }
        /// <summary>
        /// 产品实体标识
        /// </summary>
        public int T102EntityID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string T102NodeName { get; set; }
        /// <summary>
        /// 产品族叶标识
        /// </summary>
        public int T132LeafID { get; set; }
        /// <summary>
        /// 流程叶标识
        /// </summary>
        public int T120LeafID { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        public string T120NodeName { get; set; }
        /// <summary>
        /// 工段叶标识
        /// </summary>
        public int T124LeafID { get; set; }
        /// <summary>
        /// 工段名称
        /// </summary>
        public string T124NodeName { get; set; }
        /// <summary>
        /// 工位叶标识
        /// </summary>
        public int T107LeafID { get; set; }
        /// <summary>
        /// 是否在生产
        /// </summary>
        public int InProduction { get; set; }
        /// <summary>
        /// 操作工人数
        /// </summary>
        public decimal NumOperators { get; set; }
        /// <summary>
        /// 实际节拍时间(ms)
        /// </summary>
        public int ActualTaktTime { get; set; }

        public override string ToString()
        {
            return T120NodeName;
        }

        public ProcessInfo Clone()
        {
            return MemberwiseClone() as ProcessInfo;
        }
    }
}
