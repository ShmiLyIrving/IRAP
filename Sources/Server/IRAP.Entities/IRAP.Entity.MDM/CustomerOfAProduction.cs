using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    /// <summary>
    /// 产品供给客户信息
    /// </summary>
    public class CustomerOfAProduction
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
        /// 产品代码
        /// </summary>
        public string T102Code { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string T102Name { get; set; }
        /// <summary>
        /// 客户叶标识
        /// </summary>
        public int T105LeafID { get; set; }
        /// <summary>
        /// 客户代码
        /// </summary>
        public string T105Code { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string T105Name { get; set; }
        /// <summary>
        /// 客户物料编码
        /// </summary>
        public string CPartNumber { get; set; }
        /// <summary>
        /// 销售编码
        /// </summary>
        public string SalePartNumber { get; set; }

        public CustomerOfAProduction Clone()
        {
            return MemberwiseClone() as CustomerOfAProduction;
        }

        public override string ToString()
        {
            return string.Format("[{0}]{1}", T105Code, T105Name);
        }
    }
}