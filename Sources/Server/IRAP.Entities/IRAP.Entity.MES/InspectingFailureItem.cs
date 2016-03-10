using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MES
{
    /// <summary>
    /// 检查失效项
    /// </summary>
    public class InspectingFailureItem
    {
        public int T101LeafID { get; set; }
        /// <summary>
        /// 部件位置叶标识
        /// </summary>
        public int T110LeafID { get; set; }
        /// <summary>
        /// 失效模式叶标识
        /// </summary>
        public int T118LeafID { get; set; }
        public int T216LeafID { get; set; }
        /// <summary>
        /// 缺陷分类叶标识
        /// </summary>
        public int T183LeafID { get; set; }
        public int T184LeafID { get; set; }
        /// <summary>
        /// 缺陷点数
        /// </summary>
        public int CntDefect { get; set; }

        public InspectingFailureItem Clone()
        {
            return MemberwiseClone() as InspectingFailureItem;
        }
    }
}