using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 不良在制品失效情况
    /// </summary>
    public class FailuresOfNGProduct
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 物料叶标识
        /// </summary>
        public int T101LeafID { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string T101Code { get; set; }
        /// <summary>
        /// 部件位置叶标识
        /// </summary>
        public int T110LeafID { get; set; }
        /// <summary>
        /// 部件位置代码
        /// </summary>
        public string T110Code { get; set; }
        /// <summary>
        /// 部件位置名称
        /// </summary>
        public string T110Name { set; get; }
        /// <summary>
        /// 缺陷叶标识
        /// </summary>
        public int T118LeafID { get; set; }
        /// <summary>
        /// 缺陷代码
        /// </summary>
        public string T118Code { get; set; }
        /// <summary>
        /// 失效模式
        /// </summary>
        public string T118Name { get; set; }
        /// <summary>
        /// 根源工序叶标识
        /// </summary>
        public int T216LeafID { get; set; }
        /// <summary>
        /// 根源工序代码
        /// </summary>
        public string T216Code { get; set; }
        /// <summary>
        /// 根源工序名称
        /// </summary>
        public string T216Name { get; set; }
        /// <summary>
        /// 缺陷性质叶标识
        /// </summary>
        public int T183LeafID { get; set; }
        /// <summary>
        /// 缺陷性质代码
        /// </summary>
        public string T183Code { get; set; }
        /// <summary>
        /// 缺陷性质名称
        /// </summary>
        public string T183Name { get; set; }
        /// <summary>
        /// 缺陷责任叶标识
        /// </summary>
        public int T184LeafID { get; set; }
        /// <summary>
        /// 缺陷责任代码
        /// </summary>
        public string T184Code { get; set; }
        /// <summary>
        /// 缺陷责任名称
        /// </summary>
        public string T184Name { get; set; }
        /// <summary>
        /// 缺陷点数
        /// </summary>
        public int CntDefect { get; set; }

        public FailuresOfNGProduct Clone()
        {
            return MemberwiseClone() as FailuresOfNGProduct;
        }
    }
}