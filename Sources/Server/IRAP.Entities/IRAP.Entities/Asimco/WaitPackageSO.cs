using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.Asimco
{
    public class WaitPackageSO
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 制造订单号
        /// </summary>
        public string MONumber { get; set; }
        /// <summary>
        /// 制造订单行号
        /// </summary>
        public int MOLineNo { get; set; }
        /// <summary>
        /// 产品号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 外箱数量
        /// </summary>
        public long NumberOfCarton { get; set; }
        /// <summary>
        /// 外箱包含内箱数量
        /// </summary>
        public long NumberOfBox { get; set; }
        /// <summary>
        /// 订单总量
        /// </summary>
        public long PlanQty { get; set; }
        /// <summary>
        /// 订单剩余数量
        /// </summary>
        public long LeftQty { get; set; }
        /// <summary>
        /// 已打印数量
        /// </summary>
        public long PrintedQty { get; set; }
        /// <summary>
        /// 车间叶标识
        /// </summary>
        public int T134LeafID { get; set; }
        /// <summary>
        /// 车间/产线代码
        /// </summary>
        public string T134Code { get; set; }
        /// <summary>
        /// 车间名称
        /// </summary>
        public string T134NodeName { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 外箱标签模板叶标识
        /// </summary>
        public int CartonLabelLeafID { get; set; }
        /// <summary>
        /// 内箱标签模板叶标识
        /// </summary>
        public int BoxLabelLeafID { get; set; }
    }
}
