using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Asimco
{
    public class GetFactList_Method
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; } = 0;
        /// <summary>
        /// 制造订单号
        /// </summary>
        public string MONumber { get; set; } = "";
        /// <summary>
        /// 制造订单行号
        /// </summary>
        public int MOLineNo { get; set; } = 0;
        /// <summary>
        /// 工单号
        /// </summary>
        public string PWONo { get; set; } = "";
        /// <summary>
        /// 事实编号
        /// </summary>
        public long FactID { get; set; } = 0;
        /// <summary>
        /// 参数叶标识
        /// </summary>
        public int T20LeafID { get; set; } = 0;
        /// <summary>
        /// 参数代码
        /// </summary>
        public string T20Code { get; set; } = "";
        /// <summary>
        /// 参数名称
        /// </summary>
        public string T20NodeName { get; set; } = "";
        /// <summary>
        /// 参数结果
        /// </summary>
        public long Metric01 { get; set; } = 0;

        public GetFactList_Method Clone()
        {
            return MemberwiseClone() as GetFactList_Method;
        }
    }
}
