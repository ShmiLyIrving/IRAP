using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MESRMM
{
    public class PrivateRouterForAProduct
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 当前工位叶标识
        /// </summary>
        public int T107LeafID1 { get; set; }
        /// <summary>
        /// 当前工位代码
        /// </summary>
        public string T107Code1 { get; set; }
        /// <summary>
        /// 当前工位名称
        /// </summary>
        public string T107Name1 { get; set; }
        /// <summary>
        /// 路由条件值
        /// </summary>
        public long RoutingCondition { get; set; }
        /// <summary>
        /// 下一工位叶标识
        /// </summary>
        public int T107LeafID2 { get; set; }
        /// <summary>
        /// 下一工位代码
        /// </summary>
        public string T107Code2 { get; set; }
        /// <summary>
        /// 下一工位名称
        /// </summary>
        public string T107Name2 { get; set; }
        /// <summary>
        /// 是否引用的模板路由表
        /// </summary>
        public bool Reference { get; set; }

        public PrivateRouterForAProduct Clone()
        {
            return MemberwiseClone() as PrivateRouterForAProduct;
        }
    }
}